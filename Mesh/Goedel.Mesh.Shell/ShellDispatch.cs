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


    ///<summary>The current Mesh UDF.</summary>
    public string MeshID { get; set; }


    /// <summary>
    /// Default constructor. If not null, output is directed to
    /// <paramref name="output"/> Otherwise output is directed to the console.
    /// </summary>
    /// <param name="output">The output stream.</param>
    public Shell(TextWriter output = null) => Output = output ?? Console.Out;

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
            catch (Command.ParserException) {
                Command.CommandLineInterpreterBase.Brief(
                    CommandLineInterpreter.Description,
                    CommandLineInterpreter.DefaultCommand,
                    CommandLineInterpreter.Entries);
                }
            catch (System.Exception Exception) {
                console.WriteLine("Application: {0}", Exception.Message);
                //if (Exception.InnerException != null) {
                //    console.WriteLine(Exception.InnerException.Message);
                //    }
                }
            }
        }

    ///<inheritdoc/>
    public override void _PreProcess(Command.Dispatch dispatch) {
        base._PreProcess(dispatch);
        Verbosity = Verbosity.Standard;
        if (dispatch is IReporting reporting) {
            if (reporting.Json.Value) {
                Verbosity = Verbosity.Json;
                }
            else if (!reporting.Report.Value) {
                Verbosity = Verbosity.None;
                }
            else if (reporting.Verbose.Value) {
                Verbosity = Verbosity.Full;
                }
            }
        if (dispatch is ICryptoOptions options) {
            SetAlgorithms(options);
            }
        }

#pragma warning disable IDE1006 // Naming Styles
    /// <summary>
    /// Perform post processing of the result of the shell operation.
    /// </summary>
    /// <param name="shellResult">The result returned by the operation.</param>
    public virtual void _PostProcess(ShellResult shellResult) {

        switch (Verbosity) {
            case Command.Verbosity.Json: {
                    Output.Write(shellResult.GetJson(false));

                    break;
                    }
            default: {
                    var builder = new StringBuilder();
                    shellResult.ToBuilder(builder, Verbosity);

                    Output.Write(builder.ToString());
                    break;
                    }
            }
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
    /// Get a Mesh Client for the options <paramref name="options"/>.
    /// </summary>
    /// <param name="options">Options specifying the Mesh account id to bind to.</param>
    /// <returns>The Mesh Client.</returns>
    public virtual MeshServiceClient GetMeshClient(IAccountOptions options, string address=null) {
        var context = MeshHost.GetContextMesh(options.AccountAddress.Value);
        if (context != null) {
            return context.MeshClient;
            }

        address ??= options.AccountAddress.Value;
        address.AssertNotNull(ServiceNotSpecified.Throw);

        var service = address.GetService(); 

        var profileDevice = ProfileDevice.Generate();
        var credential = new MeshCredentialPrivate(profileDevice, null, null, profileDevice.KeyAuthentication as KeyPairAdvanced);



        return MeshMachine.GetMeshClient(credential, "@anonymous", service);

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
