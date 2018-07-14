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
using Goedel.Mesh.Portal;

namespace Goedel.Mesh.Portal.Client {

    /// <summary>
    /// Describes the registration of a device profile on a machine.
    /// </summary>
    public class SessionDevice : Registration {

        /// <summary>
        /// The registered signed profile.
        /// </summary>
        public override SignedProfile SignedProfile  => SignedDeviceProfile; 

        /// <summary>
        /// The Device profile
        /// </summary>
        public SignedDeviceProfile SignedDeviceProfile { get; set; }
        
        /// <summary>
        /// The most recent cached profile data, if available.
        /// </summary>
        public virtual DeviceProfile DeviceProfile  => SignedDeviceProfile.DeviceProfile;


        public MeshMachine MeshMachine { get; set; }

        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        /// <param name="SignedDeviceProfile">The device profile</param>
        /// <param name="RegistrationMachine">The machine session.</param>
        public SessionDevice (SignedDeviceProfile SignedDeviceProfile,
                    MeshMachine RegistrationMachine) {
            this.SignedDeviceProfile = SignedDeviceProfile;
            MeshMachine = RegistrationMachine;
            }



        /// <summary>
        /// Begin the process of connecting to a profile at the specified portal
        /// </summary>
        /// <param name="PortalID">The portal to connect to</param>
        /// <param name="PIN">Optional one time authenticator.</param>
        /// <returns>Personal Session.</returns>
        public SessionPersonal BeginConnect(string PortalID, string PIN = null) {

            // Create a portal for the PortalID
            var MeshClient = new MeshClient(PortalAccount: PortalID) {
                SignedDeviceProfile = SignedDeviceProfile
                };

            // Fetch the personal profile 
            var SignedPersonalProfile = MeshClient.GetPersonalProfile();
            MeshClient.SignedPersonalProfile = SignedPersonalProfile;

            var PendingResponse = MeshClient.ConnectRequest(SignedDeviceProfile, out var DeviceRequest);

            // Copy the MeshClient to the unconnected profile
            var RegisteredPersonal = MeshMachine.Add(SignedPersonalProfile);
            RegisteredPersonal.MeshClient = MeshClient;

            return RegisteredPersonal;
            }

        /// <summary>
        /// The profile fingerprint
        /// </summary>
        public override string UDF => SignedDeviceProfile?.UDF;

        /// <summary>
        /// Write to the local persistent cache.
        /// </summary>
        /// <param name="Default">If true, make this profile the default.</param>
        public override void Write(bool Default = true) => WriteToLocal(Default);

        /// <summary>
        /// No idea.
        /// </summary>
        public override void Read() {
            }

        /// <summary>
        /// If true, this is the default profile.
        /// </summary>
        public virtual bool IsDefault { get; set; } = true; // Hack: Should work out if it is default

        /// <summary>
        /// Return a serialization of the session data for this profile.
        /// </summary>
        /// <returns>The serialization object.</returns>
        public virtual SerializationDevice Serialize () {
            var Result = new SerializationDevice() {
                Profile = SignedDeviceProfile,
                };

            if (IsDefault) {
                Result.Default = DateTime.Now;
                }
            return Result;

            }

        public override void MakeDefault() => MeshMachine.MakeDefault(this);

        public override void WriteToLocal(bool Default = true) => MeshMachine.WriteToLocal(this, Default);
        }

    }
