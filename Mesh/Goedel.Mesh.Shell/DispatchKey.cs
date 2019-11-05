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
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult KeyNonce(KeyNonce Options) => new ResultKey() {
            Success = true,
            Key = Cryptography.UDF.Nonce(Options.Bits.ValueDefaulted(128))
            };

        /// <summary>
        /// Dispatch method to return a randomized string suitable for use as
        /// a password.
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult KeySecret(KeySecret Options) => new ResultKey() {
            Success = true,
            Key = Cryptography.UDF.SymmetricKey(Options.Bits.ValueDefaulted(128))
            };


        /// <summary>
        /// Dispatch method to return a randomized string suitable for use as
        /// a password.
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult KeyEarl(KeyEarl Options) {
            var bits = Options.Bits.ValueDefaulted(140);
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
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult KeyShare(KeyShare Options) {
            var quorum = Options.Quorum.Value;
            var shares = Options.Shares.Value;
            var bits = Options.Bits.ValueDefaulted(128);
            var secretUDF = Options.Secret.Value;

            var secret = secretUDF == null ? new Secret(bits) : new Secret(secretUDF);

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


        List<string> makeList(params string[] shares) {
            var result = new List<string>();
            foreach (var share in shares) {
                if (share != null) {
                    result.Add(share);
                    }
                }

            return result;
            }

        public override ShellResult KeyRecover(KeyRecover Options) {
            var s1 = Options.Share1.Value;
            var s2 = Options.Share2.Value;
            var s3 = Options.Share3.Value;
            var s4 = Options.Share4.Value;
            var s5 = Options.Share5.Value;
            var s6 = Options.Share6.Value;
            var s7 = Options.Share7.Value;
            var s8 = Options.Share8.Value;

            var shares = makeList(s1, s2, s3, s4, s5, s6, s7, s7);
            var secret = new Secret(shares);

            return new ResultKey() {
                Success = true,
                Key = secret.UDFKey,
                };
            }
        }
    }
