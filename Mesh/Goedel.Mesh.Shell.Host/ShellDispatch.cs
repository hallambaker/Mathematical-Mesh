using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Mesh.Client;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Mesh.ServiceAdmin;

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
