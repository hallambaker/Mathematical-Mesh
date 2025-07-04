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

using Goedel.Cryptography;
using Goedel.Cryptography.PKIX;
using Goedel.IO;

using System.Data;
using System.Reflection.Metadata;

namespace Goedel.Discovery;






/// <summary>
/// Mesh handle types
/// </summary>
public enum HandleType {
    ///<summary>Handle is not valid.</summary> 
    Invalid,

    ///<summary>Handle is just a domain, e.g. example.com</summary> 
    Domain,

    ///<summary>Handle is just a fingerprint, 
    ///e.g. maua-f6qe-ejui-gbwr-c4bh-4x5o-tlah</summary> 
    Fingerprint,

    ///<summary>Account service address, 
    ///e.g. alice@example.com</summary> 
    AccountServiceAddress,

    ///<summary>Direct Service Address, 
    ///e.g. maua-f6qe-ejui-gbwr-c4bh-4x5o-tlah@@example.com</summary> 
    DirectServiceAddress,

    ///<summary>Direct Account Service Address, 
    ///e.g. maua-f6qe-ejui-gbwr-c4bh-4x5o-tlah@alice@example.com</summary> 
    DirectAccountServiceAddress,

    ///<summary>DNS Handle,
    ///e.g. @alice.example.net</summary> 
    DnsHandle,

    ///<summary>Direct DNS handle, 
    ///e.g. @maua-f6qe-ejui-gbwr-c4bh-4x5o-tlah@alice.example.net</summary> 
    DirectDnsHandle,

    ///<summary>Handle Service Address, 
    ///e.g. @alice.example.net@example.com</summary> 
    HandleServiceAddress,

    ///<summary>Local name, e.g. @alice</summary> 
    LocalName
    }





/// <summary>
/// A parsed representation of a Mesh/DNS handle.
/// </summary>
public class ParsedHandle {



    ///<summary>The handle type</summary> 
    public HandleType HandleType { get; init; }

    ///<summary>The fingerprint specification</summary> 
    public string Fingerprint { get; init; } = null;

    ///<summary>The name component</summary> 
    public string Name { get; init; } = null;

    ///<summary>The Service DNS address</summary> 
    public string Service { get; init; } = null;

    ///<summary>The account address component</summary> 
    public string AccountAddress {get; private set;}

    ///<summary>Handle obtained by resolving the handle.</summary> 
    public ParsedHandle ResolvedHandle { get; private set; } = null;


    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="handle">The string to parse.</param>
    /// <exception cref="NYI"></exception>
    public ParsedHandle(string handle) {

        handle.AssertNotNull(NYI.Throw);
        (handle.Length > 0).AssertTrue(NYI.Throw);

        var at = handle.Split('@');

        switch (at.Length) {
            case 1: {  // no @, can only be a fingerprint
                if (at[0].IndexOf('.') < 0) {
                    HandleType = HandleType.Fingerprint;
                    Fingerprint = at[0];
                    }
                else {
                    HandleType = HandleType.Domain;
                    Service = at[0];
                    }
                return;
                }
            case 2: {
                if (at[0].Length > 0) {
                    // name@service, is account service address
                    HandleType = HandleType.AccountServiceAddress;
                    Name = at[0];
                    Service = at[1];
                    return;
                    }
                if (at[1].IndexOf('.') < 0) {
                    // @text, is a local name
                    HandleType = HandleType.LocalName;
                    Name = at[1];
                    return;
                    }
                // @text.text, is a DNS handle
                HandleType = HandleType.DnsHandle;
                Name = at[1];
                return;
                }
            case 3: {
                if (at[0].Length == 0) {
                    if (at[1].IndexOf('.') < 0) {
                        HandleType = HandleType.DirectDnsHandle;
                        Fingerprint = at[1];
                        Name = at[2];
                        return;
                        }
                    HandleType = HandleType.HandleServiceAddress;
                    Name = at[1];
                    Service = at[2];
                    return;
                    }
                if (at[1].Length == 0) {

                    //fingerprint@@service
                    HandleType = HandleType.DirectServiceAddress;
                    Fingerprint = at[0];
                    Service = at[2];
                    return;
                    }
                HandleType = HandleType.DirectAccountServiceAddress;
                Fingerprint = at[0];
                Name = at[1];
                Service = at[2];
                return;
                }
            }

        throw new NYI();

        }


