
//  This file was automatically generated at 7/14/2021 4:41:19 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  constant version 3.0.0.735
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2019
//  
//  Build Platform: Win32NT 10.0.18362.0
//  
//  
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

using Goedel.Utilities;

namespace Goedel.Mesh {


    ///<summary>Inbound spool message state</summary>
    public enum StateSpoolInbound {
        ///<summary>Undefined type</summary>
        Unknown = -1,
        ///<summary>Initial state (unread)</summary>
        Initial,
        ///<summary>Message was read</summary>
        Read        }

    ///<summary>Outbound spool message state</summary>
    public enum StateSpoolOutbound {
        ///<summary>Undefined type</summary>
        Unknown = -1,
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
        Unknown = -1,
        ///<summary>Initial state (unread)</summary>
        Initial,
        ///<summary>Transaction associated with the message was completed</summary>
        Closed        }

    ///<summary>Types of cryptographic key that may be created</summary>
    public enum MeshKeyType {
        ///<summary>Undefined type</summary>
        Unknown = -1,
        ///<summary>Complete Key</summary>
        Complete,
        ///<summary>Base Key Contribution</summary>
        Base,
        ///<summary>Activation Key Contribution</summary>
        Activation        }

    ///<summary>Actors for which a cryptographic key may be created</summary>
    public enum MeshActor {
        ///<summary>Undefined type</summary>
        Unknown = -1,
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
        Unknown = -1,
        ///<summary>Encryption key</summary>
        Encrypt,
        ///<summary>Signature key</summary>
        Sign,
        ///<summary>Authentication key</summary>
        Authenticate,
        ///<summary>Profile Signature key</summary>
        Profile,
        ///<summary>Administrator Encryption key</summary>
        AdminEncrypt,
        ///<summary>Administrator Signature key</summary>
        AdminSign,
        ///<summary>Escrow Encryption key</summary>
        Escrow        }

    ///<summary>Server status codes</summary>
    public enum MeshServerStatus {
        ///<summary>Undefined type</summary>
        Unknown = -1,
        ///<summary>Mesh account already registered</summary>
        AccountRegistered = 1,
        ///<summary>Operation is not authorized</summary>
        NotAuthorized = 2,
        ///<summary>Operation requires administrator privilege</summary>
        NotAdministrator = 3,
        ///<summary>Device connection was revoked</summary>
        DeviceRevoked = 4,
        ///<summary>Operation is refused</summary>
        Refused = 5,
        ///<summary>Specified account was not found</summary>
        NotFound = 6,
        ///<summary>Specified account has moved</summary>
        Moved = 7,
        ///<summary>Request is too large</summary>
        TooLarge = 8,
        ///<summary>Request timed out</summary>
        Timeout = 9        }


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

        ///<summary>Archive Spool</summary>
        public const string MMM_Archive = "MMM_Archive";

        // File: MessageStateInbound


        ///<summary>Jose enumeration tag for StateSpoolInbound.Initial</summary>
        public const string  StateSpoolInboundInitialTag = "Initial";
        ///<summary>Jose enumeration tag for StateSpoolInbound.Read</summary>
        public const string  StateSpoolInboundReadTag = "Read";

        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static StateSpoolInbound ToStateSpoolInbound (this string text) =>
            text switch {
                StateSpoolInboundInitialTag => StateSpoolInbound.Initial,
                StateSpoolInboundReadTag => StateSpoolInbound.Read,
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
                StateSpoolInbound.Initial => StateSpoolInboundInitialTag,
                StateSpoolInbound.Read => StateSpoolInboundReadTag,
                _ => null
                };

        // File: MessageStateOutbound


        ///<summary>Jose enumeration tag for StateSpoolOutbound.Initial</summary>
        public const string  StateSpoolOutboundInitialTag = "Initial";
        ///<summary>Jose enumeration tag for StateSpoolOutbound.Sent</summary>
        public const string  StateSpoolOutboundSentTag = "Sent";
        ///<summary>Jose enumeration tag for StateSpoolOutbound.Received</summary>
        public const string  StateSpoolOutboundReceivedTag = "Received";
        ///<summary>Jose enumeration tag for StateSpoolOutbound.Refused</summary>
        public const string  StateSpoolOutboundRefusedTag = "Refused";

        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static StateSpoolOutbound ToStateSpoolOutbound (this string text) =>
            text switch {
                StateSpoolOutboundInitialTag => StateSpoolOutbound.Initial,
                StateSpoolOutboundSentTag => StateSpoolOutbound.Sent,
                StateSpoolOutboundReceivedTag => StateSpoolOutbound.Received,
                StateSpoolOutboundRefusedTag => StateSpoolOutbound.Refused,
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
                StateSpoolOutbound.Initial => StateSpoolOutboundInitialTag,
                StateSpoolOutbound.Sent => StateSpoolOutboundSentTag,
                StateSpoolOutbound.Received => StateSpoolOutboundReceivedTag,
                StateSpoolOutbound.Refused => StateSpoolOutboundRefusedTag,
                _ => null
                };

