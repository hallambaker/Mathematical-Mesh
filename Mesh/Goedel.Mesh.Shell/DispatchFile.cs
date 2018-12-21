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


        public override ShellResult FileEncrypt(FileEncrypt Options) {
            throw new NYI();
            }

        public override ShellResult FileDecrypt(FileDecrypt Options) {
            throw new NYI();
            }

        public override ShellResult FileRandom(FileRandom Options) {
            return new ResultDigest() {
                Success = true,
                Digest = Cryptography.UDF.Random()
                };
            }

        public override ShellResult FileUDF(FileUDF Options) {
            var inputFile = Options.Input.Value;
            var contentType = Options.ContentType.Value ?? MimeMapping.GetMimeMapping(inputFile) ?? "";
            var hashAlgorithm = Options.AlgDigest.Value.ToCryptoAlgorithmID(CryptoAlgorithmID.SHA_2_512);

            var contentDigest = inputFile.GetDigest(hashAlgorithm);
            var digest = Cryptography.UDF.DigestToFormat(contentDigest, contentType, cryptoAlgorithmID: hashAlgorithm) ;

            return new ResultDigest() {
                Success = true,
                Digest = digest
                };
            }


        public override ShellResult FileDigest(FileDigest Options) {
            var inputFile = Options.Input.Value;
            return new ResultDigest() {
                Success = true,
                Digest = inputFile.GetDigest(Options.AlgDigest.Value).ToStringBase16()
                };
            }



        public override ShellResult FileCommitment(FileCommitment Options) {
            var inputFile = Options.Input.Value;
            var hashAlgorithm = Options.AlgDigest.Value.ToCryptoAlgorithmID(CryptoAlgorithmID.SHA_2_512);
            var key = Options.DigestKey.Value ?? Cryptography.UDF.Random();

            var contentDigest = inputFile.GetDigest(hashAlgorithm);
            var digest = Cryptography.UDF.DigestToFormat(contentDigest, key, cryptoAlgorithmID: hashAlgorithm);

            return new ResultDigest() {
                Success = true,
                Digest = digest,
                Key = key
                };
            }


        }
    }
