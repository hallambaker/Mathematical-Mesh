#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion

using System.Runtime.Intrinsics.X86;

using Goedel.ASN;
using Goedel.Contacts;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Nist;
using Goedel.Mesh;
using Goedel.Mesh.Client;
using Goedel.Mesh.Test;
using Goedel.Protocol;
using Goedel.Utilities;

using Proto = Goedel.Tool.ProtoGen;

namespace ExampleGenerator;

public enum KeyFormat {
    OpenPGP,
    PKIX,
    SSH,
    SSHCert,
    Sign
    }



public class JsContactResults {


    public Proto.AnnotateSchema AnnotatedSchema { get; set; }

    public string JmapBaseSchemaFile =>
    Path.Combine(CreateExamples.SourceDirectory, @"Libraries\Goedel.Contacts\JmapBase.Protocol");

    public string JsContactSchemaFile =>
            Path.Combine(CreateExamples.SourceDirectory, @"Libraries\Goedel.Contacts\ContactSchema.Protocol");


    public JsContact Contact { get; }
    public CreateExamples CreateExamples { get; }


    // For example, Alice has many OpenPGP keys but only one that she uses
    // with her email address alice@example.com
    public EmailAddress EmailAddress { get; set; }

    public OnlineService GitCommit { get; set; }

    public OnlineService SSHAuth { get; set; }


    public OnlineService SignDevelop { get; set; }
    public OnlineService SignProduction { get; set; }

    public ServiceGroup Developer { get; set; }



    public string CompleteContact { get; set; }




    public Dictionary<string, CryptoKey> JSContactSmime { get; } = [];
    public Dictionary<string, CryptoKey> JSContactOpenpgp { get; } = [];

    public Goedel.Contacts.ServiceGroup Group { get; set; }


    public Update Update { get; }
    public Dictionary<string, CryptoKey> UpdateKeys { get; } = [];

    public Dictionary<string, OnlineService> GroupMembers { get; } = [];


    public OnlineService OnlineServiceWithKeys { get; }
    public CryptoKey CryptoKeyWithJwk { get; }
    public Dictionary<string, OnlineService> Ssh { get; } = [];
    public Dictionary<string, CryptoKey> SshKeys { get; } = [];

    public Dictionary<string, OnlineService> CodeSign { get; } = [];
    public Dictionary<string, CryptoKey> CodeSignKeys { get; } = [];

    public Dictionary<string, OnlineService> Commit { get; } = [];
    public Dictionary<string, CryptoKey> CommitKeys { get; } = [];




    public string EARL => EarlSet.Uri;


    public KeyPairECDH SignatureEd448 { get; }

    public KeyCollection SigningKeys { get; } = new KeyCollectionEphemeral();

    public EarlSet EarlSet { get; }
    public ContentMeta ProtectedHeaderJson { get; } = new ContentMeta() {
        ContentType = "application/jscontact+json",
        Nonce = Udf.FixedNonce("JSContact")
        };

    public static bool IsEmpty<T>(List<string> include, Dictionary<string, T> entries) where T : JsonObject {
        foreach (var entry in entries) {
            if (IsIncluded (include, entry.Key)) {
                return false;
                }
            }
        return true;

        }



    public static bool IsIncluded(List<string> include, string value) {
        foreach (var key in include) {
            if (value == key) {
                return true;
                }
            }
        return false;

        }




