using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Core;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.PKIX;
using Goedel.Utilities;

using System.Collections.Generic;

namespace Goedel.Test.Core {

    public class CryptoStackDebug : CryptoStack {
        public byte[] KeyEncrypt;
        public byte[] KeyMac;
        public byte[] IV;

        /// <summary>
        /// Create a CryptoStack instance to encode data with the specified cryptographic
        /// parameters.
        /// </summary>
        public CryptoStackDebug(
                        CryptoParameters cryptoParameters
                        ) : base(cryptoParameters) => CalculateParameters(Salt, out KeyEncrypt, out KeyMac, out IV);

        /// <summary>
        /// Add a recipient.
        /// </summary>
        /// <param name="MasterKey"></param>
        /// <param name="EncryptionKey"></param>
        public override void MakeRecipient(byte[] MasterKey, CryptoKey EncryptionKey) =>
                Recipients.Add(new DareRecipientDebug(MasterSecret, EncryptionKey));
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

            EncryptionKey = result.KeyDerive.Derive(KDFInfo, Length: 256);
            KeyAgreement = result.IKM;

            var exchange = Platform.KeyWrapRFC3394.Wrap(EncryptionKey, MasterKey);

            var JoseKey = Key.GetPublic(result.EphemeralKeyPair);

            KeyIdentifier = PublicKey.KeyIdentifier;
            Epk = JoseKey;
            WrappedMasterKey = exchange;
            }
        }


    }
