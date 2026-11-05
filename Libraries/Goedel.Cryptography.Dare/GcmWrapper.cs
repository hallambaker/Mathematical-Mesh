using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Dare;

using static System.Net.WebRequestMethods;

namespace Goedel.Cryptography.Dare;


public interface IChunk {


    public int InputChunk { get; }
    public int OutputChunk { get; }

    public int Chunk(ReadOnlySpan<byte> plaintext, Span<byte> ciphertext);

    public int Finalize(ReadOnlySpan<byte> plaintext, Span<byte> ciphertext);



    public byte[] Transform(byte[] input) {

        var size = input.Length;
        using var buffer = new MemoryStream();
        var chunk = new byte[OutputChunk];

        for (var i = 0; i < size; i += InputChunk) {
            if (i + InputChunk <= size) {
                // regular block
                var plaintextSpan = new ReadOnlySpan<byte>(input, i, InputChunk);

                Chunk(plaintextSpan, chunk);

                buffer.Write(chunk);

                }
            else {
                // final block
                var plaintextSpan = new ReadOnlySpan<byte>(input, i, size - i);
                var last = new Span<byte>(chunk, 0, size - i + OutputChunk - InputChunk);

                var bytes = Finalize(plaintextSpan, last);

                buffer.Write(chunk, 0, bytes);
                }
            }

        return buffer.ToArray();

        }


    }


public class GcmHandlerBase : Disposable {
    readonly byte[] AssociatedData = "TBS".ToBytes();
    protected int IvBytes { get; } = 12;
    protected int SaltBytes { get; } = 16;
    protected int TagBytes { get; } = 16;
    protected int KeyBytes { get; } = 32;


    /// <summary>The primary key</summary>
    public byte[] Key { get; }

    /// <summary>The salt valye.</summary>
    public byte[] Salt { get; }

    /// <summary>If true, use SIV mode and insert the IV into each block.</summary>
    protected bool Siv { get; } = false;

    /// <summary>Number of SIV bytes inserted into the stream, is always zero or <see cref="IvBytes"/></summary>
    protected int SivBytes => Siv ? IvBytes : 0;

    /// <summary>Plaintext chnunk size.</summary>
    public int ChunkSize { get; }

    /// <summary>Ciphertext chunk size.</summary>
    public int ChunkSizeCiphertext => ChunkSize + SivBytes + TagBytes;

    /// <summary>Length of the plaintext recovered from a ciphertext of 
    /// <paramref name="ciphertextLength"/> bytes</summary>
    /// <param name="ciphertextLength"></param>
    /// <returns>The number of bytes.</returns>
    public long PlaintextLength(
        long ciphertextLength) => ciphertextLength - TagBytes - SivBytes;

    /// <summary>Number of chunks required to encode a plaintext of <paramref name="length"/> bytes.</summary>
    /// <param name="length"></param>
    /// <returns>The number of chunks.</returns>
    protected long ChunkCount(long length) => length / ChunkSize +
        (length % ChunkSize == 0 ? 0 : 1);

    /// <summary>Number of chunks required to encode a ciphertext of <paramref name="length"/> bytes.</summary>
    /// <param name="length"></param>
    /// <returns>The number of chunks.</returns>
    protected long ChunkCountCiphertext(long length) => length / ChunkSizeCiphertext +
        (length % ChunkSizeCiphertext == 0 ? 0 : 1);


    /// <summary>Length of the plaintext recovered from a chunked encoding of length
    /// <paramref name="ciphertextLength"/> bytes.</summary>
    /// <param name="ciphertextLength"></param>
    /// <returns>The number of bytes.</returns>
    public long PlaintextLengthChunked(
        long ciphertextLength) => ciphertextLength -
                    (TagBytes + SivBytes) * ChunkCountCiphertext(ciphertextLength);

    /// <summary>Returns the length of the ciphertext package in the preferred encoding</summary>
    /// <param name="plaintext">Length of the plaintext.</param>
    /// <param name="siv">If true, compute a synthetic IV per chunk.</param>
    /// <returns>The ciphertext length.</returns>
    //public virtual long CiphertextLength (long plaintext) => plaintext + SaltBytes + TagBytes;
    public long CiphertextLength(long plaintext,
                bool siv = false) => plaintext + TagBytes + SivBytes;

    /// <summary>Length of the ciphertext of a chunked encoding of a plaintext of
    /// <paramref name="plaintext"/> bytes.</summary>
    /// <param name="plaintext"></param>
    /// <returns>The number of bytes.</returns>
    public long CiphertextLengthChunked(
                long plaintext) => plaintext + (TagBytes + SivBytes) * ChunkCount(plaintext);