    public JsContactResults(CreateExamples createExamples) {


        CreateExamples = createExamples;
        Contacts._Initialized.AssertTrue(NYI.Throw);

        var testEnvironmentCommon = CreateExamples.TestEnvironment;


        // write to file
        Contact = new() {
            Name = new() {
                Components = [
                    new () {
                        Kind = "given",
                        Value = "Alice"
                        },
                    new () {
                        Kind = "surname",
                        Value = "Example"
                        }
                    ],
                Full = "Alice Example",
                IsOrdered = true
                },
            NickNames = new() {
                { "maiden",  new () {
                        Name = "Alice Cryptographer"
                        }
                    }
                },


            AltNames = new() {
                { "maiden",  new () {
                        Components = [
                            new () {
                                Kind = "given",
                                Value = "Alice"
                                },
                            new () {
                                Kind = "surname",
                                Value = "Cryptographer"
                                }
                            ],
                        Full = "Alice Cryptographer",
                        IsOrdered = true
                        }
                    }
                },


            Emails = [],
            CryptoKeys = [],
            OnlineServices = [],
            ServiceGroups = []
            };


        // email: alice@example.com
        var emailKey1 = AddDummyKey(Contact, "emailKey1");
        //var emailKey2 = AddDummyKey(Contact, "emailKey2");
        var emailKey3 = AddDummyKey(Contact, "emailKey3", KeyFormat.PKIX);
        var emailKey4 = AddDummyKey(Contact, "emailKey4", KeyFormat.PKIX);
        EmailAddress = new EmailAddress() {
            Address = "alice@example.com",
            CryptoKeyIds = new () { { emailKey1, "bundle" },  // { emailKey2, "encrypt" },
                    { emailKey3, "sign" }, { emailKey4, "encrypt" } }
            };
        Contact.Emails.Add("email1", EmailAddress);

        // Git commit under alice.example.com
        var gitKey1 = AddDummyKey(Contact, "gitKey1");
        GitCommit = new OnlineService() {
            Service = "commit",
            User = "alice.example.com",
            CryptoKeyIds = new() { { gitKey1, "sign" } }
            };
        Contact.OnlineServices.Add("git1", GitCommit);

        // SSH key
        var ssh1 = AddDummyKey(Contact, "sshKey1", KeyFormat.SSH);
        var ssh2 = AddDummyKey(Contact, "sshKey2", KeyFormat.SSH);
        var ssh3 = AddDummyKey(Contact, "sshKey3", KeyFormat.SSHCert);
        SSHAuth = new OnlineService() {
            Service = "ssh",
            CryptoKeyIds = new() { { ssh1, "sign" }, { ssh2, "sign" }, { ssh3, "sign" } }
            };
        Contact.OnlineServices.Add("ssh1", SSHAuth);

        var code1 = AddDummyKey(Contact, "codeSign1", KeyFormat.PKIX);
        var code2 = AddDummyKey(Contact, "codeSign2", KeyFormat.PKIX);


        SignDevelop = new OnlineService() {
            Service = "code",
            CryptoKeyIds = new() { { code1, "sign" } }
            };
        Contact.OnlineServices.Add("code1", SignDevelop);

        SignProduction = new OnlineService() {
            Service = "code",
            CryptoKeyIds = new() { { code1, "sign" } }
            };
        Contact.OnlineServices.Add("code2", SignProduction);


        Developer = new() {
            Members = new Dictionary<string, bool>() {
                    {  "email1", true },
                    {  "git1", true },
                    {  "ssh1", true }
                }
            };

        Contact.ServiceGroups.Add("group1", Developer);





        // signature and update stuff
        SignatureEd448 = KeyPairEd448.Generate(KeySecurity.Exportable, KeyUses.Sign);
 
        var updatekey1 = AddDummyKey(Contact, "updateKey1", KeyFormat.Sign);
        var update1 = new Update() {
            CryptoKeyIds = new() { { updatekey1, "sign" } },
            Uri = $"https://contacts.example.com/{Contact.Uid}"
            };

        Contact.Updates = new() {
                { "update1", update1 }
            };





        var contactBytes = Contact.GetJson(false);
        CompleteContact = contactBytes.ToUTF8();
        EarlSet = new EarlSet(ProtectedHeaderJson, contactBytes, [SignatureEd448],
            scheme: "jscontact", authority: CreateExamples.AliceService);

        }

    void CollectKeys(Dictionary<string, string> keys, Dictionary<string, CryptoKey> list) {
        foreach (var key in keys) {
            if (Contact.CryptoKeys.TryGetValue(key.Key, out var jsonWebKey)) {
                list.Add(key.Key, jsonWebKey);
                }
            }
        }

