//Sample license text.
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Goedel.Protocol;

namespace Goedel.Protocol {
    public class TicketData {
        public static Cryptography.Authentication TicketAuthentication = 
                        Cryptography.Authentication.HS256T128;
        protected static int AuthenticationBytes = 0;
        protected int MasterKeyBytes = Cryptography.KeyLength (TicketAuthentication) / 8;

        static Encoding UTF8Encoding = new UTF8Encoding ();

        public string Account;
        public string Domain;
        public byte[] MAC;

        public byte[] AccountID {
            get { return UTF8Encoding.GetBytes (Account + "@" + Domain); }
            }

        public byte[] Ticket;

        public Cryptography.Authentication Authentication;
        public Cryptography.Encryption Encryption;

        public Cryptography.Key MasterKey;
        public Cryptography.Key AuthenticationKey;
        public Cryptography.Key EncryptionKey;

        public Boolean Authenticated;


        public TicketData() {
            MasterKey = new Cryptography.Key (TicketAuthentication);
            // Derrive the Authentication and Encryption Keys
            }

        public TicketData(Cryptography.Authentication Authentication,
                Cryptography.Encryption Encryption) {

            this.Authentication = Authentication;
            this.Encryption = Encryption;

            MasterKey = new Cryptography.Key (Authentication);
            // Derrive the Authentication and Encryption Keys
            }

        protected int Unpack() {
            int index = 0;
            byte x;

            x = Ticket [index++];
            if (x != 0) throw new Exception ("Bad ticket");
            x = Ticket [index++]; // ignore, checked already
            Authentication = (Cryptography.Authentication) Ticket [index++];
            Encryption = (Cryptography.Encryption) Ticket [index++];

            byte [] MasterKeyData = new byte [MasterKeyBytes];
            for (int i = 0; i < MasterKeyBytes; i++) {
                MasterKeyData [i] = Ticket [index++];
                }
            MasterKey = new Cryptography.Key (MasterKeyData, Authentication, Encryption);

            x = Ticket [index++];
            byte [] AccountIDData = new byte [x];
            int At = x; // No @ in string would mean it is all account, no domain
            for (int i = 0; i < x; i++) {
                if (Ticket[index] == '@') {
                    At = i;
                    }
                AccountIDData [i] = Ticket [index++];
                }
            Account = UTF8Encoding.GetString (AccountIDData, 0, At);
            Account = UTF8Encoding.GetString (AccountIDData, At-1, x-At-1);

            return index;
            }

        // Unpack a binary ticket
        public TicketData(byte[] TicketIn, byte [] Hash) {
            Ticket = TicketIn;
            this.MAC = Hash;
            Unpack() ;
            }

        static void DumpCrypto (string tag, byte[] Ticket, Cryptography.Key SeedKey) {
            Console.WriteLine ("Dump Crypto {0} Seed={1} Ticket={2}",
                tag, BaseConvert.ToBase64urlString(SeedKey.KeyData), 
                        BaseConvert.ToBase64urlString(Ticket));
            }


        public static byte[] Pack(byte[] Ticket, Cryptography.Key SeedKey) {
            byte [] Result = null;
            byte [] Hash = null;

            KeyedHashAlgorithm MAC = new HMACSHA256(SeedKey.KeyData);
            using (CryptoStream cs = new CryptoStream(Stream.Null, MAC, CryptoStreamMode.Write)) {
                        cs.Write(Ticket, 0, Ticket.Length);
                        }
            Hash = MAC.Hash;
            
            using (AesManaged Aes = new AesManaged()) {
                Aes.Key = SeedKey.KeyData;
                using (MemoryStream ms = new MemoryStream()) {
                    ms.Write (Aes.IV, 0, Aes.IV.Length);
                    using (CryptoStream cs = new CryptoStream(ms,
                        Aes.CreateEncryptor(Aes.Key, Aes.IV), CryptoStreamMode.Write)) {
                        cs.Write(Ticket, 0, Ticket.Length);
                        cs.Write(Hash, 0, 16);
                        }
                    Result = ms.ToArray ();
                    }
                }
            return Result;
            }

        public static byte[] UnPack(byte[] Ticket, Cryptography.Key SeedKey, out byte [] Hash) {
            byte[] Decrypted = null;
            int IVlength;
            using (AesManaged Aes = new AesManaged()) {
                Aes.Key = SeedKey.KeyData;
                IVlength = Aes.IV.Length;
                byte [] IV = new byte [Aes.IV.Length];
                for (int i=0; i< IV.Length; i++) {
                    IV [i] = Ticket [i];
                    }
                Aes.IV = IV;
                using (MemoryStream ms = new MemoryStream()) {
                    using (CryptoStream cs = new CryptoStream(ms,
                        Aes.CreateDecryptor(Aes.Key, Aes.IV), CryptoStreamMode.Write)) {
                        cs.Write(Ticket, 0, Ticket.Length);
                        }
                    Decrypted = ms.ToArray();
                    }
                }

            
            Hash = null;

            int outLen =Decrypted.Length-IVlength - 16;

            KeyedHashAlgorithm MAC = new HMACSHA256(SeedKey.KeyData);
            using (CryptoStream cs = new CryptoStream(Stream.Null, MAC, CryptoStreamMode.Write)) {
                cs.Write(Decrypted, IVlength, outLen);
                }
            Hash = MAC.Hash;

            int offset = Decrypted.Length - 16;
            for (int i = 0; i < 16; i++) {
                if (Decrypted[offset + i] != Hash[i]) {
                    return null;
                    }
                }
            
            byte [] Result = new byte [outLen];
            Array.Copy (Decrypted, IVlength, Result, 0, outLen);

            return Result;
            }




