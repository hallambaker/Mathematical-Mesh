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

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Cryptography;

/// <summary>
/// Wrapper around a partial key pair.
/// </summary>
public class CryptoKeySymmetric : CryptoKey {

    /// <summary>UDF fingerprint of the key.</summary>
    public override string KeyIdentifier { get; }

    /// <summary>Binary fingerprint of the key</summary>
    public override byte[] UDFBytes => throw new NYI();

    ///<summary>The UDF presentation of the secret key</summary>
    public string SecretKey;

    ///<summary>The secret key.</summary>
    protected byte[] SecretValue { get; }


    /// <summary>
    /// Constructor taking the secret value from the binary value 
    /// <paramref name="secretValue"/>
    /// </summary>
    /// <param name="secretValue">The secret value.</param>
    /// <param name="udfTypeIdentifier">The UDF type identifier to create. This
    /// is either <see cref="UdfTypeIdentifier.Encryption_HKDF_AES_512"/> or
    /// <see cref="UdfTypeIdentifier.EncryptionSignature_HKDF_AES_512"/></param>
    public CryptoKeySymmetric(byte[] secretValue,
                UdfTypeIdentifier udfTypeIdentifier = UdfTypeIdentifier.Encryption_HKDF_AES_512) {

        // Create the presentation of the secret value.
        SecretValue = secretValue;
        SecretKey = Udf.TypeBDSToString(udfTypeIdentifier, SecretValue, 8 * (secretValue.Length + 1));
        KeyIdentifier = Udf.SymetricKeyId(SecretKey);


        //Console.WriteLine($"SecretKey {SecretKey}/{KeyIdentifier} {secretValue.ToStringBase16FormatHex()}");

        }

    /// <summary>
    /// Constructor taking the secret value from the UDF presentation of the secret key
    /// <paramref name="encryptionKey"/>
    /// </summary>
    /// <param name="encryptionKey">The UDF presentation of the secret value.</param>
    public CryptoKeySymmetric(string encryptionKey) :
            this(Udf.SymmetricKeyData(encryptionKey)) {
        }

    /// <summary>
    /// Encrypt the bulk key.
    /// </summary>
    /// <returns>The encoder</returns>
    public override void Encrypt(
        byte[] key,
        out byte[] exchange,
        out IAgreementData ephemeral,
        byte[] info = null) {

        var keyDerive = new KeyDeriveHKDF(SecretValue, (byte[])null);
        var encryptionKey = keyDerive.Derive(info, 256);
        exchange = Platform.KeyWrapRFC3394.Wrap(encryptionKey, key);


        //Console.WriteLine($"Encryption Key = {encryptionKey.ToStringBase16FormatHex()}");

        ephemeral = null;
        }


    /// <summary>
    /// Perform a key exchange to decrypt a bulk or wrapped key under this one.
    /// </summary>
    /// <param name="encryptedKey">The encrypted session key</param>
    /// <param name="ephemeral">Ephemeral key input (required for DH)</param>
    /// <param name="partial">Partial key agreement value (for recryption)</param>
    /// <param name="info">Optional info value for use in key derivation. If specified
    /// must match the info value used to encrypt.</param>
    /// <param name="algorithmID">The algorithm to use (redundant?)</param>
    /// <returns>The decoded data instance</returns>
    public override byte[] Decrypt(
                byte[] encryptedKey,
                IAgreementData ephemeral = null,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                KeyAgreementResult partial = null,
                byte[] info = null) {

        var keyDerive = new KeyDeriveHKDF(SecretValue, (byte[])null);
        var encryptionKey = keyDerive.Derive(info, 256);

        var result = Platform.KeyWrapRFC3394.Unwrap(encryptionKey, encryptedKey);

        //Console.WriteLine($"Encryption Key = {result.ToStringBase16FormatHex()}");

        return result;
        }


    /// <summary>
    /// Sign a precomputed digest (Not implemented)
    /// </summary>
    /// <param name="data">The data to sign.</param>
    /// <param name="algorithmID">The algorithm to use.</param>
    /// <param name="context">Additional data added to the signature scope
    /// for protocol isolation.</param>
    /// <returns>The signature data</returns>
    public override byte[] SignDigest(byte[] data, CryptoAlgorithmId algorithmID =
        CryptoAlgorithmId.Default, byte[] context = null) => throw new NotImplementedException();


    /// <summary>
    /// Verify a signature over the purported data digest.
    /// </summary>
    /// <param name="signature">The signature blob value.</param>
    /// <param name="algorithmID">The signature and hash algorithm to use.</param>
    /// <param name="context">Additional data added to the signature scope
    /// for protocol isolation.</param>
    /// <param name="digest">The digest value to be verified.</param>
    /// <returns>True if the signature is valid, otherwise false.</returns>
    public override bool VerifyDigest(
            byte[] digest,
            byte[] signature,
            CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
            byte[] context = null) => throw new NotImplementedException();


    /// <summary>
    /// String presentation of the key pair
    /// </summary>
    /// <returns>The string representation</returns>
    public override string ToString() =>
            CryptoAlgorithmId.ToString() + ":Symetric:" + KeyIdentifier;


    }