    public T TryGetAny<T>(Dictionary<string, T> dictionary) {
        foreach (var pair in dictionary) {
            return pair.Value;
            }
        return default;
        }



    public string AddDummyKey(JsContact contact, string id, KeyFormat format = KeyFormat.OpenPGP) {

        var key = format switch {
            KeyFormat.OpenPGP => DummyOpenPGP(),
            KeyFormat.PKIX => DummyPKIX(),
            KeyFormat.SSH => DummySSH(),
            KeyFormat.SSHCert => DummySSHCert(),
            KeyFormat.Sign => DummySign(),
            _ => null
            };
        Contact.CryptoKeys.Add(id, key);
        return id;
        }

    public CryptoKey DummyOpenPGP() => DummyUri("application/pgp-keys");

    public CryptoKey DummyPKIX() => DummyUri("application/pkix-cert");

    public CryptoKey DummySSHCert() => DummyUri("application/ssh-TBS");

    public CryptoKey DummyUri(string mediaType, int size=20) {

        var data = CryptoCatalog.GetBytes(size).ToStringBase64url();

        return new CryptoKey() {
            Uri = $"data:{mediaType};base64,{data}.."

            };
        }

    public CryptoKey DummySSH() {
        var sig = KeyPairEd25519.Generate(KeySecurity.Exportable, KeyUses.Sign);

        var key = new JsonWebKeySet() {
            JsonWebKeys = [JWK.Factory(sig)]
            };

        return key;

        }

    public CryptoKey DummySign() {

        var key = new JsonWebKeySet() {
            JsonWebKeys = []

            };

        var sig = KeyPairEd448.Generate(KeySecurity.Exportable, KeyUses.Sign);
        key.JsonWebKeys.Add(JWK.Factory(sig));

        return key;

        }

    public string DummyCryptoUri() => "data:application/pgp-keys;base64,LS0tLS1CR..";






    public JsContactResults(bool ignore, CreateExamples createExamples) {


        CreateExamples = createExamples;
        Contacts._Initialized.AssertTrue(NYI.Throw);

        var testEnvironmentCommon = CreateExamples.TestEnvironment;
        var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                 CreateExamples.AliceDevice1, CreateExamples.AliceAccount, "main", CreateExamples.HandleAlice);
        var roles = new List<string> { Rights.IdRolesWeb };


        // add a mail app
        var applicationMail = CatalogedApplicationMail.Create(CreateExamples.AliceAccount, roles, "Main email");
        var resultTransact2 = contextAccountAlice.AddApplication(applicationMail, [null]).Sync();

        // add a Web place
        var applicationWeb = CatalogedApplicationService.CreateWeb(
                "Web", roles, CreateExamples.WebPageAlice, "Alice's personal page");
        var resultTransact6 = contextAccountAlice.AddApplication(applicationWeb, [null]).Sync();


        // add an ssh app
        var applicationSSH = CatalogedApplicationSsh.Create("SSH", roles, "Main SSH key");
        var resultTransact1 = contextAccountAlice.AddApplication(applicationSSH, [null]).Sync();


        // add a developer app, this returns a list of applications for ssh, pgp, etc.
        var applicationDeveloper = CatalogedApplicationDeveloper.Create(CreateExamples.AliceAccountNew,
            roles, "Developer Key Set");
        var resultTransact3 = contextAccountAlice.AddApplications(applicationDeveloper, [null]).Sync();


        if (!contextAccountAlice.TryGetContactSelf(out var catalogedContact)) {
            throw new NYI();
            }

        SignatureEd448 = KeyPairEd448.Generate(KeySecurity.Exportable, KeyUses.Sign);
        SigningKeys.Add(SignatureEd448.KeyPairPublic());



        // write to file
        Contact = catalogedContact.JsContact;

        Contact.Name = new() {
            Components = [
                new () {
                    Kind = "given",
                    Value = "Alice"
                    },
                new () {
                    Kind = "surname",
                    Value = "Example"
                    }
                ],
            Full = "Alice Example",
            IsOrdered = true
            };
        Contact.NickNames = new() {
            { "maiden",  new () {
                    Name = "Alice Cryptographer"
                    }
                }
            };


