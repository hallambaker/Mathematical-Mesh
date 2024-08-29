namespace Goedel.Carnet;


/// <summary>
/// Extensions class. Provides static convenience extensions.
/// </summary>
public static class Extensions {

    ///// <summary>
    ///// Create a registry account under the name <paramref name="accountAddress"/> 
    ///// </summary>
    ///// <param name="contextUser"></param>
    ///// <param name="accountAddress"></param>
    ///// <returns></returns>
    ///// <exception cref="NYI"></exception>
    //public static ContextCarnet CreateCarnet(this ContextUser contextUser, string accountAddress) =>
    //    ContextCarnet.Create(contextUser, accountAddress);
    //}

    /// <summary>
    /// Spend <paramref name="amount"/> tokens from the wallet of <paramref name="contextUser"/>.
    /// </summary>
    /// <param name="contextUser">The user context.</param>
    /// <param name="amount">The number of tokens to spend.</param>
    /// <returns>The number of tokens spent??</returns>
    public static int Spend(this ContextUser contextUser, int amount) {
        contextUser.Future();
        amount.Future();
        return 0;
        }


    }
