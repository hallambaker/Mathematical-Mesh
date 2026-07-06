using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Nist;

using Microsoft.Extensions.Hosting;

using System.Globalization;
using System.Net.WebSockets;
using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Contacts;


public partial class NameComponent {

    /// <summary>Default constructor, returns an instance used by the deserializer.</summary>
    public NameComponent() {
        }

    /// <summary>Return a new name component of <paramref name="kind"/>,
    /// <paramref name="value"/>.</summary>
    /// <param name="kind">The component kind.</param>
    /// <param name="value">The component value.</param>
    public NameComponent(
                string kind, 
                string value) {
        Kind = kind;
        Value = value;
        }

    }

public partial class JsContact {

    ///<summary>Used during analysis to track services claiming to be part 
    ///of a service group.</summary> 
    public Dictionary<string, List<string>> GroupClaim { get; } = [];

    ///<summary>Analyzed version of the contact. Note that this is not synchronized
    ///and so a new call must be made to <see cref="Analyze"/></summary> 
    public AnalysizedContact Analysis { get; set; }


    #region // Constructors and Factory methods
    /// <summary>
    /// Returns a new instance.
    /// </summary>
    public JsContact() {
        }
    
    /// <summary>Constructor, returning a new instance of <paramref name="kind"/> in
    /// language <paramref name="language"/>.</summary>
    /// <param name="kind">The kind of contact.</param>
    /// <param name="language">The contact language.</param>
    public JsContact(
                string kind,
                string language="en") {

        var now = DateTime.Now;
        Version = "1.0";
        Created = now;
        Updated = now;
        Kind = kind;

        Uid = Udf.Nonce();
        Language = language;
        }


    /// <summary>
    /// Create a  contact of the specified kind with the Version, Created and Updated
    /// fields filled.
    /// </summary>
    /// <param name="kind">Contact kind.</param>
    /// <param name="first">The contact's first name.</param>
    /// <param name="last">The contact's last name.</param>
    /// <returns>The created contact.</returns>
    public static JsContact Create(
                string kind = "individual",
                string first = null,
                string last = null) {
        Name name = null;
        if (first != null | last != null) {
            name = new() {
                Components = []
                };
            }
        if (first != null) {
            name.Components.Add(new () {
                Kind = "given",
                Value = first
                });
            }
        if (last != null) {
            name.Components.Add(new() {
                Kind = "surname",
                Value = last
                });
            }

        return new JsContact(kind) {
            Name = name
            };


        }

    /// <summary>
    /// Create an individual contact for <paramref name="fullname"/> of gender
    /// <paramref name="gender"/>.
    /// </summary>
    /// <param name="fullname">Full name</param>
    /// <param name="gender">Gender, "masculine", "feminine", "inanimate", "animate", etc. </param>
    /// <returns>The created card.</returns>
    public static JsContact Individual(
            string fullname, string gender) {

        var pronouns = gender switch {
            "masculine" => "he/him",
            "feminine" => "she/her",
            _ => "they/them"
            };

        var result = Create("individual");

        result.Name = new() {
            Full = fullname
            };

        if (pronouns != null) {
            result.SpeakToAs = new SpeakToAs {
                GrammaticalGender = gender,
                Pronouns = new() {
                        { "p1", new() {
                            Values = pronouns
                            } }
                    }
                };
            }

        if (fullname != null) {
            }


        return result;
        }



    #endregion


    int count = 0;
    string GetId() => $"id-{count++}";

    /// <summary>Add an email address to the contact.</summary>
    /// <param name="emailAddress">The email address.</param>
    /// <param name="openPgp">The OpenPGP credential.</param>
    /// <param name="smime">The S/MIME credential.</param>
    /// <param name="id">Unique identifier of the entry.</param>
    /// <returns>The created entry</returns>
    public EmailAddress AddEmail(
                string emailAddress,
                byte[] openPgp=null,
                byte[] smime = null,
                string id = null) {
        id ??= GetId();

        var result = new EmailAddress() {
            Address = emailAddress
            };
        if (openPgp != null) {
            result.CryptoKeyIds ??= [];
            AddCryptoKey (result.CryptoKeyIds, ContactConstant.OnlineServiceOpenPgp,
                credential:openPgp);
            }
        if (smime != null) {
            result.CryptoKeyIds ??= [];
            AddCryptoKey(result.CryptoKeyIds, ContactConstant.OnlineServiceSmime,
                credential:smime);
            }

        Emails ??= [];
        Emails.Add(id, result);

        return result;
        }


