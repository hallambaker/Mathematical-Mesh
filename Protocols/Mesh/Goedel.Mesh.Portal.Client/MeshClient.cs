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
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Mesh;

namespace Goedel.Mesh.Portal.Client {

    /// <summary>
    /// High level Mesh Client interface.
    /// </summary>
    public partial class MeshClient {

        /// <summary>
        /// The MeshProtocol Service provider.
        /// </summary>
        protected MeshService MeshService;

        /// <summary>
        /// The account Identifier.
        /// </summary>
        public string AccountID;

        /// <summary>
        /// The account name.
        /// </summary>
        public string AccountName;

        ///// <summary>
        ///// The portal address.
        ///// </summary>
        //public string Portal;

        /// <summary>
        /// Fingerprint of the Personal Profile.
        /// </summary>
        public string UDF;

        /// <summary>
        /// True if the client is connected to an active MeshService.
        /// </summary>
        public bool Connected=> MeshService != null; 

        /// <summary>
        /// The active personal profile (with signature).
        /// </summary>
        public SignedPersonalProfile SignedPersonalProfile { get; set; }

        /// <summary>
        /// The active personal profile.
        /// </summary>
        public PersonalProfile PersonalProfile  => SignedPersonalProfile?.PersonalProfile;


        private SignedDeviceProfile _SignedDeviceProfile;
        /// <summary>
        /// The active device profile (with signature).
        /// </summary>
        public SignedDeviceProfile SignedDeviceProfile {
            get => _SignedDeviceProfile;

            set {
                if (PersonalProfile != null) {
                    PersonalProfile.DeviceProfile = value.DeviceProfile;
                    }
                _SignedDeviceProfile = value;
                }
            }


        /// <summary>
        /// Connect up to the specified Mesh Portal
        /// </summary>
        /// <param name="Service">The service to connect to.</param> 
        /// <param name="PortalAccount">The portal to connect to.</param>
        public MeshClient(string Service = null, string PortalAccount = null) {
            if (Service == null) {
                PortalAccount.SplitAccountID(out Service, out var Account);
                }
            Assert.NotNull(Service, InvalidPortalAddress.Throw);
            
            MeshService = MeshPortal.Default.GetService(Service);
            AccountID = PortalAccount;
            }


        public static SignedProfile GetProfile (string AccountID) {
            var Client = new MeshClient(PortalAccount: AccountID);
            var Profile = Client.GetPersonalProfile();

            return Profile;
            }


        /// <summary>
        /// Make the current portal and account name the default
        /// </summary>
        /// <param name="UDF">Fingerprint of the profile to make default.</param>
        public void MakeDefault(string UDF) {
            //var AccountID = Account.ID(AccountName, Portal);
            //Register.Write(Constants.RegistryAccounts, AccountID, UDF);
            }


        /// <summary>
        /// Check to see if an account name is acceptable for use at a portal.
        /// Note that a positive response to a validation request does not
        /// guarantee that the account name will be available for a subsequent
        /// call to CreatePersonalProfile.
        /// </summary>
        /// <param name="Account">The requested account name.</param>
        /// <returns>The service response.</returns>
        public ValidateResponse Validate(string Account) {
            var ValidateRequest = new ValidateRequest() {
                Account = Account,
                Language = new List<string> { "en-uk" }
                };
            var ValidateResponse = MeshService.ValidateAccount(ValidateRequest);

            return ValidateResponse;
            }

        /// <summary>
        /// Create a new account and set the personal profile
        /// </summary>
        /// <param name="AccountID">The requested account identifier.</param>
        /// <param name="SignedCurrentProfile">The personal profile to use.</param>
        /// <returns>The service response.</returns>
        public CreateResponse CreatePortalAccount(string AccountID,
                            SignedPersonalProfile SignedCurrentProfile) {

            var CreateRequest = new CreateRequest() {
                Profile = SignedCurrentProfile,
                Account = AccountID
                };
            var CreateResponse = MeshService.CreateAccount(CreateRequest);

            this.AccountID = AccountID;

            return CreateResponse;
            }

        /// <summary>
        /// Publish an offline escrow entry to the mesh.
        /// </summary>
        /// <param name="OfflineEscrowEntry">The escrow entry to publish</param>
        /// <returns>The service response.</returns>
        public PublishResponse Publish(OfflineEscrowEntry OfflineEscrowEntry) {
            var PublishRequest = new PublishRequest() {
                Entry = OfflineEscrowEntry
                };

            var PublishResponse = MeshService.Publish(PublishRequest);
            return PublishResponse;
            }


        /// <summary>
        /// Publish a signed profile entry to the mesh.
        /// </summary>
        /// <param name="SignedProfile">The profile to publish</param>
        /// <returns>The service response.</returns>
        public PublishResponse Publish(SignedProfile SignedProfile) {
            var PublishRequest = new PublishRequest() {
                Entry = SignedProfile
                };

            var PublishResponse = MeshService.Publish(PublishRequest);
            return PublishResponse;
            }


