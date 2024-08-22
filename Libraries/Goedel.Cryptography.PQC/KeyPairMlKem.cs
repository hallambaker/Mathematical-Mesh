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



namespace Goedel.Cryptography.PQC;

public class KeyPairMlKem : KeyPair {

    #region //Properties

    ///<summary>The public key value.</summary>
    public KyberPublic PublicKey { get; set; }
    ///<summary>The private key value</summary>
    public KyberPrivate PrivateKey { get; set; }


    /// <summary>
    /// Return private key parameters in PKIX structure
    /// </summary>
    public PKIXPrivateKeyMLKem PKIXPrivateKeyMLKem { get; }

    /// <summary>
    /// Return public key parameters in PKIX structure
    /// </summary>
    public PKIXPublicKeyMLKem PKIXPublicKeyMLKem { get; }

    ///<inheritdoc/>
    public override IPKIXPrivateKey PKIXPrivateKey => PKIXPrivateKeyMLKem;

    ///<inheritdoc/>
    public override IPkixPublicKey PkixPublicKey => PKIXPublicKeyMLKem;

    ///<inheritdoc/>
    public override KeyUses KeyUses { get; } = KeyUses.Any;


    #endregion

    ///<inheritdoc/>
    ///<exception cref="OperationNotSupported">ML-KEM does not support signature operations.</exception>
    public override int LengthSignature => throw new OperationNotSupported();

    ///<inheritdoc/>
    public override SubjectPublicKeyInfo KeyInfoData => PKIXPublicKeyMLKem.SubjectPublicKeyInfo();



    public override bool PublicOnly => throw new NotImplementedException();


    KeyPairMlKem(Kyber mlKem) : this (mlKem, Platform.GetRandomBytes(Kyber.SymBytes)) {
        }

    public KeyPairMlKem(Kyber mlKem, byte[] seed) {

        }


    /// <summary>
    /// Generate a key pair for the specified algorithm and key size.
    /// </summary>
    /// <param name="keySize">The Key size, must be 255 or 448</param>
    /// <param name="keySecurity">The key security model</param>
    /// <param name="cryptoAlgorithmID">The cryptographic algorithm identifier</param>
    /// <param name="keyUses">The permitted uses (signing, exchange) for the key.</param>
    /// <returns>The generated key pair</returns>
    public static KeyPair KeyPairFactory(
                int keySize = 0,
                KeySecurity keySecurity = KeySecurity.Bound,
                KeyUses keyUses = KeyUses.Any,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.NULL) {

        Kyber mlKem = cryptoAlgorithmID switch {
            CryptoAlgorithmId.MLKEM512 => Kyber.Kyber512,
            CryptoAlgorithmId.MLKEM768 => Kyber.Kyber768,
            CryptoAlgorithmId.MLKEM1024 => Kyber.Kyber1024,
            _ => null
            };

        mlKem ??= keySize switch {
            0 => Kyber.Kyber1024,
            512 => Kyber.Kyber512,
            768 => Kyber.Kyber768,
            1024 => Kyber.Kyber1024,
            _ => throw new KeySizeNotSupported()
            };

        return new KeyPairMlKem (mlKem);

        }





    public override byte[] Decrypt(byte[] encryptedKey, KeyPair ephemeral = null, CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, KeyAgreementResult partial = null, byte[] salt = null) {
        throw new NotImplementedException();
        }

    public override void Encrypt(byte[] key, out byte[] exchange, out KeyPair ephemeral, byte[] salt = null) {
        throw new NotImplementedException();
        }

    public override KeyPair KeyPairPublic() {
        throw new NotImplementedException();
        }

    public override void Persist(KeyCollection keyCollection) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    ///<exception cref="OperationNotSupported">ML-KEM does not support signature operations.</exception>
    public override byte[] SignHash(
                byte[] data, 
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, 
                byte[] context = null) =>
        throw new OperationNotSupported();


    ///<inheritdoc/>
    ///<exception cref="OperationNotSupported">ML-KEM does not support signature operations.</exception>
    public override bool VerifyHash(
                byte[] digest, byte[] signature, 
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, 
                byte[] context = null) =>
        throw new OperationNotSupported();
    }



