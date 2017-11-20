using System;
using System.Collections.Generic;
using Goedel.Utilities;


namespace Goedel.Utilities {


    public static partial class Extension {

        /// <summary>
        /// Extract the Account and Portal components from the specified AccountID.
        /// </summary>
        /// <param name="AccountID">The AccountID to split.</param>
        /// <param name="Account">The account name.</param>
        /// <param name="Portal">The portal address.</param>
        public static void SplitAccountID (this string AccountID, out string Account, out string Portal) {
            Account = null;
            Portal = null;
            int At = AccountID.LastIndexOf('@');
            if (At < 0) {
                return;
                }

            Account = AccountID.Substring(0, At);
            Portal = AccountID.Substring(At + 1);
            }


        }

    }
