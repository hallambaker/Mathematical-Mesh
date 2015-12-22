//Sample license text.
using System.IO;
using Microsoft.Win32;
using System.Collections.Generic;
using Goedel.Protocol;
using Goedel.LibCrypto;
using Goedel.Debug;
using Goedel.Cryptography.Jose;
using Goedel.LibCrypto.PKIX;

namespace Goedel.Mesh {

    /// <summary>
    /// Interface class to manage entries in the Windows Registry anf file system. On
    /// non-windows machines, this can simply map to flat files.
    /// </summary>
    public partial class Register {

        /// <summary>
        /// Create registry entries for the specified parameters and return the 
        /// file name to write the data file to.
        /// </summary>
        /// <param name="KeyName">The Registry key to write to.</param>
        /// <param name="Path">The Registry Path to write to</param>
        /// <param name="UDF">The fingerprint of the data object.</param>
        /// <returns>File name for the data file</returns>
        public static string WriteFile(string KeyName, string Path, string UDF) {
            return WriteFile(KeyName, Path, "", UDF);
            }

        /// <summary>
        /// Create registry entries for the specified parameters and return the 
        /// file name to write the data file to.
        /// </summary>
        /// <param name="KeyName">The Registry key to write to.</param>
        /// <param name="Path">The Registry Path to write to</param>
        /// <param name="Name">The name of the key to write to.</param>
        /// <param name="UDF">The fingerprint of the data object.</param>
        /// <returns>File name for the data file</returns>
        public static string WriteFile(string KeyName, string Path, string Name, string UDF) {
            var Hive = Microsoft.Win32.Registry.CurrentUser;
            var Key = Hive.CreateSubKey(KeyName);
            var FileName = Constants.FileProfiles + @"\" + UDF;

            Directory.CreateDirectory(Path);

            Key.SetValue(Name, UDF);
            Key.SetValue(UDF, FileName);

            return FileName;
            }

        /// <summary>
        /// Get the file name to read a file from the specified keyname and path.
        /// </summary>
        /// <param name="KeyName">The Registry key to write to.</param>
        /// <param name="Path">The Registry Path to write to</param>
        /// <returns>File name of the stored file.</returns>
        public static string ReadFile(string KeyName, string Path) {
            return ReadFile(KeyName, Path, null);
            }


        /// <summary>
        /// Get the file name to read a file from the specified keyname and path.
        /// </summary>
        /// <param name="KeyName">The Registry key to write to.</param>
        /// <param name="Path">The Registry Path to write to</param>
        /// <param name="UDF">Fingerprint of the object to read.</param>
        /// <returns>File name of the stored file.</returns>
        public static string ReadFile(string KeyName, string Path, string UDF) {
            var Hive = Microsoft.Win32.Registry.CurrentUser;
            var Key = Hive.OpenSubKey(KeyName);

            if (Key == null) {
                return null;
                }

            UDF = UDF != null? UDF : Key.GetValue("") as string;
            var FileName = Key.GetValue(UDF) as string;
            return FileName;
            }


        /// <summary>
        /// Create registry entries for the specified parameters.
        /// </summary>
        /// <param name="KeyName">The Registry key to write to.</param>
        /// <param name="Entry">The name of the key to write to.</param>
        /// <param name="UDF">The fingerprint of the data object.</param>
        public static void Write (string KeyName, string Entry, string UDF) {
            var Hive = Microsoft.Win32.Registry.CurrentUser;
            var Key = Hive.CreateSubKey(KeyName);
            Key.SetValue("", Entry);
            Key.SetValue(Entry, UDF);
            }

        /// <summary>
        /// Read registry entries for the specified parameters.
        /// </summary>
        /// <param name="KeyName">The Registry key to write to.</param>
        /// <param name="UDF">The fingerprint of the data object.</param>
        public static string Read(string KeyName, out string UDF) {
            return Read(KeyName, null, out UDF);
            }

        /// <summary>
        /// Read registry entries for the specified parameters.
        /// </summary>
        /// <param name="KeyName">The Registry key to write to.</param>
        /// <param name="Entry">The name of the key to write to.</param>
        /// <param name="UDF">The fingerprint of the data object.</param>
        public static string Read(string KeyName, string Entry, out string UDF) {
            var Hive = Microsoft.Win32.Registry.CurrentUser;
            var Key = Hive.OpenSubKey(KeyName);

            if (Key == null) {
                UDF = null;
                return null;
                }

            Entry = Entry != null ? Entry : Key.GetValue("") as string;
            UDF = Key.GetValue(Entry) as string;

            return Entry;
            }




        }



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
        public static SignedPersonalProfile GetLocal (string UDF) {
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
                var Profile =  new SignedDeviceProfile(Name, Description);
                Profile.ToRegistry(Label);
                return Profile;
                }

            var Reader = JSONReader.OfFile(FileName);
            var Result = FromTagged(Reader);

            return Result;
            }



        void Dump(RegistryKey Key) {
            var Names = Key.GetValueNames();
            foreach (var Name in Names) {

                Goedel.Debug.Trace.WriteLine("Name {0}={1}", Name, Key.GetValue(Name));
                }

            }

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
