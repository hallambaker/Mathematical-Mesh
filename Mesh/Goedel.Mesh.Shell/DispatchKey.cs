using Goedel.Cryptography;
using Goedel.Utilities;

using System;
using System.Collections.Generic;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method to return a randomized string suitable for use as
        /// a password.
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult KeyNonce(KeyNonce options) => new ResultKey() {
            Success = true,
            Key = Cryptography.UDF.Nonce(options.Bits.ValueDefaulted(128))
            };

        /// <summary>
        /// Dispatch method to return a randomized string suitable for use as
        /// a password.
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult KeySecret(KeySecret options) => new ResultKey() {
            Success = true,
            Key = Cryptography.UDF.SymmetricKey(options.Bits.ValueDefaulted(128))
            };


        /// <summary>
        /// Dispatch method to return a randomized string suitable for use as
        /// a password.
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult KeyEarl(KeyEarl options) {
            var bits = options.Bits.ValueDefaulted(140);
            var bitsid = Math.Min(bits * 2, 440);

            var key = Cryptography.UDF.SymmetricKey(bits);
            var identifier = Cryptography.UDF.ContentDigestOfDataString(key.ToUTF8(),
                    UDFConstants.UDFEncryption, bits = bitsid);


            return new ResultKey() {
                Success = true,
                Key = key,
                Identifier = identifier
                };
            }

        /// <summary>
        /// Dispatch method to return a randomized string suitable for use as
        /// a password.
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult KeyShare(KeyShare options) {
            var quorum = options.Quorum.Value;
            var shares = options.Shares.Value;
            var bits = options.Bits.ValueDefaulted(128);
            var secretUDF = options.Secret.Value;

            var secret = secretUDF == null ? new SharedSecret(bits) : new SharedSecret(secretUDF);

            var keyShares = secret.Split(shares, quorum);
            // the secrets should be in udf form as well.
            var textShares = new List<string>();
            foreach (var share in keyShares) {
                textShares.Add(share.UDFKey);
                }

            return new ResultKey() {
                Success = true,
                Key = secret.UDFKey,
                Identifier = secret.UDFIdentifier,
                Shares = textShares
                };
            }


        List<string> MakeList(params string[] shares) {
            var result = new List<string>();
            foreach (var share in shares) {
                if (share != null) {
                    result.Add(share);
                    }
                }

            return result;
            }

        /// <summary>
        /// Recover key from <paramref name="options"/>
        /// </summary>
        /// <param name="options">Options containing shares.</param>
        /// <returns>The recovered key.</returns>
        public override ShellResult KeyRecover(KeyRecover options) {
            var s1 = options.Share1.Value;
            var s2 = options.Share2.Value;
            var s3 = options.Share3.Value;
            var s4 = options.Share4.Value;
            var s5 = options.Share5.Value;
            var s6 = options.Share6.Value;
            var s7 = options.Share7.Value;
            var s8 = options.Share8.Value;

            var shares = MakeList(s1, s2, s3, s4, s5, s6, s7, s8);
            var secret = new SharedSecret(shares);

            return new ResultKey() {
                Success = true,
                Key = secret.UDFKey,
                };
            }
        }
    }
