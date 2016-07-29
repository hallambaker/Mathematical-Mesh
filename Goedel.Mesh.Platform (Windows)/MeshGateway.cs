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
using Goedel.Debug;

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


        public void Sync() {
            }


        public void Commit() {
            }


        public void Add(PersonalProfile Profile) {
            }


        public MeshPersonal GetPersonal(string UDF, string PortalID) {
            return null;
            }

        public MeshApplication GetApplication(string UDF) {
            return null;
            }

        public MeshDevice GetDevice(string UDF) {
            return null;
            }

        /// <summary>
        /// Begin the process of connecting to a profile at the specified portal
        /// </summary>
        /// <param name="PortalID"></param>
        /// <param name="PIN">Optional one time authenticator.</param>
        public void BeginConnect(string PortalID, string PIN) {
            }


        public void CompleteConnect(string PortalID) {
            }
        }


    public enum MeshApplicationType {
        Password,
        SSH,
        Mail,
        Network
        }

    public class MeshPersonal {

        //MeshDevice MeshDevice;
        public bool IsAdmin;

        /// <summary>
        /// Return an interface populated with 
        /// </summary>
        /// <param name="PortalID"></param>
        /// <param name="UDF"></param>
        public MeshPersonal(string PortalID, string UDF) {
            }


        public void AddPortal(string PortalID) {
            }


        public MeshApplication GetApplication(MeshApplicationType Type, string UDF, string Friendly) {
            return null;
            }


        public MeshApplication GetApplicationPassword(string UDF, string Friendly) {
            return null;
            }


        public MeshApplication Add(ApplicationProfile ApplicationProfile) {
            return null;
            }


        public void CreateEscrow(int shares, int quorum) {
            }

        public void DeletePrivateKeys() {
            }


        public void Pending() {
            }


        public void Complete() {
            }


        /// <summary>
        /// 
        /// </summary>
        public void Update() {
            }

        public string GetPIN() {
            return null;
            }

        }

    public class MeshApplication {
        //MeshPersonal MeshPersonal;
        //MeshDevice MeshDevice;

        public bool Changed = false;
        protected SignedApplicationProfile SignedProfile;

        /// <summary>
        /// Generic accessor for contained profile
        /// </summary>
        public virtual ApplicationProfile ApplicationProfile {
            get { return _ApplicationProfile; }
            }
        ApplicationProfile _ApplicationProfile = null;

        /// <summary>
        /// 
        /// </summary>
        public virtual void Update() {
            }

        public void Delete() {
            }

        }


    public class MeshApplicationPassword : MeshApplication {

        /// <summary>
        /// Generic accessor for contained profile
        /// </summary>
        public override ApplicationProfile ApplicationProfile {
            get { return Profile; }
            }


        public PasswordProfile Profile;
        public PasswordProfilePrivate Private {
            get { return Profile?.Private; }
            }


        public void Add(string Site, string Username, string Password) {
            Changed = true;
            }


        public void Add(List<string> Site, string Username, string Password) {
            Changed = true;
            }

        public void Delete(string Site) {
            Changed = true;
            }

        public void Get(string Site) {
            }



        }



    //public class MeshApplicationSSH : MeshApplication {

    //    /// <summary>
    //    /// Generic accessor for contained profile
    //    /// </summary>
    //    public override ApplicationProfile ApplicationProfile {
    //        get { return Profile; }
    //        }


    //    public SSHProfile Profile;
    //    public PasswordProfilePrivate Private;

    //    }


    public class MeshApplicationMail : MeshApplication {

        /// <summary>
        /// Generic accessor for contained profile
        /// </summary>
        public override ApplicationProfile ApplicationProfile {
            get { return Profile; }
            }


        public MailProfile Profile;
        public MailProfilePrivate Private {
            get { return Profile?.Private; }
            }

        }

    public class MeshApplicationNetwork : MeshApplication {

        /// <summary>
        /// Generic accessor for contained profile
        /// </summary>
        public override ApplicationProfile ApplicationProfile {
            get { return Profile; }
            }


        public NetworkProfile Profile;
        public NetworkProfilePrivate Private {
            get { return Profile?.Private; }
            }

        }


    public class MeshDevice {

        /// <summary>
        /// 
        /// </summary>
        public void Update() {
            }
        }


    }
