using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;

using System.Numerics;
using System.Collections.Generic;
using System.IO;


namespace Goedel.Mesh {
    public partial class EnvelopedData<T> : DareEnvelope where T : JsonObject {

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public EnvelopedData() {
            }

        /// <summary>
        /// Create a < 
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="contentMeta">The content metadata</param>
        /// <param name="plaintext">The payload plaintext. If specified, the plaintext will be used to
        /// create the message body. Otherwise the body is specified by calls to the Process method.</param>
        /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        public EnvelopedData(
                    CryptoParameters cryptoParameters,
                    byte[] plaintext,
                    ContentMeta contentMeta = null,
                    byte[] cloaked = null,
                    List<byte[]> dataSequences = null
                    ) : base(cryptoParameters, plaintext, contentMeta, cloaked, dataSequences) {
            }
        public T Decode(IKeyLocate keyCollection = null) {
            throw new NYI();
            }
        }

    #region // Profiles
    /// <summary>
    /// Envelope containing a <see cref="ProfileUser"/>. Encode and Decode methods
    /// automatically cause signature creation and verification.
    /// </summary>
    public partial class EnvelopedProfileUser : EnvelopedData<ProfileUser> {

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public EnvelopedProfileUser() {
            }


        /// <summary>
        /// Create a EnvelopedProfileUser instance.
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="profileUser">The payload data, a profile user.</param>
        public EnvelopedProfileUser (
                    CryptoParameters cryptoParameters,
                    ProfileUser profileUser) : base(cryptoParameters, profileUser.GetBytes(true)) {
            }

        /// <summary>
        /// Create a new DARE Message from the specified parameters.
        /// </summary>
        /// <param name="profileUser">The payload data, a profile user.</param>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <returns>The signed profile.</returns>
        public static EnvelopedProfileUser Encode(
                    ProfileUser profileUser,
                    CryptoKey signingKey = null,
                    CryptoKey encryptionKey = null) {
            var cryptoParameters = new CryptoParameters(signer: signingKey, recipient: encryptionKey);
            return new EnvelopedProfileUser(cryptoParameters, profileUser);
            }

        }

    /// <summary>
    /// Envelope containing a <see cref="ProfileDevice"/>. Encode and Decode methods
    /// automatically cause signature creation and verification.
    /// </summary>
    public partial class EnvelopedProfileDevice : EnvelopedData<ProfileDevice> {

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public EnvelopedProfileDevice() {
            }

        /// <summary>
        /// Create a EnvelopedProfileUser instance.
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="profileDevice">The payload data, a profile user.</param>
        public EnvelopedProfileDevice(
                    CryptoParameters cryptoParameters,
                    ProfileDevice profileDevice) : base(cryptoParameters, profileDevice.GetBytes(true)) {
            }

        /// <summary>
        /// Create a new DARE Message from the specified parameters.
        /// </summary>
        /// <param name="profileDevice">The payload data, a profile user.</param>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <returns>The signed profile.</returns>
        public static EnvelopedProfileDevice Encode(
                    ProfileDevice profileDevice,
                    CryptoKey signingKey = null,
                    CryptoKey encryptionKey = null) {
            var cryptoParameters = new CryptoParameters(signer: signingKey, recipient: encryptionKey);
            return new EnvelopedProfileDevice(cryptoParameters, profileDevice);
            }

        }

    /// <summary>
    /// Envelope containing a <see cref="ProfileService"/>. Encode and Decode methods
    /// automatically cause signature creation and verification.
    /// </summary>
    public partial class EnvelopedProfileService : EnvelopedData<ProfileService> {

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public EnvelopedProfileService() {
            }

        /// <summary>
        /// Create a EnvelopedProfileUser instance.
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="profileService">The payload data, a profile user.</param>
        public EnvelopedProfileService(
                    CryptoParameters cryptoParameters,
                    ProfileService profileService) : base(cryptoParameters, profileService.GetBytes(true)) {
            }

        /// <summary>
        /// Create a new DARE Message from the specified parameters.
        /// </summary>
        /// <param name="profileService">The payload data, a profile user.</param>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <returns>The signed profile.</returns>
        public static EnvelopedProfileService Encode(
                    ProfileService profileService,
                    CryptoKey signingKey = null,
                    CryptoKey encryptionKey = null) {
            var cryptoParameters = new CryptoParameters(signer: signingKey, recipient: encryptionKey);
            return new EnvelopedProfileService(cryptoParameters, profileService);
            }
        }


