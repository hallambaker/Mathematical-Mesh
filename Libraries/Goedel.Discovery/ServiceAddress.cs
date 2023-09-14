
//  Copyright (c) 2023 by Threshold Secrets
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
//  
//  

using Goedel.FSR;

namespace Goedel.Discovery;

/// <summary>
/// Recognized service address types
/// </summary>
public enum ParsedAddressType {
    ///<summary>Address is not a valid address.</summary> 
    Invalid,
    ///<summary>Address is empty.</summary> 
    Empty,
    ///<summary>IPv4 service address</summary> 
    IPv4,
    ///<summary>IPv6 Service address</summary> 
    IPv6,
    ///<summary>Dns service address only.</summary> 
    Dns,
    ///<summary>Callsign account without service specifier.</summary> 
    Callsign,

    ///<summary>Callsign account with callsign service specifier.</summary> 
    CallsignCallsign,
    ///<summary>Callsign account with DNS service specifier.</summary> 
    CallSignDns,
    ///<summary>RFC822 style account and DNS address.</summary> 
    AccountDns
    }

/// <summary>
/// A parsed address specifier. May be an account address or a service address.
/// </summary>
public record ParsedAddress {

    ///<summary>The address type.</summary> 
    public ParsedAddressType AddressType { get; init; }

    /// <summary> The service address </summary>
    public string? Address { get; init; } = null;

    ///<summary>The callsign version, is only valid for callsigns</summary> 
    public int? Version { get; init; } = 0;

    ///<summary>Convenience value for invalid address.</summary> 
    public static ParsedAddress Invalid { get; } = new () {
        AddressType = ParsedAddressType.Invalid,
        };
    }

/// <summary>
/// A parsed account/service address specifier. A callsign account address is 
/// bound to its current service address through the registry registration.
/// </summary>
public record ServiceAddress {

    ///<summary>Toplevel pseudo directory for Mesh callsigns</summary> 
    public const string MeshTopLevelDirectory = "mm--";

    ///<summary>The composite address type.</summary> 
    public ParsedAddressType AddressType { get; } 
    //=> GetAddressType();

    /// <summary> The service address </summary>
    public ParsedAddress Service { get; }

    ///<summary>The account portion.</summary> 
    public ParsedAddress? Account { get; }

    ///<summary></summary> 
    public int? Port { get; init; }

    /// <summary>
    /// Constructor returning an instance with only one address specifier
    /// <paramref name="address"/>.
    /// </summary>
    /// <param name="address">The address specifier.</param>
    public ServiceAddress(ParsedAddress address) {
        if (address.AddressType == ParsedAddressType.Callsign) {
            Account = address;
            AddressType = address.AddressType;
            }
        else {
            Service = address;
            AddressType = address.AddressType;
            }
        }

    /// <summary>
    /// Constructor returning an instance with an <paramref name="account"/>
    /// address specifier and a <paramref name="service"/> address specifier..
    /// </summary>
    /// <param name="account">The account specifier.</param>
    /// <param name="service">The service specifier.</param>
    public ServiceAddress(ParsedAddress account, ParsedAddress service) {

        if (service.AddressType == ParsedAddressType.Callsign) {
            AddressType = ParsedAddressType.CallsignCallsign;
            }
        else if (account.AddressType == ParsedAddressType.Callsign) {
            AddressType = ParsedAddressType.CallSignDns;
            }
        else {
            AddressType = ParsedAddressType.AccountDns;
            }
        Account = account;
        Service = service;
        }




    /// <summary>
    /// Convenience wrapper, attempts to parse <paramref name="identifier"/>. If the identifier is 
    /// a valid service address, returns true, otherwise false. The value 
    /// </summary>
    /// <param name="identifier"></param>
    /// <param name="serviceAddress"></param>
    /// <returns></returns>
    public static bool TryParse(string identifier, out ServiceAddress serviceAddress) {
        if (identifier == null) {
            serviceAddress = null;
            return false;
            }

        return ServiceAddressSplitLex.TryParse(identifier, out serviceAddress);
        }

    }


