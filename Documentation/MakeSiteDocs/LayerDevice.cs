using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;
using Goedel.Mesh.Test;
using Goedel.Mesh.Shell;
using Goedel.Test.Core;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Utilities;
using System.Linq;
using Goedel.Cryptography;
using System.Numerics;
using System.Collections.Generic;

namespace ExampleGenerator {


    public partial class CreateExamples {

        public void LayerDevice() {

            DoCommandsProfile();

            }

        #region // Tests

        public List<ExampleResult> ProfileCreateAlice;
        public List<ExampleResult> ProfileAliceDelete;



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
        public List<ExampleResult> ProfileRegister;

        public List<ExampleResult> ProfileSync;

        public List<ExampleResult> ProfileCreateBob;

        public JSONObject Profile;

        public ResultMasterCreate AliceProfiles;
        public ResultHello ResultHello;


        public void DoCommandsProfile() {


            ProfileCreateAlice = testCLIAlice1.Example($"mesh create");




            AliceProfiles = ProfileCreateAlice[0].Result as ResultMasterCreate;

            ProfileList = testCLIAlice1.Example($"profile list");
            ProfileDump = testCLIAlice1.Example($"profile get /mesh={AliceAccount1}");



            ProfileEscrow = testCLIAlice1.Example($"profile escrow");

            //var share1 = (ProfileEscrow[0].Result as ResultEscrow).Shares[0];
            //var share2 = (ProfileEscrow[0].Result as ResultEscrow).Shares[2];

            //ProfileAliceDelete = testCLIAlice1.Example($"profile delete  {AliceService1}");

            //ProfileRecover = testCLIAlice1.Example($"profile recover ${share1} ${share2} /verify");
            //ProfileExport = testCLIAlice1.Example($"profile export {TestExport}");
            //ProfileImport = testCLIAlice2.Example($"profile import {TestExport}"); // do on another device

  
            //ProfileAliceRegister = testCLIAlice1.Example($"account recover  {AliceAccount1}");

            

            }

        #endregion
        }
    }
