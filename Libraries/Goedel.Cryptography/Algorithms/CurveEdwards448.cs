using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace Goedel.Cryptography.Algorithms {



    /// <summary>
    /// Edwards Curve [x^2 = (y^2 - 1) / (d y^2 + 1) (mod p)] for 2^448 - 2^224 - 1
    /// </summary>
    public class CurveEdwards448 : CurveEdwards {

        #region // curve parameter constant definitions
        ///<summary>The Jose curve name</summary>
        public const string CurveJose = "Ed448";

        ///<summary>The domain parameters</summary>
        public override DomainParameters DomainParameters => DomainParameters.Curve448;

        ///<summary>The modulus, p = 2^255 - 19</summary>
        public static BigInteger P => DomainParameters.Curve448.P;

        ///<summary>The small order subgroup q</summary>
        public static BigInteger Q => DomainParameters.Curve448.Q;

        ///<summary>The Curve Constant d</summary>
        public static BigInteger D => DomainParameters.Curve448.D;
        #endregion


        #region // computed curve points
        /// <summary>The base point for the subgroup</summary>
        static readonly CurveEdwards448 BasePoint =
            new CurveEdwards448(DomainParameters.Curve448.By, false);

        /// <summary>The base point for the subgroup</summary>
        public static CurveEdwards448 Base => BasePoint.Copy();

        /// <summary>The point P such that P + Q = Q for all Q</summary>
        static readonly CurveEdwards448 NeutralPoint = new CurveEdwards448() { X = 0, Y = 1, Z = 1 };

        /// <summary>The point P such that P + Q = Q for all Q</summary>
        public static CurveEdwards448 Neutral => NeutralPoint.Copy();
        #endregion

        /// <summary>
        /// Return a IKeyAdvancedPublic public key for this point. 
        /// </summary>
        public override IKeyAdvancedPublic KeyAdvancedPublic => new CurveEdwards448Public(this);

        /// <summary>Default constructor</summary>
        protected CurveEdwards448() {
            }


        /// <summary>
        /// Construct a point from a Y coordinate and sign.
        /// </summary>
        /// <param name="Y">The Y coordinate</param>
        /// <param name="X0">The sign of X</param>
        public CurveEdwards448(BigInteger Y, bool X0) {
            this.Y = Y;
            this.Z = 1;
            X = RecoverX(X0);
            }

        /// <summary>
        /// Recover the X coordinate from the Y value and sign of X.
        /// </summary>
        /// <param name="X0">If true X is odd, otherwise, X is even.</param>
        /// <returns>The X coordinate value.</returns>
        public override BigInteger RecoverX(bool X0) {
            Assert.True(Y < Prime, InvalidOperation.Throw);
            //var x2 = ((Y * Y - 1) * (CurveConstrantD * Y * Y - 1)).Mod (p);
            var yy = (Y * Y - 1).Mod(Prime);
            var zz = (CurveConstantD * Y * Y - 1).Mod(Prime);
            var x2 = (yy * zz.ModularInverse(Prime)).Mod(Prime);

            return x2.Sqrt(Prime, SqrtMinus1, X0);
            }



        /// <summary>
        /// Crete a new point with the same parameters as this.
        /// </summary>
        /// <returns>The copied point.</returns>
        public CurveEdwards448 Copy() => new CurveEdwards448() { X = X, Y = Y, Z = Z };


        /// <summary>
        /// Multiply this point by a scalar
        /// </summary>
        /// <param name="S">Scalar factor</param>
        /// <returns>The result of the multiplication</returns>
        public CurveEdwards448 Multiply(BigInteger S) {
            var Q = Neutral.Copy();
            Assert.NotNull(Q, InvalidOperation.Throw);
            var BitIndex = new BitIndex(S, Bits, Up: true);

            var P = Copy();

            //int i = 0;
            while (BitIndex.GoingUp) {
                //Console.Write($"{i++}:  ");


                if (BitIndex.Up()) {
                    Q.Accumulate(P);
                    }
                P.DoublePoint();

                //Console.WriteLine($"{Q.Z}");
                }

            return Q;
            }


        /// <summary>
        /// Replace the current point value with the current value added to itself
        /// (used to implement multiply)
        /// </summary>
        public override void DoublePoint() {
            var x1s = (X * X).Mod(Prime);
            var y1s = (Y * Y).Mod(Prime);
            var z1s = (Z * Z).Mod(Prime);
            var xys = (X + Y).Mod(Prime);
            var F = (x1s + y1s).Mod(Prime);
            var J = (F - 2 * z1s).Mod(Prime);
            var B = (xys * xys).Mod(Prime);

            X = ((B - F) * J).Mod(Prime);
            Y = (F * (x1s - y1s)).Mod(Prime);
            Z = (F * J).Mod(Prime);
            }



        /// <summary>
        /// Add two points
        /// </summary>
        /// <param name="P1">First point</param>
        /// <param name="P2">Second point</param>
        /// <param name="X3"></param>
        /// <param name="Y3"></param>
        /// <param name="Z3"></param>
        /// <returns>The result of the addition.</returns>
        static void Add(CurveEdwards448 P1, CurveEdwards448 P2, out BigInteger X3, out BigInteger Y3, out BigInteger Z3) {
            Assert.NotNull(P2, NYI.Throw);

            var A = P1.Z * P2.Z;
            var B = A * A;
            var C = P1.X * P2.X;
            var D = P1.Y * P2.Y;
            var E = CurveEdwards448.D * C * D;
            var F = B - E;
            var G = B + E;
            var H = (P1.X + P1.Y) * (P2.X + P2.Y);
            X3 = (A * F * (H - C - D)).Mod(P);
            Y3 = (A * G * (D - C)).Mod(P);
            Z3 = (F * G).Mod(P);
            }

        /// <summary>
        /// Add two points
        /// </summary>
        /// <param name="Point">Second point</param>
        /// <returns>The result of the addition.</returns>
        public override CurveEdwards Add(CurveEdwards Point) {
            Add(this, Point as CurveEdwards448, out var X3, out var Y3, out var Z3);

            var P2 = new CurveEdwards448() { X = X3, Y = Y3, Z = Z3 };
            return P2;
            }


        /// <summary>
        /// Add two points
        /// </summary>
        /// <param name="Point">Second point</param>
        /// <returns>The result of the addition.</returns>
        public override void Accumulate(CurveEdwards Point) {
            Add(this, Point as CurveEdwards448, out var X3, out var Y3, out var Z3);
            X = X3;
            Y = Y3;
            Z = Z3;
            }


        /// <summary>
        /// Generate the public parameter (a point on the curve)
        /// </summary>
        /// <param name="Private">The extended private key</param>
        /// <returns>The public key corresponding to Private (s.B)</returns>
        public static CurveEdwards448 GetPublic(BigInteger Private) => Base.Multiply(Private);

        /// <summary>
        /// Encode this point in the compressed buffer representation
        /// </summary>
        /// <returns>The encoded point.</returns>
        public override byte[] Encode() {
            Translate(out var X0, out var Y0);

            byte[] Buffer = new byte[57];
            var YBuf = Y0.ToByteArray();
            Array.Copy(YBuf, Buffer, YBuf.Length);
            if (!X0.IsEven) {        // Encode the sign bit
                Buffer[56] = (byte)(Buffer[56] | 0x80);
                }
            return Buffer;
            }


        /// <summary>
        /// Construct a point on the curve from a buffer.
        /// </summary>
        /// <param name="Data">The encoded data</param>
        /// <returns>The point created</returns>
        public static CurveEdwards448 Decode(byte[] Data) {
            if ((Data[56] & 0x80) == 0) {
                var Y0 = Data.BigIntegerLittleEndian();
                return new CurveEdwards448(Y0, false);
                }
            var Copy = Data.Duplicate();
            Copy[56] = (byte)(Data[56] & 0x7f);
            var Y1 = Copy.BigIntegerLittleEndian();
            return new CurveEdwards448(Y1, true);
            }


        /// <summary>
        /// Calculate the value of K for the domain parameters <paramref name="domain"/>,
        /// point <paramref name="encodedR"/> and data to be signed <paramref name="data"/>.
        /// </summary>
        /// <param name="domain">The domain parameter</param>
        /// <param name="encodedR">The encoding of the point R.</param>
        /// <param name="data">The data to sign.</param>
        /// <returns>The value HashModQ (<paramref name="domain"/>, <paramref name="encodedR"/>,
        ///     Public, <paramref name="data"/>)</returns>

        public override BigInteger GetK(
                byte[] domain,
                byte[] encodedR,
                byte[] data) => HashModQ(domain, encodedR, Encode(), data);

        /// <summary>
        /// Calculate the domain parameters for the cryptographic algoriothm <paramref name="cryptoAlgorithm"/>
        /// and encoded y value <paramref name="y"/>.
        /// </summary>
        /// <param name="cryptoAlgorithm">The cryptographic algorithm identifier (used to specify
        /// whether the signed data is prehashed or not.</param>
        /// <param name="y">The y value.</param>
        /// <returns>The domain parameter.</returns>
        public override byte[] Domain(
                CryptoAlgorithmId cryptoAlgorithm,
                byte[] y) => Dom4(cryptoAlgorithm, y);

        /// <summary>
        /// Calculate the domain parameters for the cryptographic algoriothm <paramref name="cryptoAlgorithm"/>
        /// and encoded y value <paramref name="y"/>.
        /// </summary>
        /// <param name="cryptoAlgorithm">The cryptographic algorithm identifier (used to specify
        /// whether the signed data is prehashed or not.</param>
        /// <param name="y">The y value.</param>
        /// <returns>The domain parameter.</returns>
        public static byte[] Dom4(CryptoAlgorithmId cryptoAlgorithm, byte[] y) {
            byte x = 0;
            switch (cryptoAlgorithm) {
                case CryptoAlgorithmId.Ed448: {
                    x = 0;
                    break;
                    }
                case CryptoAlgorithmId.Ed448ph: {
                    x = 1;
                    break;
                    }

                default:
                    break;
                }

            var Buffer = new MemoryStream();
            Buffer.Write("SigEd448".ToBytes());
            Buffer.WriteByte(x);
            if (y == null) {
                Buffer.WriteByte(0);
                }
            else {
                Buffer.WriteByte((byte)y.Length);
                Buffer.Write(y);
                }
            return Buffer.ToArray();
            }



        /// <summary>
        /// Calculate the SHA-2-512 hash of the inputs, convert to an integer and reduce
        /// modulo the subgroup. This is completely wrong of course because the spec requires
        /// SHA-3 SHAKE-256
        /// </summary>
        /// <param name="A0">First data input, ignored if null</param>
        /// <param name="A1">Second data input, ignored if null</param>
        /// <param name="A2">Third data input, ignored if null</param>
        /// <param name="A3">Fourth data input, ignored if null</param>
        /// <returns>The hashed and reduced inputs.</returns>
        public static BigInteger HashModQ(byte[] A0, byte[] A1, byte[] A2, byte[] A3 = null) {

            var Buffer = new MemoryStream();
            Buffer.Write(A0);
            Buffer.Write(A1);
            Buffer.Write(A2);
            Buffer.Write(A3);
            var Input = Buffer.ToArray();
            var Digest = SHAKE256.Process(Input, 114 * 8);
            var Result = Digest.BigIntegerLittleEndian();
            Result %= Q;

            return Result;
            }


        /// <summary>
        /// Verify a signature on a message according to RFC8032.
        /// </summary>
        /// <remarks>This method does not prehash the message data since if
        /// prehashing is desired, it is because the data needs to be hashed
        /// before being presented.</remarks>
        /// <param name="Public">The public key</param>
        /// <param name="Message">The message data.</param>
        /// <param name="Signature">The encoded signature data.</param>
        /// <param name="Context">Context value, if used.</param>
        /// <returns>True if signature verification succeeded, otherwise false.</returns>
        public bool VerifySignature(byte[] Public, byte[] Message, byte[] Signature, byte[] Context = null) {
            Assert.True(Public.Length == 57, InvalidOperation.Throw);
            Assert.True(Signature.Length == 114, InvalidOperation.Throw);

            //var A = Decode(Public);

            var Rs = Signature.Duplicate(0, 57);
            var R = Decode(Rs);


            var Bs = Signature.Duplicate(57, 57);
            var s = Bs.BigIntegerLittleEndian();

            if (s > Q) {
                return false;
                }

            var k = GetK(Context, Rs, Message);

            return Verify(k, s, R);
            }

        /// <summary>
        /// Verify that s.B = R + k.P where <paramref name="s"/> is s, <paramref name="curveR"/>
        /// is R, <paramref name="k"/> is k and P is the public key point.
        /// </summary>
        /// <param name="k">The scalar value being signed.</param>
        /// <param name="s">The signature scalar value.</param>
        /// <param name="curveR">The fixed point used to obscure the private key value.</param>
        /// <returns>True if the signature is correct, otherwise false.</returns>
        public override bool Verify(BigInteger k, BigInteger s, CurveEdwards curveR) {

            var sB = Base.Multiply(s);
            var hA = Multiply(k);
            var Rha = hA.Add(curveR);

            var Result = sB.Equal(Rha);

            return Result;
            }

        /// <summary>
        /// Return a threshold signature coordinator for this public key.
        /// </summary>
        /// <returns>The signature coordinator.</returns>
        public override ThresholdCoordinatorEdwards Coordinator() =>
                new ThresholdCoordinatorEdwards448(this);
        }



    /// <summary>
    /// Manages the public key
    /// </summary>
    public class CurveEdwards448Public : CurveEdwardsPublic {

        /// <summary>The public key, i.e. a point on the curve</summary>
        public CurveEdwards448 Public { get; }

        /// <summary>The public key, i.e. a point on the curve</summary>
        public override CurveEdwards PublicKey => Public;

        /// <summary>Encoded form of the public key.</summary>
        public override byte[] Encoding { get; }

        /// <summary>
        /// Construct from public key parameters.
        /// </summary>
        /// <param name="publicKey">The public key.</param>
        public CurveEdwards448Public(CurveEdwards448 publicKey) {
            this.Public = publicKey;
            this.Encoding = publicKey.Encode();
            }

        /// <summary>
        /// Construct from binary encoded form.
        /// </summary>
        /// <param name="Encoding">The binary encoded public key.</param>
        public CurveEdwards448Public(byte[] Encoding) {
            this.Public = CurveEdwards448.Decode(Encoding);
            this.Encoding = Encoding;
            }

        /// <summary>
        /// Verify a signature over the purported data digest.
        /// </summary>
        /// <param name="Signature">The signature blob value.</param>
        /// <param name="Context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <param name="Digest">The digest value to be verified.</param>
        /// <returns>True if the signature is valid, otherwise false.</returns>
        public bool Verify(byte[] Signature, byte[] Digest, byte[] Context = null) =>
                    Public.VerifySignature(Encoding, Digest, Signature, Context);

        /// <summary>
        /// Create a new ephemeral private key and use it to perform a key
        /// agreement.
        /// </summary>
        /// <returns>The key agreement parameters, the public key value and the
        /// key agreement.</returns>
        public CurveEdwards448Result Agreement() {
            var Private = new CurveEdwards448Private();

            return new CurveEdwards448Result() {
                EphemeralPublicValue = Private.Public,
                AgreementEd448 = Private.Agreement(this)
                };
            }


        /// <summary>
        /// Perform final stage in a Diffie Hellman Agreement to reduce an 
        /// array of carry returns to a single agreement result.
        /// </summary>
        /// <param name="Carry">The partial recryption results.</param>
        /// <returns>The key agreement value ZZ</returns>
        public CurveEdwards448 Agreement(CurveEdwards448[] Carry) {
            Assert.True(Carry.Length >= 1, InsufficientResults.Throw);

            var Total = CurveEdwards448.Neutral;
            foreach (var Part in Carry) {
                Total.Accumulate(Part);
                }

            return Total;
            }

        /// <summary>
        /// Combine the two public keys to create a composite public key.
        /// </summary>
        /// <param name="Contribution">The key contribution.</param>
        /// <returns>The composite key</returns>
        public CurveEdwards448Public Combine(CurveEdwards448Public Contribution) {
            var NewPublic = Public.Add(Contribution.Public);
            return new CurveEdwards448Public((CurveEdwards448)NewPublic);
            }


        /// <summary>
        /// Combine the two public keys to create a composite public key.
        /// </summary>
        /// <param name="Contribution">The key contribution.</param>
        /// <returns>The composite key</returns>
        public override IKeyAdvancedPublic Combine(IKeyAdvancedPublic Contribution) =>
            Combine(Contribution as CurveEdwards448Public);
        }



    /// <summary>
    /// Manages the private key.
    /// </summary>
    public class CurveEdwards448Private : CurveEdwardsPrivate {

        /// <summary>The random secret used to generate the private key</summary>
        byte[] Secret { get; }

        /// <summary>Hash of the secret value bytes [0:31]</summary>
        byte[] PreSecret { get; }



        /// <summary>Hash of the secret value bytes [31:63]</summary>
        byte[] HashPrefix { get; }


        /// <summary>The public key, a point on the curve</summary>
        public CurveEdwards448Public Public { get; }

        /// <summary>The corresponding public key</summary>
        public override CurveEdwards PublicPoint => Public.Public;

        /// <summary>The wire encoding. Null if the key is not exportable</summary>
        public byte[] Encoding { get; }

        /// <summary>If true, this is a recryption key.</summary>
        public bool IsRecryption { get; set; } = false;


        /// <summary>
        /// Generate a new private key
        /// </summary>
        /// <param name="Exportable">If true, the private key is exportable</param>
        public CurveEdwards448Private(bool Exportable = false) :
                this(Platform.GetRandomBytes(32), Exportable) => Secret = Platform.GetRandomBytes(32);

        /// <summary>
        /// Construct a private key from the specified binary representation.
        /// </summary>
        /// <param name="secret">The byte array used to generate the secret key</param>
        /// <param name="exportable">If true, the private key is exportable</param>
        public CurveEdwards448Private(byte[] secret, bool exportable = false) {
            Secret = secret;

            var Buffer = SHAKE256.Process(secret, 114 * 8);
            PreSecret = Buffer.Duplicate(0, 57);
            HashPrefix = Buffer.Duplicate(57, 57);
            Private = ExtractPrivate(PreSecret);

            var PublicPoint = CurveEdwards448.GetPublic(Private);
            Public = new CurveEdwards448Public(PublicPoint);
            if (exportable) {
                Encoding = Secret;
                }
            }


        /// <summary>
        /// Construct a private key from the specified input buffer.
        /// </summary>
        /// <param name="privateKey">The private key</param>
        /// <param name="exportable">If true, the private key is exportable</param>
        public CurveEdwards448Private(BigInteger privateKey, bool exportable = false) {
            this.Private = privateKey;
            this.Secret = privateKey.ToByteArray();

            var PublicPoint = CurveEdwards448.GetPublic(privateKey);
            Public = new CurveEdwards448Public(PublicPoint);

            if (exportable) {
                Encoding = Secret;
                }
            }



        /// <summary>
        /// Generate a new private key using the specified Nonce value to generate
        /// a Witness value for the private key.
        /// </summary>
        /// <param name="blind">The blinding value n.</param>
        /// <param name="witness">The point [s-SHA512(n)]B where s is the secret key.</param>
        /// <param name="exportable">If true, the private key is exportable</param>
        public CurveEdwards448Private(
                    byte[] blind,
                    out CurveEdwards448 witness,
                    bool exportable = false) {

            var SecretLocal = ExtractPrivate(Platform.GetRandomBytes(32));
            var SecretBlind = ExtractPrivate(blind);

            var SecretValue = (SecretLocal + SecretBlind).Mod(DomainParameters.Curve448.P);
            var Secret = ValidatePrivateBytes(SecretValue.ToByteArray());
            PreSecret = Secret;

            // Calculate the Prefix
            var Buffer = Platform.SHA3_512.Process(Secret);
            HashPrefix = Buffer.Duplicate(32, 32);

            // Calculate the public point
            var PublicPoint = CurveEdwards448.GetPublic(Private);
            Public = new CurveEdwards448Public(PublicPoint);

            // Calculate the witness value
            witness = CurveEdwards448.GetPublic(SecretLocal);

            if (exportable) {
                Encoding = this.Secret;
                }
            }


        /// <summary>
        /// Create a new key pair instance for this private key.
        /// </summary>
        /// <param name="keyType">The key type.</param>
        /// <param name="keyUses">The permitted key uses.</param>
        /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
        /// in signature operations.</param>
        /// <returns>The KeyPair instance.</returns>
        public override KeyPairAdvanced GetKeyPair(
                    KeySecurity keyType = KeySecurity.Public,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default) => new
                        KeyPairEd448(this, keyType, keyUses, cryptoAlgorithmID);


        /// <summary>
        /// Verify that a witness value was used to construct a public key.
        /// </summary>
        /// <param name="blind">The blinding value.</param>
        /// <param name="witness">The witness value.</param>
        /// <param name="publicKey">The resulting private key.</param>
        /// <returns>True if the value was correctly constructed using the specified witness, otherwise false.</returns>
        public bool VerifyWitness(byte[] blind, CurveEdwards448 witness, CurveEdwards448 publicKey) {
            var SecretBlind = ExtractPrivate(blind);
            var PublicBlind = CurveEdwards448.GetPublic(SecretBlind);

            var TestPublic = witness.Add(PublicBlind);
            return TestPublic.Equal(publicKey);
            }


        /// <summary>
        /// Create the extended private key. The Private key is extended using the
        /// hash value.
        /// </summary>
        /// <param name="hash">The hash value</param>
        /// <returns>The private key.</returns>
        public BigInteger ExtractPrivate(byte[] hash) => ValidatePrivateBytes(hash).BigIntegerLittleEndian();


        /// <summary>
        /// Create the extended private key. The Private key is extended using the
        /// hash value.
        /// </summary>
        /// <param name="hash">The hash value</param>
        /// <returns>True if the private key is valid, otherwise false.</returns>
        public byte[] ValidatePrivateBytes(byte[] hash) {
            var Copy = new byte[57];
            Array.Copy(hash, Copy, 57); // bytes 0-31

            Copy[0] = (byte)(Copy[0] & 0xfC);
            Copy[55] = (byte)(Copy[55] | 0x80);
            Copy[56] = 0;
            return Copy;
            }

        /// <summary>
        /// Perform a presigning operation on the message <paramref name="message"/> with
        /// context <paramref name="context"/>.
        /// </summary>
        /// <param name="message">The message to pre-sign</param>
        /// <param name="context">Optional signature context.</param>
        /// <returns>The scalar r and point r.B.</returns>
        public override (BigInteger, byte[]) PreSign(byte[] message, byte[] context = null) {
            var r = CurveEdwards448.HashModQ(context, HashPrefix, message);
            var R = CurveEdwards448.Base.Multiply(r);
            var Rs = R.Encode();
            return (r, Rs);
            }

        /// <summary>
        /// Sign the scalar data value <paramref name="k"/> using scalar presignature
        /// value <paramref name="r"/>.
        /// </summary>
        /// <param name="k">The data to sign.</param>
        /// <param name="r">The presignature value.</param>
        /// <returns>The value r+k* Private.</returns>
        public override BigInteger Sign(BigInteger k, BigInteger r) => (r + k * Private) % DomainParameters.Curve448.Q;


        /// <summary>
        /// Encode the signature with point <paramref name="encodedR"/> and
        /// scalar value <paramref name="scalar"/>.
        /// </summary>
        /// <param name="encodedR">The point value.</param>
        /// <param name="scalar">The signature scalar.</param>
        /// <returns>The encoded signature.</returns>
        public override byte[] EncodeSignature(byte[] encodedR, BigInteger scalar) {
            var Bs = scalar.ToByteArrayLittleEndian();
            var Result = new byte[114]; // Is set to zeros
            Array.Copy(encodedR, Result, encodedR.Length); // little endian so trailing zeroes don't matter.
            Array.Copy(Bs, 0, Result, 57, Bs.Length);

            return Result;
            }





        /// <summary>
        /// Perform a partial key agreement.
        /// </summary>
        /// <param name="keyPair">The key pair to perform the agreement against.</param>
        /// <returns>The key agreement result.</returns>
        public override KeyAgreementResult Agreement(KeyPair keyPair) {
            var publicKey = (keyPair as KeyPairEd448).PublicKey;
            var agreement = Agreement(publicKey);
            return new CurveEdwards448Result() { AgreementEd448 = agreement };
            }


        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to a public key
        /// </summary>
        /// <param name="publicKey">Public key parameters</param>
        /// <returns>The key agreement value ZZ</returns>
        public CurveEdwards448 Agreement(CurveEdwards448Public publicKey) => publicKey.Public.Multiply(Private);


        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to a private key
        /// </summary>
        /// <param name="publicKey">Public key parameters</param>
        /// <param name="carry">Recryption carry over value, to be combined with the
        /// result of this key agreement.</param>
        /// <returns>The key agreement value ZZ</returns>
        public CurveEdwards448 Agreement(CurveEdwards448Public publicKey, CurveEdwards448 carry) {
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
        public override IKeyAdvancedPrivate[] MakeThresholdKeySet(int shares) {
            BigInteger Accumulator = 0;
            var Result = new IKeyAdvancedPrivate[shares];

            for (var i = 1; i < shares; i++) {
                //var Range = 2 * Accumulator / (1+ Shares - i);
                //var NewPrivate = Platform.GetRandomBigInteger(Range);

                //Assert.True(NewPrivate > 0 & NewPrivate < Private, CryptographicException.Throw);

                //Result[i] = new CurveEdwards448Private(NewPrivate) { IsRecryption = true };
                //Accumulator -= NewPrivate;


                var NewPrivate = Platform.GetRandomBigInteger(CurveEdwards448.Q);
                Result[i] = new CurveEdwards448Private(NewPrivate, exportable: true) { IsRecryption = true };
                Accumulator = (Accumulator + NewPrivate) % (CurveEdwards448.Q);

                }

            //Assert.True(Accumulator > 0 & Accumulator < Private, CryptographicException.Throw);

            Result[0] = new CurveEdwards448Private(
                (CurveEdwards448.Q + Private - Accumulator) % (CurveEdwards448.Q)) {
                IsRecryption = true
                };
            return Result;

            }

        /// <summary>
        /// Make a recryption keyset by splitting the private key.
        /// </summary>
        /// <param name="Shares">Number of shares to create</param>
        /// <returns>Array shares.</returns>
        public override IKeyAdvancedPrivate CompleteRecryptionKeySet(IEnumerable<KeyPair> Shares) {
            BigInteger Accumulator = 0;

            foreach (var share in Shares) {
                var key = share as KeyPairEd448;
                var privateKey = (key.IKeyAdvancedPrivate as CurveEdwards448Private);

                Accumulator = (Accumulator + privateKey.Private).Mod(CurveEdwards448.Q);
                }

            return new CurveEdwards25519Private(
                (CurveEdwards448.Q + Private - Accumulator).Mod(CurveEdwards448.Q)) {
                IsRecryption = true
                };
            }


        /// <summary>
        /// Combine the two public keys to create a composite public key.
        /// </summary>
        /// <param name="contribution">The key contribution.</param>
        /// <param name="keySecurity">The key security model.</param>
        /// <param name="keyUses">The allowed key uses.</param>
        /// <returns>The composite key</returns>
        public CurveEdwards448Private Combine(CurveEdwards448Private contribution,
                    KeySecurity keySecurity = KeySecurity.Bound,
                    KeyUses keyUses = KeyUses.Any) {
            var NewPrivate = (Private + contribution.Private).Mod(CurveEdwards448.Q);
            return new CurveEdwards448Private(NewPrivate, keySecurity.IsExportable());
            }


        /// <summary>
        /// Combine the two public keys to create a composite public key.
        /// </summary>
        /// <param name="contribution">The key contribution.</param>
        /// <param name="keySecurity">The key security model.</param>
        /// <param name="keyUses">The allowed key uses.</param>
        /// <returns>The composite key</returns>
        public override IKeyAdvancedPrivate Combine(IKeyAdvancedPrivate contribution,
                    KeySecurity keySecurity = KeySecurity.Bound,
                    KeyUses keyUses = KeyUses.Any) =>
            Combine(contribution as CurveEdwards448Private, keySecurity, keyUses);
        #endregion

        }


    /// <summary>
    /// Represent the result of a Diffie Hellman Key exchange.
    /// </summary>
    public class CurveEdwards448Result : ResultECDH {
        ///<summary>The Jose curve name</summary>
        public override string CurveJose => CurveEdwards448.CurveJose;

        ///<summary>The key agreement value, a point on the curve.</summary>
        public override Curve Agreement => AgreementEd448;

        /// <summary>The key agreement result</summary>
        public CurveEdwards448 AgreementEd448 { get; set; }

        /// <summary>
        /// The DER encoding of the data. This is the IKM octet sequence.
        /// </summary>
        /// <returns></returns>
        public override byte[] DER() => AgreementEd448.Encode();

        /// <summary>The key agreement result as a byte array</summary>
        public override byte[] IKM => AgreementEd448.Encode();

        /// <summary>
        /// The Ephemeral public key
        /// </summary>
        public override KeyPair EphemeralKeyPair => new KeyPairEd448(EphemeralKeyValue448);

        /// <summary>Public key generated by ephemeral key generation.</summary>
        CurveEdwards448Public EphemeralKeyValue448 => EphemeralPublicValue as CurveEdwards448Public;
        }
    }
