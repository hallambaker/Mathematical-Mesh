using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Core;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;
using Goedel.Protocol.Debug;
using Goedel.Test;
using Goedel.Test.Core;
using Goedel.Utilities;

using System;
using System.IO;
using System.Numerics;
using System.Collections.Generic;

namespace ExampleGenerator {

    public static class Extension {
        public static (BigInteger X, BigInteger Y) GetXY(this Curve curve) {
            switch (curve) {

                case CurveMontgomery curveMontgomery: {
                    return (curveMontgomery.U,
                        curveMontgomery.V);
                    }
                case CurveEdwards curveEdwards: {
                    return (curveEdwards.X,
                        curveEdwards.Y);
                    }
                }

            throw new NYI();
            }

        
        }
    public partial class Threshold {
        public KeyGen KeyGenX25519;
        public KeyGen KeyGenX448;
        public KeyGen KeyGenEd25519;
        public KeyGen KeyGenEd448;

        public Decrypt DecryptX25519;
        public Decrypt DecryptX448;


        public Threshold() {
            KeyGenX25519 = new KeyGen(CryptoAlgorithmID.X25519);
            KeyGenX448 = new KeyGen(CryptoAlgorithmID.X448);
            KeyGenEd25519 = new KeyGen(CryptoAlgorithmID.Ed25519);
            KeyGenEd448 = new KeyGen(CryptoAlgorithmID.Ed448);

            DecryptX25519 = new Decrypt(CryptoAlgorithmID.X25519);
            DecryptX448 = new Decrypt(CryptoAlgorithmID.X448);
            }
        }


    public partial class CurveResult {
        public Curve CurvePoint;
        public IKeyAdvancedPublic Key;

        public byte[] Public;

        public bool IsCurveX => CurvePoint is CurveMontgomery;
        public string XTag => IsCurveX ? "U" : "X";
        public string YTag => IsCurveX ? "V" : "Y";

        public BigInteger X = -1;
        public BigInteger Y = -1;


        public BigInteger X2;
        public BigInteger Z2;
        public BigInteger X3;
        public BigInteger Z3;

        public CurveResult(Curve point = null) {
            CurvePoint = point;
            Key = CurvePoint.KeyAdvancedPublic;
            Public = Key.Encoding;

            (X, Y) = point.GetXY();
            }
        public CurveResult(IKeyAdvancedPrivate key, KeyPairAdvanced Point) {
            var scalar = key.Private;

            CurveMontgomery curve;
            switch (Point.IKeyAdvancedPublic) {
                case CurveX25519Public point: {
                    curve = point.Public;
                    break;
                    }
                case CurveX448Public point: {
                    curve = point.Public;
                    break;
                    }
                default: {
                    throw new NYI();
                    }
                }

            CurvePoint = curve;

            curve.ScalarAccumulate(curve.U, scalar, out X2, out Z2, out X3, out Z3);
            (X, Y) = curve.ScalarMultiplySigned(scalar);

            Public = curve.Encode(false);
            }
        }

    public partial class CurveKey {

        static readonly byte[] Dummy = { 0 };

        public string Name = "TBS";
        CryptoAlgorithmID CryptoAlgorithmID;
        public KeyPairAdvanced KeyPair;

        public bool IsCurveX => (KeyPair is KeyPairX25519) | (KeyPair is KeyPairX448);

        public string Curve => CryptoAlgorithmID.ToJoseID();
        public string UDF = "TBS";
        public BigInteger Scalar = -1;
        public byte[] Public = Dummy;
        public byte[] Private = Dummy;

        public bool Extended = false;

        public BigInteger X = -1;
        public BigInteger Y = -1;
        public string XTag => IsCurveX ? "U": "X";
        public string YTag => IsCurveX ? "V" : "Y";

        // Intermediate Montgomery Ladder parameters
        public string X2 = "TBS";
        public string Z2 = "TBS";
        public string X3 = "TBS";
        public string Z3 = "TBS";

