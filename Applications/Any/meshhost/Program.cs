using Goedel.Utilities;
using Goedel.Mesh.Host;
using Goedel.Cryptography.Core;

namespace meshhost {
    ///<summary>Main calling program.</summary> 
    public class Program {

        static Program() => Initialization.Initialized.AssertTrue(Internal.Throw);

        static void Main(string[] args) {
            var commandLineInterpreter = new CommandLineInterpreter();
            commandLineInterpreter.MainMethod(args);
            }
        }
    }
