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
using Goedel.Mesh;


namespace Goedel.Mesh {

    public partial class KeyValue {

        /// <summary>
        /// Constructor from principal fields.
        /// </summary>
        /// <param name="Key">The initial value of the Key field.</param>
        /// <param name="Value">The initial value of the Value field.</param>
        public KeyValue(string Key, string Value) {
            this.Key = Key;
            this.Value = Value;
            }


        }


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

        /// <summary>
        /// The portal address.
        /// </summary>
        public string Portal;

        /// <summary>
        /// Fingerprint of the Personal Profile.
        /// </summary>
        public string UDF;

        /// <summary>
        /// True if the client is connected to an active MeshService.
        /// </summary>
        public bool Connected { get { return MeshService != null; } }

        private SignedPersonalProfile _SignedPersonalProfile;

        /// <summary>
        /// The active personal profile (with signature).
        /// </summary>
        public SignedPersonalProfile SignedPersonalProfile {
            get {
                if (_SignedPersonalProfile == null) {
                    GetPersonalProfile();
                    }
                return _SignedPersonalProfile;
                }
            }

        /// <summary>
        /// The active personal profile.
        /// </summary>
        public PersonalProfile PersonalProfile {
            get {
                if (SignedPersonalProfile == null) return null;
                return SignedPersonalProfile.Signed;
                }
            }

        private SignedDeviceProfile _SignedDeviceProfile;
        /// <summary>
        /// The active device profile (with signature).
        /// </summary>
        public SignedDeviceProfile SignedDeviceProfile {
            get {
                return _SignedDeviceProfile;
                }

            set {
                if (PersonalProfile != null) {
                    PersonalProfile.SignedDeviceProfile = value;
                    }
                _SignedDeviceProfile = value;
                }
            }


        /// <summary>
        /// Connect up to a specified Mesh Portal and account.
        /// </summary>
        /// <param name="Portal">The portal to connect to.</param>
        /// <param name="AccountID">The account identifier.</param>
        public MeshClient(string Portal, string AccountID) {
            MeshService = MeshPortal.Default.GetService(Portal, AccountID);
            this.AccountID = AccountID;
            }


        /// <summary>
        /// Connect up to the specified Mesh Portal
        /// </summary>
        public MeshClient(string Portal) {
            this.Portal = Portal;
            MeshService = MeshPortal.Default.GetService(Portal);
            }



        /// <summary>
        /// Make the current portal and account name the default
        /// </summary>
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
            var ValidateRequest = new ValidateRequest();

            ValidateRequest.Account = Account;
            ValidateRequest.Language = new List<string> { "en-uk" };

            var ValidateResponse = MeshService.ValidateAccount(ValidateRequest);

