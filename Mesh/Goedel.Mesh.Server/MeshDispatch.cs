#region // Copyright - MIT License
//  Copyright © 2019-2021 by Phill Hallam-Baker
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
#endregion


using Goedel.Protocol;

using System;

namespace Goedel.Mesh.Server;




/// <summary>
/// The session class implements the Mesh session. The implementations in this class are mostly 
/// stubbs that martial and validate the parameters presented in the request and pass the
/// work on to the <see cref="Server.MeshPersist"/> instance <see cref="MeshPersist"/>
/// </summary>
public class PublicMeshService : MeshService {

    #region // Properties


    ///<summary>Name for the default hosts and Services configuration file.</summary> 
    public const string DefaultConfiguration = "MeshService";


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

    /////<summary>The service configuration</summary> 
    //public ServiceConfiguration ServiceConfiguration { get; init; }

    /////<summary>The Host Configuration</summary> 
    //public HostConfiguration HostConfiguration { get; init; }




    /// <summary>
    /// The mesh persistence provider.
    /// </summary>
    public MeshPersist MeshPersist { get; init; }


    ///<summary>The callsign catalog mapping account names to profiles.</summary> 
    public CatalogAccount CatalogAccount => MeshPersist.CatalogAccount;

    /////<summary>The service description.</summary> 
    //public static ServiceDescription ServiceDescription => new(WellKnown, Factory);

    ///<summary>Key collection giving access to host and service keys.</summary> 
    public IKeyCollection KeyCollection { get; }

    ///<summary>The logging service.</summary> 
    public LogService LogService { get; }


    ILogger Logger => LogService.Logger;

    /////<summary>The service endpoints</summary> 
    //public List<Endpoint> Endpoints { get; } = new();


    GenericHostConfiguration GenericHostConfiguration { get; }

    MeshServiceConfiguration MeshHostConfiguration { get; }

    IPresence PresenceService { get; }


    ///<summary>The callsign registry service profile.</summary> 
    public ProfileAccount CallsignServiceProfile { get; set; }

    ///<summary>Earl dispatch service</summary>
    public EarlDispatch EarlDispatch { get; }

    ///<summary>DNS Publication hook.</summary>
    public IDnsPublisher IDnsPublisher { get; set; }

    #endregion
    #region // Disposing
    ///<inheritdoc/>
    protected override void Disposing() {

        Logger.ServiceEnd(PublicMeshService.WellKnown);

        MeshPersist.Dispose();
        base.Disposing();
        }
    #endregion
    #region // Constructors and factories

