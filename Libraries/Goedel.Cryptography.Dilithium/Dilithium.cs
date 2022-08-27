using Goedel.Cryptography.Algorithms;
using Goedel.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Cryptography.PQC;


public enum DilithiumMode {
    Mode2 = 0,
    Mode3 = 1,
    Mode5 = 2
    }


public class Dilithium : IDilithium {

    public const int SEEDBYTES = 32;
    public const int CRHBYTES = 48;
    public int N => 256;

    public int ROOT_OF_UNITY => 1753;

    public int K { get; }
    public int L { get; }
    public int ETA { get; }
    public int TAU { get; }

    public int BETA { get; }
    public int GAMMA1 { get; }
    public int GAMMA2 { get; }
    public int OMEGA { get; }
    public DilithiumMode Mode { get; }

    int Index { get; }
    int[] MODEs = new int[] { 2, 3, 5 };

    readonly int[] Ks = new int[] { 4, 6, 8 };
    readonly int[] Ls = new int[] { 4, 5, 7 };
    readonly int[] ETAs = new int[] { 2, 4, 2 };
    readonly int[] TAUs = new int[] { 39, 49, 60 };

    readonly int[] BETAs = new int[] { 78, 196, 120 };
    readonly int[] GAMMA1s = new int[] { IDilithium.GAMMA_17, IDilithium.GAMMA_19, IDilithium.GAMMA_19 };
    readonly int[] GAMMA2s = new int[] { IDilithium.GAMMA_2_88, IDilithium.GAMMA_2_32, IDilithium.GAMMA_2_32 };
    readonly int[] OMEGAs = new int[] { 80, 55, 75 };


    public static Dilithium Mode2 { get; } 
    public static Dilithium Mode3 { get; } 
    public static Dilithium Mode5 { get; } 


    static Dilithium() {
        // Do a one time initialization of the parameter presets on assembly load.
        Mode2 = new Dilithium(DilithiumMode.Mode2);
        Mode3 = new Dilithium(DilithiumMode.Mode3);
        Mode5 = new Dilithium(DilithiumMode.Mode5);
        }

    public Dilithium(DilithiumMode mode) {
        Mode = mode;
        Index = (int)mode;
        K = Ks[Index];
        L = Ls[Index];
        ETA = ETAs[Index];
        TAU = TAUs[Index];
        BETA = BETAs[Index];
        GAMMA1 = GAMMA1s[Index];
        GAMMA2 = GAMMA2s[Index];
        OMEGA = OMEGAs[Index];
        }


    public static (byte[], byte[]) GenerateKeypair(Dilithium parameters, byte[]? seed = null) {


        //Get randomness for rho, rhoprime and key
        seed ??= Platform.GetRandomBytes(SEEDBYTES);
        var seedbuff = SHAKE256.Process(seed, 8*SEEDBYTES);

        var rho = seedbuff.Extract(0, SEEDBYTES);
        var rhoPrime = seedbuff.Extract(SEEDBYTES, SEEDBYTES);
        var key = seedbuff.Extract(SEEDBYTES*2, SEEDBYTES);


        var mat = PolynomialMatrixInt32.MatrixExpandFromSeed(parameters, rho);
        var s1 = parameters.UniformEta(rhoPrime, 0);
        var s2 = parameters.UniformEta(rhoPrime, parameters.L);


        // Ensure all arrays with woroking data are cleared on exit.
        Platform.Wipe(seedbuff, rho, rhoPrime, key);
        Platform.Dispose(mat);


        // Matrix-vector multiplication
        var s1hat = s1.Copy();
        s1hat.NTT();
        var t1 = mat.MatrixPointwiseMontgomery(s1hat);
        t1.Reduce();
        t1.InvNTT2Mont();

        // Add error vector s2
        t1.Add(s2);

        // Extract t1 and write public key
        t1.Caddq();
        var t0 = t1.Power2Round();

        var pk = DilithiumPublic.Pack(rho, t1);

        // Compute CRH(rho, t1) and write secret key
        var tr = DilithiumPublic.CRH(pk, CRHBYTES);
        var sk = DilithiumPrivate.Pack(rho, tr, key, t0, s1, s2);
        return (pk, sk);
        }





    public PolynomialVectorInt32 UniformGamma1(byte[] seed, int nonce) {
        var result = new PolynomialVectorInt32(this);
        result.UniformGamma1(seed, nonce);
        return result;
        }


    public PolynomialVectorInt32 UniformEta(byte[] seed, int nonce) {
        var result = new PolynomialVectorInt32(this);
        result.UniformEta(seed, nonce);
        return result;
        }

    }
