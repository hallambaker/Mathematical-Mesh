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


public class Dilithium : IPolynomial {

    public const int SEEDBYTES = 32;
    public const int CRHBYTES = 48;
    public int N =>  256;

    const int mont = -4186625;
    const int qinv = 58728449 ;
    const int q = 8380417;



    public int Q => q;
    public int D => 13;
    public int ROOT_OF_UNITY => 1753;

    public  int K { get; }
    public  int L { get; }
    public  int ETA { get; }
    public  int TAU { get; }

    public   int BETA { get; }
    public  int GAMMA1 { get; }
    public  int GAMMA2{ get; }
    public  int OMEGA{ get; }
    public DilithiumMode Mode { get; }

    int Index { get; }
    int[] MODEs = new int[] { 2, 3, 5};


    public const int GAMMA_17 = (1 << 17);
    public const int GAMMA_19 = (1 << 19);

    readonly int[] Ks =         new int[] { 4, 6, 8 };
    readonly int[] Ls =         new int[] { 4, 5, 7 };
    readonly int[] ETAs =       new int[] { 2, 4, 2 };
    readonly int[] TAUs =       new int[] { 39, 49, 60 };

    readonly int[] BETAs =      new int[] { 78, 196, 120 };
    readonly int[] GAMMA1s =    new int[] { GAMMA_17, GAMMA_19, GAMMA_19 };
    readonly int[] GAMMA2s =    new int[] { ((q - 1) / 88), ((q - 1) / 32), ((q - 1) / 32) };
    readonly int[] OMEGAs =     new int[] { 80, 55, 75 };

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


    public static (byte[], byte[]) GenerateKeypair(byte[] seed) {
        return (null, null);
        }


    /// <summary>
    /// Montgomery reduction according to <see cref="q"/>. Changed return
    /// type to int since this appears more consistent with use in the code.
    /// </summary>
    /// <param name="a">The value to reduce.</param>
    /// <returns>The Montgomery reduction.</returns>
    public static int MontgomeryReduce(long a) {
        int t = (int)(a * qinv);
        return (int) (a - ((long)t * q) >> 32);
        }



    }


public class DilithiumPublic : Dilithium {

    static DilithiumMode GetMode(int? length) => DilithiumMode.Mode5;

    public DilithiumPublic(byte[] publicKey) : base(GetMode(publicKey?.Length)) {
        }

    public bool Verify(byte[] message, byte[] signature) => false;


    }

public class DilithiumPrivate : DilithiumPublic {

    static DilithiumMode GetMode(int length) => DilithiumMode.Mode5;

    public DilithiumPrivate(byte[] privateKey) : base(privateKey) {
        }

    public byte[] Sign(byte[] message) => null;


    }