        /// <summary>
        /// Recover an offline escrow entry
        /// </summary>
        /// <param name="Identifier">The UDF of the decryption key</param>
        /// <returns>Offline escrow entry (if found), null otherwise.</returns>
        public OfflineEscrowEntry Recover (string Identifier) {
            var GetRequest = new GetRequest() {
                Identifier = Identifier,
                Multiple = false
                };
            var GetResponse = MeshService.Get(GetRequest);

            if (GetResponse.Entries.Count == 0) { return null; }

            var Result = GetResponse.Entries[0] as OfflineEscrowEntry;

            return Result;
            }


        /// <summary>
        /// Get the active profile associated with the current account.
        /// </summary>
        /// <returns>The signed personal profile.</returns>
        public SignedPersonalProfile GetPersonalProfile() {
            if (AccountID == null) {
                return null;
                }

            var GetRequest = new GetRequest() {
                Account = AccountID,
                Multiple = false
                };

            var GetResponse = MeshService.Get(GetRequest);

            if ((GetResponse.Entries == null || GetResponse.Entries.Count == 0)) { return null; }

            SignedPersonalProfile = GetResponse.Entries[0] as SignedPersonalProfile;

            if (PersonalProfile != null) {
                PersonalProfile.DeviceProfile = SignedDeviceProfile?.DeviceProfile;
                }
            return SignedPersonalProfile;
            }

        /// <summary>
        /// Retrieve an application profile by unique ID.
        /// </summary>
        /// <param name="ID">the unique id of the profile.</param>
        /// <returns>The signed application profile if found, otherwise null.</returns>
        public SignedApplicationProfile GetApplicationProfile (string ID) {

            var GetRequest = new GetRequest() {
                Identifier = ID,
                Multiple = false
                };

            var GetResponse = MeshService.Get(GetRequest);
            if (GetResponse.Entries == null) { return null; }
            if (GetResponse.Entries.Count == 0) { return null; }

            if (!(GetResponse.Entries[0] is SignedApplicationProfile SignedApplicationProfile)) { return null; }

            return SignedApplicationProfile;
            }


        /// <summary>
        /// Initiate a device connection request.
        /// </summary>
        /// <param name="SignedDeviceProfile">The device profile to register.</param>
        /// <param name="DeviceData">List of application data</param>
        /// <param name="DeviceRequest">The device request data</param>
        /// <returns>The service response.</returns>
        public ConnectStartResponse ConnectRequest (
                            SignedDeviceProfile SignedDeviceProfile,
                            out ConnectStartRequest DeviceRequest,
                            List<ApplicationDevicePublic> DeviceData = null) {
            this.SignedDeviceProfile = SignedDeviceProfile;

            var PersonalProfile = GetPersonalProfile();


            if (DeviceData == null) {
                DeviceData = new List<ApplicationDevicePublic>();

                //NYI: Fill device data 
                }

            // Create the request 
            var ConnectionRequest = new ConnectionRequest() {
                ParentUDF = PersonalProfile.UDF,
                Device = SignedDeviceProfile,
                DeviceData = DeviceData
                };

            DeviceRequest = new ConnectStartRequest() {
                SignedRequest = ConnectionRequest.SignedConnectionRequest,
                AccountID = AccountID
                };
            var DeviceResponse = MeshService.ConnectStart(DeviceRequest);

            return DeviceResponse;
            }

        /// <summary>
        /// Get status for a pending device connection request.
        /// </summary>
        /// <param name="UDF">Fingerprint of the device that requested the connection.</param>
        /// <returns>The service response.</returns>
        public ConnectStatusResponse ConnectStatus (string UDF) {
            var DeviceCheckRequest = new ConnectStatusRequest() {
                DeviceID = UDF,
                AccountID = AccountID
                };
            var DeviceResponse = MeshService.ConnectStatus(DeviceCheckRequest);


            return DeviceResponse;
            }

        /// <summary>
        /// Get a list of pending device connection requests.
        /// </summary>
        /// <returns>The service response.</returns>
        public ConnectPendingResponse ConnectPending () {
            var PendingRequest = new ConnectPendingRequest() {
                AccountID = AccountID
                };
            var PendingResponse = MeshService.ConnectPending(PendingRequest);
            return PendingResponse;
            }


        /// <summary>
        /// Close a pending device connection request. NB: It is the responsibility of the caller
        /// to make any changes to the profile.
        /// </summary>
        /// <param name="SignedConnectionRequest">The connection request to close.</param>
        /// <param name="ConnectionStatus">The status to set.</param>
        /// <returns>The service response.</returns>
        public ConnectCompleteResponse ConnectClose(SignedConnectionRequest SignedConnectionRequest,
                    ConnectionStatus ConnectionStatus) {

            var ConnectionRequest = SignedConnectionRequest.Data;
            var Device = ConnectionRequest.Device;




            var ConnectionResult = new ConnectionResult() {
                Result = ConnectionStatus.ToString(),
                Profile = PersonalProfile.SignedPersonalProfile,
                Device = Device
                };
            var SignedConnectionResult = new SignedConnectionResult(ConnectionResult,
                PersonalProfile.AdministrationKey);

            var ConnectCloseRequest = new ConnectCompleteRequest() {
                Result = SignedConnectionResult,
                AccountID = AccountID
                };

            var ConnectCloseResponse = MeshService.ConnectComplete(ConnectCloseRequest);
            return ConnectCloseResponse;
            }

        }

    }
