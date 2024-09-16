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

namespace Goedel.Cryptography.Dare;


/// <summary>
/// Creates a factory for generating a stack of CryptoStream objects for processing
/// a stream of data.
/// </summary>
public abstract partial class CryptoStack {

    /// <summary>Constant for deriving a MAC key.</summary>
    public static readonly byte[] InfoKeyMac = "mac".ToBytes();

    /// <summary>Constant for deriving an encryption key.</summary>
    public static readonly byte[] InfoKeyEncrypt = "encrypt".ToBytes();

    /// <summary>Constant for deriving an initialization vector.</summary>
    public static readonly byte[] InfoKeyIv = "iv".ToBytes();


    /// <summary>
    /// The recipient information fields.
    /// </summary>
    public List<DareRecipient> Recipients;

    /// <summary>
    /// The JOSE algorithm identifier for the encryption algorithm.
    /// </summary>
    public string EncryptionAlgorithm = null;

    /// <summary>
    /// The JOSE algorithm identifier for the encryption algorithm.
    /// </summary>
    public string DigestAlgorithm = null;



    /// <summary>
    /// The base salt value.
    /// </summary>
    public byte[] Salt;


    /// <summary>
    /// The Keys to be used to sign the message. 
    /// </summary>
    public abstract List<CryptoKey> SignerKeys { get; }

    /// <summary>
    /// The base seed provided as a verbatim value or provided through a key exchange to be 
    /// used together with the salt data to derive the keys and initialization data for 
    /// cryptographic operations.
    /// </summary>
    public abstract byte[] BaseSeed { get; }

    /// <summary>The authentication algorithm to use</summary>
    public abstract CryptoAlgorithmId DigestId { get; }

    /// <summary>The encryption algorithm to use</summary>
    public abstract CryptoAlgorithmId EncryptId { get; }

    ///<summary>The key size in bits determined by the value of <see cref="EncryptId"/></summary> 
    public abstract int KeySize { get; }

    ///<summary>The block size in bits determined by the value of <see cref="EncryptId"/></summary> 
    public abstract int BlockSize { get; }



    ///<summary>The block size in bytes.</summary> 
    protected abstract int BlockSizeByte { get; }

    ///<summary>Returns a UDF key identifier for the master secret</summary>
    public string GetKeyIdentifier() => BaseSeed == null ? null : Udf.SymetricKeyId(BaseSeed);


    /// <summary>
    /// Calculate the ciphertext length for a specified plaintext length.
    /// </summary>
    /// <param name="plaintextLength">The input plaintext length.</param>
    /// <returns>The ciphertext length using the current cipher.</returns>
    public long CipherTextLength(long plaintextLength) => EncryptId == CryptoAlgorithmId.NULL
        ? plaintextLength
        : BlockSizeByte * (1 + (plaintextLength / BlockSizeByte));


    /// <summary>
    /// Convert an int64 counter to a unique salt value.
    /// </summary>
    /// <param name="saltValue"></param>
    /// <returns></returns>
    public static byte[] MakeSalt(long saltValue) {
        var salt = saltValue;

        var Index = 0;
        while (salt > 0xFF) {
            Index++;
            salt >>= 8;
            }

        var Result = new byte[Index + 1];

        salt = saltValue;
        Index = 0;
        Result[Index++] = (byte)(salt & 0xFF);
        while (salt > 0xFF) {
            Result[Index++] = (byte)(salt & 0xFF);
            salt >>= 8;
            }
        return Result;

        }


    /// <summary>
    /// Calculate key parameters 
    /// </summary>
    /// <param name="thisSalt">The salt value to use</param>
    /// <param name="keyEncrypt">The derrived Encryption key.</param>
    /// <param name="keyMac">The derrived MAC key.</param>
    /// <param name="iv">The derrivedIV.</param>
    protected void CalculateParameters(
        byte[] thisSalt,
        out byte[] keyEncrypt,
        out byte[] keyMac,
        out byte[] iv
        ) {
        var KDF = new KeyDeriveHKDF(BaseSeed, thisSalt, CryptoAlgorithmId.HMAC_SHA_2_256);
        keyEncrypt = KDF.Derive(InfoKeyEncrypt, 256);
        keyMac = KDF.Derive(InfoKeyMac, KeySize);
        iv = KDF.Derive(InfoKeyIv, BlockSize);
        }


