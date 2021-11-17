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

using System;
using System.Collections.Generic;

using Goedel.IO;
using Goedel.Mesh.Client;
using Goedel.Mesh.Shell;
using Goedel.Protocol;
using Goedel.Test;
using Goedel.Test.Core;
using Goedel.Utilities;

#pragma warning disable IDE0059

namespace Goedel.Mesh.Test {

    public partial class TestShell : Goedel.Mesh.Shell.Shell {
        public string MachineName = "Test";


        public TestEnvironmentCommon TestEnvironmentCommon;

        public override IMeshMachineClient MeshMachine => MeshMachineTest;

        public MeshMachineTest MeshMachineTest => meshMachineTest ??
           new MeshMachineTest(TestEnvironmentCommon, MachineName).CacheValue(out meshMachineTest);
        //new MeshMachineTestWeb(TestEnvironmentCommon, MachineName).CacheValue(out meshMachineTest));
        MeshMachineTest meshMachineTest;

        //MeshServiceClient MeshClient => meshClient ??
        //    GetMeshClient(null).CacheValue(out meshClient);
        //MeshServiceClient meshClient;


        //public bool Direct { get; }

        /// <summary>
        /// Create a new test shell
        /// </summary>
        /// <param name="meshPortalDirect"></param>
        public TestShell(TestEnvironmentCommon testEnvironment, string machineName = null) {
            MachineName = machineName ?? MachineName;
            TestEnvironmentCommon = testEnvironment;
            //Direct = direct;
            }


        //public MeshServiceClient GetMeshClient(ICredentialPrivate credential) =>
        //    MeshMachine.GetMeshClient(credential);

        /////<inheritdoc/>
        //public override MeshServiceClient GetMeshClient(IAccountOptions Options) => throw new NYI();
        //MeshClient;

        public ShellResult ShellResult;

        /// <summary>
        /// Override the post processing hook to save the result.
        /// </summary>
        /// <param name="shellResult"></param>
        public override void _PostProcess(ShellResult shellResult) {
            Console.WriteLine(shellResult.ToString());
            ShellResult = shellResult;
            }
        }




    public partial class ExampleResult {
        public Result Result;
        public string ResultType => Result._Tag;
        public string Command;
        public TestCLI TestCLI;



        public string ResultText => Result.ToString();
        //{ get {
        //    var result = 
        //    return result == "" ? "\n" : result;
        //    } }
        public string ResultJSON => Result.GetJson(true).ToUTF8();


        public ResultEntry ResultEntry => Result as ResultEntry;

        public ResultMail ResultMail => Result as ResultMail;

        public ResultSSH ResultSSH => Result as ResultSSH;


        public string MachineName => TestCLI.MachineName;

        public List<Trace> Traces;



        public ExampleResult(TestCLI testCLI, string command, Result result) {
            Result = result;
            Command = command;
            TestCLI = testCLI;
            }





        }

    public partial class ResultDirect : Result {

        public string Output;

        public override string ToString() => Output;

        }

    public partial class TestCLI : CommandLineInterpreter {
        public TestShell Shell;

        public List<Result> Results = new();
        public Result Last => Results[^1];


        public int ErrorCount = 0;
        public static int ErrorCountTotal { get; set; } = 0;


        public int Count = 0;
        public static int CountTotal { get; set; } = 0;

        public TestCLI(TestShell shell) : base() => Shell = shell;
        public string MachineName => Shell.MachineName;


        public ExampleResult DumpFile(string filename) {
            string output;
            try {
                output = filename.OpenReadToEnd();
                }
            catch {
                output = "Error: File Not Found";
                }

            string cmd = $"type {filename}";
            var result = new ResultDirect() {
                Output = output + "\n"
                };
            return new ExampleResult(this, cmd, result);


            }


        public List<ExampleResult> Example(params string[] commands) {
            var result = new List<ExampleResult>();

            //var Args = command.Split(' ');
            //Dispatcher(Entries, DefaultCommand, Shell, Args, 0);
            //result.Add(new ExampleResult(command, Shell.ShellResult as Result));

            foreach (var cmd in commands) {
                Count++;
                CountTotal++;
                try {
                    Shell.MeshMachineTest.MeshProtocolMessages.Clear();

                    Dispatcher(Entries, DefaultCommand, Shell, cmd.Split(' '), 0);
                    result.Add(new ExampleResult(this, cmd, Shell.ShellResult as Result) {
                        Traces = new (Shell.MeshMachineTest.MeshProtocolMessages)
                        });
                    }
                catch (Exception exception) {
                    ErrorCount++;
                    ErrorCountTotal++;

                    var cmdresult = new Result() {
                        Success = false,
                        Reason = exception.Message
                        };
                    result.Add(new ExampleResult(this, cmd, cmdresult) {
                        Traces = Shell.MeshMachineTest.MeshProtocolMessages
                        });
                    }
                }

            return result;
            }


