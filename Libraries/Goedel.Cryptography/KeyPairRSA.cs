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


namespace Goedel.Cryptography;

public static class BigNumber {
    /// <summary>
    /// Return a positive random BigInteger that is strictly less than 2^bits.
    /// </summary>
    /// <param name="Bits">The number of bits in the output</param>
    /// <returns>The random value.</returns>
    public static BigInteger Random(int Bits) {
        var bytes = CryptoCatalog.GetBytes(Bits / 8);
        return bytes.BigIntegerLittleEndian();
        }


    /// <summary>
    /// Return a positive random BigInteger that is strictly less than 2^bits.
    /// </summary>
    /// <param name="maximum">One more than the maximum value that may be returned.</param>
    /// <returns>The random value.</returns>
    public static BigInteger Random(this BigInteger maximum) {
        var bytes = CryptoCatalog.GetBytes(maximum.GetByteCount() + 16);
        return bytes.BigIntegerLittleEndian() % maximum;
        }


    /// <summary>
    /// Miller-Rabin probabalistic primality test.
    /// https://rosettacode.org/wiki/Miller%E2%80%93Rabin_primality_test#C.23
    /// </summary>
    /// <param name="source">The integer to test</param>
    /// <param name="certainty">The degree of certainty.</param>
    /// <returns>If the value <paramref name="source"/> is found to not be prime,
    /// returns false. Otherwise, returns true.</returns>
    public static bool IsProbablePrime(this BigInteger source, int certainty = 128) {
        if (source == 2 || source == 3) {
            return true;
            }
        if (source < 2 || source.IsEven) {
            return false;
            }

        BigInteger d = source - 1;
        int s = 0;

        while (d % 2 == 0) {
            d /= 2;
            s += 1;
            }

        byte[] bytes = new byte[source.ToByteArray().LongLength];
        BigInteger a;

        for (int i = 0; i < certainty; i++) {
            do {
                Platform.FillRandom(bytes, 0, bytes.Length);
                a = new BigInteger(bytes);
                } while (a < 2 || a >= source - 2);

            var x = BigInteger.ModPow(a, d, source);
            if (x == 1 || x == source - 1) {
                continue;
                }

            for (int r = 1; r < s; r++) {
                x = BigInteger.ModPow(x, 2, source);
                if (x == 1) {
                    return false;
                    }

                if (x == source - 1) {
                    break;
                    }
                }

            if (x != source - 1) {
                return false;
                }
            }

        return true;

        }
    }


/// <summary>
/// RSA Key Pair
/// </summary>
public partial class KeyPairRSA : KeyPairBaseRSA {
    /// <summary>
    /// Return the underlying .NET cryptographic provider.
    /// </summary>
    public virtual AsymmetricAlgorithm AsymmetricAlgorithm => provider;
    private readonly RSACryptoServiceProvider provider;
    private RSAParameters publicParameters;

    #region //Properties
    ///<inheritdoc/>
    public override IPKIXPrivateKey PKIXPrivateKey {
        get {
            Assert.AssertNotNull(PkixPrivateKeyRSA, NotExportable.Throw);
            return PkixPrivateKeyRSA;
            }
        }

    ///<inheritdoc/>
    public override IPKIXPublicKey PKIXPublicKey => PkixPublicKeyRsa;

    ///<inheritdoc/>
    public override PkixPrivateKeyRsa PkixPrivateKeyRSA { get; }

    ///<inheritdoc/>
    public override PkixPublicKeyRsa PkixPublicKeyRsa => publicParameters.GetPkixPublicKeyRsa();

    ///<inheritdoc/>
    public override KeyUses KeyUses { get; } = Cryptography.KeyUses.Any;

    ///<inheritdoc/>
    public override bool PublicOnly => provider.PublicOnly;




    #endregion


    ///<inheritdoc/>
    public override CryptoAlgorithmId SignatureAlgorithmID(CryptoAlgorithmId Base) =>
            CryptoAlgorithmId.RSASign | Base.Bulk();




    /// <summary>
    /// Return a PKIX SubjectPublicKeyInfo structure for the public key.
    /// </summary>
    public override SubjectPublicKeyInfo KeyInfoData =>
            new(CryptoConfig.MapNameToOID("RSA"),
                    PkixPublicKeyRsa.DER());


