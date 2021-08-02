
//  © 2021 by Phill Hallam-Baker
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
//  
//  
//  This file was automatically generated at 5/15/2021 1:18:01 AM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  yaschema version 3.0.0.730
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2021
//  
//  Build Platform: Win32NT 10.0.18362.0
//  
//  
using System.Collections.Generic;

using Goedel.Utilities;


namespace Goedel.Protocol.Presentation {

    /// <summary>
    /// Client connection class. Tracks the state of a client connection.
    /// </summary>
    public partial class ConnectionInitiator : RudConnection {


        // Serialize Client packet InitiatorHello

        /// <summary>
        /// Create a serialised packet of type InitiatorHello packet.
        /// </summary>
        /// <param name="sourceId">The source identifier.</param>
        /// <param name="payload">The payload data.</param>
        /// <param name="plaintextExtensionsIn">Additional extensions to be presented 
        /// in the plaintext segment.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeInitiatorHello(
                byte[] sourceId,
                byte[] payload = null,
                List<PacketExtension> plaintextExtensionsIn = null) {

            // The plaintext part
            var outerWriter = PacketWriterFactory();
            byte[] destinationId = null;
            outerWriter.WriteStreamId(destinationId);

            outerWriter.Write(InitiatorMessageType.InitiatorHello);
            // Plaintext fields..
            var plaintextExtensions = new List<PacketExtension>();
            AddEphemerals(destinationId, plaintextExtensions);
            plaintextExtensions.AddRangeSafe(plaintextExtensionsIn);
            outerWriter.WriteExtensions(plaintextExtensions);


            // Only have plaintext
            outerWriter.Write(sourceId);
            outerWriter.Write(payload);

            // Return the outermost packet
            return outerWriter.Packet;
            }

        // Serialize Client packet InitiatorComplete

