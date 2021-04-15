////  Copyright © 2021 by Threshold Secrets Llc.
////  
////  Permission is hereby granted, free of charge, to any person obtaining a copy
////  of this software and associated documentation files (the "Software"), to deal
////  in the Software without restriction, including without limitation the rights
////  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
////  copies of the Software, and to permit persons to whom the Software is
////  furnished to do so, subject to the following conditions:
////  
////  The above copyright notice and this permission notice shall be included in
////  all copies or substantial portions of the Software.
////  
////  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
////  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
////  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
////  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
////  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
////  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
////  THE SOFTWARE.

//using Goedel.Utilities;

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;
//using Goedel.Protocol.Service;

//namespace Goedel.Protocol.Presentation {

//    /// <summary>
//    /// RDP Service provider managing HTTP and UDP listeners using Mesh credentials.
//    /// </summary>
//    public class RdpService : Goedel.Protocol.Service.Service {

//        /// <summary>
//        /// Constructor returning an instance servicing the interfaces <paramref name="providers"/>.
//        /// </summary>
//        /// <param name="credential">The responder credential</param>
//        /// <param name="providers">The services to be served.</param>
//        /// <param name="maxCores">Maximum number of dispatch threads.</param>
//        /// <remarks>Constructor returns after the service has been started and listener threads 
//        /// initialized.</remarks>
//        public RdpService(Credential credential, List<Provider> providers, int maxCores = 0) : 
//                    base (new RdpListener(credential), providers, maxCores) {
//            }




//        }
//    }
