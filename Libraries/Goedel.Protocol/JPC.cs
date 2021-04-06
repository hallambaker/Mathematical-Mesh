//  Copyright © 2015 by Comodo Group Inc.
//  Copyright © 2021 Threshold Secrets Llc
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
//  
//  

using System.Collections.Generic;
using System.IO;

namespace Goedel.Protocol {

    /// <summary>
    /// Base class for all JPC server classes.
    /// </summary>
    public abstract class JpcInterface {

        ///<summary>List of DNS domains serviced by this interface.</summary> 
        public List<string> Domains { get; set; }

        /// <summary>
        /// The WellKnown service name for HTTP and DNS prefix use.
        /// </summary>
        public abstract string GetWellKnown {
            get;
            }

        /// <summary>
        /// The WellKnown service name for HTTP and DNS prefix use.
        /// </summary>
        public abstract string GetDiscovery {
            get;
            }

        /// <summary>
        /// Dispatch Class. Reads input from the provided reader and attempts to
        /// dispatch a method in response. Note that the calling routine may throw 
        /// an error. This must be caught and processed by the host dispatch class.
        /// </summary>
        /// <param name="Session">The service session that is to handle the request.</param>
        /// <param name="JSONReader">The input stream to be read</param>
        /// <returns>The response to the request.</returns>
        public abstract Goedel.Protocol.JsonObject Dispatch(IJpcSession Session,
            JsonReader JSONReader);

        /// <summary>
        /// Return a client tapping the service API directly without serialization bound to
        /// the session <paramref name="jpcSession"/>. This is intended for use in testing etc.
        /// </summary>
        /// <param name="jpcSession">Session to which requests are to be bound.</param>
        /// <returns>The direct client instance.</returns>
        public abstract Goedel.Protocol.JpcClientInterface GetDirect(IJpcSession jpcSession);

        /// <summary>
        /// Return a JpcSession for the service.
        /// </summary>
        /// <returns></returns>
        public abstract IJpcSession GetSession();


        }

    /// <summary>
    /// Base class for all JPC client classes.
    /// </summary>
    public abstract class JpcClientInterface {

        /// <summary>
        /// The WellKnown service name for HTTP and DNS prefix use.
        /// </summary>
        public abstract string GetWellKnown {
            get;
            }

        /// <summary>
        /// The WellKnown service name for HTTP and DNS prefix use.
        /// </summary>
        public abstract string GetDiscovery {
            get;
            }

        /// <summary>
        /// The active JpcSession.
        /// </summary>		
        public virtual IJpcSession JpcSession { get; set; }



        //public JpcClientInterface(IJpcSession jpcSession = null) =>
        //    JpcSession = jpcSession;



        ///<summary>The active JpcSession as a remote session.</summary> 
        public IJpcSession JpcRemoteSession => JpcSession;

        }
    }

