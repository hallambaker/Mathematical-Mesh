using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Mesh.Client;

namespace Goedel.Mesh.Shell {
    public partial class Shell : _Shell {

        //CommandLineInterpreter CommandLineInterpreter;

        public virtual IMeshMachineClient MeshMachine { get; }


        public virtual CatalogHost CatalogHost => catalogHost ??
            CatalogHost.GetCatalogHost(MeshMachine).CacheValue(out catalogHost);
        CatalogHost catalogHost;

        public static void Main(string[] Args) {
            var CLI = new CommandLineInterpreter();
            var Dispatch = new Shell();
            CLI.MainMethod(Dispatch, Args);
            }



        public bool Verbose { get; set; }
        public bool Report { get; set; }
        public bool Json { get; set; }

        public string MeshID { get; set; }

        TextWriter Output;

        public Shell(TextWriter output = null) => Output = output ?? Console.Out;

        public CryptoAlgorithmID AlgorithmSign          = CryptoAlgorithmID.Ed448;
        public CryptoAlgorithmID AlgorithmAuthenticate  = CryptoAlgorithmID.Ed448;
        public CryptoAlgorithmID AlgorithmExchange      = CryptoAlgorithmID.Ed448;

        public CryptoAlgorithmID AlgorithmDigest        = CryptoAlgorithmID.Default;
        public CryptoAlgorithmID AlgorithmMAC           = CryptoAlgorithmID.Default;
        public CryptoAlgorithmID AlgorithmEncrypt       = CryptoAlgorithmID.Default;

        public override void _PreProcess(Command.Dispatch options) {
            if (options is IReporting Reporting) {
                Verbose = Reporting.Verbose.Value;
                Report = Reporting.Report.Value;
                Json = Reporting.Json.Value;
                }

            if (options is IAccountOptions AccountOptions) {
                MeshID = AccountOptions.ServiceID.Value;
                }

            if (options is ICryptoOptions CryptoOptions) {
                SetAlgorithms(CryptoOptions);

                }

            if (options is IMailOptions MailOptions) {
                }

            if (options is IPublicKeyOptions PublicKeyOptions) {
                }

            if (options is IPrivateKeyOptions PrivateKeyOptions) {
                }

            }


        void SetAlgorithms(ICryptoOptions CryptoOptions) {
            AlgorithmSign = CryptoAlgorithmID.Ed448;
            AlgorithmAuthenticate = CryptoAlgorithmID.Ed448;
            AlgorithmExchange = CryptoAlgorithmID.Ed448;

            AlgorithmDigest = CryptoAlgorithmID.Default;
            AlgorithmMAC = CryptoAlgorithmID.Default;
            AlgorithmEncrypt = CryptoAlgorithmID.Default;

            if (CryptoOptions.Algorithms.Value != null) {
                var algorithms = CryptoOptions.Algorithms.Value.Split(',');
                foreach (var algorithm in algorithms) {
                    SetAlgorithm(algorithm);
                    }
                }
            }

        void SetAlgorithm(string algorithm) {
            var algID = algorithm.ToCryptoAlgorithmID();
            var algClass = algID.Class();

            switch (algClass) {
                case CryptoAlgorithmClass.Digest: {
                    AlgorithmDigest = algID;
                    return;
                    }
                case CryptoAlgorithmClass.Encryption: {
                    AlgorithmEncrypt = algID;
                    return;
                    }
                case CryptoAlgorithmClass.MAC: {
                    AlgorithmMAC = algID;
                    return;
                    }
                case CryptoAlgorithmClass.Signature: {
                    AlgorithmSign = algID;
                    return;
                    }
                case CryptoAlgorithmClass.Exchange: {
                    AlgorithmExchange = algID;
                    AlgorithmAuthenticate = algID;
                    return;
                    }

                }

            }


        public virtual void _PostProcess(ShellResult shellResult) {
            if (Json) {
                // Only report the results in JSON format and without
                // additional text.
                Output.Write(shellResult.GetJson(false));
                }
            else if (Verbose) {
                Output.Write(shellResult.Verbose());
                }
            else {
                Output.Write(shellResult.ToString());
                }
            }

