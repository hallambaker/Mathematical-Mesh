using Goedel.Cryptography;
using Goedel.Cryptography.Nist;

using System.Net.WebSockets;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Contacts;



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
    /// <param name="kind"></param>
    /// <returns>The created contact.</returns>
    public static JsContact Create(
                string kind = "individual",
                string first = null,
                string last = null) {
        Name name = null;
        if (first != null | last != null) {
            name = new() {
                Components = new()
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




    }


public partial class EmailAddress {

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


    public List<ServiceGroup> ServiceGroups { get; } = [];


    public OnlineService () { }

    public OnlineService(
                string user) {

        
        
        }

    }


public partial class JsonWebKeySet {



    public byte[] MeshProfileBytes => Data;

    }