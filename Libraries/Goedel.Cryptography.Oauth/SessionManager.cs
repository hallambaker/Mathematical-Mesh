
using Goedel.ASN;
using Goedel.Discovery;
using Goedel.IO;

using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.Json.Nodes;
using System.Xml;

namespace Goedel.Cryptography.Oauth;


public interface ICache {
    }


public class CachedDocument<T>  {

    ///<summary>The value.</summary> 
    public T Value { get; set; }

    ///<summary>Time the value was last refreshed.</summary> 
    public DateTime Refreshed { get; set; }

    ///<summary>Number of times the item was accessed in the last period.</summary> 
    public int AccessedLast { get; set; } = 0;

    ///<summary>Number of times the item has been accessed this period so far.</summary> 
    public int AccessedThis { get; set; } = 0;

    }


public delegate Task<T?> ResolutionDelegate<K,T> (
            K key, 
            CachedDocument<T>? last = null);


public class DocumentCache<K,T> where T: class?{

    ///<summary>Time after which documents are considered expired</summary> 
    public TimeSpan Expire;

    ///<summary>The cached data.</summary> 
    public Dictionary<K, CachedDocument<T>> Dictionary { get; set; } = new();

    ///<summary>Number of cached items.</summary> 
    public int Count => Dictionary.Count;


    ResolutionDelegate<K,T> Resolver { get; set; }

    /// <summary>
    /// Constructor, returns a new instance using the asynchronous resolver 
    /// <paramref name="resolver"/>.
    /// </summary>
    /// <param name="resolver">The resolver delegate.</param>
    public DocumentCache(
                ResolutionDelegate<K,T> resolver) {
        Resolver = resolver;
        }

    public async Task<T?> GetValueAsync(K key) {
        if (Dictionary.TryGetValue(key, out var handle)) {
            if (handle.Refreshed + Expire > DateTime.Now) { 
                // Value has not expired.
                handle.AccessedThis++;
                return handle.Value;
                }
            var newData = await Resolver(key, handle);
            if (newData != null){ 
                // Resolution succeeded.
                handle.Value = newData;
                handle.Refreshed = DateTime.Now;
                handle.AccessedThis++;
                return handle.Value;
                }

            // Could not resolve, remove value from the dictionary.
            Dictionary.Remove(key); 
            return default;
            }

        var fetchedData = await Resolver(key);
        if (fetchedData != null) { // Resolution succeeded.
            handle = new CachedDocument<T>() {
                Value = fetchedData,
                Refreshed = DateTime.Now
                };
            Dictionary.Add(key, handle);
            return handle.Value;
            }
        return default;
        }

    /// <summary>
    /// Purge the cache. This will require a locking mechanism. Best approach is probably
    /// to create a second sorted dictionary and copy all the items from the first, in batches,
    /// allowing the lock to expire with each lookup. Then copy the elements top be kept back 
    /// again.
    /// </summary>
    /// <param name="maxRemaining">Number of elements to keep. If less than 0, keep
    /// all and only remove items with no accesses since the last purge.</param>
    /// <returns>The number of elements that were purged.</returns>
    public int Purge(int maxRemaining=-1) {
        return 0;
        }


    }


/// <summary>
/// Session manager class, supports OAUTH and other login modes.
/// </summary>
public class SessionManager : Disposable {

    #region // Properties
    DnsClient DnsClient = DnsClient.Default;

    DocumentCache<string, DidDocument> DidDictionary { get; }
    DocumentCache<string, ResourceServerMetadata> ResourceServerDictionary { get; }
    DocumentCache<string, AuthorizationServerMetadata> AuthServerDictionary { get; }


    #endregion

    #region // Constructors
    public SessionManager() {
        DidDictionary = new(TryResolveDid);
        ResourceServerDictionary = new(TryResolveResourceServer);
        AuthServerDictionary = new(TryResolveAuthServer);
        }

    #endregion
    #region // Methods

    /// <summary>
    /// Return the DID associated with the handle <paramref name="handle"/>.
    /// </summary>
    /// <param name="handle"></param>
    /// <returns></returns>
    public  DidDocument HandleToDid(string handle) {
        throw new NYI();
        //if (DidDictionary.GetValueAsync(handle, out var didDocument)) {
        //    return didDocument;
        //    }

        //var atproto = "_atproto." + handle;







        }

