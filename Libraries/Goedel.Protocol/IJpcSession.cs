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

//  

namespace Goedel.Protocol {



    /// <summary>
    /// Jpc Session interface.
    /// </summary>
    public interface IJpcSession {

        ///<summary>The verified account bound to this session (used for inbound sessions
        ///only.)</summary> 
        ICredential Credential { get; }

        /// <summary>
        /// The target account this session is attempting to interact with.
        /// </summary>
        public string TargetAccount { get;  }



        /// <summary>
        /// Post the request <paramref name="request"/> 
        /// </summary>
        /// <param name="tag">The transaction identifier.</param>

        /// <param name="request">The transaction request.</param>
        /// <returns>The transaction response</returns>
        JsonObject Post(string tag, JsonObject request);


        /// <summary>
        ///Bind new credential to the session to create a new one.
        /// </summary>
        /// <param name="credential">Credential to bind.</param>
        /// <returns>The new session.</returns>
        IJpcSession Rebind(ICredential credential);
        }
    }