        public static bool VerifyTicket (byte[] Ticket, Cryptography.Key SeedKey) {
            int Sign = Ticket.Length - AuthenticationBytes;

            byte [] Hash = Cryptography.GetMAC (Ticket, Sign, TicketAuthentication, SeedKey);

            for (int i = 0; i < AuthenticationBytes; i++) {
                if (Hash [i] != Ticket [Sign+i]) throw new Exception ("Bad Ticket");
                }
            DumpCrypto ("Verify ticket", Hash, SeedKey);
            return true;
            }

        public static TicketData MakeTicket(byte[] WrappedTicket, Cryptography.Key SeedKey) {
            byte [] Hash;
            byte[] Ticket = UnPack (WrappedTicket, SeedKey, out Hash);

            //VerifyTicket (Ticket, SeedKey);

            int index = 0;
            byte x;

            x = Ticket [index++];
            if (x != 0) throw new Exception ("Bad ticket");
            x = Ticket [index++];
            if (x == 0) return new TicketData (Ticket, Hash);
            if (x == 1) return new TemporaryTicketData (Ticket, Hash);
            throw new Exception ("Bad ticket");
            }


        // Create a binary ticket
        // Format is:
        //
        //  [1]         Version number  = 0
        //  [1]         Key identifier  (rolls round)
        //  [1]         Authentication Code ( = 0 for HMAC-SHA256
        //  [1]         Encryption Code ( = 0 for AES-CBC-128
        //  [KEY-SIZE]  MasterKeyData
        //  [1]         Username Name Length
        //  [A-SIZE]    Username (username@domain)


        //  [KEY-SIZE]  MAC Data

        public virtual int Length() {
            return (5 + MasterKey.KeyData.Length + AccountID.Length + AuthenticationBytes);
            }

        protected virtual int Fill() {
            int index = 0;

            Ticket [index++] = 0; // Version number
            Ticket [index++] = 0; //
            Ticket [index++] = (byte) Authentication; //
            Ticket [index++] = (byte) Encryption; //
            Array.Copy (MasterKey.KeyData, 0, Ticket, index, MasterKey.KeyData.Length); // The master key
            index += MasterKey.KeyData.Length;
            Ticket [index++] = (byte) AccountID.Length; //
            Array.Copy (AccountID, 0, Ticket, index,  AccountID.Length);
            index += AccountID.Length;

            return (index);
            }

        
        public byte[] GetTicket(Cryptography.Key MasterKey) {
            Ticket = new byte [Length()];
            
            int Sign = Fill();

            //if (Sign != Ticket.Length - AuthenticationBytes) throw new Exception ("Ticket Length");

            //byte [] Hash = Cryptography.GetMAC (Ticket, Sign, TicketAuthentication, MasterKey);
            //Array.Copy (Hash, 0, Ticket, Sign, AuthenticationBytes);

            //DumpCrypto ("Sign ticket", Hash, MasterKey);

            return Pack (Ticket, MasterKey);
            }

        }

    public class TemporaryTicketData : TicketData {
        public byte[] ClientChallenge;
        public byte[] ServerChallenge;

        public TemporaryTicketData() {
            }


        public TemporaryTicketData(byte[] TicketIn, byte [] Hash) {
            Ticket = TicketIn;
            MAC = Hash;
            int index = Unpack() ;
            int x;

            x = Ticket [index++];
            ClientChallenge = new byte [x];
            for (int i = 0; i < x; i++) {
                ClientChallenge [i] = Ticket [index++];
                }
            
            x = Ticket [index++];
            ServerChallenge = new byte [x];
            for (int i = 0; i < x; i++) {
                ServerChallenge [i] = Ticket [index++];
                }
            }

        public override int Length() {
            return (7 + MasterKeyBytes + AccountID.Length + AuthenticationBytes + ClientChallenge.Length + ServerChallenge.Length);
            }

        protected override int Fill() {
            int index = 0;

            Ticket [index++] = 0; // Version number
            Ticket [index++] = 1; //
            Ticket [index++] = (byte) Authentication; //
            Ticket [index++] = (byte) Encryption; //
            Array.Copy (MasterKey.KeyData, 0, Ticket, index, MasterKey.KeyData.Length); // The master key
            index += MasterKey.KeyData.Length;
            Ticket [index++] = (byte) AccountID.Length; //
            Array.Copy (AccountID, 0, Ticket, index,  AccountID.Length);
            index += AccountID.Length;
            Ticket [index++] = (byte) ClientChallenge.Length;
            Array.Copy (ClientChallenge, 0, Ticket, index, ClientChallenge.Length); // The server challenge value
            index += ClientChallenge.Length;
            Ticket [index++] = (byte) ServerChallenge.Length;
            Array.Copy (ServerChallenge, 0, Ticket, index, ServerChallenge.Length); // The client challenge value
            index += ServerChallenge.Length;

            return (index);
            }


        }
    }
