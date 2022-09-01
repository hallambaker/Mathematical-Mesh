

using Goedel.Utilities;
using Goedel.Cryptography.PQC;
using Goedel.Cryptography.Algorithms;
using Goedel.Test;
using System;

namespace Goedel.Cryptography.PQC;


/// <summary>
/// Class containing test stubs DELETE
/// </summary>
public class Test {

    static void Main() {

        //for (int i = -50; i < 50; i++) {
        //    var x = i << 20;
        //    var y = x & 42;
        //    Console.WriteLine($"{i} {x} {y}");
        //    }




        var dilithium = new Dilithium(DilithiumMode.Mode5);


        var seed = new byte[Dilithium.SeedBytes];
        var keySeed = new byte[Dilithium.CrhBytes];
        var sm = RandomBytes(Dilithium.CrhBytes);

        //var a = new PolynomialInt32(dilithium);

        //a.UniformEta(seed, 0);
        //a.GetHash("UniformEta = FB9D-D633-D4D9-AEE2");

        //var mat = PolynomialMatrixInt32.MatrixExpandFromSeed(dilithium, seed);
        //mat.GetHash("MatrixExpand = AD45-A785-C0D1-");

        ////var a = mat.Vectors[0].Polynomials[0];
        //var b = mat.Vectors[0].Polynomials[1];
        //var c = mat.Vectors[0].Polynomials[2];




        //a.UniformGamma1(keySeed, 0);
        //a.GetHash("UniformGamma1 = 46D9-90D3-28CF-3F23");

        //a.NTT();
        //a.GetHash("NTT = 7A2B-EE89-795E-6D82");

        //a.InvNTT2Mont();
        //a.GetHash("InvnttTomont = 2C87-462C-A37A-B7F5");

        //c.PointwiseMontgomery(a, b);
        //c.GetHash("PointwiseMontgomery = 29BC-1206-8835-39BA");

        //c.Challenge(seed);
        //c.GetHash("Challenge = D001-BC96-6AF4-D12F");

        var matseed = RandomBytes(Dilithium.SeedBytes);
        var (pk, sk) = Dilithium.GenerateKeypair (Dilithium.Mode5, matseed);


        DumpBufferFingerprint(pk, "Public Key: 3EE4-65AE-2807-");
        DumpBufferFingerprint(sk, "Private Key: CA1F-DFA6-EC4A");




        var privateKey = new DilithiumPrivate(sk);
        var signature = privateKey.Sign(sm);
        DumpBufferFingerprint(signature, "Signature: 1ADB-7261-CBAE");

        var publicKey = new DilithiumPublic(pk);
        var verify = publicKey.Verify (signature);
        Console.WriteLine($"Verify {verify}");
        }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="length"></param>
    /// <returns></returns>
    public static byte[] RandomBytes(int length) {
        var result = new byte[length];

        for (var i = 0; i < length; i++) {
            result[i] = (byte)i;
            }

        return result;
        }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="tag"></param>
    /// <param name="length"></param>
    /// <param name="first"></param>
    public static void DumpBufferHex(byte[] buffer, string? tag = null, int length = -1, int first =0) {
        if (tag != null) {
            Console.WriteLine(tag);
            }
        Console.WriteLine(buffer.ToStringBase16(length: length, Format: ConversionFormat.Dash4, first: first));
        }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="length"></param>
    /// <param name="tag"></param>
    public static void DumpBufferFingerprint(byte[] buffer, int length, string? tag = null) {

        var extract = buffer.Extract (0, length);
        DumpBufferFingerprint(extract, $"{tag} / {length}");
        }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="tag"></param>
    public static void DumpBufferFingerprint(byte[] buffer, string? tag = null) {
        if (tag != null) {
            Console.WriteLine(tag);
            }

        Console.WriteLine(GetBufferFingerprint(buffer));
        }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static string GetBufferFingerprint(byte[] buffer) {
        if (buffer == null) {
            return "<null>";
            }

        var hash = SHAKE128.Process(buffer);
        return hash.ToStringBase16(Format: ConversionFormat.Dash4);
        }

    }