    public static string GetDomain(string handle) {

        var parsedHandle = new ParsedHandle(handle);
        var domain = parsedHandle.HandleType switch {
            HandleType.Domain => parsedHandle.Service,
            HandleType.DnsHandle => parsedHandle.Name,
            HandleType.DirectDnsHandle => parsedHandle.Name,
            _ => throw new NYI(),
            };
        return domain;
        }


    /// <summary>
    /// Convenience method, resolve the handle <paramref name="handle"/> and
    /// return the the corresponding account service address as a text string.
    /// </summary>
    /// <param name="handle"></param>
    /// <returns></returns>
    public static string Resolve(DnsClient dnsClient, string handle) {
        var parsed = new ParsedHandle(handle);
        return parsed.Resolve(dnsClient).Sync();
        }


    /// <summary>
    /// Resolve the handle to return the account service address for the corresponding
    /// Mesh account.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NYI"></exception>
    public async Task<string> Resolve(DnsClient dnsClient) {

        switch (HandleType) {
            case HandleType.DirectDnsHandle:
            case HandleType.DnsHandle: {
                ResolvedHandle = await ResolveDnsHandle(dnsClient);
                AccountAddress = ResolvedHandle.Fingerprint + "@@" + ResolvedHandle.Service;
                return AccountAddress;
                }

            case HandleType.AccountServiceAddress: {
                AccountAddress = Name + "@" + Service;
                return AccountAddress;
                }
            case HandleType.DirectServiceAddress:
            case HandleType.DirectAccountServiceAddress: {
                AccountAddress = Fingerprint + "@@" + Service;
                return AccountAddress;
                }

            default: throw new NYI();
            }
        }





    ///// <summary>
    ///// Return the Mesh service provider associated with the handle.
    ///// </summary>
    ///// <returns>The service provider.</returns>
    ///// <exception cref="NYI"></exception>
    //public async Task<string> ResolveMeshService() {
    //    switch (HandleType) {
    //        // Just return the service component
    //        case HandleType.Domain: 
    //        case HandleType.AccountServiceAddress:
    //        case HandleType.DirectServiceAddress:
    //        case HandleType.DirectAccountServiceAddress: {
    //            return Service;
    //            }

    //        // For a DNS handle, we have to first resolve to get the DirectServiceAddress
    //        case HandleType.DnsHandle:
    //        case HandleType.DirectDnsHandle: {
    //            var handle = await ResolveDnsHandle();
    //            return handle?.Service;
    //            }

    //        // These all fail because there isn't enough information to resolve a service
    //        case HandleType.LocalName:
    //        case HandleType.Invalid:
    //        case HandleType.Fingerprint: {
    //            throw new NYI();
    //            }
    //        }

    //    throw new NYI();
    //    }





    /// <summary>
    /// Return the Account Service handle associated with the handle.
    /// </summary>
    /// <returns>The account service handle</returns>
    public async Task<ParsedHandle?> ResolveDnsHandle(DnsClient dnsClient) {

        var meshService = await HandleServiceMesh.Fetch(dnsClient, Name);
        if (meshService != null) {
            return new ParsedHandle(meshService.Dsa);
            }

        return null;
        }

    ///// <summary>
    ///// Resolve the JSContact entry for the handle <paramref name="handle"/> and return the 
    ///// plaintext bytes and media type.
    ///// </summary>
    ///// <param name="handle"></param>
    ///// <returns></returns>
    //public static async Task<byte[]> ResolveContact(string handle) {

    //    var contactTxt = await HandleServiceContact.Fetch(handle);

    //    return await ResolveEarl(contactTxt.Uri);
    //    }



    //public static Func<string, Task<byte[]>> ResolveEarl { get; set; } = ResolveEarlDns;


    ///// <summary>
    ///// Resolve <paramref name="uriString"/> to obtain the HTTPS well known service, 
    ///// fetch the ciphertext, decrypt and return the result.
    ///// </summary>
    ///// <param name="uriString">The uri to parse.</param>
    ///// <returns>The resolution result</returns>
    //public static async Task<byte[]> ResolveEarlDns(
    //                string uriString) {

    //    // The well known service and extension are ALWAYS earl, regardless of the
    //    // uri scheme.
    //    var wellKnown = "earl";
    //    var extension = "earl";

    //    var uri = new Uri(uriString);
    //    var host = uri.Host;
    //    var earl = uri.Segments[^1];

