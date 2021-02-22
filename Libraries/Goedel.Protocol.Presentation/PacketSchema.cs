

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
    /// Client connection class. Tracks the state of a client connection.
    /// </summary>
    public partial class ConnectionClient : Connection {


        // Serialize Client packet ClientInitial

        /// <summary>
        /// Create a serialised packet of type ClientInitial packet.
        /// </summary>
        /// <param name="payload">The payload data.</param>
        /// <param name="plaintextExtensionsIn">Additional extensions to be presented 
        /// in the plaintext segment.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeXpacketClientInitial (
                byte[] payload = null,
                List<PacketExtension> plaintextExtensionsIn = null                ) {

            // The plaintext part
            var outerWriter = new PacketWriterAesGcm();
            // Plaintext fields..
            var plaintextExtensions = new List<PacketExtension>();
            AddEphemerals (plaintextExtensions);
            plaintextExtensions.AddRangeSafe(plaintextExtensionsIn);
            outerWriter.WriteExtensions(plaintextExtensions);


            // Only have plaintext
            outerWriter.Write(payload);

            // Return the outermost packet
            return outerWriter.Packet;
            }

        // Serialize Client packet ClientExchange

        /// <summary>
        /// Create a serialised packet of type ClientExchange packet.
        /// </summary>
        /// <param name="payload">The payload data.</param>
        /// <param name="plaintextExtensionsIn">Additional extensions to be presented 
        /// in the plaintext segment.</param>
        /// <param name="mezanineExtensionsIn">Additional extensions to be presented
        /// in the mezzanine segment.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeXpacketClientExchange (
                byte[] payload = null,
                List<PacketExtension> plaintextExtensionsIn = null,
                List<PacketExtension> mezanineExtensionsIn = null                ) {

            // The plaintext part
            var outerWriter = new PacketWriterAesGcm();
            // Plaintext fields..
            ClientKeyExchange (out var ephemeral, out var clientKeyId);
            outerWriter.Write (clientKeyId);
            outerWriter.Write (ephemeral);
            outerWriter.WriteExtensions(plaintextExtensionsIn);


            // Mezzanine
            var mezanineWriter = new PacketWriterAesGcm(outerWriter.RemainingSpace);
            var mezanineExtensions = new List<PacketExtension>();
            AddCredentials (mezanineExtensions);
            mezanineExtensions.AddRangeSafe(mezanineExtensionsIn);
            mezanineWriter.WriteExtensions(mezanineExtensions);
            mezanineWriter.Write(payload);
            outerWriter.Encrypt(ClientKeyOut, mezanineWriter);

            // Return the outermost packet
            return outerWriter.Packet;
            }

        // Serialize Client packet ClientComplete

        /// <summary>
        /// Create a serialised packet of type ClientComplete packet.
        /// </summary>
        /// <param name="payload">The payload data.</param>
        /// <param name="plaintextExtensionsIn">Additional extensions to be presented 
        /// in the plaintext segment.</param>
        /// <param name="mezanineExtensionsIn">Additional extensions to be presented
        /// in the mezzanine segment.</param>
        /// <param name="ciphertextExtensions">Additional extensions to be presented 
        /// in the encrypted segment.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeXpacketClientComplete (
                byte[] payload = null,
                List<PacketExtension> plaintextExtensionsIn = null,
                List<PacketExtension> mezanineExtensionsIn = null,
                List<PacketExtension> ciphertextExtensions = null                ) {

            // The plaintext part
            var outerWriter = new PacketWriterAesGcm();
            // There are no plaintext fields.
            outerWriter.WriteExtensions(plaintextExtensionsIn);


            // Mezzanine
            var mezanineWriter = new PacketWriterAesGcm(outerWriter.RemainingSpace);
            var mezanineExtensions = new List<PacketExtension>();
            MutualKeyExchange (out var hostKeyId);
            mezanineWriter.Write (hostKeyId);
            AddCredentials (mezanineExtensions);
            mezanineExtensions.AddRangeSafe(mezanineExtensionsIn);
            mezanineWriter.WriteExtensions(mezanineExtensions);
            // Encrypted inside Mezzanine
            var innerWriter = new PacketWriter(mezanineWriter.RemainingSpace);
            innerWriter.WriteExtensions(ciphertextExtensions);
            innerWriter.Write(payload);
            mezanineWriter.Encrypt(MutualKeyOut, innerWriter);
            outerWriter.Encrypt(ClientKeyOut, mezanineWriter);

            // Return the outermost packet
            return outerWriter.Packet;
            }

        // Serialize Client packet ClientCompleteDeferred

        /// <summary>
        /// Create a serialised packet of type ClientCompleteDeferred packet.
        /// </summary>
        /// <param name="payload">The payload data.</param>
        /// <param name="plaintextExtensionsIn">Additional extensions to be presented 
        /// in the plaintext segment.</param>
        /// <param name="mezanineExtensionsIn">Additional extensions to be presented
        /// in the mezzanine segment.</param>
        /// <param name="ciphertextExtensions">Additional extensions to be presented 
        /// in the encrypted segment.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeXpacketClientCompleteDeferred (
                byte[] payload = null,
                List<PacketExtension> plaintextExtensionsIn = null,
                List<PacketExtension> mezanineExtensionsIn = null,
                List<PacketExtension> ciphertextExtensions = null                ) {

            // The plaintext part
            var outerWriter = new PacketWriterAesGcm();
            // Plaintext fields..
            var plaintextExtensions = new List<PacketExtension>();
            ClientKeyExchange (out var ephemeral, out var clientKeyId);
            outerWriter.Write (clientKeyId);
            outerWriter.Write (ephemeral);
            AddResponse (plaintextExtensions);
            plaintextExtensions.AddRangeSafe(plaintextExtensionsIn);
            outerWriter.WriteExtensions(plaintextExtensions);


            // Mezzanine
            var mezanineWriter = new PacketWriterAesGcm(outerWriter.RemainingSpace);
            var mezanineExtensions = new List<PacketExtension>();
            MutualKeyExchange (out var hostKeyId);
            mezanineWriter.Write (hostKeyId);
            AddCredentials (mezanineExtensions);
            mezanineExtensions.AddRangeSafe(mezanineExtensionsIn);
            mezanineWriter.WriteExtensions(mezanineExtensions);
            // Encrypted inside Mezzanine
            var innerWriter = new PacketWriter(mezanineWriter.RemainingSpace);
            innerWriter.WriteExtensions(ciphertextExtensions);
            innerWriter.Write(payload);
            mezanineWriter.Encrypt(MutualKeyOut, innerWriter);
            outerWriter.Encrypt(ClientKeyOut, mezanineWriter);

            // Return the outermost packet
            return outerWriter.Packet;
            }



        /// <summary>
        /// Parse the packet <paramref name="packet"/> received from <paramref name="sourceId"/>
        /// as a HostExchange packet.
        /// </summary>
        /// <param name="sourceId">The packet source.</param>
        /// <param name="packet">The packet data</param>
        /// <returns>The parsed packet.</returns>

        public XpacketHostExchange ParseXpacketHostExchange (PortId sourceId, byte[] packet) {
            var result = new XpacketHostExchange () {
                SourcePortId = sourceId
                };

            // The plaintext part
            var outerReader = new PacketReaderAesGcm(packet);
            result.HostKeyId = outerReader.ReadString ();
            result.PlaintextExtensions = outerReader.ReadExtensions();
            ClientKeyExchange (result.HostKeyId);
            // Mezzanine
            var mezanineReader = outerReader.Decrypt (ClientKeyIn);
            result.MezzanineExtensions = mezanineReader.ReadExtensions();
            result.Payload = mezanineReader.ReadBinary();

            return result;
            }

        /// <summary>
        /// Parse the packet <paramref name="packet"/> received from <paramref name="sourceId"/>
        /// as a HostChallenge1 packet.
        /// </summary>
        /// <param name="sourceId">The packet source.</param>
        /// <param name="packet">The packet data</param>
        /// <returns>The parsed packet.</returns>

        public XpacketHostChallenge1 ParseXpacketHostChallenge1 (PortId sourceId, byte[] packet) {
            var result = new XpacketHostChallenge1 () {
                SourcePortId = sourceId
                };

            // The plaintext part
            var outerReader = new PacketReaderAesGcm(packet);
            result.PlaintextExtensions = outerReader.ReadExtensions();
            // Only have plaintext
            result.Payload = outerReader.ReadBinary();

            return result;
            }

        /// <summary>
        /// Parse the packet <paramref name="packet"/> received from <paramref name="sourceId"/>
        /// as a HostChallenge2 packet.
        /// </summary>
        /// <param name="sourceId">The packet source.</param>
        /// <param name="packet">The packet data</param>
        /// <returns>The parsed packet.</returns>

        public XpacketHostChallenge2 ParseXpacketHostChallenge2 (PortId sourceId, byte[] packet) {
            var result = new XpacketHostChallenge2 () {
                SourcePortId = sourceId
                };

            // The plaintext part
            var outerReader = new PacketReaderAesGcm(packet);
            result.PlaintextExtensions = outerReader.ReadExtensions();
            // Only have plaintext
            result.Payload = outerReader.ReadBinary();

            return result;
            }

        /// <summary>
        /// Parse the packet <paramref name="packet"/> received from <paramref name="sourceId"/>
        /// as a HostComplete packet.
        /// </summary>
        /// <param name="sourceId">The packet source.</param>
        /// <param name="packet">The packet data</param>
        /// <returns>The parsed packet.</returns>

        public XpacketHostComplete ParseXpacketHostComplete (PortId sourceId, byte[] packet) {
            var result = new XpacketHostComplete () {
                SourcePortId = sourceId
                };

            // The plaintext part
            var outerReader = new PacketReaderAesGcm(packet);
            result.PlaintextExtensions = outerReader.ReadExtensions();
            // Mezzanine
            var mezanineReader = outerReader.Decrypt (ClientKeyIn);
            result.ClientKeyId = outerReader.ReadString ();
            result.HostEphemeral = outerReader.ReadBinary ();
            MutualKeyExchange (result.HostEphemeral, result.ClientKeyId);
            result.MezzanineExtensions = mezanineReader.ReadExtensions();
            // Encrypted inside Mezzanine
            var innerReader = mezanineReader.Decrypt (MutualKeyIn);
            result.CiphertextExtensions = innerReader.ReadExtensions();
            result.Payload = innerReader.ReadBinary();

            return result;
            }


		}

    public partial class ConnectionHost : Connection {

        // Serialize Host packet HostExchange

        /// <summary>
        /// Create a serialised packet of type HostExchange packet.
        /// </summary>
        /// <param name="payload">The payload data.</param>
        /// <param name="plaintextExtensionsIn">Additional extensions to be presented 
        /// in the plaintext segment.</param>
        /// <param name="mezanineExtensionsIn">Additional extensions to be presented
        /// in the mezzanine segment.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeXpacketHostExchange (
                byte[] payload = null,
                List<PacketExtension> plaintextExtensionsIn = null,
                List<PacketExtension> mezanineExtensionsIn = null                ) {

            // The plaintext part
            var outerWriter = new PacketWriterAesGcm();
            // Plaintext fields..
            var plaintextExtensions = new List<PacketExtension>();
            ClientKeyExchange (out var clientKeyId);
            outerWriter.Write (clientKeyId);
            AddEphemerals (plaintextExtensions);
            AddCredentials (plaintextExtensions);
            plaintextExtensions.AddRangeSafe(plaintextExtensionsIn);
            outerWriter.WriteExtensions(plaintextExtensions);


            // Mezzanine
            var mezanineWriter = new PacketWriterAesGcm(outerWriter.RemainingSpace);
            mezanineWriter.WriteExtensions(plaintextExtensionsIn);
            mezanineWriter.Write(payload);
            outerWriter.Encrypt(ClientKeyOut, mezanineWriter);

            // Return the outermost packet
            return outerWriter.Packet;
            }

        // Serialize Host packet HostChallenge1

        /// <summary>
        /// Create a serialised packet of type HostChallenge1 packet.
        /// </summary>
        /// <param name="payload">The payload data.</param>
        /// <param name="plaintextExtensionsIn">Additional extensions to be presented 
        /// in the plaintext segment.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeXpacketHostChallenge1 (
                byte[] payload = null,
                List<PacketExtension> plaintextExtensionsIn = null                ) {

            // The plaintext part
            var outerWriter = new PacketWriterAesGcm();
            // Plaintext fields..
            var plaintextExtensions = new List<PacketExtension>();
            AddEphemerals (plaintextExtensions);
            AddChallenge (plaintextExtensions);
            AddCredentials (plaintextExtensions);
            plaintextExtensions.AddRangeSafe(plaintextExtensionsIn);
            outerWriter.WriteExtensions(plaintextExtensions);


            // Only have plaintext
            outerWriter.Write(payload);

            // Return the outermost packet
            return outerWriter.Packet;
            }

        // Serialize Host packet HostChallenge2

        /// <summary>
        /// Create a serialised packet of type HostChallenge2 packet.
        /// </summary>
        /// <param name="payload">The payload data.</param>
        /// <param name="plaintextExtensionsIn">Additional extensions to be presented 
        /// in the plaintext segment.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeXpacketHostChallenge2 (
                byte[] payload = null,
                List<PacketExtension> plaintextExtensionsIn = null                ) {

            // The plaintext part
            var outerWriter = new PacketWriterAesGcm();
            // Plaintext fields..
            var plaintextExtensions = new List<PacketExtension>();
            AddEphemerals (plaintextExtensions);
            AddChallenge (plaintextExtensions);
            plaintextExtensions.AddRangeSafe(plaintextExtensionsIn);
            outerWriter.WriteExtensions(plaintextExtensions);


            // Only have plaintext
            outerWriter.Write(payload);

            // Return the outermost packet
            return outerWriter.Packet;
            }

        // Serialize Host packet HostComplete

        /// <summary>
        /// Create a serialised packet of type HostComplete packet.
        /// </summary>
        /// <param name="payload">The payload data.</param>
        /// <param name="plaintextExtensionsIn">Additional extensions to be presented 
        /// in the plaintext segment.</param>
        /// <param name="mezanineExtensionsIn">Additional extensions to be presented
        /// in the mezzanine segment.</param>
        /// <param name="ciphertextExtensions">Additional extensions to be presented 
        /// in the encrypted segment.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeXpacketHostComplete (
                byte[] payload = null,
                List<PacketExtension> plaintextExtensionsIn = null,
                List<PacketExtension> mezanineExtensionsIn = null,
                List<PacketExtension> ciphertextExtensions = null                ) {

            // The plaintext part
            var outerWriter = new PacketWriterAesGcm();
            // There are no plaintext fields.
            outerWriter.WriteExtensions(plaintextExtensionsIn);


            // Mezzanine
            var mezanineWriter = new PacketWriterAesGcm(outerWriter.RemainingSpace);
            MutualKeyExchange (out var ephemeral, out var hostKeyId);
            mezanineWriter.Write (hostKeyId);
            mezanineWriter.Write (ephemeral);
            mezanineWriter.WriteExtensions(plaintextExtensionsIn);
            // Encrypted inside Mezzanine
            var innerWriter = new PacketWriter(mezanineWriter.RemainingSpace);
            innerWriter.WriteExtensions(ciphertextExtensions);
            innerWriter.Write(payload);
            mezanineWriter.Encrypt(MutualKeyOut, innerWriter);
            outerWriter.Encrypt(ClientKeyOut, mezanineWriter);

            // Return the outermost packet
            return outerWriter.Packet;
            }


        // Skip Client packet ClientInitial (initial packets parsed by the listener)
        // Skip Client packet ClientExchange (initial packets parsed by the listener)

        /// <summary>
        /// Parse the packet <paramref name="packet"/> received from <paramref name="sourceId"/>
        /// as a ClientComplete packet.
        /// </summary>
        /// <param name="sourceId">The packet source.</param>
        /// <param name="packet">The packet data</param>
        /// <returns>The parsed packet.</returns>

        public XpacketClientComplete ParseXpacketClientComplete (PortId sourceId, byte[] packet) {
            var result = new XpacketClientComplete () {
                SourcePortId = sourceId
                };

            // The plaintext part
            var outerReader = new PacketReaderAesGcm(packet);
            result.PlaintextExtensions = outerReader.ReadExtensions();
            // Parsing the inner packet is deferred until plaintext is parsed.
            result.Reader = outerReader;

            return result;
            }

        /// <summary>
        /// Parse the packet <paramref name="packet"/> received from <paramref name="sourceId"/>
        /// as a ClientCompleteDeferred packet.
        /// </summary>
        /// <param name="sourceId">The packet source.</param>
        /// <param name="packet">The packet data</param>
        /// <returns>The parsed packet.</returns>

        public XpacketClientCompleteDeferred ParseXpacketClientCompleteDeferred (PortId sourceId, byte[] packet) {
            var result = new XpacketClientCompleteDeferred () {
                SourcePortId = sourceId
                };

            // The plaintext part
            var outerReader = new PacketReaderAesGcm(packet);
            result.HostKeyId = outerReader.ReadString ();
            result.ClientEphemeral = outerReader.ReadBinary ();
            result.PlaintextExtensions = outerReader.ReadExtensions();
            // Parsing the inner packet is deferred until plaintext is parsed.
            result.Reader = outerReader;

            return result;
            }

        /// <summary>
        /// Perform key exchanges and complete parsing of the packet
        /// </summary>
        public void CompleteClientExchange (XpacketClientExchange result) {
            var outerReader = result.Reader;
            ClientKeyExchange (result.ClientEphemeral, result.HostKeyId);
            // Mezzanine
            var mezanineReader = outerReader.Decrypt (ClientKeyIn);
            result.MezzanineExtensions = mezanineReader.ReadExtensions();
            result.Payload = mezanineReader.ReadBinary();
            }

        /// <summary>
        /// Perform key exchanges and complete parsing of the packet
        /// </summary>
        public void CompleteClientComplete (XpacketClientComplete result) {
            var outerReader = result.Reader;
            // Mezzanine
            var mezanineReader = outerReader.Decrypt (ClientKeyIn);
            result.ClientKeyId = outerReader.ReadString ();
            MutualKeyExchange (result.ClientKeyId);
            result.MezzanineExtensions = mezanineReader.ReadExtensions();
            // Encrypted inside Mezzanine
            var innerReader = mezanineReader.Decrypt (MutualKeyIn);
            result.CiphertextExtensions = innerReader.ReadExtensions();
            result.Payload = innerReader.ReadBinary();
            }

        /// <summary>
        /// Perform key exchanges and complete parsing of the packet
        /// </summary>
        public void CompleteClientCompleteDeferred (XpacketClientCompleteDeferred result) {
            var outerReader = result.Reader;
            ClientKeyExchange (result.ClientEphemeral, result.HostKeyId);
            // Mezzanine
            var mezanineReader = outerReader.Decrypt (ClientKeyIn);
            result.ClientKeyId = outerReader.ReadString ();
            MutualKeyExchange (result.ClientKeyId);
            result.MezzanineExtensions = mezanineReader.ReadExtensions();
            // Encrypted inside Mezzanine
            var innerReader = mezanineReader.Decrypt (MutualKeyIn);
            result.CiphertextExtensions = innerReader.ReadExtensions();
            result.Payload = innerReader.ReadBinary();
            }
		}


    public partial class Listener {

        /// <summary>
        /// Parse the packet <paramref name="packet"/> received from <paramref name="sourceId"/>
        /// as a ClientInitial packet.
        /// </summary>
        /// <param name="sourceId">The packet source.</param>
        /// <param name="packet">The packet data</param>
        /// <returns>The parsed packet.</returns>

        public XpacketClientInitial ParseXpacketClientInitial (PortId sourceId, byte[] packet) {
            var result = new XpacketClientInitial () {
                SourcePortId = sourceId
                };

            // The plaintext part
            var outerReader = new PacketReaderAesGcm(packet);
            result.PlaintextExtensions = outerReader.ReadExtensions();
            // Only have plaintext
            result.Payload = outerReader.ReadBinary();

            return result;
            }

        /// <summary>
        /// Parse the packet <paramref name="packet"/> received from <paramref name="sourceId"/>
        /// as a ClientExchange packet.
        /// </summary>
        /// <param name="sourceId">The packet source.</param>
        /// <param name="packet">The packet data</param>
        /// <returns>The parsed packet.</returns>

        public XpacketClientExchange ParseXpacketClientExchange (PortId sourceId, byte[] packet) {
            var result = new XpacketClientExchange () {
                SourcePortId = sourceId
                };

            // The plaintext part
            var outerReader = new PacketReaderAesGcm(packet);
            result.HostKeyId = outerReader.ReadString ();
            result.ClientEphemeral = outerReader.ReadBinary ();
            result.PlaintextExtensions = outerReader.ReadExtensions();
            // Parsing the inner packet is deferred until plaintext is parsed.
            result.Reader = outerReader;

            return result;
            }
		}


    /// <summary>
    /// Parsed ClientInitial packet
    /// </summary>   
    public partial class XpacketClientInitial : Packet {





        }


    /// <summary>
    /// Parsed ClientExchange packet
    /// </summary>   
    public partial class XpacketClientExchange : Packet {

        ///<summary>Packet reader used to complete reading of the packet.</summary> 
        public PacketReader Reader{ get; set; }
        ///<summary>Options specified in the packet mezzanine.</summary> 
        public List<PacketExtension> MezzanineExtensions{ get; set; }

        ///<summary>Host chosen ephemeral key.</summary> 
        public byte[] ClientEphemeral  { get; set; }
        ///<summary>Client Key Identifier.</summary> 
        public string HostKeyId { get; set; }



        }


    /// <summary>
    /// Parsed ClientComplete packet
    /// </summary>   
    public partial class XpacketClientComplete : Packet {

        ///<summary>Packet reader used to complete reading of the packet.</summary> 
        public PacketReader Reader{ get; set; }
        ///<summary>Options specified in the packet mezzanine.</summary> 
        public List<PacketExtension> MezzanineExtensions{ get; set; }
        ///<summary>Options specified in the packet ciphertext.</summary> 
        public List<PacketExtension> CiphertextExtensions { get; set; }


        ///<summary>Host Key Identifier.</summary> 
        public string ClientKeyId { get; set; }


        }


    /// <summary>
    /// Parsed ClientCompleteDeferred packet
    /// </summary>   
    public partial class XpacketClientCompleteDeferred : Packet {

        ///<summary>Packet reader used to complete reading of the packet.</summary> 
        public PacketReader Reader{ get; set; }
        ///<summary>Options specified in the packet mezzanine.</summary> 
        public List<PacketExtension> MezzanineExtensions{ get; set; }
        ///<summary>Options specified in the packet ciphertext.</summary> 
        public List<PacketExtension> CiphertextExtensions { get; set; }

        ///<summary>Host chosen ephemeral key.</summary> 
        public byte[] ClientEphemeral  { get; set; }
        ///<summary>Client Key Identifier.</summary> 
        public string HostKeyId { get; set; }

        ///<summary>Host Key Identifier.</summary> 
        public string ClientKeyId { get; set; }


        }


    /// <summary>
    /// Parsed HostExchange packet
    /// </summary>   
    public partial class XpacketHostExchange : Packet {

        ///<summary>Options specified in the packet mezzanine.</summary> 
        public List<PacketExtension> MezzanineExtensions{ get; set; }

        ///<summary>Client Key Identifier.</summary> 
        public string HostKeyId { get; set; }



        }


    /// <summary>
    /// Parsed HostChallenge1 packet
    /// </summary>   
    public partial class XpacketHostChallenge1 : Packet {





        }


    /// <summary>
    /// Parsed HostChallenge2 packet
    /// </summary>   
    public partial class XpacketHostChallenge2 : Packet {





        }


    /// <summary>
    /// Parsed HostComplete packet
    /// </summary>   
    public partial class XpacketHostComplete : Packet {

        ///<summary>Options specified in the packet mezzanine.</summary> 
        public List<PacketExtension> MezzanineExtensions{ get; set; }
        ///<summary>Options specified in the packet ciphertext.</summary> 
        public List<PacketExtension> CiphertextExtensions { get; set; }


        ///<summary>Client chosen ephemeral key.</summary> 
        public byte[] HostEphemeral  { get; set; }
        ///<summary>Host Key Identifier.</summary> 
        public string ClientKeyId { get; set; }


        }

	}


