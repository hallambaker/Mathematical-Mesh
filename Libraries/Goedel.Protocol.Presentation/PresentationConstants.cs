
//  This file was automatically generated at 5/13/2021 2:13:21 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  constant version 3.0.0.698
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

namespace Goedel.Protocol.Presentation {


    ///<summary>Inbound spool message state</summary>
    public enum InitiatorMessageType {
        ///<summary>Undefined type</summary>
        Unknown = -1,
        ///<summary>Host exchange message</summary>
        Error = 0,
        ///<summary>Data message</summary>
        Data = 1,
        ///<summary>Initial contact message without key exchange</summary>
        InitiatorHello = 2,
        ///<summary>Initial contact message with key exchange</summary>
        InitiatorExchange = 3,
        ///<summary>Initial contact message with key exchange</summary>
        InitiatorComplete = 4        }

    ///<summary>Host response messages</summary>
    public enum ResponderMessageType {
        ///<summary>Undefined type</summary>
        Unknown = -1,
        ///<summary>Host exchange message</summary>
        Error = 0,
        ///<summary>Host exchange message</summary>
        Data = 1,
        ///<summary>Host exchange message</summary>
        ResponderChallenge = 2,
        ///<summary>Host challenge type 1</summary>
        ResponderComplete = 3        }

    ///<summary>Response error codes</summary>
    public enum ErrorCodes {
        ///<summary>Undefined type</summary>
        Unknown = -1,
        ///<summary>Bad request</summary>
        BadRequest = 400,
        ///<summary>Unauthorized</summary>
        Unauthorized = 401,
        ///<summary>Forbidden</summary>
        Forbidden = 403,
        ///<summary>Message timeout</summary>
        Timeout = 408,
        ///<summary>Too many requests</summary>
        TooManyRequests = 429,
        ///<summary>The service is unavailable</summary>
        ServiceUnavailable = 503        }

    ///<summary>Stream and packet encryption options</summary>
    public enum EncryptionOptions {
        ///<summary>Undefined type</summary>
        Unknown = -1,
        ///<summary>AESGCM</summary>
        AesGcm,
        ///<summary>AESCFB</summary>
        AesCfb,
        ///<summary>AESheader</summary>
        EncryptPacketHeader,
        ///<summary>OTSIDr</summary>
        RequireOneTimeId        }

    ///<summary>Presentation extension tags</summary>
    public enum ExtensionTags {
        ///<summary>Undefined type</summary>
        Unknown = -1,
        ///<summary>X448</summary>
        X448,
        ///<summary>PKIXC</summary>
        PkixX509,
        ///<summary>PKIXO</summary>
        PkixOcsp,
        ///<summary>MMMP</summary>
        MeshProfile,
        ///<summary>MMMC</summary>
        MeshConnection,
        ///<summary>Claim</summary>
        ClaimId,
        ///<summary>SID</summary>
        StreamId,
        ///<summary>OTSID</summary>
        OneTimeStreamId,
        ///<summary>Roll</summary>
        Roll,
        ///<summary>Challenge</summary>
        Challenge,
        ///<summary>ProofOfWork</summary>
        ChallengeProofOfWork,
        ///<summary>Refuse</summary>
        Refuse,
        ///<summary>Unknown</summary>
        NotKnown,
        ///<summary>Authorize</summary>
        Authorize,
        ///<summary>Encrypt</summary>
        Encrypt,
        ///<summary>Close</summary>
        CloseStream,
        ///<summary>CloseConnection</summary>
        CloseConnection,
        ///<summary>Client</summary>
        StreamClient,
        ///<summary>Receiver</summary>
        StreamReceiver,
        ///<summary>New</summary>
        StreamNew,
        ///<summary>Sender</summary>
        StreamSender,
        ///<summary>Service</summary>
        StreamService        }


    ///<summary>
    ///Constants specified in hallambaker-mesh-schema
    ///</summary>
    public static partial class Constants {

        // File: PresentationConstants



        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static InitiatorMessageType ToInitiatorMessageType (this string text) =>
            text switch {
                _ => InitiatorMessageType.Unknown
                };

        /// <summary>
        /// Convert the enumerated value <paramref name="data"/> to the corresponding string
        /// value.
        /// </summary>
        /// <param name="data">The enumerated value.</param>
        /// <returns>The text value.</returns>
        public static string ToLabel (this InitiatorMessageType data) =>
            data switch {
                _ => null
                };



        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static ResponderMessageType ToResponderMessageType (this string text) =>
            text switch {
                _ => ResponderMessageType.Unknown
                };

        /// <summary>
        /// Convert the enumerated value <paramref name="data"/> to the corresponding string
        /// value.
        /// </summary>
        /// <param name="data">The enumerated value.</param>
        /// <returns>The text value.</returns>
        public static string ToLabel (this ResponderMessageType data) =>
            data switch {
                _ => null
                };



        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static ErrorCodes ToErrorCodes (this string text) =>
            text switch {
                _ => ErrorCodes.Unknown
                };

