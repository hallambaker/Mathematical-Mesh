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
using System.Collections.Generic;


namespace Goedel.Mesh.Platform.Windows {

    /// <summary>
    /// Interface class to manage entries in the Windows Registry and file system. On
    /// non-windows machines, this can simply map to flat files.
    /// </summary>
    public partial class Register {

        /// <summary>
        /// Create registry entries for the specified parameters and return the 
        /// file name to write the data file to.
        /// </summary>
        /// <param name="KeyName">The Registry key to write to.</param>
        /// <param name="Tag">The name of the key to write to.</param>
        /// <param name="UDF">The fingerprint of the data object.</param>
        /// <returns>File name for the data file</returns>
        public static void WriteKey(string KeyName, string Tag, string UDF) {
            var Hive = Microsoft.Win32.Registry.CurrentUser;
            var Key = Hive.CreateSubKey(KeyName);
            Key.SetValue(Tag, UDF);
            return;
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
        /// <returns>The registry value</returns>
        public static string Read(string KeyName, out string UDF) {
            return Read(KeyName, null, out UDF);
            }

        /// <summary>
        /// Read registry entries for the specified parameters.
        /// </summary>
        /// <param name="KeyName">The Registry key to write to.</param>
        /// <param name="Entry">The name of the key to write to.</param>
        /// <param name="UDF">The fingerprint of the data object.</param>
        /// <returns>The registry value</returns>
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

        /// <summary>
        /// Get windows registry keys matching a key name.
        /// </summary>
        /// <param name="KeyName">The key to fetch.</param>
        /// <returns>Dictionary mapping keys to values.</returns>
        public static Dictionary<string, string> GetKeys(string KeyName) {
            var Result = new Dictionary<string, string>();

            var Hive = Microsoft.Win32.Registry.CurrentUser;
            if (Hive == null) return Result;

            var Key = Hive.OpenSubKey(KeyName);
            if (Key == null) return Result;

            foreach (var SubKey in Key.GetValueNames()) {
                var Value = Key.GetValue(SubKey);
                if ((Value as string)!= null) {
                    Result.Add(SubKey, Value as string);
                    }
                }

            return Result;
            }


        /// <summary>
        /// Get registry sub keys
        /// </summary>
        /// <param name="KeyName">The registry key to retrieve.</param>
        /// <returns>Set of registry keys</returns>
        public static List<RegistryKeySet> GetSubKeys(string KeyName) {
            var Result = new List<RegistryKeySet>();

            var Hive = Microsoft.Win32.Registry.CurrentUser;
            if (Hive == null) return Result;

            var Key = Hive.OpenSubKey(KeyName);
            if (Key == null) return Result;

            string Default = Key.GetValue("") as string;

            foreach (var SubKey in Key.GetSubKeyNames()) {
                var Value = Key.OpenSubKey(SubKey);
                var RegistryKeySet = new RegistryKeySet(SubKey, Value);
                RegistryKeySet.Default = SubKey == Default;
                Result.Add(RegistryKeySet);
                }

            return Result;
            }


        }

    /// <summary>
    /// A set of registry keys
    /// </summary>
    public class RegistryKeySet {
        Microsoft.Win32.RegistryKey RegistryKey;

        /// <summary>The key value</summary>
        public string Key { get; set; }

        /// <summary>If true, there is a default value.</summary>
        public bool Default = false;

        /// <summary>
        /// Get set of registry keys
        /// </summary>
        /// <param name="Key">Key to fetch</param>
        /// <param name="RegistryKey">Key value</param>
        public RegistryKeySet(string Key, Microsoft.Win32.RegistryKey RegistryKey) {
            this.RegistryKey = RegistryKey;
            this.Key = Key;
            }

        /// <summary>
        /// Get a multiple string value.
        /// </summary>
        /// <param name="Key">key to fetch</param>
        /// <returns>Array of strings</returns>
        public string[] GetValueMultiString (string Key) {
            var RVK = RegistryKey.GetValueKind(Key);

            if (RVK != Microsoft.Win32.RegistryValueKind.MultiString) {
                return null;
                }

            return (string[]) RegistryKey.GetValue(Key);
            }

        /// <summary>
        /// Get a single string value
        /// </summary>
        /// <param name="Key">The key</param>
        /// <returns>A string value.</returns>
        public string GetValueString(string Key) {
            var RVK = RegistryKey.GetValueKind(Key);

            if (RVK != Microsoft.Win32.RegistryValueKind.String) {
                return null;
                }

            return (string)RegistryKey.GetValue(Key);
            }

        /// <summary>
        /// Write a string valye
        /// </summary>
        /// <param name="Key">The Key</param>
        /// <param name="Value">The value.</param>
        public void Write(string Key, string Value) {
            RegistryKey.SetValue(Key, Value);
            }

        /// <summary>
        /// Write a multiple string valye
        /// </summary>
        /// <param name="Key">The Key</param>
        /// <param name="Value">The value.</param>
        public void Write(string Key, List<string> Value) {
            RegistryKey.SetValue(Key, Value);
            }

        }
    }
