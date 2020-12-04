using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace Goedel.Cryptography.Dare {
    /// <summary>
    /// Specifies a set of cryptographic parameters to be used to create 
    /// CryptoStacks
    /// </summary>
    public partial class CryptoParametersContainer : CryptoParameters {

        bool ForcePolicy = false;
        DarePolicy Policy { get; set; }
        PolicyEncryption PolicyEncryption { get; }

        PolicySignature PolicySignature { get; }

        int keyExchangeFrame;

        /// <summary>
        /// Create cryptoparameters for a reopened container.
        /// </summary>
        /// <param name="keyCollection"></param>
        /// <param name="header">Header specifying the governing policy.</param>
        public CryptoParametersContainer(
                IKeyLocate keyCollection,
                ContainerType containerType,
                DareHeader header) {

            var policy = header.Policy;

            // Force calculation of the payload digest for container types that require it.
            switch (containerType) {
                case ContainerType.Digest:
                case ContainerType.Chain:
                case ContainerType.MerkleTree: {
                    var digest = policy?.DigestAlgorithm;
                    DigestId = digest != null ?
                            digest.FromJoseID() : CryptoID.DefaultDigestId;
                    break;
                    }
                }

            if (policy == null) {
                return; // no policy to set here.
                }

            // EncryptionAlgorithm, Encryption, EncryptKeys
            PolicyEncryption = policy.Encryption.ToPolicyEncryption();
            if (PolicyEncryption == PolicyEncryption.Unknown) {
                PolicyEncryption = policy.EncryptKeys == null ? PolicyEncryption.None :
                    PolicyEncryption.Isolated;
                }

            if (PolicyEncryption == PolicyEncryption.None) {
                EncryptId = CryptoAlgorithmId.NULL;
                }
            else {
                EncryptId = policy.EncryptionAlgorithm == null ? CryptoID.DefaultEncryptionId :
                    policy.EncryptionAlgorithm.FromJoseID();
                if (policy.EncryptKeys != null) {
                    EncryptionKeys = new List<CryptoKey>();
                    foreach (var key in policy.EncryptKeys) {
                        var keyPair = key.KeyPair;
                        EncryptionKeys.Add(keyPair);
                        }
                    }
                keyExchangeFrame = header.Index;
                if (keyExchangeFrame > 0 & PolicyEncryption == PolicyEncryption.Once) {
                    RecoverKeyExchange(header);
                    }
                }

            // DigestAlgorithm, Signature, SignKeys
            PolicySignature = policy.Signature.ToPolicySignature();
            if (PolicySignature == PolicySignature.Unknown) {
                PolicySignature = policy.SignKeys == null ? PolicySignature.None :
                    PolicySignature.Last;
                }
            if (PolicySignature != PolicySignature.None) {
                if (policy.SignKeys != null) {
                    SignerKeys = new List<CryptoKey>();
                    foreach (var key in policy.SignKeys) {
                        var keyPair = key.KeyPair;
                        EncryptionKeys.Add(keyPair);
                        }
                    }
                }
            }


        void RecoverKeyExchange(DareHeader header) {

            throw new NYI();
            }

        /// <summary>
        /// Applies the security policy and container status information to determine if a prior
        /// key exchange can be reused. If the value false is returned, a new key exchange is
        /// required. Otherwise, the value <paramref name="previousFrame"/> is set to the index value
        /// of the prior frame where the key exchange can be found.
        /// </summary>
        /// <param name="currentFrame"></param>
        /// <param name="previousFrame"></param>
        /// <returns></returns>
        public bool ReuseKeyExchange(
                int currentFrame,
                out int previousFrame) {

            switch (PolicyEncryption) {
                case PolicyEncryption.Isolated: {
                    previousFrame = currentFrame;
                    return false;
                    }
                case PolicyEncryption.Once:
                case PolicyEncryption.Session: {
                    if (currentFrame == keyExchangeFrame) {
                        previousFrame = currentFrame;
                        return false;
                        }
                    previousFrame = keyExchangeFrame;
                    return true;
                    }
                }

            throw new NYI();
            }


        /// <summary>
        /// Perform the steps necessary to 
        /// </summary>
        /// <param name="header"></param>
        public override void SetKeyExchange(DareHeader header) {

            header.Recipients = KeyExchange();


            }







        }
    }
