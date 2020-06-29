namespace Goedel.Cryptography.Jose {
    public partial class PrivateKeyUDF {


        ///<summary>The encryption algorithm identifier</summary>
        public CryptoAlgorithmId AlgorithmEncryptID =>
            AlgorithmEncrypt != null ? AlgorithmEncrypt.FromJoseID() : CryptoAlgorithmId.Default;

        ///<summary>The signature algorithm identifier</summary>
        public CryptoAlgorithmId AlgorithmSignID =>
            AlgorithmSign != null ? AlgorithmSign.FromJoseID() : CryptoAlgorithmId.Default;

        ///<summary>The authentication algorithm identifier</summary>
        public CryptoAlgorithmId AlgorithmAuthenticateID =>
            AlgorithmAuthenticate != null ? AlgorithmAuthenticate.FromJoseID() : CryptoAlgorithmId.Default;


        /// <summary>
        /// Basic constructor for deserialization
        /// </summary>
        public PrivateKeyUDF() {
            }

        /// <summary>
        /// Constructor generating a new instance with a private key derived from the
        /// seed <paramref name="secret"/> if not null or a randomly generated key
        /// of <paramref name="bits"/> bits otherwise.
        /// </summary>
        /// <param name="udfAlgorithmIdentifier">The type of master secret.</param>
        /// <param name="algorithmEncrypt">The encryption algorithm.</param>
        /// <param name="algorithmSign">The signature algorithm</param>
        /// <param name="algorithmAuthenticate">The signature algorithm</param>
        /// <param name="secret">The master secret.</param>
        /// <param name="bits">The size of key to generate in bits/</param>
        public PrivateKeyUDF(
                UdfAlgorithmIdentifier udfAlgorithmIdentifier,
                CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default,
                byte[] secret = null,
                int bits = 256) : this(
                    udfAlgorithmIdentifier,
                    UDF.DerivedKey(udfAlgorithmIdentifier, data: secret ?? Platform.GetRandomBits(bits)), 
                                algorithmEncrypt, algorithmSign, algorithmAuthenticate
                    ) {
            }



        /// <summary>
        /// Constructor generating a new instance with a private key derrived from the
        /// seed  <paramref name="udf"/>.
        /// </summary>
        /// <param name="udfAlgorithmIdentifier">The type of master secret.</param>
        /// <param name="udf">The private seed value</param>
        /// <param name="algorithmEncrypt">The encryption algorithm.</param>
        /// <param name="algorithmSign">The signature algorithm</param>
        /// <param name="algorithmAuthenticate">The signature algorithm</param>

        public PrivateKeyUDF(
                UdfAlgorithmIdentifier udfAlgorithmIdentifier,
                string udf = null,
                CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default) {

            PrivateValue = udf;
            KeyType = udfAlgorithmIdentifier.ToString();

            AlgorithmSign = algorithmSign.ToJoseID();
            AlgorithmEncrypt = algorithmEncrypt.ToJoseID();
            AlgorithmAuthenticate = algorithmAuthenticate.ToJoseID();
            }


        }



    }
