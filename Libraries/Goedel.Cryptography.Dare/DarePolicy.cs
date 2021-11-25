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
using System.Collections.Generic;

using Goedel.Cryptography.Jose;
using Goedel.Utilities;

namespace Goedel.Cryptography.Dare;


public partial class DarePolicy {

    ///<summary>If true, payload data must be encrypted.</summary> 

    public bool Encrypt => EncryptKeys != null;

    ///<summary>Key collection to be used to resolve keys.</summary> 
    public IKeyLocate KeyLocation { get; set; }


    /////<summary></summary> 
    //CryptoParameters CryptoParameters { get; set; }

    /// <summary>
    /// Default constructor used for deserialization.
    /// </summary>
    public DarePolicy() {
        }


    /// <summary>
    /// Convenience constructor to create a policy to be used to encode a container. The parameter
    /// <paramref name="keyLocate"/> is used to resolve the keys specified in 
    /// <paramref name="signers"/> and <paramref name="recipients"/>. The parameters 
    /// <paramref name="encrypt"/> and <paramref name="digest"/> allow the bulk ciphers to be
    /// specified using <see cref="CryptoAlgorithmId"/> parameters rather than JOSE identifiers.
    /// Additional properties MAY be specified directly.
    /// </summary>
    /// <param name="keyLocate">The key location instance.</param>
    /// <param name="signers">Signer identifiers. to be resolved using <paramref name="keyLocate"/></param>
    /// <param name="recipients">Recipient identifiers. to be resolved using <paramref name="keyLocate"/></param>
    /// <param name="encrypt">The bulk encryption algorithm.</param>
    /// <param name="digest">The bulk digest algorithm.</param>
    public DarePolicy(IKeyLocate keyLocate,
            List<string> signers = null,
            List<string> recipients = null,
            CryptoAlgorithmId encrypt = CryptoAlgorithmId.NULL,
            CryptoAlgorithmId digest = CryptoAlgorithmId.NULL) {

        KeyLocation = keyLocate;
        EncryptionAlgorithm = encrypt.ToJoseID();
        DigestAlgorithm = digest.ToJoseID();

        if (recipients != null) {
            EncryptKeys = new List<Jose.Key>();

            foreach (var recipient in recipients) {
                keyLocate.TryFindKeyEncryption(recipient, out var keypair).AssertTrue(KeyNotFound.Throw);
                EncryptKeys.Add(Jose.Key.FactoryPublic(keypair as KeyPair));
                }
            }

        signers.Future();

        Sealed = true;
        }

    /// <summary>
    /// Convenience constructor to create a policy to be used to encode a container.
    /// </summary>
    /// <param name="keyLocate">The key location instance.</param>
    /// <param name="signer">Signer key</param>
    /// <param name="recipient">Recipient key</param>
    /// <param name="encrypt">The bulk encryption algorithm.</param>
    /// <param name="digest">The bulk digest algorithm.</param>
    public DarePolicy(IKeyLocate keyLocate,
            CryptoKey signer = null,
            CryptoKey recipient = null,
            CryptoAlgorithmId encrypt = CryptoAlgorithmId.NULL,
            CryptoAlgorithmId digest = CryptoAlgorithmId.NULL) {

        KeyLocation = keyLocate;
        EncryptionAlgorithm = encrypt.ToJoseID();
        DigestAlgorithm = digest.ToJoseID();

        if (recipient != null) {
            var joseKey = Jose.Key.FactoryPublic(recipient as KeyPair);
            EncryptKeys = new List<Jose.Key>() { joseKey };
            }
        if (signer != null) {
            var joseKey = Jose.Key.FactoryPublic(signer as KeyPair);
            EncryptKeys = new List<Jose.Key>() { joseKey };
            }


        Sealed = true;
        }



    ///// <summary>
    ///// Obsolete constructor being used for testing, eliminate when no longer used.
    ///// </summary>
    ///// <param name="cryptoParameters"></param>
    //public DarePolicy(CryptoParameters cryptoParameters) {
    //    CryptoParameters = cryptoParameters;
    //    throw new NYI();
    //    }



    }
