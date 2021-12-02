﻿#region // Copyright - MIT License
//  Copyright © 2015 by Comodo Group Inc.
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

using System.Net;


namespace Goedel.Mesh.Server;




/// <summary>
/// The session class implements the Mesh session. The implementations in this class are mostly 
/// stubbs that martial and validate the parameters presented in the request and pass the
/// work on to the <see cref="Server.MeshPersist"/> instance <see cref="MeshPersist"/>
/// </summary>
public class PublicMeshService : MeshService {

    #region // Properties


    ///<summary>Name for the default hosts and Services configuration file.</summary> 
    public const string DefaultConfiguration = "HostsAndServices";

    ///<summary>Extension for hosts and services configuration files.</summary> 
    public const string ConfigurationFileExtension = ".hasconf";


    ///<summary>The Mesh Machine base</summary> 
    public IMeshMachine MeshMachine { get; init; }

    ///<summary>The profile describing the service</summary>
    public ProfileService ProfileService { get; init; }

    ///<summary>The profile describing the host</summary>
    public ProfileHost ProfileHost { get; init; }

    ///<summary>The host activation record.</summary> 
    public ActivationDevice ActivationDevice { get; init; }

    ///<summary>The host connection record.</summary> 
    public ConnectionService ConnectionDevice { get; init; }

    ///<summary>The service configuration</summary> 
    public ServiceConfiguration ServiceConfiguration { get; init; }

    ///<summary>The Host Configuration</summary> 
    public HostConfiguration HostConfiguration { get; init; }


    public bool ConsoleOut => HostConfiguration.ConsoleOutput;


    /// <summary>
    /// The mesh persistence provider.
    /// </summary>
    public MeshPersist MeshPersist { get; init; }

    ///<summary>The service description.</summary> 
    public static ServiceDescription ServiceDescription => new(WellKnown, Factory);

    ///<summary>Key collection giving access to host and service keys.</summary> 
    public IKeyCollection KeyCollection { get; }


    public LogService LogService { get; }

    #endregion
    #region // Disposing
    ///<inheritdoc/>
    protected override void Disposing() {
        MeshPersist.Dispose();
        base.Disposing();
        }
    #endregion
    #region // Constructors and factories

    ///<inheritdoc cref="ServiceFactoryDelegate"/>
    public static RudProvider Factory(
            IMeshMachine meshMachine,
            ServiceConfiguration serviceConfiguration,
            HostConfiguration hostConfiguration) {

        hostConfiguration.AssertNotNull(NYI.Throw); // Force fixin of direct unit tests.

        // Since it is the host that responds, the service binds to the host endpoints
        // in addition to the service.

        var endpoints = hostConfiguration.GetEndpoints();
        //endpoints.AddRange(hostConfiguration.GetEndpoints());
        var provider = new PublicMeshService(meshMachine, serviceConfiguration, hostConfiguration);

        return new RudProvider(endpoints, provider);
        }



