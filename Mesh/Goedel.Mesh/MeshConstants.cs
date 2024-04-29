
//  This file was automatically generated at 4/29/2024 4:32:31 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  constant version 3.0.0.945
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.22631.0
//  
//  
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

using Goedel.Utilities;

namespace Goedel.Mesh ;


///<summary>Store labels</summary>
public enum StoreType {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>Any Store</summary>
    Any,
    ///<summary>Local Spool</summary>
    Local,
    ///<summary>Inbound Spool</summary>
    Inbound,
    ///<summary>Outbound Spool</summary>
    Outbound,
    ///<summary>Archive Spool</summary>
    Archive,
    ///<summary>Notary Catalog</summary>
    Notary,
    ///<summary>Access Catalog</summary>
    Access,
    ///<summary>Application Catalog</summary>
    Application,
    ///<summary>Bookmark Catalog</summary>
    Bookmark,
    ///<summary>Callsign Catalog</summary>
    Callsign,
    ///<summary>Carnet Catalog</summary>
    Carnet,
    ///<summary>Contact Catalog</summary>
    Contact,
    ///<summary>Credential Catalog</summary>
    Credential,
    ///<summary>Device Catalog</summary>
    Device,
    ///<summary>Member Catalog</summary>
    Member,
    ///<summary>Network Catalog</summary>
    Network,
    ///<summary>Publication Catalog</summary>
    Publication,
    ///<summary>Task Catalog</summary>
    Task,
    ///<summary>Account Catalog</summary>
    Account,
    ///<summary>Document Catalog</summary>
    Document    }

///<summary>Inbound spool message state</summary>
public enum StateSpoolMessage {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>Initial state (unread)</summary>
    Initial,
    ///<summary>Message was read</summary>
    Read,
    ///<summary>Message was sent and receipt acknowledged</summary>
    Received,
    ///<summary>Message was refused</summary>
    Refused,
    ///<summary>Message was sent</summary>
    Sent,
    ///<summary>Transaction associated with the message was completed</summary>
    Closed,
    ///<summary>Transaction associated with the message was completed</summary>
    Deleted    }

///<summary>Inbound spool message state</summary>
public enum StateSpoolInbound {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>Initial state (unread)</summary>
    Initial,
    ///<summary>Message was read</summary>
    Read    }

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
    Refused    }

///<summary>Local spool message state</summary>
public enum StateSpoolLocal {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>Initial state (unread)</summary>
    Initial,
    ///<summary>Transaction associated with the message was completed</summary>
    Closed    }

///<summary>Types of cryptographic key that may be created</summary>
public enum MeshKeyType {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>Complete Key</summary>
    Complete,
    ///<summary>Base Key Contribution</summary>
    Base,
    ///<summary>Activation Key Contribution</summary>
    Activation    }

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
    Host    }

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
    Escrow    }

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
    Timeout = 9    }


///<summary>
///Constants specified in hallambaker-mesh-schema
///</summary>
public static partial class MeshConstants {

    // File: CatalogLabels


