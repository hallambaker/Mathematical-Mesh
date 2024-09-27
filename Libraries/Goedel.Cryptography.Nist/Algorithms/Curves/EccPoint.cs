using System.Security.Cryptography;

namespace Goedel.Cryptography.Nist;

///<summary>A point on a prime curve.</summary> 
public class EccPoint {

    ///<summary>The curve.</summary> 
    public PrimeCurve Curve { get; }

    ///<summary>If true, this is the infinityh point.</summary> 
    public bool Infinity { get; } = false;

    /// <summary>
    /// X Coordinate of the point
    /// </summary>
    public BigInteger X { get; set; }

    /// <summary>
    /// Y Coordinate of the point
    /// </summary>
    public BigInteger Y { get; set; }


    public EccPoint() {

        }

    public EccPoint(PrimeCurve curve, string inf) {
        Infinity = true;
        Curve = curve;
        }

    public EccPoint(PrimeCurve curve, BigInteger x, BigInteger y) {
        Curve = curve;
        X = x;
        Y = y;
        }

    public bool Equals(EccPoint b) {
        // Both points are infinity
        if (this.Infinity && b.Infinity) {
            return true;
            }

        // One point is infinity and the other is not
        if (this.Infinity || b.Infinity) {
            return false;
            }

        // Compare (x,y) values
        if (this.X == b.X && this.Y == b.Y) {
            return true;
            }

        return false;
        }
    }