    /// <summary>Constructor for base handler class.</summary>
    /// <param name="key">The key.</param>
    /// <param name="salt">The salt.</param>
    /// <param name="algorithm">The encryption algorithm.</param>
    /// <param name="chunkSize">The chunk size.</param>
    /// <exception cref="CipherModeNotSupported">The algorithm <paramref name="algorithm"/>
    /// is not supported.</exception>
    public GcmHandlerBase(
            byte[] key = null,
            byte[] salt = null,
            CryptoAlgorithmId algorithm = CryptoAlgorithmId.AES256GCM, 
            int chunkSize = 4096) {

        var algbase = algorithm & CryptoAlgorithmId.BaseEncryptionMask;
        switch (algbase) {
            case CryptoAlgorithmId.AES256: {
                KeyBytes = 32;
                break;
                }
            case CryptoAlgorithmId.AES192: {
                KeyBytes = 24;
                break;
                }
            case CryptoAlgorithmId.AES128: {
                KeyBytes = 16;
                break;
                }
            default: throw new CipherModeNotSupported();
            }

        var algmode = algorithm & CryptoAlgorithmId.BulkModeMask;
        switch (algmode) {
            case CryptoAlgorithmId.ModeGcm:
            case CryptoAlgorithmId.ModeGcmChunked: {
                break;
                }
            case CryptoAlgorithmId.ModeGcmSiv: 
            case CryptoAlgorithmId.ModeGcmChunkedSiv: {
                Siv = true;
                break;
                }
            default: throw new CipherModeNotSupported();
            }

        Key = key ?? Platform.GetRandomBytes(KeyBytes);
        Salt = salt ?? Platform.GetRandomBytes(KeyBytes);
        ChunkSize = chunkSize;
        }

    /// <summary>Encode a data chunk.</summary>
    /// <param name="input">The plaintext to encode.</param>
    /// <param name="kdfIn">Input to the key schedule</param>
    /// <param name="output">Buffer to receive siv mask (if used), ciphertext and tag.</param>

    public void EncodeChunk(
                    byte[] kdfIn,
                    ReadOnlySpan<byte> input,
                    Span<byte> output) {

        var digest = Shake256.HashData(kdfIn, IvBytes + KeyBytes);
        if (Siv) {
            var sivMask = Shake256.HashData(kdfIn, IvBytes);
            var spanSiv = new ReadOnlySpan<byte>(sivMask);
            var spanSivdest = output.Slice(0, SivBytes);

            sivMask.CopyTo(spanSivdest);

            for (var i = 0; i < SivBytes; i++) {
                digest[i] |= spanSiv[i];
                }
            }

        // inputs
        var keySpan = new ReadOnlySpan<byte>(digest, 0, KeyBytes);
        var nonceSpan = new Span<byte>(digest, KeyBytes, IvBytes);


        Console.WriteLine($"key {keySpan.ToArray().ToStringBase16()}");
        Console.WriteLine($"nonce {nonceSpan.ToArray().ToStringBase16()}");

        //var plaintextSpan = new ReadOnlySpan<byte>(plaintext);
        var associatedData = new ReadOnlySpan<byte>(AssociatedData);

        Console.WriteLine($"ad {associatedData.ToArray().ToStringBase16()}");

        // outputs
        var ciphertextSpan = output.Slice(SivBytes, input.Length);
        var tagSpan = output.Slice(SivBytes + input.Length, TagBytes);

        // Perform a single encrypt operation
        var aes = new AesGcm(keySpan, TagBytes);
        aes.Encrypt(nonceSpan, input, ciphertextSpan, tagSpan, associatedData);


        Console.WriteLine($"digest {digest.ToStringBase16()}");
        Console.WriteLine($"input {input.ToArray().ToStringBase16()}");
        Console.WriteLine($"output {output.ToArray().ToStringBase16()}");


        Console.WriteLine($"tag {tagSpan.ToArray().ToStringBase16()}");
        Console.WriteLine($"ciphertext {ciphertextSpan.ToArray().ToStringBase16()}");

        //Console.WriteLine();
        }



