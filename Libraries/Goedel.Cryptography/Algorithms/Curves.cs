using Goedel.Utilities;

using System;
using System.Numerics;

namespace Goedel.Cryptography.Algorithms {

    /// <summary>
    /// Base Class for Elliptic Curve implementations
    /// </summary>
    public abstract class Curve {

        /// <summary>The paameter p</summary>
        public abstract BigInteger Prime { get; }

        }


    /// <summary>
    /// Montgomery Curve [v^2 = u^3 + A*u^2 + u] for 2^255-19
    /// </summary>
    public abstract class CurveMontgomery : Curve {

        /// <summary>The U value (we never use the V value)</summary>
        public BigInteger U { get; set; }

        /// <summary>Size of the modular field in bits.</summary>
        public abstract int Bits { get; }

        /// <summary>The parameter A24</summary>
        public abstract int A24 { get; }


        #region // equality
        /// <summary>
        /// Return the hash code
        /// </summary>
        /// <returns>The hash code value.</returns>
        public override int GetHashCode() => U.GetHashCode();

        /// <summary>
        /// Check points for equality
        /// </summary>
        /// <param name="obj">Other point</param>
        /// <returns>True if the two points are equal (the P and U values are the same), otherwise false.</returns>
        public override bool Equals(object obj) => Equal((CurveMontgomery)obj);

        /// <summary>
        /// Check points for equality
        /// </summary>
        /// <param name="obj">Other point</param>
        /// <returns>True if the two points are equal (the P and U values are the same), otherwise false.</returns>
        public bool Equal(CurveMontgomery obj) => this == obj;

        /// <summary>
        /// Check points for equality
        /// </summary>
        /// <param name="a">First point</param>
        /// <param name="b">Second point</param>
        /// <returns>True if the two points are equal (the P and U values are the same), otherwise false.</returns>
        public static bool operator ==(CurveMontgomery a, CurveMontgomery b) =>
            (a.Prime == b.Prime) & (a.U == b.U);

        /// <summary>
        /// Check points for inequality
        /// </summary>
        /// <param name="a">First point</param>
        /// <param name="b">Second point</param>
        /// <returns>True if the two points are not equal (the P and/or U values are different), otherwise false.</returns>
        public static bool operator !=(CurveMontgomery a, CurveMontgomery b) => !(a == b);
        #endregion

        /// <summary>
        /// Create a point from the specified U value.
        /// </summary>
        /// <param name="U">U value to convert</param>
        /// <returns>Created point</returns>
        public abstract CurveMontgomery Factory(BigInteger U);

        /// <summary>
        /// Multiply a point by a scalar
        /// </summary>
        /// <param name="s">Scalar factor</param>
        /// <returns>The result of the multiplication</returns>
        protected BigInteger ScalarMultiply(BigInteger s) {

            BigInteger x_1 = U;
            BigInteger x_2 = 1;
            BigInteger z_2 = 0;
            BigInteger x_3 = U;
            BigInteger z_3 = 1;
            bool swap = false;

            for (var i = 0; i < Bits; i++) {
                var k_t = ((s >> i) & 1) == 1;
                swap ^= k_t ;
                Cswap(swap, ref x_2, ref x_3);
                Cswap(swap, ref z_2, ref z_3);
                //swap = k_t;

                var A = x_2 + z_2;
                var AA = A * A;
                var B = x_2 - z_2;
                var BB = B * B;
                var E = AA - BB;
                var C = x_3 + z_3;
                var D = x_3 - z_3;
                var DA = D * A;
                var CB = C * B;
                x_3 = (DA + CB) ^ 2;
                z_3 = x_1 * (DA - CB) ^ 2;
                x_2 = AA * BB;
                z_2 = E * (AA + A24 * E);
                }

            Cswap(swap, ref x_2, ref x_3);
            Cswap(swap, ref z_2, ref z_3);
            return (x_2 * (BigInteger.ModPow(z_2, (Prime - 2), Prime))) % Prime;

            }

        /// <summary>
        /// Conditional swap in constant time.
        /// </summary>
        /// <param name="Swap">If false A'=A and B'=B on exit, if true A'=B and B'=A on exit</param>
        /// <param name="A">First parameter</param>
        /// <param name="B">Second parameter</param>
        public static void Cswap(bool Swap, ref BigInteger A, ref BigInteger B) {

            if (Swap) {  // Limit: This should be in constant time
                var Dummy = A;
                A = B;
                B = Dummy;
                }

            }
        


