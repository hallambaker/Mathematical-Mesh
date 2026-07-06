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

using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.PQC;
using Goedel.Mesh.Test;
using Goedel.Protocol;
using Goedel.Test;
using Goedel.Utilities;

using System.Net.WebSockets;
using System.Security.Cryptography;

namespace ExampleGenerator;



public record TestVector {
    public string Title { get; set; }
    public string EncryptionAlgorithm { get; set; } = "none";

    public string SignatureAlgorithm { get; set; } = "none";

    public DareEnvelope JsonSerialication { get; set; }
    public byte[] BinarySerialization { get; set; }

    }




public class DareResults {
    public CreateExamples CreateExamples { get; }

    public DareEnvelope EnvelopeMini { get; set; }
    public DareSequence SequenceMini { get; set; }


    public DareEnvelope Envelope2 { get; set; }
    public DareSequence Sequence2 { get; set; }


    public byte[] ExchangedKey { get; set; }
    public string ExchangedKeyId { get; set; }


    public int KeySize => 256;

    public JsonObject RecipientPublicKey { get; set; }


    public CryptoAlgorithmId EncryptId { get; } = CryptoAlgorithmId.AES256GCM;
    public DareRecipient Recipient { get; } 

    public DareHeader EncryptedUnsignedHeader { get; } 

    public byte[] SharedSecret { get; set; }
    public string Wrapped { get; set; }

    public JsonObject RecipientInfo { get; set; }

    public byte[] Salt { get; set; }
    public byte[] KDFIn { get; set; }

    public byte[] KDFOut{ get; set; }
    public byte[] EncryptionKey { get; set; }
    public byte[] EncryptionIV { get; set; }

    public byte[] EncryptedPayload { get; set; }

    public byte[] SignedContentMeta { get; set; }
    public int TagLength => 16;

    public DareEnvelope EnvelopedEncryption { get; set; }


    public DareHeader Preamble { get; set; }

    public DareSignature PreambleSignature { get; set; }    
    public DareTrailer Trailer { get; set; }

    public DareSignature TrailerSignature { get; set; }

    public CryptoAlgorithmId SignatureDigest = CryptoAlgorithmId.SHA_3_512;



    public byte[] SignedHeaderDigest { get; set; }
    public byte[] PayloadDigest { get; set; }
    public byte[] Manifest { get; set; }
    public byte[] SignatureValue { get; set; }

    public JsonObject SignatureKey { get; set; }

    public string SignatureKeyId { get; set; }


    public DareEnvelope EnvelopedSigned { get; set; }


    public DareHeader PreambleSequence { get; set; }
    public DareEnvelope EnvelopeInSequence { get; set; }
    public DareSequence SignatureInSequence { get; set; }

    public List<TestVector> EnvelopeTests { get; set; } = [];
    public List<TestVector> SequenceTests { get; set; } = [];

    public const string TestPayload = "This is a test for Data At Rest Envelope";
    public const string TestPayload2 = "This is a test";

    public byte[] TestPayloadBytes { get; set; } = TestPayload.ToBytes();

    public const string TestPayloadMedia = "text/plain";

    public KeyPair KeyPairX448 { get; set; }
    public KeyPairX25519 KeyPairX25519 { get; set; }
    public KeyPair KeyPairEd448 { get; set; }
    public KeyPair KeyPairEd25519 { get; set; }

    public KeyPair PublicX448 { get; set; }
    public KeyPairX25519 PublicX25519 { get; set; }
    public KeyPair PublicEd448 { get; set; }
    public KeyPair PublicEd25519 { get; set; }

    public byte[] ContextString { get; }





    public KeyCollectionEphemeral KeyCollection { get; } = new();


    public ContentMeta TestPayloadMeta { get; set; } = new ContentMeta() {
        ContentType = TestPayloadMedia
        };