        public List<ExampleResult> ExampleNoCatch(params string[] commands) {
            var result = new List<ExampleResult>();

            //var Args = command.Split(' ');
            //Dispatcher(Entries, DefaultCommand, Shell, Args, 0);
            //result.Add(new ExampleResult(command, Shell.ShellResult as Result));

            foreach (var cmd in commands) {
                Count++;
                CountTotal++;
                Shell.MeshMachineTest.MeshProtocolMessages = new();


                Dispatcher(Entries, DefaultCommand, Shell, cmd.Split(' '), 0);
                result.Add(new ExampleResult(this, cmd, Shell.ShellResult as Result) {
                    Traces = Shell.MeshMachineTest.MeshProtocolMessages
                    });

                }

            return result;
            }


        public Result Dispatch(string command, bool fail = false) {
            var Args = command.Split(' ');

            if (!fail) {
                Dispatcher(Entries, DefaultCommand, Shell, Args, 0);
                var result = Shell.ShellResult as Result;
                result.Success.TestTrue();
                return result;
                }
            else {
                try {
                    Dispatcher(Entries, DefaultCommand, Shell, Args, 0);
                    var result = Shell.ShellResult as Result;
                    if (result.Success) {
                        throw new TestExpectedFalse();
                        }
                    return result;
                    }
                catch (TestExpectedFalse) {
                    throw new TestExpectedFalse();
                    }
                catch {
                    return Shell.ShellResult as Result;
                    }
                }
            }

        public Result CreateAccount(string account) => Dispatch($"mesh create /service={account}");


        //public bool AssertAccount(int count = -1, string account = null, bool exists = true) => throw new NYI();

        public bool FailPasswordResult(string site) {
            var result = Dispatch($"password get {site}", fail: true) as ResultEntry;
            result.Future();
            return true;
            }

        public bool CheckPasswordResult(string site, string username, string password) {
            var result = Dispatch($"password get {site}") as ResultEntry;
            var entry = result.CatalogEntry as CatalogedCredential;

            (site == entry.Service).TestTrue();
            (username == entry.Username).TestTrue();
            (password == entry.Password).TestTrue();
            return true;
            }

        public bool FailContactResult(string site) {
            var result = Dispatch($"contact get {site}", fail: true) as ResultEntry;
            return true;
            }

        public bool CheckContactResult(string key, string email) {

            email.Future();

            var result = Dispatch($"contact get {key}") as ResultEntry;
            var entry = result.CatalogEntry as CatalogedContact;

            (key == entry.Key).TestTrue();
            return true;
            }

        public bool FailBookmarkResult(string path) {
            var result = Dispatch($"bookmark get {path}", fail: true) as ResultEntry;
            return true;
            }

        public bool CheckBookmarkResult(string path, string uri, string title) {
            var result = Dispatch($"bookmark get {path}") as ResultEntry;
            var entry = result.CatalogEntry as CatalogedBookmark;

            (uri == entry.Uri).TestTrue();
            (title == entry.Title).TestTrue();
            (path == entry.Path).TestTrue();
            return true;
            }

        public bool FailTaskResult(string site) {
            var result = Dispatch($"calendar get {site}", fail: true) as ResultEntry;
            return true;
            }

        public bool CheckTaskResult(string key, string title) {

            title.Future();

            var result = Dispatch($"calendar get {key}") as ResultEntry;
            var entry = result.CatalogEntry as CatalogedTask;

            (key == entry.Key).TestTrue();
            return true;
            }

        public bool FailNetworkResult(string site) {
            var result = Dispatch($"network get {site}", fail: true) as ResultEntry;
            return true;
            }

        public bool CheckNetworkResult(string key, string password) {
            var result = Dispatch($"network get {key}") as ResultEntry;
            var entry = result.CatalogEntry as CatalogedNetwork;

            (key == entry.Service).TestTrue();
            (password == entry.Password).TestTrue();
            return true;
            }


        public ResultSync Connect(TestCLI newDevice, string account) {
            var result = Dispatch($"account pin /web") as ResultPIN;
            var pin = result.MessagePIN.Pin;

            newDevice.Dispatch($"device request {account} /pin {pin}");
            var resultsync = Dispatch($"account sync /auto") as ResultSync;

            // failing because we are not correctly matching PIN allocation to requests
            newDevice.Dispatch($"device complete");
            newDevice.Dispatch($"account sync");


            return resultsync;
            }



        public void CheckHostCatalogExtended() => Shell.MeshMachineTest.CheckHostCatalogExtended();
        }


    }
