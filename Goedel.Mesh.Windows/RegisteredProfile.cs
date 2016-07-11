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

namespace Goedel.Mesh.Platform {

    /// <summary>
    /// Describe the means by which a registration is made.
    /// </summary>
    public enum RegistrationType {
        /// <summary>
        /// Data is stored in a Windows registry key
        /// </summary>
        Registry,

        /// <summary>
        /// Data is stored in a file in the ~/.mmm directory.
        /// </summary>
        File,

        /// <summary>
        /// Data was previously registered but has been deleted.
        /// </summary>
        Removed
        }

    /// <summary>
    /// Describes a registration
    /// </summary>
    public abstract partial class Registration {

        /// <summary>
        /// The profile fingerprint
        /// </summary>
        public abstract string UDF { get;}

        /// <summary>
        /// The location of the registration.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The type of registration (i.e. Registry or file)
        /// </summary>
        public RegistrationType Type { get; set; }

        /// <summary>
        /// Fetch the latest version of the profile version
        /// </summary>
        public abstract void Refresh();

        /// <summary>
        /// Delete the associated profile from the registry
        /// </summary>
        public virtual void Delete() { }

        /// <summary>
        /// Update the associated profile in the registry
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// 
        /// </summary>
        public virtual void ToRegistry() { }


        protected string Filename(string Path, string Fingerprint) {
            return Path + "\\" + Fingerprint + ".mmm";
            }
        }


    /// <summary>
    /// Describes the registration of as profile on as machine. This includes
    /// the fingerprint, the cached profile data and the list of portal entries
    /// to which the profile is bound.
    /// </summary>
    public partial class RegistrationPersonal : Registration {



        /// <summary>
        /// The most recent cached profile data, if available.
        /// </summary>
        public SignedPersonalProfile Profile;

        /// <summary>
        /// The profile fingerprint
        /// </summary>
        public override string UDF { get { return Profile?.UDF;  } }


        /// <summary>
        /// Profiles associated with this account in chronological order.
        /// </summary>
        public SortedList<DateTime, SignedProfile> Profiles;


        /// <summary>
        /// Filename of the profile archive.
        /// </summary>
        public string Archive { get; set; }

        /// <summary>
        /// List of the accounts through which the profile is registered.
        /// </summary>
        public List<string> Portals { get; set; }

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
        public RegistrationPersonal(string UDF, string File) {

            Profile = SignedPersonalProfile.FromFile (UDF, File);
            }

        /// <summary>
        /// Register a personal profile in the Windows registry
        /// </summary>
        /// <param name="Profile"></param>
        public RegistrationPersonal(SignedPersonalProfile Profile, List<string> Portals) {
            this.Profile = Profile;
            this.Portals = Portals;
            ToRegistry();
            }



        public override void ToRegistry() {
            // This was going to be a call to a method off Registry but a compiler
            // error stopped that.

            //RegistryKeySet TheRegistryKeySet = null;
            //var FileName = Register.MakeKeyset(Constants.RegistryPersonal,
            //    Constants.FileProfiles, UDF, ref TheRegistryKeySet);
            var KeyName = Constants.RegistryPersonal;

            var Hive = Microsoft.Win32.Registry.CurrentUser;
            var Key = Hive.CreateSubKey(KeyName);
            var FileName = Filename (Constants.FileProfilesPersonal, UDF);

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

        }


    /// <summary>
    /// Describes the registration of a device profile on a machine.
    /// </summary>
    public class RegistrationApplication : Registration {
        SignedApplicationProfile _Profile;

        /// <summary>
        /// The Device profile
        /// </summary>
        public SignedApplicationProfile Profile {
            get {
                return _Profile;
                }

            set {
                _Profile = value;
                }
            }

        /// <summary>
        /// The profile fingerprint
        /// </summary>
        public override string UDF { get { return Profile?.UDF; } }


        /// <summary>
        /// Fetch the latest version of the profile version
        /// </summary>
        public override void Refresh() {
            }


        public RegistrationApplication(SignedApplicationProfile SignedApplicationProfile) {
            _Profile = SignedApplicationProfile;
            ToRegistry();
            }

        /// <summary>
        /// Read a personal registration from a file
        /// </summary>
        /// <param name="UDF">File fingerprint</param>
        /// <param name="File">Filename on local machine</param>
        public RegistrationApplication(string UDF, string File) {


            _Profile = SignedApplicationProfile.FromFile(UDF, File);
            ToRegistry();
            }
        }

