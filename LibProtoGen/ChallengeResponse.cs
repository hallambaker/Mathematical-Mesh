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
using Goedel.Protocol;

namespace Goedel.Protocol {
    public partial class Cryptography {

        public static byte [] NormalizePIN(string PIN) {
            UTF8Encoding Encoder = new UTF8Encoding ();

            string result = "";

            foreach (char c in PIN) {
                if (c != ' ' & c != '\t' & c != '\r' & c != '-' & c != '_') {
                    result += c;
                    }
                }

            return Encoder.GetBytes (result);
            }

        public static byte[] GetPINKey(string PIN, byte[] ClientChallenge,
            Cryptography.Authentication Authentication) {

            byte [] NPIN = NormalizePIN (PIN);

            HMACSHA256 MAC = new HMACSHA256(ClientChallenge);
            CryptoStream CryptoStream = new CryptoStream(Stream.Null, MAC, CryptoStreamMode.Write);
            CryptoStream.Write(NPIN, 0, NPIN.Length);
            CryptoStream.Close();

            return MAC.Hash;
            }

        public static byte[] ServerChallengeResponse (string PIN, byte [] ClientChallenge, 
                        string Payload, byte [] Secret, Cryptography.Authentication Authentication) {
            UTF8Encoding Encoder = new UTF8Encoding ();
            return ServerChallengeResponse (PIN, ClientChallenge, 
                        Encoder.GetBytes(Payload), Secret, Authentication);
            }

        public static byte[] ServerChallengeResponse (string PIN, byte [] ClientChallenge, 
                        byte [] Payload, byte [] Secret,
                        Cryptography.Authentication Authentication) {
            byte [] KPC = GetPINKey (PIN, ClientChallenge, Authentication);

            HMACSHA256 MAC = new HMACSHA256(KPC);
            CryptoStream CryptoStream = new CryptoStream(Stream.Null, MAC, CryptoStreamMode.Write);
            CryptoStream.Write(Payload, 0, Payload.Length);
            CryptoStream.Close();

            return MAC.Hash;
            }

        public static byte[] ClientChallengeResponse(string PIN, byte [] ServerChallenge, 
                    string Payload, byte [] Secret, Cryptography.Authentication Authentication) {
            UTF8Encoding Encoder = new UTF8Encoding ();
            return ClientChallengeResponse (PIN, ServerChallenge, 
                    Encoder.GetBytes(Payload), Secret, Authentication);
            }

        public static byte[] ClientChallengeResponse(string PIN, byte [] ServerChallenge, 
                    byte [] Payload, byte [] Secret, Cryptography.Authentication Authentication) {
            byte [] KPC = GetPINKey (PIN, ServerChallenge, Authentication);

            HMACSHA256 MAC = new HMACSHA256(KPC);
            CryptoStream CryptoStream = new CryptoStream(Stream.Null, MAC, CryptoStreamMode.Write);
            CryptoStream.Write(Payload, 0, Payload.Length);
            CryptoStream.Close();

            return MAC.Hash;
            }
        }
    }
