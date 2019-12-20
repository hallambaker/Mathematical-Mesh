using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

#pragma warning disable IDE0060  // NYI: Pretty much the whole of this scheme

namespace Goedel.Cryptography.Algorithms {

    public class CurveX448Signed : CurveX448 {

        static readonly CurveX448Signed BasePoint =
                new CurveX448Signed(DomainParameters.Curve448.U, DomainParameters.Curve448.V);

        /// <summary>The base point for the subgroup</summary>
        public static CurveX448Signed Base => BasePoint.Copy();

        /// <summary>
        /// Crete a new point with the same parameters as this.
        /// </summary>
        /// <returns>The new point</returns>
        public CurveX448Signed Copy() => new CurveX448Signed(U, V);


        // constructors

        /// <summary>
        /// Construct a point from U and V coordinates. Is only for use by internal
        /// methods.
        /// </summary>
        /// <param name="u">The U coordinate</param>
        /// <param name="v">The V coordinate</param>
        public CurveX448Signed(BigInteger u, BigInteger v) {
            U = u.Mod(P);
            V = v.Mod(P);
            }


        /// <summary>
        /// Construct a point from a U coordinate and sign of V.
        /// </summary>
        /// <param name="u">The U coordinate</param>
        /// <param name="odd">Specify the sign of the V value</param> 
        public CurveX448Signed(BigInteger u, bool? odd) {
            U = u.Mod(P);
            V = GetV(odd);
            }


        /// <summary>
        /// Construct a point from a U coordinate.
        /// </summary>
        /// <param name="data">The encoded U coordinate</param>
        public CurveX448Signed(byte[] data) {
            bool? odd;
            (U, odd) = DecodePointSigned(data);
            V = GetV(odd);
            }


        /// <summary>
        /// Create a point from the specified U value.
        /// </summary>
        /// <param name="u">The U value</param>
        /// <param name="odd">Specify the sign of the V value, ignored for this curve.</param> 
        /// <returns>Created point</returns>
        public override CurveMontgomery Factory(BigInteger u, bool? odd) => new CurveX448Signed(u, odd);

        // need to override the encode / decode mechanisms


        /// <summary>
        /// Construct a point on the curve from a buffer.
        /// </summary>
        /// <param name="data">The encoded data</param>
        /// <returns>The point created</returns>
        public static (BigInteger, bool?) DecodePointSigned(byte[] data) {
            throw new NYI();
            //return (data.BigIntegerLittleEndian(), null);

            //var copy = data.Duplicate();
            //copy[0] &= 252;
            //copy[55] |= 128;
            //return copy.BigIntegerLittleEndian();
            }

        /// <summary>
        /// Encode the code point <paramref name="u"/>.
        /// </summary>
        /// <param name="u">The point to encode.</param>
        /// <returns>The encoded format of the point</returns>
        public static byte[] EncodePointSigned(BigInteger u) => throw new NYI();
           //u.ByteArrayLittleEndian(56);

        /// <summary>
        /// Encode the code point.
        /// </summary>
        /// <returns>The encoded format of the point</returns>
        public override byte[] Encode() => EncodePointSigned(U);


        /// <summary>
        /// Add two points
        /// </summary>
        /// <param name="point">Second point</param>
        /// <returns>The result of the addition.</returns>
        public override CurveMontgomery Add(CurveMontgomery point) {
            (point is CurveX448Signed).AssertTrue();

            var (u, v) = Add(this, point);
            return new CurveX448Signed(u, v);

            }

        /// <summary>
        /// Multiply this point by a scalar and return the new point.
        /// </summary>
        /// <param name="s">Scalar factor</param>
        /// <returns>The result of the multiplication</returns>
        public CurveMontgomery MultiplyFast(BigInteger s) {




            var (u,v) = ScalarMultiplySigned(s);
            return new CurveX448Signed(u, v);
            }


