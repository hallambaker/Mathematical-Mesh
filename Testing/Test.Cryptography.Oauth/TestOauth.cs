

using Goedel.Cryptography.Oauth;

using static Goedel.Cryptography.Oauth.OauthClient;

namespace Test.Cryptography.Oauth;

public class TestOauth {

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

        SessionManager SessionManager = new();

        //var did2 = SessionManager.TryResolveDid("hallam.bsky.social").Sync();
        //var did1 = SessionManager.TryResolveDid("phill.hallambaker.com").Sync() ;

        //var res1 = SessionManager.TryResolveResourceServer(did1).Sync();
        //var res2 = SessionManager.TryResolveResourceServer(did2).Sync();

        //var auth1 = SessionManager.TryResolveAuthServer(res1.AuthorizationServers[0]).Sync();
        //var auth2 = SessionManager.TryResolveAuthServer(res1.AuthorizationServers[0]).Sync();

        //var document = SessionManager.Resolve(did as DidPlc);


        //var oauth = new OAuth(document);

        var oauth1 = SessionManager.TryResolveHandle(PHB1).Sync();
        var oauth2 = SessionManager.TryResolveHandle(PHB2).Sync();






        }
    [Fact]
    public void TestPAR() {
        var client = new OauthClient(null, null, null);
        //var par = client.PreRequest(PHB1, "fatfreddy").Sync();

        SessionManager SessionManager = new();
        var oauth1 = SessionManager.TryResolveHandle(PHB1).Sync();
        var req = client.ConstructPAR(oauth1, "fat freddy");

        var state = new EncodedState(null, req.State);

        }

    }