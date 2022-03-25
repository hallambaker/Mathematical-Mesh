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

using Goedel.Protocol.Service;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Net;
using System.Text;


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

    ///<summary>Extension for hosts and services configuration files.</summary> 
    public const string ConfigurationFileExtension = ".json";


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

    /////<summary>The service description.</summary> 
    //public static ServiceDescription ServiceDescription => new(WellKnown, Factory);

    ///<summary>Key collection giving access to host and service keys.</summary> 
    public IKeyCollection KeyCollection { get; }

    ///<summary>The logging service.</summary> 
    public LogService LogService { get; }


    ILogger Logger => LogService.Logger;

    ///<summary>The service endpoints</summary> 
    public List<Endpoint> Endpoints { get; } = new();


    GenericHostConfiguration GenericHostConfiguration { get; }

    MeshServiceConfiguration MeshHostConfiguration { get; }

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
    public PublicMeshService(
            IMeshMachine meshMachine,
            GenericHostConfiguration hostConfiguration,
            MeshServiceConfiguration meshServiceConfiguration,
            LogService logService) {
        LogService = logService;
        MeshMachine = meshMachine;
        GenericHostConfiguration = hostConfiguration;
        MeshHostConfiguration = meshServiceConfiguration;
        KeyCollection = MeshMachine.KeyCollection;

        Logger.ServiceStart(PublicMeshService.WellKnown, 
            meshServiceConfiguration.ServiceUdf, GenericHostConfiguration.HostUdf);

        // Load the Mesh persistence base
        var path = MeshHostConfiguration.HostPath ?? meshMachine.DirectoryMesh;
        MeshPersist = new MeshPersist(KeyCollection, path, FileStatus.OpenOrCreate);

        var instance = GenericHostConfiguration.Instance ?? meshMachine.Instance;

        Endpoints.Add(
            new HttpEndpoint(GenericHostConfiguration.HostDns, GetWellKnown,
                    GenericHostConfiguration.Port, instance, this));

        var meshHost = MeshHost.GetCatalogHost(MeshMachine);
        if (meshHost?.GetStoreEntry(GenericHostConfiguration.HostUdf) is CatalogedService hostServiceDescription) {
            // Decode the service and host profiles.
            ProfileService = hostServiceDescription.EnvelopedProfileService.Decode();
            ProfileHost = hostServiceDescription.EnvelopedProfileHost.Decode();

            // Activate the host and load the decryption key.
            ProfileHost.Activate(KeyCollection);
            KeyCollection.Add(ProfileHost.KeyEncrypt);

            // Decrypt the service activation.
            ActivationDevice = hostServiceDescription.EnvelopedActivationHost.Decode(KeyCollection);
            ConnectionDevice = hostServiceDescription.EnvelopedConnectionService.Decode(KeyCollection);
            }

        }

    #endregion

    static string GetFilePath(
            IMeshMachineClient meshMachine,
            string fileSpec,
            string type) {
        var defaulted = fileSpec.ApplyExtensionDefault(ConfigurationFileExtension);

        if (Path.IsPathRooted(fileSpec) | Path.HasExtension(fileSpec)) {
            return defaulted;
            }
        return Path.Combine(meshMachine.DirectoryMesh, type, defaulted);


        }

    /// <summary>
    /// Return the file path for the service description <paramref name="fileSpec"/>.
    /// <para>If <paramref name="fileSpec"/> contains no file path specifier, it is
    /// interpreted as a named service description to be stored in the location 
    /// specified by <paramref name="meshMachine"/>. Otherwise, the specified file
    /// path is used.
    /// </para>
    /// </summary>
    /// <param name="meshMachine">The Mesh machine specification (used to determine
    /// the location of system configuration files).</param>
    /// <param name="fileSpec">The service description specifier.</param>
    /// <returns>The file path.</returns>
    public static string GetService(
        IMeshMachineClient meshMachine, string fileSpec=null) => GetFilePath(
            meshMachine, fileSpec ?? DefaultConfiguration, "Service");

    /// <summary>
    /// Return the file path for the service specified <paramref name="hostname"/>. The
    /// host description is always stored in a location determined by 
    /// <paramref name="meshMachine"/>.
    /// </summary>
    /// <param name="meshMachine">The Mesh machine specification (used to determine
    /// the location of system configuration files).</param>
    /// <param name="hostname">The host name.</param>
    /// <returns>The file path.</returns>
    public static string GetHost(
        IMeshMachineClient meshMachine, string hostname) =>
        Path.Combine(meshMachine.DirectoryMesh, "Hosts", hostname);


    #region // Create service

    /// <summary>
    /// Create a new Mesh Service
    /// </summary>
    /// <param name="meshMachine">The Mesh Machine</param>
    /// <param name="serviceConfig">The service configuration file.</param>
    /// <param name="serviceDns">The canonical DNS name of the service</param>
    /// <param name="hostIp">The host IP address</param>
    /// <param name="hostDns">The host DNS name</param>
    /// <param name="admin">The administrative account to create.</param>
    /// <param name="hostAccount">The platform account under which the host process is to run.</param>
    /// <returns>The created service</returns>
    public static Configuration Create(
        IMeshMachineClient meshMachine,
        string serviceConfig,
        string serviceDns,
        string hostIp=null,
        string hostDns = null,
        string admin = null,
        string? hostAccount = null) {

        hostDns ??= Dns.GetHostName();
        hostIp ??= "127.0.0.1:666";
        hostDns ??= serviceDns;

        var pathHost = GetHost(meshMachine, hostDns);
        var pathLog = GetHost(meshMachine, "Logs");

        // Create the initial service application
        var configuration = new Configuration();


        var serviceConfiguration = new MeshServiceConfiguration {
            // ServiceUdf later
            // Administrators later
            ServiceDNS = new List<string> { serviceDns },
            ServicePath = meshMachine.DirectoryMesh,
            HostPath = pathHost
            };

        var hostConfiguration = new GenericHostConfiguration {
            // HostUdf later
            // DeviceUdf later
            Description = $"New service configuration created on {DateTime.Now.ToRFC3339()}",
            HostDns = hostDns,
            IP = new List<string> { hostIp },
            RunAs = hostAccount
            };

        var dareLogger = new DareLoggerConfiguration {
            Path = pathLog,
            };
        var consoleLogger = new ConsoleLoggerConfiguration {
            Default = LogLevel.Trace
            };

        var logging = new Dictionary<string, object> {
                { "Default", "Trace" },
                { "Dare", dareLogger },
                { "Console", consoleLogger },
            };


        configuration.Add(MeshServiceConfiguration.ConfigurationEntry, serviceConfiguration);
        configuration.Add(GenericHostConfiguration.ConfigurationEntry, hostConfiguration);
        configuration.Dictionary.Add("Logging", logging);

        // create the service. This will populate the UDF fields.
        using var service = Create(meshMachine, serviceConfiguration, hostConfiguration);

        if (admin != null) {

            serviceConfiguration.Administrators.Add(admin);
            dareLogger.Recipients.Add(admin);
            // bind to the service instance directly
            var directMachine = new MeshMachineDirect(meshMachine, service);
            var meshHost = new MeshHost(meshMachine.MeshHost, directMachine);

            // create an administrator profile
            using var contextUser = meshHost.ConfigureMesh(admin, "admin");
            var udf = contextUser.ProfileUser.Udf;

            // Set the log files to encrypt to the newly created admin account.
            var adminSin = $"{admin}.mm-{udf}";
            //localLog.Readers = new List<string> { adminSin };
            }

        // Write the configuration out to the file
        serviceConfig.MakePath();
        configuration.ToFile(serviceConfig);

        return configuration;
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

        // Create the service profile
        var profileService = ProfileService.Generate(meshMachine.KeyCollection);

        // Create a host profile and add create a connection to the host.
        var profileHost = ProfileHost.CreateHost(meshMachine);
        var activationDevice = new ActivationHost(profileHost);
        activationDevice.Envelope(encryptionKey: profileHost.KeyEncrypt);
        // Persist the profile keys
        profileService.PersistSeed(meshMachine.KeyCollection);
        profileHost.PersistSeed(meshMachine.KeyCollection);

        // Need to envelope the activation device under device key.

        activationDevice.Activate(profileHost.SecretSeed);
        var connectionDevice1 = activationDevice.Connection;
        var connectionDevice = new ConnectionService() {
            Account = deviceAddress,
            Subject = connectionDevice1.Authentication.CryptoKey.KeyIdentifier,
            Authority = profileService.Udf,

            Authentication = connectionDevice1.Authentication
            };

        // Strip and sign the device connection.
        connectionDevice.Strip();
        profileService.Sign(connectionDevice, ObjectEncoding.JSON_B);

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

        serviceConfiguration.ServiceUdf = profileService.Udf;
        hostConfiguration.HostUdf = connectionDevice.Subject;
        hostConfiguration.DeviceUdf = profileHost.Udf;

        var logService = new LogService(hostConfiguration, serviceConfiguration, null);
        logService.Logger ??= ConsoleLogger.Factory("MeshHost");


        // Initialize the persistence store.
        //var meshPersist = new MeshPersist(hostConfiguration.Path, FileStatus.OpenOrCreate);

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
        string token="???";
        JsonObject request;

        try {
            (token, request) = GetRequest(jsonReader);
            }
        catch (Exception exception) {
            var result = new StatusResponse(exception);
            LogService.UnknownCommand(token);
            return result;
            }

        var log = LogService.Start(token, request as IReport);

        try {
            var result = Dispatch(token, request, session);
            log.Success(result as IReport);

            return result;
            }
        catch (Exception exception) {
            var result = new StatusResponse(exception);
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

        var HelloResponse = new MeshHelloResponse() {
            Version = new Goedel.Protocol.Version() {
                Major = 3,
                Minor = 0,
                Encodings = new List<Goedel.Protocol.Encoding>(),
                },
            EnvelopedProfileService = ProfileService.GetEnvelopedProfileService(),
            //EnvelopedProfileHost = ProfileHost.EnvelopedProfileHost,
            Status = 201 // Must specify this explicitly since not derrived from MeshResponse.
            };

        var Encoding = new Goedel.Protocol.Encoding() {
            ID = new List<string> { "application/json" }
            };
        HelloResponse.Version.Encodings.Add(Encoding);

        return HelloResponse;
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

            // canonicalize the account address to ensure consistency.
            request.AccountAddress = request.AccountAddress.CannonicalAccountAddress();
            var account = request.AccountAddress;

            // Authenticate and authorize the request before acting on it.
            var profileAccount = request.EnvelopedProfileAccount.Decode();
            VerifyDevice(profileAccount, jpcSession).AssertTrue(NotAuthenticated.Throw);


            var accountHostAssignment = new AccountHostAssignment() {
                AccountAddess = account,
                AccessEncrypt = ProfileHost.Encryption,
                };
            accountHostAssignment.Envelope();

            // Create the account (not transactional)
            var accountEntry = new AccountUser(request) {
                EnvelopedAccountHostAssignment = accountHostAssignment.GetEnvelopedAccountHostAssignment()
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
            StatusRequest request, IJpcSession jpcSession) {
        try {
            return MeshPersist.AccountStatus(jpcSession, request.CatalogedDeviceDigest);
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
            DownloadRequest request, IJpcSession jpcSession) {
        try {
            var Updates = MeshPersist.AccountDownload(jpcSession, request.Select);
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
            MeshPersist.AccountTransact(jpcSession,
                    request.Updates, request.Inbound, request.Outbound, request.Local, request.Accounts); ;
            return new TransactResponse();
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


    #endregion


    }
