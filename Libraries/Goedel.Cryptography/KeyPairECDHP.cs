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

/// <summary>
/// NIST P256/P384/P521 Elliptic Curve Key Pair
/// </summary>
public class KeyPairECDHP : KeyPairECDH {


    ///<inheritdoc/>
    public override PKIXPrivateKeyECDH PKIXPrivateKeyECDH => throw new NotImplementedException();

    ///<inheritdoc/>
    public override PKIXPublicKeyECDH PKIXPublicKeyECDH => throw new NotImplementedException();

    ///<inheritdoc/>
    public override IKeyAdvancedPublic IKeyAdvancedPublic => throw new NotImplementedException();

    ///<inheritdoc/>
    public override IKeyAdvancedPrivate IKeyAdvancedPrivate => throw new NotImplementedException();

    ///<inheritdoc/>
    public override bool PublicOnly => throw new NotImplementedException();

    ///<inheritdoc/>
    public override byte[] Decrypt(byte[] encryptedKey, KeyPair ephemeral = null, byte[] ciphertext = null, CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, KeyAgreementResult partial = null, byte[] salt = null) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public override void Encrypt(byte[] key, out byte[] exchange, out KeyPair ephemeral, out byte[] ciphertext, byte[] salt = null) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public override KeyPairAdvanced KeyPair(IKeyAdvancedPrivate privateKey, KeySecurity keySecurity = KeySecurity.Admin, KeyUses keyUses = KeyUses.Any) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public override KeyPairAdvanced KeyPair(IKeyAdvancedPublic publicKey, KeyUses keyUses = KeyUses.Any) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public override KeyPair KeyPairPublic() {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public override void Persist(KeyCollection keyCollection) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public override byte[] SignHash(byte[] digest, CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, byte[] context = null) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public override bool VerifyHash(byte[] digest, byte[] signature, CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, byte[] context = null) {
        throw new NotImplementedException();
        }
    }
