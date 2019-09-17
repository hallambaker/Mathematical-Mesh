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


        public ActivationAccount ConnectDevice (
                        IMeshMachine meshMachine,
                        ConnectionDevice connectionDevice,
                        List<Permission> permissions
                        ) {
            // Get an online signature key if not already found
            KeySignOnline = KeySignOnline ?? meshMachine.KeyCollection.LocatePrivate(KeysOnlineSignature);

            // Create a new activation and entry
            var activationAccount = new ActivationAccount(meshMachine, connectionDevice, this, permissions);
            
            // Sign the activation
            activationAccount.EnvelopedConnectionAccount = activationAccount.ConnectionAccount.Sign(KeySignOnline);

            // Encrypt to the device


            return activationAccount;
            }

        /// <summary>
        /// Decode from DareEnvelope
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <returns>The decoded ProfileAccount.</returns>
        public static new ProfileAccount Decode(DareEnvelope envelope) {
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


        public ConnectionAccount ConnectionAccount => connectionAccount ??
            ConnectionAccount.Decode(
                    EnvelopedConnectionAccount).CacheValue(out connectionAccount);
        ConnectionAccount connectionAccount;



        public ActivationAccount() {
            }


        public ActivationAccount (
                        IMeshMachine meshMachine,
                        ConnectionDevice connectionDevice,
                        ProfileAccount  profileAccount,
                        List<Permission> permissions) {

            EnvelopedProfileAccount = profileAccount.DareEnvelope;

            KeySignature = new KeyOverlay(meshMachine, connectionDevice.KeySignature);
            //KeyEncryption = new KeyComposite(meshMachine, connectionDevice.KeyEncryption);
            KeyAuthentication = new KeyOverlay(meshMachine, connectionDevice.KeyAuthentication);

            connectionAccount = new ConnectionAccount() {
                SubjectUDF = KeySignature.KeyPair.UDF,
                AuthorityUDF = profileAccount.UDF,
                KeySignature = new PublicKey(KeySignature.KeyPair.KeyPairPublic()),
                KeyAuthentication = new PublicKey(KeyAuthentication.KeyPair.KeyPairPublic()),
                Permissions = permissions
                };

            }


        }


    public partial class ConnectionAccount {




        public static new ConnectionAccount Decode(DareEnvelope message) {
            var result = FromJSON(message.GetBodyReader(), true);
            result.DareEnvelope = message;
            return result;
            }
        }

    }