    //    // Form the .well-known service URI and fetch the result
    //    var locator = Udf.EarlLocator(earl);
    //    var serviceUri = $"https://{host}/.well-known/{wellKnown}/{locator}.{extension}";
    //    var ciphertext = await UriClient.DownloadByteArrayAsync(serviceUri);

    //    // If this fails, it is likely due to the service not being up!
    //    ciphertext.AssertNotNull(NYI.Throw);

    //    // decrypt the cipher text
    //    var plaintext = Udf.GetDecryptedData(ciphertext, earl);
    //    return (plaintext);
    //    }


    ///// <summary>
    ///// Fetch the services associated with this handle.
    ///// </summary>
    ///// <returns>The services</returns>
    //public async Task<DnsHandleServices> GetServices() => await GetServices(Name);

    ///// <summary>
    ///// Fetch the services associated with the handle <paramref name="handle"/>.
    ///// </summary>
    ///// <returns>The services</returns>
    //public static async Task<DnsHandleServices> GetServices(string handle) {
    //    var result = new DnsHandleServices(handle);

    //    var handleTxt = await DnsClient.GetPrefixedTXT(handle, "_handle");

    //    if (handleTxt == null) {
    //        result.Add(await HandleServiceMesh.Fetch(handle));
    //        result.Add(await HandleServiceOauth.Fetch(handle));
    //        result.Add(await HandleServiceAtprotocol.Fetch(handle));
    //        result.Add(await HandleServiceHttp.Fetch(handle));
    //        return result;
    //        }

    //    // collect up all the text into one bucket, that is our entry
    //    var services = handleTxt.FullText().Split (' ');


    //    foreach (var service in services) {
    //        switch (service) {

    //            case "mesh": {
    //                result.Add (await HandleServiceMesh.Fetch (handle, true));
    //                break;
    //                }
    //            case "oauth": {
    //                result.Add(await HandleServiceOauth.Fetch(handle, true));
    //                break;
    //                }
    //            case "atproto": {
    //                result.Add(await HandleServiceAtprotocol.Fetch(handle, true));
    //                break;
    //                }
    //            case "https": {
    //                result.Add(await HandleServiceHttp.Fetch(handle, true));
    //                break;
    //                }
    //            case "": {
    //                break;
    //                }
    //            }
    //        }

    //    return result;
    //    }

    }



///// <summary>
///// Services associated with a DNS handle
///// </summary>
///// <param name="Handle"></param>
//public record DnsHandleServices(
//                string Handle) {

//    ///<summary>The set of supported services</summary> 
//    public List<HandleService> Services = [];

//    ///<summary>Contact service declaration.</summary> 
//    public HandleServiceContact Contact { get; set; }

//    ///<summary>Calendar service declaration.</summary> 
//    public HandleServiceCalendar Calendar { get; set; }

//    ///<summary>Mesh service declaration.</summary> 
//    public HandleServiceMesh Mesh { get; set; }

//    ///<summary>Oauth service declaration.</summary> 
//    public HandleServiceOauth Oauth { get; set; }

//    ///<summary>ATprotocol service declaration.</summary> 
//    public HandleServiceAtprotocol Atprotocol { get; set; }

//    ///<summary>Http service declaration.</summary> 
//    public HandleServiceHttp Http { get; set; }

//    /// <summary>
//    /// Add the service <paramref name="service"/> to the services.
//    /// </summary>
//    /// <param name="service">The service to add.</param>
//    public void Add(HandleService service) {
//        if (service != null) { 
//            Services.Add(service);
//            Mesh ??= service as HandleServiceMesh;
//            Oauth ??= service as HandleServiceOauth;
//            Atprotocol ??= service as HandleServiceAtprotocol;
//            Http ??= service as HandleServiceHttp;
//            Contact ??= service as HandleServiceContact;
//            Calendar ??= service as HandleServiceCalendar;
//            }
//        }

//    }

/// <summary>
/// Base class for handle service records.
/// </summary>
public abstract record HandleService {

    ///<summary>The text value of the handle.</summary> 
    public string? Text { get; }

    ///<summary>Dictionary mapping tag entries to the corresponding values.</summary> 
    public Dictionary<string, string> Tags = [];

