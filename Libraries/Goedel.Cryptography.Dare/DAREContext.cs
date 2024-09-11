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
//using System;

using Goedel.Cryptography.PQC;

namespace Goedel.Cryptography.Dare;

/// <summary>
/// 
/// </summary>
public partial class DareRecipient {

    /// <summary>
    /// Salt value used in the key derivation function.
    /// </summary>
    public static readonly byte[] KDFInfo = "master".ToUTF8();

    /// <summary>
    /// Default constructor. Used for serializatrion.
    /// </summary>
    public DareRecipient() {
        }

    /// <summary>
    /// Create a DARERecipient using the specified cryptographic parameters.
    /// </summary>
    /// <param name="masterKey">The master key</param>
    /// <param name="encryptionKey">The recipient encryption key.</param>
    /// <
    /// <returns>The recipient informatin object.</returns>
    public DareRecipient(
                    byte[] masterKey, 
                    CryptoKey encryptionKey) {
        //var ExchangeProvider = PublicKey.ExchangeProvider();
        //ExchangeProvider.Encrypt(MasterKey, out var Exchange, out var Ephemeral, Salt: KDFSalt);

        encryptionKey.Encrypt(
                    masterKey,
                    out var exchange,
                    out var ephemeral);

        if (ephemeral is KeyPair keyPairEpk) {
            Epk = Key.GetPublic(keyPairEpk);
            }
        else if (ephemeral is AgreementDataBinary kemCiphertext) {
            Ek = kemCiphertext.Value;
            }

        KeyIdentifier = encryptionKey.KeyIdentifier;
        WrappedBaseSeed = exchange;

        }



    /// <summary>
    /// Create a DARERecipient using the specified cryptographic parameters.
    /// </summary>
    /// <param name="masterKey">The master key</param>
    /// <returns>The recipient informatin object.</returns>
    public DareRecipient(byte[] masterKey) => KeyIdentifier = Udf.SymetricKeyId(masterKey);

    public IAgreementData GetAgreementData() {

        if (Epk is not null) {
            return Epk.GetKeyPair(KeySecurity.Bound) as IAgreementData;
            }
        else if (Ek is not null) {
            return new AgreementDataBinary(Ek);
            }
        return null;
        }


    }
