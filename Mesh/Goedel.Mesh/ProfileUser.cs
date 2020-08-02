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


        ///<summary>The identifier of the default service.</summary>
        public string ServiceDefault => AccountAddresses?[0];

        /////<summary>The private encryption key generated from the secret seed.</summary>
        //public KeyPair PrivateEncryption;

        /////<summary>The private signature key generated from the secret seed.</summary>
        //public KeyPair PrivateOfflineSignature;

        /////<summary>The private authentication key generated from the secret seed.</summary>
        //public KeyPair PrivateAuthentication;

        //KeyPair keySignOffline;
        CryptoKey keySignOnline;

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
        /// <param name="keyCollection">The keyCollection to manage and persist the generated keys.</param>
        /// <param name="secretSeed">The secret seed value.</param>
        /// <param name="keyPairOnlineSignature">The intial online signature key.
        /// <paramref name="keyCollection"/>.</param>
        public ProfileUser(
                    IKeyCollection keyCollection,
                    PrivateKeyUDF secretSeed,
                    KeyPair keyPairOnlineSignature) {
            //Console.WriteLine($"Created seed {secretSeed.PrivateValue}");

            // Generate the private keys
            var PrivateOfflineSignature = secretSeed.BasePrivate(
                MeshKeyType.UserSign, keyCollection, KeySecurity.Storable);
            var PrivateEncryption = secretSeed.BasePrivate(
                MeshKeyType.UserEncrypt, keyCollection, KeySecurity.Storable);
            var PrivateAuthentication = secretSeed.BasePrivate(
                MeshKeyType.UserAuthenticate, keyCollection, KeySecurity.Storable);

            //Set the public key parameters
            KeyOfflineSignature = new KeyData(PrivateOfflineSignature.KeyPairPublic());
            KeyEncryption = new KeyData(PrivateEncryption.KeyPairPublic());
            KeyAuthentication = new KeyData(PrivateAuthentication.KeyPairPublic());

            KeysOnlineSignature = new List<KeyData> {
                new KeyData(keyPairOnlineSignature.KeyPairPublic())
                };

            Sign(PrivateOfflineSignature);
            }

        ///// <summary>
        ///// Connect the device described by <paramref name="catalogedDevice"/> with 
        ///// the set of permissions <paramref name="permissions"/>> to the account
        ///// described by this profile using the account administration key acquired from
        ///// <paramref name="catalogedDevice"/>.
        ///// </summary>
        ///// <param name="keyCollection">Key collection from which to fetch the key to sign
        ///// the corresponding Activation and Connection.</param>
        ///// <param name="catalogedDevice">The device to connect. The catalog entry will
        ///// be updated to reflect the connection to the account.</param>
        ///// <param name="permissions">The set of permissions to grant to the device
        ///// within the account.</param>
        ///// <param name="accountEncryptionKey">Key or key share used to decrypt the
        ///// data encrypted to the account key.</param>
        ///// <returns>The account description.</returns>
        //public AccountEntry ConnectDevice(
        //                IKeyCollection keyCollection,
        //                CatalogedDevice catalogedDevice,
        //                KeyData accountEncryptionKey,
        //                List<Permission> permissions
        //                ) {

        //    permissions.Future(); // Mark permissions as required parameter for future use.

        //    // Get an online signature key if not already found
        //    keySignOnline ??= keyCollection.LocatePrivate(KeysOnlineSignature);

        //    // Grant the device access to data encrypted under the account key.
        //    // Note that this cannot be granted through the capabilities catalog because that
        //    // is also encrypted under the account key.
        //    var activationAccount = new ActivationUser(catalogedDevice.ProfileDevice) {
        //        KeyAccountEncryption = accountEncryptionKey 
        //        };

        //    // Sign and encrypt the activation
        //    activationAccount.Package(keySignOnline);

        //    // Encrypt to the device
        //    var accountEntry = new AccountEntry() {
        //        AccountUDF = UDF,
        //        EnvelopedProfileAccount = DareEnvelope,
        //        EnvelopedConnectionAccount = activationAccount.ConnectionAccount.DareEnvelope,
        //        EnvelopedActivationAccount = activationAccount.DareEnvelope
        //        };

        //    //catalogedDevice.Accounts ??= new List<AccountEntry>();
        //    //catalogedDevice.Accounts.Add(accountEntry);

        //    return accountEntry;
        //    }

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
            builder.AppendIndent(indent, $"KeyOfflineSignature: {KeyOfflineSignature.UDF} ");
            if (KeysOnlineSignature != null) {
                foreach (var online in KeysOnlineSignature) {
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
            builder.AppendIndent(indent, $"KeyEncryption:       {KeyEncryption.UDF} ");

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



    public partial class ActivationUser {

        ///<summary>The UDF profile constant used for key derrivation 
        ///<see cref="Constants.UDFActivationAccount"/></summary>
        public override string UDFKeyDerrivation => Constants.UDFActivationAccount;

        ///<summary>The connection value.</summary>
        public override Connection Connection => ConnectionUser;

        ///<summary>The <see cref="ConnectionUser"/> instance binding the activated device
        ///to a MeshProfile.</summary>
        public ConnectionUser ConnectionUser { get; set; }

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public ActivationUser() {
            }

        /// <summary>
        /// Construct a new <see cref="ActivationUser"/> instance for the profile
        /// <paramref name="profileDevice"/>. The property <see cref="Activation.ActivationKey"/> is
        /// calculated from the values specified for the activation type.
        /// If the value <paramref name="masterSecret"/> is
        /// specified, it is used as the seed value. Otherwise, a seed value of
        /// length <paramref name="bits"/> is generated.
        /// The public key value is calculated for the public key pairs and the corresponding
        /// <see cref="ConnectionUser"/> generated for the public values.
        /// </summary>
        /// <param name="profileDevice">The base profile that the activation activates.</param>
        /// <param name="masterSecret">If not null, specifies the seed value. Otherwise,
        /// a seed value of <paramref name="bits"/> length is generated.</param>
        /// <param name="bits">The size of the seed to be generated if <paramref name="masterSecret"/>
        /// is null.</param>
        public ActivationUser(
                    ProfileDevice profileDevice,
                    byte[] masterSecret = null,
                    int bits = 256) : base(
                        profileDevice, UdfAlgorithmIdentifier.MeshActivationUser, masterSecret, bits) {
            ProfileDevice = profileDevice;

            AccountUDF = profileDevice.UDF;

            var keyEncryption = profileDevice.KeyEncryption.ActivatePublic(ActivationKey,
                    MeshKeyType | MeshKeyType.Encrypt);
            var keyAuthentication = profileDevice.KeyAuthentication.ActivatePublic(ActivationKey,
                    MeshKeyType | MeshKeyType.Authenticate);


            // Create the (unsigned) ConnectionDevice
            ConnectionUser = new ConnectionUser() {
                KeyEncryption = new KeyData(keyEncryption.KeyPairPublic()),
                KeySignature = new KeyData(KeySignature.KeyPairPublic()),
                KeyAuthentication = new KeyData(keyAuthentication.KeyPairPublic())
                };
            }




        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="ActivationUser"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        /// <returns>The decoded profile.</returns>
        public static new ActivationUser Decode(DareEnvelope envelope,
                    IKeyLocate keyCollection = null) =>
                        MeshItem.Decode(envelope, keyCollection) as ActivationUser;


        /// <summary>
        /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
        /// a leading indent of <paramref name="indent"/> units. The key collection 
        /// <paramref name="keyCollection"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="keyCollection">The Key collection.</param>
        public override void ToBuilder(StringBuilder builder, int indent = 0, IKeyCollection keyCollection = null) {

            builder.AppendIndent(indent, $"Activation Account");
            indent++;
            DareEnvelope.Report(builder, indent);
            indent++;

            builder.AppendIndent(indent, $"Activation Key:   {ActivationKey} ");
            builder.AppendIndent(indent, $"KeySignature:     {KeySignature} ");
            }
        }


    public partial class ConnectionUser {

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public ConnectionUser() {
            }


        /// <summary>
        /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
        /// a leading indent of <paramref name="indent"/> units. The cryptographic context from
        /// the key collection <paramref name="keyCollection"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="keyCollection">The key collection to use to obtain decryption keys.</param>
        public override void ToBuilder(StringBuilder builder, int indent = 0, IKeyCollection keyCollection = null) {

            builder.AppendIndent(indent, $"Connection User");
            indent++;
            DareEnvelope.Report(builder, indent);
            indent++;
            //builder.AppendIndent(indent, $"KeyOfflineSignature: {KeyOfflineSignature.UDF} ");

            //if (KeysOnlineSignature != null) {
            //    foreach (var online in KeysOnlineSignature) {
            //        builder.AppendIndent(indent, $"   KeysOnlineSignature: {online.UDF} ");
            //        }
            //    }
            builder.AppendIndent(indent, $"KeyEncryption:       {KeyEncryption.UDF} ");
            builder.AppendIndent(indent, $"KeyAuthentication:   {KeyAuthentication.UDF} ");

            }

        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="ConnectionUser"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        /// <returns>The decoded profile.</returns>
        public static new ConnectionUser Decode(DareEnvelope envelope,
                    IKeyLocate keyCollection = null) =>
                        MeshItem.Decode(envelope, keyCollection) as ConnectionUser;


        }

    }
