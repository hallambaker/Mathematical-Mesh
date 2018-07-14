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
using System.IO;
using System.Net;
using System.Text;
using Goedel.Utilities;

namespace Goedel.Cryptography.Ticket {

    /// <summary>Cryptographic context</summary>
    public class CryptographicContext {
        
        /// <summary>The ticket</summary>
        public byte[] Ticket;
        
        /// <summary>The master key.</summary>
        public byte[] Key;
        
        /// <summary>Authentication algorithm identifier.</summary>
        public CryptoAlgorithmID Authentication;

        /// <summary>Encryption algorithm identifier.</summary>
        public CryptoAlgorithmID Encryption;

        /// <summary>
        /// Factory method returning a cryptographic context.
        /// </summary>
        /// <param name="Ticket">The ticket data.</param>
        /// <param name="Key">Secret key</param>
        /// <param name="AuthenticationIn">Authentication algorithm identifier.</param>
        /// <param name="EncryptionIn">Encryption algorithm identifier.</param>
        /// <returns>Cryptographic context.</returns>
        public static CryptographicContext MakeCryptographicContext(
            byte[] Ticket, byte[] Key,
            CryptoAlgorithmID AuthenticationIn, CryptoAlgorithmID EncryptionIn) => new CryptographicContext(Ticket, Key, AuthenticationIn, EncryptionIn);


        /// <summary>
        /// Constructor for specified ticket and key.
        /// </summary>
        /// <param name="Ticket">The ticket data.</param>
        /// <param name="Key">Secret key</param>
        /// <param name="Authentication">Authentication algorithm identifier.</param>
        /// <param name="Encryption">Encryption algorithm identifier.</param>

        public CryptographicContext (byte[] Ticket, byte[] Key,
                        CryptoAlgorithmID Authentication, CryptoAlgorithmID Encryption)  {

            this.Ticket = Ticket;
            this.Key = Key;
            this.Authentication = Authentication;
            this.Encryption = Encryption;
            }


        /// <summary>Convert base 64 encoded string to byte array.</summary>
        /// <param name="Base64Data">The string to convert</param>
        /// <returns>The converted string.</returns>
        public static byte[] ConvertFromBase64String(String Base64Data) {
            byte[] result;
            try {
                result = BaseConvert.FromBase64(Base64Data);
                return result;
                }
            catch {
                //Console.WriteLine ("Rejected!");
                return null;
                }
            }

        /// <summary>
        /// Get the MAC value of the specified data under the authentication key.
        /// </summary>
        /// <param name="Data">Data to authenticate</param>
        /// <returns>The MAC value.</returns>
        public byte[] MAC(byte[] Data) {
            var Provider = CryptoCatalog.Default.GetAuthentication(Authentication) as
                        CryptoProviderAuthentication;
            return Provider.ProcessData(Data, Key);
            }

        /// <summary>
        /// Generate an integrity header - this is to change to the new package format.
        /// </summary>
        /// <param name="data">Data to generate integrity value for.</param>
        /// <returns>The integrity header.</returns>
        public string GetIntegrityHeader(byte[] data) => "Session: Value=" + BaseConvert.ToStringBase64url(MAC(data))
                + "; Id=" + BaseConvert.ToStringBase64url(Ticket);


        /// <summary>
        /// Parse integrity header to get MAC and ticket.
        /// </summary>
        /// <param name="Header">The header string</param>
        /// <param name="Mac">The MAC value</param>
        /// <param name="Ticket">The ticket value.</param>
        public static void ParseIntegrityHeader(string Header, out byte[] Mac, out byte[] Ticket) {
            int Start = 0;
            int state = 1;
            int Tag = -1;
            Mac = null;
            Ticket = null;
            for (int i = 0; i < Header.Length; i++) {
                char c = Header[i];
                //Console.WriteLine ("State {0} Char {1}", c, state);
                switch (state) {
                    case 0: {
                        if (c == ':') {
                            state = 1;
                            }
                        break;
                        }
                    case 1:
                        if ((c != ' ') & (c != '\t')) {
                            state = 2;
                            Start = i;
                            }
                        break;
                    case 2:
                        if (c == '=') {
                            string s = Header.Substring (Start, i-Start);
                        if (s == "Value") {
                            Tag = 0;
                            }
                        else if (s == "Id") {
                            Tag = 1;
                            }
                            state = 3;
                            Start = i+1;
                            }
                        break;
                    case 3:
                        if (c == ' ' | c == '\t' | c == ';' | i + 1 == Header.Length) {
                            string s = Header.Substring(Start, 
                                (i + 1 == Header.Length) ?  1 + i - Start : i - Start);

                            if (Tag == 0) {
                                Mac = ConvertFromBase64String(s);
                                }
                            if (Tag == 1) {
                                Ticket = ConvertFromBase64String(s);
                                }
                            state = 1;
                            }
                        break;
                    }
                }
            }
        }
    }
