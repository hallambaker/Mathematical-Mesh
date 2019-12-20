using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
#pragma warning disable IDE0060  // NYI: Pretty much the whole of this scheme

namespace Goedel.Cryptography.Algorithms {

    /// <summary>
    /// Montgomery Curve [v^2 = u^3 + A*u^2 + u] for 2^255-19
    /// </summary>
    public class CurveX25519 : CurveMontgomery {

        #region // curve parameter constant definitions
        ///<summary>The domain parameters</summary>
        public override DomainParameters DomainParameters => DomainParameters.Curve25519;

        ///<summary>The modulus, p = 2^255 - 19</summary>
        public static BigInteger P => DomainParameters.Curve25519.P;

        ///<summary>The small order subgroup q</summary>
        public static BigInteger Q => DomainParameters.Curve25519.Q;
        #endregion
        #region // computed curve points
        /// <summary>The base point for the subgroup</summary>
        static readonly CurveX25519 BasePoint =
            new CurveX25519(DomainParameters.Curve25519.U);

        /// <summary>The base point for the subgroup</summary>
        public static CurveX25519 Base => BasePoint.Copy();

        ///<summary>The neutral point which returns the original value when 
        ///added to a point.</summary>
        public CurveX25519 Neutral => throw new NYI();
        #endregion


        #region // Constructors
        /// <summary>Default constructor</summary>
        protected CurveX25519() {
            }

        /// <summary>
        /// Construct a point from a U coordinate.
        /// </summary>
        /// <param name="u">The U coordinate</param>
        public CurveX25519(BigInteger u) => U = u.Mod(P);


        /// <summary>
        /// Construct a point from a U coordinate.
        /// </summary>
        /// <param name="data">The encoded U coordinate</param>
        public CurveX25519(byte[] data) : this (DecodePoint (data)) { }

        #endregion

        /// <summary>
        /// Crete a new point with the same parameters as this.
        /// </summary>
        /// <returns>The new point</returns>
        public CurveX25519 Copy() => new CurveX25519(U);

        /// <summary>
        /// Multiply this point by a scalar
        /// </summary>
        /// <param name="s">Scalar factor</param>
        /// <returns>The result of the multiplication</returns>

        public CurveX25519 Multiply(BigInteger s) => new CurveX25519(ScalarMultiply(s));



        /// <summary>
        /// Generate the public parameter (a point on the curve)
        /// </summary>
        /// <param name="Private">The extended private key</param>
        /// <returns>The public key corresponding to Private (s.B)</returns>
        public static CurveX25519 GetPublic(BigInteger Private) => Base.Multiply(Private);


        /// <summary>
        /// Encode the code point.
        /// </summary>
        /// <returns>The encoded format of the point</returns>
        public override byte[] Encode() => EncodePoint (U);

        /// <summary>
        /// Encode the code point <paramref name="u"/>.
        /// </summary>
        /// <param name="u">The point to encode.</param>
        /// <returns>The encoded format of the point</returns>
        public static byte[] EncodePoint(BigInteger u) =>
            u.ByteArrayLittleEndian(32);

        /// <summary>
        /// Encode the code point <paramref name="u"/>.
        /// </summary>
        /// <param name="u">The point to encode.</param>
        /// <returns>The encoded format of the point</returns>
        public static byte[] EncodeScalar(BigInteger u) =>
            u.ByteArrayLittleEndian(32);

        /// <summary>
        /// Construct a point on the curve from a buffer.
        /// </summary>
        /// <param name="Data">The encoded data</param>
        /// <returns>The point created</returns>
        public static BigInteger DecodePoint(byte[] Data) {
            var copy = Data.Duplicate();
            copy[31] &= 127;
            return copy.BigIntegerLittleEndian();
            }

        /// <summary>
        /// Construct a point on the curve from a buffer.
        /// </summary>
        /// <param name="Data">The encoded data</param>
        /// <returns>The point created</returns>
        public static BigInteger DecodeScalar(byte[] Data) {
            var copy = Data.Duplicate();
            copy[0] &= 248;
            copy[31] &= 127;
            copy[31] |= 64;
            return copy.BigIntegerLittleEndian();
            }

        /// <summary>
        /// Create a point from the specified U value.
        /// </summary>
        /// <param name="U">The U value</param>
        /// <returns>Created point</returns>
        public override CurveMontgomery Factory(BigInteger U, bool? odd) => new CurveX25519(U);
        }


    /// <summary>
    /// Manages the public key
    /// </summary>
    public class CurveX25519Public : IKeyAdvancedPublic {


