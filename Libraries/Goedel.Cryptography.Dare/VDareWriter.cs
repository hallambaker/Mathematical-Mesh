#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion
using Goedel.Cryptography.Nist;

namespace Goedel.Cryptography.Dare;

public class VDareWriter{

    protected IEnumerable<CryptographicKey> Signers;
    //protected IEnumerable<CryptographicKey> Recipients;

    ///<summary>The parsed unprotected header.</summary> 
    public Unprotected? Unprotected { get; protected set; } = null;

    ///<summary>The parsed unprotected header.</summary> 
    public ContentMeta? ContentMeta { get; protected set; } = null;

    protected byte[]? MetadataBytes { get; set; }

    ///<summary>The parsed trailer.</summary>
    public Unprotected? Trailer { get; protected set; } = null;

    protected bool Sign { get; set; } = false;
    protected bool Encrypt { get; set; } = false;

    protected HashAlgorithm? Digest { get; set; } = null;

    protected IChunk GcmWrapperChunked { get; set; } = null;

    protected CryptoAlgorithmId DigestId { get; set; }
    protected CryptoAlgorithmId EncryptionId { get; set; }

    ///<summary>The metadata digest.</summary>
    public byte[]? MetadataDigest { get; protected set; } = null;

    ///<summary>The payload digest.</summary>
    public byte[]? PayloadDigest { get; protected set; } = null;

    public byte[]? Salt { get; protected set; } = null;
    public byte[]? Malt { get; protected set; } = null;
    public byte[]? Manifest { get; protected set; } = null;


    byte[]? CiphertextBuffer { get; set; }


    protected void Initialize(
            ContentMeta contentMeta,
            Unprotected? unprotected=null,
            IEnumerable<CryptographicKey> recipients = null,
            IEnumerable<CryptographicKey> signers = null,
            CryptoAlgorithmId digestId = CryptoAlgorithmId.Default,
            CryptoAlgorithmId encryptionId = CryptoAlgorithmId.Default,
            byte[] key = null,
            byte[]? salt = null,
            int chunkSize = 4096) {

        ContentMeta = contentMeta;
        Unprotected = unprotected;
        Salt = salt;

        Encrypt = recipients != null;
        Sign = signers != null;

        Signers = signers;

        DigestId = digestId;

        MetadataBytes = ContentMeta?.GetBytes(false) ?? [];



        if (Sign) {
            // The unprotected header must be initialized if signing
            Unprotected ??= new();

            // set up the algorithm
            foreach (var pair in signers) {
                if (pair.CryptoAlgorithmId == CryptoAlgorithmId.Ed448) {
                    DigestId = digestId == CryptoAlgorithmId.Default ? CryptoAlgorithmId.SHA_3_512 : digestId;
                    }

                else if (digestId == CryptoAlgorithmId.Default) {
                    DigestId = CryptoAlgorithmId.SHA_3_256;
                    }
                }

            Unprotected.Signers = [];
            foreach (var signerKey in signers) {
                var signer = new EarlSignature(signerKey);
                Unprotected.Signers.Add(signer);
                }
            Trailer ??= new();

            }

        if((DigestId != CryptoAlgorithmId.Default) & (DigestId != CryptoAlgorithmId.NULL)) {
            Unprotected ??= new();
            Digest = DigestId.CreateDigest();
            MetadataDigest = Digest.ComputeHash(MetadataBytes);

            Salt ??= Platform.GetRandomBytes(32);

            Unprotected ??= new();
            Unprotected.DigestAlgorithm = DigestId.ToJoseID();

            Unprotected.Salt = Salt;
            //Unprotected.Malt = metaDigest.ComputeHash(GcmWrapperChunked.Salt);

            Trailer ??= new();
            }


        if (Encrypt) {
            Unprotected ??= new();
            // The unprotected header must be initialized if encrypting

            // set up the algorithm
            EncryptionId = encryptionId != CryptoAlgorithmId.Default ?
                EncryptionId : CryptoAlgorithmId.AES256GCM;

            // set up the encoder
            GcmWrapperChunked = new GcmWrapperChunked(algorithm: EncryptionId, chunkSize: chunkSize);


            Console.WriteLine($"Key {GcmWrapperChunked.Key.ToStringBase16FormatHex()}");
            Console.WriteLine($"Salt {GcmWrapperChunked.Salt.ToStringBase16FormatHex()}");


            Unprotected.EncryptionAlgorithm = EncryptionId.ToJoseID();
            Unprotected.Salt = GcmWrapperChunked.Salt;
            if (Digest is not null) {
                Malt = Digest.ComputeHash(Unprotected.Salt);
                }

            if (chunkSize != 4096) {
                Unprotected.Chunk = chunkSize;
                }

            Unprotected.Recipients = KeyExchange(GcmWrapperChunked.Key, recipients);
            //header.KeyIdentifier = GetKeyIdentifier();

            //cryptoParameters.SetKeyExchange(header);


            //if (cryptoParameters is CryptoParametersSequence cryptoParametersContainer) {
            //    if (cryptoParametersContainer.ReuseKeyExchange((int)header.Index, out var keyExchange)) {
            //        header.SequenceInfo.ExchangePosition = keyExchange;
            //        }
            //    else {
            //        cryptoParameters.SetKeyExchange(header);
            //        }
            //    }
            //else {
            //    cryptoParameters.SetKeyExchange(header);
            //    }

            //if (cloaked != null) {
            //    header.Cloaked = Encode(cloaked, MakeSalt(saltValue++));
            //    }
            }




        }

