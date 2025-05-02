using Goedel.Cryptography;
using Goedel.Cryptography.Nist;

using System.Net.WebSockets;

namespace Goedel.Contacts;





/// <summary>
/// Convenience class collecting together related parts of a <see cref="JsContact"/>.
/// </summary>
public record AnalysizedContact {

    ///<summary>Service groups this entry is a member of.</summary> 
    public List<OnlineService> Parents { get; } = [];

    ///<summary>Services that are members of this service groups.</summary> 
    public List<OnlineService> Children { get; } = [];


    ///<summary>Email addresses as an <see cref="OnlineService"/></summary> 
    public List<OnlineService> Emails { get; } = [];

    ///<summary>Services of type HTTP or HTTPS</summary> 
    public List<OnlineService> Webs { get; } = [];

    ///<summary>Mesh services</summary> 
    public List<OnlineService> Mesh { get; } = [];

    ///<summary>Groups</summary> 
    public List<OnlineService> Groups { get; } = [];

    ///<summary>Services of type SSH</summary> 
    public List<OnlineService> Ssh { get; } = [];

    ///<summary>Services of type credential</summary> 
    public List<OnlineService> Credentials{ get; } = [];

    ///<summary>Services not included in any other category.</summary> 
    public List<OnlineService> Other { get; } = [];
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

    /// <summary>
    /// Create a  contact of the specified kind with the Version, Created and Updated
    /// fields filled.
    /// </summary>
    /// <param name="kind"></param>
    /// <returns>The created contact.</returns>
    public static JsContact Create(
                string kind = null) {

        return new JsContact() {
            Version = "1.0",
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Kind = kind,

            Uid = Udf.Nonce(),
            Language = "en",
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
        Emails ??= [];
        OnlineServices ??= [];
        CryptoKeys ??= [];

        Analysis = new();

        var worklist = new Dictionary<string,OnlineService>();


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
                Groups = email.Groups,
                Analysis = new()
                };
            worklist.Add(service.Key, service);
            }

        foreach (var pair in OnlineServices) {
            var service = pair.Value;
            service.Analysis = new();

            service.Key = pair.Key;
            if (CryptoKeys.TryGetValue(service.Key, out var cryptoKey)) {
                service.CryptoKey = cryptoKey;
                }

            worklist.Add(service.Key, service);
            }

        foreach (var pair in worklist) {
            var item = pair.Value;
            if (item.Groups != null && item.Groups.Count > 0) {
                foreach (var member in item.Groups) {
                    if (CheckNotCyclic(worklist, item) & worklist.TryGetValue(member, out var parent)) {
                        AnalyzeService(parent.Analysis, item);

                        parent.Analysis.Children.Add(item);
                        item.Analysis.Parents.Add(parent);
                        }
                    }
                }
            else {
                AnalyzeService(Analysis, item);
                Analysis.Children.Add(item);
                }
            }
        }


    static bool CheckNotCyclic(
                    Dictionary<string, OnlineService> worklist,
                    OnlineService service,
                    string? key = null) {
        key ??= service.Key;

        if (service.Groups is null || service.Groups.Count == 0) {
            return true;
            }

        foreach (var member in service.Groups) {
            if (member == key) {
                return false;
                }
            if (worklist.TryGetValue(member, out var parent)) {
                if (!CheckNotCyclic(worklist, parent, key)) {
                    return false;
                    }
                }
            }
        return true;
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

    ///<summary>The dictionary key (filled by calling Analyze)</summary> 
    public string Key { get; set; }


    public AnalysizedContact Analysis { get; set; }
    }


public partial class OnlineService {

    ///<summary>The dictionary key (filled by calling Analyze)</summary> 
    public string Key { get; set; }

    ///<summary>The associated <see cref="CryptoKey"/> entry.</summary> 
    public CryptoKey CryptoKey { get; set; }

    ///<summary>Analysis of the service parent and children.</summary> 
    public AnalysizedContact Analysis { get; set; }

    }