        public virtual MeshService GetMeshClient(IAccountOptions options) {
            var serviceID = options.ServiceID.Value;

            return MeshMachine.GetMeshClient(serviceID, null, null);

            }

        /// <summary>
        /// Get or create a device profile without an associated account.
        /// </summary>
        /// <param name="options">The shell options.</param>
        /// <returns>The device context</returns>
        public virtual ContextMeshAdmin GetContextMeshAdmin(IDeviceProfileInfo options) {


            return MeshMachine.GetContextMesh(admin:true) as ContextMeshAdmin;


            //if (!options.DeviceNew.Value) {
            //    var deviceUDF = options.DeviceUDF.Value;context
            //    var deviceID = options.DeviceID.Value;

            //    var result = ContextDevice.GetContextDevice(MeshMachine, deviceUDF, deviceID);
            //    if(result != null) {
            //        return result;
            //        }
            //    }
            //var deviceDescription = options.DeviceDescription.Value;
            //return ContextDevice.Generate(MeshMachine, description: deviceDescription);

            }

        public virtual ContextMeshAdmin GetContextMeshAdmin(IMasterProfileInfo options) {


            return MeshMachine.GetContextMesh(admin: true) as ContextMeshAdmin;


            //if (!options.DeviceNew.Value) {
            //    var deviceUDF = options.DeviceUDF.Value;context
            //    var deviceID = options.DeviceID.Value;

            //    var result = ContextDevice.GetContextDevice(MeshMachine, deviceUDF, deviceID);
            //    if(result != null) {
            //        return result;
            //        }
            //    }
            //var deviceDescription = options.DeviceDescription.Value;
            //return ContextDevice.Generate(MeshMachine, description: deviceDescription);

            }


        //public virtual ContextMaster GetContextMaster(IMasterProfileInfo options) {
        //    }

        public virtual ContextAccount GetContextAccount(IAccountOptions options) {
            var contextMesh = MeshMachine.GetContextMesh();

            return contextMesh.GetContextAccount();
            }



        public virtual ContextAccount GetContextDevice(IAccountOptions options) => throw new NYI();
            //CatalogHost.GetContextDevice();


        public KeyCollection KeyCollection(IAccountOptions options) => throw new NYI();
                    //CatalogHost.GetKeyCollection();


        /// <summary>
        /// Generate the CryptoParameters from a set of specified options. Encryption and 
        /// authentication are handled independently. 
        /// <para>If <paramref name="Options.Recipient"/> is specified, the corresponding public key is
        /// resolved using the contacts catalog and used to perform a public key agreemen. The field
        /// <paramref name="Options.EncryptKey"/>is ignored.</para>
        /// <para>Otherwise the field <paramref name="Options.EncryptKey"/> is used as the secret
        /// for a key derrivation function that is used to generate the master key.</para>
        /// <para>Otherwise the message </para>
        /// </summary>
        /// <param name="Options"></param>
        /// <returns></returns>
        public CryptoParameters GetCryptoParameters(KeyCollection keyCollection, IEncodeOptions Options) {
            var cryptoParameters = new CryptoParameters();

            // Goal: do an encrypt self default option
            if (Options.Encrypt != null) {
                if (Options.Encrypt.Value != null) {
                    cryptoParameters.EncryptID = AlgorithmEncrypt.DefaultBulk(CryptoAlgorithmID.AES256CBC);
                    cryptoParameters.EncryptionKeys = new List<KeyPair> 
                        { keyCollection.GetByAccountEncrypt(Options.Encrypt.Value)};
                    }

                }


            if (Options.Sign != null) {
                if (Options.Sign.Value != null) {
                    cryptoParameters.DigestID = AlgorithmDigest.DefaultBulk(CryptoAlgorithmID.SHA_2_512);
                    cryptoParameters.SignerKeys = new List<KeyPair>
                        { keyCollection.GetByAccountSign(Options.Sign.Value)};
                    }
                }

            else if (Options.Hash.Value) {
                cryptoParameters.DigestID = AlgorithmDigest.DefaultBulk(CryptoAlgorithmID.SHA_2_512);
                }

            return cryptoParameters;
            }

        }


    }