    /// <summary>
    /// Generate an ephemeral RSA key with the specified key size.
    /// </summary>
    /// <param name="rsa">The cryptographic provider.</param>
    /// <param name="keyType">The key type.</param>
    /// <param name="keyUses">The permitted key uses.</param>
    public KeyPairRSA(
                RSACryptoServiceProvider rsa,
                KeySecurity keyType = KeySecurity.Public,
                KeyUses keyUses = KeyUses.Any) {
        provider = rsa;
        KeySecurity = keyType;
        KeyUses = keyUses;
        publicParameters = rsa.ExportParameters(false);

        if (keyType.IsExportable()) {
            var PrivateParameters = provider.ExportParameters(true);
            PkixPrivateKeyRSA = PrivateParameters.GetPkixPrivateKeyRSA();
            }
        }

    /// <summary>
    /// Generate a KeyPair from a .NET set of parameters.
    /// </summary>
    /// <param name="RSAParameters">The RSA parameters.</param>
    /// <param name="keyType">The key type.</param>
    /// <param name="keyUses">The permitted key uses.</param>
    public KeyPairRSA(RSAParameters RSAParameters,
                KeySecurity keyType = KeySecurity.Public,
                KeyUses keyUses = KeyUses.Any) : this(GetRSA(RSAParameters), keyType, keyUses) {
        }

    /// <summary>
    /// Generate a KeyPair from a .NET set of parameters.
    /// </summary>
    /// <param name="PKIXParameters">The RSA parameters as a PKIX structure</param>
    public KeyPairRSA(PkixPublicKeyRsa PKIXParameters) {
        publicParameters = PKIXParameters.GetRsaParameters();
        provider = new RSACryptoServiceProvider();
        provider.ImportParameters(publicParameters);
        }

    /// <summary>
    /// Generate a KeyPair from a .NET set of parameters.
    /// </summary>
    /// <param name="PKIXParameters">The RSA parameters as a PKIX structure</param>
    public KeyPairRSA(PkixPrivateKeyRsa PKIXParameters) {
        publicParameters = PKIXParameters.GetRsaParameters();

        provider = new RSACryptoServiceProvider();
        provider.ImportParameters(publicParameters);
        }

    /// <summary>
    /// Generate a new RSA KeyPair with the specified parameters.
    /// </summary>
    /// <param name="keySize">The Key size</param>
    /// <param name="keySecurity">The key security model</param>
    /// <param name="keyUses">The permitted uses (signing, exchange) for the key.</param>
    /// <param name="algorithmID">The key algorithm (ignored).</param>
    /// <returns>The created key pair</returns>
    public static KeyPairRSA Generate(
                int keySize = 0,
                KeySecurity keySecurity = KeySecurity.Bound,
                KeyUses keyUses = KeyUses.Any,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.NULL) {
        algorithmID.Keep();
        keySize = keySize == 0 ? 2048 : keySize;

        //var cspParameters = new CspParameters() { Flags = CspProviderFlags.CreateEphemeralKey };
        //var rsa = new RSACryptoServiceProvider(keySize, cspParameters);


        var rsa = new RSACryptoServiceProvider(keySize);
        return new KeyPairRSA(rsa, keySecurity, keyUses);
        }


    static RSACryptoServiceProvider GetRSA(RSAParameters RSAParameters) {
        var rsa = new RSACryptoServiceProvider();
        rsa.ImportParameters(RSAParameters);
        return rsa;
        }


    ///<inheritdoc/>
    public override void Persist(KeyCollection keyCollection) {
        Assert.AssertTrue(PersistPending, CryptographicException.Throw);
        var privateParameters = provider.ExportParameters(true);
        var pkix = privateParameters.GetPkixPrivateKeyRSA();
        keyCollection.Persist(KeyIdentifier, pkix, KeySecurity.IsExportable());
        }

    /// <summary>
    /// Returns a new KeyPair instance which only has the public values.
    /// </summary>
    /// <returns></returns>
    public override KeyPair KeyPairPublic() {
        var result = new KeyPairRSA(provider.ExportParameters(false), KeySecurity.Public, KeyUses);
        Assert.AssertTrue(result.PublicOnly, CryptographicException.Throw);
        return result;
        }

