using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Protocol;

using System.Collections.Generic;

namespace ExampleGenerator {


    public partial class CreateExamples {

        public void LayerDevice() => DoCommandsProfile();

        #region // Tests

        public List<ExampleResult> ProfileCreateAlice;
        public List<ExampleResult> ProfileAliceDelete;
        public List<ExampleResult> ProfileAliceRecover;


        public List<ExampleResult> ProfileDevice;
        public List<ExampleResult> ProfileList;
        public List<ExampleResult> ProfileDump;
        public List<ExampleResult> ProfileEscrow;

        public List<ExampleResult> ProfileRecover;
        public List<ExampleResult> ProfileExport;
        public List<ExampleResult> ProfileImport;
        public List<ExampleResult> ProfileHello;
        public List<ExampleResult> ProfileHelloDevice;
        public List<ExampleResult> ProfileHelloProfile;
        public List<ExampleResult> ProfileHelloTicket;


        public List<ExampleResult> ProfileSync;

        public List<ExampleResult> ProfileCreateBob;

        public JSONObject Profile;

        public ResultCreatePersonal AliceProfiles;
        public ResultHello ResultHello;


        public void DoCommandsProfile() {
            // Create a new profile
            ProfileCreateAlice = testCLIAlice1.Example($"mesh create");
            AliceProfiles = ProfileCreateAlice[0].Result as ResultCreatePersonal;


            // decode the catalogged device here and provide the Key collection

            // Bob uses the all in one approach
            ProfileCreateBob = testCLIBob1.Example($"mesh create /account {BobAccount} /service={BobService}");

            // Basic get information tests.
            ProfileList = testCLIAlice1.Example($"mesh list");
            ProfileDump = testCLIAlice1.Example($"mesh get");


            // Escrow round trip
            //ProfileEscrow = testCLIAlice1.Example($"mesh escrow");

            //var share1 = (ProfileEscrow[0].Result as ResultEscrow).Shares[0];
            //var share2 = (ProfileEscrow[0].Result as ResultEscrow).Shares[2];

            //ProfileAliceDelete = testCLIAlice1.Example($"mesh delete");
            //ProfileRecover = testCLIAlice1.Example($"mesh recover {share1} {share2} /verify");


            // Import and export test
            ProfileExport = testCLIAlice1.Example($"mesh export {TestExport}");
            ProfileImport = testCLIAlice4.Example($"mesh import {TestExport}"); // do on another device (to be created
            }

        #endregion
        }
    }
