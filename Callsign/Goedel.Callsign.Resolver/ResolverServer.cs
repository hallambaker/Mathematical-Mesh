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
using Goedel.Cryptography.Jose;
using Goedel.Mesh;
using Goedel.Mesh.Client;
using Goedel.Protocol;
using Goedel.Protocol.Service;
using Goedel.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Goedel.Callsign.Resolver;



public class PublicCallsignResolver : ResolverService, IDisposable{




    public ResolverServiceClient GetClient() =>
            new ResolverServiceDirect() {
                Service = this
                };


    #region // Properties

    /////<summary>The resolver service.</summary> 
    //public PublicCallsignResolver PublicResolverService { get; }

    ///<summary>The Mesh Machine base</summary> 
    public IMeshMachine MeshMachine { get; init; }

    ///<summary>The profile describing the service</summary>
    public ProfileService ProfileService { get; init; }

    ///<summary>The profile describing the host</summary>
    public ProfileHost ProfileHost { get; init; }

    ///<summary>The host activation record.</summary> 
    public ActivationAccount ActivationDevice { get; init; }

    ///<summary>The host connection record.</summary> 
    public ConnectionService ConnectionDevice { get; init; }


    GenericHostConfiguration HostConfiguration { get; }
    CallsignResolverConfiguration CallsignResolverConfiguration { get; }

    public string Registry => CallsignResolverConfiguration.Registry;
    ///<summary>The registation catalog.</summary> 

    public CatalogRegistration CatalogRegistration = null;
    public CatalogNotary CatalogNotary = null;


    public IKeyCollection KeyCollection { get; }

    MeshServiceClient MeshClient => meshClient ?? 
            MeshMachine.GetMeshClient(MeshKeyCredentialPrivate, Registry).CacheValue(out meshClient);
    MeshServiceClient meshClient;
    LogService LogService { get; }

    MeshKeyCredentialPrivate MeshKeyCredentialPrivate { get; }

    #endregion


