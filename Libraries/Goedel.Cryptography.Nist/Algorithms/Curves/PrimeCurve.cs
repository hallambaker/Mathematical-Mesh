using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

namespace Goedel.Cryptography.Nist;

/// <summary>
/// Point on a NIST prime curve.
/// </summary>
public class PrimeCurve  {
    private readonly PrimeFieldOperator _operator;

    ///<summary>The cryptographic algorithm ID</summary> 
    public CryptoAlgorithmId CryptoAlgorithmId { get; init; }
    
    ///<summary>The Jose ID.</summary> 
    public string JoseId { get; init; }

    ///<summary>Number of bytes required to encode X and Y.</summary> 
    public int ByteEncoding { get; init; }

    // A = -3 (mod p) for prime curves

    ///<summary>The A coefficient.</summary> 
    public BigInteger CoefficientA { get { return FieldSizeQ - 3; } }

    ///<summary>The B coefficient.</summary> 
    public BigInteger CoefficientB { get; }

    ///<summary>The base point G.</summary> 
    public EccPoint BasePointG { get; }

    ///<summary>The group order.</summary> 
    public BigInteger OrderN { get; }

    ///<summary>The field size.</summary> 
    public BigInteger FieldSizeQ { get; }


    ///<summary>Cofactor is always 1 for a prime curve</summary> 
    public int CofactorH { get { return 1; } }

    /////<summary>CurveType is obviously prime</summary> 
    //public CurveType CurveType { get { return CurveType.Prime; } }

    ///<summary>The curve name</summary> 
    public NistCurve CurveName { get; }

    ///<summary>The key size in bits.</summary> 
    public int KeySize { get; }

    ///<summary>The minimum number of bits required to generate a key.</summary> 
    public int MinimumOutputSize { get; }

    /// <summary>
    /// Constructor, return an instance with the specified parameters.
    /// </summary>
    /// <param name="curveName">The curve name.</param>
    /// <param name="p">The field size, Q.</param>
    /// <param name="b">The b coefficient.</param>
    /// <param name="g">The base point G.</param>
    /// <param name="n">The prime.</param>
    /// <param name="l">Minimum number of bits required to generate a key (defaults to keysize).</param>
    public PrimeCurve(
                    NistCurve curveName, 
                    BigInteger p, 
                    BigInteger b, 
                    EccPoint g, 
                    BigInteger n,
                    int l = -1) {
        CurveName = curveName;

        FieldSizeQ = p;
        CoefficientB = b;
        BasePointG = new EccPoint (this, g.X, g.Y);
        OrderN = n;
        KeySize = OrderN.CountBits();

        MinimumOutputSize = l < 0? KeySize : l;


        _operator = new PrimeFieldOperator(p);
        }

    /// <summary>
    /// Verify that <paramref name="x"/>, <paramref name="y"/> is a point on the 
    /// curve and return a constructed point.
    /// </summary>
    /// <param name="x">The X coordinate.</param>
    /// <param name="y">The Y coordinate.</param>
    /// <returns>The verified point.</returns>
    public EccPoint GetPointVerified(BigInteger x, BigInteger y) {
        var point = new EccPoint(this, x, y);
        // Check that point exists in the field.
        PointExistsInField(point).AssertTrue(CryptographicException.Throw);
        // Check that point is on the curve.
        PointExistsOnCurve(point).AssertTrue(CryptographicException.Throw);
        return point;
        }

    /// <summary>
    /// Point add operation.
    /// </summary>
    /// <param name="pointA">First point</param>
    /// <param name="pointB">Second Point</param>
    /// <returns><paramref name="pointA"/>+ <paramref name="pointB"/>.</returns>
    public EccPoint Add(EccPoint pointA, EccPoint pointB) {
        // Any point added to infinity is itself
        if (pointA.Infinity) {
            return pointB;
            }

        // Any point added to infinity is itself
        if (pointB.Infinity) {
            return pointA;
            }

        // Any point added to its inverse is infinity
        if (pointA.Equals(Negate(pointB))) {
            return new EccPoint(this, "infinity");
            }

        // Cannot add two identical points, use Double instead
        if (pointA.Equals(pointB)) {
            return Double(pointA);
            }

        var numerator = _operator.Subtract(pointB.Y, pointA.Y);
        var denominator = _operator.Subtract(pointB.X, pointA.X);
        var lambda = _operator.Divide(numerator, denominator);

        var x = _operator.Subtract(_operator.Subtract(_operator.Multiply(lambda, lambda), pointA.X), pointB.X);
        var y = _operator.Subtract(_operator.Multiply(_operator.Subtract(pointA.X, x), lambda), pointA.Y);

        return new EccPoint(this, x, y);
        }

