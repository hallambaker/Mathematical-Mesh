//using System;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Cryptography.Jose;

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
        public DareRecipient () {
            }

        /// <summary>
        /// Create a DARERecipient using the specified cryptographic parameters.
        /// </summary>
        /// <param name="MasterKey">The master key</param>
        /// <param name="PublicKey">The recipient public key.</param>
        /// <returns>The recipient informatin object.</returns>
        public DareRecipient (byte[] MasterKey, KeyPair PublicKey) {
            //var ExchangeProvider = PublicKey.ExchangeProvider();
            //ExchangeProvider.Encrypt(MasterKey, out var Exchange, out var Ephemeral, Salt: KDFSalt);


            PublicKey.Encrypt(MasterKey, out var Exchange, out var Ephemeral, Salt: KDFSalt);


            var JoseKey = Key.GetPublic(Ephemeral);


            KeyIdentifier = PublicKey.UDF;
            Epk = JoseKey;
            WrappedMasterKey = Exchange;

            }


        }

    }