    /// <summary>Add a Web resource to the contact.</summary>
    /// <param name="uri">The Web site URI.</param>
    /// <param name="contexts">The contexts in which the resource is used.</param>
    /// <param name="id">Unique identifier of the entry.</param>
    /// <returns>The created entry</returns>
    public OnlineService AddWeb(
            string uri,
            List<string> contexts=null,
            string id = null) {
        id ??= GetId();

        var result = new OnlineService() {
            Service = ContactConstant.OnlineServiceWeb,
            Uri = uri,
            Contexts=GetContexts(contexts)
            };

        OnlineServices ??= [];
        OnlineServices.Add(id, result);

        return result;
        }

    /// <summary>Add an SSH resource to the contact.</summary>
    /// <param name="authenticate">The authentication public keys</param>
    /// <param name="contexts">The contexts in which the resource is used.</param>
    /// <param name="id">Unique identifier of the entry.</param>
    /// <returns>The created entry</returns>
    public OnlineService AddSsh(
            List<KeyPair> authenticate = null,
            List<string> contexts = null,
            string id = null) {
        id ??= GetId();
        var result = new OnlineService() {
            Service = ContactConstant.OnlineServiceSsh,
            Contexts = GetContexts(contexts)
            };

        result.CryptoKeyIds ??= [];
        AddCryptoKeys(result.CryptoKeyIds, authenticate, ContactConstant.CryptoKeySign);

        OnlineServices ??= [];
        OnlineServices.Add(id, result);

        return result;
        }

    /// <summary>Add a Mesh resource to the contact.</summary>
    /// <param name="profile">The Mesh profile</param>
    /// <param name="contexts">The contexts in which the resource is used.</param>
    /// <param name="id">Unique identifier of the entry.</param>
    /// <returns>The created entry</returns>
    public OnlineService AddMesh(
            byte[] profile,
            List<string> contexts = null,
            string id = null) {
        id ??= GetId();
        var result = new OnlineService() {
            Service = ContactConstant.OnlineServiceMesh,
            Contexts = GetContexts(contexts)
            };
        result.CryptoKeyIds ??= [];
        AddCryptoKey(result.CryptoKeyIds, ContactConstant.OnlineServiceMesh,
            credential: profile);

        OnlineServices ??= [];
        OnlineServices.Add(id, result);

        return result;
        }

    /// <summary>Add a Git entry to the contact.</summary>
    /// <param name="signing">The set of commit siognature keys</param>
    /// <param name="contexts">The contexts in which the resource is used.</param>
    /// <param name="id">Unique identifier of the entry.</param>
    /// <returns>The created entry</returns>
    public OnlineService AddGit(
            List<KeyPair> signing=null,
            List<string> contexts = null,

            string id = null) {
        id ??= GetId();
        var result = new OnlineService() {
            Service = ContactConstant.OnlineServiceGit,
            Contexts = GetContexts(contexts)
            };

        result.CryptoKeyIds ??= [];
        AddCryptoKeys(result.CryptoKeyIds, signing, ContactConstant.CryptoKeySign);

        OnlineServices ??= [];
        OnlineServices.Add(id, result);

        return result;
        }

    /// <summary>Add an update entry to the contact</summary>
    /// <param name="protocol">The update protocol.</param>
    /// <param name="uri">The URI</param>
    /// <param name="verification">The verification keys.</param>
    /// <param name="contexts">The contexts in which the resource is used.</param>
    /// <param name="id">Unique identifier of the entry.</param>
    /// <returns>The created entry</returns>
    public Update AddUpdate(
            string protocol,
            string uri,
            List<KeyPair> verification,
            List<string> contexts = null,
            string id = null) {

        id ??= GetId();
        var result = new Update() {
            Protocol = protocol,
            Uri = uri,
            Contexts = GetContexts(contexts)
            };

        result.CryptoKeyIds ??= [];
        AddCryptoKeys(result.CryptoKeyIds, verification, ContactConstant.CryptoKeySign);

        Updates ??= [];
        Updates.Add(id, result);

        return result;
        }

