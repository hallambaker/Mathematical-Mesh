using System;
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Mesh.Protocol.Client;
using Goedel.Utilities;
using Goedel.Test.Core;


namespace Goedel.Mesh.Test {

    public partial class TestProfiles {

        static string Service = "example.com";
        static string AccountAlice = $"alice@{Service}";


        public static TestProfiles Test => new TestProfiles();

        public  void GenerateMaster() {
            var MachineAliceAdmin = new MeshMachineTest(name:"Alice Admin");
            var MachineAliceRecover = new MeshMachineTest(name: "Alice Admin Recovered");

            var DeviceAdmin = ContextDevice.Generate(MachineAliceAdmin);
            var MasterAdmin = DeviceAdmin.GenerateMaster();

            var (Escrow, Shares) = MasterAdmin.Escrow(3, 2);
            var RecoverShares = new KeyShare[] { Shares[0], Shares[2] };

            var DeviceAdminRecovered = DeviceAdmin.Recover(Escrow, RecoverShares);

            }


        public  void GenerateDevice() {
            var MachineAliceAdmin = new MeshMachineTest(name: "Alice Admin");
            var MachineAliceSecond = new MeshMachineTest(name: "Alice 2");

            var DeviceAdmin = ContextDevice.Generate(MachineAliceAdmin);
            var MasterAdmin = DeviceAdmin.GenerateMaster();
            MasterAdmin.Register(AccountAlice);

            var DeviceSecond = ContextDevice.Generate(MachineAliceSecond);
            var Fingerprint = DeviceSecond.Connect(AccountAlice);

            var Connected = DeviceSecond.Complete(AccountAlice);
            Assert.False(Connected);
            MasterAdmin.ConnectionResponse(Fingerprint, ConnectionState.Connected);

            Connected = DeviceSecond.Complete(AccountAlice);
            Assert.True(Connected);
            }

        }
    }