        /// <summary>
        /// Create a serialised packet of type InitiatorComplete packet.
        /// </summary>
        /// <param name="sourceId">The source identifier.</param>
        /// <param name="payload">The payload data.</param>
        /// <param name="plaintextExtensionsIn">Additional extensions to be presented 
        /// in the plaintext segment.</param>
        /// <param name="mezanineExtensionsIn">Additional extensions to be presented
        /// in the mezzanine segment.</param>
        /// <param name="ciphertextExtensions">Additional extensions to be presented 
        /// in the encrypted segment.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeInitiatorComplete(
                byte[] sourceId,
                byte[] payload = null,
                List<PacketExtension> plaintextExtensionsIn = null,
                List<PacketExtension> mezanineExtensionsIn = null,
                List<PacketExtension> ciphertextExtensions = null) {

            // The plaintext part
            var outerWriter = PacketWriterFactory();
            byte[] destinationId = null;
            outerWriter.WriteStreamId(destinationId);

            outerWriter.Write(InitiatorMessageType.InitiatorComplete);
            // Plaintext fields..
            var plaintextExtensions = new List<PacketExtension>();
            ClientKeyExchange(out var ephemeral, out var hostKeyId);
            outerWriter.Write(hostKeyId);
            outerWriter.Write(ephemeral);
            AddResponse(plaintextExtensions);
            plaintextExtensions.AddRangeSafe(plaintextExtensionsIn);
            outerWriter.WriteExtensions(plaintextExtensions);


            // Mezzanine
            var mezanineWriter = PacketWriterFactory(outerWriter);
            var mezanineExtensions = new List<PacketExtension>();
            MutualKeyExchange(out var clientKeyId);
            mezanineWriter.Write(clientKeyId);
            AddCredentials(mezanineExtensions);
            mezanineExtensions.AddRangeSafe(mezanineExtensionsIn);
            mezanineWriter.WriteExtensions(mezanineExtensions);
            // Encrypted inside Mezzanine
            var innerWriter = PacketWriterFactory(mezanineWriter);
            innerWriter.WriteExtensions(ciphertextExtensions);
            innerWriter.Write(sourceId);
            innerWriter.Write(payload);
            mezanineWriter.Encrypt(MutualKeyOut, innerWriter, false);
            outerWriter.Encrypt(ClientKeyOut, mezanineWriter, true);

            // Return the outermost packet
            return outerWriter.Packet;
            }



        /// <summary>
        /// Parse the packet <paramref name="packet"/> as a ResponderChallenge packet.
        /// </summary>
        /// <param name="packet">The packet data</param>
        /// <param name="position">Start position at which reading of the packet should start.</param>
        /// <param name="count">Maximum number of bytes to be read from <paramref name="packet"/>.
        /// If less than 0, <paramref name="packet"/> is read to the end.</param>
        /// <returns>The parsed packet.</returns>

        public PacketResponderChallenge ParseResponderChallenge(
                byte[] packet,
                int position = 0,
                int count = -1) {
            var result = new PacketResponderChallenge();
            PacketIn = result;
            // The plaintext part
            var outerReader = PacketReaderFactory(packet, position, count);
            result.PlaintextExtensions = outerReader.ReadExtensions();
            CredentialOther = CredentialSelf.GetCredentials(result.PlaintextExtensions);
            // Only have plaintext
            result.Payload = outerReader.ReadBinary();

            return result;
            }


        }

    public partial class ConnectionResponder : RudConnection {

        // Serialize Host packet ResponderChallenge

        /// <summary>
        /// Create a serialised packet of type ResponderChallenge packet.
        /// </summary>
        /// <param name="sourceId">The source identifier.</param>
        /// <param name="destinationId">The destination identifier.</param>
        /// <param name="payload">The payload data.</param>
        /// <param name="plaintextExtensionsIn">Additional extensions to be presented 
        /// in the plaintext segment.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeResponderChallenge(
                byte[] sourceId,
                byte[] destinationId,
                byte[] payload = null,
                List<PacketExtension> plaintextExtensionsIn = null) {

            // The plaintext part
            var outerWriter = PacketWriterFactory();
            outerWriter.WriteStreamId(destinationId);

            outerWriter.Write(ResponderMessageType.ResponderChallenge);
            // Plaintext fields..
            var plaintextExtensions = new List<PacketExtension>();
            AddEphemerals(destinationId, plaintextExtensions);
            AddChallenge(plaintextExtensions);
            AddCredentials(plaintextExtensions);
            plaintextExtensions.AddRangeSafe(plaintextExtensionsIn);
            outerWriter.WriteExtensions(plaintextExtensions);


            // Only have plaintext
            outerWriter.Write(payload);

            // Return the outermost packet
            return outerWriter.Packet;
            }



        /// <summary>
        /// Parse the packet <paramref name="packet"/> as a InitiatorHello packet.
        /// </summary>
        /// <param name="packet">The packet data</param>
        /// <param name="position">Start position at which reading of the packet should start.</param>
        /// <param name="count">Maximum number of bytes to be read from <paramref name="packet"/>.
        /// If less than 0, <paramref name="packet"/> is read to the end.</param>
        /// <returns>The parsed packet.</returns>

        public PacketInitiatorHello ParseInitiatorHello(
                byte[] packet,
                int position = 0,
                int count = -1) {
            var result = new PacketInitiatorHello();
            PacketIn = result;
            // The plaintext part
            var outerReader = PacketReaderFactory(packet, position, count);
            result.PlaintextExtensions = outerReader.ReadExtensions();
            // Only have plaintext
            result.SourceId = outerReader.ReadBinary();
            result.Payload = outerReader.ReadBinary();

            return result;
            }
        // Perform initial parse as static listener, only complete decrypt in session context

        /// <summary>
        /// Perform key exchanges and complete parsing of the packet
        /// </summary>
        public void CompleteInitiatorComplete(PacketInitiatorComplete result) {
            var outerReader = result.Reader;
            ClientKeyExchange(result.ClientEphemeral, result.HostKeyId);
            // Mezzanine
            var mezanineReader = outerReader.Decrypt(ClientKeyIn);
            result.ClientKeyId = mezanineReader.ReadString();
            result.MezzanineExtensions = mezanineReader.ReadExtensions();
            CredentialOther = CredentialSelf.GetCredentials(result.MezzanineExtensions);
            MutualKeyExchange(result.ClientKeyId);
            // Encrypted inside Mezzanine
            var innerReader = mezanineReader.Decrypt(MutualKeyIn, false);
            result.CiphertextExtensions = innerReader.ReadExtensions();
            result.SourceId = innerReader.ReadBinary();
            result.Payload = innerReader.ReadBinary();
            }
        }


    public partial class Listener {

        /// <summary>
        /// Parse the packet <paramref name="packet"/> as a InitiatorHello packet.
        /// </summary>
        /// <param name="packet">The packet data</param>
        /// <param name="position">Start position at which reading of the packet should start.</param>
        /// <param name="count">Maximum number of bytes to be read from <paramref name="packet"/>.
        /// If less than 0, <paramref name="packet"/> is read to the end.</param>
        /// <returns>The parsed packet.</returns>

        public static PacketInitiatorHello ParseInitiatorHello(
                byte[] packet,
                int position = 0,
                int count = -1) {
            var result = new PacketInitiatorHello();
            // The plaintext part
            var outerReader = PacketReaderFactory(packet, position, count);
            result.PlaintextExtensions = outerReader.ReadExtensions();
            // Only have plaintext
            result.SourceId = outerReader.ReadBinary();
            result.Payload = outerReader.ReadBinary();

            return result;
            }

        /// <summary>
        /// Parse the packet <paramref name="packet"/> as a InitiatorComplete packet.
        /// </summary>
        /// <param name="packet">The packet data</param>
        /// <param name="position">Start position at which reading of the packet should start.</param>
        /// <param name="count">Maximum number of bytes to be read from <paramref name="packet"/>.
        /// If less than 0, <paramref name="packet"/> is read to the end.</param>
        /// <returns>The parsed packet.</returns>

        public static PacketInitiatorComplete ParseInitiatorComplete(
                byte[] packet,
                int position = 0,
                int count = -1) {
            var result = new PacketInitiatorComplete();
            // The plaintext part
            var outerReader = PacketReaderFactory(packet, position, count);
            result.HostKeyId = outerReader.ReadString();
            result.ClientEphemeral = outerReader.ReadBinary();
            result.PlaintextExtensions = outerReader.ReadExtensions();
            // Parsing the inner packet is deferred until plaintext is parsed.
            result.Reader = outerReader;

            return result;
            }
        }


    /// <summary>
    /// Parsed InitiatorHello packet
    /// </summary>   
    public partial class PacketInitiatorHello : Packet {





        }


    /// <summary>
    /// Parsed InitiatorComplete packet
    /// </summary>   
    public partial class PacketInitiatorComplete : Packet {

        ///<summary>Packet reader used to complete reading of the packet.</summary> 
        public PacketReader Reader { get; set; }
        ///<summary>Options specified in the packet mezzanine.</summary> 
        public List<PacketExtension> MezzanineExtensions { get; set; }
        ///<summary>Options specified in the packet ciphertext.</summary> 
        public List<PacketExtension> CiphertextExtensions { get; set; }

        ///<summary>Host chosen ephemeral key.</summary> 
        public byte[] ClientEphemeral { get; set; }
        ///<summary>Client Key Identifier.</summary> 
        public string HostKeyId { get; set; }

        ///<summary>Host Key Identifier.</summary> 
        public string ClientKeyId { get; set; }


        }


    /// <summary>
    /// Parsed ResponderChallenge packet
    /// </summary>   
    public partial class PacketResponderChallenge : Packet {





        }

    }