/// <summary>
/// Symmetric encryption with signature key.
/// </summary>
public class CryptoKeySymmetricSigner : CryptoKeySymmetric {

    ///<summary>If true, the key can only be used for verification.</summary>
    public bool VerifyOnly => SigningKey == null || SigningKey.PublicOnly;

    ///<summary>The signature key. This is only populated if either the private signature key
    ///value is available or the key has been used to verify a signature that provided 
    ///the public parameters.</summary>
    KeyPair SigningKey { get; }

    CryptoAlgorithmId AlgorithmSign { get; }

    /// <summary>
    /// Constructor creating an instance with a new signing key. 
    /// </summary>
    /// <param name="keySecurity">The key security model.</param>
    /// <param name="bits">Number of bits precision, if less than the minimum number
    /// of bits will be set equal to <see cref="Udf.MinimumBits"/></param>
    /// <param name="algorithmSign">The signature algorithm to use.</param>
    /// <param name="algorithmDigest">The digest algorithm to use.</param>
    public CryptoKeySymmetricSigner(
            KeySecurity keySecurity = KeySecurity.Exportable,
            int bits = 0,
            CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.HMAC_SHA_2_256) :
                base(CreateKey(keySecurity, bits, algorithmSign),
                    UdfTypeIdentifier.EncryptionSignature_HKDF_AES_512) {
        AlgorithmSign = algorithmSign;
        }


    static byte[] CreateKey(
            KeySecurity keySecurity,
            int bits,
            CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.HMAC_SHA_2_256) {


        bits = bits == 0 ? 256 : bits; // default to 128 bit work factor.
        var secretValue = Platform.GetRandomBits(bits);

        return secretValue;
        }

    /// <summary>
    /// Constructor creating an instance from the key identifier <paramref name="keyIdentifier"/>.
    /// </summary>
    /// <param name="keyIdentifier">The decryption/verification key.</param>
    public CryptoKeySymmetricSigner(
            string keyIdentifier) :
                base(Udf.SymmetricKeyData(keyIdentifier), UdfTypeIdentifier.EncryptionSignature_HKDF_AES_512) {

        }

    ///<inheritdoc/>
    public override (byte[], CryptoAlgorithmId) SignManifest(
                    byte[] data, 
                    CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, 
                    byte[] context = null) =>
                        (GetMac(data, context), CryptoAlgorithmId.NULL);



    ///<inheritdoc/>
    public override bool VerifyManifest(
                    byte[] data, 
                    byte[] signature, 
                    CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, 
                    byte[] context = null) {
        var test = GetMac(data, context);
        return test.Equals(signature);
        }


    byte[] GetMac(byte[] data, byte[] context = null) {
        using var hmac = AlgorithmSign.CreateMac(SecretValue);
        var manifest = CryptographyExtensions.CreateManifestPrefixPure(context);
        hmac.TransformBlock(manifest, 0, manifest.Length, manifest, 0);
        hmac.TransformFinalBlock(data, 0, data.Length);

        return hmac.Hash;
        }


    /// <summary>
    /// Sign a precomputed digest 
    /// </summary>
    /// <param name="data">The data to sign.</param>
    /// <param name="algorithmID">The algorithm to use.</param>
    /// <param name="context">Additional data added to the signature scope
    /// for protocol isolation.</param>
    /// <returns>The signature data</returns>
    public override byte[] SignDigest(byte[] digest, CryptoAlgorithmId algorithmID =
        CryptoAlgorithmId.Default, byte[] context = null) =>
                GetMacDigest(digest, algorithmID, context);


    /// <summary>
    /// Verify a signature over the purported data digest.
    /// </summary>
    /// <param name="signature">The signature blob value.</param>
    /// <param name="algorithmID">The signature and hash algorithm to use.</param>
    /// <param name="context">Additional data added to the signature scope
    /// for protocol isolation.</param>
    /// <param name="digest">The digest value to be verified.</param>
    /// <returns>True if the signature is valid, otherwise false.</returns>
    public override bool VerifyDigest(
            byte[] digest,
            byte[] signature,
            CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
            byte[] context = null) {
        var test = GetMacDigest(digest, algorithmID, context);
        return test.Equals(signature);
        }


    byte[] GetMacDigest(byte[] digest, CryptoAlgorithmId digestID, byte[] context = null) {
        digestID = digestID.DefaultDigest();

        var oid = digestID.ToOID();
        var oidBytes = oid.ParseOid();

        var manifest = CryptographyExtensions.CreateManifestHashed(digest, oidBytes, context);
        using var hmac = AlgorithmSign.CreateMac(SecretValue);
        hmac.TransformFinalBlock(manifest, 0, manifest.Length);


        return hmac.Hash;
        }


    /// <summary>
    /// String presentation of the key pair
    /// </summary>
    /// <returns>The string representation</returns>
    public override string ToString() =>
            CryptoAlgorithmId.ToString() + (VerifyOnly ? ":Verify:" : ":Sign:") + KeyIdentifier;



    }
