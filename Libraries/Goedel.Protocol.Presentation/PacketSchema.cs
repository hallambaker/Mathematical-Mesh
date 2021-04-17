
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
//  This file was automatically generated at 4/15/2021 5:25:38 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  yaschema version 3.0.0.704
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2021
//  
//  Build Platform: Win32NT 10.0.18362.0
//  
//  
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
    public partial class  ConnectionInitiator : Connection {


        // Serialize Client packet ClientInitial

        /// <summary>
        /// Create a serialised packet of type ClientInitial packet.
        /// </summary>
        /// <param name="sourceId">The source identifier.</param>
        /// <param name="destinationId">The destination identifier.</param>
        /// <param name="payload">The payload data.</param>
        /// <param name="plaintextExtensionsIn">Additional extensions to be presented 
        /// in the plaintext segment.</param>
        /// <param name="buffer">Buffer provided by caller</param>
        /// <param name="position">Offset within packet at which first byte is to be written.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeClientInitial (
                byte[] sourceId,
                byte[] destinationId,
                byte[] payload = null,
                List<PacketExtension> plaintextExtensionsIn = null,
                byte[] buffer=null,
                int position=0) {

            // The plaintext part
            var outerWriter = new PacketWriterAesGcm(buffer:buffer, position:position);
            outerWriter.WriteStreamId(destinationId);
            // Plaintext fields..
            var plaintextExtensions = new List<PacketExtension>();
            AddEphemerals (destinationId, plaintextExtensions);
            plaintextExtensions.AddRangeSafe(plaintextExtensionsIn);
            outerWriter.WriteExtensions(plaintextExtensions);


            // Only have plaintext
            outerWriter.Write(sourceId);
            outerWriter.Write(payload);

            // Return the outermost packet
            return outerWriter.Packet;
            }

        // Serialize Client packet ClientExchange

        /// <summary>
        /// Create a serialised packet of type ClientExchange packet.
        /// </summary>
        /// <param name="sourceId">The source identifier.</param>
        /// <param name="destinationId">The destination identifier.</param>
        /// <param name="payload">The payload data.</param>
        /// <param name="plaintextExtensionsIn">Additional extensions to be presented 
        /// in the plaintext segment.</param>
        /// <param name="mezanineExtensionsIn">Additional extensions to be presented
        /// in the mezzanine segment.</param>
        /// <param name="buffer">Buffer provided by caller</param>
        /// <param name="position">Offset within packet at which first byte is to be written.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeClientExchange (
                byte[] sourceId,
                byte[] destinationId,
                byte[] payload = null,
                List<PacketExtension> plaintextExtensionsIn = null,
                List<PacketExtension> mezanineExtensionsIn = null,
                byte[] buffer=null,
                int position=0) {

            // The plaintext part
            var outerWriter = new PacketWriterAesGcm(buffer:buffer, position:position);
            outerWriter.WriteStreamId(destinationId);
            // Plaintext fields..
            ClientKeyExchange (out var ephemeral, out var hostKeyId);
            outerWriter.Write (hostKeyId);
            outerWriter.Write (ephemeral);
            outerWriter.WriteExtensions(plaintextExtensionsIn);


            // Mezzanine
            var mezanineWriter = new PacketWriterAesGcm(outerWriter.RemainingSpace);
            var mezanineExtensions = new List<PacketExtension>();
            AddCredentials (mezanineExtensions);
            mezanineExtensions.AddRangeSafe(mezanineExtensionsIn);
            mezanineWriter.WriteExtensions(mezanineExtensions);
            mezanineWriter.Write(sourceId);
            mezanineWriter.Write(payload);
            outerWriter.Encrypt(ClientKeyOut, mezanineWriter);

            // Return the outermost packet
            return outerWriter.Packet;
            }

        // Serialize Client packet ClientComplete

        /// <summary>
        /// Create a serialised packet of type ClientComplete packet.
        /// </summary>
        /// <param name="sourceId">The source identifier.</param>
        /// <param name="destinationId">The destination identifier.</param>
        /// <param name="payload">The payload data.</param>
        /// <param name="plaintextExtensionsIn">Additional extensions to be presented 
        /// in the plaintext segment.</param>
        /// <param name="mezanineExtensionsIn">Additional extensions to be presented
        /// in the mezzanine segment.</param>
        /// <param name="ciphertextExtensions">Additional extensions to be presented 
        /// in the encrypted segment.</param>
        /// <param name="buffer">Buffer provided by caller</param>
        /// <param name="position">Offset within packet at which first byte is to be written.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeClientComplete (
                byte[] sourceId,
                byte[] destinationId,
                byte[] payload = null,
                List<PacketExtension> plaintextExtensionsIn = null,
                List<PacketExtension> mezanineExtensionsIn = null,
                List<PacketExtension> ciphertextExtensions = null,
                byte[] buffer=null,
                int position=0) {

            // The plaintext part
            var outerWriter = new PacketWriterAesGcm(buffer:buffer, position:position);
            outerWriter.WriteStreamId(destinationId);
            // There are no plaintext fields.
            outerWriter.WriteExtensions(plaintextExtensionsIn);


            // Mezzanine
            var mezanineWriter = new PacketWriterAesGcm(outerWriter.RemainingSpace);
            var mezanineExtensions = new List<PacketExtension>();
            MutualKeyExchange (out var clientKeyId);
            mezanineWriter.Write (clientKeyId);
            AddCredentials (mezanineExtensions);
            mezanineExtensions.AddRangeSafe(mezanineExtensionsIn);
            mezanineWriter.WriteExtensions(mezanineExtensions);
            // Encrypted inside Mezzanine
            var innerWriter = new PacketWriter(mezanineWriter.RemainingSpace);
            innerWriter.WriteExtensions(ciphertextExtensions);
            innerWriter.Write(sourceId);
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
        /// <param name="sourceId">The source identifier.</param>
        /// <param name="destinationId">The destination identifier.</param>
        /// <param name="payload">The payload data.</param>
        /// <param name="plaintextExtensionsIn">Additional extensions to be presented 
        /// in the plaintext segment.</param>
        /// <param name="mezanineExtensionsIn">Additional extensions to be presented
        /// in the mezzanine segment.</param>
        /// <param name="ciphertextExtensions">Additional extensions to be presented 
        /// in the encrypted segment.</param>
        /// <param name="buffer">Buffer provided by caller</param>
        /// <param name="position">Offset within packet at which first byte is to be written.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeClientCompleteDeferred (
                byte[] sourceId,
                byte[] destinationId,
                byte[] payload = null,
                List<PacketExtension> plaintextExtensionsIn = null,
                List<PacketExtension> mezanineExtensionsIn = null,
                List<PacketExtension> ciphertextExtensions = null,
                byte[] buffer=null,
                int position=0) {

            // The plaintext part
            var outerWriter = new PacketWriterAesGcm(buffer:buffer, position:position);
            outerWriter.WriteStreamId(destinationId);
            // Plaintext fields..
            var plaintextExtensions = new List<PacketExtension>();
            ClientKeyExchange (out var ephemeral, out var hostKeyId);
            outerWriter.Write (hostKeyId);
            outerWriter.Write (ephemeral);
            AddResponse (plaintextExtensions);
            plaintextExtensions.AddRangeSafe(plaintextExtensionsIn);
            outerWriter.WriteExtensions(plaintextExtensions);


            // Mezzanine
            var mezanineWriter = new PacketWriterAesGcm(outerWriter.RemainingSpace);
            var mezanineExtensions = new List<PacketExtension>();
            MutualKeyExchange (out var clientKeyId);
            mezanineWriter.Write (clientKeyId);
            AddCredentials (mezanineExtensions);
            mezanineExtensions.AddRangeSafe(mezanineExtensionsIn);
            mezanineWriter.WriteExtensions(mezanineExtensions);
            // Encrypted inside Mezzanine
            var innerWriter = new PacketWriter(mezanineWriter.RemainingSpace);
            innerWriter.WriteExtensions(ciphertextExtensions);
            innerWriter.Write(sourceId);
            innerWriter.Write(payload);
            mezanineWriter.Encrypt(MutualKeyOut, innerWriter);
            outerWriter.Encrypt(ClientKeyOut, mezanineWriter);

            // Return the outermost packet
            return outerWriter.Packet;
            }



        /// <summary>
        /// Parse the packet <paramref name="packet"/> as a HostExchange packet.
        /// </summary>
        /// <param name="packet">The packet data</param>
        /// <param name="position">Start position at which reading of the packet should start.</param>
        /// <param name="count">Maximum number of bytes to be read from <paramref name="packet"/>.
        /// If less than 0, <paramref name="packet"/> is read to the end.</param>
        /// <returns>The parsed packet.</returns>

        public  PacketHostExchange ParseHostExchange (
                byte[] packet,
                int position=0,
                int count = -1) {
            var result = new PacketHostExchange () ;
            PacketIn=result;
            // The plaintext part
            var outerReader = new PacketReaderAesGcm(packet, position, count);
            result.HostKeyId = outerReader.ReadString ();
            result.PlaintextExtensions = outerReader.ReadExtensions();
            CredentialOther = CredentialSelf.GetCredentials (result.PlaintextExtensions);
            ClientKeyExchange (result.HostKeyId);
            // Mezzanine
            var mezanineReader = outerReader.Decrypt (ClientKeyIn);
            result.MezzanineExtensions = mezanineReader.ReadExtensions();
            result.SourceId = mezanineReader.ReadBinary();
            result.Payload = mezanineReader.ReadBinary();

            return result;
            }

        /// <summary>
        /// Parse the packet <paramref name="packet"/> as a HostChallenge1 packet.
        /// </summary>
        /// <param name="packet">The packet data</param>
        /// <param name="position">Start position at which reading of the packet should start.</param>
        /// <param name="count">Maximum number of bytes to be read from <paramref name="packet"/>.
        /// If less than 0, <paramref name="packet"/> is read to the end.</param>
        /// <returns>The parsed packet.</returns>

        public  PacketHostChallenge1 ParseHostChallenge1 (
                byte[] packet,
                int position=0,
                int count = -1) {
            var result = new PacketHostChallenge1 () ;
            PacketIn=result;
            // The plaintext part
            var outerReader = new PacketReaderAesGcm(packet, position, count);
            result.PlaintextExtensions = outerReader.ReadExtensions();
            CredentialOther = CredentialSelf.GetCredentials (result.PlaintextExtensions);
            // Only have plaintext
            result.SourceId = outerReader.ReadBinary();
            result.Payload = outerReader.ReadBinary();

            return result;
            }

        /// <summary>
        /// Parse the packet <paramref name="packet"/> as a HostChallenge2 packet.
        /// </summary>
        /// <param name="packet">The packet data</param>
        /// <param name="position">Start position at which reading of the packet should start.</param>
        /// <param name="count">Maximum number of bytes to be read from <paramref name="packet"/>.
        /// If less than 0, <paramref name="packet"/> is read to the end.</param>
        /// <returns>The parsed packet.</returns>

        public  PacketHostChallenge2 ParseHostChallenge2 (
                byte[] packet,
                int position=0,
                int count = -1) {
            var result = new PacketHostChallenge2 () ;
            PacketIn=result;
            // The plaintext part
            var outerReader = new PacketReaderAesGcm(packet, position, count);
            result.PlaintextExtensions = outerReader.ReadExtensions();
            // Only have plaintext
            result.SourceId = outerReader.ReadBinary();
            result.Payload = outerReader.ReadBinary();

            return result;
            }

        /// <summary>
        /// Parse the packet <paramref name="packet"/> as a HostComplete packet.
        /// </summary>
        /// <param name="packet">The packet data</param>
        /// <param name="position">Start position at which reading of the packet should start.</param>
        /// <param name="count">Maximum number of bytes to be read from <paramref name="packet"/>.
        /// If less than 0, <paramref name="packet"/> is read to the end.</param>
        /// <returns>The parsed packet.</returns>

        public  PacketHostComplete ParseHostComplete (
                byte[] packet,
                int position=0,
                int count = -1) {
            var result = new PacketHostComplete () ;
            PacketIn=result;
            // The plaintext part
            var outerReader = new PacketReaderAesGcm(packet, position, count);
            result.PlaintextExtensions = outerReader.ReadExtensions();
            // Mezzanine
            var mezanineReader = outerReader.Decrypt (ClientKeyIn);
            result.ClientKeyId = mezanineReader.ReadString ();
            result.HostEphemeral = mezanineReader.ReadBinary ();
            result.MezzanineExtensions = mezanineReader.ReadExtensions();
            MutualKeyExchange (result.HostEphemeral, result.ClientKeyId);
            // Encrypted inside Mezzanine
            var innerReader = mezanineReader.Decrypt (MutualKeyIn);
            result.CiphertextExtensions = innerReader.ReadExtensions();
            result.SourceId = innerReader.ReadBinary();
            result.Payload = innerReader.ReadBinary();

            return result;
            }


		}

    public partial class ConnectionResponder : Connection {

        // Serialize Host packet HostExchange

        /// <summary>
        /// Create a serialised packet of type HostExchange packet.
        /// </summary>
        /// <param name="sourceId">The source identifier.</param>
        /// <param name="destinationId">The destination identifier.</param>
        /// <param name="payload">The payload data.</param>
        /// <param name="plaintextExtensionsIn">Additional extensions to be presented 
        /// in the plaintext segment.</param>
        /// <param name="mezanineExtensionsIn">Additional extensions to be presented
        /// in the mezzanine segment.</param>
        /// <param name="buffer">Buffer provided by caller</param>
        /// <param name="position">Offset within packet at which first byte is to be written.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeHostExchange (
                byte[] sourceId,
                byte[] destinationId,
                byte[] payload = null,
                List<PacketExtension> plaintextExtensionsIn = null,
                List<PacketExtension> mezanineExtensionsIn = null,
                byte[] buffer=null,
                int position=0) {

            // The plaintext part
            var outerWriter = new PacketWriterAesGcm(buffer:buffer, position:position);
            outerWriter.WriteStreamId(destinationId);
            outerWriter.Write(Constants.TagHostExchange);
            // Plaintext fields..
            var plaintextExtensions = new List<PacketExtension>();
            ClientKeyExchange (out var clientKeyId);
            outerWriter.Write (clientKeyId);
            AddEphemerals (destinationId, plaintextExtensions);
            AddCredentials (plaintextExtensions);
            plaintextExtensions.AddRangeSafe(plaintextExtensionsIn);
            outerWriter.WriteExtensions(plaintextExtensions);


            // Mezzanine
            var mezanineWriter = new PacketWriterAesGcm(outerWriter.RemainingSpace);
            mezanineWriter.WriteExtensions(mezanineExtensionsIn);
            mezanineWriter.Write(sourceId);
            mezanineWriter.Write(payload);
            outerWriter.Encrypt(ClientKeyOut, mezanineWriter);

            // Return the outermost packet
            return outerWriter.Packet;
            }

        // Serialize Host packet HostChallenge1

        /// <summary>
        /// Create a serialised packet of type HostChallenge1 packet.
        /// </summary>
        /// <param name="sourceId">The source identifier.</param>
        /// <param name="destinationId">The destination identifier.</param>
        /// <param name="payload">The payload data.</param>
        /// <param name="plaintextExtensionsIn">Additional extensions to be presented 
        /// in the plaintext segment.</param>
        /// <param name="buffer">Buffer provided by caller</param>
        /// <param name="position">Offset within packet at which first byte is to be written.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeHostChallenge1 (
                byte[] sourceId,
                byte[] destinationId,
                byte[] payload = null,
                List<PacketExtension> plaintextExtensionsIn = null,
                byte[] buffer=null,
                int position=0) {

            // The plaintext part
            var outerWriter = new PacketWriterAesGcm(buffer:buffer, position:position);
            outerWriter.WriteStreamId(destinationId);
            outerWriter.Write(Constants.TagHostChallenge1);
            // Plaintext fields..
            var plaintextExtensions = new List<PacketExtension>();
            AddEphemerals (destinationId, plaintextExtensions);
            AddChallenge (plaintextExtensions);
            AddCredentials (plaintextExtensions);
            plaintextExtensions.AddRangeSafe(plaintextExtensionsIn);
            outerWriter.WriteExtensions(plaintextExtensions);


            // Only have plaintext
            outerWriter.Write(sourceId);
            outerWriter.Write(payload);

            // Return the outermost packet
            return outerWriter.Packet;
            }

        // Serialize Host packet HostChallenge2

        /// <summary>
        /// Create a serialised packet of type HostChallenge2 packet.
        /// </summary>
        /// <param name="sourceId">The source identifier.</param>
        /// <param name="destinationId">The destination identifier.</param>
        /// <param name="payload">The payload data.</param>
        /// <param name="plaintextExtensionsIn">Additional extensions to be presented 
        /// in the plaintext segment.</param>
        /// <param name="buffer">Buffer provided by caller</param>
        /// <param name="position">Offset within packet at which first byte is to be written.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeHostChallenge2 (
                byte[] sourceId,
                byte[] destinationId,
                byte[] payload = null,
                List<PacketExtension> plaintextExtensionsIn = null,
                byte[] buffer=null,
                int position=0) {

            // The plaintext part
            var outerWriter = new PacketWriterAesGcm(buffer:buffer, position:position);
            outerWriter.WriteStreamId(destinationId);
            outerWriter.Write(Constants.TagHostChallenge2);
            // Plaintext fields..
            var plaintextExtensions = new List<PacketExtension>();
            AddEphemerals (destinationId, plaintextExtensions);
            AddChallenge (plaintextExtensions);
            plaintextExtensions.AddRangeSafe(plaintextExtensionsIn);
            outerWriter.WriteExtensions(plaintextExtensions);


            // Only have plaintext
            outerWriter.Write(sourceId);
            outerWriter.Write(payload);

            // Return the outermost packet
            return outerWriter.Packet;
            }

        // Serialize Host packet HostComplete

        /// <summary>
        /// Create a serialised packet of type HostComplete packet.
        /// </summary>
        /// <param name="sourceId">The source identifier.</param>
        /// <param name="destinationId">The destination identifier.</param>
        /// <param name="payload">The payload data.</param>
        /// <param name="plaintextExtensionsIn">Additional extensions to be presented 
        /// in the plaintext segment.</param>
        /// <param name="mezanineExtensionsIn">Additional extensions to be presented
        /// in the mezzanine segment.</param>
        /// <param name="ciphertextExtensions">Additional extensions to be presented 
        /// in the encrypted segment.</param>
        /// <param name="buffer">Buffer provided by caller</param>
        /// <param name="position">Offset within packet at which first byte is to be written.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeHostComplete (
                byte[] sourceId,
                byte[] destinationId,
                byte[] payload = null,
                List<PacketExtension> plaintextExtensionsIn = null,
                List<PacketExtension> mezanineExtensionsIn = null,
                List<PacketExtension> ciphertextExtensions = null,
                byte[] buffer=null,
                int position=0) {

            // The plaintext part
            var outerWriter = new PacketWriterAesGcm(buffer:buffer, position:position);
            outerWriter.WriteStreamId(destinationId);
            outerWriter.Write(Constants.TagHostComplete);
            // There are no plaintext fields.
            outerWriter.WriteExtensions(plaintextExtensionsIn);


            // Mezzanine
            var mezanineWriter = new PacketWriterAesGcm(outerWriter.RemainingSpace);
            MutualKeyExchange (out var ephemeral, out var clientKeyId);
            mezanineWriter.Write (clientKeyId);
            mezanineWriter.Write (ephemeral);
            mezanineWriter.WriteExtensions(mezanineExtensionsIn);
            // Encrypted inside Mezzanine
            var innerWriter = new PacketWriter(mezanineWriter.RemainingSpace);
            innerWriter.WriteExtensions(ciphertextExtensions);
            innerWriter.Write(sourceId);
            innerWriter.Write(payload);
            mezanineWriter.Encrypt(MutualKeyOut, innerWriter);
            outerWriter.Encrypt(ClientKeyOut, mezanineWriter);

            // Return the outermost packet
            return outerWriter.Packet;
            }


        // Skip Client packet ClientInitial (initial packets parsed by the listener)

        // Skip Client packet ClientExchange (initial packets parsed by the listener)

        // Perform initial parse as static listener, only complete decrypt in session context

        /// <summary>
        /// Perform key exchanges and complete parsing of the packet
        /// </summary>
        public void CompleteClientComplete (PacketClientComplete result) {
            var outerReader = result.Reader;
            // Mezzanine
            var mezanineReader = outerReader.Decrypt (ClientKeyIn);
            result.ClientKeyId = mezanineReader.ReadString ();
            result.MezzanineExtensions = mezanineReader.ReadExtensions();
            CredentialOther = CredentialSelf.GetCredentials (result.MezzanineExtensions);
            MutualKeyExchange (result.ClientKeyId);
            // Encrypted inside Mezzanine
            var innerReader = mezanineReader.Decrypt (MutualKeyIn);
            result.CiphertextExtensions = innerReader.ReadExtensions();
            result.SourceId = innerReader.ReadBinary();
            result.Payload = innerReader.ReadBinary();
            }
        // Perform initial parse as static listener, only complete decrypt in session context

        /// <summary>
        /// Perform key exchanges and complete parsing of the packet
        /// </summary>
        public void CompleteClientCompleteDeferred (PacketClientCompleteDeferred result) {
            var outerReader = result.Reader;
            ClientKeyExchange (result.ClientEphemeral, result.HostKeyId);
            // Mezzanine
            var mezanineReader = outerReader.Decrypt (ClientKeyIn);
            result.ClientKeyId = mezanineReader.ReadString ();
            result.MezzanineExtensions = mezanineReader.ReadExtensions();
            CredentialOther = CredentialSelf.GetCredentials (result.MezzanineExtensions);
            MutualKeyExchange (result.ClientKeyId);
            // Encrypted inside Mezzanine
            var innerReader = mezanineReader.Decrypt (MutualKeyIn);
            result.CiphertextExtensions = innerReader.ReadExtensions();
            result.SourceId = innerReader.ReadBinary();
            result.Payload = innerReader.ReadBinary();
            }
		}


    public partial class Listener {

        /// <summary>
        /// Parse the packet <paramref name="packet"/> as a ClientInitial packet.
        /// </summary>
        /// <param name="packet">The packet data</param>
        /// <param name="position">Start position at which reading of the packet should start.</param>
        /// <param name="count">Maximum number of bytes to be read from <paramref name="packet"/>.
        /// If less than 0, <paramref name="packet"/> is read to the end.</param>
        /// <returns>The parsed packet.</returns>

        public static PacketClientInitial ParseClientInitial (
                byte[] packet,
                int position=0,
                int count = -1) {
            var result = new PacketClientInitial () ;
            // The plaintext part
            var outerReader = new PacketReaderAesGcm(packet, position, count);
            result.PlaintextExtensions = outerReader.ReadExtensions();
            // Only have plaintext
            result.SourceId = outerReader.ReadBinary();
            result.Payload = outerReader.ReadBinary();

            return result;
            }

        /// <summary>
        /// Parse the packet <paramref name="packet"/> as a ClientExchange packet.
        /// </summary>
        /// <param name="packet">The packet data</param>
        /// <param name="position">Start position at which reading of the packet should start.</param>
        /// <param name="count">Maximum number of bytes to be read from <paramref name="packet"/>.
        /// If less than 0, <paramref name="packet"/> is read to the end.</param>
        /// <returns>The parsed packet.</returns>

        public static PacketClientExchange ParseClientExchange (
                byte[] packet,
                int position=0,
                int count = -1) {
            var result = new PacketClientExchange () ;
            // The plaintext part
            var outerReader = new PacketReaderAesGcm(packet, position, count);
            result.HostKeyId = outerReader.ReadString ();
            result.ClientEphemeral = outerReader.ReadBinary ();
            result.PlaintextExtensions = outerReader.ReadExtensions();
            // Parsing the inner packet is deferred until plaintext is parsed.
            result.Reader = outerReader;

            return result;
            }

        /// <summary>
        /// Parse the packet <paramref name="packet"/> as a ClientComplete packet.
        /// </summary>
        /// <param name="packet">The packet data</param>
        /// <param name="position">Start position at which reading of the packet should start.</param>
        /// <param name="count">Maximum number of bytes to be read from <paramref name="packet"/>.
        /// If less than 0, <paramref name="packet"/> is read to the end.</param>
        /// <returns>The parsed packet.</returns>

        public static PacketClientComplete ParseClientComplete (
                byte[] packet,
                int position=0,
                int count = -1) {
            var result = new PacketClientComplete () ;
            // The plaintext part
            var outerReader = new PacketReaderAesGcm(packet, position, count);
            result.PlaintextExtensions = outerReader.ReadExtensions();
            // Parsing the inner packet is deferred until plaintext is parsed.
            result.Reader = outerReader;

            return result;
            }

        /// <summary>
        /// Parse the packet <paramref name="packet"/> as a ClientCompleteDeferred packet.
        /// </summary>
        /// <param name="packet">The packet data</param>
        /// <param name="position">Start position at which reading of the packet should start.</param>
        /// <param name="count">Maximum number of bytes to be read from <paramref name="packet"/>.
        /// If less than 0, <paramref name="packet"/> is read to the end.</param>
        /// <returns>The parsed packet.</returns>

        public static PacketClientCompleteDeferred ParseClientCompleteDeferred (
                byte[] packet,
                int position=0,
                int count = -1) {
            var result = new PacketClientCompleteDeferred () ;
            // The plaintext part
            var outerReader = new PacketReaderAesGcm(packet, position, count);
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
    public partial class PacketClientInitial : Packet {





        }


    /// <summary>
    /// Parsed ClientExchange packet
    /// </summary>   
    public partial class PacketClientExchange : Packet {

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
    public partial class PacketClientComplete : Packet {

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
    public partial class PacketClientCompleteDeferred : Packet {

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
    public partial class PacketHostExchange : Packet {

        ///<summary>Options specified in the packet mezzanine.</summary> 
        public List<PacketExtension> MezzanineExtensions{ get; set; }

        ///<summary>Client Key Identifier.</summary> 
        public string HostKeyId { get; set; }



        }


    /// <summary>
    /// Parsed HostChallenge1 packet
    /// </summary>   
    public partial class PacketHostChallenge1 : Packet {





        }


    /// <summary>
    /// Parsed HostChallenge2 packet
    /// </summary>   
    public partial class PacketHostChallenge2 : Packet {





        }


    /// <summary>
    /// Parsed HostComplete packet
    /// </summary>   
    public partial class PacketHostComplete : Packet {

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


