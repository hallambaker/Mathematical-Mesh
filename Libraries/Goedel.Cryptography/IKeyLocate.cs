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
/// Key discovery interface.
/// </summary>
public interface IKeyLocate {
    /// <summary>
    /// Attempt to find a private key for the specified recipient entry.
    /// </summary>
    /// <param name="keyID">The key identifier to match</param>
    /// <param name="cryptoKey">The key (if found)</param>
    /// <returns>True if a match is found, otherwise false.</returns>
    bool TryFindKeyDecryption(string keyID, out IKeyDecrypt cryptoKey);

    /// <summary>
    /// Locate a private key
    /// </summary>
    /// <param name="UDF">fingerprint of key to locate.</param>
    /// <param name="cryptoKey">The key (if found)</param>
    /// <returns>A KeyPair instance bound to the private key.</returns>
    bool LocatePrivateKeyPair(string UDF, out CryptoKey cryptoKey);

    /// <summary>
    /// Resolve a public key by identifier. This may be a UDF fingerprint of the key,
    /// an account identifier or strong account identifier.
    /// </summary>
    /// <param name="keyID">The identifier to resolve.</param>
    /// <param name="cryptoKey">The key (if found)</param>
    /// <returns>true if a key is found, otherwise, false.</returns>
    bool TryFindKeyEncryption(string keyID, out CryptoKey cryptoKey);

    /// <summary>
    /// Resolve a private key by identifier. This may be a UDF fingerprint of the key,
    /// an account identifier or strong account identifier.
    /// </summary>
    /// <param name="signingKey">The identifier to resolve.</param>
    /// <param name="cryptoKey">The key (if found)</param>
    /// <returns>The identifier.</returns>
    bool TryFindKeySignature(string signingKey, out CryptoKey cryptoKey);

    /// <summary>
    /// Resolve a public key by identifier. This may be a UDF fingerprint of the key,
    /// an account identifier or strong account identifier.
    /// </summary>
    /// <param name="keyId">The identifier to resolve.</param>
    /// <param name="cryptoKey">The key (if found)</param>
    /// <returns>The identifier.</returns>
    bool TryFindPublicKey(string keyId, out CryptoKey cryptoKey);


    /// <summary>
    /// Add a keypair to the collection.
    /// </summary>
    /// <param name="keyPair">The key pair to add.</param>
    /// <param name="accounts">Accounts to which the key is bound.</param>
    void Add(KeyPair keyPair, List<string> accounts = null);

    /// <summary>
    /// Persist a private key if permitted by the KeySecurity model of the key.
    /// </summary>
    /// <param name="keyPair">The key to persist.</param>
    void Persist(KeyPair keyPair);


    /// <summary>
    /// Perform a remote key agreement between the key identified by <paramref name="shareId"/> and 
    /// <paramref name="ephemeral"/>.
    /// </summary>
    /// <param name="serviceAddress"></param>
    /// <param name="ephemeral">The public ephemeral.</param>
    /// <returns>The key agreement result share.ephemeral.</returns>
    /// <param name="shareId"></param>
    KeyAgreementResult RemoteAgreement(string serviceAddress, KeyPairAdvanced ephemeral, string shareId);

    }
