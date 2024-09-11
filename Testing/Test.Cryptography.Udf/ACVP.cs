using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Nist;
using Goedel.Cryptography.PQC;
using Goedel.Mesh.Test;
using Goedel.Protocol;
using Goedel.XUnit;

using System;
using System.Collections;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace Goedel.Test;





public class UdfKeyGenTest : AcvpTest {

    public string? SeedUdf { get; set; }

    public byte[]? KeyUdf { get; set; }

    public string? KeyUdfString { get; set; }

    public string? KeyAlgorithm { get; set; }


    public string? Hints { get; set; }


    public string? Mode { get; set; }

    public UdfKeyGenTest() {
        }

    public UdfKeyGenTest (
                    int testId, 
                    UdfAlgorithmIdentifier udfAlgorithm,
                    KeyGenTestMode mode,
                    int size = 256,
                    bool keepHints = true) {
        var data = SHAKE256.Process($"This is a common test seed of {testId}".ToBytes(), size);
        
        SeedUdf = Udf.DerivedKey(udfAlgorithm, data);
        var (keypair, hints) = Udf.DeriveKeyHints(SeedUdf, null);

        TestKey(keypair, mode);

        KeyUdf = keypair.UDFBytes;
        KeyUdfString = keypair.UDFValue;
        KeyAlgorithm = keypair.CryptoAlgorithmId.ToString();
        Hints = keepHints ? hints : null;
        Mode = mode.ToString();

        TestData = new AcvpTestItem() {
            TcId = testId,
            };


        Bind(TestData, "seedUdf", this.SeedUdf);
        Bind(TestData, "keyUdf", KeyUdf);
        Bind(TestData, "keyUdfValue", KeyUdfString);
        Bind(TestData, "keyalg", KeyAlgorithm);
        Bind(TestData, "hints", Hints);
        Bind(TestData, "mode", Mode);
        }


    void TestKey(KeyPair keyPair, KeyGenTestMode mode) {
        keyPair.PublicOnly.TestFalse();

        switch (mode) {
            case KeyGenTestMode.Sign: {
                TestKeySign(keyPair);
                break;
                }
            case KeyGenTestMode.Encrypt: {
                TestKeyEncrypt(keyPair);
                break;
                }
            case KeyGenTestMode.SignEncrypt: {
                TestKeySign(keyPair);
                TestKeyEncrypt(keyPair);
                break;
                }
            }

        }

    void TestKeySign(KeyPair keyPair) {
        // Create test data
        var testData = $"Signature test {keyPair.UDFValue}".ToBytes();


        // Create signature over test data using DARE
        var keyCollection = new KeyCollectionEphemeral();
        keyCollection.Add(keyPair);

        var parameters = new CryptoParameters(signer: keyPair);

        var envelope =  DareEnvelope.Encode (parameters, testData);

        // verify signature
        var validEnvelope = DareEnvelope.Verify(envelope, keyCollection);
        validEnvelope.VerifySignature(keyPair).TestTrue();

        var testDare = new TestDare(envelope);
        var e2 = testDare.GetBytes();

        testDare.CorruptBody();
        var e3 = testDare.GetBytes();

        // make sure it is corrupted
        e3.TestNotEqual(e2);

        // verify invalid signature
        var invalidEnvelope = DareEnvelope.Verify(e3, keyCollection);
        invalidEnvelope.VerifySignature(keyPair).TestFalse();

        }

    void TestKeyEncrypt(KeyPair keyPair) {
        // Create test data
        var testData = $"Encryption test {keyPair.UDFValue}".ToBytes();

        var keyCollection = new KeyCollectionEphemeral();
        keyCollection.Add(keyPair);

        // encrypt the data
        var parameters = new CryptoParameters(recipient: keyPair);
        var envelope = DareEnvelope.Encode(parameters, testData);


        // decrypt the data
        var readStream = new MemoryStream(envelope);
        var output = new MemoryStream();
        var data = DareEnvelope.Decode(readStream, output, keyCollection: keyCollection);


        var result = output.ToArray();
        var resultText = result.ToUTF8();
        //Console.WriteLine($"Result {resultText}");

        testData.TestEqual(result);
        }


    public override void Populate(AcvpTestGroup group, AcvpTestItem test) {
        base.Populate(group, test);
        SeedUdf = BindString(test, "seedUdf");
        KeyUdf = BindBinary(test, "keyUdf");
        KeyUdfString = BindString(test, "keyUdfValue");
        KeyAlgorithm = BindString(test, "keyalg");
        Hints = BindString(test, "hints");
        }


    public override void Test() {
        //var (keypair1, hints) = Udf.DeriveKeyHints(SeedUdf, null);


        var keypair = Udf.DeriveKey(SeedUdf, Hints);


        keypair.UDFBytes.TestEqual(KeyUdf);
        keypair.UDFValue.TestEqual(KeyUdfString);
        keypair.CryptoAlgorithmId.ToString().TestEqual(KeyAlgorithm);

        }



    }


