//   Copyright © 2015 by Comodo Group Inc.
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
//  
//  
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Goedel.Utilities;

namespace Goedel.Cryptography {

    // Having realized that all crypto applications invariably end up with nested
    // systems of crypto algorithm marshalling code, here is yet another set of 
    // wrapper classes.

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
                _CryptoCatalog = _CryptoCatalog ?? new CryptoCatalog();
                return _CryptoCatalog;
                }
            }



        /// <summary>The default digest algorithm.</summary>
        public CryptoAlgorithmID AlgorithmDigest { get; set; } = CryptoAlgorithmID.NULL;

        /// <summary>The default symmetric encryption algorithm.</summary>
        public CryptoAlgorithmID AlgorithmEncryption { get; set; } = CryptoAlgorithmID.NULL;

        /// <summary>The default message authentication code algorithm.</summary>
        public CryptoAlgorithmID AlgorithmMAC { get; set; } = CryptoAlgorithmID.NULL;

        /// <summary>The default asymmetric encryption algorithm.</summary>
        public CryptoAlgorithmID AlgorithmExchange { get; set; } = CryptoAlgorithmID.NULL;

        /// <summary>The default signature algorithm.</summary>
        public CryptoAlgorithmID AlgorithmSignature { get; set; } = CryptoAlgorithmID.NULL;


        /// <summary>
        /// Set undefined identifier components to default signature and digest.
        /// </summary>
        /// <param name="Base">The base id</param>
        /// <returns>The defaulted algorithm relative to the base.</returns>
        public CryptoAlgorithmID SignatureDefaults(CryptoAlgorithmID Base) => Base.Default(AlgorithmDigest, AlgorithmSignature);

        /// <summary>
        /// Set undefined identifier components to default exchange and encryption.
        /// </summary>
        /// <param name="Base">The base id</param>
        /// <returns>The defaulted algorithm relative to the base.</returns>
        public CryptoAlgorithmID EncryptionDefaults(CryptoAlgorithmID Base) => Base.Default(AlgorithmExchange, AlgorithmEncryption);


        CryptoAlgorithmID SetDefault(CryptoAlgorithmID Current, CryptoAlgorithm New, CryptoAlgorithmID ID,
                CryptoAlgorithmClass Class) {

            if (Current == CryptoAlgorithmID.NULL & (New.AlgorithmClass == Class)) {
                Current = ID;
                }
            return Current;
            }

        /// <summary>Map crypto identifier to crypto algorithm.</summary>
        public Dictionary<CryptoAlgorithmID, CryptoAlgorithm> Dictionary = 
            new Dictionary<CryptoAlgorithmID, CryptoAlgorithm>();

        /// <summary>
        /// Add a cryptographic algorithm provider to the catalog
        /// </summary>
        /// <param name="CryptoAlgorithm">Algorithm description</param>
        /// <returns>The catalog entry.</returns>
        public CryptoAlgorithm Add(CryptoAlgorithm CryptoAlgorithm) {
            var ID = CryptoAlgorithm.CryptoAlgorithmID;

            try {
                Dictionary.Add(ID, CryptoAlgorithm);



                AlgorithmDigest = SetDefault(AlgorithmDigest, CryptoAlgorithm, ID, CryptoAlgorithmClass.Digest);
                AlgorithmMAC = SetDefault(AlgorithmMAC, CryptoAlgorithm, ID, CryptoAlgorithmClass.MAC);
                AlgorithmEncryption = SetDefault(AlgorithmEncryption, CryptoAlgorithm, ID, CryptoAlgorithmClass.Encryption);
                AlgorithmSignature = SetDefault(AlgorithmSignature, CryptoAlgorithm, ID, CryptoAlgorithmClass.Signature);
                AlgorithmExchange = SetDefault(AlgorithmExchange, CryptoAlgorithm, ID, CryptoAlgorithmClass.Exchange);
                }
            catch {
                // already added, ignore.
                }

            return CryptoAlgorithm;
            }

        /// <summary>
        /// Add a cryptographic algorithm provider to the catalog
        /// </summary>
        /// <param name="CryptoAlgorithmID">CryptoAlgorithmID Identifier.</param>
        /// <param name="KeySize">Default algorithm key size.</param>
        /// <param name="AlgorithmClass">Algorithm type.</param>
        /// <param name="CryptoProviderFactory">Delegate returning the default crypto provider.</param>
        /// <returns>The catalog entry.</returns>
        public CryptoAlgorithm Add(
            CryptoAlgorithmID CryptoAlgorithmID,
            int KeySize,
            CryptoAlgorithmClass AlgorithmClass,
            CryptoProviderFactoryDelegate CryptoProviderFactory) {

            var CryptoAlgorithm = new CryptoAlgorithm(CryptoAlgorithmID, AlgorithmClass, CryptoProviderFactory, KeySize);
            Add(CryptoAlgorithm);
            return CryptoAlgorithm;

            }

        /// <summary>
        /// Return the length of the output data for the algorithm <paramref name="ID"/> in bytes.
        /// </summary>
        /// <param name="ID">The algorithm to return the output data length for.</param>
        /// <returns>The output data length in bytes.</returns>
        public int ResultInBytes(CryptoAlgorithmID ID) {
            var Found = Dictionary.TryGetValue(ID, out var Meta);
            if (Found) {
                return Meta.KeySize / 8;
                }
            return -1;

            }



        /// <summary>
        /// Get a cryptographic provider by combined algorithm identifier
        /// </summary>
        /// <param name="ID">Combined algorithm identifier.</param>
        /// <returns>Cryptographic provider if found or null otherwise.</returns>
        public CryptoProvider Get(CryptoAlgorithmID ID) {

            // Look for an exact match first implementing the combined ID
            var Found = Dictionary.TryGetValue(ID, out var Meta);
            if (Found) {
                return Meta.CryptoProviderFactory (Meta.KeySize, ID);
                }

            // If not successful, try to construct from a meta and a bulk algorithm
            Found = Dictionary.TryGetValue(ID.Meta(), out Meta);
            if (Found) {
                return Meta.CryptoProviderFactory (Meta.KeySize, ID.Bulk());

                }
            return null;
            }

        /// <summary>
        /// Get a cryptographic provider by algorithm identifier
        /// </summary>
        /// <param name="ID">Algorithm identifier</param>
        /// <returns>Cryptographic provider if found or null otherwise.</returns>
        public CryptoProviderDigest GetDigest(CryptoAlgorithmID ID) => Get(ID.DefaultBulk(AlgorithmDigest)) as CryptoProviderDigest;

        /// <summary>
        /// Get a cryptographic provider  by algorithm identifier
        /// </summary>
        /// <param name="ID">Algorithm identifier</param>
        /// <returns>Cryptographic provider if found or null otherwise.</returns>
        public CryptoProviderAuthentication GetAuthentication(CryptoAlgorithmID ID) => Get(ID.DefaultBulk(AlgorithmMAC)) as CryptoProviderAuthentication;

        /// <summary>
        /// Get a cryptographic provider  by algorithm identifier
        /// </summary>
        /// <param name="ID">Algorithm identifier</param>
        /// <returns>Cryptographic provider if found or null otherwise.</returns>
        public CryptoProviderEncryption GetEncryption(CryptoAlgorithmID ID) => Get(ID.DefaultBulk(AlgorithmEncryption)) as CryptoProviderEncryption;


        /// <summary>
        /// Returns a byte array with the specified number of random bits.
        /// </summary>
        /// <param name="Bits">Number of bits</param>
        /// <returns>A byte array with the specified number of bits.</returns>
        public static byte[] GetBits(int Bits) => GetBytes((Bits + 7) / 8);

        /// <summary>
        /// Returns a byte array with the specified number of random bytes.
        /// </summary>
        /// <param name="Bytes">Number of bytes</param>
        /// <returns>A byte array with the specified number of bytes.</returns>        
        public static byte[] GetBytes(int Bytes) => Platform.GetRandomBytes(Bytes);


        }
    /// <summary>
    /// Delegate to create a cryptographic provider with optional key size and/or
    /// bulk algorithm variants where needed.
    /// </summary>
    /// <param name="KeySize">Key size parameter (if needed).</param>
    /// <param name="BulkAlgorithmID">Algorithm identifier of bulk algorithm (if needed).</param>
    /// <returns></returns>
    public delegate CryptoProvider GetCryptoProviderGenerateDelegate(int KeySize, CryptoAlgorithmID BulkAlgorithmID);


    /// <summary>
    /// Delegate to create a cryptographic provider with optional key size and/or
    /// bulk algorithm variants where needed.
    /// </summary>
    /// <param name="Key">Reference to Key</param>
    /// <returns></returns>
    public delegate CryptoProvider GetCryptoProviderByHandleDelegate (KeyHandle Key);

    /// <summary>
    /// Base class for cryptography providers.
    /// </summary>
    public abstract class CryptoProvider {

        /// <summary>
        /// Return a CryptoAlgorithm structure with properties describing this provider.
        /// </summary>
        public virtual CryptoAlgorithm CryptoAlgorithm { get; }


        /// <summary>
        /// The type of algorithm
        /// </summary>
        public abstract CryptoAlgorithmClass AlgorithmClass { get; }

        /// <summary>
        /// The CryptoAlgorithmID Identifier.
        /// </summary>
        public abstract CryptoAlgorithmID CryptoAlgorithmID { get; }

        /// <summary>
        /// Default algorithm key or output size.
        /// </summary>
        public abstract int Size { get; }

        /// <summary>
        /// The UDF fingerprint of the key.
        /// </summary>
        public virtual string UDF  => null; 

        /// <summary>
        /// Return the provider key.
        /// </summary>
        public virtual KeyPair KeyPair {
            get => null;
            set { }
            }

        /// <summary>
        /// Create an encoder for a bulk algorithm and optional key wrap or exchange.
        /// This may be used to implement an encoder for signature or encryption but
        /// not both. To create a double encoder it is necessary to wrap one inside the
        /// other.
        /// </summary>

        /// <param name="Algorithm">The key wrap algorithm</param>
        /// <param name="Bulk">The bulk provider to use. If specified, the parameters from
        /// the specified provider will be used. Otherwise a new bulk provider will 
        /// be created and returned as part of the result.</param>
        /// <param name="OutputStream">Output stream</param>
        /// <returns>Instance describing the key agreement parameters.</returns>
        public abstract CryptoDataEncoder MakeEncoder(
                            CryptoProviderBulk Bulk = null,
                            CryptoAlgorithmID Algorithm = CryptoAlgorithmID.Default,
                            Stream OutputStream = null
                            );

        /// <summary>
        /// Complete processing at the end of an encoding or decoding operation
        /// </summary>
        /// <param name="CryptoData">The completion data.</param>
        public virtual void Complete (CryptoData CryptoData) {
            if (CryptoData.OutputStream is MemoryStream MemoryStream) {
                CryptoData.ProcessedData = MemoryStream.ToArray();
                }
            return;
            }

        /*
         * Convenience methods  
         */

        /// <summary>
        /// Convenience method to create a bulk encoder and apply it to
        /// the specified data. The data will be signed and/or encrypted
        /// according to the provider type.
        /// </summary>
        /// <param name="Data">Data to process</param>
        /// <param name="Algorithm">Bulk processing algorithm</param>
        /// <returns>The processed data.</returns>
        public virtual CryptoData Encode(
                    byte[] Data,
                    CryptoAlgorithmID Algorithm = CryptoAlgorithmID.Default
                    ) {

            var Encoder = MakeEncoder(Algorithm: Algorithm);
            Encoder.InputStream.Write(Data, 0, Data.Length);
            Encoder.Complete();
            return Encoder;
            }

        /// <summary>
        /// Convenience method to create a bulk encoder and apply it to
        /// the specified data. The data will be signed and/or encrypted
        /// according to the provider type.
        /// </summary>
        /// <param name="Text">Data to process</param>
        /// <param name="Algorithm">Bulk processing algorithm</param>
        /// <returns>The processed data.</returns>
        public virtual CryptoData Encode(
                    string Text,
                    CryptoAlgorithmID Algorithm = CryptoAlgorithmID.Default
                    ) {
            var Data = System.Text.Encoding.UTF8.GetBytes(Text);
            return Encode(Data, Algorithm);
            }

        }

    }
