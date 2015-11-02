using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Goedel.Protocol;

namespace Goedel.Protocol {
    public class WebMessageTrace {
        public WebRequest WebRequest;
        public string Request, Response;
        public HttpWebResponse HttpWebResponse;

        string CRLF = "\r\n";
        Boolean Empty = false;
        
        public WebMessageTrace() {
            Empty = true;
            }

        public WebMessageTrace(WebRequest WebRequest, string Request, HttpWebResponse HttpWebResponse,
                   string Response) {
            this.WebRequest = WebRequest;
            this.HttpWebResponse = HttpWebResponse;
            this.Request = Request;
            this.Response = Response;
            }

        public string HTTPRequest {
            get {
                if (Empty) return "[To Be Specified]";

                string result = WebRequest.Method + " " + WebRequest.RequestUri.AbsolutePath
                    + WebRequest.RequestUri.Query + " HTTP/1.1" + CRLF;
                result += WebRequest.Headers;
                result += Request;

                return WrapWriter.Wrap (result);
                }
            }

        public string HTTPResponse {
            get {
                if (Empty) return "[To Be Specified]";
                string result = "HTTP/1.1 " +  HttpWebResponse.StatusCode.ToString () + " " +
                     HttpWebResponse.StatusDescription + CRLF + HttpWebResponse.Headers + Response;

                return WrapWriter.Wrap (result);
                }
            }

        }
    
    
    public class WebServiceClient {
        int Port;
        string Domain;
        string Stem;

        string Uri { get { return "http://" + Domain + ":" + Port.ToString() + "/" + Stem ;}}


        public bool Trace = false;
        public WebMessageTrace WebMessageTrace;

        public CryptographicContext CryptographicContext = null;
        

        public WebServiceClient(string Domain, int Port, string Stem) :
            this (Domain, Port, Stem, false, false ) {
            }

        public WebServiceClient(string Domain, int Port, string Stem, bool UseLocal, bool Debug) {
            this.Port = Port;
            this.Domain = UseLocal ? "localhost" : Domain;
            this.Stem = Stem == null ? "" : Stem;
            this.Trace = Debug;
            }


        WebRequest  GetWebRequest () {
            WebRequest WebRequest = WebRequest.Create (Uri);
            WebRequest.Method = "POST";

            WebRequest.ContentType = "application/json;charset=UTF-8";
            WebRequest.Headers.Add("Cache-Control: no-store");
            

            return WebRequest;
            }


        HttpWebResponse GetWebResponse(WebRequest WebRequest) {
            HttpWebResponse WebResponse = (HttpWebResponse)WebRequest.GetResponse();
            int Code = (int)WebResponse.StatusCode;

            Console.WriteLine("Got a response {0} {1}",
                Code, WebResponse.StatusDescription);

            if (Code > 399) {
                throw new Exception(WebResponse.StatusDescription);
                }

            return WebResponse;
            }

        //
        // A more efficient implementation would 
        //
        public StreamBuffer Request (StreamBuffer Content) {
            WebRequest WebRequest  = GetWebRequest ();

            byte[] buffer = Content.GetBytes;
            WebRequest.ContentLength = Content.Length;

            if (CryptographicContext != null) {
                string Integrity = CryptographicContext.GetIntegrityHeader (buffer);
                WebRequest.Headers.Add(Integrity);
                }

            Content.Write (WebRequest.GetRequestStream ());

            HttpWebResponse WebResponse = GetWebResponse(WebRequest) ;

            StreamBuffer ReadBuffer = new StreamBuffer (WebResponse.GetResponseStream ());
            string Result = ReadBuffer.GetUTF8;

            //Console.WriteLine(Result);
            //Console.WriteLine("-----------");

            if (Trace) WebMessageTrace = new WebMessageTrace (WebRequest, Content.GetUTF8, WebResponse, Result);

            return ReadBuffer;
            }




        public string Request(string Content) {
            WebRequest WebRequest  = GetWebRequest ();

            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(Content);
            WebRequest.ContentLength = buffer.Length;

            if (CryptographicContext != null) {
                string Integrity = CryptographicContext.GetIntegrityHeader (buffer);
                WebRequest.Headers.Add(Integrity);
                }

            StreamBuffer.Write (WebRequest.GetRequestStream (), buffer);

            HttpWebResponse WebResponse = GetWebResponse(WebRequest) ;

            StreamBuffer ReadBuffer = new StreamBuffer (WebResponse.GetResponseStream ());
            string Result = ReadBuffer.GetUTF8;

            Console.WriteLine(Result);
            Console.WriteLine("-----------");

            if (Trace) WebMessageTrace = new WebMessageTrace (WebRequest, Content, WebResponse, Result);

            return Result;
            }
        }
    }
