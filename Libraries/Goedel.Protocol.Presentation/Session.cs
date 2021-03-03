//  Copyright © 2021 by Threshold Secrets Llc.
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.

using System.Collections.Generic;
using System.Threading.Tasks;

using Goedel.Utilities;
using Goedel.Cryptography;

namespace Goedel.Protocol.Presentation {
    /// <summary>
    /// Base class for presentation connections.
    /// </summary>
    public abstract class Session : Disposable{

        #region // Properties

        ///<summary>Symmetric key used to encrypt/decrypt mezzanine data sent by the client to 
        ///the host.</summary> 
        public byte[] ClientKeyClientToHost { get; set; }
        ///<summary>Symmetric key used to encrypt/decrypt mezzanine data sent by the host to 
        ///the client.</summary> 
        public byte[] ClientKeyHostToClient { get; set; }
        ///<summary>Symmetric key used to encrypt/decrypt inner data sent by the client to 
        ///the host.</summary> 
        public byte[] MutualKeyClientToHost { get; set; }
        ///<summary>Symmetric key used to encrypt/decrypt inner data sent by the host to 
        ///the client.</summary> 
        public byte[] MutualKeyHostToClient { get; set; }

        ///<summary>Symmetric key used to decrypt received mezzanine data.</summary> 
        public abstract byte[] ClientKeyIn { get; }
        ///<summary>Symmetric key used to encrypt sent mezzanine data.</summary> 
        public abstract byte[] ClientKeyOut { get; }
        ///<summary>Symmetric key used to decrypt received inner data.</summary> 
        public abstract byte[] MutualKeyIn { get; }
        ///<summary>Symmetric key used to encrypt sent inner data.</summary> 
        public abstract byte[] MutualKeyOut { get; }

        ///<summary>Public credential of the counter party.</summary> 
        public virtual Credential CredentialOther { get; set; }
        ///<summary>Private credential of self.</summary> 
        public virtual Credential CredentialSelf { get; set; }

        ///<summary>The host credential</summary> 
        public abstract Credential HostCredential { get; }

        ///<summary>The client credential</summary> 
        public abstract Credential ClientCredential { get; }

        ///<summary>The packet that the connection is a response to.</summary> 
        public Packet PacketIn { get; set; }


        ///<summary>Completion task source.</summary> 
        public TaskCompletionSource TaskCompletion { get; set; }


        List<KeyPairAdvanced> ephemeralsOffered;
        #endregion

        #region // Destructor
        #endregion

        #region // Constructors
        #endregion

        #region // Methods - Serialization
        /// <summary>
        /// Generate a set of ephemerals for the supported algorithms to offer for 
        /// key agreement and add to <paramref name="extensions"/>.
        /// </summary>
        /// <param name="extensions">List of extensions to add the ephemerals to.</param>
        public virtual void AddEphemerals(
            List<PacketExtension> extensions) =>
                    CredentialSelf.AddEphemerals(extensions, ref ephemeralsOffered);

        /// <summary>
        /// Add the credentials specified in <see cref="CredentialSelf"/> to 
        /// <paramref name="extensions"/>
        /// </summary>
        /// <param name="extensions">List of extensions to add the ephemerals to.</param>
        public virtual void AddCredentials(
            List<PacketExtension> extensions) => CredentialSelf.AddCredentials(extensions);

        /// <summary>
        /// Add a challenge value over the current state to <paramref name="extensions"/>
        /// </summary>
        /// <param name="extensions">List of extensions to add the ephemerals to.</param>
        public virtual void AddChallenge(
                List<PacketExtension> extensions) {

            }

        /// <summary>
        /// Add a response value over the current state to <paramref name="extensions"/>
        /// </summary>
        /// <param name="extensions">List of extensions to add the ephemerals to.</param>
        public virtual void AddResponse(
                List<PacketExtension> extensions) {

            }

        #endregion
        #region // Methods - PacketData Serializer/Deserializer

        /// <summary>
        /// Serialize and mutually encrypt a data packet.
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="ciphertextExtensions"></param>
        public virtual byte[] SerializePacketData(
                byte[] payload = null,
                List<PacketExtension> ciphertextExtensions = null) {
            using var writer = new PacketWriterAesGcm();
            writer.WriteExtensions(ciphertextExtensions);
            writer.Write(payload);

            // encrypt the result and return.
            return writer.Wrap(MutualKeyOut);
            }

        /// <summary>
        /// Parse the data in <paramref name="packet"/> and return the resulting packet.
        /// </summary>
        /// <param name="sourceId">The data source.</param>
        /// <param name="packet">The encrypted packet</param>
        /// <returns>Packet specifying the decrypted payload and extensions (if specified).</returns>

        public virtual Packet ParsePacketData(PortId sourceId, byte[] packet) {
            var innerReader = PacketReaderAesGcm.Unwrap(MutualKeyIn, packet);

            var result = new PacketData() {
                SourcePortId = sourceId,
                };

            result.CiphertextExtensions = innerReader.ReadExtensions();
            result.Payload = innerReader.ReadBinary();

            return result;
            }

        #endregion
        #region // Methods - Key Agreement

        KeyAgreementResult clientKeyAgreementResult;
        KeyAgreementResult mutualKeyAgreementResult;
        /// <summary>
        /// Perform a key exchange to the host credential only. 
        /// </summary>
        /// <param name="privateKey">The private key</param>
        /// <param name="keyPublic">The public key.</param>
        public void ClientKeyExchange(
                        KeyPairAdvanced privateKey,
                        KeyPairAdvanced keyPublic) {
            clientKeyAgreementResult = privateKey.Agreement(keyPublic);

            var keyDerive = clientKeyAgreementResult.KeyDerive;

            Screen.WriteLine($"Key Agreement {privateKey.KeyIdentifier}.{keyPublic.KeyIdentifier}");
            Screen.WriteLine($"     {clientKeyAgreementResult.IKM.ToStringBase16()}");

            ClientKeyClientToHost = keyDerive.Derive(Constants.TagKeyClientHost, Constants.SizeKeyAesGcm * 8);
            ClientKeyHostToClient = keyDerive.Derive(Constants.TagKeyHostClient, Constants.SizeKeyAesGcm * 8);
            }