    /// <summary>
    /// Constructor, create an entry from <paramref name="text"/>
    /// </summary>
    /// <param name="text">The text to create the entry.</param>
    protected HandleService(string? text) {
        Text = text;
        if (text is null) {
            return;
            }

        var parts = text.Split(' ');
        foreach (var part in parts) {
            var index = part.IndexOf('=');

            if (index > 0) {
                var tag = part.Substring(0, index);
                var rest = part.Substring(index + 1);
                Tags.Add(tag, rest);
                }
            }
        }
    }




/// <summary>
/// Mesh service description.
/// </summary>
public record HandleServiceMesh : HandleService {

    ///<summary>The Direct Service Address</summary> 
    public string Dsa { get; set; }

    /// <summary>
    /// Constructor, create an instance from <paramref name="text"/>
    /// </summary>
    /// <param name="text">The TXT record text</param>
    public HandleServiceMesh(string? text = null) : base(text) {
        Tags.TryGetValue("dsa", out var did);
        Dsa = did;
        }

    /// <summary>
    /// Attempt to fetch the Mesh record associated with the handle 
    /// <paramref name="domain"/>.
    /// </summary>
    /// <param name="dnsClient"></param>
    /// <param name="domain">The domain to query.</param>
    /// <returns>The service description.</returns>
    /// <param name="dummy">If true return a dummy result if there is no 
    /// TXT record published, otherwise return null.</param>
    public static async Task<HandleServiceMesh> Fetch(DnsClient dnsClient, string domain, bool dummy = false) {
        var handle = await dnsClient.GetPrefixedTXT(domain, "_mesh");
        var text = handle.FullText();
        if (text is null) {
            return dummy ? new HandleServiceMesh((string)null) : null;
            }

        return new HandleServiceMesh(text);
        }


    }

///// <summary>
///// Oauth service description.
///// </summary>
//public record HandleServiceOauth : HandleService {

//    ///<summary>The Oauth unique identifier.</summary> 
//    public string Did { get; set; }

//    ///<summary>The Oauth service URI</summary> 
//    public string ServiceUri { get; set; }

//    /// <summary>
//    /// Constructor, create an instance from <paramref name="text"/>
//    /// </summary>
//    /// <param name="text">The TXT record text</param>
//    public HandleServiceOauth(string text = null) : base(text) {
//        Tags.TryGetValue("did", out var did);
//        Did = did;
//        Tags.TryGetValue("sm", out var serviceUri);
//        ServiceUri = serviceUri;
//        }

//    ///// <summary>
//    ///// Attempt to fetch the Oauth record associated with the handle 
//    ///// <paramref name="domain"/>.
//    ///// </summary>
//    ///// <param name="domain">The domain to query.</param>
//    ///// <param name="dummy">If true return a dummy result if there is no 
//    ///// TXT record published, otherwise return null.</param>
//    ///// <returns>The service description.</returns>
//    //public static async Task<HandleServiceOauth> Fetch(string domain, bool dummy = false) {
//    //    var handle = await DnsClient.GetPrefixedTXT(domain, "_oauth");
//    //    var text = handle.FullText();
//    //    if (text is null) {
//    //        return dummy ? new HandleServiceOauth((string)null): null;
//    //        }

//    //    return new HandleServiceOauth(text);
//    //    }

//    }

///// <summary>
///// Http service description.
///// </summary>
//public record HandleServiceHttp : HandleService {

//    ///<summary>The HTTP Domain.</summary> 
//    public string Domain { get; set; }

//    /// <summary>
//    /// Constructor, create an instance from <paramref name="text"/>
//    /// </summary>
//    /// <param name="text">The TXT record text</param>
//    public HandleServiceHttp(string text = null) : base(text) {
//        }

//    ///// <summary>
//    ///// Attempt to fetch the Http record associated with the handle 
//    ///// <paramref name="domain"/>.
//    ///// </summary>
//    ///// <param name="domain">The domain to query.</param>
//    ///// <param name="dummy">If true return a dummy result if there is no 
//    ///// TXT record published, otherwise return null.</param>
//    ///// <returns>The service description.</returns>
//    //public static async Task<HandleServiceHttp> Fetch(string domain, bool dummy = false) {
//    //    var handle = await DnsClient.GetPrefixedTXT(domain, "_https");
//    //    var text = handle.FullText();
//    //    if (text is null) {
//    //        return dummy ? new HandleServiceHttp((string)null) { Domain =domain} : null;
//    //        }
//    //    return new HandleServiceHttp(text);
//    //    }

//    }

///// <summary>
///// ATProtocol service description.
///// </summary>
//public record HandleServiceAtprotocol : HandleService {

