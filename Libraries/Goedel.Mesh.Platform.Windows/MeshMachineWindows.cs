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
        public static string FilePersonalProfile(string Fingerprint) => 
            Constants.FileProfilesPersonal + "\\" + Fingerprint + ".mmmp";

        /// <summary>
        /// Construct filename for a mesh personal profile
        /// </summary>
        /// <param name="Fingerprint">Fingerprint identifying data</param>
        /// <returns>The file name.</returns>
        public static string FileDeviceProfile(string Fingerprint) => 
            Constants.FileProfilesDevice + "\\" + Fingerprint + ".mmmd";

        /// <summary>
        /// Construct filename for a mesh personal profile
        /// </summary>
        /// <param name="Fingerprint">Fingerprint identifying data</param>
        /// <returns>The file name.</returns>
        public static string FileApplicationlProfile(string Fingerprint) => 
            Constants.FileProfilesApplication + "\\" + Fingerprint + ".mmma";

        }

    /// <summary>Machine session class for Windows in native mode.</summary>
    public partial class MeshMachineWindows : MeshMachineCached {

        /// <summary>
        /// Register the delegates for handling Windows native registrations with
        /// the Registration class stubs.
        /// </summary>
        /// <param name="TestMode">If true, the application will be initialized in
        /// test/debug mode.</param>
        public static void Initialize(bool TestMode = false) {
            if (Current == null) {
                Current = new MeshMachineWindows();
                }
            }

        /// <summary>
        /// Default constructor, get values from the current machine.
        /// </summary>
        public MeshMachineWindows() => Fill();

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
                    var SignedProfile = SignedPersonalProfile.FromFile(Filename, KeySet.Key);

                    var Profile = new SessionPersonal (SignedProfile, this, Portals);
                    if (Profile != null) {
                        Register(Profile);
                        // ToDo: implement archiving of profiles
                        //// add Archive n 
                        //var Archive = KeySet.GetValueString("Archive");
                        //Profile.Archive = Archive;
                        if (KeySet.Default) {
                            Personal = Profile;
                            }
                        }
                    }
                }

            foreach (var Key in ApplicationKeys) {
                if (Key.Key.Length > 10) {
                    var ApplicationProfile = GetLocalApplicationProfile(Key.Value, Key.Key);

                    ApplicationProfiles.Add(ApplicationProfile);

                    //var Profile = new SessionApplication(ApplicationProfile, this);
                    //if (Profile != null) {
                    //    ApplicationProfilesByUDF.AddSafe(Key.Key, Profile); // NYI check if present
                    //    }
                    }
                else {
                    ApplicationProfilesDefault.AddSafe(Key.Key, Key.Value); // NYI check if present
                    }
                }

            foreach (var Key in DeviceKeys) {
                if (Key.Key != "") {
                    //Key.Key, Key.Value
                    var DeviceProfile = SignedDeviceProfile.FromFile(Key.Value, Key.Key);
                    var Profile = new SessionDevice (DeviceProfile, this);
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

        private static ApplicationProfile GetLocalApplicationProfile (string File = null, string UDF = null) {
            if (File == null) {
                var FileName = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\"
                            + Constants.RegistryApplication, UDF, null);
                File = FileName as string;
                }
            var SignedProfile = SignedApplicationProfile.FromFile(File, UDF);

            try {
                return SignedProfile.ApplicationProfile;
                }
            catch {
                return null;
                }
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
            ApplicationProfilesByUDF.Clear();
            ApplicationProfilesDefault.Clear();
            DeviceProfiles.Clear();
            }

        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        /// <param name="SignedProfile">Profile to add.</param>
        /// <returns>Registration for the created profile.</returns>
        public override SessionDevice Add(SignedDeviceProfile SignedProfile) {
            var SessionDevice = new SessionDevice(SignedProfile, this);
            DeviceProfiles.AddSafe(SignedProfile.Identifier, SessionDevice);
            WriteToLocal(SessionDevice);
            return SessionDevice;
            }

        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        /// <param name="SignedProfile">Profile to add.</param>
        /// <returns>Registration for the created profile.</returns>
        public override SessionPersonal Add(SignedPersonalProfile SignedProfile) {
            var Registration = new SessionPersonal(SignedProfile, this);
            Register(Registration);
            return Registration;
            }

        public override void WriteToLocal (SessionPersonal SessionPersonal, bool Default = false) {
            var UDF = SessionPersonal.UDF;
            var KeyName = Constants.RegistryPersonal;

            var Hive = Microsoft.Win32.Registry.CurrentUser;
            var FileName = MeshWindows.FilePersonalProfile(UDF);

            Directory.CreateDirectory(Constants.FileProfilesPersonal);
            var SubKeyName = KeyName + @"\" + UDF;
            var SubKey = Hive.CreateSubKey(SubKeyName);

            SubKey.SetValue("", FileName);
            if (SessionPersonal.Portals != null) {
                SubKey.SetValue("Portals", SessionPersonal.Portals.ToArray(),
                        Microsoft.Win32.RegistryValueKind.MultiString);
                }
            SubKey.SetValue("Archive", "TBS");

            File.WriteAllText(FileName, SessionPersonal.SignedPersonalProfile.ToString());

            if (Default) {
                MakeDefault(SessionPersonal);
                }
            }

        public override void MakeDefault (SessionPersonal SessionPersonal) {
            var Hive = Microsoft.Win32.Registry.CurrentUser;
            var Key = Hive.CreateSubKey(Constants.RegistryPersonal);
            var Exists = Key.GetValue("") == null;
            Key.SetValue("", SessionPersonal.UDF);
            }


        public override void WriteToLocal (SessionApplication SessionApplication, bool Default = false) {
            var Hive = Microsoft.Win32.Registry.CurrentUser;
            var Key = Hive.CreateSubKey(Constants.RegistryApplication);
            var UDF = SessionApplication.UDF;
            var FileName = MeshWindows.FileApplicationlProfile(UDF);

            Directory.CreateDirectory(Constants.FileProfilesApplication);

            Key.SetValue(UDF, FileName);

            File.WriteAllText(FileName, SessionApplication.SignedApplicationProfile.ToString());

            if (Default) {
                MakeDefault(SessionApplication);
                }
            }

        public override void MakeDefault(SessionApplication SessionApplication) => throw new NYI(); // Do we even make defaujlt application sessions on the machine?


        public override void MakeDefault (SessionDevice SessionDevice) {
            var Hive = Microsoft.Win32.Registry.CurrentUser;
            var Key = Hive.CreateSubKey(Constants.RegistryDevice);
            Key.SetValue("", SessionDevice.UDF);
            }


        /// <summary>
        /// Write values to registry.
        /// </summary>
        /// <param name="Default">If true, make this the default.</param>
        public override void WriteToLocal (SessionDevice Device, bool Default = false) {
            var UDF = Device.UDF;

            var Hive = Microsoft.Win32.Registry.CurrentUser;
            var Key = Hive.CreateSubKey(Constants.RegistryDevice);
            var FileName = MeshWindows.FileDeviceProfile(UDF);

            Directory.CreateDirectory(Constants.FileProfilesDevice);

            Key.SetValue(UDF, FileName);

            File.WriteAllText(FileName, Device.SignedDeviceProfile.ToString());

            if (Default) {
                MakeDefault(Device);
                }
            }

        // May or may not need to override these

        //public override void GetFromPortal (SessionApplication SessionApplication) {
        //    }
        //public override void WriteToPortal (SessionApplication SessionApplication) {
        //    }

        //public override void MakeDefault (SessionApplication SessionApplication) {
        //    }


        }
    }
