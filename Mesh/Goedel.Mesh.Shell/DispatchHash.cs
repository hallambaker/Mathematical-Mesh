﻿using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult HashUDF(HashUDF options) {
            var inputFile = options.Input.Value;
            var contentType = options.ContentType.Value ?? MimeMapping.GetMimeMapping(inputFile) ?? "";
            var bits = options.Bits.ValueDefaulted(140);
            var hashAlgorithm = AlgorithmDigest.DefaultBulk(CryptoAlgorithmId.SHA_2_512);
            var expect = options.Expect.Value;


            var contentDigest = inputFile.GetDigestOfFile(hashAlgorithm);
            var digest = Cryptography.UDF.ContentDigestOfDigestString(
                contentDigest, contentType, cryptoAlgorithmId: hashAlgorithm, bits: bits);

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
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult HashDigest(HashDigest options) {
            var inputFile = options.Input.Value;
            var hashAlgorithm = AlgorithmDigest.DefaultBulk(CryptoAlgorithmId.SHA_2_512);

            return new ResultDigest() {
                Success = true,
                Digest = inputFile.GetDigestOfFile(hashAlgorithm).ToStringBase16()
                };
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult HashMac(HashMac options) {
            var inputFile = options.Input.Value;
            var bits = options.Bits.ValueDefaulted(140);
            var contentType = options.ContentType.Value ?? MimeMapping.GetMimeMapping(inputFile) ?? "";
            var hashAlgorithm = AlgorithmDigest.DefaultBulk(CryptoAlgorithmId.SHA_2_512);
            var expect = options.Expect.Value;

            var key = options.DigestKey.Value ?? Cryptography.UDF.Nonce();

            var contentDigest = inputFile.GetDigestOfFile(hashAlgorithm);
            var digest = Cryptography.UDF.ContentDigestOfDigestString(
                contentDigest, contentType, cryptoAlgorithmId: hashAlgorithm, key: key, bits: bits);

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
