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

using System.IO;
using System.Net;
using Goedel.Utilities;
using Goedel.Discovery;

namespace Goedel.Protocol {
    //public delegate JpcSession JpcSessionFactoryDelegate(
    //            JpcCredential jpcCredential);



    /// <summary>
    /// Jpc credential. May be extended in subclasses to enable authentication.
    /// </summary>
    public class JpcCredential {

        ///<summary>The account address (Account@Domain or @callsign)</summary>
        public virtual string AccountAddress { get; }

        ///<summary>The account portion of <see cref="AccountAddress"/></summary>
        public virtual string Account { get; }

        ///<summary>The domain portion of <see cref="AccountAddress"/></summary>
        public virtual string Domain { get; }

        protected JpcCredential() {
            }

        public JpcCredential(string accountAddress) {
            AccountAddress = accountAddress;

            accountAddress.SplitAccountIDService(out var account, out var domain);
            Account = account;
            Domain = domain;
            }

        }

    }