    /// <summary>Decode a data chunk.</summary>
    /// <param name="input">The ciphertext package to decode.</param>
    /// <param name="output">Buffer to receive recovered plaintext.</param>
    /// <param name="kdfIn">Input to the key schedule</param>
    public void DecodeChunk(
                    byte[] kdfIn,
                    ReadOnlySpan<byte> input,
                    Span<byte> output) {

        var digest = Shake256.HashData(kdfIn, IvBytes + KeyBytes);
        Console.WriteLine($"digest {digest.ToStringBase16()}");
        Console.WriteLine($"input {input.ToArray().ToStringBase16()}");


        if (Siv) {
            // apply the siv  mask to the computed nonce
            for (var i = 0; i < SivBytes; i++) {
                digest[i] |= input[i];
                }
            }

        // inputs
        var keySpan = new ReadOnlySpan<byte>(digest, 0, KeyBytes);
        var nonceSpan = new Span<byte>(digest, KeyBytes, IvBytes);

        Console.WriteLine($"key       {keySpan.ToArray().ToStringBase16()}");
        Console.WriteLine($"nonce     {nonceSpan.ToArray().ToStringBase16()}");

        //var plaintextSpan = new ReadOnlySpan<byte>(plaintext);
        var associatedData = new ReadOnlySpan<byte>(AssociatedData);
        Console.WriteLine($"ad        {associatedData.ToArray().ToStringBase16()}");

        // outputs
        var ciphertext = input.Slice(SivBytes, output.Length);
        var tagSpan = input.Slice(SivBytes + output.Length, TagBytes);



        Console.WriteLine($"tag        {tagSpan.ToArray().ToStringBase16()}");
        Console.WriteLine($"ciphertext {ciphertext.ToArray().ToStringBase16()}");

        // Perform a single encrypt operation
        var aes = new AesGcm(keySpan, TagBytes);
        aes.Decrypt(nonceSpan, ciphertext, tagSpan, output, associatedData);

        Console.WriteLine($"input {input.ToArray().ToStringBase16()}");
        Console.WriteLine($"output {output.ToArray().ToStringBase16()}");
        }
    }

public class GcmWrapper : GcmHandlerBase {

    public GcmWrapper(
            byte[] key = null,
            byte[] salt = null,
            CryptoAlgorithmId algorithm = CryptoAlgorithmId.AES256GCM) : base(null, salt, algorithm) {
        }


    /// <summary>Encode <paramref name="plaintext"/> and return the ciphertext 
    /// package consisting of the salt, ciphertext and tag encrypted under a new 
    /// derrived key.</summary>
    /// <param name="plaintext">The plaintext.</param>
    /// <param name="salt">Salt value, guarantees uniqueness of key plus IV</param>
    /// <returns>The ciphertext package</returns>
    public byte[] Encode(
                ReadOnlySpan<byte> plaintext) {

        // Compute the per encrypt nonce and key.
        var kdfIn = new byte[KeyBytes + SaltBytes];
        Buffer.BlockCopy(Key, 0, kdfIn, 0, KeyBytes);
        Buffer.BlockCopy(Salt, 0, kdfIn, KeyBytes, SaltBytes);

        // create the output
        var result = new byte[CiphertextLength(plaintext.Length)];

        // Add the ciphertext and tag
        EncodeChunk(kdfIn, plaintext, new Span<byte>(result));

        return result;
        }

    }
/// <summary>Wrapper class providing chunked GCM encoding.</summary>
/// <param name="digest"></param>
/// <param name="algorithm"></param>
/// <param name="chunkSize">The chunk size. This is intentionally restricted to the 
/// range of a signed 32 bit integer. The internal counter in GCM is 32 bits after
/// which the cipher stream wraps allowing a trivial recovery attack. Thus the 
/// maximum secure chunk size is 2^39-256 bits. Since we expect blocks
/// to be comfortably shorter than 2^31 bytes, specifying the chunk size
/// as an integer enforces this constraint.</param>
public class GcmWrapperChunked: GcmHandlerBase, IChunk {

    /// <inheritdoc/>
    public int InputChunk => ChunkSize;

    /// <inheritdoc/>
    public int OutputChunk => ChunkSizeCiphertext;

    byte[] KdfInput { get; set; }

    ulong Counter { get; set; } = 0;



    public GcmWrapperChunked(
        byte[] key = null,
        byte[] salt = null,
        CryptoAlgorithmId algorithm = CryptoAlgorithmId.AES256GCM,
        int chunkSize = 4096) : base(key, salt, algorithm, chunkSize) {

        KdfInput = new byte[KeyBytes + SaltBytes + 16];
        Buffer.BlockCopy(Key, 0, KdfInput, 0, KeyBytes);
        Buffer.BlockCopy(Salt, 0, KdfInput, KeyBytes, SaltBytes);
        }

    //public byte[] Transform(byte[] input) => ((IChunk)this).Transform(input);


