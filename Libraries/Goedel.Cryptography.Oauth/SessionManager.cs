
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
/// Session manager class, supports OAUTH and other login modes.
/// </summary>
public class SessionManager : Disposable {

    #region // Properties


    Dictionary<string, DidDocument> DidDictionary = new();
    Dictionary<string, AuthorizationServerMetadata> AuthServerDictionary = new();
    #endregion

    #region // Constructors
    public SessionManager() {
        }

    #endregion
    #region // Methods

    /// <summary>
    /// Return the DID associated with the handle <paramref name="handle"/>.
    /// </summary>
    /// <param name="handle"></param>
    /// <returns></returns>
    public DidDocument HandleToDid(string handle) {
        if (DidDictionary.TryGetValue(handle, out var didDocument)) {
            return didDocument;
            }

        var atproto = "_atproto." + handle;
        var did = DnsClient.ResolveAtHandle(atproto).Sync();

        // have to check for Web here?

        var client = UriClient.HttpClient;
        var uri = "https://plc.directory/" + did.Identifier;

        var result = client.GetStringAsync(uri).Sync();
        Console.WriteLine(result);

        using var jsonReader = new JsonReader(result);
        
        didDocument = DidDocument.FromJson(jsonReader, false);

        return didDocument;


        }


    public AuthorizationServerMetadata GetAuthorization(
                DidDocument didDocument
                ) {




        if (AuthServerDictionary.TryGetValue(handle, out var didDocument)) {
            return didDocument;
            }

        throw new NYI();
        }




    #endregion
    }

public partial class DidDocument {

    public bool TryGetService(string key, out DidService service) {
        service = null;
        
        if (Service is null) {
            return false;
            }
        foreach (var item in Service) {
            if (item.Id == key) {
                service = item;
                return true;
                }
            }
        return false;
        }
    
    }


public record OAuth {
    public DidService AtProtoService { get; }
    public ResourceServerMetadata ResourceServer { get; }
    public List<AuthorizationServerMetadata> AuthorizationServers { get; } = new();

    public string ResourceServerEndpoint =>
        AtProtoService?.ServiceEndpoint.AddPath(".well-known/oauth-protected-resource");
    public string AuthorizationServerEndpoint(string server) =>
        server.AddPath(".well-known/oauth-authorization-server");


    public OAuth(DidDocument document) {



        if (document.Service.TryGetValue("#atproto_pds", out var service)) {
            AtProtoService = service;
            }

        var client = UriClient.HttpClient;

        var result1 = client.GetStringAsync(ResourceServerEndpoint).Sync();
        ResourceServer = Serialization<ResourceServerMetadata>.Deserialize(result1);

        foreach (var authServer in ResourceServer.AuthorizationServers) {

            var endpoint = AuthorizationServerEndpoint(authServer);

            var result2 = client.GetStringAsync(endpoint).Sync();
            using var jsonReader = new JsonReader(result2);
            var authServerData = AuthorizationServerMetadata.FromJson(jsonReader, false);

            AuthorizationServers.Add(authServerData);
            }



        }

    }
