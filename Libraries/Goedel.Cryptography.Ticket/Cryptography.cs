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
using System.Text;
using System.Diagnostics;
using System.IO;
using Goedel.Utilities;
using Goedel.Cryptography;

namespace Goedel.Cryptography.Ticket {
    public partial class Cryptography {

        /// <summary>
        /// Ticket, public part corresponding to shared secret.
        /// </summary>
        public class Ticket {

            /// <summary>The master private key</summary>
            public byte[] Key { get; set; }
            /// <summary>Encryption key derived from master private key.</summary>
            public byte[] EncryptionKey { get; set; }
            /// <summary>Authentication key derived from master private key.</summary>
            public byte[] AuthenticationKey { get; set; }

            /// <summary>The encoded ticket data.</summary>
            public byte []  TicketData;


            /// <summary>The block size for encryption operations</summary>
            public int      BlockSize = 16;
            /// <summary>The MAC code output.</summary>
            public int      MACLength = 16;
            /// <summary>The length of the required initialization vector.</summary>
            public int      IVLength = 16;

            CryptoProviderEncryption EncryptionAlgorithm = 
                            Platform.AES_256.CryptoProviderEncryption();
            CryptoProviderAuthentication AuthenticationAlgorithm = Platform.HMAC_SHA2_256.CryptoProviderAuthentication();

            /// <summary>Constructor of ticket from ticket data and key data.</summary>
            /// <param name="TicketData">The ticket public value.</param>
            /// <param name="KeyDataIn">The ticket private data.</param>
            /// <param name="Authentication">The authentication algorithm to use.</param>
            /// <param name="Encryption">The encryption algorithm to use.</param>
            public Ticket(byte[] TicketData, byte[] KeyDataIn, 
                    CryptoAlgorithmID Authentication, CryptoAlgorithmID Encryption) : 
                        this (TicketData) {
                }

            /// <summary>Constructor of ticket from ticket data and key data.</summary>
            /// <param name="TicketData">The ticket public value.</param>
            /// <param name="Key">The ticket private data.</param>
            public Ticket(byte[] TicketData, byte[] Key = null) {
                this.Key = Key ; // NYI: generate random key
                this.TicketData = TicketData;

                EncryptionKey = Key;           // NYI derive properly
                AuthenticationKey = Key;       // NYI derive properly
                }

            /// <summary>The initialization vector</summary>
            public byte[] IV() {
                return Nonce (IVLength);
                }

            /// <summary>
            /// Encryption method, this should be replaced with the common wrapper classes.
            /// </summary>
            /// <param name="IV"></param>
            /// <param name="ClearText"></param>
            /// <param name="Ciphertext"></param>
            /// <param name="To"></param>
            public void Encrypt(byte[] IV,
                    byte[] ClearText, byte[] Ciphertext, int To) {

                throw new NYI();
                }

            }

        /// <summary>Return key length of algorithm.</summary>
        /// <returns>The key length in bits.</returns>
        public static int KeyLength(Encryption Algorithm) {
            switch (Algorithm) {
                case Encryption.A128CBC : return 128;
                case Encryption.A128GCM : return 128 ;
                case Encryption.A256CBC : return 256;
                case Encryption.A256GCM : return 256;
                default : return 256;
                }
            }

        /// <summary>Return key length of algorithm.</summary>
        /// <returns>The key length in bits.</returns>
        public static int KeyLength(Authentication Algorithm) {
            switch (Algorithm) {
                case Authentication.HS256 : return 256;
                case Authentication.HS512T128 : return 128 ;
                case Authentication.HS512 : return 256;
                default : return 256;
                }
            }

        /// <summary>Return longest key length of known algorithms.</summary>
        /// <returns>The key length in bits.</returns>
        public static int KeyLength() {
            return (KeyLength(Authentication.Unknown) > KeyLength (Encryption.Unknown)) ?
                KeyLength(Authentication.Unknown) : KeyLength (Encryption.Unknown);
            }

        /// <summary>Compressed encryption algorithm identifiers.</summary>
        public enum Encryption {
            /// <summary></summary>
            None = -2,
            /// <summary></summary>
            Unknown = -1,
            /// <summary></summary>
            A128CBC = 0,
            /// <summary></summary>
            A256CBC = 1,
            /// <summary></summary>
            A128GCM = 2,
            /// <summary></summary>
            A256GCM = 3
            }

