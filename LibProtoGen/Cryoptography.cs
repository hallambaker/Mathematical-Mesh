//   Copyright © 2015 by Comodo Group Inc.
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
//  
//  

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Goedel.Protocol {
    public partial class Cryptography {

            //using (AesManaged aesAlg = new AesManaged()) {
            //    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            //    using (MemoryStream msEncrypt = new MemoryStream()) {
            //        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)) {

            //            }
            //        }
            //    }
        

        // Encrypt Plaintext writing the first byte of the output
        // to Ciphertext[Start]

        //public static void Encrypt(Key Key, byte[] IV,
        //        byte[] ClearText, byte[] Ciphertext, int Start) {

        //    }

        //public static void Authenticate(Key Key,
        //        byte[] Input, int Length, byte Output, int Start, int Truncate) {


        //    }

        public static void Dump(string Tag, byte [] Data) {
                Console.Write("KEY[{0}]::", Tag);
                for (int i = 0; i < Data.Length; i++) {
                    Console.Write("{0:x2}-", Data[i]);
                    }
                Console.WriteLine ();
                }



        // The ticket class is the easiest peg to hang all the convenience functions
        // off since every operation has a keyidentifier (ticket) and a key.

        public class Ticket {
            public Key      Key;
            public Key      EncryptionKey;
            public Key      AuthenticationKey;
            public byte []  TicketData;

            // NYI get these from the algorithm identifiers.
            public int      BlockSize = 16;
            public int      MACLength = 16;     
            public int      IVLength = 16;

            System.Security.Cryptography.SymmetricAlgorithm     EncryptionAlgorithm;
            System.Security.Cryptography.KeyedHashAlgorithm     AuthenticationAlgorithm;

            public Ticket(byte[] TicketData, byte[] KeyDataIn, 
                    string Authentication, string Encryption) : 
                        this (TicketData, 
                            new Key (KeyDataIn, Authentication, Encryption) ) {
                }

            public Ticket(byte[] TicketData, Key Key) {
                this.Key = Key;
                this.TicketData = TicketData;

                this.EncryptionKey = Key;           // NYI derrive properly
                this.AuthenticationKey = Key;       // NYI derrive properly
                
                
                EncryptionAlgorithm =  new AesManaged ();
                BlockSize = EncryptionAlgorithm.BlockSize / 8;
                IVLength = BlockSize;
                AuthenticationAlgorithm = new HMACSHA256 (AuthenticationKey.KeyData);

                MACLength = BlockSize;
                }

            public byte[] IV() {
                return Nonce (IVLength);
                }

            public void Encrypt(byte[] IV,
                    byte[] ClearText, byte[] Ciphertext, int To) {

                using (var Transform = EncryptionAlgorithm.CreateEncryptor(
                    EncryptionKey.KeyData, IV)) {

                    int FullBlocks = ClearText.Length / BlockSize;
                    int From = 0;
                    for (int i = 0; i < FullBlocks; i++) {
                        Transform.TransformBlock (ClearText, From, BlockSize, Ciphertext, To);
                        From += BlockSize;
                        To += BlockSize;
                        }

                    byte [] Final = Transform.TransformFinalBlock (
                        ClearText, From, ClearText.Length-From);
                    Array.Copy (Final, 0, Ciphertext, To, Final.Length);
                    }
                }

            public byte [] Authenticate(byte[] Input, int Count) {
                return Authenticate (Input, 0, Count, Input, Count);
                }

            public byte [] Authenticate(byte[] Input, int Offset, int Count, 
                        byte[] Output, int Index) {

                // NYI check that there is space in the output buffer for the 
                // hash data

                byte [] Hash = AuthenticationAlgorithm.ComputeHash (Input, Offset, Count);
                Array.Copy (Hash, 0, Output, Index, MACLength);

                return Hash;
                }

            }

        public class Key {
            public byte[] KeyData;
            Authentication Authentication = Authentication.Unknown;
            Encryption Encryption = Encryption.Unknown;

            public Key() {
                this.KeyData = Nonce(KeyLength() / 8);
                this.Authentication = Authentication.Unknown;
                this.Encryption = Encryption.Unknown;
                }

            public Key(byte[] KeyDataIn, string Authentication, string Encryption) {
                this.KeyData = KeyDataIn;
                this.Authentication = AuthenticationCode(Authentication);
                this.Encryption = EncryptionCode(Encryption);
                }

            public Key(byte[] KeyData, Authentication Authentication, Encryption Encryption) {
                this.KeyData = KeyData;
                this.Authentication = Authentication;
                this.Encryption = Encryption;
                }

            public Key(Key Master, Authentication Authentication, string Salt) {
                this.Authentication = Authentication;
                this.Encryption = Encryption.None;
                this.KeyData = GetMAC(Salt, Authentication, Master);
                }

            //public Key(Key Master, Encryption EncryptionIn) {
            //    Authentication = EncryptionIn;
            //    Encryption = Encryption.None;
            //    KeyData = GetMAC (Salt, Authentication.HS512, Master);
            //    }

            public Key(Authentication Alg) {
                Authentication = Alg;
                switch (Alg) {
                    case Authentication.HS256:
                    case Authentication.HS256T128: {
                            KeyData = Nonce(16);
                            break;
                            }
                    case Authentication.HS384: {
                            KeyData = Nonce(24);
                            break;
                            }
                    case Authentication.HS512: {
                            KeyData = Nonce(32);
                            break;
                            }
                    }
                }

            public Key(Encryption Alg) {
                Encryption = Alg;
                switch (Alg) {
                    case Encryption.A128CBC:
                    case Encryption.A128GCM: {
                            KeyData = Nonce(16);
                            break;
                            }
                    case Encryption.A256CBC:
                    case Encryption.A256GCM: {
                            KeyData = Nonce(32);
                            break;
                            }
                    }
                }

            public void Dump(string Tag) {
                Console.Write("KEY[{0}]::", Tag);
                for (int i = 0; i < 8; i++) {
                    Console.Write("{0:x2}-", KeyData[i]);
                    }
                Console.WriteLine ();
                }
            }


        static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();


        public static int KeyLength(Encryption Algorithm) {
            switch (Algorithm) {
                case Encryption.A128CBC : return 128;
                case Encryption.A128GCM : return 128 ;
                case Encryption.A256CBC : return 256;
                case Encryption.A256GCM : return 256;
                default : return 256;
                }
            }

        public static int KeyLength(Authentication Algorithm) {
            switch (Algorithm) {
                case Authentication.HS256 : return 256;
                case Authentication.HS256T128 : return 128 ;
                case Authentication.HS384 : return 384;
                case Authentication.HS512 : return 256;
                default : return 256;
                }
            }

        public static int KeyLength() {
            return (KeyLength(Authentication.Unknown) > KeyLength (Encryption.Unknown)) ?
                KeyLength(Authentication.Unknown) : KeyLength (Encryption.Unknown);
            }

        public enum Encryption {
            None = -2,
            Unknown = -1,
            A128CBC = 0, 
            A256CBC = 1, 
            A128GCM = 2, 
            A256GCM = 3
            }
        
        public enum Authentication {
            None = -2,
            Unknown = -1,
            HS256 = 0,
            HS384 = 1,
            HS512 = 2,
            HS256T128 = 3
            }

        public static List<string> AuthenticationAlgorithms = 
            new List<string>() {"HS256", "HS384", "HS512", "HS256T128"};
        public static List<string> EncryptionAlgorithms = 
            new List<string>() {"A128CBC", "A256CBC", "A128GCM", "A256GCM"};

        public static Authentication AuthenticationCode (string Code) {
            for (int i = 0 ; i< AuthenticationAlgorithms.Count; i++ ) {
                if (AuthenticationAlgorithms[i] == Code) {
                    return (Authentication) i;
                    }
                }
            return Authentication.Unknown;
            }

        public static string AuthenticationCode(Authentication Code) {
            if (Code >= 0 & (int) Code < AuthenticationAlgorithms.Count) {
                return AuthenticationAlgorithms [(int) Code];
                }
            return null;
            }

        public static Encryption EncryptionCode (string Code) {
            for (int i = 0 ; i< EncryptionAlgorithms.Count; i++ ) {
                if (EncryptionAlgorithms[i] == Code) {
                    return (Encryption) i;
                    }
                }
            return Encryption.Unknown;
            }

        public static string EncryptionCode(Encryption Code) {
            if (Code >= 0 & (int) Code < EncryptionAlgorithms.Count) {
                return EncryptionAlgorithms [(int) Code];
                }
            return null;
            }

        public static byte[] Nonce(int size) {
            byte [] Result = new byte [size];
            rng.GetBytes(Result);
            return Result; 
            }

        public static byte[] Nonce() {
            return Nonce (16);
            }

        // Convert a text string (e.g. 'account@example.com') to a PIN verification code
        public static string MakePin(string Text, byte [] key, int length) {
            byte [] Bytes = GetBytes (Text);

            HMACSHA256 MAC = new HMACSHA256(key);
            CryptoStream CryptoStream = new CryptoStream(Stream.Null, MAC, CryptoStreamMode.Write);
            CryptoStream.Write(Bytes, 0, Text.Length);
            CryptoStream.Close();

            byte[] Hash = MAC.Hash;

            return ToBase32hsString (Hash, length);
            }




        // There may be a serious issue here due to conversion to/from UTF8 The
        // payload variable should be byte []



        static KeyedHashAlgorithm GetKeyedHashAlgorithm(Authentication Algorithm, Key key) {
            switch (Algorithm) {
                case Authentication.HS256: {
                        return new HMACSHA256(key.KeyData);
                        }
                case Authentication.HS256T128: {
                        return new HMACSHA256(key.KeyData);
                        }
                case Authentication.HS384:{
                        return new HMACSHA384(key.KeyData);
                        }
                case Authentication.HS512:{
                        return new HMACSHA512(key.KeyData);
                        }
                default: throw new Exception("MAC not known");
                }
            }

        public static byte[] GetMAC(string Text, Authentication Algorithm, Key key) {
            byte[] Bytes = GetBytes(Text);
            
            return GetMAC(Bytes, Bytes.Length, Algorithm, key);
            }

        public static byte [] GetMAC(byte [] Bytes, int Length, Authentication Algorithm, Key key) {
            KeyedHashAlgorithm MAC = GetKeyedHashAlgorithm (Algorithm, key);
                      
            CryptoStream CryptoStream = new CryptoStream(Stream.Null, MAC, CryptoStreamMode.Write);
            CryptoStream.Write(Bytes, 0, Length);
            CryptoStream.Close();

            return MAC.Hash;
            }

        public static byte [] GetMAC(StreamBuffer StreamBuffer, Authentication Algorithm, Key key) {
            KeyedHashAlgorithm MAC = GetKeyedHashAlgorithm (Algorithm, key);
            StreamBuffer.Write (new CryptoStream(Stream.Null, MAC, CryptoStreamMode.Write));
            return MAC.Hash;
            }

       public static bool ArraysEqual(byte[] Test1, byte [] Test2) {
            if ((Test1 == null) & (Test2 != null)) {
                return false;
                }
            if (Test2 == null) {
                return false;
                }
            if (Test1.Length != Test2.Length) {
                return false;
                }
            for (int i = 0; i < Test1.Length; i++) {
                if (Test1[i] != Test2[i]) {
                    return false;
                    }
                }

            return true;
            }

        // Code to convert arrays of bytes to various forms of string
        private static char[] BASE16 = new char[]{
                    '0', '1', '2', '3', '4', '5', '6', '7',
                    '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        private static char[] BASE32 = new char[]{
                    'A' , 'B', 'C', 'D', 'E', 'F', 'G', 'H', 
                     'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
                     'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
                     'Y', 'Z', '2', '3', '4', '5', '6', '7'};

        private static char[] BASE32HEX = new char[]{
                    '0' , '1', '2', '3', '4', '5', '6', '7', 
                     '8', '9', 'A', 'B', 'C', 'D', 'E', 'F',
                     'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
                     'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V'};

        private static char[] BASE64URL = new char[]{
                    'A' , 'B', 'C', 'D', 'E', 'F', 'G', 'H', 
                     'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
                     'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
                     'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f',
                     'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
                     'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
                     'w', 'x', 'y', 'z', '0', '1', '2', '3',
                     '4', '5', '6', '7', '8', '9', '-', '_'};


        static string ToBase16String (byte [] data, int Length) {
            string      result = "";

            for (int i = 0; i<Length; i++) {
                //Console.WriteLine ("{0:x2}", data [i]);

                int n1 = data[i] >>4;
                int n2 = data[i] & 0xF;
                
                result = result + BASE16 [n1] + BASE16 [n2];
                }

            //Console.WriteLine ("   {0}", result);
            return result;
            }

        static string ToBase32String(byte[] data, int Length) {
            string result = "";
            int offset = 0;
            int a = 0;

            for (int i = 0; i < Length; i++) {
                a = (a << 8) | data[i];
                offset += 8;

                //Console.WriteLine("{0:x4}/{2} : {1}", a, result, offset);

                while (offset >= 5) {
                    offset -= 5;

                    int n = a >> offset;
                    result = result + BASE32[n];
                    a = a & (0x1f >> (5 - offset));
                    }
                }

            if (offset > 0) {
                result = result + BASE32[a];
                }
            return result;
            }

        static string ToBase32sString(byte[] data, int Length) {
            string result = "";
            int offset = 0;
            int a = 0;

            for (int i = 0; i < Length; i++) {

                if (((i & 0x3) == 0) & i > 0) {
                    result = result + "-";
                    }

                a = (a << 8) | data[i];
                offset += 8;

                //Console.WriteLine("{0:x4}/{2} : {1}", a, result, offset);

                while (offset >= 5) {
                    offset -= 5;

                    int n = a >> offset;
                    result = result + BASE32[n];
                    a = a & (0x1f >> (5 - offset));
                    }
                }

            if (offset > 0) {
                result = result + BASE32[a];
                }
            return result;
            }

        static string ToBase32hsString(byte[] data, int Length) {
            string result = "";
            int offset = 0;
            int a = 0;

            for (int i = 0; i < Length; i++) {

                if (((i & 0x3) == 0) & i > 0) {
                    result = result + "-";
                    }

                a = (a << 8) | data[i];
                offset += 8;

                //Console.WriteLine("{0:x4}/{2} : {1}", a, result, offset);

                while (offset >= 5) {
                    offset -= 5;

                    int n = a >> offset;
                    result = result + BASE32HEX[n];
                    a = a & (0x1f >> (5 - offset));
                    }
                }

            if (offset > 0) {
                result = result + BASE32[a];
                }
            return result;
            }

        static string ToBase64urlString(byte[] data, int Length) {
            string result = "";
            int offset = 0;
            int a = 0;

            for (int i = 0; i < Length; i++) {
                a = (a << 8) | data[i];
                offset += 8;

                //Console.WriteLine ("{0:x4}/{2:3} : {1}", a, result, offset);

                while (offset >= 6) {
                    offset -= 6;

                    int n = a >> offset;
                    result = result + BASE64URL[n];
                    a = a & (0x3f >> (6 - offset));
                    }
                }
            if (offset > 0) {
                result = result + BASE64URL[a];
                }
            return result;
            }




        // convert a string to an array of character data and back without encoding
        static byte[] GetBytes(string Chars){
            byte[] Bytes = new byte[Chars.Length * sizeof(char)];
            System.Buffer.BlockCopy(Chars.ToCharArray(), 0, Bytes, 0, Bytes.Length);
            return Bytes;
            }

        static string GetString(byte[] Bytes){
            char[] Chars = new char[Bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(Bytes, 0, Chars, 0, Bytes.Length);
            return new string(Chars);
            }
        }
    }
