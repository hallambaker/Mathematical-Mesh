//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Goedel.Debug {

//    /// <summary>
//    /// Define extension codes for checking HTTP/SMTP/FTP style status return values
//    /// </summary>
//    public static class Extensions {

//        /// <summary>
//        /// Extension method to report the success or failure of transaction.
//        /// Information return codes are integers in the range 100..199
//        /// </summary>
//        /// <param name="Status">Status code returned by transaction.</param>
//        /// <returns>true if and only iff the transaction succeeded.</returns>
//        public static bool StatusInformation(this int Status) {
//            return (Status >= 100) & (Status <= 199);
//            }

//        /// <summary>
//        /// Extension method to report the success or failure of transaction.
//        /// Success return codes are integers in the range 200..299
//        /// </summary>
//        /// <param name="Status">Status code returned by transaction.</param>
//        /// <returns>true if and only iff the transaction succeeded.</returns>
//        public static bool StatusSuccess(this int Status) {
//            return (Status >= 200) & (Status <= 299);
//            }

//        /// <summary>
//        /// Extension method to report the success or failure of transaction.
//        /// Success return codes are integers in the range 300..399
//        /// </summary>
//        /// <param name="Status">Status code returned by transaction.</param>
//        /// <returns>true if and only iff the transaction succeeded.</returns>
//        public static bool StatusIncomplete(this int Status) {
//            return (Status >= 300) & (Status <= 399);
//            }

//        /// <summary>
//        /// Extension method to report the success or failure of transaction.
//        /// Client Error return codes are integers in the range 400..499
//        /// </summary>
//        /// <param name="Status">Status code returned by transaction.</param>
//        /// <returns>true if and only iff the transaction succeeded.</returns>
//        public static bool StatusClientError(this int Status) {
//            return (Status >= 400) & (Status <= 499);
//            }

//        /// <summary>
//        /// Extension method to report the success or failure of transaction.
//        /// Server Error return codes are integers in the range 500..599
//        /// </summary>
//        /// <param name="Status">Status code returned by transaction.</param>
//        /// <returns>true if and only iff the transaction succeeded.</returns>
//        public static bool StatusServerError(this int Status) {
//            return (Status >= 500) & (Status <= 599);
//            }

//        }

//    }
