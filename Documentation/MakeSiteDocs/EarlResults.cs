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

using System.Security.Cryptography;

using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Dare;
using Goedel.Test;
using Goedel.Utilities;

namespace ExampleGenerator;

public class EarlResults {
    public CreateExamples CreateExamples { get; }

    public byte[] Payload { get; }
    public ContentMeta ProtectedHeaderJson { get; } = new ContentMeta() {
        ContentType = "text/plain",
        Nonce = Udf.FixedNonce("EarlTest1")
        };

    public ContentMeta ProtectedHeaderJson2 { get; } = new ContentMeta() {
        ContentType = "text/plain",
        Nonce = Udf.FixedNonce("EarlTest2")
        };
    public ContentMeta ProtectedHeaderJson3 { get; } = new ContentMeta() {
        ContentType = "text/plain",
        Nonce = Udf.FixedNonce("EarlTest3")
        };

    public ContentMeta ProtectedHeaderJson4 { get; } = new ContentMeta() {
        ContentType = "text/plain",
        Nonce = Udf.FixedNonce("EarlTest4")
        };

    public byte[] ProtectedHeader { get; }


    public byte[] EnvelopeContent { get; }
    public byte[] EnvelopeContentMeta { get; }

    public byte[] ContentDigest { get; }
    public byte[] ContentDigestTruncated { get; }

    public int Precision { get; } = 140;
    public byte VersionTag { get; } = 34;


    public string EarlPath { get; }

    public string EarlName => $"earl:{EarlPath}";
    public string EarlLocator => $"earl://{CreateExamples.AliceService}/{EarlPath}";
    public string EarlJSContact => $"jscontact://{CreateExamples.AliceService}/{EarlPath}";

    
    public byte[] AesKeyNonce { get; }


    public byte[] Ciphertext { get; }

    public byte[] Locator1 { get; }
    public byte[] Locator2 { get; }


    public string Password { get; }

    public string Locator { get; }
    public string LocatorUri { get; }

    public EarlSet WithMeta { get; }
    public EarlSet WithNonce { get; }
    public EarlSet WithNonce2 { get; }


    public KeyPairECDH SignatureEd25519 { get; }
    public KeyPairECDH SignatureEd448 { get; }


    public KeyCollection SigningKeys { get; } = new KeyCollectionEphemeral();


    public VDareEnvelopeWriter Unsigned { get; }

    public VDareEnvelopeWriter Signed25519 { get; }
    public VDareEnvelopeWriter SignedEd448 { get; }


    public EarlSet WithType1 { get; }

    public EarlSet With25519 { get; }
    public EarlSet WithEd448 { get; }


    public string FirstChunk => "First Chunk";
    public string SecondChunk => "Second Chunk";


    public byte[] BytesMeta { get; }
    public byte[] BytesUnsigned { get; }

    public byte[] Bytes25519 { get; }
    public byte[] Bytes448 { get; }

