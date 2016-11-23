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


namespace Goedel.Mesh.Platform {

    /// <summary>
    /// Provides the interface layer between the application and all Mesh 
    /// functions.
    /// </summary>
    public class MeshCatalog {

        /// <summary>
        /// Return an interface populated with all the profiles and portal
        /// accounts on the current machine
        /// </summary>
        public MeshCatalog() {
            }

        /// <summary>
        /// Attempt to synchronize the catalog to get the authoritative sources.
        /// </summary>
        /// <returns>True if synchronization attempt succeeded.</returns>
        public bool Sync() {
            return false;
            }

        /// <summary>
        /// Commit local changes to upstream.
        /// </summary>
        /// <returns>True if synchronization attempt succeeded.</returns>
        public bool Commit() {
            return false;
            }

        /// <summary>
        /// Add a personal profile to the current machine
        /// </summary>
        /// <param name="Profile">Profile to add.</param>
        public void Add(PersonalProfile Profile) {
            }

        /// <summary>
        /// Get a personal profile.
        /// </summary>
        /// <param name="UDF">Profile fingerprint.</param>
        /// <param name="PortalID">Portal account.</param>
        /// <returns>The personal profile.</returns>
        public MeshPersonal GetPersonal(string UDF, string PortalID) {
            return null;
            }

        /// <summary>
        /// Get an application profile.
        /// </summary>
        /// <param name="UDF">Fingerprint of profile.</param>
        /// <returns>The profile (if found).</returns>
        public MeshApplication GetApplication(string UDF) {
            return null;
            }

        /// <summary>
        /// Get a device profile.
        /// </summary>
        /// <param name="UDF">Fingerprint of profile.</param>
        /// <returns>The profile (if found).</returns>
        public MeshDevice GetDevice(string UDF) {
            return null;
            }

        /// <summary>
        /// Begin the process of connecting to a profile at the specified portal
        /// </summary>
        /// <param name="PortalID">The portal to connect to</param>
        /// <param name="PIN">Optional one time authenticator.</param>
        public void BeginConnect(string PortalID, string PIN) {
            }

