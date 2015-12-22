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
using Microsoft.Win32;

namespace Goedel.Mesh {

    /// <summary>
    /// Constants specifying operating system locations and formats for the Mesh.
    /// </summary>
    public class Constants {

        /// <summary>
        /// The administraiton key.
        /// </summary>
        public const string AdminKey = "$Admin";

        /// <summary>
        /// The root entry for the CryptoMesh entries.
        /// </summary>
        public const string RegistryRoot = @"Software\CryptoMesh";

        /// <summary>
        /// Root entry for device specific settings.
        /// </summary>
        public const string RegistryDevice = RegistryRoot + @"\ThisDevice";

        /// <summary>
        /// Root entry for personal profiles shared across multiple machines.
        /// </summary>
        public const string RegistryPersonal = RegistryRoot + @"\PersonalProfiles";

        /// <summary>
        /// Root entry for registry account entries.
        /// </summary>
        public const string RegistryAccounts = RegistryRoot + @"\Accounts";

        /// <summary>
        /// The application data path (may be shared across machines).
        /// </summary>
        readonly static string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        /// <summary>
        /// Root directory for CryptoMesh files.
        /// </summary>
        public readonly static string FileRoot = AppData + @"\CryptoMesh";

        /// <summary>
        /// Root directory for personal profiles.
        /// </summary>
        public readonly static string FileProfiles = FileRoot + @"\PersonalProfiles";

        /// <summary>
        /// The device specific data path.
        /// </summary>
        readonly static string DeviceData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        /// <summary>
        /// The root directory for device files.
        /// </summary>
        public readonly static string DeviceRoot = AppData + @"\CryptoMesh";

        /// <summary>
        /// The root directory for device profiles.
        /// </summary>
        public readonly static string DeviceProfiles = FileRoot + @"\DeviceProfiles";


        }
    }
