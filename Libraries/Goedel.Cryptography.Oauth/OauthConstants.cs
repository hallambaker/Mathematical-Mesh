
//  This file was automatically generated at 1/9/2026 6:59:54 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  constant version 3.0.0.1170
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.26200.0
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
    Web = 0,
    ///<summary>native</summary>
    Native = 1    }

///<summary>Grant types</summary>
public enum GrantTypes {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>authorization_code</summary>
    AuthorizationCode = 0,
    ///<summary>refresh_token</summary>
    RefreshToken = 1    }

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
    Code = 0    }

///<summary>Authentication Method</summary>
public enum AuthenticationMethod {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>private_key_jwt</summary>
    JWT = 0    }

///<summary>Endpoint Signature Algorithm</summary>
public enum EndpointSignature {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>ES256</summary>
    ES256 = 0    }

///<summary>Assertion Types</summary>
public enum AssertionTypes {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>urn:ietf:params:oauth:client-assertion-type:jwt-bearer</summary>
    Bearer = 0    }


///<summary>
///</summary>
public static partial class OauthConstants {

    // File: OauthIdentifier


    ///<summary>Jose enumeration tag for ApplicationType.Web</summary>
    public const string  ApplicationTypeWebTag = "Web";
    ///<summary>Description for ApplicationType.Web</summary>
    public const string  ApplicationTypeWebTitle = "web";
    ///<summary>Jose enumeration tag for ApplicationType.Native</summary>
    public const string  ApplicationTypeNativeTag = "Native";
    ///<summary>Description for ApplicationType.Native</summary>
    public const string  ApplicationTypeNativeTitle = "native";

    /// <summary>
    /// Convert the string <paramref name="text"/> to the corresponding enumeration
    /// value.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The enumeration value.</returns>
    public static ApplicationType ToApplicationType (this string text) =>
        text switch {
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
            _ => null
            };


    ///<summary>Jose enumeration tag for GrantTypes.AuthorizationCode</summary>
    public const string  GrantTypesAuthorizationCodeTag = "AuthorizationCode";
    ///<summary>Description for GrantTypes.AuthorizationCode</summary>
    public const string  GrantTypesAuthorizationCodeTitle = "authorization_code";
    ///<summary>Jose enumeration tag for GrantTypes.RefreshToken</summary>
    public const string  GrantTypesRefreshTokenTag = "RefreshToken";
    ///<summary>Description for GrantTypes.RefreshToken</summary>
    public const string  GrantTypesRefreshTokenTitle = "refresh_token";

    /// <summary>
    /// Convert the string <paramref name="text"/> to the corresponding enumeration
    /// value.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The enumeration value.</returns>
    public static GrantTypes ToGrantTypes (this string text) =>
        text switch {
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
    ///<summary>Description for ResponseType.Code</summary>
    public const string  ResponseTypeCodeTitle = "code";

    /// <summary>
    /// Convert the string <paramref name="text"/> to the corresponding enumeration
    /// value.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The enumeration value.</returns>
    public static ResponseType ToResponseType (this string text) =>
        text switch {
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
            _ => null
            };


    ///<summary>Jose enumeration tag for AuthenticationMethod.JWT</summary>
    public const string  AuthenticationMethodJWTTag = "JWT";
    ///<summary>Description for AuthenticationMethod.JWT</summary>
    public const string  AuthenticationMethodJWTTitle = "private_key_jwt";

    /// <summary>
    /// Convert the string <paramref name="text"/> to the corresponding enumeration
    /// value.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The enumeration value.</returns>
    public static AuthenticationMethod ToAuthenticationMethod (this string text) =>
        text switch {
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
            _ => null
            };


    ///<summary>Jose enumeration tag for EndpointSignature.ES256</summary>
    public const string  EndpointSignatureES256Tag = "ES256";
    ///<summary>Description for EndpointSignature.ES256</summary>
    public const string  EndpointSignatureES256Title = "ES256";

    /// <summary>
    /// Convert the string <paramref name="text"/> to the corresponding enumeration
    /// value.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The enumeration value.</returns>
    public static EndpointSignature ToEndpointSignature (this string text) =>
        text switch {
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
            _ => null
            };


    ///<summary>Jose enumeration tag for AssertionTypes.Bearer</summary>
    public const string  AssertionTypesBearerTag = "Bearer";
    ///<summary>Description for AssertionTypes.Bearer</summary>
    public const string  AssertionTypesBearerTitle = "urn:ietf:params:oauth:client-assertion-type:jwt-bearer";

    /// <summary>
    /// Convert the string <paramref name="text"/> to the corresponding enumeration
    /// value.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The enumeration value.</returns>
    public static AssertionTypes ToAssertionTypes (this string text) =>
        text switch {
            _ => AssertionTypes.Unknown
            };

    /// <summary>
    /// Convert the enumerated value <paramref name="data"/> to the corresponding string
    /// value.
    /// </summary>
    /// <param name="data">The enumerated value.</param>
    /// <returns>The text value.</returns>
    public static string ToLabel (this AssertionTypes data) =>
        data switch {
            _ => null
            };

    }

