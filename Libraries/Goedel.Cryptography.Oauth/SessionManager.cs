
using Goedel.ASN;
using Goedel.IO;

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


    public static string Resolve(DidPlc did) {


        var client = UriClient.HttpClient;
        var uri = "https://plc.directory/" + did.Identifier;

        var result = client.GetStringAsync(uri).Sync();
        Console.WriteLine(result);
        var node = new DidDocument(result);

        return null;

        }



    #endregion
    }


public record DidDocument {
    public JsonNode Tree { get; }
    public Dictionary<string, DidService> Services { get; private set; }

    public DidDocument(string text) {
        Tree = JsonNode.Parse(text);


        if (Tree is JsonObject root) {
            ParseRoot(root);
            }


        }

    /// <summary>
    /// While .Net provides reflection based deserialization, this breaks with
    /// stripped binaries and so can't be trusted.
    /// </summary>
    /// <param name="root"></param>
    void ParseRoot(JsonObject root) {
        foreach (var field in root) {
            switch (field.Key) {
                case "@context": {
                    break;
                    }
                case "id": {
                    break;
                    }
                case "alsoKnownAs": {
                    break;
                    }
                case "verificationMethod": {
                    break;
                    }
                case "service": {
                    if (field.Value is JsonArray array) {
                        ParseServices(array);
                        }
                    break;
                    }
                }

            }



        }


    void ParseServices(JsonArray array) {
        Services = new();
        foreach (var item in array) {
            if (item is JsonObject service) {
                var didService = new DidService(service);

                Services.Add(didService.Id, didService);
                }
            }
        }

    }

public record DidService {

    public string Id { get; }
    public string Type { get; }
    public string ServiceEndpoint { get; }


    public DidService(JsonObject service) {

        foreach (var field in service) {
            switch (field.Key) {
                case "id": {
                    Id = field.Value.GetString();

                    break;
                    }
                case "type": {
                    Type = field.Value.GetString();

                    break;
                    }
                case "serviceEndpoint": {
                    ServiceEndpoint = field.Value.GetString();

                    break;
                    }
                }


            }
        }

    }

public static class Extensions {

    public static string GetString(this JsonNode node) {
        if (!(node is JsonValue value)) {
            return null;
            }
        if (value.GetValueKind() != System.Text.Json.JsonValueKind.String) {
            return null;
            }
        return value.ToString();

        }

    }