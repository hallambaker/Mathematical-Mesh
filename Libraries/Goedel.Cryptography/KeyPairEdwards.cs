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

namespace Goedel.Cryptography;

/// <summary>
/// A key share containing a scalar on an Edwards curve.
/// </summary>
public class KeyShareEdwards : KeyShare {

    }

/// <summary>
/// Base class for Edwards key pairs.
/// </summary>
public abstract class KeyPairEdwards : KeyPairECDH {

    /// <summary>
    /// Begin the process of signing the data <paramref name="data"/> according to the
    /// algorithm specifier <paramref name="algorithmID"/> and optional context value
    /// <paramref name="context"/>.
    /// </summary>
    /// <param name="data">The data to sign</param>
    /// <param name="algorithmID">The specific signature algorithm variant.</param>
    /// <param name="context">Optional context value.</param>
    /// <returns>The signature context.</returns>
    public abstract ThresholdSignatureEdwards SignHashThreshold(byte[] data,
            CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
            byte[] context = null);


    /// <summary>
    /// Split the private key into <paramref name="n"/> shares with a 
    /// threshold <paramref name="t"/>.
    /// </summary>
    /// <param name="n">The number of shares to create.</param>
    /// <param name="t">The number of shares needed to recover the private key.</param>
    /// <returns>The set of key shares.</returns>
    public static KeyShareEdwards[] Split(int n, int t) =>
            Split(n, t);

    /// <summary>
    /// Split the private key into <paramref name="n"/> shares with a 
    /// threshold <paramref name="t"/>.
    /// </summary>
    /// <param name="n">The number of shares to create.</param>
    /// <param name="t">The number of shares needed to recover the private key.</param>
    /// <param name="polynomial">The polynomial parameters.</param>
    /// <returns>The set of key shares.</returns>
    public KeyShareEdwards[] Split(
                int n, int t, out BigInteger[] polynomial) {

        var privateKey = (IKeyAdvancedPrivate as CurveEdwardsPrivate);

        var Shared = new Shared(privateKey.Private,
                privateKey.PublicPoint.DomainParameters.Q);

        var keyshares = new KeyShareEdwards[n];

        for (int i = 0; i < n; i++) {
            keyshares[i] = new KeyShareEdwards() {
                Index = i + 1
                };
            }


        Shared.Split(keyshares, t, out polynomial);
        return keyshares;
        }


    }

/// <summary>
/// Base class for threshold signature coordinator classes.
/// </summary>
public abstract class ThresholdCoordinatorEdwards {

    ///<summary>The curve prime.</summary>
    public abstract BigInteger Prime { get; }

    ///<summary>The scalar signature data value k.</summary>
    public BigInteger K;

    ///<summary>The aggregate point R</summary>
    public CurveEdwards R = null;

    ///<summary>The aggregate scalar s</summary>
    public BigInteger S = 0;

    ///<summary>The public key value.</summary>
    public abstract CurveEdwards PublicKey { get; }

    /// <summary>
    /// Add the share value <paramref name="encodedR"/>
    /// </summary>
    /// <param name="encodedR"></param>
    public abstract void AddShareR(byte[] encodedR);


    /// <summary>
    /// Complete the first round of the signature of the message <paramref name="data"/> 
    /// with optional inputs <paramref name="context"/> and <paramref name="algorithmID"/>.
    /// and return the value of the additive point R in encoded form.
    /// </summary>
    /// <param name="data">The data to sign.</param>
    /// <param name="algorithmID">The signature algorithm identifier. This is contstrained by
    /// but not determined by the key.</param>
    /// <param name="context">The signature context value (if used).</param>
    /// <returns>The encoded value of the additive point R in encoded form.</returns>
    public byte[] CompleteR(
                byte[] data,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                byte[] context = null) {
        K = PublicKey.GetK(algorithmID, R.Encode(), data, context);

        //Console.WriteLine($"Prime {Prime}");
        //Console.WriteLine($"Public Key {PublicKey.DomainParameters.Q}");

        //Console.WriteLine($"Sign 0");
        //Console.WriteLine($"   K=  {K}");
        //Console.WriteLine($"   R");
        //Console.WriteLine(R.Encode().ToStringBase16FormatHex());
        return R.Encode();
        }