        public CurveKey() {
            }

        public CurveKey(
                CryptoAlgorithmID cryptoAlgorithmID, 
                bool extended, 
                string prefix = null, 
                string name=null) {
            CryptoAlgorithmID = cryptoAlgorithmID;

            if (name != null) {
                Name = cryptoAlgorithmID.ToJoseID() + name;
                UDF = Goedel.Cryptography.UDF.TestKey(cryptoAlgorithmID, prefix + Name);
                }

            KeyPair = Goedel.Cryptography.UDF.DeriveKey(UDF, KeySecurity.Exportable, KeyUses.Any) as KeyPairAdvanced;
            SetParameters(KeyPair, extended);

            }
        public CurveKey(KeyPair keyPair, bool extended) {
            KeyPair = keyPair as KeyPairAdvanced;
            SetParameters(KeyPair, extended);
            }

        void SetParameters(KeyPair keyPair, bool extended) {
            switch (keyPair) {
                case KeyPairX25519 keyPairX25519: {
                    SetParameters(keyPairX25519, extended);
                    break;
                    }
                case KeyPairX448 keyPairX448: {
                    SetParameters(keyPairX448, extended);
                    break;
                    }
                case KeyPairEd25519 keyPairEd25519: {
                    SetParameters(keyPairEd25519);
                    break;
                    }
                case KeyPairEd448 keyPairEd448: {
                    SetParameters(keyPairEd448);
                    break;
                    }
                }
            Private = Private ?? Dummy;
            Public = Public ?? Dummy;
            }
        void SetParameters(KeyPairX25519 keyPair, bool extended) {
            //var publicKey = keyPair.IKeyAdvancedPublic as CurveX25519Public;
            var privateKey = keyPair.IKeyAdvancedPrivate as CurveX25519Private;
            var publicKey = privateKey.Public;

            Scalar = privateKey.Private;
            Private = privateKey.Encoding ;
            Public = publicKey.Public.Encode (extended);

            X = publicKey.Public.U;
            Y = publicKey.Public.V;
            }
        void SetParameters(KeyPairX448 keyPair, bool extended) {
            //var publicKey = keyPair.IKeyAdvancedPublic as CurveX448Public;
            var privateKey = keyPair.IKeyAdvancedPrivate as CurveX448Private;
            var publicKey = privateKey.Public;

            Scalar = privateKey.Private;
            Private = privateKey.Encoding;
            Public = publicKey.Public.Encode(extended);

            X = publicKey.Public.U;
            Y = publicKey.Public.V;
            }
        void SetParameters(KeyPairEd25519 keyPair) {
            //var publicKey = keyPair.IKeyAdvancedPublic as CurveEdwards25519Public;
            var privateKey = keyPair.IKeyAdvancedPrivate as CurveEdwards25519Private;
            var publicKey = privateKey.Public;

            Scalar = privateKey.Private;
            Private = privateKey.Encoding;
            Public = publicKey.Encoding;

            X = publicKey.Public.X;
            Y = publicKey.Public.Y;
            }
        void SetParameters(KeyPairEd448 keyPair) {
            //var publicKey = keyPair.IKeyAdvancedPublic as CurveEdwards448Public;
            var privateKey = keyPair.IKeyAdvancedPrivate as CurveEdwards448Private;
            var publicKey = privateKey.Public;

            Scalar = privateKey.Private;
            Private = privateKey.Encoding;
            Public = publicKey.Encoding;

            X = publicKey.Public.X;
            Y = publicKey.Public.Y;
            }

        }



    public partial class Decrypt {
        CryptoAlgorithmID CryptoAlgorithmID;

        public CurveKey KeyE;

        public CurveResult KeyEA;
        public CurveResult KeyE1;
        public CurveResult KeyE2;
        public CurveResult KeyE12;

        // Splitting
        public CurveKey KeyA;
        public CurveKey Key1;
        public CurveKey Key2;


