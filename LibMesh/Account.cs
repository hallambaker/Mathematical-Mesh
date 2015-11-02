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




        public static string ID(string Account, string Portal) {
            return Account + "@" + Portal;
            }

        public static string PrimaryKey (string UniqueID) {
            return "Account-" + UniqueID;
            }


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
