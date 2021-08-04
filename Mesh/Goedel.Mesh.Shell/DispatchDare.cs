#region // Copyright
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion

using System.IO;

using Goedel.Cryptography.Dare;
using Goedel.Utilities;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DareEncode(DareEncode options) {
            var inputFile = options.Input.Value;
            var outputFile = options.Output.Value ?? Path.ChangeExtension(inputFile, ".dare");
            var contentType = options.ContentType.Value ?? MimeMapping.GetMimeMapping(inputFile) ?? "";

            var keyLocate = GetKeyCollection(options);

            var cryptoParameters = GetCryptoParameters(keyLocate, options);

            //Screen.WriteLine($"***Encrypt to {cryptoParameters.EncryptionKeys?[0].KeyIdentifier}");
            var ContentInfo = new ContentMeta() {
                Filename = inputFile,
                ContentType = contentType
                };


            var Length = DareEnvelope.Encode(cryptoParameters, inputFile, outputFile,
                contentMeta: ContentInfo);

            return new ResultFile() {
                Filename = outputFile,
                TotalBytes = (int)Length
                };

            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>)
        /// <returns>Mesh result instance</returns>
        public override ShellResult DareDecode(DareDecode options) {
            var inputFile = options.Input.Value;
            var outputFile = options.Output.Value ?? Path.ChangeExtension(inputFile, ".xdare");
            //var keyLocate = GetKeyCollection(options);

            var contextAccount = GetContextUser(options);
            var Length = DareEnvelope.Decode(inputFile, outputFile, keyCollection: contextAccount);

            return new ResultFile() {
                TotalBytes = (int)Length
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DareVerify(DareVerify options) {
            var inputFile = options.Input.Value;
            var contextAccount = GetContextUser(options);

            var result = DareEnvelope.Verify(inputFile, contextAccount);

            "Should check that the signature value is correct".TaskFunctionality();

            return new ResultFileDare() {
                Verified = true, // Hack: Should test here!!!!
                TotalBytes = (int)result.PayloadLength,
                Filename = inputFile,
                Envelope = result
                };
            }



        /// <summary>
        /// Dispatch method for the 
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DareEARL(DareEARL options) {
            var inputFile = options.Input.Value;
            var outputDirectory = options.Directory.Value;
            var domain = options.Domain.Value;
            var log = options.Log.Value;
            var recipient = options.Admin.Value;

            using var keyLocate = GetContextUser(options);

            var result = EARL.Encode(inputFile, out var outputFile, domain,
                outputDirectory, log, recipient);


            return new ResultFileEARL() {
                Source = inputFile,
                Created = outputFile,
                URI = result
                };
            }





        }
    }
