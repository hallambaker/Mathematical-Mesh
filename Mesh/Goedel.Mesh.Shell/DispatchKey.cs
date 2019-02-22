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
            Key = Cryptography.UDF.Nonce()
            };

        /// <summary>
        /// Dispatch method to return a randomized string suitable for use as
        /// a password.
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult KeySecret(KeySecret Options) => new ResultKey() {
            Success = true,
            Key = Cryptography.UDF.SymmetricKey()
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
            var identifier = Cryptography.UDF.DataToFormat(key.ToUTF8(), 
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

            var bits = 140;
            var bitsid = Math.Min(bits * 2, 440);

            var secret = new Secret(128);

            // should be Secret.id and secret.string

            var keyShares = secret.Split(shares, quorum);
            // the secrets should be in udf form as well.
            var textShares = new List<string>();
            foreach (var share in keyShares) {
                textShares.Add(share.Text);
                }

            var key = Cryptography.UDF.SymmetricKey(bits);
            var identifier = Cryptography.UDF.DataToFormat(key.ToUTF8(),
                    UDFConstants.UDFEncryption, bits= bitsid);


            return new ResultKey() {
                Success = true,
                Key = key,
                Identifier= identifier,
                Shares = textShares
                };
            }


        }
    }
