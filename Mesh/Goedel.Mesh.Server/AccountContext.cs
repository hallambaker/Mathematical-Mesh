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

using Goedel.Protocol;
using Goedel.Protocol.Presentation;
using Goedel.Utilities;
namespace Goedel.Mesh.Server {
    /// <summary>
    /// Wrapper for the AccountEntry permitting the context in which the account entry
    /// is used to be cached and shared between operations.
    /// </summary>
    public class AccountContext : Disposable {

        #region // Public and private properties

        ///<summary>Timestamp of context creation.</summary> 
        public DateTime Created { get; }

        ///<summary>Timestamp of context last accessed</summary> 
        public DateTime Accessed { get; private set; }

        ///<summary>The account entry from the host store.</summary> 
        public AccountEntry AccountEntry { get; init; }

        ///<summary>The directory in which all the account data is stored.</summary> 
        public string Directory => AccountEntry.Directory;

        public AccessCapability AccessCapability => CatalogedAccess?.Capability as AccessCapability;


        public CatalogedAccess CatalogedAccess { get; set; }


        #endregion
        #region // Dispose

        protected override void Disposing() {
            if (catalogAccess != null) {
                Screen.WriteLine($"Dispose {catalogAccess}");
                }
            catalogAccess?.Dispose();
            Screen.WriteLine($"Dispose Done!");
            }

        #endregion
        #region // Constructors
        /// <summary>
        /// Return a new instance.
        /// </summary>
        public AccountContext() => Created = Accessed = DateTime.Now;

        #endregion
        #region // Methods

        /// <summary>
        /// Return the publication catalog. This is a catalog that the service MUST have
        /// read access to. Not clear that the clients need access though.
        /// </summary>
        /// <returns></returns>
        public CatalogAccess GetCatalogCapability() => catalogAccess ??
            new CatalogAccess(Directory).CacheValue(out catalogAccess);
        //public CatalogAccess CatalogAccess { get => catalogAccess; set => value = catalogAccess; }
        CatalogAccess catalogAccess;


        /// <summary>
        /// Called just before a caller unlocks the file, Updates the 
        /// last access timestamp to allow intelligent cache management.
        /// </summary>
        public void Close() {
            Accessed = DateTime.Now;
            }

        /// <summary>
        /// Verify that the request <paramref name="session"/> has the 
        /// privileges <paramref name="accountPrivilege"/>.
        /// </summary>
        /// <param name="session">The request session.</param>
        /// <param name="accountPrivilege">The privileges required to perform the operation.</param>
        /// <returns>True if all the privileges are granted, otherwise false.</returns>
        public bool Authenticate(
                    IJpcSession session, 
                    AccountPrivilege accountPrivilege) {
            switch (session.Credential) {
                case MeshCredentialPublic meshCredential: {
                    return Authenticate(meshCredential, accountPrivilege);
                    }
                case KeyCredentialPublic keyCredentialPublic: {
                    return Authenticate(keyCredentialPublic, accountPrivilege);
                    }

                }
            return false;
            }

        bool Authenticate(
                    KeyCredentialPublic credential,
                    AccountPrivilege accountPrivilege) {

            var profileAccount = (AccountEntry as AccountUser).GetProfileAccount();

            // To operate under the account authentication key, the request must be
            // authenticated under the AccountAuthenticationKey

            switch (accountPrivilege) {
                case AccountPrivilege.Post:
                case AccountPrivilege.Device: {
                    break;
                    }
                default: {
                    (profileAccount.AccountAuthenticationKey.MatchKeyIdentifier(
                            credential.AuthenticationKeyId)).AssertTrue(NotAuthorized.Throw);
                    break;
                    }
                }




            return true;
            }

        bool Authenticate(
            MeshCredentialPublic credential,
            AccountPrivilege accountPrivilege) {

            var profileAccount = (AccountEntry as AccountUser).GetProfileAccount();

            var catalogCapability = GetCatalogCapability();

            CatalogedAccess = catalogCapability.Locate(credential.AuthenticationKeyId);

            switch (accountPrivilege) {
                case AccountPrivilege.Post:
                case AccountPrivilege.Device: {
                    break;
                    }
                default: {
                    (AccessCapability?.Active == true).AssertTrue(NotAuthorized.Throw);
                    break;
                    }
                }

            return true;
            }

        #endregion
        }
    }
