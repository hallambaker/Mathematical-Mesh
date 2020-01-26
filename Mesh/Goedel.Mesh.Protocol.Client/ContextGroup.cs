
using System;

namespace Goedel.Mesh.Client {

    /// <summary>
    /// Context binding for a Group account
    /// </summary>
    public class ContextGroup : ContextAccountEntry {

        public CatalogedGroup CatalogedGroup;



        public ContextGroup(CatalogedGroup catalogedGroup) => CatalogedGroup = catalogedGroup;




        #region Implement Group operations

        // ToDo: Implement Add member to group

        public CatalogedMember Add(string id) => throw new NotImplementedException();

        // ToDo: Implement Locate member in group

        public CatalogedMember Locate(string id) => throw new NotImplementedException();

        // ToDo: Delete Add member from group
        public CatalogedMember Delete(CatalogedMember id) => throw new NotImplementedException();

        #endregion
        }





    }
