namespace Goedel.Cryptography.Nist;

/// <summary>
/// The prime field operator.
/// </summary>
public class PrimeFieldOperator  {
    private readonly BigInteger _m;

    /// <summary>
    /// Constructor, return an instance for the modular field <paramref name="modulo"/>.
    /// </summary>
    /// <param name="modulo">The prime modulus.</param>
    public PrimeFieldOperator(BigInteger modulo) {
        _m = modulo;
        }

    /// <summary>
    /// Add <paramref name="a"/> and <paramref name="b"/> modulo the modulus and 
    /// return the result.
    /// </summary>
    /// <param name="a">First parameter</param>
    /// <param name="b">Second parameter.</param>
    /// <returns><paramref name="a"/> + <paramref name="b"/>.</returns>
    public BigInteger Add(BigInteger a, BigInteger b) {
        return Modulo(a + b);
        }

    /// <summary>
    /// Divide <paramref name="a"/> by <paramref name="b"/> modulo the modulus and 
    /// return the result.
    /// </summary>
    /// <param name="a">First parameter</param>
    /// <param name="b">Second parameter.</param>
    /// <returns><paramref name="a"/> + <paramref name="b"/>.</returns>
    public BigInteger Divide(BigInteger a, BigInteger b) {
        return Multiply(a, Inverse(b));
        }

    /// <summary>
    /// Multiply <paramref name="a"/> and <paramref name="b"/> modulo the modulus and 
    /// return the result.
    /// </summary>
    /// <param name="a">First parameter</param>
    /// <param name="b">Second parameter.</param>
    /// <returns><paramref name="a"/> * <paramref name="b"/>.</returns>
    public BigInteger Multiply(BigInteger a, BigInteger b) {
        return Modulo(a * b);
        }

    /// <summary>
    /// Subtract <paramref name="b"/> from <paramref name="a"/> modulo the modulus and 
    /// return the result.
    /// </summary>
    /// <param name="a">First parameter</param>
    /// <param name="b">Second parameter.</param>
    /// <returns><paramref name="a"/> - <paramref name="b"/>.</returns>
    public BigInteger Subtract(BigInteger a, BigInteger b) {
        return Modulo(a - b);
        }

    /// <summary>
    /// Return the additive inverse of <paramref name="a"/>
    /// </summary>
    /// <param name="a">Input</param>
    /// <returns>-<paramref name="a"/></returns>
    public BigInteger Negate(BigInteger a) {
        return Modulo(_m - a);
        }

    /// <summary>
    /// Return the multiplicative inverse of <paramref name="a"/>
    /// </summary>
    /// <param name="a">Input</param>
    /// <returns>1/<paramref name="a"/></returns>
    public BigInteger Inverse(BigInteger a) {
        return a.ModularInverse(_m);
        }

    /// <summary>
    /// Reduce <paramref name="a"/> by the modulus.
    /// </summary>
    /// <param name="a">Input</param>
    /// <returns>|<paramref name="a"/>|</returns>
    public BigInteger Modulo(BigInteger a) {
        return a.PosMod(_m);
        }


    }