    ///<summary>Jose enumeration tag for StoreType.Any</summary>
    public const string  StoreTypeAnyTag = "Any";
    ///<summary>Jose enumeration tag for StoreType.Local</summary>
    public const string  StoreTypeLocalTag = "Local";
    ///<summary>Jose enumeration tag for StoreType.Inbound</summary>
    public const string  StoreTypeInboundTag = "Inbound";
    ///<summary>Jose enumeration tag for StoreType.Outbound</summary>
    public const string  StoreTypeOutboundTag = "Outbound";
    ///<summary>Jose enumeration tag for StoreType.Archive</summary>
    public const string  StoreTypeArchiveTag = "Archive";
    ///<summary>Jose enumeration tag for StoreType.Notary</summary>
    public const string  StoreTypeNotaryTag = "Notary";
    ///<summary>Jose enumeration tag for StoreType.Access</summary>
    public const string  StoreTypeAccessTag = "Access";
    ///<summary>Jose enumeration tag for StoreType.Application</summary>
    public const string  StoreTypeApplicationTag = "Application";
    ///<summary>Jose enumeration tag for StoreType.Bookmark</summary>
    public const string  StoreTypeBookmarkTag = "Bookmark";
    ///<summary>Jose enumeration tag for StoreType.Callsign</summary>
    public const string  StoreTypeCallsignTag = "Callsign";
    ///<summary>Jose enumeration tag for StoreType.Carnet</summary>
    public const string  StoreTypeCarnetTag = "Carnet";
    ///<summary>Jose enumeration tag for StoreType.Contact</summary>
    public const string  StoreTypeContactTag = "Contact";
    ///<summary>Jose enumeration tag for StoreType.Credential</summary>
    public const string  StoreTypeCredentialTag = "Credential";
    ///<summary>Jose enumeration tag for StoreType.Device</summary>
    public const string  StoreTypeDeviceTag = "Device";
    ///<summary>Jose enumeration tag for StoreType.Member</summary>
    public const string  StoreTypeMemberTag = "Member";
    ///<summary>Jose enumeration tag for StoreType.Network</summary>
    public const string  StoreTypeNetworkTag = "Network";
    ///<summary>Jose enumeration tag for StoreType.Publication</summary>
    public const string  StoreTypePublicationTag = "Publication";
    ///<summary>Jose enumeration tag for StoreType.Task</summary>
    public const string  StoreTypeTaskTag = "Task";
    ///<summary>Jose enumeration tag for StoreType.Account</summary>
    public const string  StoreTypeAccountTag = "Account";
    ///<summary>Jose enumeration tag for StoreType.Document</summary>
    public const string  StoreTypeDocumentTag = "Document";

    /// <summary>
    /// Convert the string <paramref name="text"/> to the corresponding enumeration
    /// value.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The enumeration value.</returns>
    public static StoreType ToStoreType (this string text) =>
        text switch {
            StoreTypeAnyTag => StoreType.Any,
            StoreTypeLocalTag => StoreType.Local,
            StoreTypeInboundTag => StoreType.Inbound,
            StoreTypeOutboundTag => StoreType.Outbound,
            StoreTypeArchiveTag => StoreType.Archive,
            StoreTypeNotaryTag => StoreType.Notary,
            StoreTypeAccessTag => StoreType.Access,
            StoreTypeApplicationTag => StoreType.Application,
            StoreTypeBookmarkTag => StoreType.Bookmark,
            StoreTypeCallsignTag => StoreType.Callsign,
            StoreTypeCarnetTag => StoreType.Carnet,
            StoreTypeContactTag => StoreType.Contact,
            StoreTypeCredentialTag => StoreType.Credential,
            StoreTypeDeviceTag => StoreType.Device,
            StoreTypeMemberTag => StoreType.Member,
            StoreTypeNetworkTag => StoreType.Network,
            StoreTypePublicationTag => StoreType.Publication,
            StoreTypeTaskTag => StoreType.Task,
            StoreTypeAccountTag => StoreType.Account,
            StoreTypeDocumentTag => StoreType.Document,
            _ => StoreType.Unknown
            };

    /// <summary>
    /// Convert the enumerated value <paramref name="data"/> to the corresponding string
    /// value.
    /// </summary>
    /// <param name="data">The enumerated value.</param>
    /// <returns>The text value.</returns>
    public static string ToLabel (this StoreType data) =>
        data switch {
            StoreType.Any => StoreTypeAnyTag,
            StoreType.Local => StoreTypeLocalTag,
            StoreType.Inbound => StoreTypeInboundTag,
            StoreType.Outbound => StoreTypeOutboundTag,
            StoreType.Archive => StoreTypeArchiveTag,
            StoreType.Notary => StoreTypeNotaryTag,
            StoreType.Access => StoreTypeAccessTag,
            StoreType.Application => StoreTypeApplicationTag,
            StoreType.Bookmark => StoreTypeBookmarkTag,
            StoreType.Callsign => StoreTypeCallsignTag,
            StoreType.Carnet => StoreTypeCarnetTag,
            StoreType.Contact => StoreTypeContactTag,
            StoreType.Credential => StoreTypeCredentialTag,
            StoreType.Device => StoreTypeDeviceTag,
            StoreType.Member => StoreTypeMemberTag,
            StoreType.Network => StoreTypeNetworkTag,
            StoreType.Publication => StoreTypePublicationTag,
            StoreType.Task => StoreTypeTaskTag,
            StoreType.Account => StoreTypeAccountTag,
            StoreType.Document => StoreTypeDocumentTag,
            _ => null
            };

