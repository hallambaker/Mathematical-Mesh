//#region // Copyright - MIT License
////  © 2021 by Phill Hallam-Baker
////  
////  Permission is hereby granted, free of charge, to any person obtaining a copy
////  of this software and associated documentation files (the "Software"), to deal
////  in the Software without restriction, including without limitation the rights
////  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
////  copies of the Software, and to permit persons to whom the Software is
////  furnished to do so, subject to the following conditions:
////  
////  The above copyright notice and this permission notice shall be included in
////  all copies or substantial portions of the Software.
////  
////  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
////  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
////  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
////  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
////  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
////  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
////  THE SOFTWARE.
//#endregion


//namespace Goedel.Cryptography;

///// <summary>
///// Key factory generating ECC keypairs on the NIST curves P256, P384 and P512,
///// </summary>
//public class KeyFactoryECC {


//    /// <summary>
//    /// Generate a key pair
//    /// </summary>
//    /// <param name="ikm"></param>
//    /// <param name="keySpecifier"></param>
//    /// <param name="keyName"></param>
//    /// <param name="keySize"></param>

//    public static void Generate(
//                    byte[] ikm,
//                    byte[] keySpecifier,
//                    string keyName,
//                    int keySize) {
//        var generator = new PrimeGeneratorUdf(ikm, keySpecifier, keyName);
//        Generate(generator, keySize);

//        }

//    /// <summary>
//    /// Generate a key with size <paramref name="keySize"/> using <paramref name="generator"/>
//    /// </summary>
//    /// <param name="generator">The random number generator.</param>
//    /// <param name="keySize">The key size in bits.</param>
//    /// <exception cref="CryptographicException">The number of bits is not supported.</exception>
//    public static void Generate(IPrimeGenerator generator, int keySize) {

//        var curveId = keySize switch {
//            256 => NistCurve.P256,
//            384 => NistCurve.P384,
//            521 => NistCurve.P521,
//            _ => throw new CryptographicException()
//            };

//        //var factory = new EccCurveFactory();
//        var curve = EccCurveFactory.GetCurve(curveId);

//        var d = generator.GetEntropy(1, curve.OrderN, "d", null);


//        var Q = curve.Multiply(curve.BasePointG, d);

//        //need to encode octets according to
//        //https://www.secg.org/sec1-v2.pdf

//        // First output the byte 04 (uncompressed)
//        // Then X in bigendian form and Y in bigendian form.

//        }



//    }
