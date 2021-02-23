using System.Collections.Generic;
using System.Threading.Tasks;



namespace Goedel.Protocol.Presentation {
    /// <summary>
    /// Base class for presentation connections.
    /// </summary>
    public abstract class Connection {

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


        /// <summary>
        /// Generate a set of ephemerals for the supported algorithms to offer for 
        /// key agreement and add to <paramref name="extensions"/>.
        /// </summary>
        /// <param name="extensions">List of extensions to add the ephemerals to.</param>
        public virtual void AddEphemerals(
            List<PacketExtension> extensions) {

            }

        /// <summary>
        /// Add the credentials specified in <see cref="CredentialSelf"/> to 
        /// <paramref name="extensions"/>
        /// </summary>
        /// <param name="extensions">List of extensions to add the ephemerals to.</param>
        public virtual void AddCredentials(
            List<PacketExtension> extensions) {

            }

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


        public virtual void ClientKeyExchange(string keyId) {
            }

        public virtual void ClientKeyExchange(byte[] ephemeral, string keyId) {
            }


        public virtual void MutualKeyExchange(string keyId) {
            }

        public virtual void MutualKeyExchange(byte[] ephemeral, string keyId) {
            }




        /// <summary>
        /// Perform a key exchange to the host credential using a nonce chosen from the
        /// set of nonces chosen by the client.
        /// </summary>
        /// <param name="keyId">Host key identifier</param>
        public virtual void ClientKeyExchange(out string keyId) {
            keyId = null;
            }

        /// <summary>
        /// Perform a key exchange to the host credential selecting a key and generating a
        /// compatible ephemeral returned as <paramref name="ephemeral"/>.
        /// </summary>
        /// <param name="ephemeral">The ephemeral generated.</param>
        /// <param name="keyId">Host key identifier</param>
        public virtual void ClientKeyExchange(out byte[] ephemeral, out string keyId) {
            keyId = null;
            ephemeral = null;
            }

        /// <summary>
        /// Perform a key exchange to the client credential using a nonce chosen from the
        /// set of nonces chosen by the host to complete a mutual key exchange.
        /// </summary>
        /// <param name="keyId">Client key identifier</param>
        public virtual void MutualKeyExchange(out string keyId) {
            keyId = null;
            }

        /// <summary>
        /// Perform a key exchange to the client credential selecting a key and generating a
        /// compatible ephemeral returned as <paramref name="ephemeral"/> to complete a 
        /// mutual key exchange..
        /// </summary>
        /// <param name="ephemeral">The ephemeral generated.</param>
        /// <param name="keyId">Client key identifier</param>
        public virtual void MutualKeyExchange(out byte[] ephemeral, out string keyId) {
            keyId = null;
            ephemeral = null;
            }

        }

    }
