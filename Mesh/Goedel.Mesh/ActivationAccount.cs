using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Mesh;
using System;
using System.Collections.Generic;
using System.IO;
using Goedel.Protocol;
using System.Text;

namespace Goedel.Mesh {
    public partial class ActivationAccount {

        // Properties providing access to account-wide keys.

        ///<summary>The account offline signature key</summary>
        public KeyPair PrivateAccountOfflineSignature { get; private set; }

        ///<summary>The account online signature key</summary>
        public KeyPair PrivateAccountOnlineSignature { get; private set; }

        ///<summary>The account encryption key</summary>
        public KeyPair PrivateAccountEncryption { get; private set; }

        ///<summary>The account authentication key</summary>
        public KeyPair PrivateAccountAuthentication { get; private set; }

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public ActivationAccount() {
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
        public ActivationAccount(
                    ProfileDevice profileDevice,
                    byte[] masterSecret = null,
                    int bits = 256) : base(
                        profileDevice, UdfAlgorithmIdentifier.MeshActivationUser, masterSecret, bits) {
            ProfileDevice = profileDevice;
            }


        /// <summary>
        /// Activate the keys bound to this activation record using keys derived from 
        /// <paramref name="deviceKeySeed"/>.
        /// </summary>
        /// <param name="keyCollection">Key collection to register keys in.</param>
        /// <param name="deviceKeySeed">Generator for the private key contributions.</param>
        public void Activate(
                IKeyCollection keyCollection, 
                IActivate deviceKeySeed) {

            PrivateAccountOfflineSignature = AccountOnlineSignature?.GetKeyPair(KeySecurity.Exportable);
            PrivateAccountOnlineSignature = AccountOfflineSignature?.GetKeyPair(KeySecurity.Exportable);
            PrivateAccountEncryption = AccountEncryption?.GetKeyPair(KeySecurity.Exportable);
            PrivateAccountAuthentication = AccountAuthentication?.GetKeyPair(KeySecurity.Exportable);

            }



        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="ActivationUser"/>
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


            }
        }

    }
