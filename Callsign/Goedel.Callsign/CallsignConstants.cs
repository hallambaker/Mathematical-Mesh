
//  This file was automatically generated at 20-Apr-23 5:44:41 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  constant version 3.0.0.945
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.19042.0
//  
//  
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

using Goedel.Utilities;

namespace Goedel.Callsign ;


///<summary>Registration reason</summary>
public enum RegistrationReason {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>Initial registration</summary>
    Initial,
    ///<summary>Update of prior registration</summary>
    Update,
    ///<summary>Voluntary transfer of registration</summary>
    Voluntary,
    ///<summary>Administrative transfer of registration</summary>
    Administrative,
    ///<summary>Registration revocation</summary>
    Revoke    }

///<summary>Refusal reason</summary>
public enum RegistrationRefusal {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>Registration refused</summary>
    RegistrationRefused,
    ///<summary>Binding request larger than the maximum permitted size.</summary>
    RequestTooLarge,
    ///<summary>Canonical form invalid.</summary>
    CanonicalFormInvalid,
    ///<summary>Display form does not match the canonical form.</summary>
    DisplayFormInvalid,
    ///<summary>Callsign length is invalid.</summary>
    CallsignLengthInvalid,
    ///<summary>Request signature is invalid.</summary>
    RequestSignatureInvalid,
    ///<summary>Binding signature is invalid.</summary>
    BindingSignatureInvalid,
    ///<summary>Request is not authorized.</summary>
    RequestNotAuthorized,
    ///<summary>Requires payment.</summary>
    RequestRequiresPayment,
    ///<summary>Payment insufficient.</summary>
    PaymentInsufficient    }


///<summary>
///Constants specified in hallambaker-callsign
///</summary>
public static partial class CallsignConstants {

    // File: ReservedTopLevelDomain

    ///<summary>
    ///The toplevel pseudo-domain for mesh assigned names.
    ///</summary>
    public const string CallsignDomain = "mesh";

    // File: CharacterPageCallsigns

    ///<summary>
    ///Character page specifying digits and spaces
    ///</summary>
    public const string CharacterPageDigitsId = "CharacterPageDigits";

    ///<summary>
    ///Character page specifying Latin-1 character set
    ///</summary>
    public const string CharacterPageLatinId = "CharacterPageLatin";

    // File: ReservedCallsigns

    ///<summary>
    ///Provisional provider
    ///</summary>
    public const string CallsignProvider0 = "provisional";

    ///<summary>
    ///Mesh service provider
    ///</summary>
    public const string CallsignProvider1 = "provider";

    ///<summary>
    ///Alice original callsign
    ///</summary>
    public const string CallsignAlice = "alice";

    ///<summary>
    ///Alice updated callsign
    ///</summary>
    public const string CallsignAlice1 = "Alice";

    ///<summary>
    ///Bob original callsign
    ///</summary>
    public const string CallsignBob = "bob";

    ///<summary>
    ///The quartermaster's callsign.
    ///</summary>
    public const string CallsignQuartermaster = "quartermaster";

    // File: RegistrationReasons


    ///<summary>Jose enumeration tag for RegistrationReason.Initial</summary>
    public const string  RegistrationReasonInitialTag = "Initial";
    ///<summary>Jose enumeration tag for RegistrationReason.Update</summary>
    public const string  RegistrationReasonUpdateTag = "Update";
    ///<summary>Jose enumeration tag for RegistrationReason.Voluntary</summary>
    public const string  RegistrationReasonVoluntaryTag = "Voluntary";
    ///<summary>Jose enumeration tag for RegistrationReason.Administrative</summary>
    public const string  RegistrationReasonAdministrativeTag = "Administrative";
    ///<summary>Jose enumeration tag for RegistrationReason.Revoke</summary>
    public const string  RegistrationReasonRevokeTag = "Revoke";

    /// <summary>
    /// Convert the string <paramref name="text"/> to the corresponding enumeration
    /// value.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The enumeration value.</returns>
    public static RegistrationReason ToRegistrationReason (this string text) =>
        text switch {
            RegistrationReasonInitialTag => RegistrationReason.Initial,
            RegistrationReasonUpdateTag => RegistrationReason.Update,
            RegistrationReasonVoluntaryTag => RegistrationReason.Voluntary,
            RegistrationReasonAdministrativeTag => RegistrationReason.Administrative,
            RegistrationReasonRevokeTag => RegistrationReason.Revoke,
            _ => RegistrationReason.Unknown
            };

    /// <summary>
    /// Convert the enumerated value <paramref name="data"/> to the corresponding string
    /// value.
    /// </summary>
    /// <param name="data">The enumerated value.</param>
    /// <returns>The text value.</returns>
    public static string ToLabel (this RegistrationReason data) =>
        data switch {
            RegistrationReason.Initial => RegistrationReasonInitialTag,
            RegistrationReason.Update => RegistrationReasonUpdateTag,
            RegistrationReason.Voluntary => RegistrationReasonVoluntaryTag,
            RegistrationReason.Administrative => RegistrationReasonAdministrativeTag,
            RegistrationReason.Revoke => RegistrationReasonRevokeTag,
            _ => null
            };

