//using System;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;

namespace Goedel.Cryptography.Dare {

    /// <summary>
    /// 
    /// </summary>
    public partial class DareRecipient {

        /// <summary>
        /// Salt value used in the key derivation function.
        /// </summary>
        public static readonly byte[] KDFInfo = "master".ToUTF8();

        /// <summary>
        /// Default constructor. Used for serializatrion.
        /// </summary>
        public DareRecipient() {
            }

        /// <summary>
        /// Create a DARERecipient using the specified cryptographic parameters.
        /// </summary>
        /// <param name="masterKey">The master key</param>
        /// <param name="encryptionKey">The recipient encryption key.</param>
        /// <returns>The recipient informatin object.</returns>
        public DareRecipient(byte[] masterKey, CryptoKey encryptionKey) {
            //var ExchangeProvider = PublicKey.ExchangeProvider();
            //ExchangeProvider.Encrypt(MasterKey, out var Exchange, out var Ephemeral, Salt: KDFSalt);


            encryptionKey.Encrypt(masterKey, out var exchange, out var ephemeral);

            if (ephemeral != null) {
                Epk = Key.GetPublic(ephemeral);
                }
            KeyIdentifier = encryptionKey.KeyIdentifier;
            WrappedMasterKey = exchange;

            }



        /// <summary>
        /// Create a DARERecipient using the specified cryptographic parameters.
        /// </summary>
        /// <param name="masterKey">The master key</param>
        /// <returns>The recipient informatin object.</returns>
        public DareRecipient(byte[] masterKey) => KeyIdentifier = UDF.SymetricKeyId(masterKey);
        }

    }
