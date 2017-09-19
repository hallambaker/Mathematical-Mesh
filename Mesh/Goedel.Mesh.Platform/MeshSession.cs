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
using Goedel.Utilities;
using Goedel.Protocol;
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Mesh.Server;

namespace Goedel.Mesh.Platform {

    /// <summary>
    /// Provides the interface layer between the application and all Mesh 
    /// functions.
    /// </summary>
    public class MeshSession {

        /// <summary>The cached machine registration data</summary>
        public MeshMachine Machine { get; private set; }

        /// <summary>
        /// Return an interface populated with all the profiles and portal
        /// accounts on the current machine
        /// </summary>
        /// <param name="Machine">Machine registration to use. If null, the default
        /// registration is used.</param>
        public MeshSession (MeshMachine Machine = null) {
            this.Machine = Machine ?? MeshMachine.Current;
            }



        public MeshClient Bind (string Portal) {
            Assert.NotNull(Portal, NoPortalAccount.Throw);
            Goedel.Mesh.Account.SplitAccountID(Portal, out var Account, out var Service);
            Assert.NotNull(Account, InvalidPortalAddress.Throw);
            var MeshClient = new MeshClient(PortalAccount: Portal);
            Assert.NotNull(MeshClient, PortalConnectFail.Throw);

            return MeshClient;
            }


        /// <summary>
        /// Erase all configuration data from the current machine.
        /// </summary>
        public void EraseTest () {
            Machine.Erase();
            }

        ///// <summary>
        ///// Erase all configuration data from the current machine.
        ///// </summary>
        //public void Reload () {
        //    Machine = Machine.Reload ();
        //    }


        /// <summary>
        /// Create a new device profile and register it to the current machine.
        /// </summary>
        /// <param name="ID">The device short identifier, if null, the UDF is used.</param>
        /// <param name="Description">Device description, if null, defaults to 'unknown'</param>
        /// <param name="Default">If true, the new profile will be made
        /// the default. If null, the new profile will become the default
        /// if there is no default specified already. Otherwise, the default
        /// is unchanged.</param>
        /// <returns></returns>
        public RegistrationDevice CreateDevice (
                            string ID = null,
                            string Description = "Unknown",
                            bool? Default = null) {

            var ProfileDevice = new SignedDeviceProfile(ID, Description);
            var RegistrationDevice = Machine.Add(ProfileDevice);

            if (Default == true | (Default == null & Machine.Device == null)) {
                Machine.Device = RegistrationDevice;
                }

            return RegistrationDevice;
            }


        /// <summary>
        /// Get a device profile.
        /// </summary>
        /// <param name="UDF">Fingerprint of profile.</param>
        /// <returns>The profile (if found).</returns>
        public RegistrationDevice GetDevice (string UDF) {
            var Found = Machine.Find(UDF, out RegistrationDevice RegistrationDevice);
            Assert.True(Found, ProfileNotFound.Throw);
            return RegistrationDevice;
            }


        /// <summary>
        /// Get or create a device profile registered to the current machine.
        /// </summary>
        /// <param name="DeviceNew">If true, create a new profile. Otherwise create a 
        /// new profile if and only if DeviceUDF is null and no default profile is registered.</param>
        /// <param name="DeviceUDF">Specify the device profile by UDF fingerprint.</param>
        /// <param name="DeviceID">The identifier for device profile if created.</param>
        /// <param name="DeviceDescription">The device description for the device profile if created.</param>
        /// <returns></returns>
        public RegistrationDevice GetDevice (bool DeviceNew = false,
                    string DeviceUDF = null,
                    string DeviceID = null,
                    string DeviceDescription = null
                    ) {

            RegistrationDevice RegistrationDevice = null;
            bool Generate = false;
            if (DeviceNew) {
                Generate = true;
                }
            else if (DeviceUDF != null) {
                // use the profile with the specified fingerprint
                var Found = Machine.Find(DeviceUDF, out RegistrationDevice);
                Assert.NotNull(Found, ProfileNotFound.Throw);
                }
            else if (DeviceID != null) {
                // use the profile with the specified ID
                var Found = Machine.Find(DeviceID, out RegistrationDevice);
                Assert.True(Found, ProfileNotFound.Throw);
                }
            else if (Machine.Device != null) {
                RegistrationDevice = Machine.Device;
                }
            else {
                Generate = true;
                }

            // Generate a new device profile
            if (Generate) {
                var NewProfileDevice = new SignedDeviceProfile(DeviceID, DeviceDescription);
                RegistrationDevice = Machine.Add(NewProfileDevice);
                }

            // Always make the device profile the default if one is not specified.
            if (Machine.Device == null) {
                Machine.Device = RegistrationDevice;
                }

            return RegistrationDevice;
            }

