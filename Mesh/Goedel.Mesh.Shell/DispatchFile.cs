using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.IO;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh.Shell {
    public partial class Shell {


        public override ShellResult FileEncrypt(FileEncrypt Options) {
            throw new NYI();
            }

        public override ShellResult FileDecrypt(FileDecrypt Options) {
            throw new NYI();
            }

        public override ShellResult FileRandom(FileRandom Options) {
            return new ResultRandom() {
                Success = true,
                Data = Goedel.Cryptography.UDF.Random()
                };
            }

        public override ShellResult FileDigest(FileDigest Options) {

            var hashAlgorithm = Options.AlgDigest.Value.FromUncasedID();
            var hashProvider = hashAlgorithm.CreateDigest();
            var inputFile = Options.Input.Value;

            using (var inputStream = inputFile.OpenFileRead()) {
                using (var cryptoStream = new CryptoStream(Stream.Null, hashProvider, CryptoStreamMode.Write)) {
                    inputStream.CopyTo(cryptoStream);
                    }
                }
            var result = hashAlgorithm.Hash;
            return new ResultDigest() {
                Success = true,
                Data = result.ToStringBase16()
                };
            }



        public override ShellResult FileCommitment(FileCommitment Options) => throw new NYI();


        }
    }
