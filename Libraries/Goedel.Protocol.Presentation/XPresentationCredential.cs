using Goedel.Cryptography;
using Goedel.Cryptography.Jose;

using System.Collections.Generic;

namespace Goedel.Protocol.Presentation {


    /// <summary>
    /// Base class for presentation credential
    /// </summary>
    public abstract class XPresentationCredential {

        // ToDo: It should not be necessary to access these keys directly.
        // Instead use matching to identify the most approrpriate algorithm.


        ///<summary>The signature key to sign under the credential.</summary> 
        public abstract KeyPairAdvanced KeySignPrivate { get; }

        ///<summary>The private key exchange key.</summary> 
        public abstract KeyPairAdvanced KeyExchangePrivate { get; }

        ///<summary>The signature verification key under the credential</summary> 
        public abstract KeyPairAdvanced KeySignPublic { get; }

        ///<summary>The public key exchange key.</summary> 
        public abstract KeyPairAdvanced KeyExchangePublic { get; }

        ///<summary>List of extension entries presenting credentials.</summary> 
        public abstract List<PacketExtension> GetCredentials { get; }



        /// <summary>
        /// Obsolete, to be removed.
        /// </summary>
        /// <param name="jsonWriter"></param>
        public abstract void WriteClientCredential(JsonWriter jsonWriter);


        /// <summary>
        /// Write credential type specifier and credential to packet.
        /// </summary>
        /// <param name="writer">The packet writer</param>
        public abstract void WriteCredential(PacketWriter writer);


        public abstract KeyPairAdvanced MatchPublic(string keyIdentifier);

        public abstract KeyPairAdvanced MatchPrivate(string keyIdentifier);

        /// <summary>
        /// Return a (public, private) key pair that can be used to perform a key exchange
        /// from the credential key exchange key(s) and the ephemeral keys presented in the
        /// list of extensions <paramref name="extensions"/>.
        /// </summary>
        /// <param name="extensions">List of extensions specifying an ephemeral key.</param>
        /// <returns>The key exchange parameters (if found).</returns>
        public (KeyPairAdvanced, KeyPairAdvanced) GetEphemeral() {

            var tag = KeyExchangePublic.CryptoAlgorithmId.ToJoseID();
            return (KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced, 
                        KeyExchangePrivate);

            }


        /// <summary>
        /// Return a (public, private) key pair that can be used to perform a key exchange
        /// from the credential key exchange key(s) and the ephemeral keys presented in the
        /// list of extensions <paramref name="extensions"/>.
        /// </summary>
        /// <param name="extensions">List of extensions specifying an ephemeral key.</param>
        /// <returns>The key exchange parameters (if found).</returns>
        public (byte[], KeyPairAdvanced) MatchEphemeral(List<PacketExtension> extensions) {

            var tag = KeyExchangePublic.CryptoAlgorithmId.ToJoseID();
            return (XPacket.GetExtension(extensions, tag), KeyExchangePrivate);

            }



        /// <summary>
        /// Return a (public, private) key pair that can be used to perform a key exchange
        /// from the credential key exchange key(s) and the ephemeral keys presented in the
        /// list of extensions <paramref name="extensions"/>.
        /// </summary>
        /// <param name="extensions">List of extensions specifying an ephemeral key.</param>
        /// <returns>The key exchange parameters (if found).</returns>
        public (byte[], KeyPairAdvanced) MatchEphemeral(List<PacketExtension> extensions,
                    string keyIdentifier) {

            var tag = KeyExchangePublic.CryptoAlgorithmId.ToJoseID();
            return (XPacket.GetExtension(extensions, tag), KeyExchangePrivate);

            }


        }


    }
