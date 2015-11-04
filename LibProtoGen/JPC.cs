using System;


namespace Goedel.Protocol {

    /// <summary>
    /// Base class for a Host
    /// </summary>
    public abstract class JPCHost {

        /// <summary>
        /// Dispatch Class. Reads input from the provided reader and attempts to
        /// dispatch a method in response. Note that the calling routine may throw 
        /// an error. This must be caught and processed by the host dispatch class.
        /// </summary>
        /// <param name="JPCService">The service that is to handle the request.</param>
        /// <param name="JSONReader"></param>
        /// <returns>The response to the request.</returns>
        public abstract Goedel.Protocol.JSONObject Dispatch(JPCSession Session,
            JSONReader JSONReader);

        }


    /// <summary>
    /// Base class for all JPC server and client classes.
    /// </summary>
    public abstract class JPCService {

        /// <summary>
        /// The WellKnown service name for HTTP and DNS prefix use.
        /// </summary>
        public abstract string GetWellKnown {
            get;
            }

        }





    /// <summary>
    /// The session class describes the caller of a method.
    /// </summary>
    public abstract class JPCSession {

        /// <summary>
        /// Account name.
        /// </summary>
        public string Account;

        /// <summary>
        /// Fingerprint of authentication key
        /// </summary>
        public string UDF;

        /// <summary>
        /// Portal Address.
        /// </summary>
        public string Portal;

        /// <summary>
        /// If true we have an authentication structure.
        /// </summary>
        public bool Authenticated;

        /// <summary>
        /// Authenticate session data.
        /// </summary>
        /// <param name="UDF">Fingerprint of authentication key to use for authentication.</param>
        public abstract bool Authenticate(string UDF);
      

        }

    /// <summary>
    /// Direct connection between client and service host. Useful for debugging
    /// and for direct access to a service on the same machine.
    /// </summary>
    public partial class DirectSession : JPCSession{

        public DirectSession (string Account) {
            this.Account = Account;
            }

        public override bool Authenticate(string UDF) {
            this.UDF = UDF;
            Authenticated = true;
            return Authenticated;
            }
        }



    /// <summary>
    /// Direct connection between client and service host. Useful for debugging
    /// and for direct access to a service on the same machine.
    /// </summary>
    public abstract partial class JPCRemoteSession : JPCSession {



        /// <summary>
        /// Set the authentication key for use with the session
        /// </summary>
        /// <param name="UDF">Fingerprint of the authentication key.</param>
        /// <returns>True is successful. Otherwise, false.</returns>
        public override bool Authenticate(string UDF) {
            this.UDF = UDF;
            return false;
            }

        public abstract StreamBuffer Post(StreamBuffer Data);

        public virtual string Post (string Tag, JSONObject Request) {

            var Buffer = new StreamBuffer();
            var JSONWriter = new JSONWriter(Buffer);

            // Wrap the request object with the transaction name.
            JSONWriter.WriteObjectStart();
            JSONWriter.WriteToken(Tag,0);
            Request.Serialize(JSONWriter, true);
            JSONWriter.WriteObjectEnd();

            // Send the request
            var ResponseBuffer = Post(Buffer);
            return ResponseBuffer.GetUTF8;
            }

        }

    /// <summary>
    /// Direct connection between client and service host with messages 
    /// encoded and decoded from JSON. For use in debugging issues that
    /// might be the result of JSON encoding issues and to collect samples
    /// for documentation.
    /// </summary>
    public partial class LocalRemoteSession : JPCRemoteSession {
        JPCHost Host;

        /// <summary>
        /// Create a remote session without authentication. This call
        /// is typically used when beginning an interaction that will
        /// lead to the authentication credential being established.
        /// </summary>
        /// <param name="Host">The host implementation</param>
        /// <param name="Domain">Portal address</param>
        /// <param name="Account">User account</param>
        public LocalRemoteSession(JPCHost Host, string Domain, string Account)
                : this (Host, Domain, Account, null)  {
            }

        /// <summary>
        /// Create a remote session with authentication under the
        /// specified credential.
        /// </summary>
        /// <param name="Host">The host implementation</param>
        /// <param name="Domain">Portal address</param>
        /// <param name="Account">User account</param>
        /// <param name="UDF">Authentication key identifier.</param>
        public LocalRemoteSession(JPCHost Host, string Domain, string Account, string UDF) {
            this.Account = Account;
            this.Portal = Domain;
            this.UDF = UDF;
            this.Host = Host;
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

        }



    /// <summary>
    /// Generic exception. Thrown when the specified host is not
    /// valid.
    /// </summary>
    public class InvalidHostService : SystemException {
        public InvalidHostService() : base() { }
        public InvalidHostService(string message) : base(message) { }
        public InvalidHostService(string message, System.Exception inner) : base(message, inner) { }
        }

    /// <summary>
    /// Generic exception. Thrown when the requested operation is not
    /// known to the host.
    /// </summary>
    public class UnknownOperation : SystemException {
        public UnknownOperation() : base() { }
        public UnknownOperation(string message) : base(message) { }
        public UnknownOperation(string message, System.Exception inner) : base(message, inner) { }
        }

    }

