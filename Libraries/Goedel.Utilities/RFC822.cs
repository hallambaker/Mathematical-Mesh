using System;
using System.Collections.Generic;
using Goedel.Utilities;


namespace Goedel.Utilities {


    public static partial class Extension {

        /// <summary>
        /// Extract the Account and Portal components from the specified AccountID.
        /// </summary>
        /// <param name="AccountID">The AccountID to split.</param>
        /// <param name="Service">The portal address.</param>
        /// <param name="Account">The account name.</param>
        public static void SplitAccountID (this string AccountID,
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
        public static void SplitAccountIDService (this string Identifier,
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
