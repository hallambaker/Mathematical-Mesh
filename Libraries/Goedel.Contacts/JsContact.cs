using Goedel.Cryptography;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Contacts;



public partial class JsContact {
    public JsContact() {
        }


    public static JsContact Individual(
            string fullname, string gender) {

        var pronouns = gender switch {
            "masculine" => "he/him",
            "feminine" => "she/her",
            _ => "they/them"
            };

        var result = new JsContact() {
            Version = "1.0",
            Created = DateTime.Now,
            Updated = DateTime.Now,
            Kind = "individual",

            Uid = Udf.Nonce(),
            Language = "en",

            Name = new() {
                Full = fullname
                }
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

    public void Update() {
        Updated = DateTime.Now;
        }



    }
