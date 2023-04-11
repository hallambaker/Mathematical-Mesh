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
    /// <param name="contextUser"></param>
    /// <param name="accountAddress"></param>
    /// <returns></returns>
    /// <exception cref="NYI"></exception>
    public static ContextRegistry CreateRegistry(
                        this ContextUser contextUser, 
                        string accountAddress,
                    PrivateKeyUDF accountSeed = null,
                    CallsignMapping callsignMapping = null) =>
        ContextRegistry.CreateRegistry(
            contextUser, accountAddress, accountSeed, callsignMapping:callsignMapping);


    public static ContextRegistry GetRegistry(
                    this ContextUser contextUser,
                    string accountAddress,
                    string key=null) {
        contextUser.Sync();

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
