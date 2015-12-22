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
using Goedel.Protocol;
using Goedel.Mesh;
using Goedel.Debug;
using Goedel.LibCrypto;
using CLG=Goedel.LibCrypto;

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

            MeshClient = new MeshClient(Portal);


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
                MeshClient.Publish(PasswordProfile.Signed);
                }

            if (ConfigureNetwork) {
                var NetworkProfile = new NetworkProfile(UserProfile);
                NetworkProfile.AddDevice(ThisDevice);
                MeshClient.Publish(NetworkProfile.Signed);
                }

            if (ConfigureEmail) {
                foreach (var MailAccountInfo in MailAccountInfos) {
                    // Add in the S/MIME parameters and update the profile
                    //if (!MailAccountInfo.GotSMIME) {
                        MailAccountInfo.GenerateSMIME();
                        MailAccountInfo.Update();
                        //}

                    var MailProfile = new MailProfile(UserProfile, MailAccountInfo);
                    MailProfile.AddDevice(ThisDevice);

                    //var SignedMailProfile = new SignedApplicationProfile(MailProfile);
                    MeshClient.Publish(MailProfile.Signed);
                    }
                }

            if (ConfigureRecovery) {
                MakeCheckRecovery();
                }

            // publish to the cloud
            var SignedProfile = new SignedPersonalProfile(UserProfile);
            SignedProfile.ToRegistry();

            MeshClient.CreatePersonalProfile(AccountID, SignedProfile);
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
        public string RecoverProfile(string[] Shares) {

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
        public bool CheckPending() {
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

        /// <summary>
        /// Reject the connection request
        /// </summary>
        public bool RejectConnection() {

            var CurrentRequest = PendingConnectionRequests[0];
            MeshClient.ConnectClose(CurrentRequest, ConnectionStatus.Rejected);

            return true;
            }


        /// <summary>
        /// Accept the connection request
        /// </summary>
        public bool AcceptConnection() {

            // Get the connection request
            var CurrentRequest = PendingConnectionRequests[0];
            var RequestData = CurrentRequest.Data;

            // Extract the device profile
            var DeviceProfile = RequestData.Device;

            //// Validate the device profile
            //var SignedPersonalProfile = MeshClient.GetPersonalProfile();

            //// Add device profile to personal profile

            //var UserProfile = SignedPersonalProfile.Signed;
            
            UserProfile.Add(DeviceProfile);
            UserProfile.SignedDeviceProfile = ThisDevice;

            foreach (var Entry in UserProfile.Applications) {
                AddDevice(Entry, UserProfile, DeviceProfile);
                }
            // Sign personal profile
            var SignedProfile = new SignedPersonalProfile(UserProfile);
            SignedProfile.ToRegistry();

            // Send client the personal profile update
            MeshClient.Publish(SignedProfile);

            // Send client the connection result
            MeshClient.ConnectClose(CurrentRequest, ConnectionStatus.Accepted);


            return true;
            }

        /// <summary>
        /// Add a device to an application profile 
        /// </summary>
        /// <param name="Entry">Applicationprofile entry to update</param>
        /// <param name="PersonalProfile">Personal profile to link to</param>
        /// <param name="Device">Signed device profile.</param>
        public void AddDevice(ApplicationProfileEntry Entry, 
                    PersonalProfile PersonalProfile,
                SignedDeviceProfile Device) {

            // Add an entry into the application profile
            // This is not required for profile maintenance but 
            // is needed for navigation (it seems.
            //Entry.ApplicationProfile.AddDevice(Device);

            // Add entries into the application profile entry
            // This sets up the permissions.

            Entry.AddDevice(Device);

            var SignedAppProfile = MeshClient.GetApplicationProfile(Entry.Identifier);
            if (SignedAppProfile == null) return;

            var AppProfile = SignedAppProfile.Signed;
            AppProfile.Link(PersonalProfile);
            AppProfile.EncryptPrivate();
            var NewSignedAppProfile = new SignedApplicationProfile(AppProfile);
            MeshClient.Publish(NewSignedAppProfile);
            }
        }


    }
