

//using Goedel.Utilities;

//using Goedel.Test;
//using System;

//namespace Goedel.Cryptography.PQC;

///// <summary>
///// 
///// </summary>
//public class Test {

//    static void Main() {

//        //for (int i = 0; i < 256; i++) {
//        //    var b = (int) i;
//        //    Console.WriteLine( (byte)((b * -1) >> 31));
//        //    }

//        // See https://aka.ms/new-console-template for more information
//        Console.WriteLine("Gen martix");

//        var kyber = new Kyber(1024);
//        var seed = new byte[Kyber.SymBytes];


//        //var matrix = Matrix.GenerateMatrix(kyber.K, seed);
//        //Console.WriteLine(matrix.GetHash());
//        //// Elements for Seed={0} = 3DF0-CEDB-8BAB-CF8D-348B-B746-5199-B357-CC28-D36B-A426-2D3B-C8AE-DD3D-DC39-2364

//        //var ap1 = kyber.GetNoiseEta1(seed, 0);
//        //Console.WriteLine(ap1.GetHash());

//        //var ap2 = kyber.GetNoiseEta2(seed, 0);
//        //Console.WriteLine(ap2.GetHash());

//        //ap2.PolyNTT();
//        //Console.WriteLine(ap2.GetHash());

//        //ap2.PolyInvNTT();
//        //Console.WriteLine(ap2.GetHash());
        
//        var seed2 = Kyber.FakeRand(Kyber.SymBytes);
//        var (publicKey, privateKey) = kyber.KeyPair(seed2);
//        // publicKey = A1DC-91E9-9D1D-12D3-38F4-2C53-6D9D-4C4C-395A-A822-3C2A-4B29-80F4-60AD-AE1B-52FA
//        // privateKey = BA54-C21A-D741-BEBB-D9DA-FC7A-EC44-45C0-F4AA-B983-EA9B-D64A-50F0-ADF6-09BB-61E0

//        DumpBufferFingerprint(publicKey);
//        DumpBufferFingerprint(privateKey);

//        Console.WriteLine();
//        var seed3 = Kyber.FakeRand(KyberPublic.SharedSecretBytes);
//        DumpBufferHex(seed3);

//        var encryptor = new KyberPublic(publicKey);
//        var (ciphertext, sharedSecret) = encryptor.Encrypt(seed3);

//        Console.WriteLine("Ciphertext");
//        DumpBufferHex(ciphertext);

//        Console.WriteLine("Result encrypt");
//        DumpBufferFingerprint(ciphertext);
//        DumpBufferHex(sharedSecret);

//        var decryptor = new KyberPrivate(privateKey);
//        var plaintext = decryptor.Decrypt(ciphertext);

//        Console.WriteLine("Result decrypt: 7B80-BF7A-");
//        DumpBufferHex(plaintext);

//        plaintext.TestEqual(sharedSecret);


//        }





//    /// <summary>
//    /// 
//    /// </summary>
//    /// <param name="buffer"></param>
//    /// <param name="tag"></param>
//    /// <param name="length"></param>
//    /// <param name="first"></param>
//    public static void DumpBufferHex(byte[] buffer, string? tag = null, int length = -1, int first =0) {
//        if (tag != null) {
//            Console.WriteLine(tag);
//            }
//        Console.WriteLine(buffer.ToStringBase16(length: length, Format: ConversionFormat.Dash4, first: first));
//        }

//    /// <summary>
//    /// 
//    /// </summary>
//    /// <param name="buffer"></param>
//    /// <param name="tag"></param>
//    public static void DumpBufferFingerprint(byte[] buffer, string? tag = null) {
//        if (tag != null) {
//            Console.WriteLine(tag);
//            }

//        Console.WriteLine(GetBufferFingerprint(buffer));
//        }

//    /// <summary>
//    /// 
//    /// </summary>
//    /// <param name="buffer"></param>
//    /// <returns></returns>
//    public static string GetBufferFingerprint(byte[] buffer) {
//        var hash = SHAKE128.Process(buffer);
//        return hash.ToStringBase16(Format: ConversionFormat.Dash4);
//        }


//    }
