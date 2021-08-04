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

using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Test;

using Xunit;

#pragma warning disable IDE0059

namespace Goedel.XUnit {
    public partial class TestGoedelCryptography {

        [Fact]
        public void TestBigIntConvert() {

            var M1 = new BigInteger(1000000000000);
            var X1 = M1 * 2;


            var M2 = (new byte[] { 0x00, 0x10, 0xA5, 0xD4, 0xE8, 0x00 }).BigIntegerLittleEndian();
            var M3 = (new byte[] { 0x00, 0x10, 0xA5, 0xD4, 0xE8 }).BigIntegerLittleEndian();
            var M4 = (new byte[] { 0x00, 0xE8, 0xD4, 0xA5, 0x10, 0x00 }).BigIntegerBigEndian();
            var M5 = (new byte[] { 0xE8, 0xD4, 0xA5, 0x10, 0x00 }).BigIntegerBigEndian();

            var X2 = (new byte[] { 0x00, 0x20, 0x4a, 0xA9, 0xD1, 0x01, 0x00 }).BigIntegerLittleEndian();
            var X3 = (new byte[] { 0x00, 0x20, 0x4a, 0xA9, 0xD1, 0x01 }).BigIntegerLittleEndian();
            var X4 = (new byte[] { 0x00, 0x01, 0xD1, 0xA9, 0x4A, 0x20, 0x00 }).BigIntegerBigEndian();
            var X5 = (new byte[] { 0x01, 0xD1, 0xA9, 0x4A, 0x20, 0x00 }).BigIntegerBigEndian();

            (M1 == M2).TestTrue();
            (M1 == M3).TestTrue();
            (M1 == M4).TestTrue();
            (M1 == M4).TestTrue();

            (X1 == X2).TestTrue();
            (X1 == X3).TestTrue();
            (X1 == X4).TestTrue();
            (X1 == X4).TestTrue();
            }

        [Fact]
        public void TestBitField1() {

            var BitIndex = new BitIndex(new BigInteger(0x80), 8, Up: false);

            (BitIndex.Down()).TestTrue();
            (BitIndex.Down()).TestFalse();
            (BitIndex.Down()).TestFalse();
            (BitIndex.Down()).TestFalse();

            (BitIndex.Down()).TestFalse();
            (BitIndex.Down()).TestFalse();
            (BitIndex.Down()).TestFalse();
            (BitIndex.Down()).TestFalse();
            }


        [Fact]
        public void TestBitField1Up() {

            var BitIndex = new BitIndex(new BigInteger(0x80), 8, Up: true);


            (BitIndex.Up()).TestFalse();
            (BitIndex.Up()).TestFalse();
            (BitIndex.Up()).TestFalse();
            (BitIndex.Up()).TestFalse();

            (BitIndex.Up()).TestFalse();
            (BitIndex.Up()).TestFalse();
            (BitIndex.Up()).TestFalse();
            (BitIndex.Up()).TestTrue();
            }



        [Fact]
        public void TestBitField2() {
            var BitIndex = new BitIndex(new BigInteger(0x81), 8);

            (BitIndex.Down()).TestTrue();
            (BitIndex.Down()).TestFalse();
            (BitIndex.Down()).TestFalse();
            (BitIndex.Down()).TestFalse();

            (BitIndex.Down()).TestFalse();
            (BitIndex.Down()).TestFalse();
            (BitIndex.Down()).TestFalse();
            (BitIndex.Down()).TestTrue();
            }

        [Fact]
        public void TestBitField3() =>
            Xunit.Assert.Throws<InvalidOperation>(() => {
                var BitIndex = new BitIndex(new BigInteger(0x81), 8);

                (BitIndex.Down()).TestTrue();
                (BitIndex.Down()).TestFalse();
                (BitIndex.Down()).TestFalse();
                (BitIndex.Down()).TestFalse();

                (BitIndex.Down()).TestFalse();
                (BitIndex.Down()).TestFalse();
                (BitIndex.Down()).TestFalse();
                (BitIndex.Down()).TestTrue();
                BitIndex.Down();
            });

