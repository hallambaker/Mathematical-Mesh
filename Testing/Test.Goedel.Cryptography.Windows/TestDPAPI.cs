using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

using Goedel.Cryptography.Windows;
using Goedel.Test;
using Goedel.Utilities;

namespace UnitTestProject1 {
    [TestClass]
    public partial class Tests {
        [TestMethod]
        public void TestDapi() {


            var TestData = TestVector.FillCount(42);

            var Cipher = DPAPI.Encrypt(TestData);

            string Description;
            var Recovered = DPAPI.Decrypt(Cipher, out Description);

            UT.Assert.IsTrue(Recovered.IsEqualTo(TestData));

            }


        [TestMethod]
        public void TestDpapi_Description() {

            var Description = "Test data";

            var TestData = TestVector.FillCount(42);

            var Cipher = DPAPI.Encrypt(TestData, Description:Description);

            string DescriptionOut;
            var Recovered = DPAPI.Decrypt(Cipher, out DescriptionOut);

            UT.Assert.IsTrue(Recovered.IsEqualTo(TestData));
            UT.Assert.IsTrue(Description == DescriptionOut);
            }

        [TestMethod]
        public void TestDpapi_Entropy() {

            var Description = "Test data";

            var TestData = TestVector.FillCount(42);
            var Entropy = TestVector.FillCount(32,45);

            var Cipher = DPAPI.Encrypt(TestData, Description: Description, EntropyBytes:Entropy);

            string DescriptionOut;
            var Recovered = DPAPI.Decrypt(Cipher, out DescriptionOut, EntropyBytes: Entropy);

            UT.Assert.IsTrue(Recovered.IsEqualTo(TestData));
            UT.Assert.IsTrue(Description == DescriptionOut);
            }

        [TestMethod]
        [ExpectedException (typeof(DecryptionFailed))]
        public void TestDpapi_Fail() {

            var Description = "Test data";

            var TestData = TestVector.FillCount(42);
            var Entropy = TestVector.FillCount(32, 45);

            var Cipher = DPAPI.Encrypt(TestData, Description: Description, EntropyBytes: Entropy);

            Entropy[0] = Entropy[1]; // Cause error
            string DescriptionOut;
            var Recovered = DPAPI.Decrypt(Cipher, out DescriptionOut, EntropyBytes: Entropy);
            }


        }
    }
