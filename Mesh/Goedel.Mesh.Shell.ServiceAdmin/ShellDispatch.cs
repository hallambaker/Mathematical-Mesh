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
    public void _PostProcess(ShellResult result) {
#pragma warning restore IDE1006 // Naming Styles
        this.Future();
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
