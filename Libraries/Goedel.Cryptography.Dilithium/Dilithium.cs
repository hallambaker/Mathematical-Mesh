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


public class Dilithium {

    public const int SEEDBYTES = 32;
    public const int CRHBYTES = 48;
    public const int N = 256;
    public const int Q = 8380417;
    public const int D = 13;
    public const int ROOT_OF_UNITY = 1753;

    public  int K { get; }
    public  int L { get; }
    public  int ETA { get; }
    public  int TAU { get; }

    public   int BETA { get; }
    public  int GAMMA1 { get; }
    public  int GAMMA2{ get; }
    public  int OMEGA{ get; }


    int Index { get; }
    int[] MODEs = new int[] { 2, 3, 5};

    readonly int[] Ks =         new int[] { 4, 6, 8 };
    readonly int[] Ls =         new int[] { 4, 5, 7 };
    readonly int[] ETAs =       new int[] { 2, 4, 2 };
    readonly int[] TAUs =       new int[] { 39, 49, 60 };

    readonly int[] BETAs =      new int[] { 78, 196, 120 };
    readonly int[] GAMMA1s =    new int[] { (1 << 17), (1 << 19), (1 << 19) };
    readonly int[] GAMMA2s =    new int[] { ((Q - 1) / 88), ((Q - 1) / 32), ((Q - 1) / 32) };
    readonly int[] OMEGAs =     new int[] { 80, 55, 75 };

    public Dilithium(DilithiumMode mode) {
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