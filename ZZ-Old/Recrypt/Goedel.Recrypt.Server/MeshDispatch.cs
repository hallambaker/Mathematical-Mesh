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
using Goedel.Debug;
using Goedel.Recrypt;

namespace Goedel.Recrypt.Server {

    /// <summary>
    /// The host class. Receives a stream from the HTTP server caller and 
    /// dispatches the specified server.
    /// </summary>
    public class PublicRecryptServiceProvider : RecryptServiceProvider {

        /// <summary>
        /// Initialize a Mesh Service Provider.
        /// </summary>
        /// <param name="Domain">The domain of the service provider.</param>
        /// <param name="PortalStore">The portal persistence store fielname.</param>
        public PublicRecryptServiceProvider(string Domain, string PortalStore) {
            // here we start the Portal store etc.
            }


        }


    /// <summary>
    /// The session class implements the Mesh session.
    /// </summary>
    public class PublicRecryptService : RecryptService {
        PublicRecryptServiceProvider Provider;



        /// <summary>
        /// The mesh service dispatcher.
        /// </summary>
        /// <param name="Host">The service provider.</param>
        /// <param name="Session">The authentication context.</param>
        public PublicRecryptService(PublicRecryptServiceProvider Host, JPCSession Session) {
            this.Provider = Host;
            Host.Interfaces.Add(this);
            Host.Service = this;
            //this.JPCSession = Session;
            }


        /// <summary>
		/// Respond with the 'hello' version and encoding info.
        /// </summary>		
        public override HelloResponse Hello(
                HelloRequest Request) {

            var HelloResponse = new HelloResponse();
            HelloResponse.Version = new Version();
            HelloResponse.Version.Major = 0;
            HelloResponse.Version.Minor = 7;
            HelloResponse.Version.Encodings = new List<Encoding>();

            var Encoding = new Encoding();
            Encoding.ID = new List<string> { "application/json" };
            HelloResponse.Version.Encodings.Add(Encoding);

            return HelloResponse;
            }


        }




    }
