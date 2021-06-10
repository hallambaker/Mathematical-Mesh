
/* Unmerged change from project 'Goedel.Utilities'
Before:
using System;
using System.Collections.Generic;
using Goedel.Utilities;
After:
using Goedel.Utilities;

using System;
using System.Collections.Generic;
*/
namespace Goedel.Utilities {


    public static partial class Extension {

        /// <summary>
        /// If the input string contains the separator, return the string leading up 
        /// to the separator. Otherwise return null.
        /// </summary>
        /// <param name="Input">The string to split.</param>
        /// <param name="Separator">The separator character</param>
        /// <returns>If the separator is found, returns the input string up to but not 
        /// including the separator, otherwise null.</returns>
        public static string Left(this string Input, char Separator) {
            var Index = Input.IndexOf(Separator);
            return Index < 0 ? null : Input.Substring(0, Index);
            }

        /// <summary>
        /// If the input string contains the separator, return the string leading up 
        /// to the separator. Otherwise return null.
        /// </summary>
        /// <param name="Input">The string to split.</param>
        /// <param name="Separator">The separator character</param>
        /// <returns>If the separator is found, returns the input string up to but not 
        /// including the separator, otherwise null.</returns>
        public static string Right(this string Input, char Separator) {
            var Index = Input.IndexOf(Separator);
            return Index < 0 ? null : Input.Substring(Index + 1);
            }


        /// <summary>
        /// If the input string contains the separator, return the string leading up 
        /// to the separator. Otherwise return null.
        /// </summary>
        /// <param name="Input">The string to split.</param>
        /// <param name="Separator">The separator character</param>
        /// <param name="Right">The string to the right of the separator</param>
        /// <param name="Left">The string to the left of the separator</param>
        /// <returns>If the separator is found, returns the input string up to but not 
        /// including the separator, otherwise null.</returns>
        public static void Separate(this string Input, char Separator,
            out string Left, out string Right) {
            var Index = Input.IndexOf(Separator);
            Left = Index < 0 ? null : Input.Substring(0, Index);
            Right = Index < 0 ? null : Input.Substring(Index + 1);
            }

        /// <summary>
        /// Returns true if <paramref name="accountID"/> is a reasonably well formed account
        /// address, other
        /// </summary>
        /// <param name="accountID">The string to test.</param>
        /// <returns><paramref name="accountID"/> if it is a well formed account identifier
        /// and null otherwise.</returns>
        public static bool IsAccountID(this string accountID) {
            if (accountID == null || accountID.Length < 3) {
                return false;
                }
            return true; // Hack: need to do this properly.
            }


        /// <summary>
        /// Parse a string that may contain an account identifier to extract the service and 
        /// account components.
        /// </summary>
        /// <param name="identifier">The AccountID to split.</param>
        /// <param name="service">The portal address.</param>
        /// <param name="account">The account name.</param>
        public static void SplitAccountIDService(this string identifier,
                out string service,
                out string account) {
            account = null;
            service = null;
            if (identifier == null) {
                return;
                }

            var at = identifier.LastIndexOf('@');
            if (at < 0) {
                service = identifier;
                return;
                }

            account = identifier.Substring(0, at);
            service = identifier.Substring(at + 1);
            }


        /// <summary>
        /// Parse a string that may contain an account identifier to extract the service and 
        /// account components.
        /// </summary>
        /// <param name="identifier">The AccountID to split.</param>
        public static string GetService(this string identifier) {

            int At = identifier.LastIndexOf('@');
            if (At < 0) {
                return identifier;
                }


            return identifier.Substring(At + 1);
            }

        }

    }