    /// <summary>
    /// A Mesh service provider.
    /// </summary>
    /// <param name="meshMachine">The Mesh Machine</param>
    /// <param name="hostConfiguration">Host configuration.</param>
    /// <param name="meshServiceConfiguration">Service configuration.</param>
    /// <param name="logService">The transaction logging service.</param>
    /// <param name="presenceServiceProvider">Optional presence service.</param>
    public PublicMeshService(
            IMeshMachine meshMachine,
            GenericHostConfiguration hostConfiguration,
            MeshServiceConfiguration meshServiceConfiguration,
            LogService logService,
            IPresenceProvider presenceServiceProvider = null,
            EarlDispatch earlDispatch=null) {
        EarlDispatch = earlDispatch ?? new EarlDispatchCached("example.com",
                        meshMachine.Instance);


        LogService = logService;
        MeshMachine = meshMachine;
        GenericHostConfiguration = hostConfiguration;
        MeshHostConfiguration = meshServiceConfiguration;
        KeyCollection = MeshMachine.KeyCollection;
        PresenceService = presenceServiceProvider?.GetPresenceProvider();

        Logger.ServiceStart(PublicMeshService.WellKnown,
            meshServiceConfiguration.ServiceUdf, GenericHostConfiguration.HostUdf);

        // Load the Mesh persistence base
        var path = MeshHostConfiguration.HostPath ?? meshMachine.DirectoryAccounts;
        MeshPersist = new MeshPersist(KeyCollection, path, FileStatus.OpenOrCreate, Logger, PresenceService) {
            EarlDispatch = EarlDispatch
            };

        if (!meshServiceConfiguration.ProfileRegistryCallsign.IsBlank()) {
            var envelope = JsonObject.StreamParse<Enveloped>(meshServiceConfiguration.ProfileRegistryCallsign);
            CallsignServiceProfile = envelope.StreamParseTag<ProfileRegistry>();
            }
        //var instance = GenericHostConfiguration.Instance ?? meshMachine.Instance;

        //Endpoints.Add(
        //    new HttpEndpoint(GenericHostConfiguration.HostDns, GetWellKnown,
        //            GenericHostConfiguration.Port, instance, this));

        var meshHost = MeshHost.GetCatalogHost(MeshMachine);

        var catalogedService = GenericHostConfiguration.HostUdf != null ?
            meshHost?.GetStoreEntry(GenericHostConfiguration.HostUdf) : meshHost.DefaultService;

        if (catalogedService is CatalogedService hostServiceDescription) {
            // Decode the service and host profiles.
            ProfileService = hostServiceDescription.ProfileService;
            ProfileHost = hostServiceDescription.EnvelopedProfileHost.Decode();

            // Activate the host and load the decryption key.
            ProfileHost.Activate(KeyCollection);
            KeyCollection.Add(ProfileHost.KeyEncrypt);

            // Decrypt the service activation.
            ActivationDevice = hostServiceDescription.EnvelopedActivationHost.Decode(KeyCollection);
            ConnectionDevice = hostServiceDescription.EnvelopedConnectionService.Decode(KeyCollection);
            }

        AddEndpoints(hostConfiguration, meshMachine.Instance);



        }

    #endregion





    #region // Create service


    /// <summary>
    /// Add administrator account <paramref name="admin"/> to the service.
    /// </summary>
    /// <param name="meshMachine">The mesh machine context.</param>
    /// <param name="admin">The administration account to create.</param>
    /// <param name="serviceConfiguration">The service configuration.</param>
    /// <param name="dareLogger">Logger configuration.</param>
    /// <returns></returns>
    public virtual ContextUser AddAdministrator(
                IMeshMachineClient meshMachine,
                string admin,
                MeshServiceConfiguration serviceConfiguration,
                DareLoggerConfiguration dareLogger) {
        serviceConfiguration.Administrators.Add(admin);
        dareLogger.Recipients.Add(admin);
        // bind to the service instance directly
        using var directMachine = new MeshMachineDirect(meshMachine, this);
        using var meshHost = new MeshHost(meshMachine.MeshHost, directMachine);
        var contextUser = meshHost.ConfigureMeshAsync(admin, "admin").Sync();
        var udf = contextUser.ProfileUser.UdfString;

        // Set the log files to encrypt to the newly created admin account.
        var adminSin = $"{admin}.mm-{udf}";
        //localLog.Readers = new List<string> { adminSin };
        return contextUser;
        }


    /// <summary>
    /// Add administrator account <paramref name="admin"/> to the service.
    /// </summary>
    /// <param name="meshMachine">The mesh machine context.</param>
    /// <param name="admin">The administration account to create.</param>
    /// <param name="serviceConfiguration">The service configuration.</param>
    /// <param name="dareLogger">Logger configuration.</param>
    /// <returns></returns>
    public virtual ContextUser AddAdministratorDirect(
                IMeshMachineClient meshMachine,
                string admin,
                MeshServiceConfiguration serviceConfiguration,
                DareLoggerConfiguration dareLogger) {
        serviceConfiguration.Administrators.Add(admin);
        dareLogger.Recipients.Add(admin);
        // bind to the service instance directly
        //using var directMachine = new MeshMachineDirect(meshMachine, this);
        using var meshHost = new MeshHost(meshMachine.MeshHost, meshMachine);
        var contextUser = meshHost.ConfigureMeshAsync(admin, "admin").Sync();
        var udf = contextUser.ProfileUser.UdfString;

        // Set the log files to encrypt to the newly created admin account.
        var adminSin = $"{admin}.mm-{udf}";
        //localLog.Readers = new List<string> { adminSin };
        return contextUser;
        }




