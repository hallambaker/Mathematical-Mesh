using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Mesh.Client;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Mesh.ServiceAdmin;
using Goedel.IO;
using System;
using System.Collections.Generic;
using System.IO;

namespace Goedel.Mesh.Shell.Host {

    /// <summary>
    /// The command shell.
    /// </summary>
    public partial class Shell : _Shell {

        /// <summary>
        /// Post processing action
        /// </summary>
        /// <param name="result"></param>
        public void _PostProcess(ShellResult result) {
            }


        bool Console;
        string MachineName;
        ServiceAdmin.ServiceConfig HostConfig;


        public override ShellResult HostStart(HostStart Options) {
            var result = VerifyConfig(Options.Console.Value, Options.MachineName.Value, Options.HostConfig.Value);
            
            result.AssertTrue(NYI.Throw);

            return new Result() {
                Success = true
                };
            }


        public override ShellResult HostVerify(HostVerify Options) {
            var result = VerifyConfig(Options.Console.Value, Options.MachineName.Value, Options.HostConfig.Value);

            result.AssertTrue(NYI.Throw);

            // Start the service.



            return new Result() {
                Success = true
                };
            }

        bool VerifyConfig(
                bool console,
                string machineName,
                string hostConfig) {

            Console = console;

            // Fetch the canonical machine name from the system registry or equivalent and convert
            // to lower case.
            if (machineName == null) {
                MachineName = System.Environment.MachineName.ToLower();
                if (console) {
                    System.Console.WriteLine($"HostName: {MachineName} (default)");
                    }
                }
            else {
                MachineName = machineName.ToLower();
                System.Console.WriteLine($"HostName: {MachineName}");
                }

            using var stream = hostConfig.OpenFileReadShared();
            using var reader = new JsonBcdReader(stream);
            var serviceAdmin = ServiceConfig.FromJson(reader, false);

            return true;

            }


        }

    public partial class CommandLineInterpreter {

        ///<summary>Dictionary of service descriptions.</summary> 
        public Dictionary<string, ServiceDescription>
            ServiceDescriptionDictionary { get; } = new();


        /// <summary>
        /// Add a service provider to the hosting options.
        /// </summary>
        /// <param name="serviceDescription">The service description.</param>
        public void AddService(ServiceDescription serviceDescription) => 
            ServiceDescriptionDictionary.Add(serviceDescription.WellKnown, serviceDescription);



        }
    }
