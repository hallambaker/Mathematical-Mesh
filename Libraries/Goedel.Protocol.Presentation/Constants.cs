using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Goedel.Cryptography;
using Goedel.Utilities;

namespace Goedel.Protocol.Presentation {


    /// <summary>
    /// Identifiers used within encrypted data packets.
    /// </summary>
    public enum EncryptedPacketIdentifier {
        ///<summary>Packet contains a complete message.</summary> 
        Atomic = 0,

        ///<summary>Heartbeat packet, the outbound port and IP address to which the sender 
        ///directs it.</summary> 
        Heartbeat = 1,

        ///<summary>Packet contains a part of a message.</summary> 
        Serialized = 2,

        ///<summary>Packet contains a part of a message in a streamed connection.</summary> 
        Streamed = 3,

        ///<summary>Mezzanine packet containing an inner packet with the client credentials.</summary> 
        Mezzanine = 4,

        ///<summary>Packet contains a tunnelled message.</summary> 
        Tunnelled = 64
        }


    /// <summary>
    /// The packet types passed as plaintext.
    /// </summary>
    public enum PlaintextPacketType {


        ///<summary>Report an error to the sender.</summary> 
        Error = 0x80,

        ///<summary>Plaintext request to establish a new connection to the host. This is 
        ///only used in cases where the client does not have the public key of the host.</summary> 
        ClientInitial = 0x81,

        ///<summary>Encrypted request to establish a new connection to the host.
        ///This MAY be used in cases where the client has the public key of the host.</summary> 
        ClientExchange = 0x82,

        ///<summary>Client completion of key exchange.</summary> 
        ClientComplete = 0x83,

        ///<summary>Client completion of key exchange.</summary> 
        ClientCompleteDeferred = 0x84,

        ///<summary>Present a challenge to a client requesting a connection.</summary> 
        HostChallenge = 0x85,

        ///<summary>Present a challenge to a client requesting a connection.</summary> 
        HostExchange = 0x86,

        ///<summary>Host completion of key exchange.</summary> 
        HostComplete = 0x87,

        ///<summary>Establish a new binding for the specified connection identifier.</summary> 
        Rebind = 0x88

        }

    /// <summary>
    /// Error response codes.
    /// </summary>
    public enum ErrorCode {
        
        ///<summary>The request could not be bound to an inbound connection. This could be because
        ///the source address has changed.</summary> 
        UnknownConnection = 0,

        ///<summary>The request was refused for reasons reserved to the responder.</summary> 
        Refused = 1


        }


    /// <summary>
    /// Constants class
    /// </summary>
    public static class Constants {

        ///<summary>The minimum packet size.</summary> 
        public const int MinimumPacketSize = 1200;

        ///<summary>Size of packet nonce to be used in AES-GCM packet.</summary> 
        public const int SizeNonceAesGcm= 16;
        ///<summary>Size of initialization vector / AES nonce to be used in AES-GCM packet.</summary> 
        public const int SizeIvAesGcm = 12;
        ///<summary>Size of authentication tag to be used in AES-GCM packet.</summary> 
        public const int SizeTagAesGcm = 16;
        ///<summary>Size of key to be used in AES-GCM packet.</summary> 
        public const int SizeKeyAesGcm = 32;

        ///<summary>The KDF info tag to be used to derive initialization vectors.</summary> 
        public readonly static byte[] TagIv = "IV".ToUTF8();

        ///<summary>The KDF info tag to be used to derive keys.</summary> 
        public readonly static byte[] TagKey = "Key".ToUTF8();



        ///<summary>The KDF info tag to be used to derive keys.</summary> 
        public readonly static byte[] TagKeyClientHost = "ClientHost".ToUTF8();

        ///<summary>The KDF info tag to be used to derive keys.</summary> 
        public readonly static byte[] TagKeyHostClient = "HostClient".ToUTF8();



        ///<summary>Proof of work challenge</summary> 
        public const string ExtensionChallengeNonce = "NONCE";

        ///<summary>Proof of work challenge</summary> 
        public const string ExtensionChallengePOW = "POW";



        ///<summary>PKIX Certificate</summary> 
        public const string ExtensionPkixX509 = "PKIXC";

        ///<summary>PKIX OCSP Token</summary> 
        public const string ExtensionPkixOcsp = "PKIXO";

        ///<summary>Mesh Profile</summary> 
        public const string ExtensionMeshProfile = "MMMP";

        ///<summary>Mesh Connection</summary> 
        public const string ExtensionMeshConnection = "MMMC";


        /// <summary>
        /// Using the primary key <paramref name="ikm"/> and generated nonce <paramref name="nonce"/>,
        /// derive key <paramref name="key"/> and initialization vector <paramref name="iv"/>.
        /// </summary>
        /// <param name="ikm">The primary key.</param>
        /// <param name="nonce">The generated nonce.</param>
        /// <param name="iv">The generated initialization vector.</param>
        /// <param name="key">The generated key.</param>
        public static void Derive(byte[] ikm, out byte[] nonce, out byte[] iv, out byte[] key) {
            nonce = Platform.GetRandomBytes(SizeNonceAesGcm);
            nonce[0] |= 0b1000_0000;

            Derive2(ikm, nonce, out iv, out key);


            }

        /// <summary>
        /// Using the primary key <paramref name="ikm"/> and provided nonce <paramref name="nonce"/>,
        /// derive key <paramref name="key"/> and initialization vector <paramref name="iv"/>.
        /// </summary>
        /// <param name="ikm">The primary key.</param>
        /// <param name="nonce">The nonce.</param>
        /// <param name="iv">The generated initialization vector.</param>
        /// <param name="key">The generated key.</param>
        public static void Derive2(byte[] ikm, byte[] nonce, out byte[] iv, out byte[] key) {
            // Performance: refactor HKDF to avoid need to copy nonce?

            var keyDerive = new KeyDeriveHKDF(ikm, nonce);
            iv = keyDerive.Derive(TagIv, SizeIvAesGcm);
            key = keyDerive.Derive(TagKey, SizeKeyAesGcm);
            }



        ///<summary>Obsolete, remove</summary> 
        public static readonly byte[] ZeroArray = new byte[MinimumPacketSize];
        }
    }
