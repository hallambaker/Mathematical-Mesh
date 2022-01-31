#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
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
#endregion


namespace Goedel.Mesh.Shell.Host;

/// <summary>
/// The command shell.
/// </summary>
public partial class Shell : _Shell {

    ///<summary>The Mesh Machine</summary> 
    public IMeshMachineClient MeshMachine { get; init; }


    ///<summary>The service instance</summary> 
    public string Instance { get; init; }


    ///<summary>If false, catch exceptions and interpret as an error.</summary> 
    public bool NoCatch { get; init; }



    ///<summary>Result returned by last shell command.</summary> 
    public ShellResult ShellResult { get; set; }


    /////<summary>Dictionary of service descriptions.</summary> 
    //public Dictionary<string, ServiceDescription>
    //    ServiceDescriptionDictionary { get; } = new();




    ///// <summary>
    ///// Constructor creating a shell prepopulated with the service descriptions
    ///// <paramref name="serviceDescriptions"/>.
    ///// </summary>
    ///// <param name="serviceDescriptions">Descriptions of services to dispatch on.</param>
    //public Shell(params ServiceDescription[] serviceDescriptions) {

    //    foreach (var serviceDescription in serviceDescriptions) {
    //        AddService(serviceDescription);
    //        }

    //    }

    /// <summary>
    /// Dispatch command line instruction with arguments <paramref name="args"/> and
    /// error output <paramref name="console"/>.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    /// <param name="console">Error output stream.</param>
    public void Dispatch(string[] args, TextWriter console) {
        var commandLineInterpreter = new CommandLineInterpreter();


        //if (NoCatch) {
        //    commandLineInterpreter.MainMethod(this, args);
        //    }
        //else {


        //    try {
        //        commandLineInterpreter.MainMethod(this, args);
        //        }
        //    catch (Goedel.Command.ParserException) {
        //        CommandLineInterpreter.Brief(
        //            CommandLineInterpreter.Description,
        //            CommandLineInterpreter.DefaultCommand,
        //            CommandLineInterpreter.Entries);
        //        }
        //    catch (System.Exception Exception) {
        //        console.WriteLine("Application: {0}", Exception.Message);
        //        if (Exception.InnerException != null) {
        //            console.WriteLine(Exception.InnerException.Message);
        //            }
        //        }
        //    }
        }


    ///// <summary>
    ///// Add a service provider to the hosting options.
    ///// </summary>
    ///// <param name="serviceDescription">The service description.</param>
    //public void AddService(ServiceDescription serviceDescription) =>
    //    ServiceDescriptionDictionary.Add(serviceDescription.WellKnown, serviceDescription);


    /// <summary>
    /// Post processing action
    /// </summary>
    /// <param name="result"></param>
    public void _PostProcess(ShellResult result) {
        ShellResult = result;
        }
    ///<summary>The Machine name</summary> 
    public string MachineName { get; set; }
    ///<summary>The service configuration.</summary> 
    public Configuration Configuration { get; set; }
    //HostConfiguration HostConfiguration { get; set; }
    //ServiceConfiguration ServiceConfiguration { get; set; }
    RudService RudService { get; set; }

    string GetMultiConfig(Command._File file) =>
        PublicMeshService.GetService(MeshMachine, file.Value);


    ///<inheritdoc/>
    public override ShellResult HostStart(HostStart Options) {
        var multiConfig = GetMultiConfig(Options.MultiConfig);
        var hostConfig = Options.HostConfig.Value ?? System.Environment.MachineName;


        var result = VerifyConfig(multiConfig, hostConfig);
        result.AssertTrue(InvalidConfiguration.Throw, Options.HostConfig.Value ?? "<none>");

        // Start the service.

        //var configuration = Configuration.ReadFile(multiConfig);
        //var hostConfiguration = configuration.GetHostConfiguration(hostConfig);
        //var serviceConfiguration = configuration.GetServiceConfiguration(hostConfiguration);

        //serviceConfiguration.Instance = Instance;
        //hostConfiguration.Instance = Instance;

        //hostConfiguration.ConsoleOutput = 
        //    Options.Console.Value ? LogLevelSeverity.Information: LogLevelSeverity.None;

        ////ServiceConfiguration.Instance ??= Instance;
        //RudService = StartService(hostConfiguration, serviceConfiguration);


        return new ResultStartService() {
            Success = true,
            RudService = RudService
            };
        }

