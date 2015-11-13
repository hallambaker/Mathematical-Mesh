using System;
using System.Collections.Generic;
using Goedel.Protocol;
using Goedel.Mesh;
using Goedel.Debug;
using Goedel.CryptoLibNG;
using CLG=Goedel.CryptoLibNG;

namespace Goedel.MeshProfileManager {

    /// <summary>
    /// This class functions like a large FORTRAN common block tracking the 
    /// stateful user interaction.
    /// </summary>
    public partial class AddProfile {

        /// <summary>
        /// Set true if the user wants to setup the password profile app.
        /// </summary>
        public bool ConfigurePassword = false;

        /// <summary>
        /// Set true if the user wants to setup the network profile app.
        /// </summary>
        public bool ConfigureNetwork = false;

        /// <summary>
        /// Set true if the user wants to setup the email profile app.
        /// </summary>
        public bool ConfigureEmail = false;

        /// <summary>
        /// Set true if the user wants to escrow keys for recovery.
        /// </summary>
        public bool ConfigureRecovery = false;

        /// <summary>
        /// Return the first share value
        /// </summary>
        public string share1 = "share1 TBS";

        /// <summary>
        /// Return the second share value
        /// </summary>
        public string share2 = "share2 TBS";

        /// <summary>
        /// Return the third share value
        /// </summary>
        public string share3 = "share3 TBS";

        /// <summary>
        /// The UDF of the current personal profile.
        /// </summary>
        public string UDF = "ProfileUDF TBS";

        /// <summary>
        /// The device name
        /// </summary>
        public string Device1 = "DeviceName";

        /// <summary>
        /// The Device Description.
        /// </summary>
        public string Device1Description = "Original profile device";

        /// <summary>
        /// Account name
        /// </summary>
        public string AccountName;

        /// <summary>
        /// DNS address of Mesh portal.
        /// </summary>
        public string Portal;

        /// <summary>
        /// Account Identifier, is [AccountName]@[Portal]
        /// </summary>
        public string AccountID {
            get { return Account.ID(AccountName, Portal); }
            }

        /// <summary>
        /// Index variable used to track which mail account is being 
        /// queried.
        /// </summary>
        public int AccountIndex;
        
        /// <summary>
        /// User's personal profile.
        /// </summary>
        PersonalProfile UserProfile;

        /// <summary>
        /// Usre's Signed Profile.
        /// </summary>
        SignedPersonalProfile SignedCurrentProfile;

        /// <summary>
        /// The offline escrow entry data.
        /// </summary>
        OfflineEscrowEntry OfflineEscrowEntry;

        /// <summary>
        /// The list of mail accounts found on the machine.
        /// </summary>
        public List<MailAccountInfo> AllMailAccountInfos;

        /// <summary>
        /// The list of mail accounts the user would like to create mesh profiles for.
        /// </summary>
        public List<MailAccountInfo> MailAccountInfos = new List<MailAccountInfo>();

        /// <summary>
        /// Reporting string for invalid input. When an operation throws an error, the
        /// corresponding text is written to InvalidInput for reporting to the user.
        /// </summary>
        public string InvalidInput;

        /// <summary>
        /// The device profile.
        /// </summary>
        public SignedDeviceProfile ThisDevice;

        /// <summary>
        /// Track state of the mesh connection.
        /// </summary>
        public MeshClient MeshClient;

        /// <summary>
        /// Flag to allow local processing.
        /// </summary>
        public bool DoLocal = false;

        /// <summary>
        /// One time initialization of the page.
        /// </summary>
        public override void Initialize() {

            // Get the device profile or create a new one if necessary.
            ThisDevice = SignedDeviceProfile.GetLocal(Device1, Device1Description);



            if (DoLocal) {
                MeshPortal.Default = new MeshPortalDirect();
                
                // Get the default profile if possible
                MeshClient = new MeshClient(); // default account
                MeshClient.AccountID = AccountID;

                if (MeshClient.Connected) {
                    AccountName = MeshClient.AccountName;
                    Portal = MeshClient.Portal;
                    SignedCurrentProfile = SignedPersonalProfile.GetLocal(MeshClient.UDF);
                    Navigate(Data_SetupComplete);
                    }
                }


            else {

                JPCProvider.LocalLoopback = false;
                var Portal = new MeshPortalRemote();
                MeshPortal.Default = Portal;


                }


            }


        /// <summary>
        /// Attempt to create an account at the specified portal.
        /// </summary>
        /// <param name="Portal"></param>
        /// <param name="Account"></param>
        /// <returns>true if succeeded, false otherwise.</returns>
        public bool TryNewPortalAccount(string Portal, string Account) {
            Portal = (Portal == null) || (Portal == "") ? "prismproof.org" : Portal;


            this.Portal = Portal;
            this.AccountName = Account;

            MeshClient = new MeshClient (Portal);


            var ValidateResponse = MeshClient.Validate(AccountID);

            if (!ValidateResponse.Valid) {
                InvalidInput = ValidateResponse.Reason;
                }

            return ValidateResponse.Valid;
            }


        /// <summary>
        /// Generate a new profile with the requested options. Note that this could be
        /// parallelized very easily by performing time consuming operations (e.g. generating
        /// keys) while the user is answering other questions.
        /// </summary>
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

            MeshClient.CreatePersonalProfile (AccountID, SignedProfile);
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

        /// <summary>
        /// Recover profile from the mesh using the threshold key shares.
        /// </summary>
        /// <param name="Shares">Array containing the necessary shares.</param>
        /// <returns>UDF of the recovered profile (if successful).</returns>
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

        /// <summary>
        /// List of pending connection requests.
        /// </summary>
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


        /// <summary>
        /// Get the account data
        /// </summary>
        /// <param name="Portal"></param>
        /// <param name="Account"></param>
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

        /// <summary>
        /// Post a connection request.
        /// </summary>
        public void PostConnect() {



            // Generate the device profile


            }

        }


    }
