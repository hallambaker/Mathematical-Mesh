using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Goedel.Protocol;

namespace Goedel.Protocol.Debug {



    /// <summary>
    /// Direct connection between client and service host with messages 
    /// encoded and decoded from JSON. For use in debugging issues that
    /// might be the result of JSON encoding issues and to collect samples
    /// for documentation.
    /// </summary>
    public  class DebugLocalSession :LocalRemoteSession  {
        TraceDictionary _Traces;

        /// <summary>
        /// Trace Dictionary for this session
        /// </summary>
        public TraceDictionary Traces {
            get {
                return _Traces;
                }
            set {
                _Traces = value;
                }
            }


        /// <summary>
        /// Create a remote session without authentication. This call
        /// is typically used when beginning an interaction that will
        /// lead to the authentication credential being established.
        /// </summary>
        /// <param name="Host">The host implementation</param>
        /// <param name="Domain">Portal address</param>
        /// <param name="Account">User account</param>
        public DebugLocalSession(JPCProvider Host, string Domain, string Account)
                : this(Host, Domain, Account, null) {
            }

        /// <summary>
        /// Create a remote session with authentication under the
        /// specified credential.
        /// </summary>
        /// <param name="Host">The host implementation</param>
        /// <param name="Domain">Portal address</param>
        /// <param name="Account">User account</param>
        /// <param name="UDF">Authentication key identifier.</param>
        public DebugLocalSession(JPCProvider Host, string Domain, string Account, string UDF) :
                base (Host, Domain, Account, UDF ){


            }



        /// <summary>
        /// Post a request and retrieve the response.
        /// </summary>
        /// <param name="Data">StreamBuffer object containing JSON encoded request.</param>
        /// <returns>StreamBuffer object containing JSON encoded response.</returns>
        public override StreamBuffer Post(StreamBuffer Data) {

            var DataText = Data.GetUTF8;
            var JSONReader = new JSONReader(DataText);

            var ResultObject = Host.Dispatch(this, JSONReader);

            return null;
            }

        public override string Post(string Tag, JSONObject Request) {

            var Buffer = new StreamBuffer();
            var JSONWriter = new JSONWriter(Buffer);

            // Wrap the request object with the transaction name.
            JSONWriter.WriteObjectStart();
            JSONWriter.WriteToken(Tag, 0);
            Request.Serialize(JSONWriter, true);
            JSONWriter.WriteObjectEnd();

            // Now prepare a reader so that the data can be unpacked
            var DataText = Buffer.GetUTF8;
            var JSONReader = new JSONReader(DataText);

            // Send the request
            var ResultObject = Host.Dispatch(this, JSONReader);

            if (_Traces != null) {
                _Traces.Request(Request);
                _Traces.Response("200 OK", ResultObject);
                }

            // Return the response as a string for disassembly
            return ResultObject.ToString ();
            }

        }


    }
