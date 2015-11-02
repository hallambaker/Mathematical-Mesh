using System;
using System.Collections.Generic;
using Goedel.Protocol;
using Goedel.Mesh;
using Goedel.Debug;
using Goedel.CryptoLibNG;
using CLG=Goedel.CryptoLibNG;


namespace Goedel.MeshConnect {


    public partial class ConnectProfile {

        public string UDF = "ProfileUDF TBS";

        public string Device1 = "SecondDevice";
        public string Device1Description = "Second profile device";

        public string Account;
        public string Portal;

        public int AccountIndex;

        public SignedDeviceProfile DevProfile;
        public SignedPersonalProfile SignedCurrentProfile;


        public string InvalidInput;

        string Pending = "ConnectPending";

        public SignedDeviceProfile ThisDevice;

        public MeshClient MeshClient;
        public override void Initialize() {
            MeshPortal.Default = new MeshPortalDirect();

            DevProfile = SignedDeviceProfile.GetLocal(Pending);

            // Check to see if we have a pending request
            // if so go to Wait to complete.


            DevProfile = new SignedDeviceProfile(Device1, Device1Description);
            DevProfile.ToRegistry(Pending);
            }


        public string GetAccount (string Portal, string Account) {

            // Attempt to connect to portal and connect to account.

            this.Portal = Portal;
            this.Account = Account;

            MeshClient = new MeshClient(Portal, Account);
            SignedCurrentProfile = MeshClient.GetPersonalProfile();
            if (SignedCurrentProfile == null) return null;
            return SignedCurrentProfile.UDF;
            }


        public bool PostConnect () {
            var Pending = MeshClient.ConnectRequest(DevProfile);
            return true;
            }


        public bool CompleteConnect () {
            var Connected = MeshClient.ConnectStatus(DevProfile.UDF);

            // Success?

            // Pull the profile from the mesh.


            return true;
            }

        }


    }


