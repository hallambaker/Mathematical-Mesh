using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Goedel.Protocol;
using System.Security.Cryptography;

namespace Goedel.Cryptography.Jose {
    class Program {

        static string ExamplePayload = "{\"iss\":\"joe\",\r\n \"exp\":1300819380,\r\n \"http://example.com/is_root\":true}";
        static string ExampleHeader = "{\"typ\":\"JWT\",\r\n \"alg\":\"HS256\"}";

        static string ExampleKey = @"{""kty"":""oct"",
          ""k"":""AyM1SysPpbyDfgZld3umj1qzKObwVMkoqQ-EstJQLr_T-1qS0gZH75
     aKtMN3Yj0iPS4hcgUuTwjAzZr1Z9CAow"",
          ""kid"":""HMAC key used in JWS A.1 example""}";


        static void Main(string[] args) {

            var TagDictionary = Constants.MakeDictionary(Constants.JoseTags);

            var ExamplePayloadBytes = UTF8Encoding.UTF8.GetBytes(ExamplePayload);
            var ExampleHeaderBytes = UTF8Encoding.UTF8.GetBytes(ExampleHeader);

            var Key = new Key(new JSONReader(ExampleKey));
            var Header = new Header(new JSONReader(ExampleHeader));

            //var Signed = Sign(ExampleHeaderBytes, ExamplePayloadBytes, Key);

            // Sign and serialize using JSON
            var JWS = new JoseWebSignature(Header, ExamplePayload);

            Sign(JWS, Key, ExampleHeader);
            byte[] JWSinJSON = JWS.ToJson();
            Console.WriteLine("In JSON:   {0} bytes", JWSinJSON.Length);
            Console.WriteLine("    Protected {0} / Payload {1} / Signature {2}",
                JWS.Protected.Length, JWS.Payload.Length, JWS.Signature.Length);



            // Sign and serialize using JSON-B
            SignB(JWS, Key);
            byte[] JWSinJSONB = JWS.ToJsonB();
            Console.WriteLine("In JSON-B: {0} bytes", JWSinJSONB.Length);
            Console.WriteLine("    Protected {0} / Payload {1} / Signature {2}",
                JWS.Protected.Length, JWS.Payload.Length, JWS.Signature.Length);

            // Sign and serialize using JSON-C
            SignC(JWS, Key, TagDictionary);
            byte[] JWSinJSONC = JWS.ToJsonC(TagDictionary);

            Console.WriteLine("In JSON-C: {0} bytes", JWSinJSONC.Length);
            Console.WriteLine("    Protected {0} / Payload {1} / Signature {2}",
                JWS.Protected.Length, JWS.Payload.Length, JWS.Signature.Length);

            Dump("JSON-B", JWSinJSONB);
            Dump("JSON-C", JWSinJSONC);

            }

        
        static void Dump(string Tag, byte[] Data) {
            int Stride = 8;
            Console.WriteLine("{0}:", Tag);

            int rows = (Data.Length + Stride - 1) / Stride;
            for (int row = 0; row < rows; row++) {
                for (int col = 0; col < Stride; col++) {
                    int i = row * Stride + col;
                    if (i < Data.Length) {
                        Console.Write("{0:X2} ", Data[i]);
                        }
                    else {
                        Console.Write("   ");
                        }
                    }

                Console.Write(" : ");

                for (int col = 0; col < Stride; col++) {
                    int i = row * Stride + col;

                    if (i < Data.Length) {
                        char c = (char)Data[i];
                        if (c >= 32 & c < 128) {
                            Console.Write(c);
                            }
                        else {
                            Console.Write(".");
                            }
                        }
                    }
                Console.WriteLine();
                }
            }


        static void Sign(JoseWebSignature Signature, Key Key, string PHeader) {
            Signature.ProtectHeader();
            var MAC = new HMACSHA256(Key.k);

            string Base64Protected = BaseConvert.ToBase64urlString(
                UTF8Encoding.UTF8.GetBytes(PHeader), false);
            byte[] ByteBase64Protected = UTF8Encoding.UTF8.GetBytes(Base64Protected);

            string Base64Payload = BaseConvert.ToBase64urlString(
                Signature.Payload, false);
            byte[] ByteBase64Payload = UTF8Encoding.UTF8.GetBytes(Base64Payload);

            var Stream = new MemoryStream();
            Stream.Write(ByteBase64Protected, 0, ByteBase64Protected.Length);
            Stream.WriteByte((byte)'.');
            Stream.Write(ByteBase64Payload, 0, ByteBase64Payload.Length);
            Stream.Position = 0;

            //var ByteStream = Stream.ToArray();
            //for (int i = 0; i < ByteStream.Length; i++) {
            //    Console.Write("{0}, ", ByteStream[i]);
            //    }

            Signature.Signature = MAC.ComputeHash(Stream);

            }


        static void Sign(JoseWebSignature Signature, Key Key) {
            Signature.ProtectHeader();
            

            string Base64Protected = BaseConvert.ToBase64urlString(
                Signature.Protected, false);
            byte[] ByteBase64Protected = UTF8Encoding.UTF8.GetBytes(Base64Protected);

            string Base64Payload = BaseConvert.ToBase64urlString(
                Signature.Payload, false);
            byte[] ByteBase64Payload = UTF8Encoding.UTF8.GetBytes(Base64Protected);

            var Stream = new MemoryStream();
            Stream.Write(ByteBase64Protected, 0, ByteBase64Protected.Length);
            Stream.WriteByte((byte)'.');
            Stream.Write(ByteBase64Payload, 0, ByteBase64Payload.Length);
            Stream.Position = 0;

            //var ByteStream = Stream.ToArray();
            //for (int i = 0; i < ByteStream.Length; i++) {
            //    Console.Write("{0}, ", ByteStream[i]);
            //    }

            var MAC = new HMACSHA256(Key.k);
            Signature.Signature = MAC.ComputeHash(Stream);



            }

        static void SignB(JoseWebSignature Signature, Key Key) {
            Signature.ProtectHeaderB();

            var Stream = new MemoryStream();
            Stream.Write(Signature.Protected, 0, Signature.Protected.Length);
            Stream.WriteByte((byte)'.');
            Stream.Write(Signature.Payload, 0, Signature.Payload.Length);

            var MAC = new HMACSHA256(Key.k);
            Signature.Signature = MAC.ComputeHash(Stream);
            }

        static void SignC(JoseWebSignature Signature, Key Key, Dictionary<string, int> Dict) {
            Signature.ProtectHeaderC(Dict);

            var Stream = new MemoryStream();
            Stream.Write(Signature.Protected, 0, Signature.Protected.Length);
            Stream.WriteByte((byte)'.');
            Stream.Write(Signature.Payload, 0, Signature.Payload.Length);

            var MAC = new HMACSHA256(Key.k);
            Signature.Signature = MAC.ComputeHash(Stream);
            }

 
        
        }

    }

