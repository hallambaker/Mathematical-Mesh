﻿using Goedel.Cryptography;
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
        CorruptPublicKey = 0b_0000_0001,

        ///<summary>The signature data is modified.</summary>
        CorruptSignature = 0b_0000_0010,

        ///<summary>The digest data is modified.</summary>
        CorruptDigest = 0b_0000_0100,

        ///<summary>The body is modified.</summary>
        CorruptPayload = 0b_0000_1000,

        ///<summary>An Attribute is modified.</summary>
        CorruptAttributes = 0b_0001_0000,
        }

    public static class Extension {


        public static void Corrupt(
                this DareEnvelope envelope,
                DataValidity dataValidity = DataValidity.CorruptPayload) {

            switch (dataValidity) {
                case DataValidity.CorruptPayload: {
                    envelope.Body = envelope.Body.Corrupt();
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
                case DataValidity.CorruptPublicKey: {
                    throw new NYI();
                    }
                case DataValidity.CorruptAttributes: {
                    throw new NYI();
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
                        CryptoParametersSequence cryptoParameters,
                        DareHeader dareHeader
                        ) : base(cryptoParameters, dareHeader) => CalculateParameters(Salt, out KeyEncrypt, out KeyMac, out IV);

        ///// <summary>
        ///// Add a recipient.
        ///// </summary>
        ///// <param name="MasterKey"></param>
        ///// <param name="EncryptionKey"></param>
        //public override void MakeRecipient(byte[] MasterKey, CryptoKey EncryptionKey) =>
        //        Recipients.Add(new DareRecipientDebug(BaseSeed, EncryptionKey));
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
            WrappedBaseSeed = exchange;
            }
        }

    }