    private void CalculateParameters(
        bool encrypt,
        byte[] extraSalt,
        out ICryptoTransform transformEncrypt,
        out HashAlgorithm transformMac,
        out HashAlgorithm transformDigest) {
        transformDigest = DigestId.CreateDigest();
        if (BaseSeed == null) {
            transformMac = null;
            transformEncrypt = null;
            return;
            }
        // The extra salt data is prepended rather than postpended. This ensures that the salt value is changed
        // by the extra salt even if the extra salt value is all zeros.
        var ThisSalt = extraSalt == null ? Salt : extraSalt.Concat(Salt);

        CalculateParameters(ThisSalt, out var KeyEncrypt, out var KeyMac, out var IV);

        transformMac = EncryptId.CreateMac(KeyMac);
        transformEncrypt = encrypt
            ? EncryptId.CreateEncryptor(KeyEncrypt, IV)
            : EncryptId.CreateDecryptor(KeyEncrypt, IV);
        }


    /// <summary>
    /// Construct the trailer value.
    /// </summary>
    /// <param name="writer">The cryptographic stream used to write the payload
    /// data.</param>
    /// <returns>The trailer value.</returns>
    public DareTrailer GetTrailer(CryptoStackStreamWriter writer) {
        DareTrailer Result = null;



        if (writer.DigestValue != null) {

            Result = new DareTrailer() {
                PayloadDigest = writer.DigestValue,
                WitnessValue = writer.WitnessValue,
                };

            if (writer.GetApexDigest != null) {
                Result.ApexDigest = writer.GetApexDigest(writer.DigestValue);
                }


            }

        if (SignerKeys != null) {
            Result ??= new DareTrailer();
            Result.Signatures = new List<DareSignature>();

            // Here calculate the manifest
            var manifest = GetEnvelopeSignatureManifest(DigestId, Result);

            if (EncryptId != CryptoAlgorithmId.NULL) {
                var derive = new KeyDeriveHKDF(BaseSeed, Salt, CryptoAlgorithmId.HMAC_SHA_2_256);
                Result.WitnessValue = KeyDeriveHKDF.Derive(BaseSeed, Salt, manifest, 
                                algorithm:CryptoAlgorithmId.HMAC_SHA_2_256);
                }

            foreach (var Key in SignerKeys) {
                Result.Signatures.Add(new DareSignature(Key, manifest, DigestId));
                }
            }


        return Result;
        }


    public static byte[] GetEnvelopeSignatureManifest(CryptoAlgorithmId digestId, DareTrailer trailer) {
        var memoryStream = new MemoryStream();
        var writer = new JsonBWriter(memoryStream);

        writer.WriteString(digestId.ToJoseID());
        writer.WriteBinary(trailer.PayloadDigest);
        if (trailer.ChainDigest != null) {
            writer.WriteBinary(trailer.ChainDigest);
            }
        //if (trailer.ApexDigest != null) {
        //    writer.WriteBinary(trailer.ApexDigest);
        //    }

        writer.Flush();
        memoryStream.Flush();

        return memoryStream.ToArray();  
        }

    public static byte[] GetSequenceSignatureManifest(CryptoAlgorithmId digestId, DareTrailer trailer) {
        var memoryStream = new MemoryStream();
        var writer = new JsonBWriter(memoryStream);

        writer.WriteString(digestId.ToJoseID());
        writer.WriteBinary(trailer.PayloadDigest);
        if (trailer.ChainDigest != null) {
            writer.WriteBinary(trailer.ChainDigest);
            }
        if (trailer.ApexDigest != null) {
            writer.WriteBinary(trailer.ApexDigest);
            }

        writer.Flush();
        memoryStream.Flush();

        return memoryStream.ToArray();
        }




