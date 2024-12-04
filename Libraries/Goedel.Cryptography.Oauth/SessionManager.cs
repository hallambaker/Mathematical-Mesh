
namespace Goedel.Cryptography.Oauth;

/// <summary>
/// Session manager class, supports OAUTH and other login modes.
/// </summary>
public class SessionManager : Disposable {

    #region // Properties

    #endregion

    #region // Constructors
    public SessionManager() {




        }

    #endregion
    #region // Methods

    /// <summary>
    /// Return the DID associated with the handle <paramref name="handle"/>.
    /// </summary>
    /// <param name="handle"></param>
    /// <returns></returns>
    public static Did  HandleToDid(string handle) {

        var result = DnsClient.ResolveAtHandle(handle);

        return null;
        }


    #endregion
    }


