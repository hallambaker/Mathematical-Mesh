#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion


using Goedel.Cryptography.Nist;
using Goedel.Cryptography.Standard;

using System.Reflection.Metadata;

namespace Goedel.Cryptography;



public record RsaGenerationHints {


    public int Q;
    public int Q1;
    public int Q2;
    public int QQ;

    public int P;
    public int P1;
    public int P2;
    public int PP;

    public RsaGenerationHints(Dictionary<string, int> callCount) {
        callCount.TryGetValue("q", out Q);
        callCount.TryGetValue("q1", out Q1);
        callCount.TryGetValue("q2", out Q2);
        callCount.TryGetValue("qq", out QQ);

        callCount.TryGetValue("p", out P);
        callCount.TryGetValue("p1", out P1);
        callCount.TryGetValue("p2", out P2);
        callCount.TryGetValue("pp", out PP);
        }


    public byte[] ToBytes() {
        var stream = new MemoryStream();
        Append(stream, P);
        Append(stream, Q);

        Append(stream, P1);
        Append(stream, Q1);

        Append(stream, P2);
        Append(stream, Q2);

        Append(stream, PP);
        Append(stream, QQ);


        return stream.ToArray();
        }


    public void Append(MemoryStream stream, int value) {
        while (true) {
            if (value < 0x80) {
                stream.WriteByte((byte)value);
                return;
                }
            else {
                stream.WriteByte((byte) (0x80 | (value & 0x7f)));
                value = value >> 7;
                }
            }
        }

    ///<inheritdoc/>
    public override string ToString() => ToBytes().ToStringBase32(format: ConversionFormat.Dash4);

    }


public class KeyFactoryECC {

    //public KeyFactoryECC() {

    //    var factory = new EccCurveFactory();
    //    var curve1 = factory.GetCurve(NistCurve.P256);

    //    }


    public static void Generate(
                    byte[] ikm,
                    byte[] keySpecifier,
                    string keyName,
                    int keySize) {
        var generator = new PrimeGeneratorUdf(ikm, keySpecifier, keyName);
        Generate(generator, keySize);

        }

    public static void Generate(IPrimeGenerator generator, int keySize) {



        var curveId = keySize switch {
            256 => NistCurve.P256,
            384 => NistCurve.P384,
            521 => NistCurve.P521,
            _ => throw new CryptographicException()
        };

        var factory = new EccCurveFactory();
        var curve = factory.GetCurve(curveId);

        var d = generator.GetEntropy(1, curve.OrderN, "d");


        var Q = curve.Multiply(curve.BasePointG, d);

        //need to encode octets according to
        //https://www.secg.org/sec1-v2.pdf

        // First output the byte 04 (uncompressed)
        // Then X in bigendian form and Y in bigendian form.

        }



    }



public  class KeyFactoryRsa {


    public static (PkixPrivateKeyRsa, RsaGenerationHints) Generate(
                        byte[] ikm,
                        byte[] keySpecifier,
                        string keyName,
                        int keySize) {
        var generator = new PrimeGeneratorUdf(ikm, keySpecifier, keyName);
        var result = Generate(generator, keySize);

        var hints = new RsaGenerationHints(generator.CallCount);
        Console.WriteLine($"Hints  P {hints.P}   Q {hints.Q}");
        return (result, hints);
        }


    public static PkixPrivateKeyRsa Generate(IPrimeGenerator generator, int keySize) {
        var keyGenerator = new CrtKeyComposer(generator);
        var keypair = keyGenerator.GenerateKeyPair(keySize);
        //var result = keypair.GetPkixPrivateKeyRSA();

        var keyBytes = keySize / 8;
        var primeBytes = keyBytes / 2;
        var result = new PkixPrivateKeyRsa {
            Modulus = keypair.PubKey.N.ToByteArrayBigEndian(keyBytes),
            PublicExponent = keypair.PubKey.E.ToByteArrayBigEndian(3),

            PrivateExponent = keypair.PrivKey.D.ToByteArrayBigEndian(keyBytes),
            Prime1 = keypair.PrivKey.P.ToByteArrayBigEndian(primeBytes),
            Prime2 = keypair.PrivKey.Q.ToByteArrayBigEndian(primeBytes),
            Exponent1 = keypair.PrivKey.DMP1.ToByteArrayBigEndian(primeBytes),
            Exponent2 = keypair.PrivKey.DMQ1.ToByteArrayBigEndian(primeBytes),
            Coefficient = keypair.PrivKey.IQMP.ToByteArrayBigEndian(primeBytes)
            };

        return result;
        }


    }
