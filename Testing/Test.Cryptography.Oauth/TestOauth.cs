using Goedel.Cryptography.Oauth;
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

        var result = SessionManager.HandleToDid("phill.hallambaker.com");

        }




    }
