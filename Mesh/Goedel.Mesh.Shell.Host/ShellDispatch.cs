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


using Goedel.Registry;
using Microsoft.Extensions.Configuration;
using System.Threading;

namespace Goedel.Mesh.Shell.Host;

/// <summary>
/// The command shell.
/// </summary>
public partial class Shell : _Shell {

    ///<summary>The Mesh Machine</summary> 
    public IMeshMachineClient MeshMachine { get; init; }


    ///<summary>The service instance</summary> 
    public string Instance { get; init; }


    ///<summary>Result returned by last shell command.</summary> 
    public ShellResult ShellResult { get; set; }


    /////<summary>Dictionary of service descriptions.</summary> 
    //public Dictionary<string, ServiceDescription>
    //    ServiceDescriptionDictionary { get; } = new();

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult About(About options) {

        var compilationDate = Script.AssemblyBuildTime;
        if (options.Where.Value) {
            Verbosity = Verbosity.Full;
            }
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

    /// <summary>
    /// Dispatch command line instruction with arguments <paramref name="args"/> and
    /// error output <paramref name="console"/>.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    /// <param name="console">Error output stream.</param>
    public void Dispatch(string[] args, TextWriter console) {
        var commandLineInterpreter = new CommandLineInterpreter();
        Output = console;

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
                if (Exception.InnerException != null) {
                    console.WriteLine(Exception.InnerException.Message);
                    }
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
        }



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

    ///<summary>The Machine name</summary> 
    public string MachineName { get; set; }
    ///<summary>The service configuration.</summary> 
    public Configuration Configuration { get; set; }
    //HostConfiguration HostConfiguration { get; set; }
    //ServiceConfiguration ServiceConfiguration { get; set; }
    RudService RudService { get; set; }

    string GetMultiConfig(Command._File file) =>
        PublicMeshService.GetService(MeshMachine, file.Value);

    ///<summary>Delegate to set platform services</summary> 
    public Func<HostBuilderContext, IServiceCollection, HostBuilderContext> 
        AddPlatformServices { get; set; } = DefaultPlatformServices;

    static HostBuilderContext DefaultPlatformServices(
            HostBuilderContext host,
            IServiceCollection services) {

        return host;
        }

    //IEnumerable<IConfguredService> Providers;

    ///<inheritdoc/>
    public override ShellResult HostStart(HostStart Options) {
        // ToDo: deal with 'args'

        var settings = PublicMeshService.GetService(MeshMachine);
        using var host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
            // read in the options file here.
            .ConfigureAppConfiguration((hostingContext, configuration) => {
                //IHostEnvironment env = hostingContext.HostingEnvironment;
                configuration.Sources.Clear();
                configuration.AddJsonFile(settings, true, true);
            })
            .ConfigureLogging(logging => {
                logging.ClearProviders();
                //logging.AddDareLogger();
                logging.AddConsoleLogger();
            })
            .ConfigureServices((hostContext, services) => {
                services.AddSingleton<HostMonitor, HostMonitor>();
                services.AddSingleton<IServiceListener, MeshRudListener>();
                services.AddSingleton<IMeshMachine, MeshMachineCore>();
                AddPlatformServices(hostContext, services);
            })
            .AddListenerHosted()
            .AddMeshService()
            .AddGenericHost()
            .AddResolverService()
            .AddPresenceService()
            .Build();

        host.Run();

        return new ResultStartService() {
            Success = true,
            RudService = RudService
            };
        }

    //async Task Wait(CancellationToken cancellationToken) {
    //    await cancellationToken;
    //    }



    ///<inheritdoc/>
    public override ShellResult HostVerify(HostVerify Options) {
        var serviceConfig = GetMultiConfig(Options.ServiceConfig);
        var hostConfig = Options.HostConfig.Value ?? System.Environment.MachineName;

        var result = VerifyConfig(Options.MachineName.Value, hostConfig);

        result.AssertTrue(InvalidConfiguration.Throw);



        return new Result() {
            Success = true
            };
        }

    /// <summary>
    /// Verify the configuration specified in <paramref name="hasConfig"/> and extract the host 
    /// description for <paramref name="hasConfig"/>.
    /// </summary>
    /// <param name="machineName"></param>
    /// <param name="hasConfig"></param>
    /// <returns></returns>
    public bool VerifyConfig(
        string hasConfig,
        string machineName
            ) {

        hasConfig.Future();


        // Fetch the canonical machine name from the system registry or equivalent and convert
        // to lower case.
        if (machineName == null) {
            MachineName = System.Environment.MachineName.ToLower();
            //if (Console) {
            //    System.Console.WriteLine($"HostName: {MachineName} (default)");
            //    }
            }
        else {
            MachineName = machineName.ToLower();
            //System.Console.WriteLine($"HostName: {MachineName}");
            }

        return true;

        }

    }

/// <summary>
/// Host Shell Command Line Interpreter.
/// </summary>
public partial class CommandLineInterpreter {





    }
