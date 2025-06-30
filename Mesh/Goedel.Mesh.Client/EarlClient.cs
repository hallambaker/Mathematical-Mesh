using Goedel.Discovery;

namespace Goedel.Mesh.Client;

/// <summary>
/// Base class for EARL Clients
/// </summary>
public abstract class EarlClient {

    public static EarlClient Client { get; set; } = new EarlClientHttp();

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


    public async Task<T> TryResolveEarl<T>(string uriString) where T : JsonObject{
        var uri = new Uri(uriString);
        var earl = uri.AbsolutePath[1..];

        var locator = Udf.EarlLocator(earl);
        var ciphertext = await TryGetValue(uri.Authority, earl);

        var plaintext = Udf.GetDecryptedData(ciphertext, earl);

        var (contentMeta, enveloped) = EarlEnvelopeReader.Parse(plaintext);

        Console.WriteLine(enveloped.ToUTF8());

        return JsonObject.StreamParse<T>(enveloped);
        }

    public async Task<T> TryResolveHandle<T>(string handle, string prefix) where T : JsonObject {

        // need to reduce handle here to a domain.

        var domain = ParsedHandle.GetDomain(handle);

        var txt = await DnsClient.GetPrefixedTXT(domain, prefix);
        var text = txt.FullText();

        var earl = GetTag(text, MediaTypes.EarlTag);

        return await ResolveEarl<T>(earl);
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

    public static async Task<T> ResolveHandle<T>(string earl, string prefix) where T : JsonObject =>
            await Client.TryResolveHandle<T>(earl, prefix);
    public static async Task<T> ResolveEarl<T>(string earl) where T : JsonObject => 
            await Client.TryResolveEarl<T>(earl);

    public static async Task<JsContact> ResolveContactHandle(string earl) => 
            await Client.TryResolveHandle<JsContact>(earl, MediaTypes.JSContactPrefix);
    public static async Task<JsContact> ResolveContactEarl(string earl) => 
            await Client.TryResolveEarl<JsContact>(earl);

    public static async Task<JsDevice> ResolveDeviceHandle(string earl) =>
            await Client.TryResolveHandle<JsDevice>(earl, MediaTypes.JSDevicePrefix);
    public static async Task<JsDevice> ResolveDeviceEarl(string earl) =>
            await Client.TryResolveEarl<JsDevice>(earl);

    }

/// <summary>
/// EARL client resolving via HTTP.
/// </summary>
/// <param name="Instance"></param>
public class EarlClientHttp(string? Instance = null) : EarlClient {

    /// <inheritdoc/>
    public override async Task<byte[]> TryGetValue(
            string authority,
            string locator) {

        var path = $"http://{authority}/{GetPrefix(Instance)}{locator}";
        var data = await path.DownloadByteArrayAsync();


        if (data == null) {
            throw new NYI();
            }

        return data;
        }

    }