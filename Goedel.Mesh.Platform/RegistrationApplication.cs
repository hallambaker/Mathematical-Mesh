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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Goedel.Utilities;
using Goedel.Mesh;

namespace Goedel.Mesh.Platform {


    /// <summary>
    /// Describes the registration of a device profile on a machine.
    /// </summary>
    public abstract class RegistrationApplication : Registration {

        /// <summary>
        /// The Device profile
        /// </summary>
        public SignedApplicationProfile SignedApplicationProfile { get; set; }

        /// <summary>
        /// The most recent cached profile data, if available.
        /// </summary>
        public virtual ApplicationProfile ApplicationProfile {
            get { return SignedApplicationProfile.ApplicationProfile; }
            }


        /// <summary>
        /// The profile fingerprint
        /// </summary>
        public override string UDF { get { return SignedApplicationProfile?.UDF; } }

        }


    }
