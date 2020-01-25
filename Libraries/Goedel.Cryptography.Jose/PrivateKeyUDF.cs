using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using System;
using System.Text;
using Goedel.Utilities;
namespace Goedel.Cryptography.Jose {
    public partial class PrivateKeyUDF {


        ///<summary>The encryption algorithm identifier</summary>
        public CryptoAlgorithmID AlgorithmEncryptID =>
            AlgorithmEncrypt != null ? AlgorithmEncrypt.FromJoseID() : CryptoAlgorithmID.Default;

        ///<summary>The signature algorithm identifier</summary>
        public CryptoAlgorithmID AlgorithmSignID =>
            AlgorithmSign != null ? AlgorithmSign.FromJoseID() : CryptoAlgorithmID.Default;

        ///<summary>The authentication algorithm identifier</summary>
        public CryptoAlgorithmID AlgorithmAuthenticateID =>
            AlgorithmAuthenticate != null ? AlgorithmAuthenticate.FromJoseID() : CryptoAlgorithmID.Default;


        /// <summary>
        /// Basic constructor for deserialization
        /// </summary>
        public PrivateKeyUDF() {
            }

        /// <summary>
        /// Constructor generating a new instance with a private key derrived from the
        /// seed <paramref name="masterSecret"/> if not null or a randomly generated key
        /// of <paramref name="bits"/> bits otherwise.
        /// </summary>
        /// <param name="udfAlgorithmIdentifier">The type of master secret.</param>
        /// <param name="algorithmEncrypt">The encryption algorithm.</param>
        /// <param name="algorithmSign">The signature algorithm</param>
        /// <param name="algorithmAuthenticate">The signature algorithm</param>
        /// <param name="masterSecret">The master secret.</param>
        /// <param name="bits">The size of key to generate in bits/</param>
        public PrivateKeyUDF(
                UdfAlgorithmIdentifier udfAlgorithmIdentifier,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default,
                byte[] masterSecret = null,
                int bits = 256) {

            masterSecret ??= Platform.GetRandomBits(bits);
            PrivateValue = Cryptography.UDF.DerivedKey(
                    udfAlgorithmIdentifier, data: masterSecret);
            KeyType = udfAlgorithmIdentifier.ToString();

            AlgorithmSign = algorithmSign.ToJoseID();
            AlgorithmEncrypt = algorithmEncrypt.ToJoseID();
            AlgorithmAuthenticate = algorithmAuthenticate.ToJoseID();
            }

        }

    //public partial class PrivateKeyUDFMaster {

    //    /// <summary>
    //    /// Basic constructor for deserialization
    //    /// </summary>
    //    public PrivateKeyUDFMaster() {
    //        }

    //    /// <summary>
    //    /// Constructor generating a new instance with a private key derrived from the
    //    /// seed <paramref name="masterSecret"/> if not null or a randomly generated key
    //    /// of <paramref name="bits"/> bits otherwise.
    //    /// </summary>
    //    /// <param name="algorithmEncrypt">The encryption algorithm.</param>
    //    /// <param name="algorithmSign">The signature algorithm</param>
    //    /// <param name="masterSecret">The master secret.</param>
    //    /// <param name="bits">The size of key to generate in bits/</param>
    //    public PrivateKeyUDFMaster(
    //            CryptoAlgorithmID algorithmEncrypt,
    //            CryptoAlgorithmID algorithmSign,
    //            byte[] masterSecret = null,
    //            int bits = 256) : base(UdfAlgorithmIdentifier.MeshProfileMaster,
    //                algorithmEncrypt, algorithmSign, CryptoAlgorithmID.NULL, masterSecret, bits) {
    //        }
    //    }


    //public partial class PrivateKeyUDFDevice {


    //    /// <summary>
    //    /// Basic constructor for deserialization
    //    /// </summary>
    //    public PrivateKeyUDFDevice() {
    //        }

    //    /// <summary>
    //    /// Constructor generating a new instance with a private key derrived from the
    //    /// seed <paramref name="masterSecret"/> if not null or a randomly generated key
    //    /// of <paramref name="bits"/> bits otherwise.
    //    /// </summary>
    //    /// <param name="algorithmEncrypt">The encryption algorithm.</param>
    //    /// <param name="algorithmSign">The signature algorithm</param>
    //    /// <param name="algorithmAuthenticate">The signature algorithm</param>
    //    /// <param name="masterSecret">The master secret.</param>
    //    /// <param name="bits">The size of key to generate in bits/</param>
    //    public PrivateKeyUDFDevice(
    //            CryptoAlgorithmID algorithmEncrypt,
    //            CryptoAlgorithmID algorithmSign,
    //            CryptoAlgorithmID algorithmAuthenticate,
    //            byte[] masterSecret = null,
    //            int bits = 256) : base(UdfAlgorithmIdentifier.MeshProfileDevice,
    //                algorithmEncrypt, algorithmSign, algorithmAuthenticate, masterSecret, bits) {
    //        }
    //    }



    //public partial class PrivateKeyUDFAccount {
    //    /// <summary>
    //    /// Basic constructor for deserialization
    //    /// </summary>
    //    public PrivateKeyUDFAccount() {
    //        }

    //    /// <param name="algorithmEncrypt">The encryption algorithm.</param>
    //    /// <param name="algorithmSign">The signature algorithm</param>
    //    /// <param name="algorithmAuthenticate">The signature algorithm</param>
    //    /// <param name="masterSecret">The master secret.</param>
    //    /// <param name="bits">The size of key to generate in bits/</param>
    //    public PrivateKeyUDFAccount(
    //            CryptoAlgorithmID algorithmEncrypt,
    //            CryptoAlgorithmID algorithmSign,
    //            CryptoAlgorithmID algorithmAuthenticate,
    //            byte[] masterSecret = null,
    //            int bits = 256) : base(UdfAlgorithmIdentifier.MeshProfileAccount,
    //                algorithmEncrypt, algorithmSign, algorithmAuthenticate, masterSecret, bits) {

    //        }

    //    }



    }
