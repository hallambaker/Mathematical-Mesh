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

    /// <summary>Machine session for Linux platform.</summary>
    public partial class MeshMachineLinux : MeshMachineCached {

        /// <summary>Returns the root directory for the profile data.</summary>
        public string RootDirectory { get; }

        /// <summary>
        /// Construct filename for a mesh personal profile
        /// </summary>
        /// <param name="Fingerprint">Fingerprint identifying data</param>
        /// <returns>The file name.</returns>
        public string FilePersonalProfile (string Fingerprint) {
            return RootDirectory + "\\" + Fingerprint + Constants.PersonalExtension;
            }

        /// <summary>
        /// Construct filename for a mesh personal profile
        /// </summary>
        /// <param name="Fingerprint">Fingerprint identifying data</param>
        /// <returns>The file name.</returns>
        public string FileDeviceProfile (string Fingerprint) {
            return RootDirectory + "\\" + Fingerprint + Constants.DeviceExtension;
            }

        /// <summary>
        /// Construct filename for a mesh personal profile
        /// </summary>
        /// <param name="Fingerprint">Fingerprint identifying data</param>
        /// <returns>The file name.</returns>
        public string FileApplicationlProfile (string Fingerprint) {
            return RootDirectory + "\\" + Fingerprint + Constants.ApplicationExtension;
            }



        /// <summary>
        /// Register the delegates for handling Windows native registrations with
        /// the Registration class stubs.
        /// </summary>
        /// <param name="TestMode">If true, the application will be initialized in
        /// test/debug mode.</param>
        /// <param name="Load">Load data from the machine store.</param>
        public static void Initialize(bool TestMode = false, bool Load = true) {

            if (Current == null) {
                Current = new MeshMachineLinux(Load : Load);
                }
            }

        /// <summary>
        /// Default constructor, get values from the current machine.
        /// </summary>
        /// <param name="RootDirectory">The root directory for the session information</param>
        /// <param name="Load">If true load the data from the machine stores.</param>
        public MeshMachineLinux (string RootDirectory = null, bool Load =true) {
            this.RootDirectory = RootDirectory ??
                System.IO.Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.UserProfile),
                        Constants.MeshProfiles) ;
            if (Load ) {
                Fill();
                }
            }


        


        /// <summary>
        /// Return a new machine registration.
        /// </summary>
        public override void Reload () {
            base.Erase();
            Fill();
            }


        /// <summary>
        /// Fetch the latest version of the profile version
        /// </summary>
        void Fill () {


            // Create the directory if it does not exist already.
            Directory.CreateDirectory(RootDirectory);

            // Map personal profiles
            var PersonalFiles = Directory.GetFiles(RootDirectory, Constants.PersonalExtensionSearch);
            foreach (var File in PersonalFiles) {
                var PersonalReg = new PersonalSessionLinux(this, File);

                if (PersonalReg != null) {
                    Register(PersonalReg);

                    var Personal = PersonalReg.PersonalProfile;
                    foreach (var DeviceEntry in Personal.Devices) {
                        var DeviceReg = new RegistrationDeviceLinux(this, UDF: DeviceEntry.UDF);
                        if (DeviceReg != null) {
                            Register(DeviceReg);
                            }
                        }
                    }


                }

            //var DeviceFiles = Directory.GetFiles(RootDirectory, Constants.DeviceExtensionSearch);
            //foreach (var File in DeviceFiles) {
            //    var Registration = new RegistrationDeviceLinux(File);
            //    Register(Registration);
            //    }

            //var ApplicationFiles = Directory.GetFiles(RootDirectory, Constants.ApplicationExtensionSearch);
            //foreach (var File in ApplicationFiles) {
            //    var Registration = new RegistrationApplicationLinux(File);
            //    Register(Registration);
            //    }

            //throw new NYI();
            }



        /// <summary>Erase the profile and associated keys.</summary>
        public override void Erase() {
            if (Constants.TestMode.False()) {
                return; //
                }
            // Delete the stuff here

            Reload();
            }


        private static void DirectoryDelete(string Path) {
            if (!Directory.Exists(Path)) {
                return;
                }
            try {
                var DirectoryInfo = new DirectoryInfo(Path);
                foreach (var Entry in DirectoryInfo.GetFiles()) {
                    Entry.Delete();
                    }
                Directory.Delete(Path, true);
                }
            catch {
                }

            }
        

        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        /// <param name="SignedProfile">Profile to add.</param>
        /// <returns>Registration for the created profile.</returns>
        public override RegistrationDevice Add(SignedDeviceProfile SignedProfile) {
            var Registration = new RegistrationDeviceLinux(SignedProfile, this);
            DeviceProfiles.AddSafe(SignedProfile.Identifier, Registration); // NYI check if present
            return Registration;
            }

        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        /// <param name="SignedProfile">Profile to add.</param>
        /// <returns>Registration for the created profile.</returns>
        public override SessionPersonal Add (SignedPersonalProfile SignedProfile) {
            var Registration = new PersonalSessionLinux(SignedProfile, this);
            Register(Registration);
            return Registration;
            }

        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        /// <param name="ApplicationProfile">Profile to add.</param>
        /// <returns>Registration for the created profile.</returns>
        public override SessionApplication Add(ApplicationProfile ApplicationProfile) {
            var Registration = new RegistrationApplicationLinux(ApplicationProfile, this);
            ApplicationProfiles.AddSafe(ApplicationProfile.Identifier, Registration); // NYI check if present

            ApplicationProfilesDefault.AddSafe(ApplicationProfile.Tag(), ApplicationProfile.Identifier);
            return Registration;
            }

        }

    }
