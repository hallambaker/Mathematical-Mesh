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


namespace Goedel.Protocol {
    /// <summary>
    /// Direct connection between client and service host. Useful for debugging
    /// and for direct access to a service on the same machine.
    /// </summary>
    public partial class JpcSessionDirect : JpcSession {
        JpcInterface JpcInterface { get; }

        /// <summary>
        /// Create a direct session for the specified account.
        /// </summary>
        /// <param name="credential">The credential to be used.</param>
        /// <param name="jpcInterface">The interfact to which the direct session is bound</param>
        public JpcSessionDirect(JpcInterface jpcInterface, ICredential credential) : base(credential) {
            JpcInterface = jpcInterface;
            }

        /// <summary>
        /// Return a client bound to the interface using the session.
        /// </summary>
        /// <typeparam name="T">The client type</typeparam>
        /// <returns>The client</returns>
        public override T GetWebClient<T>() => JpcInterface.GetDirect(this) as T;
        ///<inheritdoc/>
        public override IJpcSession Rebind(ICredential credential) {
            Credential = credential;
            return this;
            }
        }


    }