    #region // Dsiposing
    /// <summary>
    /// Dispose method, frees all resources.
    /// </summary>
    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
        }

    bool disposed = false;
    /// <summary>
    /// Dispose method, frees resources when disposing, 
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing) {
        if (disposed) {
            return;
            }

        if (disposing) {
            Disposing();
            }

        disposed = true;
        }

    /// <summary>
    /// Destructor.
    /// </summary>
    ~PublicCallsignResolver() {
        Dispose(false);
        }

    /// <summary>
    /// The class specific disposal routine.
    /// </summary>
    protected virtual void Disposing() {
        CatalogRegistration?.Dispose();
        CatalogNotary?.Dispose();
        }
    #endregion

    #region // Constructors

    public PublicCallsignResolver(
            IMeshMachine meshMachine,
            GenericHostConfiguration hostConfiguration,
            CallsignResolverConfiguration resolverServiceConfiguration,
            LogService logService) {

        // load up the persistence store here.

        HostConfiguration = hostConfiguration;
        CallsignResolverConfiguration = resolverServiceConfiguration;
        MeshMachine = meshMachine;
        LogService = logService;
        KeyCollection = meshMachine.KeyCollection;




        var meshHost = MeshHost.GetCatalogHost(MeshMachine);
        // Unpack the profiles
        if (meshHost?.GetStoreEntry(hostConfiguration.HostUdf) is CatalogedService hostServiceDescription) {
            ProfileService = hostServiceDescription.EnvelopedProfileService.Decode();
            ProfileHost = hostServiceDescription.EnvelopedProfileHost.Decode();

            // Activate the host and load the decryption key.
            ProfileHost.Activate(KeyCollection);
            KeyCollection.Add(ProfileHost.KeyEncrypt);

            // Decrypt the service activation.
            ActivationDevice = hostServiceDescription.EnvelopedActivationHost.Decode(KeyCollection);
            ConnectionDevice = hostServiceDescription.EnvelopedConnectionService.Decode(KeyCollection);

            ActivationDevice.Activate(ProfileHost.SecretSeed);
            }

        MeshKeyCredentialPrivate = 
            new MeshKeyCredentialPrivate(ActivationDevice.AccountAuthentication as KeyPairAdvanced, "anonymous");





        AddEndpoints(hostConfiguration, meshMachine.Instance);

        }



    public override bool Initialize(IEnumerable<IConfguredService> services) {

        var directory = CallsignResolverConfiguration.HostPath;

        InitializeRepository(MeshMachine, ActivationDevice.AccountAuthentication, CallsignResolverConfiguration.Registry,
                directory, CatalogRegistration.Label);
        InitializeRepository(MeshMachine, ActivationDevice.AccountAuthentication, CallsignResolverConfiguration.Registry,
                directory, CatalogNotary.Label);

        CatalogRegistration = new CatalogRegistration(directory);
        CatalogNotary = new CatalogNotary(directory);


        return true;
        }



    public static PublicCallsignResolver Create(
        IMeshMachineClient meshMachine,
        Enveloped<ProfileAccount> envelopedProfileRegistry,
        GenericHostConfiguration hostConfiguration,
        CallsignResolverConfiguration resolverServiceConfiguration,
        LogService logService) {

        ProfileService profileService;
        ProfileHost profileHost;
        ActivationHost activationDevice;
        ConnectionService connectionDevice;

        ProfileResolver.CreateService(meshMachine, envelopedProfileRegistry,
            out profileService, out profileHost, out activationDevice, out connectionDevice);

        var catalogedService = new CatalogedService() {
            Id = connectionDevice.Subject,
            EnvelopedProfileService = profileService.GetEnvelopedProfileService(),
            EnvelopedProfileHost = profileHost.GetEnvelopedProfileHost(),
            EnvelopedActivationHost = activationDevice.GetEnvelopedActivationHost(),
            EnvelopedConnectionService = connectionDevice.GetEnvelopedConnectionService()
            };
        meshMachine.MeshHost.Register(catalogedService, null);


        resolverServiceConfiguration.ServiceUdf = profileService.UdfString;
        hostConfiguration.HostUdf = connectionDevice.Subject;
        hostConfiguration.DeviceUdf = profileHost.UdfString;

        // Check for persistence store files and create blank if they do not exist.

        var directory = resolverServiceConfiguration.HostPath ?? hostConfiguration.HostPath;
        //InitializeRepository(meshMachine, activationDevice.AccountAuthentication, resolverServiceConfiguration.Registry,
        //        directory, CatalogRegistration.Label);
        //InitializeRepository(meshMachine, activationDevice.AccountAuthentication, resolverServiceConfiguration.Registry,
        //        directory, CatalogNotary.Label);

        var result = new PublicCallsignResolver(
            meshMachine, hostConfiguration, resolverServiceConfiguration, logService) {
            //MeshPersist = meshPersist,
            ProfileService = profileService,
            ProfileHost = profileHost,
            ActivationDevice = activationDevice,
            ConnectionDevice = connectionDevice
            };

        // now we synchronize the persistence stores.

        return result;
        }


    static void InitializeRepository(
                IMeshMachine meshMachine,
                KeyPairAdvanced authenticationKey,
                string registry,
                string directory, 
                string label) {

        var fileName = Store.FileName(directory, label);
        if (File.Exists(fileName)) {
            return;
            }

        var keyCredential = new MeshKeyCredentialPrivate(authenticationKey as KeyPairAdvanced, "anonymous");
        var meshClient = meshMachine.GetMeshClient(keyCredential, registry);

        var registrySelect = new ConstraintsSelect() {
            Store = CatalogRegistration.Label,
            IndexMin = 0
            };

        var notarySelect = new ConstraintsSelect() {
            Store = CatalogNotary.Label,
            IndexMin = 0
            };

        var downloadRequest = new PublicRequest() {
            Account = registry,
            Select = new() {
                registrySelect, notarySelect
                }
            
            };


        var response = meshClient.PublicRead(downloadRequest);
        response.Success().AssertTrue(NYI.Throw);
        // here we create a new sequence by writing the envelopes to it

        var update = response.GetUpdate(label);
        update.AssertNotNull(NYI.Throw);
        Directory.CreateDirectory (directory);

        using var sequence = Sequence.MakeNewSequence(fileName, meshMachine.KeyCollection, update.Envelopes);
        }


    #endregion
    #region // Implement IResolver

    public bool TryResolveCallsign(string callsign, out Enveloped<Registration> callsignBinding) {

        if (CatalogRegistration.TryGetValue(callsign, out var index)) {
            var result = index.JsonObject as CatalogedRegistration;
            callsignBinding = result.EnvelopedRegistration;
            return true;
            }

        callsignBinding = null;
        return false;
        }


    #endregion
    #region // Dispatch Methods

    public void SyncToRegistry() {
        var registrySelect = new ConstraintsSelect() {
            Store = CatalogRegistration.Label,
            IndexMin= (int) CatalogRegistration.FrameCount
            };

        var notarySelect = new ConstraintsSelect() {
            Store = CatalogNotary.Label,
            IndexMin = (int)CatalogNotary.FrameCount
            };

        var downloadRequest = new PublicRequest() {
            Account = Registry,
            Select = new() {
                registrySelect, notarySelect
                }
            };


        var response = MeshClient.PublicRead(downloadRequest);



        foreach (var update in response.Updates) {
            switch (update.Store) {
                case CatalogRegistration.Label: {
                    CatalogRegistration.AppendDirect(update.Envelopes);
                    break;
                    }
                case CatalogNotary.Label: {
                    CatalogNotary.AppendDirect(update.Envelopes);
                    break;
                    }
                }
            }

        }
    
    
    ///<inheritdoc/>
    public override QueryResponse Query(QueryRequest request, IJpcSession session) {
        TryResolveCallsign(request.CallSign, out var envelopedRegistration);
        return new QueryResponse(envelopedRegistration);
        }

    ///<inheritdoc/>
    ///<remarks>Not currently implemented as this operation requires checking the request is
    ///from an authorized administrator.</remarks>
    public override SyncResponse Sync(SyncRequest request, IJpcSession session) {
        throw new NotImplementedException();
        }

    #endregion


    }


