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

namespace Goedel.Mesh.Platform.Windows {

    public static class Platform {

        public static void Initialize () {
            RegistrationMachineWindows.Initialize();
            }

        /// <summary>
        /// Construct filename for a mesh personal profile
        /// </summary>
        /// <param name="Path">Path to write file to</param>
        /// <param name="Fingerprint">Fingerprint identifying data</param>
        /// <returns>The file name.</returns>
        public static string FilePersonalProfile(string Fingerprint) {
            return Constants.FileProfilesPersonal + "\\" + Fingerprint + ".mmmp";
            }

        /// <summary>
        /// Construct filename for a mesh personal profile
        /// </summary>
        /// <param name="Path">Path to write file to</param>
        /// <param name="Fingerprint">Fingerprint identifying data</param>
        /// <returns>The file name.</returns>
        public static string FileDeviceProfile(string Fingerprint) {
            return Constants.FileProfilesDevice + "\\" + Fingerprint + ".mmmd";
            }

        /// <summary>
        /// Construct filename for a mesh personal profile
        /// </summary>
        /// <param name="Path">Path to write file to</param>
        /// <param name="Fingerprint">Fingerprint identifying data</param>
        /// <returns>The file name.</returns>
        public static string FileApplicationlProfile(string Fingerprint) {
            return Constants.FileProfilesApplication + "\\" + Fingerprint + ".mmma";
            }

        }


    public partial class RegistrationMachineWindows : RegistrationMachine {

        /// <summary>
        /// The a dictionary of personal profiles indexed by fingerprint.
        /// </summary>
        public override Dictionary<string, RegistrationPersonal> PersonalProfiles {
            get { return _PersonalProfiles; }
            }
        Dictionary<string, RegistrationPersonal> _PersonalProfiles;

        /// <summary>
        /// A dictionary of application profiles indexed by fingerprint.
        /// </summary>
        public override Dictionary<string, RegistrationApplication> ApplicationProfiles {
            get { return _ApplicationProfiles; }
            }
        Dictionary<string, RegistrationApplication> _ApplicationProfiles;

        /// <summary>
        /// A dictionary of default application profiles indexed by application identifier;
        /// </summary>
        public override Dictionary<string, string> ApplicationProfilesDefault {
            get { return _ApplicationProfilesDefault; }
            }
        Dictionary<string, string> _ApplicationProfilesDefault;

        /// <summary>
        /// A dictionary of device profiles indexed by fingerprint.
        /// </summary>
        public override Dictionary<string, RegistrationDevice> DeviceProfiles {
            get { return _DeviceProfiles; }
            }
        Dictionary<string, RegistrationDevice> _DeviceProfiles;



        /// <summary>
        /// Register the delegates for handling Windows native registrations with
        /// the Registration class stubs.
        /// </summary>
        public static void Initialize() {
            if (Current == null) {
                Current = new RegistrationMachineWindows();
                }

            }

        /// <summary>
        /// Write out the configuration to the current machine.
        /// </summary>
        public override void Write() {

            }



        /// <summary>
        /// Default constructor, get values from the current machine.
        /// </summary>
        public RegistrationMachineWindows() {
            Fill();
            }

        // The default profile
        public override RegistrationPersonal Personal {
            get { return _Personal; }
            set {
                var Value = value as RegistrationPersonalWindows;
                _Personal = Value;
                Value.MakeDefault();
                }
            }
        RegistrationPersonal _Personal;

        // The default device
        public override RegistrationDevice Device {
            get { return _Device; }
            set {
                var Value = value as RegistrationDeviceWindows;
                _Device = Value;
                Value.MakeDefault();
                }
            }
        RegistrationDevice _Device;



