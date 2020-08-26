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

        ///<summary>Typed enveloped data</summary> 
        public Enveloped<MessageClaim> EnvelopedMessageClaim =>
            envelopedProfileUser ?? new Enveloped<MessageClaim>(DareEnvelope).
                    CacheValue(out envelopedProfileUser);
        Enveloped<MessageClaim> envelopedProfileUser;


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

        /// <summary>
        /// Verify the claim against a service and device authenticator.
        /// </summary>
        /// <param name="serviceAuthenticator">The service authentication key.</param>
        /// <param name="deviceAuthenticator">The device authentication key.</param>
        /// <param name="length">minimum match length.</param>
        /// <returns>True if the match succeeded, otherwise false.</returns>
        public bool Verify(
                string serviceAuthenticator,
                string deviceAuthenticator,
                int length = 100) {
            return CatalogedPublication.Verify(Sender, deviceAuthenticator, DeviceAuthenticate, length) &&
                CatalogedPublication.Verify(Sender, serviceAuthenticator, ServiceAuthenticate, length);
            // Hack: should this raise an exception?


            }


        }
    }
