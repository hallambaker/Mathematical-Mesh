using System;
using System.Collections.Generic;
using System.IO;
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

        /// <summary>
        /// Trace Dictionary for this session
        /// </summary>
        public TraceDictionary Traces { get; set; }


        /// <summary>
        /// Create a remote session without authentication. This call
        /// is typically used when beginning an interaction that will
        /// lead to the authentication credential being established.
        /// </summary>
        /// <param name="Host">The host implementation</param>
        /// <param name="serviceID">User account</param>
        public DebugLocalSession(JPCProvider Host, string serviceID)
                : this(Host, serviceID, null) {
            }

        /// <summary>
        /// Create a remote session with authentication under the
        /// specified credential.
        /// </summary>
        /// <param name="Host">The host implementation</param>
        /// <param name="Domain">Portal address</param>
        /// <param name="serviceID">User account</param>
        /// <param name="UDF">Authentication key identifier.</param>
        public DebugLocalSession(JPCProvider Host, string Domain, string serviceID, string UDF=null) :
                base (Host, serviceID, UDF ){


            }



        /// <summary>
        /// Post a request and retrieve the response.
        /// </summary>
        /// <param name="Data">StreamBuffer object containing JSON encoded request.</param>
        /// <returns>StreamBuffer object containing JSON encoded response.</returns>
        public override Stream Post(MemoryStream Data) {

            var DataText = Data.GetUTF8();
            var JSONReader = new JSONReader(DataText);

            var ResultObject = Host.Dispatch(this, JSONReader);

            return null;
            }

        /// <summary>
        /// Post a request and retrieve the response.
        /// </summary>
        /// <param name="Tag">Command</param>
        /// <param name="Request">JSON encoded request.</param>
        /// <returns>JSON encoded response.</returns>
        public override string Post(string Tag, JSONObject Request) {

            var Buffer = new MemoryStream();
            var JSONWriter = new JSONWriter(Buffer);

            // Wrap the request object with the transaction name.
            JSONWriter.WriteObjectStart();
            JSONWriter.WriteToken(Tag, 0);
            Request.Serialize(JSONWriter, false);
            JSONWriter.WriteObjectEnd();

            // Now prepare a reader so that the data can be unpacked
            var DataText = Buffer.GetUTF8();
            var JSONReader = new JSONReader(DataText);

            // Send the request
            var ResultObject = Host.Dispatch(this, JSONReader);

            if (Traces != null) {
                Traces.Request(Request);
                Traces.Response("200 OK", ResultObject);
                }

            // Return the response as a string for disassembly
            return ResultObject.ToString ();
            }

        }


    }
