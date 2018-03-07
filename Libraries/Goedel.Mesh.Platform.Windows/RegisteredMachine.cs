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
using Goedel.IO;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Mesh.Portal;
using Goedel.Mesh.Portal.Client;

namespace Goedel.Mesh.Platform.Windows {

    /// <summary>Windows specific constants and functions.</summary>
    public static class MeshWindows {

        /// <summary>
        /// Construct filename for a mesh personal profile
        /// </summary>
        /// <param name="Fingerprint">Fingerprint identifying data</param>
        /// <returns>The file name.</returns>
        public static string FilePersonalProfile(string Fingerprint) {
            return Constants.FileProfilesPersonal + "\\" + Fingerprint + ".mmmp";
            }

        /// <summary>
        /// Construct filename for a mesh personal profile
        /// </summary>
        /// <param name="Fingerprint">Fingerprint identifying data</param>
        /// <returns>The file name.</returns>
        public static string FileDeviceProfile(string Fingerprint) {
            return Constants.FileProfilesDevice + "\\" + Fingerprint + ".mmmd";
            }

        /// <summary>
        /// Construct filename for a mesh personal profile
        /// </summary>
        /// <param name="Fingerprint">Fingerprint identifying data</param>
        /// <returns>The file name.</returns>
        public static string FileApplicationlProfile(string Fingerprint) {
            return Constants.FileProfilesApplication + "\\" + Fingerprint + ".mmma";
            }

        }

    /// <summary>Machine session class for Windows in native mode.</summary>
    public partial class RegistrationMachineWindows : MeshMachineCached {

        /// <summary>
        /// Register the delegates for handling Windows native registrations with
        /// the Registration class stubs.
        /// </summary>
        /// <param name="TestMode">If true, the application will be initialized in
        /// test/debug mode.</param>
        public static void Initialize(bool TestMode = false) {
            if (Current == null) {
                Current = new RegistrationMachineWindows();
                }
            }

        /// <summary>
        /// Default constructor, get values from the current machine.
        /// </summary>
        public RegistrationMachineWindows() {
            Fill();
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
        void Fill() {


            // Hack: Check to see that default personal etc. profile is set.

            var ProfileKeys = Windows.Register.GetSubKeys(Constants.RegistryPersonal);
            var DeviceKeys = Windows.Register.GetKeys(Constants.RegistryDevice);
            var ApplicationKeys = Windows.Register.GetKeys(Constants.RegistryApplication);
            string DefaultDevice = null;

            foreach (var KeySet in ProfileKeys) {
                var Filename = KeySet.GetValueString("");

                if (Filename != "") {
                    var Portals = KeySet.GetValueMultiString("Portals");
                    var Profile = new RegistrationPersonalWindows (this, KeySet.Key, Filename, Portals);
                    if (Profile != null) {
                        Register(Profile);
                        // add Archive
                        var Archive = KeySet.GetValueString("Archive");
                        Profile.Archive = Archive;
                        if (KeySet.Default) {
                            Personal = Profile;
                            }
                        }
                    }
                }

            foreach (var Key in ApplicationKeys) {
                if (Key.Key.Length > 10) {
                    var Profile = new RegistrationApplicationWindows(this, Key.Key, Key.Value);
                    if (Profile != null) {
                        ApplicationProfiles.AddSafe(Key.Key, Profile); // NYI check if present
                        }
                    }
                else {
                    ApplicationProfilesDefault.AddSafe(Key.Key, Key.Value); // NYI check if present
                    }
                }


            foreach (var Key in DeviceKeys) {
                if (Key.Key != "") {
                    var Profile = new RegistrationDeviceWindows (Key.Key, Key.Value);
                    if (Profile != null) {
                        DeviceProfiles.AddSafe(Key.Key, Profile); // NYI check if present
                        }
                    }
                else {
                    DefaultDevice = Key.Value; 
                    }
                }

            if (DefaultDevice != null) {
                DeviceProfiles.TryGetValue(DefaultDevice, out var DeviceOut);
                Device = DeviceOut;
                }

            return;
            }



        /// <summary>Erase the profile and associated keys.</summary>
        public override void Erase() {

            if (Constants.TestMode.False()) {
                return; //
                }

            DirectoryTools.DirectoryDelete(Constants.RoamingRoot);        // Personal and application profiles
            DirectoryTools.DirectoryDelete(Constants.NonRoamingRoot);     // Device specific profiles

            var Hive = Microsoft.Win32.Registry.CurrentUser;

            Hive.DeleteSubKeyTree(Constants.RegistryRoot, false);
            foreach (var Erase in Goedel.Cryptography.Platform.EraseTest) {
                Erase();
                }

            PersonalProfilesUDF.Clear();
            PersonalProfilesPortal.Clear();
            ApplicationProfiles.Clear();
            ApplicationProfilesDefault.Clear();
            DeviceProfiles.Clear();
            }


        

        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        /// <param name="SignedProfile">Profile to add.</param>
        /// <returns>Registration for the created profile.</returns>
        public override RegistrationDevice Add(SignedDeviceProfile SignedProfile) {
            var Registration = new RegistrationDeviceWindows(SignedProfile) {
                MeshMachine = this
                };
            DeviceProfiles.AddSafe(SignedProfile.Identifier, Registration); // NYI check if present
            return Registration;
            }

        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        /// <param name="SignedProfile">Profile to add.</param>
        /// <returns>Registration for the created profile.</returns>
        public override SessionPersonal Add(SignedPersonalProfile SignedProfile) {
            var Registration = new RegistrationPersonalWindows(SignedProfile, this);
            Register(Registration);
            return Registration;
            }



        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        /// <param name="ApplicationProfile">Profile to add.</param>
        /// <returns>Registration for the created profile.</returns>
        public override SessionApplication Add(ApplicationProfile ApplicationProfile) {
            var Registration = new RegistrationApplicationWindows(ApplicationProfile,this);
            ApplicationProfiles.AddSafe(ApplicationProfile.Identifier, Registration); // NYI check if present

            ApplicationProfilesDefault.AddSafe(ApplicationProfile.Tag(), ApplicationProfile.Identifier);
            return Registration;
            }

        /// <summary>
        /// Locate a device profile by identifier
        /// </summary>
        /// <param name="RegistrationDevice">The returned profile.</param>
        /// <param name="ID">UDF fingerprint of the profile or short form ID</param>
        /// <returns>True if the profile is found, otherwise false.</returns>
        public override bool Find(string ID, out RegistrationDevice RegistrationDevice) {
            return DeviceProfiles.TryGetValue (ID, out RegistrationDevice);
            }

        /// <summary>
        /// Locate a device profile by identifier
        /// </summary>
        /// <param name="RegistrationApplication">The returned profile.</param>
        /// <param name="ID">UDF fingerprint of the profile or short form ID</param>
        /// <returns>True if the profile is found, otherwise false.</returns>
        public override bool Find(string ID, out SessionApplication RegistrationApplication) {
            return ApplicationProfiles.TryGetValue(ID, out RegistrationApplication);
            }

        /// <summary>
        /// Locate a device profile by identifier
        /// </summary>
        /// <param name="RegistrationPersonal">The returned profile.</param>
        /// <param name="ID">UDF fingerprint of the profile or short form ID</param>
        /// <returns>True if the profile is found, otherwise false.</returns>
        public override bool Find(string ID, out SessionPersonal RegistrationPersonal) {
            return PersonalProfilesUDF.TryGetValue(ID, out RegistrationPersonal);
            }

        }

    }
