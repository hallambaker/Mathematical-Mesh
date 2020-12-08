using System;
using System.Collections.Generic;
using System.Diagnostics;
using Goedel.Cryptography;


/// <summary>
/// 
/// </summary>
namespace Goedel.Combined.Shell.Client {

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