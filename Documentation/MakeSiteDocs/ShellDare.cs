using Goedel.Mesh.Test;

using System.Collections.Generic;

namespace ExampleGenerator {
    public class ShellDare : ExampleSet {
        public List<ExampleResult> DarePlaintext;
        public List<ExampleResult> DareSymmetric;
        public List<ExampleResult> DareSub;
        public List<ExampleResult> DareMesh;


        public List<ExampleResult> DareVerifyDigest;
        public List<ExampleResult> DareVerifySigned;
        public List<ExampleResult> DareVerifySymmetric;
        public List<ExampleResult> DareVerifySymmetricUnknown;

        public List<ExampleResult> DareDecodePlaintext;
        public List<ExampleResult> DareDecodeSymmetric;
        public List<ExampleResult> DareDecodePrivate;

        public List<ExampleResult> DareEarl;
        public List<ExampleResult> DareEARLLog;
        public List<ExampleResult> DareEARLLogNew;

        public ShellDare(CreateExamples createExamples) :
                base(createExamples) {
            DarePlaintext = Alice1.Example($"dare encode {TestFile1}");
            DareSymmetric = Alice1.Example($"dare encode {TestFile1} /out={TestFile1}.symmetric.dare " +
                        $"/key={Secret1}");
            DareSub = Alice1.Example($"dare encode {TestDir1} /encrypt={Secret1}");
            DareMesh = Alice1.Example($"dare encode {TestFile1} {TestFile1}.mesh.dare" +
                        $"/encrypt={BobAccount} /sign={AliceAccount}");

            DareVerifyDigest = Alice1.Example($"dare verify {TestFile1}.dare");
            DareVerifySigned = Alice1.Example($"dare verify {TestFile1}.mesh.dare");
            DareVerifySymmetricUnknown = Alice1.Example($"dare verify {TestFile1}.symmetric.dare");
            DareVerifySymmetric = Alice1.Example($"dare verify {TestFile1}.symmetric.dare /encrypt={Secret1}");

            DareDecodePlaintext = Alice1.Example($"dare decode {TestFile1}.dare");
            DareDecodeSymmetric = Alice1.Example($"dare decode {TestFile1}.symmetric.dare /encrypt={Secret1}");
            DareDecodePrivate = Alice1.Example($"dare decode {TestFile1}.mesh.dare");

            //            DareEarl = testCLIAlice1.Example($"dare earl {TestFile1} {EARLDomain}");
            //            DareEARLLog = testCLIAlice1.Example($"dare container create {DareLogEarl} /encrypt={AliceService1}",
            //                                                    $"dare earl {TestFile1} /log={DareLogEarl}");
            //            DareEARLLogNew = testCLIAlice1.Example($"dare earl {TestFile1} /new={DareLogEarl}");

            }
        }
    }
