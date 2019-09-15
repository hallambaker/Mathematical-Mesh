using System;
using System.IO;
using Goedel.Mesh.Test;
using Goedel.Mesh.Shell;
using Goedel.Test.Core;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Utilities;
using System.Linq;
using Goedel.Cryptography;
using System.Numerics;
using System.Collections.Generic;
using Goedel.Test;


namespace ExampleGenerator {


    public partial class CreateExamples {



        public ResultKey ResultUDFNonce;
        public ResultKey ResultUDFSecret;
        public ResultKey ResultUDFEARL;
        public ResultKey ResultUDFShares;



        public ResultDigest ResultDigestSHA2;
        public ResultDigest ResultDigestSHA3;

        public ResultDigest ResultCommitSHA2;
        public ResultDigest ResultCommitSHA3;

        public Secret UDFSplitSecret;
        public Goedel.Cryptography.KeyShare[] UDFSplitShares;
        public BigInteger[] UDFSplitPolynomial;

        public string TestStringValue = "UDF Content Data";


        public KeyPairEd25519 PublicKeyed25519;

        public void PlatformUDF() {
            // ToDo: need to do full cleanup on the key splitting.
            // ToDo: use the new primes
            // ToDo: also new method of compression


            var testCLI = GetTestCLI();
            ResultUDFNonce = testCLI.Dispatch("key nonce") as ResultKey;

            ResultUDFSecret = testCLI.Dispatch("key share /quorum=2 /shares=3") as ResultKey;
            ResultUDFEARL = testCLI.Dispatch("key earl") as ResultKey;

            var filename = TestStringValue.ToFileUnique();
            ResultDigestSHA2 = testCLI.Dispatch($"hash udf {filename} /alg sha2") as ResultDigest;
            ResultDigestSHA3 = testCLI.Dispatch($"hash udf {filename} /alg sha3") as ResultDigest;
            ResultCommitSHA2 = testCLI.Dispatch($"hash mac {filename} /alg sha2 /key {ResultUDFNonce.Key}") as ResultDigest;

            UDFSplitSecret = new Secret(128);
            UDFSplitShares = UDFSplitSecret.Split(5, 3, out UDFSplitPolynomial);

            PublicKeyed25519 = KeyPair.Factory(CryptoAlgorithmID.Ed25519, KeySecurity.Exportable)
                as KeyPairEd25519;

            var test = PublicKeyed25519.KeyInfoData;
            test.DER();
            var _ = PublicKeyed25519.UDF;
            }


        }
    }
