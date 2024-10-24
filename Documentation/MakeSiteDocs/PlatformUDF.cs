﻿#region // Copyright - MIT License
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

using System.Numerics;

using Goedel.Cryptography;
using Goedel.Mesh.Shell;
using Goedel.Test;
using Goedel.Utilities;

using GC = Goedel.Cryptography;

namespace ExampleGenerator;


public partial class CreateExamples {



    public ResultKey ResultUDFNonce;
    public ResultKey ResultUDFSecret;
    public ResultKey ResultUDFEARL;
    public ResultKey ResultUDFShares;



    public ResultDigest ResultDigestSHA2;
    public ResultDigest ResultDigestSHA3;

    public ResultDigest ResultCommitSHA2;
    public ResultDigest ResultCommitSHA3;

    public SharedSecret UDFSplitSecret;
    public Goedel.Cryptography.KeyShareSymmetric[] UDFSplitShares;
    public BigInteger[] UDFSplitPolynomial;

    public string TestStringValue = "UDF Content Data";


    public KeyPairEd25519 PublicKeyed25519;

    public UDFResults UDFResults;

    public void PlatformUDF() {
        // ToDo: need to do full cleanup on the key splitting.
        // ToDo: use the new primes
        // ToDo: also new method of compression
        UDFResults = new UDFResults();

        var testCLI = GetTestCLI();
        ResultUDFNonce = testCLI.Dispatch("key nonce") as ResultKey;

        ResultUDFSecret = testCLI.Dispatch("key share /quorum=2 /shares=3") as ResultKey;
        ResultUDFEARL = testCLI.Dispatch("key earl") as ResultKey;

        var filename = TestStringValue.ToFileUnique();
        ResultDigestSHA2 = testCLI.Dispatch($"hash udf {filename} /alg sha2") as ResultDigest;
        ResultDigestSHA3 = testCLI.Dispatch($"hash udf {filename} /alg sha3") as ResultDigest;
        ResultCommitSHA2 = testCLI.Dispatch($"hash mac {filename} /alg sha2 /key {ResultUDFNonce.Key}") as ResultDigest;

        UDFSplitSecret = new SharedSecret(128);
        UDFSplitShares = UDFSplitSecret.Split(5, 3, out UDFSplitPolynomial);

        PublicKeyed25519 = KeyPair.Factory(CryptoAlgorithmId.Ed25519, KeySecurity.Exportable)
            as KeyPairEd25519;

        //var test = PublicKeyed25519.KeyInfoData;
        //test.DER();
        //var _ = PublicKeyed25519.UDF;




        }


    }
public partial class UDFResults {

    public Derive Derive;
    public UDFResults() => Derive = new Derive();

    }

public partial class Derive {
    public DerivedKeyEC X25519 = new(UdfAlgorithmIdentifier.X25519);
    public DerivedKeyEC X448 = new(UdfAlgorithmIdentifier.X448);
    public DerivedKeyEC Ed25519 = new(UdfAlgorithmIdentifier.Ed25519);
    public DerivedKeyEC Ed448 = new(UdfAlgorithmIdentifier.Ed448);

    public DerivedKeyNIST P256 = new(UdfAlgorithmIdentifier.P256);
    public DerivedKeyNIST P384 = new(UdfAlgorithmIdentifier.P384);
    public DerivedKeyNIST P521 = new(UdfAlgorithmIdentifier.P521);

    public DerivedKeyRSA RSA2048 = new(UdfAlgorithmIdentifier.RSA2048);
    public DerivedKeyRSA RSA3072 = new(UdfAlgorithmIdentifier.RSA3072);
    public DerivedKeyRSA RSA4096 = new(UdfAlgorithmIdentifier.RSA4096);

    public DerivedKeyRSA Any_RSA2048 =
        new(UdfAlgorithmIdentifier.Any, UdfAlgorithmIdentifier.RSA2048);
    public DerivedKeyEC Any_x25519 =
        new(UdfAlgorithmIdentifier.Any, UdfAlgorithmIdentifier.X25519);

    }

public partial class DerivedKey {

    public string UDF;

    public byte[] IKM;
    public byte[] Salt;
    public byte[] PRK => HKDF.PRK;


    public KeyDeriveHKDF HKDF;

    public UdfAlgorithmIdentifier AlgorithmID;

    public DerivedKey(UdfAlgorithmIdentifier type,
                UdfAlgorithmIdentifier specific = UdfAlgorithmIdentifier.Any) {

        AlgorithmID = specific == UdfAlgorithmIdentifier.Any ? type : specific;

        var seed = GC.UDF.KeySpecifier(type);
        var random = KeyDeriveHKDF.Random(seed, 128, "UDF examples".ToUTF8());

        UDF = GC.UDF.DerivedKey(type, data: random);
        IKM = GC.UDF.DerivedKey(UDF);

        Salt = GC.UDF.KeySpecifier(AlgorithmID);

        HKDF = new KeyDeriveHKDF(IKM, Salt, CryptoAlgorithmId.HMAC_SHA_2_512);

        }

    }