        /// <summary>
        /// Fetch the latest version of the profile version
        /// </summary>
        void Fill() {

            _PersonalProfiles = new Dictionary<string, RegistrationPersonal>();
            _ApplicationProfiles = new Dictionary<string, RegistrationApplication>();
            _ApplicationProfilesDefault = new Dictionary<string, string>();
            _DeviceProfiles = new Dictionary<string, RegistrationDevice>();

            var ProfileKeys = Register.GetSubKeys(Constants.RegistryPersonal);
            var DeviceKeys = Register.GetKeys(Constants.RegistryDevice);
            var ApplicationKeys = Register.GetKeys(Constants.RegistryApplication);
            string DefaultDevice = null;


            foreach (var KeySet in ProfileKeys) {
                var Filename = KeySet.GetValueString("");

                if (Filename != "") {
                    var Portals = KeySet.GetValueMultiString("Portals");
                    var Profile = new RegistrationPersonalWindows (KeySet.Key, Filename, Portals);
                    if (Profile != null) {
                        PersonalProfiles.Add(KeySet.Key, Profile);

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
                    var Profile = new RegistrationApplicationWindows(Key.Key, Key.Value);
                    if (Profile != null) {
                        ApplicationProfiles.Add(Key.Key, Profile);
                        }
                    }
                else {
                    ApplicationProfilesDefault.Add(Key.Key, Key.Value);
                    }
                }


            foreach (var Key in DeviceKeys) {
                if (Key.Key != "") {
                    var Profile = new RegistrationDeviceWindows (Key.Key, Key.Value);
                    if (Profile != null) {
                        DeviceProfiles.Add(Key.Key, Profile);
                        }
                    }
                else {
                    DefaultDevice = Key.Value;
                    }
                }

            if (DefaultDevice != null) {
                RegistrationDevice DeviceOut;
                DeviceProfiles.TryGetValue(DefaultDevice, out DeviceOut);
                Device = DeviceOut;
                }

            return;
            }


        /// <summary>
        /// Fetch the latest version of the profile version
        /// </summary>
        public override void Refresh() {
            }



        /// <summary>Erase the profile and associated keys.</summary>
        public override void Erase() {

            if (Constants.TestMode.False()) {
                return; //
                }

            DirectoryDelete(Constants.RoamingRoot);        // Personal and application profiles
            DirectoryDelete(Constants.NonRoamingRoot);     // Device specific profiles

            var Hive = Microsoft.Win32.Registry.CurrentUser;

            Hive.DeleteSubKeyTree(Constants.RegistryRoot, false);


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
                // Ignore failures, we have done as much as possible
                }

            }
        

        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        /// <param name="SignedProfile">Profile to add.</param>
        /// <returns>Registration for the created profile.</returns>
        public override RegistrationDevice Add(SignedDeviceProfile SignedProfile) {
            var Registration = new RegistrationDeviceWindows(SignedProfile);
            DeviceProfiles.Add(SignedProfile.Identifier, Registration);
            return Registration;
            }

        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        /// <param name="SignedProfile">Profile to add.</param>
        /// <returns>Registration for the created profile.</returns>
        public override RegistrationPersonal Add(SignedPersonalProfile SignedProfile) {
            var Registration = new RegistrationPersonalWindows(SignedProfile);
            PersonalProfiles.Add(SignedProfile.Identifier, Registration);
            return Registration;
            }



        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        /// <param name="SignedProfile">Profile to add.</param>
        /// <returns>Registration for the created profile.</returns>
        public override RegistrationApplication Add(SignedApplicationProfile SignedProfile) {
            var Registration = new RegistrationApplicationWindows(SignedProfile);
            ApplicationProfiles.Add(SignedProfile.Identifier, Registration);
            return Registration;
            }

        /// <summary>
        /// Locate a device profile by identifier
        /// </summary>
        /// <param name="RegistrationDevice">The returned profile.</param>
        /// <param name="ID">UDF fingerprint of the profile or short form ID</param>
        /// <returns>True if the profile is found, otherwise false.</returns>
        public override bool Find(string ID, out RegistrationDevice RegistrationDevice) {
            RegistrationDevice = null;
            return false;
            }

        /// <summary>
        /// Locate a device profile by identifier
        /// </summary>
        /// <param name="RegistrationDevice">The returned profile.</param>
        /// <param name="ID">UDF fingerprint of the profile or short form ID</param>
        /// <returns>True if the profile is found, otherwise false.</returns>
        public override bool Find(string ID, out RegistrationApplication RegistrationApplication) {
            RegistrationApplication = null;
            return false;
            }

