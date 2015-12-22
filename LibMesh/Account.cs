//Sample license text.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Mesh {
    public partial class Account {

        /// <summary>
        /// Return the unique ID for the account.
        /// </summary>
        public virtual string UniqueID {
            get { return AccountID; }
            }



        /// <summary>
        /// Construct an account identifier from an account name and
        /// a portal name.
        /// </summary>
        /// <param name="Account">The account name.</param>
        /// <param name="Portal">The dns address of the portal.</param>
        /// <returns>The account identifier - Account@Portal.</returns>
        public static string ID(string Account, string Portal) {
            return Account + "@" + Portal;
            }

        /// <summary>
        /// Construct a Primary Key from the specified Unique ID.
        /// </summary>
        /// <param name="UniqueID">The AccountID</param>
        /// <returns>The Primary Key Value.</returns>
        public static string PrimaryKey (string UniqueID) {
            return "Account$" + UniqueID;
            }


        /// <summary>
        /// Extract the Account and Portal components from the specified AccountID.
        /// </summary>
        /// <param name="AccountID">The AccountID to split.</param>
        /// <param name="Account">The account name.</param>
        /// <param name="Portal">The portal address.</param>
        public static void SplitAccountID(string AccountID, out string Account, out string Portal) {
            Account = null;
            Portal = null;
            int At = AccountID.LastIndexOf('@');
            if (At < 0) return;

            Account = AccountID.Substring(0, At);
            Portal = AccountID.Substring(At + 1);
            }

        }
    }
