using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;

namespace Goedel.Mesh.Shell {
    public partial class Shell : _Shell {

        CommandLineInterpreter CommandLineInterpreter;

        public static void Main(string[] Args) {
            var CLI = new CommandLineInterpreter();
            var Dispatch = new Shell();
            CLI.MainMethod(Dispatch, Args);
            }



        public bool Verbose { get; set; }
        public bool Report { get; set; }
        public bool Json { get; set; }

        public string AccountID { get; set; }
        public string UDF { get; set; }

        public bool DeviceNew { get; set; }
        public string DeviceUDF { get; set; }
        public string DeviceID { get; set; }
        public string DeviceDescription { get; set; }

        TextWriter Output;

        public Shell(TextWriter output = null) {
            Output = output ?? Console.Out;
            }

        public override void _PreProcess(Command.Dispatch options) {
            if (options is IReporting Reporting) {
                Verbose = Reporting.Verbose.Value;
                Report = Reporting.Report.Value;
                Json = Reporting.Json.Value;
                }

            if (options is IAccountOptions AccountOptions) {
                AccountID = AccountOptions.AccountID.Value;
                UDF = AccountOptions.UDF.Value;
                // Set the account here using MeshMachine
                }

            if (options is IDeviceProfileInfo DeviceProfileInfo) {
                DeviceNew = DeviceProfileInfo.DeviceNew.Value;
                DeviceUDF = DeviceProfileInfo.DeviceUDF.Value;
                DeviceID = DeviceProfileInfo.DeviceID.Value;
                DeviceDescription = DeviceProfileInfo.DeviceDescription.Value;
                // Set the Device profile here
                }

            if (options is IMailOptions MailOptions) {
                }

            if (options is IPublicKeyOptions PublicKeyOptions) {
                }

            if (options is IPrivateKeyOptions PrivateKeyOptions) {
                }

            }

        public virtual void _PostProcess(ShellResult shellResult) {
            if (Json) {
                // Only report the results in JSON format and without
                // additional text.
                Output.Write(shellResult.GetJson(false));
                }
            else {
                Output.Write(shellResult.ToString());
                if (Verbose) {
                    Output.Write(shellResult.Verbose());
                    }
                }
            }

        //public List<string> Signers(IEncodeOptions Options) =>
        //    (Options.Signer.Value == null) ? null : new List<string> { Options.Signer.Value };
        //public List<string> Recipients(IEncodeOptions Options) =>
        //    (Options.Recipient.Value == null) ? null : new List<string> { Options.Recipient.Value };


        public KeyCollection KeyCollection(IAccountOptions Options) => 
                    Cryptography.KeyCollection.Default;


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
        public CryptoParameters CryptoParameters(IEncodeOptions Options) {
            var cryptoParameters = new CryptoParameters();

            if (Options.Encrypt != null) {
                if (Options.Encrypt.Value != null) {
                    throw new NYI(); // Hack: need to resolve this against the contacts catalog
                    }
                cryptoParameters.EncryptID = Options.AlgEncrypt.Value.ToCryptoAlgorithmID();
                }


            if (Options.Sign != null) {
                cryptoParameters.DigestID = Options.AlgDigest.Value.ToCryptoAlgorithmID();
                throw new NYI(); // Hack: need to resolve this against the contacts catalog
                }

            return cryptoParameters;
            }

        }


    }
