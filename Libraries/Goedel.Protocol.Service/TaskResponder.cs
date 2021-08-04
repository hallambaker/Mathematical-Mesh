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


using System.Threading.Tasks;

using Goedel.Protocol.Presentation;

namespace Goedel.Protocol.Service {

    /// <summary>
    /// UDP Host type.
    /// </summary>
    public class HostUDP {

        #region // Properties
        #endregion

        #region // Destructor
        #endregion

        #region // Constructors
        #endregion

        #region // Implement Interface: Ixxx
        #endregion

        #region // Methods 
        #endregion
        }

    /// <summary>
    /// UDP Connection type (obsolete?)
    /// </summary>
    public class ConnectionUDP {

        #region // Properties

        ///<summary>This really goes in the stream</summary> 
        TaskCompletionSource<Packet> CompletionInbound;


        ///<summary>This really goes in the stream</summary> 
        Task<Packet> TaskInbound;

        /////<summary>These are bound to the specific connection.</summary> 
        //List<Packet> PacketsOutbound;


        #endregion

        #region // Destructor
        #endregion

        #region // Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public ConnectionUDP() {
            CompletionInbound = new();

            TaskInbound = CompletionInbound.Task;


            // Do this when we have completely assembled a datagram.
            CompletionInbound.SetResult(null);

            }

        #endregion

        #region // Implement Interface: Ixxx
        #endregion

        #region // Methods 
        #endregion
        }



    }
