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


#pragma warning disable IDE1006 // Naming Styles

namespace Goedel.Mesh.Shell;

/// <summary>
/// The command shell.
/// </summary>
public partial class Shell : _Shell {


    ///<summary>If false, catch exceptions and interpret as an error.</summary> 
    public bool NoCatch { get; init; }


    ///<summary>The MeshMachine</summary>
    public virtual IMeshMachineClient MeshMachine { get; set; }

    ///<summary>Convenience accessor for the Mesh Host.</summary>
    public MeshHost MeshHost => MeshMachine?.MeshHost;

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

    readonly TextWriter output;

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
    /// Dispatch command line instruction with arguments <paramref name="args"/> and
    /// error output <paramref name="console"/>.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    /// <param name="console">Error output stream.</param>
    public void Dispatch(string[] args, TextWriter console) {
        var commandLineInterpreter = new CommandLineInterpreter();


        if (NoCatch) {
            commandLineInterpreter.MainMethod(this, args);
            }
        else {
            try {
                commandLineInterpreter.MainMethod(this, args);
                }
            catch (Goedel.Command.ParserException) {
                CommandLineInterpreter.Brief(
                    CommandLineInterpreter.Description,
                    CommandLineInterpreter.DefaultCommand,
                    CommandLineInterpreter.Entries);
                }
            catch (System.Exception Exception) {
                console.WriteLine("Application: {0}", Exception.Message);
                if (Exception.InnerException != null) {
                    console.WriteLine(Exception.InnerException.Message);
                    }
                }
            }
        }




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
            MeshID = AccountOptions.AccountAddress.Value;
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
    public virtual MeshServiceClient GetMeshClient(IAccountOptions options) {
        var context = MeshHost.GetContextMesh(options.AccountAddress.Value);
        if (context != null) {
            return context.MeshClient;
            }

        var profileDevice = ProfileDevice.Generate();
        var credential = new MeshCredentialPrivate(profileDevice, null, null, profileDevice.KeyAuthentication as KeyPairAdvanced);

        return MeshMachine.GetMeshClient(credential, null, "@anonymous");

        }


    /// <summary>
    /// Obtain an account context for the options specified in <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The command options.</param>
    /// <returns>The account context.</returns>
    public virtual ContextUser TryGetContextUser(IAccountOptions options) {


        //throw new NYI();
        var accountAddress = options.AccountAddress.Value;
        var local = options.LocalName.Value;

        var result = MeshHost.GetContextMesh(accountAddress ?? local) as ContextUser;


        return result;
        }

    /// <summary>
    /// Obtain an account context for the options specified in <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The command options.</param>
    /// <returns>The account context.</returns>

    public virtual ContextUser GetContextUser(IAccountOptions options) {
        var result = TryGetContextUser(options);
        result.AssertNotNull(NYI.Throw);
        return result;
        }


    /// <summary>
    /// Obtain a key collection for the options specified in <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The command options.</param>
    /// <returns>The key collection.</returns>

    public IKeyLocate GetKeyCollection(IAccountOptions options) {

        // here need to pull the account details and the contact catalogs from each account?
        try {
            var contextAccount = GetContextUser(options);
            return contextAccount;
            }
        catch {
            return CatalogHost.KeyCollection;
            }
        }


    /// <summary>
    /// Return a list of rights being requested by or to be applied to a device.
    /// </summary>
    /// <param name="deviceAuthOptions">The set of options.</param>
    /// <returns>If any of the rights flag values are present, returns a list of rights
    /// specifiers. Otherwise returns null.</returns>
    public static List<string> GetRights(IDeviceAuthOptions deviceAuthOptions) {
        var result = new List<string>();

        if (deviceAuthOptions.Auth.Value != null) {
            result.Add(deviceAuthOptions.Auth.Value);
            }
        if (deviceAuthOptions.AuthSuper.Value) {
            result.Add("super");
            }
        if (deviceAuthOptions.AuthAdmin.Value) {
            result.Add("admin");
            }
        if (deviceAuthOptions.AuthDevice.Value) {
            result.Add("device");
            }
        if (deviceAuthOptions.AuthMessage.Value) {
            result.Add("message");
            }
        if (deviceAuthOptions.AuthWeb.Value) {
            result.Add("web");
            }
        if (deviceAuthOptions.AuthThreshold.Value) {
            result.Add("threshold");
            }

        //if (deviceAuthOptions.AuthSSH.Value != null) {
        //    result.Add($"ssh:{deviceAuthOptions.AuthSSH.Value}");
        //    }
        //if (deviceAuthOptions.AuthEmail.Value != null) {
        //    result.Add($"ssh:{deviceAuthOptions.AuthEmail.Value}");
        //    }
        //if (deviceAuthOptions.AuthGroupMember.Value != null) {
        //    result.Add($"member:{deviceAuthOptions.AuthGroupMember.Value}");
        //    }
        //if (deviceAuthOptions.AuthGroupAdmin.Value != null) {
        //    result.Add($"group:{deviceAuthOptions.AuthGroupAdmin.Value}");
        //    }

        return result.Count > 0 ? result : null;

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
                recipients = new List<string> {
                        Options.Encrypt.Value
                        };
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

        var cryptoParameters = new CryptoParameters(keyCollection, recipients, signers);

        if (Options.Hash.Value) {
            cryptoParameters.DigestId = AlgorithmDigest.DefaultBulk(CryptoAlgorithmId.SHA_2_512);
            }

        return cryptoParameters;
        }

    }
