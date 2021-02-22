using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Protocol;
using System.Threading.Tasks;

namespace Goedel.Protocol.Presentation {

    /// <summary>
    /// Base class for presentation listeners.
    /// </summary>
    public abstract partial class Listener {
        }

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

    /// <summary>
    /// Presentation client connection. Tracks the state of a client connection.
    /// </summary>
    public partial class ConnectionClient : Connection {
        ///<summary>Symmetric key used to decrypt received mezzanine data.</summary> 
        public override byte[] ClientKeyIn => ClientKeyHostToClient;
        ///<summary>Symmetric key used to encrypt sent mezzanine data.</summary> 
        public override byte[] ClientKeyOut => ClientKeyClientToHost;
        ///<summary>Symmetric key used to decrypt received inner data.</summary> 
        public override byte[] MutualKeyIn => MutualKeyHostToClient;
        ///<summary>Symmetric key used to encrypt sent inner data.</summary> 
        public override byte[] MutualKeyOut => MutualKeyClientToHost;
        ///<summary>The host credential</summary> 
        public override Credential HostCredential => CredentialOther;
        ///<summary>The client credential</summary> 
        public override Credential ClientCredential => CredentialSelf;
        }

    /// <summary>
    /// Presentation host connection. Tracks the state of a host connection.
    /// </summary>
    public partial class ConnectionHost : Connection {
        ///<summary>Symmetric key used to decrypt received mezzanine data.</summary> 
        public override byte[] ClientKeyIn => ClientKeyClientToHost;
        ///<summary>Symmetric key used to encrypt sent mezzanine data.</summary> 
        public override byte[] ClientKeyOut => ClientKeyHostToClient;
        ///<summary>Symmetric key used to decrypt received inner data.</summary> 
        public override byte[] MutualKeyIn => MutualKeyClientToHost;
        ///<summary>Symmetric key used to encrypt sent inner data.</summary>
        public override byte[] MutualKeyOut => MutualKeyHostToClient;
        ///<summary>The host credential</summary> 
        public override Credential HostCredential => CredentialSelf;
        ///<summary>The client credential</summary> 
        public override Credential ClientCredential => CredentialOther;
        }

    /// <summary>
    /// Base class for presentation credentials.
    /// </summary>
    public abstract class Credential {
        }





    /// <summary>
    /// Base class for packet classes.
    /// </summary>
    public class Packet {
        ///<summary>The packet payload.</summary> 
        public byte[] Payload { get; set; }

        ///<summary>The source address and port.</summary> 
        public PortId SourcePortId;

        ///<summary>Options specified in the packet plaintext.</summary> 
        public List<PacketExtension> PlaintextExtensions { get; set; }



        /// <summary>
        /// Perform key exchanges and complete parsing of the packet
        /// </summary>
        public virtual void Complete() {
            }

        }

    }
