using System;
using System.Collections.Generic;
using System.IO;
using Goedel.Debug;
using Goedel.Protocol;

namespace Goedel.Mesh {

    partial class MeshTest {

        MeshClient MeshClient1;
        MeshClient MeshClient2;
        MeshClient MeshClient3;

        public void MeshStoreAPI() {
            File.Delete(Store);
            File.Delete(Portal);
            MeshPortal.Default = new MeshPortalDirect(Store, Portal);

            MeshClient1 = new MeshClient(Service);
            var valid = MeshClient1.Validate(AccountID);

            var DevProfile = new SignedDeviceProfile(Device1, Device1Description);
            var UserProfile = new PersonalProfile(DevProfile);
            var SignedProfile = UserProfile.Signed;

            MeshClient1.CreatePersonalProfile(AccountID, SignedProfile);

            // Create a password profile
            var PasswordProfile = new PasswordProfile(UserProfile);
            var SignedPasswordProfile = PasswordProfile.Signed;
            SignedProfile = UserProfile.Signed;

            MeshClient1.Publish(SignedPasswordProfile);
            MeshClient1.Publish(SignedProfile);


            MeshClient2 = new MeshClient(Service, AccountID);
            MeshClient2.SignedDeviceProfile = DevProfile;
            var AccountPersonalProfile = MeshClient2.GetPersonalProfile();

            // Read back the password profile and add entry 
            var AccountPasswordProfile = MeshClient2.GetPasswordProfile();
            AccountPasswordProfile.Add(PWDSite, PWDUser, PWDPassword);
            var AccountSignedPassword = AccountPasswordProfile.Signed;



            // Publish updates to both profiles.
            MeshClient2.Publish(AccountSignedPassword);

            // Create a new device profile.
            var DevProfile2 = new SignedDeviceProfile(Device2, Device2Description);

            MeshClient3 = new MeshClient(Service, AccountID);

            MeshClient3.ConnectRequest(DevProfile2);
            var Stat1 = MeshClient2.ConnectStatus(DevProfile2.UniqueID);

            var PendingResponse = MeshClient1.ConnectPending();

            foreach (var Request in PendingResponse.Pending) {
                MeshClient1.ConnectClose(Request, ConnectionStatus.Accepted);
                }

            var Stat2 = MeshClient3.ConnectStatus(DevProfile2.UniqueID);

            var Dev2Password = MeshClient3.GetPasswordProfile();

            }


        }
    }
