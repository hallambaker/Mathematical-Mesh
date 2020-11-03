using Goedel.Mesh.Test;
using Goedel.Mesh.Shell;

using System.Collections.Generic;

namespace ExampleGenerator {
    public class ShellKey : ExampleSet {
        public List<ExampleResult> KeyNonce;
        public List<ExampleResult> KeyNonce256;
        public List<ExampleResult> KeySecret;
        public List<ExampleResult> KeySecret256;
        public List<ExampleResult> KeyEarl;

        public List<ExampleResult> KeyShare;
        public List<ExampleResult> KeyRecover;
        public List<ExampleResult> KeyShare2;
        public List<ExampleResult> KeyShare3;


        ////AdvancedQuantum
        public byte[] AdvancedQuantumMasterSecret;
        public string[] AdvancedQuantumShares;
        public byte[][] AdvancedQuantumPrivate;
        public byte[] AdvancedQuantumPublic;
        public string AdvancedQuantumPublicUDF;


        public ShellKey(CreateExamples createExamples) :
                base(createExamples) {
            KeyNonce = testCLIAlice1.Example("key nonce");
            KeyNonce256 = testCLIAlice1.Example("key nonce /bits=256");
            KeySecret = testCLIAlice1.Example("key secret");
            KeySecret256 = testCLIAlice1.Example("key secret /bits=256");
            KeyEarl = testCLIAlice1.Example("key earl");
            KeyShare = testCLIAlice1.Example("key share");
            Secret1 = (KeyShare[0].Result as ResultKey).Key;
            var share1 = (KeyShare[0].Result as ResultKey).Shares[0];
            var share2 = (KeyShare[0].Result as ResultKey).Shares[2];

            KeyRecover = testCLIAlice1.Example($"key recover {share1} {share2}");
            KeyShare2 = testCLIAlice1.Example($"key share /quorum=3 /shares=5");
            KeyShare3 = testCLIAlice1.Example($"key share {Secret1}");

            }
        }
    }