    /// <summary>
    /// Describes the registration of a device profile on a machine.
    /// </summary>
    public class RegistrationDevice : Registration {
        SignedDeviceProfile _Device;

        /// <summary>
        /// The Device profile
        /// </summary>
        public SignedDeviceProfile Device {
            get {
                return _Device;
                }

            set {
                _Device = value;
                }
            }

        public override string UDF {
            get { return Device?.UDF; }
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
        public RegistrationDevice(string UDF, string File) {
            _Device = SignedDeviceProfile.FromFile(UDF, File);
            }


        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        public RegistrationDevice (SignedDeviceProfile SignedDeviceProfile) {
            _Device = SignedDeviceProfile;
            ToRegistry();
            }

        /// <summary>
        /// 
        /// </summary>
        public override void ToRegistry() {
            var Hive = Microsoft.Win32.Registry.CurrentUser;
            var Key = Hive.CreateSubKey(Constants.RegistryDevice);
            var FileName = Filename(Constants.FileProfilesDevice, UDF);

            Directory.CreateDirectory(Constants.FileProfilesDevice);

            Key.SetValue(UDF, FileName);

            File.WriteAllText(FileName, Device.ToString());
            }

        }

    /// <summary>
    /// Describes a set of registered profiles on a particular machine, usually the
    /// current machine.
    /// </summary>
    public class RegistrationMachine : Registration {

        static RegistrationMachine _Current;

        /// <summary>
        /// The a dictionary of personal profiles indexed by fingerprint.
        /// </summary>
        public Dictionary<string, RegistrationPersonal> PersonalProfiles { get; set; }

        /// <summary>
        /// A dictionary of application profiles indexed by fingerprint.
        /// </summary>
        public Dictionary<string, RegistrationApplication> ApplicationProfiles { get; set; }


        /// <summary>
        /// A dictionary of default application profiles indexed by application identifier;
        /// </summary>
        public Dictionary<string, string> ApplicationProfilesDefault { get; set; }

        /// <summary>
        /// A dictionary of device profiles indexed by fingerprint.
        /// </summary>
        public Dictionary<string, RegistrationDevice> DeviceProfiles { get; set; }


        public override string UDF {
            get { return _Device?.UDF; }
            }

        RegistrationPersonal _Personal;
        RegistrationDevice _Device;


        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        public void Add(Registration Registration) {
            if (Registration as RegistrationApplication != null) {
                Add(Registration as RegistrationApplication);
                }

            }

        /// <summary>
        /// Add the associated registration to the machine store.
        /// </summary>
        public void Add(RegistrationDevice Registration) {
            if (!DeviceProfiles.ContainsKey(Registration.UDF)) {
                DeviceProfiles.Add(Registration.UDF, Registration);
                }
            // If no existing default, register as the default
            if (Device == null) {
                Device = Registration;
                }

            }

        /// <summary>
        /// Add the associated registration to the machine store.
        /// </summary>
        public void Add(RegistrationPersonal Registration) {
            PersonalProfiles.Add(Registration.UDF, Registration);

            // If no existing default, register as the default
            if (Personal == null) {
                Personal = Registration;
                }

            }


        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        public RegistrationDevice Add(SignedDeviceProfile SignedDeviceProfile) {
            var Registration = new RegistrationDevice(SignedDeviceProfile);

            Add(Registration);
            return Registration;
            }

        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        public RegistrationApplication Add(SignedApplicationProfile SignedApplicationProfile) {
            var Registration = new RegistrationApplication(SignedApplicationProfile);

            Add(Registration);
            return Registration;
            }

        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        public RegistrationPersonal Add(SignedPersonalProfile SignedPersonalProfile, string PortalAddress) {
            var Registration = new RegistrationPersonal(SignedPersonalProfile, new List<string> { PortalAddress });
            Add(Registration);
            return Registration;
            }


        /// <summary>
        /// The registration on the current machine. This will be read from either
        /// the Windows registry (Windows) or the ~/.mmm directory (OSX, Linux).
        /// </summary>
        public static RegistrationMachine Current {
            get {
                if (_Current == null) {
                    _Current = new RegistrationMachine();
                    }
                return _Current;
                }
            set {
                Register.WriteKey(Constants.RegistryDevice, "", value.UDF);
                }
            }

