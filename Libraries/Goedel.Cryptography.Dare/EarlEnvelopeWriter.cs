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
using Goedel.ASN;
using Goedel.Protocol;

using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
using System.Security.Cryptography;
using System.Data;
using System.Collections.Generic;
using System.Net.WebSockets;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;

namespace Goedel.Cryptography.Dare;



public partial class EarlEnvelopeReader {
    Stream Stream { get; }

    public int Version { get; private set; }

    public Unprotected? UnprotectedHeader { get; private set; } = null;

    public ContentMeta? ContentMeta { get; private set; } = null;

    public Unprotected? Trailer { get; private set; } = null;

    HashAlgorithm? Digest = null;
    CryptoAlgorithmId DigestId;
    byte[]? MetadataDigest = null;
    public EarlEnvelopeReader(Stream stream) {
        Stream = stream;
        Version = (int)ReadVarint(Stream);
        }

    public EarlEnvelopeReader(byte[] bytes) : this(new MemoryStream(bytes)) {

        }


    public static (ContentMeta, byte[]) Parse(byte[] bytes,
            KeyCollection? keyCollection=null) {

        var reader = new EarlEnvelopeReader(bytes);
        reader.ReadMetadata();

        var buffer = new MemoryStream();
        while (reader.CopyPayload(buffer)) {
            }

        reader.Verify(keyCollection).AssertTrue(NYI.Throw);

        return (reader.ContentMeta, buffer.ToArray());

        }


    public ContentMeta ReadMetadata() {
        if (Version == 1) {
            var unprotectedHeader = ReadBlock(Stream);
            if (unprotectedHeader.Length > 0) {
                UnprotectedHeader = Unprotected.FromJson(new JsonReader(unprotectedHeader), false);
                if (UnprotectedHeader.DigestAlgorithm is not null) {
                    DigestId = UnprotectedHeader.DigestAlgorithm.ToCryptoAlgorithmID();
                    Digest = DigestId.CreateDigest();
                    }



                }
            }
        var contentMeta = ReadBlock(Stream);
        if (contentMeta.Length > 0) {
            ContentMeta = ContentMeta.FromJson(new JsonReader(contentMeta), false);
            }
        if (Digest is not null) {
            var metaDigest = DigestId.CreateDigest();
            MetadataDigest = metaDigest.ComputeHash(contentMeta);

            }


        return ContentMeta;
        }

    /// <summary>
    /// Copy bytes from the 
    /// </summary>
    /// <param name="output"></param>
    /// <returns>True if there is more payload to be read</returns>
    public bool CopyPayload(Stream output) {
        var length = ReadVarint(Stream);
        if (length == 0) {
            return false;
            }

        if (Digest is null) {
            Stream.CopyTo(output, length);
            }
        else {
            Stream.HashCopyTo(output, length, Digest);
            }

        return Version == 1;
        }

    public bool Verify(
            KeyCollection? keyCollection = null) {
        if (Version == 0) {
            return true;
            }

        var trailer = ReadBlock(Stream);
        if (trailer.Length > 0) {
            Trailer = Unprotected.FromJson(new JsonReader(trailer), false);
            }

        var signatures = UnprotectedHeader?.Signatures ?? Trailer?.Signatures;
        if (signatures is null & UnprotectedHeader?.Signers is null) {
            return true; // There are no signatures to verify.
            }

        // Check that there is exactly one Signatures property.
        (Trailer?.Signatures is null | UnprotectedHeader?.Signatures is null).AssertTrue(NYI.Throw);

        if (UnprotectedHeader?.Signers is not null) {
            (UnprotectedHeader.Signers.Count == Trailer.Signatures.Count).AssertTrue(NYI.Throw);

            foreach (var signature in signatures) {
                var signer = Find(UnprotectedHeader.Signers, signature.KeyIdentifier);
                signature.Alg ??= signer.Alg;
                }
            }

        // Check that we computed a digest.
        (Digest is not null).AssertTrue(NYI.Throw);

        var value = Digest.GetValue();
        Console.WriteLine($"Digest Value = {value.ToStringBase16FormatHex()}");

        var manifest = EarlEnvelopeWriter.GetManifest(DigestId, MetadataDigest, value);
        Console.WriteLine($"Manifest Value = {manifest.ToStringBase16FormatHex()}");

        ContentMeta.VerifiedSignatures = [];
        foreach (var signature in signatures) {
            if (signature?.Value is null) {
                return false;
                }
            if (!keyCollection.TryFindPublicKey(signature.KeyIdentifier, out var key)) {
                // unknown key.
                return false;
                }
            if (!key.VerifyManifest(manifest, signature.Value)) {
                return false;
                }

            ContentMeta.VerifiedSignatures.Add(signature);
            }

        return true;
        }


