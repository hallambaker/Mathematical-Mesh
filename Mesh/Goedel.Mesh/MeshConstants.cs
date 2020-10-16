
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

using Goedel.Utilities;

namespace Goedel.Mesh {


    ///<summary>Inbound spool message state</summary>
    public enum StateSpoolInbound {
        ///<summary>Undefined type</summary>
        Unknown,
        ///<summary>Initial state (unread)</summary>
        Initial,
        ///<summary>Message was read</summary>
        Read        }

    ///<summary>Outbound spool message state</summary>
    public enum StateSpoolOutbound {
        ///<summary>Undefined type</summary>
        Unknown,
        ///<summary>Initial state (not sent)</summary>
        Initial,
        ///<summary>Message was sent</summary>
        Sent,
        ///<summary>Message was sent and receipt acknowledged</summary>
        Received,
        ///<summary>Message was refused</summary>
        Refused        }

    ///<summary>Local spool message state</summary>
    public enum StateSpoolLocal {
        ///<summary>Undefined type</summary>
        Unknown,
        ///<summary>Initial state (unread)</summary>
        Initial,
        ///<summary>Transaction associated with the message was completed</summary>
        Closed        }

    ///<summary>Types of cryptographic key that may be created</summary>
    public enum MeshKeyType {
        ///<summary>Undefined type</summary>
        Unknown,
        ///<summary>Complete Key</summary>
        Complete,
        ///<summary>Base Key Contribution</summary>
        Base,
        ///<summary>Activation Key Contribution</summary>
        Activation        }

    ///<summary>Actors for which a cryptographic key may be created</summary>
    public enum MeshActor {
        ///<summary>Undefined type</summary>
        Unknown,
        ///<summary>Account</summary>
        Account,
        ///<summary>Group Member</summary>
        Member,
        ///<summary>Device Profile</summary>
        Device,
        ///<summary>Service Profile</summary>
        Service,
        ///<summary>Host Profile</summary>
        Host        }

    ///<summary>Operations for which a cryptographic key may be created</summary>
    public enum MeshKeyOperation {
        ///<summary>Undefined type</summary>
        Unknown,
        ///<summary>Encryption key</summary>
        Encrypt,
        ///<summary>Signature key</summary>
        Sign,
        ///<summary>Authentication key</summary>
        Authenticate,
        ///<summary>Profile Signature key</summary>
        Profile,
        ///<summary>Administrator Signature key</summary>
        Administrator,
        ///<summary>Escrow Encryption key</summary>
        Escrow        }


    ///<summary>
    ///Constants specified in hallambaker-mesh-schema
    ///</summary>
    public static partial class MeshConstants {

        // File: CatalogLabels

        ///<summary>Access Catalog</summary>
        public const string MMM_Access = "MMM_Access";

        ///<summary>Application Catalog</summary>
        public const string MMM_Application = "MMM_Application";

        ///<summary>Bookmark Catalog</summary>
        public const string MMM_Bookmark = "MMM_Bookmark";

        ///<summary>Contact Catalog</summary>
        public const string MMM_Contact = "MMM_Contact";

        ///<summary>Credential Catalog</summary>
        public const string MMM_Credential = "MMM_Credential";

        ///<summary>Device Catalog</summary>
        public const string MMM_Device = "MMM_Device";

        ///<summary>Member Catalog</summary>
        public const string MMM_Member = "MMM_Member";

        ///<summary>Network Catalog</summary>
        public const string MMM_Network = "MMM_Network";

        ///<summary>Publication Catalog</summary>
        public const string MMM_Publication = "MMM_Publication";

        ///<summary>Task Catalog</summary>
        public const string MMM_Task = "MMM_Task";

        // File: SpoolLabels

        ///<summary>Local Spool</summary>
        public const string MMM_Local = "MMM_Local";

        ///<summary>Inbound Spool</summary>
        public const string MMM_Inbound = "MMM_Inbound";

        ///<summary>Outbound Spool</summary>
        public const string MMM_Outbound = "MMM_Outbound";