        // File: MessageStateLocal


        ///<summary>Jose enumeration tag for StateSpoolLocal.Initial</summary>
        public const string  StateSpoolLocalInitialTag = "Initial";
        ///<summary>Jose enumeration tag for StateSpoolLocal.Closed</summary>
        public const string  StateSpoolLocalClosedTag = "Closed";

        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static StateSpoolLocal ToStateSpoolLocal (this string text) =>
            text switch {
                StateSpoolLocalInitialTag => StateSpoolLocal.Initial,
                StateSpoolLocalClosedTag => StateSpoolLocal.Closed,
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
                StateSpoolLocal.Initial => StateSpoolLocalInitialTag,
                StateSpoolLocal.Closed => StateSpoolLocalClosedTag,
                _ => null
                };

        // File: IdentifierDerrivation

        ///<summary>
        ///The proposed IANA content identifier for the Mesh message type.
        ///</summary>
        public const string IanaTypeMeshEnvelopeId = "application/mmm/envelopeid";

        ///<summary>
        ///The proposed IANA content identifier for the Mesh message type.
        ///</summary>
        public const string IanaTypeMeshResponseId = "application/mmm/responseid";

        // File: PinActionCodes

        ///<summary>
        ///Action info for device PIN
        ///</summary>
        public const string MessagePINActionDevice = "Device";

        ///<summary>
        ///Action info for contact PIN
        ///</summary>
        public const string MessagePINActionContact = "Contact";

        // File: MiscUnsorted

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
        public const string IanaTypeMeshCapabilityId = "application/mmm/capability/";

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



        ///<summary>Jose enumeration tag for MeshKeyType.Complete</summary>
        public const string  MeshKeyTypeCompleteTag = "Complete";
        ///<summary>Jose enumeration tag for MeshKeyType.Base</summary>
        public const string  MeshKeyTypeBaseTag = "Base";
        ///<summary>Jose enumeration tag for MeshKeyType.Activation</summary>
        public const string  MeshKeyTypeActivationTag = "Activation";

        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static MeshKeyType ToMeshKeyType (this string text) =>
            text switch {
                MeshKeyTypeCompleteTag => MeshKeyType.Complete,
                MeshKeyTypeBaseTag => MeshKeyType.Base,
                MeshKeyTypeActivationTag => MeshKeyType.Activation,
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
                MeshKeyType.Complete => MeshKeyTypeCompleteTag,
                MeshKeyType.Base => MeshKeyTypeBaseTag,
                MeshKeyType.Activation => MeshKeyTypeActivationTag,
                _ => null
                };


        ///<summary>Jose enumeration tag for MeshActor.Account</summary>
        public const string  MeshActorAccountTag = "Account";
        ///<summary>Jose enumeration tag for MeshActor.Member</summary>
        public const string  MeshActorMemberTag = "Member";
        ///<summary>Jose enumeration tag for MeshActor.Device</summary>
        public const string  MeshActorDeviceTag = "Device";
        ///<summary>Jose enumeration tag for MeshActor.Service</summary>
        public const string  MeshActorServiceTag = "Service";
        ///<summary>Jose enumeration tag for MeshActor.Host</summary>
        public const string  MeshActorHostTag = "Host";

        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static MeshActor ToMeshActor (this string text) =>
            text switch {
                MeshActorAccountTag => MeshActor.Account,
                MeshActorMemberTag => MeshActor.Member,
                MeshActorDeviceTag => MeshActor.Device,
                MeshActorServiceTag => MeshActor.Service,
                MeshActorHostTag => MeshActor.Host,
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
                MeshActor.Account => MeshActorAccountTag,
                MeshActor.Member => MeshActorMemberTag,
                MeshActor.Device => MeshActorDeviceTag,
                MeshActor.Service => MeshActorServiceTag,
                MeshActor.Host => MeshActorHostTag,
                _ => null
                };


