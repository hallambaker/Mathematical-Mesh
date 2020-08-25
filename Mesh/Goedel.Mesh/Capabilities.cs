using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;

using System.Numerics;
using System.Collections.Generic;
using System.IO;


namespace Goedel.Mesh {

    /// <summary>
    /// Interface that returns a Mesh client for an account.
    /// </summary>
    public interface IMeshClient {

        /// <summary>
        /// Get a Mesh client for the address <paramref name="accountAddress"/>.
        /// </summary>
        /// <param name="accountAddress">The account to obtain a client for.</param>
        /// <returns>The client.</returns>
        MeshService GetMeshClient (string accountAddress);

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


    public partial class CryptographicCapability  {


        ///<summary>If not null, specifies a key to which key shares MUST be encrypted
        ///when creating.</summary>
        public CryptoKey KeyDataEncryptionKey;

        ///<summary>The primary key is the value of the <see cref="Id"/> property.</summary>
        public override string _PrimaryKey => Id;

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
                KeyData.GetKeyPairAdvanced().CacheValue (out keyPair);

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
        public virtual KeyAgreementResult Agreement(KeyPair keyPair) =>
            KeyPair.Agreement(keyPair);

        }
    public partial class CapabilityDecryptPartial :ICapabilityPartial {


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

            var client = CryptographicClient.GetMeshClient(ServiceAddress);
            var response = client.Operate(operateRequest);

            var result = response.Results[0] as CryptographicResultKeyAgreement;

            return result.KeyAgreement.KeyAgreementResult;
            }

        }
    public partial class CapabilityDecryptServiced :ICapabilityServiced {
        }



    public partial class CapabilityKeyGenerate {

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
                    UDF = UDF.Nonce() // Hack: ??? should this be some function of the base key???
                    };
                }
            }


        //ShamirSharePrivate[] MakeThresholdKeySet(
        //    string accountAddress,
        //    int shares,
        //    int threshold) {
        //    throw new NYI();
        //    }

        }

    }
