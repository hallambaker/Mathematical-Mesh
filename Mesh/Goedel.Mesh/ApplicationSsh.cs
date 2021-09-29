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


// Todo: SSH Add support for SSH ECC Algorithms
// Todo: SSH Support for per device client keys
// Todo: SSH Create SSH root of trust for user
// Todo: SSH Collect host credentials, sign and book to service
// Todo: SSH Passphrase for PEM Private keys




namespace Goedel.Mesh {

    #region // ActivationApplicationSsh
    public partial class ActivationApplicationSsh {
        #region // Properties
        ///<summary>The enveloped object</summary> 
        public Enveloped<ActivationApplicationSsh> EnvelopedActivationApplicationSsh =>
            new Enveloped<ActivationApplicationSsh>(DareEnvelope)

        #endregion

        }
    #endregion
    #region // ApplicationEntrySsh
    public partial class ApplicationEntrySsh {
        #region // Properties
        ///<summary>The decrypted activation.</summary> 
        public ActivationApplicationSsh Activation { get; set; }
        #endregion
        #region // Methods

        ///<inheritdoc/>
        public override void Decode(IKeyCollection keyCollection) => Activation = EnvelopedActivation.Decode(keyCollection);

        #endregion

        }
    #endregion
    #region // CatalogedApplicationSsh
    public partial class CatalogedApplicationSsh {
        #region // Properties
        /// <summary>
        /// The primary key used to catalog the entry.
        /// </summary>
        public override string _PrimaryKey => Key;

        ///<summary>The privatge client key</summary> 
        public KeyPair ClientKeyPrivate { get; init; }
        #endregion
        #region // Constructors and factories

        /// <summary>
        /// Create a new catalog entry for a set of client authentication keys.
        /// </summary>
        /// <param name="key">The application key.</param>
        /// <param name="roles">The roles to which the key is to be granted.</param>
        /// <returns></returns>
        public static CatalogedApplicationSsh Create(string key, List<string> roles) {
            // generate an RSA client key here.
            var clientKey = KeyPair.Factory(CryptoAlgorithmId.RSAExch,
                    KeySecurity.Exportable, keySize: 2048);

            // don't need to add it to the application record though because every device will have a copy.
            var applicationSSH = new CatalogedApplicationSsh() {
                Key = key,
                Grant = roles,
                ClientKeyPrivate = clientKey,
                ClientKey = new KeyData(clientKey)
                };

            return applicationSSH;
            }

        #endregion
        #region // Methods
        ///<inheritdoc/>
        public override ApplicationEntry GetActivation(CatalogedDevice catalogedDevice) {
            var activation = new ActivationApplicationSsh() {
                ClientKey = new KeyData(ClientKeyPrivate, true)
                };

            activation.Envelope(encryptionKey: catalogedDevice.ConnectionDevice.Encryption.GetKeyPair());


            return new ApplicationEntrySsh() {
                Identifier = Key,
                EnvelopedActivation = activation.EnvelopedActivationApplicationSsh
                };

            }

        ///<inheritdoc/>
        public override KeyData[] GetEscrow() => new KeyData[] {
            new KeyData(ClientKeyPrivate, true)};

        ///<inheritdoc/>
        public override void ToBuilder(StringBuilder output) {
            output.AppendNotNull(ClientKey?.Udf, $"Udf: {ClientKey?.Udf}/n");

            }

        #endregion
        }

    #endregion

    }