        delegate KeyPair MakeKeyPair(IKeyAdvancedPrivate keybase,
                    KeySecurity keySecurity = KeySecurity.Bound,
                    KeyUses keyUses = KeyUses.Any);

        public Decrypt(CryptoAlgorithmID cryptoAlgorithmID) {
            CryptoAlgorithmID = cryptoAlgorithmID;

            // Create the key split first!
            Key1 = new CurveKey(CryptoAlgorithmID, true, "THD", "Key1");
            var key1 = Key1.KeyPair.IKeyAdvancedPrivate;

            KeyA = new CurveKey(CryptoAlgorithmID, false, "THD", "KeyA");
            KeyE = new CurveKey(CryptoAlgorithmID, false, "THD", "KeyE");

            MakeKeyPair makeKeyPair = KeyA.KeyPair.KeyPair;

            var keyA = KeyA.KeyPair.IKeyAdvancedPrivate;
            var keyE = KeyE.KeyPair.IKeyAdvancedPrivate;

            var keyEA = keyE.Agreement(KeyA.KeyPair) as ResultECDH;
            KeyEA = new CurveResult(keyEA.Agreement);


            var keys = new List<KeyPair>() { Key1.KeyPair };

            var key2 = keyA.Combine(key1, KeySecurity.Exportable);
            Key2 = new CurveKey(makeKeyPair(key2, KeySecurity.Exportable), true);

            KeyE1 = new CurveResult(key1, KeyE.KeyPair);
            KeyE2 = new CurveResult(key2, KeyE.KeyPair);

            var keyE12 = KeyE1.CurvePoint.Add (KeyE2.CurvePoint);
            KeyE12 = new CurveResult(keyE12);
            }

        }

    public partial class KeyGen {
        CryptoAlgorithmID CryptoAlgorithmID;

        public CurveKey Key1;
        public CurveKey Key2;
        public CurveKey KeyA;

        public KeyGen(CryptoAlgorithmID cryptoAlgorithmID) {
            CryptoAlgorithmID = cryptoAlgorithmID;

            
            Key1 = new CurveKey(CryptoAlgorithmID, true, "TKG", "Key1");
            Key2 = new CurveKey(CryptoAlgorithmID, true, "TKG", "Key2");

            var keypair = Key1.KeyPair.Combine(Key2.KeyPair, KeySecurity.Exportable);


            KeyA = new CurveKey(keypair, false);

            
            }
        }




    public partial class CreateExamples {
        #region //stuff
        //KeyExchangeClient KeyExchangeClient;
        //KeyExchangePortalTraced KeyExchangePortalTraced;

        public TraceDictionary KeyExchangeTraces;
        public Key ClientDHIdentity;
        public string TraceDH = "DiffieHellman";

        //AdvancedRecovery
        public byte[] AdvancedRecoveryMaster;
        public int AdvancedRecoveryThreshold = 3;
        public int AdvancedRecoveryCount = 5;
        public BigInteger[] AdvancedRecoveryPolynomial;
        public KeyShare[] AdvancedRecoveryShares;
        public BigInteger[] AdvancedRecoveryShareValues;
        public byte[][] AdvancedRecoverySharesHex;
        public string[] AdvancedRecoveryBase32;

        //AdvancedCogen
        public ProfileDevice AdvancedCogenDeviceProfile;
        public byte[] AdvancedCogenPrivateKeySeed;
        public PrivateKeyECDH AdvancedCogenPrivateKeyValue;
        public PublicKeyECDH AdvancedCogenCompositeKey;
        public DareEnvelope AdvancedCogenPrivateKeySeedEncrypted;