        /// <summary>
        /// Complete process of connecting to a profile.
        /// </summary>
        /// <param name="PortalID">The portal to connect to</param>
        public void CompleteConnect(string PortalID) {
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

    /// <summary>
    /// Wrapper for Mesh personal profile.
    /// </summary>
    public class MeshPersonal {

        //MeshDevice MeshDevice;
        /// <summary>If true, this is an administration profile.</summary>
        public bool IsAdmin;

        /// <summary>
        /// Return an interface populated with personal profile.
        /// </summary>
        /// <param name="PortalID">Portal Identifier</param>
        /// <param name="UDF">Fingerprint of profile to locate.</param>
        public MeshPersonal(string PortalID, string UDF) {
            }

        /// <summary>
        /// Add a portal to the local profile.
        /// </summary>
        /// <param name="PortalID">Portal Identifier</param>
        public void AddPortal(string PortalID) {
            }


        /// <summary>
        /// Get a application profile with the specified UDF. If neither the UDF nor the 
        /// friendly name is specified, the default profile is returned.
        /// </summary>
        /// <param name="Type">The application type</param>
        /// <param name="UDF">Fingerprint of profile to locate.</param>
        /// <param name="Friendly">Friendly name of profile to locate.</param>
        /// <returns>The selected password application.</returns>
        public MeshApplication GetApplication(MeshApplicationType Type, string UDF, string Friendly) {
            return null;
            }

        /// <summary>
        /// Get a password application profile with the specified UDF. If neither the UDF nor the 
        /// friendly name is specified, the default profile is returned.
        /// </summary>
        /// <param name="UDF">Fingerprint of profile to locate.</param>
        /// <param name="Friendly">Friendly name of profile to locate.</param>
        /// <returns>The selected password application.</returns>
        public MeshApplication GetApplicationPassword(string UDF, string Friendly) {
            return null;
            }

        /// <summary>
        /// Add application profile
        /// </summary>
        /// <param name="ApplicationProfile">Profile to add</param>
        /// <returns>The interface class for the profile that was added.</returns>
        public MeshApplication Add(ApplicationProfile ApplicationProfile) {
            return null;
            }

        /// <summary>
        /// Create a set of escrow shared for the private keys
        /// </summary>
        /// <param name="shares">Number of shares.</param>
        /// <param name="quorum">Number of shares required to reconstruct the key.</param>
        public void CreateEscrow(int shares, int quorum) {
            }

        /// <summary>
        /// Delete all private keys from this machine
        /// </summary>
        public void DeletePrivateKeys() {
            }

        /// <summary>
        /// Retrieve pending connection requests
        /// </summary>
        public void Pending() {
            }

        /// <summary>
        /// Complete a pending connection request.
        /// </summary>
        public void Complete() {
            }


        /// <summary>
        /// Write updates to the portal
        /// </summary>
        public void Update() {
            }

        /// <summary>
        /// Get a pin code verifier for the profile.
        /// </summary>
        /// <returns>Pin code for pre-authenticating the connection request.</returns>
        public string GetPIN() {
            return null;
            }

        }

    /// <summary>
    /// Base class for Mesh application profiles.
    /// </summary>
    public class MeshApplication {
        //MeshPersonal MeshPersonal;
        //MeshDevice MeshDevice;

        /// <summary>If true a change to the profile has not been synced.</summary>
        public bool Changed = false;

        /// <summary>The signed application profile</summary>
        protected SignedApplicationProfile SignedProfile;

        /// <summary>
        /// Generic accessor for contained profile
        /// </summary>
        public virtual ApplicationProfile ApplicationProfile {
            get { return _ApplicationProfile; }
            }
        ApplicationProfile _ApplicationProfile = null;

        /// <summary>
        /// Update profile.
        /// </summary>
        public virtual void Update() {
            }

        /// <summary>delete profile</summary>
        public void Delete() {
            }

        }

    /// <summary>
    /// Password wpplication profile interface.
    /// </summary>
    public class MeshApplicationPassword : MeshApplication {

        /// <summary>
        /// Generic accessor for contained profile
        /// </summary>
        public override ApplicationProfile ApplicationProfile {
            get { return Profile; }
            }

        /// <summary>Public profile</summary>
        public PasswordProfile Profile;

        /// <summary>Private profile</summary>
        public PasswordProfilePrivate Private {
            get { return Profile?.Private; }
            }

        /// <summary>
        /// Add username and password entry for a site.
        /// </summary>
        /// <param name="Site">Site for which the credential applies</param>
        /// <param name="Username">Username part of credential</param>
        /// <param name="Password">Password part of credential</param>
        public void Add(string Site, string Username, string Password) {
            Changed = true;
            }

        /// <summary>
        /// Add username and password entry for a site.
        /// </summary>
        /// <param name="Sites">List of sites for which the credential applies</param>
        /// <param name="Username">Username part of credential</param>
        /// <param name="Password">Password part of credential</param>
        public void Add(List<string> Sites, string Username, string Password) {
            Changed = true;
            }

        /// <summary>
        /// Delete credential entry for a site.
        /// </summary>
        /// <param name="Site">Name of site to delete credentials for</param>
        public void Delete(string Site) {
            Changed = true;
            }

        /// <summary>
        /// Get credential for a site.
        /// </summary>
        /// <param name="Site">Name of site to get credentials for</param>
        public void Get(string Site) {
            }



        }


    /// <summary>
    /// Wrapper class for SSH application profile.
    /// </summary>
    public class MeshApplicationSSH : MeshApplication {

        /// <summary>
        /// Generic accessor for contained profile
        /// </summary>
        public override ApplicationProfile ApplicationProfile {
            get { return Profile; }
            }

        /// <summary>The public part of the profile.</summary>
        public SSHProfile Profile;
        /// <summary>The private part of the profile</summary>
        public PasswordProfilePrivate Private;

        }

    /// <summary>
    /// Interface class for mail profile.
    /// </summary>
    public class MeshApplicationMail : MeshApplication {

        /// <summary>
        /// Generic accessor for contained profile
        /// </summary>
        public override ApplicationProfile ApplicationProfile {
            get { return Profile; }
            }

        /// <summary>The public profile</summary>
        public MailProfile Profile;

        /// <summary>The private profile.</summary>
        public MailProfilePrivate Private {
            get { return Profile?.Private; }
            }

        }

    /// <summary>
    /// Network application profile interface.
    /// </summary>
    public class MeshApplicationNetwork : MeshApplication {

        /// <summary>
        /// Generic accessor for contained profile
        /// </summary>
        public override ApplicationProfile ApplicationProfile {
            get { return Profile; }
            }

        /// <summary>Public profile</summary>
        public NetworkProfile Profile;

        /// <summary>Private profile</summary>
        public NetworkProfilePrivate Private {
            get { return Profile?.Private; }
            }

        }

    /// <summary>
    /// Interface for device profile.
    /// </summary>
    public class MeshDevice {

        /// <summary>
        /// Update the profile.
        /// </summary>
        public void Update() {
            }
        }


    }
