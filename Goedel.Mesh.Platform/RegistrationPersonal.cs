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

namespace Goedel.Mesh.Platform {


    /// <summary>
    /// Describes the registration of as profile on as machine. This includes
    /// the fingerprint, the cached profile data and the list of portal entries
    /// to which the profile is bound.
    /// </summary>
    public abstract class RegistrationPersonal : PortalRegistration {

        /// <summary>
        /// The registered signed profile.
        /// </summary>
        public override SignedProfile SignedProfile { get => SignedPersonalProfile; }


        /// <summary>
        /// The most recent cached profile data, if available.
        /// </summary>
        public virtual PersonalProfile PersonalProfile {
            get => SignedPersonalProfile.PersonalProfile; 
            }


        public MeshCatalog MeshCatalog { get; set; }

        /// <summary>
        /// Client which may be used to interact with the portal on which this
        /// profile is registered.
        /// </summary>
        public override MeshClient MeshClient {
            get {
                _MeshClient = _MeshClient ?? MeshCatalog.Bind(Portals.Default);
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
        public virtual SignedPersonalProfile SignedPersonalProfile { get; set; }

        /// <summary>
        /// The profile fingerprint
        /// </summary>
        public override string UDF { get => SignedPersonalProfile?.UDF; } 

        /// <summary>
        /// Profiles associated with this account in chronological order.
        /// </summary>
        public abstract SortedList<DateTime, SignedProfile> Profiles { get; set; }


        public virtual bool Escrow (int Shares, int Quorum) {
            var OfflineEscrowEntry = new OfflineEscrowEntry(
               PersonalProfile, Shares, Quorum);
            return Escrow(OfflineEscrowEntry);
            }

        public virtual bool Escrow(OfflineEscrowEntry OfflineEscrowEntry) {
            var Result = MeshClient.Publish(OfflineEscrowEntry);
            return Result.Status.StatusSuccess();
            }


        /// <summary>
        /// Add a portal to this registration
        /// </summary>
        /// <param name="AccountID"></param>
        /// <param name="MeshClient"></param>
        /// <param name="Create">If true, the mesh client </param>
        public abstract void AddPortal(string AccountID, MeshClient MeshClient = null, bool Create=false);

        /// <summary>
        /// Add an application to this profile
        /// </summary>
        /// <param name="Profile"></param>
        /// <param name="Delay"></param>
        /// <returns></returns>
        public virtual RegistrationApplication Add(
                    ApplicationProfile Profile, bool Write = true) {

            var Entry = PersonalProfile.Add(Profile);

            var RegistrationApplication = RegistrationMachine.Add(Profile);
            RegistrationApplication.RegistrationPersonal = this;

            if (Write) {
                this.Write();
                RegistrationApplication.Write();
                }

            return RegistrationApplication;
            }



        /// <summary>
        /// Complete process of connecting to a profile.
        /// </summary>
        public List<ConnectionRequest> GetPending() {
            throw new NYI();
            }

        /// <summary>
        /// Complete process of connecting to a profile.
        /// </summary>
        public void Confirm(ConnectionRequest Request) {
            PersonalProfile.Add(Request.Device.DeviceProfile);

            Write();
           
            }

        /// <summary>
        /// Provide a PIN for authenticating the specified account ID
        /// </summary>
        public string GetPin (string AccountID, int length) {
            throw new NYI();
            }

        /// <summary>
        /// Complete process of connecting to a profile.
        /// </summary>
        public void CompleteConnect() {
            GetFromPortal();
            }

        /// <summary>
        /// Fetch the latest version of the profile version
        /// </summary>
        public override void GetFromPortal() {
            SignedPersonalProfile = MeshClient.GetPersonalProfile();
            }
        /// <summary>
        /// Update the associated profile in the registry
        /// </summary>
        public override void WriteToPortal() {
            MeshClient.Publish(SignedPersonalProfile);
            }

        }

    }

