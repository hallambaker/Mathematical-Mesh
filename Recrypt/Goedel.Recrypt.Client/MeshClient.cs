//   Copyright © 2015 by Comodo Group Inc.
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

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;
using Goedel.Recrypt;

namespace Goedel.Recrypt.Client {


    /// <summary>
    /// High level Recrypt Client interface.
    /// </summary>
    public partial class RecryptClient {

        /// <summary>
        /// The Recrypt Service provider.
        /// </summary>
        protected RecryptService Service;

        /// <summary>
        /// The account Identifier.
        /// </summary>
        public string AccountID;

        /// <summary>
        /// The account name.
        /// </summary>
        public string AccountName;

        /// <summary>
        /// The portal address.
        /// </summary>
        public string Portal;

        /// <summary>
        /// Fingerprint of the Personal Profile.
        /// </summary>
        public string UDF;

        /// <summary>
        /// True if the client is connected to an active MeshService.
        /// </summary>
        public bool Connected { get { return Service != null; } }



        /// <summary>
        /// Connect up to a specified Mesh Portal and account.
        /// </summary>
        /// <param name="Portal">The portal to connect to.</param>
        /// <param name="AccountID">The account identifier.</param>
        public RecryptClient(string Portal, string AccountID) {
            Service = RecryptPortal.Default.GetService(Portal, AccountID);
            this.AccountID = AccountID;
            }


        /// <summary>
        /// Connect up to the specified Mesh Portal
        /// </summary>
        public RecryptClient(string Portal) {
            this.Portal = Portal;
            Service = RecryptPortal.Default.GetService(Portal);
            }


        /// <summary>
        /// Get the available services and features
        /// </summary>
        /// <returns></returns>
        public HelloResponse Hello () {
            var Request = new HelloRequest();
            var Response = Service.Hello(Request);
            return Response;
            }

        }

    }
