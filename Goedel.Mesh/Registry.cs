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

using System.IO;
using Goedel.Protocol;
using Goedel.Cryptography.Registry;



namespace Goedel.Mesh {


    public partial class AccountProfile {

        string UDF {
            get { return Profile != null ? Profile.UDF : null; }
            }

        /// <summary>
        /// Write to the O/S appropriate store.
        /// </summary>
        public void ToRegistry() {
            var FileName = Register.WriteFile(Constants.RegistryPersonal, Constants.FileProfiles, Profile.UDF);
            File.WriteAllText(FileName, ToString());
            }

        }


    public partial class SignedPersonalProfile {
        /// <summary>
        /// Write the personal profile to a file and store the filename in a 
        /// registry key and set as the default profile.
        /// </summary>
        public void ToRegistry() {
            var FileName = Register.WriteFile(Constants.RegistryPersonal,
                Constants.FileProfiles, UDF);
            File.WriteAllText(FileName, ToString());
            }

        /// <summary>
        /// Search for the default profile on the local machine
        /// </summary>
        /// <returns>The signed profile if found or null otherwise.</returns>
        public static SignedPersonalProfile GetLocal() {
            return GetLocal(null);
            }

        /// <summary>
        /// Search for the specified profile on the local machine.
        /// </summary>
        /// <param name="UDF">Fingerprint of the profile to find.</param>
        /// <returns>The signed profile if found or null otherwise.</returns>
        public static SignedPersonalProfile GetLocal(string UDF) {
            var FileName = Register.ReadFile(Constants.RegistryPersonal,
                    Constants.FileProfiles, UDF);

            if (FileName == null) {
                return null;
                }

            var Reader = JSONReader.OfFile(FileName);
            var Result = SignedPersonalProfile.FromTagged(Reader);

            return Result;
            }

        }


    public partial class SignedDeviceProfile {


        /// <summary>
        /// Write this device profile to a registry key and set as the default profile.
        /// </summary>
        public void ToRegistry() {
            ToRegistry("");
            }

        /// <summary>
        /// Write this device profile to a registry key as a named profile.
        /// </summary>
        public void ToRegistry(string Name) {
            var FileName = Register.WriteFile(Constants.RegistryDevice,
                Constants.FileProfiles, Name, UDF);
            File.WriteAllText(FileName, ToString());

            }

        /// <summary>
        /// Get the default device profile for the local machine.
        /// </summary>
        /// <returns>The signed profile</returns>
        public static SignedDeviceProfile GetLocal() {
            return GetLocal(null, null);
            }

        /// <summary>
        /// Get the specified device profile for the local machine.
        /// </summary>
        /// <param name="Label">The device profile label</param>
        /// <returns>The signed profile</returns>
        public static SignedDeviceProfile GetLocal(string Label) {
            return GetLocal(null, null, Label);
            }

        /// <summary>
        /// Get the specified device profile for the local machine.
        /// </summary>
        /// <param name="Name">The device profile name</param>
        /// <param name="Description">The device profile description.</param>
        /// <returns>The signed profile</returns>
        public static SignedDeviceProfile GetLocal(string Name, string Description) {
            return GetLocal(Name, Description, null);
            }

        /// <summary>
        /// Get the specified device profile for the local machine.
        /// </summary>
        /// <param name="Name">The device profile name</param>
        /// <param name="Description">The device profile description.</param>
        /// <param name="Label">The device profile label</param> 
        /// <returns>The signed profile</returns>
        public static SignedDeviceProfile GetLocal(string Name, string Description, string Label) {
            var FileName = Register.ReadFile(Constants.RegistryDevice,
                    Constants.FileProfiles, Label);

            // No device profile found?
            // Create a new one.
            if (FileName == null) {
                if (Name == null | Description == null) {
                    return null;
                    }
                var Profile = new SignedDeviceProfile(Name, Description);
                Profile.ToRegistry(Label);
                return Profile;
                }

            var Reader = JSONReader.OfFile(FileName);
            var Result = FromTagged(Reader);

            return Result;
            }



        //void Dump(RegistryKey Key) {
        //    var Names = Key.GetValueNames();
        //    foreach (var Name in Names) {

        //        Goedel.Debug.Trace.WriteLine("Name {0}={1}", Name, Key.GetValue(Name));
        //        }

        //    }

        /// <summary>
        /// Read this device profile from a registry key
        /// </summary>
        public static SignedDeviceProfile FromRegistry() {
            var Hive = Microsoft.Win32.Registry.CurrentUser;
            var Key = Hive.OpenSubKey(Constants.RegistryDevice);
            var Names = Key.GetValueNames();

            foreach (var Name in Names) {
                Goedel.Debug.Trace.WriteLine("Name {0}={1}", Name, Key.GetValue(Name));
                var Result = SignedDeviceProfile.FromTagged(Key.GetValue(Name).ToString());
                if (Result != null) {
                    Result.Unpack();
                    return Result;
                    }
                }

            return null;
            }
        }

    }
