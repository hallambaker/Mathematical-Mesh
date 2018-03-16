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
using Goedel.IO;
using Goedel.Mesh;
using Goedel.Mesh.Portal;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.KeyFile;

namespace Goedel.Mesh.Portal.Client {


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
        public override MeshMachine MeshMachine => SessionPersonal?.MeshMachine;


        PersonalProfile PersonalProfile => SessionPersonal?.PersonalProfile;

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


        /// <summary>
        /// Fetch the latest version of the profile version
        /// </summary>
        public override void GetFromPortal () {
            throw new NYI();
            }

        /// <summary>
        /// Make this the default registration for its type
        /// </summary>
        public override void MakeDefault () {
            throw new NYI();
            }
        }


    public static partial class Extension {

        public static SessionMail Create (
                    this SessionPersonal SessionPersonal,
                    MailProfile MailProfile) {

            throw new NYI();

            }

        public static SessionMail SessionMail (
                this SessionPersonal SessionPersonal,
                string UDF = null,
                string ShortId = null) {

            var Found = SessionPersonal.MeshMachine.Find(
                out var Result,
                "SessionMail",
                UDF: UDF,
                ShortId: ShortId);

            return Result as SessionMail;
            }


        public static SessionCredential Create (
                    this SessionPersonal SessionPersonal,
                    CredentialProfile MailProfile) {

            throw new NYI();

            }

        public static SessionCredential SessionCredential (
                this SessionPersonal SessionPersonal,
                string UDF = null,
                string ShortId = null) {

            var Found = SessionPersonal.MeshMachine.Find(
                out var Result,
                "SessionCredential",
                UDF: UDF,
                ShortId: ShortId);

            return Result as SessionCredential;
            }


        public static SessionBookmark Create (
                    this SessionPersonal SessionPersonal,
                    BookmarkProfile MailProfile) {

            throw new NYI();

            }

        public static SessionBookmark SessionBookmark (
                this SessionPersonal SessionPersonal,
                string UDF = null,
                string ShortId = null) {

            var Found = SessionPersonal.MeshMachine.Find(
                out var Result,
                "SessionBookmark",
                UDF: UDF,
                ShortId: ShortId);

            return Result as SessionBookmark;
            }


        public static SessionContact Create (
                    this SessionPersonal SessionPersonal,
                    ContactProfile MailProfile) {

            throw new NYI();

            }

        public static SessionContact SessionContact (
                this SessionPersonal SessionPersonal,
                string UDF = null,
                string ShortId = null) {

            var Found = SessionPersonal.MeshMachine.Find(
                out var Result,
                "SessionContact",
                UDF: UDF,
                ShortId: ShortId);

            return Result as SessionContact;
            }


        public static SessionNetwork Create (
                    this SessionPersonal SessionPersonal,
                    NetworkProfile MailProfile) {

            throw new NYI();

            }

        public static SessionNetwork SessionNetwork (
                this SessionPersonal SessionPersonal,
                string UDF = null,
                string ShortId = null) {

            var Found = SessionPersonal.MeshMachine.Find(
                out var Result,
                "SessionNetwork",
                UDF: UDF,
                ShortId: ShortId);

            return Result as SessionNetwork;
            }

        public static SessionSSH Create (
            this SessionPersonal SessionPersonal,
            SSHProfile MailProfile) {

            throw new NYI();

            }

        public static SessionSSH SessionSSH (
                this SessionPersonal SessionPersonal,
                string UDF = null,
                string ShortId = null) {

            var Found = SessionPersonal.MeshMachine.Find(
                out var Result,
                "SessionSSH",
                UDF: UDF,
                ShortId: ShortId);

            return Result as SessionSSH;
            }


        public static void SSHExpand (
                    this SessionPersonal SessionPersonal,
                    string FileName = null) {

            throw new NYI();

            }

        }

    public abstract class SessionCatalog : SessionApplication {

        public override MeshMachine MeshMachine { set => throw new NotImplementedException(); }

        public override void GetFromPortal () {
            throw new NotImplementedException();
            }

        public override void MakeDefault () {
            throw new NotImplementedException();
            }
        }

    public partial class SessionMail : SessionCatalog {


        public void Export (
                    TextWriter TextWriter,
                    KeyFileFormat KeyFileFormat,
                    bool Private = false,
                    byte[] Password = null) {

            throw new NYI();
            }

        public void Export (
            string Filename,
            KeyFileFormat KeyFileFormat,
            bool Private = false,
            byte[] Password = null) {

            using (var Writer = Filename.OpenTextWriterNew()) {
                Export(Writer, KeyFileFormat, Private, Password);
                }
            }


        }


    public partial class SessionSSH : SessionCatalog {


        public void Export (
                    TextWriter TextWriter,
                    KeyFileFormat KeyFileFormat,
                    bool Private = false,
                    byte[] Password = null) {

            throw new NYI();
            }

        public void Export (
            string Filename,
            KeyFileFormat KeyFileFormat,
            bool Private = false,
            byte[] Password = null) {

            using (var Writer = Filename.OpenTextWriterNew()) {
                Export(Writer, KeyFileFormat, Private, Password);
                }
            }

        public void Rekey () {
            throw new NYI();
            }
        }



    public partial class SessionCredential : SessionCatalog {

        public void Add (CredentialEntry CredentialEntry) {
            throw new NYI();
            }

        public void Update (CredentialEntry CredentialEntry, bool Create=true) {
            throw new NYI();
            }

        public CredentialEntry Get (string Identifier) {
            throw new NYI();
            }

        public void Delete (string Identifier) {
            throw new NYI();
            }

        }

    public partial class SessionBookmark : SessionCatalog {

        public void Add (BookmarkEntry CredentialEntry) {
            throw new NYI();
            }

        public void Update (BookmarkEntry CredentialEntry, bool Create = true) {
            throw new NYI();
            }

        public BookmarkEntry Get (string Identifier) {
            throw new NYI();
            }

        public void Delete (string Identifier) {
            throw new NYI();
            }

        }

    public partial class SessionContact : SessionCatalog {

        public void Add (ContactEntry CredentialEntry) {
            throw new NYI();
            }

        public void Update (ContactEntry CredentialEntry, bool Create = true) {
            throw new NYI();
            }

        public ContactEntry Get (string Identifier) {
            throw new NYI();
            }

        public void Delete (string Identifier) {
            throw new NYI();
            }

        }

    public partial class SessionNetwork : SessionCatalog {

        public void Add (NetworkEntry CredentialEntry) {
            throw new NYI();
            }

        public void Update (NetworkEntry CredentialEntry, bool Create = true) {
            throw new NYI();
            }

        public NetworkEntry Get (string Identifier) {
            throw new NYI();
            }

        public void Delete (string Identifier) {
            throw new NYI();
            }

        }

    }