        /// <summary>
        /// Perform a client key exchange to the host credential using an ephemeral chosen from the
        /// set of ephemerals chosen by the client.
        /// </summary>
        /// <param name="keyId">Host key identifier</param>
        public void ClientKeyExchange(out string keyId) {
            var (privateKey, publicEphemeral) = HostCredential.SelectKey(PacketIn.PlaintextExtensions);
            keyId = privateKey.KeyIdentifier;
            ClientKeyExchange(privateKey, publicEphemeral);
            }

        /// <summary>
        /// Perform a client key exchange to the host credential using the ephemeral chosen by the
        /// client.
        /// </summary>
        /// <param name="ephemeral"></param>
        /// <param name="keyId"></param>
        public virtual void ClientKeyExchange(byte[] ephemeral, string keyId) {
            var (privateKey, publicEphemeral) = HostCredential.SelectKey(keyId, ephemeral);
            ClientKeyExchange(privateKey, publicEphemeral);
            }


        /// <summary>
        /// Perform a client key exchange to the key <paramref name="keyId"/> using the first compatible 
        /// ephemeral previously offered.
        /// </summary>
        /// <param name="keyId">Host key identifier</param>
        public virtual void ClientKeyExchange(string keyId) {
            var (privateEphemeral, publickey) = HostCredential.SelectKey(ephemeralsOffered, keyId);
            ClientKeyExchange(privateEphemeral, publickey);
            }


        /// <summary>
        /// Perform a client key exchange to the host credential selecting a key and generating a
        /// compatible ephemeral returned as <paramref name="ephemeral"/>.
        /// </summary>
        /// <param name="ephemeral">The ephemeral generated.</param>
        /// <param name="keyId">Host key identifier</param>
        public virtual void ClientKeyExchange(out byte[] ephemeral, out string keyId) {
            var (privateEphemeral, publickey) = HostCredential.SelectKey();
            ClientKeyExchange(privateEphemeral, publickey);

            keyId = publickey.KeyIdentifier;
            ephemeral = privateEphemeral.IKeyAdvancedPublic.Encoding;
            }



        /// <summary>
        /// Complete a mutual key exchange to the client credential and previous client exchange. 
        /// </summary>
        /// <param name="privateKey">The private key</param>
        /// <param name="keyPublic">The public key.</param>
        public void MutualKeyExchange(
                        KeyPairAdvanced privateKey,
                        KeyPairAdvanced keyPublic) {
            mutualKeyAgreementResult = privateKey.Agreement(keyPublic);

            var ikm = clientKeyAgreementResult.IKM.Concatenate(mutualKeyAgreementResult.IKM);

            var keyDerive = new KeyDeriveHKDF(ikm);

            MutualKeyClientToHost = keyDerive.Derive(Constants.TagKeyClientHost, Constants.SizeKeyAesGcm * 8);
            MutualKeyHostToClient = keyDerive.Derive(Constants.TagKeyHostClient, Constants.SizeKeyAesGcm * 8);
            }


        /// <summary>
        /// Complete a mutual key exchange to the client credential using an ephemeral chosen from the
        /// set of nonces chosen by the host to complete a mutual key exchange.
        /// </summary>
        /// <param name="keyId">Client key identifier</param>
        public virtual void MutualKeyExchange(out string keyId) {
            var (privateKey, publicEphemeral) = ClientCredential.SelectKey(PacketIn.PlaintextExtensions);
            keyId = privateKey.KeyIdentifier;
            MutualKeyExchange(privateKey, publicEphemeral);
            }

        /// <summary>
        /// Complete a mutual key exchange to the host credential using the ephemeral chosen by the
        /// host.
        /// </summary>
        /// <param name="ephemeral"></param>
        /// <param name="keyId"></param>
        public virtual void MutualKeyExchange(byte[] ephemeral, string keyId) {
            var (privateKey, publicEphemeral) = ClientCredential.SelectKey(keyId, ephemeral);
            MutualKeyExchange(privateKey, publicEphemeral);
            }

        /// <summary>
        /// Complete a mutual key exchange to the key <paramref name="keyId"/> using the first compatible 
        /// ephemeral previously offered.
        /// </summary>
        /// <param name="keyId">Host key identifier</param>
        public virtual void MutualKeyExchange(string keyId) {
            var (privateEphemeral, publickey) = ClientCredential.SelectKey(ephemeralsOffered, keyId);
            MutualKeyExchange(privateEphemeral, publickey);
            }

        /// <summary>
        /// Complete a mutual key exchange to the client credential selecting a key and generating a
        /// compatible ephemeral returned as <paramref name="ephemeral"/> to complete a 
        /// mutual key exchange..
        /// </summary>
        /// <param name="ephemeral">The ephemeral generated.</param>
        /// <param name="keyId">Client key identifier</param>
        public virtual void MutualKeyExchange(out byte[] ephemeral, out string keyId) {
            var (privateEphemeral, publickey) = ClientCredential.SelectKey();
            MutualKeyExchange(privateEphemeral, publickey);

            keyId = publickey.KeyIdentifier;
            ephemeral = privateEphemeral.IKeyAdvancedPublic.Encoding;
            }


        #endregion

        }

    }
