//using Goedel.Discovery;

//using System.Reflection.Metadata;

//namespace Goedel.Mesh.Client;



///// <summary>
///// Base class for EARL Clients
///// </summary>
//public abstract class EarlClient {

//    public DnsClient DnsClient { get; }


//    //public static EarlClient Client { get; set; } = new EarlClientHttp();


//    public EarlClient(DnsClient dnsClient) {
//        DnsClient = dnsClient;
//        }

//    /// <summary>
//    /// Compute the Well Known service prefix.
//    /// </summary>
//    /// <param name="instance">If not null, a service variation prefix used to 
//    /// separate multiple test instances on same service.</param>
//    /// <returns></returns>
//    public static string GetPrefix(string? instance = null) => (instance) == null ?
//            "/.well-known/earl/" : $"/.well-known/earl/{instance}/";

//    /// <summary>
//    /// Attempt to resolve an EARL
//    /// </summary>
//    /// <param name="authority">The EARL authoritah</param>
//    /// <param name="locator">The locator section.</param>
//    /// <returns>If successfull, the EARL ciphertext, otherwise null.</returns>
//    public abstract Task<byte[]> TryGetValue(
//            string authority,
//            string locator);


//    public async Task<T> TryResolveEarl<T>(string uriString) where T : JsonObject{
//        LogFile.WriteLine($"Resolve earl {uriString}");


//        var uri = new Uri(uriString);
//        var earl = uri.AbsolutePath[1..];

//        var locator = Udf.EarlLocator(earl);
//        var ciphertext = await TryGetValue(uri.Authority, earl);

//        var plaintext = Udf.GetDecryptedData(ciphertext, earl);

//        var (contentMeta, enveloped) = EarlEnvelopeReader.Parse(plaintext);

//        Console.WriteLine(enveloped.ToUTF8());
//        LogFile.WriteLine($"Success earl {uriString}");
//        return JsonObject.StreamParse<T>(enveloped);
//        }

//    public async Task<T> TryResolveHandle<T>(string handle, string prefix) where T : JsonObject {
//        LogFile.WriteLine($"Resolve handle {handle}, {prefix}");

//        // need to reduce handle here to a domain.

//        var domain = ParsedHandle.GetDomain(handle);


//        LogFile.WriteLine($"Get prefixed {domain}, {prefix}");
//        var txt = await DnsClient.GetPrefixedTXT(domain, prefix);

//        if (txt is null) {
//            return null;
//            }


//        var text = txt.FullText();
//        LogFile.WriteLine($" TXT prefixed {domain}, {prefix} -> {text}");


//        var earl = GetTag(text, MediaTypes.EarlTag);

//        var result = await ResolveEarl<T>(earl);

//        LogFile.WriteLine($"Finished handle {handle}, {prefix}");
//        return result;
//        }

//    static string GetTag(string text, string tag) {

//        var parts = text.Split(' ');
//        foreach (var part in parts) {
//            var index = part.IndexOf('=');

//            if (index > 0) {
//                if (part.Substring(0, index) == tag) {
//                    return part.Substring(index + 1);
//                    }
//                }
//            }
//        return null;
//        }


//    public async Task<string> ResolveMeshService(string handle) {


//        var contact = await ResolveContactHandle(handle);
//        if (contact is null) {
//            return null;
//            }

//        foreach (var service in contact?.OnlineServices.IfEnumerable()) {
//            if (service.Value.Service == ContactConstant.OnlineServiceMesh) {
//                var user = service.Value.User;

//                var parsed = new ParsedHandle(user);

//                switch (parsed.HandleType) {
//                    case HandleType.Domain:
//                    case HandleType.AccountServiceAddress:
//                    case HandleType.DirectServiceAddress:
//                    case HandleType.DirectAccountServiceAddress: {
//                        return parsed.Service;
//                        }
//                    }
//                }

//            }

//        return null;
//        }




//    public  async Task<T> ResolveHandle<T>(string earl, string prefix) where T : JsonObject =>
//            await TryResolveHandle<T>(earl, prefix);
//    public  async Task<T> ResolveEarl<T>(string earl) where T : JsonObject => 
//            await TryResolveEarl<T>(earl);

//    public  async Task<JsContact> ResolveContactHandle(string earl) => 
//            await TryResolveHandle<JsContact>(earl, MediaTypes.JSContactPrefix);
//    public  async Task<JsContact> ResolveContactEarl(string earl) => 
//            await TryResolveEarl<JsContact>(earl);

//    public  async Task<JsDevice> ResolveDeviceHandle(string earl) =>
//            await TryResolveHandle<JsDevice>(earl, MediaTypes.JSDevicePrefix);
//    public  async Task<JsDevice> ResolveDeviceEarl(string earl) =>
//            await TryResolveEarl<JsDevice>(earl);

//    }

///// <summary>
///// EARL client resolving via HTTP.
///// </summary>
///// <param name="Instance"></param>
//public class EarlClientHttp(DnsClient dnsClient, string? Instance = null) : EarlClient (dnsClient) {



//    /// <inheritdoc/>
//    public override async Task<byte[]> TryGetValue(
//            string authority,
//            string locator) {

//        var path = $"http://{authority}/{GetPrefix(Instance)}{locator}";
//        var data = await path.DownloadByteArrayAsync();


//        if (data == null) {
//            throw new NYI();
//            }

//        return data;
//        }

//    }