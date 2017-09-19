using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Mesh;
using Goedel.Utilities;
using Goedel.Mesh.Platform;



namespace Goedel.Mesh.MeshMan {

    public partial class Shell {

        bool VerboseOutput = true;
        bool ReportOutput = true;

        private void SetReporting(Flag Report, Flag Verbose) {
            ReportOutput = Report.Value;
            VerboseOutput = Verbose.Value;
            }

        public void Verbose(string Text, params object[] Data) {
            if (VerboseOutput & ReportOutput) {
                Console.WriteLine(Text, Data);
                }
            }

        public void ReportWrite(string Text) {
            if (ReportOutput) {
                Console.Write(Text);
                }
            }

        public void Report(string Text, List<string> Items) {
            if (!ReportOutput) return;
            Console.Write(Text);
            foreach (var Item in Items) {
                Console.Write(" ");
                Console.Write(Item);
                }
            Console.WriteLine();
            }

        public void Report(string Text, params object[] Data) {
            if (ReportOutput) {
                Console.WriteLine(Text, Data);
                }
            }

        public void Report(string Text) {
            if (ReportOutput) {
                Console.WriteLine(Text);
                }
            }

        public MeshClient GetMeshClient() {
            return GetMeshClient(PortalID);
            }


        /// <summary>
        /// Bind to the Mesh client for the specified portal account
        /// </summary>
        /// <param name="PortalID"></param>
        /// <returns></returns>
        public MeshClient GetMeshClient(string PortalID) {
            this.PortalID = PortalID;

            Assert.NotNull(PortalID, NoPortalAccount.Throw);
            Account.SplitAccountID(PortalID, out AccountID, out Portal);
            Assert.NotNull(AccountID, InvalidPortalAddress.Throw);
            MeshClient = new MeshClient(Portal);
            Assert.NotNull(MeshClient, PortalConnectFail.Throw);

            return MeshClient;
            }


        /// <summary>
        /// Rough draft, I think this is correct but can't check now 
        /// as the server is accepting everything.
        /// </summary>
        private void GetNextAccount() {

            int Base = 1;
            int Index = 1;

            bool Found = CheckAccount(Index);
            if (Found) {
                AccountID = MakeAccountID(Index);
                return;
                }

            while (!Found) {
                Base = Index;
                Index = Index * 2;
                Found = CheckAccount(Index);
                }
            while (Index > 2) {
                Index = Index / 2;
                Found = CheckAccount(Base + Index);
                if (!Found) {
                    Base = Base + Index;
                    }
                }
            AccountID = MakeAccountID(Base + Index);

            throw new NYI("Generate new identifer if original is taken");

            }

        private string MakeAccountID(int I) {
            return AccountID + "_" + I.ToString("x");
            }

        private bool CheckAccount(int I) {
            //var TestID = MakeAccountID(I);
            var AccountAvailable = MeshClient.Validate(AccountID);
            return AccountAvailable.Valid;
            }


        RegistrationPersonal RegistrationPersonal;
        SignedPersonalProfile SignedPersonalProfile;
        PersonalProfile PersonalProfile;

        private void GetProfile(String Portal, String UDF) {

            RegistrationPersonal = Machine.Personal;
            Assert.NotNull(RegistrationPersonal, NoPersonalProfile.Throw);

            PortalID = RegistrationPersonal?.Portals?[0];
            Assert.NotNull(PortalID, NoPortalAccount.Throw);

            SignedPersonalProfile = RegistrationPersonal.Profile;
            PersonalProfile = SignedPersonalProfile.Signed;

            PersonalProfile.SignedDeviceProfile = GetDevice(SignedPersonalProfile);
            }





        // A placeholder routine. This should actually search
        // the profile to find a matching device profile that
        // is supported on the local machine.
        private SignedDeviceProfile GetDevice(SignedPersonalProfile Profile) {
            return Machine.Device.Device;
            }

        ApplicationProfileEntry PasswordEntry;
        RegistrationApplication PasswordRegistration;
        SignedApplicationProfile SignedApplicationWeb;
        PasswordProfile PasswordProfile;
        PasswordProfilePrivate PasswordProfilePrivate;

        private void GetPasswordProfile () {

            PasswordEntry = SignedPersonalProfile.Signed.GetApplicationEntryPassword(
                null);
            PasswordRegistration = Machine.Get(PasswordEntry);

            SignedApplicationWeb = PasswordRegistration.Profile;
            PasswordProfile = SignedApplicationWeb.Signed as PasswordProfile;
            PasswordProfile.Link (SignedPersonalProfile.Signed, PasswordEntry);
            PasswordProfilePrivate = PasswordProfile.Private;

            return;
            }

        private void UpdatePasswordProfile() {

            var NewSigned = PasswordProfile.Signed;

            PasswordRegistration.Profile = NewSigned;
            PasswordRegistration.Update();
            MeshClient.Publish(PasswordRegistration.Profile);
            return;
            }

        }
    }
