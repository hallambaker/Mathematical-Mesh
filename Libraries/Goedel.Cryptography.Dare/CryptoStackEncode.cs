using System.Collections.Generic;
using Goedel.Cryptography.Jose;

namespace Goedel.Cryptography.Dare {
    /// <summary>
    /// Cryptographic stack to encode an envelope.
    /// </summary>
    public partial class CryptoStackEncode : CryptoStack {
        CryptoParameters CryptoParameters { get; }

        /// <summary>
        /// The Keys to be used to sign the message. 
        /// </summary>
        public override List<CryptoKey> SignerKeys => CryptoParameters.SignerKeys;

        /// <summary>
        /// The base seed provided as a verbatim value or provided through a key exchange to be 
        /// used together with the salt data to derive the keys and initialization data for 
        /// cryptographic operations.
        /// </summary>
        public override byte[] BaseSeed => CryptoParameters.BaseSeed;


        /// <summary>The authentication algorithm to use</summary>
        public override CryptoAlgorithmId DigestId => CryptoParameters.DigestId;


        /// <summary>The encryption algorithm to use</summary>
        public override CryptoAlgorithmId EncryptId => CryptoParameters.EncryptId;

        ///<summary>The block size in bytes.</summary> 
        protected override int BlockSizeByte => CryptoParameters.BlockSizeByte;


        ///<summary>The key size in bits determined by the value of <see cref="EncryptId"/></summary> 
        public override int KeySize => CryptoParameters.KeySize;

        ///<summary>The block size in bits determined by the value of <see cref="EncryptId"/></summary> 
        public override int BlockSize => CryptoParameters.BlockSize;

        /// <summary>
        /// Create a CryptoStack instance to encode data with the specified cryptographic
        /// parameters.
        /// </summary>
        /// <param name="cryptoParameters">The cryptographic parameters to create the stack from.</param>
        /// <param name="header">Header to write the key exchange information to</param>
        /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        public CryptoStackEncode(
                CryptoParameters cryptoParameters,
                DareHeader header,
                byte[] cloaked = null,
                List<byte[]> dataSequences = null) {

            CryptoParameters = cryptoParameters;

            header.CryptoStack = this;

            if (cryptoParameters.Encrypt) {
                header.EncryptionAlgorithm = EncryptId.ToJoseID();

                Salt = Platform.GetRandomBits(128);
                header.Salt = Salt;
                header.KeyIdentifier = GetKeyIdentifier();


                if (cryptoParameters is CryptoParametersContainer cryptoParametersContainer) {
                    if (cryptoParametersContainer.ReuseKeyExchange(header.Index, out var keyExchange)) {
                        header.ContainerInfo.ExchangePosition = keyExchange;
                        }
                    else {
                        cryptoParameters.SetKeyExchange(header);
                        }
                    }
                else {
                    cryptoParameters.SetKeyExchange(header);
                    }
                long saltValue = 0;
                if (cloaked != null) {
                    header.Cloaked = Encode(cloaked, MakeSalt(saltValue++));
                    }
                if (dataSequences != null) {
                    header.EDSS = new List<byte[]>();
                    foreach (var DataSequence in dataSequences) {
                        header.EDSS.Add(Encode(DataSequence, MakeSalt(saltValue++)));
                        }
                    }
                }

            if (DigestId != CryptoAlgorithmId.NULL) {
                header.DigestAlgorithm = DigestId.ToJoseID();
                }
            }


        }
    }