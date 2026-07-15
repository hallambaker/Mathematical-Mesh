



using System.Collections.Generic;
using System.IO;
using System.Net.Mime;

using Goedel.Contacts;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Discovery;
using Goedel.IO;
using Goedel.Mesh;
using Goedel.Mesh.Test;

namespace Goedel.XUnit;
public class TestOauth : UnitTestSet {

    //public TestEnvironmentBase TestEnvironment => testEnvironment ??
    //        GetTestEnvironment().CacheValue(out testEnvironment);
    //TestEnvironmentBase testEnvironment;

    //public virtual TestEnvironmentBase GetTestEnvironment() =>
    //        new TestEnvironmentCommon(this);

    public DnsClient DnsClient { get; set; } = new DnsClientUDP();


    string PHB1 => "hallam.bsky.social";
    string PHB2 => "phill.hallambaker.com";
    /// <summary>
    /// Static constructor, put initializations here.
    /// </summary>
    static TestOauth() {
        }


    /// <summary>
    /// Create method, return an instance.
    /// </summary>
    /// <returns>The instance</returns>
    public static TestOauth Test() => new();


    [Fact]
    public void TestDidResolve() {

        SessionManager SessionManager = new() {
            DnsClient = DnsClient
            };

        //var did2 = SessionManager.TryResolveDid("hallam.bsky.social").Sync();
        //var did1 = SessionManager.TryResolveDid("phill.hallambaker.com").Sync() ;

        //var res1 = SessionManager.TryResolveResourceServer(did1).Sync();
        //var res2 = SessionManager.TryResolveResourceServer(did2).Sync();

        //var auth1 = SessionManager.TryResolveAuthServer(res1.AuthorizationServers[0]).Sync();
        //var auth2 = SessionManager.TryResolveAuthServer(res1.AuthorizationServers[0]).Sync();

        //var document = SessionManager.Resolve(did as DidPlc);


        //var oauth = new OAuth(document);

        var oauth1 = SessionManager.TryResolveHandle(PHB1);
        oauth1.Sync();
        var oauth2 = SessionManager.TryResolveHandle(PHB2).Sync();

        }
    [Fact]
    public void TestPAR() {
        Directory.SetCurrentDirectory(Seed.Directory);


        var client = new OauthClient(null, null, Seed.Directory) {
            DnsClient = DnsClient
            };
        //var manager = new EncryptedTokenManager();
        //var par = client.PreRequest(PHB1, "fatfreddy").Sync();

        SessionManager SessionManager = new() {
            DnsClient = DnsClient
            }; 
        var oauth1 = SessionManager.TryResolveHandle(PHB1).Sync();
        var req = client.ConstructPar(oauth1, "fat freddy");
        var state = new EncodedState(client.EncryptedTokenManager, req.State);

        }


    [Fact]
    public void TestEncDed() {
        //var x = new AuthorizationRequest();
        //var y = new AuthorizationServerMetadata();

        var manager = new EncryptedTokenManager();

        var test = "Fat Freddy".ToUTF8();

        var ciphertext = manager.Encrypt(test);
        var plaintext = manager.Decrypt(ciphertext);

        test.TestEqual(plaintext);
        }


    [Fact]
    public void TestJsContact() {

        var name = new Name() {
            Components = [
                new ("title", "Dr.") ,
            new ("given", "Phillip"),
            new ("given2", "Martin"),
            new ("surname", "Hallam-Baker"),
            new ("credential", "BEng.(Soton)"),
            new ("credential", "DPhil.(Oxon)")],
            IsOrdered = true,
            Full = "Phillip Hallam-Baker"

            };

        var contact = new JsContact() {
            Version = "1.0",
            Kind="individual",
            Language ="en",
            Name = name,
            Organizations = new() {
                    { "1", new() { Name="Mplace2.Social"} }
                },
            SpeakToAs = new SpeakToAs() {
                GrammaticalGender= "masculine",
                Pronouns = new() {
                        { "a", new() {Values="he/him/his" } }
                    }
                },
            //Media 
            //https://www.hallambaker.com/Images/PHBInDalek.png
            PreferredLanguages =new() {
                    { "b", new() { Language="en"} }
                },
            Titles=null,
            Emails=[],
            OnlineServices=[],
            Media=[],
            Updates=[]
            };

        contact.AddMedia("https://www.hallambaker.com/Images/PHBavatar.png", "image/png");

        var openPgp = new byte[166];
        var smime = new byte[1166];
        // Add Email
        contact.AddEmail("phill@hallambaker.com", openPgp: openPgp, smime: smime);

        // Add Website - Mplace2.social
        contact.AddWeb("https://www.hallambaker.com/", ["personal"]);
        contact.AddWeb("https://phill.hallambaker.com/", ["social"]);
        contact.AddWeb("https://mplace2.social/", ["social"]);

        // Add MoqPresence

        contact.AddService(ContactConstant.OnlineServiceMoqPresence, ["personal"]);

        // Add SSH key
        var sshKey = KeyPairX25519.Generate();
        contact.AddSsh([sshKey]);

        var gitKey = KeyPairEd25519.Generate(KeySecurity.Ephemeral);
        contact.AddGit([gitKey]);

        // Add Mesh Profile
        var meshProfile = new byte[1166];
        contact.AddMesh(meshProfile);

        

        // Add update mechanism
        var updateKey = KeyPairEd448.Generate(KeySecurity.Ephemeral);
        contact.AddUpdate("dns", "handle:phill.hallambaker.com", [updateKey]);

        // write to a file as an EARL.


        var earlset = contact.GetEarlSet();

        var file1 = earlset.Earl + ".earl";
        var file2 = earlset.Locator + ".earl";

        file1.WriteFileNew(earlset.Ciphertext);
        file2.WriteFileNew(earlset.Ciphertext);
        }

    

    }