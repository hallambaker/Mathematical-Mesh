using Goedel.Utilities;

namespace Goedel.Mesh {
    public partial class AccountEntry {

        public ProfileAccount ProfileAccount => profileAccount ??
            ProfileAccount.Decode(EnvelopedProfileAccount).CacheValue(out profileAccount);
        ProfileAccount profileAccount = null;

        public ConnectionAccount ConnectionAccount => connectionAccount ??
            ConnectionAccount.Decode(EnvelopedConnectionAccount).CacheValue(out connectionAccount);
        ConnectionAccount connectionAccount = null;

        public ActivationAccount ActivationAccount => activationAccount ??
            ActivationAccount.Decode(EnvelopedActivationAccount).CacheValue(out activationAccount);
        ActivationAccount activationAccount = null;


        }
    }
