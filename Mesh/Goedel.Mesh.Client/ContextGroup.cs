using Goedel.Utilities;
using System;

namespace Goedel.Mesh.Client {

    /// <summary>
    /// Context binding for a Group account
    /// </summary>
    public class ContextGroup : ContextAccountEntry {

        ///<summary>The catalogued group description.</summary>
        public CatalogedGroup CatalogedGroup;


        /// <summary>
        /// Default constuctor, creates a group context for <paramref name="catalogedGroup"/>
        /// </summary>
        /// <param name="catalogedGroup">Description of the group to return the
        /// context for.</param>
        public ContextGroup(CatalogedGroup catalogedGroup) {
            CatalogedGroup = catalogedGroup;

            throw new NYI();
            }




        #region Implement Group operations

        // ToDo: Implement Add member to group

        /// <summary>
        /// Add a member to the group.
        /// </summary>
        /// <param name="id">The member to add.</param>
        /// <returns>The member catalog entry.</returns>
        public CatalogedMember Add(string id) => throw new NotImplementedException();

        // ToDo: Implement Locate member in group

        /// <summary>
        /// Locate the a member record in the group.
        /// </summary>
        /// <param name="id">The member to locate.</param>
        /// <returns>The member catalog entry.</returns>
        public CatalogedMember Locate(string id) => throw new NotImplementedException();

        // ToDo: Delete Add member from group

        /// <summary>
        /// Delete a member from the group
        /// </summary>
        /// <param name="id">The member to delete.</param>
        /// <returns>The member catalog entry.</returns>
        public CatalogedMember Delete(CatalogedMember id) => throw new NotImplementedException();

        #endregion
        }





    }
