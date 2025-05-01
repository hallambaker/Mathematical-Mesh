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

using Goedel.Contacts;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;
using Goedel.Mesh.Client;
using Goedel.Mesh.Test;
using Goedel.Protocol;
using Goedel.Utilities;

namespace ExampleGenerator;

public class JsContactResults {

    public JsContact Contact { get; }
    public CreateExamples CreateExamples { get; }


    public Dictionary<string, CryptoKey> JSContactSmime { get; } = [];
    public Dictionary<string, CryptoKey> JSContactOpenpgp { get; } = [];
    public EmailAddress EmailAddress { get; set; }

    public Goedel.Contacts.Group Group { get; set; }


    public Update Update { get; }
    public Dictionary<string, CryptoKey> UpdateKeys { get; } = [];

    public Dictionary<string, OnlineService> GroupMembers { get; } = [];


    public Dictionary<string, OnlineService> Ssh { get; } = [];
    public Dictionary<string, CryptoKey> SshKeys { get; } = [];

    public Dictionary<string, OnlineService> CodeSign { get; } = [];
    public Dictionary<string, CryptoKey> CodeSignKeys { get; } = [];

    public Dictionary<string, OnlineService> Commit { get; } = [];
    public Dictionary<string, CryptoKey> CommitKeys { get; } = [];

    public string EARL => EarlSet.Uri;
    public string EARLDNS => "TBS";

    public KeyPairECDH SignatureEd448 { get; }

    public KeyCollection SigningKeys { get; } = new KeyCollectionEphemeral();

    public EarlSet EarlSet { get; }
    public ContentMeta ProtectedHeaderJson { get; } = new ContentMeta() {
        ContentType = "application/jscontact+json",
        Nonce = Udf.FixedNonce("JSContact")
        };

    public JsContactResults(CreateExamples createExamples) {

        CreateExamples = createExamples;
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
        Contact = catalogedContact.Contact;

        var update1 = new Update() {
            Keys =[]
            };

        update1.Keys.Add(SignatureEd448.KeyIdentifier, "sign");


        Contact.Updates = new();
        Contact.Updates.Add("update", update1);

        var jwk = JWK.Factory(SignatureEd448);
        var jwks = new Jwks() {
            Jwk = jwk
            };
        Contact.CryptoKeys.Add(SignatureEd448.KeyIdentifier, jwks);



        //Console.WriteLine(contact.ToString());

        Console.WriteLine(JSONDebugWriter.Write(Contact));

        var contactBytes = Contact.GetJson(false);
        EarlSet = new EarlSet(ProtectedHeaderJson, contactBytes, [SignatureEd448], 
            scheme:"jscontact", service: CreateExamples.AliceService);
        // create an EARL for the contact here.

        foreach (var servicePair in Contact.Emails) {
            //var service = servicePair.Value;
            //if (service.Pr

            EmailAddress = servicePair.Value;
            }

        // email address
        foreach (var key in EmailAddress.Keys) {
            if (key.Value == "smime") {
                if (Contact.CryptoKeys.TryGetValue(key.Key, out var jsonWebKey)) {
                    JSContactSmime.Add(key.Key, jsonWebKey);
                    }
                }
            else if (key.Value == "openpgp") {
                if (Contact.CryptoKeys.TryGetValue(key.Key, out var jsonWebKey)) {
                    JSContactOpenpgp.Add(key.Key, jsonWebKey);
                    }
                }
            }

        foreach (var servicePair in Contact.OnlineServices) {
            var service= servicePair.Value;
            if (service.Service == "ssh") {
                Ssh.Add(servicePair.Key, servicePair.Value);
                CollectKeys(service.Keys, SshKeys);
                }
            if (service.Service == "code") {
                CodeSign.Add(servicePair.Key, servicePair.Value);
                CollectKeys(service.Keys, CodeSignKeys);
                }
            if (service.Service == "commit") {
                Commit.Add(servicePair.Key, servicePair.Value);
                CollectKeys(service.Keys, CommitKeys);
                }
            }

        foreach (var update in Contact.Updates) {
            Update = update.Value;
            CollectKeys(Update.Keys, UpdateKeys);
            }


        foreach (var key in Contact.Groups) {
            Group = key.Value;

            }

        int count = 0;

        foreach (var key in Group.Members) {
            if (count<3 & Contact.OnlineServices.TryGetValue(key.Key, out var member)) {
                GroupMembers.Add(key.Key, member);
                count++;
                }

            }
        }

    void CollectKeys(Dictionary<string,string> keys, Dictionary<string, CryptoKey> list) {
        foreach (var key in keys) {
            if (Contact.CryptoKeys.TryGetValue(key.Key, out var jsonWebKey)) {
                list.Add(key.Key, jsonWebKey);
                }
            }
        }


    }