    public DareResults(CreateExamples createExamples) {
        CreateExamples = createExamples;


        EnvelopeMini = DareEnvelope.Create(TestPayloadMeta, TestPayloadBytes);
        SequenceMini = new();
        SequenceMini.Add(EnvelopeMini);

        Envelope2 = DareEnvelope.Create(TestPayloadMeta, TestPayload2.ToBytes());

        Sequence2 = new();
        Sequence2.Add(EnvelopeMini);
        Sequence2.Add(Envelope2);

        Console.WriteLine(EnvelopeMini);


        // Generate key pairs.

        KeyPairX448 = KeyPair.Factory(CryptoAlgorithmId.X448,
                KeySecurity.Exportable, KeyCollection, keyUses: KeyUses.Encrypt);
        PublicX448 = KeyPairX448.KeyPairPublic();

        KeyPairX25519 = KeyPair.Factory(CryptoAlgorithmId.X25519,
                KeySecurity.Exportable, KeyCollection, keyUses: KeyUses.Encrypt) as KeyPairX25519;
        PublicX25519 = KeyPairX25519.KeyPairPublic() as KeyPairX25519;

        KeyPairEd448 = KeyPair.Factory(CryptoAlgorithmId.Ed448,
                KeySecurity.Exportable, KeyCollection, keyUses: KeyUses.Sign);
        PublicEd448 = KeyPairEd448.KeyPairPublic();

        KeyPairEd25519 = KeyPair.Factory(CryptoAlgorithmId.Ed25519,
                KeySecurity.Exportable, KeyCollection, keyUses: KeyUses.Sign);
        PublicEd25519 = KeyPairEd25519.KeyPairPublic();



        // Encryption example

        ExchangedKey = Platform.GetRandomBits(KeySize);
        ExchangedKeyId = Udf.ContentDigestOfDataString(ExchangedKey,"application/key");


        // Calculate the recipient key blob
        RecipientPublicKey = Key.GetPublic(PublicX25519);
        //PublicX25519.Encrypt(ExchangedKey, out var exchange, out var agreementData);


        var agreement = PublicX25519.PublicKey.Agreement();
        SharedSecret = agreement.KeyDerive.Derive(null, length: 256);
        var wrappedKey = Platform.KeyWrapRFC3394.Wrap(SharedSecret, ExchangedKey);



        Recipient = new () {
            Epk = Key.GetPublic(agreement.EphemeralKeyPair as KeyPair),
            KeyIdentifier = PublicX25519.KeyIdentifier,
            WrappedBaseSeed = wrappedKey
            };


        Salt = Platform.GetRandomBits(KeySize);
        EncryptedUnsignedHeader = new DareHeader() {
            EncryptionAlgorithm =EncryptId.ToJoseID(),
            Salt = Salt,
            Recipients = [Recipient]
            };

        KDFIn = Salt.Concat (ExchangedKey);
        KDFOut = Shake256.HashData(KDFIn, 32 + 12); // need 32 byte key and 12 byte nonce

        EncryptionIV = KDFOut.Extract(0, 12);
        EncryptionKey = KDFOut.Extract(12, 32);

        EncryptedPayload = new byte[TestPayloadBytes.Length + TagLength];
        SignedContentMeta = TestPayloadMeta.ToBytes();

        var ciphertextSpan = new Span<byte>(EncryptedPayload, 0, TestPayloadBytes.Length);
        var tagSpan = new Span<byte>(EncryptedPayload, TestPayloadBytes.Length, TagLength);

        var encryptor = new AesGcm(EncryptionKey, TagLength);
        encryptor.Encrypt(new ReadOnlySpan<byte>(EncryptionIV), new ReadOnlySpan<byte>(TestPayloadBytes),
            ciphertextSpan, tagSpan, new ReadOnlySpan<byte>(SignedContentMeta)); 

        EnvelopedEncryption = DareEnvelope.Create(EncryptedPayload, EncryptedUnsignedHeader,
                SignedContentMeta);

        // Signature example

        PreambleSignature = new() {
            Dig = SignatureDigest.ToJoseID(),
            Alg = PublicEd25519.CryptoAlgorithmId.ToJoseID(),
            KeyIdentifier = PublicEd25519.KeyIdentifier
            };

        Preamble = new () {
            Signatures = [PreambleSignature]
            };

        SignedHeaderDigest = SHA3_512.HashData(SignedContentMeta);
        PayloadDigest = SHA3_512.HashData(TestPayloadBytes);



        var digestId = PreambleSignature.Dig.ToUTF8().Concat ([0]);
        Manifest = digestId.Concat (SignedHeaderDigest, PayloadDigest);

        ContextString = "DARE-Signature".ToBytes();


        SignatureValue = KeyPairEd25519.Sign(Manifest, CryptoAlgorithmId.Ed25519, ContextString);

        TrailerSignature = new() {
            Dig = SignatureDigest.ToJoseID(),
            Alg = PublicEd25519.CryptoAlgorithmId.ToJoseID(),
            KeyIdentifier = PublicEd25519.KeyIdentifier,
            SignatureValue = SignatureValue
            };

        Trailer = new() {
            Signatures = [TrailerSignature]
            };


        EnvelopedSigned = DareEnvelope.Create(TestPayloadBytes, Preamble, SignedContentMeta, Trailer);

        // Same for sequence
        PreambleSequence = new() {
            Signatures = [TrailerSignature]
            };
        EnvelopeInSequence = DareEnvelope.Create(TestPayloadBytes, PreambleSequence, SignedContentMeta);
        SignatureInSequence = new();
        SignatureInSequence.Add(EnvelopeInSequence);


        EnvelopeTests.Add(MakeTestEnvelope("Plaintext Unsigned"));
        EnvelopeTests.Add(MakeTestEnvelope("Encrypted Unsigned", encrypt: "X25519"));
        EnvelopeTests.Add(MakeTestEnvelope("Plaintext Signed", sign:"Ed25519"));
        EnvelopeTests.Add(MakeTestEnvelope("Encrypted Signed", sign: "Ed25519", encrypt: "X25519"));
        }

    TestVector MakeTestEnvelope(string title, string encrypt = "none", string sign = "none") {
        return new TestVector() {
            Title = title,
            EncryptionAlgorithm = encrypt,
            SignatureAlgorithm = sign
            };
        }

    TestVector MakeTestSequence(string title, string encrypt = "none", string sign = "none") {
        return new TestVector() {
            Title = title,
            EncryptionAlgorithm = encrypt,
            SignatureAlgorithm = sign
            };
        }

    }