        //AdvancedRecryption
        public string AdvancedRecryptionGroupID = "recrypt@example.com";
        public ProfileMesh AdvancedRecryptionGroup;
        public string AdvancedRecryptionMessagePlaintext;
        public DareEnvelope AdvancedRecryptionMessageEncrypted;
        public Assertion AdvancedRecryptionBobProfile;
        public Key AdvancedRecryptionBobDecryptionKey;
        public Key AdvancedRecryptionBobRecryptionKey;
        public Key AdvancedRecryptionBobRecryptionEntry;
        public Object AdvancedRecryptionRecryptionAddMemberRequest;
        public Object AdvancedRecryptionRecryptionRecryptionRequest;
        public Object AdvancedRecryptionRecryptionRecryptionResponse;
        public Object AdvancedRecryptionDecryptionValue;
        public Object AdvancedRecryptionKeyAgreementValue;

        //AdvancedQuantum
        public byte[] AdvancedQuantumMasterSecret;
        public string[] AdvancedQuantumShares;
        public byte[][] AdvancedQuantumPrivate;
        public byte[] AdvancedQuantumPublic;
        public string AdvancedQuantumPublicUDF;
        #endregion      
        public CryptoCombine CryptoCombine;
        public CryptoGroup CryptoGroup;
        public Threshold Threshold;

        public void PlatformCrypto() {
            // To do - write the code to create examples for the 'advanced' section
            // These will need to include examples of the internals of shamir secret sharing, 
            // co-generation, recryption, etc.
            //CryptoCombine = new CryptoCombine();
            //CryptoGroup = new CryptoGroup();
            Threshold = new Threshold();
            }
        }



    //public class CryptoParametersTest : CryptoParameters {


    //    public CryptoParametersTest(
    //                List<KeyPair> encryptionKeys = null,
    //                List<KeyPair> signerKeys = null,
    //                CryptoAlgorithmID encryptID = CryptoAlgorithmID.Default,
    //                CryptoAlgorithmID digestID = CryptoAlgorithmID.Null) :
    //        base(new KeyCollectionCore(),  encryptID: encryptID, digestID: digestID) {

    //        EncryptionKeys = encryptionKeys;
    //        SignerKeys = signerKeys;

    //        }


    //    protected override void AddEncrypt(string AccountId) => AddEncrypt(AccountId, true);

    //    public void AddEncrypt(string accountId, bool register = true) {
    //        EncryptionKeys = EncryptionKeys ?? new List<KeyPair>();

    //        var udf = UDF.DerivedKey(UDFAlgorithmIdentifier.Ed25519, data: accountId.ToUTF8());
    //        var keypair = UDF.DeriveKey(udf, keyType: KeySecurity.Exportable) as KeyPairEd25519;
    //        keypair.Locator = accountId;

    //        var publicKeyKeypair = keypair.KeyPairPublic();
    //        EncryptionKeys.Add(publicKeyKeypair);

    //        //Console.WriteLine($"Keypair is {Keypair.UDF}");
    //        //Console.WriteLine($"  Public {Keypair.PKIXPublicKeyDH}");
    //        //Console.WriteLine($"  Public {PublicKeyKeypair.UDF}");

    //        if (register) {
    //            KeyCollection.Add(keypair);
    //            }

    //        }
    //    }
    public partial class KeyPairPartialTest : KeyPairPartial {

        public string IdGroup;
        public string IdMember;
        public KeyPair PrivateKey;
        public KeyPairAdvanced KeyPairService;
        public KeyAgreementResult PartialService;
        public byte[] PartialServiceEncoded => (PartialService as CurveEdwards25519Result).AgreementEd25519.Encode();
        public KeyAgreementResult PartialDevice;
        public byte[] PartialDeviceEncoded => (PartialDevice as CurveEdwards25519Result).AgreementEd25519.Encode();
        public byte[] Result;

        public KeyPairPartialTest(KeyPairAdvanced keyPairGroup,
                KeyPairAdvanced keyPairPart, KeyPairAdvanced keyPairService) : base(keyPairGroup, keyPairPart) {
            KeyPairService = keyPairService;
            }