        /// <summary>
        /// Multiply this point by a scalar and return the new point.
        /// </summary>
        /// <param name="s">Scalar factor</param>
        /// <returns>The result of the multiplication</returns>
        public CurveMontgomery Multiply(BigInteger s) {
            ScalarAccumulate(U, s, out var xq, out var zq, out var xq1, out var zq1);

            var uq = Recover(xq, zq);
            var uq1 = Recover(xq1, zq1);

            var vq = GetV(uq, true);
            //var vq1 = GetV(uq1, true);

            CheckCurve(uq, vq);
            var q = new CurveX448Signed(uq, vq);

            var q1 = Add(q);
            if (uq1 != q1.U) {
                q.V = (Prime - q.V).Mod(Prime);
                }
            return q;
            }

        }

    /// <summary>
    /// Montgomery Curve [v^2 = u^3 + A*u^2 + u] for 2^448 - 2^224 -1
    /// </summary>
    public class CurveX448 : CurveMontgomery {

        #region // curve parameter constant definitions
        ///<summary>The domain parameters</summary>
        public override DomainParameters DomainParameters => DomainParameters.Curve448;

        ///<summary>The modulus, p = 2^255 - 19</summary>
        public static BigInteger P => DomainParameters.Curve448.P;

        ///<summary>The small order subgroup q</summary>
        public static BigInteger Q => DomainParameters.Curve448.Q;
        #endregion
        #region // computed curve points
        /// <summary>The base point for the subgroup</summary>
        static readonly CurveX448 BasePoint =
            new CurveX448(DomainParameters.Curve448.U);

        /// <summary>The base point for the subgroup</summary>
        public static CurveX448 Base => BasePoint.Copy();

        ///<summary>The neutral point which returns the original value when 
        ///added to a point.</summary>
        public CurveX448 Neutral => throw new NYI();
        #endregion


        #region // Constructors
        /// <summary>Default constructor</summary>
        protected CurveX448() {
            }

        /// <summary>
        /// Construct a point from a U coordinate.
        /// </summary>
        /// <param name="u">The U coordinate</param>
        public CurveX448(BigInteger u) => U = u.Mod(P);


        /// <summary>
        /// Construct a point from a U coordinate.
        /// </summary>
        /// <param name="data">The encoded U coordinate</param>
        public CurveX448(byte[] data) : this(DecodePoint(data)) { }

        #endregion


        /// <summary>
        /// Crete a new point with the same parameters as this.
        /// </summary>
        /// <returns>The new point</returns>
        public CurveX448 Copy() => new CurveX448(U);

        /// <summary>
        /// Multiply this point by a scalar
        /// </summary>
        /// <param name="s">Scalar factor</param>
        /// <returns>The result of the multiplication</returns>

        public CurveX448 Multiply(BigInteger s) => new CurveX448(ScalarMultiply(s));

        /// <summary>
        /// Generate the public parameter (a point on the curve)
        /// </summary>
        /// <param name="secretScalar">The extended private key</param>
        /// <returns>The public key corresponding to Private (s.B)</returns>
        public static CurveX448 GetPublic(BigInteger secretScalar) => Base.Multiply(secretScalar);


        /// <summary>
        /// Encode the code point.
        /// </summary>
        /// <returns>The encoded format of the point</returns>
        public override byte[] Encode() => EncodePoint(U);

        /// <summary>
        /// Encode the code point <paramref name="u"/>.
        /// </summary>
        /// <param name="u">The point to encode.</param>
        /// <returns>The encoded format of the point</returns>
        public static byte[] EncodePoint(BigInteger u) =>
            u.ByteArrayLittleEndian(56);

        /// <summary>
        /// Encode the code point <paramref name="s"/>.
        /// </summary>
        /// <param name="s">The point to encode.</param>
        /// <returns>The encoded format of the point</returns>
        public static byte[] EncodeScalar(BigInteger s) =>
            s.ByteArrayLittleEndian(56);



        /// <summary>
        /// Construct a point on the curve from a buffer.
        /// </summary>
        /// <param name="data">The encoded data</param>
        /// <returns>The point created</returns>
        public static BigInteger DecodePoint(byte[] data) {
            return data.BigIntegerLittleEndian();
            }