    /// <summary>
    /// Create new service and host configurations and attach the service to the host.
    /// </summary>
    /// <param name="meshMachine">The mesh machine</param>
    /// <param name="serviceConfiguration">The service configuration</param>
    /// <param name="hostConfiguration">The host configuration</param>
    /// <param name="deviceAddress">The address of the initial host.</param>
    /// <returns>The mesh service interface.</returns>
    public static PublicMeshService Create(
            IMeshMachineClient meshMachine,
            MeshServiceConfiguration serviceConfiguration,
            GenericHostConfiguration hostConfiguration,
            string deviceAddress = "@example"
            ) {
        ProfileService profileService;
        ProfileHost profileHost;
        ActivationHost activationDevice;
        ConnectionService connectionDevice;

        ProfileService.CreateService(meshMachine,
            out profileService, out profileHost, out activationDevice, out connectionDevice);

        var catalogedService = new CatalogedService() {
            Id = connectionDevice.Subject,
            EnvelopedProfileService = profileService.GetEnvelopedProfileService(),
            EnvelopedProfileHost = profileHost.GetEnvelopedProfileHost(),
            EnvelopedActivationHost = activationDevice.GetEnvelopedActivationHost(),
            EnvelopedConnectionService = connectionDevice.GetEnvelopedConnectionService()
            };
        meshMachine.MeshHost.Register(catalogedService, null);

        // Update the service configuration to add the service profile
        //serviceConfiguration.EnvelopedProfileService = profileService.EnvelopedProfileService;

        //hostConfiguration.EnvelopedProfileHost = profileHost.EnvelopedProfileHost;
        //hostConfiguration.EnvelopedConnectionDevice = connectionDevice.EnvelopedConnectionDevice;

        serviceConfiguration.ServiceUdf = profileService.UdfString;
        hostConfiguration.HostUdf = connectionDevice.Subject;
        hostConfiguration.DeviceUdf = profileHost.UdfString;

        var logService = new LogService(hostConfiguration, serviceConfiguration, null);
        logService.Logger ??= ConsoleLogger.Factory("MeshHost");


        // Initialize the persistence store.
        //var meshPersist = new MeshPersist(hostConfiguration.Path, FileStatus.OpenOrCreate);

        //Console.WriteLine($"This is the new version {hostConfiguration.Description}");
        //Console.WriteLine($"This is the new version {hostConfiguration.MaxCores}");
        //Console.WriteLine($"This is the new version {hostConfiguration.DeviceUdf}");


        return new PublicMeshService(
                    meshMachine, hostConfiguration, serviceConfiguration, logService) {
            //MeshPersist = meshPersist,
            ProfileService = profileService,
            ProfileHost = profileHost,
            ActivationDevice = activationDevice,
            ConnectionDevice = connectionDevice
            };

        }




    #endregion



    ///<inheritdoc/>
    public override JsonObject ResponseFail(Exception exception) =>
                new StatusResponse(exception);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="profileAccount"></param>
    /// <param name="jpcSession"></param>
    /// <returns></returns>
    public static bool VerifyDevice(ProfileAccount profileAccount, IJpcSession jpcSession) =>
            profileAccount.AccountAuthenticationKey.MatchKeyIdentifier(
                jpcSession.Credential.AuthenticationKeyId);


    ///<inheritdoc/>
    public override JsonObject Dispatch(IJpcSession session,
                            JsonReader jsonReader) {
        string token = "???";
        JsonObject request;

        LogService.Logger.DispatchBegin();
        try {
            (token, request) = GetRequest(jsonReader);
            }
        catch (Exception exception) {
            LogService.Logger.DispatchParse();
            LogService.UnknownCommand(token);
            return ResponseFail(exception);
            }

        LogService.Logger.DispatchStart(token);
        var log = LogService.Start(token, request as IReport);




        try {
            var result = Dispatch(token, request, session);
            log.Success(result as IReport);
            LogService.Logger.DispatchComplete(token);
            return result;
            }
        catch (Exception exception) {
            LogService.Logger.DispatchFail(token, exception.Message);
            var result = ResponseFail(exception);
            log.Fail(exception, result as IReport);
            return result;
            }

        }
    #region // Transaction dispatch methods


