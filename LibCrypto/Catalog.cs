//Sample license text.
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Goedel.LibCrypto {

    // Having realized that all crypto applications invariably end up with nested
    // systems of crypto algorithm martialing code, here is yet another set of 
    // wrapper classes.

    //

    /// <summary>
    /// Cryptographic Algorithm Identifiers.
    /// </summary>
    public enum CryptoAlgorithmID {
        ///<summary>Null algorithm</summary>
        NULL,

        /// <summary>
        /// SHA1 
        /// </summary>
        SHA_1_DEPRECATED,

        /// <summary>
        /// SHA2 256 bit
        /// </summary>
        SHA_2_256,

        /// <summary>
        /// SHA2 512 bit
        /// </summary>
        SHA_2_512,

        /// <summary>
        /// SHA3 256 bit
        /// </summary>
        SHA_3_256,

        /// <summary>
        /// SHA3 512 bit
        /// </summary>
        SHA_3_512,

        // AES modes

        /// <summary>
        /// AES 128 bit in CBC mode
        /// </summary>
        AES128CBC,
        
        /// <summary>
        /// AES 256 bit in CBC mode
        /// </summary>
        AES256CBC,

        /// <summary>
        /// AES 128 bit in Cipher Text Stealing (CTS) mode
        /// </summary>
        AES128CTS,  // NYI

        /// <summary>
        /// AES 256 bit in Cipher Text Stealing (CTS) mode
        /// </summary>
        AES256CTS, // NYI

        // HMAC Modes

        /// <summary>
        /// HMAC SHA 2 with 256 bit key.
        /// </summary>
        HMAC_SHA_2_256,

        /// <summary>
        /// HMAC SHA 2 with 512 bit key.
        /// </summary>
        HMAC_SHA_2_512,


        // Public Key Signatgure

        /// <summary>
        /// RSA Signature with 2048 bit key.
        /// </summary>
        RSASign2048,
        
        /// <summary>
        /// RSA Signature with 4096 bit key.
        /// </summary>
        RSASign4096,

        /// <summary>
        /// Elliptic Curve DSA with curve P256
        /// </summary>
        ECDSA_P256,

        /// <summary>
        /// Elliptic Curve DSA with curve P521
        /// </summary>
        ECDSA_P521,


        //CFRGSign255,
        //CFRGSign448,

        // Public Key Exchange

        /// <summary>
        /// RSA Encryption with 2048 bit key using OAEP padding.
        /// </summary>
        RSAExch2048,

        /// <summary>
        /// RSA Encryption with 4096 bit key using OAEP padding.
        /// </summary>
        RSAExch4096,

        /// <summary>
        /// RSA Encryption with 2048 bit key using PKCS#1.5 padding.
        /// </summary>
        RSAExch2048_P15,

        /// <summary>
        /// RSA Encryption with 4096 bit key using PKCS#1.5 padding.
        /// </summary>
        RSAExch4096_P15,

        /// <summary>
        /// Elliptic Curve DH with curve P256
        /// </summary>
        ECDH_P256,

        /// <summary>
        /// Elliptic Curve DH with curve P521
        /// </summary>
        ECDH_P521,


        //CFRGExch255,
        //CFRGExch448,

        /// <summary>
        /// Count of the number of built-in algorithms 
        /// </summary>
        AlgorithmCount,

        
        // Only flags should be deflared after this:

        /// <summary>
        /// Flag for CBC mode
        /// </summary>
        ModeCBC,

        /// <summary>
        /// Flag for Cipher Text Stealling Mode
        /// </summary>
        ModeCTS,

        /// <summary>
        /// Flag for Galois Counter Mode
        /// </summary>
        ModeGCM
        
        
        
        }

    /// <summary>
    /// Defines levels of key protection to be applied.
    /// </summary>
    public enum KeySecurity {
        /// <summary>
        /// Key is a master key and will be stored in a key container marked 
        /// as archivable and user protected. Master keys SHOULD be deleted after 
        /// being escrowed and recovery verified.
        /// </summary>
        Master,

        /// <summary>
        /// Key is an administration key and will be  stored in a key container marked as non 
        /// exportable and user protected.
        /// </summary>
        Admin,

        /// <summary>
        /// Key is a device key and will be  stored in a key container bound to 
        /// the current machine that cannot be exported or archived.
        /// </summary>
        Device,

        /// <summary>
        /// Key is temporary and cannot be exported or stored.
        /// </summary>
        Ephemeral,

        /// <summary>
        /// Key may be exported.
        /// </summary>
        Exportable
        }

    /// <summary>
    /// Algorithm classes.
    /// </summary>
    public enum CryptoAlgorithmClass {

        /// <summary>
        /// Unspecified.
        /// </summary>
        NULL,

        /// <summary>
        /// Digest algorithm.
        /// </summary>
        Digest,

        /// <summary>
        /// Message Authentication Code.
        /// </summary>
        MAC,

        /// <summary>
        /// Symmetric Encryption.
        /// </summary>
        Encryption,

        /// <summary>
        /// Digital Signature
        /// </summary>
        Signature,

        /// <summary>
        /// Asymmetric Encryption.
        /// </summary>
        Exchange
        }

    /// <summary>
    /// Manages a cryptographic catalog and associated key management functions.
    /// </summary>
    public class CryptoCatalog {

        static CryptoCatalog _CryptoCatalog;

        /// <summary>
        /// Returns the default catalog of suites.
        /// </summary>
        public static CryptoCatalog Default {
            get {
                if (_CryptoCatalog == null) _CryptoCatalog = new CryptoCatalog();
                return _CryptoCatalog;
                }
            }


        private CryptoAlgorithmID _AlgorithmDigest = CryptoAlgorithmID.NULL;
        /// <summary>
        /// The default digest algorithm.
        /// </summary>
        public CryptoAlgorithmID AlgorithmDigest {
            get { return _AlgorithmDigest; }
            set { _AlgorithmDigest = value; }
            }
        private CryptoAlgorithmID _AlgorithmEncryption = CryptoAlgorithmID.NULL;
        /// <summary>
        /// The default symmetric encryption algorithm.
        /// </summary>
        public CryptoAlgorithmID AlgorithmEncryption {
            get { return _AlgorithmEncryption; }
            set { _AlgorithmEncryption = value; }
            }
        private CryptoAlgorithmID _AlgorithmMAC = CryptoAlgorithmID.NULL;
        /// <summary>
        /// The default message authentication code algorithm.
        /// </summary>
        public CryptoAlgorithmID AlgorithmMAC {
            get { return _AlgorithmMAC; }
            set { _AlgorithmMAC = value; }
            }
        private CryptoAlgorithmID _AlgorithmExchange = CryptoAlgorithmID.NULL;
        /// <summary>
        /// The default asymmetric encryption algorithm.
        /// </summary>
        public CryptoAlgorithmID AlgorithmExchange {
            get { return _AlgorithmExchange; }
            set { _AlgorithmExchange = value; }
            }
        private CryptoAlgorithmID _AlgorithmSignature = CryptoAlgorithmID.NULL;
        /// <summary>
        /// The default signature algorithm.
        /// </summary>
        public CryptoAlgorithmID AlgorithmSignature {
            get { return _AlgorithmSignature; }
            set { _AlgorithmSignature = value; }
            }

        void SetDefault(ref CryptoAlgorithmID Current, CryptoAlgorithm New, CryptoAlgorithmID ID,
                CryptoAlgorithmClass Class) {

            if (Current == CryptoAlgorithmID.NULL & (New.AlgorithmClass == Class)) {
                Current = ID;
                }
            }
        
        /// <summary>
        /// Array containing the registered algorithms.
        /// </summary>
        public CryptoAlgorithm[] Algorithms = new CryptoAlgorithm[(int)CryptoAlgorithmID.AlgorithmCount];

        /// <summary>
        /// Create and populate a new catalog of cryptographic algorithms including the 
        /// default providers for all the standard algorithms.
        /// </summary>
        public CryptoCatalog() {
            // Load thje default algorithms first
            Add(new CryptoProviderSHA2_512());
            Add(new CryptoProviderHMACSHA2_512());
            Add(new CryptoProviderEncryptAES(256));
            Add(new CryptoProviderSignatureRSA(2048));
            Add(new CryptoProviderExchangeRSA(2048));

            // The rest
            Add(new CryptoProviderSHA2_256());
            Add(new CryptoProviderHMACSHA2_256());
            Add(new CryptoProviderEncryptAES(128));
            
            //Add(new CryptoProviderEncryptAES(128, CipherMode.CTS));
            //Add(new CryptoProviderEncryptAES(256, CipherMode.CTS));

            Add(new CryptoProviderSignatureRSA(4096));       
            Add(new CryptoProviderExchangeRSA(4096));
            Add(new CryptoProviderExchangeRSAPKCS(2048));
            Add(new CryptoProviderExchangeRSAPKCS(4096));

            }

        /// <summary>
        /// Add a cryptographic algorithm provider to the catalog
        /// </summary>
        /// <param name="CryptoProvider"></param>
        public void Add(CryptoProvider CryptoProvider) {
            var ID = CryptoProvider.CryptoAlgorithmID;
            var Slot = (int)ID;
            var CryptoAlgorithm = CryptoProvider.CryptoAlgorithm;
            if (CryptoAlgorithm == null) {
                CryptoAlgorithm = new CryptoAlgorithm(CryptoProvider);
                }

            // If the array isn't big enough, then grow it
            if (Slot >= Algorithms.Length) {
                Array.Resize(ref Algorithms, Slot + 1);
                }

            Algorithms[(int)Slot] = CryptoAlgorithm;

            SetDefault(ref _AlgorithmDigest, CryptoAlgorithm, ID, CryptoAlgorithmClass.Digest);
            SetDefault(ref _AlgorithmMAC, CryptoAlgorithm, ID, CryptoAlgorithmClass.MAC);
            SetDefault(ref _AlgorithmEncryption, CryptoAlgorithm, ID, CryptoAlgorithmClass.Encryption);
            SetDefault(ref _AlgorithmSignature, CryptoAlgorithm, ID, CryptoAlgorithmClass.Signature);
            SetDefault(ref _AlgorithmExchange, CryptoAlgorithm, ID, CryptoAlgorithmClass.Exchange);
            }

        CryptoAlgorithmID OrDefault(CryptoAlgorithmID Value, CryptoAlgorithmID Default) {
            return Value == CryptoAlgorithmID.NULL ? Default : Value;
            }

        /// <summary>
        /// Get a cryptographic provider by algorithm identifier
        /// </summary>
        /// <param name="ID">Principal algorithm identifier.</param>
        /// <returns>Cryptographic provider if found or null otherwise.</returns>
        public CryptoProvider Get(CryptoAlgorithmID ID) {
            var Index = (int)ID;
            var Entry = Algorithms[Index];
            return Entry.GetCryptoProvider(Entry.KeySize, CryptoAlgorithmID.NULL);
            }


        /// <summary>
        /// Get a cryptographic provider by algorithm identifier
        /// </summary>
        /// <param name="ID">Principal algorithm identifier.</param>
        /// <param name="Bulk">Bulk algorithm identifier.</param>
        /// <returns>Cryptographic provider if found or null otherwise.</returns>
        public CryptoProvider Get(CryptoAlgorithmID ID, CryptoAlgorithmID Bulk) {
            var Entry = Algorithms[(int)ID];
            return Entry.GetCryptoProvider(Entry.KeySize, Bulk);
            }

        /// <summary>
        /// Get a cryptographic provider by algorithm identifier
        /// </summary>
        /// <param name="ID">Algorithm identifier</param>
        /// <returns>Cryptographic provider if found or null otherwise.</returns>
        public CryptoProviderDigest GetDigest(CryptoAlgorithmID ID) {

            return Get(OrDefault(ID, AlgorithmDigest)) as CryptoProviderDigest;
            }

        /// <summary>
        /// Get a cryptographic provider  by algorithm identifier
        /// </summary>
        /// <param name="ID">Algorithm identifier</param>
        /// <returns>Cryptographic provider if found or null otherwise.</returns>
        public CryptoProviderAuthentication GetAuthentication(CryptoAlgorithmID ID) {
        return Get(OrDefault(ID, AlgorithmMAC)) as CryptoProviderAuthentication;
            }

        /// <summary>
        /// Get a cryptographic provider  by algorithm identifier
        /// </summary>
        /// <param name="ID">Algorithm identifier</param>
        /// <returns>Cryptographic provider if found or null otherwise.</returns>
        public CryptoProviderEncryption GetEncryption(CryptoAlgorithmID ID) {
            var Result = Get(ID);
            return Get(OrDefault(ID, AlgorithmEncryption)) as CryptoProviderEncryption;
            }

        /// <summary>
        /// Get a cryptographic provider  by algorithm identifier
        /// </summary>
        /// <param name="ID">Algorithm identifier</param>
        /// <returns>Cryptographic provider if found or null otherwise.</returns>
        public CryptoProviderAsymmetric GetAsymmetric(CryptoAlgorithmID ID) {
            var Result = Get(ID);
            return Result as CryptoProviderAsymmetric;
            }

        /// <summary>
        /// Get a cryptographic provider by algorithm identifier
        /// </summary>
        /// <param name="ID">Algorithm identifier</param>
        /// <returns>Cryptographic provider if found or null otherwise.</returns>
        public CryptoProviderSignature GetSignature(CryptoAlgorithmID ID) {
            return Get(OrDefault(ID, AlgorithmSignature)) as CryptoProviderSignature;
            }

        /// <summary>
        /// Get a signature provider by algorithm identifier
        /// </summary>>
        /// <param name="Signature">Signature algorithm identifier.</param>
        /// <param name="Digest">Digest algorithm identifer.</param>
        /// <returns>Cryptographic provider if found or null otherwise.</returns>
        public CryptoProviderSignature GetSignature(CryptoAlgorithmID Signature, 
                    CryptoAlgorithmID Digest) {
            return Get(Signature, Digest) as CryptoProviderSignature;
            }

        /// <summary>
        /// Get a signature provider by algorithm identifier
        /// </summary>>
        /// <param name="Signature">Signature algorithm identifier.</param>
        /// <param name="Digest">Digest algorithm identifer.</param>
        /// <returns>Cryptographic provider if found or null otherwise.</returns>
        public CryptoProviderExchange GetExchange(CryptoAlgorithmID Signature,
                    CryptoAlgorithmID Digest) {
            return Get(Signature, Digest) as CryptoProviderExchange;
            }

        /// <summary>
        /// Get a signature provider by key fingerprint.
        /// </summary>
        /// <param name="UDF">Fingerprint of key</param>
        /// <returns>Cryptographic provider if found or null otherwise.</returns>
        public CryptoProviderSignature GetSignature (string UDF) {
            var Key = KeyPair.FindLocal(UDF);
            if (Key == null) return null;
            return Key.SignatureProvider;
            }

        /// <summary>
        /// Get an exchange provider by key fingerprint.
        /// </summary>
        /// <param name="UDF">Fingerprint of key</param>
        /// <returns>Cryptographic provider if found or null otherwise.</returns>
        public CryptoProviderExchange GetExchange(string UDF) {
            var Key = KeyPair.FindLocal(UDF);
            if (Key == null) return null;
            return Key.ExchangeProviderEncrypt;
            }

        /// <summary>
        /// Get a cryptographic provider  by algorithm identifier
        /// </summary>
        /// <param name="ID">Algorithm identifier</param>
        /// <returns>Cryptographic provider if found or null otherwise.</returns>
        public CryptoProviderExchange GetExchange(CryptoAlgorithmID ID) {
            return Get(OrDefault(ID, AlgorithmExchange)) as CryptoProviderExchange;
            }


        static RNGCryptoServiceProvider _RNGCryptoServiceProvider;
        
        /// <summary>
        /// The random number generator associated with the catalog.
        /// </summary>
        public static RNGCryptoServiceProvider RNGCryptoServiceProvider {
            get {
                if (_RNGCryptoServiceProvider == null) _RNGCryptoServiceProvider = new RNGCryptoServiceProvider();
                return _RNGCryptoServiceProvider;
                }
            set {
                _RNGCryptoServiceProvider = value;
                }
            }

        /// <summary>
        /// Returns a byte array with the specified number of random bits.
        /// </summary>
        /// <param name="Bits">Number of bits</param>
        /// <returns>A byte array with the specified number of bits.</returns>
        public static byte[] GetBits(int Bits) {
            return GetBytes((Bits + 7) / 8);
            }

        /// <summary>
        /// Returns a byte array with the specified number of random bytes.
        /// </summary>
        /// <param name="Bytes">Number of bytes</param>
        /// <returns>A byte array with the specified number of bytess.</returns>        
        public static byte[] GetBytes(int Bytes) {
            var Data = new byte[Bytes];
            RNGCryptoServiceProvider.GetBytes(Data);
            return Data;
            }


        }

    /// <summary>
    /// 
    /// </summary>
    public class CryptoAlgorithm {

        CryptoAlgorithmID _CryptoAlgorithmID;

        /// <summary>
        /// The enumerated cryptographic algorithm identifier.
        /// </summary>
        public CryptoAlgorithmID CryptoAlgorithmID {
            get { return _CryptoAlgorithmID; }
            }

        /// <summary>
        /// .NET Framework name
        /// </summary>
        public string Name {
            get { return _Name; }
            }
        private string _Name;


        
        /// <summary>
        /// Return the type of algorithm.
        /// </summary>
        public CryptoAlgorithmClass AlgorithmClass {
            get { return _AlgorithmClass; }
            set { _AlgorithmClass = value; }
            }
        CryptoAlgorithmClass _AlgorithmClass;

        /// <summary>
        /// ASN.1 Object Identifier
        /// </summary>
        public string OID {
            get { return _OID; }
            }
        private string _OID;

        /// <summary>
        /// Default algorithm key  or output size.
        /// </summary>
        public int KeySize {
            get { return _KeySize; }
            }
        private int _KeySize;
        
        /// <summary>
        /// Returns the default crypto provider.
        /// </summary>


        public GetCryptoProvider GetCryptoProvider {
            get { return _GetCryptoProvider; }
            }
        private GetCryptoProvider _GetCryptoProvider;

        /// <summary>
        /// JSON Key Type
        /// </summary>
        public string JSON_kty {
            get { return _JSON_kty; }
            }
        private string _JSON_kty;
        
       
        /// <summary>
        /// JSON Key Use
        /// </summary>
        public string JSON_use {
            get { return _JSON_use; }
            }
        private string _JSON_use;

        /// <summary>
        /// JSON Algorithm Identifier. NB, not all algorithms have a JSON
        /// algorithm identifier.
        /// </summary>
        public string JSON_alg {
            get { return _JSON_alg; }
            }
        private string _JSON_alg;

        /// <summary>
        /// 
        /// </summary>
        public string XML {
            get { return _XML; }
            }
        private string _XML;


        /// <summary>
        /// Create an instance with the specified property values.
        /// </summary>
        /// <param name="CryptoAlgorithmID">CryptoAlgorithmID Identifier.</param>
        /// <param name="Name">.NET Framework name.</param>
        /// <param name="KeySize">Default algorithm key size.</param>
        /// <param name="JSON_alg">JSON Algorithm Identifier.</param>
        /// <param name="JSON_kty">JSON Key type.</param>
        /// <param name="JSON_use">JSON Key Use.</param>
        /// <param name="XML">XML algorithm identifier.</param>
        /// <param name="AlgorithmClass">Algorithm type.</param>
        /// <param name="GetCryptoProvider">Delegate returning the default crypto provider.</param>
        public CryptoAlgorithm(
                    CryptoAlgorithmID CryptoAlgorithmID,
                    string Name,
                    int KeySize,
                    string JSON_kty,
                    string JSON_use,
                    string JSON_alg,
                    string XML,
                    CryptoAlgorithmClass AlgorithmClass,
                    GetCryptoProvider GetCryptoProvider) {
             _CryptoAlgorithmID = CryptoAlgorithmID;
            _Name = Name;
            _OID = CryptoConfig.MapNameToOID(Name);
            _GetCryptoProvider = GetCryptoProvider;
            _KeySize = KeySize;
            _JSON_alg = JSON_alg;
            _JSON_use = JSON_use;
            _JSON_kty = JSON_kty;
            _XML = XML;
            _AlgorithmClass = AlgorithmClass;
            }

        /// <summary>
        /// Create an instance from the public properties of the specified CryptoProvider.
        /// </summary>
        /// <param name="CryptoProvider">Template from which to take the properties.</param>
        public CryptoAlgorithm(CryptoProvider CryptoProvider) {
            this._Name = CryptoProvider.Name;
            this._OID = CryptoConfig.MapNameToOID(Name);
            this._GetCryptoProvider = CryptoProvider.GetCryptoProvider;
            this._KeySize = CryptoProvider.Size;
            _JSON_use = CryptoProvider.JSONKeyUse;
            _JSON_kty = CryptoProvider.JSONKeyType;
            _AlgorithmClass = CryptoProvider.AlgorithmClass;
            }

        }

    /// <summary>
    /// Delegate to create a cryptographic provider with optional key size and/or
    /// bulk algorithm variants where needed.
    /// </summary>
    /// <param name="KeySize">Key size parameter (if needed).</param>
    /// <param name="BulkAlgorithmID">Algorithm identifier of bulk algorithm (if needed).</param>
    /// <returns></returns>
    public delegate CryptoProvider GetCryptoProvider (int KeySize, CryptoAlgorithmID BulkAlgorithmID);

    /// <summary>
    /// Base class for cryptography providers.
    /// </summary>
    public abstract class CryptoProvider {

        /// <summary>
        /// Return a CryptoAlgorithm structure with properties describing this provider.
        /// </summary>
        public virtual CryptoAlgorithm CryptoAlgorithm {
            get { return null; }
            }

        /// <summary>
        /// The type of algorithm
        /// </summary>
        public abstract CryptoAlgorithmClass AlgorithmClass { get; }

        /// <summary>
        /// The CryptoAlgorithmID Identifier.
        /// </summary>
        public abstract CryptoAlgorithmID CryptoAlgorithmID { get;  }

        /// <summary>
        /// CryptoAlgorithmID Identifier.
        /// </summary>
        public abstract string Name { get;  }

        /// <summary>
        /// JSON Algorithm Name.
        /// </summary>
        public abstract string JSONName { get;  }

        /// <summary>
        /// JSON Key type.
        /// </summary>
        public virtual string JSONKeyType { get { return null; } }

        /// <summary>
        /// JSON Key use.
        /// </summary>
        public virtual string JSONKeyUse { get { return null; } }


        /// <summary>
        /// Default algorithm key or output size.
        /// </summary>
        public abstract int Size { get;  }
        
        /// <summary>
        /// Returns the default crypto provider.
        /// </summary>
        public abstract GetCryptoProvider GetCryptoProvider { get;  }

        /// <summary>
        /// ASN.1 Object Identifier.
        /// </summary>
        public virtual string OID {
            get {
                return CryptoConfig.MapNameToOID(Name);
                }
            }

        /// <summary>
        /// The UDF fingerprint of the key.
        /// </summary>
        public virtual string UDF {
            get { return null; }
            }


        /// <summary>
        /// Return the provider key.
        /// </summary>
        public virtual KeyPair KeyPair {
            get { return null; }
            set { }
            }




        }

    }
