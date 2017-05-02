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

        MeshClient MeshClient;

        MeshCatalog MeshCatalog;

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


        /// <summary>
        /// Create a new personal profile
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Personal(Personal Options) {
            SetReporting(Options.Report, Options.Verbose);

            var Address = Options.Portal.Value;
            Assert.True((Address != null & Address != ""), NoPortalAccount.Throw);

            RegistrationDevice DeviceRegistration;


            // Hack: Should rejig command parsing to return presence or absence of flags.
            
            // Feature: Should allow user to specify if device profile should be the default.

            if (Options.DeviceUDF.Value != null) {
                // Fingerprint specified so must use existing.
                DeviceRegistration = MeshCatalog.GetDevice(Options.DeviceUDF.Value);
                }
            else if (Options.DeviceID.Value == null | Options.DeviceNew.Value) {
                // Either no Device ID specified or the new flag specified so create new.
                var DeviceID = Options.DeviceID.Value ?? "Default";     // Feature: Pull from platform
                var DeviceDescription = Options.DeviceDescription.Value ?? "Unknown";  // Feature: Pull from platform
                DeviceRegistration = MeshCatalog.CreateDevice(DeviceID, DeviceDescription, true);
                }
            else {
                // DeviceID specified without new so look for existing profile.
                DeviceRegistration = MeshCatalog.GetDevice(DeviceID: Options.DeviceID.Value);
                }

            var PersonalProfile = new PersonalProfile(DeviceRegistration.DeviceProfile);

            var Registration = MeshCatalog.CreateAccount(Address, PersonalProfile);

            Report("Created new personal profile {0}", Registration.UDF);
            Report("Profile registered to {0}", Address);

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



        }
    }