    public EarlResults(CreateExamples createExamples) {
        CreateExamples = createExamples;

        Payload = CreateExamples.TestFile1Text.ToUTF8();
        var checkSet = new EarlSet(null, Payload);


        EnvelopeContent = VDareEnvelopeWriter.GetBytes(Payload);
        ContentDigest = Shake256.HashData(EnvelopeContent, 32);

        var bytes = (Precision + 7) / 8;

        ContentDigestTruncated = ContentDigest[0..(bytes)];
        ContentDigestTruncated[0] = VersionTag;

        EarlPath = ContentDigestTruncated.ToStringBase32(format: ConversionFormat.Dash4,
                outputMax: Precision / 5).ToLower();
        checkSet.Earl.TestEqual(EarlPath);

        var copy = ContentDigestTruncated[..];
        var length = 5 * (Precision / 20) - 1;
        if ((length + 1) % 10 != 0) {
            copy[^1] &= 0xF0;
            }

        var recovered = EarlPath.FromBase32(partial: true);
        recovered.TestEqual(copy);

        AesKeyNonce = Shake256.HashData(recovered, 44);

        Ciphertext = Udf.EarlCiphertext(EnvelopeContent, EarlPath);
        checkSet.Ciphertext.TestEqual(Ciphertext);

        Locator1 = SHA3_256.HashData(recovered);
        Locator2 = SHA3_256.HashData(Locator1);

        Locator = Locator2.ToStringBase64url();
        LocatorUri = EarlSet.GetWellKnown(CreateExamples.AliceService, Locator);

        Password = Locator1.ToStringBase32();

        checkSet.Locator.TestEqual(Locator);

        var plaintext = Udf.GetDecryptedData(Ciphertext, EarlPath);
        var (recoveredMeta, recoveredPayload) = VDareEnvelopeReader.Parse(plaintext);
        recoveredPayload.TestEqual(Payload);
        recoveredMeta.TestNull();

        // Same but with a protected header
        EnvelopeContentMeta = VDareEnvelopeWriter.GetBytes(Payload, ProtectedHeaderJson);

        WithMeta = new EarlSet(EnvelopeContentMeta, CreateExamples.AliceService);
        BytesMeta = Verify(WithMeta, ProtectedHeaderJson, Payload, SigningKeys);

        using (var stream = new MemoryStream()) {
            Unsigned = new(stream, ProtectedHeaderJson);
            Unsigned.Write(FirstChunk);
            Unsigned.Write(SecondChunk);
            Unsigned.End();
            BytesUnsigned = stream.ToArray();
            }
        WithType1 = new EarlSet(BytesUnsigned, CreateExamples.AliceService);





        plaintext = Udf.GetDecryptedData(WithMeta.Ciphertext, WithMeta.Earl);
        (recoveredMeta, recoveredPayload) = VDareEnvelopeReader.Parse(plaintext);
        recoveredPayload.TestEqual(Payload);
        (recoveredMeta.Nonce == ProtectedHeaderJson.Nonce).TestTrue();

        WithNonce = new EarlSet(ProtectedHeaderJson, Payload, CreateExamples.AliceService);
        WithNonce2 = new EarlSet(ProtectedHeaderJson2, Payload, CreateExamples.AliceService);

        Verify(WithNonce, ProtectedHeaderJson, Payload, SigningKeys);
        Verify(WithNonce2, ProtectedHeaderJson2, Payload, SigningKeys);

        SignatureEd25519 = KeyPairEd25519.Generate(KeySecurity.Exportable, KeyUses.Sign);
        SignatureEd448 = KeyPairEd448.Generate(KeySecurity.Exportable, KeyUses.Sign);

        SigningKeys.Add(SignatureEd25519.KeyPairPublic());
        SigningKeys.Add(SignatureEd448.KeyPairPublic());

        var chunks = (FirstChunk + SecondChunk).ToUTF8();

        using (var stream1 = new MemoryStream()) {
            Signed25519 = new(stream1, ProtectedHeaderJson3, signers: [SignatureEd25519]);
            Signed25519.Write(FirstChunk);
            Signed25519.Write(SecondChunk);
            Signed25519.End();

            Bytes25519 = stream1.ToArray();
            }

        With25519 = new EarlSet(Bytes25519, CreateExamples.AliceService);

        Verify(With25519, ProtectedHeaderJson3, chunks, SigningKeys);

        using (var stream2 = new MemoryStream()) {
            SignedEd448 = new(stream2, ProtectedHeaderJson4, signers: [SignatureEd448]);
            SignedEd448.Write(chunks);
            SignedEd448.End();
            Bytes448 = stream2.ToArray();
            }

        WithEd448 = new EarlSet(Bytes448, CreateExamples.AliceService);

        Verify(WithEd448, ProtectedHeaderJson4, chunks, SigningKeys);
        }


    byte[] Verify(
                    EarlSet earlSet,
                    ContentMeta contentMeta,
                    byte[] payload,
                    KeyCollection keyCollection) {
        var plaintext = Udf.GetDecryptedData(earlSet.Ciphertext, earlSet.Earl);
        var (recoveredMeta, recoveredPayload) = VDareEnvelopeReader.Parse(plaintext, SigningKeys);
        (recoveredMeta.Nonce == contentMeta.Nonce).TestTrue();
        (recoveredMeta.ContentType == contentMeta.ContentType).TestTrue();

        return plaintext;

        }
    }