    EarlSignature Find(IEnumerable<EarlSignature> signers, string keyId) {
        foreach (var signer in signers) {
            if (signer.KeyIdentifier == keyId) {
                return signer;
                }
            }

        throw new NYI();
        }

    public static byte[] ReadBlock(Stream stream) {
        var length = ReadVarint(stream);
        var buffer = new byte[length];
        stream.ReadExactly(buffer, 0, (int) length);
        return buffer;
        }

    public static ulong ReadVarint(Stream stream) {
        ulong result;

        var read = ReadByteExact(stream);
        var type = read & 0b1100_0000;
        result = (ulong)read & 0b0011_1111;

        var count = type switch {
            0 => 0,
            0b0100_0000 => 1,
            0b1000_0000 => 3,
            0b1100_0000 => 7,
            };

        for (var i = 0; i < count; i++) {
            read = ReadByteExact(stream);
            result <<= 8;
            if (read < 0) {
                throw new EndOfStreamException();
                }

            result |= (byte) read;
            }

        return result;
        }

    public static byte ReadByteExact(Stream stream) {
        var read = stream.ReadByte();
        if (read < 0) {
            throw new EndOfStreamException();
            }

        return (byte) read;
        }


    }


public partial class EarlEnvelopeWriter {

    MemoryStream Buffer = new MemoryStream();
    public Unprotected? Header { get; private set; }
    public Unprotected? Trailer { get; private set; }
    int Type { get; }

    int State { get; set; }

    CryptoStream DigestStream = null;
    HashAlgorithm Digest = null;
    CryptoAlgorithmId DigestId;

    public byte[]? MetadataDigest { get; private set; } = null;
    public byte[]? PayloadDigest { get; private set; } = null;

    public byte[]? Manifest { get; private set; } = null;


    public EarlEnvelopeWriter(
            byte[] payload,
            byte[]? metadata = null,
            byte[]? unprotectedHeader = null,
            byte[]? trailer = null) {

        Type = (unprotectedHeader == null && trailer == null) ? 0 : 1;
        WriteVarint(Buffer, Type);

        if (Type == 1) {
            WriteBytes(Buffer, unprotectedHeader);
            }
        WriteBytes(Buffer, metadata);
        WriteBytes(Buffer, payload);

        if (Type == 1) {
            // close the data chunks
            WriteVarint(Buffer, 0);
            WriteBytes(Buffer, trailer);
            }
        }

    public EarlEnvelopeWriter(
            ContentMeta metadata,
            IEnumerable<KeyPair> signers = null,
            CryptoAlgorithmId digest = CryptoAlgorithmId.Default) : this (){
        Begin(metadata, signers);

        }

    public EarlEnvelopeWriter() {
        Type = 1;
        WriteVarint(Buffer, Type);
        State = 0;
        }


    public void Begin(
            ContentMeta metadata,
            IEnumerable<KeyPair> signers=null,
            CryptoAlgorithmId digestId = CryptoAlgorithmId.Default) {


        signers ??= [];
        foreach (KeyPair pair in signers) {
            if (pair.CryptoAlgorithmId == CryptoAlgorithmId.Ed448) {
                digestId = CryptoAlgorithmId.SHA_3_512;
                }

            else if (digestId == CryptoAlgorithmId.Default) {
                digestId = CryptoAlgorithmId.SHA_3_256;
                }
            }

        DigestId = digestId;
        var metadataBytes = metadata.GetJson(false);

        if (signers.Count() > 0) {
            var metaDigest = DigestId.CreateDigest();
            MetadataDigest = metaDigest.ComputeHash(metadataBytes);

            Digest = DigestId.CreateDigest();

            Header = new Unprotected() {
                DigestAlgorithm = DigestId.ToJoseID(),
                Signers = []
                };

            foreach (var key in signers) {
                var signer = new EarlSignature(key);
                Header.Signers.Add(signer);
                }

            var unprotectedBytes = Header.GetBytes(false);
            WriteUnprotected(unprotectedBytes);
            }
        else {
            // No signers, no unprotected header.
            WriteUnprotected();
            }

        WriteMetadata(metadataBytes);

        }

    public void Write(
            byte[] chunk) {
        if (Digest is not null) {
            Digest.Digest(chunk);
            }
        WritePayload(chunk);

        }

    public void Write(
        string chunk) => Write (chunk.ToUTF8());

