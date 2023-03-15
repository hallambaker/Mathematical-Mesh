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

using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

namespace Goedel.Callsign; 

public partial class Registration {
    #region // Properties



    #endregion
    #region // Constructors


    /// <summary>
    /// Default constructor, returns an empty instance.
    /// </summary>
    public Registration() {



        }

    /// <summary>
    /// Return a registration instance for the callsign <paramref name="callsign"/> with optional
    /// prior registration <paramref name="registration"/> and 
    /// </summary>
    /// <param name="callsign">The callsign binding.</param>
    /// <param name="registration">The prior registration for the canonical callsign
    /// value.</param>
    /// <param name="registrationReason">The registration reason. This is ignored if 
    /// <paramref name="registration"/> is null.</param>
    public Registration(
            CallsignBinding callsign, 
            Registration? registration=null, 
            RegistrationReason registrationReason= RegistrationReason.Update) {
        Id = Udf.Nonce();
        Entry = callsign.Enveloped as Enveloped<CallsignBinding>;
        Submitted = System.DateTime.Now;

        if (registration is null) {
            Reason = CallsignConstants.RegistrationReasonInitialTag;
            }
        else {
            Reason = registrationReason.ToLabel();
            PriorId = registration.Id;
            }

        // not currently dealling with the registrar slot.
        }

    #endregion


    #region // Methods



    #endregion


    }
