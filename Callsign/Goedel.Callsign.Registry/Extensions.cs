using Goedel.Cryptography.Jose;

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
    public static async Task<ContextRegistry> GetRegistryAsync(
                    this ContextUser contextUser,
                    string key = null) {
        await contextUser.SynchronizeAsync();

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
