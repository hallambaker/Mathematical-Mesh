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
using System.IO;
using System.Net;
using Goedel.Mesh.Platform;
using Goedel.Mesh.Platform.Windows;
using Goedel.Cryptography;
using Goedel.Cryptography.KeyFile;

namespace Goedel.Mesh {
    class Program {
        static void Main(string[] args) {
            Goedel.Platform.Framework.Platform.Initialize();
            Goedel.Cryptography.Framework.Cryptography.Initialize();
            Goedel.Mesh.Platform.Windows.Platform.Initialize();

            var MeshTest = new MeshTest();
            MeshTest.Gateway();


            }
        }


    partial class ParseSSH  {

        public ParseSSH () {

            //var KeyPair = KeyFile.DecodePEM("PrivateKey.OpenSSH");

            KeyFile.DecodeAuthHost("authorized_keys.pub");


            //var NewKeyPair = new RSAKeyPair (2048, true);
            //var ReEncode = KeyPair.ToPEM();

            //Console.Write(ReEncode);

            //var KeyPair2 = KeyFile.DecodePEMText(ReEncode);

            }

 

        }




    partial class MeshTest {
        public static string UserName = "Alice";
        public static string Service = "prismproof.org";

        public readonly string AccountID = Account.ID(UserName, Service);


        public string Device1 = "Voodoo";
        public string Device1Description = "Windows Desktop";

        public string App1 = "Password";
        public string App2 = "Mail";

        public string MailAccount = "alice@example.com";

        public static List<string> STARTTLS = new List<string> { "STARTTLS" };
        public static List<string> TLS = new List<string>  { "TLS" };
        public Connection ConnectionSubmit = new Connection(
            "smtp.example.com", 587, "_submission._tcp", STARTTLS);
        public Connection ConnectionIMAP = new Connection(
            "imap.example.com", 993, "_imap4._tcp", TLS);

        public string Device2 = "Phone";
        public string Device2Description = "Apple iPhone";

        public string Device3 = "Watch";
        public string Device3Description = "Android Watch";

        public string PWDSite = "www.example.com";
        public string PWDUser = "Alice";
        public string PWDPassword = "Secret1";

        //public string PWDUserResult, PWDPasswordResult;

        public Connection DNS1 = new Connection(
            "10.10.10.10", 53, "_dns._udp", null);
        public Connection DNS2 = new Connection(
            "10.10.5.5", 53, "_dns._udp", null);

        public int shares = 5;
        public int quorum = 3;

        public Mesh Mesh;
        //public PublicMeshServiceHost MeshServiceHost;
        //public JPCSession Session;
        //public MeshService MeshService;

        public string Store = "Tmesh.jlog";
        public string Portal = "Tportal.jlog";

        MeshCatalog MeshCatalog;
        public MeshTest() {

            MeshCatalog = new MeshCatalog();


            }

        /// <summary>
        /// The Mesh gateway
        /// </summary>
        public void Gateway () {

            var Registration = MeshCatalog.AddPersonal(AccountID, DeviceNew:true,
                DeviceID: Device1, DeviceDescription: Device1Description);

            var SignedPersonalProfile = Registration.Profile;
            //var ProfileDevice = Registration.Device.UDF;
            var PortalID = Registration.Portals.Default;

            Console.WriteLine("Created new personal profile {0}", SignedPersonalProfile.UDF);
            //Report("Device profile is {0}", ProfileDevice);
            Console.WriteLine("Profile registered to {0}", PortalID);
            }




        public void TestRegistry() {
            //RegistrationMachine.Erase();

            //var MeshAddress = "Testing@wherever";

            //var Machine = RegistrationMachine.Current;
            //var NewProfileDevice = new SignedDeviceProfile("Test", "Test Device");
            //Machine.Add(NewProfileDevice);

            //var PersonalProfile = new PersonalProfile(NewProfileDevice);
            //var SignedPersonalProfile = PersonalProfile.Signed;

            //Machine.Add(SignedPersonalProfile, MeshAddress);

            }



        public void TestLiveMail () {

            // Create test Mesh
            File.Delete(Store);
            File.Delete(Portal);
            Mesh = new Mesh(Service, Store, Portal);

            // Create Master Profile

            Mesh.CheckAccount(AccountID);
            var DevProfile = new SignedDeviceProfile(Device1, Device1Description);
            var UserProfile = new PersonalProfile(DevProfile);

            var SignedProfile = UserProfile.Signed;
            Mesh.CreateAccount(UserName, SignedProfile);

            Mesh.GetAccount(UserName);


            // Read the LiveMail accounts

            var MailClientCatalog = new MailClientCatalogPlatform();
            MailClientCatalog.ImportWindowsLiveMail();
            MailClientCatalog.Dump();

            var MailAccount = MailClientCatalog.Accounts[0];
            // Add self signed certs if they don't have them already
            MailAccount.GenerateSMIME();

            // Write out the updated profile
            MailAccount.Update();

            //// Create Mail Profile
            //var MailProfile = new MailProfile(UserProfile, MailAccount);


            // Create Test Account from Mail Profile

            var NewMailInfo = new MailAccountInfoWLM();
            //MailProfile.Export(NewMailInfo);
            NewMailInfo.AccountName = "Test-Delete";

            // Write it out
            NewMailInfo.Create();

            }





