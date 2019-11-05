using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System;
using System.Collections.Generic;

namespace Goedel.Mesh.Client {

    public class ContextGroup : Disposable, IKeyLocate, IDare {

        public CatalogedGroup CatalogedGroup;



        public ContextGroup(CatalogedGroup catalogedGroup) {
            CatalogedGroup = catalogedGroup;
            }



        #region Implement IKeyLocate
        public KeyPair GetByAccountEncrypt(string keyID) => throw new NotImplementedException();
        public KeyPair GetByAccountSign(string keyID) => throw new NotImplementedException();
        public KeyPair LocatePrivate(string UDF) => throw new NotImplementedException();
        public KeyPair TryMatchRecipient(string keyID) => throw new NotImplementedException();
        #endregion

        #region Implement IDare
        public DareEnvelope DareEncode(byte[] plaintext, ContentMeta contentMeta = null, byte[] cloaked = null, List<byte[]> dataSequences = null, List<string> recipients = null, bool sign = false) => throw new NotImplementedException();
        public byte[] DareDecode(DareEnvelope envelope, bool verify = false) => throw new NotImplementedException();

        #endregion

        #region Implement Group operations

        public CatalogedMember Add(string id) => throw new NotImplementedException();

        public CatalogedMember Locate(string id) => throw new NotImplementedException();


        public CatalogedMember Delete(CatalogedMember id) => throw new NotImplementedException();

        #endregion
        }





    }
