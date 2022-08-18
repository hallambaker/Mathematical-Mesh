

using Goedel.Utilities;

namespace Goedel.Cryptography.PQC;


public class Test {

    static void Main() {

        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Gen martix");

        var kyber = new Kyber1024();
        var seed = new byte[Kyber.SymBytes];


        //var matrix = Matrix.GenerateMatrix(kyber.K, seed);
        //Console.WriteLine(matrix.GetHash());
        //// Value for Seed={0} = 3DF0-CEDB-8BAB-CF8D-348B-B746-5199-B357-CC28-D36B-A426-2D3B-C8AE-DD3D-DC39-2364

        //var ap1 = kyber.GetNoiseEta1(seed, 0);
        //Console.WriteLine(ap1.GetHash());

        //var ap2 = kyber.GetNoiseEta2(seed, 0);
        //Console.WriteLine(ap2.GetHash());

        //ap2.PolyNTT();
        //Console.WriteLine(ap2.GetHash());

        //ap2.PolyInvNTT();
        //Console.WriteLine(ap2.GetHash());
        
        var seed2 = FakeRand(Kyber.SymBytes);
        var (publicKey, privateKey) = kyber.KeyPair(seed2);


        DumpBufferHex(publicKey);
        DumpBufferHex(privateKey);
        }

    public static byte[] FakeRand(int len) {
        var result = new byte[len];
        FakeRand(result);
        return result;
        }


    public static void FakeRand(byte[] buffer) {
        for (int i = 0; i < buffer.Length; i++) {
            buffer[i]=(byte)i;
            }

        }


    public static void DumpBufferHex(byte[] buffer, int length = -1) {
        Console.WriteLine(buffer.ToStringBase16(length: length, Format: ConversionFormat.Dash4));
        }

    public static void DumpBufferFingerprint(byte[] buffer) {
        Console.WriteLine(GetBufferFingerprint(buffer));
        }

    public static string GetBufferFingerprint(byte[] buffer) {
        var hash = SHAKE128.Process(buffer);
        return hash.ToStringBase16(Format: ConversionFormat.Dash4);
        }




    static string GetHash(PolynomialMatrix data) => data.GetHash();
    static string GetHash(PolynomialVector data) => data.GetHash();
    static string GetHash(Polynomial data) => data.GetHash();
    static string GetHash(byte[] data) => GetBufferFingerprint(data);

    }
