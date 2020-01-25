using Goedel.Cryptography;

namespace Goedel.Mesh {

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



        ///<summary>Salt value for creating a ProfileMaster Encryption Key</summary>
        public const string MeshKeyMasterEncrypt = "mmm/ProfileMeshEncrypt";
        ///<summary>Salt value for creating a ProfileMaster Signature Key</summary>
        public const string MeshKeyMasterSign           = "mmm/ProfileMeshSign";


        ///<summary>Salt value for creating a ProfileDevice Encryption Key</summary>
        public const string MeshKeyDeviceEncrypt = "mmm/ProfileDeviceEncrypt";
        ///<summary>Salt value for creating a ProfileDevice Signature Key</summary>
        public const string MeshKeyDeviceSign           = "mmm/ProfileDeviceSign";
        ///<summary>Salt value for creating a ProfileDevice Authentication Key</summary>
        public const string MeshKeyDeviceAuthenticate   = "mmm/ProfileDeviceEscrow";


        ///<summary>Salt value for creating a ProfileAccount Encryption Key</summary>
        public const string MeshKeyAccountEncrypt = "mmm/ProfileAccountEncrypt";
        ///<summary>Salt value for creating a ProfileAccount Signature Key</summary>
        public const string MeshKeyAccountSign          = "mmm/ProfileAccountSign";
        ///<summary>Salt value for creating a ProfileAccount Authentication Key</summary>
        public const string MeshKeyAccountAuthenticate  = "mmm/ProfileAccountAuthenticate";

        // Group























        ///<summary>Salt value for creating a ActivationAccount Encryption Key</summary>
        public const string MeshKeyGroupEncrypt= "mmm/ProfileGroupEncrypt";
        ///<summary>Salt value for creating a ActivationAccount Signature Key</summary>
        public const string MeshKeyGroupSign = "mmm/ProfileGroupAccountSign";
        ///<summary>Salt value for creating a ActivationAccount Authentication  Key</summary>
        public const string MeshKeyGroupAuthenticate = "mmm/ProfileGroupAuthenticate";

        ///<summary>Salt value for creating a ActivationAccount Encryption Key</summary>
        public const string MeshKeyGroupEncryptActivation = "mmm/ProfileGroupEncryptActivation";
        ///<summary>Salt value for creating a ActivationAccount Signature Key</summary>
        public const string MeshKeyGroupSignActivation = "mmm/ProfileGroupAccountSignActivation";
        ///<summary>Salt value for creating a ActivationAccount Authentication  Key</summary>
        public const string MeshKeyGroupAuthenticateActivation = "mmm/ProfileGroupAuthenticateActivation";

        // Service

        ///<summary>Salt value for creating a ActivationAccount Encryption Key</summary>
        public const string MeshKeyServiceEncrypt = "mmm/ProfileServiceEncrypt";
        ///<summary>Salt value for creating a ActivationAccount Signature Key</summary>
        public const string MeshKeyServiceSign = "mmm/ProfileServiceAccountSign";
        ///<summary>Salt value for creating a ActivationAccount Authentication  Key</summary>
        public const string MeshKeyServiceAuthenticate = "mmm/ProfileServiceAuthenticate";



        ///<summary>Salt value for creating a ActivationDevice Encryption Key</summary>
        public const string MeshKeyDeviceEncryptActivation = "mmm/ActivationDeviceEncrypt";
        ///<summary>Salt value for creating a ActivationDevice Signature  Key</summary>
        public const string MeshKeyDeviceSignActivation = "mmm/ActivationDeviceSign";
        ///<summary>Salt value for creating a ActivationDevice Authentication Activation Key</summary>
        public const string MeshKeyDeviceAuthenticateActivation = "mmm/ActivationDeviceAuthenticate";


