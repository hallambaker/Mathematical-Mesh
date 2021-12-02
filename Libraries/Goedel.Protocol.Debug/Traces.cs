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


namespace Goedel.Protocol.Debug;

/// <summary>
/// The trace dictionary class is used for capturing a set of protocol
/// messages for use in documentation. The functions supported include
/// capture of the message objects and presenting them in full or
/// with various levels of redaction.
/// </summary>
public class TraceDictionary {

    TracePoint _Current;

    /// <summary>
    /// The Service Host Name
    /// </summary>
    public string HostName { get; }


    /// <summary>
    /// The HTTP Web Service URI
    /// </summary>
    public string URI { get; }


    /// <summary>
    /// The tract dictionary, maps labels to traces.
    /// </summary>
    public Dictionary<string, TracePoint> Traces = new();

    /// <summary>
    /// Set the level of detail for trace messages
    /// </summary>
    public int Level { get; set; }

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
        this.HostName = HostName;
        this.URI = URI;
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
    public TracePoint Label(string Tag, string Command = null) {
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

        return Found ? Result : null;

        }


    /// <summary>
    /// Create a trace entry for a request message
    /// </summary>
    /// <param name="Payload">The message Payload</param>
    /// <returns>The trace message entry</returns>
    public TraceMessage Request(JsonObject Payload) => new(Current, Payload, DateTime.Now, true);


    /// <summary>
    /// Create a trace entry for a response message
    /// </summary>
    /// <param name="Status">HTTP Status return line</param>
    /// <param name="Payload">The message Payload</param>
    /// <returns>The trace message entry</returns>
    public TraceMessage Response(string Status, JsonObject Payload) {
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

    ///<summary>Tag to label trace information with.</summary>
    public string Tag;

    /// <summary>
    /// The console command issued to cause the result.
    /// </summary>
    public string Command { get; set; }

    /// <summary>
    /// The text of the message
    /// </summary>
    public List<TraceMessage> Messages { get; set; }

    /// <summary>Current level of trace detail
    /// </summary>
    public int Level => TraceDictionary.Level;



    /// <summary>
    /// The current Trace Dictionary
    /// </summary>
    public TraceDictionary TraceDictionary { get; }


    /// <summary>
    /// Constructor for a trace point.
    /// </summary>
    /// <param name="traceDictionary">The parent dictionary</param>
    /// <param name="tag">Locator tag within the trace dictionary</param>
    public TracePoint(TraceDictionary traceDictionary, string tag) {
        TraceDictionary = traceDictionary;
        Messages = new List<TraceMessage>();
        Tag = tag;
        }



    }

/// <summary>
/// Represents a single trace message
/// </summary>
public class TraceMessage {

    TracePoint TracePoint;
    TraceDictionary TraceDictionary => TracePoint.TraceDictionary;

    /// <summary>
    /// The text of the message payload
    /// </summary>
    public JsonObject Payload { get; }

    /// <summary>
    /// The time the message was sent
    /// </summary>
    public DateTime Time { get; }

    /// <summary>
    /// If true message was a request, otherwise is a response.
    /// </summary>
    public bool IsRequest { get; }



    /// <summary>
    /// The HTTP result
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="TracePoint">the parent tracepoint</param>
    /// <param name="Payload">the payload object</param>
    /// <param name="Time">The date and time of the request</param>
    /// <param name="IsRequest">If true, this was a request message (sent by the initiator
    /// of the conversation. Otherwise it is a response.</param>
    public TraceMessage(TracePoint TracePoint,
                JsonObject Payload, DateTime Time, bool IsRequest) {
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
        JsonWriter JSONWriter;

        if (Redact) {
            JSONWriter = new JSONDebugWriter(Buffer);
            }
        else {
            JSONWriter = new JsonWriter(Buffer);
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

        return Level switch {
            0 => StringHTTP(false),
            1 => StringHTTP(true),
            4 => StringJSON(false),
            5 => StringJSON(true),
            _ => StringHTTP(true),
            };
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
