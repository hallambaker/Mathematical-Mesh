using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Utilities;

using System.Numerics;

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

            (M1 == M2).AssertTrue();
            (M1 == M3).AssertTrue();
            (M1 == M4).AssertTrue();
            (M1 == M4).AssertTrue();

            (X1 == X2).AssertTrue();
            (X1 == X3).AssertTrue();
            (X1 == X4).AssertTrue();
            (X1 == X4).AssertTrue();
            }

        [Fact]
        public void TestBitField1() {

            var BitIndex = new BitIndex(new BigInteger(0x80), 8, Up: false);

            (BitIndex.Down()).AssertTrue();
            (BitIndex.Down()).AssertFalse();
            (BitIndex.Down()).AssertFalse();
            (BitIndex.Down()).AssertFalse();

            (BitIndex.Down()).AssertFalse();
            (BitIndex.Down()).AssertFalse();
            (BitIndex.Down()).AssertFalse();
            (BitIndex.Down()).AssertFalse();
            }


        [Fact]
        public void TestBitField1Up() {

            var BitIndex = new BitIndex(new BigInteger(0x80), 8, Up: true);


            (BitIndex.Up()).AssertFalse();
            (BitIndex.Up()).AssertFalse();
            (BitIndex.Up()).AssertFalse();
            (BitIndex.Up()).AssertFalse();

            (BitIndex.Up()).AssertFalse();
            (BitIndex.Up()).AssertFalse();
            (BitIndex.Up()).AssertFalse();
            (BitIndex.Up()).AssertTrue();
            }



        [Fact]
        public void TestBitField2() {
            var BitIndex = new BitIndex(new BigInteger(0x81), 8);

            (BitIndex.Down()).AssertTrue();
            (BitIndex.Down()).AssertFalse();
            (BitIndex.Down()).AssertFalse();
            (BitIndex.Down()).AssertFalse();

            (BitIndex.Down()).AssertFalse();
            (BitIndex.Down()).AssertFalse();
            (BitIndex.Down()).AssertFalse();
            (BitIndex.Down()).AssertTrue();
            }

        [Fact]
        public void TestBitField3() =>
            Xunit.Assert.Throws<InvalidOperation>(() => {
                var BitIndex = new BitIndex(new BigInteger(0x81), 8);

                (BitIndex.Down()).AssertTrue();
                (BitIndex.Down()).AssertFalse();
                (BitIndex.Down()).AssertFalse();
                (BitIndex.Down()).AssertFalse();

                (BitIndex.Down()).AssertFalse();
                (BitIndex.Down()).AssertFalse();
                (BitIndex.Down()).AssertFalse();
                (BitIndex.Down()).AssertTrue();
                BitIndex.Down();
            });

        [Fact]
        public void TestBitField4() {
            var BitIndex = new BitIndex(new BigInteger(0x8118), 16);

            (BitIndex.Down()).AssertTrue();
            (BitIndex.Down()).AssertFalse();
            (BitIndex.Down()).AssertFalse();
            (BitIndex.Down()).AssertFalse();

            (BitIndex.Down()).AssertFalse();
            (BitIndex.Down()).AssertFalse();
            (BitIndex.Down()).AssertFalse();
            (BitIndex.Down()).AssertTrue();

            (BitIndex.Down()).AssertFalse();
            (BitIndex.Down()).AssertFalse();
            (BitIndex.Down()).AssertFalse();
            (BitIndex.Down()).AssertTrue();

            (BitIndex.Down()).AssertTrue();
            (BitIndex.Down()).AssertFalse();
            (BitIndex.Down()).AssertFalse();
            (BitIndex.Down()).AssertFalse();
            }


        [Fact]
        public void TestBitField4Up() {

            var BitIndex = new BitIndex(new BigInteger(0x0180), 16, Up: true);


            (BitIndex.Up()).AssertFalse();
            (BitIndex.Up()).AssertFalse();
            (BitIndex.Up()).AssertFalse();
            (BitIndex.Up()).AssertFalse();

            (BitIndex.Up()).AssertFalse();
            (BitIndex.Up()).AssertFalse();
            (BitIndex.Up()).AssertFalse();
            (BitIndex.Up()).AssertTrue();

            (BitIndex.Up()).AssertTrue();
            (BitIndex.Up()).AssertFalse();
            (BitIndex.Up()).AssertFalse();
            (BitIndex.Up()).AssertFalse();

            (BitIndex.Up()).AssertFalse();
            (BitIndex.Up()).AssertFalse();
            (BitIndex.Up()).AssertFalse();
            (BitIndex.Up()).AssertFalse();


            }



        [Fact]
        public void TestCurveConstants() {

            var Curve25519 = DomainParameters.Curve25519;

            var D = "37095705934669439343138083508754565189542113879843219016388785533085940283555".DecimalToBigInteger();
            var By = "46316835694926478169428394003475163141307993866256225615783033603165251855960".DecimalToBigInteger();
            var p = "57896044618658097711785492504343953926634992332820282019728792003956564819949".DecimalToBigInteger();

            (Curve25519.D == D).AssertTrue();
            (Curve25519.By == By).AssertTrue();
            (Curve25519.P == p).AssertTrue();

            var M1M = (-1).Mod(Curve25519.P);
            var M1 = Curve25519.P - 1;
            var RM1S = (Curve25519.SqrtMinus1 * Curve25519.SqrtMinus1).Mod(Curve25519.P);

            (M1 == RM1S).AssertTrue();
            (M1 == M1M).AssertTrue();


            var Neutral = CurveEdwards25519.Neutral;

            var BaseX = ("15112221349535400772501151409588531511454012693041857206046113283949847762202").DecimalToBigInteger();
            var BaseY = ("46316835694926478169428394003475163141307993866256225615783033603165251855960").DecimalToBigInteger();

            (BaseX == CurveEdwards25519.Base.X).AssertTrue();
            (BaseY == CurveEdwards25519.Base.Y).AssertTrue();

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

            (Dp.IsEven).AssertTrue();
            (Dn.IsEven).AssertFalse();
            (D2 == (Da * Da).Mod(Curve25519.P)).AssertTrue();
            (D2 == (Db * Db).Mod(Curve25519.P)).AssertTrue();
            (D2 == (Dp * Dp).Mod(Curve25519.P)).AssertTrue();
            (D2 == (Dn * Dn).Mod(Curve25519.P)).AssertTrue();

            }

        }
    }
