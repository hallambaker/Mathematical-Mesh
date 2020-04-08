using Goedel.Cryptography;

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
    /// Collected constants used in the Mathematical Mesh
    /// </summary>
    public static class Constants {

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
