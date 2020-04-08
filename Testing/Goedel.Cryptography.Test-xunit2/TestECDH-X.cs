using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Utilities;

using System.Numerics;

using Xunit;

#pragma warning disable IDE0059


namespace Goedel.XUnit {
    public partial class TestGoedelCryptography {


        [Theory]
        [InlineData(1000, 500)]
        [InlineData(1000, 50)]
        public void X448SignedMultiply(int totalIn, int partIn) {

            BigInteger total = totalIn;
            BigInteger part = partIn;


            var q = CurveX448.Base;
            var q1 = q.Multiply(part+1);

            var point = CurveX448.Base;
            CheckCurve(point);

            point.ScalarAccumulate(point.U, part, out var xq, out var zq, out var xq1, out var zq1);
            point.ScalarAccumulate(point.U, part+1, out var xq2, out var zq2, out _, out var _);

            var u0 = point.Recover(xq, zq);
            
            var u1 = point.Recover(xq1, zq1);
            var u2 = point.Recover(xq2, zq2);
            (u1 == u2).AssertTrue();
            (q1.U == u2).AssertTrue();

            var v0 = point.GetV(u0, true);
            var s = new CurveX448(u0, v0);
            var s1 = s.Add(point);

            (s1.U == u1).AssertTrue();

            var v1a = point.GetV(u1, true);
            var v1b = point.GetV(u1, false);


            var v1 = point.GetV(u1, !s1.V.IsEven);
            (s1.V == v1).AssertTrue();


            var p1 = point.Multiply(part);
            CheckCurve(p1);


            var p2 = point.Multiply(total - part);
            CheckCurve(p2);

            var p3 = p1.Add(p2);
            CheckCurve(p3);

            var p3test = point.Multiply(total);
            CheckCurve(p3test);

            (p3.U == p3test.U).AssertTrue();
            (p3.V == p3test.V).AssertTrue();
            }

        [Theory]
        [InlineData(1000, 500)]
        [InlineData(1000, 50)]
        public void X448SignedMultiplyFast(int totalIn, int partIn) {
            BigInteger total = totalIn;
            BigInteger part = partIn;

            var q = CurveX448.Base;
            var q1 = q.Multiply(part + 1);

            var point = CurveX448.Base;
            CheckCurve(point);

            point.ScalarAccumulate(point.U, part, out var xq, out var zq, out var xq1, out var zq1);
            point.ScalarAccumulate(point.U, part + 1, out var xq2, out var zq2, out _, out var _);

            var u0 = point.Recover(xq, zq);

            var u1 = point.Recover(xq1, zq1);
            var u2 = point.Recover(xq2, zq2);
            (u1 == u2).AssertTrue();
            (q1.U == u2).AssertTrue();

            var v0 = point.GetV(u0, true);
            var s = new CurveX448(u0, v0);
            var s1 = s.Add(point);

            (s1.U == u1).AssertTrue();

            var v1a = point.GetV(u1, true);
            var v1b = point.GetV(u1, false);


            var v1 = point.GetV(u1, !s1.V.IsEven);
            (s1.V == v1).AssertTrue();


            var p1 = point.MultiplySigned(part);
            CheckCurve(p1);


            var p2 = point.MultiplySigned(total - part);
            CheckCurve(p2);

            var p3 = p1.Add(p2);
            CheckCurve(p3);

            var p3test = point.MultiplySigned(total);
            CheckCurve(p3test);

            (p3.U == p3test.U).AssertTrue();
            (p3.V == p3test.V).AssertTrue();
            }


        bool CheckCurve(CurveMontgomery curve) {
            bool? odd = ((curve.V) & 1) == 1;
            var vtest = curve.GetV(odd);

            (curve.V == vtest).AssertTrue();

            return true;
            }


        }
    }
