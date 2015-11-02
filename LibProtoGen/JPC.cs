using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;

namespace Goedel.Protocol {

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
        public string Account;
        public string UDF;
        public bool Authenticated;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UDF"></param>
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
    public partial class RemoteSession : JPCSession {

        /// <summary>
        /// Create a remote session without authentication. This call
        /// is typically used when beginning an interaction that will
        /// lead to the authentication credential being established.
        /// </summary>
        /// <param name="Domain"></param>
        /// <param name="Account"></param>
        public RemoteSession(string Domain, string Account) {
            this.Account = Account;
            }

        /// <summary>
        /// Create a remote session with authentication under the
        /// specified credential.
        /// </summary>
        /// <param name="Domain"></param>
        /// <param name="Account"></param>
        /// <param name="UDF"></param>
        public RemoteSession(string Domain, string Account, string UDF) {
            this.Account = Account;
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UDF"></param>
        /// <returns></returns>
        public override bool Authenticate(string UDF) {
            this.UDF = UDF;
            return false;
            }
        }





    public class InvalidHostService : SystemException {
        public InvalidHostService() : base() { }
        public InvalidHostService(string message) : base(message) { }
        public InvalidHostService(string message, System.Exception inner) : base(message, inner) { }
        }

    public class UnknownOperation : SystemException {
        public UnknownOperation() : base() { }
        public UnknownOperation(string message) : base(message) { }
        public UnknownOperation(string message, System.Exception inner) : base(message, inner) { }
        }

    }

