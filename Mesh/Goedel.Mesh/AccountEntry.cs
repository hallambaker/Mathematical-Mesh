using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;
using Goedel.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Mesh {
    public partial class AccountEntry {

        public ProfileAccount ProfileAccount => profileAccount ??
            ProfileAccount.Decode(EnvelopedProfileAccount).CacheValue(out profileAccount);
        ProfileAccount profileAccount = null;

        public ConnectionAccount ConnectionAccount => connectionAccount ??
            ConnectionAccount.Decode(EnvelopedConnectionAccount).CacheValue(out connectionAccount);
        ConnectionAccount connectionAccount = null;



        public ActivationAccount GetActivationAccount(KeyCollection keyCollection) =>
            activationAccount ?? (keyCollection == null ? null :
            ActivationAccount.Decode(EnvelopedActivationAccount, keyCollection).CacheValue(out activationAccount));
        ActivationAccount activationAccount;

        public virtual bool Validate() {
            ProfileAccount.Validate();


            ProfileAccount.Verify(EnvelopedConnectionAccount);
            ProfileAccount.Verify(EnvelopedActivationAccount);

            return false;
            }


        }
    }
