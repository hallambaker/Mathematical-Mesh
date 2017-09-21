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
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh.Platform {


    /// <summary>
    /// Describes the registration of a device profile on a machine.
    /// </summary>
    public abstract class SessionApplication : PortalRegistration {

        /// <summary>The personal session</summary>
        public SessionPersonal SessionPersonal;

        /// <summary>
        /// The most recent cached profile data, if available.
        /// </summary>
        public ApplicationProfile ApplicationProfile { get; set; }


        /// <summary>
        /// The Device profile
        /// </summary>
        public SignedApplicationProfile SignedApplicationProfile {
            get => ApplicationProfile.SignedApplicationProfile;
            set => ApplicationProfile = value.ApplicationProfile;
            }

        /// <summary>
        /// Client which may be used to interact with the portal on which this
        /// profile is registered.
        /// </summary>
        public override MeshClient MeshClient {
            get => SessionPersonal.MeshClient;
            set => SessionPersonal.MeshClient = value;
            }

        /// <summary>
        /// The list of decrypt devices registered for this application.
        /// </summary>
        public List<RegistrationDevice> DecryptDeviceProfiles;

        /// <summary>
        /// The list of administration devices registered for this application.
        /// </summary>
        public List<RegistrationDevice> AdminDeviceProfiles;

        /*  Derrived properties */

        /// <summary>Find a device registration that can decrypt the specified data.</summary>
        /// <param name="DecryptionUDF">Data to decrypt</param>
        /// <returns>Device session</returns>
        public RegistrationDevice FindByDecryption (string DecryptionUDF) =>
            DecryptDeviceProfiles.Find(
                x => x.DeviceProfile.DeviceEncryptiontionKey.UDF.CompareUDF(DecryptionUDF));

        /// <summary>
        /// Find a device session that can decrypt JWE data.
        /// </summary>
        /// <param name="Recipients">The JWE Recipients list.</param>
        /// <returns>The first device registration that can decrypt the data (if found)</returns>
        public RegistrationDevice FindByDecryption (List<Recipient> Recipients) {
            foreach (var Recipient in Recipients) {
                var RegistrationDevice = FindByDecryption(Recipient?.Header?.Kid);
                if (RegistrationDevice != null) {
                    return RegistrationDevice;
                    }
                }
            return null;
            }



        /// <summary>
        /// List of the accounts through which the profile is registered.
        /// </summary>
        public override PortalCollection Portals => SessionPersonal.Portals; 



        /// <summary>The abstract machine a profile registration is attached to</summary>
        public override MeshMachine MeshMachine  => SessionPersonal?.MeshMachine; 


        PersonalProfile PersonalProfile  => SessionPersonal?.PersonalProfile;

        /// <summary>
        /// The registered signed profile.
        /// </summary>
        public override SignedProfile SignedProfile => SignedApplicationProfile; 

        /// <summary>
        /// The profile fingerprint
        /// </summary>
        public override string UDF => ApplicationProfile?.UDF;

        /// <summary>
        /// Add a new device to the access list for this application.
        /// </summary>
        /// <param name="DeviceProfile">The device to add.</param>
        /// <param name="Administration">If true, give the device administration rights.</param>
        public void AddDevice (
                    DeviceProfile DeviceProfile,
                    bool Administration = false) {
            ApplicationProfile.AddDevice(DeviceProfile, Administration);
            }


        /// <summary>Return the private portion of the application profile that is common to all devices.</summary>
        public ApplicationProfilePrivate ApplicationProfilePrivate { get; set; }

        /// <summary>Return the private portion of the application profile that is specific to this device.</summary>
        public ApplicationDevicePrivate ApplicationDevicePrivate { get; set; }


        //List<ApplicationDevicePrivate> _ApplicationDevicePrivates;
        //public List<ApplicationDevicePrivate> ApplicationDevicePrivates {
        //    get {
        //        _ApplicationDevicePrivates = _ApplicationDevicePrivates ?? GetDevicePrivate();
        //        return _ApplicationDevicePrivates;
        //        }
        //    }

        //ApplicationProfilePrivate _ApplicationProfilePrivate;
        //public ApplicationProfilePrivate ApplicationProfilePrivate {
        //    get {
        //        _ApplicationProfilePrivate = _ApplicationProfilePrivate ?? GetPrivate();
        //            return ApplicationProfilePrivate;
        //        }
        //    }


        //public List<ApplicationDevicePrivate> GetDevicePrivate () {
        //    throw new Utilities.NYI();
        //    }


        //public ApplicationProfilePrivate GetPrivate () {
        //    throw new Utilities.NYI();
        //    }


        }


    }
