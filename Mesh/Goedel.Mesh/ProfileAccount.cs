﻿using Goedel.Cryptography;
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
        public string ServiceDefault => ServiceIDs?[0];


        //KeyPair keySignOffline;
        KeyPair keySignOnline;


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
            KeyCollection keyCollection,
            CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
            CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,

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
                    KeyCollection keyCollection,
                    PrivateKeyUDF secretSeed,
                    bool persist = false) {
            MeshProfileUDF = profileMesh.UDF;

            var keyEncrypt = Derive(keyCollection, secretSeed, Constants.UDFMeshKeySufixEncrypt);
            var keySign = Derive(keyCollection, secretSeed, Constants.UDFMeshKeySufixSign);
            var keyAuthenticate = Derive(keyCollection, secretSeed, Constants.UDFMeshKeySufixAuthenticate);

            KeyOfflineSignature = new PublicKey(keySign.KeyPairPublic());
            KeyEncryption = new PublicKey(keyEncrypt.KeyPairPublic());
            KeyAuthentication = new PublicKey(keyAuthenticate.KeyPairPublic());

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
        /// <returns>The account description.</returns>
        public AccountEntry ConnectDevice(
                        KeyCollection keyCollection,
                        CatalogedDevice catalogedDevice,
                        List<Permission> permissions
                        ) {

            permissions.Future(); // Mark permissions as required parameter for future use.

            // Get an online signature key if not already found
            keySignOnline ??= keyCollection.LocatePrivate(KeysOnlineSignature);

            var activationAccount = new ActivationAccount(
                catalogedDevice.ProfileDevice, keyCollection);

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
        /// a leading indent of <paramref name="indent"/> units. The cryptographic context from
        /// the mesh machine <paramref name="machine"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="machine">Mesh machine providing cryptographic context.</param>
        public override void ToBuilder(StringBuilder builder, int indent = 0, IMeshMachine machine = null) {

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
            if (ServiceIDs != null) {
                foreach (var serviceID in ServiceIDs) {
                    builder.AppendIndent(indent, $"ServiceID : {serviceID} ");
                    }
                }
            else {
                builder.AppendIndent(indent, $"ServiceID : [None]");
                }
            builder.AppendIndent(indent, $"KeyEncryption:       {KeyEncryption.UDF} ");

            }

        /// <summary>
        /// Decode from DareEnvelope
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <returns>The decoded ProfileAccount.</returns>
        public static new ProfileAccount Decode(DareEnvelope envelope) {
            if (envelope == null) {
                return null;
                }
            var result = FromJSON(envelope.GetBodyReader(), true);
            result.DareEnvelope = envelope;
            return result;
            }


        /// <summary>
        /// Convenience routine reporting if the profile is serviced by the specified provider.
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public int MatchService(string service) {
            int id = 0;

            foreach (var serviceID in ServiceIDs) {

                if (service == serviceID) {
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

        ///<summary>The aggregate encryption key</summary>
        public KeyPairAdvanced KeyEncryption { get; set; }

        ///<summary>The aggregate authentication key</summary>
        public KeyPairAdvanced KeyAuthentication { get; set; }

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
        /// The public key value is calculated for  <see cref="KeyEncryption"/> ,
        ///  <see cref="Activation.KeySignature"/>  and  <see cref="KeyAuthentication"/>,
        /// and registered in the KeyCollection <paramref name="keyCollection"/>.
        /// </summary>
        /// <param name="profileDevice">The base profile that the activation activates.</param>
        /// <param name="keyCollection">The key collection to register the 
        /// <see cref="Activation.KeySignature"/> public key to.</param>
        /// <param name="masterSecret">If not null, specifies the seed value. Otherwise,
        /// a seed value of <paramref name="bits"/> length is generated.</param>
        /// <param name="bits">The size of the seed to be generated if <paramref name="masterSecret"/>
        /// is null.</param>
        public ActivationAccount(
                    ProfileDevice profileDevice,
                    KeyCollection keyCollection,
                    byte[] masterSecret = null,
                    int bits = 256) : base(
                        profileDevice, keyCollection, UdfAlgorithmIdentifier.MeshProfileDevice,
                        Constants.UDFActivationDevice, masterSecret, bits) {
            ProfileDevice = profileDevice;

            AccountUDF = profileDevice.UDF;

            KeyEncryption = Combine(keyCollection, profileDevice.KeyEncryption,
                ActivationKey, Constants.UDFMeshKeySufixEncrypt);

            KeyAuthentication = Combine(keyCollection, profileDevice.KeyAuthentication,
                ActivationKey, Constants.UDFMeshKeySufixAuthenticate);

            // Create the (unsigned) ConnectionDevice
            ConnectionAccount = new ConnectionAccount() {
                KeyEncryption = new PublicKey(KeyEncryption.KeyPairPublic()),
                KeySignature = new PublicKey(KeySignature.KeyPairPublic()),
                KeyAuthentication = new PublicKey(KeyAuthentication.KeyPairPublic())
                };
            }







        /// <summary>
        /// Decode from DareEnvelope
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to collect keys from.</param>
        /// <returns>The decoded ProfileAccount.</returns>
        public static ActivationAccount Decode(DareEnvelope envelope, KeyCollection keyCollection) {
            if (envelope == null) {
                return null;
                }
            var plaintext = envelope.GetPlaintext(keyCollection);

            Console.WriteLine(plaintext.ToUTF8());
            var result = FromJSON(plaintext.JSONReader(), true);
            result.DareEnvelope = envelope;

            return result;
            }

        /// <summary>
        /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
        /// a leading indent of <paramref name="indent"/> units. The cryptographic context from
        /// the mesh machine <paramref name="machine"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="machine">Mesh machine providing cryptographic context.</param>
        public override void ToBuilder(StringBuilder builder, int indent = 0, IMeshMachine machine = null) {

            builder.AppendIndent(indent, $"Activation Account");
            indent++;
            DareEnvelope.Report(builder, indent);
            indent++;

            builder.AppendIndent(indent, $"KeySignature:       {KeySignature?.UDF} ");
            builder.AppendIndent(indent, $"KeyAuthentication:   {KeyAuthentication?.UDF} ");
            builder.AppendIndent(indent, $"KeyEncryption:       {KeyEncryption?.UDF} ");
            builder.AppendIndent(indent, $"KeyGroup:       {KeyGroup?.UDF} ");
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
        /// the mesh machine <paramref name="machine"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="machine">Mesh machine providing cryptographic context.</param>
        public override void ToBuilder(StringBuilder builder, int indent = 0, IMeshMachine machine = null) {

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
        /// Decode the DareEnvelope <paramref name="envelope"/> and return the corresponding
        /// <see cref="ConnectionDevice"/> instance.
        /// </summary>
        /// <param name="envelope">The DareEnvelope to decode</param>
        /// <returns>The decoded <see cref="ConnectionDevice"/> instance.</returns>
        public static new ConnectionAccount Decode(DareEnvelope envelope) {
            if (envelope == null) {
                return null;
                }
            var result = FromJSON(envelope.GetBodyReader(), true);
            result.DareEnvelope = envelope;
            return result;
            }
        }

    }
