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
//  

using System;
using System.Collections.Generic;

using Goedel.Utilities;


namespace Goedel.Utilities {
    public static partial class Extension {


        #region // Methods 

        /// <summary>
        /// Returns the canonicalized address form of <paramref name="address"/> as a
        /// string.
        /// </summary>
        /// <param name="address">The input, an account address.</param>
        /// <returns>The canonicalized form of <paramref name="address"/>.</returns>
        public static string CannonicalAccountAddress(this string address) => address.ToLower();

        /// <summary>
        /// Returns the canonicalized address form of <paramref name="address"/> as
        /// a UTF8 encoded byte sequence.
        /// </summary>
        /// <param name="address">The input, an account address.</param>
        /// <returns>The canonicalized form of <paramref name="address"/> as
        /// a UTF8 encoded byte sequence.</returns>
        public static byte[] CannonicalAccountAddressUtf8(this string address) => 
            address.CannonicalAccountAddress().ToUTF8();


        #endregion 
        }

    }
