using System;
using System.Collections.Generic;
using System.Diagnostics;
using Goedel.Cryptography;
using Goedel.Mesh.MeshMan;

/// <summary>
/// 
/// </summary>
namespace Meshman_OSX {

    /// <summary>
    /// 
    /// </summary>
    public class _Main {

        static _Main() {
            Goedel.Mesh.Mesh.Initialize();
            }

        static void Main(string[] args) {
            var CommandLineInterpreter = new CommandLineInterpreter();
            CommandLineInterpreter.MainMethod(args);
            }
        }

    }