    public async Task<DidDocument> TryResolveDid(string handle) => await DidDictionary.GetValueAsync(handle);

    async Task<DidDocument?> TryResolveDid(
                string key, 
                CachedDocument<DidDocument>? last) {

        var did = await DnsClient.ResolveAtHandle(key);

        var uri = "https://plc.directory/" + did.Identifier;

        var result = await UriClient.DownloadStringAsync(uri);

        using var jsonReader = new JsonReader(result);
        var didDocument = DidDocument.FromJson(jsonReader, false);

        return didDocument;
        }


    public async Task<ResourceServerMetadata?> TryResolveResourceServer(DidDocument document) {

        if (!document.Service.TryGetValue("#atproto_pds", out var service)) {
            return null;
            }

        var result = await ResourceServerDictionary.GetValueAsync(service.ServiceEndpoint);



        return result;
        }

    async Task<ResourceServerMetadata?> TryResolveResourceServer(
            string key,
            CachedDocument<ResourceServerMetadata>? last) {
        var uri = key.AddPath(".well-known/oauth-protected-resource");

        var result = await UriClient.DownloadStringAsync(uri);
        using var jsonReader = new JsonReader(result);
        var resourceMeta = ResourceServerMetadata.FromJson(jsonReader, false);

        return resourceMeta;
        }

    public async Task<AuthorizationServerMetadata?> TryResolveAuthServer(string key) => 
                    await AuthServerDictionary.GetValueAsync(key);

    async Task<AuthorizationServerMetadata?> TryResolveAuthServer(
            string key,
            CachedDocument<AuthorizationServerMetadata>? last) {
        var uri = key.AddPath(".well-known/oauth-authorization-server");

        var result = await UriClient.DownloadStringAsync(uri);
        using var jsonReader = new JsonReader(result);
        var authMeta = AuthorizationServerMetadata.FromJson(jsonReader, false);

        return authMeta;
        }


    public async Task<OauthHandleResolution> TryResolveHandle(string handle) {
        var result = new OauthHandleResolution(handle);

        result.DidDocument = await TryResolveDid(handle);
        if (result.DidDocument is not null) {
            result.ResourceServerMetadata = await TryResolveResourceServer(result.DidDocument);
            }
        if ((result.ResourceServerMetadata?.AuthorizationServers != null) &&
            (result.ResourceServerMetadata.AuthorizationServers.Count >0)) {

            result.AuthorizationServerMetadata = 
                await TryResolveAuthServer(result.ResourceServerMetadata.AuthorizationServers[0]);
            }
        return result;
        }
    #endregion
    }


public record OauthHandleResolution(
            string Handle
            ) {

    public DidDocument? DidDocument = null;
    public ResourceServerMetadata? ResourceServerMetadata = null;
    public AuthorizationServerMetadata? AuthorizationServerMetadata = null;
    }


//public record OAuth {
//    public DidService AtProtoService { get; }
//    public ResourceServerMetadata ResourceServer { get; }
//    public List<AuthorizationServerMetadata> AuthorizationServers { get; } = new();

//    public string ResourceServerEndpoint =>
//        AtProtoService?.ServiceEndpoint.AddPath(".well-known/oauth-protected-resource");
//    public string AuthorizationServerEndpoint(string server) =>
//        server.AddPath(".well-known/oauth-authorization-server");


//    public OAuth(DidDocument document) {



//        if (document.Service.TryGetValue("#atproto_pds", out var service)) {
//            AtProtoService = service;
//            }

//        var client = UriClient.HttpClient;

//        var result1 = client.GetStringAsync(ResourceServerEndpoint).Sync();
//        ResourceServer = Serialization<ResourceServerMetadata>.Deserialize(result1);

//        foreach (var authServer in ResourceServer.AuthorizationServers) {

//            var endpoint = AuthorizationServerEndpoint(authServer);

//            var result2 = client.GetStringAsync(endpoint).Sync();
//            using var jsonReader = new JsonReader(result2);
//            var authServerData = AuthorizationServerMetadata.FromJson(jsonReader, false);

//            AuthorizationServers.Add(authServerData);
//            }

//        }

    //}