    /// <summary>
    /// Add a signature contribution to the accumulator.
    /// </summary>
    /// <param name="s"></param>
    public void AddShareS(BigInteger s) => S = (S + s).Mod(Prime);

    /// <summary>
    /// Complete the second round of the signature and return the scalar value S
    /// such that S.B == R + k.A
    /// </summary>
    /// <returns>The signature scalar value S.</returns>
    public BigInteger CompleteS(bool validate = true) {
        //Console.WriteLine($"Verify");
        //Console.WriteLine($"   K=  {K}");
        //Console.WriteLine($"   S=  {S}");
        //Console.WriteLine($"   R");
        //Console.WriteLine(R.Encode().ToStringBase16FormatHex());

        if (validate) {
            PublicKey.Verify(K, S, R).AssertTrue(InternalCryptographicException.Throw);
            }
        return S;
        }

    }

/// <summary>
/// Threshold signature coordinator for Ed25519 signature
/// </summary>
public class ThresholdCoordinatorEdwards25519 : ThresholdCoordinatorEdwards {
    ///<summary>The curve prime.</summary>
    public override BigInteger Prime => DomainParameters.Curve25519.Q;

    ///<summary>The public key parameter A.</summary>
    public CurveEdwards25519 A;

    ///<summary>The public key</summary>
    public override CurveEdwards PublicKey => A;

    /// <summary>
    /// Constructor for the public key <paramref name="a"/>.
    /// </summary>
    /// <param name="a">The public key point.</param>
    public ThresholdCoordinatorEdwards25519(CurveEdwards25519 a) => A = a;

    /// <summary>
    /// Add the share value <paramref name="encodedR"/>
    /// </summary>
    /// <param name="encodedR"></param>
    public override void AddShareR(byte[] encodedR) {

        var shareR = CurveEdwards25519.Decode(encodedR);
        R = R == null ? shareR : R.Add(shareR);
        }

    }

/// <summary>
/// Threshold signature coordinator for Ed448signature
/// </summary>
public class ThresholdCoordinatorEdwards448 : ThresholdCoordinatorEdwards {
    ///<summary>The curve prime.</summary>
    public override BigInteger Prime => DomainParameters.Curve448.Q;

    ///<summary>The public key parameter A.</summary>
    public CurveEdwards448 A;

    ///<summary>The public key</summary>
    public override CurveEdwards PublicKey => A;

    /// <summary>
    /// Constructor for the public key <paramref name="a"/>.
    /// </summary>
    /// <param name="a">The public key point.</param>
    public ThresholdCoordinatorEdwards448(CurveEdwards448 a) => A = a;

    /// <summary>
    /// Add the share value <paramref name="encodedR"/>
    /// </summary>
    /// <param name="encodedR"></param>
    public override void AddShareR(byte[] encodedR) {

        var shareR = CurveEdwards448.Decode(encodedR);
        R = R == null ? shareR : R.Add(shareR);
        }

    }

/// <summary>
/// Base class for threshold signature context.
/// </summary>
public abstract class ThresholdSignatureEdwards {

    ///<summary>The public point R.</summary>
    public CurveEdwards PublicR;

    ///<summary>The secret scalar r</summary>
    public BigInteger PrivateR;

    ///<summary>The private key value.</summary>
    protected BigInteger privateKey;

    ///<summary>The scalar value representing the data being signed.</summary>
    public BigInteger K;

    /// <summary>
    /// Base constructor, specifying the prime value <paramref name="prime"/>
    /// </summary>
    /// <param name="prime">The prime value.</param>
    protected ThresholdSignatureEdwards(BigInteger prime) =>
        PrivateR = BigNumber.Random(prime);

    /// <summary>
    /// Complete the threshold signature contribution
    /// </summary>
    /// <param name="aggregateR">The aggregare value of R</param>
    /// <param name="A">The public key value.</param>
    /// <param name="data">The data to sign.</param>

