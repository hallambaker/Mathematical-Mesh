namespace Goedel.Cryptography.PQC;

public class DilithiumPrivate : Dilithium, IDisposable {

    byte[] PrivateKey { get; }
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




    static DilithiumMode GetMode(int length) => DilithiumMode.Mode5;






    public DilithiumPrivate(byte[] privateKey) : base(GetMode(privateKey.Length)) {
        PrivateKey = privateKey;

        // Unpack key here
        rho = null;
        tr = null;
        key = null;
        mu = null;

        t0 = null;
        s1 = null;
        s2 = null;

        // Expand matrix and transform vectors
        mat = PolynomialMatrixInt32.MatrixExpandFromSeed(this, rho);
        s1.NTT();
        s2.NTT();
        t0.NTT();


        }







    public byte[] Sign(byte[] message) {

        var mu = SHAKE256.GetBytes(CRHBYTES, tr, message);
        var rhoprime = DilithiumPublic.CRH(key, SEEDBYTES + CRHBYTES);


        // Loop over 
        while (true) {
            //Sample intermediate vector y 
            var nonce = 0;
            var y = UniformGamma1(rhoprime, nonce);
            var z = y.Copy();

            z.NTT();

            // Matrix-vector multiplication
            var w1 = mat.MatrixPointwiseMontgomery(z);
            w1.InvNTT2Mont();

            // Decompose w and call the random oracle
            w1.Caddq();
            var w0 = w1.Decompose();
            var sig1 = w1.PackW1();

            var sig = SHAKE256.GetBytes(SEEDBYTES, mu, sig1);
            var cp = new PolynomialInt32(this);
            cp.Challenge(sig);
            cp.NTT();

            // Compute z, reject if it reveals secret

            z = cp.PointwisePolyMontgomery(s1);
            z.InvNTT2Mont();
            z.Add(y);
            z.Reduce();
            if (z.Chknorm(GAMMA1 - BETA)) {
                break;
                }

            // Check that subtracting cs2 does not change high bits of w and low bits
            // do not reveal secret information
            var h = cp.PointwisePolyMontgomery(s2);
            h.InvNTT2Mont();
            w0.SubFrom(h);
            w0.Reduce();
            if (w0.Chknorm(GAMMA2 - BETA)) {
                break;
                }

            // Compute hints for w1
            h = cp.PointwisePolyMontgomery(t0);
            h.InvNTT2Mont();
            h.Reduce();
            if (h.Chknorm(GAMMA2)) {
                break;
                }

            w0.Add(h);
            w0.Caddq();

            var n = h.MakeHint(w0, w1);
            if (n > OMEGA) {
                break;
                }
            // Write signature and exit loop.

            return PackSignature(sig, z, h);
            }
        return null; // Will never be reached so do not throw error.
        }


    public static byte[] PackSignature(byte[]sig, PolynomialVectorInt32 z, PolynomialVectorInt32 h) {
        throw new NYI();
        }

    public static byte[] Pack(
            byte[] rho,
            byte[] tr,
            byte[] key,
            PolynomialVectorInt32 t0,
            PolynomialVectorInt32 s1,
            PolynomialVectorInt32 s2) {
        throw new NYI();
        }
    }