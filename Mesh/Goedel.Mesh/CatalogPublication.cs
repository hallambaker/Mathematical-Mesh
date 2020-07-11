using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;

namespace Goedel.Mesh {


    #region // The data classes CatalogMember, CatalogedMember
    /// <summary>
    /// Device catalog. Describes the members of a Mesh Group.
    /// </summary>
    public class CatalogPublication : Catalog<CatalogedPublication> {

        ///<summary>The canonical label for the catalog</summary>
        public const string Label = "mmm_Publication";

        ///<summary>The catalog label</summary>
        public override string ContainerDefault => Label;

        /// <summary>
        /// Constructor for a catalog named <paramref name="storeName"/> in directory
        /// <paramref name="directory"/> using the cryptographic parameters <paramref name="cryptoParameters"/>
        /// and key collection <paramref name="keyCollection"/>.
        /// </summary>
        /// <param name="create">Create a new persistence store on disk if it does not already exist.</param>
        /// <param name="decrypt">Attempt to decrypt the contents of the catalog if encrypted.</param>
        /// <param name="directory">The directory in which the catalog persistence container is stored.</param>
        /// <param name="storeName">The catalog persistence container file name.</param>
        /// <param name="cryptoParameters">The default cryptographic enhancements to be applied to container entries.</param>
        /// <param name="keyCollection">The key collection to be used to resolve keys when reading entries.</param>
        public CatalogPublication(
                    string directory,
                    string storeName = null,
                    CryptoParameters cryptoParameters = null,
                    IKeyCollection keyCollection = null,
                    bool decrypt = true,
                    bool create = true) :
            base(directory, storeName ?? Label,
                        cryptoParameters, keyCollection, decrypt: decrypt, create: create) {
            }

        }




    #endregion


    public partial class CatalogedPublication {

        ///<summary>The primary key.</summary>
        public override string _PrimaryKey => ID;

        ///<summary>Base constructor for deserialization.</summary>
        public CatalogedPublication() { }

        /// <summary>
        /// Construct an instance with PIN <paramref name="pin"/>.
        /// </summary>
        /// <param name="pin">The pin value as a UDF.</param>
        public CatalogedPublication(string pin) {
            ID = UDF.SymetricKeyId(pin);
            Authenticator = GetServiceAuthenticator(pin);
            }

        /// <summary>
        /// Get the service authenticator key using a HKDF function on <paramref name="key"/>.
        /// </summary>
        /// <param name="key">A UDF symmetric key value</param>
        /// <returns>The authenticator key</returns>
        public static string GetServiceAuthenticator(
                    string key) => UDF.SymmetricKeyHkdf(key, Constants.ServiceAuthenticatorInfo);

        /// <summary>
        /// Get the device authenticator key using a HKDF function on <paramref name="key"/>.
        /// </summary>
        /// <param name="key">A UDF symmetric key value</param>
        /// <returns>The authenticator key</returns>
        public static string GetDeviceAuthenticator(
            string key) => UDF.SymmetricKeyHkdf(key, Constants.DeviceAuthenticatorInfo);


        /// <summary>
        /// Get a service authenticator value for using an HMAC function on the data
        /// <paramref name="account"/> using the key <paramref name="key"/>.
        /// </summary>
        /// <param name="account">The account to authenticate</param>
        /// <param name="key">A UDF symmetric key value</param>
        /// <returns>The authenticator value</returns>
        public static string AuthenticateService(
                    string account,
                    string key) => Authenticate(account, GetServiceAuthenticator(key));

        /// <summary>
        /// Get a device authenticator value for using an HMAC function on the data
        /// <paramref name="account"/> using the key <paramref name="key"/>.
        /// </summary>
        /// <param name="account">The account to authenticate</param>
        /// <param name="key">A UDF symmetric key value</param>
        /// <returns>The authenticator value</returns>
        public static string AuthenticateDevice(
                string account,
                string key) => Authenticate(account, GetDeviceAuthenticator(key));


        /// <summary>
        /// Verify a service authenticator value <paramref name="value"/> against the
        /// value generated using an HMAC function on the data
        /// <paramref name="account"/> using the class Authenticator property
        /// as the key.
        /// </summary>
        /// <param name="value">The test value.</param>
        /// <param name="account">The account to authenticate</param>
        /// <param name="length">The minimum match length (default is 125 bits)</param>
        /// <returns>The authenticator value</returns>
        public bool VerifyService(
            string account,
            string value,
            int length=125) => Verify(account, Authenticator, value, length);


        static string Authenticate(string account, string key) =>
            UDF.SymmetricKeyMac(account.ToUTF8(), key,
                algorithm: CryptoAlgorithmId.HMAC_SHA_2_512);

        /// <summary>
        /// Verify a MAC value <paramref name="value"/> against the
        /// value generated using an HMAC function on the data
        /// <paramref name="account"/> using the key <paramref name="key"/>.
        /// </summary>
        /// <param name="value">The test value.</param>
        /// <param name="key">The authentication key</param>
        /// <param name="account">The account to authenticate</param>
        /// <param name="length">The minimum match length (default is 125 bits)</param>
        /// <returns>The authenticator value</returns>
        public static bool Verify(string account, string key, string value, int length) =>
            UDF.SymmetricKeyVerifyMac(value, account.ToUTF8(), key, length,
                algorithm: CryptoAlgorithmId.HMAC_SHA_2_512);


        }





    }
