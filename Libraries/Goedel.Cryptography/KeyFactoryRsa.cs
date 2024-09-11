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
namespace Goedel.Cryptography;



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

        //var factory = new EccCurveFactory();
        var curve = EccCurveFactory.GetCurve(curveId);

        var d = generator.GetEntropy(1, curve.OrderN, "d", null);


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
                        int keySize,
                        RsaGenerationHints hintsIn = null) {
        var generator = new PrimeGeneratorUdf(ikm, keySpecifier, keyName);
        var result = Generate(generator, keySize, hintsIn);

        var hints = new RsaGenerationHints(generator.CallCount);
        //Console.WriteLine($"Hints  P {hints.P}   Q {hints.Q}");
        return (result, hints);
        }


    public static PkixPrivateKeyRsa Generate(IPrimeGenerator generator, int keySize,
                        RsaGenerationHints hintsIn = null) {
        var keyGenerator = new CrtKeyComposer(generator);
        var keypair = keyGenerator.GenerateKeyPair(keySize, hintsIn);
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
