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
using Goedel.Mesh.Portal.Client;

namespace Goedel.Mesh.Platform.Windows {


    /// <summary>
    /// Describes the registration of a device profile on a machine.
    /// </summary>
    public class RegistrationApplicationWindows : RegistrationApplicationCached {


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
        public RegistrationApplicationWindows (ApplicationProfile ApplicationProfile, 
                            MeshMachine Machine) : base(ApplicationProfile, Machine)  {
            this.ApplicationProfile = ApplicationProfile;
            }


        /// <summary>
        /// Read a personal registration from a file
        /// </summary>
        /// <param name="Machine">The machine session to bind to.</param>
        /// <param name="UDF">File fingerprint</param>
        /// <param name="File">Filename on local machine</param>
        public RegistrationApplicationWindows(MeshMachine Machine, 
                    string UDF=null, string File=null) : base (GetFromLocal(UDF, File), Machine) {
            }



        private static ApplicationProfile GetFromLocal (string UDF = null, string File = null) {
            if (File == null) {
                var FileName = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\"
                            + Constants.RegistryApplication, UDF, null);
                File = FileName as string;
                }
            var SignedProfile = SignedApplicationProfile.FromFile(File, UDF);
            return SignedProfile.ApplicationProfile;
            }

        /// <summary>Write to registry.</summary>
        /// <param name="Default">If true, make this the default.</param>
        public override void WriteToLocal(bool Default = true) {
            var Hive = Microsoft.Win32.Registry.CurrentUser;
            var Key = Hive.CreateSubKey(Constants.RegistryApplication);
            var FileName = MeshWindows.FileApplicationlProfile(UDF);

            Directory.CreateDirectory(Constants.FileProfilesApplication);

            Key.SetValue(UDF, FileName);

            File.WriteAllText(FileName, SignedApplicationProfile.ToString());

            }
        }
    }
