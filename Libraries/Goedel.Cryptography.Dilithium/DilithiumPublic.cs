using Goedel.Test;

namespace Goedel.Cryptography.PQC;

public class DilithiumPublic : Dilithium {

    byte[] rho { get; }

    PolynomialVectorInt32 T1 { get; }

    byte[] muPK { get; }


    static DilithiumMode GetMode(int? length) => DilithiumMode.Mode5;

    public DilithiumPublic(byte[] publicKey) : base(GetMode(publicKey?.Length)) {
        rho = null;
        T1 = null;
        muPK = null;
        }


    public bool Verify(byte[] message, byte[] signature) {

        if (!UnpackSignature(signature, out var c, out var z, out var h)) {
            return false;
            }

        if (z.Chknorm(GAMMA1 - BETA)) {
            return false;
            }

        // Compute CRH(CRH(rho, t1), msg)
        var mu = SHAKE256.GetBytes(CRHBYTES, muPK, message);


        // Matrix-vector multiplication; compute Az - c2^dt1
        var cp = new PolynomialInt32(this);
        cp.Challenge(c);
        var mat = PolynomialMatrixInt32.MatrixExpandFromSeed(this, rho);
        
        z.NTT();
        var w1 = mat.MatrixPointwiseMontgomery(z);

        cp.NTT();
        var t1 = T1.Copy();
        t1.ShiftLeft();
        t1.NTT();

        cp.PointwisePolyMontgomery(z, t1);

        w1.Sub(t1);
        w1.Reduce();
        w1.InvNTT2Mont();


        // Reconstruct w1
        w1.Caddq();
        w1.UseHint(h);
        var buf = w1.PackW1();

        // Call random oracle and verify challenge
        var c2 = SHAKE256.GetBytes(CRHBYTES, mu, buf);
        return (c.IsEqualTo (c2));
        }


    public bool UnpackSignature (byte[] signature,
        out byte[] c, out PolynomialVectorInt32 v, out PolynomialVectorInt32 h) => throw new NYI();

    public static byte[] Pack(byte[] rho, PolynomialVectorInt32 t1) {
        throw new NYI();
        }




    public static byte[] CRH(byte[] pk, int length) {
        throw new NYI();
        }






    }
