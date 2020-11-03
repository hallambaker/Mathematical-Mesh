using Goedel.Mesh.Test;

using System.Collections.Generic;

namespace ExampleGenerator {
    public class ShellNetwork : ExampleSet {
        public List<ExampleResult> NetworkAdd;
        public List<ExampleResult> NetworkGet;
        public List<ExampleResult> NetworkList;

        public List<ExampleResult> NetworkDelete;
        public List<ExampleResult> NetworkAuth;

        public const string NetworkFile1 = "NetworkEntry1.json";
        public const string NetworkFile2 = "NetworkEntry2.json";
        public const string NetworkID1 = "NetID1";
        public const string NetworkID2 = "NetID2";

        public List<ExampleResult> NetworkList2;

        public ShellNetwork(CreateExamples createExamples) :
                base(createExamples) {
            NetworkAdd = testCLIAlice1.Example($"network add {NetworkFile1} {NetworkID1}",
                $"network add {NetworkFile2} {NetworkID2}");
            NetworkGet = testCLIAlice1.Example($"network get {NetworkID2}");
            NetworkList = testCLIAlice1.Example($"network list");

            NetworkDelete = testCLIAlice1.Example($"network delete {NetworkID2}",
                $"network list");
            }
        }
    }