        /// <summary>
        /// Begin creation of a portal account
        /// </summary>
        /// <param name="PortalAddress"></param>
        /// <returns>Registration created account (if successful)</returns>
        public SessionPersonal CreateAccount (
                    string PortalAddress,
                    PersonalProfile Profile,
                    MeshClient MeshClient = null) {

            MeshClient = MeshClient ?? new MeshClient(PortalAccount: PortalAddress);
            var RegistrationPersonal = AddPersonal(Profile);

            RegistrationPersonal.AddPortal(PortalAddress, MeshClient, true);

            MeshClient.CreatePortalAccount(PortalAddress, Profile.SignedPersonalProfile);


            return RegistrationPersonal;
            }

        public ValidateResponse Validate (
                    string PortalAddress,
                    MeshClient MeshClient = null) {

            MeshClient = MeshClient ?? new MeshClient(PortalAccount: PortalAddress);
            return MeshClient.Validate(PortalAddress);
            }


        public SessionPersonal AddPersonal (
                    bool DeviceNew = false,
                    string DeviceUDF = null,
                    string DeviceID = null,
                    string DeviceDescription = null
                    ) {
            RegistrationDevice RegistrationDevice = GetDevice(DeviceNew, DeviceUDF, DeviceID, DeviceDescription);
            return AddPersonal(RegistrationDevice);
            }

        public SessionPersonal AddPersonal (
                    RegistrationDevice RegistrationDevice) {

            var ProfileDevice = RegistrationDevice.SignedDeviceProfile;

            var PersonalProfile = new PersonalProfile(ProfileDevice.DeviceProfile);
            return AddPersonal(PersonalProfile);
            }


        /// <summary>
        /// Register the specified personal profile
        /// </summary>
        /// <param name="PortalAddress">The portal at which to register the profile</param>
        /// <param name="PersonalProfile">The profile to register.</param>
        /// <returns>The profile registration.</returns>
        public SessionPersonal AddPersonal (
            PersonalProfile PersonalProfile) {

            var SignedPersonalProfile = PersonalProfile.SignedPersonalProfile;
            var Registration = Machine.Add(SignedPersonalProfile);
            Registration.MeshCatalog = this;

            return Registration;
            }




        public SessionPersonal Recover (
                    Secret Secret) {

            var Identifier = UDF.ToString(UDF.FromEscrowed(Secret.Key, 150));

            var MeshClient = Bind(Identifier);
            var EscrowEntry = MeshClient.Recover(Identifier);
            var EscrowedKeySet = EscrowEntry.Decrypt(Secret);


            var DeviceProfile = GetDevice();
            var MasterProfile = new MasterProfile(EscrowedKeySet);
            var PersonalProfile = new PersonalProfile(DeviceProfile.DeviceProfile, MasterProfile);

            return AddPersonal(PersonalProfile);

            }


        /// <summary>
        /// Attempt to synchronize the catalog to get the authoritative sources.
        /// </summary>
        /// <returns>True if synchronization attempt succeeded.</returns>
        public bool Sync () {
            return false;
            }

        /// <summary>
        /// Commit local changes to upstream.
        /// </summary>
        /// <returns>True if synchronization attempt succeeded.</returns>
        public bool Commit () {
            return false;
            }

        /// <summary>
        /// Add a personal profile to the current machine
        /// </summary>
        /// <param name="Profile">Profile to add.</param>
        public void Add (PersonalProfile Profile) {
            }

        /// <summary>
        /// Get a personal profile.
        /// </summary>
        /// <param name="UDF">Profile fingerprint.</param>
        /// <param name="PortalID">Portal account.</param>
        /// <returns>The personal profile.</returns>
        public SessionPersonal GetPersonal (
                        string PortalID = null,
                        string UDF = null,
                        bool Cached = true,
                        bool Portal = true) {
            SessionPersonal Result = null;

            if (Cached) {
                if (UDF != null) {
                    if (Machine.PersonalProfilesUDF.TryGetValue(UDF, out Result)) {
                        return Result;
                        }
                    }
                if (PortalID != null) {
                    if (Machine.PersonalProfilesPortal.TryGetValue(PortalID, out Result)) {
                        return Result;
                        }
                    }
                return Machine.Personal;
                }

            return Result;
            }



        public ConnectStartRequest Connect (RegistrationDevice Device, string Address, out string Authenticator) {
            var MeshClient = new MeshClient(PortalAccount: Address);

            var ConnectStartResponse = MeshClient.ConnectRequest(
                    Device.SignedDeviceProfile,
                    out var DeviceRequest);

            Machine.ConnectStartRequests.Add(DeviceRequest);

            Authenticator = UDF.FromUDFPair(
                Device.UDF,
                MeshClient.PersonalProfile.UDF
                );

            return DeviceRequest;
            }


        public ConnectionStatus Await (ConnectStartRequest Connect, int TimeOut = -1) {
            throw new NYI();
            }



        }

    /// <summary>
    /// Mesh application profile types.
    /// </summary>
    public enum MeshApplicationType {
        /// <summary>Password profile</summary>
        Password,
        /// <summary>SSH profile</summary>
        SSH,
        /// <summary>Mail Profile</summary>
        Mail,
        /// <summary>Network profile type</summary>
        Network,
        /// <summary>Mesh/Remesh profile</summary>
        Remesh
        }



    }