        public void TestMail() {

            var MailClientCatalog = new MailClientCatalogPlatform();
            MailClientCatalog.ImportWindowsLiveMail();
            MailClientCatalog.Dump();


            var MailAccountInfo = new MailAccountInfoWLM();

            var TestName = "test-";

            MailAccountInfo.EmailAddress = TestName + "@example.com";
            MailAccountInfo.DisplayName = TestName + "- Delete";
            MailAccountInfo.AccountName = TestName;

            MailAccountInfo.Out = new Connection(
                    "smtp.example.com", 465, AppProtocol.SUBMIT, TestName, null, 
                    TLSMode.Upgrade, true);
            MailAccountInfo.In = new Connection(
                    "imap.example.com", 993, AppProtocol.IMAP4, TestName, null, 
                    TLSMode.Direct, true);

            // Dump out the data on the new account.
            MailAccountInfo.Dump ();

            MailAccountInfo.Create();

            var MailClientCatalog2 = new MailClientCatalogPlatform();
            MailClientCatalog2.ImportWindowsLiveMail();
            MailClientCatalog2.Dump();
            }




        public void Do() {
            MeshStoreAPI();

            }

        public void MeshStorem() {
            File.Delete(Store);
            File.Delete(Portal);
            Mesh = new Mesh(Service, Store, Portal);
            Mesh.CheckAccount(AccountID);

            var DevProfile = new SignedDeviceProfile(Device1, Device1Description);
            var UserProfile = new PersonalProfile(DevProfile);

            var SignedProfile = UserProfile.Signed;
            Mesh.CreateAccount(UserName, SignedProfile);

            Mesh.GetAccount(UserName);

            var PasswordProfile = new PasswordProfile(true);
            var SignedPasswordProfile = PasswordProfile.Signed;

            SignedProfile = UserProfile.Signed;
            Mesh.AddProfile(SignedPasswordProfile);
            Mesh.UpdateProfile(SignedProfile);





            }


        public void MeshStore () {

            File.Delete(Store);
            File.Delete(Portal);
            Mesh = new Mesh(Service, Store, Portal);

            Mesh.CheckAccount(AccountID);

            var DevProfile = new SignedDeviceProfile(Device1, Device1Description);
            var UserProfile = new PersonalProfile(DevProfile);

            var SignedProfile = UserProfile.Signed;
            Mesh.CreateAccount(AccountID, SignedProfile);

            // Add the device to the profile entry in the parent.

            var PasswordProfile = new PasswordProfile(true);

            var SignedPasswordProfile = PasswordProfile.Signed;

            SignedProfile = UserProfile.Signed;
            Mesh.AddProfile(SignedPasswordProfile); 
            Mesh.UpdateProfile(SignedProfile);

            // ok now pull the profile as a client.

            var Account = Mesh.GetAccount(AccountID); 
            var AccountPersonalProfile = Mesh.GetPersonalProfile(Account.UserProfileUDF);
            AccountPersonalProfile.SignedDeviceProfile = DevProfile;

            var PasswordEntry = AccountPersonalProfile.GetPasswordProfile();
            var SignedPasswordProfile2 = 
                Mesh.GetProfile(PasswordEntry.Identifier) as SignedProfile;

            var AccountPasswordProfile = PasswordProfile.Get(
                            SignedPasswordProfile2, AccountPersonalProfile);
            AccountPasswordProfile.Add(PWDSite, PWDUser, PWDPassword);

            // Implement the second way to do things, cleaner.
            //var AccountSignedPassword = new SignedPasswordProfile(AccountPasswordProfile);
            var AccountSignedPassword = AccountPasswordProfile.Signed;
            Mesh.UpdateProfile(AccountSignedPassword);

            // Now add a new device

            var DevProfile2 = new SignedDeviceProfile(Device2, Device2Description);

            // Post Connect Request
            Mesh.GetChainToken();
            var ConnectionRequest = new ConnectionRequest(Account, DevProfile2);

            Mesh.PostConnectionRequest(ConnectionRequest.Signed, 
                Account.UniqueID);

            // Get list of pending requests
            Mesh.GetPendingRequests(Account.AccountID);

            // Accept pending request


            var ConnectionResult = new ConnectionResult();
            ConnectionResult.Result = "Accept";
            ConnectionResult.Device = DevProfile2;
            var SignedConnectionResult = new SignedConnectionResult(ConnectionResult,
                AccountPersonalProfile.GetAdministrationKey());
            Mesh.CloseConnectionRequest(Account.AccountID, SignedConnectionResult);


            // Pull password data 
            Mesh.GetRequestStatus(Account.AccountID, DevProfile2.UDF);


            // decrypt using device2 credential
            var SignedPasswordProfile3 = 
                Mesh.GetProfile(PasswordEntry.Identifier) as SignedProfile;
            var PP3 = PasswordProfile.Get(SignedPasswordProfile3, AccountPersonalProfile);
            var PasswordPrivate = PP3.Private;


            }


        }
    }
