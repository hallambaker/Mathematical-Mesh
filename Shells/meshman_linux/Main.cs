using System;
using System.Collections.Generic;
using System.Diagnostics;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Mesh.MeshMan;

/// <summary>
/// 
/// </summary>
namespace Meshman_Windows {

    /// <summary>
    /// 
    /// </summary>
    public class _Main {

        static _Main() {
            Goedel.Platform.PlatformFramework.Initialize();
            MeshWindows.Initialize();
            }

        static void Main(string[] args) {
            var CommandLineInterpreter = new CommandLineInterpreter();


            CommandLineInterpreter.MainMethod(args);
            }
        }

    }