        /// <summary>
        /// Encode the code point.
        /// </summary>
        /// <returns>The encoded format of the point</returns>
        public abstract byte[] Encode();

        /// <summary>
        /// Add two points
        /// </summary>
        /// <param name="Point">Second point</param>
        /// <returns>The result of the addition.</returns>
        public abstract CurveMontgomery Add(CurveMontgomery Point);

        /// <summary>
        /// Add two points
        /// </summary>
        /// <param name="Point">Second point</param>
        /// <returns>The result of the addition.</returns>
        public abstract void Accumulate(CurveMontgomery Point);
        }





    /// <summary>
    /// Edwards Curve [x^2 = (y^2 - 1) / (d y^2 + 1) (mod p)] for 2^255-19
    /// </summary>
    public abstract class CurveEdwards : Curve {

        /// <summary>The X coordinate</summary>
        public BigInteger X { get; set; }

        /// <summary>The Y coordinate</summary>
        public BigInteger Y { get; set; }

        /// <summary>The projected Z coordinate</summary>
        public BigInteger Z { get; set; }


        ///<summary>The modulus, q = 2^255 - 19</summary>
        public abstract BigInteger CurveConstrantD { get; }

        ///<summary>The modulus, q = 2^255 - 19</summary>
        public abstract BigInteger SqrtMinus1 { get; }

        /// <summary>
        /// Add this point to a second point
        /// </summary>
        /// <param name="P2">Second point</param>
        /// <returns>The result of the addition.</returns>
        public abstract CurveEdwards Add(CurveEdwards P2);

        /// <summary>Test to see if two points on a curve are equal</summary>
        /// <param name="Q">The Q parameter of the curve.</param>
        /// <returns>True if the points are equal, otherwise false.</returns>
        public bool Equal(CurveEdwards Q) {


            Assert.True(Q.Prime == Prime);

            if (((X * Q.Z) - (Q.X * Z)).Mod(Prime) != 0) {
                return false;
                }
            if (((Y * Q.Z) - (Q.Y * Z)).Mod(Prime) != 0) {
                return false;
                }
            return true;
            }

        /// <summary>
        /// Recover the X coordinate from the Y value and sign of X.
        /// </summary>
        /// <param name="X0">If true X is odd, otherwise, X is even.</param>
        /// <returns>The X coordinate.</returns>
        public virtual BigInteger RecoverX(bool X0) {
            Assert.True(Y < Prime, InvalidOperation.Throw);
            var x2 = (Y * Y - 1) * (CurveConstrantD * Y * Y + 1).ModularInverse(Prime);
            return x2.Sqrt(Prime, SqrtMinus1, X0);
            }

        /// <summary>Modular multiplicative inverse of Z</summary>
        public BigInteger ZInv => Z.ModularInverse(Prime);

        /// <summary>X translated to fixed coordinates</summary>
        public BigInteger X0 => (X * ZInv).Mod(Prime);

        /// <summary>Y translated to fixed coordinates</summary>
        public BigInteger Y0 => (Y * ZInv).Mod(Prime);

        /// <summary>
        /// Convert back from 3D to 2D representation
        /// </summary>
        /// <param name="Xout">The X value</param>
        /// <param name="Yout">The Y value</param>
        public void Translate(out BigInteger Xout, out BigInteger Yout) {
            Xout = (X * ZInv).Mod(Prime);
            Yout = (Y * ZInv).Mod(Prime);
            }

        /// <summary>
        /// Replace the current point value with the current value added to itself
        /// (used to implement multiply)
        /// </summary>
        public abstract void DoublePoint();

        /// <summary>
        /// Add two points
        /// </summary>
        /// <param name="Point">Second point</param>
        /// <returns>The result of the addition.</returns>
        public abstract void Accumulate(CurveEdwards Point);

        }



    /// <summary>
    /// Specifies the curve parameters for a Montgomery or Edwards Elliptic Curve
    /// v^2 = u^3 + A*u^2 + u
    /// </summary>
    public struct DomainParameters : IEquatable<DomainParameters> {

