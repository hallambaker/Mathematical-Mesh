using Goedel.Cryptography.Oauth;
using Goedel.Discovery;
using Goedel.Test;
using Xunit;

namespace Test.Cryptography.Oauth;

public class TestOauth {


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

        var did = SessionManager.HandleToDid("phill.hallambaker.com");
        var document = SessionManager.Resolve(did as DidPlc);


        var oauth = new OAuth(document);


        var clientMeta = ClientMetadata.FactoryAtproto("mplace2.app");


        var asString = clientMeta.ToString();
        }



    }