//    ///<summary>The ATProtocol unique identifier.</summary> 
//    public string Did { get; set; }

//    ///<summary>The ATProtocol service URI</summary> 
//    public string ServiceUri { get; set; }

//    /// <summary>
//    /// Constructor, create an instance from <paramref name="text"/>
//    /// </summary>
//    /// <param name="text">The TXT record text</param>
//    public HandleServiceAtprotocol(string text=null) : base(text) {
//        Tags.TryGetValue("did", out var did);
//        Did = did;
//        Tags.TryGetValue("sm", out var serviceUri);
//        ServiceUri = serviceUri;
//        }

//    ///// <summary>
//    ///// Attempt to fetch the ATProtocol record associated with the handle 
//    ///// <paramref name="domain"/>.
//    ///// </summary>
//    ///// <param name="domain">The domain to query.</param>
//    ///// <param name="dummy">If true return a dummy result if there is no 
//    ///// TXT record published, otherwise return null.</param>
//    ///// <returns>The service description.</returns>
//    //public static async Task<HandleServiceAtprotocol> Fetch(string domain, bool dummy = false) {
//    //    var handle = await DnsClient.GetPrefixedTXT(domain, "_atproto");
//    //    var text = handle.FullText();

//    //    if (text is null) {
//    //        return dummy ? new HandleServiceAtprotocol((string)null): null;
//    //        }

//    //    return new HandleServiceAtprotocol(text);
//    //    }

//    }


///// <summary>
///// Contact service description.
///// </summary>
//public record HandleServiceContact : HandleService {

//    ///<summary>Link to the Contact data</summary> 
//    public string Uri { get; set; }

//    ///<summary>Update notification service</summary> 
//    public string Update { get; set; }

//    /// <summary>
//    /// Constructor, create an instance from <paramref name="text"/>
//    /// </summary>
//    /// <param name="text">The TXT record text</param>
//    public HandleServiceContact(string text = null) : base(text) {
//        Tags.TryGetValue("uri", out var uri);
//        Uri = uri;
//        Tags.TryGetValue("update", out var update);
//        Update = update;
//        }

//    ///// <summary>
//    ///// Attempt to fetch the Contact record associated with the handle 
//    ///// <paramref name="domain"/>.
//    ///// </summary>
//    ///// <param name="domain">The domain to query.</param>
//    ///// <param name="dummy">If true return a dummy result if there is no 
//    ///// TXT record published, otherwise return null.</param>
//    ///// <returns>The service description.</returns>
//    //public static async Task<HandleServiceContact> Fetch(string domain, bool dummy = false) {
//    //    var handle = await DnsClient.GetPrefixedTXT(domain, "_jscontact");
//    //    var text = handle.FullText();

//    //    if (text is null) {
//    //        return dummy ? new HandleServiceContact((string)null) : null;
//    //        }

//    //    return new HandleServiceContact(text);
//    //    }

//    }

///// <summary>
///// ATProtocol service description.
///// </summary>
//public record HandleServiceCalendar : HandleService {

//    ///<summary>Link to the calendar data</summary> 
//    public string Uri { get; set; }

//    ///<summary>Update notification service</summary> 
//    public string Update { get; set; }

//    /// <summary>
//    /// Constructor, create an instance from <paramref name="text"/>
//    /// </summary>
//    /// <param name="text">The TXT record text</param>
//    public HandleServiceCalendar(string text = null) : base(text) {
//        Tags.TryGetValue("uri", out var uri);
//        Uri = uri;
//        Tags.TryGetValue("update", out var update);
//        Update = update;
//        }

//    ///// <summary>
//    ///// Attempt to fetch the calendar record associated with the handle 
//    ///// <paramref name="domain"/>.
//    ///// </summary>
//    ///// <param name="domain">The domain to query.</param>
//    ///// <param name="dummy">If true return a dummy result if there is no 
//    ///// TXT record published, otherwise return null.</param>
//    ///// <returns>The service description.</returns>
//    //public static async Task<HandleServiceCalendar?> Fetch(string domain, bool dummy = false) {
//    //    var handle = await DnsClient.GetPrefixedTXT(domain, "_jscalendar");
//    //    var text = handle.FullText();

//    //    if (text is null) {
//    //        return dummy ? new HandleServiceCalendar((string)null) : null;
//    //        }
//    //    return new HandleServiceCalendar(text);
//    //    }

//    }