        /// <summary>
        /// Perform a key exchange to encrypt a bulk or wrapped key under this one.
        /// </summary>
        /// <param name="encryptedKey">The encrypted session</param>
        /// <param name="ephemeral">Ephemeral key input (required for DH)</param>
        /// <param name="algorithmID">The algorithm to use.</param>
        /// <param name="partial">Partial key agreement carry in (for recryption)</param>
        /// <param name="salt">Optional salt value for use in key derivation. If specified
        /// must match the salt used to encrypt.</param>        
        /// <returns>The decoded data instance</returns>
        public override byte[] Decrypt(
                    byte[] encryptedKey,
                    KeyPair ephemeral = null,
                    CryptoAlgorithmID algorithmID = CryptoAlgorithmID.Default,
                    KeyAgreementResult partial = null,
                    byte[] salt = null) {

            PartialService = KeyPairService.Agreement(ephemeral);
            PartialDevice = KeyPartial.Agreement(ephemeral);

            var keyPartial = KeyPartial as KeyPairEd25519;


            Result = keyPartial.Agreement(
                ephemeral as KeyPairEd25519, PartialService as CurveEdwards25519Result).AgreementEd25519.Encode();
            return KeyPartial.Decrypt(encryptedKey, ephemeral, algorithmID, PartialService, salt); ;
            }

        }
    public class CryptoGroup {

        public readonly string PlaintextText = "This is a test";
        public byte[] Plaintext => PlaintextText.ToUTF8();

        public string KeyUDFGroup;
        public string KeyUDFDevice;

        public KeyPairEd25519 KeyPairGroup;
        public KeyPairEd25519 KeyPairDevice;
        public KeyPairEd25519 KeyPairService;


        public byte[] KeyPairGroupPrivate => (KeyPairGroup.IKeyAdvancedPrivate as CurveEdwards25519Private).Encoding;
        public byte[] KeyPairDevicePrivate => (KeyPairDevice.IKeyAdvancedPrivate as CurveEdwards25519Private).Encoding;

        public BigInteger KeyPairDevicePrivateInt => (KeyPairDevice.IKeyAdvancedPrivate as CurveEdwards25519Private).Private;

        public BigInteger KeyPairGroupPrivateInt => (KeyPairGroup.IKeyAdvancedPrivate as CurveEdwards25519Private).Private;

        public BigInteger KeyPairServicePrivateInt => (KeyPairService.IKeyAdvancedPrivate as CurveEdwards25519Private).Private;


        public DareEnvelope Envelope;
        public KeyPairPartialTest KeyPairDeviceWrapped;

        public string GroupName = "GroupW@example.com";
        public string UserName = "Bob@example.com";

        public CryptoGroup() {

            KeyUDFGroup = UDF.DerivedKey(UDFAlgorithmIdentifier.Ed25519, data: GroupName.ToUTF8());
            KeyUDFDevice = UDF.DerivedKey(UDFAlgorithmIdentifier.Ed25519, data: UserName.ToUTF8());



            KeyPairGroup = UDF.DeriveKey(KeyUDFGroup, keyType: KeySecurity.Exportable) as KeyPairEd25519;
            KeyPairGroup.Locator = KeyUDFGroup;


            //var RecipientsGroup = new List<KeyPair> { KeyPairGroup };
            var CryptoParametersGroup = new CryptoParameters(recipient: KeyPairGroup);


            KeyPairDevice = UDF.DeriveKey(KeyUDFDevice, keyType: KeySecurity.Exportable) as KeyPairEd25519;

            KeyPairService = KeyPairGroup.GenerateRecryptionKey(KeyPairDevice) as KeyPairEd25519;


            Envelope = new DareEnvelope(CryptoParametersGroup, Plaintext);



            KeyPairDeviceWrapped = new KeyPairPartialTest(KeyPairGroup, KeyPairDevice, KeyPairService) {
                IdGroup = GroupName,
                IdMember = UserName
                };

            var keyCollectionDevice = new KeyCollectionCore();
            keyCollectionDevice.Add(KeyPairDeviceWrapped);



            CheckDecode(Envelope, Plaintext, keyCollectionDevice);

            }