    /// <summary>
    /// Locate key by fingerprint.
    /// </summary>
    /// <param name="UDF">Fingerprint of key to be located.</param>
    ///  <param name="keyPair">The key, (if found).</param>
    /// <returns>The located key (if found).</returns>
    public static bool Locate(string UDF, out KeyPair keyPair) {
        UDF.Future();
        keyPair = null;
        return false;
        }

    /// <summary>
    /// Delegate to create a key pair base
    /// </summary>
    /// <param name="pkixParameters">The parameters to construct from</param>
    /// <returns>The created key pair</returns>
    public static new KeyPair KeyPairPublicFactory(PkixPublicKeyRsa pkixParameters) {
        var rsaParameters = pkixParameters.GetRsaParameters();
        return new KeyPairRSA(rsaParameters);
        }

    /// <summary>
    /// Delegate to create a key pair base
    /// </summary>
    /// <param name="PKIXParameters">The parameters to construct from</param>
    /// <param name="keySecurity">The key security model</param>
    /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
    /// the value of <paramref name="keySecurity"/></param>/// <returns>The created key pair</returns>
    public static new KeyPair KeyPairPrivateFactory(
            PkixPrivateKeyRsa PKIXParameters,
            KeySecurity keySecurity,
            IKeyLocate keyCollection) {

        keyCollection.Keep();
        var RSAParameters = PKIXParameters.GetRsaParameters();
        return new KeyPairRSA(RSAParameters, keySecurity);
        }

    public static KeyPairRSA KeyPairFactory(
            CryptoAlgorithmId algorithmID,
            KeySecurity keySecurity,
            byte[] ikm,
            byte[] keySpecifier,
            string keyName,
            IKeyLocate keyCollection = null,
            int keySize = 0,
            KeyUses keyUses = KeyUses.Any) {

        var privateKey = KeyFactoryRsa.Generate(ikm, keySpecifier, keyName, keySize);
        return new(privateKey);
        var seed = KeySeed(bits, ikm, keySpecifier, keyName, param);
        //keySize = keySize == 0 ? 2048 : keySize;
        //var bits = keySize / 2;

        //var (primep, countp) = GetPrime(bits, ikm, keySpecifier, keyName, "p");

        //for (var i = countp; true;) {
        //    BigInteger primeq;
        //    (primeq, i) = GetPrime(bits, ikm, keySpecifier, keyName, "q", i);
        //    var privateKey = GetRsa(bits, primep, primeq);

        //    if (privateKey is not null) {
        //        return new(privateKey);
        //        }
        //    }
        }

    ///// <summary>
    ///// Return a prime with <paramref name="bits"/> significant bits
    ///// using the parameters <paramref name="ikm"/>, <paramref name="keyName"/>,
    ///// <paramref name="keySpecifier"/>, <paramref name="parameter"/>.
    ///// </summary>
    ///// <param name="bits"></param>
    ///// <param name="ikm"></param>
    ///// <param name="keySpecifier"></param>
    ///// <param name="keyName"></param>
    ///// <param name="parameter"></param>
    ///// <param name="index">Starting index for search</param>
    ///// <returns>The prime and the iteration count.</returns>
    ///// <exception cref="NYI"></exception>
    //static (BigInteger, int) GetPrime(
    //                int bits,
    //                byte[] ikm,
    //                byte[] keySpecifier,
    //                string keyName,
    //                string parameter,
    //                int index = 0) {

    //    // This needs to be replaced with the method described in FIPS 186 B.10

    //    for (var i = index; true; i++) {
    //        var param = $"{parameter}{i}";
    //        var seed = KeySeed(bits, ikm, keySpecifier, keyName, param);

    //        // Make sure the candidate is odd and has <bits> significant bits.
    //        seed[seed.Length - 1] |= 0x01;
    //        seed[0] |= 0x80;


    //        var c = seed.BigIntegerBigEndian();
    //        if (c.IsProbablePrime(256)) {
    //            return (c, i);
    //            }
    //        }

    //    }

    ///// <summary>
    ///// Generate and validate the remaining RSA parameters in accordance with 
    ///// NIST.SP800-56Br2.
    ///// https://nvlpubs.nist.gov/nistpubs/SpecialPublications/NIST.SP.800-56Br2.pdf
    ///// </summary>
    ///// <param name="bits">The number of bits in the prime values</param>
    ///// <param name="p">The prime p</param>
    ///// <param name="q">The prime q</param>
    ///// <returns>The private key parameters if valid, otherwise null</returns>
    //static PkixPrivateKeyRsa? GetRsa(
    //            int bits,
    //            BigInteger p,
    //            BigInteger q) {

