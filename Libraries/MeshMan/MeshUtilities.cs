using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Goedel.Mesh;
using Goedel.Utilities;
using Goedel.Mesh.Platform;
using Goedel.Mesh.Portal;
using Goedel.Mesh.Portal.Client;
using Goedel.Protocol;

namespace Goedel.Mesh.MeshMan {

    public partial class Shell {

        protected bool VerboseOutput = false;
        protected bool ReportOutput = true;
        protected bool ActiveListener = false;


        private void SetReporting(Goedel.Mesh.MeshMan.IReporting Reporting) => SetReporting(Reporting.Report, Reporting.Verbose);

        private void SetReporting (Flag Report, Flag Verbose) {
            ReportOutput = Report.Value;
            VerboseOutput = Verbose.Value;

            if (VerboseOutput & !ActiveListener) {
                //Debug.Listeners.Add(new TextWriterTraceListener(Console.Out)); 
                // TODO: Fix listeners
                ActiveListener = true;
                }
            }

        public void Verbose (string Text, params object[] Data) {
            if (VerboseOutput & ReportOutput) {
                Console.WriteLine(Text, Data);
                }
            }

        public virtual void ReportWrite (string Text) {
            if (ReportOutput) {
                Console.Write(Text);
                }
            }

        public virtual void ReportWriteLine (string Text, params object[] Data) {
            if (ReportOutput) {
                Console.WriteLine(Text, Data);
                }
            }

        public void Report (string Text, List<string> Items) {
            if (!ReportOutput) {
                return;
                }
            ReportWrite(Text);
            foreach (var Item in Items) {
                ReportWrite(" ");
                ReportWrite(Item);
                }
            ReportWriteLine("");
            }


        public JSONObject LastResult;


        public SessionDevice GetDevice (IDeviceProfileInfo Options) {
            // Feature: Should allow user to specify if device profile should be the default.

            if (!Options.DeviceUDF.ByDefault) {
                // Fingerprint specified so must use existing.
                return MeshMachine.GetDevice(Options.DeviceUDF.Value);
                }
            if (Options.DeviceID.ByDefault | Options.DeviceNew.Value) {
                // Either no Device ID specified or the new flag specified so create new.
                var DeviceID = Options.DeviceID.Value ?? "Default";     // Feature: Pull from platform
                var DeviceDescription = Options.DeviceDescription.Value ?? "Unknown";  // Feature: Pull from platform
                return MeshMachine.CreateDevice(DeviceID, DeviceDescription, true);
                }
            // DeviceID specified without new so look for existing profile.
            return MeshMachine.GetDevice(DeviceID: Options.DeviceID.Value);
            }

        public SessionPersonal GetPersonal(IPortalAccount Options) => GetPersonal(Options.Portal.Value);

        public SessionPersonal GetPersonal (string Address) {
            var SessionPersonal = MeshMachine.GetPersonal(Address);

            Assert.NotNull(SessionPersonal, ProfileNotFound.Throw,
                new ExceptionData() { String = Address ?? "<default>" });

            return SessionPersonal;
            }



        //public SessionApplication Register (SessionPersonal RegistrationPersonal,
        //       ApplicationProfile ApplicationProfile) {


        //    // Add the application to the personal profile.
        //    // By default we add all the admin devices for the personal profile to be admin for 
        //    // the app profile.
        //    var RegistrationApplication = RegistrationPersonal.Add(ApplicationProfile, false);

        //    // Add this device to the registration in the personal profile.
        //    var DeviceProfile = RegistrationPersonal.PersonalProfile.DeviceProfile;
        //    RegistrationApplication.AddDevice(DeviceProfile, Administration: true);
        //    RegistrationPersonal.Write();
        //    RegistrationApplication.Write();

        //    return RegistrationApplication;
        //    }


        public MeshClient GetMeshClient() => GetMeshClient(PortalID);


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

        private string MakeAccountID(int I) => AccountID + "_" + I.ToString("x");

        private bool CheckAccount(int I) {
            //var TestID = MakeAccountID(I);
            var AccountAvailable = MeshClient.Validate(AccountID);
            return AccountAvailable.Valid;
            }

        SessionPersonal RegistrationPersonal;
        PersonalProfile PersonalProfile;

        private void GetProfile(String Portal, String UDF) {
            RegistrationPersonal = MeshMachine.Personal;
            Assert.NotNull(RegistrationPersonal, NoPersonalProfile.Throw);

            PortalID = RegistrationPersonal?.Portals?.Default;
            Assert.NotNull(PortalID, NoPortalAccount.Throw);

            PersonalProfile = RegistrationPersonal.PersonalProfile;
            }

        public SessionApplication GetApplication (IPortalAccount Options, string Type) {
            MeshMachine.Find (out var RegistrationApplication, Type,
                    Options.Portal.Value, Options.UDF.Value, Options.ID.Value);

            //this.RegistrationApplication = RegistrationApplication;
            //PasswordProfile = RegistrationApplication?.ApplicationProfile as PasswordProfile;

            RegistrationPersonal = MeshMachine.Personal;
            PortalID = RegistrationPersonal?.Portals?.Default;
            PersonalProfile = RegistrationPersonal?.PersonalProfile;
            return RegistrationApplication;
            }

        }
    }
