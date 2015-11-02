using System;
using System.Collections.Generic;
using Goedel.Protocol;
using Goedel.CryptoLibNG;
using Goedel.Debug;
using Goedel.Cryptography.Jose;
using Goedel.CryptoLibNG.PKIX;

namespace Goedel.Mesh {
    public partial class DeviceProfile : Profile {



        public override string UDF {
            get { return DeviceSignatureKey.UDF; }
            }

        public DeviceProfile(string Name, string Description) : this 
              (Name, Description,
                        CryptoCatalog.Default.AlgorithmSignature,
                        CryptoCatalog.Default.AlgorithmExchange) {

            }


        public DeviceProfile(string Name, string Description,
                    CryptoAlgorithmID SignatureAlgorithmID, 
                    CryptoAlgorithmID ExchangeAlgorithmID) {
            this.Names = new List<string>();
            this.Names.Add(Name);
            this.Description = Description;

            DeviceSignatureKey = PublicKey.Generate (KeyType.DSK, SignatureAlgorithmID);
            //DeviceSignatureKey.SelfSignCertificate(Application.DeviceMaster);

            DeviceAuthenticationKey = PublicKey.Generate(KeyType.DAK,
                    SignatureAlgorithmID);
            //DeviceAuthenticationKey.SignCertificate(Application.ClientAuth, DeviceSignatureKey);

            DeviceEncryptiontionKey = PublicKey.Generate(KeyType.DEK, ExchangeAlgorithmID);
            //DeviceEncryptiontionKey.SignCertificate(Application.DataEncryption, DeviceSignatureKey);

            Identifier = DeviceSignatureKey.UDF;

            }




        }



    }
