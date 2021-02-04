﻿//  Copyright © 2021 Threshold Secrets Llc
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
using Goedel.Cryptography;
using Goedel.Protocol;

namespace Goedel.Mesh.Client {


    public class MeshCredential : JpcCredential {

        ProfileAccount ProfileAccount => CatalogedDevice.ProfileUser;

        IKeyLocate KeyLocate { get; }

        CatalogedDevice CatalogedDevice { get; }





        ConnectionDevice ConnectionDevice { get; }


        public MeshCredential() {
            }


        /// <summary>
        /// Create a credential for the device/profile <paramref name="catalogedDevice"/>.
        /// </summary>
        /// <param name="catalogedDevice">The device catalog entry.</param>
        /// <param name="keyLocate">The key locator to be used to obtain keys.</param>
        public MeshCredential(
                    CatalogedDevice catalogedDevice, 
                    IKeyLocate keyLocate) {
            CatalogedDevice = catalogedDevice;
            ConnectionDevice = CatalogedDevice.EnvelopedConnectionUser.Decode();

            KeyLocate = keyLocate;
            }

        // authenticate gubbins goes here...


        }
    }