    public byte[] End(
        IEnumerable<KeyPair> signers) {

        if (signers.Count() > 0) {

            Trailer = new Unprotected() {
                Signatures = []
                };

            PayloadDigest = Digest.GetValue();
            Console.WriteLine($"Digest Value = {PayloadDigest.ToStringBase16FormatHex()}");

            Manifest = GetManifest(DigestId, MetadataDigest, PayloadDigest);
            Console.WriteLine($"Manifest Value = {Manifest.ToStringBase16FormatHex()}");


            foreach (var key in signers) {
                var signer = new EarlSignature(key, Manifest, DigestId);
                Trailer.Signatures.Add(signer);
                }

            var trailerBytes = Trailer.GetBytes(false);

            WriteTrailer(trailerBytes);
            }
        else {
            WriteTrailer();
            }
        return Buffer.ToArray();
        }

    public static byte[] GetManifest(
                CryptoAlgorithmId digest,
                byte[] metadataDigest,
                byte[] contentDigest,
                byte[]? protectedData=null) {
        var oid = digest.ToOID().ParseOid();
        var stream = new MemoryStream();


        stream.Write(oid);
        stream.Write( metadataDigest);
        stream.Write( contentDigest);
        if (protectedData != null) {
            stream.Write( protectedData);
            }

        return stream.ToArray();
        }

    public void WriteUnprotected(
                byte[]? unprotectedHeader=null) {
        (State == 0).AssertTrue(NYI.Throw);
        WriteBytes(Buffer, unprotectedHeader);
        State = 1;
        }

    public void WriteMetadata(
            byte[]? metadata = null) {
        (State <2).AssertTrue(NYI.Throw);
        if (State == 0) {
            WriteUnprotected();
            }
        WriteBytes(Buffer, metadata);
        State = 2;
        }

    public void WritePayload(
            byte[] payload) {
        (State < 3).AssertTrue(NYI.Throw);
        if (State < 2) {
            WriteMetadata();
            }
        if (payload.Length > 0) {
            WriteBytes(Buffer, payload);
            }

        }

    public void WriteTrailer(
            byte[]? trailer=null) {
        (State < 3).AssertTrue(NYI.Throw);
        if (State < 2) {
            WriteMetadata();
            }
        WriteVarint(Buffer, 0); // last payload chunk
        WriteBytes(Buffer, trailer);
        State = 3;
        }



    public static byte[] GetBytes(
            byte[] payload,
            byte[]? protectedHeader = null,
            byte[]? unprotectedHeader = null,
            byte[]? trailer = null) =>
        new EarlEnvelopeWriter(payload, protectedHeader, unprotectedHeader, trailer).ToArray();


    public static byte[]? GetBytes(
        ContentMeta? contentMeta,
        byte[] payload) {

        var protectedHeader = GetProtectedHeader (contentMeta);
        return GetBytes (payload, protectedHeader);
        }


    public static byte[]? GetProtectedHeader(
            ContentMeta? contentMeta) => contentMeta is null ? null : contentMeta.GetJson(false);


    public byte[] ToArray() => Buffer.ToArray();



    public static void WriteBytes(
            Stream stream,
            byte[]? data) {

        if (data is null) {
            stream.Write((byte)0);

            }
        else {
            WriteVarint(stream, data.Length);
            stream.Write(data);
            }
        
        }

    public static void WriteVarint(
                Stream stream,
                long value) {

        if (value < 64) {
            stream.Write((byte)value);
            return;
            }

        if (value < 16383) {
            var v2 = (value >> 8);

            stream.Write((byte)(v2 | 0b0100_0000));
            stream.Write((byte)value);
            return;
            }

        if (value < 1073741823) {
            var v2 = (value >> 8);
            var v3 = (v2 >> 8);
            var v4 = (v3 >> 8);

            stream.Write((byte)(v4 | 0b1000_0000));
            stream.Write((byte)v3);
            stream.Write((byte)v2);
            stream.Write((byte)value);
            return;
            }

        if (value < 4611686018427387903) {
            var v2 = (value >> 8);
            var v3 = (v2 >> 8);
            var v4 = (v3 >> 8);
            var v5 = (v4 >> 8);
            var v6 = (v5 >> 8);
            var v7 = (v6 >> 8);
            var v8 = (v7 >> 8);

            stream.Write((byte)(v8 | 0b1100_0000));
            stream.Write((byte)v7);
            stream.Write((byte)v6);
            stream.Write((byte)v5);
            stream.Write((byte)v4);
            stream.Write((byte)v3);
            stream.Write((byte)v2);
            stream.Write((byte)value);
            return;
            }

        else throw new InvalidLength();

        }


    }
