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


using System;

namespace Goedel.Cryptography;



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
    ///<summary>The private key parameters represented in PKIX form</summary>
    public override IPKIXPrivateKey PKIXPrivateKey {
        get {
            Assert.AssertNotNull(PkixPrivateKeyRSA, NotExportable.Throw);
            return PkixPrivateKeyRSA;
            }
        }


    ///<summary>The public key parameters represented in PKIX form</summary>
    public override IPKIXPublicKey PKIXPublicKey => PkixPublicKeyRsa;

    /// <summary>
    /// Return private key parameters in PKIX structure
    /// </summary>
    public override PkixPrivateKeyRsa PkixPrivateKeyRSA { get; }

    /// <summary>
    /// Return public key parameters in PKIX structure
    /// </summary>
    public override PkixPublicKeyRsa PkixPublicKeyRsa => publicParameters.GetPkixPublicKeyRsa();

    /// <summary>The supported key uses (e.g. signing, encryption)</summary>
    public override KeyUses KeyUses { get; } = Cryptography.KeyUses.Any;

    ///<summary>If true, the key only has access to public key values.</summary>
    public override bool PublicOnly => provider.PublicOnly;




    #endregion


    /// <summary>
    /// Return the CryptoAlgorithmID that would be used with the specified base parameters.
    /// </summary>
    /// <param name="Base">The base algorithm</param>
    /// <returns>The computed CryptoAlgorithmID</returns>
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


    /// <summary>
    /// Persist key to <paramref name="keyCollection"/>.
    /// </summary>
    /// <param name="keyCollection">Key Collection the key is to be persisted to.</param>
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

        keySize = keySize == 0 ? 2048 : keySize;
        var bits = keySize / 2;

        var (primep, countp) = GetPrime(bits, ikm, keySpecifier, keyName, "p");

        for (var i = countp; true;) {
            BigInteger primeq;
            (primeq, i) = GetPrime(bits, ikm, keySpecifier, keyName, "q", i);
            var privateKey = GetRsa(bits, primep, primeq);

            if (privateKey is not null) {
                return new (privateKey);
                }
            }
        }

    /// <summary>
    /// Return a prime with <paramref name="bits"/> significant bits
    /// using the parameters <paramref name="ikm"/>, <paramref name="keyName"/>,
    /// <paramref name="keySpecifier"/>, <paramref name="parameter"/>.
    /// </summary>
    /// <param name="bits"></param>
    /// <param name="ikm"></param>
    /// <param name="keySpecifier"></param>
    /// <param name="keyName"></param>
    /// <param name="parameter"></param>
    /// <param name="index">Starting index for search</param>
    /// <returns>The prime and the iteration count.</returns>
    /// <exception cref="NYI"></exception>
    static (BigInteger, int) GetPrime(
                    int bits, 
                    byte[] ikm,
                    byte[] keySpecifier,
                    string keyName,
                    string parameter,
                    int index = 0) {

        for (var i = index; true; i++) {
            var param = $"{parameter}{i}";
            var seed = KeySeed(bits, ikm, keySpecifier, keyName, param);

            // Make sure the candidate is odd and has <bits> significant bits.
            seed[seed.Length - 1] |= 0x01;
            seed[0] |= 0x80;

            var c = seed.BigIntegerBigEndian();
            if (c.IsProbablePrime(256)) {
                return (c, i);
                }
            }

        }

    /// <summary>
    /// Generate and validate the remaining RSA parameters in accordance with 
    /// NIST.SP800-56Br2.
    /// https://nvlpubs.nist.gov/nistpubs/SpecialPublications/NIST.SP.800-56Br2.pdf
    /// </summary>
    /// <param name="bits">The number of bits in the prime values</param>
    /// <param name="p">The prime p</param>
    /// <param name="q">The prime q</param>
    /// <returns>The private key parameters if valid, otherwise null</returns>
    static PkixPrivateKeyRsa? GetRsa(
                int bits,
                BigInteger p,
                BigInteger q) {

        // We always use 2^16+1 as the public exponent.
        var e = new BigInteger(65537);

        // Ensure |p-q| > 2^ (bits - 100)
        var v1 = p - q;
        v1 = v1 > 0 ? v1 : -v1;
        if (!v1.IsGreaterPower2(bits - 100) ) {
            return null;
            }

        // Step 3, NYI
        var d = new BigInteger(1);
        if (!d.IsGreaterPower2(bits) {
            return null;
            }

        // Step 4
        var n = p * q;

        // Step 5
        var dp = d.Mod(p-1);
        var dq = d.Mod(q-1);
        var qInv = q.ModularInverse(p);

        // Step 6, Perform a pair-wise consistency test
        var m = n.Random();
        var encrypt = BigInteger.ModPow(m, e, n);
        var decrypt = BigInteger.ModPow(encrypt, d, n);
        (m == decrypt).AssertTrue (CryptographicException.Throw);

        // Step 7, output values
        var keySize = bits / 4;
        var primeSize = bits / 8;

        var result = new PkixPrivateKeyRsa() {
            Version = 1,
            Modulus = n.ToByteArrayBigEndian(keySize),
            PublicExponent = e.ToByteArrayBigEndian(keySize),
            PrivateExponent = d.ToByteArrayBigEndian(keySize),
            Coefficient = qInv.ToByteArrayBigEndian(keySize),
            Exponent1 = dp.ToByteArrayBigEndian(keySize),
            Exponent2 = dq.ToByteArrayBigEndian(keySize),
            Prime1 = p.ToByteArrayBigEndian(primeSize),
            Prime2 = q.ToByteArrayBigEndian(primeSize)
            };

        // Destroy all local copies of the variables
        p.Erase();
        q.Erase();
        dp.Erase();
        dq.Erase();
        qInv.Erase();
        d.Erase();

        return result;

        }


    #region // operations

    /// <summary>
    /// Encrypt a bulk key.
    /// </summary>
    /// <returns>The encoder</returns>
    /// <param name="Key">The key to encrypt.</param>
    /// <param name="Ephemeral">The ephemeral key to use for the exchange (if used)</param>
    /// <param name="Exchange">The private key to use for the exchange.</param>
    /// <param name="Salt">Optional salt value for use in key derivation.</param>
    public override void Encrypt(byte[] Key, out byte[] Exchange, out KeyPair Ephemeral, byte[] Salt = null) {
        Ephemeral = null;
        Exchange = provider.Encrypt(Key, RSAEncryptionPadding.Pkcs1);
        }

    /// <summary>
    /// Perform a key exchange to encrypt a bulk or wrapped key under this one.
    /// </summary>
    /// <param name="EncryptedKey">The encrypted session</param>
    /// <param name="Ephemeral">Ephemeral key input (required for DH)</param>
    /// <param name="AlgorithmID">The algorithm to use.</param>
    /// <param name="Partial">Partial key agreement carry in (for recryption)</param>
    /// <param name="Salt">Optional salt value for use in key derivation. If specified
    /// must match the salt used to encrypt.</param>        
    /// <returns>The decoded data instance</returns>
    public override byte[] Decrypt(
            byte[] EncryptedKey,
            KeyPair Ephemeral = null,
            CryptoAlgorithmId AlgorithmID = CryptoAlgorithmId.Default,
            KeyAgreementResult Partial = null,
            byte[] Salt = null) => provider.Decrypt(EncryptedKey, RSAEncryptionPadding.Pkcs1);

    /// <summary>
    /// Sign a precomputed digest
    /// </summary>
    /// <param name="Data">The data to sign.</param>
    /// <param name="AlgorithmID">The algorithm to use.</param>
    /// <param name="Context">Additional data added to the signature scope
    /// for protocol isolation.</param>
    /// <returns>The signature data</returns>
    public override byte[] SignHash(
            byte[] Data,
            CryptoAlgorithmId AlgorithmID = CryptoAlgorithmId.Default,
            byte[] Context = null) => provider.SignHash(Data, AlgorithmID.ToHashAlgorithmName(), RSASignaturePadding.Pkcs1);

    /// <summary>
    /// Verify a signature over the purported data digest.
    /// </summary>
    /// <param name="Signature">The signature blob value.</param>
    /// <param name="AlgorithmID">The signature and hash algorithm to use.</param>
    /// <param name="Context">Additional data added to the signature scope
    /// for protocol isolation.</param>
    /// <param name="Digest">The digest value to be verified.</param>
    /// <returns>True if the signature is valid, otherwise false.</returns>
    public override bool VerifyHash(byte[] Digest, byte[] Signature,
            CryptoAlgorithmId AlgorithmID = CryptoAlgorithmId.Default, byte[] Context = null) => provider.VerifyHash(Digest, Signature, AlgorithmID.ToHashAlgorithmName(), RSASignaturePadding.Pkcs1);
    #endregion
    }
