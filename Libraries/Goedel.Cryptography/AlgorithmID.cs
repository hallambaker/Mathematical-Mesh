using System.Collections.Generic;
using System.Security.Cryptography;

namespace Goedel.Cryptography {

    /// <summary>
    /// Extension class to manage OID and XML references.
    /// </summary>
    public static partial class AlgorithmID {

        /// <summary>
        /// Mapping of XML DigSig entries to CryptoAlgorithmID
        /// </summary>
        static readonly Dictionary<string, CryptoAlgorithmID> XMLToID =
            new Dictionary<string, CryptoAlgorithmID> {
                    {"http://www.w3.org/2001/04/xmldsig-more#rsa-sha256", CryptoAlgorithmID.RSASign |CryptoAlgorithmID.SHA_2_256 },
                    {"http://www.w3.org/2001/04/xmldsig-more#rsa-sha512", CryptoAlgorithmID.RSASign |CryptoAlgorithmID.SHA_2_512 },
                    {"http://www.w3.org/2001/04/xmlenc#aes128-cbc", CryptoAlgorithmID.AES128CBC },
                    {"http://www.w3.org/2001/04/xmlenc#aes256-cbc", CryptoAlgorithmID.AES256CBC },
                    {"http://www.w3.org/2001/04/xmlenc#kw-aes128", CryptoAlgorithmID.KW3394_AES128 },
                    {"http://www.w3.org/2001/04/xmlenc#kw-aes256", CryptoAlgorithmID.KW3394_AES256 },
                    {"http://www.w3.org/2009/xmlenc11#rsa-oaep", CryptoAlgorithmID.RSAExch },
                    {"http://www.w3.org/2001/04/xmlenc#rsa-1_5", CryptoAlgorithmID.RSAExch_P15 },
                    {"http://www.w3.org/2001/04/xmlenc#sha256", CryptoAlgorithmID.SHA_2_256 },
                    {"http://www.w3.org/2001/04/xmlenc#sha512", CryptoAlgorithmID.SHA_2_512 },
                    {"http://www.w3.org/2007/05/xmldsig-more#sha3-256", CryptoAlgorithmID.SHA_3_256 },
                    {"http://www.w3.org/2007/05/xmldsig-more#sha3-512", CryptoAlgorithmID.SHA_3_512 },
                    {"http://www.w3.org/2009/xmlenc11#aes128-gcm", CryptoAlgorithmID.AES128GCM },
                    {"http://www.w3.org/2009/xmlenc11#aes256-gcm", CryptoAlgorithmID.AES256GCM },
                    {"http://www.w3.org/2009/xmlenc11#dh-es", CryptoAlgorithmID.DH },
            };

        static readonly Dictionary<CryptoAlgorithmID, string> IDToXML =
            new Dictionary<CryptoAlgorithmID, string>();


        /// <summary>
        /// Mapping of OID entries to CryptoAlgorithmID. This is populated with values for 
        /// the common algorithms (SHA-2 / AES / RSA / HMAC. Additional values may be added
        /// by providers as they register additional algorithms.
        /// </summary>
        /// 
        static readonly Dictionary<string, CryptoAlgorithmID> OIDToID =
            new Dictionary<string, CryptoAlgorithmID> {
                    { PKIX.Constants.OIDS__sha256WithRSAEncryption, CryptoAlgorithmID.RSASign_SHA_2_256},
                    { PKIX.Constants.OIDS__sha512WithRSAEncryption, CryptoAlgorithmID.RSASign_SHA_2_512},
                    { PKIX.Constants.OIDS__rsaEncryption, CryptoAlgorithmID.RSAExch_P15},
                    { PKIX.Constants.OIDS__rsaOAEPEncryptionSET, CryptoAlgorithmID.RSAExch},
                    { PKIX.Constants.OIDS__id_aes128_cbc, CryptoAlgorithmID.AES128CBC},
                    { PKIX.Constants.OIDS__id_aes128_wrap, CryptoAlgorithmID.KW3394_AES128},
                    { PKIX.Constants.OIDS__id_aes128_gcm, CryptoAlgorithmID.AES128GCM},
                    { PKIX.Constants.OIDS__id_aes256_cbc, CryptoAlgorithmID.KW3394_AES256},
                    { PKIX.Constants.OIDS__id_aes256_wrap, CryptoAlgorithmID.AES256CBC},
                    { PKIX.Constants.OIDS__id_aes256_gcm, CryptoAlgorithmID.AES256GCM},
                    { PKIX.Constants.OIDS__id_hmacWithSHA256, CryptoAlgorithmID.HMAC_SHA_2_256},
                    { PKIX.Constants.OIDS__id_hmacWithSHA512, CryptoAlgorithmID.HMAC_SHA_2_512},
                    { PKIX.Constants.OIDS__id_sha256, CryptoAlgorithmID.SHA_2_256},
                    { PKIX.Constants.OIDS__id_sha512, CryptoAlgorithmID.SHA_2_512}

            };

