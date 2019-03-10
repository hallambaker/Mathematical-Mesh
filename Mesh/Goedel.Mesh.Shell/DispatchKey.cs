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
            var bits = 140;
            var bitsid = Math.Min(bits*2, 440);

            var key = Cryptography.UDF.SymmetricKey(bits);
            var identifier = Cryptography.UDF.ContentDigestOfDataString(key.ToUTF8(), 
                    UDFConstants.UDFEncryption, bits= bitsid);


            return new ResultKey() {
                Success = true,
                Key = key,
                Identifier= identifier
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
                Identifier= secret.UDFIdentifier,
                Shares = textShares
                };
            }

        public override ShellResult KeyRecover(KeyRecover Options) {
            CommandLineInterpreter.DescribeValues(Options);
            return null;
            }
        }
    }
