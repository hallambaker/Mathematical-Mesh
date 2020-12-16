using System;
using System.Collections.Generic;
using System.Text;

using Goedel.Cryptography.Jose;
using Goedel.Utilities;

namespace Goedel.Cryptography.Dare {


    public partial class DarePolicy {

        ///<summary>If true, payload data must be encrypted.</summary> 

        public bool Encrypt => EncryptKeys != null;

        ///<summary>Key collection to be used to resolve keys.</summary> 
        public IKeyLocate KeyLocate { get; set; }


        ///<summary></summary> 
        CryptoParameters CryptoParameters { get; set; }

        /// <summary>
        /// Default constructor used for deserialization.
        /// </summary>
        public DarePolicy() {
            }


        /// <summary>
        /// Convenience constructor to create a policy to be used to encode a container. The parameter
        /// <paramref name="keyLocate"/> is used to resolve the keys specified in 
        /// <paramref name="signers"/> and <paramref name="recipients"/>. The parameters 
        /// <paramref name="encrypt"/> and <paramref name="digest"/> allow the bulk ciphers to be
        /// specified using <see cref="CryptoAlgorithmId"/> parameters rather than JOSE identifiers.
        /// Additional properties MAY be specified directly.
        /// </summary>
        /// <param name="keyLocate">The key location instance.</param>
        /// <param name="signers">Signer identifiers. to be resolved using <paramref name="keyLocate"/></param>
        /// <param name="recipients">Recipient identifiers. to be resolved using <paramref name="keyLocate"/></param>
        /// <param name="encrypt">The bulk encryption algorithm.</param>
        /// <param name="digest">The bulk digest algorithm.</param>
        public DarePolicy(IKeyLocate keyLocate,
                List<string> signers=null, 
                List<string> recipients = null,
                CryptoAlgorithmId encrypt=CryptoAlgorithmId.NULL,
                CryptoAlgorithmId digest = CryptoAlgorithmId.NULL) {
            
            KeyLocate = keyLocate;
            EncryptionAlgorithm = encrypt.ToJoseID();
            DigestAlgorithm = digest.ToJoseID();

            if (recipients != null) {
                EncryptKeys = new List<Jose.Key>();

                foreach (var recipient in recipients) {
                    keyLocate.TryFindKeyEncryption(recipient, out var keypair).AssertTrue(KeyNotFound.Throw);
                    EncryptKeys.Add(Jose.Key.FactoryPublic(keypair as KeyPair));
                    }
                }
            
            signers.Future();

            Sealed = true;
            }

        /// <summary>
        /// Convenience constructor to create a policy to be used to encode a container. The parameter
        /// <paramref name="keyLocate"/> is used to resolve the keys specified in 
        /// <paramref name="signers"/> and <paramref name="recipients"/>. The parameters 
        /// <paramref name="encrypt"/> and <paramref name="digest"/> allow the bulk ciphers to be
        /// specified using <see cref="CryptoAlgorithmId"/> parameters rather than JOSE identifiers.
        /// Additional properties MAY be specified directly.
        /// </summary>
        /// <param name="keyLocate">The key location instance.</param>
        /// <param name="signers">Signer identifiers. to be resolved using <paramref name="keyLocate"/></param>
        /// <param name="recipients">Recipient identifiers. to be resolved using <paramref name="keyLocate"/></param>
        /// <param name="encrypt">The bulk encryption algorithm.</param>
        /// <param name="digest">The bulk digest algorithm.</param>
        public DarePolicy(IKeyLocate keyLocate,
                CryptoKey signer = null,
                CryptoKey recipient = null,
                CryptoAlgorithmId encrypt = CryptoAlgorithmId.NULL,
                CryptoAlgorithmId digest = CryptoAlgorithmId.NULL) {

            KeyLocate = keyLocate;
            EncryptionAlgorithm = encrypt.ToJoseID();
            DigestAlgorithm = digest.ToJoseID();

            if (recipient != null) {
                var joseKey = Jose.Key.FactoryPublic(recipient as KeyPair);
                EncryptKeys = new List<Jose.Key>() { joseKey };
                }
            if (signer != null) {
                var joseKey = Jose.Key.FactoryPublic(signer as KeyPair);
                EncryptKeys = new List<Jose.Key>() { joseKey };
                }


            Sealed = true;
            }



        /// <summary>
        /// Obsolete constructor being used for testing, eliminate when no longer used.
        /// </summary>
        /// <param name="cryptoParameters"></param>
        public DarePolicy(CryptoParameters cryptoParameters) {
            CryptoParameters = cryptoParameters;
            throw new NYI();
            }



        }

    }
