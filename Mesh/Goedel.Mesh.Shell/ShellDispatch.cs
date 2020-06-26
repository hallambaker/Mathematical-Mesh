using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Mesh.Client;
using Goedel.Protocol;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.IO;

namespace Goedel.Mesh.Shell {

    /// <summary>
    /// The command shell.
    /// </summary>
    public partial class Shell : _Shell {

        //CommandLineInterpreter CommandLineInterpreter;

        ///<summary>The MeshMachine</summary>
        public virtual IMeshMachineClient MeshMachine { get; }

        ///<summary>Convenience accessor for the Mesh Host.</summary>
        public MeshHost MeshHost => MeshMachine.MeshHost;

        ///<summary>The Host catalog.</summary>
        public virtual MeshHost CatalogHost => catalogHost ??
            MeshHost.GetCatalogHost(MeshMachine).CacheValue(out catalogHost);
        MeshHost catalogHost;

        /// <summary>
        /// The static main entry point for the shell.
        /// </summary>
        /// <param name="Args">The command line arguments.</param>
        public static void Main(string[] Args) {
            var CLI = new CommandLineInterpreter();
            var Dispatch = new Shell();
            CLI.MainMethod(Dispatch, Args);
            }

        ///<summary>Report flag, if <see langword="true"/> results of operations
        ///are reported to the console. Otherwise, no output is returned.</summary>
        public bool Report { get; set; }

        ///<summary>Verbose flag, if <see langword="true"/> verbose results of operations
        ///are reported to the console. Takes priority over <see cref="Report"/></summary>
        public bool Verbose { get; set; }

        ///<summary>JSON result flag, if <see langword="true"/> results of operations
        ///are reported to the console in JSON encoding. Takes priority over
        ///<see cref="Verbose"/> and <see cref="Report"/>.</summary>
        public bool Json { get; set; }

        ///<summary>The current Mesh UDF.</summary>
        public string MeshID { get; set; }

        TextWriter output;

        /// <summary>
        /// Default constructor. If not null, output is directed to
        /// <paramref name="output"/> Otherwise output is directed to the console.
        /// </summary>
        /// <param name="output">The output stream.</param>
        public Shell(TextWriter output = null) => this.output = output ?? Console.Out;

        ///<summary>The signature algorithm. Defaults to <see cref="CryptoAlgorithmId.Ed448"/></summary>
        public CryptoAlgorithmId AlgorithmSign = CryptoAlgorithmId.Ed448;

        ///<summary>The signature algorithm. Defaults to <see cref="CryptoAlgorithmId.X448"/></summary>
        public CryptoAlgorithmId AlgorithmAuthenticate = CryptoAlgorithmId.X448;

        ///<summary>The signature algorithm. Defaults to <see cref="CryptoAlgorithmId.X448"/></summary>
        public CryptoAlgorithmId AlgorithmExchange = CryptoAlgorithmId.X448;

        ///<summary>The digest algorithm. Defaults to <see cref="CryptoAlgorithmId.SHA_2_512"/></summary>
        public CryptoAlgorithmId AlgorithmDigest = CryptoAlgorithmId.Default;

        ///<summary>The MAC algorithm. Defaults to <see cref="CryptoAlgorithmId.HMAC_SHA_2_512"/></summary>
        public CryptoAlgorithmId AlgorithmMAC = CryptoAlgorithmId.Default;

        ///<summary>The encryption algorithm. Defaults to <see cref="CryptoAlgorithmId.AES256CBC"/></summary>
        public CryptoAlgorithmId AlgorithmEncrypt = CryptoAlgorithmId.Default;

        /// <summary>
        /// Preprocess the common command options <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options to process.</param>
        public override void _PreProcess(Command.Dispatch options) {
            if (options is IReporting Reporting) {
                Verbose = Reporting.Verbose.Value;
                Report = Reporting.Report.Value;
                Json = Reporting.Json.Value;
                }

            if (options is IAccountOptions AccountOptions) {
                MeshID = AccountOptions.AccountAddress .Value;
                }

            if (options is ICryptoOptions CryptoOptions) {
                SetAlgorithms(CryptoOptions);

                }

            //if (options is IMailOptions MailOptions) {
            //    }

            //if (options is IPublicKeyOptions PublicKeyOptions) {
            //    }

            //if (options is IPrivateKeyOptions PrivateKeyOptions) {
            //    }

            }

