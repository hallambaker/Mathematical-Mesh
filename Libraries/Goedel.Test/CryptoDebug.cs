using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Core;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.PKIX;
using Goedel.Utilities;

using System.Collections.Generic;

namespace Goedel.Test.Core {

    public enum DataValidity {
        ///<summary>The data is valid.</summary>
        Valid = 0b_0000_0000,

        ///<summary>The public key is invalid.</summary>
        CorruptSigner = 0b_0000_0001,

        ///<summary>The signature data is modified.</summary>
        CorruptSignature = 0b_0000_0010,

        ///<summary>The digest data is modified.</summary>
        CorruptDigest = 0b_0000_0100,

        ///<summary>The body is modified.</summary>
        CorruptPayload = 0b_0000_1000,

        ///<summary>An Attribute is modified.</summary>
        CorruptAttributes = 0b_0001_0000,

        ///<summary>The body is modified.</summary>
        CorruptMissing = 0b_0010_0000,

        }

    public static class Extension {

        public static string CorruptedPIN(this string data) =>
            $"{data[0]}{data[1]}{data[2].Corrupt()}" + data.Substring(3);

        public static char Corrupt(this char data) {
            var c = ((int)data) ^ 0x01;
            return (char)c;

            }

        public static string Corrupted(this string data) => data switch {
            null => "A",
            "" => "A",
            _ => data[0].Corrupt() + data.Substring(1)
            };


        public static void Corrupt(
                this DareEnvelope envelope,
                DataValidity dataValidity = DataValidity.CorruptPayload,
                DareEnvelope alternative=null) {

            switch (dataValidity) {
                case DataValidity.CorruptPayload: {
                    envelope.Body = envelope.Body.Corrupt();
                    return;
                    }
                case DataValidity.CorruptMissing: {
                    envelope.Trailer.Signatures = null;
                    return;
                    }
                case DataValidity.CorruptDigest: {
                    envelope.Trailer.PayloadDigest = envelope.Trailer.PayloadDigest.Corrupt();
                    return;
                    }
                case DataValidity.CorruptSignature: {
                    var signature = envelope.Trailer.Signatures[0];
                    signature.SignatureValue = signature.SignatureValue.Corrupt();
                    return;
                    }
                case DataValidity.CorruptSigner: {
                    envelope.Trailer.Signatures = alternative.Trailer.Signatures;
                    return;
                    }

                }
            }



        public static void Corrupt(
                ref byte[] data) => data = Corrupt(data);


        public static byte[] Corrupt(
                this byte[] data) {
            if ((data == null) || (data.Length == 0)) {
                return new byte[1];
                }
            else {
                data[0] ^= 1;
                return data;
                }
            }
        }
    public class CryptoStackDebug : CryptoStackEncode {
        public byte[] KeyEncrypt;
        public byte[] KeyMac;
        public byte[] IV;

        /// <summary>
        /// Create a CryptoStack instance to encode data with the specified cryptographic
        /// parameters.
        /// </summary>
        public CryptoStackDebug(
                        CryptoParameters cryptoParameters,
                        DareHeader dareHeader
                        ) : base(cryptoParameters, dareHeader) => CalculateParameters(Salt, out KeyEncrypt, out KeyMac, out IV);

        }


    public class CryptoParametersDebug : CryptoParameters{

        public CryptoParametersDebug(IKeyLocate keyCollection = null,
                        List<string> recipients = null,
                        List<string> signers = null,
                        CryptoKey recipient = null,
                        CryptoKey signer = null,
                        CryptoAlgorithmId encryptID = CryptoAlgorithmId.NULL,
                        CryptoAlgorithmId digestID = CryptoAlgorithmId.NULL) : 
                    base (keyCollection, recipients, signers, recipient, signer, encryptID, digestID) {
            }

        /// <summary>
        /// Perform a new key exchange and 
        /// </summary>
        /// <returns></returns>
        protected override List<DareRecipient> KeyExchange() {
            // create the new base seed.
            BaseSeed = Platform.GetRandomBits(KeySize);

            // perform a key exchange for each recipient.
            var result = new List<DareRecipient>();
            foreach (var encryptionKey in EncryptionKeys) {
                result.Add(new DareRecipientDebug(BaseSeed, encryptionKey));
                }

            return result;
            }


        }


    public class DareRecipientDebug : DareRecipient {

        public Key EphemeralPrivate;

        public byte[] KeyAgreement;

        public byte[] EncryptionKey;

        /// <summary>
        /// Create a DARERecipient using the specified cryptographic parameters.
        /// </summary>
        /// <param name="MasterKey">The master key</param>
        /// <param name="PublicKey">The recipient public key.</param>
        /// <returns>The recipient informatin object.</returns>
        public DareRecipientDebug(byte[] MasterKey, CryptoKey PublicKey) {

            var Secret = Platform.GetRandomBytes(32);
            var PrivateKey = new CurveEdwards25519Private();
            var Ephemeralpublic = PrivateKey.Public;
            var PKIXPublicKeyECDH = new PKIXPublicKeyEd25519(Ephemeralpublic.Encoding);
            var PKIXPrivateKeyECDH = new PKIXPrivateKeyEd25519(Secret, PKIXPublicKeyECDH);
            EphemeralPrivate = new PrivateKeyECDH(PKIXPrivateKeyECDH);

            var PublicKeyEd = PublicKey as KeyPairEd25519;

            var result = new CurveEdwards25519Result() {
                EphemeralPublicValue = PrivateKey.Public,
                AgreementEd25519 = PrivateKey.Agreement(PublicKeyEd.IKeyAdvancedPublic as CurveEdwards25519Public)
                };

            EncryptionKey = result.KeyDerive.Derive(KDFInfo, 256);
            KeyAgreement = result.IKM;

            var exchange = Platform.KeyWrapRFC3394.Wrap(EncryptionKey, MasterKey);

            var JoseKey = Key.GetPublic(result.EphemeralKeyPair);

            KeyIdentifier = PublicKey.KeyIdentifier;
            Epk = JoseKey;
            WrappedBaseSeed = exchange;
            }
        }

    }
