using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Goedel.Protocol;


namespace Goedel.Protocol.Debug {
    /// <summary>
    /// The trace dictionary class is used for capturing a set of protocol
    /// messages for use in documentation. The functions supported include
    /// capture of the message objects and presenting them in full or
    /// with various levels of redaction.
    /// </summary>
    public class TraceDictionary {

        TracePoint _Current;
        string _HostName;
        string _URI;

        /// <summary>
        /// The Service Host Name
        /// </summary>
        public string HostName  => _HostName;


        /// <summary>
        /// The HTTP Web Service URI
        /// </summary>
        public string URI => _URI;


        /// <summary>
        /// The tract dictionary, maps labels to traces.
        /// </summary>
        public Dictionary<string, TracePoint> Traces = new Dictionary<string, TracePoint>();

        /// <summary>
        /// Set the level of detail for trace messages
        /// </summary>
        public int Level {get; set; }

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
        /// <param name="HostName">The host name for the example</param>
        /// <param name="URI">The web service end point.</param>
        public TraceDictionary(string HostName, string URI) {
            _HostName = HostName;
            _URI = URI;
            Traces = new Dictionary<string, TracePoint>();
            }

        /// <summary>
        /// Start a new named trace point. This allows an example generator to assign
        /// labels to each test 'label1' and retrieve the 2nd message of trace 'label1'
        /// when describing that particular function.
        /// </summary>
        /// <param name="Tag">Label for future retrieval</param>
        /// <param name="Command">Console command that caused the trace.</param>
        /// <returns>The trace point created.</returns>
        public TracePoint Label (string Tag, string Command = null) {
            _Current = new TracePoint(this, Tag) {
                Command = Command
                };
            Traces.Add(Tag, _Current);
            return _Current;
            }

        /// <summary>
        /// Find the trace point with the specified value
        /// </summary>
        /// <param name="Tag">The trace label to find</param>
        /// <returns>The traces created.</returns>
        public TracePoint Get(string Tag) {
            var Found = Traces.TryGetValue(Tag, out var Result);

            return Found ? Result: null;

            }


        /// <summary>
        /// Create a trace entry for a request message
        /// </summary>
        /// <param name="Payload">The message Payload</param>
        /// <returns>The trace message entry</returns>
        public TraceMessage Request(JSONObject Payload) {
            return new TraceMessage(Current, Payload, DateTime.Now, true);
            }


        /// <summary>
        /// Create a trace entry for a response message
        /// </summary>
        /// <param name="Status">HTTP Status return line</param>
        /// <param name="Payload">The message Payload</param>
        /// <returns>The trace message entry</returns>
        public TraceMessage Response (string Status, JSONObject Payload) {
            var Message = new TraceMessage(Current, Payload, DateTime.Now, false) {
                Status = Status
                };

            return Message;
            }


        }

    /// <summary>
    /// Capture a related set of traces.
    /// </summary>
    public class TracePoint {
        TraceDictionary _TraceDictionary;
        List<TraceMessage> _Messages;

        string _Tag;

        /// <summary>
        /// The console command issued to cause the result.
        /// </summary>
        public string Command { get; set; }

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
        public int Level =>TraceDictionary.Level;



        /// <summary>
        /// The current Trace Dictionary
        /// </summary>
        public TraceDictionary TraceDictionary => _TraceDictionary;


        /// <summary>
        /// Constructor for a trace point.
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
    /// Represents a single trace message
    /// </summary>
    public class TraceMessage {

        TracePoint TracePoint;
        TraceDictionary TraceDictionary  => TracePoint.TraceDictionary; 

        /// <summary>
        /// The text of the message payload
        /// </summary>
        public JSONObject Payload { get; }

        /// <summary>
        /// The time the message was sent
        /// </summary>
        public DateTime Time { get ; }

        /// <summary>
        /// If true message was a request, otherwise is a response.
        /// </summary>
        public bool IsRequest { get ; }



        /// <summary>
        /// The HTTP result
        /// </summary>
        public string Status {get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="TracePoint">the parent tracepoint</param>
        /// <param name="Payload">the payload object</param>
        /// <param name="Time">The date and time of the request</param>
        /// <param name="IsRequest">If true, this was a request message (sent by the initiator
        /// of the conversation. Otherwise it is a response.</param>
        public TraceMessage(TracePoint TracePoint,
                    JSONObject Payload, DateTime Time, bool IsRequest) {
            this.TracePoint = TracePoint;
            this.Payload = Payload.DeepCopy();
            this.Time = Time.ToUniversalTime();
            this.IsRequest = IsRequest;

            TracePoint.Messages.Add(this);
            }

        /// <summary>
        /// Wrap minimal HTTP headers round a request
        /// </summary>
        /// <param name="Redact">If true, redact the payload to omit long
        /// sections of base64 encoded text.</param>
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
            var Buffer = new MemoryStream();
            JSONWriter JSONWriter;

            if (Redact) {
                JSONWriter = new JSONDebugWriter(Buffer);
                }
            else {
                JSONWriter = new JSONWriter(Buffer);
                }
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
            if (Payload == null) {
                return "$$$$ Missing $$$$";
                }

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
            var Result = "\n~~~~\n" + String(TracePoint.Level) + "\n~~~~\n";

            return Result;
            }
        }
    }
