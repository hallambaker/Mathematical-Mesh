using Goedel.Cryptography;
using System;

namespace Goedel.Mesh {

   


    ///<summary>Enumeration for Key types</summary>
    public enum MeshKeyType {

        ///<summary>Mask to recover seed type</summary>
        IndexSeedType = 0x10,

        ///<summary>Mask to recover seed type</summary>
        MaskSeedType = 0xF * IndexSeedType,

        ///<summary>Mask to recover seed type</summary>
        MaskKeyUse = 0x0F,


        // ** Key uses
        ///<summary>offline signature</summary>
        Sign = 0x00,

        ///<summary>Master profile online signature</summary>
        OnlineSign = 0x01,

        ///<summary>Encryption</summary>
        Encrypt = 0x02,

        ///<summary>Master profile authentication</summary>
        Authenticate = 0x03,

        ///<summary>Master profile authentication</summary>
        PartialUser = 0x04,

        ///<summary>Master profile authentication</summary>
        PartialService = 0x05,


        // ** Master Profile
        ///<summary>Master profile offline signature</summary>
        MasterProfile = IndexSeedType * 1,

        ///<summary>Master profile offline signature</summary>
        MasterOfflineSign = MasterProfile,

        ///<summary>Master profile online signature</summary>
        MasterOnlineSign = OnlineSign,

        ///<summary>Master profile encryption</summary>
        MasterEncrypt = Encrypt,


        // ** Device Profile
        ///<summary>Master profile offline signature</summary>
        DeviceProfile = IndexSeedType * 2,

        ///<summary>Master profile offline signature</summary>
        DeviceSign = DeviceProfile + Sign,


        ///<summary>Master profile encryption</summary>
        DeviceEncrypt = DeviceSign + Encrypt,

        ///<summary>Master profile authentication</summary>
        DeviceAuthenticate = DeviceSign + Authenticate,


        // ** Account Profile
        ///<summary>Master profile offline signature</summary>
        AccountProfile = IndexSeedType * 3,

        ///<summary>Master profile offline signature</summary>
        AccountSign = AccountProfile + Sign,

        ///<summary>Master profile encryption</summary>
        AccountEncrypt = AccountSign + Encrypt,

        ///<summary>Master profile authentication</summary>
        AccountAuthenticate = AccountSign + Authenticate,


        // ** Group Profile
        ///<summary>Master profile offline signature</summary>
        GroupProfile = IndexSeedType * 4,

        ///<summary>Master profile offline signature</summary>
        GroupSign = GroupProfile + Sign,

        ///<summary>Master profile encryption</summary>
        GroupEncrypt = GroupSign + Encrypt,

        ///<summary>Master profile authentication</summary>
        GroupAuthenticate = GroupSign + Authenticate,

        ///<summary>Master profile authentication</summary>
        GroupUser = GroupSign + PartialUser,

        ///<summary>Master profile authentication</summary>
        GroupService = GroupSign + PartialService,


        // ** Service Profile
        ///<summary>Master profile offline signature</summary>
        ServiceProfile = IndexSeedType * 5,

        ///<summary>Master profile offline signature</summary>
        ServiceSign = AccountProfile + Sign,

        ///<summary>Master profile encryption</summary>
        ServiceEncrypt = AccountSign + Encrypt,

        ///<summary>Master profile authentication</summary>
        ServiceAuthenticate = AccountSign + Authenticate,

        }

    /// <summary>
    /// Status values for Mesh Messages
    /// </summary>
    public enum MessageStatus {



        ///<summary>Message is unread.</summary>
        Unread = 0b1,

        ///<summary>Message has been read.</summary>
        Read = 0b10,

        ///<summary>Message has expired</summary>
        Unexpired = 0b100,

        ///<summary>Message has expired</summary>
        Expired = 0b1000,

        ///<summary>Message is open.</summary>
        Open = 0b1_0000,

        ///<summary>Message is closed.</summary>
        Closed = 0b10_0000,


        ///<summary>Initial Message Status</summary>
        Initial = Unread | Open,