public partial class DerivedKeyEC : DerivedKey {
    public BigInteger P256 = 2 ^ (256) - 2 ^ (224) + 2 ^ (192) + 2 ^ (96) - 1;
    public BigInteger P384 = 2 ^ (384) - 2 ^ (128) - 2 ^ (96) + 2 ^ (32) - 1;
    public BigInteger P521 = 2 ^ (521) - 1;

    public byte[] Key;
    public byte[] OKM;

    public DerivedKeyEC(UdfAlgorithmIdentifier type,
            UdfAlgorithmIdentifier specific = UdfAlgorithmIdentifier.Any) :
                    base(type, specific) {

        switch (AlgorithmID) {
            case UdfAlgorithmIdentifier.X25519: {
                    OKM = HKDF.Derive(null, 256);
                    break;
                    }
            case UdfAlgorithmIdentifier.X448: {
                    OKM = HKDF.Derive(null, 448);
                    break;
                    }
            case UdfAlgorithmIdentifier.Ed25519: {
                    OKM = HKDF.Derive(null, 256);
                    break;
                    }
            case UdfAlgorithmIdentifier.Ed448: {
                    OKM = HKDF.Derive(null, 448);
                    break;
                    }
            default:
                break;
            }

        Key = OKM;
        }



    }



public partial class DerivedKeyNIST : DerivedKey {

    ///<summary>2 ^ (256) - 2 ^ (224) + 2 ^ (192) + 2 ^ (96) - 1;</summary>
    readonly BigInteger p256 = BigInteger.Pow(2, 256) - BigInteger.Pow(2, 224) +
        BigInteger.Pow(2, 192) + BigInteger.Pow(2, 96) - 1;

    ///<summary>2 ^ (384) - 2 ^ (128) - 2 ^ (96) + 2 ^ (32) - 1</summary>    
    readonly BigInteger p384 = BigInteger.Pow(2, 384) - BigInteger.Pow(2, 128)
        - BigInteger.Pow(2, 96) + BigInteger.Pow(2, 32) - 1;

    ///<summary>2 ^ (521) - 1</summary>
    readonly BigInteger p521 = BigInteger.Pow(2, 521) - 1;
    readonly BigInteger prime;
    public BigInteger Key;
    public byte[] OKM;

    public DerivedKeyNIST(UdfAlgorithmIdentifier type,
            UdfAlgorithmIdentifier specific = UdfAlgorithmIdentifier.Any) :
                    base(type, specific) {

        switch (AlgorithmID) {
            case UdfAlgorithmIdentifier.P256: {
                    OKM = HKDF.Derive(null, 320);
                    prime = p256;
                    break;
                    }
            case UdfAlgorithmIdentifier.P384: {
                    OKM = HKDF.Derive(null, 448);
                    prime = p384;
                    break;
                    }
            case UdfAlgorithmIdentifier.P521: {
                    OKM = HKDF.Derive(null, 592);
                    prime = p521;
                    break;
                    }


            default:
                break;
            }
        Key = ModConvert(OKM, prime);
        }

    static BigInteger ModConvert(byte[] okm, BigInteger prime) {

        var c = okm.BigIntegerBigEndian();
        return (c % (prime - 1)) + 1;
        }


    }


public partial class DerivedKeyRSA : DerivedKey {

    public byte[] Info_P = new byte[] { 112 };
    public byte[] Info_Q = new byte[] { 113 };

    public byte[] OKM_P;
    public byte[] OKM_Q;

    public BigInteger P;
    public BigInteger Q;
    public DerivedKeyRSA(UdfAlgorithmIdentifier type,
            UdfAlgorithmIdentifier specific = UdfAlgorithmIdentifier.Any) :
                    base(type, specific) {

        int bits = 0;
        switch (AlgorithmID) {

            case UdfAlgorithmIdentifier.P256: {
                    bits = 1024;
                    break;
                    }
            case UdfAlgorithmIdentifier.P384: {
                    bits = 1536;
                    break;
                    }
            case UdfAlgorithmIdentifier.P521: {
                    bits = 2048;
                    break;
                    }

            default:
                break;
            }

        OKM_P = HKDF.Derive(Info_P, bits);
        OKM_Q = HKDF.Derive(Info_Q, bits);


        P = NextPrime(OKM_P);
        Q = NextPrime(OKM_Q);
        }

    static BigInteger NextPrime(byte[] okm) {
        var c = okm.BigIntegerBigEndian();

        c = c % 2 == 1 ? c : c + 1; // next highest odd number;
        while (true) {
            if (c.IsProbablePrime()) {
                return c;
                }
            c += 2;
            }
        }
    }