        static void CheckDecode(
                    DareEnvelope envelope,
                    byte[] plaintext,
                    KeyCollection keyCollection
                    ) {

            var cryptoStack = envelope.Header.GetCryptoStack(keyCollection);
            byte[] decrypt;


            using (var input = new MemoryStream(envelope.Body)) {
                using (var output = new MemoryStream()) {
                    var decoder = cryptoStack.GetDecoder(input, out var plaintextStream);
                    plaintextStream.CopyTo(output);
                    decrypt = output.ToArray();
                    decrypt.IsEqualTo(plaintext).AssertTrue();
                    }
                }

            }

        }
    public class CryptoCombine {

        public string SeedAliceDevice;
        public string SeedAliceOverlay;

        public KeyPairEd25519 KeyPairDevice;
        public KeyPairEd25519 KeyPairOverlay;

        public byte[] KeyPairDevicePrivate => (KeyPairDevice.IKeyAdvancedPrivate as CurveEdwards25519Private).Encoding;
        public byte[] KeyPairOverlayPrivate => (KeyPairOverlay.IKeyAdvancedPrivate as CurveEdwards25519Private).Encoding;

        public KeyPairEd25519 CombinedPrivate;
        public KeyPairEd25519 CombinedPublic;

        public BigInteger SecretScalarDevice => (KeyPairDevice.IKeyAdvancedPrivate as CurveEdwards25519Private).Private;
        public BigInteger SecretScalarOverlay => (KeyPairOverlay.IKeyAdvancedPrivate as CurveEdwards25519Private).Private;
        public BigInteger SecretScalarComposite => (CombinedPrivate.IKeyAdvancedPrivate as CurveEdwards25519Private).Private;

        public CryptoCombine() {


            var seed = "AliceDevice1".ToUTF8();
            var random1 = KeyDeriveHKDF.Random(seed, 128, "Signature".ToUTF8());
            var random2 = KeyDeriveHKDF.Random(seed, 128, "OverlaySignature".ToUTF8());

            SeedAliceDevice = UDF.DerivedKey(UDFAlgorithmIdentifier.Ed25519, data: random1);
            SeedAliceOverlay = UDF.DerivedKey(UDFAlgorithmIdentifier.Ed25519, data: random2);

            KeyPairDevice = UDF.DeriveKey(SeedAliceDevice, KeySecurity.Exportable) as KeyPairEd25519;
            KeyPairOverlay = UDF.DeriveKey(SeedAliceOverlay, KeySecurity.Exportable) as KeyPairEd25519;

            CombinedPrivate = KeyPairDevice.Combine(KeyPairDevice) as KeyPairEd25519;
            CombinedPublic = KeyPairDevice.CombinePublic(KeyPairDevice) as KeyPairEd25519;
            }

        //            KeySignature = new KeyOverlay(meshMachine, profileDevice.KeyOfflineSignature);

        //// AdvancedRecovery 
        //var AdvancedRecoveryMaster = CryptoCatalog.GetBits(128);
        //var Secret = new Secret(AdvancedRecoveryMaster);
        //Secret.Keep();
        //var AdvancedRecoveryShares = Secret.Split(AdvancedRecoveryThreshold,
        //        AdvancedRecoveryCount, out AdvancedRecoveryPolynomial);
        //AdvancedRecoveryShareValues = new BigInteger[AdvancedRecoveryCount];
        //AdvancedRecoverySharesHex = new byte[AdvancedRecoveryCount][];
        //AdvancedRecoveryBase32 = new string[AdvancedRecoveryCount];

        //for (var i = 0; i < AdvancedRecoveryCount; i++) {
        //    AdvancedRecoveryShareValues[i] = AdvancedRecoveryShares[i].Value;
        //    AdvancedRecoverySharesHex[i] = AdvancedRecoveryShares[i].Key;
        //    AdvancedRecoveryBase32[i] = AdvancedRecoveryShares[i].UDFKey;
        //    }

