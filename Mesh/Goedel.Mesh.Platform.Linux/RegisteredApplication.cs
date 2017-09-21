//   Copyright © 2015 by Comodo Group Inc.
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
//  
//  
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Goedel.Utilities;
using Goedel.Cryptography;

namespace Goedel.Mesh.Platform.Linux {


    /// <summary>
    /// Describes the registration of a device profile on a machine.
    /// </summary>
    public class RegistrationApplicationLinux : RegistrationApplicationCached {

        /// <summary>Return the Mesh Machine registration</summary>
        public MeshMachineLinux RegistrationMachineLinux  => MeshMachine as MeshMachineLinux;


        /// <summary>
        /// Fetch the latest version of the profile version
        /// </summary>
        public override void GetFromPortal() {
            }

        /// <summary>
        /// Register request to register an application.
        /// </summary>
        /// <param name="Machine">The machine session to bind to.</param>
        /// <param name="ApplicationProfile">The application profile</param>
        public RegistrationApplicationLinux (ApplicationProfile ApplicationProfile,
                        MeshMachineLinux Machine) : base(ApplicationProfile, Machine) {
            }

        /// <summary>
        /// Read a personal registration from a file
        /// </summary>
        /// <param name="File">Filename on local machine</param>
        /// <param name="Machine">The machine session to bind to.</param>
        public RegistrationApplicationLinux (MeshMachineLinux Machine, string File = null)
                    : base(SignedApplicationProfile.FromFile(File).ApplicationProfile, Machine) {
            }


 
        /// <summary>
        /// Write values to file
        /// </summary>
        /// <param name="Default">If true, mark as the default device profile.</param>
        public override void WriteToLocal (bool Default = true) {
            var FileName = RegistrationMachineLinux.FileApplicationlProfile(UDF);
            Directory.CreateDirectory(RegistrationMachineLinux.RootDirectory);
            if (Default) {
                SignedApplicationProfile.Unauthenticated = new Advice() {
                    Default = DateTime.Now
                    };
                }
            else {
                SignedApplicationProfile.Unauthenticated = null;
                }

            File.WriteAllText(FileName, SignedApplicationProfile.ToString());
            }


        }
    }
