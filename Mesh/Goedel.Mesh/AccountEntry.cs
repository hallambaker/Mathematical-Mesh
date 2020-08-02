using Goedel.Cryptography.Dare;
using Goedel.Utilities;

namespace Goedel.Mesh {
    public partial class AccountEntry {

        ///<summary>Cached convenience accessor. Returns the corresponding 
        ///<see cref="ProfileAccount"/> .</summary>
        public ProfileUser ProfileAccount => profileAccount ??
            ProfileUser.Decode(EnvelopedProfileAccount).CacheValue(out profileAccount);
        ProfileUser profileAccount = null;

        ///<summary>Cached convenience accessor. Returns the corresponding 
        ///<see cref="ConnectionAccount"/> .</summary>
        public ConnectionUser ConnectionAccount => connectionAccount ??
            ConnectionUser.Decode(EnvelopedConnectionAccount).CacheValue(out connectionAccount);
        ConnectionUser connectionAccount = null;


        ///<summary>Cached convenience accessor. Returns the corresponding 
        ///<see cref="GetActivationAccount"/> .</summary>
        public ActivationUser GetActivationAccount(IKeyCollection keyCollection) =>
            activationAccount ?? (keyCollection == null ? null :
            ActivationUser.Decode(EnvelopedActivationAccount, keyCollection).CacheValue(out activationAccount));
        ActivationUser activationAccount;

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
