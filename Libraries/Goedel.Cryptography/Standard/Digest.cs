#region // Copyright
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

using System.IO;
using System.Security.Cryptography;

using Goedel.Cryptography.Algorithms;
using Goedel.Utilities;

namespace Goedel.Cryptography.Standard {

    /// <summary>
    /// <para>Base class for all cryptographic hash providers.</para>
    /// 
    /// <para>Provides utility and convenience functions that are employed in derived
    /// classes. This provides consistency when using either the built in .NET
    /// providers or those from other sources.</para>
    /// 
    /// <para>Unlike the .NET API, the wrapper provider completely conceals the details 
    /// of the cryptographic algorithm implementation. It is not necessary to 
    /// observe block boundaries when using the TransformData methods.</para>
    /// </summary>
    public abstract class CryptoProviderDigest :
                Goedel.Cryptography.CryptoProviderDigest {


        /// <summary>
        /// Hash algorithm provider.
        /// </summary>
        public abstract HashAlgorithm HashAlgorithm();


        /// <summary>
        /// Register this set of providers to the specified catalog.
        /// </summary>
        /// <param name="Catalog">Catalog to register the providers to</param>
        /// <returns>Registration for the preferred provider (SHA-2-512)</returns>
        public static CryptoAlgorithm Register(CryptoCatalog Catalog = null) {
            CryptoProviderSHA2_256.Register(Catalog);
            CryptoProviderSHA1.Register(Catalog);
            return CryptoProviderSHA2_512.Register(Catalog);
            }

        /// <summary>Create an encoder for the specified data</summary>
        /// <param name="Algorithm">Ignored</param>
        /// <param name="Bulk">Ignored</param>
        /// <param name="OutputStream">Output stream. Data written to the input 
        /// stream is written to the output without modification. This permits
        /// multiple digest values to be calculated simultaneously.</param>
        /// <returns>Instance describing the key agreement parameters.</returns>
        public override CryptoDataEncoder MakeEncoder(
                            CryptoProviderBulk Bulk = null,
                            CryptoAlgorithmId Algorithm = CryptoAlgorithmId.Default,
                            Stream OutputStream = null
                            ) {


            var Result = new CryptoDataEncoder(Algorithm, this) {
                OutputStream = OutputStream ?? Stream.Null
                };
            BindEncoder(Result);

            return Result;
            }

        HashAlgorithm HashAlgorithmEncoder;

        /// <summary>
        /// Create a crypto stream from this provider.
        /// </summary>
        /// <param name="Encoder">The encoder to bind.</param>
        public override void BindEncoder(CryptoDataEncoder Encoder) {
            HashAlgorithmEncoder = HashAlgorithm();
            Encoder.InputStream = new CryptoStream(
                    Encoder.OutputStream, HashAlgorithmEncoder, CryptoStreamMode.Write);
            }

        /// <summary>
        /// Complete processing at the end of an encoding or decoding operation
        /// </summary>
        /// <param name="CryptoData">Structure to write result to</param>
        public override void Complete(CryptoData CryptoData) {
            var CryptoStream = CryptoData.InputStream as CryptoStream;
            CryptoStream.FlushFinalBlock();
            CryptoData.Integrity = HashAlgorithmEncoder.Hash.OrTruncated(Truncate);
            CryptoStream.Dispose();
            return;
            }


        /// <summary>
        /// Truncation length. If this value is greater than 0, the output size is 
        /// truncated to the nearest integer multiple of 8 bits.
        /// </summary>
        protected int Truncate { get; set; } = 0;

        /// <summary>
        /// Processes the specified byte array
        /// </summary>
        /// <param name="Data">The input to process</param>
        /// <param name="Offset">Offset within array</param>
        /// <param name="Count">Number of bytes to process</param>
        /// <param name="Key">The key</param>
        /// <returns>The result of the cryptographic operation.</returns>
        public override byte[] ProcessData(byte[] Data, int Offset,
                            int Count, byte[] Key = null) {
            var Result = HashAlgorithm().ComputeHash(Data, Offset, Count);
            return Result.OrTruncated(Truncate);
            }



        }



    class CryptoDataEncoderDigest : CryptoDataEncoder {

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="Identifier">The Goedel Cryptography identifier.</param>
        /// <param name="Bulk">Provider to use to process the bulk data
        /// signature operations where the asymmetric operation is performed after the
        /// bulk operation completes. </param> 
        public CryptoDataEncoderDigest(CryptoAlgorithmId Identifier,
                        CryptoProviderBulk Bulk) :
                            base(Identifier, Bulk) {
            }

