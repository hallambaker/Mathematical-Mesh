using Goedel.Cryptography.PKIX;
using Goedel.FSR;
using Goedel.IO;

using System.Collections.Generic;

namespace Goedel.Cryptography.KeyFile {

    // Feature: Read Bitvise private key
    // Feature: Read PuTTY format private keys.

    /// <summary>
    /// Encoders and decoders for various key file formats
    /// </summary>
    public static class KeyFileDecode {

        /// <summary>
        /// Decode SSH Authorized Key file format
        /// </summary>
        /// <param name="FileName">File to decode.</param>
        /// <returns>List of authorized keys</returns>
        public static List<AuthorizedKey> DecodeAuthHost(string FileName) {
            using var TextReader = FileName.OpenFileReadShared();
            using LexReader LexReader = new LexReader(TextReader);
            return DecodeAuthHost(LexReader);
            }

        /// <summary>
        /// Decode an authorized hosts format file.
        /// </summary>
        /// <param name="LexReader">Input</param>
        /// <returns>List of authorized keys</returns>
        public static List<AuthorizedKey> DecodeAuthHost(LexReader LexReader) {
            List<AuthorizedKey> Result = new List<AuthorizedKey>();

            try {
                using var Lexer = new AuthKeysFileLex(LexReader);
                var Token = Lexer.GetToken();
                while (Token == AuthKeysFileLex.Token.Data) {
                    var TaggedData = Lexer.GetTaggedData();
                    Result.Add(TaggedData);
                    Token = Lexer.GetToken();
                    }
                }
            catch (System.Exception Inner) {
                throw new ParseError(LexReader, Inner);
                }

            return Result;
            }



        /// <summary>
        /// Decode PEM format key file.
        /// </summary>
        /// <param name="FileName">Name of the file</param>
        /// <returns>Public key information</returns>
        /// <param name="keySecurity">The key security model</param>
        /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
        /// the value of <paramref name="keySecurity"/></param>
        public static KeyPair DecodePEM(string FileName,
            KeySecurity keySecurity, KeyCollection keyCollection) {
            using var TextReader = FileName.OpenFileReadShared();
            LexReader LexReader = new LexReader(TextReader);
            return DecodePEM(LexReader, keySecurity, keyCollection);
            }

        /// <summary>
        /// Decode PEM format key file.
        /// </summary>
        /// <param name="Text">Text input.</param>
        /// <returns>Public key information</returns>
        /// <param name="keySecurity">The key security model</param>
        /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
        /// the value of <paramref name="keySecurity"/></param>
        public static KeyPair DecodePEMText(string Text,
            KeySecurity keySecurity, KeyCollection keyCollection) {
            var Reader = new System.IO.StringReader(Text);
            LexReader LexReader = new LexReader(Reader);
            return DecodePEM(LexReader, keySecurity, keyCollection);
            }


        /// <summary>
        /// Decode PEM format key file.
        /// </summary>
        /// <param name="LexReader">Input file.</param>
        /// <returns>Public key information</returns>
        /// <param name="keySecurity">The key security model</param>
        /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
        /// the value of <paramref name="keySecurity"/></param>
        public static KeyPair DecodePEM(LexReader LexReader,
                    KeySecurity keySecurity, KeyCollection keyCollection) {
            using var Lexer = new KeyFileLex(LexReader);
            var Token = Lexer.GetToken();

            if (Token == KeyFileLex.Token.Data) {
                var TaggedData = Lexer.GetTaggedData();
                if (!TaggedData.Strict) {
                    //Console.WriteLine("Some yukky data here");
                    }

                if (TaggedData.Tag == "RSAPRIVATEKEY") {
                    // is ASN.1 format DER modulus/exponent etc.

                    var RSAPrivate = new PKIXPrivateKeyRSA(TaggedData.Data);
                    return KeyPairBaseRSA.KeyPairPrivateFactory(RSAPrivate, keySecurity, keyCollection);
                    }
                else if (TaggedData.Tag == "RSAPUBLICKEY") {
                    // is ASN.1 format DER modulus/exponent
                    var RSAPrivate = new PKIXPrivateKeyRSA(TaggedData.Data);
                    return KeyPairBaseRSA.KeyPairPrivateFactory(RSAPrivate, keySecurity, keyCollection);
                    }
                else if (TaggedData.Tag == "SSH2PUBLICKEY") {
                    var SSH_Public_Key = SSHData.Decode(TaggedData.Data);
                    return SSH_Public_Key.KeyPair;
                    }
                }

            return null;
            }

        }
    }
