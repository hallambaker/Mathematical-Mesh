using System;
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Mesh.Protocol.Client;
using Goedel.Utilities;

namespace Goedel.Mesh.Test {

    public partial class TestProfiles {

        static string Service = "example.com";
        static string AccountAlice = $"alice@{Service}";


        public static TestProfiles Test => new TestProfiles();

        public  void GenerateMaster() {
            var MachineAliceAdmin = new MeshMachineTest("Alice Admin");
            var MachineAliceRecover = new MeshMachineTest("Alice Admin");

            var DeviceAdmin = ContextDevice.Generate(MachineAliceAdmin);
            var MasterAdmin = DeviceAdmin.GenerateMaster();

            var (Escrow, Shares) = MasterAdmin.Escrow(3, 2);
            var RecoverShares = new KeyShare[] { Shares[0], Shares[2] };

            var DeviceAdminRecovered = ContextMaster.Recover(Escrow, RecoverShares);

            }


        public  void GenerateDevice() {
            var MachineAliceAdmin = new MeshMachineTest("Alice Admin");
            var MachineAliceSecond = new MeshMachineTest("Alice 2");

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