    /// <summary>
    /// Construct a stream encoder for the cryptographic parameters. The encoder may
    /// be used in either mode (read/write).
    /// </summary>
    /// <param name="stream">The encoded stream.</param>
    /// <param name="packagingFormat">The packaging format to use.</param>
    /// <param name="contentLength">The content length of the payload data.</param>
    /// <param name="extraSalt">Additional salt material.</param>
    /// <returns>Encoder parameters.</returns>
    public CryptoStackStreamWriter GetEncoder(
        Stream stream,
        PackagingFormat packagingFormat,
        long contentLength = -1,
        byte[] extraSalt = null
        ) {
        CalculateParameters(
            true, extraSalt, out var transformEncrypt,
            out var transformMac, out var transformDigest);

        if (packagingFormat == PackagingFormat.EDS & extraSalt != null) {
            JsonBWriter.WriteBinary(stream, extraSalt);
            }



        var payloadLength = contentLength < 0 ? -1 : CipherTextLength(contentLength);

        var writer = new CryptoStackStreamWriter(
            stream, packagingFormat,
            transformMac, transformDigest, payloadLength);

        if (transformEncrypt != null) {
            writer.Writer = new CryptoStream(writer, transformEncrypt, CryptoStreamMode.Write);
            }

        return writer;
        }

    /// <summary>
    /// Encode a data block
    /// </summary>
    /// <param name="data">The data to encode.</param>
    /// <param name="extraSalt">Additional salt value.</param>
    /// <returns>The encoded data.</returns>
    public byte[] Encode(
        byte[] data,
        byte[] extraSalt = null) {
        using var input = new MemoryStream(data);
        using var output = new MemoryStream();

        var encoderData = GetEncoder(
            output, PackagingFormat.EDS,
            data.LongLength, extraSalt);
        input.CopyTo(encoderData.Writer);
        encoderData.Close();
        output.Flush();

        return output.ToArray();
        }

    readonly static byte[] NullArray = Array.Empty<byte>();

    /// <summary>
    /// Encode a payload data block
    /// </summary>
    /// <param name="data">The data to encode.</param>
    /// <param name="trailer">Prototype trailer containing the calculated digest value.</param>
    /// <returns>The encoded data.</returns>
    public byte[] Encode(
        byte[] data,
        out DareTrailer trailer
        ) {
        data ??= NullArray;

        using var input = new MemoryStream(data);
        using var output = new MemoryStream();

        var EncoderData = GetEncoder(output, PackagingFormat.Direct, data.LongLength, null);
        input.CopyTo(EncoderData.Writer);
        EncoderData.Close();
        output.Flush();
        trailer = GetTrailer(EncoderData);


        return output.ToArray();
        }


    /// <summary>
    /// Encode a data block as an EDS.
    /// </summary>
    /// <param name="data">The data to encode.</param>
    /// <param name="extraSalt">Additional salt value.</param>
    /// <returns>The encoded data.</returns>
    public byte[] EncodeEDS(
        byte[] data,
        byte[] extraSalt = null
        ) {
        data ??= NullArray;
        using var input = new MemoryStream(data);
        using var output = new MemoryStream();
        //var JSONBWriter = new JSONBWriter(Output);
        var encoderData = GetEncoder(output, PackagingFormat.EDS, data.LongLength, extraSalt);
        input.CopyTo(encoderData.Writer);
        encoderData.Close();
        output.Flush();
        //DARETrailer = GetTrailer(EncoderData);

        return output.ToArray();
        }


