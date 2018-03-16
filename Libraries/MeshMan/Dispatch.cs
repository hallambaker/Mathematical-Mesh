using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Goedel.Utilities;
using Goedel.Command;
using Goedel.Protocol;
using Goedel.Mesh;
using Goedel.Mesh.Platform;
using Goedel.Mesh.Portal.Client;

namespace Goedel.Mesh.MeshMan {

    public partial class Shell {

        public List<ConnectionRequest> PendingRequests;
        MeshMachine Machine=> MeshSession.Machine;


        string PortalID;
        string AccountID;

        public MeshClient MeshClient;

        public MeshSession MeshSession;
        CommandLineInterpreter CommandLineInterpreter = new CommandLineInterpreter();

        public string DefaultID {
            get => _PersonalCreate._DescribeCommand.GetDefault("did");
            set => _PersonalCreate._DescribeCommand.SetDefault("did", value);
            }
        public string DefaultDescription {
            get => _PersonalCreate._DescribeCommand.GetDefault("dd");
            set => _PersonalCreate._DescribeCommand.SetDefault("dd", value);
            }

        public Shell () {
            MeshSession = new MeshSession();
            }

        public string CommandLine { get; set; }
        public string Dispatch (string Command) {
            CommandLine = "meshman " + Command;
            CommandLineInterpreter.MainMethod(this, CommandSplitLex.Split(Command));
            return CommandLine;
            }


        public RegistrationDevice RegistrationDevice  => Machine.Device;
        public DeviceProfile DeviceProfile => RegistrationDevice.DeviceProfile;

        /// <summary>
        /// Erase all test profiles
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Reset (Reset Options) {
            MeshSession.EraseTest();
            }


        /// <summary>
        /// Create a new device profile
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Device (Device Options) {
            var DeviceID = Options.DeviceID.Value ?? "Default";
            var DeviceDescription = Options.DeviceDescription.Value ?? "Unknown";
            bool? Default = Options.Default.Value;

            MeshSession.CreateDevice(DeviceID, DeviceDescription, Default);
            }

        ///// <summary>
        ///// Create a new personal profile
        ///// </summary>
        ///// <param name="Options">Command line parameters</param>
        //public override void Deregister (Deregister Options) {

        //    SetReporting(Options.Report, Options.Verbose);
        //    var Address = Options.Portal.Value;
        //    Assert.True((Address != null & Address != ""), NoPortalAccount.Throw);

        //    var ProfileRegistration = MeshSession.GetPersonal(Address, Portal: false);
        //    Assert.NotNull(ProfileRegistration, ProfileNotFound.Throw);

        //    ProfileRegistration.Delete();
        //    }


        ///// <summary>
        ///// Create a new personal profile
        ///// </summary>
        ///// <param name="Options">Command line parameters</param>
        //public override void Verify (Verify Options) {
        //    SetReporting(Options.Report, Options.Verbose);
        //    try {
        //        var Address = Options.Portal.Value;
        //        Assert.True((Address != null & Address != ""), NoPortalAccount.Throw);

        //        var Response = MeshSession.Validate(Address);
        //        LastResult = Response;

        //        if (Response.Valid) {
        //            ReportWriteLine("Accepted: {0}", Address);
        //            }
        //        else {
        //            if (Response.StatusDescription == null) {
        //                ReportWriteLine("Refused {0}", Address);
        //                }
        //            else {
        //                ReportWriteLine("Refused {0} because {1}", Address, Response.StatusDescription);
        //                }
        //            }
        //        }
        //    catch (Exception Exception) {
        //        Error(Exception);
        //        }
        //    }



        }
    }
