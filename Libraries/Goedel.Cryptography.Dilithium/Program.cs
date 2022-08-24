

using Goedel.Utilities;
using Goedel.Cryptography.PQC;
using Goedel.Cryptography.Algorithms;
using Goedel.Test;
using System;

namespace Goedel.Cryptography.PQC;

public class Test {

    static void Main() {

        var dilithium = new Dilithium(DilithiumMode.Mode5);


        var seed = new byte[Dilithium.SEEDBYTES];
        var keySeed = new byte[Dilithium.CRHBYTES];

        var sm = new byte[Dilithium.CRHBYTES];

        var a = new PolynomialInt32(dilithium);

        a.UniformEta(seed, 0);
        a.GetHash("UniformEta = FB9D-D633-D4D9-AEE2");

        var mat = PolynomialMatrixInt32.MatrixExpand(dilithium, seed);
        mat.GetHash("MatrixExpand = AD45-A785-C0D1-");

        //var a = mat.Vectors[0].Polynomials[0];
        var b = mat.Vectors[0].Polynomials[1];
        var c = mat.Vectors[0].Polynomials[2];




        a.UniformGamma1(keySeed, 0);
        a.GetHash("UniformGamma1 = 46D9-90D3-28CF-3F23");

        a.NTT();
        a.GetHash("NTT = 911B-1F04-6EB5-F5AA");

        a.InvnttTomont();
        a.GetHash("InvnttTomont = F452-754A-4342-6AA8");

        var c2 = a.PointwiseMontgomery(b);
        c2.GetHash("PointwiseMontgomery = C2CF-8BB1-BF77-9E9F");

        var c3 = PolynomialInt32.Challenge(dilithium, seed);
        c3.GetHash("Challenge = D001-BC96-6AF4-D12F");

        var (pk, sk) = Dilithium.GenerateKeypair (keySeed);
        var privateKey = new DilithiumPrivate(sk);

        DumpBufferFingerprint(pk, "Public Key: 3EE4-65AE-2807-");
        DumpBufferFingerprint(sk, "Private Key: 4427-F224-FE20");

        var signature = privateKey.Sign(sm);
        DumpBufferFingerprint(signature, "Signature: 1ADB-7261-CBAE");

        var publicKey = new DilithiumPublic(pk);
        var verify = publicKey.Verify (sm, signature);
        Console.WriteLine($"Verify {verify}");

        }






    public static void DumpBufferHex(byte[] buffer, string tag = null, int length = -1, int first =0) {
        if (tag != null) {
            Console.WriteLine(tag);
            }
        Console.WriteLine(buffer.ToStringBase16(length: length, Format: ConversionFormat.Dash4, first: first));
        }

    public static void DumpBufferFingerprint(byte[] buffer, string tag = null) {
        if (tag != null) {
            Console.WriteLine(tag);
            }

        Console.WriteLine(GetBufferFingerprint(buffer));
        }

    public static string? GetBufferFingerprint(byte[] buffer) {
        if (buffer == null) {
            return null;
            }

        var hash = SHAKE128.Process(buffer);
        return hash.ToStringBase16(Format: ConversionFormat.Dash4);
        }




    //static string GetHash(PolynomialMatrix data) => data.GetHash();
    //static string GetHash(PolynomialVector data) => data.GetHash();
    //static string GetHash(Polynomial data) => data.GetHash();
    //static string GetHash(byte[] data) => GetBufferFingerprint(data);

    }
