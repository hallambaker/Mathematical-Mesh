using System;
using Xunit;
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Mesh.Protocol.Client;
using Goedel.Mesh.Test;
using Goedel.Test.Core;

namespace Goedel.Mesh.xunit {

    public class CustomTestTypeAttribute : System.Attribute { }

    public partial class TestProfilesXunit {

        public static TestProfilesXunit Test() => new TestProfilesXunit();
        public TestProfilesXunit() {
            TestEnvironment.Initialize();
            Mesh.Initialize();
            }


        //static string Service = "example.com";
        //static string AccountAlice = $"alice@{Service}";


        [Fact]
        public void EscrowRecover() => TestProfiles.Test.EscrowRecover();

        [Fact]
        public void CatalogCredentials() => TestProfiles.Test.CatalogCredentials();

        [Fact]
        public void CatalogDevices() => TestProfiles.Test.CatalogDevices();

        [Fact]
        public void CatalogContacts() => TestProfiles.Test.CatalogContacts();


        [Fact (Skip="Get basic working first")]
        public void GenerateDevice() => TestProfiles.Test.GenerateDevice();

        }
    }