//public class PublicResolverService : ResolverService {


//    public CatalogRegistration CatalogRegistration { get; }

//    PublicCallsignResolver PublicCallsignResolver { get; }


//    ///<summary>The service endpoints</summary> 
//    public List<Endpoint> Endpoints { get; } = new();

//    public PublicResolverService(

//                PublicCallsignResolver publicCallsignResolver) {
//        PublicCallsignResolver = publicCallsignResolver;
//        CatalogRegistration = publicCallsignResolver.CatalogRegistration;
//        }


//    #region // Override Methods

//    public override QueryResponse Query(
//        QueryRequest request, IJpcSession session) {

//        var callsign = request.CallSign;
//        callsign.AssertNotNull(NYI.Throw);


//        if (CatalogRegistration.TryGetValue(callsign, out var result)) {
//            var catalogedRegistration = result.JsonObject as CatalogedRegistration;
//            return new QueryResponse(catalogedRegistration.EnvelopedRegistration);

//            }
//        return new QueryResponse(null);

//        }

//    public override SyncResponse Sync(SyncRequest request, IJpcSession session) {
//        PublicCallsignResolver.SyncToRegistry();
//        return new SyncResponse();
//        }


//    #endregion
//    }




/// <summary>
/// The resolver server.
/// </summary>
public class ResolverServer  {
    #region // Properties

    ///<summary>The resolver client context.</summary> 
    ContextResolver ContextResolver { get; }

    ///<summary>Resolver client configuration.</summary> 
    CatalogedMachine CatalogedMachine { get; }

    #endregion
    #region // Constructors

    /// <summary>
    /// Constructs an instance of a Callsign resolver service bound to the registry 
    /// specified in <paramref name="catalogedMachine"/>.
    /// </summary>
    /// <param name="meshHost">The Mesh host.</param>
    /// <param name="catalogedMachine">The resolver client description.</param>
    public ResolverServer  (
                MeshHost meshHost,
                CatalogedService catalogedMachine) {



        // pull up client here.
        ContextResolver = new ContextResolver(meshHost, catalogedMachine);
        }



    #endregion
    #region // Implement Inteface $$$
    #endregion

    #region // Methods

    /// <summary>
    /// Update dispatch
    /// </summary>
    public void Update() {

        //Synchronize client
        ContextResolver.Update();

        }

    /// <summary>
    /// Resolver dispatch.
    /// </summary>
    /// <param name="callsign">The callsign to resolve.</param>
    /// <returns>The resolution result.</returns>
    public Enveloped<Registration> Resolve(string callsign) {
        
        // Get callsign data and return.
        
        return ContextResolver.Resolve (callsign);
        }


    #endregion
    }
