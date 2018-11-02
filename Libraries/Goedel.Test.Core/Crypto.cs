using System;
using System.Threading;
using System.Collections.Generic;
using Goedel.Cryptography;
using Goedel.Cryptography.Core;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.PKIX;
using Goedel.Utilities;
using Goedel.Cryptography.Algorithms;

namespace Goedel.Test.Core {


    public class CryptoParametersTest : CryptoParameters {


        public CryptoParametersTest(
                    List<string> Recipients = null,
                    List<string> Signers = null,
                    CryptoAlgorithmID EncryptID = CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID DigestID = CryptoAlgorithmID.NULL) :
            base(new KeyCollectionCore(), Recipients, Signers, EncryptID, DigestID) {
            }

        protected override void AddEncrypt(string AccountId) => AddEncrypt(AccountId, true);

        public void AddEncrypt(string AccountId, bool Register = true) {
            EncryptionKeys = EncryptionKeys ?? new List<KeyPair>();

            var Keypair = new KeyPairDH();
            var Pub = Keypair.KeyPairPublic();
            var PublicKeyKeypair = Keypair.KeyPairPublic();
            EncryptionKeys.Add(PublicKeyKeypair);

            Console.WriteLine($"Keypair is {Keypair.UDF}");
            Console.WriteLine($"  Public {Keypair.PKIXPublicKeyDH}");
            Console.WriteLine($"  Public {PublicKeyKeypair.UDF}");

            if (Register) {
                KeyCollection.Add(Keypair);
                }

            }

        protected override void AddSign(string AccountId) => AddSign(AccountId, true);
        public void AddSign(string AccountId, bool Register) {
            SignerKeys = SignerKeys ?? new List<KeyPair>();

            var Keypair = KeyPair.KeyPairFactoryRSA(keyType: KeySecurity.Ephemeral);
            var PublicKeyKeypair = Keypair.KeyPairPublic();
            SignerKeys.Add(Keypair);

            Console.WriteLine($"Keypair is {Keypair.UDF}");
            Console.WriteLine($"  Public {PublicKeyKeypair.UDF}");

            if (Register) {
                KeyCollection.Add(Keypair);
                }
            }

        }



    public class TestKeys {

        KeyCollection KeyCollection;

        public List<KeyPair> EncryptionKeys;
        public List<KeyPair> SignerKeys;

        public TestKeys(KeyCollection KeyCollection = null) => this.KeyCollection = KeyCollection ?? KeyCollection.Default;

        public void AddEncrypt(bool Register = true) {
            EncryptionKeys = EncryptionKeys ?? new List<KeyPair>();

            var Keypair = new KeyPairDH();
            var Public = Keypair.PKIXPublicKeyDH;
            var PublicKeyKeypair = KeyPairDH.KeyPairPublicFactory(Public);
            EncryptionKeys.Add(PublicKeyKeypair);

            Console.WriteLine($"Keypair is {Keypair.UDF}");
            Console.WriteLine($"  Public {Keypair.PKIXPublicKeyDH}");
            Console.WriteLine($"  Public {PublicKeyKeypair.UDF}");

            if (Register) {
                KeyCollection.Default.Add(Keypair);
                }
            }

        public void AddSign(bool Register = true) {
            SignerKeys = SignerKeys ?? new List<KeyPair>();

            throw new NYI();
            }
        }

    }
