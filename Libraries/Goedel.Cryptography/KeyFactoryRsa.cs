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
using System.Reflection.Metadata;

namespace Goedel.Cryptography;

public class PrimeGeneratorUdf(
                    byte[] ikm,
                    byte[] keySpecifier,
                    string keyName) : IPrimeGenerator {

    //byte[] Ikm { get; } = ikm;
    //byte[] KeySpecifier { get; } = keySpecifier;
    //string KeyName { get; } = keyName;


    ///<inheritdoc/>
    public BigInteger GetEntropy(BigInteger minInclusive, BigInteger maxInclusive) {



        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public (BigInteger, BigInteger) GetPrime(int bits, int modulus) {
        var param = $"{parameter}{i}";

        var seed = KeyPair.KeySeed(bits, ikm, keySpecifier, keyName, param);

        throw new NotImplementedException();
        }




    }



public  class KeyFactoryRsa {


    public static PkixPrivateKeyRsa Generate(
                        byte[] ikm,
                        byte[] keySpecifier,
                        string keyName,
                        int keySize) {
        var generator = new PrimeGenerator();
        return Generate(generator, keySize);
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


            //Modulus = keypair.PubKey.N.ToByteArrayLittleEndian(keySize),
            //PublicExponent = keypair.PubKey.E.ToByteArrayLittleEndian(3),

            //Prime1 = keypair.PrivKey.P.ToByteArrayLittleEndian(primesize),
            //Prime2 = keypair.PrivKey.Q.ToByteArrayLittleEndian(primesize),
            //PrivateExponent = keypair.PrivKey.D.ToByteArrayLittleEndian(keySize),
            //Exponent1 = keypair.PrivKey.DMP1.ToByteArrayLittleEndian(primesize),
            //Exponent2 = keypair.PrivKey.DMQ1.ToByteArrayLittleEndian(primesize),
            //Coefficient = keypair.PrivKey.IQMP.ToByteArrayLittleEndian(primesize)
            };

        return result;
        }


    }
