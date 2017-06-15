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
using Goedel.Mesh.Server;

namespace Goedel.Mesh.Platform {


    /// <summary>
    /// Describes the registration of a device profile on a machine.
    /// </summary>
    public abstract class RegistrationApplication : PortalRegistration {

        /// <summary>
        /// List of the accounts through which the profile is registered.
        /// </summary>
        public override PortalCollection Portals { get => RegistrationPersonal.Portals; }


        public RegistrationPersonal RegistrationPersonal;


        /// <summary>The abstract machine a profile registration is attached to</summary>
        public override RegistrationMachine RegistrationMachine {
                get => RegistrationPersonal?.RegistrationMachine; }


        PersonalProfile PersonalProfile {
                get => RegistrationPersonal?.PersonalProfile;
                }

        /// <summary>
        /// Client which may be used to interact with the portal on which this
        /// profile is registered.
        /// </summary>
        public override MeshClient MeshClient {
            get => RegistrationPersonal.MeshClient;
            set => RegistrationPersonal.MeshClient = value;
            }


        /// <summary>
        /// The registered signed profile.
        /// </summary>
        public override SignedProfile SignedProfile { get => SignedApplicationProfile; }


        /// <summary>
        /// The Device profile
        /// </summary>
        public SignedApplicationProfile SignedApplicationProfile {
            get => ApplicationProfile.SignedApplicationProfile;
            set => ApplicationProfile = value.ApplicationProfile;
                } 

        /// <summary>
        /// The most recent cached profile data, if available.
        /// </summary>
        public  ApplicationProfile ApplicationProfile { get; set; }

        /// <summary>
        /// The profile fingerprint
        /// </summary>
        public override string UDF { get => ApplicationProfile?.UDF; }

        public void AddDevice (
                    DeviceProfile DeviceProfile,
                    bool Administration = false) {
            ApplicationProfile.AddDevice(DeviceProfile, Administration);
            }

        }


    }
