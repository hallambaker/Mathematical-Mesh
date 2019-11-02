using System;

using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Numerics;
using Goedel.Mesh;
using Goedel.Utilities;
using Goedel.Protocol.Debug;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;

using Goedel.IO;
using Goedel.Command;
using Goedel.Cryptography.Algorithms;
using Goedel.Test;
using Goedel.Cryptography.Core;
using Goedel.Test.Core;

namespace ExampleGenerator {


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

        public void PlatformCrypto() {
            // To do - write the code to create examples for the 'advanced' section
            // These will need to include examples of the internals of shamir secret sharing, 
            // co-generation, recryption, etc.
            CryptoCombine = new CryptoCombine();
            CryptoGroup = new CryptoGroup();

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
        public byte[] PartialServiceEncoded => (PartialService as CurveEdwards25519Result).Agreement.Encode();
        public KeyAgreementResult PartialDevice;
        public byte[] PartialDeviceEncoded => (PartialDevice as CurveEdwards25519Result).Agreement.Encode();
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
                ephemeral as KeyPairEd25519, PartialService as CurveEdwards25519Result).Agreement.Encode();
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
