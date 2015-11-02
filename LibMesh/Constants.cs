using System;
using Microsoft.Win32;

namespace Goedel.Mesh {
    public class Constants {
        public const string AdminKey = "$Admin";
        public const string RegistryRoot = @"Software\CryptoMesh";
        public const string RegistryDevice = RegistryRoot + @"\ThisDevice";
        public const string RegistryPersonal = RegistryRoot + @"\PersonalProfiles";
        public const string RegistryAccounts = RegistryRoot + @"\Accounts";

        readonly static string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public readonly static string FileRoot = AppData + @"\CryptoMesh";
        public readonly static string FileProfiles = FileRoot + @"\PersonalProfiles";

        readonly static string DeviceData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public readonly static string DeviceRoot = AppData + @"\CryptoMesh";
        public readonly static string DeviceProfiles = FileRoot + @"\DeviceProfiles";

        //public readonly static RegistryKey PersonalHive = Microsoft.Win32.Registry.CurrentUser;
        //public readonly static RegistryKey DeviceHive = Microsoft.Win32.Registry.CurrentUser;



        }
    }
