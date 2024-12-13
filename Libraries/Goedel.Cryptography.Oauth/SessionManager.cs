
using Goedel.ASN;
using Goedel.Discovery;
using Goedel.IO;

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
    public static Did  HandleToDid(string handle) {
        //var r2 = DnsClient.ResolveServiceAsync("example.com", "mmm");


        var atproto = "_atproto." + handle;

        var result = DnsClient.ResolveAtHandle(atproto).Sync();


        return result;
        }


    public static DidDocument Resolve(DidPlc did) {


        var client = UriClient.HttpClient;
        var uri = "https://plc.directory/" + did.Identifier;

        var result = client.GetStringAsync(uri).Sync();
        Console.WriteLine(result);


        //var document = Serialization<DidDocument>.Deserialize(result);

        using var jsonReader = new JsonReader(result);
        var doc2 = DidDocument.FromJson(jsonReader, false);

        return doc2;


        }







    #endregion
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
