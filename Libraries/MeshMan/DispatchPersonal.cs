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


        /// <summary>
        /// Create a new personal profile
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void PersonalCreate (PersonalCreate Options) {
            var Address = Options.Portal.Value;
            Assert.True((Address != null & Address != ""), NoPortalAccount.Throw);
            SetReporting(Options.Report, Options.Verbose);

            var DeviceRegistration = GetDevice(Options);

            var PersonalProfile = new PersonalProfile(DeviceRegistration.DeviceProfile);

            var Registration = MeshMachine.CreateAccount(Address, PersonalProfile);

            ReportWriteLine("Created new personal profile {0}", Registration.UDF);
            ReportWriteLine("Profile registered to {0}", Address);

            }

        }
    }