    ///<inheritdoc/>
    public override ShellResult HostVerify(HostVerify Options) {
        var serviceConfig = GetMultiConfig(Options.ServiceConfig);
        var hostConfig = Options.HostConfig.Value ?? System.Environment.MachineName;

        var result = VerifyConfig(Options.MachineName.Value, hostConfig);

        result.AssertTrue(InvalidConfiguration.Throw);



        return new Result() {
            Success = true
            };
        }

    /// <summary>
    /// Verify the configuration specified in <paramref name="hasConfig"/> and extract the host 
    /// description for <paramref name="hasConfig"/>.
    /// </summary>
    /// <param name="machineName"></param>
    /// <param name="hasConfig"></param>
    /// <returns></returns>
    public bool VerifyConfig(
        string hasConfig,
        string machineName
            ) {

        // Fetch the canonical machine name from the system registry or equivalent and convert
        // to lower case.
        if (machineName == null) {
            MachineName = System.Environment.MachineName.ToLower();
            //if (Console) {
            //    System.Console.WriteLine($"HostName: {MachineName} (default)");
            //    }
            }
        else {
            MachineName = machineName.ToLower();
            //System.Console.WriteLine($"HostName: {MachineName}");
            }


        //Configuration = JsonReader.ReadFile<Configuration>(hasConfig, false);

        //HostConfiguration = Configuration.GetHostConfiguration(MachineName);
        //ServiceConfiguration = Configuration.GetServiceConfiguration(HostConfiguration);


        return true;

        }

    ///// <summary>
    ///// Start the service
    ///// </summary>
    ///// <param name="hostConfiguration">The host configuration.</param>
    ///// <param name="serviceConfiguration">The service configuration</param>
    ///// <returns>The RUD service</returns>
    //public RudService StartService(
    //        HostConfiguration hostConfiguration,
    //        ServiceConfiguration serviceConfiguration) {


    //    // This is a mess, need to 
    //    // 1) Check the credential is being configuired correctly
    //    // 2) Support multiple service configurations (mmm, presence, etc.)



    //    var providers = new List<RudProvider>();

    //    if (ServiceDescriptionDictionary.TryGetValue(serviceConfiguration.WellKnown, out var provider)) {
    //        providers.Add(provider.Factory(MeshMachine, serviceConfiguration, hostConfiguration));
    //        }

    //    // add in the management service 
    //    if (!ServiceDescriptionDictionary.TryGetValue(
    //        ServiceManagementProvider.WellKnown, out var managementProviderDescription)) {
    //        managementProviderDescription = ServiceManagementProvider.ServiceDescriptionHost;
    //        }
    //    providers.Add(managementProviderDescription.Factory(
    //        MeshMachine, serviceConfiguration, hostConfiguration));

    //    // retrieve the credential
    //    var credential = hostConfiguration.GetCredential(MeshMachine);

    //    // start the service
    //    var service = new RudService(providers, credential);

    //    var sigintReceived = false;
    //    // Catch SIGINT
    //    System.Console.CancelKeyPress += (_, ea) => {
    //        // Tell .NET to not terminate the process
    //        ea.Cancel = true;

    //        Screen.WriteInfo(Resources.ReceivedSIGINT);
    //        service.Dispose();
    //        sigintReceived = true;
    //    };

    //    // Catch SIGTERM
    //    AppDomain.CurrentDomain.ProcessExit += (_, _) => {
    //        if (!sigintReceived) {
    //            Screen.WriteInfo(Resources.ReceivedSIGTERM);
    //            service.Dispose();
    //            }
    //        else {
    //            Screen.WriteInfo(Resources.IgnoreSIGTERM);
    //            }
    //    };

    //    return service;
    //    }


    }

/// <summary>
/// Host Shell Command Line Interpreter.
/// </summary>
public partial class CommandLineInterpreter {





    }