        ///<summary>Initial Message Status</summary>
        Active = Unexpired | Open,


        ///<summary>All messages.</summary>
        All = 0b11_1111,

        ///<summary>No messages.</summary>
        None = 0b00_0000
        }

    /// <summary>
    /// Collected constants used in the Mathematical Mesh
    /// </summary>
    public static class Constants {

        ///<summary>Action info for device PIN</summary>
        public const string MessagePINActionDevice = "Device";

        ///<summary>Action info for contact PIN</summary>
        public const string MessagePINActionContact = "Contact";

        ///<summary>The proposed IANA content identifier for the Mesh message type.</summary>
        public const string IanaTypeMeshMessage = "application/mmm/message";

        ///<summary>The proposed IANA content identifier for the Mesh message type.</summary>
        public const string IanaTypeMeshObject = "application/mmm/object";


        ///<summary>The proposed IANA content identifier for the Mesh message type.</summary>
        public const string IanaTypeMeshNonce = "application/mmm/nonce";


        ///<summary>The proposed IANA content identifier for the Mesh message type.</summary>
        public const string IanaTypeMeshAuthenticator = "application/mmm/authenticator";


        ///<summary>The proposed IANA URI scheme.</summary>
        public const string MeshConnectURI = "mcu";

        ///<summary>HKDF info tag for deriving Service Authenticator from IKM</summary>
        public const string ServiceAuthenticatorInfo = "mmm/key/authenticate/service";

        ///<summary>HKDF info tag for deriving Device Authenticator from IKM</summary>
        public const string DeviceAuthenticatorInfo = "mmm/key/authenticate/device";


        ///<summary>Prefix to be applied to form the ID of a mesh group in the catalog.</summary>
        public const string PrefixCatalogedGroup = "mmm/CatalogedGroup/";

        // Constants for calculating timeout values.

        ///<summary>Number of ticks in a millisecond</summary>
        public const long MillisecondInTicks =   10_000 ;
        ///<summary>Number of ticks in a second</summary>
        public const long SecondInTicks =       1000 * MillisecondInTicks;
        ///<summary>Number of ticks in a minute</summary>
        public const long MinuteInTicks =       60 * SecondInTicks;
        ///<summary>Number of ticks in a hour</summary>
        public const long HourInTicks =         60 * MinuteInTicks;
        ///<summary>Number of ticks in a day</summary>
        public const long DayInTicks =          24 * HourInTicks;
        ///<summary>Number of ticks in a week</summary>
        public const long WeekInTicks =         7 * DayInTicks;
        ///<summary>Number of ticks in a year</summary>
        public const long YearInTicks =         365 * DayInTicks;

        // Constants used in conjunction with UDF derived keys.

        ///<summary>Default master seed size in bits.</summary>
        public const int DefaultMasterKeyBits = 256;

        ///<summary>Salt value for creating a ProfileAccount Encryption Key</summary>
        public const string UDFMeshKeyPrefix = "mmm/";

        ///<summary>Salt value for creating a ProfileAccount Encryption Key</summary>
        public const string UDFMeshKeySufixEncrypt = "Encrypt";
        ///<summary>Salt value for creating a ProfileAccount Encryption Key</summary>
        public const string UDFMeshKeySufixSign = "Sign";
        ///<summary>Salt value for creating a ProfileAccount Encryption Key</summary>
        public const string UDFMeshKeySufixAuthenticate = "Authenticate";


        ///<summary>Salt value for creating a ProfileAccount Encryption Key</summary>
        public const string UDFProfileDevice = "ProfileDevice";
        ///<summary>Salt value for creating a ProfileAccount Encryption Key</summary>
        public const string UDFProfileAccount = "ProfileAccount";
        ///<summary>Salt value for creating a ProfileAccount Encryption Key</summary>
        public const string UDFProfileGroup = "ProfileGroup";
        ///<summary>Salt value for creating a ProfileAccount Encryption Key</summary>
        public const string UDFProfileService = "ProfileService";


