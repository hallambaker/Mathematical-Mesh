using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;

using System;
using System.Collections.Generic;
using System.IO;

namespace Goedel.Mesh {
    public partial class MessageClaim {

        ///<summary>Base constructor used for deserialization.</summary>
        public MessageClaim() { }


        /// <summary>
        /// Construct a MessageClaim instance making a claim by <paramref name="claimaintAccount"/>
        /// for <paramref name="targetAccount"/> using the value <paramref name="pin"/> for
        /// authentication.
        /// </summary>
        /// <param name="targetAccount">The account to which the claim is directed.</param>
        /// <param name="claimaintAccount">The account making the claim.</param>
        /// <param name="pin">Authentication code.</param>
        public MessageClaim(
                string targetAccount,
                string claimaintAccount,
                string pin) {
            Recipient = targetAccount;
            Sender = claimaintAccount;
            PublicationId = UDF.SymetricKeyId (pin);

            ServiceAuthenticate = CatalogedPublication.AuthenticateService(claimaintAccount, pin);
            DeviceAuthenticate = CatalogedPublication.AuthenticateDevice(claimaintAccount, pin);
            }

        }
    }
