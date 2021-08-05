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

using Goedel.Mesh.Client;
using Goedel.Mesh.Server;
using Goedel.Mesh.ServiceAdmin;
using Goedel.Protocol;

namespace Goedel.Mesh.Shell.ServiceAdmin {

    /// <summary>
    /// Service administration CLI
    /// </summary>
    public partial class CommandLineInterpreter {



        }





    /// <summary>
    /// The command shell.
    /// </summary>
    public partial class Shell : _Shell {


        string GetFile(ExistingFile file) => MeshMachine.GetFilePath(file.Value);
        string GetFile(NewFile file) => MeshMachine.GetFilePath(file.Value);

        ///<summary>The Mesh Machine (Must support client catalog)</summary> 
        public IMeshMachineClient MeshMachine { get; init; }

        /////<summary>The Mesh Service Provider.</summary> 
        //public PublicMeshService PublicMeshService { get; set; }

        /// <summary>
        /// Post processing action
        /// </summary>
        /// <param name="result"></param>
        public void _PostProcess(ShellResult result) {
            }

        ///<inheritdoc/>
        public override ShellResult Create(Create Options) {
            var serviceConfig = GetFile(Options.ServiceConfig);
            var serviceDns = Options.ServiceDns.Value;
            var hostIp = Options.HostIp.Value;
            var hostDns = Options.HostDns.Value;
            var admin = Options.Admin.Value;
            var newFile = GetFile(Options.NewFile);

           using var _ = PublicMeshService.Create(MeshMachine, serviceConfig, serviceDns, hostIp, hostDns, admin, newFile);



            return null;
            }

        ///<inheritdoc/>
        public override ShellResult Start(Start Options) {
            CommandLineInterpreter.DescribeValues(Options);
            return null;
            }

        ///<inheritdoc/>
        public override ShellResult Stop(Stop Options) {
            CommandLineInterpreter.DescribeValues(Options);
            return null;
            }

        ///<inheritdoc/>
        public override ShellResult Pause(Pause Options) {
            CommandLineInterpreter.DescribeValues(Options);
            return null;
            }

        ///<inheritdoc/>
        public override ShellResult Fetch(Fetch Options) {
            CommandLineInterpreter.DescribeValues(Options);
            return null;
            }

        ///<inheritdoc/>
        public override ShellResult Update(Update Options) {
            CommandLineInterpreter.DescribeValues(Options);
            return null;
            }

        ///<inheritdoc/>
        public override ShellResult Verify(Verify Options) {
            CommandLineInterpreter.DescribeValues(Options);
            return null;
            }

        ///<inheritdoc/>
        public override ShellResult DNS(DNS Options) {
            CommandLineInterpreter.DescribeValues(Options);

            var hostConfig = GetFile(Options.HostConfig);
            var dnsConfig = GetFile(Options.DnsConfig);


            var configuration = JsonReader.ReadFile<Configuration>(hostConfig, false);

            DnsConfiguration.BindConfig(configuration, dnsConfig);

            return null;
            }

        ///<inheritdoc/>
        public override ShellResult Credential(Credential Options) {
            CommandLineInterpreter.DescribeValues(Options);
            return null;
            }


        }


    }
