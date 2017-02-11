using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Goedel.Utilities;
using Goedel.Protocol;
using Goedel.Mesh;
using Goedel.Mesh.Platform;

namespace Goedel.Mesh.MeshMan {

    public partial class Shell {

        static RegistrationMachine _Machine = null;
        static RegistrationMachine Machine {
            get {
                if (_Machine == null) {
                    _Machine = RegistrationMachine.Current;
                    }
                return _Machine; }
            }

        string PortalID;
        string AccountID;
        string Portal;
        MeshClient MeshClient;

        MeshCatalog MeshCatalog;

        public Shell() {
            MeshCatalog = new MeshCatalog();
            }


        /// <summary>
        /// Erase all test profiles
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Reset(Reset Options) {
            MeshCatalog.EraseTest();
            }


        /// <summary>
        /// Create a new device profile
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Device(Device Options) {
            var DeviceID = Options.DeviceID.Value ?? "Default";
            var DeviceDescription = Options.DeviceDescription.Value ?? "Unknown";
            bool? Default = Options.Default.Value;

            MeshCatalog.CreateDevice(DeviceID, DeviceDescription, Default);

            //var ProfileDevice = new SignedDeviceProfile(DeviceID, DeviceDescription);
            //var RegistrationDevice = Machine.Add(ProfileDevice);

            //if (Options.Default.Value) {
            //    Machine.Device = RegistrationDevice;
            //    }


            }


        /// <summary>
        /// Create a new personal profile
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Personal(Personal Options) {
            SetReporting(Options.Report, Options.Verbose);

            var Address = Options.Portal.Value;
            Assert.True((Address != null & Address != ""), NoPortalAccount.Throw);

            var Registration = MeshCatalog.AddPersonal(
                Options.Portal.Value,
                Options.DeviceNew.Value,
                Options.DeviceUDF.Value,
                Options.DeviceID.Value,
                Options.DeviceDescription.Value
                );



            //// See if the portal exists and will accept the specified account name.
            //GetMeshClient(Address);
            //var AccountAvailable = MeshClient.Validate(AccountID);

            //if (!AccountAvailable.Valid) {
            //    if (Options.Next.Value) {
            //        GetNextAccount();
            //        }
            //    else {
            //        throw new PortalRefusedRequest();
            //        //Utils.Error("Portal refused account {0} because {1}",
            //        //    Address, AccountAvailable.Reason);
            //        }
            //    }

            //// Get / create the device profile if required
            //RegistrationDevice RegistrationDevice = null;
            //bool Generate = false;
            //if (Options.DeviceNew.Value) {
            //    Generate = true;
            //    }
            //else if (Options.DeviceUDF.Value != null) {
            //    // use the profile with the specified fingerprint
            //    var Found = Machine.Find(Options.DeviceUDF.Value, out RegistrationDevice);
            //    Assert.NotNull(Found, ProfileNotFound.Throw);
            //    //"Could not find profile " + Options.DeviceID.Value);
            //    }
            //else if (Options.DeviceID.Value != null) {
            //    // use the profile with the specified ID
            //    var Found = Machine.Find(Options.DeviceID.Value, out RegistrationDevice);
            //    Assert.NotNull(Found, ProfileNotFound.Throw);
            //        //"Could not find profile " + Options.DeviceID.Value);
            //    }
            //else if (Machine.Device != null) {
            //    RegistrationDevice = Machine.Device;
            //    }
            //else {
            //    Generate = true;
            //    }

            //// Generate a new device profile
            //if (Generate) {
            //    var DeviceID = Options.DeviceID.Value ?? "Default";
            //    var DeviceDescription = Options.DeviceDescription.Value ?? "Unknown";

            //    var NewProfileDevice = new SignedDeviceProfile(DeviceID, DeviceDescription);
            //    RegistrationDevice = Machine.Add(NewProfileDevice);
            //    }

            //if (Machine.Device == null) {
            //    Machine.Device = RegistrationDevice;
            //    }


            //var ProfileDevice = RegistrationDevice.Profile;

            //var PersonalProfile = new PersonalProfile(ProfileDevice);
            //var SignedPersonalProfile = PersonalProfile.Signed;

            //// add to the machine registry
            //Machine.Add(SignedPersonalProfile, PortalID);

            //// Register with the Mesh portal
            //var PublishResult = MeshClient.Publish(SignedPersonalProfile);
            //Assert.True(PublishResult.Status.StatusSuccess(), PublicationRequestRefused.Throw);

            var SignedPersonalProfile = Registration.SignedPersonalProfile;
            //var ProfileDevice = Registration.Device.UDF;
            var PortalID = Registration.Portals.Default;

            Report("Created new personal profile {0}", SignedPersonalProfile.UDF);
            //Report("Device profile is {0}", ProfileDevice);
            Report("Profile registered to {0}", PortalID);

            }