    /// <summary>Add a service entry to the contact.</summary>
    /// <param name="protocol">The service protocol.</param>
    /// <param name="contexts">The contexts in which the resource is used.</param>
    /// <param name="id">Unique identifier of the entry.</param>
    /// <returns>The created entry</returns>
    public OnlineService AddService(
            string protocol,
            List<string> contexts = null,
            string id = null) {

        id ??= GetId();
        var result = new OnlineService() {

            Contexts = GetContexts(contexts)
            };

        OnlineServices ??= [];
        OnlineServices.Add(id, result);

        return result;
        }

    /// <summary>Add a set of cryptographic keys to the contact.</summary>
    /// <param name="cryptoKeyIds">Dictionary mapping resource identifiers to keys..</param>
    /// <param name="keys">The keys to add.</param>
    /// <param name="use">The use of the key.</param>
    public void AddCryptoKeys(
            Dictionary<string,string> cryptoKeyIds,
            List<KeyPair> keys,
            string use) {
        foreach (var key in keys.IfEnumerable()) {
            AddCryptoKey(cryptoKeyIds, use, key);
            }
        }

    /// <summary>Add a cryptographic key to the contact.</summary>
    /// <param name="cryptoKeyIds">Dictionary mapping resource identifiers to keys..</param>
    /// <param name="key">The key to add.</param>
    /// <param name="use">The use of the key.</param>
    /// <param name="credential">Credential validating the key.</param>
    /// <param name="mediaType">The media type of the credential.</param>
    public CryptoKey AddCryptoKey(
            Dictionary<string, string> cryptoKeyIds,
            string use,
            KeyPair key=null,
            byte[] credential=null,
            string mediaType = null) {

        var id = GetId();
        var jwks = new JsonWebKeySet() {
            Data=credential,
            MediaType = mediaType
            };

        if (key != null) {
            // make sure we only have the public component.
            var keyPublic = key.PublicOnly ? key : key.KeyPairPublic();
            var jwk = JWK.Factory(keyPublic);
            jwks.JsonWebKeys = [jwk];
            }

        cryptoKeyIds.Add(id, use);
        CryptoKeys ??= [];
        CryptoKeys.Add(id, jwks);

        return null;
        }

    /// <summary>Add media to the contact.</summary>
    /// <param name="uri"></param>
    /// <param name="mediaType"></param>
    /// <param name="kind"></param>
    /// <returns>The created entry</returns>
    public Media AddMedia(
                string uri,
                string mediaType=null,
                string kind="photo") {
        var id = GetId();
        var media = new Media() {
            Uri = uri,
            MediaType = mediaType,
            Kind = kind
            };

        Media ??= [];
        Media.Add(id, media);

        // here attempt to resolve the uri and extract the metadata

        return media;
        }


    Dictionary<string, bool>? GetContexts(List<string> contexts) {
        if (contexts.IsEmpty()) {
            return null;
            }
        var result = new Dictionary<string, bool>();
        foreach (var context in contexts) {
            result.Add(context, true);
            }
        return result;
        }

    /// <summary>Add an online service top the contact.</summary>
    /// <param name="service">The service to add</param>
    /// <param name="id">Unique identifier of the entry.</param>
    /// <param name="kind">Service kind.</param>
    /// <param name="data">Service data.</param>
    /// <param name="key">The key</param>
    public void Add(
                OnlineService service,
                string id,
                string kind,
                byte[] data=null,
                KeyPair key=null) {
        service.CryptoKeyIds ??= [];
        service.CryptoKeyIds.Add(id, kind);
        var cryptoKey = new JsonWebKeySet() {
            Data = data,
            Kind=kind
            };
        if (key != null) {
            cryptoKey.JsonWebKeys = [JWK.Factory(key)];
            }
        CryptoKeys ??= [];
        CryptoKeys.Add(id, cryptoKey);
        }





    /// <summary>
    /// Update the contact updated time.
    /// </summary>
    public void Update() {
        Updated = DateTime.UtcNow;
        }


