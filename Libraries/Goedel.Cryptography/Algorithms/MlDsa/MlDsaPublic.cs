

using System.Security.Cryptography.X509Certificates;

namespace Goedel.Cryptography.PQC;

/// <summary>
/// Dilithium public key.
/// </summary>
public class MlDsaPublic : MLDSA {

    byte[] rho { get; }

    PolynomialVectorInt32 T1 { get; }

    byte[] muPK { get; }

    public byte[] PublicKey { get; }

    static MlDsaMode GetMode(int length) {
        if (length == MLDSA.Mode5.PublicKeyBytes) {
            return MlDsaMode.Mode87;
            }
        if (length == MLDSA.Mode3.PublicKeyBytes) {
            return MlDsaMode.Mode65;
            }
        if (length == MLDSA.Mode2.PublicKeyBytes) {
            return MlDsaMode.Mode44;
            }

        throw new NYI();
        }

    /// <summary>
    /// Constructor, create instance from packed public key bytes
    /// <paramref name="publicKey"/>.
    /// </summary>
    /// <param name="publicKey">The public key bytes.</param>
    public MlDsaPublic(byte[] publicKey) : base(GetMode(publicKey.Length)) {
        PublicKey = publicKey;
        var offset = 0;
        rho = publicKey.Extract(ref offset, SeedBytes);

        T1 = GetVectorK(false);
        for (var i = 0; i < T1.Polynomials.Length; i++) {
            T1.Polynomials[i].UnpackT1(publicKey, ref offset);
            }

        muPK = SHAKE256.GetBytes(MrsBytes, publicKey);
        }

    /// <summary>
    /// Verify the signature <paramref name="signature"/>.
    /// </summary>
    /// <param name="signature">The signature and message to verify.</param>
    /// <param name="message">The signed message.</param>
    /// <returns>True if signature isvalid, otherwise false.</returns>
    public bool Verify(byte[] signature, byte[]message) {

        if (!UnpackSignature(signature, out var c, out var z, out var h, out byte[] messageSig)) {
            return false;
            }
        if (z.Chknorm(Gamma1 - Beta)) {
            return false;
            }

        // Compute CRH(CRH(rho, t1), msg)
        var mu = SHAKE256.GetBytes(MrsBytes, muPK, message);

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
        t1.PointwisePolyMontgomery(cp, t1);

        w1.Sub(t1);
        w1.Reduce();
        w1.InvNTT2Mont();

        // Reconstruct w1
        w1.Caddq();
        w1.UseHint(h);
        var buf = w1.PackW1();

        // Call random oracle and verify challenge
        var c2 = SHAKE256.GetBytes(SeedBytes, mu, buf);
        return (c.IsEqualTo (c2));
        }

    /// <summary>
    /// Unpack the signature bytes <paramref name="signature"/> and return the 
    /// corresponding parameters.
    /// </summary>
    /// <param name="signature">The signature bytes.</param>
    /// <param name="sig">The sig parameter.</param>
    /// <param name="v">The Z vector.</param>
    /// <param name="h">The hints vector.</param>
    /// <param name="message">The signed message.</param>
    /// <returns>False if the signature parameters are invalid.</returns>
    public bool UnpackSignature(byte[] signature,
        out byte[] sig, out PolynomialVectorInt32 v, out PolynomialVectorInt32 h, out byte[] message) {
        var offset = 0;

        sig = signature.Extract(ref offset, SeedBytes);

        v = GetVectorL(false);
        for (var i = 0; i < v.Polynomials.Length; i++) {
            v.Polynomials[i].UnpackZ(signature, ref offset);
            }

        h = GetVectorK(false);

        message = Array.Empty<byte>(); // should be optimized away if not needed.

        var k = 0;
        for (var p = 0; p < h.Polynomials.Length; p++) {
            for (var c = 0; c < N; c++) {
                h.Polynomials[p].Coefficients[c] = 0;
                }
            var omegaP = signature[offset + OMEGA + p];


            if ((omegaP < k) || (omegaP > OMEGA)) {
                return false;
                }
            for (var j = k; j < omegaP; j++) {
                var ind = offset + j;
                var s1 = signature[ind];
                var s0 = signature[ind-1];

                if ((j > k) && s1 <= s0) {
                    return false;
                    }
                h.Polynomials[p].Coefficients[s1] = 1;
                }

            k = omegaP;
            }

        // extract the message;
        offset = SignatureBytes;
        //message = signature.Extract(ref offset, signature.Length - offset);

        return true;
        }







    }