    /// <param name="lagrange">The Lagrange cofactor</param>
    /// <param name="algorithmID">The algorithm identifier for the signature.</param>
    /// <param name="context">The signature context information.</param>
    /// <param name="prehash">If true, perform prehashing.</param>
    /// <returns>The threshold signature contribution.</returns>
    public abstract BigInteger GetS(
                byte[] aggregateR,
                CurveEdwards A,
                byte[] data,
                BigInteger lagrange,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                byte[] context = null,
                bool prehash = true);

    }

/// <summary>
/// Threshold signature context for Ed25518 curve.
/// </summary>
public class ThresholdSignatureEdwards25519 : ThresholdSignatureEdwards {

    /// <summary>
    /// Constructor for the private key contribution <paramref name="key"/>
    /// </summary>
    /// <param name="key">The private key contribution.</param>
    public ThresholdSignatureEdwards25519(CurveEdwards25519Private key) :
            base(DomainParameters.Curve25519.Q) {
        privateKey = key.Private;
        PublicR = CurveEdwards25519.Base.Multiply(PrivateR);
        }

    /// <summary>
    /// Complete the threshold signature contribution
    /// </summary>
    /// <param name="aggregateR">The aggregare value of R</param>
    /// <param name="A">The public key value.</param>
    /// <param name="data">The data to sign.</param>

    /// <param name="lagrange">The Lagrange cofactor</param>
    /// <param name="algorithmID">The algorithm identifier for the signature.</param>
    /// <param name="context">The signature context information.</param>
    /// <param name="prehash">If true, perform prehashing.</param>
    /// <returns>The threshold signature contribution.</returns>

    public override BigInteger GetS(
                byte[] aggregateR,
                CurveEdwards A,
                byte[] data,
                BigInteger lagrange,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                byte[] context = null,
                bool prehash = true) {

        var domain = CurveEdwards25519.Dom2(algorithmID, context);
        var k = A.GetK(domain, aggregateR, data);

        var scalar = lagrange == 1 ? privateKey : (privateKey * lagrange).Mod(DomainParameters.Curve25519.Q);

        var sk = (k * scalar).Mod(DomainParameters.Curve25519.Q);
        var s = (PrivateR + sk).Mod(DomainParameters.Curve25519.Q);
        PrivateR = 0; // prevent reuse of the private additive scalar.

        return s;
        }


    }

/// <summary>
/// Threshold signature context for Ed448 curve.
/// </summary>
public class ThresholdSignatureEdwards448 : ThresholdSignatureEdwards {

    /// <summary>
    /// Constructor for the private key contribution <paramref name="key"/>
    /// </summary>
    /// <param name="key">The private key contribution.</param>
    public ThresholdSignatureEdwards448(CurveEdwards448Private key) :
            base(DomainParameters.Curve448.Q) {
        privateKey = key.Private;
        PublicR = CurveEdwards448.Base.Multiply(PrivateR);
        }

    /// <summary>
    /// Complete the threshold signature contribution
    /// </summary>
    /// <param name="aggregateR">The aggregare value of R</param>
    /// <param name="A">The public key value.</param>
    /// <param name="data">The data to sign.</param>

    /// <param name="lagrange">The Lagrange cofactor</param>
    /// <param name="algorithmID">The algorithm identifier for the signature.</param>
    /// <param name="context">The signature context information.</param>
    /// <param name="prehash">If true, perform prehashing.</param>
    /// <returns>The threshold signature contribution.</returns>

    public override BigInteger GetS(
                byte[] aggregateR,
                CurveEdwards A,
                byte[] data,
                BigInteger lagrange,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                byte[] context = null,
                bool prehash = true) {

        var domain = CurveEdwards448.Dom4(algorithmID, context);
        var k = A.GetK(domain, aggregateR, data);

        var scalar = lagrange == 1 ? privateKey : (privateKey * lagrange).Mod(DomainParameters.Curve25519.Q);

        var sk = (k * scalar).Mod(DomainParameters.Curve448.Q);
        var s = (PrivateR + sk).Mod(DomainParameters.Curve448.Q);
        PrivateR = 0; // prevent reuse of the private additive scalar.

        return s;
        }
    }
