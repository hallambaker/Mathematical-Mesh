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

using Goedel.Cryptography.PKIX;

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

    public string AccountAddress {get; private set;}

    public ParsedHandle ResolvedHandle { get; private set; } = null;

    protected ParsedHandle() {
        }


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
                    HandleType = HandleType.DirectDnsHandle;
                    Fingerprint = at[1];
                    Name = at[2];

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

    public static string Resolve(string handle) {
        var parsed = new ParsedHandle(handle);
        return parsed.Resolve().Sync();
        }


    public async Task<string> Resolve() {

        switch (HandleType) {
            case HandleType.DirectDnsHandle:
            case HandleType.DnsHandle: {
                ResolvedHandle = await ResolveDnsHandle();
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

    public async Task<string> ResolveMeshService() {
        switch (HandleType) {
            // Just return the service component
            case HandleType.Domain: 
            case HandleType.AccountServiceAddress:
            case HandleType.DirectServiceAddress:
            case HandleType.DirectAccountServiceAddress: {
                return Service;
                }

            // For a DNS handle, we have to first resolve to get the DirectServiceAddress
            case HandleType.DnsHandle:
            case HandleType.DirectDnsHandle: {
                var handle = await ResolveDnsHandle();
                return handle?.Service;
                }

            // These all fail because there isn't enough information to resolve a service
            case HandleType.LocalName:
            case HandleType.Invalid:
            case HandleType.Fingerprint: {
                throw new NYI();
                }
            }

        throw new NYI();
        }


    public async Task <ParsedHandle?> ResolveDnsHandle() {

        var meshService = await HandleServiceMesh.Fetch(Name);
        if (meshService == null) {
            return null;
            }


        return new ParsedHandle(meshService.Dsa);


        }
    public async Task<DnsHandleServices> GetServices() => await GetServices(Name);

    public static async Task<DnsHandleServices> GetServices(string handle) {
        var result = new DnsHandleServices(handle);

        var handleTxt = await DnsClient.GetPrefixedTXT(handle, "_handle");

        if (handleTxt == null) {
            result.Add(await HandleServiceMesh.Fetch(handle));
            result.Add(await HandleServiceOauth.Fetch(handle));
            result.Add(await HandleServiceAtprotocol.Fetch(handle));
            result.Add(await HandleServiceHttp.Fetch(handle));
            return result;
            }

        // collect up all the text into one bucket, that is our entry
        var services = handleTxt.FullText().Split (' ');


        foreach (var service in services) {
            switch (service) {

                case "mesh": {
                    result.Add (await HandleServiceMesh.Fetch (handle, true));
                    break;
                    }
                case "oauth": {
                    result.Add(await HandleServiceOauth.Fetch(handle, true));
                    break;
                    }
                case "atproto": {
                    result.Add(await HandleServiceAtprotocol.Fetch(handle, true));
                    break;
                    }
                case "https": {
                    result.Add(await HandleServiceHttp.Fetch(handle, true));
                    break;
                    }
                case "": {
                    break;
                    }
                }
            }

        return result;
        }

    }




public record DnsHandleServices(
                string Handle) {
    public List<HandleService> Services = [];

    public HandleServiceMesh Mesh { get; set; }
    public HandleServiceOauth Oauth { get; set; }
    public HandleServiceAtprotocol Atprotocol { get; set; }
    public HandleServiceHttp Http { get; set; }

    public void Add(HandleService service) {
        if (service != null) { 
            Services.Add(service);
            Mesh ??= service as HandleServiceMesh;
            Oauth ??= service as HandleServiceOauth;
            Atprotocol ??= service as HandleServiceAtprotocol;
            Http ??= service as HandleServiceHttp;

            }

        }



    }


public abstract record HandleService {

    public string? Text { get; }

    public Dictionary<string, string> Tags = [];

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

public record HandleServiceMesh : HandleService {

    public string Dsa { get; set; }

    public HandleServiceMesh(string? text = null) : base(text) {
        }

    public static async Task<HandleServiceMesh> Fetch(string domain, bool dummy=false) {
        var handle = await DnsClient.GetPrefixedTXT(domain, "_mesh");
        var text = handle.FullText();
        if (text is null) {
            return dummy ?  new HandleServiceMesh((string) null): null;
            }

        var result = new HandleServiceMesh(text);
        result.Tags.TryGetValue("dsa", out var did);
        result.Dsa = did;


        return result;
        }


    }

public record HandleServiceOauth : HandleService {
    public string Did { get; set; }
    public string ServiceUri { get; set; }

    public HandleServiceOauth(string text = null) : base(text) {
        }

    public static async Task<HandleServiceOauth> Fetch(string domain, bool dummy = false) {
        var handle = await DnsClient.GetPrefixedTXT(domain, "_oauth");
        var text = handle.FullText();
        if (text is null) {
            return dummy ? new HandleServiceOauth((string)null): null;
            }

        var result = new HandleServiceOauth(text);
        result.Tags.TryGetValue("did", out var did);
        result.Did = did;
        result.Tags.TryGetValue("sm", out var serviceUri);
        result.ServiceUri = serviceUri;

        return result;
        }

    }
public record HandleServiceHttp : HandleService {


    public string Domain { get; set; }

    public HandleServiceHttp(string text = null) : base(text) {
        }

    public static async Task<HandleServiceHttp> Fetch(string domain, bool dummy = false) {
        var handle = await DnsClient.GetPrefixedTXT(domain, "_https");
        var text = handle.FullText();
        if (text is null) {
            return dummy ? new HandleServiceHttp((string)null) { Domain =domain} : null;
            }
        var result = new HandleServiceHttp(text);

        return result;
        }

    }

public record HandleServiceAtprotocol : HandleService {

    public string Did { get; set; }
    public string ServiceUri { get; set; }

    public HandleServiceAtprotocol(string text=null) : base(text) {
        }

    public static async Task<HandleServiceAtprotocol> Fetch(string domain, bool dummy = false) {
        var handle = await DnsClient.GetPrefixedTXT(domain, "_atproto");
        var text = handle.FullText();

        if (text is null) {
            return dummy ? new HandleServiceAtprotocol((string)null): null;
            }

        var result = new HandleServiceAtprotocol(text);
        result.Tags.TryGetValue("did", out var did);
        result.Did = did;
        result.Tags.TryGetValue("sm", out var serviceUri);
        result.ServiceUri = serviceUri;

        return result;
        }

    }
