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

        PolicyEncryption PolicyEncryption { get; }

        PolicySignature PolicySignature { get; }

        int keyExchangeFrame;

        /// <summary>
        /// Create cryptoparameters for a container from the specified policy.
        /// </summary>
        /// <param name="containerType">The container type.</param>
        /// <param name="header">Header specifying the governing policy.</param>
        public CryptoParametersContainer(
                ContainerType containerType,
                DareHeader header,
                bool recover=false,
                IKeyLocate keyLocate=null) {

            var policy = header.Policy;

            // Force calculation of the payload digest for container types that require it.
            var digest = policy?.DigestAlgorithm;
            switch (containerType) {
                case ContainerType.Digest:
                case ContainerType.Chain:
                case ContainerType.Merkle: {
                    DigestId = digest.FromJoseIDDigest(true);
                    break;
                    }
                default: {
                    DigestId = digest.FromJoseIDDigest(false);
                    break;
                    }
                }

            if (policy == null) {
                PolicyEncryption = PolicyEncryption.None;
                EncryptId = CryptoAlgorithmId.NULL;
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
                EncryptId = digest.FromJoseIDEncryption(true);
                if (policy.EncryptKeys != null) {
                    EncryptionKeys = new List<CryptoKey>();
                    foreach (var key in policy.EncryptKeys) {
                        var keyPair = key.KeyPair;
                        EncryptionKeys.Add(keyPair);
                        }
                    }
                if (PolicyEncryption == PolicyEncryption.Once) {
                    keyExchangeFrame = 0;
                    if (recover) {
                        BaseSeed = keyLocate.Decrypt(header.Recipients, EncryptId);
                        }
                    else {
                         SetKeyExchange(header);
                        }
                    }
                else {
                    keyExchangeFrame = -1; // do not attempt to restart!
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
                    if (keyExchangeFrame==-1) {
                        previousFrame = currentFrame;
                        keyExchangeFrame = currentFrame;
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

        /// <summary>
        /// Get a trailer for an empty payload.
        /// </summary>
        /// <returns>The trailer with a null digest value.</returns>
        public DareTrailer GetNullTrailer() => new DareTrailer() {
            PayloadDigest = DigestProvider.NullDigest
            };

        CryptoProviderDigest DigestProvider => digestProvider ??= 
            CryptoCatalog.Default.GetDigest(DigestId).CacheValue(out digestProvider);
        CryptoProviderDigest digestProvider;

        /// <summary>
        /// Combine digests to produce the digest for a node.
        /// </summary>
        /// <param name="first">The left hand digest.</param>
        /// <param name="second">The right hand digest.</param>
        /// <returns>The digest value.</returns>
        public byte[] CombineDigest(
            byte[] first,
            byte[] second) {
            var length = DigestProvider.Size / 8;

            var buffer = new byte[length * 2];
            if (first != null) {
                Assert.AssertTrue(
                    length == first.Length,
                    CryptographicException.Throw);
                Array.Copy(first, buffer, length);
                }
            if (second != null) {
                Assert.AssertTrue(
                    length == second.Length,
                    CryptographicException.Throw);
                Array.Copy(second, 0, buffer, length, length);
                }


            return DigestProvider.ProcessData(buffer);
            }



        }


    }
