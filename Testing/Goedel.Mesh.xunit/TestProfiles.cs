using System;
using Xunit;
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Mesh.Protocol.Client;
using Goedel.Mesh.Test;

namespace Goedel.Mesh.xunit {
    public sealed class IgnoreXunitAnalyzersRule1013Attribute : System.Attribute { }

    [IgnoreXunitAnalyzersRule1013]
    public class CustomTestTypeAttribute : System.Attribute { }

    public partial class TestProfiles {

        static string Service = "example.com";
        static string AccountAlice = $"alice@{Service}";

#pragma warning disable xUnit1013 // Public method should be marked as test
        [CustomTestType]
        public static void TestDirect() {
            var TestProfiles = new TestProfiles();
            TestProfiles.GenerateMaster();
            }
#pragma warning restore xUnit1013 // Public method should be marked as test

        public TestProfiles() => Mesh.Initialize();

        [Fact]
        public void GenerateMaster() => Goedel.Mesh.Test.TestProfiles.Test.GenerateMaster();

        [Fact (Skip="Get basic working first")]
        public void GenerateDevice() => Goedel.Mesh.Test.TestProfiles.Test.GenerateDevice();

        }
    }