    //    // Declare all registers which may contain values leaking the secret
    //    BigInteger e, n, d = BigInteger.Zero,
    //        dp = BigInteger.Zero, dq = BigInteger.Zero, qInv = BigInteger.Zero;
    //    // Create reduced versions of p and q. We do this so that we can
    //    // force erasure at the end
    //    var p1 = p - 1;
    //    var q1 = q - 1;

    //    try {
    //        // We always use 2^16+1 as the public exponent.
    //        e = new BigInteger(65537);

    //        // Ensure |p-q| > 2^ (bits - 100)
    //        if (!BigInteger.Abs(p - q).IsGreaterPower2(bits - 100)) {
    //            return null;
    //            }

    //        // Step 3, NYI
    //        d = p1 * q1;
    //        d = d / BigInteger.GreatestCommonDivisor(p1, q1);
    //        if (!d.IsGreaterPower2(bits)) {
    //            return null;
    //            }

    //        // Step 4
    //        n = p * q;

    //        // Step 5
    //        dp = d.Mod(p1);
    //        dq = d.Mod(q1);
    //        qInv = q.ModularInverse(p);

    //        // Step 6, Perform a pair-wise consistency test
    //        var m = n.Random();
    //        var encrypt = BigInteger.ModPow(m, e, n);
    //        var decrypt = BigInteger.ModPow(encrypt, d, n);
    //        (m == decrypt).AssertTrue(CryptographicException.Throw);

    //        // Step 7, output values
    //        var keySize = bits / 4;
    //        var primeSize = bits / 8;

    //        var result = new PkixPrivateKeyRsa() {
    //            Version = 1,
    //            Modulus = n.ToByteArrayBigEndian(keySize),
    //            PublicExponent = e.ToByteArrayBigEndian(keySize),
    //            PrivateExponent = d.ToByteArrayBigEndian(keySize),
    //            Coefficient = qInv.ToByteArrayBigEndian(keySize),
    //            Exponent1 = dp.ToByteArrayBigEndian(keySize),
    //            Exponent2 = dq.ToByteArrayBigEndian(keySize),
    //            Prime1 = p.ToByteArrayBigEndian(primeSize),
    //            Prime2 = q.ToByteArrayBigEndian(primeSize)
    //            };

    //        return result;
    //        }
    //    finally {
    //        // Destroy all local copies of the variables
    //        p.Erase();
    //        q.Erase();
    //        p1.Erase();
    //        q1.Erase();
    //        dp.Erase();
    //        dq.Erase();
    //        qInv.Erase();
    //        d.Erase();
    //        }
    //    }


    #region // operations

    ///<inheritdoc/>
    public override void Encrypt(
                byte[] Key, 
                out byte[] Exchange, 
                out KeyPair Ephemeral, 
                out byte[] ciphertext, 
                byte[] Salt = null) {
        Ephemeral = null;
        Exchange = provider.Encrypt(Key, RSAEncryptionPadding.Pkcs1);
        ciphertext = null;
        }

    ///<inheritdoc/>
    public override byte[] Decrypt(
            byte[] EncryptedKey,
            KeyPair Ephemeral = null,
            byte[] ciphertext = null,
            CryptoAlgorithmId AlgorithmID = CryptoAlgorithmId.Default,
            KeyAgreementResult Partial = null, byte[] Salt = null) => provider.Decrypt(EncryptedKey, RSAEncryptionPadding.Pkcs1);

    ///<inheritdoc/>
    public override byte[] SignHash(
            byte[] Data,
            CryptoAlgorithmId AlgorithmID = CryptoAlgorithmId.Default,
            byte[] Context = null) => provider.SignHash(Data, AlgorithmID.ToHashAlgorithmName(), RSASignaturePadding.Pkcs1);

    ///<inheritdoc/>
    public override bool VerifyHash(byte[] Digest, byte[] Signature,
            CryptoAlgorithmId AlgorithmID = CryptoAlgorithmId.Default, byte[] Context = null) => provider.VerifyHash(Digest, Signature, AlgorithmID.ToHashAlgorithmName(), RSASignaturePadding.Pkcs1);
    #endregion
    }
