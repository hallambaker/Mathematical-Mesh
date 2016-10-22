using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.PKIX;
using Goedel.FSR;
using Goedel.IO;

namespace Goedel.Cryptography.KeyFile {



    /// <summary>
    /// Encoders and decoders for various key file formats
    /// </summary>
    public static class KeyFile {

        /// <summary>
        /// Decode SSH Authorized Key file format
        /// </summary>
        /// <param name="FileName">File to decode.</param>
        public static void DecodeAuthHost(string FileName) {
            using (var TextReader = FileName.OpenFileReadShared()) {
                LexReader LexReader = new LexReader(TextReader);
                DecodeAuthHost(LexReader);
                }
            }

        public static void DecodeAuthHost(LexReader LexReader) {
            List<AuthorizedKey> Result = new List<AuthorizedKey>();


            try {
                var Lexer = new AuthKeysFileLex(LexReader);

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

            }




        public static KeyPair DecodePEM(string FileName) {
            using (var TextReader = FileName.OpenFileReadShared()) {
                LexReader LexReader = new LexReader(TextReader);
                return DecodePEM(LexReader);
                }
            }

        public static KeyPair DecodePEMText(string Text) {
            var Reader = new System.IO.StringReader(Text);
            LexReader LexReader = new LexReader(Reader);
            return DecodePEM(LexReader);
            }

        public static KeyPair DecodePEM (LexReader LexReader) {
            var Lexer = new KeyFileLex(LexReader);
            var Token = Lexer.GetToken();

            if (Token == KeyFileLex.Token.Data) {
                var TaggedData = Lexer.GetTaggedData();
                if (!TaggedData.Strict) {
                    Console.WriteLine("Some yukky data here");

                    }

                if (TaggedData.Tag == " RSA PRIVATE KEY") {
                    return DecodeRSAKeyPair(TaggedData.Data);
                    }



                }


            return null;
            }


        static KeyPair DecodeRSAKeyPair (byte[] Data) {

            var PrivateKey = new RSAPrivateKey(Data);

            var RSAParameters = PrivateKey.RSAParameters;
            RSAParameters.Dump();


            //PrivateKey.Dump();

            var RSAKeyPair = new RSAKeyPair(RSAParameters);


            return RSAKeyPair;
            }

        }
    }