        /// <summary>
        /// Convert the enumerated value <paramref name="data"/> to the corresponding string
        /// value.
        /// </summary>
        /// <param name="data">The enumerated value.</param>
        /// <returns>The text value.</returns>
        public static string ToLabel (this ErrorCodes data) =>
            data switch {
                _ => null
                };

        ///<summary>InitiatorResponder</summary>
        public const string TagKeyInitiatorResponder = "TagKeyInitiatorResponder";

        ///<summary>ResponderInitiator</summary>
        public const string TagKeyResponderInitiator = "TagKeyResponderInitiator";

        ///<summary>RUD</summary>
        public const string ProtocolIdRud = "ProtocolIdRud";


        ///<summary>Jose enumeration tag for EncryptionOptions.AesGcm</summary>
        public const string  EncryptionOptionsAesGcmTag = "AesGcm";
        ///<summary>Jose enumeration tag for EncryptionOptions.AesCfb</summary>
        public const string  EncryptionOptionsAesCfbTag = "AesCfb";
        ///<summary>Jose enumeration tag for EncryptionOptions.EncryptPacketHeader</summary>
        public const string  EncryptionOptionsEncryptPacketHeaderTag = "EncryptPacketHeader";
        ///<summary>Jose enumeration tag for EncryptionOptions.RequireOneTimeId</summary>
        public const string  EncryptionOptionsRequireOneTimeIdTag = "RequireOneTimeId";

        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static EncryptionOptions ToEncryptionOptions (this string text) =>
            text switch {
                EncryptionOptionsAesGcmTag => EncryptionOptions.AesGcm,
                EncryptionOptionsAesCfbTag => EncryptionOptions.AesCfb,
                EncryptionOptionsEncryptPacketHeaderTag => EncryptionOptions.EncryptPacketHeader,
                EncryptionOptionsRequireOneTimeIdTag => EncryptionOptions.RequireOneTimeId,
                _ => EncryptionOptions.Unknown
                };

        /// <summary>
        /// Convert the enumerated value <paramref name="data"/> to the corresponding string
        /// value.
        /// </summary>
        /// <param name="data">The enumerated value.</param>
        /// <returns>The text value.</returns>
        public static string ToLabel (this EncryptionOptions data) =>
            data switch {
                EncryptionOptions.AesGcm => EncryptionOptionsAesGcmTag,
                EncryptionOptions.AesCfb => EncryptionOptionsAesCfbTag,
                EncryptionOptions.EncryptPacketHeader => EncryptionOptionsEncryptPacketHeaderTag,
                EncryptionOptions.RequireOneTimeId => EncryptionOptionsRequireOneTimeIdTag,
                _ => null
                };


