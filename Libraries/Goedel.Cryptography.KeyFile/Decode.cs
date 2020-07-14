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
        /// <param name="fileName">File to decode.</param>
        /// <returns>List of authorized keys</returns>
        public static List<AuthorizedKey> DecodeAuthHost(string fileName) {
            using var TextReader = fileName.OpenFileReadShared();
            using LexReader LexReader = new LexReader(TextReader);
            return DecodeAuthHost(LexReader);
            }

        /// <summary>
        /// Decode an authorized hosts format file.
        /// </summary>
        /// <param name="lexReader">Input</param>
        /// <returns>List of authorized keys</returns>
        public static List<AuthorizedKey> DecodeAuthHost(LexReader lexReader) {
            List<AuthorizedKey> Result = new List<AuthorizedKey>();

            try {
                using var Lexer = new AuthKeysFileLex(lexReader);
                var Token = Lexer.GetToken();
                while (Token == AuthKeysFileLex.Token.Data) {
                    var TaggedData = Lexer.GetTaggedData();
                    Result.Add(TaggedData);
                    Token = Lexer.GetToken();
                    }
                }
            catch (System.Exception inner) {
                throw new ParseError(inner: inner, args: lexReader.FilePath);
                }

            return Result;
            }



        /// <summary>
        /// Decode PEM format key file.
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <returns>Public key information</returns>
        /// <param name="keySecurity">The key security model</param>
        /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
        /// the value of <paramref name="keySecurity"/></param>
        public static KeyPair DecodePEM(string fileName,
            KeySecurity keySecurity, keyCollection keyCollection) {
            using var TextReader = fileName.OpenFileReadShared();
            LexReader LexReader = new LexReader(TextReader);
            return DecodePEM(LexReader, keySecurity, keyCollection);
            }

        /// <summary>
        /// Decode PEM format key file.
        /// </summary>
        /// <param name="text">Text input.</param>
        /// <returns>Public key information</returns>
        /// <param name="keySecurity">The key security model</param>
        /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
        /// the value of <paramref name="keySecurity"/></param>
        public static KeyPair DecodePEMText(string text,
            KeySecurity keySecurity, keyCollection keyCollection) {
            var Reader = new System.IO.StringReader(text);
            LexReader LexReader = new LexReader(Reader);
            return DecodePEM(LexReader, keySecurity, keyCollection);
            }


        /// <summary>
        /// Decode PEM format key file.
        /// </summary>
        /// <param name="lexReader">Input file.</param>
        /// <returns>Public key information</returns>
        /// <param name="keySecurity">The key security model</param>
        /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
        /// the value of <paramref name="keySecurity"/></param>
        public static KeyPair DecodePEM(LexReader lexReader,
                    KeySecurity keySecurity, keyCollection keyCollection) {
            using var Lexer = new KeyFileLex(lexReader);
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
