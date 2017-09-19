////   Copyright © 2015 by Comodo Group Inc.
////  
////  Permission is hereby granted, free of charge, to any person obtaining a copy
////  of this software and associated documentation files (the "Software"), to deal
////  in the Software without restriction, including without limitation the rights
////  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
////  copies of the Software, and to permit persons to whom the Software is
////  furnished to do so, subject to the following conditions:
////  
////  The above copyright notice and this permission notice shall be included in
////  all copies or substantial portions of the Software.
////  
////  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
////  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
////  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
////  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
////  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
////  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
////  THE SOFTWARE.
////  
////  

//using System;
//using System.Collections.Generic;
//using System.IO;
//using Goedel.Protocol;

//// TODO: Create SSH key files
//// TODO: Create Mesh/Remesh key files
//// TODO: Create Escrow data
//// TODO: Recover escrow data
//// TODO: create SSH, SMIME escrow data
//// TODO: Recover SSH, SMIME escrow data


//namespace Goedel.Mesh {

//    partial class MeshTest {

//        public bool DoLocal = false;

//        MeshClient MeshClient1;
//        MeshClient MeshClient2;
//        MeshClient MeshClient3;

//        public void MeshStoreAPI() {

//            if (DoLocal) {
//                File.Delete(Store);
//                File.Delete(Portal);
//                MeshPortal.Default = new MeshPortalDirect(Store, Portal);
//                }
//            else {
//                JPCProvider.LocalLoopback = false;
//                var Portal = new MeshPortalRemote();
//                MeshPortal.Default = Portal;
//                }


//            MeshClient1 = new MeshClient(PortalAccount: Service);
//            var valid = MeshClient1.Validate(AccountID);
//            if (!valid.Status.StatusSuccess()) {
//                Console.WriteLine("Validate failed");
//                }

//            var DevProfile = new DeviceProfile(Device1, Device1Description);
//            var UserProfile = new PersonalProfile(DevProfile);
//            var SignedProfile = UserProfile.SignedPersonalProfile;

//            MeshClient1.CreatePortalAccount(AccountID, SignedProfile);

//            // Create a password profile
//            //var PasswordProfile = new PasswordProfile(UserProfile);
//            //var SignedPasswordProfile = PasswordProfile.Signed;
//            //SignedProfile = UserProfile.Signed;

//            //MeshClient1.Publish(SignedPasswordProfile);
//            //MeshClient1.Publish(SignedProfile);


//            MeshClient2 = new MeshClient(PortalAccount: AccountID) {
//                SignedDeviceProfile = DevProfile.SignedDeviceProfile,
//                };
//            MeshClient2.GetPersonalProfile();
//            // Read back the password profile and add entry 
//            var AccountPasswordProfile = MeshClient2.GetPasswordProfile();
//            AccountPasswordProfile.Add(PWDSite, PWDUser, PWDPassword);
//            var AccountSignedPassword = AccountPasswordProfile.SignedApplicationProfile;



//            // Publish updates to both profiles.
//            MeshClient2.Publish(AccountSignedPassword);

//            // Create a new device profile.
//            var DevProfile2 = new SignedDeviceProfile(Device2, Device2Description);

//            MeshClient3 = new MeshClient(PortalAccount: AccountID);

//            MeshClient3.ConnectRequest(DevProfile2);
//            MeshClient2.ConnectStatus(DevProfile2.UniqueID);

//            var PendingResponse = MeshClient1.ConnectPending();

//            foreach (var Request in PendingResponse.Pending) {
//                MeshClient1.ConnectClose(Request, ConnectionStatus.Accepted);
//                }

//            MeshClient3.ConnectStatus(DevProfile2.UniqueID);

//            MeshClient3.GetPasswordProfile();

//            }


//        }
//    }