    /// <summary>
    /// Create a Mesh Service provider instance on the machine <paramref name="hostConfiguration"/>
    /// according to the parameters specified in <paramref name="serviceConfiguration"/> and
    /// <paramref name="hostConfiguration"/>/
    /// </summary>
    ///<inheritdoc cref="ServiceFactoryDelegate"/>
    public PublicMeshService(
            IMeshMachine meshMachine,
            ServiceConfiguration serviceConfiguration,
            HostConfiguration hostConfiguration) {

        // Bugs? Seems like this is in initializing the service and host, not starting it.

        LogService = new LogService(null) {
            ConsoleOutput = hostConfiguration.ConsoleOutput ?
                ReportMode.Brief : ReportMode.None
            };

        MeshMachine = meshMachine;
        ServiceConfiguration = serviceConfiguration;
        HostConfiguration = hostConfiguration;
        KeyCollection = MeshMachine.KeyCollection;

        var path = hostConfiguration?.Path ?? meshMachine.DirectoryMesh;


        // Dummy profiles for the service and host at this point
        ProfileService = ProfileService.Generate(KeyCollection);


        ProfileHost = ProfileHost.CreateHost(MeshMachine);

        // create an activation record and a connection record.

        ActivationDevice = new ActivationHost(ProfileHost);


        //Screen.WriteLine($"$$$$ Seed {ActivationDevice.ActivationSeed}");
        //Screen.WriteLine($"$$$$ Suth {ActivationDevice.ConnectionUser.Authentication.Udf}");
        // activate
        ActivationDevice.Activate(ProfileHost.SecretSeed);

        //Screen.WriteLine($"$$$$ Suth {ActivationDevice.DeviceAuthentication}");



        var connectionDevice = ActivationDevice.Connection;

        // Sign the connection and connection slim

        this.ConnectionDevice = new ConnectionService() {
            Account = "@example",
            Subject = connectionDevice.Subject,
            Authority = connectionDevice.Authority,
            Authentication = connectionDevice.Authentication
            };

        this.ConnectionDevice.Strip();

        ProfileService.Sign(this.ConnectionDevice, ObjectEncoding.JSON_B);
        //KeyCollection.Add(ProfileHost.KeyEncryption);
        KeyCollection.Add(ProfileService.KeyEncryption);
        MeshPersist = new MeshPersist(KeyCollection, path, FileStatus.OpenOrCreate);


        this.ConnectionDevice.DareEnvelope.Strip();
        }





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
        IMeshMachineClient meshMachine, string fileSpec) => GetFilePath(
            meshMachine, fileSpec ?? DefaultConfiguration, "Service");

    /// <summary>
    /// Return the file path for the service specified <paramref name="hostname"/>. The
    /// host description is always stored in a location determined by 
    /// <paramref name="meshMachine"/>.
    /// </summary>
    /// <param name="meshMachine">The Mesh machine specification (used to determine
    /// the location of system configuration files).</param>
    /// <param name="fileSpec">The service specification.</param>
    /// <param name="hostname">The host name.</param>
    /// <returns>The file path.</returns>
    public static string GetHost(
        IMeshMachineClient meshMachine, string hostname) =>
        Path.Combine(meshMachine.DirectoryMesh, "Hosts", hostname);


    //GetFilePath(
    //    meshMachine, fileSpec, "Hosts", hostname);


    /// <summary>
    /// Create a new Mesh Service
    /// </summary>
    /// <param name="meshMachine">The Mesh Machine</param>
    /// <param name="serviceConfig">The service configuration file.</param>
    /// <param name="serviceDns">The canonical DNS name of the service</param>
    /// <param name="hostIp">The host IP address</param>
    /// <param name="hostDns">The host DNS name</param>
    /// <param name="admin">The administrative account to create.</param>
    /// <param name="newFile">The file to write the new service configuration to.</param>
    /// <returns></returns>
    public static PublicMeshService Create(
        IMeshMachineClient meshMachine,
        string serviceConfig,
        string serviceDns,
        string hostConfig,
        string hostIp, string hostDns,
        string admin) {

        var serviceName = "MeshService";

        hostDns ??= Dns.GetHostName();
        hostIp ??= "127.0.0.1:666";
        //var hostIpv6 = "[::1]:15099";


        hostDns ??= serviceDns;


        var pathHost = GetHost(meshMachine, hostConfig);

        var pathLog = Path.Combine(pathHost, "Logs");
        // Create the initial service application

        var ServiceConfiguration = new ServiceConfiguration() {
            Id = serviceName,
            DNS = new List<string> { serviceDns },
            Path = meshMachine.DirectoryMesh,
            WellKnown = "mmm",
            Addresses = new List<string> { serviceDns }
            };

        // populate with user supplied data




        var hostConfiguration = new HostConfiguration() {
            Id = System.Environment.MachineName.ToLower(),
            IP = new List<string> { hostIp },
            DNS = new List<string> { hostDns },
            Port = 15099,
            Services = new List<string> { serviceName },
            Path = pathHost,

            };

        // create the service.
        using var service = Create(meshMachine, ServiceConfiguration, hostConfiguration, hostDns);

        var configuration = new Configuration() {
            Name = "Mesh",
            Address = serviceDns,
            Entries = new List<ConfigurationEntry> { ServiceConfiguration, hostConfiguration }
            };

        var localLog = new LocalLog() {
            Path = pathLog,
            Roll = "1d",
            Events = new List<string> {
                "error", "event"
                }
            };

        if (admin != null) {

            // bind to the service instance directly
            var directMachine = new MeshMachineDirect(meshMachine, service);
            var meshHost = new MeshHost(meshMachine.MeshHost, directMachine);

            // create an administrator profile
            using var contextUser = meshHost.ConfigureMesh(admin, "admin");
            var udf = contextUser.ProfileUser.Udf;

            // Set the log files to encrypt to the newly created admin account.
            var adminSin = $"{admin}.mm-{udf}";
            localLog.Readers = new List<string> { adminSin };
            }

        hostConfiguration.Logs = new List<LogEntry> { localLog };

        // write the configuration out.
        //configuration.ToFile(newFile ?? serviceConfig);

        serviceConfig.MakePath();

        configuration.ToFile(serviceConfig);

        return service;
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
            ServiceConfiguration serviceConfiguration,
            HostConfiguration hostConfiguration,
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

        serviceConfiguration.ProfileUdf = profileService.Udf;
        hostConfiguration.ProfileUdf = connectionDevice.Subject;
        hostConfiguration.DeviceUdf = profileHost.Udf;


        // Initialize the persistence store.
        //var meshPersist = new MeshPersist(hostConfiguration.Path, FileStatus.OpenOrCreate);

        return new PublicMeshService(
                    meshMachine, serviceConfiguration, hostConfiguration) {
            //MeshPersist = meshPersist,
            ProfileService = profileService,
            ProfileHost = profileHost,
            ActivationDevice = activationDevice,
            ConnectionDevice = connectionDevice
            };

        }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="meshMachine"></param>
    /// <param name="serviceConfiguration"></param>
    /// <param name="hostConfiguration"></param>
    /// <returns></returns>
    public static PublicMeshService Load(
            IMeshMachine meshMachine,
            ServiceConfiguration serviceConfiguration,
            HostConfiguration hostConfiguration
            ) {

        // Need to read the host config back from the master catalog here
        //ActivationDevice activationDevice = null;

        return new PublicMeshService(meshMachine, serviceConfiguration, hostConfiguration);


        throw new NYI();
        }



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
    public override Goedel.Protocol.JsonObject Dispatch(IJpcSession session,
                            Goedel.Protocol.JsonReader jsonReader) {
        string token;
        JsonObject request;

        try {
            (token, request) = GetRequest(jsonReader);
            }
        catch (Exception exception) {
            var result = new StatusResponse(exception);
            LogService.UnknownCommand(exception);
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
                AccessEncrypt = ProfileService.ServiceEncryption,
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
