using Goedel.Cryptography.Dare;
using Goedel.Utilities;

namespace Goedel.Mesh {
    public partial class AccountEntry {

        ///<summary>Cached convenience accessor. Returns the corresponding 
        ///<see cref="ProfileAccount"/> .</summary>
        public ProfileAccount ProfileAccount => profileAccount ??
            ProfileAccount.Decode(EnvelopedProfileAccount).CacheValue(out profileAccount);
        ProfileAccount profileAccount = null;

        ///<summary>Cached convenience accessor. Returns the corresponding 
        ///<see cref="ConnectionAccount"/> .</summary>
        public ConnectionAccount ConnectionAccount => connectionAccount ??
            ConnectionAccount.Decode(EnvelopedConnectionAccount).CacheValue(out connectionAccount);
        ConnectionAccount connectionAccount = null;


        ///<summary>Cached convenience accessor. Returns the corresponding 
        ///<see cref="GetActivationAccount"/> .</summary>
        public ActivationAccount GetActivationAccount(IKeyCollection keyCollection) =>
            activationAccount ?? (keyCollection == null ? null :
            ActivationAccount.Decode(EnvelopedActivationAccount, keyCollection).CacheValue(out activationAccount));
        ActivationAccount activationAccount;

        /// <summary>
        /// Verify the AccountEntry contains all the required fields and their contents 
        /// are valid in the context of the corresponding <see cref="ProfileMesh"/> and
        /// <see cref="ProfileAccount"/>.
        /// </summary>
        /// <returns><see langword="true"/> if the validation succeeds, otherwise 
        /// <see langword="false"/></returns>
        public virtual bool Validate() {
            ProfileAccount.Validate();


            ProfileAccount.Verify(EnvelopedConnectionAccount);
            ProfileAccount.Verify(EnvelopedActivationAccount);

            return false;
            }


        }
    }