    // File: SpoolLabels

    // File: MessageState


    ///<summary>Jose enumeration tag for StateSpoolMessage.Initial</summary>
    public const string  StateSpoolMessageInitialTag = "Initial";
    ///<summary>Jose enumeration tag for StateSpoolMessage.Read</summary>
    public const string  StateSpoolMessageReadTag = "Read";
    ///<summary>Jose enumeration tag for StateSpoolMessage.Received</summary>
    public const string  StateSpoolMessageReceivedTag = "Received";
    ///<summary>Jose enumeration tag for StateSpoolMessage.Refused</summary>
    public const string  StateSpoolMessageRefusedTag = "Refused";
    ///<summary>Jose enumeration tag for StateSpoolMessage.Sent</summary>
    public const string  StateSpoolMessageSentTag = "Sent";
    ///<summary>Jose enumeration tag for StateSpoolMessage.Closed</summary>
    public const string  StateSpoolMessageClosedTag = "Closed";
    ///<summary>Jose enumeration tag for StateSpoolMessage.Deleted</summary>
    public const string  StateSpoolMessageDeletedTag = "Deleted";

    /// <summary>
    /// Convert the string <paramref name="text"/> to the corresponding enumeration
    /// value.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The enumeration value.</returns>
    public static StateSpoolMessage ToStateSpoolMessage (this string text) =>
        text switch {
            StateSpoolMessageInitialTag => StateSpoolMessage.Initial,
            StateSpoolMessageReadTag => StateSpoolMessage.Read,
            StateSpoolMessageReceivedTag => StateSpoolMessage.Received,
            StateSpoolMessageRefusedTag => StateSpoolMessage.Refused,
            StateSpoolMessageSentTag => StateSpoolMessage.Sent,
            StateSpoolMessageClosedTag => StateSpoolMessage.Closed,
            StateSpoolMessageDeletedTag => StateSpoolMessage.Deleted,
            _ => StateSpoolMessage.Unknown
            };

    /// <summary>
    /// Convert the enumerated value <paramref name="data"/> to the corresponding string
    /// value.
    /// </summary>
    /// <param name="data">The enumerated value.</param>
    /// <returns>The text value.</returns>
    public static string ToLabel (this StateSpoolMessage data) =>
        data switch {
            StateSpoolMessage.Initial => StateSpoolMessageInitialTag,
            StateSpoolMessage.Read => StateSpoolMessageReadTag,
            StateSpoolMessage.Received => StateSpoolMessageReceivedTag,
            StateSpoolMessage.Refused => StateSpoolMessageRefusedTag,
            StateSpoolMessage.Sent => StateSpoolMessageSentTag,
            StateSpoolMessage.Closed => StateSpoolMessageClosedTag,
            StateSpoolMessage.Deleted => StateSpoolMessageDeletedTag,
            _ => null
            };

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
    ///The proposed IANA URI scheme for offering a device connection.
    ///</summary>
    public const string MeshConnectURIDevice = "mcd";

    ///<summary>
    ///The proposed IANA URI scheme for offering to exchange contacts.
    ///</summary>
    public const string MeshConnectURIUser = "mcu";

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

    ///<summary>
    ///To be requested IANA service name for Mesh presence service
    ///</summary>
    public const string MeshPresenceService = "mmm_presence";

    ///<summary>
    ///</summary>
    public const string DirectoryKeys = "Keys";

    ///<summary>
    ///</summary>
    public const string DirectoryProfiles = "Profiles";

    ///<summary>
    ///</summary>
    public const string DirectoryAccounts = "Accounts";

    ///<summary>
    ///</summary>
    public const string DirectoryResolver = "Resolver";

    ///<summary>
    ///</summary>
    public const string DirectoryPresentation = "Presentation";

    ///<summary>
    ///</summary>
    public const string DirectoryCarnet = "Carnet";

    }

