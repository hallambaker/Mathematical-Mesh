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
using Goedel.Protocol;
using Goedel.Registry;
using System.Net;
namespace Goedel.Mesh.Shell.ServiceAdmin;

/// <summary>
/// Service administration CLI
/// </summary>
public partial class CommandLineInterpreter {



    }





/// <summary>
/// The command shell.
/// </summary>
public partial class Shell : _Shell {
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

    TextWriter Output { get; set; }


    ///<summary>If false, catch exceptions and interpret as an error.</summary> 
    public bool NoCatch { get; init; }

    /// <summary>
    /// Dispatch command line instruction with arguments <paramref name="args"/> and
    /// error output <paramref name="console"/>.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    /// <param name="console">Error output stream.</param>
    public void Dispatch(string[] args, TextWriter console) {
        var commandLineInterpreter = new CommandLineInterpreter();
        Output=console;

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
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult About(About options) {

        var compilationDate = Script.AssemblyBuildTime;

        return new ResultAbout() {
            Success = true,
            DirectoryKeys = MeshMachine.DirectoryKeys,
            DirectoryMesh = MeshMachine.DirectoryMesh,
            AssemblyTitle = Script.AssemblyTitle,
            AssemblyDescription = Script.AssemblyDescription,
            AssemblyCopyright = Script.AssemblyCopyright,
            AssemblyCompany = Script.AssemblyCompany,
            AssemblyVersion = Script.AssemblyVersion,
            Build = Script.LocalizeTime(compilationDate, false)
            };
        }


    string GetMultiConfig(Command._File file) =>
        PublicMeshService.GetService(MeshMachine, file.Value);


    string GetFile(NewFile file) => MeshMachine.GetFilePath(file.Value);

    ///<summary>The Mesh Machine (Must support client catalog)</summary> 
    public IMeshMachineClient MeshMachine { get; init; }

    /////<summary>The Mesh Service Provider.</summary> 
    //public PublicMeshService PublicMeshService { get; set; }

    /// <summary>
    /// Post processing action
    /// </summary>
    /// <param name="result"></param>
#pragma warning disable IDE1006 // Naming Styles
    /// <summary>
    /// Perform post processing of the result of the shell operation.
    /// </summary>
    /// <param name="shellResult">The result returned by the operation.</param>
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



    ///<inheritdoc/>
    public override ShellResult Create(Create Options) {
        var multiConfig = GetMultiConfig(Options.MultiConfig);
        var serviceDns = Options.ServiceDns.Value ?? Dns.GetHostName();
        var hostIp = Options.HostIp.Value ?? "127.0.0.1:15099";
        var hostDns = Options.HostDns.Value ?? serviceDns;
        var admin = Options.Admin.Value;
        var hostConfig = Options.HostConfig.Value ?? "mmmsettings.json";
        var runAs = Options.Account.Value;

        var configuration = PublicMeshService.Create(
                MeshMachine, multiConfig, serviceDns, hostConfig, hostIp, hostDns, admin, runAs);

        // here populate a status response from configuration

        return new ResultServiceConfiguration() {
            Configuration = configuration
            };

        }


    ///<inheritdoc/>
    public override ShellResult DNS(DNS Options) {
        var multiConfig = GetMultiConfig(Options.MultiConfig);
        var hostConfig = Options.HostConfig.Value ?? System.Environment.MachineName;
        var dnsConfig = Options.DnsConfig.Value;

        var configuration = Configuration.FromFile(multiConfig);

        DnsConfiguration.BindConfig(configuration, dnsConfig);
        return new ResultServiceConfiguration() {
            Configuration = configuration
            };
        }

    ///<inheritdoc/>
    public override ShellResult Netsh(Netsh Options) {
        var multiConfig = GetMultiConfig(Options.MultiConfig);
        var hostConfig = Options.HostConfig.Value ?? System.Environment.MachineName;
        var dnsConfig = Options.DnsConfig.Value;

        var configuration = Configuration.FromFile(multiConfig);

        DnsConfiguration.NetshConfig(configuration, dnsConfig);
        return new ResultServiceConfiguration() {
            Configuration = configuration
            };
        }


    }
