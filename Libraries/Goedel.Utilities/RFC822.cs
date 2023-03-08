#region // Copyright - MIT License
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
#endregion

/* Unmerged change from project 'Goedel.Utilities'
Before:
using System;
using System.Collections.Generic;
using Goedel.Utilities;
After:
using Goedel.Utilities;

using System;
using System.Collections.Generic;
*/
using System.Runtime.CompilerServices;

namespace Goedel.Utilities;

/// <summary>
/// Account addresses used in the Mesh.
/// </summary>
public enum AddressType {
    ///<summary>Address value is null.</summary> 
    Null,

    ///<summary>Address is in username@domain format. Note that if there
    ///are multiple @ signs the address is always split at the last one so that
    ///domain never contains an @.</summary> 
    AccountAtDns,

    ///<summary>Address is a pure account, no service specifier.</summary> 
    AccountOnly,

    ///<summary>Address begins with @, is a callsign.</summary> 
    Callsign
    }



public static partial class Extension {

    /// <summary>
    /// If the input string contains the separator, return the string leading up 
    /// to the separator. Otherwise return null.
    /// </summary>
    /// <param name="Input">The string to split.</param>
    /// <param name="Separator">The separator character</param>
    /// <returns>If the separator is found, returns the input string up to but not 
    /// including the separator, otherwise null.</returns>
    public static string Left(this string Input, char Separator) {
        var Index = Input.IndexOf(Separator);
        return Index < 0 ? null : Input[..Index];
        }

    /// <summary>
    /// If the input string contains the separator, return the string leading up 
    /// to the separator. Otherwise return null.
    /// </summary>
    /// <param name="Input">The string to split.</param>
    /// <param name="Separator">The separator character</param>
    /// <returns>If the separator is found, returns the input string up to but not 
    /// including the separator, otherwise null.</returns>
    public static string Right(this string Input, char Separator) {
        var Index = Input.IndexOf(Separator);
        return Index < 0 ? null : Input[(Index + 1)..];
        }


    /// <summary>
    /// If the input string contains the separator, return the string leading up 
    /// to the separator. Otherwise return null.
    /// </summary>
    /// <param name="Input">The string to split.</param>
    /// <param name="Separator">The separator character</param>
    /// <param name="Right">The string to the right of the separator</param>
    /// <param name="Left">The string to the left of the separator</param>
    /// <returns>If the separator is found, returns the input string up to but not 
    /// including the separator, otherwise null.</returns>
    public static void Separate(this string Input, char Separator,
        out string Left, out string Right) {
        var Index = Input.IndexOf(Separator);
        Left = Index < 0 ? null : Input[..Index];
        Right = Index < 0 ? null : Input[(Index + 1)..];
        }

    /// <summary>
    /// Returns true if <paramref name="accountID"/> is a reasonably well formed account
    /// address, other
    /// </summary>
    /// <param name="accountID">The string to test.</param>
    /// <returns><paramref name="accountID"/> if it is a well formed account identifier
    /// and null otherwise.</returns>
    public static bool IsAccountID(this string accountID) {
        if (accountID == null || accountID.Length < 3) {
            return false;
            }
        return true; // Hack: need to do this properly.
        }


    /// <summary>
    /// Parse a string that may contain an account identifier to extract the service and 
    /// account components.
    /// </summary>
    /// <param name="identifier">The AccountID to split.</param>
    /// <param name="service">The portal address.</param>
    /// <param name="account">The account name.</param>
    /// <returns>The type of address specified.</returns>
    public static AddressType SplitAccountAddress(this string identifier,
            out string service,
            out string account) {
        account = null;
        service = null;
        if (identifier == null) {
            return AddressType.Null;
            }

        var at = identifier.LastIndexOf('@');
        if (at < 0) {
            account = identifier;
            return AddressType.AccountOnly;
            }

        if (at == 0) {
            account = identifier;
            service = null;
            return AddressType.Callsign;
            }

        account = identifier[..at];
        service = identifier[(at + 1)..];

        return AddressType.AccountAtDns;
        }



    /// <summary>
    /// Parse a string that may contain an account identifier to extract the service and 
    /// account components.
    /// </summary>
    /// <param name="identifier">The AccountID to split.</param>
    /// <param name="service">The portal address.</param>
    /// <param name="account">The account name.</param>
    public static void SplitAccountIDService(this string identifier,
            out string service,
            out string account) {
        account = null;
        service = null;
        if (identifier == null) {
            return;
            }

        var at = identifier.LastIndexOf('@');
        if (at < 0) {
            service = identifier;
            return;
            }

        account = identifier[..at];
        service = identifier[(at + 1)..];
        }

    /// <summary>
    /// Parse a string that may contain an account identifier to extract the service and 
    /// account components.
    /// </summary>
    /// <param name="identifier">The AccountID to split.</param>
    /// <returns>The service component.</returns>
    public static string GetService(this string identifier) => GetServiceRaw(identifier).ToLower();



    /// <summary>
    /// Parse a string that may contain an account identifier to extract the service and 
    /// account components.
    /// </summary>
    /// <param name="identifier">The AccountID to split.</param>
    /// <returns>The service component.</returns>
    public static string GetServiceRaw(this string identifier) {

        int At = identifier.LastIndexOf('@');
        if (At < 0) {
            return identifier;
            }


        return identifier[(At + 1)..];
        }

    }
