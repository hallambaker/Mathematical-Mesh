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
using Goedel.Protocol;
using Goedel.Mesh.Portal;

namespace Goedel.Mesh.Portal.Client {


    /// <summary>
    /// Describes the registration of as profile on as machine. This includes
    /// the fingerprint, the cached profile data and the list of portal entries
    /// to which the profile is bound.
    /// </summary>
    public abstract partial class SessionPersonal : PortalRegistration {

        /// <summary>
        /// The registered signed profile.
        /// </summary>
        public override SignedProfile SignedProfile  => SignedPersonalProfile; 


        /// <summary>
        /// The most recent cached profile data, if available.
        /// </summary>
        public virtual PersonalProfile PersonalProfile { get; set; }

        /// <summary>The Mech catalog for this session.</summary>
        public MeshSession MeshCatalog { get; set; }


        /// <summary>
        /// Client which may be used to interact with the portal on which this
        /// profile is registered.
        /// </summary>
        public override MeshClient MeshClient {
            get {
                if (_MeshClient == null) {
                    _MeshClient =  MeshCatalog.Bind(Portals.Default);
                    _MeshClient.SignedPersonalProfile = SignedPersonalProfile;
                    }
                
                return _MeshClient;
                }
            set {
                _MeshClient = value;
                }
            }
        MeshClient _MeshClient = null;

        /// <summary>
        /// The most recent cached profile data, if available.
        /// </summary>
        public virtual SignedPersonalProfile SignedPersonalProfile {
            get => PersonalProfile.SignedPersonalProfile;
            set => PersonalProfile = value.PersonalProfile;
            }

        /// <summary>
        /// The profile fingerprint
        /// </summary>
        public override string UDF  => SignedPersonalProfile?.UDF; 

        /// <summary>
        /// Profiles associated with this account in chronological order.
        /// </summary>
        public abstract SortedList<DateTime, SignedProfile> Profiles { get; set; }

        /// <summary>
        /// Escrow the personal profile to the bound portal.
        /// </summary>
        /// <param name="Shares">Number of escrow shares (must be greater than Quorum)</param>
        /// <param name="Quorum">Quorum required for recovery.</param>
        /// <returns>True if escrow record was accepted.</returns>
        public virtual bool Escrow (int Shares, int Quorum) {
            var OfflineEscrowEntry = new OfflineEscrowEntry(
               PersonalProfile, Shares, Quorum);
            return Escrow(OfflineEscrowEntry);
            }

        /// <summary>
        /// Push an OfflineEscrowEntry to the bound portal. This may be a personal profile or 
        /// other data to be escrowed.
        /// </summary>
        /// <param name="OfflineEscrowEntry">The offline escrow entry to register.</param>
        /// <returns>True if escrow record was accepted.</returns>
        public virtual bool Escrow (OfflineEscrowEntry OfflineEscrowEntry) {
            var Result = MeshClient.Publish(OfflineEscrowEntry);
            return Result.Status.StatusSuccess();
            }


        /// <summary>
        /// Add a portal to this registration
        /// </summary>
        /// <param name="AccountID">The portal account.</param>
        /// <param name="MeshClient">A Mesh Client connected to the portal.</param>
        /// <param name="Create">If true, the mesh client should request the account be created.</param>
        public abstract void AddPortal (string AccountID, MeshClient MeshClient = null, bool Create = false);


        public virtual void Add (SessionApplication SessionApplication) {

            MeshMachine.Add(SessionApplication);
            }


        ///// <summary>
        ///// Add an application to this profile
        ///// </summary>
        ///// <param name="Profile">Application session to add</param>
        ///// <param name="Write">If true, write to persistent store.</param>
        ///// <returns>The new application session.</returns>
        //public virtual SessionApplication Add (
        //            ApplicationProfile Profile, bool Write = true) {

        //    var RegistrationApplication = MeshMachine.Add(Profile);
        //    RegistrationApplication.SessionPersonal = this;

        //    if (Write) {
        //        this.Write();
        //        RegistrationApplication.Write();
        //        }

        //    return RegistrationApplication;
        //    }


        /// <summary>
        /// Complete process of connecting to a profile.
        /// </summary>
        /// <returns>The result of the pending connections query.</returns>
        public ConnectPendingResponse ConnectPending () {
            throw new Goedel.Utilities.NYI();
            }

        /// <summary>
        /// Complete process of connecting to a profile.
        /// </summary>
        /// <param name="Request">The connection request</param>
        /// <param name="Status">The connection status result.</param>
        /// <returns>The response from the service.</returns>
        public ConnectStatusResponse ConnectClose (SignedConnectionRequest Request, ConnectionStatus Status) {
            //PersonalProfile.Add(Request.Device.DeviceProfile);

            //Write();
            throw new Goedel.Utilities.NYI();
            }