        /// <summary>
        /// Set choices of cryptographic options.
        /// </summary>
        /// <param name="CryptoOptions">The cryptographic options.</param>
        void SetAlgorithms(ICryptoOptions CryptoOptions) {
            AlgorithmSign = CryptoAlgorithmId.Ed448;
            AlgorithmAuthenticate = CryptoAlgorithmId.Ed448;
            AlgorithmExchange = CryptoAlgorithmId.Ed448;

            AlgorithmDigest = CryptoAlgorithmId.Default;
            AlgorithmMAC = CryptoAlgorithmId.Default;
            AlgorithmEncrypt = CryptoAlgorithmId.Default;

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
                case CryptoAlgorithmClasses.Digest: {
                    AlgorithmDigest = algID;
                    return;
                    }
                case CryptoAlgorithmClasses.Encryption: {
                    AlgorithmEncrypt = algID;
                    return;
                    }
                case CryptoAlgorithmClasses.MAC: {
                    AlgorithmMAC = algID;
                    return;
                    }
                case CryptoAlgorithmClasses.Signature: {
                    AlgorithmSign = algID;
                    return;
                    }
                case CryptoAlgorithmClasses.Exchange: {
                    AlgorithmExchange = algID;
                    AlgorithmAuthenticate = algID;
                    return;
                    }

                case CryptoAlgorithmClasses.NULL:
                    break;
                default:
                    break;
                }

            }

        /// <summary>
        /// Perform post processing of the result of the shell operation.
        /// </summary>
        /// <param name="shellResult">The result returned by the operation.</param>
        public virtual void _PostProcess(ShellResult shellResult) {
            if (Json) {
                // Only report the results in JSON format and without
                // additional text.
                output.Write(shellResult.GetJson(false));
                }
            else if (Verbose) {
                output.Write(shellResult.Verbose());
                }
            else {
                output.Write(shellResult.ToString());
                }
            }

        /// <summary>
        /// Get a Mesh Client for the options <paramref name="options"/>.
        /// </summary>
        /// <param name="options">Options specifying the Mesh account id to bind to.</param>
        /// <returns>The Mesh Client.</returns>
        public virtual MeshService GetMeshClient(IAccountOptions options) {
            var accountAddress = options.AccountAddress .Value;

            return MeshMachine.GetMeshClient(accountAddress, null, null);

            }

        ///// <summary>
        ///// Get or create a device profile without an associated account.
        ///// </summary>
        ///// <param name="options">The shell options.</param>
        ///// <returns>The device context</returns>
        //public virtual ContextMeshAdmin GetContextMeshAdmin(IDeviceProfileInfo options) => MeshHost.GetContextMesh(admin: true) as ContextMeshAdmin;

        /// <summary>
        /// Obtain an administration context for the options specified in <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The command options.</param>
        /// <returns>The administration context.</returns>
        public virtual ContextMeshAdmin GetContextMeshAdmin(IMasterProfileInfo options) => MeshHost.GetContextMesh(admin: true) as ContextMeshAdmin;

        /// <summary>
        /// Obtain an account context for the options specified in <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The command options.</param>
        /// <returns>The account context.</returns>
        public virtual ContextAccount GetContextAccount(IAccountOptions options) {
            options.Future();
            var contextMesh = MeshHost.GetContextMesh();

            return contextMesh.GetContextAccount();
            }


        /// <summary>
        /// Obtain a device context for the options specified in <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The command options.</param>
        /// <returns>The device context.</returns>
        public virtual ContextAccount GetContextDevice(IAccountOptions options) {
            options.Future();
            throw new NYI();
            //CatalogHost.GetContextDevice();
            }

        /// <summary>
        /// Obtain a key collection for the options specified in <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The command options.</param>
        /// <returns>The key collection.</returns>

        public IKeyLocate GetKeyCollection(IAccountOptions options) {

            // here need to pull the account details and the contact catalogs from each account?
            try {
                var contextAccount = GetContextAccount(options);
                return contextAccount;
                }
            catch {
                return CatalogHost.KeyCollection;
                }
            }



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
        /// <param name="Options">The command options.</param>
        /// <param name="keyCollection">The key collection to use to obtain and store keys.</param>
        /// <returns>The cryptographic parameter set.</returns>
        public CryptoParameters GetCryptoParameters(IKeyLocate keyCollection, IEncodeOptions Options) {
            List<string> recipients = null;
            List<string> signers = null;


            // ToDo: enable specification of multiple recipients in COMMAND
            if (Options.Encrypt != null) {
                if (Options.Encrypt.Value != null) {
                    recipients = new List<string>();
                    recipients.Add(Options.Encrypt.Value);
                    }

                }

            // ToDo: enable specification of multiple signers in COMMAND
            if (Options.Sign != null) {
                if (Options.Sign.Value != null) {
                    signers = new List<string> {
                        Options.Sign.Value
                        };
                    }
                }

            var cryptoParameters = new CryptoParameters(keyCollection, recipients, signers) ;

            if (Options.Hash.Value) {
                cryptoParameters.DigestID = AlgorithmDigest.DefaultBulk(CryptoAlgorithmId.SHA_2_512);
                }

            return cryptoParameters;
            }

        }


    }