        /// <summary>
        /// Close the crypto stream and get the digest value.
        /// </summary>
        public override void Complete() => InputStream.Close();
        }


    /// <summary>
    /// Provider for the SHA-2 256 bit Hash Algorithm
    /// </summary>
    public class CryptoProviderSHA2_256 : CryptoProviderDigest {


        static CryptoAlgorithmId _CryptoAlgorithmID = CryptoAlgorithmId.SHA_2_256;

        /// <summary>
        /// The CryptoAlgorithmID Identifier.
        /// </summary>
        public override CryptoAlgorithmId CryptoAlgorithmID => _CryptoAlgorithmID;

        /// <summary>
        /// Return a CryptoAlgorithm structure with properties describing this provider.
        /// </summary>
        public override CryptoAlgorithm CryptoAlgorithm => _CryptoAlgorithm;


        static CryptoAlgorithm _CryptoAlgorithm = new(
                    _CryptoAlgorithmID, _AlgorithmClass, Factory, 256);

        /// <summary>
        /// Hash algorithm provider.
        /// </summary>
        public override HashAlgorithm HashAlgorithm() => new SHA256CryptoServiceProvider();

        /// <summary>
        /// Register this provider in the specified crypto catalog. A provider may 
        /// register itself multiple times to describe different configurations that 
        /// are supported.
        /// </summary>
        /// <param name="Catalog">The catalog to register the provider to, if
        /// null, the default catalog is used.</param>
        /// <returns>Description of the principal algorithm registration.</returns>
        public static new CryptoAlgorithm Register(CryptoCatalog Catalog = null) {
            Catalog ??= CryptoCatalog.Default;
            return Catalog.Add(_CryptoAlgorithm);
            }

        /// <summary>
        /// Default output size.
        /// </summary>
        public override int Size => 256;


        private static CryptoProvider Factory(int KeySize, CryptoAlgorithmId DigestAlgorithm) => new CryptoProviderSHA2_256();


        }

    /// <summary>
    /// Provider for the SHA-2 512 bit Hash Algorithm
    /// </summary>
    public class CryptoProviderSHA2_512 : CryptoProviderDigest {

        static CryptoAlgorithmId _CryptoAlgorithmID = CryptoAlgorithmId.SHA_2_512;

        /// <summary>
        /// The CryptoAlgorithmID Identifier.
        /// </summary>
        public override CryptoAlgorithmId CryptoAlgorithmID => _CryptoAlgorithmID;

        /// <summary>
        /// Return a CryptoAlgorithm structure with properties describing this provider.
        /// </summary>
        public override CryptoAlgorithm CryptoAlgorithm => _CryptoAlgorithm;


        static CryptoAlgorithm _CryptoAlgorithm = new(
                    _CryptoAlgorithmID, _AlgorithmClass, Factory, 512);

        /// <summary>
        /// Hash algorithm provider.
        /// </summary>
        public override HashAlgorithm HashAlgorithm() => new SHA512CryptoServiceProvider();


        /// <summary>
        /// Register this provider in the specified crypto catalog. A provider may 
        /// register itself multiple times to describe different configurations that 
        /// are supported.
        /// </summary>
        /// <param name="Catalog">The catalog to register the provider to, if
        /// null, the default catalog is used.</param>
        /// <returns>Description of the principal algorithm registration.</returns>
        public static new CryptoAlgorithm Register(CryptoCatalog Catalog = null) {
            Catalog ??= CryptoCatalog.Default;

            var Default = Catalog.Add(CryptoAlgorithmId.SHA_2_512, 512, _AlgorithmClass, Factory);
            Catalog.Add(CryptoAlgorithmId.SHA_2_512T128, 128, _AlgorithmClass, Factory);

            return Default;
            }

        /// <summary>
        /// Default output size.
        /// </summary>
        public override int Size => Truncate > 0 ? Truncate : 512;

        private static CryptoProvider Factory(int KeySize,
                            CryptoAlgorithmId ID = CryptoAlgorithmId.SHA_2_512) => new CryptoProviderSHA2_512(KeySize, ID);

        /// <summary>
        /// Create a SHA-2-256 digest provider.
        /// </summary>
        /// <param name="KeySize">Key size.</param>
        /// <param name="ID">Cryptgraphic algorithm.</param>
        public CryptoProviderSHA2_512(int KeySize = 512,
                    CryptoAlgorithmId ID = CryptoAlgorithmId.SHA_2_512) {

            if (KeySize > 0 & KeySize < 512) {
                Truncate = KeySize;
                }
            }



        }

