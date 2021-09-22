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



using System;
using System.Collections.Generic;

using Goedel.Cryptography.Dare;
using Goedel.Protocol;
using Goedel.Protocol.Presentation;
using Goedel.Utilities;
namespace Goedel.Mesh.Server {

    [Flags]
    public enum AccountPrivilege {
        Unbind = 0b1,
        Connected = 0b10,
        Pending = 0b100,
        Device = 0b1000,
        Post = 0b10_000,
        Local = 0b10_0000
        }

    public class AccountContext {

        DateTime Created;
        DateTime Accessed;
        public AccountEntry AccountEntry { get; init; }

        public Dictionary <string, Store> DictionaryStores = new ();


        public AccountContext() {
            Created = Accessed = DateTime.Now;
            }

        Store GetStore() {
            throw new NYI();
            }

        /// <summary>
        /// Called just before a caller unlocks the file, Updates the 
        /// last access timestamp to allow intelligent cache management.
        /// </summary>
        public void Close() {
            Accessed = DateTime.Now;
            }


        public bool Authenticate(
                    IJpcSession session, 
                    AccountPrivilege accountPrivilege) {
            switch (session.Credential) {
                case KeyCredentialPublic: {
                    break;
                    }
                }
            return false;
            }

        public bool Authenticate(
                    KeyCredentialPublic credential,
                    AccountPrivilege accountPrivilege) {


            return true;
            }

        }


    public class AccountHandleLocked : Disposable {



        public string Provider;


        public AccountPrivilege AccountPrivilege { get; init; }

        /// <summary>
        /// The account description. This is only accessible through the account handle.
        /// </summary>
        protected AccountContext AccountContext { get; }



        string Directory => AccountContext.AccountEntry.Directory;

        protected override void Disposing() {
            AccountContext.Close();
            System.Threading.Monitor.Exit(AccountContext);
            }



        public AccountHandleLocked(IJpcSession session, AccountContext accountContext) {
            accountContext = AccountContext;
            }




        /// <summary>
        /// Post a message to the spool associated with the account. This is the only operation
        /// that is supported for a device that is not connected to the account profile.
        /// </summary>
        /// <param name="dareMessage">The message to post.</param>
        public void PostInbound(DareEnvelope dareMessage) {
            AccountPrivilege.HasFlag(AccountPrivilege.Post).AssertTrue(NotAuthorized.Throw);

            using var container = new Spool(Directory, SpoolInbound.Label);
            container.Add(dareMessage);

            }

        /// <summary>
        /// Post a message to the spool associated with the account. This is the only operation
        /// that is supported for a device that is not connected to the account profile.
        /// </summary>
        /// <param name="envelope">The message to post.</param>
        public void PostLocal(DareEnvelope envelope) {
            AccountPrivilege.HasFlag(AccountPrivilege.Local).AssertTrue(NotAuthorized.Throw);

            using var container = new Spool(Directory, SpoolLocal.Label);
            container.Add(envelope);

            }

        /// <summary>
        /// Append the envelopes <paramref name="envelopes"/> to the store named
        /// <paramref name="label"/>.
        /// </summary>
        /// <param name="label">The store to add the envelopes to.</param>
        /// <param name="envelopes">The envelopes to append.</param>
        public void StoreAppend(string label, List<DareEnvelope> envelopes) {
            AccountPrivilege.HasFlag(AccountPrivilege.Connected).AssertTrue(NotAuthorized.Throw);
            Store.Append(Directory, null, envelopes, label);
            }
        }
    }