        // File: MessageStateInbound


        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static  StateSpoolInbound ToStateSpoolInbound (this string text) =>
            text switch {
                "Initial" => StateSpoolInbound.Initial,
                "Read" => StateSpoolInbound.Read,
                _ => StateSpoolInbound.Unknown
                };

        /// <summary>
        /// Convert the enumerated value <paramref name="data"/> to the corresponding string
        /// value.
        /// </summary>
        /// <param name="data">The enumerated value.</param>
        /// <returns>The text value.</returns>
        public static string ToLabel (this StateSpoolInbound data) =>
            data switch {
                StateSpoolInbound.Initial => "Initial",
                StateSpoolInbound.Read => "Read",
                _ => null
                };

        // File: MessageStateOutbound


        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static  StateSpoolOutbound ToStateSpoolOutbound (this string text) =>
            text switch {
                "Initial" => StateSpoolOutbound.Initial,
                "Sent" => StateSpoolOutbound.Sent,
                "Received" => StateSpoolOutbound.Received,
                "Refused" => StateSpoolOutbound.Refused,
                _ => StateSpoolOutbound.Unknown
                };

        /// <summary>
        /// Convert the enumerated value <paramref name="data"/> to the corresponding string
        /// value.
        /// </summary>
        /// <param name="data">The enumerated value.</param>
        /// <returns>The text value.</returns>
        public static string ToLabel (this StateSpoolOutbound data) =>
            data switch {
                StateSpoolOutbound.Initial => "Initial",
                StateSpoolOutbound.Sent => "Sent",
                StateSpoolOutbound.Received => "Received",
                StateSpoolOutbound.Refused => "Refused",
                _ => null
                };

        // File: MessageStateLocal


        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static  StateSpoolLocal ToStateSpoolLocal (this string text) =>
            text switch {
                "Initial" => StateSpoolLocal.Initial,
                "Closed" => StateSpoolLocal.Closed,
                _ => StateSpoolLocal.Unknown
                };

        /// <summary>
        /// Convert the enumerated value <paramref name="data"/> to the corresponding string
        /// value.
        /// </summary>
        /// <param name="data">The enumerated value.</param>
        /// <returns>The text value.</returns>
        public static string ToLabel (this StateSpoolLocal data) =>
            data switch {
                StateSpoolLocal.Initial => "Initial",
                StateSpoolLocal.Closed => "Closed",
                _ => null
                };

        // File: MiscUnsorted

        ///<summary>
        ///Action info for device PIN
        ///</summary>
        public const string MessagePINActionDevice = "Device";

        ///<summary>
        ///Action info for contact PIN
        ///</summary>
        public const string MessagePINActionContact = "Contact";

        ///<summary>
        ///The proposed IANA content identifier for the Mesh message type.
        ///</summary>
        public const string IanaTypeMeshMessage = "application/mmm/message";

        ///<summary>
        ///The proposed IANA content identifier for the Mesh message type.
        ///</summary>
        public const string IanaTypeMeshObject = "application/mmm/object";

        ///<summary>
        ///The proposed IANA content identifier for the Mesh message type.
        ///</summary>
        public const string IanaTypeMeshNonce = "application/mmm/nonce";

        ///<summary>
        ///The proposed IANA content identifier for the Mesh message type.
        ///</summary>
        public const string IanaTypeMeshEnvelopeId = "application/mmm/envelopeid";

        ///<summary>
        ///The proposed IANA content identifier for the Mesh message type.
        ///</summary>
        public const string IanaTypeMeshResponseId = "application/mmm/response";

        ///<summary>
        ///The proposed IANA content identifier for the Mesh message type.
        ///</summary>
        public const string IanaTypeMeshAuthenticator = "application/mmm/authenticator";

        ///<summary>
        ///The proposed IANA URI scheme.
        ///</summary>
        public const string MeshConnectURI = "mcu";

        ///<summary>
        ///HKDF info tag for deriving Service Authenticator from IKM
        ///</summary>
        public const string ServiceAuthenticatorInfo = "mmm/key/authenticate/service";

        ///<summary>
        ///HKDF info tag for deriving Device Authenticator from IKM
        ///</summary>
        public const string DeviceAuthenticatorInfo = "mmm/key/authenticate/device";

