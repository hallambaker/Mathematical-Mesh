using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
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
    /// <param name="contextUser">The user context under which the registry is to be created.</param>
    /// <param name="accountAddress">The registry account service address.</param>
    /// <param name="accountSeed">Optional account seed.</param>
    /// <param name="callsignMapping">Optional callsign mapping specifier.</param>
    /// <returns>The registry account context.</returns>
    public static ContextRegistry CreateRegistry(
                        this ContextUser contextUser, 
                        string accountAddress,
                    PrivateKeyUDF accountSeed = null,
                    CallsignMapping callsignMapping = null) =>
        ContextRegistry.CreateRegistryAsync(contextUser, accountAddress, accountSeed).Sync();

    /// <summary>
    /// Return the registry account context for the <paramref name="contextUser"/> context.
    /// 
    /// </summary>
    /// <param name="contextUser"></param>
    /// <param name="key">Key used to disambiguate multiple registries (why would you need that???).</param>
    /// <returns>The registry context.</returns>
    public static ContextRegistry GetRegistry(
                    this ContextUser contextUser,
                    string key = null) {
        contextUser.SynchronizeAsync().Sync();

        var applicationCatalog = contextUser.GetStore(CatalogApplication.Label) as CatalogApplication;

        foreach (var application in applicationCatalog) {
            if (application is CatalogedRegistry catalogedRegistry) {
                if (key == null | key == catalogedRegistry.Key) {

                    catalogedRegistry.Activate(
                                contextUser.ApplicationEntries, contextUser.ProfileDevice, 
                                contextUser
                                );


                    return new ContextRegistry(contextUser, catalogedRegistry, 
                        catalogedRegistry.ActivationApplicationRegistry);

                    }
                }
            }


        throw new NYI();
        }

    }
