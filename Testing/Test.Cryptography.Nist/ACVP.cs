



using Goedel.Cryptography;
using Goedel.Cryptography.Nist;
using Goedel.Cryptography.PQC;

using System;
using System.Collections;

namespace Goedel.Test;


public static class Extensions {

    public static KyberParameterSet MlKem(this AcvpTestGroup GroupData) => GroupData.ParameterSet switch {
        "ML-KEM-512" => KyberParameterSet.ML_KEM_512,
        "ML-KEM-768" => KyberParameterSet.ML_KEM_768,
        "ML-KEM-1024" => KyberParameterSet.ML_KEM_1024,
        _ => throw new NYI()
        };


    public static DilithiumParameterSet Mode(this AcvpTestGroup GroupData) => GroupData.ParameterSet switch {
        "ML-DSA-44" => DilithiumParameterSet.ML_DSA_44,
        "ML-DSA-65" => DilithiumParameterSet.ML_DSA_65,
        "ML-DSA-87" => DilithiumParameterSet.ML_DSA_87,
        _ => throw new NYI()
        };


    public static DilithiumNist GetDsa(this AcvpTestGroup GroupData) {
        var shaFactory = new NativeShaFactory();
        var parameterSet = GroupData.Mode();
        var parameters = new DilithiumParameters(parameterSet);
        var dilithium = new DilithiumNist(parameters, shaFactory);

        return dilithium;
        }


    }




public class DsaKeyGenTest : AcvpTest {

    public byte[] Seed { get; set; }

    public byte[] PublicKey { get; set; }

    public byte[] SecretKey { get; set; }


    public override void Populate(AcvpTestGroup group, AcvpTestItem test) {
        base.Populate(group, test);
        Seed = BindBinary(test, "seed");
        PublicKey = BindBinary(test, "pk");
        SecretKey = BindBinary(test, "sk");
        //Z = BindBinary(test, "z");
        }


    public override void Test() {

        //var dilithium = GroupData.GetDsa();

        //var (publicKey, secretKey) = dilithium.GenerateKey(Seed);
        //publicKey.TestEqual(PublicKey);
        //secretKey.TestEqual(SecretKey);


        var parameterSet = GroupData.Mode();
        var privateKey = DilithiumPrivate.FromSeed(Seed, parameterSet);
        privateKey.PublicKey.TestEqual(PublicKey);
        privateKey.SecretKey.TestEqual(SecretKey);


        }

    }
public class DsaSignTest : DsaKeyGenTest {

    public byte[] Message { get; set; }

    public byte[] Signature { get; set; }

    public byte[] Rnd { get; set; }

    public bool? Deterministic { get; set; }


    public override void Populate(AcvpTestGroup group, AcvpTestItem test) {
        base.Populate(group, test);
        Message = BindBinary(test, "message");
        Signature = BindBinary(test, "signature");
        Rnd = BindBinary(test, "rnd");
        Deterministic = BindBool(group, "deterministic");
        }

    public override void Test() {
        var privateKey = DilithiumPrivate.FromSecretKey(SecretKey);

        if (Deterministic == true) {
            var signature = privateKey.SignInternal(Message);
            signature.TestEqual(Signature);
            }

        else {
            var signature = privateKey.SignInternal(Message, Rnd);
            signature.TestEqual(Signature);
            }

        }

    }

public class DsaVerifyTest : DsaKeyGenTest {
    public byte[] Message { get; set; }

    public byte[] Signature { get; set; }

    public string Reason { get; set; }
    public bool? TestPassed { get; set; }

    public override void Populate(AcvpTestGroup group, AcvpTestItem test) {
        base.Populate(group, test);

        PublicKey = BindBinary(group, "pk");
        SecretKey = BindBinary(group, "sk");
        Message = BindBinary(test, "message");
        Signature = BindBinary(test, "signature");

        Reason = BindString(test, "reason");
        TestPassed = BindBool(test, "testPassed");
        }

    public override void Test() {

        var publicKey = DilithiumPublic.FromPublicKey(PublicKey);

        //var message = MsbLsbConversionHelpers.MostSignificantByteArrayToLeastSignificantBitArray(Message);
        var test = publicKey.Verify(Signature, Message);

        test.TestEqual(TestPassed == true);
        }

    }




public class KemKeyGenTest : AcvpTest {

    public byte[] Z { get; set; }

    public byte[] D { get; set; }

    public byte[] EncryptionKey { get; set; }

    public byte[] DecryptionKey { get; set; }

    public override void Populate(AcvpTestGroup group, AcvpTestItem test) {
        base.Populate(group, test);
        Z = BindBinary(test, "z");
        D = BindBinary(test, "d");
        EncryptionKey = BindBinary(group, "ek") ?? BindBinary(test, "ek");
        DecryptionKey = BindBinary(group, "dk") ?? BindBinary(test, "dk");
        }

    public override void Test() {
        var parameterSet = GroupData.MlKem();

        var privateKey = KyberPrivate.FromZD(Z, D, parameterSet);
        EncryptionKey.TestEqual(privateKey.PublicKey);
        DecryptionKey.TestEqual(privateKey.SecretKey);
        }

    }

public class KemEncapDecapTest : KemKeyGenTest {
    public byte[] Ciphertext { get; set; }
    public byte[] Message { get; set; }
    public byte[] SharedSecret { get; set; }
    public string Reason { get; set; }
    public override void Populate(AcvpTestGroup group, AcvpTestItem test) {
        base.Populate(group, test);
        Ciphertext = BindBinary(test, "c");
        Message = BindBinary(test, "m");
        SharedSecret = BindBinary(test, "k");
        Reason = BindString(test, "reason");
        }

    public override void Test() {
        //var kyber = GroupData.GetKem();

        switch (GroupData.Function) {
            case "encapsulation": {
                var publicKey = KyberPublic.FromPublicKey(EncryptionKey);
                var (sharedSecret, ciphertext) = publicKey.Encapsulate(Message);

                sharedSecret.TestEqual(SharedSecret);
                ciphertext.TestEqual(Ciphertext);

                // for completeness, check we can deencapsulate
                var secretKey = KyberPrivate.FromSecretKey(DecryptionKey);

                var (recoveredMessage, implicitRejection) = secretKey.Decapsulate(ciphertext);
                recoveredMessage.TestEqual(SharedSecret);
                break;
                }

            case "decapsulation": {
                var secretKey = KyberPrivate.FromSecretKey(DecryptionKey);
                var (recoveredMessage, implicitRejection) = secretKey.Decapsulate(Ciphertext);

                recoveredMessage.TestEqual(SharedSecret);
                var reason = implicitRejection ? "modify ciphertext" : "no modification";

                reason.TestEqual(Reason);
                break;
                }
            }
        }

    }







public class MessageLength {
    public int min { get; set; }
    public int max { get; set; }
    public int increment { get; set; }
    }