        ///<summary>
        ///Prefix to be applied to form the ID of a mesh group in the catalog.
        ///</summary>
        public const string PrefixCatalogedGroup = "mmm/CatalogedGroup/";

        /// <summary>
        /// Derivation of the key name from the context in which it is to be used.
        /// </summary>
        /// <param name="intype">The type of key to create.</param>
        /// <param name="inactor">The actor to create the key for.</param>
        /// <param name="inoperation">The operation for which the key is to be used.</param>
        /// <returns></returns>
        public static string KeyDerivationKeyName (
                    MeshKeyType intype,
                    MeshActor inactor,
                    MeshKeyOperation inoperation) {
            var type = intype.ToLabel(); 
            var actor = inactor.ToLabel(); 
            var operation = inoperation.ToLabel(); 

            var KeyName = type + "_" + actor + "_" + operation ;

            return KeyName;
            }



        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static  MeshKeyType ToMeshKeyType (this string text) =>
            text switch {
                "Complete" => MeshKeyType.Complete,
                "Base" => MeshKeyType.Base,
                "Activation" => MeshKeyType.Activation,
                _ => MeshKeyType.Unknown
                };

        /// <summary>
        /// Convert the enumerated value <paramref name="data"/> to the corresponding string
        /// value.
        /// </summary>
        /// <param name="data">The enumerated value.</param>
        /// <returns>The text value.</returns>
        public static string ToLabel (this MeshKeyType data) =>
            data switch {
                MeshKeyType.Complete => "Complete",
                MeshKeyType.Base => "Base",
                MeshKeyType.Activation => "Activation",
                _ => null
                };


        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static  MeshActor ToMeshActor (this string text) =>
            text switch {
                "Account" => MeshActor.Account,
                "Member" => MeshActor.Member,
                "Device" => MeshActor.Device,
                "Service" => MeshActor.Service,
                "Host" => MeshActor.Host,
                _ => MeshActor.Unknown
                };

        /// <summary>
        /// Convert the enumerated value <paramref name="data"/> to the corresponding string
        /// value.
        /// </summary>
        /// <param name="data">The enumerated value.</param>
        /// <returns>The text value.</returns>
        public static string ToLabel (this MeshActor data) =>
            data switch {
                MeshActor.Account => "Account",
                MeshActor.Member => "Member",
                MeshActor.Device => "Device",
                MeshActor.Service => "Service",
                MeshActor.Host => "Host",
                _ => null
                };


        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static  MeshKeyOperation ToMeshKeyOperation (this string text) =>
            text switch {
                "Encrypt" => MeshKeyOperation.Encrypt,
                "Sign" => MeshKeyOperation.Sign,
                "Authenticate" => MeshKeyOperation.Authenticate,
                "Profile" => MeshKeyOperation.Profile,
                "Administrator" => MeshKeyOperation.Administrator,
                "Escrow" => MeshKeyOperation.Escrow,
                _ => MeshKeyOperation.Unknown
                };

        /// <summary>
        /// Convert the enumerated value <paramref name="data"/> to the corresponding string
        /// value.
        /// </summary>
        /// <param name="data">The enumerated value.</param>
        /// <returns>The text value.</returns>
        public static string ToLabel (this MeshKeyOperation data) =>
            data switch {
                MeshKeyOperation.Encrypt => "Encrypt",
                MeshKeyOperation.Sign => "Sign",
                MeshKeyOperation.Authenticate => "Authenticate",
                MeshKeyOperation.Profile => "Profile",
                MeshKeyOperation.Administrator => "Administrator",
                MeshKeyOperation.Escrow => "Escrow",
                _ => null
                };

        ///<summary>
        ///Transaction result tag Accept
        ///</summary>
        public const string TransactionResultAccept = "Accept";

        ///<summary>
        ///Transaction result tag Reject
        ///</summary>
        public const string TransactionResultReject = "Reject";

        ///<summary>
        ///Transaction result tag Pending
        ///</summary>
        public const string TransactionResultPending = "Pending";

        ///<summary>
        ///Transaction result tag Expired
        ///</summary>
        public const string TransactionResultExpired = "Expired";

        }
    }
