#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion



using System.Text;

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

namespace Goedel.Mesh {

    #region // ActivationApplicationGroup
    public partial class ActivationApplicationGroup {
        #region // Properties
        ///<summary>The enveloped object</summary> 
        public Enveloped<ActivationApplicationGroup> GetEnvelopedActivationApplicationGroup() =>
            new(DareEnvelope);

        #endregion


        }
    #endregion

    #region // ApplicationEntryGroup

    public partial class ApplicationEntryGroup {

        #region // Properties
        ///<summary>The decrypted activation.</summary> 
        public ActivationApplicationGroup Activation { get; set; }

        #endregion
        #region // Methods

        ///<inheritdoc/>
        public override void Decode(IKeyCollection keyCollection) =>
            Activation = EnvelopedActivation.Decode(keyCollection);

        /// <summary>
        /// Construct an activation record for the group.
        /// </summary>
        /// <returns></returns>
        public ActivationAccount GetActivationAccount() => new(Activation);


        #endregion

        }
    #endregion

    public partial class CatalogedGroup {
        #region // Properties
        ///<summary>Return the catalog identifier for the group <paramref name="groupAddress"/>.</summary>
        public static string GetGroupID(string groupAddress) => MeshConstants.PrefixCatalogedGroup + groupAddress;

        /// <summary>
        /// The primary key used to catalog the entry.
        /// </summary>
        public override string _PrimaryKey => GetGroupID(Key);


        ///<summary>Cached convenience accessor that unpacks the value of <see cref="EnvelopedProfileGroup"/>
        ///to return the <see cref="ProfileUser"/> value.</summary>
        public ProfileGroup ProfileGroup => profileGroup ??
                    (EnvelopedProfileGroup.Decode(KeyCollection) as ProfileGroup).CacheValue(out profileGroup);
        ProfileGroup profileGroup;

        ActivationAccount ActivationAccount { get; set; }

        /// <summary>
        /// Return the escrowed keys.
        /// </summary>
        /// <returns></returns>
        public override KeyData[] GetEscrow() => 
            new KeyData[] { new KeyData () {
                PrivateParameters =ActivationAccount.SecretSeed } };



        #endregion
            #region // Factory methods and constructors
            /// <summary>
            /// Default constructor for serialization.
            /// </summary>     
        public CatalogedGroup() {
            }


        /// <summary>
        /// Create and return a new catalog entry for <paramref name="profileGroup"/> with
        /// the activation data <paramref name="activationAccount"/>.
        /// </summary>
        /// <param name="profileGroup">The group profile.</param>
        /// <param name="activationAccount">The activation data.</param>
        /// <param name="encryptionKey">Key under which the activation is to be encrypted.</param>
        /// <param name="connectionAddress">Connection binding profile to an address.</param>
        /// <returns>The created group.</returns>
        public CatalogedGroup (
                        ProfileGroup profileGroup,
                        ActivationAccount activationAccount,
                        CryptoKey encryptionKey,
                        ConnectionAddress connectionAddress
                        ) {
            encryptionKey.Future();
            connectionAddress.Future();

            profileGroup?.DareEnvelope.AssertNotNull(Internal.Throw);

            ActivationAccount = activationAccount;
            Key = profileGroup.AccountAddress;
            EnvelopedProfileGroup = profileGroup.GetEnvelopedProfileAccount();
            }



        ///<inheritdoc/>
        public override ApplicationEntry GetActivation(CatalogedDevice catalogedDevice) {
            var activation = new ActivationApplicationGroup() {
                AccountEncryption = new KeyData(ActivationAccount.AccountEncryptionKey, true),
                AdministratorSignature = new KeyData(ActivationAccount.AdministratorSignatureKey, true),
                AccountAuthentication = new KeyData(ActivationAccount.AccountAuthenticationKey, true),
                };

            activation.Envelope(encryptionKey: catalogedDevice.ConnectionDevice.Encryption.GetKeyPair());



            return new ApplicationEntryGroup() {
                Identifier = ProfileGroup.AccountAddress,
                EnvelopedActivation = activation.GetEnvelopedActivationApplicationGroup()
                };

            }

        ///<inheritdoc/>
        public override void ToBuilder(StringBuilder output) {

            }

        #endregion

        }




    }
