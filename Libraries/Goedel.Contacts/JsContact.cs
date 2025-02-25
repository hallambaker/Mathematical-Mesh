using Goedel.Cryptography;
using Goedel.Cryptography.Nist;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Contacts;

public record JsContactPersona(
            string Label) {
    
    
    
    }



public enum ServiceType {
    Email,
    Mesh,
    Ssh,
    Code,
    Web,
    Messaging,
    Unknown

    }

public record JsContactService (
            string Label) {

    public virtual ServiceType ServiceType { get; set; } = ServiceType.Unknown;

    public List<OnlineService> OnlineServices { get; } = [];

    public List<string> Accounts { get; } = [];


    public Dictionary<string, CryptoKey> Credentials { get; } = [];


    public JsContactService(
                    OnlineService onlineService, 
                    string tag,
                    CryptoKey cryptoKey=null,
                    string cryptoLabel = null) : this(tag) {
        Add(onlineService, cryptoKey, cryptoLabel);
        }


    public void Add(
                    OnlineService onlineService,
                    CryptoKey cryptoKey = null,
                    string cryptoLabel = null) {

        var serviceType = onlineService.Service.ToLower();

        if (serviceType == "mesh") {
            ServiceType = ServiceType.Mesh;
            Accounts.Add (onlineService.User);
            }

        if (cryptoKey != null) {
            Credentials.AddSafe (cryptoLabel,cryptoKey);
            }

        }


    }

public record JsContactServiceEmail(
            EmailAddress EmailAddress) : JsContactService(EmailAddress.Address) {

    public override ServiceType ServiceType => ServiceType.Email;

    }

[Flags]
public enum CredentialUse {
    OpenPgp = 1,
    OpenPgpSub = 2,
    Pkix = 4,
    PkixCode = 8,
    PkixSign = 16,
    PkixEncrypt =32
    }


public record JsContactCredential (CryptoKey CryptoKey) {


    }


//public record JsContactEmail (
//            EmailAddress entry){

//    public string Address => entry.Address;

//    public List<JsContactSmime> Smime { get; } = [];
//    public List<JsContactOpenPgp> OpenPgp { get; } = [];

//    //public List<JsContactSmime> Smime { get; } = [];

//    //public List<JsContactSmime> Smime { get; } = [];
//    }

//public record JsContactSmime {


//    }

//public record JsContactOpenPgp {


//    }

//public record JsContactMesh {


//    }

//public record JsContactDeveloper {


//    }

//public record JsContactMessaging {


//    }

//public record JsContactWeb (
//            OnlineService service){


//    }



public partial class JsContact {

    public Dictionary<string, JsContactService> DictionaryServices { get; } = [];
    public Dictionary<string, JsContactCredential> DictionaryCredential { get; } = [];

    //public Dictionary<string, JsContactEmail> DictionaryEmail { get; } = [];

    //public Dictionary<string, JsContactMesh> DictionaryMesh { get; } = [];

    //public Dictionary<string, JsContactDeveloper> DictionaryDeveloper { get; } = [];

    //public Dictionary<string, JsContactMessaging> DictionaryMessaging { get; } = [];

    //public Dictionary<string, JsContactWeb> DictionaryWeb { get; } = [];
    #region // Constructors and Factory methods
    public JsContact() {
        }

    public static JsContact Create(
    string kind = null) {

        return new JsContact() {
            Version = "1.0",
            Created = DateTime.Now,
            Updated = DateTime.Now,
            Kind = kind,

            Uid = Udf.Nonce(),
            Language = "en",
            };
        }


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


    public void Update() {
        Updated = DateTime.Now;
        }



    public void Analyze() {
        // First create all the principal services
        foreach (var email in Emails) {
            var key = email.Value?.Address;
            if (!DictionaryServices.ContainsKey(key)) {
                DictionaryServices.Add(key, new JsContactServiceEmail(email.Value));
                }
            }
        //foreach (var keyPair in CryptoKeys) {
        //    var cryptoKey = keyPair.Value;

        //    var credential = new JsContactCredential(cryptoKey);


        //    }

        foreach (var servicePair in OnlineServices) {
            var serviceTag = servicePair.Value.Service.ToLower();
            var (serviceLabel, keyLabel) = GetLabel(servicePair.Value);

            CryptoKey? cryptoKey=null;
            if (keyLabel != null) {
                CryptoKeys.TryGetValue(keyLabel, out cryptoKey);
                }

            if (DictionaryServices.TryGetValue(serviceLabel, out var service)) {
                service.Add(servicePair.Value, cryptoKey, keyLabel);
                }
            else {
                service = new JsContactService(servicePair.Value, serviceLabel, cryptoKey, keyLabel);
                DictionaryServices.Add(serviceLabel, service);
                }
            }





        }


    (string, string) GetLabel(OnlineService service) {
        var serviceTag = service.Service.ToLower();
        //var label = service.Label.ToLower();

        switch (serviceTag) {
            case "mesh": {
                return (service.Uri, service.Uri);
                }
            case "smime_encrypt":
            case "smime":
            case "openpgp_encrypt":
            case "openpgp": {
                return (service.User, service.Uri);
                }


            }



        return ("", null);
        }


    }
