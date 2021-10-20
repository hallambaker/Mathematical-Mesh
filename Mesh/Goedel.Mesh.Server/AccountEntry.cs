#region // Copyright - MIT License
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


using Goedel.Protocol;
using Goedel.Utilities;

namespace Goedel.Mesh.Server {
    public abstract partial class AccountEntry {

        ///<summary>The primary key</summary>
        public override string _PrimaryKey => AccountAddress;



        /// <summary>
        /// Default constructor for serialization.
        /// </summary>
        public AccountEntry() {
            }

        /// <summary>
        /// Verification function.
        /// </summary>
        /// <returns>True if the account entry is properly formatted.</returns>
        public abstract void Verify(MeshVerifiedAccount meshVerifiedAccount);

        }


    public partial class AccountUser {


        ///<summary>Cached convenience accessor for <see cref="profileAccount"/></summary>
        public ProfileAccount GetProfileAccount() =>
            profileAccount ?? EnvelopedProfileUser.Decode().CacheValue (out profileAccount);

        ProfileAccount profileAccount;

        //public ProfileUser ProfileUser => GetProfileAccount() as ProfileUser;

        ///<summary>Cached convenience accessor for <see cref="ProfileUser"/></summary>
        public ProfileUser ProfileUser => GetProfileAccount() as ProfileUser;


        ///<summary>Cached convenience accessor for <see cref="ProfileGroup"/></summary>
        public ProfileGroup ProfileGroup => GetProfileAccount() as ProfileGroup;


        /// <summary>
        /// Default constructor for serialization.
        /// </summary>
        public AccountUser() {
            }

        /// <summary>
        /// Constructor creating an Account entry from the request <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The account creation request.</param>
        public AccountUser(BindRequest request) {
            AccountAddress = request.AccountAddress;
            EnvelopedProfileUser = request.EnvelopedProfileAccount;
            Directory = AccountAddress;
            }


        ///<inheritdoc/>
        public override void Verify(MeshVerifiedAccount meshVerifiedAccount) {
            var profile = GetProfileAccount();

            switch (profile) {
                case ProfileUser profileUser: {
                    meshVerifiedAccount.Validate(profileUser);
                    break;
                    }
                case ProfileGroup profileGroup: {
                    meshVerifiedAccount.Validate(profileGroup);
                    break;
                    }
                }
            }
        }

    //public partial class AccountGroup {

    //    /// <summary>
    //    /// Default constructor for serialization.
    //    /// </summary>
    //    public AccountGroup() {
    //        }
    //    /// <summary>
    //    /// Constructor creating an Account entry from the request <paramref name="request"/>.
    //    /// </summary>
    //    /// <param name="request">The account creation request.</param>
    //    public AccountGroup(BindRequest request) {
    //        AccountAddress = request.AccountAddress;
    //        EnvelopedProfileGroup = request.EnvelopedProfileAccount;
    //        Directory = AccountAddress;
    //        }

    //    public override void Verify(MeshVerifiedAccount meshVerifiedAccount) => throw new NYI();

    //    }
    }
