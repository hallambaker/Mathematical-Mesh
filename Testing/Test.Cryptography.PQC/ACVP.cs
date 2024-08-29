namespace Goedel.Test;

public class DsaKeyGenTest : AcvpTest {

    public byte[] Seed { get; set; }

    public byte[] PublicKey { get; set; }

    public byte[] SecretKey { get; set; }

    //public byte[] Z { get; set; }

    public MlDsaMode Mode => GroupData.ParameterSet switch {
        "ML-DSA-44" => MlDsaMode.Mode44,
        "ML-DSA-65" => MlDsaMode.Mode65,
        "ML-DSA-87" => MlDsaMode.Mode87,
        _ => throw new NYI()
        };

    public override void Populate(AcvpTestGroup group, AcvpTestItem test) {
        base.Populate(group, test);
        Seed = BindBinary(test, "seed");
        PublicKey = BindBinary(test, "pk");
        SecretKey = BindBinary(test, "sk");
        //Z = BindBinary(test, "z");
        }


    public override void Test() {
        var (publicKey, secretKey) = MLDSA.GenerateKeypair(Mode, Seed);
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
        var secretKey = new MlDsaPrivate(SecretKey);
        var signature = secretKey.SignInternal(Message, Rnd);
        signature.TestEqual(Signature);
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
        var publicKey = new MlDsaPublic(PublicKey);
        var test = publicKey.Verify(Signature, Message);
        test.TestEqual(TestPassed == true);

        // not currently using the reason codes.

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
        EncryptionKey = BindBinary(test, "ek");
        DecryptionKey = BindBinary(test, "dk");
        }

    public MlKem MlKem => GroupData.ParameterSet switch {
        "ML-KEM-512" => MlKem.MLKEM512,
        "ML-KEM-768" => MlKem.MLKEM768,
        "ML-KEM-1024" => MlKem.MLKEM1024,
        _ => throw new NYI()
        };

    public override void Test() {
        var (publicKey, secretKey) = MlKem.MlKeyGen(Z, D);

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
        switch (GroupData.Function) {
            case "encapsulation": {
                var publicKey = new MlKemPublic(EncryptionKey);
                var (sharedSecret, ciphertext) = publicKey.EncapsInternal(Message);

                sharedSecret.TestEqual(SharedSecret);
                ciphertext.TestEqual(Ciphertext);

                // for completeness, check we can deencapsulate?
                var privateKey = new MlKemPrivate(DecryptionKey);

                var recoveredMessage = privateKey.Decrypt(ciphertext);
                recoveredMessage.TestEqual(SharedSecret);
                break;
                }

            case "decapsulation": {
                var privateKey = new MlKemPrivate(DecryptionKey);
                var recoveredMessage = privateKey.Decrypt(Ciphertext);

                recoveredMessage.TestEqual(SharedSecret);
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
