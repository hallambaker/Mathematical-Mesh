using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Mesh {
    public partial class ProfileUser {

        ///<summary>The signed profile</summary> 
        public EnvelopedProfileUser EnvelopedProfileUser { get; protected set; }

        /// <summary>
        /// Sign the profile under <paramref name="SignatureKey"/>.
        /// </summary>
        /// <param name="SignatureKey">The signature key (MUST match the offline key).</param>
        /// <returns>Envelope containing the signed profile. Also updates the property
        /// <see cref="EnvelopedProfileUser"/></returns>
        public override DareEnvelope Sign(CryptoKey SignatureKey) {
            EnvelopedProfileUser = EnvelopedProfileUser.Encode(this, signingKey: SignatureKey);
            DareEnvelope = EnvelopedProfileUser;
            return DareEnvelope;
            }



        ///<summary>Cached convenience accessor. Returns the corresponding 
        ///<see cref="ProfileService"/> .</summary>
        public ProfileService ProfileService => profileService ??
            ProfileService.Decode(EnvelopedProfileService).CacheValue(out profileService);
        ProfileService profileService = null;

        /// <summary>
        /// Blank constructor for use by deserializers.
        /// </summary>
        public ProfileUser() {
            }

        /// <summary>
        /// Construct a new ProfileDevice instance from a <see cref="PrivateKeyUDF"/>
        /// seed.
        /// </summary>
        /// <param name="activationAccount">An activation account with full administrative privileges.</param>
        public ProfileUser(
                    ActivationAccount activationAccount) {

            var privateAccountOfflineSignature = activationAccount.PrivateAccountOfflineSignature;
            var privateAccountEncryption = activationAccount.PrivateAccountEncryption;
            var privateAccountAuthentication = activationAccount.PrivateAccountAuthentication;

            //Set the public key parameters
            OfflineSignature = new KeyData(privateAccountOfflineSignature.KeyPairPublic());
            AccountEncryption = new KeyData(privateAccountEncryption.KeyPairPublic());
            KeyAuthentication = new KeyData(privateAccountAuthentication.KeyPairPublic());

            //OnlineSignature = new List<KeyData> {
            //    new KeyData(activationAccount.PrivateAccountOnlineSignature.KeyPairPublic())
            //    };

            Sign(privateAccountOfflineSignature);
            }


        /// <summary>
        /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
        /// a leading indent of <paramref name="indent"/> units.The cryptographic context from
        /// the key collection <paramref name="keyCollection"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="keyCollection">The key collection to use to obtain decryption keys.</param>
        public override void ToBuilder(StringBuilder builder, int indent = 0, IKeyCollection keyCollection = null) {

            builder.AppendIndent(indent, $"Profile User");
            indent++;
            DareEnvelope.Report(builder, indent);
            indent++;
            builder.AppendIndent(indent, $"KeyOfflineSignature: {OfflineSignature.UDF} ");
            if (OnlineSignature != null) {
                foreach (var online in OnlineSignature) {
                    builder.AppendIndent(indent, $"KeysOnlineSignature: {online.UDF} ");
                    }
                }
            if (AccountAddresses != null) {
                foreach (var accountAddress in AccountAddresses) {
                    builder.AppendIndent(indent, $"AccountAddress : {accountAddress} ");
                    }
                }
            else {
                builder.AppendIndent(indent, $"AccountAddress : [None]");
                }
            builder.AppendIndent(indent, $"KeyEncryption:       {AccountEncryption.UDF} ");

            }

        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="ProfileService"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        /// <returns>The decoded profile.</returns>
        public static new ProfileUser Decode(DareEnvelope envelope,
                    IKeyLocate keyCollection = null) =>
                        MeshItem.Decode(envelope, keyCollection) as ProfileUser;



        /// <summary>
        /// Convenience routine reporting if the profile is serviced by the specified provider.
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public int MatchAccountAddress(string service) {
            int id = 0;

            foreach (var accountAddress in AccountAddresses) {

                if (service == accountAddress) {
                    return id;
                    }
                id++;
                }
            return -1;
            }


        }

    }
