//  Copyright © 2021 by Threshold Secrets Llc.
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

using Goedel.Utilities;
//using Goedel.Protocol.Service;
using System.Threading.Tasks;



namespace Goedel.Protocol.Presentation {
    /// <summary>
    /// RUD service stream, exposes transaction dispatch methods.
    /// </summary>
    public class RudStreamService : RudStream {

        ///<summary>The service instance.</summary> 
        public JpcInterface JpcInterface;

        #region // Constructors

        /// <summary>
        /// Initialize a new stream instance as a child of <paramref name="parent"/> to support
        /// protocol <paramref name="protocol"/> 
        /// </summary>
        /// <param name="parent">The parent stream</param>
        /// <param name="protocol">The stream protocol</param>
        /// <param name="credential">Optional additional credential.</param>
        /// <param name="rudConnection">The parent connection (if specified, overrides <paramref name="parent"/></param>

        public RudStreamService(
                RudStream parent,
                string protocol,
                ICredentialPrivate credential = null, 
                string instance=null,
                RudConnection rudConnection = null) : base(parent, protocol, credential, rudConnection) {

            JpcInterface = RudConnection?.Listener.GetService(protocol, instance);

            }
        #endregion


        #region // Methods


        public async Task<DataGram> AsyncRequestDatagram() => throw new NYI();

        public async Task<JsonObject> AsyncRequestObject() => throw new NYI();


        public void Respond (DataGram dataGram) => throw new NYI();


        public void Respond(JsonObject jsonObject) => throw new NYI();
        #endregion
        }


    }
