
//  This file was automatically generated at 4/6/2021 12:47:54 PM
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
    public enum ClientInitial {
        ///<summary>Undefined type</summary>
        Unknown = -1,
        ///<summary>Initial contact message without key exchange</summary>
        ClientInitialHello = 1,
        ///<summary>Initial contact message with key exchange</summary>
        ClientInitialExchange = 2,
        ///<summary>Error response</summary>
        PacketError = 3        }

    ///<summary>Host response messages</summary>
    public enum HostMessageTags {
        ///<summary>Undefined type</summary>
        Unknown = -1,
        ///<summary>Host exchange message</summary>
        TagHostExchange = 1,
        ///<summary>Host challenge type 1</summary>
        TagHostChallenge1 = 2,
        ///<summary>Host challenge type 2</summary>
        TagHostChallenge2 = 3,
        ///<summary>Host exchange completetion</summary>
        TagHostComplete = 4        }

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

    ///<summary>Presentation extension tags</summary>
    public enum ExtensionTags {
        ///<summary>Undefined type</summary>
        Unknown = -1        }


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
        public static ClientInitial ToClientInitial (this string text) =>
            text switch {
                _ => ClientInitial.Unknown
                };

        /// <summary>
        /// Convert the enumerated value <paramref name="data"/> to the corresponding string
        /// value.
        /// </summary>
        /// <param name="data">The enumerated value.</param>
        /// <returns>The text value.</returns>
        public static string ToLabel (this ClientInitial data) =>
            data switch {
                _ => null
                };



        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static HostMessageTags ToHostMessageTags (this string text) =>
            text switch {
                _ => HostMessageTags.Unknown
                };

        /// <summary>
        /// Convert the enumerated value <paramref name="data"/> to the corresponding string
        /// value.
        /// </summary>
        /// <param name="data">The enumerated value.</param>
        /// <returns>The text value.</returns>
        public static string ToLabel (this HostMessageTags data) =>
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



        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static ExtensionTags ToExtensionTags (this string text) =>
            text switch {
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
                _ => null
                };

        }
    }
