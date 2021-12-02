﻿#region // Copyright - MIT License
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


using System;
using Goedel.Mesh;
using Goedel.Mesh.Shell;
using Goedel.Utilities;


#if NET6_0_WINDOWS_OR_GREATER
using Goedel.Cryptography.Windows;
//using Goedel.Cryptography.Core;
#elif NET6_0_MACOS_OR_GREATER
using Goedel.Cryptography.Core;
#else
#endif



#if !(_Github_)
[assembly: System.Reflection.AssemblyKeyName("SigningKeyDeveloper")]
#endif

namespace meshman;

///<summary>Main calling program.</summary> 
public class Program {


    static Program() => Goedel.Cryptography.Windows.Initialization.Initialized.AssertTrue(
        Goedel.Mesh.Internal.Throw);

    static void Main(string[] args) {

        Shell shell = new Shell(
            ) {
            NoCatch = true,
            MeshMachine = new MeshMachineCore()
            };
        shell.Dispatch(args, Console.Out);


        //var commandLineInterpreter = new CommandLineInterpreter();
        //commandLineInterpreter.MainMethod(args);
        }
    }
