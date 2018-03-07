using System.Numerics;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

using Goedel.Utilities;
using Goedel.Test;
using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;

namespace Test.Goedel.Cryptography {
    public partial class TestGoedelCryptography {


        /// <summary></summary>

        [TestMethod]
        public void TestDHAgree() {

            var KeyA = new DiffeHellmanPrivate();
            var KeyB = new DiffeHellmanPrivate();

            var AgreeAB = KeyA.Agreement(KeyB.DiffeHellmanPublic);
            var AgreeBA = KeyB.Agreement(KeyA.DiffeHellmanPublic);

            UT.Assert.IsTrue(AgreeAB == AgreeBA);
            }


        [TestMethod]
        public void TestDHAgreeToPublic() {

            var KeyA = new DiffeHellmanPrivate();
            var KeyAPublic = KeyA.DiffeHellmanPublic;

            var Result = KeyAPublic.Agreement();

            var AgreeAB = KeyA.Agreement(Result.DiffeHellmanPublic);

            UT.Assert.IsTrue(AgreeAB == Result.Agreement);
            }


        [TestMethod]
        public void TestDHAgreeRecryption() {

            var KeyA = new DiffeHellmanPrivate();
            var KeyAPublic = KeyA.DiffeHellmanPublic;


            var RecryptKeys = KeyA.MakeRecryption(2);

            var Result = KeyAPublic.Agreement();

            BigInteger[] Carry = new BigInteger[2];
            Carry[0] = RecryptKeys[0].Agreement(Result.DiffeHellmanPublic);
            Carry[1] = RecryptKeys[1].Agreement(Result.DiffeHellmanPublic);

            var AgreeAB = KeyAPublic.Agreement(Carry);

            UT.Assert.IsTrue(AgreeAB == Result.Agreement);
            }



        }
    }
