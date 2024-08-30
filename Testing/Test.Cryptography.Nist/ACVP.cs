using Goedel.Cryptography.Nist;
using Goedel.Cryptography.PQC;

using System.Collections;

namespace Goedel.Test;


public static class Extensions {

    public static KyberParameterSet MlKem (this AcvpTestGroup GroupData)  => GroupData.ParameterSet switch {
        "ML-KEM-512" => KyberParameterSet.ML_KEM_512,
        "ML-KEM-768" => KyberParameterSet.ML_KEM_768,
        "ML-KEM-1024" => KyberParameterSet.ML_KEM_1024,
        _ => throw new NYI()
        };

    public static IMLKEM GetKem(this AcvpTestGroup GroupData) {
        var shaFactory = new NativeShaFactory();
        var KyberFactory = new KyberFactory(shaFactory);

        var parameters = GroupData.MlKem();
        var kyber = KyberFactory.GetKyber(parameters);

        return kyber;
        }

    public static DilithiumParameterSet Mode(this AcvpTestGroup GroupData) => GroupData.ParameterSet switch {
        "ML-DSA-44" => DilithiumParameterSet.ML_DSA_44,
        "ML-DSA-65" => DilithiumParameterSet.ML_DSA_65,
        "ML-DSA-87" => DilithiumParameterSet.ML_DSA_87,
        _ => throw new NYI()
        };


    public static IMLDSA GetDsa(this AcvpTestGroup GroupData) {
        var shaFactory = new NativeShaFactory();
        var random = new Random800_90();
        var entropy = new EntropyProvider(random);

        var KyberFactory = new DilithiumFactory(shaFactory, entropy);

        var parameters = GroupData.Mode();
        var kyber = KyberFactory.GetDilithium(parameters);

        return kyber;
        }


    }


public class DsaKeyGenTest : AcvpTest {

    public byte[] Seed { get; set; }

    public byte[] PublicKey { get; set; }

    public byte[] SecretKey { get; set; }

    //public byte[] Z { get; set; }

    //public MlDsaMode Mode => GroupData.ParameterSet switch {
    //    "ML-DSA-44" => MlDsaMode.Mode44,
    //    "ML-DSA-65" => MlDsaMode.Mode65,
    //    "ML-DSA-87" => MlDsaMode.Mode87,
    //    _ => throw new NYI()
    //    };

    public override void Populate(AcvpTestGroup group, AcvpTestItem test) {
        base.Populate(group, test);
        Seed = BindBinary(test, "seed");
        PublicKey = BindBinary(test, "pk");
        SecretKey = BindBinary(test, "sk");
        //Z = BindBinary(test, "z");
        }


    public override void Test() {

        var dilithium = GroupData.GetDsa();

        var seed = MsbLsbConversionHelpers.MostSignificantByteArrayToLeastSignificantBitArray(Seed);
        var (publicKey, secretKey) = dilithium.GenerateKey(seed);
        publicKey.TestEqual(PublicKey);
        secretKey.TestEqual(SecretKey);
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

        var dilithium = GroupData.GetDsa();



        var message = MsbLsbConversionHelpers.MostSignificantByteArrayToLeastSignificantBitArray(Message);

        if (Deterministic == true) {
            var signature = dilithium.Sign(SecretKey, message, true);

            signature.TestEqual(Signature);
            }

        else {
            var rnd = MsbLsbConversionHelpers.MostSignificantByteArrayToLeastSignificantBitArray(Rnd);

            var signature = dilithium.Sign(SecretKey, message, false, rnd);

            signature.TestEqual(Signature);

            //var test = dilithium.Verify(SecretKey, Signature, message);


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
        var dilithium = GroupData.GetDsa();

        var message = MsbLsbConversionHelpers.MostSignificantByteArrayToLeastSignificantBitArray(Message);
        var test = dilithium.Verify(PublicKey, Signature, message);

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

        var kyber = GroupData.GetKem();

        var (publicKey, secretKey) = kyber.GenerateKey(Z, D);

        EncryptionKey.TestEqual(publicKey);
        DecryptionKey.TestEqual(secretKey);
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
        var kyber = GroupData.GetKem();

        switch (GroupData.Function) {
            case "encapsulation": {
                var (sharedSecret, ciphertext) = kyber.Encapsulate(EncryptionKey, Message);

                sharedSecret.TestEqual(SharedSecret);
                ciphertext.TestEqual(Ciphertext);

                // for completeness, check we can deencapsulate
                var (recoveredMessage, implicitRejection) = kyber.Decapsulate(DecryptionKey, ciphertext);
                recoveredMessage.TestEqual(SharedSecret);
                break;
                }

            case "decapsulation": {
                var (recoveredMessage, implicitRejection) = kyber.Decapsulate(DecryptionKey, Ciphertext);

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
