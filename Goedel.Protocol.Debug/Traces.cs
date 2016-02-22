using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Protocol;


namespace Goedel.Protocol.Debug {
    /// <summary>
    /// 
    /// </summary>
    public class TraceDictionary {

        int _Level;
        TracePoint _Current;
        string _HostName;
        string _URI;

        /// <summary>
        /// The Service Host Name
        /// </summary>
        public string HostName {
            get {
                return _HostName;
                }
            }

        /// <summary>
        /// The HTTP Web Service URI
        /// </summary>
        public string URI {
            get {       
                return _URI;
                }
            }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, TracePoint> Traces;

        /// <summary>
        /// Set the level of detail for trace messages
        /// </summary>
        public int Level {
            get {
                return _Level;
                }
            set {
                _Level = value;
                }
            }

        /// <summary>
        /// The current trace point.
        /// </summary>
        public TracePoint Current {
            get {
                if (_Current == null) {
                    Label(null);
                    }
                return _Current;
                }
            }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TraceDictionary(string HostName, string URI) {
            _HostName = HostName;
            _URI = URI;
            Traces = new Dictionary<string, TracePoint>();
            }

        /// <summary>
        /// Start a new trace point.
        /// </summary>
        /// <param name="Tag"></param>
        public TracePoint Label(string Tag) {
            _Current = new TracePoint(this, Tag);
            Traces.Add(Tag, _Current);
            return _Current;
            }

        /// <summary>
        /// Find the trace point with the specified value
        /// </summary>
        /// <param name="Tag"></param>
        /// <returns></returns>
        public TracePoint Get(string Tag) {

            TracePoint Result;
            var Found = Traces.TryGetValue(Tag, out Result);

            return Found ? Result: null;

            }


        /// <summary>
        /// Create a trace entry for a request message
        /// </summary>
        /// <param name="Payload">The message Payload</param>
        /// <returns></returns>
        public TraceMessage Request(JSONObject Payload) {
            return new TraceMessage(Current, Payload, DateTime.Now, true);
            }


        /// <summary>
        /// Create a trace entry for a response message
        /// </summary>
        /// <param name="Status">HTTP Status return line</param>
        /// <param name="Payload">The message Payload</param>
        /// <returns></returns>
        public TraceMessage Response(string Status, JSONObject Payload) {
            var Message = new TraceMessage(Current, Payload, DateTime.Now, false);
            Message.Status = Status;

            return Message;
            }


        }

    /// <summary>
    /// 
    /// </summary>
    public class TracePoint {
        TraceDictionary _TraceDictionary;
        List<TraceMessage> _Messages;

        string _Tag;

        /// <summary>
        /// The text of the message
        /// </summary>
        public List<TraceMessage> Messages {
            get {
                return _Messages;
                }

            set {
                _Messages = value;
                }
            }

        /// <summary>
        /// Current level of trace detail
        /// </summary>
        public int Level {
            get {
                return _TraceDictionary.Level;
                }
            }

        /// <summary>
        /// The current Trace Dictionary
        /// </summary>
        public TraceDictionary TraceDictionary {
            get {
                return _TraceDictionary;
                }
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TraceDictionary">The parent dictionary</param>
        /// <param name="Tag">Locator tag within the trace dictionary</param>
        public TracePoint(TraceDictionary TraceDictionary, string Tag) {
            _TraceDictionary = TraceDictionary;
            _Messages = new List<TraceMessage>();
            _Tag = Tag;
            }



        }

    /// <summary>
    /// 
    /// </summary>
    public class TraceMessage {

        TracePoint TracePoint;
        JSONObject _Payload;

        string _Status;

        TraceDictionary TraceDictionary {
            get {
                return TracePoint.TraceDictionary;
                }
            }


        /// <summary>
        /// The text of the message payload
        /// </summary>
        public JSONObject Payload {
            get {
                return _Payload;
                }
            }


        DateTime _Time;
        /// <summary>
        /// The time the message was sent
        /// </summary>
        public DateTime Time {
            get {
                return _Time;
                }
            }


        bool _IsRequest;
        /// <summary>
        /// If true message was a request, otherwise is a response.
        /// </summary>
        public bool IsRequest {
            get {
                return _IsRequest;
                }
            }



        /// <summary>
        /// The HTTP result
        /// </summary>
        public string Status {
            get {
                return _Status;
                }
            set {
                _Status = value;
                }
            }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="TracePoint">the parent tracepoint</param>
        /// <param name="Payload"></param>
        /// <param name="Time"></param>
        /// <param name="IsRequest"></param>
        public TraceMessage(TracePoint TracePoint,
                    JSONObject Payload, DateTime Time, bool IsRequest) {
            this.TracePoint = TracePoint;
            _Payload = Payload;
            _Time = Time.ToUniversalTime();
            _IsRequest = IsRequest;

            TracePoint.Messages.Add(this);
            }

        /// <summary>
        /// Wrap minimal HTTP headers round a request
        /// </summary>
        /// <param name="Redact"></param>
        /// <returns>the formatted message</returns>
        public string StringHTTP(bool Redact) {
            var StringBuilder = new StringBuilder();

            var Payload = StringJSON(Redact);

            if (IsRequest) {
                StringBuilder.Append("POST ");
                StringBuilder.Append(TraceDictionary.URI);
                StringBuilder.Append("HTTP/1.1\r\nHost: ");
                StringBuilder.Append(TraceDictionary.HostName);
                }
            else {
                StringBuilder.Append("HTTP/1.1 ");
                StringBuilder.Append(Status);
                StringBuilder.Append("\r\nDate: ");
                StringBuilder.Append(Time.ToString(
                    "ddd dd MMM yyyy hh:mm:ss",
                    System.Globalization.CultureInfo.InvariantCulture));
                }

            StringBuilder.Append("\r\nContent-Length: ");
            StringBuilder.Append(Payload.Length);
            StringBuilder.Append("\r\n\r\n");
            StringBuilder.Append(Payload);

            return StringBuilder.ToString();
            }

        /// <summary>
        /// Serialize an individual payload
        /// </summary>
        /// <param name="Redact">If true, Base64 blobs are 
        /// limited to two start lines and a last line.</param>
        /// <returns>the formatted message</returns>
        public string StringJSON(bool Redact) {
            var Buffer = new StreamBuffer();
            var JSONWriter = new JSONWriter(Buffer);
            Payload.Serialize(JSONWriter, true);
            return JSONWriter.GetUTF8;
            }


        /// <summary>
        /// Serialize a message at the specified level of detail
        /// </summary>
        /// <param name="Level">level of detail. 0=full message, 
        /// 2= HTTP Payload including authentication envelope,
        /// 4 = Just the JSON payload. Adding 1 causes the JSON 
        /// payload to be abbreviated so that Base64 blobs are
        /// limited to a start line and a last line.</param>
        /// <returns>the formatted message</returns>
        public string String(int Level) {
            switch (Level) {
                case 0: return StringHTTP(false);
                case 1: return StringHTTP(true);
                case 4: return StringJSON(false);
                case 5: return StringJSON(true);
                }
            return StringHTTP(true);
            }

        /// <summary>
        /// Serialize a message at the current default level of detail
        /// </summary>
        /// <returns>the formatted message</returns>
        public string String() {
            return String(TracePoint.Level);
            }
        }
    }
