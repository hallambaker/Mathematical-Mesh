using Goedel.Discovery;

using System.Reflection.Metadata;

namespace Goedel.Mesh;



/// <summary>
/// Base class for EARL resolution Clients
/// </summary>
public abstract class EarlClient {


    DnsClient DnsClient { get; }


    /// <summary>Constructor, returns a new instance using the client <paramref name="dnsClient"/>.</summary>
    /// <param name="dnsClient">The DNS client to use.</param>
    public EarlClient(DnsClient dnsClient=null) {
        DnsClient = dnsClient ?? DnsClient.Default;
        }

    /// <summary>
    /// Compute the Well Known service prefix.
    /// </summary>
    /// <param name="instance">If not null, a service variation prefix used to 
    /// separate multiple test instances on same service.</param>
    /// <returns></returns>
    public static string GetPrefix(string? instance = null) => (instance) == null ?
            "/.well-known/earl/" : $"/.well-known/earl/{instance}/";

    /// <summary>
    /// Attempt to resolve an EARL
    /// </summary>
    /// <param name="authority">The EARL authoritah</param>
    /// <param name="locator">The locator section.</param>
    /// <returns>If successfull, the EARL ciphertext, otherwise null.</returns>
    public abstract Task<byte[]> TryGetValue(
            string authority,
            string locator);


    /// <summary>Attempt to resolve the EARL <paramref name="uriString"/> as a typed JSON
    /// object asynchronously.</summary>
    /// <typeparam name="T">The type of the target data.</typeparam>
    /// <param name="uriString">The EARL uri.</param>
    /// <returns>Task returning the result.</returns>
    public async Task<T> TryResolveEarl<T>(string uriString) where T : JsonObject{
        //LogFile.WriteLine($"Resolve earl {uriString}");


        var uri = new Uri(uriString);
        var earl = uri.AbsolutePath[1..];

        var locator = Udf.EarlLocator(earl);
        var ciphertext = await TryGetValue(uri.Authority, earl);

        var plaintext = Udf.GetDecryptedData(ciphertext, earl);

        var enveloped = VDareEnvelopeReader.GetEnveloped(plaintext);

        //Console.WriteLine(enveloped.Body.ToUTF8());
        //LogFile.WriteLine($"Success earl {uriString}");

        var result =  JsonObject.StreamParse<T>(enveloped.Body);
        result.Envelope = enveloped;
        return result;
        }

    /// <summary>Attempt to resolve the DNS handle <paramref name="handle"/> with prefix
    /// <paramref name="prefix"/> and return the corresponding payload of type <typeparamref name="T"/>
    /// asynchronously.</summary>
    /// <typeparam name="T">The type of the payload data.</typeparam>
    /// <param name="handle">The handle portion.</param>
    /// <param name="prefix">The DNS prefix.</param>
    /// <returns>Task returning the value, if found.</returns>
    public async Task<T> TryResolveHandle<T>(string handle, string prefix) where T : JsonObject {
        //LogFile.WriteLine($"Resolve handle {handle}, {prefix}");

        // need to reduce handle here to a domain.

        var domain = ParsedHandle.GetDomain(handle);


        //LogFile.WriteLine($"Get prefixed {domain}, {prefix}");
        var txt = await DnsClient.GetPrefixedTXT(domain, prefix);

        if (txt is null) {
            return null;
            }


        var text = txt.FullText();
        //LogFile.WriteLine($" TXT prefixed {domain}, {prefix} -> {text}");


        var earl = GetTag(text, MediaTypes.EarlTag);

        var result = await ResolveEarl<T>(earl);

        //LogFile.WriteLine($"Finished handle {handle}, {prefix}");
        return result;
        }

    static string GetTag(string text, string tag) {

        var parts = text.Split(' ');
        foreach (var part in parts) {
            var index = part.IndexOf('=');

            if (index > 0) {
                if (part.Substring(0, index) == tag) {
                    return part.Substring(index + 1);
                    }
                }
            }
        return null;
        }

