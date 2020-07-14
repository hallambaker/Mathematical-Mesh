using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult HashUDF(HashUDF Options) {
            var inputFile = Options.Input.Value;
            var contentType = Options.ContentType.Value ?? MimeMapping.GetMimeMapping(inputFile) ?? "";
            var bits = Options.Bits.ValueDefaulted(140);
            var hashAlgorithm = AlgorithmDigest.DefaultBulk(CryptoAlgorithmId.SHA_2_512);
            var expect = Options.Expect.Value;


            var contentDigest = inputFile.GetDigestOfFile(hashAlgorithm);
            var digest = Cryptography.UDF.ContentDigestOfDigestString(
                contentDigest, contentType, cryptoAlgorithmID: hashAlgorithm, bits: bits);

            if (expect == null) {

                return new ResultDigest() {
                    Success = true,
                    Digest = digest
                    };
                }

            Assert.AssertTrue(expect.CompareUDF(digest), DidNotMatchExpectedValue.Throw);

            return new ResultDigest() {
                Success = true,
                Digest = digest,
                Verified = true
                };

            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult HashDigest(HashDigest Options) {
            var inputFile = Options.Input.Value;
            var hashAlgorithm = AlgorithmDigest.DefaultBulk(CryptoAlgorithmId.SHA_2_512);

            return new ResultDigest() {
                Success = true,
                Digest = inputFile.GetDigestOfFile(hashAlgorithm).ToStringBase16()
                };
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult HashMac(HashMac Options) {
            var inputFile = Options.Input.Value;
            var bits = Options.Bits.ValueDefaulted(140);
            var contentType = Options.ContentType.Value ?? MimeMapping.GetMimeMapping(inputFile) ?? "";
            var hashAlgorithm = AlgorithmDigest.DefaultBulk(CryptoAlgorithmId.SHA_2_512);
            var expect = Options.Expect.Value;

            var key = Options.DigestKey.Value ?? Cryptography.UDF.Nonce();

            var contentDigest = inputFile.GetDigestOfFile(hashAlgorithm);
            var digest = Cryptography.UDF.ContentDigestOfDigestString(
                contentDigest, contentType, cryptoAlgorithmID: hashAlgorithm, key: key, bits: bits);

            if (expect == null) {

                return new ResultDigest() {
                    Success = true,
                    Digest = digest,
                    Key = key
                    };
                }

            Assert.AssertTrue(expect.CompareUDF(digest), DidNotMatchExpectedValue.Throw);

            return new ResultDigest() {
                Success = true,
                Digest = digest,
                Verified = true,
                Key = key
                };
            }


        }
    }