        Contact.AltNames = new() {
            { "maiden",  new () {
                    Components = [
                        new () {
                            Kind = "given",
                            Value = "Alice"
                            },
                        new () {
                            Kind = "surname",
                            Value = "Cryptographer"
                            }
                        ],
                    Full = "Alice Cryptographer",
                    IsOrdered = true
                    }
                }
            };


        var update1 = new Update() {
            CryptoKeyIds = [],
            Uri = $"https://contacts.example.com/{Contact.Uid}"
            };

        update1.CryptoKeyIds.Add(SignatureEd448.KeyIdentifier, "sign");


        Contact.Updates = new() {
                { "update1", update1 }
            };

        var jwk = JWK.Factory(SignatureEd448);
        var jwks = new JsonWebKeySet() {
            JsonWebKeys = [jwk]
            };
        Contact.CryptoKeys.Add(SignatureEd448.KeyIdentifier, jwks);



        //-------- Here the stuff


        EmailAddress = new EmailAddress() {
            Address = "alice@example.com"
            };

        Contact.Emails = [];



        //Console.WriteLine(contact.ToString());

        Console.WriteLine(JSONDebugWriter.Write(Contact, false));

        var contactBytes = Contact.GetJson(false);
        EarlSet = new EarlSet(ProtectedHeaderJson, contactBytes, [SignatureEd448],
            scheme: "jscontact", authority: CreateExamples.AliceService);





        // create an EARL for the contact here.

        //foreach (var servicePair in Contact.Emails.IfEnumerable()) {
        //    //var service = servicePair.Value;
        //    //if (service.Pr

        //    EmailAddress = servicePair.Value;
        //    }

        //// email address
        //if (EmailAddress?.CryptoKeyIds is not null) {
        //    foreach (var key in EmailAddress.CryptoKeyIds) {
        //        if (key.Value == "smime") {
        //            if (Contact.CryptoKeys.TryGetValue(key.Key, out var jsonWebKey)) {
        //                JSContactSmime.Add(key.Key, jsonWebKey);
        //                }
        //            }
        //        else if (key.Value == "openpgp") {
        //            if (Contact.CryptoKeys.TryGetValue(key.Key, out var jsonWebKey)) {
        //                JSContactOpenpgp.Add(key.Key, jsonWebKey);
        //                }
        //            }
        //        }
        //    }
        //if (Contact?.OnlineServices is not null) {
        //    foreach (var servicePair in Contact.OnlineServices.IfEnumerable()) {
        //        var service = servicePair.Value;
        //        if (service.Service == "ssh") {
        //            Ssh.Add(servicePair.Key, servicePair.Value);
        //            OnlineServiceWithKeys = TryGetAny(Ssh);

        //            CollectKeys(service.CryptoKeyIds, SshKeys);
        //            CryptoKeyWithJwk = TryGetAny(SshKeys);
        //            }
        //        if (service.Service == "code") {
        //            CodeSign.Add(servicePair.Key, servicePair.Value);
        //            CollectKeys(service.CryptoKeyIds, CodeSignKeys);
        //            }
        //        if (service.Service == "commit") {
        //            Commit.Add(servicePair.Key, servicePair.Value);
        //            CollectKeys(service.CryptoKeyIds, CommitKeys);
        //            }
        //        }
        //    }

        //foreach (var update in Contact.Updates.IfEnumerable()) {
        //    Update = update.Value;
        //    CollectKeys(Update.CryptoKeyIds, UpdateKeys);
        //    }


        //foreach (var key in Contact.ServiceGroups.IfEnumerable()) {
        //    Group = key.Value;

        //    }

        //int count = 0;

        //if (Group?.Members is not null) {
        //    foreach (var key in Group?.Members) {
        //        if (count < 3 & Contact.OnlineServices.TryGetValue(key.Key, out var member)) {
        //            GroupMembers.Add(key.Key, member);
        //            count++;
        //            }
        //        }
        //    }
        }
    }