    /// <summary>
    /// Point negation operation.
    /// </summary>
    /// <param name="point">The point to negate.</param>
    /// <returns>-<paramref name="point"/></returns>
    public EccPoint Negate(EccPoint point) {
        if (point.Infinity) {
            return point;
            }

        // Negate the point, - (x, y) == (x, -y), but -1 * y (mod q) == q - y
        return new EccPoint(this, point.X, _operator.Negate(point.Y));
        }

    /// <summary>
    /// Point subtract operation.
    /// </summary>
    /// <param name="pointA">First point</param>
    /// <param name="pointB">Second Point</param>
    /// <returns><paramref name="pointA"/>- <paramref name="pointB"/>.</returns>
    public EccPoint Subtract(EccPoint pointA, EccPoint pointB) {
        return Add(pointA, Negate(pointB));
        }

    /// <summary>
    /// Point double operation.
    /// </summary>
    /// <param name="point">The point to double.</param>
    /// <returns> <paramref name="point"/> + <paramref name="point"/></returns>
    public EccPoint Double(EccPoint point) {
        if ((point.X == 0 && point.Y == 0) || point.Infinity) {
            return point;
            }

        if (point.Y == 0) {
            throw new ArgumentException("Cannot double a point with y = 0");
            }

        var numerator = _operator.Add(_operator.Multiply(_operator.Multiply(3, point.X), point.X), CoefficientA);
        var denominator = _operator.Multiply(2, point.Y);
        var lambda = _operator.Divide(numerator, denominator);

        var x = _operator.Subtract(_operator.Multiply(lambda, lambda), _operator.Multiply(2, point.X));
        var y = _operator.Subtract(_operator.Multiply(_operator.Subtract(point.X, x), lambda), point.Y);

        return new EccPoint(this, x, y);
        }

    /// <summary>
    /// Point multiply operation.
    /// </summary>
    /// <param name="startPoint">First point</param>
    /// <param name="nafBs">Second Point</param>
    /// <returns><paramref name="startPoint"/> *<paramref name="nafBs"/>.</returns>
    private EccPoint Multiply(EccPoint startPoint, NonAdjacentBitString nafBs) {
        var point = new EccPoint(this, "infinity");
        var naBits = nafBs.Bits;

        for (var i = naBits.Length - 1; i >= 0; i--) {
            point = Double(point);
            if (naBits[i] == 1) {
                point = Add(point, startPoint);
                }
            else if (naBits[i] == -1) {
                point = Subtract(point, startPoint);
                }
            }

        return point;
        }
    /// <summary>
    /// Multiply <paramref name="startPoint"/> by <paramref name="scalar"/>.
    /// </summary>
    /// <param name="startPoint">The point.</param>
    /// <param name="scalar">The scalar.</param>
    /// <returns>Returns scalar.Point.</returns>
    public EccPoint Multiply(EccPoint startPoint, BigInteger scalar) {
        // Find scalar within group and convert to NABS, normal modulo here, not on the field, like CAVS
        return Multiply(startPoint, new NonAdjacentBitString(scalar % OrderN));
        }

    /// <summary>
    /// Return true if the point <paramref name="point"/> is on this curve, otherwise, false.
    /// </summary>
    /// <param name="point">The point.</param>
    /// <returns>True if the point <paramref name="point"/> is on this curve, otherwise, false.</returns>
    public bool PointExistsOnCurve(EccPoint point) {
        if (point.Infinity) {
            return true;
            }

        // Point is out of bounds
        if (!PointExistsInField(point)) {
            return false;
            }

        var lhs = _operator.Multiply(point.Y, point.Y);
        var rhs = _operator.Add(_operator.Add(_operator.Multiply(_operator.Multiply(point.X, point.X), point.X), _operator.Multiply(CoefficientA, point.X)), CoefficientB);

        return (lhs == rhs);
        }


    /// <summary>
    /// Return true if the point <paramref name="point"/> exists in the field, otherwise, false.
    /// </summary>
    /// <param name="point">The point.</param>
    /// <returns>True if the point <paramref name="point"/> exists in the field, otherwise, false.</returns>
    public bool PointExistsInField(EccPoint point) {
        if (point.X < 0 || point.X > FieldSizeQ - 1) {
            return false;
            }

        if (point.Y < 0 || point.Y > FieldSizeQ - 1) {
            return false;
            }

        return true;
        }



    }

