using System;
using Xunit;
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Mesh.Protocol.Client;
using Goedel.Mesh.Test;
using Goedel.Test.Core;
using Goedel.Utilities;

namespace Goedel.XUnit {

    public class CustomTestTypeAttribute : System.Attribute { }

    /// <summary>
    /// Perform unit tests on profiles using the .NET Core framework. 
    /// </summary>
    /// <remarks>These tests are stubs to the tests in the shared library so that the
    /// same tests can be run using the .NET Framework testing.</remarks>
    public partial class TestProfilesXunit {

        public static TestProfilesXunit Test() => new TestProfilesXunit();
        public TestProfilesXunit() {
            TestEnvironmentCommon.Initialize();
            Goedel.Mesh.Mesh.Initialize();
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



        [Fact(Skip = "Decode a device profile")]
        public void DecodeProfileDevice() => throw new NYI();

        [Fact(Skip = "Check a valid device profile signature")]
        public void DecodeProfileSignatureFail() => throw new NYI();

        [Fact(Skip = "Check an invalid device profile signature")]
        public void DecodeProfileSignatureValid() => throw new NYI();

        }
    }
