//   Copyright © 2015 by Comodo Group Inc.
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
//  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Mesh {

    /// <summary>
    /// A portal account object.
    /// </summary>
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
