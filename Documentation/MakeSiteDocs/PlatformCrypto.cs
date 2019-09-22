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

        public void PlatformCrypto() {
            // To do - write the code to create examples for the 'advanced' section
            // These will need to include examples of the internals of shamir secret sharing, 
            // co-generation, recryption, etc.


            }





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

        void GoAdvanced() {

            //// AdvancedRecovery 
            //var AdvancedRecoveryMaster = CryptoCatalog.GetBits(128);
            var Secret = new Secret(AdvancedRecoveryMaster);
            Secret.Keep();
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
    }