    /// <summary>
    /// Provider for the SHA-1 Hash algorithm
    /// </summary>
    public class CryptoProviderSHA1 : CryptoProviderDigest {


        static CryptoAlgorithmId _CryptoAlgorithmID = CryptoAlgorithmId.SHA_1_DEPRECATED;

        /// <summary>
        /// The CryptoAlgorithmID Identifier.
        /// </summary>
        public override CryptoAlgorithmId CryptoAlgorithmID => _CryptoAlgorithmID;

        /// <summary>
        /// Return a CryptoAlgorithm structure with properties describing this provider.
        /// </summary>
        public override CryptoAlgorithm CryptoAlgorithm => _CryptoAlgorithm;

        static CryptoAlgorithm _CryptoAlgorithm = new(
                    _CryptoAlgorithmID, _AlgorithmClass, Factory, 160);

        /// <summary>
        /// Hash algorithm provider.
        /// </summary>
        public override HashAlgorithm HashAlgorithm() => new SHA1CryptoServiceProvider();


        /// <summary>
        /// Register this provider in the specified crypto catalog. A provider may 
        /// register itself multiple times to describe different configurations that 
        /// are supported.
        /// </summary>
        /// <param name="Catalog">The catalog to register the provider to, if
        /// null, the default catalog is used.</param>
        /// <returns>Description of the principal algorithm registration.</returns>
        public static new CryptoAlgorithm Register(CryptoCatalog Catalog = null) {
            Catalog ??= CryptoCatalog.Default;
            return Catalog.Add(_CryptoAlgorithm);
            }

        /// <summary>
        /// Default output size.
        /// </summary>
        public override int Size => 160;



        private static CryptoProvider Factory(int KeySize, CryptoAlgorithmId DigestAlgorithm) => new CryptoProviderSHA1();


        }




    /// <summary>
    /// Provider for the SHA-3 256 bit Hash Algorithm
    /// </summary>
    public class CryptoProviderSHA3_256 : CryptoProviderDigest {


        static CryptoAlgorithmId _CryptoAlgorithmID = CryptoAlgorithmId.SHA_3_256;

        /// <summary>
        /// The CryptoAlgorithmID Identifier.
        /// </summary>
        public override CryptoAlgorithmId CryptoAlgorithmID => _CryptoAlgorithmID;

        /// <summary>
        /// Return a CryptoAlgorithm structure with properties describing this provider.
        /// </summary>
        public override CryptoAlgorithm CryptoAlgorithm => _CryptoAlgorithm;


        static CryptoAlgorithm _CryptoAlgorithm = new(
                    _CryptoAlgorithmID, _AlgorithmClass, Factory, 256);

        /// <summary>
        /// Hash algorithm provider.
        /// </summary>
        public override HashAlgorithm HashAlgorithm() => new SHA3Managed(256);

        /// <summary>
        /// Register this provider in the specified crypto catalog. A provider may 
        /// register itself multiple times to describe different configurations that 
        /// are supported.
        /// </summary>
        /// <param name="Catalog">The catalog to register the provider to, if
        /// null, the default catalog is used.</param>
        /// <returns>Description of the principal algorithm registration.</returns>
        public static new CryptoAlgorithm Register(CryptoCatalog Catalog = null) {
            Catalog ??= CryptoCatalog.Default;
            return Catalog.Add(_CryptoAlgorithm);
            }

        /// <summary>
        /// Default output size.
        /// </summary>
        public override int Size => 256;


        private static CryptoProvider Factory(int KeySize, CryptoAlgorithmId DigestAlgorithm) => new CryptoProviderSHA3_256();


        }


    /// <summary>
    /// Provider for the SHA-3 512 bit Hash Algorithm
    /// </summary>
    public class CryptoProviderSHA3_512 : CryptoProviderDigest {


        static CryptoAlgorithmId _CryptoAlgorithmID = CryptoAlgorithmId.SHA_3_512;

        /// <summary>
        /// The CryptoAlgorithmID Identifier.
        /// </summary>
        public override CryptoAlgorithmId CryptoAlgorithmID => _CryptoAlgorithmID;

        /// <summary>
        /// Return a CryptoAlgorithm structure with properties describing this provider.
        /// </summary>
        public override CryptoAlgorithm CryptoAlgorithm => _CryptoAlgorithm;


        static CryptoAlgorithm _CryptoAlgorithm = new(
                    _CryptoAlgorithmID, _AlgorithmClass, Factory, 512);

