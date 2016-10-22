using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using Goedel.Utilities;

namespace Goedel.Cryptography.KeyFile {

    /// <summary>
    /// Lexical analyzer for parsing the OpenSSH public key format and
    /// authorized_keys file.
    /// </summary>
    public partial class AuthKeysFileLex {
        StringBuilder BuildTag1 = new StringBuilder();
        StringBuilder BuildTag2 = new StringBuilder();
        StringBuilder BuildBase64 = new StringBuilder();

        /// <summary>
        /// Add characters to the algorithm
        /// </summary>
        /// <param name="c"></param>
        public virtual void AddAlgorithm(int c) {
            BuildTag1.Append(c.ToASCII());
            }

        /// <summary>
        /// Add characters to the base64 encoded data section
        /// </summary>
        /// <param name="c"></param>
        public virtual void AddData(int c) {
            BuildBase64.Append(c.ToASCII());
            }

        /// <summary>
        /// Add characters to the comment section
        /// </summary>
        /// <param name="c"></param>
        public virtual void AddComment(int c) {
            BuildTag2.Append(c.ToASCII());
            }

        /// <summary>
        /// Do nothing
        /// </summary>
        /// <param name="c"></param>
        public virtual void Ignore(int c) {
            }


        /// <summary>
        /// Retrieve tagged data and reset lexical analyzer to read the next line
        /// </summary>
        /// <returns>A public key record</returns>
        public AuthorizedKey GetTaggedData() {

            var Base64Data = BuildBase64.ToString();
            var Data = BaseConvert.FromBase64urlString(Base64Data);
            var Decoded = SSHData.Decode(Data);

            var Result = new AuthorizedKey {
                Algorithm = BuildTag1.ToString(),
                Comment = BuildTag2.ToString(),
                Data = Data,
                SSHData = Decoded
                };

            BuildTag1.Clear();
            BuildTag2.Clear();
            BuildBase64.Clear();

            return Result;
            }

        }

    /// <summary>
    /// A key authorization entry.
    /// </summary>
    public struct AuthorizedKey {

        /// <summary>
        /// The raw key data.
        /// </summary>
        public byte[] Data;

        /// <summary>
        /// The key algorithm
        /// </summary>
        public string Algorithm;

        /// <summary>
        /// Optional user comment
        /// </summary>
        public string Comment;

        /// <summary>
        /// The parsed key data
        /// </summary>
        public SSHData SSHData;
        }


    }
