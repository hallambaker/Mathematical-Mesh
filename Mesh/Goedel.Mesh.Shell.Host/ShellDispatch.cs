using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Mesh.Client;
using Goedel.Protocol;
using Goedel.Protocol.Presentation;
using Goedel.Protocol.Service;
using Goedel.Utilities;
using Goedel.Mesh.ServiceAdmin;
using Goedel.IO;
using System;
using System.Collections.Generic;
using System.IO;

using Goedel.Mesh.Management;

namespace Goedel.Mesh.Shell.Host {

    /// <summary>
    /// The command shell.
    /// </summary>
    public partial class Shell : _Shell {

        ///<summary>The Mesh Machine</summary> 
        public IMeshMachine MeshMachine { get; init; }


        public ShellResult ShellResult { get; set; }


        ///<summary>Dictionary of service descriptions.</summary> 
        public Dictionary<string, ServiceDescription>
            ServiceDescriptionDictionary { get; } = new();




        /// <summary>
        /// Constructor creating a shell prepopulated with the service descriptions
        /// <paramref name="serviceDescriptions"/>.
        /// </summary>
        /// <param name="serviceDescriptions">Descriptions of services to dispatch on.</param>
        public Shell(params ServiceDescription[] serviceDescriptions) {

            foreach (var serviceDescription in serviceDescriptions) {
                AddService(serviceDescription);
                }

            }

        /// <summary>
        /// Dispatch command line instruction with arguments <paramref name="args"/> and
        /// error output <paramref name="console"/>.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        /// <param name="console">Error output stream.</param>
        public void Dispatch(string[] args, TextWriter console) {
            var commandLineInterpreter = new CommandLineInterpreter();

            try {
                commandLineInterpreter.MainMethod(this, args);
                }
            catch (Goedel.Command.ParserException) {
                CommandLineInterpreter.Brief(
                    CommandLineInterpreter.Description,
                    CommandLineInterpreter.DefaultCommand,
                    CommandLineInterpreter.Entries);
                }
            catch (System.Exception Exception) {
                console.WriteLine("Application: {0}", Exception.Message);
                if (Exception.InnerException != null) {
                    console.WriteLine(Exception.InnerException.Message);
                    }
                }
            }


        /// <summary>
        /// Add a service provider to the hosting options.
        /// </summary>
        /// <param name="serviceDescription">The service description.</param>
        public void AddService(ServiceDescription serviceDescription) =>
            ServiceDescriptionDictionary.Add(serviceDescription.WellKnown, serviceDescription);


        /// <summary>
        /// Post processing action
        /// </summary>
        /// <param name="result"></param>
        public void _PostProcess(ShellResult result) {
            ShellResult = result;
            }


        bool Console { get; set; }
        string MachineName { get; set; }
        Configuration Configuration { get; set; }
        HostConfiguration HostConfiguration { get; set; }
        ServiceConfiguration ServiceConfiguration { get; set; }
        RudService RudService { get; set; }

        string GetFile(ExistingFile file) => MeshMachine.GetFilePath(file.Value);
        string GetFile(NewFile file) => MeshMachine.GetFilePath(file.Value);


        ///<inheritdoc/>
        public override ShellResult HostStart(HostStart Options) {

            var hostConfig = GetFile(Options.HostConfig);


            var result = VerifyConfig(Options.Console.Value, Options.MachineName.Value, hostConfig);
            result.AssertTrue(InvalidConfiguration.Throw, Options.HostConfig.Value ?? "<none>");

            // Start the service.

            RudService = StartService(HostConfiguration, ServiceConfiguration);


            return new ResultStartService() {
                Success = true,
                RudService = RudService
                };
            }

        ///<inheritdoc/>
        public override ShellResult HostVerify(HostVerify Options) {
            var hostConfig = GetFile(Options.HostConfig);

            var result = VerifyConfig(Options.Console.Value, Options.MachineName.Value, hostConfig);

            result.AssertTrue(InvalidConfiguration.Throw);



            return new Result() {
                Success = true
                };
            }

        /// <summary>
        /// Verify the configuration specified in <paramref name="hostConfig"/> and extract the host 
        /// description for <paramref name="hostConfig"/>.
        /// </summary>
        /// <param name="console"></param>
        /// <param name="machineName"></param>
        /// <param name="hostConfig"></param>
        /// <returns></returns>
        public bool VerifyConfig(
                bool console,
                string machineName,
                string hostConfig) {

            Console = console;

            // Fetch the canonical machine name from the system registry or equivalent and convert
            // to lower case.
            if (machineName == null) {
                MachineName = System.Environment.MachineName.ToLower();
                if (Console) {
                    System.Console.WriteLine($"HostName: {MachineName} (default)");
                    }
                }
            else {
                MachineName = machineName.ToLower();
                System.Console.WriteLine($"HostName: {MachineName}");
                }


            Configuration = JsonReader.ReadFile<Configuration>(hostConfig, false);

            HostConfiguration = Configuration.GetHostConfiguration(MachineName);
            ServiceConfiguration = Configuration.GetServiceConfiguration(HostConfiguration);


            return true;

            }

        /// <summary>
        /// Start the service
        /// </summary>
        /// <param name="hostConfiguration">The host configuration.</param>
        /// <param name="serviceConfiguration">The service configuration</param>
        /// <returns>The RUD service</returns>
        public RudService StartService(HostConfiguration hostConfiguration, ServiceConfiguration serviceConfiguration) {



            var providers = new List<RudProvider>();

            // add in the management service 

            if (ServiceDescriptionDictionary.TryGetValue(
                ServiceManagementProvider.WellKnown, out var managementProviderDescription)) {
                }
            else {
                managementProviderDescription = ServiceManagementProvider.ServiceDescriptionHost;
                }
            providers.Add(managementProviderDescription.Factory(
                        serviceConfiguration, hostConfiguration));


            var credential = HostConfiguration.GetCredential();

            // Need to extract the host credential here...


            var service = new RudService(providers, credential);

            var sigintReceived = false;
            // Catch SIGINT
            System.Console.CancelKeyPress += (_, ea) => {
                // Tell .NET to not terminate the process
                ea.Cancel = true;

                Screen.WriteLine("Received SIGINT (Ctrl+C)");
                service.Dispose();
                sigintReceived = true;
                };

            // Catch SIGTERM
            AppDomain.CurrentDomain.ProcessExit += (_, _) => {
                if (!sigintReceived) {
                    Screen.WriteLine("Received SIGTERM");
                    service.Dispose();
                    }
                else {
                    Screen.WriteLine("Received SIGTERM, ignoring it because already processed SIGINT");
                    }
                };

            return service;
            }


        }

    /// <summary>
    /// Host Shell Command Line Interpreter.
    /// </summary>
    public partial class CommandLineInterpreter {





        }
    }