    /// <summary>
    /// Envelope containing a <see cref="ProfileGroup"/>. Encode and Decode methods
    /// automatically cause signature creation and verification.
    /// </summary>
    public partial class EnvelopedProfileGroup : EnvelopedData<ProfileGroup> {

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public EnvelopedProfileGroup() {
            }

        /// <summary>
        /// Create a EnvelopedProfileUser instance.
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="profileGroup">The payload data, a profile user.</param>
        public EnvelopedProfileGroup(
                    CryptoParameters cryptoParameters,
                    ProfileGroup profileGroup) : base(cryptoParameters, profileGroup.GetBytes(true)) {
            }

        /// <summary>
        /// Create a new DARE Message from the specified parameters.
        /// </summary>
        /// <param name="profileGroup">The payload data, a profile user.</param>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <returns>The signed profile.</returns>
        public static EnvelopedProfileGroup Encode(
                    ProfileGroup profileGroup,
                    CryptoKey signingKey = null,
                    CryptoKey encryptionKey = null) {
            var cryptoParameters = new CryptoParameters(signer: signingKey, recipient: encryptionKey);
            return new EnvelopedProfileGroup(cryptoParameters, profileGroup);
            }
        }

    /// <summary>
    /// Envelope containing a <see cref="ProfileAccount"/>. Encode and Decode methods
    /// automatically cause signature creation and verification.
    /// </summary>
    public partial class EnvelopedProfileAccount : EnvelopedData<ProfileAccount> {

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public EnvelopedProfileAccount() {
            }


        /// <summary>
        /// Create a EnvelopedProfileUser instance.
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="profileAccount">The payload data, a profile user.</param>
        public EnvelopedProfileAccount(
                    CryptoParameters cryptoParameters,
                    ProfileAccount profileAccount) : base(cryptoParameters, profileAccount.GetBytes(true)) {
            }

        /// <summary>
        /// Create a new DARE Message from the specified parameters.
        /// </summary>
        /// <param name="profileAccount">The payload data, a profile user.</param>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <returns>The signed profile.</returns>
        public static EnvelopedProfileAccount Encode(
                    ProfileAccount profileAccount,
                    CryptoKey signingKey = null,
                    CryptoKey encryptionKey = null) {
            var cryptoParameters = new CryptoParameters(signer: signingKey, recipient: encryptionKey);
            return new EnvelopedProfileAccount(cryptoParameters, profileAccount);
            }
        }

    /// <summary>
    /// Envelope containing a <see cref="ProfileAccount"/>. Encode and Decode methods
    /// automatically cause signature creation and verification.
    /// </summary>
    public partial class EnvelopedProfileHost : EnvelopedData<ProfileHost> {

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public EnvelopedProfileHost() {
            }


        /// <summary>
        /// Create a EnvelopedProfileUser instance.
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="profileHost">The payload data, a profile user.</param>
        public EnvelopedProfileHost(
                    CryptoParameters cryptoParameters,
                    ProfileHost profileHost) : base(cryptoParameters, profileHost.GetBytes(true)) {
            }

        /// <summary>
        /// Create a new DARE Message from the specified parameters.
        /// </summary>
        /// <param name="profileHost">The payload data, a profile user.</param>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <returns>The signed profile.</returns>
        public static EnvelopedProfileHost Encode(
                    ProfileHost profileHost,
                    CryptoKey signingKey = null,
                    CryptoKey encryptionKey = null) {
            var cryptoParameters = new CryptoParameters(signer: signingKey, recipient: encryptionKey);
            return new EnvelopedProfileHost(cryptoParameters, profileHost);
            }
        }


    #endregion
    #region // Connections

    /// <summary>
    /// Envelope containing a <see cref="ConnectionUser"/>. Encode and Decode methods
    /// automatically cause signature creation and verification.
    /// </summary>
    public partial class EnvelopedConnectionUser : EnvelopedData<ConnectionUser> {


        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public EnvelopedConnectionUser() {
            }

        /// <summary>
        /// Create a EnvelopedProfileUser instance.
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="connectionUser">The payload data, a profile user.</param>
        public EnvelopedConnectionUser(
                    CryptoParameters cryptoParameters,
                    ConnectionUser connectionUser) : base(cryptoParameters, connectionUser.GetBytes(true)) {
            }

