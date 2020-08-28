using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Mesh {

    public partial class ProfileAccount {
        ///<summary>Typed enveloped data</summary> 
        public Enveloped<ProfileAccount> EnvelopedProfileAccount =>
            envelopedProfileAccount ?? new Enveloped<ProfileAccount>(DareEnvelope).
                    CacheValue(out envelopedProfileAccount);
        Enveloped<ProfileAccount> envelopedProfileAccount;

        ///<summary>Cached convenience accessor. Returns the corresponding 
        ///<see cref="ProfileService"/>.</summary>
        public ProfileService ProfileService => EnvelopedProfileService.Decode(KeyCollection);
        }


    public partial class ProfileUser {

        ///<summary>Typed enveloped data</summary> 
        public Enveloped<ProfileUser> EnvelopedProfileUser =>
            envelopedProfileUser ?? new Enveloped<ProfileUser>(DareEnvelope).
                    CacheValue(out envelopedProfileUser);
        Enveloped<ProfileUser> envelopedProfileUser;




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

            var privateAccountOfflineSignature = activationAccount.PrivateProfileSignature;
            var privateAccountEncryption = activationAccount.PrivateAccountEncryption;
            var privateAccountAuthentication = activationAccount.PrivateAccountAuthentication;

            //Set the public key parameters
            OfflineSignature = new KeyData(privateAccountOfflineSignature.KeyPairPublic());
            AccountEncryption = new KeyData(privateAccountEncryption.KeyPairPublic());
            KeyAuthentication = new KeyData(privateAccountAuthentication.KeyPairPublic());

            //OnlineSignature = new List<KeyData> {
            //    new KeyData(activationAccount.PrivateAccountOnlineSignature.KeyPairPublic())
            //    };

            Envelope(privateAccountOfflineSignature);
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
