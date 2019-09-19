using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Protocol;

namespace Goedel.Mesh {
    public partial class ProfileAccount {

        ///<summary>The primary key</summary>
        public override string _PrimaryKey => UDF;

        ///<summary>The UDF of the account</summary>
        public string UDF => KeyOfflineSignature.UDF;

        KeyPair KeySignOffline;
        KeyPair KeySignOnline;

        /// <summary>
        /// Generate a new ProfileAccount with a unique signature and encryption key.
        /// </summary>
        /// <param name="meshMachine">The machine context in which to generate and persist the key pairs.</param>
        /// <param name="profileMesh">The mesh profile to which this account will belong.</param>
        /// <param name="algorithmSign">The algorithm to be used for signature.</param>
        /// <param name="algorithmEncrypt">The algorithm to be used for encryption.</param>
        /// <returns></returns>
        public static ProfileAccount Generate(
                    IMeshMachine meshMachine,
                    ProfileMesh profileMesh,
                    CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                    CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default) {

            algorithmSign = algorithmSign.DefaultAlgorithmSign();
            algorithmEncrypt = algorithmEncrypt.DefaultAlgorithmEncrypt();

            var keySignOffline = meshMachine.CreateKeyPair(algorithmSign, KeySecurity.Device, keyUses: KeyUses.Sign);
            var keySignOnline = meshMachine.CreateKeyPair(algorithmSign, KeySecurity.Device, keyUses: KeyUses.Sign);
            var keyEncrypt = meshMachine.CreateKeyPair(algorithmEncrypt, KeySecurity.Exportable, keyUses: KeyUses.Encrypt);

            var account = new ProfileAccount() {
                KeyOfflineSignature = new PublicKey(keySignOffline.KeyPairPublic()),
                KeysOnlineSignature = new List<PublicKey> {
                    new PublicKey(keySignOnline.KeyPairPublic())},
                MeshProfileUDF = profileMesh.UDF,
                KeyEncryption = new PublicKey(keyEncrypt.KeyPairPublic())
                };

            account.Sign(keySignOffline);

            return account;
            }


        public AccountEntry ConnectDevice (
                        IMeshMachine meshMachine,
                        CatalogedDevice catalogedDevice,
                        List<Permission> permissions
                        ) {
            // Get an online signature key if not already found
            KeySignOnline = KeySignOnline ?? meshMachine.KeyCollection.LocatePrivate(KeysOnlineSignature);

            // Create a new activation and entry
            var activationAccount = new ActivationAccount(meshMachine, catalogedDevice, this);
            var connectionAccount = new ConnectionAccount(activationAccount, null);


            // Sign the activation
            var envelopedConnectionAccount = connectionAccount.Sign(KeySignOnline);
            //activationAccount.EnvelopedConnectionAccount = envelopedConnectionAccount;

            activationAccount.Sign(KeySignOnline);
            "Need to encrypt the data under the device connection key".TaskFunctionality();


            // Encrypt to the device
            var accountEntry = new AccountEntry() {
                AccountUDF = UDF,
                EnvelopedProfileAccount = DareEnvelope,
                EnvelopedConnectionAccount = envelopedConnectionAccount,
                EnvelopedActivationAccount = activationAccount.DareEnvelope
                };

            catalogedDevice.Accounts = catalogedDevice.Accounts ?? new List<AccountEntry>();
            catalogedDevice.Accounts.Add(accountEntry);


            return accountEntry;
            }


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


        public DareEnvelope Sign(
                    IMeshMachine meshMachine) {
            KeySignOffline = KeySignOffline ?? meshMachine.KeyCollection.LocatePrivate(KeyOfflineSignature.UDF);
            return Sign(KeySignOffline);
            }

        }



    public partial class ActivationAccount {


        //public ConnectionAccount ConnectionAccount => connectionAccount ??
        //    ConnectionAccount.Decode(
        //            EnvelopedConnectionAccount).CacheValue(out connectionAccount);
        //ConnectionAccount connectionAccount;



        public ActivationAccount() {
            }


        public ActivationAccount (
                        IMeshMachine meshMachine,
                        CatalogedDevice catalogedDevice,
                        ProfileAccount  profileAccount
                        ) {

            var profileDevice = catalogedDevice.ProfileDevice;
            //EnvelopedProfileAccount = profileAccount.DareEnvelope;

            AccountUDF = profileAccount.UDF;
            KeySignature = new KeyOverlay(meshMachine, profileDevice.KeyOfflineSignature);
            KeyEncryption = new KeyOverlay(meshMachine, profileDevice.KeyEncryption);
            KeyAuthentication = new KeyOverlay(meshMachine, profileDevice.KeyAuthentication);
            }


        public ConnectionAccount GetConnection(List<Permission> permissions) => new ConnectionAccount() {
            SubjectUDF = KeySignature.KeyPair.UDF,
            AuthorityUDF = AccountUDF,
            KeySignature = new PublicKey(KeySignature.KeyPair.KeyPairPublic()),
            KeyAuthentication = new PublicKey(KeyAuthentication.KeyPair.KeyPairPublic()),
            Permissions = permissions
            };

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


        /// <summary>
        /// Decode from DareEnvelope
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <returns>The decoded ProfileAccount.</returns>
        public static new ActivationAccount Decode(DareEnvelope envelope) {
            if (envelope == null) {
                return null;
                }
            var result = FromJSON(envelope.GetBodyReader(), true);
            result.DareEnvelope = envelope;
            return result;
            }

        }


    public partial class ConnectionAccount {
        public ConnectionAccount() {
            }

        public ConnectionAccount(ActivationAccount activationAccount, List<Permission> permissions) {
            SubjectUDF = activationAccount.KeySignature.KeyPair.UDF;
            AuthorityUDF = activationAccount.AccountUDF;
            KeySignature = new PublicKey(activationAccount.KeySignature.KeyPair.KeyPairPublic());
            KeyAuthentication = new PublicKey(activationAccount.KeyAuthentication.KeyPair.KeyPairPublic());
            Permissions = permissions;
            }

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

        public static new ConnectionAccount Decode(DareEnvelope message) {
            if (message == null) {
                return null;
                }
            var result = FromJSON(message.GetBodyReader(), true);
            result.DareEnvelope = message;
            return result;
            }
        }

    }