        /// <summary>The public key, i.e. a point on the curve</summary>
        public virtual CurveX25519 Public { get; }

        /// <summary>Encoded form of the public key.</summary>
        public virtual byte[] Encoding { get; }

        /// <summary>
        /// Construct provider from public key parameters.
        /// </summary>
        /// <param name="publicKey">The public key values.</param>
        public CurveX25519Public(CurveX25519 publicKey) {
            this.Public = publicKey;
            this.Encoding = publicKey.Encode();
            }

        /// <summary>
        /// Construct provider from public key data.
        /// </summary>
        /// <param name="encoding">The encoded public key value.</param>
        public CurveX25519Public(byte[] encoding) {
            this.Public =  new CurveX25519 (encoding);
            this.Encoding = encoding;
            }
        /// <summary>
        /// Create a new ephemeral private key and use it to perform a key
        /// agreement.
        /// </summary>
        /// <returns>The key agreement parameters, the public key value and the
        /// key agreement.</returns>
        public CurveX25519Result Agreement() {
            var Private = new CurveX25519Private();

            return new CurveX25519Result() {
                EphemeralPublicValue = Private.Public,
                Agreement = Private.Agreement(this)
                };
            }

        /// <summary>
        /// Create a new ephemeral private key and use it to perform a key
        /// agreement.
        /// </summary>
        /// <returns>The key agreement parameters, the public key value and the
        /// key agreement.</returns>
        public CurveX25519 Agreement(CurveX25519[] Carry) {
            Assert.True(Carry.Length >= 1, InsufficientResults.Throw);

            var Total = Carry[0]; 
            for(var i = 1; i < Carry.Length; i++) {
                
                Total.Accumulate(Carry[i]);
                }

            return Total;
            }

        /// <summary>
        /// Combine the two public keys to create a composite public key.
        /// </summary>
        /// <param name="contribution">The key contribution.</param>
        /// <returns>The composite key</returns>
        public CurveX25519Public Combine(CurveX25519Public contribution) {
            var NewPublic = Public.Add(contribution.Public);
            return new CurveX25519Public((CurveX25519)NewPublic);
            }


        /// <summary>
        /// Combine the two public keys to create a composite public key.
        /// </summary>
        /// <param name="Contribution">The key contribution.</param>
        /// <returns>The composite key</returns>
        public IKeyAdvancedPublic Combine(IKeyAdvancedPublic Contribution) =>
            Combine(Contribution as CurveX25519Public);


        }

    /// <summary>
    /// Manages the public key
    /// </summary>
    public class CurveX25519Private : IKeyAdvancedPrivate {

        /// <summary>The public key, i.e. a point on the curve</summary>
        public CurveX25519Public Public { get; set; }

        /// <summary>Encoded form of the public key.</summary>
        public byte[] Encoding { get; }

        /// <summary>The random secret used to generate the private key</summary>
        byte[] Secret { get; }

        /// <summary>If true, this is a recryption key.</summary>
        public bool IsRecryption { get; set; } = false;

        /// <summary>The private key, i.e. a scalar</summary>
        public BigInteger Private { get; }


        /// <summary>
        /// Construct a private key from the specified input buffer.
        /// </summary>
        /// <param name="privateKey">The private key</param>
        /// <param name="exportable">If true, the private key is exportable</param>

        public CurveX25519Private(BigInteger privateKey, bool exportable = false) {
            Private = privateKey;
            Secret = CurveX25519.EncodeScalar(privateKey);

            var PublicPoint = CurveX25519.GetPublic(privateKey);
            Public = new CurveX25519Public(PublicPoint);

            if (exportable) {
                Encoding = Secret;
                }
            }

        /// <summary>
        /// Construct provider from private key data.
        /// </summary>
        /// <param name="encoding">The encoded private key value.</param>
        /// <param name="exportable">If true, the private key is exportable</param>
        public CurveX25519Private(byte[] encoding, bool exportable = false) :
            this(CurveX25519.DecodeScalar(encoding), exportable) { }


        /// <summary>
        /// Generate a new private key
        /// </summary>
        /// <param name="exportable">If true, the private key is exportable</param>
        public CurveX25519Private(bool exportable = false) :
            this(Platform.GetRandomBytes(32), exportable) { }






