using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Goedel.Utilities;
using Goedel.Protocol;
using Goedel.Mesh;
using Goedel.Mesh.Platform;
using Goedel.Mesh.Server;

namespace Goedel.Mesh.MeshMan {

    public partial class Shell {

        public List<ConnectionRequest> PendingRequests;
        RegistrationMachine Machine {
            get => MeshCatalog.Machine;
            }

        string PortalID;
        string AccountID;

        public MeshClient MeshClient;

        public MeshCatalog MeshCatalog;

        public Shell () {
            MeshCatalog = new MeshCatalog();
            }


        /// <summary>
        /// Erase all test profiles
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Reset (Reset Options) {
            MeshCatalog.EraseTest();
            }


        /// <summary>
        /// Create a new device profile
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Device (Device Options) {
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
        public override void Deregister (Deregister Options) {



                SetReporting(Options.Report, Options.Verbose);
                var Address = Options.Portal.Value;
                Assert.True((Address != null & Address != ""), NoPortalAccount.Throw);

                var ProfileRegistration = MeshCatalog.GetPersonal(Address, Portal: false);
                Assert.NotNull(ProfileRegistration, ProfileNotFound.Throw);

                ProfileRegistration.Delete();



            }


        /// <summary>
        /// Create a new personal profile
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Verify (Verify Options) {
            SetReporting(Options.Report, Options.Verbose);
            try {
                var Address = Options.Portal.Value;
                Assert.True((Address != null & Address != ""), NoPortalAccount.Throw);

                var Response = MeshCatalog.Validate(Address);

                if (Response.Valid) {
                    Report("Accepted: {0}", Address);
                    }
                else {
                    if (Response.StatusDescription == null) {
                        Report("Refused {0}", Address);
                        }
                    else {
                        Report("Refused {0} because {1}", Address, Response.StatusDescription);
                        }
                    }
                }
            catch (Exception Exception) {
                Error(Exception);
                }
            }



        }
    }
