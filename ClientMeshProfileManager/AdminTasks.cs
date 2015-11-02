using System;
using System.Collections.Generic;
using Goedel.Protocol;
using Goedel.Mesh;
using Goedel.Debug;
using Goedel.CryptoLibNG;
using CLG=Goedel.CryptoLibNG;

namespace Goedel.MeshProfileManager {


    public partial class AddProfile {
        public bool ConfigurePassword = false;
        public bool ConfigureNetwork = false;
        public bool ConfigureEmail = false;
        public bool ConfigureRecovery = false;

        public string share1 = "share1 TBS";
        public string share2 = "share2 TBS";
        public string share3 = "share3 TBS";

        public string UDF = "ProfileUDF TBS";

        public string Device1 = "DeviceName";
        public string Device1Description = "Original profile device";

        public string AccountName;
        public string Portal;
        public string AccountID {
            get { return Account.ID(AccountName, Portal); }
            }

        //public MailClientCatalog MailClientCatalog;
        public int AccountIndex;
        
        PersonalProfile UserProfile;
        SignedPersonalProfile SignedCurrentProfile;
        OfflineEscrowEntry OfflineEscrowEntry;

        public List<MailAccountInfo> AllMailAccountInfos;
        public List<MailAccountInfo> MailAccountInfos = new List<MailAccountInfo>();

        public string InvalidInput;
        //public MeshService MeshService;


        public SignedDeviceProfile ThisDevice;

        public MeshClient MeshClient;
        public override void Initialize() {
            MeshPortal.Default = new MeshPortalDirect();
            ThisDevice = SignedDeviceProfile.GetLocal(Device1, Device1Description);




            // Get the default profile if possible
            MeshClient = new MeshClient(); // default account

            if (MeshClient.Connected) {
                AccountName = MeshClient.AccountName;
                Portal = MeshClient.Portal;
                SignedCurrentProfile = SignedPersonalProfile.GetLocal(MeshClient.UDF);
                Navigate(Data_SetupComplete);
                }
            
            }


        /// <summary>
        /// Attempt to create an account at the specified portal.
        /// </summary>
        /// <param name="Portal"></param>
        /// <param name="account"></param>
        /// <returns>true if succeeded, false otherwise.</returns>
        public bool TryNewPortalAccount(string Portal, string Account) {
            Portal = (Portal == null) || (Portal == "") ? "prismproof.org" : Portal;


            this.Portal = Portal;
            this.AccountName = Account;

            MeshClient = new MeshClient (Portal);


            var ValidateResponse = MeshClient.Validate(Account);

            if (!ValidateResponse.Valid) {
                InvalidInput = ValidateResponse.Reason;
                }

            return ValidateResponse.Valid;
            }


        public void GenerateProfile() {

            UserProfile = new PersonalProfile(ThisDevice);
            UDF = UserProfile.PersonalMasterProfile.MasterSignatureKey.UDF;

            if (ConfigurePassword) {
                var PasswordProfile = new PasswordProfile(UserProfile);
                PasswordProfile.AddDevice(ThisDevice);
                }

            if (ConfigureNetwork) {
                var NetworkProfile = new NetworkProfile(UserProfile);
                NetworkProfile.AddDevice(ThisDevice);
                }

            if (ConfigureEmail) {
                foreach (var MailAccountInfo in MailAccountInfos) {
                    var MailProfile = new MailProfile(UserProfile, MailAccountInfo);
                    MailProfile.AddDevice(ThisDevice);
                    }
                }

            if (ConfigureRecovery) {
                MakeCheckRecovery();
                }
            
            // publish to the cloud
            var SignedProfile = new SignedPersonalProfile(UserProfile);

            SignedProfile.ToRegistry();

            MeshClient.CreatePersonalProfile (AccountName, SignedProfile);


            //var CreateRequest = new CreateRequest();
            //CreateRequest.Profile = SignedProfile;
            //CreateRequest.Account = Account;
            //var CreateResponse = MeshService.CreateAccount(CreateRequest);


            }


        void MakeCheckRecovery() {
            OfflineEscrowEntry = new OfflineEscrowEntry(UserProfile, 3, 2);
            share1 = OfflineEscrowEntry.KeyShares[0].Text;
            share2 = OfflineEscrowEntry.KeyShares[1].Text;
            share3 = OfflineEscrowEntry.KeyShares[2].Text;

            var PublishResponse = MeshClient.Publish(OfflineEscrowEntry);

            string[] TestShares = { share1, share2 };
            var RecoveryKey = RecoverProfile(TestShares);

            if (RecoveryKey != OfflineEscrowEntry.Identifier) {
                //throw new Exception("Recovery failure!");
                Trace.WriteLine("****Fail {0}");
                }
            }

        public string RecoverProfile(string [] Shares) {

            var KeyShares = new KeyShare[Shares.Length];

            int i = 0;
            foreach (var Share in Shares) {
                var Bytes = BaseConvert.FromBase32String(Share);
                KeyShares[i++] = new KeyShare(Bytes);

                //Trace.WriteHex("Share", Bytes);
                }

            var Combined = new Secret(KeyShares);
            //Trace.WriteHex("MasterKey", Combined.Key);
            var Identifier = CLG.UDF.ToString(CLG.UDF.FromEscrowed(Combined.Key, 150));

            return Identifier;
            }


        public List<SignedConnectionRequest> PendingConnectionRequests;

        /// <summary>
        /// Check to see if there are pending connection requests.
        /// </summary>
        /// <returns>True, if a pending connection request is present,
        /// otherwise false.</returns>
        public bool CheckPending () {
            var PendingResponse = MeshClient.ConnectPending();
            PendingConnectionRequests = PendingResponse.Pending;

            return (PendingConnectionRequests != null &&
                    PendingConnectionRequests.Count > 0);

            }



        public void GetAccount(string Portal, string Account) {
            //this.Account = Account;
            //this.Portal = Portal;

            //MeshService = MeshPortal.Default.GetService(Portal);

            //var GetRequest = new GetRequest();

            //GetRequest.Account  = Account;
            //var GetResponse = MeshService.Get(GetRequest);

            //if (GetResponse.Entries.Count < 0) {
            //    UDF = "Profile not found";
            //    }
            //else {
            //    var SignedProfile = GetResponse.Entries[0] as SignedPersonalProfile;
            //    UDF = SignedProfile.UDF;
            //    }

            }


        public void PostConnect() {



            // Generate the device profile


            }

        }


    }