            return ValidateResponse;
            }

        /// <summary>
        /// Create a new account and set the personal profile
        /// </summary>
        /// <param name="AccountID">The requested account identifier.</param>
        /// <param name="SignedCurrentProfile">The personal profile to use.</param>
        /// <returns>The service response.</returns>
        public CreateResponse CreatePersonalProfile(string AccountID,
                            SignedPersonalProfile SignedCurrentProfile) {

            var CreateRequest = new CreateRequest();
            CreateRequest.Profile = SignedCurrentProfile;
            CreateRequest.Account = AccountID;
            var CreateResponse = MeshService.CreateAccount(CreateRequest);

            this.AccountID = AccountID;
            //Register.Write(Constants.RegistryAccounts, AccountID, SignedCurrentProfile.UDF);

            return CreateResponse;
            }

        /// <summary>
        /// Publish an offline escrow entry to the mesh.
        /// </summary>
        /// <param name="OfflineEscrowEntry"></param>
        /// <returns>The service response.</returns>
        public PublishResponse Publish(OfflineEscrowEntry OfflineEscrowEntry) {
            var PublishRequest = new PublishRequest();
            PublishRequest.Entry = OfflineEscrowEntry;

            var PublishResponse = MeshService.Publish(PublishRequest);
            return PublishResponse;
            }


        /// <summary>
        /// Publish a signed profile entry to the mesh.
        /// </summary>
        /// <param name="SignedProfile"></param>
        /// <returns>The service response.</returns>
        public PublishResponse Publish(SignedProfile SignedProfile) {
            var PublishRequest = new PublishRequest();
            PublishRequest.Entry = SignedProfile;

            var PublishResponse = MeshService.Publish(PublishRequest);
            return PublishResponse;
            }


        /// <summary>
        /// Recover an offline escrow entry
        /// </summary>
        /// <param name="Identifier">The UDF of the decryption key</param>
        /// <returns>Offline escrow entry (if found), null otherwise.</returns>
        public OfflineEscrowEntry Recover (string Identifier) {
            var GetRequest = new GetRequest();
            GetRequest.Identifier = Identifier;
            GetRequest.Multiple = false;
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
            if (AccountID == null) return null;

            var GetRequest = new GetRequest ();
            GetRequest.Account = AccountID;
            GetRequest.Multiple = false;

            var GetResponse = MeshService.Get(GetRequest);

            if (GetResponse.Entries.Count == 0) { return null; }

            _SignedPersonalProfile = GetResponse.Entries[0] as SignedPersonalProfile;

            if (PersonalProfile != null) {
                PersonalProfile.SignedDeviceProfile = SignedDeviceProfile;
                }
            return _SignedPersonalProfile;
            }

        /// <summary>
        /// Retrieve an application profile by unique ID.
        /// </summary>
        /// <param name="ID">the unique id of the profile.</param>
        /// <returns>The signed application profile if found, otherwise null.</returns>
        public SignedApplicationProfile GetApplicationProfile (string ID) {

            var GetRequest = new GetRequest();
            GetRequest.Identifier = ID;
            GetRequest.Multiple = false;

            var GetResponse = MeshService.Get(GetRequest);
            if (GetResponse.Entries == null) { return null; }
            if (GetResponse.Entries.Count == 0) { return null; }

            var SignedApplicationProfile = GetResponse.Entries[0] as SignedApplicationProfile;
            if (SignedApplicationProfile == null) { return null; }

            return SignedApplicationProfile;
            }

        /// <summary>
        /// Retreive the default password profile.
        /// </summary>
        /// <returns>The password profile if found and valid, otherwise null.</returns>
        public PasswordProfile GetPasswordProfile() {
            if (PersonalProfile == null) return null;

            var PasswordProfileEntry = PersonalProfile.GetPasswordProfile();
            if (PasswordProfileEntry == null) return null;

            var SignedApplicationProfile = GetApplicationProfile(
                PasswordProfileEntry.Identifier);
            if (SignedApplicationProfile == null) return null;

            var Result = PasswordProfile.Get(SignedApplicationProfile,
                    PersonalProfile);

            return Result;
            }

        /// <summary>
        /// Retreive the default mail profile.
        /// </summary>
        /// <returns>The mail profile if found and valid, otherwise null.</returns>
        public MailProfile GetMailProfile() {
            if (PersonalProfile == null) return null;

            var PasswordProfileEntry = PersonalProfile.GetMailProfile();
            if (PasswordProfileEntry == null) return null;

            var SignedApplicationProfile = GetApplicationProfile(
                PasswordProfileEntry.Identifier);
            if (SignedApplicationProfile == null) return null;

            return null;
            }

        /// <summary>
        /// Retreive the default network profile.
        /// </summary>
        /// <returns>The network profile if found and valid, otherwise null.</returns>
        public NetworkProfile GetNetworkProfile() {
            if (PersonalProfile == null) return null;

            var PasswordProfileEntry = PersonalProfile.GetNetworkProfile();
            if (PasswordProfileEntry == null) return null;

            var SignedApplicationProfile = GetApplicationProfile(
                PasswordProfileEntry.Identifier);
            if (SignedApplicationProfile == null) return null;

            return null;
            }

        /// <summary>
        /// Initiate a device connection request.
        /// </summary>
        /// <param name="SignedDeviceProfile">The device profile to register.</param>
        /// <returns></returns>
        public ConnectStartResponse ConnectRequest (SignedDeviceProfile SignedDeviceProfile) {
            this.SignedDeviceProfile = SignedDeviceProfile;

            var ConnectionRequest = new ConnectionRequest(AccountID, SignedDeviceProfile);

            var DeviceRequest = new ConnectStartRequest();
            DeviceRequest.SignedRequest = ConnectionRequest.Signed;
            DeviceRequest.AccountID = AccountID;
            var DeviceResponse = MeshService.ConnectStart(DeviceRequest);


            return DeviceResponse;
            }

        /// <summary>
        /// Get status for a pending device connection request.
        /// </summary>
        /// <param name="UDF"></param>
        /// <returns>The service response.</returns>
        public ConnectStatusResponse ConnectStatus (string UDF) {
            var DeviceCheckRequest = new ConnectStatusRequest();
            DeviceCheckRequest.DeviceID = UDF;
            DeviceCheckRequest.AccountID = AccountID;
            var DeviceResponse = MeshService.ConnectStatus(DeviceCheckRequest);


            return DeviceResponse;
            }

        /// <summary>
        /// Get a list of pending device connection requests.
        /// </summary>
        /// <returns>The service response.</returns>
        public ConnectPendingResponse ConnectPending () {
            var PendingRequest = new ConnectPendingRequest();
            PendingRequest.AccountID = AccountID;
            var PendingResponse = MeshService.ConnectPending(PendingRequest);
            return PendingResponse;
            }

        /// <summary>
        /// Close a pending device connection request.
        /// </summary>
        /// <param name="SignedConnectionRequest">The connection request to close.</param>
        /// <param name="ConnectionStatus">The status to set.</param>
        /// <returns>The service response.</returns>
        public ConnectCompleteResponse ConnectClose (SignedConnectionRequest SignedConnectionRequest,
                    ConnectionStatus ConnectionStatus) {

            var ConnectionRequest = SignedConnectionRequest.Data;
            var Device = ConnectionRequest.Device;

            var ConnectionResult = new ConnectionResult();
            ConnectionResult.Result = ConnectionStatus.ToString ();
            ConnectionResult.Device = Device;
            var SignedConnectionResult = new SignedConnectionResult(ConnectionResult,
                PersonalProfile.GetAdministrationKey());

            var ConnectCloseRequest = new ConnectCompleteRequest();
            ConnectCloseRequest.Result = SignedConnectionResult;
            ConnectCloseRequest.AccountID = AccountID;

            var ConnectCloseResponse = MeshService.ConnectComplete(ConnectCloseRequest);
            return ConnectCloseResponse;
            }

        }

    }