        /// <summary>
        /// Report the profiles registered to the current machine.
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void List(List Options) {
            SetReporting(Options.Report, Options.Verbose);

            Report("Personal Profiles");
            foreach (var Registration in Machine.PersonalProfilesUDF) {
                Report(Registration.Value, false);
                }
            Report("Device Profiles");
            foreach (var Registration in Machine.DeviceProfiles) {
                Report(Registration.Value);
                }
            Report("Application Profiles");
            foreach (var Registration in Machine.ApplicationProfiles) {
                Report(Registration.Value);
                }
            }

        void Report(RegistrationPersonal Registration, bool Detail) {
            var SignedPersonalProfile = Registration.SignedPersonalProfile;
            var PersonalProfile = SignedPersonalProfile.PersonalProfile;

            var Identifier = PersonalProfile.Identifier ?? "<null>";
            var Updated = PersonalProfile.Updated.ToString() ?? "<null>";
            var UDF = PersonalProfile.UDF ?? "<null>";


            Report("Profile {0}", Identifier);
            Report("    UDF : {0}", UDF);
            Report("    Updated : {0}", Updated);

            ReportWrite("    PortalIDs :");
            foreach (var Portal in Registration.Portals) {
                ReportWrite(" ");
                ReportWrite(Portal);
                }
            Report("");

            if (!Detail) return;

            Report("Devices");
            foreach (var Device in PersonalProfile.Devices) {
                Report(Device);
                }

            Report("Applications");
            foreach (var ApplicationProfileEntry in PersonalProfile.Applications) {
                Report("    Type {0}, Friendly {1}", ApplicationProfileEntry.Type,
                        ApplicationProfileEntry.Friendly);
                Report("    Identifier: {0}", ApplicationProfileEntry.Identifier);
                Report("        Sign IDs: ", ApplicationProfileEntry.SignID);
                Report("        Decrypt IDs: ", ApplicationProfileEntry.DecryptID);
                }

            }

        void Report(RegistrationApplication Registration) {
            Report(Registration.SignedApplicationProfile);
            }

        void Report(SignedApplicationProfile Application) {
            Report("Profile {0}", Application.UDF);
            }

        void Report(RegistrationDevice Registration) {
            Report(Registration.SignedDeviceProfile);
            }

        void Report(SignedDeviceProfile Device) {
            Report("Profile {0}", Device.UDF);
            }

        /// <summary>
        /// Write out the current personal profile
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Dump(Dump Options) {
            SetReporting(Options.Report, Options.Verbose);
            GetProfile(Options.Portal, Options.UDF);

            Report(RegistrationPersonal, true);
            }

        /// <summary>
        /// List pending connection requests
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Pending(Pending Options) {
            SetReporting(Options.Report, Options.Verbose);
            GetProfile(Options.Portal, Options.UDF);
            GetMeshClient();

            throw new NYI();
            }

        /// <summary>
        /// Accept a connection request
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Accept(Accept Options) {
            SetReporting(Options.Report, Options.Verbose);
            GetProfile(Options.Portal, Options.UDF);
            GetMeshClient();

            throw new NYI();
            }

        /// <summary>
        /// Complete processing of a connection request
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Complete(Complete Options) {
            SetReporting(Options.Report, Options.Verbose);
            GetProfile(Options.Portal, Options.UDF);
            GetMeshClient();

            throw new NYI();
            }

        /// <summary>


        }
    }
