using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Goedel.DNS {
    class Canonicalize {
        public string   Build;
        public string   Text { get {return (Build); }}

        public Canonicalize (string Result) {
            this.Build = Result;
            }

        public void Add(string Text) {
            Build += " ";
            Build += Text;
            }
        public void AddBinary(string Text) {
            Build += " ";
            Build += Text;
            }
        public void AddQuoted(string Text) {
            Build += " \"";
            Build += Text;
            Build += "\"";
            }

        public Canonicalize  (string Tag, Domain Domain) {
            Build = Domain.Name + "    " + Tag;
            }

        public void IPv4 (IPAddress Data) {
            Add (Data.ToString ());
            }
        public void IPv6 (IPAddress Data) {
            Add (Data.ToString ());
            }
        public void Domain (Domain Data) {
            Add (Data.Name);
            }
        public void Mail (string Data) {
            Add (Data);
            }
        public void NodeID (ulong Data) {
            // Add (Data); 
            }
        public void Byte (byte Data) {
            Add (Data.ToString ());
            }
        public void Int16 (ushort Data) {
            Add (Data.ToString ());
            }
        public void Int32 (uint Data) {
            Add (Data.ToString ());
            }

        // Unsigned numbers of seconds since the start of 1 January 1970, GMT, ignoring leap seconds.
        // Proper format for time is YYYYMMDDHHMMSS
        public void Time32 (uint Data) {
            Add (Data.ToString ());
            }
        // Same as for Time32 (resolution is still seconds, just a longer interval)
        public void Time48 (ulong Data) {
            Add (Data.ToString ());
            }

        public void String (string Data) {
            AddQuoted (Data);
            }
        public void OptionalString (string Data) {
            AddQuoted (Data);
            }
        public void StringX (string Data) {
            AddQuoted (Data);
            }
        public void Strings(List<string> Data) {
            foreach (string s in Data) {
                AddQuoted(s);
                }
            }
        public void Binary (byte[] Data) {
            AddBinary (Convert.ToBase64String (Data));
            }
        public void Binary8 (byte[] Data) {
            AddBinary (Convert.ToBase64String (Data));
            }
        public void Binary16 (byte[] Data) {
            AddBinary (Convert.ToBase64String (Data));
            }
        public void LBinary (byte[] Data) {
            AddBinary (Convert.ToBase64String (Data));
            }




        static string [] HexChars = {"0", "1", "2", "3", "4", "5", "6", "7", 
                                  "8", "9", "A", "B", "C", "D", "E", "F"};

        public static string Hex(byte b) {
                int MSN = b / 16;
                int LSN = b & (byte) 0xf;
            return HexChars [MSN] + HexChars [LSN];
            }        
        
        public void Hex (byte[] Data) {
            string Hex = "";
            foreach (byte b in Data) {
                Hex +=  Hex [b];
                }
            AddBinary (Hex);
            }
        public void Hex8 (byte[] Data) {
            Hex (Data);
            }
        public void Hex16 (byte[] Data) {
            Hex (Data);
            }
        }
    }
