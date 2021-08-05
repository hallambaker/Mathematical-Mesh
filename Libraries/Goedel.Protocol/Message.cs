#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
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
#endregion

using System;
using System.Text;

using Goedel.Utilities;

namespace Goedel.Protocol {

    abstract public partial class Response {
        /// <summary>
        /// Returns true if the response indicates the transaction completed successfully
        /// </summary>
        /// <returns>true if the response indicates the transaction completed successfully</returns>
        public bool Success() => Status.IsSuccess();

        /// <summary>
        /// Returns true if the response indicates the transaction failed.
        /// </summary>
        /// <returns>true if the response indicates the transaction failed</returns>
        public bool Error() => Status.IsError();
        }

    /// <summary>
    /// Message types
    /// </summary>
    public enum MessageType {
        /// <summary>Request</summary>
        Request,
        /// <summary>Response</summary>
        Response
        }

    /// <summary>
    /// Message bound to transport context
    /// </summary>
    public abstract class BoundMessage {

        /// <summary>The payload data</summary>
        public string Payload;
        /// <summary>The authentication ticket</summary>
        public byte[] Ticket = null;
        //TicketData TicketData = null;
        /// <summary>The message authentication code.</summary>
        public byte[] MAC = null;

        /// <summary>The message as a HTTP string.</summary>
        public string HTTPBinding => HTTP();


        /// <summary>Convert message to HTTP</summary>
        /// <returns>The HTTP message value.</returns>
        public abstract string HTTP();

        /// <summary>Default constructor.</summary>
        public BoundMessage() => Payload = "{NOT-YET-IMPLEMENTED}";

        System.Text.Encoding UTF8 = new UTF8Encoding(false);

        /// <summary>The length of the payload data.</summary>
        public int ByteCount => UTF8.GetByteCount(Payload);


        /// <summary>The ticket in Base64.</summary>
        public string Base64Ticket => BaseConvert.ToStringBase64url(Ticket);


        /// <summary>The message authentication code in Base64.</summary>
        public string Base64Mac => BaseConvert.ToStringBase64url(MAC);




        /// <summary>Construct from a payload string.</summary>
        /// <param name="PayloadIn">The payload to construct from</param>
        public BoundMessage(string PayloadIn) => Payload = PayloadIn;



        }


    /// <summary>The request message</summary>
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

        /// <summary>Construct from string payload.</summary>
        /// <param name="PayloadIn">The string payload to wrap.</param>
        public BoundRequest(string PayloadIn)
            : base(PayloadIn) { }

        ///// <summary></summary>
        //public BoundRequest(string PayloadIn, byte[] TicketIn,
        //             Goedel.Cryptography.Ticket.Cryptography.Authentication Authentication,
        //             Goedel.Cryptography.Ticket.Cryptography.Key Key)
        //    : base(PayloadIn, TicketIn, Authentication, Key) { }

        /// <summary>Present message as HTTP</summary>
        /// <returns>The formatted message.</returns>
        public override string HTTP() {
            string Header = String.Format(HeaderFormat, "/", "example.com", Payload.Length);
            string ContentIntegrity = "";
            if (Ticket != null) {
                ContentIntegrity = String.Format(ContentIntegrityFormat, Base64Mac, Base64Ticket);
                }

            return Header + ContentIntegrity + "\n" + Payload;
            }
        }

    /// <summary>The response message</summary>
    public class BoundResponse : BoundMessage {

        /// <summary>Constant for invalid Mac response.</summary>
        public static BoundResponse ErrorBadMac = new(401, "Not Authorized");

        /// <summary>Constant for invalid message error.</summary>
        public static BoundResponse ErrorUnknown = new(500, "Internal Server Error");

        /// <summary>Constant for bad request.</summary>
        public static BoundResponse ErrorSyntax = new(400, "Bad Request");


        /// <summary>The status value (defaults to 200)</summary>
        public int Status = 200;

        /// <summary>The status description.</summary>
        public string StatusDescription = "OK";

        static string HeaderFormat = @"HTTP/1.1 {0} {1}
Content-Type: application/json;charset=UTF-8
Content-Length: {2}
";
        static string ContentIntegrityFormat = "Session: Value={0}; Id={1}\n";
        //public BoundResponse(string PayloadIn, Cryptographic Cryptographic)
        //    : base(PayloadIn, Cryptographic) { }

        /// <summary>Construct response for the specified payload.</summary>
        /// <param name="PayloadIn">The message payload.</param>
        public BoundResponse(string PayloadIn)
            : base(PayloadIn) { }

        ///// <summary></summary>
        //public BoundResponse(string PayloadIn, byte[] TicketIn,
        //             Goedel.Cryptography.Ticket.Cryptography.Authentication Authentication,
        //             Goedel.Cryptography.Ticket.Cryptography.Key Key)
        //    : base(PayloadIn, TicketIn, Authentication, Key) { }

        /// <summary>Construct response for the specified result code.</summary>
        /// <param name="ErrorCode">The error code to return.</param>
        /// <param name="Explanation">Description of the error.</param>
        public BoundResponse(int ErrorCode, string Explanation) {
            Payload = Explanation;
            Status = ErrorCode;
            }

        /// <summary>Present message as HTTP</summary>
        /// <returns>The message value.</returns>
        public override string HTTP() {
            string Header = String.Format(HeaderFormat, Status, StatusDescription, Payload.Length);
            string ContentIntegrity = "";
            if (Ticket != null) {
                ContentIntegrity = String.Format(ContentIntegrityFormat, Base64Mac, Base64Ticket);
                }

            return Header + ContentIntegrity + "\n" + Payload;
            }

        }


    }