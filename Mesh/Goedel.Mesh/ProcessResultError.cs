using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;
using Goedel.Utilities;

using System;
using System.Text;

namespace Goedel.Mesh {
    /// <summary>
    /// Interface for returning the result of processing a message result
    /// </summary>
    public interface IProcessResult {

        /// <summary>
        /// Returns the response identifier.
        /// </summary>
        /// <returns>The response ID.</returns>
        string GetResponseID();

        ///<summary>If true, the operation succeeded</summary>
        bool Success { get; }

        ///<summary>The error report code</summary>
        string ErrorReport { get; }
        }


    /// <summary>
    /// Base class for error results.
    /// </summary>
    public abstract class ProcessResultError : IProcessResult {

        /// <summary>
        /// Returns the response identifier.
        /// </summary>
        /// <returns>The response ID.</returns>
        public string GetResponseID() => null;

        ///<summary>Always false for an error result.</summary>
        public bool Success => false;

        ///<summary>The error report code</summary>
        public abstract string ErrorReport { get; }
        }


    ///<summary>Invalid PIN result.</summary>
    public class PINNotAutomatic : ProcessResultError {
        ///<summary>The error report code</summary>
        public override string ErrorReport => "NotAutomatic";
        }

    ///<summary>Invalid PIN result.</summary>
    public class InvalidPIN : ProcessResultError {
        ///<summary>The error report code</summary>
        public override string ErrorReport => "InvalidPIN";
        }

    ///<summary>Expired PIN result. Note that this is different from an Invalid PIN as 
    ///the user might decide to accept the PIN manually.</summary>
    public class ExpiredPIN : ProcessResultError {
        ///<summary>The error report code</summary>
        public override string ErrorReport => "ExpiredPIN";
        }

    }
