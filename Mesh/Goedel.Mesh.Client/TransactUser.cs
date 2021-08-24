#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
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
#endregion

using System.Collections.Generic;

using Goedel.Cryptography;
using Goedel.Utilities;

namespace Goedel.Mesh.Client {
    /// <summary>
    /// Transaction on a Mesh user account.Provides access to the account catalogs and spools.
    /// </summary>
    public partial class TransactUser : Transaction<ContextUser> {

        #region // Properties
        /// <summary>The account context in which this transaction takes place.</summary>
        public override ContextUser ContextAccount => ContextUser;
        /// <summary>The account context in which this transaction takes place.</summary>
        public ContextUser ContextUser { get; }

        ///<summary>Returns the application catalog for the account</summary>
        public CatalogApplication GetCatalogApplication() => ContextUser.GetStore(CatalogApplication.Label) as CatalogApplication;

        ///<summary>Returns the contacts catalog for the account</summary>
        public CatalogDevice GetCatalogDevice() => ContextUser.GetStore(CatalogDevice.Label) as CatalogDevice;

        ///<summary>Returns the contacts catalog for the account</summary>
        public CatalogContact GetCatalogContact() => ContextUser.GetStore(CatalogContact.Label) as CatalogContact;

        ///<summary>Returns the credential catalog for the account</summary>
        public CatalogCredential GetCatalogCredential() => ContextUser.GetStore(CatalogCredential.Label) as CatalogCredential;

        ///<summary>Returns the bookmark catalog for the account</summary>
        public CatalogBookmark GetCatalogBookmark() => ContextUser.GetStore(CatalogBookmark.Label) as CatalogBookmark;

        ///<summary>Returns the calendar catalog for the account</summary>
        public CatalogTask GetCatalogCalendar() => ContextUser.GetStore(CatalogTask.Label) as CatalogTask;

        ///<summary>Returns the network catalog for the account</summary>
        public CatalogNetwork GetCatalogNetwork() => ContextUser.GetStore(CatalogNetwork.Label) as CatalogNetwork;

        ///<summary>Returns the inbound spool for the account</summary>
        public SpoolInbound GetSpoolInbound() => ContextUser.GetStore(SpoolInbound.Label) as SpoolInbound;
        #endregion
        #region // Constructors

        /// <summary>
        /// Constructor creating transaction instance under the account context
        /// <paramref name="contextUser"/>
        /// </summary>
        /// <param name="contextUser">The account context in which the update
        /// is to be applied.</param>
        public TransactUser(ContextUser contextUser) => ContextUser = contextUser;

        #endregion
        #region // Methods
        public void ApplicationCreate(
                    CatalogedApplication catalogedApplication) {

            var catalog = GetCatalogApplication();
            CatalogUpdate(catalog, catalogedApplication);

            var catalogDevice = GetCatalogDevice();
            var updated = new List<CatalogedDevice>();
            foreach (var device in catalogDevice.AsCatalogedType) {

                Screen.WriteLine("Got device");
                if (catalogedApplication.DeviceAuthorized(device)) {
                    var activationApplication = catalogedApplication.GetActivation(device);

                    device.EnvelopedActivationApplications ??= new();
                    device.EnvelopedActivationApplications.Add(
                            activationApplication.EnvelopedActivationApplication);

                    updated.Add(device);
                    }
                }
            foreach (var device in updated) {
                CatalogUpdate(catalogDevice, device);
                }

            }

        public CryptoKey ApplicationUpdate(
            CatalogedApplication catalogedApplication) => throw new NYI();


        public void ApplicationDelete(
                    string applicationId) => throw new NYI();


        // Refactor this, it moves to ContextUser
        // Only requires the ConnectionDevice information

        public CatalogedApplication ApplicationGetSsh(
                    string applicationId, string deviceId= null) => throw new NYI();

        public CatalogedApplication ApplicationGetMail(
            string applicationId,
            string deviceUdf = null) => throw new NYI();

        public CatalogedApplication ApplicationDeviceAdd(
            CatalogedApplicationSsh application, Connection ProfileDevice=null) => throw new NYI();

        public CatalogedApplication ApplicationDeviceAdd(
            CatalogedApplicationMail application, Connection ProfileDevice = null) => throw new NYI();



        public CatalogedApplication ApplicationDeviceDelete(
                    string applicationId, string deviceUdf) => throw new NYI();



        public KeyPairAdvanced CreateServiced(
                    KeyPairAdvanced primaryKey,
                    KeyPair deviceEncryption) => throw new NYI();


        #endregion
        }
    }