        [Fact]
        public void TestBitField4() {
            var BitIndex = new BitIndex(new BigInteger(0x8118), 16);

            (BitIndex.Down()).TestTrue();
            (BitIndex.Down()).TestFalse();
            (BitIndex.Down()).TestFalse();
            (BitIndex.Down()).TestFalse();

            (BitIndex.Down()).TestFalse();
            (BitIndex.Down()).TestFalse();
            (BitIndex.Down()).TestFalse();
            (BitIndex.Down()).TestTrue();

            (BitIndex.Down()).TestFalse();
            (BitIndex.Down()).TestFalse();
            (BitIndex.Down()).TestFalse();
            (BitIndex.Down()).TestTrue();

            (BitIndex.Down()).TestTrue();
            (BitIndex.Down()).TestFalse();
            (BitIndex.Down()).TestFalse();
            (BitIndex.Down()).TestFalse();
            }


        [Fact]
        public void TestBitField4Up() {

            var BitIndex = new BitIndex(new BigInteger(0x0180), 16, Up: true);


            (BitIndex.Up()).TestFalse();
            (BitIndex.Up()).TestFalse();
            (BitIndex.Up()).TestFalse();
            (BitIndex.Up()).TestFalse();

            (BitIndex.Up()).TestFalse();
            (BitIndex.Up()).TestFalse();
            (BitIndex.Up()).TestFalse();
            (BitIndex.Up()).TestTrue();

            (BitIndex.Up()).TestTrue();
            (BitIndex.Up()).TestFalse();
            (BitIndex.Up()).TestFalse();
            (BitIndex.Up()).TestFalse();

            (BitIndex.Up()).TestFalse();
            (BitIndex.Up()).TestFalse();
            (BitIndex.Up()).TestFalse();
            (BitIndex.Up()).TestFalse();


            }



        [Fact]
        public void TestCurveConstants() {

            var Curve25519 = DomainParameters.Curve25519;

            var D = "37095705934669439343138083508754565189542113879843219016388785533085940283555".DecimalToBigInteger();
            var By = "46316835694926478169428394003475163141307993866256225615783033603165251855960".DecimalToBigInteger();
            var p = "57896044618658097711785492504343953926634992332820282019728792003956564819949".DecimalToBigInteger();

            (Curve25519.D == D).TestTrue();
            (Curve25519.By == By).TestTrue();
            (Curve25519.P == p).TestTrue();

            var M1M = (-1).Mod(Curve25519.P);
            var M1 = Curve25519.P - 1;
            var RM1S = (Curve25519.SqrtMinus1 * Curve25519.SqrtMinus1).Mod(Curve25519.P);

            (M1 == RM1S).TestTrue();
            (M1 == M1M).TestTrue();


            var Neutral = CurveEdwards25519.Neutral;

            var BaseX = ("15112221349535400772501151409588531511454012693041857206046113283949847762202").DecimalToBigInteger();
            var BaseY = ("46316835694926478169428394003475163141307993866256225615783033603165251855960").DecimalToBigInteger();

            (BaseX == CurveEdwards25519.Base.X).TestTrue();
            (BaseY == CurveEdwards25519.Base.Y).TestTrue();

            var Curve448 = DomainParameters.Curve448;

            }


        [Fact]
        public void TestSquareRoot() {
            var Curve25519 = DomainParameters.Curve25519;

            var D2 = (Curve25519.By * Curve25519.By).Mod(Curve25519.P);
            var Da = D2.Sqrt(Curve25519.P, Curve25519.SqrtMinus1);
            var Db = D2.Sqrt(Curve25519.P);
            var Dp = D2.Sqrt(Curve25519.P, Curve25519.SqrtMinus1, false);
            var Dn = D2.Sqrt(Curve25519.P, Curve25519.SqrtMinus1, true);

            (Dp.IsEven).TestTrue();
            (Dn.IsEven).TestFalse();
            (D2 == (Da * Da).Mod(Curve25519.P)).TestTrue();
            (D2 == (Db * Db).Mod(Curve25519.P)).TestTrue();
            (D2 == (Dp * Dp).Mod(Curve25519.P)).TestTrue();
            (D2 == (Dn * Dn).Mod(Curve25519.P)).TestTrue();

            }

        }
    }