    // File: RegistrationRefusals


    ///<summary>Jose enumeration tag for RegistrationRefusal.RegistrationRefused</summary>
    public const string  RegistrationRefusalRegistrationRefusedTag = "RegistrationRefused";
    ///<summary>Jose enumeration tag for RegistrationRefusal.RequestTooLarge</summary>
    public const string  RegistrationRefusalRequestTooLargeTag = "RequestTooLarge";
    ///<summary>Jose enumeration tag for RegistrationRefusal.CanonicalFormInvalid</summary>
    public const string  RegistrationRefusalCanonicalFormInvalidTag = "CanonicalFormInvalid";
    ///<summary>Jose enumeration tag for RegistrationRefusal.DisplayFormInvalid</summary>
    public const string  RegistrationRefusalDisplayFormInvalidTag = "DisplayFormInvalid";
    ///<summary>Jose enumeration tag for RegistrationRefusal.CallsignLengthInvalid</summary>
    public const string  RegistrationRefusalCallsignLengthInvalidTag = "CallsignLengthInvalid";
    ///<summary>Jose enumeration tag for RegistrationRefusal.RequestSignatureInvalid</summary>
    public const string  RegistrationRefusalRequestSignatureInvalidTag = "RequestSignatureInvalid";
    ///<summary>Jose enumeration tag for RegistrationRefusal.BindingSignatureInvalid</summary>
    public const string  RegistrationRefusalBindingSignatureInvalidTag = "BindingSignatureInvalid";
    ///<summary>Jose enumeration tag for RegistrationRefusal.RequestNotAuthorized</summary>
    public const string  RegistrationRefusalRequestNotAuthorizedTag = "RequestNotAuthorized";
    ///<summary>Jose enumeration tag for RegistrationRefusal.RequestRequiresPayment</summary>
    public const string  RegistrationRefusalRequestRequiresPaymentTag = "RequestRequiresPayment";
    ///<summary>Jose enumeration tag for RegistrationRefusal.PaymentInsufficient</summary>
    public const string  RegistrationRefusalPaymentInsufficientTag = "PaymentInsufficient";

    /// <summary>
    /// Convert the string <paramref name="text"/> to the corresponding enumeration
    /// value.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The enumeration value.</returns>
    public static RegistrationRefusal ToRegistrationRefusal (this string text) =>
        text switch {
            RegistrationRefusalRegistrationRefusedTag => RegistrationRefusal.RegistrationRefused,
            RegistrationRefusalRequestTooLargeTag => RegistrationRefusal.RequestTooLarge,
            RegistrationRefusalCanonicalFormInvalidTag => RegistrationRefusal.CanonicalFormInvalid,
            RegistrationRefusalDisplayFormInvalidTag => RegistrationRefusal.DisplayFormInvalid,
            RegistrationRefusalCallsignLengthInvalidTag => RegistrationRefusal.CallsignLengthInvalid,
            RegistrationRefusalRequestSignatureInvalidTag => RegistrationRefusal.RequestSignatureInvalid,
            RegistrationRefusalBindingSignatureInvalidTag => RegistrationRefusal.BindingSignatureInvalid,
            RegistrationRefusalRequestNotAuthorizedTag => RegistrationRefusal.RequestNotAuthorized,
            RegistrationRefusalRequestRequiresPaymentTag => RegistrationRefusal.RequestRequiresPayment,
            RegistrationRefusalPaymentInsufficientTag => RegistrationRefusal.PaymentInsufficient,
            _ => RegistrationRefusal.Unknown
            };

    /// <summary>
    /// Convert the enumerated value <paramref name="data"/> to the corresponding string
    /// value.
    /// </summary>
    /// <param name="data">The enumerated value.</param>
    /// <returns>The text value.</returns>
    public static string ToLabel (this RegistrationRefusal data) =>
        data switch {
            RegistrationRefusal.RegistrationRefused => RegistrationRefusalRegistrationRefusedTag,
            RegistrationRefusal.RequestTooLarge => RegistrationRefusalRequestTooLargeTag,
            RegistrationRefusal.CanonicalFormInvalid => RegistrationRefusalCanonicalFormInvalidTag,
            RegistrationRefusal.DisplayFormInvalid => RegistrationRefusalDisplayFormInvalidTag,
            RegistrationRefusal.CallsignLengthInvalid => RegistrationRefusalCallsignLengthInvalidTag,
            RegistrationRefusal.RequestSignatureInvalid => RegistrationRefusalRequestSignatureInvalidTag,
            RegistrationRefusal.BindingSignatureInvalid => RegistrationRefusalBindingSignatureInvalidTag,
            RegistrationRefusal.RequestNotAuthorized => RegistrationRefusalRequestNotAuthorizedTag,
            RegistrationRefusal.RequestRequiresPayment => RegistrationRefusalRequestRequiresPaymentTag,
            RegistrationRefusal.PaymentInsufficient => RegistrationRefusalPaymentInsufficientTag,
            _ => null
            };

    }