    /// <summary>Attempt to resolve the mesh service for <paramref name="handle"/></summary>
    /// <param name="handle">Handle of the Mesh Service user.</param>
    /// <returns>The Mesh service.</returns>
    public async Task<string> ResolveMeshService(string handle) {


        var contact = await ResolveContactHandle(handle);
        if (contact is null) {
            return null;
            }

        foreach (var service in contact?.OnlineServices.IfEnumerable()) {
            if (service.Value.Service == ContactConstant.OnlineServiceMesh) {
                var user = service.Value.User;

                var parsed = new ParsedHandle(user);

                switch (parsed.HandleType) {
                    case HandleType.Domain:
                    case HandleType.AccountServiceAddress:
                    case HandleType.DirectServiceAddress:
                    case HandleType.DirectAccountServiceAddress: {
                        return parsed.Service;
                        }
                    }
                }

            }

        return null;
        }

    /// <summary>Attempt to resolve the mesh service for <paramref name="handle"/></summary>
    /// <param name="handle">Handle of the Mesh Service user.</param>
    /// <returns>The Mesh service.</returns>
    public async Task<string> ResolveMeshService(ParsedHandle handle) {
        switch (handle.HandleType) {
            // Just return the service component
            case HandleType.Domain:
            case HandleType.AccountServiceAddress:
            case HandleType.DirectServiceAddress:
            case HandleType.DirectAccountServiceAddress: {
                return handle.Service;
                }

            // For a DNS handle, we have to first resolve to get the DirectServiceAddress
            case HandleType.DnsHandle:
            case HandleType.DirectDnsHandle: {
                return await ResolveMeshService(handle.Name);
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


    ///// <summary>Attempt to resolve the EARL <paramref name="earl"/> with prefix
    ///// <paramref name="prefix"/></summary>
    ///// <typeparam name="T">The object type</typeparam>
    ///// <param name="earl">The EARL</param>
    ///// <param name="prefix">The prefix</param>
    ///// <returns></returns>
    //public  async Task<T> ResolveHandle<T>(string earl, string prefix) where T : JsonObject =>
    //        await TryResolveHandle<T>(earl, prefix);

    /// <summary>Attempt to resolve the EARL <paramref name="earl"/> as an object of type
    /// <typeparamref name="T"/>.</summary>
    /// <typeparam name="T">The object type</typeparam>
    /// <param name="earl">The EARL</param>
    /// <returns>The EARL resolved as a JSON object of type T.</returns>
    public async Task<T> ResolveEarl<T>(string earl) where T : JsonObject => 
            await TryResolveEarl<T>(earl);

    /// <summary>Resolve the handle <paramref name="dns"/> as a JSContact.</summary>
    /// <param name="dns">The URI of the content.</param>
    /// <returns>The decoded data</returns>
    public  async Task<JsContact> ResolveContactHandle(string dns) => 
            await TryResolveHandle<JsContact>(dns, MediaTypes.JSContactPrefix);

    /// <summary>Resolve the URI <paramref name="earl"/> as a JSContact.</summary>
    /// <param name="earl">The URI of the content.</param>
    /// <returns>The decoded data</returns>
    public async Task<JsContact> ResolveContactEarl(string earl) => 
            await TryResolveEarl<JsContact>(earl);

    /// <summary>Resolve the handle <paramref name="dns"/> as a JSDevice.</summary>
    /// <param name="dns">The URI of the content.</param>
    /// <returns>The decoded data</returns>
    public async Task<JsDevice> ResolveDeviceHandle(string dns) =>
            await TryResolveHandle<JsDevice>(dns, MediaTypes.JSDevicePrefix);

    /// <summary>Resolve the URI <paramref name="earl"/> as a JSDevice.</summary>
    /// <param name="earl">The URI of the content.</param>
    /// <returns>The decoded data</returns>
    public async Task<JsDevice> ResolveDeviceEarl(string earl) =>
            await TryResolveEarl<JsDevice>(earl);

    }

/// <summary>
/// EARL client resolving via HTTP.
/// </summary>
/// <param name="dnsClient">The DNS client.</param>
/// <param name="Instance">Instance identifier, allows multiple test instances to run concurrently.</param>
public class EarlClientHttp(DnsClient dnsClient, string? Instance = null) : EarlClient (dnsClient) {



    /// <inheritdoc/>
    public override async Task<byte[]> TryGetValue(
            string authority,
            string locator) {

        var path = $"http://{authority}/{GetPrefix(Instance)}{locator}.earl";
        var data = await path.DownloadByteArrayAsync();


        if (data == null) {
            throw new NYI();
            }

        return data;
        }

    }