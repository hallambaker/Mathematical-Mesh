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

using Goedel.Cryptography;
using System.Collections.Generic;

using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using System.Text;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh {
    // Phase2: Mail Store account access details, passwords, etc.

    // Phase2: Mail PGP Passprase for PEM keys
    // Phase2: Mail PGP Support for PGP ECC algorithms
    // Phase2: Mail PGP Create PGP subkey / fingerprint / etc.
    // Phase2: Mail PGP Push key to MIT key server

    // Phase2: Mail SMIME Create CSR
    // Phase2: Mail SMIME Request CA issued cert via ACME
    // Phase2: Mail SMIME Save private key as P12
    // Phase2: Mail SMIME Self signed root o'trust

    #region // ActivationApplicationMail
    public partial class ActivationApplicationMail {
        #region // Properties
        ///<summary>The enveloped object</summary> 
        public Enveloped<ActivationApplicationMail> EnvelopedActivationApplicationMail =>
            envelopedActivationApplicationMail ?? new Enveloped<ActivationApplicationMail>(DareEnvelope).
                    CacheValue(out envelopedActivationApplicationMail);
        Enveloped<ActivationApplicationMail> envelopedActivationApplicationMail;

        #endregion


        }
    #endregion
    #region // ApplicationEntryMail

    public partial class ApplicationEntryMail {

        #region // Properties
        ///<summary>The decrypted activation.</summary> 
        public ActivationApplicationMail Activation { get; set; }

        #endregion
        #region // Methods

        ///<inheritdoc/>
        public override void Decode(IKeyCollection keyCollection) => 
            Activation = EnvelopedActivation.Decode(keyCollection);
        
        #endregion

        }
    #endregion
    #region // CatalogedApplicationMail
    public partial class CatalogedApplicationMail {
        #region // Properties
        /// <summary>
        /// The primary key used to catalog the entry.
        /// </summary>
        public override string _PrimaryKey => Key;

        ///<summary>The S/MIME signature key.</summary> 
        public KeyPair SmimeSignKeyPair {  get; init; }
        ///<summary>The S/MIME encryption key.</summary> 
        public KeyPair SmimeEncryptKeyPair {  get; init; }

        ///<summary>The OpenPGP signature key.</summary> 
        public KeyPair OpenpgpSignKeyPair {  get; init; }
        ///<summary>The OpenPGP encryption key.</summary> 
        public KeyPair OpenpgpEncryptKeyPair {  get; init; }


        public override KeyData[] GetEscrow() => new KeyData[] {
                new KeyData(SmimeSignKeyPair, true),
                new KeyData(SmimeEncryptKeyPair, true),
                new KeyData(OpenpgpSignKeyPair, true),
                new KeyData(OpenpgpEncryptKeyPair, true)
            };

        #endregion
        #region // Constructors and factories
        /// <summary>
        /// Create a new mail application instance.
        /// </summary>
        /// <param name="address">The email address.</param>
        /// <param name="roles">The roles to which the application is granted.</param>
        /// <returns></returns>
        public static CatalogedApplicationMail Create(string address, List<string> roles) {
            var key = GetKey(address);
            var smimeSignKeyPair = KeyPair.Factory(CryptoAlgorithmId.RSAExch,
                     KeySecurity.Exportable, keySize: 2048);
            var smimeEncryptKeyPair = KeyPair.Factory(CryptoAlgorithmId.RSAExch,
                    KeySecurity.Exportable, keySize: 2048);
            var openpgpSignKeyPair = KeyPair.Factory(CryptoAlgorithmId.RSAExch,
                    KeySecurity.Exportable, keySize: 2048);
            var openpgpEncryptKeyPair = KeyPair.Factory(CryptoAlgorithmId.RSAExch,
                   KeySecurity.Exportable, keySize: 2048);

            return new CatalogedApplicationMail() {
                AccountAddress = address,
                Key = key,
                Grant = roles,
                SmimeSignKeyPair = smimeSignKeyPair,
                SmimeEncryptKeyPair = smimeEncryptKeyPair,
                OpenpgpSignKeyPair = openpgpSignKeyPair,
                OpenpgpEncryptKeyPair = openpgpEncryptKeyPair,
                SmimeSign = new KeyData(smimeSignKeyPair),
                SmimeEncrypt = new KeyData(smimeEncryptKeyPair),
                OpenpgpSign = new KeyData(openpgpSignKeyPair),
                OpenpgpEncrypt = new KeyData(openpgpEncryptKeyPair)
                };
            }
        #endregion
        #region // Methods

        public static string GetKey (string address) => $"mailto:{address}";


        ///<inheritdoc/>
        public override ApplicationEntry GetActivation(CatalogedDevice catalogedDevice) {
            var activation = new ActivationApplicationMail() {
                SmimeSign = new KeyData(SmimeSignKeyPair, true),
                SmimeEncrypt = new KeyData(SmimeEncryptKeyPair, true),
                OpenpgpSign = new KeyData(OpenpgpSignKeyPair, true),
                OpenpgpEncrypt = new KeyData(OpenpgpEncryptKeyPair, true)
                };

            activation.Envelope(encryptionKey: catalogedDevice.ConnectionDevice.Encryption.GetKeyPair());

            return new ApplicationEntryMail() {
                Identifier = Key,
                EnvelopedActivation = activation.EnvelopedActivationApplicationMail
                };
            }

        ///<inheritdoc/>
        public override void ToBuilder(StringBuilder output) {
            output.AppendNotNull(AccountAddress,        $"Account:         {AccountAddress}");
            output.AppendNotNull(InboundConnect,        $"Inbound Server:  {InboundConnect}");
            output.AppendNotNull(OutboundConnect,       $"Outbound Server: {OutboundConnect}");
            output.AppendNotNull(SmimeSign?.Udf,        $"S/Mime Sign:     {SmimeSign?.Udf}");
            output.AppendNotNull(SmimeEncrypt?.Udf,     $"S/Mime Encrypt:  {SmimeEncrypt?.Udf}");
            output.AppendNotNull(OpenpgpSign?.Udf,      $"OpenPGP Sign:    {OpenpgpSign?.Udf}");
            output.AppendNotNull(OpenpgpEncrypt?.Udf,   $"OpenPGP Encrypt: {OpenpgpEncrypt?.Udf}");
            //output.AppendNotNull(AccountAddress, $"/n");
            //output.AppendNotNull(AccountAddress, $"/n");
            //output.AppendNotNull(AccountAddress, $"/n");
            //output.AppendNotNull(AccountAddress, $"/n");
            }


        #endregion

        }

    #endregion

    }

