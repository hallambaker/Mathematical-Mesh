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
using Goedel.Protocol;
//using OBPConnection;
//using OBPQuery;

namespace Goedel.Protocol {
    public enum MessageType {
        Request,
        Response
        }


    public abstract class BoundMessage {
        public string Payload;
        public byte[] Ticket = null;
        //TicketData TicketData = null;
        public byte[] MAC = null;

        public string HTTPBinding {
            get { return HTTP () ;}
            }

        public abstract string HTTP() ; 

        public BoundMessage() {
            Payload = "{NOT-YET-IMPLEMENTED}";
            }

        Encoding UTF8 = new UTF8Encoding(false);

        public int ByteCount {
            get { return UTF8.GetByteCount(Payload); }
            }
        public string Base64Ticket {
            get { return BaseConvert.ToBase64urlString(Ticket); }
            }
        public string Base64Mac {
            get { return BaseConvert.ToBase64urlString(MAC); }
            }

        public byte[] GetMAC(Cryptography.Authentication Authentication, Cryptography.Key Key) {
            if (Authentication != Cryptography.Authentication.Unknown) {
                return Cryptography.GetMAC(Payload, Authentication, Key);
                }
            else {
                return null;
                }
            }

        public void MakeMAC(Cryptography.Authentication Authentication, Cryptography.Key Key) {
            MAC = GetMAC(Authentication, Key);
            }

        public bool VerifyMAC(Cryptography.Authentication Authentication, Cryptography.Key Key) {
            byte[] Test = GetMAC(Authentication, Key);

            return Cryptography.ArraysEqual(Test, MAC);
            }

        public BoundMessage(string PayloadIn) {
            Payload = PayloadIn;
            }

        //public BoundMessage(string PayloadIn, Cryptographic Cryptographic) {
        //    if (Cryptographic == null) {
        //        Payload = PayloadIn;
        //        }
        //    else {
        //        Cryptography.Authentication Authentication =
        //            Cryptography.AuthenticationCode(Cryptographic.Authentication);
        //        Cryptography.Key Key = new Cryptography.Key(Cryptographic.Secret, Authentication,
        //                   Cryptography.Encryption.Unknown);
        //        BindMessage(PayloadIn, Cryptographic.Ticket, Authentication, Key);
        //        }
        //    }
        public BoundMessage(string PayloadIn, byte[] TicketIn,
                     Cryptography.Authentication Authentication, Cryptography.Key Key) {
            BindMessage(PayloadIn, TicketIn, Authentication, Key);
            }

        private void BindMessage(string PayloadIn, byte[] TicketIn,
                    Cryptography.Authentication Authentication, Cryptography.Key Key) {
            Payload = PayloadIn;
            Ticket = TicketIn;
            MakeMAC(Authentication, Key);
            }



        }


    public class BoundRequest : BoundMessage {

        static string HeaderFormat = @"Post {0} HTTP/1.1
Host: {1}
Cache-Control: no-store
Content-Type: Application/json;charset=UTF-8
Content-Length: {2}
";
        static string ContentIntegrityFormat = "Session: Value={0}; Id={1}\n";


        //public BoundRequest(string PayloadIn, Cryptographic Cryptographic)
        //    : base(PayloadIn, Cryptographic) { }
        public BoundRequest(string PayloadIn) 
            : base (PayloadIn) { }
        public BoundRequest(string PayloadIn, byte[] TicketIn,
                     Cryptography.Authentication Authentication, Cryptography.Key Key)
            : base(PayloadIn, TicketIn, Authentication, Key) { }

        public override string HTTP () {
            string Header = String.Format (HeaderFormat, "/", "example.com", Payload.Length);
            string ContentIntegrity = "";
            if (Ticket != null) {
                ContentIntegrity = String.Format (ContentIntegrityFormat, Base64Mac, Base64Ticket);
                }

            return Header + ContentIntegrity + "\n" + Payload;
            }
        }

    public class BoundResponse : BoundMessage {

        public static BoundResponse ErrorBadMac = new BoundResponse (401, "Not Authorized");
        public static BoundResponse ErrorUnknown = new BoundResponse (500, "Internal Server Error");
        public static BoundResponse ErrorSyntax =  new BoundResponse (400, "Bad Request");


        public int Status = 200;
        public string StatusDescription = "OK";

        static string HeaderFormat = @"HTTP/1.1 {0} {1}
Content-Type: application/json;charset=UTF-8
Content-Length: {2}
";
        static string ContentIntegrityFormat = "Session: Value={0}; Id={1}\n";
        //public BoundResponse(string PayloadIn, Cryptographic Cryptographic)
        //    : base(PayloadIn, Cryptographic) { }
        public BoundResponse(string PayloadIn) 
            : base (PayloadIn) { }
        public BoundResponse(string PayloadIn, byte[] TicketIn,
                     Cryptography.Authentication Authentication, Cryptography.Key Key)
            : base(PayloadIn, TicketIn, Authentication, Key) { }

        public BoundResponse(int ErrorCode, string Explanation) {
            Payload = Explanation;
            Status = ErrorCode;
            }

        public override string HTTP () {
            string Header = String.Format (HeaderFormat, Status, StatusDescription, Payload.Length);
            string ContentIntegrity = "";
            if (Ticket != null) {
                ContentIntegrity = String.Format (ContentIntegrityFormat, Base64Mac, Base64Ticket);
                }

            return Header + ContentIntegrity + "\n" + Payload;
            }

        }


    }