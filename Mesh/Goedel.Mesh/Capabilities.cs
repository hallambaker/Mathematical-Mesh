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
using System.Numerics;

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Utilities;


namespace Goedel.Mesh {

    /// <summary>
    /// Interface that returns a Mesh client for an account.
    /// </summary>
    public interface IMeshClient {

        ///<summary>Return a Mesh client</summary> 
        public MeshServiceClient MeshClient { get; }

        }

    /// <summary>
    /// Interface containing methods and properties used to request a service perform
    /// the counterparty operation for a partial capability.
    /// </summary>
    public interface ICapabilityPartial {

        /// <summary>
        ///The identifier used to claim the capability from the service.
        /// </summary>
        string ServiceId { get; set; }

        /// <summary>
        ///The service account that supports a serviced capability. 
        /// </summary>
        string ServiceAddress { get; set; }

        /// <summary>
        /// Instance with interface that returns a Mesh client for an account. This could
        /// be changed to a delegate function.
        /// </summary>
        IMeshClient CryptographicClient { get; set; }

        }

    /// <summary>
    /// Interface containing methods and properties used to implement a service performing
    /// the counterparty operation for a partial capability.
    /// </summary>
    public interface ICapabilityServiced {

        /// <summary>
        ///UDF of trust root under which request to use a serviced capability must be 
        ///authorized. [Only present for a serviced capability]
        /// </summary>

        string AuthenticationId { get; set; }

        }


    public partial class AccessCapability {

        ///<inheritdoc/>
        public override string _PrimaryKey => Id;

        }


    public partial class CryptographicCapability {


        ///<summary>If not null, specifies a key to which key shares MUST be encrypted
        ///when creating.</summary>
        public CryptoKey KeyDataEncryptionKey;

        ///<summary>The primary key is the value of the <see cref="Capability.Id"/> property.</summary>
        public override string _PrimaryKey => Id;

        // current: implement here.
        
        ///<summary>Convenience accessor, pulls the information out of the key.</summary> 
        public virtual string SubjectId => throw new NYI();
        ///<summary>Convenience accessor, pulls the information out of the key.</summary> 
        public virtual string SubjectAddress => throw new NYI();



        public KeyPairAdvanced KeyShare { get; set; }


        /// <summary>
        /// Default constructor used for deserialization.
        /// </summary>
        public CryptographicCapability() {
            }

        /// <summary>
        /// Constructor returning an instance of the capability named <paramref name="capability"/>
        /// for the subject <paramref name="subjectId"/>.
        /// </summary>
        /// <param name="subjectId">The subject identifier.</param>
        /// <param name="capability">The capability type.</param>
        public CryptographicCapability(string subjectId, string capability) {
            //SubjectId = subjectId;

            var contentType = MeshConstants.IanaTypeMeshCapabilityId + capability;
            Id = UDF.ContentDigestOfDataString(subjectId.ToUTF8(), contentType);


            }



        public KeyPair DecryptShare(IKeyCollection keyCollection) {

            //Screen.WriteLine($"Decode from  {EnvelopedKeyShare.Header.Recipients[0]}");
            //JsonReader.Trace = true;

            var keyShare = EnvelopedKeyShare.Decode(keyCollection);
            return keyShare.PrivateParameters.GetKeyPair(KeySecurity.Ephemeral);
            }

        }


    public partial class CapabilitySign : IKeySign {


        /// <summary>
        /// Sign a precomputed digest
        /// </summary>
        /// <param name="data">The data to sign.</param>
        /// <param name="algorithmID">The algorithm to use.</param>
        /// <param name="context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <returns>The signature data</returns>       
        public virtual byte[] SignHash(
            byte[] data,
            CryptoAlgorithmId algorithmID =
            CryptoAlgorithmId.Default,
            byte[] context = null) => throw new OperationNotSupported();


        }

    public partial class CapabilityDecrypt : IKeyDecrypt {



        ///<summary>The cached <see cref="KeyPairAdvanced"/> instance corresponding
        ///to <see cref="KeyData"/></summary>
        protected KeyPairAdvanced KeyPair => keyPair ??
                KeyData.GetKeyPairAdvanced().CacheValue(out keyPair);

        KeyPairAdvanced keyPair;


        /// <summary>
        /// Perform a key exchange to encrypt a bulk or wrapped key under this one.
        /// </summary>
        /// <param name="encryptedKey">The encrypted session</param>
        /// <param name="ephemeral">Ephemeral key input (required for DH)</param>
        /// <param name="algorithmID">The algorithm to use (redundant?)</param>
        /// <param name="partial">Partial key agreement carry in (for recryption)</param>
        /// <param name="salt">Optional salt value for use in key derivation. If specified
        /// must match the salt used to encrypt.</param>        
        /// <returns>The decoded data instance</returns>
        public virtual byte[] Decrypt(
                byte[] encryptedKey,
                KeyPair ephemeral = null,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                KeyAgreementResult partial = null,
                byte[] salt = null) => KeyPair.Decrypt(encryptedKey,
                    ephemeral, algorithmID, partial, salt);


