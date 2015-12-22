//Sample license text.
using System;
using System.Collections.Generic;
using Goedel.Protocol;
using Goedel.LibCrypto;
using Goedel.Debug;
using Goedel.Cryptography.Jose;
using Goedel.LibCrypto.PKIX;

namespace Goedel.Mesh {

    /// <summary>
    /// Partial class for Device Profile
    /// </summary>
    public partial class DeviceProfile : Profile {


        /// <summary>
        /// The profile fingerprint value is the device signature key.
        /// </summary>
        public override string UDF {
            get { return DeviceSignatureKey.UDF; }
            }

        /// <summary>
        /// Construct profile for the specified device.
        /// </summary>
        /// <param name="Name">The name of the device within profiles.</param>
        /// <param name="Description">Description of the device.</param>
        public DeviceProfile(string Name, string Description) : this 
              (Name, Description,
                        CryptoCatalog.Default.AlgorithmSignature,
                        CryptoCatalog.Default.AlgorithmExchange) {
            }

        /// <summary>
        /// Construct profile for the specified device.
        /// </summary>
        /// <param name="Name">The name of the device within profiles.</param>
        /// <param name="Description">Description of the device.</param>
        /// <param name="SignatureAlgorithmID">The public key algorithm to use for signature keys.</param>
        /// <param name="ExchangeAlgorithmID">The public key algorithm to use for encryption keys.</param>
        public DeviceProfile(string Name, string Description,
                    CryptoAlgorithmID SignatureAlgorithmID, 
                    CryptoAlgorithmID ExchangeAlgorithmID) {
            this.Names = new List<string>();
            this.Names.Add(Name);
            this.Description = Description;

            DeviceSignatureKey = PublicKey.Generate (KeyType.DSK, SignatureAlgorithmID);

            DeviceAuthenticationKey = PublicKey.Generate(KeyType.DAK,
                    SignatureAlgorithmID);

            DeviceEncryptiontionKey = PublicKey.Generate(KeyType.DEK, ExchangeAlgorithmID);

            Identifier = DeviceSignatureKey.UDF;
            }
        }
    }
