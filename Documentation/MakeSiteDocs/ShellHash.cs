using Goedel.Mesh.Test;

using System.Collections.Generic;
using Goedel.Mesh.Shell;

namespace ExampleGenerator {
    public class ShellHash : ExampleSet {
        public List<ExampleResult> HashUDF2;
        public List<ExampleResult> HashUDF3;
        public List<ExampleResult> HashUDF200; // Wrong precision, implement /bits
        public List<ExampleResult> HashUDFExpect; // implement /expect
        public List<ExampleResult> HashDigest;
        public List<ExampleResult> HashDigests;
        public List<ExampleResult> MAC1;  // return the key
        public List<ExampleResult> MAC2;  // implement key option
        public List<ExampleResult> MAC3;  // implement expect option



        public ShellHash(CreateExamples createExamples) :
                base(createExamples) {
            HashUDF2 = testCLIAlice1.Example($"hash udf {TestFile1}");
            var expect2 = (HashUDF2[0].Result as ResultDigest).Digest;
            HashUDF3 = testCLIAlice1.Example($"hash udf {TestFile1} /cty=application/binary",
                                              $"hash udf {TestFile1} /alg=sha3");
            var expect3 = (HashUDF3[0].Result as ResultDigest).Digest;
            HashUDF200 = testCLIAlice1.Example($"hash udf {TestFile1} /bits=200");
            HashUDFExpect = testCLIAlice1.Example($"hash udf {TestFile1} /expect={expect2}",
                                              $"hash udf {TestFile1} /expect={expect3}");
            HashDigest = testCLIAlice1.Example($"hash digest {TestFile1}");
            HashDigests = testCLIAlice1.Example($"hash digest {TestFile1} /alg=sha256",
                                              // $"hash digest {TestFile1} /alg=sha128",
                                              $"hash digest {TestFile1} /alg=sha3256",
                                              $"hash digest {TestFile1} /alg=sha3");
            MAC1 = testCLIAlice1.Example($"hash mac {TestFile1}");
            var key = (MAC1[0].Result as ResultDigest).Key;
            var digest = (MAC1[0].Result as ResultDigest).Digest;

            MAC2 = testCLIAlice1.Example($"hash mac {TestFile1} /key={key}");
            MAC3 = testCLIAlice1.Example($"hash mac {TestFile1} /key={key} /expect={digest}",
                $"hash mac {TestFile1} /key={key} /expect={expect2}");
            }
        }
    }