        static readonly Dictionary<CryptoAlgorithmID, HashAlgorithmName> IDtoHashAlgorithmName =
            new Dictionary<CryptoAlgorithmID, HashAlgorithmName> {
                    { CryptoAlgorithmID.SHA_1_DEPRECATED, HashAlgorithmName.SHA1},
                    { CryptoAlgorithmID.SHA_2_256, HashAlgorithmName.SHA256},
                    { CryptoAlgorithmID.SHA_2_512, HashAlgorithmName.SHA512}
                };

        /// <summary>
        /// Calculate the digest of <paramref name="Input"/> using digest <paramref name="CryptoAlgorithmID"/>.
        /// </summary>
        /// <param name="CryptoAlgorithmID">The digest algorithm to use.</param>
        /// <param name="Input">The data to be digested.</param>
        /// <returns>The digest value.</returns>
        static public byte[] GetDigest(this CryptoAlgorithmID CryptoAlgorithmID, byte[] Input) {
            var Provider = CryptoCatalog.Default.GetDigest(CryptoAlgorithmID);
            return Provider.ProcessData(Input);

            }


        static readonly Dictionary<CryptoAlgorithmID, string> IDToOID =
            new Dictionary<CryptoAlgorithmID, string>();


        static AlgorithmID() {

            foreach (var Entry in XMLToID) {
                IDToXML.Add(Entry.Value, Entry.Key);
                }
            foreach (var Entry in OIDToID) {
                IDToOID.Add(Entry.Value, Entry.Key);
                }
            }


        /// <summary>
        /// Add an algorithm entry. Note this is not thread safe and is only intended to be 
        /// called during class library initialization.
        /// </summary>
        /// <param name="ID">CryptoAlgorithmID Identifier</param>
        /// <param name="OID">OID</param>
        /// <param name="XML">XML Signature and Encryption algorithm identifier</param>
        public static void Add(CryptoAlgorithmID ID, string OID = null, string XML = null) {
            if (OID != null) {
                IDToOID.Add(ID, OID);
                OIDToID.Add(OID, ID);
                }
            if (XML != null) {
                IDToXML.Add(ID, XML);
                XMLToID.Add(XML, ID);
                }
            }


        /// <summary>
        /// Get the CryptoAlgorithmID corresponding to an XML DigSig URL
        /// </summary>
        /// <param name="id">XML Signature and Encryption algorithm identifier</param>
        /// <returns>Algorithm Identifier</returns>
        public static CryptoAlgorithmID FromXMLID(this string id) {
            var Found = XMLToID.TryGetValue(id, out var Result);
            return Found ? Result : CryptoAlgorithmID.NULL;
            }


        /// <summary>
        /// Get the XML DigSig URL corresponding to a CryptoAlgorithmID
        /// </summary>
        /// <param name="id">Algorithm Identifier</param>
        /// <returns>XML Signature and Encryption algorithm identifier</returns>
        public static string ToXMLID(this CryptoAlgorithmID id) {
            var Found = IDToXML.TryGetValue(id, out var Result);
            return Found ? Result : null;
            }

        /// <summary>
        /// Get the CryptoAlgorithmID corresponding to an XML DigSig URL
        /// </summary>
        /// <param name="id">XML Signature and Encryption algorithm identifier</param>
        /// <returns>Algorithm Identifier</returns>
        public static CryptoAlgorithmID FromOID(this string id) {
            var Found = OIDToID.TryGetValue(id, out var Result);
            return Found ? Result : CryptoAlgorithmID.NULL;
            }

        /// <summary>
        /// Get the XML DigSig URL corresponding to a CryptoAlgorithmID
        /// </summary>
        /// <param name="id">Algorithm Identifier</param>
        /// <returns>XML Signature and Encryption algorithm identifier</returns>
        public static string ToOID(this CryptoAlgorithmID id) {
            var Found = IDToOID.TryGetValue(id, out var Result);
            return Found ? Result : null;
            }


        /// <summary>
        /// Get the .Net Standard Hash algorithm name.
        /// </summary>
        /// <param name="id">The Goedel Algorithm identifier.</param>
        /// <returns>The corresponding .Net algorithm name.</returns>
        public static HashAlgorithmName ToHashAlgorithmName(this CryptoAlgorithmID id) {
            IDtoHashAlgorithmName.TryGetValue(id.Bulk(), out var Result);
            return Result;
            }

        }
    }