    /// <summary>
    /// Respond with the 'hello' version and encoding info. This request does not 
    /// require authentication or authorization since it is the method a client
    /// calls to determine what the requirements for these are.
    /// </summary>		
    /// <param name="request">The request object to send to the host.</param>
    /// <param name="jpcSession">The connection authentication context.</param>
    /// <returns>The response object from the service</returns>
    public override MeshHelloResponse Hello(
            HelloRequest request, IJpcSession jpcSession) {

        var envelopedProfileService = ProfileService.GetEnvelopedProfileService();

        var encoding = new Goedel.Protocol.Encoding() {
            ID = ["application/json"]
            };
        var helloResponse = new MeshHelloResponse() {
            Version = new Goedel.Protocol.Version() {
                Major = 3,
                Minor = 0,
                Encodings = [encoding],
                },
            EnvelopedProfileService = envelopedProfileService,
            Status = 201 // Must specify this explicitly since not derrived from MeshResponse.
            };

        return helloResponse;
        }

    /// <summary>
    /// Server method implementing the transaction CreateAccount.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
    /// <param name="jpcSession">The connection authentication context.</param>
    /// <returns>The response object from the service</returns>
    public override BindResponse BindAccount(
            BindRequest request, IJpcSession jpcSession) {


        try {
            // Authenticate and authorize the request before acting on it.
            var profileAccount = request.EnvelopedProfileAccount.Decode();
            VerifyDevice(profileAccount, jpcSession).AssertTrue(NotAuthenticated.Throw);

            // canonicalize the account address to ensure consistency.
            request.AccountAddress = request.AccountAddress.CannonicalAccountAddress();
            var account = request.AccountAddress;

            var envelopedProfileService = ProfileService.GetEnvelopedProfileService();

            var accountHostAssignment = new AccountHostAssignment() {
                AccountAddess = account,
                AccessEncrypt = ProfileHost.Encryption,
                CallsignServiceProfile = CallsignServiceProfile,
                EnvelopedProfileService = envelopedProfileService
                };
            accountHostAssignment.Envelope();

            // Create the account (not transactional)
            var accountEntry = new AccountUser(request) {
                EnvelopedAccountHostAssignment = accountHostAssignment.GetEnvelopedAccountHostAssignment(),
                LocalAddress = account,
                LocalName = account
                };

            // Perform the transaction.
            MeshPersist.AccountBind(accountEntry);

            // ToDo: Allow the BindResponse to specify a different host
            // ToDo: Allow the BindResponse to specify a unique service encryption key for the acount                

            return new BindResponse() {
                EnvelopedAccountHostAssignment = accountHostAssignment.GetEnvelopedAccountHostAssignment()
                };
            }
        catch (System.Exception exception) {
            return new BindResponse(exception);
            }
        }

    /// <summary>
    /// Server method implementing the transaction  DeleteAccount.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
    /// <param name="jpcSession">The connection authentication context.</param>
    /// <returns>The response object from the service</returns>
    public override UnbindResponse UnbindAccount(
            UnbindRequest request, IJpcSession jpcSession) {

        try {
            MeshPersist.AccountUnbind(jpcSession, request.Account);
            return new UnbindResponse();
            }
        catch (System.Exception exception) {
            return new UnbindResponse(exception);

            }

        }



