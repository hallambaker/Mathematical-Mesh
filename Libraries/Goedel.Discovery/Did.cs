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

namespace Goedel.Discovery;

/// <summary>
/// W3C DID manager (for what that is worth).
/// </summary>
public record Did {
    

    ///<summary>The stripped DID identifier.</summary> 
    public string Identifier = "";

    /// <summary>
    /// Factory returning a DID from the DNS record <paramref name="record"/>
    /// </summary>
    /// <param name="record">The DNS record.</param>
    /// <returns>The DID and resolved document</returns>
    public static Did Factory (DNSRecord_TXT record) {
        foreach (var text in record.Text) {
            var stripped = StripPrefix("did=", text);
            if (stripped != null) {
                return (Factory(stripped));
                }
            }
        return null;
        }

    /// <summary>
    /// Factory returning a DID from the identifier <paramref name="identifier"/>
    /// </summary>
    /// <param name="identifier">The identifier.</param>
    /// <returns>The DID and resolved document</returns>
    public static Did Factory(string identifier) {
        if (identifier.StartsWith(DidPlc.Prefix)) {
            return new DidPlc(identifier);
            }
        if (identifier.StartsWith(DidWeb.Prefix)) {
            return new DidWeb(identifier);
            }
        return null;
        }


    /// <summary>
    /// Strip the prefiox <paramref name="prefix"/> from the DID.
    /// </summary>
    /// <param name="prefix">Prefix to strip.</param>
    /// <param name="text">Test to trim.</param>
    /// <returns>The stripped text.</returns>
    static string StripPrefix(string prefix, string text) {
        if (text.ToLower().StartsWith(prefix)) {
            return text[prefix.Length..];
            }

        return null;
        }


    }


/// <summary>
/// Web form DID.
/// </summary>
public record DidWeb : Did {

    ///<summary>The DID prefix.</summary> 
    public const string Prefix = "did:web:";

    ///<summary>The Web domain.</summary> 
    public string Domain;

    /// <summary>
    /// Constructor, return an instance for <paramref name="identifier"/>.
    /// </summary>
    /// <param name="identifier">The identifier to return an instance for.</param>
    public DidWeb(string identifier) {
        Identifier = identifier;
        Domain = identifier[Prefix.Length..];
        }

    }

/// <summary>
/// PLC form DID
/// </summary>
public record DidPlc : Did {

    ///<summary>The DID prefix.</summary> 
    public const string Prefix = "did:plc:";

    ///<summary>The PLC key.</summary> 
    public string Key;

    /// <summary>
    /// Constructor, return an instance for <paramref name="identifier"/>.
    /// </summary>
    /// <param name="identifier">The identifier to return an instance for.</param>
    public DidPlc(string identifier) {

        Identifier = identifier;
        Key = identifier[Prefix.Length..];
        }

    }