        ///<summary>Jose enumeration tag for MeshKeyOperation.Encrypt</summary>
        public const string  MeshKeyOperationEncryptTag = "Encrypt";
        ///<summary>Jose enumeration tag for MeshKeyOperation.Sign</summary>
        public const string  MeshKeyOperationSignTag = "Sign";
        ///<summary>Jose enumeration tag for MeshKeyOperation.Authenticate</summary>
        public const string  MeshKeyOperationAuthenticateTag = "Authenticate";
        ///<summary>Jose enumeration tag for MeshKeyOperation.Profile</summary>
        public const string  MeshKeyOperationProfileTag = "Profile";
        ///<summary>Jose enumeration tag for MeshKeyOperation.AdminEncrypt</summary>
        public const string  MeshKeyOperationAdminEncryptTag = "AdminEncrypt";
        ///<summary>Jose enumeration tag for MeshKeyOperation.AdminSign</summary>
        public const string  MeshKeyOperationAdminSignTag = "AdminSign";
        ///<summary>Jose enumeration tag for MeshKeyOperation.Escrow</summary>
        public const string  MeshKeyOperationEscrowTag = "Escrow";

        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static MeshKeyOperation ToMeshKeyOperation (this string text) =>
            text switch {
                MeshKeyOperationEncryptTag => MeshKeyOperation.Encrypt,
                MeshKeyOperationSignTag => MeshKeyOperation.Sign,
                MeshKeyOperationAuthenticateTag => MeshKeyOperation.Authenticate,
                MeshKeyOperationProfileTag => MeshKeyOperation.Profile,
                MeshKeyOperationAdminEncryptTag => MeshKeyOperation.AdminEncrypt,
                MeshKeyOperationAdminSignTag => MeshKeyOperation.AdminSign,
                MeshKeyOperationEscrowTag => MeshKeyOperation.Escrow,
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
                MeshKeyOperation.Encrypt => MeshKeyOperationEncryptTag,
                MeshKeyOperation.Sign => MeshKeyOperationSignTag,
                MeshKeyOperation.Authenticate => MeshKeyOperationAuthenticateTag,
                MeshKeyOperation.Profile => MeshKeyOperationProfileTag,
                MeshKeyOperation.AdminEncrypt => MeshKeyOperationAdminEncryptTag,
                MeshKeyOperation.AdminSign => MeshKeyOperationAdminSignTag,
                MeshKeyOperation.Escrow => MeshKeyOperationEscrowTag,
                _ => null
                };


        ///<summary>Jose enumeration tag for MeshServerStatus.AccountRegistered</summary>
        public const string  MeshServerStatusAccountRegisteredTag = "AccountRegistered";
        ///<summary>Description for MeshServerStatus.AccountRegistered</summary>
        public const string  MeshServerStatusAccountRegisteredTitle = "Mesh account already registered";
        ///<summary>Jose enumeration tag for MeshServerStatus.NotAuthorized</summary>
        public const string  MeshServerStatusNotAuthorizedTag = "NotAuthorized";
        ///<summary>Description for MeshServerStatus.NotAuthorized</summary>
        public const string  MeshServerStatusNotAuthorizedTitle = "Operation is not authorized";
        ///<summary>Jose enumeration tag for MeshServerStatus.NotAdministrator</summary>
        public const string  MeshServerStatusNotAdministratorTag = "NotAdministrator";
        ///<summary>Description for MeshServerStatus.NotAdministrator</summary>
        public const string  MeshServerStatusNotAdministratorTitle = "Operation requires administrator privilege";
        ///<summary>Jose enumeration tag for MeshServerStatus.DeviceRevoked</summary>
        public const string  MeshServerStatusDeviceRevokedTag = "DeviceRevoked";
        ///<summary>Description for MeshServerStatus.DeviceRevoked</summary>
        public const string  MeshServerStatusDeviceRevokedTitle = "Device connection was revoked";
        ///<summary>Jose enumeration tag for MeshServerStatus.Refused</summary>
        public const string  MeshServerStatusRefusedTag = "Refused";
        ///<summary>Description for MeshServerStatus.Refused</summary>
        public const string  MeshServerStatusRefusedTitle = "Operation is refused";
        ///<summary>Jose enumeration tag for MeshServerStatus.NotFound</summary>
        public const string  MeshServerStatusNotFoundTag = "NotFound";
        ///<summary>Description for MeshServerStatus.NotFound</summary>
        public const string  MeshServerStatusNotFoundTitle = "Specified account was not found";
        ///<summary>Jose enumeration tag for MeshServerStatus.Moved</summary>
        public const string  MeshServerStatusMovedTag = "Moved";
        ///<summary>Description for MeshServerStatus.Moved</summary>
        public const string  MeshServerStatusMovedTitle = "Specified account has moved";
        ///<summary>Jose enumeration tag for MeshServerStatus.TooLarge</summary>
        public const string  MeshServerStatusTooLargeTag = "TooLarge";
        ///<summary>Description for MeshServerStatus.TooLarge</summary>
        public const string  MeshServerStatusTooLargeTitle = "Request is too large";
        ///<summary>Jose enumeration tag for MeshServerStatus.Timeout</summary>
        public const string  MeshServerStatusTimeoutTag = "Timeout";
        ///<summary>Description for MeshServerStatus.Timeout</summary>
        public const string  MeshServerStatusTimeoutTitle = "Request timed out";

        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static MeshServerStatus ToMeshServerStatus (this string text) =>
            text switch {
                _ => MeshServerStatus.Unknown
                };

        /// <summary>
        /// Convert the enumerated value <paramref name="data"/> to the corresponding string
        /// value.
        /// </summary>
        /// <param name="data">The enumerated value.</param>
        /// <returns>The text value.</returns>
        public static string ToLabel (this MeshServerStatus data) =>
            data switch {
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