    /// <summary>
    /// Server method implementing the transaction  Connect.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
    /// <param name="jpcSession">The connection authentication context.</param>
    /// <returns>The response object from the service</returns>
    public override ConnectResponse Connect(
            ConnectRequest request, IJpcSession jpcSession) {

        // decode MessageConnectionRequestClient with verification
        var requestConnection = request.EnvelopedRequestConnection.Decode();

        try {
            var connectResponse = MeshPersist.Connect(jpcSession, requestConnection);
            return connectResponse;
            }
        catch (System.Exception exception) {
            return new ConnectResponse(exception);

            }

        throw new NYI();
        }

    /// <summary>
    /// Server method implementing the transaction Download.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
    /// <param name="jpcSession">The connection authentication context.</param>
    /// <returns>The response object from the service</returns>
    public override CompleteResponse Complete(
            CompleteRequest request, IJpcSession jpcSession) {
        try {
            return MeshPersist.AccountComplete(jpcSession, request);
            }
        catch (System.Exception exception) {
            return new CompleteResponse(exception);

            }

        }

    /// <summary>
    /// Server method implementing the transaction Download.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
    /// <param name="jpcSession">The connection authentication context.</param>
    /// <returns>The response object from the service</returns>
    public override StatusResponse Status(
                StatusRequest request,
                IJpcSession jpcSession) {
        try {
            return MeshPersist.AccountStatus(jpcSession,
                    request.CatalogedDeviceDigest,
                    request.Catalogs,
                    request.Services,
                    request.DeviceStatus == true);
            }
        catch (System.Exception exception) {
            return new StatusResponse(exception);

            }

        }


    /// <summary>
    /// Server method implementing the transaction  Download.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
    /// <param name="jpcSession">The connection authentication context.</param>
    /// <returns>The response object from the service</returns>
    public override DownloadResponse Download(
                DownloadRequest request,
                IJpcSession jpcSession) {
        try {
            return MeshPersist.AccountDownload(jpcSession, request);
            }
        catch (System.Exception exception) {
            return new DownloadResponse(exception);

            }
        }

    /// <summary>
    /// Server method implementing the transaction  Download.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
    /// <param name="jpcSession">The connection authentication context.</param>
    /// <returns>The response object from the service</returns>
    public override DownloadResponse PublicRead(
            PublicRequest request, IJpcSession jpcSession) {
        try {
            var Updates = MeshPersist.PublicDownload(jpcSession, request.Account, request.Select);
            return new DownloadResponse() { Updates = Updates };
            }
        catch (System.Exception exception) {
            return new DownloadResponse(exception);

            }
        }


    /// <summary>
    /// Server method implementing the transaction  Upload.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
    /// <param name="jpcSession">The connection authentication context.</param>
    /// <returns>The response object from the service</returns>
    public override TransactResponse Transact(
            TransactRequest request, IJpcSession jpcSession) {
        try {
            //var account = VerifyAccount(jpcSession);
            var digest = MeshPersist.AccountTransact(jpcSession,
                    request.Updates, request.EnvelopedInbound, request.EnvelopedOutbound, request.EnvelopedLocal, request.Accounts); ;
            return new TransactResponse() {
                Bitmask = digest
                };
            }
        catch (System.Exception exception) {
            return new TransactResponse(exception);

            }


        }



    /// <summary>
    /// Server method implementing the transaction  Post.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
    /// <param name="jpcSession">The connection authentication context.</param>
    /// <returns>The response object from the service</returns>
    public override UploadResponse Upload(
            UploadRequest request, IJpcSession jpcSession) {

        try {
            return new UploadResponse();
            }
        catch (System.Exception exception) {
            return new UploadResponse(exception);

            }

        }


    /// <summary>
    /// Server method implementing the transaction  Post.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
    /// <param name="jpcSession">The connection authentication context.</param>
    /// <returns>The response object from the service</returns>
    public override GetDataResponse GetData(
            GetDataRequest request, IJpcSession jpcSession) {

        try {
            return new GetDataResponse();
            }
        catch (System.Exception exception) {
            return new GetDataResponse(exception);

            }

        }