        ///<summary>Salt value for creating a ActivationAccount Encryption Key</summary>
        public const string MeshKeyAccountEncryptActivation = "mmm/ActivationAccountEncrypt";
        ///<summary>Salt value for creating a ActivationAccount Signature Key</summary>
        public const string MeshKeyAccountSignActivation = "mmm/ActivationAccountSign";
        ///<summary>Salt value for creating a ActivationAccount Authentication  Key</summary>
        public const string MeshKeyAccountAuthenticateActivation = "mmm/ActivationAccountAuthenticate";





        // Transaction related constants

        ///<summary>Transaction result tag Accept</summary>
        public const string TransactionResultAccept = "Accept";

        ///<summary>Transaction result tag Reject</summary>
        public const string TransactionResultReject = "Reject";

        ///<summary>Transaction result tag Pending</summary>
        public const string TransactionResultPending = "Pending";


        // CryptoAlgorithmID related constants and convenience functions

        ///<summary>The default encryption algorithm</summary>
        public const CryptoAlgorithmID DefaultAlgorithmEncryptID = CryptoAlgorithmID.Ed448;
        ///<summary>The default signature algorithm</summary>
        public const CryptoAlgorithmID DefaultAlgorithmSignID = CryptoAlgorithmID.Ed448;
        ///<summary>The default authentication algorithm</summary>
        public const CryptoAlgorithmID DefaultAlgorithmAuthenticateID = CryptoAlgorithmID.Ed448;

        /// <summary>
        /// Convenience function that returns the value <see cref="DefaultAlgorithmEncryptID"/> if
        /// <paramref name="cryptoAlgorithmID"/> is <see cref="CryptoAlgorithmID.Default"/> 
        /// and <paramref name="cryptoAlgorithmID"/>
        /// otherwise.
        /// </summary>
        /// <param name="cryptoAlgorithmID">The CryptoAlgorithmID to default.</param>
        /// <returns>The value <paramref name="cryptoAlgorithmID"/> with the
        /// specified substitution if the value is <see cref="CryptoAlgorithmID.Default"/>.</returns>
        public static CryptoAlgorithmID DefaultAlgorithmEncrypt(this CryptoAlgorithmID cryptoAlgorithmID) =>
            cryptoAlgorithmID.DefaultMeta(DefaultAlgorithmEncryptID);

        /// <summary>
        /// Convenience function that returns the value <see cref="DefaultAlgorithmSignID"/> if
        /// <paramref name="cryptoAlgorithmID"/> is <see cref="CryptoAlgorithmID.Default"/> 
        /// and <paramref name="cryptoAlgorithmID"/>
        /// otherwise.
        /// </summary>
        /// <param name="cryptoAlgorithmID">The CryptoAlgorithmID to default.</param>
        /// <returns>The value <paramref name="cryptoAlgorithmID"/> with the
        /// specified substitution if the value is <see cref="CryptoAlgorithmID.Default"/>.</returns>
        public static CryptoAlgorithmID DefaultAlgorithmSign(this CryptoAlgorithmID cryptoAlgorithmID) =>
            cryptoAlgorithmID.DefaultMeta(DefaultAlgorithmSignID);

        /// <summary>
        /// Convenience function that returns the value <see cref="DefaultAlgorithmAuthenticateID"/> if
        /// <paramref name="cryptoAlgorithmID"/> is <see cref="CryptoAlgorithmID.Default"/> 
        /// and <paramref name="cryptoAlgorithmID"/>
        /// otherwise.
        /// </summary>
        /// <param name="cryptoAlgorithmID">The CryptoAlgorithmID to default.</param>
        /// <returns>The value <paramref name="cryptoAlgorithmID"/> with the
        /// specified substitution if the value is <see cref="CryptoAlgorithmID.Default"/>.</returns>
        public static CryptoAlgorithmID DefaultAlgorithmAuthenticate(this CryptoAlgorithmID cryptoAlgorithmID) =>
            cryptoAlgorithmID.DefaultMeta(DefaultAlgorithmAuthenticateID);

        }
    }
