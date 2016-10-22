using Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Mesh;
using Goedel.Mesh.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Mesh.Platform.Tests {
    [TestClass()]
    public class RegistrationMachineTests {

        public RegistrationMachineTests() {
            }

        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext) {
            RegistrationMachine.Erase();
            }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup() { }


        [TestMethod()]
        public void AddTest() {

            var Machine = RegistrationMachine.Current;

            var NewProfile = new SignedDeviceProfile("Test", "Test Device");
            var Registration = Machine.Add(NewProfile);

            }
        }
    }