#region // Copyright
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
using System.IO;

using Goedel.Utilities;


namespace Goedel.Protocol.Debug {



    /// <summary>
    /// Direct connection between client and service host with messages 
    /// encoded and decoded from JSON. For use in debugging issues that
    /// might be the result of JSON encoding issues and to collect samples
    /// for documentation.
    /// </summary>
    public class DebugLocalSession : JpcSessionSerialized {

        /// <summary>
        /// Trace Dictionary for this session
        /// </summary>
        public TraceDictionary Traces { get; set; }


        /// <summary>
        /// Create a remote session with debugging hooks.
        /// </summary>
        /// <param name="host">The host implementation</param>
        /// <param name="credential">The credential to be used.</param>
        public DebugLocalSession(JpcInterface host, ICredential credential)
                : base(host, credential) {
            }



        /// <summary>
        /// Post a request and retrieve the response.
        /// </summary>
        /// <param name="data">StreamBuffer object containing JSON encoded request.</param>
        /// <param name="requestObject">The abstract request object (for debugging).</param>
        /// <returns>StreamBuffer object containing JSON encoded response.</returns>
        public override Stream Post(MemoryStream data, JsonObject requestObject) {

            var DataText = data.GetUTF8();
            var JSONReader = new JsonReader(DataText);

            var ResultObject = Host.Dispatch(this, JSONReader);
            ResultObject.Future();

            "Need to reset the API here to be on the object.".TaskFunctionality(true);

            return null;
            }


        }


    }
