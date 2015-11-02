using Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Cryptography.Jose;
using Goedel.CryptoLibNG;
using Goedel.Debug;

namespace Goedel.Cryptography.Jose.Tests {
    [TestClass()]
    public class JoseWebEncryptionTests {
        [TestMethod()]
        public void JoseWebEncryptionTest() {

            var Plaintext = CryptoCatalog.GetBytes(2000);

            var Encrypted = new JoseWebEncryption(Plaintext);
            var Recovered = Encrypted.Decrypt();

            Trace.AssertEqual("Check Testvector", Plaintext, Recovered);
            }

        [TestMethod()]
        public void TestPublicKeyExchange () {
            Assert.Fail();
            }

        }
    }