        /// <summary>
        /// Perform a key agreement.
        /// </summary>
        /// <param name="keyPair">The key pair to perform the agreement against.</param>
        /// <returns>The key agreement result.</returns>
        public virtual KeyAgreementResult Agreement(KeyPair keyPair) {

            Active.AssertTrue(NYI.Throw);
         
            return KeyPair.Agreement(keyPair);
            }
        // Current: Fails here because we are not decrypting the enveloped key!


        }
    public partial class CapabilityDecryptPartial : ICapabilityPartial {




        ///<summary>Instance exposing the <see cref="IMeshClient"/> interface allowing
        ///a client to be obtained for resolving the service.</summary>
        public IMeshClient CryptographicClient { get; set; }

        /// <summary>
        /// Perform a key exchange to encrypt a bulk or wrapped key under this one.
        /// </summary>
        /// <param name="encryptedKey">The encrypted session</param>
        /// <param name="ephemeral">Ephemeral key input (required for DH)</param>
        /// <param name="algorithmID">The algorithm to use (redundant?)</param>
        /// <param name="partial">Partial key agreement carry in (for recryption)</param>
        /// <param name="salt">Optional salt value for use in key derivation. If specified
        /// must match the salt used to encrypt.</param>        
        /// <returns>The decoded data instance</returns>
        public override byte[] Decrypt(
                byte[] encryptedKey,
                KeyPair ephemeral = null,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                KeyAgreementResult partial = null,
                byte[] salt = null) {

            // delegate service... 
            var partial2 = KeyAgreement(ServiceAddress, ServiceId, ephemeral);

            if (partial != null) {
                //partial2 = partial2.Add(partial);
                }

            return KeyPair.Decrypt(encryptedKey, ephemeral, algorithmID, partial2, salt);
            }

        KeyAgreementResult KeyAgreement(
            string accountAddress,
            string keyId,
            KeyPair ephemeral,
            BigInteger? lagrange = null) {

            lagrange.Future();

            // current: this is where decryption capabilities are used
            var operation = new CryptographicOperationKeyAgreement() {
                KeyId = keyId,
                PublicKey = Key.GetPublic(ephemeral)
                };

            var operateRequest = new OperateRequest() {
                AccountAddress = accountAddress,
                Operations = new List<CryptographicOperation>() {
                    operation
                    }
                };


            var client = CryptographicClient.MeshClient;
            var response = client.Operate(operateRequest);

            var result = response.Results[0] as CryptographicResultKeyAgreement;

            return result.KeyAgreement.KeyAgreementResult;
            }

        }
    public partial class CapabilityDecryptServiced : ICapabilityServiced {
        }



    public partial class CapabilityKeyGenerate {


        /// <summary>
        /// Default constructor used for deserialization.
        /// </summary>
        public CapabilityKeyGenerate() {
            }

        /// <summary>
        /// Constructor returning an instance of the capability named <paramref name="capability"/>
        /// for the subject <paramref name="subjectId"/>.
        /// </summary>
        /// <param name="subjectId">The subject identifier.</param>
        /// <param name="capability">The capability type.</param>
        public CapabilityKeyGenerate(string subjectId, string capability) :
                    base(subjectId, capability) {
            }


        /// <summary>
        /// Factory method returning a new capability for the private key 
        /// <paramref name="keyPair"/> encrypting the one of the shares under <paramref name="encrypt"/>.
        /// </summary>
        /// <param name="keyPair">The key to split</param>
        /// <param name="encrypt">The key to encrypt the shaed key under.</param>
        /// <returns>The generated capability.</returns>
        public static CapabilityKeyGenerate CreateThreshold(KeyPair keyPair,
                        KeyPair encrypt = null) {
            if (encrypt == null) {
                return CreateDirect(keyPair);
                }

            return null;
            }

        /// <summary>
        /// Create a direct key generation capability.
        /// </summary>
        /// <param name="keyPair">The key from which keys are to be generated.</param>
        /// <returns>The generated capability.</returns>
        public static CapabilityKeyGenerate CreateDirect(KeyPair keyPair) {
            var result = new CapabilityKeyGenerate(keyPair.KeyIdentifier, "CapabilityKeyGenerate") {

                KeyData = new KeyData(keyPair, export: true)
                };

            return result;
            }



        /// <summary>
        /// Create key shares to augment the array of capabilities <paramref name="capabilities"/>
        /// with the threshold set to the total number of shares created and bind to the
        /// <see cref="KeyData"/> properties of each.
        /// </summary>
        /// <param name="capabilities">The capabilities to augment.</param>
        public void CreateShares(params CryptographicCapability[] capabilities) {
            var keyAdvanced = KeyData.GetKeyPairAdvanced();
            var privateAdvanced = keyAdvanced.IKeyAdvancedPrivate;

            var keys = privateAdvanced.MakeThresholdKeySet(capabilities.Length);

            for (var i = 0; i < capabilities.Length; i++) {
                capabilities[i].KeyData = new KeyData(keys[i]) {
                    Udf = UDF.Nonce() // Hack: ??? should this be some function of the base key???
                    };
                }
            }


        }

    }
