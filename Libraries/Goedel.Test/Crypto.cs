using System;
using System.Threading;
using System.Collections.Generic;
using UT = Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Cryptography;
using Goedel.Cryptography.Core;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.PKIX;
using Goedel.Utilities;
using Goedel.Cryptography.Algorithms;

namespace Goedel.Test {


    public class CryptoParametersTest : CryptoParameters {


        public CryptoParametersTest(
                    List<string> recipients = null,
                    List<string> signers = null,
                    CryptoAlgorithmID encryptID = CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID digestID = CryptoAlgorithmID.NULL) :
            base(new KeyCollectionCore(), recipients, signers, encryptID:encryptID, digestID:digestID) {
            }

        protected override void AddEncrypt(string AccountId) => AddEncrypt(AccountId, true);

        public void AddEncrypt(string AccountId, bool Register = true) {
            EncryptionKeys = EncryptionKeys ?? new List<KeyPair>();

            var Keypair = new KeyPairDH();
            var Pub = Keypair.KeyPairPublic();
            var PublicKeyKeypair = Keypair.KeyPairPublic();
            EncryptionKeys.Add(PublicKeyKeypair);

            //Console.WriteLine($"Keypair is {Keypair.UDF}");
            //Console.WriteLine($"  Public {Keypair.PKIXPublicKeyDH}");
            //Console.WriteLine($"  Public {PublicKeyKeypair.UDF}");

            if (Register) {
                KeyCollection.Add(Keypair);
                }

            }

        protected override void AddSign(string accountId) => AddSign(accountId, true);
        public void AddSign(string accountId, bool register) {
            SignerKeys = SignerKeys ?? new List<KeyPair>();

            var Keypair = KeyPair.KeyPairFactoryRSA(keyType: KeySecurity.Ephemeral);
            var PublicKeyKeypair = Keypair.KeyPairPublic();
            SignerKeys.Add(Keypair);

            //Console.WriteLine($"Keypair is {Keypair.UDF}");
            //Console.WriteLine($"  Public {PublicKeyKeypair.UDF}");

            if (register) {
                KeyCollection.Add(Keypair);
                }
            }

        }



    public class TestKeys {

        KeyCollection KeyCollection;

        public List<KeyPair> EncryptionKeys;
        public List<KeyPair> SignerKeys;

        public TestKeys(KeyCollection keyCollection = null) => KeyCollection = keyCollection ?? KeyCollection.Default;

        public void AddEncrypt(bool register = true) {
            EncryptionKeys = EncryptionKeys ?? new List<KeyPair>();

            var Keypair = new KeyPairDH();
            var Public = Keypair.PKIXPublicKeyDH;
            var PublicKeyKeypair = KeyPairDH.KeyPairPublicFactory(Public);
            EncryptionKeys.Add(PublicKeyKeypair);

            //Console.WriteLine($"Keypair is {Keypair.UDF}");
            //Console.WriteLine($"  Public {Keypair.PKIXPublicKeyDH}");
            //Console.WriteLine($"  Public {PublicKeyKeypair.UDF}");

            if (register) {
                KeyCollection.Default.Add(Keypair);
                }
            }

        public void AddSign(bool register = true) {
            SignerKeys = SignerKeys ?? new List<KeyPair>();

            throw new NYI();
            }
        }

    }