        /// <summary>The prime field</summary>
        public BigInteger P { get; }

        /// <summary>The number of bits in the prime field</summary>
        public int Bits { get; }

        /// <summary>The Montgomery curve coeffient A</summary>
        public BigInteger A { get; }

        /// <summary>The Montgomery curve coeffient constant = (A-2) / 4</summary>
        public BigInteger A24 { get; }

        /// <summary>The Edwards curve coeffient D</summary>
        public BigInteger D { get; }

        /// <summary>The Montgomery initial point U value</summary>
        public BigInteger U { get; }

        /// <summary>The Edwards curve generator Y coordinate</summary>
        public BigInteger By { get; }

        /// <summary>Square root of -1 mod p.</summary>
        public BigInteger SqrtMinus1 {
            get;
            }


        #region // Equality testing bollocks
        /// <summary>Test to see if the domain parameters are equal.</summary>
        /// <param name="other">The parameters to test against</param>
        /// <returns>True if the parameters are equal, otherwise false.</returns>
        public override bool Equals(object other) {
            if (!(other is DomainParameters)) {
                return false;
                }

            return Equals((DomainParameters)other);
            }

        /// <summary>Test to see if the domain parameters are equal.</summary>
        /// <param name="other">The parameters to test against</param>
        /// <returns>True if the parameters are equal, otherwise false.</returns>
        public bool Equals(DomainParameters other) => this == other;

        /// <summary>Test to see if the domain parameters are equal.</summary>
        /// <param name="p1">First value to test</param>
        /// <param name="p2">Second value to test</param> 
        /// <returns>True if the parameters are equal, otherwise false.</returns>
        public static bool operator ==(DomainParameters p1, DomainParameters p2) => (p1.P == p2.P);

        /// <summary>Test to see if the domain parameters are not equal.</summary>
        /// <param name="p1">First value to test</param>
        /// <param name="p2">Second value to test</param> 
        /// <returns>False if the parameters are equal, otherwise true.</returns>
        public static bool operator !=(DomainParameters p1, DomainParameters p2) => !(p1 == p2);

        /// <summary>
        /// Return a hash code. 
        /// </summary>
        /// <returns>Hash of the prime value.</returns>
        public override int GetHashCode() {
            return P.GetHashCode();
            }
        #endregion




        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="p">The prime.</param>
        /// <param name="A">The curve coefficient.</param>
        /// <param name="U">The Montgomery initial point U value.</param>
        /// <param name="d">The Edwards curve coeffient D</param>
        /// <param name="By">The Edwards curve base point Y value.</param>
        /// <param name="Bits">The number of bits in the prime.</param>
        public DomainParameters(BigInteger p, BigInteger A, BigInteger U, BigInteger d,
                        BigInteger By, int Bits) {
            this.P = p;
            this.A = A;
            this.U = U;
            this.D = d;
            this.By = By;
            A24 = (A - 2) / 4;
            this.Bits = Bits;

            SqrtMinus1 = p.SqrtMinus1();
            }

        static readonly BigInteger Curve25519Prime = BigInteger.Pow(2, 255) - 19;

        static readonly BigInteger CurveConstant25519 = (
            -121665 * (121666.ModularInverse(Curve25519Prime))).Mod(Curve25519Prime);

        static readonly BigInteger Curve25519BaseY = (4 * 5.ModularInverse(Curve25519Prime)) % Curve25519Prime;

        /// <summary>
        /// Montgomery curve parameters for Curve25519S
        /// </summary>
        public static readonly DomainParameters Curve25519 = new DomainParameters(
                Curve25519Prime,
                486662,
                9,
                CurveConstant25519,
                Curve25519BaseY,
                255);

        static readonly BigInteger Curve448BaseY = (
            "298819210078481492676017930443930673437544040154080242095928241" +
            "372331506189835876003536878655418784733982303233503462500531545062" +
            "832660").DecimalToBigInteger();


        /// <summary>
        /// Montgomery parameters for Curve 448
        /// </summary>
        public static readonly DomainParameters Curve448 = new DomainParameters(
                BigInteger.Pow(2, 448) - BigInteger.Pow(2, 224) - 1,
                156326,
                5,
                -39081,
                Curve448BaseY,
                448);




        }

    }
