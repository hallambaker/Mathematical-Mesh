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

namespace Goedel.Mesh.Platform.Linux {

    /// <summary>
    /// Constants specifying operating system locations and formats for the Mesh.
    /// </summary>
    public class Constants {


        /// <summary>
        /// If true, use test mode locations.
        /// </summary>
        public const bool TestMode = true;

        /// <summary>Mesh profiles directory</summary>
        public const string MeshProfiles = ".mesh";

        /// <summary>Extension for personal profile files</summary>
        public const string PersonalExtension = ".mmmp";

        /// <summary>Extension for personal profile files</summary>
        public const string PersonalExtensionSearch = "*"+ PersonalExtension;

        /// <summary>Extension for device profile files</summary>
        public const string DeviceExtension = ".mmmd";

        /// <summary>Extension for personal profile files</summary>
        public const string DeviceExtensionSearch = "*" + DeviceExtension;

        /// <summary>Extension for application profile files</summary>
        public const string ApplicationExtension = ".mmma";

        /// <summary>Extension for personal profile files</summary>
        public const string ApplicationExtensionSearch = "*" + ApplicationExtension;
        }
    }