        /// <summary>
        /// Construct a point on the curve from a buffer.
        /// </summary>
        /// <param name="data">The encoded data</param>
        /// <returns>The point created</returns>
        public static BigInteger DecodeScalar(byte[] data) {
            var copy = data.Duplicate();
            copy[0] &= 252;
            copy[55] |= 128;
            return copy.BigIntegerLittleEndian();
            }


        /// <summary>
        /// Create a point from the specified U value.
        /// </summary>
        /// <param name="u">The U value</param>
        /// <param name="odd">Specify the sign of the V value, ignored for this curve.</param> 
        /// <returns>Created point</returns>
        public override CurveMontgomery Factory(BigInteger u, bool? odd) => new CurveX448(u);
        }




    /// <summary>
    /// Manages the public key
    /// </summary>
    public class CurveX448Public : IKeyAdvancedPublic {

        /// <summary>The public key, i.e. a point on the curve</summary>
        public virtual CurveX448 Public { get; }

        /// <summary>Encoded form of the public key.</summary>
        public virtual byte[] Encoding { get; }

        /// <summary>
        /// Construct provider from public key parameters.
        /// </summary>
        /// <param name="publicKey">The public key values.</param>
        public CurveX448Public(CurveX448 publicKey) {
            this.Public = publicKey;
            this.Encoding = publicKey.Encode();
            }

