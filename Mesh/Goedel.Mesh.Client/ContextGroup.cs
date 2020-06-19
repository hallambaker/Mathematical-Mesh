using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;

using System;
using System.Collections.Generic;
using System.IO;

namespace Goedel.Mesh.Client {

    /// <summary>
    /// Context binding for a Group account
    /// </summary>
    public class ContextGroup : ContextAccountEntry {

        ///<summary>The enclosing mesh context.</summary>
        public override ContextMesh ContextMesh => ContextAccount.ContextMesh;


        ///<summary>The enclosing mesh context.</summary>
        public ContextAccount ContextAccount;

        ///<summary>The catalogued group description.</summary>
        public CatalogedGroup CatalogedGroup;

        ///<summary>The group profile.</summary>
        public ProfileGroup ProfileGroup => CatalogedGroup.Profile;




        ///<summary>The directory containing the catalogs related to the account.</summary>
        public override string StoresDirectory => storesDirectory ??
            Path.Combine(MeshMachine.DirectoryMesh, ProfileGroup.UDF).CacheValue(out storesDirectory);
        string storesDirectory;


        /// <summary>
        /// Default constuctor, creates a group context for <paramref name="catalogedGroup"/>
        /// </summary>
        /// <param name="contextAccount">The enclosing account context.</param>
        /// <param name="catalogedGroup">Description of the group to return the
        /// context for.</param>
        public ContextGroup(ContextAccount contextAccount, CatalogedGroup catalogedGroup) {
            CatalogedGroup = catalogedGroup;
            ContextAccount = contextAccount;


            }

        /// <summary>
        /// Create a new group.
        /// </summary>
        /// <param name="contextAccount">The enclosing account context.</param>
        /// <param name="catalogedGroup">Description of the group to create.</param>
        /// <returns>The group context.</returns>
        public static ContextGroup CreateGroup(ContextAccount contextAccount, CatalogedGroup catalogedGroup) {
            var result = new ContextGroup(contextAccount, catalogedGroup);

            // Prepoulate the catalogs
            Directory.CreateDirectory(result.StoresDirectory);

            result.GetCatalogMember();
            result.GetCatalogCapability();

            return result;
            }


        ///<summary>Returns the network catalog for the account</summary>
        public CatalogMember GetCatalogMember() => GetStore(CatalogMember.Label) as CatalogMember;

        /// <summary>
        /// Create a new instance bound to the specified core within this account context.
        /// </summary>
        /// <param name="name">The name of the store to bind.</param>
        /// <returns>The store instance.</returns>
        protected override Store MakeStore(string name) => name switch
            {
                CatalogMember.Label => new CatalogMember(StoresDirectory, name, ContainerCryptoParameters, KeyCollection),
                _ => base.MakeStore(name),
                };



        #region Implement Group operations

        // ToDo: Implement Add member to group

        /// <summary>
        /// Add a member to the group.
        /// </summary>
        /// <param name="id">The member to add.</param>
        /// <returns>The member catalog entry.</returns>
        public CatalogedMember Add(string id) {

            // Bug: Should create an entry for the member

            // Pull the contact information from the user's contact catalog

            // Split the admin key

            // Create the capability and add to the capability catalog

            // Add the member to the member catalog


            // Create and send the invitation


            // return the member entry.



            throw new NotImplementedException();
            }

        // ToDo: Implement Locate member in group

        /// <summary>
        /// Locate the a member record in the group.
        /// </summary>
        /// <param name="id">The member to locate.</param>
        /// <returns>The member catalog entry.</returns>
        public CatalogedMember Locate(string id) {
            var catalogMember = GetCatalogMember();
            return catalogMember.Locate(id) as CatalogedMember;

            }

        // ToDo: Delete Add member from group

        /// <summary>
        /// Delete a member from the group
        /// </summary>
        /// <param name="memberAddress">The member to delete.</param>
        /// <returns>The member catalog entry.</returns>
        public void Delete(string memberAddress) {
            var member = Locate(memberAddress);
            Delete(member);
            }


        /// <summary>
        /// Delete a member from the group
        /// </summary>
        /// <param name="member">The member to delete.</param>
        /// <returns>The member catalog entry.</returns>
        public void Delete(CatalogedMember member) {
            var catalogMember = GetCatalogMember();

            // delete the capabilities of the member


            catalogMember.Delete(member);

            return;
            }


        #endregion
        }





    }
