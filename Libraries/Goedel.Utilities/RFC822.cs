
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
        /// Returns the string <paramref name="accountID"/> if it is a well formed account identifier
        /// and null otherwise.
        /// </summary>
        /// <param name="accountID">The string to test.</param>
        /// <returns><paramref name="accountID"/> if it is a well formed account identifier
        /// and null otherwise.</returns>
        public static string IsAccountID(this string accountID) {
            if (accountID == null) {
                return null;
                }
            return accountID.LastIndexOf('@') < 0 ? null : accountID;
            }


        /// <summary>
        /// Extract the Account and Portal components from the specified AccountID.
        /// </summary>
        /// <param name="AccountID">The AccountID to split.</param>
        /// <param name="Service">The portal address.</param>
        /// <param name="Account">The account name.</param>
        public static void SplitAccountID(this string AccountID,
            out string Service,
            out string Account) {
            Account = null;
            Service = null;
            int At = AccountID.LastIndexOf('@');
            if (At < 0) {
                return;
                }

            Account = AccountID.Substring(0, At);
            Service = AccountID.Substring(At + 1);
            }

        /// <summary>
        /// Parse a string that may contain an account identifier to extract the service and 
        /// account components.
        /// </summary>
        /// <param name="Identifier">The AccountID to split.</param>
        /// <param name="Service">The portal address.</param>
        /// <param name="Account">The account name.</param>
        public static void SplitAccountIDService(this string Identifier,
            out string Service,
            out string Account) {
            Account = null;

            int At = Identifier.LastIndexOf('@');
            if (At < 0) {
                Service = Identifier;
                return;
                }

            Account = Identifier.Substring(0, At);
            Service = Identifier.Substring(At + 1);
            }
        }

    }