    /// <summary>
    /// Server method implementing the transaction  Post.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
    /// <param name="jpcSession">The connection authentication context.</param>
    /// <returns>The response object from the service</returns>
    public override PostResponse Post(
            PostRequest request, IJpcSession jpcSession) {

        try {
            //if (request.Outbound!= null) {
            //    Assert.AssertTrue(request.Outbound.Count == 1, NYI.Throw); // Hack: Support multiple messages in one post
            //    Mesh.MessagePost(jpcSession, jpcSession.VerifiedAccount, request.Accounts, request.Outbound[0]);
            //    }
            //if (request.Local != null) {
            //    Assert.AssertTrue(request.Local.Count == 1, NYI.Throw); // Hack: Support multiple messages in one post
            //    Mesh.MessagePost(jpcSession, jpcSession.VerifiedAccount, null, request.Local[0]);
            //    }
            ////if (request.Inbound != null) {
            ////    throw new NYI();
            ////    //Assert.AssertTrue(request.Self.Count == 1, NYI.Throw); // Hack: Support multiple messages in one post
            ////    //Mesh.MessagePost(jpcSession, jpcSession.VerifiedAccount, null, request.Self[0]);
            ////    }


            return new PostResponse();
            }
        catch (System.Exception exception) {
            return new PostResponse(exception);

            }

        }



    /// <summary>
    /// Server method implementing the transaction  Claim.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
    /// <param name="session">The authentication binding.</param>
    /// <returns>The response object from the service</returns>
    public override ClaimResponse Claim(
                ClaimRequest request,
                IJpcSession session = null) {
        try {

            return MeshPersist.Claim(session,
                    request.EnvelopedMessageClaim);
            }
        catch (System.Exception exception) {
            return new ClaimResponse(exception);

            }
        }

    /// <summary>
    /// Server method implementing the transaction  PollClaim.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
    /// <param name="session">The authentication binding.</param>
    /// <returns>The response object from the service</returns>
    public override PollClaimResponse PollClaim(
                PollClaimRequest request,
                IJpcSession session = null) {
        try {

            return MeshPersist.PollClaim(session, request.TargetAccountAddress, request.PublicationId);
            }
        catch (System.Exception exception) {
            return new PollClaimResponse(exception);

            }
        }



    /// <summary>
    /// Server method implementing the transaction Operate
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
    /// <param name="session">The authentication binding.</param>
    /// <returns>The response object from the service</returns>
    public override OperateResponse Operate(
                OperateRequest request,
                IJpcSession session = null) {
        try {

            return MeshPersist.Operate(session, request.AccountAddress, request.Operations);
            }
        catch (System.Exception exception) {
            return new OperateResponse(exception);

            }
        }


    public override PublishEarlResponse PublishEarl(
                PublishEarlRequest request, IJpcSession jpcSession) {
        try {
            request.Data.AssertNotNull(MeshMissingParameter.Throw);
            request.PreLocator.AssertNotNull(MeshMissingParameter.Throw);
            return MeshPersist.PublishEarl(jpcSession, request.PreLocator, request.Data, request.Expire);
            }
        catch (System.Exception exception) {
            return new PublishEarlResponse(exception);

            }


        }

    public override DeleteEarlResponse DeleteEarl(
                DeleteEarlRequest request, IJpcSession jpcSession) {
        try {
            request.PreLocator.AssertNotNull(MeshMissingParameter.Throw);
            return MeshPersist.DeleteEarl(jpcSession, request.PreLocator);
            }
        catch (System.Exception exception) {
            return new DeleteEarlResponse(exception);

            }


        }

    public override PublishDnsResponse PublishDns(PublishDnsRequest request, IJpcSession jpcSession) {
        try {
            request.Updates.AssertNotNull(MeshMissingParameter.Throw);
            if (request.Updates.Count < 0) {
                // no records to publish means we always succeed.
                return new PublishDnsResponse();
                }

            return MeshPersist.PublishDns(jpcSession, IDnsPublisher, request.Updates);
            }
        catch (System.Exception exception) {
            return new PublishDnsResponse(exception);

            }
        }

    #endregion


    }
