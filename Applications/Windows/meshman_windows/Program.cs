using System;


using Goedel.Cryptography.Windows;

using Goedel.Utilities;
using Goedel.Mesh.Shell;

namespace meshman_windows {
    public class Program {

        // Register Windows specific methods to override the core implementations.
        static Program() => Initialization.Initialized.AssertTrue(Internal.Throw);

        static void Main(string[] args) {
            var commandLineInterpreter = new CommandLineInterpreter();
            commandLineInterpreter.MainMethod(args);
            }

        }
    }
