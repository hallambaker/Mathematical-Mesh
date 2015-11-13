using System;
using System.Collections.Generic;
using Goedel.Protocol;
using Goedel.Mesh;
using Goedel.Debug;
using Goedel.CryptoLibNG;
using CLG=Goedel.CryptoLibNG;


namespace Goedel.MeshConnect {


    public partial class ConnectProfile {

        /// <summary>
        /// Placeholder for device fingerprint.
        /// </summary>
        public string UDF = "ProfileUDF TBS";

        /// <summary>
        /// Placeholder for device name.
        /// </summary>
        public string Device1 = "SecondDevice";

        /// <summary>
        /// Placeholder for device description
        /// </summary>
        public string Device1Description = "Second profile device";

        /// <summary>
        /// Account name to connect to
        /// </summary>
        public string AccountName;

        /// <summary>
        /// Mesh portal to connect to
        /// </summary>
        public string Portal;

        /// <summary>
        /// Account Identifier, is [AccountName]@[Portal]
        /// </summary>
        public string AccountID {
            get { return Account.ID(AccountName, Portal); }
            }

        /// <summary>
        /// The device profile
        /// </summary>
        public SignedDeviceProfile DevProfile;

        /// <summary>
        /// The personal profile
        /// </summary>
        public SignedPersonalProfile SignedPersonalProfile;

        /// <summary>
        /// Reporting string used to inform user input is invalid.
        /// </summary>
        public string InvalidInput;

        /// <summary>
        /// Registry location for pending requests.
        /// </summary>
        string Pending = "ConnectPending";


        /// <summary>
        /// Flag to allow local processing.
        /// </summary>
        public bool DoLocal = false;

        /// <summary>
        /// The mesh client
        /// </summary>
        public MeshClient MeshClient;

        /// <summary>
        /// Initialize the class, called once when dialog is created.
        /// </summary>
        public override void Initialize() {

            if (DoLocal) {
                MeshPortal.Default = new MeshPortalDirect();
                }

            else {
                JPCProvider.LocalLoopback = false;
                var Portal = new MeshPortalRemote();
                MeshPortal.Default = Portal;
                }


            //DevProfile = SignedDeviceProfile.GetLocal(Pending);

            if (DevProfile == null) {
                DevProfile = new SignedDeviceProfile(Device1, Device1Description);
                DevProfile.ToRegistry(Pending);
                }

            }

        /// <summary>
        /// Create a MeshClient for the specified portal and request the specified 
        /// account.
        /// </summary>
        /// <param name="Portal">Mesh Portal.</param>
        /// <param name="Account">Mesh Account.</param>
        /// <returns>UDF of the personal profile.</returns>
        public string GetAccount (string Portal, string Account) {

            // Attempt to connect to portal and connect to account.

            this.Portal = Portal;
            this.AccountName = Account;

            MeshClient = new MeshClient(Portal, AccountID);
            SignedPersonalProfile = MeshClient.GetPersonalProfile();
            if (SignedPersonalProfile == null) return null;
            return SignedPersonalProfile.UDF;
            }

        /// <summary>
        /// Post the connection request
        /// </summary>
        /// <returns></returns>
        public bool PostConnect () {
            var Pending = MeshClient.ConnectRequest(DevProfile);
            return true;
            }

        /// <summary>
        /// Attempt to complete the connection
        /// </summary>
        /// <returns></returns>
        public bool CompleteConnect () {
            var Connected = MeshClient.ConnectStatus(DevProfile.UDF);

            // Success?

            // Pull the profile from the mesh.


            return true;
            }

        }


    }