        /// <summary>
        /// Construct provider from public key data.
        /// </summary>
        /// <param name="encoding">The encoded public key value.</param>
        public CurveX448Public(byte[] encoding) {
            this.Public = new CurveX448 (encoding);
            this.Encoding = encoding;
            }
        /// <summary>
        /// Create a new ephemeral private key and use it to perform a key
        /// agreement.
        /// </summary>
        /// <returns>The key agreement parameters, the public key value and the
        /// key agreement.</returns>
        public CurveX448Result Agreement() {
            var Private = new CurveX448Private();

            return new CurveX448Result() {
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
        public CurveX448 Agreement(CurveX448[] Carry) {
            Assert.True(Carry.Length >= 1, InsufficientResults.Throw);

            var Total = Carry[0];
            for (var i = 1; i < Carry.Length; i++) {

                Total.Accumulate(Carry[i]);
                }

            return Total;
            }

        /// <summary>
        /// Combine the two public keys to create a composite public key.
        /// </summary>
        /// <param name="contribution">The key contribution.</param>
        /// <returns>The composite key</returns>
        public CurveX448Public Combine(CurveX448Public contribution) {
            var NewPublic = Public.Add(contribution.Public);
            return new CurveX448Public((CurveX448)NewPublic);
            }


        /// <summary>
        /// Combine the two public keys to create a composite public key.
        /// </summary>
        /// <param name="Contribution">The key contribution.</param>
        /// <returns>The composite key</returns>
        public IKeyAdvancedPublic Combine(IKeyAdvancedPublic Contribution) =>
            Combine(Contribution as CurveX448Public);
        }

    /// <summary>
    /// Manages the public key
    /// </summary>
    public class CurveX448Private : IKeyAdvancedPrivate {


        /// <summary>The public key, i.e. a point on the curve</summary>
        public CurveX448Public Public { get; set; }

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

        public CurveX448Private(BigInteger privateKey, bool exportable = false) {
            Private = privateKey;
            Secret = CurveX448.EncodeScalar(privateKey);

            var PublicPoint = CurveX448.GetPublic(privateKey);
            Public = new CurveX448Public(PublicPoint);

            if (exportable) {
                Encoding = Secret;
                }
            }

        /// <summary>
        /// Construct provider from private key data.
        /// </summary>
        /// <param name="encoding">The encoded private key value.</param>
        /// <param name="exportable">If true, the private key is exportable</param>
        public CurveX448Private(byte[] encoding, bool exportable = false) :
            this(CurveX448.DecodeScalar(encoding), exportable) { }


        /// <summary>
        /// Generate a new private key
        /// </summary>
        /// <param name="exportable">If true, the private key is exportable</param>
        public CurveX448Private(bool exportable = false) :
            this(Platform.GetRandomBytes(56), exportable) { }






        /// <summary>
        /// Perform a partial key agreement.
        /// </summary>
        /// <param name="keyPair">The key pair to perform the agreement against.</param>
        /// <returns>The key agreement result.</returns>
        public KeyAgreementResult Agreement(KeyPair keyPair) {
            var publicKey = (keyPair as KeyPairX448).PublicKey;
            var agreement = Agreement(publicKey);
            return new CurveX448Result() { Agreement = agreement };
            }

        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to a public key
        /// </summary>
        /// <param name="publicKey">Public key parameters</param>
        /// <returns>The key agreement value ZZ</returns>
        public CurveX448 Agreement(CurveX448Public publicKey) =>
            publicKey.Public.Multiply(Private);

        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to a private key
        /// </summary>
        /// <param name="publicKey">Public key parameters</param>
        /// <param name="carry">Recryption carry over value, to be combined with the
        /// result of this key agreement.</param>
        /// <returns>The key agreement value ZZ</returns>
        public CurveX448 Agreement(CurveX448Public publicKey, CurveX448 carry) {
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
                var NewPrivate = Platform.GetRandomBigInteger(CurveX448.Q);
                Result[i] = new CurveX448Private(NewPrivate) { IsRecryption = true };
                Accumulator = (Accumulator + NewPrivate).Mod(CurveX448.Q);
                }

            //Assert.True(Accumulator > 0 & Accumulator < Private, CryptographicException.Throw);

            Result[0] = new CurveX448Private(
                (CurveX448.Q + Private - Accumulator).Mod(CurveX448.Q)) {
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
                var key = share as KeyPairEd448;
                var privateKey = (key.IKeyAdvancedPrivate as CurveX448Private);

                Accumulator = (Accumulator + privateKey.Private).Mod(CurveX448.Q);
                }

            return new CurveX448Private(
                (CurveX448.Q + Private - Accumulator).Mod(CurveX448.Q)) {
                IsRecryption = true
                };
            }


        /// <summary>
        /// Combine the two public keys to create a composite public key.
        /// </summary>
        /// <param name="contribution">The key contribution.</param>
        /// <returns>The composite key</returns>
        public CurveX448Private Combine(CurveX448Private contribution) {
            var NewPrivate = (Private + contribution.Private).Mod(CurveX448.Q);
            return new CurveX448Private(NewPrivate);
            }


        /// <summary>
        /// Combine the two public keys to create a composite public key.
        /// </summary>
        /// <param name="contribution">The key contribution.</param>
        /// <returns>The composite key</returns>
        public IKeyAdvancedPrivate Combine(IKeyAdvancedPrivate contribution) =>
            Combine(contribution as CurveX448Private);
        #endregion




        }

    /// <summary>
    /// Represent the result of a Diffie Hellman Key exchange.
    /// </summary>
    public class CurveX448Result : ResultECDH {

        /// <summary>The key agreement result</summary>
        public CurveX448 Agreement { get; set; }

        /// <summary>The agreement as ASN.1 DER encoding</summary>
        /// <returns>The DER encoded value.</returns>
        public override byte[] DER() => Agreement.Encode();


        /// <summary>The key agreement result as a byte array</summary>
        public override byte[] IKM => Agreement.Encode();

        /// <summary>
        /// The Ephemeral public key
        /// </summary>
        public override KeyPair EphemeralKeyPair => new KeyPairX448(EphemeralPublicValue as CurveX448Public);


        /// <summary>Carry from proxy recryption efforts</summary>
        public CurveX448 Carry { get; set; }

        /// <summary>Public key generated by ephemeral key generation.</summary>
        public CurveX448Public Public => EphemeralPublicValue as CurveX448Public;
        }


    }