        ///<summary>Salt value for creating a ProfileAccount Encryption Key</summary>
        public const string UDFActivationDevice = "ActivationDevice";
        ///<summary>Salt value for creating a ProfileAccount Encryption Key</summary>
        public const string UDFActivationAccount= "ActivationAccount";
        ///<summary>Salt value for creating a ProfileAccount Encryption Key</summary>
        public const string UDFActivationGroup = "ActivationGroup";
        ///<summary>Salt value for creating a ProfileAccount Encryption Key</summary>
        public const string UDFActivationService = "ActivationService";


        // Transaction related constants

        ///<summary>Transaction result tag Accept</summary>
        public const string TransactionResultAccept = "Accept";

        ///<summary>Transaction result tag Reject</summary>
        public const string TransactionResultReject = "Reject";

        ///<summary>Transaction result tag Pending</summary>
        public const string TransactionResultPending = "Pending";

        ///<summary>Transaction result tag Expired</summary>
        public const string TransactionResultExpired = "Expired";


        // CryptoAlgorithmID related constants and convenience functions

        ///<summary>The default encryption algorithm</summary>
        public const CryptoAlgorithmId DefaultAlgorithmEncryptID = CryptoAlgorithmId.X448;
        ///<summary>The default signature algorithm</summary>
        public const CryptoAlgorithmId DefaultAlgorithmSignID = CryptoAlgorithmId.Ed448;
        ///<summary>The default authentication algorithm</summary>
        public const CryptoAlgorithmId DefaultAlgorithmAuthenticateID = CryptoAlgorithmId.X448;

        /// <summary>
        /// Convenience function that returns the value <see cref="DefaultAlgorithmEncryptID"/> if
        /// <paramref name="cryptoAlgorithmID"/> is <see cref="CryptoAlgorithmId.Default"/> 
        /// and <paramref name="cryptoAlgorithmID"/>
        /// otherwise.
        /// </summary>
        /// <param name="cryptoAlgorithmID">The CryptoAlgorithmID to default.</param>
        /// <returns>The value <paramref name="cryptoAlgorithmID"/> with the
        /// specified substitution if the value is <see cref="CryptoAlgorithmId.Default"/>.</returns>
        public static CryptoAlgorithmId DefaultAlgorithmEncrypt(this CryptoAlgorithmId cryptoAlgorithmID) =>
            cryptoAlgorithmID.DefaultMeta(DefaultAlgorithmEncryptID);

        /// <summary>
        /// Convenience function that returns the value <see cref="DefaultAlgorithmSignID"/> if
        /// <paramref name="cryptoAlgorithmID"/> is <see cref="CryptoAlgorithmId.Default"/> 
        /// and <paramref name="cryptoAlgorithmID"/>
        /// otherwise.
        /// </summary>
        /// <param name="cryptoAlgorithmID">The CryptoAlgorithmID to default.</param>
        /// <returns>The value <paramref name="cryptoAlgorithmID"/> with the
        /// specified substitution if the value is <see cref="CryptoAlgorithmId.Default"/>.</returns>
        public static CryptoAlgorithmId DefaultAlgorithmSign(this CryptoAlgorithmId cryptoAlgorithmID) =>
            cryptoAlgorithmID.DefaultMeta(DefaultAlgorithmSignID);

        /// <summary>
        /// Convenience function that returns the value <see cref="DefaultAlgorithmAuthenticateID"/> if
        /// <paramref name="cryptoAlgorithmID"/> is <see cref="CryptoAlgorithmId.Default"/> 
        /// and <paramref name="cryptoAlgorithmID"/>
        /// otherwise.
        /// </summary>
        /// <param name="cryptoAlgorithmID">The CryptoAlgorithmID to default.</param>
        /// <returns>The value <paramref name="cryptoAlgorithmID"/> with the
        /// specified substitution if the value is <see cref="CryptoAlgorithmId.Default"/>.</returns>
        public static CryptoAlgorithmId DefaultAlgorithmAuthenticate(this CryptoAlgorithmId cryptoAlgorithmID) =>
            cryptoAlgorithmID.DefaultMeta(DefaultAlgorithmAuthenticateID);

        }
    }
