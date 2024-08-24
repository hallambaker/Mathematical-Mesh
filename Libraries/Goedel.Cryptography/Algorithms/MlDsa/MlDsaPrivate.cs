namespace Goedel.Cryptography.PQC;


/// <summary>
/// Dilithium private key.
/// </summary>
public class DilithiumPrivate : MLDSA, IDisposable {

    public byte[] PrivateKey { get; }
    byte[] rho { get; }
    byte[] tr { get; }
    byte[] key { get; }
    byte[] mu { get; }
    PolynomialVectorInt32 t0 { get; }
    PolynomialVectorInt32 s1 { get; }
    PolynomialVectorInt32 s2 { get; }
    PolynomialMatrixInt32 mat { get; }

    #region // Implement IDisposable
    /// <summary>
    /// Dispose method, frees all resources.
    /// </summary>
    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
        }

    bool disposed = false;
    /// <summary>
    /// Dispose method, frees resources when disposing, 
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing) {
        if (disposed) {
            return;
            }

        if (disposing) {
            Disposing();
            }

        disposed = true;
        }

    /// <summary>
    /// Destructor.
    /// </summary>
    ~DilithiumPrivate() {
        Dispose(false);
        }

    /// <summary>
    /// The class specific disposal routine.
    /// </summary>
    protected virtual void Disposing() {
        Platform.Wipe();
        Platform.Dispose();
        }

    #endregion

    static DilithiumMode GetMode(int length) {
        if (length == MLDSA.Mode5.PrivateKeyBytes) {
            return DilithiumMode.Mode5;
            }
        if (length == MLDSA.Mode3.PrivateKeyBytes) {
            return DilithiumMode.Mode3;
            }
        if (length == MLDSA.Mode2.PrivateKeyBytes) {
            return DilithiumMode.Mode2;
            }

        throw new NYI();
        }

    /// <summary>
    /// Constructor, create instance from packed private key bytes
    /// <paramref name="privateKey"/>.
    /// </summary>
    /// <param name="privateKey">The private key bytes.</param>
    public DilithiumPrivate(byte[] privateKey) : base(GetMode(privateKey.Length)) {
        PrivateKey = privateKey;
        var offset = 0;

        // Unpack key here
        rho = privateKey.Extract(ref offset, SeedBytes);

        key = privateKey.Extract(ref offset, SeedBytes);
        tr = privateKey.Extract(ref offset, TrBytes);

        s1 = GetVectorL(true);
        for (var i = 0; i < s1.Polynomials.Length; i++) {
            s1.Polynomials[i].UnpackEta(privateKey, ref offset);
            }
        //s1.GetHash("Recover S1:  6871-6921-BD10");


        s2 = GetVectorK(true);
        for (var i = 0; i < s2.Polynomials.Length; i++) {
            s2.Polynomials[i].UnpackEta(privateKey, ref offset);
            }
        //s2.GetHash("Recover S2:  EFAD-D95F-F68C");


        t0 = GetVectorK(true);
        for (var i = 0; i < t0.Polynomials.Length; i++) {
            t0.Polynomials[i].UnpackT0(privateKey, ref offset);
            }
        //t0.GetHash("Recover t0:  D03F-7BE4-914D");


        // Expand matrix and transform vectors
        mat = PolynomialMatrixInt32.MatrixExpandFromSeed(this, rho);
        //mat.GetHash("Recover: Matrix  0696-9C1B-30B1");

        s1.NTT();
        s2.NTT();
        t0.NTT();

        }

    /// <summary>
    /// Sign the message <paramref name="message"/> and return the signature 
    /// bytes.
    /// </summary>
    /// <param name="message">The message to sign.</param>
    /// <returns>The signature bytes.</returns>
    public byte[] Sign(byte[] message) {

        var mu = SHAKE256.GetBytes(MrsBytes, tr, message);
        var rhoprime = SHAKE256.GetBytes(PrsBytes, key, mu);

        var nonce = 0;

        while (true) {
            while (true) {
                //Console.WriteLine();
                //Console.WriteLine($"*** Start {nonce}");
                //Sample intermediate vector y 

                var y = GetVectorL(true);
                y.UniformGamma1(rhoprime, nonce++);
                var z = y.Copy();
                z.NTT();

                // Matrix-vector multiplication
                var w1 = mat.MatrixPointwiseMontgomery(z);
                w1.InvNTT2Mont();

                // Decompose w and call the random oracle
                w1.Caddq();

                var w0 = w1.Decompose();
                var sig1 = w1.PackW1();

                var sig = SHAKE256.GetBytes(SeedBytes, mu, sig1);
                var cp = new PolynomialInt32(this);
                cp.Challenge(sig);
                cp.NTT();

                z.PointwisePolyMontgomery(cp, s1);
                z.InvNTT2Mont();
                z.Add(y);
                z.Reduce();
                if (z.Chknorm(Gamma1 - Beta)) {
                    //Console.WriteLine("$$ Reject z");
                    break;
                    }

                // Check that subtracting cs2 does not change high bits of w and low bits
                // do not reveal secret information
                var h = GetVectorK(true);
                h.PointwisePolyMontgomery(cp, s2);
                h.InvNTT2Mont();
                w0.Sub(h);
                w0.Reduce();
                if (w0.Chknorm(Gamma2 - Beta)) {
                    //Console.WriteLine("$$ Reject w0");
                    break;
                    }

                // Compute hints for w1
                h.PointwisePolyMontgomery(cp, t0);
                h.InvNTT2Mont();
                h.Reduce();
                if (h.Chknorm(Gamma2)) {
                    //Console.WriteLine("$$ Reject h");
                    break;
                    }

                w0.Add(h);
                w0.Caddq();

                var n = h.MakeHint(w0, w1);
                if (n > OMEGA) {
                    //Console.WriteLine("$$ Reject Omega");
                    break;
                    }
                // Write signature and exit loop.

                return PackSignature(sig, message, z, h);
                }
            }
        }

    /// <summary>
    /// Pack the signature parameters and return the resulting byte array.
    /// </summary>
    /// <param name="sig">The signature.</param>
    /// <param name="message">The message.</param>
    /// <param name="z">The Z vector.</param>
    /// <param name="h">The hints vector.</param>
    /// <returns>The packed byte array.</returns>
    public byte[] PackSignature(byte[]sig, byte[] message, PolynomialVectorInt32 z, PolynomialVectorInt32 h) {
        //var result = new byte[SignatureBytes+ message.Length];
        var result = new byte[SignatureBytes];
        var offset = 0;

        sig.Append(result, ref offset);
        for (var i = 0; i < z.Polynomials.Length; i++) {
            z.Polynomials[i].PackZ(result, ref offset);
            }


        var k = 0;
        for (var p = 0; p < h.Polynomials.Length; p++) {
            for (var c = 0; c < N; c++) {
                if (h.Polynomials[p].Coefficients[c] != 0) {
                    result[offset+ k++] = (byte)c;
                    }
                }
            result[offset + OMEGA + p] = (byte)k;
            }
        offset = SignatureBytes;
        //message.Append(result, ref offset);
        return result;
        }


    }