        // AdvancedCogen
        //AdvancedCogenDeviceProfile = new DeviceProfile(
        //            "AliceWatch", "A wearable watch computer",
        //            CryptoAlgorithmID.Ed25519,
        //            CryptoAlgorithmID.XEd25519);


        //var AdvancedCogenDeviceSignPublic =
        //    (PublicKeyECDH)null; //AdvancedCogenDeviceProfile.DeviceSignatureKey.PublicParameters;
        //var AdvancedCogenDeviceSignPrivate =
        //    (PrivateKeyECDH)null; //AdvancedCogenDeviceProfile.DeviceSignatureKey.PrivateParameters;

        //AdvancedCogenPrivateKeySeed = CryptoCatalog.GetBits(128);
        //var CogenPrivateKeyValue = new PrivateKeyECDH(AdvancedCogenPrivateKeySeed, true);

        //AdvancedCogenPrivateKeyValue = AdvancedCogenDeviceSignPrivate.CombinePrivate(CogenPrivateKeyValue);
        //AdvancedCogenCompositeKey = AdvancedCogenDeviceSignPublic.CombinePublic(CogenPrivateKeyValue);

        //AdvancedCogenPrivateKeySeedEncrypted = AdvancedCogenDeviceProfile.DareEncrypt(AdvancedCogenPrivateKeyValue);


        //AdvancedRecryption
        //var AliceProfile = MakeProfile("", out var AliceKeyCollection);
        //var BobProfile = MakeProfile("", out var BobKeyCollection);

        //AddMessage(AliceProfile);
        //AddMessage(BobProfile);

        //var RecryptionGroup = new RecryptionGroup ("recrypt@example.com");
        //RecryptionGroup.AddAdmin(AliceProfile);
        //RecryptionGroup.AddMember(BobProfile);

        //AdvancedRecryptionMessagePlaintext = $"Welcome to the group {AdvancedRecryptionGroupID}";
        //AdvancedRecryptionMessageEncrypted = RecryptionGroup.Encrypt(AdvancedRecryptionMessagePlaintext);

        //BobKeyCollection.Decrypt(AdvancedRecryptionMessageEncrypted);


        //public ApplicationProfile AdvancedRecryptionGroup;
        //public string AdvancedRecryptionMessagePlaintext;
        //public DAREMessage AdvancedRecryptionMessageEncrypted;
        //public ApplicationProfile AdvancedRecryptionBobProfile;
        //public Key AdvancedRecryptionBobDecryptionKey;
        //public Key AdvancedRecryptionBobRecryptionKey;
        //public Key AdvancedRecryptionBobRecryptionEntry;
        //public Object AdvancedRecryptionRecryptionAddMemberRequest;
        //public Object AdvancedRecryptionRecryptionRecryptionRequest;
        //public Object AdvancedRecryptionRecryptionRecryptionResponse;
        //public Object AdvancedRecryptionDecryptionValue;
        //public Object AdvancedRecryptionKeyAgreementValue;





        // AdvancedQuantum

        //var XMSS = new XMSS();
        //AdvancedQuantumMasterSecret = XMSS.MasterSecret;
        //var AdvancedQuantumKeyShares = Secret.Split(AdvancedRecoveryThreshold,
        //        AdvancedRecoveryCount, out AdvancedRecoveryPolynomial);
        //AdvancedQuantumShares = new string[AdvancedRecoveryCount];
        //for (var i = 0; i < AdvancedRecoveryCount; i++) {
        //    AdvancedQuantumShares[i] = AdvancedQuantumKeyShares[i].UDFKey;
        //    }


        //AdvancedQuantumPrivate = XMSS.Private;
        //AdvancedQuantumPublic = XMSS.Public;
        //AdvancedQuantumPublicUDF = XMSS.UDF;






        }
    }
