
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
public enum ServiceAddressType {
    Invalid,
    IPv4,
    IPv6,
    DNS,
    Callsign
    }

public class ServiceAddress {
    public const string MeshTopLevelDirectory = "mm--";


    public ServiceAddressType ServiceAddressType { get; init; }

    /// <summary> The service address </summary>
    public string Service { get; init; }

    ///<summary>The callsign version, is only valid for callsigns</summary> 
    public int? Version { get; init; }

    ///<summary>The account portion.</summary> 
    public string Account { get; init; }

    ///<summary></summary> 
    public int? Port { get; init; }


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


