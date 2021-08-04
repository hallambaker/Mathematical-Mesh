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
namespace Goedel.Protocol {

    /// <summary>
    /// Define extension codes for checking HTTP/SMTP/FTP style status return values
    /// </summary>
    public static partial class Extensions {

        /// <summary>
        /// Extension method to report the success or failure of transaction.
        /// Information return codes are integers in the range 100..199
        /// </summary>
        /// <param name="Status">Status code returned by transaction.</param>
        /// <returns>true if and only iff the transaction succeeded.</returns>
        public static bool StatusInformation(this int Status) => (Status >= 100) & (Status <= 199);

        /// <summary>
        /// Extension method to report the success or failure of transaction.
        /// Success return codes are integers in the range 200..299
        /// </summary>
        /// <param name="Status">Status code returned by transaction.</param>
        /// <returns>true if and only iff the transaction succeeded.</returns>
        public static bool StatusSuccess(this int Status) => (Status >= 200) & (Status <= 299);

        /// <summary>
        /// Extension method to report the success or failure of transaction.
        /// Success return codes are integers in the range 300..399
        /// </summary>
        /// <param name="Status">Status code returned by transaction.</param>
        /// <returns>true if and only iff the transaction succeeded.</returns>
        public static bool StatusIncomplete(this int Status) => (Status >= 300) & (Status <= 399);

        /// <summary>
        /// Extension method to report the success or failure of transaction.
        /// Client Error return codes are integers in the range 400..499
        /// </summary>
        /// <param name="Status">Status code returned by transaction.</param>
        /// <returns>true if and only iff the transaction succeeded.</returns>
        public static bool StatusClientError(this int Status) => (Status >= 400) & (Status <= 499);

        /// <summary>
        /// Extension method to report the success or failure of transaction.
        /// Server Error return codes are integers in the range 500..599
        /// </summary>
        /// <param name="Status">Status code returned by transaction.</param>
        /// <returns>true if and only iff the transaction succeeded.</returns>
        public static bool StatusServerError(this int Status) => (Status >= 500) & (Status <= 599);

        }

    }
