using System.Numerics;
using System.Collections.Generic;
using Xunit;

using Goedel.Utilities;
using Goedel.Test;
using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;

namespace Goedel.XUnit {
    public partial class TestGoedelCryptography {


        /// <summary></summary>

        [Fact]
        public void TestDHAgree() {

            var KeyA = new DiffeHellmanPrivate();
            var KeyB = new DiffeHellmanPrivate();

            var AgreeAB = KeyA.Agreement(KeyB.DiffeHellmanPublic);
            var AgreeBA = KeyB.Agreement(KeyA.DiffeHellmanPublic);

            Utilities.Assert.True(AgreeAB == AgreeBA);
            }


        [Fact]
        public void TestDHAgreeToPublic() {

            var KeyA = new DiffeHellmanPrivate();
            var KeyAPublic = KeyA.DiffeHellmanPublic;

            var Result = KeyAPublic.Agreement();

            var AgreeAB = KeyA.Agreement(Result.EphemeralPublicValue);

            Utilities.Assert.True(AgreeAB == Result.Agreement);
            }


        [Fact]
        public void TestDHAgreeRecryption() {

            var KeyA = new DiffeHellmanPrivate();
            var KeyAPublic = KeyA.DiffeHellmanPublic;


            var RecryptKeys = KeyA.MakeRecryptionKeySet(2);

            var Result = KeyAPublic.Agreement();

            BigInteger[] Carry = new BigInteger[2];
            Carry[0] = (RecryptKeys[0] as DiffeHellmanPrivate).Agreement(Result.EphemeralPublicValue);
            Carry[1] = (RecryptKeys[1] as DiffeHellmanPrivate).Agreement(Result.EphemeralPublicValue);

            var AgreeAB = KeyAPublic.Agreement(Carry);

            Utilities.Assert.True(AgreeAB == Result.Agreement);
            }



        }
    }
