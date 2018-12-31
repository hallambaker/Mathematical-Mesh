using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.IO;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method to return a randomized string suitable for use as
        /// a password.
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult FileRandom(FileRandom Options) => new ResultDigest() {
            Success = true,
            Digest = Cryptography.UDF.Random()
            };

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult FileUDF(FileUDF Options) {
            var inputFile = Options.Input.Value;
            var contentType = Options.ContentType.Value ?? MimeMapping.GetMimeMapping(inputFile) ?? "";
            var hashAlgorithm = Options.AlgDigest.Value.ToCryptoAlgorithmID(CryptoAlgorithmID.SHA_2_512);

            var contentDigest = inputFile.GetDigestOfFile(hashAlgorithm);
            var digest = Cryptography.UDF.DigestToFormat(contentDigest, contentType, cryptoAlgorithmID: hashAlgorithm);

            return new ResultDigest() {
                Success = true,
                Digest = digest
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult FileDigest(FileDigest Options) {
            var inputFile = Options.Input.Value;
            return new ResultDigest() {
                Success = true,
                Digest = inputFile.GetDigestOfFile(Options.AlgDigest.Value).ToStringBase16()
                };
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult FileCommitment(FileCommitment Options) {
            var inputFile = Options.Input.Value;
            var contentType = Options.ContentType.Value ?? MimeMapping.GetMimeMapping(inputFile) ?? "";
            var hashAlgorithm = Options.AlgDigest.Value.ToCryptoAlgorithmID(CryptoAlgorithmID.SHA_2_512);
            var key = Options.DigestKey.Value ?? Cryptography.UDF.Random();

            var contentDigest = inputFile.GetDigestOfFile(hashAlgorithm);
            var digest = Cryptography.UDF.DigestToFormat(
                contentDigest, contentType, cryptoAlgorithmID: hashAlgorithm, key: key);

            return new ResultCommitment() {
                Success = true,
                Digest = digest,
                Key = key
                };
            }


        }
    }
