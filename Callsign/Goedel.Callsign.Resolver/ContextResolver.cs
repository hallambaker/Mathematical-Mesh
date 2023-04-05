//  Copyright © 2021 by Threshold Secrets Llc.
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Mesh;
using Goedel.Mesh.Client;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.PKIX;
using System.Xml.Linq;

namespace Goedel.Callsign.Resolver;


/// <summary>
/// Callsign resolution service.
/// </summary>
public class ContextResolver : ContextAccount {

    #region Properties

    ///<summary>Client used to connect to the regitry.</summary> 
    public  MeshServiceClient MeshClientRegistry { get; set; }

    ///<inheritdoc/>
    public override MeshServiceClient MeshClient { get; set; }
    //MeshServiceClient meshClient;

    ///<inheritdoc/>
    public override Profile Profile => ProfileResolver;

    ///<summary>The resolver profile</summary> 
    ProfileResolver ProfileResolver { get; }

    ///<summary>The registry profile</summary> 
    ProfileRegistry ProfileRegistry { get; }

    ///<inheritdoc/>
    public override Connection Connection => throw new NotImplementedException();

    ///<inheritdoc/>
    public override string AccountAddress { get; }

    ///<inheritdoc/>
    public override string ServiceDns => AccountAddress.GetService();

    KeyPair KeyAuthentication { get; }

    ///<summary>Returns the inbound spool for the account</summary>
    public CatalogRegistration CatalogRegistration { get; }

    ///<inheritdoc/>
    public override Dictionary<string, StoreFactoryDelegate> DictionaryCatalogDelegates => StaticCatalogDelegates;
    static readonly Dictionary<string, StoreFactoryDelegate> StaticCatalogDelegates = new() {
            { CatalogRegistration.Label, CatalogRegistration.Factory },

        //// All contexts have a capability catalog:
        //    { CatalogAccess.Label, CatalogAccess.Factory },
        //    { CatalogPublication.Label, CatalogPublication.Factory }
        };



    #endregion
    #region Constructors

    /// <summary>
    /// Constructor returning an instance of a resolver account context running on host
    /// <paramref name="meshHost"/> using the description given in <paramref name="catalogedService"/>.
    /// </summary>
    /// <param name="meshHost">The mesh host.</param>
    /// <param name="catalogedService">The resolver configuration description.</param>
    public ContextResolver(
            MeshHost meshHost,
            CatalogedService catalogedService) : base(meshHost, catalogedService) {

        ProfileResolver = catalogedService.EnvelopedProfileService.Decode() as ProfileResolver;

        ProfileRegistry = ProfileResolver.EnvelopedProfileRegistry.Decode() as ProfileRegistry;
        ActivationCommon = catalogedService.EnvelopedActivationCommon.Decode();

        var SecretSeed = meshHost.KeyCollection.LocatePrivateKey(ProfileResolver.UdfString) as PrivateKeyUDF;
        (KeyAuthentication, _) = SecretSeed.GenerateContributionKey(
        ProfileResolver.MeshKeyType, ProfileResolver.MeshActor, MeshKeyOperation.Authenticate);

        var keyCredential = new MeshKeyCredentialPrivate(KeyAuthentication as KeyPairAdvanced, AccountAddress);

        MeshClient = MeshMachine.GetMeshClient(keyCredential, ProfileRegistry.AccountAddress);

        var storesDirectory = GetStoresDirectory(meshHost, ProfileResolver);
 
        Update();
        CatalogRegistration = CatalogRegistration.Factory (storesDirectory, CatalogRegistration.Label, this,
                create:false) as CatalogRegistration;

        var syncStore = new SyncStatus(CatalogRegistration);

        DictionaryStores.Add(CatalogRegistration.Label, syncStore);

        }


    ///// <summary>
    ///// Create a new client resolver context.
    ///// </summary>
    ///// <param name="meshHost">The mesh host.</param>
    ///// <param name="resolverAddress">The address of the resolver account.</param>
    ///// <param name="accountSeed">Optional account seed.</param>
    ///// <param name="roles">The authorized roles.</param>
    ///// <param name="envelopedProfileRegistry">The enveloped registry profile.</param>
    ///// <returns></returns>
    //public static ContextResolver Create(
    //            MeshHost meshHost,
    //            string resolverAddress,
    //            Enveloped<ProfileAccount> envelopedProfileRegistry,
    //                PrivateKeyUDF accountSeed = null,
    //                List<string> roles = null
    //            ) {
    //    var meshMachine = meshHost.MeshMachine;
    //    // Create the service profile

    //    var profileResolver = ProfileService.Generate(resolverAddress, envelopedProfileRegistry, meshMachine.KeyCollection);
    //    profileResolver.PersistSeed(meshMachine.KeyCollection);


    //    // create the cataloged machine entry for the service
    //    var catalogedService = new CatalogedService() {
    //        EnvelopedProfileService = profileResolver.GetEnvelopedProfileAccount(),
    //        };

    //    // create the directory
    //    var storesDirectory = ContextAccount.GetStoresDirectory(meshHost, profileResolver);
    //    Directory.CreateDirectory(storesDirectory);

    //    var contextResolver = new ContextResolver(meshHost, catalogedService);


    //    return contextResolver;
    //    } 






    #endregion
    #region // Methods


    /// <summary>
    /// Update the resolver state.
    /// </summary>
    public void Update() {

        var statusRequest = new StatusRequest() {
            Catalogs = new List<string> { CatalogRegistration.Label }
            };

        Sync(statusRequest, MeshClient);
        // Sync against registryAddress!!!!


        }

    /// <summary>
    /// Resolve a request.
    /// </summary>
    /// <param name="callsign"></param>
    /// <returns></returns>
    public Enveloped<Registration> Resolve(string callsign) {
        var canonical = callsign.ToLower();
        return CatalogRegistration.Get(canonical)?.EnvelopedRegistration;


        }



    #endregion

    }