    /// <summary>
    /// Perform a new key exchange and 
    /// </summary>
    /// <returns></returns>
    protected virtual List<DareRecipient> KeyExchange(
                byte[] key,
                IEnumerable<CryptographicKey> recipients) {

        // perform a key exchange for each recipient.
        var result = new List<DareRecipient>();
        foreach (var encryptionKey in recipients) {
            result.Add(new DareRecipient(key, encryptionKey));
            }

        return result;
        }


    protected byte[] GetPayload(byte[] data, int chunkSize = 0) =>
        Encrypt ? GcmWrapperChunked.Transform(data) : data;




    public ReadOnlySpan<byte> Chunk(ReadOnlySpan<byte> plaintext) {
        if (!Encrypt) {
            return plaintext;
            
            }
        CiphertextBuffer ??= new byte[GcmWrapperChunked.OutputChunk];
        var span = new Span<byte>(CiphertextBuffer);
        GcmWrapperChunked.Chunk(plaintext, span);

        return span;
        }

    public ReadOnlySpan<byte> Finalize(ReadOnlySpan<byte> plaintext) {
        if (!Encrypt) {
            return plaintext;

            }
        CiphertextBuffer ??= new byte[GcmWrapperChunked.OutputChunk];
        var span = new Span<byte>(CiphertextBuffer);
        var bytes = GcmWrapperChunked.Finalize(plaintext, span);

        return span[..bytes];
        }



    protected int MeasureTrailer() {
        MakeTrailer();

        var trailerBytes = Trailer.GetBytes();

        return trailerBytes.Length;
        }

    protected void MakeTrailer() {
        if (Sign) {
            Trailer ??= new();
            Trailer.Signatures = [];
            Manifest = GetManifest(DigestId, MetadataDigest, PayloadDigest, Malt);

            foreach (var key in Signers.IfEnumerable()) {
                var signer = new EarlSignature(key, Manifest);
                Trailer.Signatures.Add(signer);
                }
            }

        }

    /// <summary>
    /// Compute the manifest of  <paramref name="contentMetadataDigest"/>, 
    /// <paramref name="payloadDigest"/> and optional <paramref name="protectedData"/> using
    /// the digest algorithm <paramref name="digest"/>
    /// </summary>
    /// <param name="digest">The digest algorithm.</param>
    /// <param name="contentMetadataDigest">Digest of the Content Metadata.</param>
    /// <param name="payloadDigest">Digest of the payload.</param>
    /// <param name="protectedData">Optional additional protected data.</param>
    /// <returns>The manifest bytes.</returns>
    public static byte[] GetManifest(
                CryptoAlgorithmId digest,
                byte[] contentMetadataDigest,
                byte[] payloadDigest,
                byte[]? protectedData = null) {
        var oid = digest.ToOID().ParseOid();
        var stream = new MemoryStream();

        stream.Write(oid);
        stream.Write(contentMetadataDigest);
        stream.Write(payloadDigest);
        if (protectedData != null) {
            stream.Write(protectedData);
            }

        return stream.ToArray();
        }
    }
