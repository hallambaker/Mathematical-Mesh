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

using Goedel.Mesh.Test;

using System.Collections.Generic;

namespace ExampleGenerator;

public class ShellSSH : ExampleSet {
    public List<ExampleResult> SSHCreate;
    public List<ExampleResult> SSHPrivate;
    public List<ExampleResult> SSHPublic;
    public List<ExampleResult> SSHMergeClients;
    public List<ExampleResult> SSHMergeHosts;
    public List<ExampleResult> SSHAddClient;
    public List<ExampleResult> SSHShowClient;
    public List<ExampleResult> SSHAddHost;
    public List<ExampleResult> SSHShowKnown;
    public List<ExampleResult> SSHAuthDev;
    public List<ExampleResult> SSHAuthProof;

    public const string SSHFilePublic = "ssh-key.public";
    public const string SSHFilePrivate = "ssh-key.public";
    public const string SSHFileKnownHosts = "ssh-key.public";
    public const string SSHFileAuthKeys = "ssh-key.public";


    public ShellSSH(CreateExamples createExamples) :
        base(createExamples) {
        //SSHCreate = testCLIAlice1.Example($"ssh create");
        //SSHPrivate = testCLIAlice1.Example($"ssh private {SSHFilePrivate}");
        //SSHPublic = testCLIAlice1.Example($"ssh public {SSHFilePublic}");
        //SSHMergeClients = testCLIAlice1.Example($"ssh merge client");
        //SSHMergeHosts = testCLIAlice1.Example($"ssh merge host");
        //SSHAddClient = testCLIAlice1.Example($"ssh add client");
        //SSHShowClient = testCLIAlice1.Example($"ssh show client");
        //SSHAddHost = testCLIAlice1.Example($"ssh add host");
        //SSHShowKnown = testCLIAlice1.Example($"ssh show host");

        //SSHAuthDev = testCLIAlice1.Example($"device auth {AliceDevice2} /ssh");
        //SSHAuthProof = testCLIAlice1.Example($"ssh show host");
        }

    }
