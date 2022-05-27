﻿//  Copyright © 2021 by Threshold Secrets Llc.
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;

namespace Goedel.Presence.Server; 
public class PresenceServer : PresenceService {
    #region // Properties

    #endregion
    #region // Constructors

    public PresenceServer() {
        }




    #endregion
    #region // Implement Inteface $$$
    #endregion
    #region // Override Methods
    #endregion
    #region // Methods


    ///<inheritdoc/>
    public override ConnectResponse Connect(ConnectRequest request, IJpcSession session) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public override QueryResponse Query(QueryRequest request, IJpcSession session) {
        throw new NotImplementedException();
        }
    #endregion
    }