        /// <summary>
        /// Create a new DARE Message from the specified parameters.
        /// </summary>
        /// <param name="connectionUser">The payload data, a profile user.</param>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <returns>The signed profile.</returns>
        public static EnvelopedConnectionUser Encode(
                    ConnectionUser connectionUser,
                    CryptoKey signingKey = null,
                    CryptoKey encryptionKey = null) {
            var cryptoParameters = new CryptoParameters(signer: signingKey, recipient: encryptionKey);
            return new EnvelopedConnectionUser(cryptoParameters, connectionUser);
            }
        }

    #endregion
    #region // Activations

    /// <summary>
    /// Envelope containing a <see cref="ProfileUser"/>. Encode and Decode methods
    /// automatically cause signature creation and verification.
    /// </summary>
    public partial class EnvelopedActivationDevice : EnvelopedData<ActivationDevice> {

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public EnvelopedActivationDevice() {
            }


        /// <summary>
        /// Create a EnvelopedProfileUser instance.
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="activationDevice">The payload data, a profile user.</param>
        public EnvelopedActivationDevice(
                    CryptoParameters cryptoParameters,
                    ActivationDevice activationDevice) : base(cryptoParameters, activationDevice.GetBytes(true)) {
            }

        /// <summary>
        /// Create a new DARE Message from the specified parameters.
        /// </summary>
        /// <param name="activationDevice">The payload data, a profile user.</param>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <returns>The signed profile.</returns>
        public static EnvelopedActivationDevice Encode(
                    ActivationDevice activationDevice,
                    CryptoKey signingKey = null,
                    CryptoKey encryptionKey = null) {
            var cryptoParameters = new CryptoParameters(signer: signingKey, recipient: encryptionKey);
            return new EnvelopedActivationDevice(cryptoParameters, activationDevice);
            }
        }


    /// <summary>
    /// Envelope containing a <see cref="ActivationAccount"/>. Encode and Decode methods
    /// automatically cause signature creation and verification.
    /// </summary>
    public partial class EnvelopedActivationAccount : EnvelopedData<ActivationAccount> {


        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public EnvelopedActivationAccount() {
            }


        /// <summary>
        /// Create a EnvelopedProfileUser instance.
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="activationAccount">The payload data, a profile user.</param>
        public EnvelopedActivationAccount(
                    CryptoParameters cryptoParameters,
                    ActivationAccount activationAccount) : base(cryptoParameters, activationAccount.GetBytes(true)) {
            }

        /// <summary>
        /// Create a new DARE Message from the specified parameters.
        /// </summary>
        /// <param name="activationAccount">The payload data, a profile user.</param>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <returns>The signed profile.</returns>
        public static EnvelopedActivationAccount Encode(
                    ActivationAccount activationAccount,
                    CryptoKey signingKey = null,
                    CryptoKey encryptionKey = null) {
            var cryptoParameters = new CryptoParameters(signer: signingKey, recipient: encryptionKey);
            return new EnvelopedActivationAccount(cryptoParameters, activationAccount);
            }
        }


    /// <summary>
    /// Envelope containing a <see cref="ActivationApplication"/>. Encode and Decode methods
    /// automatically cause signature creation and verification.
    /// </summary>
    public partial class EnvelopedActivationApplication : EnvelopedData<ActivationApplication> {


        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public EnvelopedActivationApplication() {
            }


        /// <summary>
        /// Create a EnvelopedProfileUser instance.
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="activationApplication">The payload data, a profile user.</param>
        public EnvelopedActivationApplication(
                    CryptoParameters cryptoParameters,
                    ActivationApplication activationApplication) : 
                        base(cryptoParameters, activationApplication.GetBytes(true)) {
            }

        /// <summary>
        /// Create a new DARE Message from the specified parameters.
        /// </summary>
        /// <param name="activationApplication">The payload data, a profile user.</param>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <returns>The signed profile.</returns>
        public static EnvelopedActivationApplication Encode(
                    ActivationApplication activationApplication,
                    CryptoKey signingKey = null,
                    CryptoKey encryptionKey = null) {
            var cryptoParameters = new CryptoParameters(signer: signingKey, recipient: encryptionKey);
            return new EnvelopedActivationApplication(cryptoParameters, activationApplication);
            }

        }


