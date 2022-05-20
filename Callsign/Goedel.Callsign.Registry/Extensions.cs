using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Callsign.Registry;


/// <summary>
/// Extensions class. Provides static convenience extensions.
/// </summary>
public static class Extensions {

    /// <summary>
    /// Create a registry account under the name <paramref name="accountAddress"/> 
    /// </summary>
    /// <param name="contextUser"></param>
    /// <param name="accountAddress"></param>
    /// <returns></returns>
    /// <exception cref="NYI"></exception>
    public static ContextRegistry CreateRegistry(
            this ContextUser contextUser, string accountAddress) =>
        ContextRegistry.CreateRegistry(contextUser, accountAddress);

    }