        /// <summary>
        /// Hash algorithm provider.
        /// </summary>
        public override HashAlgorithm HashAlgorithm() => new SHA3Managed(512);

        /// <summary>
        /// Register this provider in the specified crypto catalog. A provider may 
        /// register itself multiple times to describe different configurations that 
        /// are supported.
        /// </summary>
        /// <param name="Catalog">The catalog to register the provider to, if
        /// null, the default catalog is used.</param>
        /// <returns>Description of the principal algorithm registration.</returns>
        public static new CryptoAlgorithm Register(CryptoCatalog Catalog = null) {
            Catalog ??= CryptoCatalog.Default;
            return Catalog.Add(_CryptoAlgorithm);
            }

        /// <summary>
        /// Default output size.
        /// </summary>
        public override int Size => 512;


        private static CryptoProvider Factory(int KeySize, CryptoAlgorithmId DigestAlgorithm) => new CryptoProviderSHA3_512();


        }



    /// <summary>
    /// Provider for the SHA-3 512 bit Hash Algorithm
    /// </summary>
    public class CryptoProviderSHAKE128 : CryptoProviderDigest {


        static CryptoAlgorithmId _CryptoAlgorithmID = CryptoAlgorithmId.SHAKE_128;

        /// <summary>
        /// The CryptoAlgorithmID Identifier.
        /// </summary>
        public override CryptoAlgorithmId CryptoAlgorithmID => _CryptoAlgorithmID;

        /// <summary>
        /// Return a CryptoAlgorithm structure with properties describing this provider.
        /// </summary>
        public override CryptoAlgorithm CryptoAlgorithm => _CryptoAlgorithm;


        static CryptoAlgorithm _CryptoAlgorithm = new(
                    _CryptoAlgorithmID, _AlgorithmClass, Factory, 128);

        /// <summary>
        /// Hash algorithm provider.
        /// </summary>
        public override HashAlgorithm HashAlgorithm() => new SHAKE128(256);

        /// <summary>
        /// Register this provider in the specified crypto catalog. A provider may 
        /// register itself multiple times to describe different configurations that 
        /// are supported.
        /// </summary>
        /// <param name="Catalog">The catalog to register the provider to, if
        /// null, the default catalog is used.</param>
        /// <returns>Description of the principal algorithm registration.</returns>
        public static new CryptoAlgorithm Register(CryptoCatalog Catalog = null) {
            Catalog ??= CryptoCatalog.Default;
            return Catalog.Add(_CryptoAlgorithm);
            }

        /// <summary>
        /// Default output size.
        /// </summary>
        public override int Size => 128;


        private static CryptoProvider Factory(int KeySize, CryptoAlgorithmId DigestAlgorithm) => new CryptoProviderSHAKE128();

        }


    /// <summary>
    /// Provider for the SHA-3 512 bit Hash Algorithm
    /// </summary>
    public class CryptoProviderSHAKE256 : CryptoProviderDigest {


        static CryptoAlgorithmId _CryptoAlgorithmID = CryptoAlgorithmId.SHAKE_256;

        /// <summary>
        /// The CryptoAlgorithmID Identifier.
        /// </summary>
        public override CryptoAlgorithmId CryptoAlgorithmID => _CryptoAlgorithmID;

        /// <summary>
        /// Return a CryptoAlgorithm structure with properties describing this provider.
        /// </summary>
        public override CryptoAlgorithm CryptoAlgorithm => _CryptoAlgorithm;


        static CryptoAlgorithm _CryptoAlgorithm = new(
                    _CryptoAlgorithmID, _AlgorithmClass, Factory, 256);

        /// <summary>
        /// Hash algorithm provider.
        /// </summary>
        public override HashAlgorithm HashAlgorithm() => new SHAKE256(512);

        /// <summary>
        /// Register this provider in the specified crypto catalog. A provider may 
        /// register itself multiple times to describe different configurations that 
        /// are supported.
        /// </summary>
        /// <param name="Catalog">The catalog to register the provider to, if
        /// null, the default catalog is used.</param>
        /// <returns>Description of the principal algorithm registration.</returns>
        public static new CryptoAlgorithm Register(CryptoCatalog Catalog = null) {
            Catalog ??= CryptoCatalog.Default;
            return Catalog.Add(_CryptoAlgorithm);
            }

        /// <summary>
        /// Default output size.
        /// </summary>
        public override int Size => 256;

        private static CryptoProvider Factory(int KeySize, CryptoAlgorithmId DigestAlgorithm) => new CryptoProviderSHAKE256();

        }

    }