    #endregion
    #region // Misc data

    /// <summary>
    /// Envelope containing a <see cref="KeyData"/>. Encode and Decode methods
    /// automatically cause signature creation and verification.
    /// </summary>
    public partial class EnvelopedKeyShares : EnvelopedData<KeyData> {


        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public EnvelopedKeyShares() {
            }


        /// <summary>
        /// Create a EnvelopedProfileUser instance.
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="keyData">The payload data, a profile user.</param>
        public EnvelopedKeyShares(
                    CryptoParameters cryptoParameters,
                    KeyData keyData) : base(cryptoParameters, keyData.GetBytes(true)) {
            }

        /// <summary>
        /// Create a new DARE Message from the specified parameters.
        /// </summary>
        /// <param name="keyData">The payload data, a profile user.</param>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <returns>The signed profile.</returns>
        public static EnvelopedKeyShares Encode(
                    KeyData keyData,
                    CryptoKey signingKey = null,
                    CryptoKey encryptionKey = null) {
            var cryptoParameters = new CryptoParameters(signer: signingKey, recipient: encryptionKey);
            return new EnvelopedKeyShares(cryptoParameters, keyData);
            }
        }


    /// <summary>
    /// Envelope containing a <see cref="Contact"/>. Encode and Decode methods
    /// automatically cause signature creation and verification.
    /// </summary>
    public partial class EnvelopedContact : EnvelopedData<Contact> {


        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public EnvelopedContact() {
            }


        /// <summary>
        /// Create a EnvelopedProfileUser instance.
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="contact">The payload data, a profile user.</param>
        public EnvelopedContact(
                    CryptoParameters cryptoParameters,
                    Contact contact) : base(cryptoParameters, contact.GetBytes(true)) {
            }

        /// <summary>
        /// Create a new DARE Message from the specified parameters.
        /// </summary>
        /// <param name="Contact">The payload data, a profile user.</param>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <returns>The signed profile.</returns>
        public static EnvelopedContact Encode(
                    Contact Contact,
                    CryptoKey signingKey = null,
                    CryptoKey encryptionKey = null) {
            var cryptoParameters = new CryptoParameters(signer: signingKey, recipient: encryptionKey);
            return new EnvelopedContact(cryptoParameters, Contact);
            }
        }


    #endregion
    #region // Messages

    /// <summary>
    /// Envelope containing a <see cref="RequestConnection"/>. Encode and Decode methods
    /// automatically cause signature creation and verification.
    /// </summary>
    public partial class EnvelopedRequestConnection : EnvelopedData<RequestConnection> {


        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public EnvelopedRequestConnection() {
            }


        /// <summary>
        /// Create a EnvelopedProfileUser instance.
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="requestConnection">The payload data, a profile user.</param>
        public EnvelopedRequestConnection(
                    CryptoParameters cryptoParameters,
                    RequestConnection requestConnection) : base(cryptoParameters, requestConnection.GetBytes(true)) {
            }

        /// <summary>
        /// Create a new DARE Message from the specified parameters.
        /// </summary>
        /// <param name="requestConnection">The payload data, a profile user.</param>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <returns>The signed profile.</returns>
        public static EnvelopedRequestConnection Encode(
                    RequestConnection requestConnection,
                    CryptoKey signingKey = null,
                    CryptoKey encryptionKey = null) {
            var cryptoParameters = new CryptoParameters(signer: signingKey, recipient: encryptionKey);
            return new EnvelopedRequestConnection(cryptoParameters, requestConnection);
            }
        }

    /// <summary>
    /// Envelope containing a <see cref="RequestConfirmation"/>. Encode and Decode methods
    /// automatically cause signature creation and verification.
    /// </summary>
    public partial class EnvelopedMessageClaim : EnvelopedData<MessageClaim> {


        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public EnvelopedMessageClaim() {
            }


        /// <summary>
        /// Create a EnvelopedProfileUser instance.
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="messageClaim">The payload data, a profile user.</param>
        public EnvelopedMessageClaim(
                    CryptoParameters cryptoParameters,
                    MessageClaim messageClaim) : base(cryptoParameters, messageClaim.GetBytes(true)) {
            }

