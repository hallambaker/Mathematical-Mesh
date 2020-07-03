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


        ///<summary>The identifier of the default service.</summary>
        public string ServiceDefault => AccountAddresses?[0];

        ///<summary>The secret seed value used to derrive profile parameters.</summary>
        public KeyPair KeyEncrypt;


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
        public ProfileAccount() {
            }


        /// <summary>
        /// Construct a new ProfileDevice instance from a <see cref="PrivateKeyUDF"/>
        /// seed.
        /// </summary>
        /// <param name="profileMesh">The mesh profile to which this account will belong.</param>
        /// <param name="keyCollection">The keyCollection to manage and persist the generated keys.</param>
        /// <param name="algorithmEncrypt">The encryption algorithm.</param>
        /// <param name="algorithmSign">The signature algorithm.</param>
        /// <param name="secret">Specifies a seed from which to generate the ProfileDevice</param>
        /// <param name="persist">If <see langword="true"/> persist the secret seed value to
        /// <paramref name="keyCollection"/>.</param>
        public ProfileAccount(
                ProfileMesh profileMesh,
                IKeyCollection keyCollection,
                CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,

                byte[] secret = null,
                bool? persist = null) : this(profileMesh, keyCollection,
                    new PrivateKeyUDF(UdfAlgorithmIdentifier.MeshProfileAccount,
                        algorithmEncrypt, algorithmSign, secret:secret),
                    persist: (persist != null ? persist == true : secret == null)) { }


        /// <summary>
        /// Construct a new ProfileDevice instance from a <see cref="PrivateKeyUDF"/>
        /// seed.
        /// </summary>
        /// <param name="profileMesh">The mesh profile to which this account will belong.</param>
        /// <param name="keyCollection">The keyCollection to manage and persist the generated keys.</param>
        /// <param name="secretSeed">The secret seed value.</param>
        /// <param name="persist">If <see langword="true"/> persist the secret seed value to
        /// <paramref name="keyCollection"/>.</param>
        public ProfileAccount(
                    ProfileMesh profileMesh,
                    IKeyCollection keyCollection,
                    PrivateKeyUDF secretSeed,
                    bool persist = false) {
            MeshProfileUDF = profileMesh.UDF;
            //SecretSeed = secretSeed;

            Console.WriteLine($"Created seed {secretSeed.PrivateValue}");


            var meshKeyType = MeshKeyType.AccountProfile;
            var keySign = secretSeed.BasePrivate(meshKeyType | MeshKeyType.Sign);
            KeyEncrypt = secretSeed.BasePrivate(meshKeyType | MeshKeyType.Encrypt, 
                    keySecurity:KeySecurity.Exportable);
            var keyAuthenticate = secretSeed.BasePrivate(meshKeyType | MeshKeyType.Authenticate);

            KeyOfflineSignature = new KeyData(keySign.KeyPairPublic());
            KeyEncryption = new KeyData(KeyEncrypt.KeyPairPublic());
            KeyAuthentication = new KeyData(keyAuthenticate.KeyPairPublic());



            var keyOnlineSign = KeyPair.Factory(keySign.CryptoAlgorithmId, keySecurity: KeySecurity.ExportableStored,
                keyCollection, keyUses: KeyUses.Sign);

            KeysOnlineSignature = new List<KeyData> { 
                new KeyData(keyOnlineSign.KeyPairPublic())};

            if (persist) {
                keyCollection.Persist(KeyOfflineSignature.UDF, secretSeed, false);
                }

            Sign(keySign);
            }

        /// <summary>
        /// Connect the device described by <paramref name="catalogedDevice"/> with 
        /// the set of permissions <paramref name="permissions"/>> to the account
        /// described by this profile using the account administration key acquired from
        /// <paramref name="catalogedDevice"/>.
        /// </summary>
        /// <param name="keyCollection">Key collection from which to fetch the key to sign
        /// the corresponding Activation and Connection.</param>
        /// <param name="catalogedDevice">The device to connect. The catalog entry will
        /// be updated to reflect the connection to the account.</param>
        /// <param name="permissions">The set of permissions to grant to the device
        /// within the account.</param>
        /// <param name="accountEncryptionKey">Key or key share used to decrypt the
        /// data encrypted to the account key.</param>
        /// <returns>The account description.</returns>
        public AccountEntry ConnectDevice(
                        IKeyCollection keyCollection,
                        CatalogedDevice catalogedDevice,
                        KeyData accountEncryptionKey,
                        List<Permission> permissions
                        ) {

            permissions.Future(); // Mark permissions as required parameter for future use.

            // Get an online signature key if not already found
            keySignOnline ??= keyCollection.LocatePrivate(KeysOnlineSignature);

            // Grant the device access to data encrypted under the account key.
            // Note that this cannot be granted through the capabilities catalog because that
            // is also encrypted under the account key.
            var activationAccount = new ActivationAccount(catalogedDevice.ProfileDevice) {
                KeyAccountEncryption = accountEncryptionKey 
                };


            // Sign and encrypt the activation
            activationAccount.Package(keySignOnline);

            // Encrypt to the device
            var accountEntry = new AccountEntry() {
                AccountUDF = UDF,
                EnvelopedProfileAccount = DareEnvelope,
                EnvelopedConnectionAccount = activationAccount.ConnectionAccount.DareEnvelope,
                EnvelopedActivationAccount = activationAccount.DareEnvelope
                };

            catalogedDevice.Accounts ??= new List<AccountEntry>();
            catalogedDevice.Accounts.Add(accountEntry);

            return accountEntry;
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

            builder.AppendIndent(indent, $"Profile Account");
            indent++;
            DareEnvelope.Report(builder, indent);
            indent++;
            builder.AppendIndent(indent, $"KeyOfflineSignature: {KeyOfflineSignature.UDF} ");
            builder.AppendIndent(indent, $"MeshProfileUDF:      {MeshProfileUDF}");
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
        public static new ProfileAccount Decode(DareEnvelope envelope,
                    IKeyLocate keyCollection = null) =>
                        MeshItem.Decode(envelope, keyCollection) as ProfileAccount;



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



    public partial class ActivationAccount {

        ///<summary>The UDF profile constant used for key derrivation 
        ///<see cref="Constants.UDFActivationAccount"/></summary>
        public override string UDFKeyDerrivation => Constants.UDFActivationAccount;

        ///<summary>The connection value.</summary>
        public override Connection Connection => ConnectionAccount;

        ///<summary>The <see cref="ConnectionAccount"/> instance binding the activated device
        ///to a MeshProfile.</summary>
        public ConnectionAccount ConnectionAccount { get; set; }

        /////<summary>The aggregate encryption key</summary>
        //public KeyPairAdvanced KeyEncryption { get; set; }

        /////<summary>The aggregate authentication key</summary>
        //public KeyPairAdvanced KeyAuthentication { get; set; }

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public ActivationAccount() {
            }

        /// <summary>
        /// Construct a new <see cref="ActivationDevice"/> instance for the profile
        /// <paramref name="profileDevice"/>. The property <see cref="Activation.ActivationKey"/> is
        /// calculated from the values specified for the activation type.
        /// If the value <paramref name="masterSecret"/> is
        /// specified, it is used as the seed value. Otherwise, a seed value of
        /// length <paramref name="bits"/> is generated.
        /// The public key value is calculated for the public key pairs and the corresponding
        /// <see cref="ConnectionAccount"/> generated for the public values.
        /// </summary>
        /// <param name="profileDevice">The base profile that the activation activates.</param>
        /// <param name="masterSecret">If not null, specifies the seed value. Otherwise,
        /// a seed value of <paramref name="bits"/> length is generated.</param>
        /// <param name="bits">The size of the seed to be generated if <paramref name="masterSecret"/>
        /// is null.</param>
        public ActivationAccount(
                    ProfileDevice profileDevice,
                    byte[] masterSecret = null,
                    int bits = 256) : base(
                        profileDevice, UdfAlgorithmIdentifier.MeshActivationAccount, masterSecret, bits) {
            ProfileDevice = profileDevice;

            AccountUDF = profileDevice.UDF;

            var keyEncryption = profileDevice.KeyEncryption.ActivatePublic(ActivationKey,
                    MeshKeyType | MeshKeyType.Encrypt);
            var keyAuthentication = profileDevice.KeyAuthentication.ActivatePublic(ActivationKey,
                    MeshKeyType | MeshKeyType.Authenticate);


            // Create the (unsigned) ConnectionDevice
            ConnectionAccount = new ConnectionAccount() {
                KeyEncryption = new KeyData(keyEncryption.KeyPairPublic()),
                KeySignature = new KeyData(KeySignature.KeyPairPublic()),
                KeyAuthentication = new KeyData(keyAuthentication.KeyPairPublic())
                };
            }




        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="ActivationAccount"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        /// <returns>The decoded profile.</returns>
        public static new ActivationAccount Decode(DareEnvelope envelope,
                    IKeyLocate keyCollection = null) =>
                        MeshItem.Decode(envelope, keyCollection) as ActivationAccount;


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


    public partial class ConnectionAccount {

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public ConnectionAccount() {
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

            builder.AppendIndent(indent, $"Connection Account");
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
        /// Decode <paramref name="envelope"/> and return the inner <see cref="ConnectionAccount"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        /// <returns>The decoded profile.</returns>
        public static new ConnectionAccount Decode(DareEnvelope envelope,
                    IKeyLocate keyCollection = null) =>
                        MeshItem.Decode(envelope, keyCollection) as ConnectionAccount;


        }

    }