        /// <summary>
        /// Locate a device profile by identifier
        /// </summary>
        /// <param name="RegistrationDevice">The returned profile.</param>
        /// <param name="ID">UDF fingerprint of the profile or short form ID</param>
        /// <returns>True if the profile is found, otherwise false.</returns>
        public override bool Find(string ID, out RegistrationPersonal RegistrationPersonal) {
            RegistrationPersonal = null;
            return false;
            }

        }




    /// <summary>
    /// Describes the registration of as profile on as machine. This includes
    /// the fingerprint, the cached profile data and the list of portal entries
    /// to which the profile is bound.
    /// </summary>
    public partial class RegistrationPersonalWindows : RegistrationPersonal {


        /// <summary>
        /// The profile fingerprint
        /// </summary>
        public override string UDF { get { return Profile?.UDF;  } }


        /// <summary>
        /// Profiles associated with this account in chronological order.
        /// </summary>
        public override SortedList<DateTime, SignedProfile> Profiles { get; set; }


        /// <summary>
        /// List of the accounts through which the profile is registered.
        /// </summary>
        public override PortalCollection Portals { get; }

        /// <summary>
        /// Fetch the latest version of the profile version
        /// </summary>
        public override void Refresh() {
            }

        public string Archive { get; set; }

        /// <summary>
        /// Read a personal registration from a file
        /// </summary>
        /// <param name="UDF">File fingerprint</param>
        /// <param name="File">Filename on local machine</param>
        public RegistrationPersonalWindows(string UDF, string File, IEnumerable<string> Portals = null) {

            Profile = SignedPersonalProfile.FromFile (UDF, File);
            this.Portals = new PortalCollectionWindows(Portals);
            }

        /// <summary>
        /// Register a personal profile in the Windows registry
        /// </summary>
        /// <param name="Profile">The personal profile</param>
        /// <param name="Portals">The list of portals.</param>
        public RegistrationPersonalWindows(SignedPersonalProfile Profile, IEnumerable<string> Portals = null) {
            this.Profile = Profile;
            this.Portals = new PortalCollectionWindows(Portals);
            ToRegistry();
            }


        /// <summary>
        /// Factory method to create from an identifier.
        /// </summary>
        /// <param name="UDF">Profile identifier, if null, the default profile is used.</param>
        /// <param name="File">Filename, if null, a default filename is constructed from
        /// the identifier.</param>
        /// <returns>The registration object</returns>
        public static  RegistrationPersonal Factory(string UDF = null, string File = null) {

            return new RegistrationPersonalWindows(UDF, File);

            }

        /// <summary>
        /// Factory method to create from a profile
        /// </summary>
        /// <param name="Profile">The profile to register</param>
        /// <param name="Portals">The portals at which the profile is registered.</param>
        /// <returns>The registration object</returns>
        public static RegistrationPersonal Factory(
                            SignedPersonalProfile Profile, List<string> Portals = null) {

            return new RegistrationPersonalWindows(Profile, Portals);
            }



        /// <summary>Update portal entries.</summary>
        public override void Update() {

            var PersonalProfile = Profile.Signed;
            Profile = new SignedPersonalProfile (PersonalProfile);

            ToRegistry();
            }

        /// <summary>Write values to registry</summary>
        public override void ToRegistry() {

            var KeyName = Constants.RegistryPersonal;

            var Hive = Microsoft.Win32.Registry.CurrentUser;
            var FileName = Platform.FilePersonalProfile (UDF);

            Directory.CreateDirectory(Constants.FileProfilesPersonal);
            var SubKeyName = KeyName + @"\" + UDF;
            var SubKey = Hive.CreateSubKey(SubKeyName);

            SubKey.SetValue("", FileName);
            if (Portals != null) {
                SubKey.SetValue("Portals", Portals.ToArray(), 
                        Microsoft.Win32.RegistryValueKind.MultiString);
                }
            SubKey.SetValue("Archive", "TBS");
            File.WriteAllText(FileName, Profile.ToString());
            }


        public void MakeDefault() {
            var Hive = Microsoft.Win32.Registry.CurrentUser;
            var Key = Hive.CreateSubKey(Constants.RegistryPersonal);
            Key.SetValue("", UDF);
            }
        }


    /// <summary>
    /// Manage a collection of portals
    /// </summary>
    public class PortalCollectionWindows : PortalCollection {

        /// <summary>
        /// Default constructor
        /// </summary>
        public PortalCollectionWindows (IEnumerable<string> Portals) : base (Portals) {

            }
        }


