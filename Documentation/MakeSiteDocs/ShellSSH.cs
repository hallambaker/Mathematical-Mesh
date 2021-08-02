using System.Collections.Generic;

using Goedel.Mesh.Test;

namespace ExampleGenerator {
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
    }
