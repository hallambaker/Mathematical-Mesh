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

namespace Goedel.Mesh.Platform.Windows {

    /// <summary>
    /// Describes the registration of a device profile on a machine.
    /// </summary>
    public class RegistrationDeviceWindows : RegistrationDevice {


        /// <summary>Return the fingerprint.</summary>
        public override string UDF {
            get => SignedDeviceProfile?.UDF;
            }



        /// <summary>
        /// Read a personal registration from a file
        /// </summary>
        /// <param name="UDF">File fingerprint</param>
        /// <param name="File">Filename on local machine</param>
        public RegistrationDeviceWindows(string UDF = null, string File = null) {
            SignedDeviceProfile = SignedDeviceProfile.FromFile(File, UDF);
            }


        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        /// <param name="SignedDeviceProfile">The device profile</param>
        public RegistrationDeviceWindows(SignedDeviceProfile SignedDeviceProfile) {
            base.SignedDeviceProfile = SignedDeviceProfile;
            WriteToLocal();
            }

        /// <summary>
        /// Factory method to create from an identifier.
        /// </summary>
        /// <param name="UDF">Profile identifier, if null, the default profile is used.</param>
        /// <param name="File">Filename, if null, a default filename is constructed from
        /// the identifier.</param>
        /// <returns>The registration object</returns>
        public static RegistrationDevice Factory(string UDF = null, string File = null) {
            return new RegistrationDeviceWindows(UDF, File);
            }

        /// <summary>
        /// Factory method to create from a profile
        /// </summary>
        /// <param name="Profile">The profile to register</param>
        /// <param name="Portals">The portals at which the profile is registered.</param>
        /// <returns>The registration object</returns>
        public static RegistrationDevice Factory(
                            SignedDeviceProfile Profile) {
            return new RegistrationDeviceWindows(Profile);
            }


        /// <summary>
        /// Write values to registry.
        /// </summary>
        public override void WriteToLocal(bool Default = true) {
            var Hive = Microsoft.Win32.Registry.CurrentUser;
            var Key = Hive.CreateSubKey(Constants.RegistryDevice);
            var FileName = MeshWindows.FileDeviceProfile(UDF);

            Directory.CreateDirectory(Constants.FileProfilesDevice);

            Key.SetValue(UDF, FileName);

            File.WriteAllText(FileName, SignedDeviceProfile.ToString());
            }


        public override void MakeDefault () {
            var Hive = Microsoft.Win32.Registry.CurrentUser;
            var Key = Hive.CreateSubKey(Constants.RegistryDevice);
            Key.SetValue("", UDF);
            }


        }


    }
