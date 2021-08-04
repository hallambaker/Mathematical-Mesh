#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion

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
