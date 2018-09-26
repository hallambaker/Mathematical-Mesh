//using System;
//using System.Collections.Generic;
//using System.Numerics;
//using Goedel.Cryptography.Dare;
//using Goedel.Cryptography.Jose;
//using Goedel.Cryptography;
//using Goedel.Utilities;
//using Goedel.Cryptography.Algorithms;

//namespace Goedel.Test {
//    public class CryptoStackDebug : CryptoStack {

//        public BigInteger RecipientEncryptionKey;
//        public BigInteger DareWrappedKey;
//        public DARERecipientDebug DARERecipient;
//        public byte[] KeyEncrypt;
//        public byte[] IV;
//        public byte[] KeyMac;

//        public CryptoStackDebug(CryptoParameters CryptoParameters) : base(CryptoParameters) => 
//            CalculateParameters(Salt, out KeyEncrypt, out KeyMac, out IV);


//        /// <summary>
//        /// Add a recipient.
//        /// </summary>
//        /// <param name="MasterKey"></param>
//        /// <param name="EncryptionKey"></param>
//        public override void MakeRecipient(byte[] MasterKey, KeyPair EncryptionKey) {
//            DARERecipient = new DARERecipientDebug(MasterSecret, EncryptionKey);
//            Recipients.Add(DARERecipient);



//            }


//        public DareMessage Message(
//                    byte[] Plaintext,
//                    string ContentType = null,
//                    byte[] Cloaked = null,
//                    List<byte[]> DataSequences = null) {

//            var Header = new DareHeader(this, ContentType, Cloaked, DataSequences);
//            var Body = Header.EnhanceBody(Plaintext, out var Trailer);

//            return new DareMessage() { Header = Header, Body = Body, Trailer = Trailer };
//            }

//        }

//    public partial class DARERecipientDebug : DareRecipient {


//        public Key EphemeralPrivate => Key.GetPrivate(Ephemeral);
//        public KeyPair Ephemeral;
//        public byte[] KeyAgreement => Agreement.Agreement.ToByteArray();

//        public DiffieHellmanResult Agreement;
//        public KeyDerive KeyDerive;
//        public byte[] EncryptionKey;


//        /// <summary>
//        /// Create a DARERecipient using the specified cryptographic parameters.
//        /// </summary>
//        /// <param name="MasterKey">The master key</param>
//        /// <param name="PublicKey">The recipient public key.</param>
//        /// <returns>The recipient informatin object.</returns>
//        public DARERecipientDebug(byte[] MasterKey, KeyPair PublicKey) {
//            //CryptoProviderExchangeDH(PublicKey)
//            var ExchangeProvider = new CryptoProviderExchangeDHDebug(PublicKey);
//            ExchangeProvider.Encrypt(MasterKey, out var Exchange, out Ephemeral,
//                out Agreement, out KeyDerive, out EncryptionKey);
//            var JoseKey = Key.GetPublic(Ephemeral);


//            KeyIdentifier = PublicKey.UDF;
//            Epk = JoseKey;
//            WrappedMasterKey = Exchange;

//            }




//        }

//    public class CryptoProviderExchangeDHDebug : CryptoProviderExchangeDH {



//        /// <summary>
//        /// Construct a provider for a Keypair
//        /// </summary>
//        /// <param name="KeyPair">Keypair to construct from</param>
//        /// <param name="Bulk">Default encryption algorithm.</param>
//        public CryptoProviderExchangeDHDebug(KeyPair KeyPair,
//                    CryptoAlgorithmID Bulk = CryptoAlgorithmID.Default) {
//            this.KeyPair = KeyPair;
//            this.BulkAlgorithmDefault = Bulk;
//            }

//        /// <summary>
//        /// Encrypt the bulk key.
//        /// </summary>
//        /// <returns>The encoder</returns>
//        public void Encrypt(byte[] Key,
//            out byte[] Exchange, out KeyPair Ephemeral,
//            out DiffieHellmanResult Agreement, out KeyDerive KeyDerive,
//            out byte[] EncryptionKey, byte[] Salt = null) {

//            Salt = Salt ?? MasterKeyInfo;

//            var DHKeyPair = KeyPair as KeyPairDH;

//            Agreement = MakeAgreement(DHKeyPair, out var Private);


//            KeyDerive = Agreement.KeyDerive;
//            Console.Write($"PRK Encrypt is {Agreement.IKM.ToStringBase16()}");
//            // Need to do some form of key derrivation here.

//            EncryptionKey = KeyDerive.Derive(Salt, Length: 256);
//            Console.Write($"EncryptionKey Encrypt is {EncryptionKey.ToStringBase16()}");

//            Exchange = Platform.KeyWrapRFC3394.Wrap(EncryptionKey, Key);
//            Ephemeral = new KeyPairDH(Private, KeySecurity.Exportable);
//            }


//        /// <summary>
//        /// Create a new ephemeral private key and use it to perform a key
//        /// agreement.
//        /// </summary>
//        /// <returns>The key agreement parameters, the public key value and the
//        /// key agreement.</returns>
//        public DiffieHellmanResult MakeAgreement(KeyPairDH KeyPairDH, out DiffeHellmanPrivate Private) {
//            Private = new DiffeHellmanPrivate(KeyPairDH.PublicKey);
//            var DiffeHellmanPublic = Private.DiffeHellmanPublic;

//            var Result = new DiffieHellmanResult() {
//                EphemeralPublicValue = DiffeHellmanPublic,
//                Agreement = Private.Agreement(KeyPairDH.PublicKey)
//                };

//            return Result;
//            }
//        }
//    }