        /// <summary>
        /// Provide a PIN for authenticating the specified account ID
        /// </summary>
        /// <param name="AccountID">The account identifier</param>
        /// <param name="length">The PIN length</param>
        /// <returns>The PIN value.</returns>
        public string GetPin (string AccountID, int length) {
            throw new Goedel.Utilities.NYI();
            }

        /// <summary>
        /// Complete process of connecting to a profile.
        /// </summary>
        public void CompleteConnect () {
            GetFromPortal();
            }

        /// <summary>
        /// Fetch the latest version of the profile version
        /// </summary>
        public override void GetFromPortal () {
            SignedPersonalProfile = MeshClient.GetPersonalProfile();
            }
        /// <summary>
        /// Update the associated profile in the registry
        /// </summary>
        public override void WriteToPortal () {
            MeshClient.Publish(SignedPersonalProfile);
            }

        /// <summary>
        /// Report if the profile is the default personal profile or not.
        /// </summary>
        public virtual bool IsDefault { get; set; } = true; // Hack: Should work out if it is default

        /// <summary>
        /// Serialize for storage in a file.
        /// </summary>
        /// <returns>The serialization object</returns>
        public virtual SerializationPersonal Serialize () {
            var Result = new SerializationPersonal() {
                Profile = SignedPersonalProfile,
                Portals = Portals.Serialize()
                };

            if (IsDefault) {
                Result.Default = DateTime.Now;
                }
            return Result;
            }

        /// <summary>
        /// Obtain an application session for the specified identifier.
        /// </summary>
        /// <param name="Identifier">The type of application session to get.</param>
        /// <returns>The application session.</returns>
        public SessionApplication GetApplication (string Identifier) {
            MeshMachine.Find(Identifier, out SessionApplication Result);
            return Result;
            }


        /// <summary>
        /// Obtain an application session for the specified identifier.
        /// </summary>
        /// <param name="Type">The type of application</param>
        /// <returns>List of applications matching the specified type.</returns>
        public List<SessionApplication> GetApplicationsByType (string Type) {

            var Result = new List<SessionApplication>();

            foreach (var Application in PersonalProfile.Applications) {
                if (Application.Type == Type) {

                    var Session = GetSession(Application);
                    if (Session != null) {
                        Result.Add(Session);
                        }
                    }
                }

            return Result;
            }

        SessionApplication GetSession (ApplicationProfileEntry Application) {
            var Result = GetApplication(Application.Identifier);

            Result.DecryptDeviceProfiles = MatchDevices(Application.DecryptDeviceUDF);
            Result.AdminDeviceProfiles = MatchDevices(Application.DecryptDeviceUDF);

            return Result;
            }



        /// <summary>
        /// Return a list of device sessions with fingerprints that match the specified
        /// list of device identifiers.
        /// </summary>
        /// <param name="DeviceIdentifiers">The device identifier fingerprints to match.</param>
        /// <returns>The list of matching devices.</returns>
        public List<RegistrationDevice> MatchDevices (List<string> DeviceIdentifiers) {
            var Result = new List<RegistrationDevice>();

            foreach (var Identifier in DeviceIdentifiers) {
                if (MeshMachine.DeviceProfiles.TryGetValue(Identifier, out var Registration)) {
                    Result.Add(Registration);
                    }
                }

            return Result;
            }

        /// <summary>
        /// Get a user and application profile matching the specified parameters.
        /// </summary>
        /// <param name="UDF">NYI</param>
        /// <param name="Portal">List of portals to check</param>
        /// <param name="ApplicationId">Application to fetch</param>
        /// <param name="PersonalProfile">Returned personal profile.</param>
        /// <param name="ApplicationProfile">Returned application profile.</param>
        public static void GetUserProfile (string UDF, List<string> Portal, string ApplicationId,
                out PersonalProfile PersonalProfile, out ApplicationProfile ApplicationProfile) {

            Assert.True(Portal.Count > 0, ProfileNotFound.Throw);
            var PortalID = Portal[0];

            var Client = new MeshClient(PortalAccount: PortalID);
            var PersonalResponse = Client.GetPersonalProfile();
            PersonalProfile = PersonalResponse.PersonalProfile;

            var ApplicationProfileEntry = PersonalProfile.GetApplication(ApplicationId);

            var ApplicationResponse = Client.GetApplicationProfile(ApplicationProfileEntry.Identifier);
            ApplicationProfile = ApplicationResponse.ApplicationProfile;

            // NYI: Validate against the UDF
            }

        }
    }

