using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;
using Goedel.Mesh;
using Goedel.Persistence;


namespace Goedel.Mesh {
    public partial class KeyValue {
        public KeyValue(string Key, string Value) {
            this.Key = Key;
            this.Value = Value;
            }


        }


    /// <summary>
    /// High level Mesh Client interface.
    /// </summary>
    public partial class MeshClient {
        protected MeshService MeshService;

        public string AccountID;
        public string AccountName;
        public string Portal;
        public string UDF;


        

        public bool Connected { get { return MeshService != null; } }

        private SignedPersonalProfile _SignedPersonalProfile;
        public SignedPersonalProfile SignedPersonalProfile {
            get {
                if (_SignedPersonalProfile == null) {
                    GetPersonalProfile();
                    }
                return _SignedPersonalProfile;
                }
            }


        public PersonalProfile PersonalProfile {
            get {
                if (SignedPersonalProfile == null) return null;
                return SignedPersonalProfile.Signed;
                }
            }

        private SignedDeviceProfile _SignedDeviceProfile;
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
        /// Connect up to the default Mesh Service provider described in the 
        /// registry.
        /// </summary>
        public MeshClient() {
            // get the data from the registry
            var AccountID = Register.Read(Constants.RegistryAccounts, out UDF);
            if (AccountID == null) {
                return;
                }

            Account.SplitAccountID(AccountID, out AccountName, out Portal);
            MeshService = MeshPortal.Default.GetService(Portal, AccountName);
            }

        /// <summary>
        /// Connect up to a specified Mesh Portal and account.
        /// </summary>
        /// <param name="Service">The portal to connect to.</param>
        /// <param name="Account">The account name.</param>
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
            var AccountID = Account.ID(AccountName, Portal);
            Register.Write(Constants.RegistryAccounts, AccountID, UDF);
            }


        /// <summary>
        /// Check to see if an account name is acceptable for use at a portal.
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="ValidateResponse"></param>
        /// <returns></returns>
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
        /// <param name="Accountname"></param>
        /// <param name="SignedCurrentProfile"></param>
        /// <returns></returns>
        public CreateResponse CreatePersonalProfile(string AccountID,
                            SignedPersonalProfile SignedCurrentProfile) {

            var CreateRequest = new CreateRequest();
            CreateRequest.Profile = SignedCurrentProfile;
            CreateRequest.Account = AccountID;
            var CreateResponse = MeshService.CreateAccount(CreateRequest);

            this.AccountID = AccountID;
            Register.Write(Constants.RegistryAccounts, AccountID, SignedCurrentProfile.UDF);

            return CreateResponse;
            }

        /// <summary>
        /// Publish an offline escrow entry to the mesh.
        /// </summary>
        /// <param name="OfflineEscrowEntry"></param>
        /// <returns>Response from service.</returns>
        public PublishResponse Publish(OfflineEscrowEntry OfflineEscrowEntry) {
            var PublishRequest = new PublishRequest();
            PublishRequest.Entry = OfflineEscrowEntry;

            var PublishResponse = MeshService.Publish(PublishRequest);
            return PublishResponse;
            }


        /// <summary>
        /// Publish an offline escrow entry to the mesh.
        /// </summary>
        /// <param name="OfflineEscrowEntry"></param>
        /// <returns>Response from service.</returns>
        public PublishResponse Publish(SignedProfile SignedProfile) {
            var PublishRequest = new PublishRequest();
            PublishRequest.Entry = SignedProfile;

            var PublishResponse = MeshService.Publish(PublishRequest);
            return PublishResponse;
            }



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


        public SignedApplicationProfile GetApplicationProfile (string ID) {

            var GetRequest = new GetRequest();
            GetRequest.Identifier = ID;
            GetRequest.Multiple = false;

            var GetResponse = MeshService.Get(GetRequest);
            if (GetResponse.Entries.Count == 0) { return null; }

            var SignedApplicationProfile = GetResponse.Entries[0] as SignedApplicationProfile;
            if (SignedApplicationProfile == null) { return null; }

            return SignedApplicationProfile;
            }

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

        public MailProfile GetMailProfile() {
            if (PersonalProfile == null) return null;

            var PasswordProfileEntry = PersonalProfile.GetMailProfile();
            if (PasswordProfileEntry == null) return null;

            var SignedApplicationProfile = GetApplicationProfile(
                PasswordProfileEntry.Identifier);
            if (SignedApplicationProfile == null) return null;

            return null;

            //var Result = MailProfile.Get(SignedApplicationProfile,
            //        PersonalProfile);

            //return Result;
            }

        public NetworkProfile GetNetworkProfile() {
            if (PersonalProfile == null) return null;

            var PasswordProfileEntry = PersonalProfile.GetNetworkProfile();
            if (PasswordProfileEntry == null) return null;

            var SignedApplicationProfile = GetApplicationProfile(
                PasswordProfileEntry.Identifier);
            if (SignedApplicationProfile == null) return null;

            return null;

            //var Result = NetworkProfile.Get(SignedApplicationProfile,
            //        PersonalProfile);

            //return Result;
            }


        public ConnectStartResponse ConnectRequest (SignedDeviceProfile SignedDeviceProfile) {
            this.SignedDeviceProfile = SignedDeviceProfile;

            var ConnectionRequest = new ConnectionRequest(AccountID, SignedDeviceProfile);

            var DeviceRequest = new ConnectStartRequest();
            DeviceRequest.SignedRequest = ConnectionRequest.Signed;
            DeviceRequest.AccountID = AccountID;
            var DeviceResponse = MeshService.ConnectStart(DeviceRequest);


            return DeviceResponse;
            }


        public ConnectStatusResponse ConnectStatus (string UDF) {
            var DeviceCheckRequest = new ConnectStatusRequest();
            DeviceCheckRequest.DeviceID = UDF;
            DeviceCheckRequest.AccountID = AccountID;
            var DeviceResponse = MeshService.ConnectStatus(DeviceCheckRequest);


            return DeviceResponse;
            }

        public ConnectPendingResponse ConnectPending () {
            var PendingRequest = new ConnectPendingRequest();
            PendingRequest.AccountID = AccountID;
            var PendingResponse = MeshService.ConnectPending(PendingRequest);
            return PendingResponse;
            }

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

    /// <summary>
    /// Extended version of MeshClient adding in helper routines for
    /// profile administration.
    /// </summary>
    public class MeshAdminClient : MeshClient {


        }


    }
