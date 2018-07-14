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

        [TestMethod]
        public void TestBigIntConvert() {

            var M1 = new BigInteger(1000000000000);
            var X1 = M1 * 2;


            var M2 = (new byte[] { 0x00, 0x10, 0xA5, 0xD4, 0xE8, 0x00 }).BigIntegerLittleEndian();
            var M3 = (new byte[] { 0x00, 0x10, 0xA5, 0xD4, 0xE8}).BigIntegerLittleEndian();
            var M4 = (new byte[] { 0x00, 0xE8 , 0xD4, 0xA5, 0x10, 0x00}).BigIntegerBigEndian();
            var M5 = (new byte[] { 0xE8, 0xD4, 0xA5, 0x10, 0x00 }).BigIntegerBigEndian();

            var X2 = (new byte[] { 0x00, 0x20, 0x4a, 0xA9, 0xD1, 0x01, 0x00 }).BigIntegerLittleEndian();
            var X3 = (new byte[] { 0x00, 0x20, 0x4a, 0xA9, 0xD1, 0x01 }).BigIntegerLittleEndian();
            var X4 = (new byte[] { 0x00, 0x01, 0xD1, 0xA9, 0x4A, 0x20, 0x00 }).BigIntegerBigEndian();
            var X5 = (new byte[] { 0x01, 0xD1, 0xA9, 0x4A, 0x20, 0x00 }).BigIntegerBigEndian();

            UT.Assert.AreEqual(M1, M2);
            UT.Assert.AreEqual(M1, M3);
            UT.Assert.AreEqual(M1, M4);
            UT.Assert.AreEqual(M1, M4);


            UT.Assert.AreEqual(X1, X2);
            UT.Assert.AreEqual(X1, X3);
            UT.Assert.AreEqual(X1, X4);
            UT.Assert.AreEqual(X1, X4);
            }

        [TestMethod]
        public void TestBitField1() {

            var BitIndex = new BitIndex(new BigInteger(0x80), 8, Up:false);

            UT.Assert.IsTrue(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());

            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());
            }


        [TestMethod]
        public void TestBitField1Up() {

            var BitIndex = new BitIndex(new BigInteger(0x80), 8, Up:true);


            UT.Assert.IsFalse(BitIndex.Up());
            UT.Assert.IsFalse(BitIndex.Up());
            UT.Assert.IsFalse(BitIndex.Up());
            UT.Assert.IsFalse(BitIndex.Up());

            UT.Assert.IsFalse(BitIndex.Up());
            UT.Assert.IsFalse(BitIndex.Up());
            UT.Assert.IsFalse(BitIndex.Up());
            UT.Assert.IsTrue(BitIndex.Up());
            }



        [TestMethod]
        public void TestBitField2() {
            var BitIndex = new BitIndex(new BigInteger(0x81), 8);

            UT.Assert.IsTrue(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());

            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsTrue(BitIndex.Down());
            }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperation))]
        public void TestBitField3() {
            var BitIndex = new BitIndex(new BigInteger(0x81), 8);

            UT.Assert.IsTrue(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());

            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsTrue(BitIndex.Down());
            BitIndex.Down();
            }

        [TestMethod]
        public void TestBitField4() {
            var BitIndex = new BitIndex(new BigInteger(0x8118), 16);

            UT.Assert.IsTrue(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());

            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsTrue(BitIndex.Down());

            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsTrue(BitIndex.Down());

            UT.Assert.IsTrue(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());
            UT.Assert.IsFalse(BitIndex.Down());
            }


        [TestMethod]
        public void TestBitField4Up() {

            var BitIndex = new BitIndex(new BigInteger(0x0180), 16, Up: true);


            UT.Assert.IsFalse(BitIndex.Up());
            UT.Assert.IsFalse(BitIndex.Up());
            UT.Assert.IsFalse(BitIndex.Up());
            UT.Assert.IsFalse(BitIndex.Up());

            UT.Assert.IsFalse(BitIndex.Up());
            UT.Assert.IsFalse(BitIndex.Up());
            UT.Assert.IsFalse(BitIndex.Up());
            UT.Assert.IsTrue(BitIndex.Up());

            UT.Assert.IsTrue(BitIndex.Up());
            UT.Assert.IsFalse(BitIndex.Up());
            UT.Assert.IsFalse(BitIndex.Up());
            UT.Assert.IsFalse(BitIndex.Up());

            UT.Assert.IsFalse(BitIndex.Up());
            UT.Assert.IsFalse(BitIndex.Up());
            UT.Assert.IsFalse(BitIndex.Up());
            UT.Assert.IsFalse(BitIndex.Up());


            }



        [TestMethod]
        public void TestCurveConstants() {

            var Curve25519 = DomainParameters.Curve25519;

            var D = "37095705934669439343138083508754565189542113879843219016388785533085940283555".DecimalToBigInteger();
            var By = "46316835694926478169428394003475163141307993866256225615783033603165251855960".DecimalToBigInteger();
            var p = "57896044618658097711785492504343953926634992332820282019728792003956564819949".DecimalToBigInteger();

            UT.Assert.AreEqual(Curve25519.D, D);
            UT.Assert.AreEqual(Curve25519.By, By);
            UT.Assert.AreEqual(Curve25519.P, p);

            var M1M = (-1).Mod(Curve25519.P);
            var M1 = Curve25519.P - 1;
            var RM1S = (Curve25519.SqrtMinus1 * Curve25519.SqrtMinus1).Mod(Curve25519.P);

            UT.Assert.AreEqual(M1, RM1S);
            UT.Assert.AreEqual(M1, M1M);


            var Neutral = CurveEdwards25519.Neutral;

            var BaseX = ("15112221349535400772501151409588531511454012693041857206046113283949847762202").DecimalToBigInteger();
            var BaseY = ("46316835694926478169428394003475163141307993866256225615783033603165251855960").DecimalToBigInteger();

            UT.Assert.AreEqual(BaseX, CurveEdwards25519.Base.X);
            UT.Assert.AreEqual(BaseY, CurveEdwards25519.Base.Y);

            var Curve448 = DomainParameters.Curve448;

            //var BaseX = ("22458004029592430018760433409989603624678964163256413424612" +
            //"54616869504154674060329090291928693579532825780320751" +
            //"46446173674602635247710").DecimalToBigInteger();
            //var BaseY = ("2988192100784814926760179304" +
            //"43930673437544040154080242095928241372331506189835876" +
            //"00353687865541878473398230323350346250053154506283266").DecimalToBigInteger();
            }


        [TestMethod]
        public void TestSquareRoot() {
            var Curve25519 = DomainParameters.Curve25519;

            var D2 = (Curve25519.By* Curve25519.By).Mod(Curve25519.P);
            var Da = D2.Sqrt(Curve25519.P, Curve25519.SqrtMinus1);
            var Db = D2.Sqrt(Curve25519.P);
            var Dp = D2.Sqrt(Curve25519.P, Curve25519.SqrtMinus1, false);
            var Dn = D2.Sqrt(Curve25519.P, Curve25519.SqrtMinus1, true);

            UT.Assert.IsTrue(Dp.IsEven);
            UT.Assert.IsFalse(Dn.IsEven);
            UT.Assert.IsTrue(D2 == (Da * Da).Mod(Curve25519.P));
            UT.Assert.IsTrue(D2 == (Db * Db).Mod(Curve25519.P));
            UT.Assert.IsTrue(D2 == (Dp * Dp).Mod(Curve25519.P));
            UT.Assert.IsTrue(D2 == (Dn * Dn).Mod(Curve25519.P));

            }

        }
    }
