
//  This file was automatically generated at 12/12/2024 6:00:43 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  constant version 3.0.0.1053
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

namespace Goedel.Cryptography.Oauth ;


///<summary>Application Types</summary>
public enum ApplicationType {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>web</summary>
    Web,
    ///<summary>native</summary>
    Native    }

///<summary>Grant types</summary>
public enum GrantTypes {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>authorization_code </summary>
    AuthorizationCode,
    ///<summary>refresh_token </summary>
    RefreshToken    }

///<summary>Scope types</summary>
public enum ScopeTypes {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>atproto</summary>
    Atproto = 0,
    ///<summary>transition:generic</summary>
    Generic = 1,
    ///<summary>transition:chat.bsky</summary>
    Chat = 2    }

///<summary>Response Types</summary>
public enum ResponseType {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>code</summary>
    Code    }

///<summary>Authentication Method</summary>
public enum AuthenticationMethod {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>private_key_jwt</summary>
    JWT    }

///<summary>Endpoint Signature Algorithm</summary>
public enum EndpointSignature {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>ES256</summary>
    ES256    }


///<summary>
///</summary>
public static partial class OauthConstants {

    // File: OauthIdentifier


    ///<summary>Jose enumeration tag for ApplicationType.Web</summary>
    public const string  ApplicationTypeWebTag = "Web";
    ///<summary>Jose enumeration tag for ApplicationType.Native</summary>
    public const string  ApplicationTypeNativeTag = "Native";

    /// <summary>
    /// Convert the string <paramref name="text"/> to the corresponding enumeration
    /// value.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The enumeration value.</returns>
    public static ApplicationType ToApplicationType (this string text) =>
        text switch {
            ApplicationTypeWebTag => ApplicationType.Web,
            ApplicationTypeNativeTag => ApplicationType.Native,
            _ => ApplicationType.Unknown
            };

    /// <summary>
    /// Convert the enumerated value <paramref name="data"/> to the corresponding string
    /// value.
    /// </summary>
    /// <param name="data">The enumerated value.</param>
    /// <returns>The text value.</returns>
    public static string ToLabel (this ApplicationType data) =>
        data switch {
            ApplicationType.Web => ApplicationTypeWebTag,
            ApplicationType.Native => ApplicationTypeNativeTag,
            _ => null
            };


    ///<summary>Jose enumeration tag for GrantTypes.AuthorizationCode</summary>
    public const string  GrantTypesAuthorizationCodeTag = "AuthorizationCode";
    ///<summary>Jose enumeration tag for GrantTypes.RefreshToken</summary>
    public const string  GrantTypesRefreshTokenTag = "RefreshToken";

    /// <summary>
    /// Convert the string <paramref name="text"/> to the corresponding enumeration
    /// value.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The enumeration value.</returns>
    public static GrantTypes ToGrantTypes (this string text) =>
        text switch {
            GrantTypesAuthorizationCodeTag => GrantTypes.AuthorizationCode,
            GrantTypesRefreshTokenTag => GrantTypes.RefreshToken,
            _ => GrantTypes.Unknown
            };

    /// <summary>
    /// Convert the enumerated value <paramref name="data"/> to the corresponding string
    /// value.
    /// </summary>
    /// <param name="data">The enumerated value.</param>
    /// <returns>The text value.</returns>
    public static string ToLabel (this GrantTypes data) =>
        data switch {
            GrantTypes.AuthorizationCode => GrantTypesAuthorizationCodeTag,
            GrantTypes.RefreshToken => GrantTypesRefreshTokenTag,
            _ => null
            };


    ///<summary>Jose enumeration tag for ScopeTypes.Atproto</summary>
    public const string  ScopeTypesAtprotoTag = "Atproto";
    ///<summary>Description for ScopeTypes.Atproto</summary>
    public const string  ScopeTypesAtprotoTitle = "atproto";
    ///<summary>Jose enumeration tag for ScopeTypes.Generic</summary>
    public const string  ScopeTypesGenericTag = "Generic";
    ///<summary>Description for ScopeTypes.Generic</summary>
    public const string  ScopeTypesGenericTitle = "transition:generic";
    ///<summary>Jose enumeration tag for ScopeTypes.Chat</summary>
    public const string  ScopeTypesChatTag = "Chat";
    ///<summary>Description for ScopeTypes.Chat</summary>
    public const string  ScopeTypesChatTitle = "transition:chat.bsky";

    /// <summary>
    /// Convert the string <paramref name="text"/> to the corresponding enumeration
    /// value.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The enumeration value.</returns>
    public static ScopeTypes ToScopeTypes (this string text) =>
        text switch {
            _ => ScopeTypes.Unknown
            };

    /// <summary>
    /// Convert the enumerated value <paramref name="data"/> to the corresponding string
    /// value.
    /// </summary>
    /// <param name="data">The enumerated value.</param>
    /// <returns>The text value.</returns>
    public static string ToLabel (this ScopeTypes data) =>
        data switch {
            _ => null
            };


    ///<summary>Jose enumeration tag for ResponseType.Code</summary>
    public const string  ResponseTypeCodeTag = "Code";

    /// <summary>
    /// Convert the string <paramref name="text"/> to the corresponding enumeration
    /// value.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The enumeration value.</returns>
    public static ResponseType ToResponseType (this string text) =>
        text switch {
            ResponseTypeCodeTag => ResponseType.Code,
            _ => ResponseType.Unknown
            };

    /// <summary>
    /// Convert the enumerated value <paramref name="data"/> to the corresponding string
    /// value.
    /// </summary>
    /// <param name="data">The enumerated value.</param>
    /// <returns>The text value.</returns>
    public static string ToLabel (this ResponseType data) =>
        data switch {
            ResponseType.Code => ResponseTypeCodeTag,
            _ => null
            };


    ///<summary>Jose enumeration tag for AuthenticationMethod.JWT</summary>
    public const string  AuthenticationMethodJWTTag = "JWT";

    /// <summary>
    /// Convert the string <paramref name="text"/> to the corresponding enumeration
    /// value.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The enumeration value.</returns>
    public static AuthenticationMethod ToAuthenticationMethod (this string text) =>
        text switch {
            AuthenticationMethodJWTTag => AuthenticationMethod.JWT,
            _ => AuthenticationMethod.Unknown
            };

    /// <summary>
    /// Convert the enumerated value <paramref name="data"/> to the corresponding string
    /// value.
    /// </summary>
    /// <param name="data">The enumerated value.</param>
    /// <returns>The text value.</returns>
    public static string ToLabel (this AuthenticationMethod data) =>
        data switch {
            AuthenticationMethod.JWT => AuthenticationMethodJWTTag,
            _ => null
            };


    ///<summary>Jose enumeration tag for EndpointSignature.ES256</summary>
    public const string  EndpointSignatureES256Tag = "ES256";

    /// <summary>
    /// Convert the string <paramref name="text"/> to the corresponding enumeration
    /// value.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The enumeration value.</returns>
    public static EndpointSignature ToEndpointSignature (this string text) =>
        text switch {
            EndpointSignatureES256Tag => EndpointSignature.ES256,
            _ => EndpointSignature.Unknown
            };

    /// <summary>
    /// Convert the enumerated value <paramref name="data"/> to the corresponding string
    /// value.
    /// </summary>
    /// <param name="data">The enumerated value.</param>
    /// <returns>The text value.</returns>
    public static string ToLabel (this EndpointSignature data) =>
        data switch {
            EndpointSignature.ES256 => EndpointSignatureES256Tag,
            _ => null
            };

    }