        /// <summary>
        /// The default personal profile. Note that when setting the default
        /// personal profile, only the fingerprint is stored.
        /// </summary>
        public RegistrationPersonal Personal {
            get {
                return _Personal;
                }
            set {
                Register.WriteKey(Constants.RegistryPersonal, "", value.UDF);
                }
            }


        /// <summary>
        /// The list of all the available personal profiles
        /// </summary>
        public List<RegistrationPersonal> Personals {
            get {
                return PersonalProfiles.Values.ToList ();
                }
            }


        /// <summary>
        /// The list of all device profiles
        /// </summary>
        public List<RegistrationDevice> Devices {
            get {
                return DeviceProfiles.Values.ToList();
                }
            }

        /// <summary>
        /// The default device profile
        /// </summary>
        public RegistrationDevice Device {
            get {
                return _Device;
                }
            set {
                _Device = value;
                Register.WriteKey(Constants.RegistryDevice, "", _Device.UDF);
                }
            }


        /// <summary>
        /// Default constructor, get values from the current machine.
        /// </summary>
        public RegistrationMachine() {
            Fill();
            }


        /// <summary>
        /// Fetch the latest version of the profile version
        /// </summary>
        void Fill() {

            PersonalProfiles = new Dictionary<string, RegistrationPersonal>();
            ApplicationProfiles = new Dictionary<string, RegistrationApplication>();
            ApplicationProfilesDefault = new Dictionary<string, string>();
            DeviceProfiles = new Dictionary<string, RegistrationDevice>();

            var ProfileKeys = Register.GetSubKeys(Constants.RegistryPersonal);
            var DeviceKeys = Register.GetKeys(Constants.RegistryDevice);
            var ApplicationKeys = Register.GetKeys(Constants.RegistryApplication);
            string DefaultDevice = null;


            foreach (var KeySet in ProfileKeys) {
                var Filename = KeySet.GetValueString("");

                if (Filename != "") {
                    var Profile = new RegistrationPersonal(KeySet.Key, Filename);
                    if (Profile != null) {
                        PersonalProfiles.Add(KeySet.Key, Profile);

                        // add Archive
                        var Archive = KeySet.GetValueString("Archive");
                        Profile.Archive = Archive;

                        // add Portals
                        var Portals = KeySet.GetValueMultiString("Portals");
                        Profile.Portals = Portals?.ToList();

                        if (KeySet.Default) {
                            _Personal = Profile;
                            }
                        }
                    }
                }

            foreach (var Key in ApplicationKeys) {
                if (Key.Key.Length > 10) {
                    var Profile = new RegistrationDevice(Key.Key, Key.Value);
                    if (Profile != null) {
                        DeviceProfiles.Add(Key.Key, Profile);
                        }
                    }
                else {
                    ApplicationProfilesDefault.Add(Key.Key, Key.Value);
                    }
                }


            foreach (var Key in DeviceKeys) {
                if (Key.Key != "") {
                    var Profile = new RegistrationDevice(Key.Key, Key.Value);
                    if (Profile != null) {
                        DeviceProfiles.Add(Key.Key, Profile);
                        }
                    }
                else {
                    DefaultDevice = Key.Value;
                    }
                }

            if (DefaultDevice != null) {
                DeviceProfiles.TryGetValue(DefaultDevice, out _Device);
                }

            return;
            }


        /// <summary>
        /// Fetch the latest version of the profile version
        /// </summary>
        public override void Refresh() {
            }


        public bool GetID(string ID, out RegistrationDevice Registration) {
            Registration = null;
            return false;
            }


        public bool GetUDF (string UDF, out RegistrationDevice Registration) {
            Registration = null;
            return false;
            }

        public static void Erase() {
#pragma warning disable 162
            if (!Constants.TestMode) {
                return; //
                }

            DirectoryDelete(Constants.RoamingRoot);        // Personal and application profiles
            DirectoryDelete(Constants.NonRoamingRoot);     // Device specific profiles

            var Hive = Microsoft.Win32.Registry.CurrentUser;

            Hive.DeleteSubKeyTree(Constants.RegistryRoot, false);

#pragma warning restore 162
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
        }

    }