        ///<summary>Jose enumeration tag for ExtensionTags.X448</summary>
        public const string  ExtensionTagsX448Tag = "X448";
        ///<summary>Jose enumeration tag for ExtensionTags.PkixX509</summary>
        public const string  ExtensionTagsPkixX509Tag = "PkixX509";
        ///<summary>Jose enumeration tag for ExtensionTags.PkixOcsp</summary>
        public const string  ExtensionTagsPkixOcspTag = "PkixOcsp";
        ///<summary>Jose enumeration tag for ExtensionTags.MeshProfile</summary>
        public const string  ExtensionTagsMeshProfileTag = "MeshProfile";
        ///<summary>Jose enumeration tag for ExtensionTags.MeshConnection</summary>
        public const string  ExtensionTagsMeshConnectionTag = "MeshConnection";
        ///<summary>Jose enumeration tag for ExtensionTags.ClaimId</summary>
        public const string  ExtensionTagsClaimIdTag = "ClaimId";
        ///<summary>Jose enumeration tag for ExtensionTags.StreamId</summary>
        public const string  ExtensionTagsStreamIdTag = "StreamId";
        ///<summary>Jose enumeration tag for ExtensionTags.OneTimeStreamId</summary>
        public const string  ExtensionTagsOneTimeStreamIdTag = "OneTimeStreamId";
        ///<summary>Jose enumeration tag for ExtensionTags.Roll</summary>
        public const string  ExtensionTagsRollTag = "Roll";
        ///<summary>Jose enumeration tag for ExtensionTags.Challenge</summary>
        public const string  ExtensionTagsChallengeTag = "Challenge";
        ///<summary>Jose enumeration tag for ExtensionTags.ChallengeProofOfWork</summary>
        public const string  ExtensionTagsChallengeProofOfWorkTag = "ChallengeProofOfWork";
        ///<summary>Jose enumeration tag for ExtensionTags.Refuse</summary>
        public const string  ExtensionTagsRefuseTag = "Refuse";
        ///<summary>Jose enumeration tag for ExtensionTags.NotKnown</summary>
        public const string  ExtensionTagsNotKnownTag = "NotKnown";
        ///<summary>Jose enumeration tag for ExtensionTags.Authorize</summary>
        public const string  ExtensionTagsAuthorizeTag = "Authorize";
        ///<summary>Jose enumeration tag for ExtensionTags.Encrypt</summary>
        public const string  ExtensionTagsEncryptTag = "Encrypt";
        ///<summary>Jose enumeration tag for ExtensionTags.CloseStream</summary>
        public const string  ExtensionTagsCloseStreamTag = "CloseStream";
        ///<summary>Jose enumeration tag for ExtensionTags.CloseConnection</summary>
        public const string  ExtensionTagsCloseConnectionTag = "CloseConnection";
        ///<summary>Jose enumeration tag for ExtensionTags.StreamClient</summary>
        public const string  ExtensionTagsStreamClientTag = "StreamClient";
        ///<summary>Jose enumeration tag for ExtensionTags.StreamReceiver</summary>
        public const string  ExtensionTagsStreamReceiverTag = "StreamReceiver";
        ///<summary>Jose enumeration tag for ExtensionTags.StreamNew</summary>
        public const string  ExtensionTagsStreamNewTag = "StreamNew";
        ///<summary>Jose enumeration tag for ExtensionTags.StreamSender</summary>
        public const string  ExtensionTagsStreamSenderTag = "StreamSender";
        ///<summary>Jose enumeration tag for ExtensionTags.StreamService</summary>
        public const string  ExtensionTagsStreamServiceTag = "StreamService";

        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static ExtensionTags ToExtensionTags (this string text) =>
            text switch {
                ExtensionTagsX448Tag => ExtensionTags.X448,
                ExtensionTagsPkixX509Tag => ExtensionTags.PkixX509,
                ExtensionTagsPkixOcspTag => ExtensionTags.PkixOcsp,
                ExtensionTagsMeshProfileTag => ExtensionTags.MeshProfile,
                ExtensionTagsMeshConnectionTag => ExtensionTags.MeshConnection,
                ExtensionTagsClaimIdTag => ExtensionTags.ClaimId,
                ExtensionTagsStreamIdTag => ExtensionTags.StreamId,
                ExtensionTagsOneTimeStreamIdTag => ExtensionTags.OneTimeStreamId,
                ExtensionTagsRollTag => ExtensionTags.Roll,
                ExtensionTagsChallengeTag => ExtensionTags.Challenge,
                ExtensionTagsChallengeProofOfWorkTag => ExtensionTags.ChallengeProofOfWork,
                ExtensionTagsRefuseTag => ExtensionTags.Refuse,
                ExtensionTagsNotKnownTag => ExtensionTags.NotKnown,
                ExtensionTagsAuthorizeTag => ExtensionTags.Authorize,
                ExtensionTagsEncryptTag => ExtensionTags.Encrypt,
                ExtensionTagsCloseStreamTag => ExtensionTags.CloseStream,
                ExtensionTagsCloseConnectionTag => ExtensionTags.CloseConnection,
                ExtensionTagsStreamClientTag => ExtensionTags.StreamClient,
                ExtensionTagsStreamReceiverTag => ExtensionTags.StreamReceiver,
                ExtensionTagsStreamNewTag => ExtensionTags.StreamNew,
                ExtensionTagsStreamSenderTag => ExtensionTags.StreamSender,
                ExtensionTagsStreamServiceTag => ExtensionTags.StreamService,
                _ => ExtensionTags.Unknown
                };

        /// <summary>
        /// Convert the enumerated value <paramref name="data"/> to the corresponding string
        /// value.
        /// </summary>
        /// <param name="data">The enumerated value.</param>
        /// <returns>The text value.</returns>
        public static string ToLabel (this ExtensionTags data) =>
            data switch {
                ExtensionTags.X448 => ExtensionTagsX448Tag,
                ExtensionTags.PkixX509 => ExtensionTagsPkixX509Tag,
                ExtensionTags.PkixOcsp => ExtensionTagsPkixOcspTag,
                ExtensionTags.MeshProfile => ExtensionTagsMeshProfileTag,
                ExtensionTags.MeshConnection => ExtensionTagsMeshConnectionTag,
                ExtensionTags.ClaimId => ExtensionTagsClaimIdTag,
                ExtensionTags.StreamId => ExtensionTagsStreamIdTag,
                ExtensionTags.OneTimeStreamId => ExtensionTagsOneTimeStreamIdTag,
                ExtensionTags.Roll => ExtensionTagsRollTag,
                ExtensionTags.Challenge => ExtensionTagsChallengeTag,
                ExtensionTags.ChallengeProofOfWork => ExtensionTagsChallengeProofOfWorkTag,
                ExtensionTags.Refuse => ExtensionTagsRefuseTag,
                ExtensionTags.NotKnown => ExtensionTagsNotKnownTag,
                ExtensionTags.Authorize => ExtensionTagsAuthorizeTag,
                ExtensionTags.Encrypt => ExtensionTagsEncryptTag,
                ExtensionTags.CloseStream => ExtensionTagsCloseStreamTag,
                ExtensionTags.CloseConnection => ExtensionTagsCloseConnectionTag,
                ExtensionTags.StreamClient => ExtensionTagsStreamClientTag,
                ExtensionTags.StreamReceiver => ExtensionTagsStreamReceiverTag,
                ExtensionTags.StreamNew => ExtensionTagsStreamNewTag,
                ExtensionTags.StreamSender => ExtensionTagsStreamSenderTag,
                ExtensionTags.StreamService => ExtensionTagsStreamServiceTag,
                _ => null
                };

        }
    }
