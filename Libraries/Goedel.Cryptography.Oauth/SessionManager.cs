
using Goedel.ASN;
using Goedel.Discovery;
using Goedel.IO;

using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.Json.Nodes;
using System.Xml;

namespace Goedel.Cryptography.Oauth;


/// <summary>
/// Generic cached data class.
/// </summary>
/// <typeparam name="T">The type of data to cache.</typeparam>
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

/// <summary>
/// Resolution delegate.
/// </summary>
/// <typeparam name="K">The key type</typeparam>
/// <typeparam name="T">The resolved data type</typeparam>
/// <param name="key">The key.</param>
/// <param name="last">The previous value of the data or null if newly created.</param>
/// <returns></returns>
public delegate Task<T?> ResolutionDelegate<K,T> (
            K key, 
            CachedDocument<T>? last = null);

/// <summary>
/// A document cache.
/// </summary>
/// <typeparam name="K">The key type</typeparam>
/// <typeparam name="T">The resolved data type</typeparam>
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

    /// <summary>
    /// Attempt to obtain a document corresponding to the key <paramref name="key"/>
    /// </summary>
    /// <param name="key">The document key to resolve.</param>
    /// <returns>The value if found, otherwise null.</returns>
    public async Task<T?> GetValueAsync(K key) {
        if (Dictionary.TryGetValue(key, out var handle)) {
            if (handle.Refreshed + Expire > DateTime.UtcNow) { 
                // Value has not expired.
                handle.AccessedThis++;
                return handle.Value;
                }
            var newData = await Resolver(key, handle);
            if (newData != null){ 
                // Resolution succeeded.
                handle.Value = newData;
                handle.Refreshed = DateTime.UtcNow;
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
                Refreshed = DateTime.UtcNow
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

    /// <summary>The DNS client.</summary>
    public DnsClient DnsClient { get; init; } = DnsClient.Default;

    DocumentCache<string, DidDocument> DidDictionary { get; }
    DocumentCache<string, ResourceServerMetadata> ResourceServerDictionary { get; }
    DocumentCache<string, AuthorizationServerMetadata> AuthServerDictionary { get; }


    #endregion

    #region // Constructors

    /// <summary>
    /// Constructor returning a new instance
    /// </summary>
    public SessionManager() {
        DidDictionary = new(TryResolveDid);
        ResourceServerDictionary = new(TryResolveResourceServer);
        AuthServerDictionary = new(TryResolveAuthServer);
        }

    #endregion
    #region // Methods

    /// <summary>
    /// Attempt resolution of the handle <paramref name="handle"/> to a DID Document.
    /// </summary>
    /// <param name="handle"></param>
    /// <returns></returns>
    public async Task<DidDocument> TryResolveDid(string handle) => await DidDictionary.GetValueAsync(handle);

    /// <summary>
    /// Attempt resolution of the DID <paramref name="key"/>
    /// </summary>
    /// <param name="key">The DID to resolve</param>
    /// <param name="last">The result of the last resolution, if existing.</param>
    /// <returns>The DID document if found, otherwise null.</returns>
    async Task<DidDocument?> TryResolveDid(
                string key, 
                CachedDocument<DidDocument>? last) {

        var did = await DnsClient.ResolveAtHandle(key);

        var uri = "https://plc.directory/" + did.Identifier;

        Screen.WriteLine($"Resolve DID {uri}");
        var result = await UriClient.DownloadByteArrayAsync(uri);

        var didDocument = Protocol.JsonObject.StreamParseTag<DidDocument>(result, false);

        return didDocument;
        }

    /// <summary>
    /// Attempt resolution of the resource server specified in  <paramref name="document"/>
    /// </summary>
    /// <param name="document">The DID Document to resolve</param>
    /// <returns>The DID document if found, otherwise null.</returns>
    public async Task<ResourceServerMetadata?> TryResolveResourceServer(DidDocument document) {

        if (!document.Service.TryGetValue("#atproto_pds", out var service)) {
            return null;
            }

        var result = await ResourceServerDictionary.GetValueAsync(service.ServiceEndpoint);



        return result;
        }

    /// <summary>
    /// Attempt resolution of the resource server specified by <paramref name="key"/>
    /// </summary>
    /// <param name="key">The URI to resolve</param>
    /// <param name="last">The result of the last resolution, if existing.</param>
    /// <returns>The Resource Server Metadata if found, otherwise null.</returns>
    async Task<ResourceServerMetadata?> TryResolveResourceServer(
            string key,
            CachedDocument<ResourceServerMetadata>? last) {
        var uri = key.AddPath(".well-known/oauth-protected-resource");

        var result = await UriClient.DownloadByteArrayAsync(uri);
        var asText = result.ToUTF8();
        var resourceMeta = Protocol.JsonObject.StreamParseTag<ResourceServerMetadata>(result, false);

        return resourceMeta;
        }

    /// <summary>
    /// Attempt resolution of the auth server specified by <paramref name="key"/>
    /// </summary>
    /// <param name="key">The URI to resolve</param>
    /// <returns>The Authorization Server Metadata if found, otherwise null.</returns>
    public async Task<AuthorizationServerMetadata?> TryResolveAuthServer(string key) => 
                    await AuthServerDictionary.GetValueAsync(key);

    async Task<AuthorizationServerMetadata?> TryResolveAuthServer(
            string key,
            CachedDocument<AuthorizationServerMetadata>? last) {
        var uri = key.AddPath(".well-known/oauth-authorization-server");

        var result = await UriClient.DownloadByteArrayAsync(uri);
        var authMeta = Protocol.JsonObject.StreamParseTag < AuthorizationServerMetadata>(result, false);

        return authMeta;
        }

    /// <summary>
    /// Attempt resolution of the handle <paramref name="handle"/> and return the result.
    /// </summary>
    /// <param name="handle">The handle to resolve.</param>
    /// <returns>Object containing the result of the resolution.</returns>
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
        //Screen.WriteLine("# DidDocument");
        //Screen.WriteLine(result.DidDocument.ToString());

        //Screen.WriteLine("# ResourceServerMetadata");
        //Screen.WriteLine(result.ResourceServerMetadata.ToString());

        //Screen.WriteLine("# AuthorizationServerMetadata");
        //Screen.WriteLine(result.AuthorizationServerMetadata.ToString());

        return result;
        }
    #endregion
    }


/// <summary>
/// Result of resolving the handle <paramref name="Handle"/>
/// </summary>
/// <param name="Handle">The handle resolved.</param>
public record OauthHandleResolution(
            string Handle
            ) {

    ///<summary>The DID document corresponding to the handle.</summary> 
    public DidDocument? DidDocument = null;

    ///<summary>The resource server metadata</summary> 
    public ResourceServerMetadata? ResourceServerMetadata = null;

    ///<summary>The authorization server metadata.</summary> 
    public AuthorizationServerMetadata? AuthorizationServerMetadata = null;
    }

