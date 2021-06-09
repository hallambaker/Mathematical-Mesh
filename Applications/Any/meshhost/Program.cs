using Goedel.Utilities;
using Goedel.Mesh.Shell.Host;
using Goedel.Mesh.Server;
using Goedel.Cryptography.Core;
using Goedel.Mesh.Management;

namespace meshhost {
    ///<summary>Main calling program.</summary> 
    public class Program {

        static Program() => Initialization.Initialized.AssertTrue(Internal.Throw);

        static void Main(string[] args) {
            var commandLineInterpreter = new CommandLineInterpreter();

            commandLineInterpreter.AddService(PublicMeshService.ServiceDescription);
            commandLineInterpreter.AddService(ServiceManagementProvider.ServiceDescription);

            commandLineInterpreter.MainMethod(args);
            }
        }
    }