        /// <summary>
        /// Perform a partial key agreement.
        /// </summary>
        /// <param name="keyPair">The key pair to perform the agreement against.</param>
        /// <returns>The key agreement result.</returns>
        public KeyAgreementResult Agreement(KeyPair keyPair) {
            var publicKey = (keyPair as KeyPairX25519).PublicKey;
            var agreement = Agreement(publicKey);
            return new CurveX25519Result() { Agreement = agreement };
            }

        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to a public key
        /// </summary>
        /// <param name="publicKey">Public key parameters</param>
        /// <returns>The key agreement value ZZ</returns>
        public CurveX25519 Agreement(CurveX25519Public publicKey) =>
            publicKey.Public.Multiply(Private);

        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to a private key
        /// </summary>
        /// <param name="publicKey">Public key parameters</param>
        /// <param name="carry">Recryption carry over value, to be combined with the
        /// result of this key agreement.</param>
        /// <returns>The key agreement value ZZ</returns>
        public CurveX25519 Agreement(CurveX25519Public publicKey, CurveX25519 carry) {
            var Result = publicKey.Public.Multiply(Private);
            Result.Accumulate(carry);

            return Result;
            }




        #region // Advanced functions

        /// <summary>
        /// Split the private key into a number of recryption keys.
        /// <para>
        /// Since the
        /// typical use case for recryption requires both parts of the generated machine
        /// to be used on a machine that is not the machine on which they are created, the
        /// key security level is always to permit export.</para>
        /// </summary>
        /// <param name="shares">The number of keys to create.</param>
        /// <returns>The created keys</returns>
        public IKeyAdvancedPrivate[] MakeRecryptionKeySet(int shares) {
            BigInteger Accumulator = 0;
            var Result = new IKeyAdvancedPrivate[shares];

            for (var i = 1; i < shares; i++) {
                var NewPrivate = Platform.GetRandomBigInteger(CurveX25519.Q);
                Result[i] = new CurveX25519Private(NewPrivate) { IsRecryption = true };
                Accumulator = (Accumulator + NewPrivate).Mod(CurveX25519.Q);
                }

            //Assert.True(Accumulator > 0 & Accumulator < Private, CryptographicException.Throw);

            Result[0] = new CurveX25519Private(
                (CurveX25519.Q + Private - Accumulator).Mod(CurveX25519.Q)) {
                IsRecryption = true
                };
            return Result;

            }


        /// <summary>
        /// Make a recryption keyset by splitting the private key.
        /// </summary>
        /// <param name="Shares">Number of shares to create</param>
        /// <returns>Array shares.</returns>
        public IKeyAdvancedPrivate CompleteRecryptionKeySet(IEnumerable<KeyPair> Shares) {
            BigInteger Accumulator = 0;

            foreach (var share in Shares) {
                var key = share as KeyPairEd25519;
                var privateKey = (key.IKeyAdvancedPrivate as CurveX25519Private);

                Accumulator = (Accumulator + privateKey.Private).Mod(CurveX25519.Q);
                }

            return new CurveX25519Private(
                (CurveX25519.Q + Private - Accumulator).Mod(CurveX25519.Q)) {
                IsRecryption = true
                };
            }


        /// <summary>
        /// Combine the two public keys to create a composite public key.
        /// </summary>
        /// <param name="contribution">The key contribution.</param>
        /// <returns>The composite key</returns>
        public CurveX25519Private Combine(CurveX25519Private contribution) {
            var NewPrivate = (Private + contribution.Private).Mod(CurveX25519.Q);
            return new CurveX25519Private(NewPrivate);
            }


        /// <summary>
        /// Combine the two public keys to create a composite public key.
        /// </summary>
        /// <param name="contribution">The key contribution.</param>
        /// <returns>The composite key</returns>
        public IKeyAdvancedPrivate Combine(IKeyAdvancedPrivate contribution) =>
            Combine(contribution as CurveX25519Private);
        #endregion






        }

    /// <summary>
    /// Represent the result of a Diffie Hellman Key exchange.
    /// </summary>
    public class CurveX25519Result : ResultECDH {

        /// <summary>The key agreement result</summary>
        public CurveX25519 Agreement { get; set; }

        /// <summary>The agreement as ASN.1 DER encoding</summary>
        /// <returns>The DER encoded value.</returns>
        public override byte[] DER() => Agreement.Encode();


        /// <summary>The key agreement result as a byte array</summary>
        public override byte[] IKM => Agreement.Encode();

        /// <summary>
        /// The Ephemeral public key
        /// </summary>
        public override KeyPair EphemeralKeyPair => new KeyPairX25519(EphemeralPublicValue as CurveX25519Public);


        /// <summary>Carry from proxy recryption efforts</summary>
        public CurveX25519 Carry { get; set; }

        /// <summary>Public key generated by ephemeral key generation.</summary>
        public CurveX25519Public Public => EphemeralPublicValue as CurveX25519Public;
        }

    }
