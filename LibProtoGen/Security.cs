using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Goedel.Protocol;

namespace Goedel.Protocol {
    public class CryptographicContext {
        public byte[] Ticket;
        public Cryptography.Key Key;
        public Cryptography.Authentication Authentication;
        public Cryptography.Encryption Encryption;

        public static CryptographicContext MakeCryptographicContext(
            byte[] Ticket, byte[] Key,
            string AuthenticationIn, string EncryptionIn) {

            Cryptography.Authentication Authentication =
                    Cryptography.AuthenticationCode(AuthenticationIn);
            Cryptography.Encryption Encryption =
                    Cryptography.EncryptionCode(EncryptionIn);

            if (Authentication == Cryptography.Authentication.Unknown) return null;
            if (Encryption == Cryptography.Encryption.Unknown) return null;

            return new CryptographicContext(Ticket, Key, Authentication, Encryption);
            }

        public CryptographicContext(byte[] TicketIn, byte[] KeyIn, 
                        string AuthenticationIn, string EncryptionIn) :
                this (TicketIn, KeyIn, Cryptography.AuthenticationCode(AuthenticationIn),
            Cryptography.EncryptionCode(EncryptionIn)) {
            }

        public CryptographicContext(byte[] Ticket, byte[] Key,
                    Cryptography.Authentication Authentication,
                    Cryptography.Encryption Encryption) {
            this.Ticket = Ticket;
            this.Key = new Cryptography.Key(Key, Authentication, Encryption);
            this.Authentication = Authentication;
            this.Encryption = Encryption;
            }

        public static byte[] ConvertFromBase64String(String s) {
            byte[] result;
            try {
                result = BaseConvert.FromBase64urlString(s);
                return result;
                }
            catch {
                Console.WriteLine ("Rejected!");
                return null;
                }
            }

        public byte[] MAC(byte[] data) {

            return Cryptography.GetMAC(data, data.Length, Authentication, Key);
            }

        public string GetIntegrityHeader(byte[] data) {
            return "Session: Value=" + BaseConvert.ToBase64urlString(MAC(data), false)
                + "; Id=" + BaseConvert.ToBase64urlString(Ticket, false);
            }

        public string GetIntegrityHeader(StreamBuffer StreamBuffer) {
            return "Session: Value=" + BaseConvert.ToBase64urlString(
                Cryptography.GetMAC(StreamBuffer, Authentication, Key))
                + "; Id=" + BaseConvert.ToBase64urlString(Ticket);
            }

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
                            if (c == ':') state = 1;
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
                            if (s == "Value") Tag = 0;
                            else if (s == "Id") Tag = 1;
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