    /// <summary>Encode the plaintext chunk <paramref name="plaintext"/> and write the
    /// resulting plaintext and tag to the stream.</summary>
    /// <param name="plaintext">The plaintext to encrypt. MUST be the exact length
    /// specified in the constructor.</param>
    public int Chunk(ReadOnlySpan<byte> plaintext, Span<byte> ciphertext) {
        (plaintext.Length == ChunkSize).AssertTrue(InvalidChunkSize.Throw);

        // Compute the per encrypt nonce and key.
        return ChunkInternal(plaintext, ciphertext);
        }

    /// <inheritdoc/>
    public int Finalize(ReadOnlySpan<byte> plaintext, Span<byte> ciphertext) {
        if (plaintext.Length == 0) {
            return 0;
            }
        return ChunkInternal(plaintext, ciphertext);
        }


    int ChunkInternal(ReadOnlySpan<byte> data, Span<byte> ciphertext) {

        // Update the key schedule
        var count = Counter.NetworkOrder();
        Buffer.BlockCopy(count, 0, KdfInput, KeyBytes + SaltBytes, 8);

        // encode the chunk
        EncodeChunk(KdfInput, data, ciphertext);

        return data.Length + TagBytes + SivBytes;
        }


    }


public class GcmUnwrapper : GcmHandlerBase {

    public GcmUnwrapper(
            byte[] key,
            byte[] salt,
            CryptoAlgorithmId algorithm = CryptoAlgorithmId.AES256GCM,
            int chunkSize = 4096) : base(key, salt, algorithm: algorithm, chunkSize: chunkSize) {
        }




    public byte[] Decode(
                        ReadOnlySpan<byte> ciphertext
            ) {
        // Compute the per encrypt nonce and key.
        var kdfIn = new byte[KeyBytes + SaltBytes];
        Buffer.BlockCopy(Key, 0, kdfIn, 0, KeyBytes);
        Buffer.BlockCopy(Salt, 0, kdfIn, KeyBytes, SaltBytes);


        var result = new byte[PlaintextLength(ciphertext.Length)];

        DecodeChunk(kdfIn, ciphertext, new Span<byte>(result));
        return result;
        }



    }

public class GcmUnwrapperChunked : GcmHandlerBase, IChunk {

    public int InputChunk => ChunkSizeCiphertext ;
    public int OutputChunk => ChunkSize;

    ulong Counter { get; set; } = 0;

    byte[] KdfInput { get; set; }
    public  GcmUnwrapperChunked(
            byte[] key,
            byte[] salt,
            HashAlgorithm? digest = null,
            CryptoAlgorithmId encrypt = CryptoAlgorithmId.AES256GCM,
            int chunkSize = 4096) : base(key, salt, encrypt, chunkSize) {

        KdfInput = new byte[KeyBytes + SaltBytes + 16];
        Buffer.BlockCopy(Key, 0, KdfInput, 0, KeyBytes);
        Buffer.BlockCopy(Salt, 0, KdfInput, KeyBytes, SaltBytes);

        }



    /// <summary>Decrypt the ciphertext chunk <paramref name="ciphertext"/> and write the
    /// resulting plaintext and tag to the stream.</summary>
    /// <param name="ciphertext">The ciphertext to decrypt. MUST be the exact length
    /// specified in the constructor.</param>
    /// <param name="plaintext">The corresponding plaintext.</param>
    public int Chunk(
                        ReadOnlySpan<byte> ciphertext, Span<byte> plaintext) {

        (plaintext.Length == ChunkSize).AssertTrue(InvalidChunkSize.Throw);

        // Compute the per encrypt nonce and key.
        return ChunkInternal(ciphertext, plaintext);

        }


    /// <summary>Decode the final ciphertext chunk <paramref name="ciphertext"/> and write the
    /// resulting plaintext and tag to the stream.</summary>
    /// <param name="ciphertext">The plaintext to encrypt.</param>
    public int Finalize(
                    ReadOnlySpan<byte> ciphertext, Span<byte> plaintext) {

        if (plaintext.Length == 0) {
            return 0;
            }
        return ChunkInternal(ciphertext, plaintext);
        }


    int ChunkInternal(ReadOnlySpan<byte> data, Span<byte> ciphertext) {

        // Update the key schedule
        var count = Counter.NetworkOrder();
        Buffer.BlockCopy(count, 0, KdfInput, KeyBytes + SaltBytes, 8);

        // encode the chunk
        DecodeChunk(KdfInput, data, ciphertext);

        return data.Length - TagBytes - SivBytes;
        }

    }