    /// <summary>
    /// Analyze the contact to populate the property <see cref="Analysis"/>
    /// </summary>
    public void Analyze() {

        Analysis = new();



        foreach (var emailPair in Emails) {
            var email = emailPair.Value;
            email.Key = emailPair.Key;

            var service = new OnlineService() {
                Service = "smtp",
                Key = emailPair.Key,
                User = email.Address,
                Contexts = email.Contexts,
                Pref = email.Pref,
                Label = email.Label,
                Analysis = new()
                };
            email.OnlineService = service;
            Analysis.Emails.Add(service);
            }

        foreach (var groupPair in ServiceGroups) {
            var group = groupPair.Value;

            foreach (var memberPair in group.Members) {
                var key = memberPair.Key;

                if (Emails.TryGetValue(key, out var email)) {
                    email.OnlineService.ServiceGroups.Add(group);
                    }
                if (OnlineServices.TryGetValue(key, out var service)) {
                    service.ServiceGroups.Add(group);
                    }
                }
            }


        foreach (var pair in OnlineServices) {
            var service = pair.Value;
            service.Analysis = new();
            service.Key = pair.Key;

            switch (service.Service) {
                case "http": {
                    Analysis.Webs.Add(service);
                    break;
                    }
                case "Mesh": {
                    Analysis.Mesh.Add(service);
                    break;
                    }

                case "ssh": {
                    Analysis.Ssh.Add(service);
                    break;
                    }
                default: {
                    Analysis.Other.Add(service);
                    break;
                    }
                }

            }


        }

    /// <summary></summary>
    /// <param name="service"></param>
    /// <returns></returns>
    public bool MapCryptoKeys(
                    OnlineService service) {

        if (service.CryptoKeyIds == null) {
            return true;
            }
        if (CryptoKeys == null) {
            return service.CryptoKeyIds.Count == 0;
            }
        var found = true;

        service.CryptoKey = [];
        foreach (var id in service.CryptoKeyIds) {
            if (CryptoKeys.TryGetValue(id.Key, out var cryptoKey)) {
                service.CryptoKey.Add(cryptoKey);
                }
            else {
                found = false;
                }

            }

        return found;
        }

    static void AnalyzeService(AnalysizedContact analysis, OnlineService service) {

        switch (service.Service.ToLower()) {
            case "http":
            case "https":
            case "web": {
                analysis.Webs.Add(service);
                break;
                }
            case "smtp": {
                analysis.Emails.Add(service);
                break;
                }
            case "mesh": {
                analysis.Mesh.Add(service);
                break;
                }
            case "credential": {
                analysis.Credentials.Add(service);
                break;
                }
            case "group": {
                analysis.Groups.Add(service);
                break;
                }
            case "ssh": {
                analysis.Ssh.Add(service);
                break;
                }
            default: {
                analysis.Other.Add(service);
                break;
                }
            }

        }

    /// <summary>Get the first Mesh profile entry.</summary>
    /// <returns>The mesh profile entry.</returns>
    public OnlineService? GetMesh() {
        foreach (var pair in OnlineServices.IfEnumerable()) {
            if (pair.Value.Service == ContactConstant.OnlineServiceMesh) {
                return pair.Value;
                }
            }

        return null;
        }

    /// <summary>Construct an EARL over the contact data.</summary>
    /// <returns>The EARL binary data and URI.</returns>
    public EarlSet GetEarlSet() {
        var contentMeta = new ContentMeta() {
            ContentType = MediaTypes.JSContact
            };
        return new EarlSet(contentMeta, ToBytes());
        
        }

    }


public partial class EmailAddress {

    /// <summary>The online service entry.</summary>
    public OnlineService OnlineService { get; set; }

    ///<summary>The dictionary key (filled by calling Analyze)</summary> 
    public string Key { get; set; }


    }


public partial class OnlineService {

    ///<summary>The dictionary key (filled by calling Analyze)</summary> 
    public string Key { get; set; }

    ///<summary>The associated <see cref="CryptoKey"/> entry.</summary> 
    public List<CryptoKey> CryptoKey { get; set; }

    ///<summary>Analysis of the service parent and children.</summary> 
    public AnalysizedContact Analysis { get; set; }

    /// <summary>The service groups.</summary>
    public List<ServiceGroup> ServiceGroups { get; } = [];

    /// <summary>Default constructor for deserialization.</summary>
    public OnlineService () { }


    }


public partial class JsonWebKeySet {


    /// <summary>The Mesh profile bytes.</summary>
    public byte[] MeshProfileBytes => Data;

    }