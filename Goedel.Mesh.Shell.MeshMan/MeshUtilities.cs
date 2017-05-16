using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Goedel.Mesh;
using Goedel.Utilities;
using Goedel.Mesh.Platform;



namespace Goedel.Mesh.MeshMan {

    public partial class Shell {

        bool VerboseOutput = false;
        bool ReportOutput = true;
        bool ActiveListener = false;

        private void SetReporting (Goedel.Mesh.MeshMan.IReporting Reporting) {
            SetReporting(Reporting.Report, Reporting.Verbose);
            }

        private void SetReporting (Flag Report, Flag Verbose) {

            // Hack: Should really make the options groups into interfaces 
            // in the Command processor. Then can simply hand in the options.

            ReportOutput = Report.Value;
            VerboseOutput = Verbose.Value;

            if (VerboseOutput & !ActiveListener) {
                Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
                ActiveListener = true;
                }
            }

        public void Verbose (string Text, params object[] Data) {
            if (VerboseOutput & ReportOutput) {
                Console.WriteLine(Text, Data);
                }
            }

        public void ReportWrite (string Text) {
            if (ReportOutput) {
                Console.Write(Text);
                }
            }

        public void Report (string Text, List<string> Items) {
            if (!ReportOutput) {
                return;
                }
            Console.Write(Text);
            foreach (var Item in Items) {
                Console.Write(" ");
                Console.Write(Item);
                }
            Console.WriteLine();
            }

        public void Report (string Text, params object[] Data) {
            if (ReportOutput) {
                Console.WriteLine(Text, Data);
                }
            }

        public void Report (string Text) {
            if (ReportOutput) {
                Console.WriteLine(Text);
                }
            }

        public RegistrationPersonal GetPersonal (IPortalAccount Options) {
            return GetPersonal(Options.Portal.Value);
            }

        public RegistrationPersonal GetPersonal (string Address) {
            var RegistrationPersonal =  MeshCatalog.GetPersonal(Address);

            Assert.NotNull(RegistrationPersonal, ProfileNotFound.Throw,
                new ExceptionData() { String = Address ?? "<default>" });

            return RegistrationPersonal;
            }



        public void Register (RegistrationPersonal RegistrationPersonal,
               ApplicationProfile ApplicationProfile) {


            // Add the application to the personal profile.
            // By default we add all the admin devices for the personal profile to be admin for 
            // the app profile.
            var RegistrationApplication = RegistrationPersonal.Add(ApplicationProfile, false);

            // Add this device to the registration in the personal profile.
            var DeviceProfile = RegistrationPersonal.PersonalProfile.DeviceProfile;
            RegistrationApplication.AddDevice(DeviceProfile, Administration: true);

            RegistrationPersonal.Write();
            RegistrationApplication.Write();
            }


        public MeshClient GetMeshClient() {
            return GetMeshClient(PortalID);
            }


        public void Error (Exception Exception) {
            Console.WriteLine(Exception.Message);

            if (VerboseOutput & Exception.InnerException != null) {
                Error(Exception.InnerException);
                }
            }


        /// <summary>
        /// Bind to the Mesh client for the specified portal account
        /// </summary>
        /// <param name="PortalID"></param>
        /// <returns></returns>
        public MeshClient GetMeshClient(string PortalID) {
            this.PortalID = PortalID;

            Assert.NotNull(PortalID, NoPortalAccount.Throw);
            MeshClient = new MeshClient(PortalAccount: PortalID);
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

            PortalID = RegistrationPersonal?.Portals?.Default;
            Assert.NotNull(PortalID, NoPortalAccount.Throw);

            SignedPersonalProfile = RegistrationPersonal.SignedPersonalProfile;
            PersonalProfile = SignedPersonalProfile.PersonalProfile;

            //PersonalProfile.SignedDeviceProfile = GetDevice(SignedPersonalProfile);
            }


        // A placeholder routine. This should actually search
        // the profile to find a matching device profile that
        // is supported on the local machine.
        private SignedDeviceProfile GetDevice(SignedPersonalProfile Profile) {
            TraceX.TBS("Device not read properly");
            return Machine.Device.SignedDeviceProfile;
            }



        public RegistrationApplication GetApplication (IApplicationProfile Options, string Type) {

             Machine.Find (out var RegistrationApplication, Type,
                    Options.Portal.Value, Options.UDF.Value, Options.ID.Value);

            return RegistrationApplication;

            }



        ////ApplicationProfileEntry PasswordEntry;
        ////RegistrationApplication PasswordRegistration;
        ////SignedApplicationProfile SignedApplicationWeb;
        //PasswordProfile PasswordProfile;
        //PasswordProfilePrivate PasswordProfilePrivate;

        //private void GetPasswordProfile () {

        //    //PasswordEntry = SignedPersonalProfile.PersonalProfile.GetApplicationEntryPassword(
        //    //    null);
        //    //var Found = Machine.Find(PasswordEntry.Identifier, out PasswordRegistration);

        //    //PasswordProfile = PasswordRegistration.ApplicationProfile as PasswordProfile;
        //    //PasswordProfile.Link (SignedPersonalProfile.PersonalProfile, PasswordEntry);
        //    //PasswordProfilePrivate = PasswordProfile.Private;

        //    return;
        //    }

        //private void UpdatePasswordProfile() {

        //    //var NewSigned = PasswordProfile.SignedApplicationProfile;

        //    //PasswordRegistration.SignedApplicationProfile = NewSigned;
        //    //PasswordRegistration.WriteToPortal();
        //    //MeshClient.Publish(PasswordRegistration.SignedApplicationProfile);
        //    return;
        //    }

        }
    }