        /// <summary>
        /// Create a new DARE Message from the specified parameters.
        /// </summary>
        /// <param name="messageClaim">The payload data, a profile user.</param>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <returns>The signed profile.</returns>
        public static EnvelopedMessageClaim Encode(
                    MessageClaim messageClaim,
                    CryptoKey signingKey = null,
                    CryptoKey encryptionKey = null) {
            var cryptoParameters = new CryptoParameters(signer: signingKey, recipient: encryptionKey);
            return new EnvelopedMessageClaim(cryptoParameters, messageClaim);
            }
        }


    /// <summary>
    /// Envelope containing a <see cref="RequestConfirmation"/>. Encode and Decode methods
    /// automatically cause signature creation and verification.
    /// </summary>
    public partial class EnvelopedRespondConnection : EnvelopedData<RespondConnection> {


        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public EnvelopedRespondConnection() {
            }


        /// <summary>
        /// Create a EnvelopedProfileUser instance.
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="respondConnection">The payload data, a profile user.</param>
        public EnvelopedRespondConnection(
                    CryptoParameters cryptoParameters,
                    RespondConnection respondConnection) : base(cryptoParameters, respondConnection.GetBytes(true)) {
            }

        /// <summary>
        /// Create a new DARE Message from the specified parameters.
        /// </summary>
        /// <param name="respondConnection">The payload data, a profile user.</param>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <returns>The signed profile.</returns>
        public static EnvelopedRespondConnection Encode(
                    RespondConnection respondConnection,
                    CryptoKey signingKey = null,
                    CryptoKey encryptionKey = null) {
            var cryptoParameters = new CryptoParameters(signer: signingKey, recipient: encryptionKey);
            return new EnvelopedRespondConnection(cryptoParameters, respondConnection);
            }
        }


    /// <summary>
    /// Envelope containing a <see cref="RequestConfirmation"/>. Encode and Decode methods
    /// automatically cause signature creation and verification.
    /// </summary>
    public partial class EnvelopedCatalogedDevice : EnvelopedData<CatalogedDevice> {


        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public EnvelopedCatalogedDevice() {
            }


        /// <summary>
        /// Create a EnvelopedProfileUser instance.
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="catalogedDevice">The payload data, a profile user.</param>
        public EnvelopedCatalogedDevice(
                    CryptoParameters cryptoParameters,
                    CatalogedDevice catalogedDevice) : base(cryptoParameters, catalogedDevice.GetBytes(true)) {
            }

        /// <summary>
        /// Create a new DARE Message from the specified parameters.
        /// </summary>
        /// <param name="catalogedDevice">The payload data, a profile user.</param>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <returns>The signed profile.</returns>
        public static EnvelopedCatalogedDevice Encode(
                    CatalogedDevice catalogedDevice,
                    CryptoKey signingKey = null,
                    CryptoKey encryptionKey = null) {
            var cryptoParameters = new CryptoParameters(signer: signingKey, recipient: encryptionKey);
            return new EnvelopedCatalogedDevice(cryptoParameters, catalogedDevice);
            }
        }





    /// <summary>
    /// Envelope containing a <see cref="RequestConfirmation"/>. Encode and Decode methods
    /// automatically cause signature creation and verification.
    /// </summary>
    public partial class EnvelopedRequestConfirmation : EnvelopedData<RequestConfirmation> {


        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public EnvelopedRequestConfirmation() {
            }


        /// <summary>
        /// Create a EnvelopedProfileUser instance.
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="requestConfirmation">The payload data, a profile user.</param>
        public EnvelopedRequestConfirmation(
                    CryptoParameters cryptoParameters,
                    RequestConfirmation requestConfirmation) : base(cryptoParameters, requestConfirmation.GetBytes(true)) {
            }

        /// <summary>
        /// Create a new DARE Message from the specified parameters.
        /// </summary>
        /// <param name="requestConfirmation">The payload data, a profile user.</param>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <returns>The signed profile.</returns>
        public static EnvelopedRequestConfirmation Encode(
                    RequestConfirmation requestConfirmation,
                    CryptoKey signingKey = null,
                    CryptoKey encryptionKey = null) {
            var cryptoParameters = new CryptoParameters(signer: signingKey, recipient: encryptionKey);
            return new EnvelopedRequestConfirmation(cryptoParameters, requestConfirmation);
            }
        }





    #endregion
    }
