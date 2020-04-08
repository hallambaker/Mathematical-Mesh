//using System;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;

namespace Goedel.Cryptography.Dare {

    /// <summary>
    /// 
    /// </summary>
    public partial class DareRecipient {

        /// <summary>
        /// Salt value used in the key derrivation function.
        /// </summary>
        public static readonly byte[] KDFSalt = "master".ToUTF8();

        /// <summary>
        /// Default constructor. Used for serializatrion.
        /// </summary>
        public DareRecipient() {
            }

        /// <summary>
        /// Create a DARERecipient using the specified cryptographic parameters.
        /// </summary>
        /// <param name="masterKey">The master key</param>
        /// <param name="publicKey">The recipient public key.</param>
        /// <returns>The recipient informatin object.</returns>
        public DareRecipient(byte[] masterKey, KeyPair publicKey) {
            //var ExchangeProvider = PublicKey.ExchangeProvider();
            //ExchangeProvider.Encrypt(MasterKey, out var Exchange, out var Ephemeral, Salt: KDFSalt);


            publicKey.Encrypt(masterKey, out var Exchange, out var Ephemeral, salt: KDFSalt);


            var JoseKey = Key.GetPublic(Ephemeral);

            KeyIdentifier = publicKey.UDF;
            Epk = JoseKey;
            WrappedMasterKey = Exchange;

            }


        }

    }