    /// <summary>
    /// Describes the registration of a device profile on a machine.
    /// </summary>
    public class RegistrationApplicationWindows : RegistrationApplication {


        /// <summary>
        /// Fetch the latest version of the profile version
        /// </summary>
        public override void Refresh() {
            }

        /// <summary>
        /// Register request to register an application.
        /// </summary>
        /// <param name="SignedApplicationProfile">The application profile</param>
        public RegistrationApplicationWindows(SignedApplicationProfile SignedApplicationProfile) {
            Profile = SignedApplicationProfile;
            ToRegistry();
            }


        /// <summary>
        /// Read a personal registration from a file
        /// </summary>
        /// <param name="UDF">File fingerprint</param>
        /// <param name="File">Filename on local machine</param>
        public RegistrationApplicationWindows(string UDF=null, string File=null) {
            if (File == null) {
                var FileName = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\"
                            + Constants.RegistryApplication, UDF, null);
                File = FileName as string;
                }

            Profile = SignedApplicationProfile.FromFile(UDF, File);
            }


        /// <summary>
        /// Factory method to create from an identifier.
        /// </summary>
        /// <param name="UDF">Profile identifier, if null, the default profile is used.</param>
        /// <param name="File">Filename, if null, a default filename is constructed from
        /// the identifier.</param>
        /// <returns>The registration object</returns>
        public static RegistrationApplication Factory(string UDF = null, string File = null) {
            return new RegistrationApplicationWindows(UDF, File);

            }

        /// <summary>
        /// Factory method to create from a profile
        /// </summary>
        /// <param name="Profile">The profile to register</param>
        /// <param name="Portals">The portals at which the profile is registered.</param>
        /// <returns>The registration object</returns>
        public static RegistrationApplication Factory(
                            SignedApplicationProfile Profile) {
            return new RegistrationApplicationWindows(Profile);
            }



        /// <summary>Update persistence store</summary>
        public override void Update() {
            ToRegistry();
            }

        /// <summary>Write to registry.</summary>
        public override void ToRegistry() {
            var Hive = Microsoft.Win32.Registry.CurrentUser;
            var Key = Hive.CreateSubKey(Constants.RegistryApplication);
            var FileName = Platform.FileApplicationlProfile(UDF);

            Directory.CreateDirectory(Constants.FileProfilesApplication);

            Key.SetValue(UDF, FileName);

            File.WriteAllText(FileName, Profile.ToString());


            }
        }

    /// <summary>
    /// Describes the registration of a device profile on a machine.
    /// </summary>
    public class RegistrationDeviceWindows : RegistrationDevice {


        /// <summary>Return the fingerprint.</summary>
        public override string UDF {
            get { return Profile?.UDF; }
            }


        /// <summary>
        /// Fetch the latest version of the profile version
        /// </summary>
        public override void Refresh() {
            }


        /// <summary>
        /// Read a personal registration from a file
        /// </summary>
        /// <param name="UDF">File fingerprint</param>
        /// <param name="File">Filename on local machine</param>
        public RegistrationDeviceWindows(string UDF = null, string File = null) {
            Profile = SignedDeviceProfile.FromFile(UDF, File);
            }


        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        /// <param name="SignedDeviceProfile">The device profile</param>
        public RegistrationDeviceWindows(SignedDeviceProfile SignedDeviceProfile) {
            Profile = SignedDeviceProfile;
            ToRegistry();
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
        public override void ToRegistry() {
            var Hive = Microsoft.Win32.Registry.CurrentUser;
            var Key = Hive.CreateSubKey(Constants.RegistryDevice);
            var FileName = Platform.FileDeviceProfile(UDF);

            Directory.CreateDirectory(Constants.FileProfilesDevice);

            Key.SetValue(UDF, FileName);

            File.WriteAllText(FileName, Profile.ToString());
            }


        public void MakeDefault () {
            var Hive = Microsoft.Win32.Registry.CurrentUser;
            var Key = Hive.CreateSubKey(Constants.RegistryDevice);
            Key.SetValue("", UDF);
            }

        /// <summary>Update values.</summary>
        public override void Update() {
            ToRegistry();
            }

        }


    }