        /// <summary>Compressed authentication algorithm identifiers.</summary>
        public enum Authentication {
            /// <summary></summary>
            None = -2,
            /// <summary></summary>
            Unknown = -1,
            /// <summary>HMAC SHA-2 256</summary>
            HS256 = 0,
            /// <summary>HMAC SHA-2 512</summary>
            HS512 = 1,
            /// <summary>HMAC SHA-2 256 truncated to 128 bits</summary>
            HS512T128 = 2
            }

        /// <summary>JOSE authentication identifier strings</summary>
        public static List<CryptoAlgorithmID> AuthenticationAlgorithms = 
            new List<CryptoAlgorithmID>() { CryptoAlgorithmID.HMAC_SHA_2_256,
                                 CryptoAlgorithmID.HMAC_SHA_2_512,
                                 CryptoAlgorithmID.HMAC_SHA_2_512T128};

        /// <summary>JOSE encryption identifier strings</summary>
        public static List<CryptoAlgorithmID> EncryptionAlgorithms = 
            new List<CryptoAlgorithmID>() { CryptoAlgorithmID.AES128CBC,
                        CryptoAlgorithmID.AES256CBC,
                        CryptoAlgorithmID.AES128GCM,
                        CryptoAlgorithmID.AES256GCM };

        /// <summary>
        /// Convert string identifier to enumerated identifier;
        /// </summary>
        /// <param name="Code">JOSE string identifier</param>
        /// <returns>Enumerated identifier</returns>
        public static Authentication AuthenticationCode (CryptoAlgorithmID Code) {
            for (int i = 0 ; i< AuthenticationAlgorithms.Count; i++ ) {
                if (AuthenticationAlgorithms[i] == Code) {
                    return (Authentication) i;
                    }
                }
            return Authentication.Unknown;
            }

        /// <summary>
        /// Convert enumerated identifier to string identifier;
        /// </summary>
        /// <param name="Code">Enumerated identifier</param>
        /// <returns>JOSE string identifier</returns>
        public static CryptoAlgorithmID AuthenticationCode(Authentication Code) {
            if (Code >= 0 & (int) Code < AuthenticationAlgorithms.Count) {
                return AuthenticationAlgorithms [(int) Code];
                }
            return CryptoAlgorithmID.Unknown;
            }

        /// <summary>
        /// Convert string identifier to enumerated identifier;
        /// </summary>
        /// <param name="Code">JOSE string identifier</param>
        /// <returns>Enumerated identifier</returns>
        public static Encryption EncryptionCode (CryptoAlgorithmID Code) {
            for (int i = 0 ; i< EncryptionAlgorithms.Count; i++ ) {
                if (EncryptionAlgorithms[i] == Code) {
                    return (Encryption) i;
                    }
                }
            return Encryption.Unknown;
            }

        /// <summary>
        /// Convert enumerated identifier to string identifier;
        /// </summary>
        /// <param name="Code">Enumerated identifier</param>
        /// <returns>JOSE string identifier</returns>
        public static CryptoAlgorithmID EncryptionCode(Encryption Code) {
            if (Code >= 0 & (int) Code < EncryptionAlgorithms.Count) {
                return EncryptionAlgorithms [(int) Code];
                }
            return CryptoAlgorithmID.Unknown;
            }

        /// <summary>Return a new nonce with the specified length in bytes.</summary>
        public static byte[] Nonce(int size) {
            return Platform.GetRandomBytes(size); 
            }

        /// <summary>Return a new nonce with the default length (16 bytes).</summary>
        public static byte[] Nonce() {
            return Nonce (16);
            }

        /// <summary>
        /// Convert a text string (e.g. 'account@example.com') to a PIN verification code
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="key"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string MakePin(string Text, byte [] key, int length) {

            var Bytes = Text.ToBytes();
            var Hash = Platform.HMAC_SHA2_512.Process(Bytes, key);

            return BaseConvert.ToStringBase32hs (Hash, length);
            }

        }
    }