    /// <summary>
    /// Construct a stream decoder from the cryptographic data provided. Data is read
    /// from <paramref name="inputStream"/> 
    /// </summary>
    /// <param name="inputStream">The input stream.</param>
    /// <param name="contentLength">The content length if known or -1 if variable length
    /// encoding is to be used.</param>
    /// <param name="outputStream">The stream to read to obtain the decrypted data.</param>
    /// <param name="saltSuffix">Additional value to be added to the beginning of the 
    /// message salt to vary it</param>
    /// <returns>The decoder.</returns>
    public CryptoStackStream GetDecoder(
            Stream inputStream,
            out Stream outputStream,
            long contentLength = -1,
            byte[] saltSuffix = null) {
        contentLength.Future();

        CalculateParameters(
            false, saltSuffix, out var TransformEncrypt,
            out var TransformMac, out var TransformDigest);

        var result = new CryptoStackJBCDStreamReader(inputStream, TransformMac, TransformDigest);
        outputStream = TransformEncrypt == null
            ? (Stream)result
            : new CryptoStream(result, TransformEncrypt, CryptoStreamMode.Read);

        return result;
        }

    /// <summary>
    /// Construct a stream decoder from the cryptographic data provided.
    /// </summary>
    /// <param name="jsonbcdReader">The stream to decode from.</param>
    /// <param name="contentLength">The content length if known or -1 if variable length
    /// encoding is to be used.</param>
    /// <param name="reader">The stream to read to obtain the decrypted data.</param>
    /// <param name="saltSuffix">Additional value to be added to the end of the 
    /// message salt to vary it</param>
    /// <param name="decrypt">If true, attempt decryption and throw an exception if
    /// this fails.</param>
    /// <returns>The decoder.</returns>
    public CryptoStackStream GetDecoder(
            JsonBcdReader jsonbcdReader,
            out Stream reader,
            long contentLength = -1,
            byte[] saltSuffix = null,
            bool decrypt = true) {

        contentLength.Future();
        decrypt.Future();

        CalculateParameters(
            false, saltSuffix, out var TransformEncrypt,
            out var TransformMac, out var TransformDigest);

        var result = new CryptoStackStreamReader(jsonbcdReader, TransformMac, TransformDigest);

        //// Create the stack.
        //reader = TransformDigest == null ? (Stream)Result :
        //    new CryptoStream(Result, TransformDigest, CryptoStreamMode.Read);
        //reader = TransformMac == null ? reader :
        //    new CryptoStream(Result, TransformMac, CryptoStreamMode.Read);


        reader = TransformEncrypt == null
            ? (Stream)result
            : new CryptoStream(result, TransformEncrypt, CryptoStreamMode.Read);

        return result;
        }


    /// <summary>
    /// Decode a data block written as an EDS.
    /// </summary>
    /// <param name="data">The data to encode.</param>
    /// <returns>The decoded data.</returns>
    public byte[] DecodeEDS(byte[] data) {
        using var input = new JsonBcdReader(data);
        var saltSuffix = input.ReadBinary();

        using var output = new MemoryStream();
        var encoderData = GetDecoder(input, out var Reader, data.LongLength, saltSuffix);
        Reader.CopyTo(output);
        encoderData.Close();

        // Check MAC if specified.

        return output.ToArray();
        }

    /// <summary>
    /// Decode a data block written as an EDS.
    /// </summary>
    /// <param name="data">The data to encode.</param>
    /// <returns>The decoded data.</returns>
    public byte[] DecodeBody(byte[] data) {
        using var input = new MemoryStream(data);
        using var output = new MemoryStream();

        var EncoderData = GetDecoder(input, out var Reader, data.LongLength, null);
        Reader.CopyTo(output);
        EncoderData.Close();

        // Check MAC if specified.

        return output.ToArray();
        }

    /// <summary>
    /// Calculate the length of the trailer.
    /// </summary>
    /// <returns></returns>
    public DareTrailer GetDummyTrailer() {
        DareTrailer result = null;

        var digestLength = CryptoCatalog.Default.ResultInBytes(DigestId);
        if (digestLength > 0) {
            result = new DareTrailer() {
                PayloadDigest = new byte[digestLength]
                };
            }

        // Hack: does not create a dummy signature trailer.

        return result;
        }

    }
