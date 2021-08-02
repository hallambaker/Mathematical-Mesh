using System.Numerics;

using Goedel.Cryptography.Algorithms;
using Goedel.Test;

using Xunit;

namespace Goedel.XUnit {
    public partial class TestGoedelCryptography {


        /// <summary></summary>

        [Fact]
        public void TestDHAgree() {

            var KeyA = new DiffeHellmanPrivate();
            var KeyB = new DiffeHellmanPrivate();

            var AgreeAB = KeyA.Agreement(KeyB.DiffeHellmanPublic);
            var AgreeBA = KeyB.Agreement(KeyA.DiffeHellmanPublic);

            (AgreeAB == AgreeBA).TestTrue();
            }


        [Fact]
        public void TestDHAgreeToPublic() {

            var KeyA = new DiffeHellmanPrivate();
            var KeyAPublic = KeyA.DiffeHellmanPublic;

            var Result = KeyAPublic.Agreement();

            var AgreeAB = KeyA.Agreement(Result.EphemeralPublicValue);

            (AgreeAB == Result.Agreement).TestTrue();
            }


        [Fact]
        public void TestDHAgreeRecryption() {

            var KeyA = new DiffeHellmanPrivate();
            var KeyAPublic = KeyA.DiffeHellmanPublic;


            var RecryptKeys = KeyA.MakeThresholdKeySet(2);

            var Result = KeyAPublic.Agreement();

            BigInteger[] Carry = new BigInteger[2];
            Carry[0] = (RecryptKeys[0] as DiffeHellmanPrivate).Agreement(Result.EphemeralPublicValue);
            Carry[1] = (RecryptKeys[1] as DiffeHellmanPrivate).Agreement(Result.EphemeralPublicValue);

            var AgreeAB = KeyAPublic.Agreement(Carry);

            (AgreeAB == Result.Agreement).TestTrue();
            }



        }
    }
