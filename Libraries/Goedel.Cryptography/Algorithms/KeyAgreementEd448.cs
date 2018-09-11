using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Goedel.ASN;
using Goedel.Utilities;
using Goedel.Cryptography.PKIX;
using Goedel.Cryptography;

namespace Goedel.Cryptography.Algorithms {



    /// <summary>
    /// Edwards Curve [x^2 = (y^2 - 1) / (d y^2 + 1) (mod p)] for 2^448 - 2^224 - 1
    /// </summary>
    public class CurveEdwards448 : CurveEdwards {

        ///<summary>The modulus, p = 2^448 - 2^224 - 1</summary>
        readonly static BigInteger P = BigInteger.Pow(2, 448) - BigInteger.Pow(2, 224) - 1;

        ///<summary>The modulus, p = 2^448 - 2^224 - 1</summary>
        public override BigInteger Prime  => P; 


        ///<summary>The Curve Constant d</summary>
        public override BigInteger CurveConstrantD  => D; 

        ///<summary>The Curve Constant d</summary>
        public static readonly BigInteger D = P-39081;

        ///<summary>The square root of -1.</summary>
        public override BigInteger SqrtMinus1  => _SqrtMinus1; 
        readonly static BigInteger _SqrtMinus1 = P.SqrtMinus1();

        ///<summary>The small order subgroup q</summary>
        public static readonly BigInteger Q =
            BigInteger.Pow(2, 446) -
            "13818066809895115352007386748515426880336692474882178609894547503885".DecimalToBigInteger();


        static readonly BigInteger Curve448BaseY = (
            "298819210078481492676017930443930673437544040154080242095928241" +
            "372331506189835876003536878655418784733982303233503462500531545" +
            "062832660").DecimalToBigInteger();

        static readonly BigInteger Curve448BaseX = (
            "224580040295924300187604334099896036246789641632564134246125461" +
            "686950415467406032909029192869357953282578032075146446173674602" +
            "635247710").DecimalToBigInteger();

        /// <summary>The base point for the subgroup</summary>
        static readonly CurveEdwards448 _Base = new CurveEdwards448(Curve448BaseY, false); // { X = Curve448BaseX, Y = Curve448BaseY, Z = 1 };

        /// <summary>The base point for the subgroup</summary>
        public static CurveEdwards448 Base  => _Base.Copy(); 

        /// <summary>The point P such that P + Q = Q for all Q</summary>
        static readonly CurveEdwards448 _Neutral = new CurveEdwards448()  { X=0, Y= 1 , Z=1};

        /// <summary>The point P such that P + Q = Q for all Q</summary>
        public static CurveEdwards448 Neutral  => _Neutral.Copy(); 

        /// <summary>The number of bits to multiply</summary>
        public const int Bits = 448;

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
            var yy = (Y * Y - 1).Mod(P);
            var zz = (CurveConstrantD * Y * Y - 1).Mod(P);
            var x2 = (yy * zz.ModularInverse(P)).Mod(P);

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

            int i = 0;
            while (BitIndex.GoingUp) {
                Console.Write($"{i++}:  ");


                if (BitIndex.Up()) {
                    Q.Accumulate(P);
                    }
                P.Double();

                Console.WriteLine($"{Q.Z}");
                }

            return Q;
            }


        /// <summary>
        /// Replace the current point value with the current value added to itself
        /// (used to implement multiply)
        /// </summary>
        public override void Double() {
            var x1s = (X * X).Mod(P);
            var y1s = (Y * Y).Mod(P);
            var z1s = (Z * Z).Mod(P);
            var xys = (X + Y).Mod(P);
            var F = (x1s + y1s).Mod(P);
            var J = (F - 2 * z1s).Mod(P);
            var B = (xys * xys).Mod(P);

            X = ((B - F) * J).Mod(P);
            Y = (F * (x1s - y1s)).Mod(P);
            Z = (F * J).Mod(P);
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
            X3 = (A * F * (H - C - D)) .Mod(P);
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
        public byte[] Encode() {
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
            var Y1 = Copy.BigIntegerLittleEndian();
            return new CurveEdwards448(Y1, true);
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
            var SHA512 = Platform.SHA3_512.CryptoProviderDigest();
            if (A0 != null) {
                SHA512.ProcessData(A0);
                }
            if (A1 != null) {
                SHA512.ProcessData(A1);
                }
            if (A2 != null) {
                SHA512.ProcessData(A2);
                }
            if (A3 != null) {
                SHA512.ProcessData(A3);
                }
            var CryptoData = new CryptoDataEncoder(CryptoAlgorithmID.Default, SHA512);
            SHA512.Complete(CryptoData);

            var Digest = CryptoData.Integrity;
            var Result = Digest.BigIntegerLittleEndian();

            Result = Result % Q;

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
        public bool Verify(byte[] Public, byte[] Message, byte[] Signature, byte[] Context = null) {
            Assert.True(Public.Length == 57, InvalidOperation.Throw);
            Assert.True(Signature.Length == 114, InvalidOperation.Throw);

            var A = Decode(Public);

            var Rs = Signature.Duplicate(0, 57);
            //var R = Decode(Rs);

            var Bs = Signature.Duplicate(57, 57);
            var s = Bs.BigIntegerLittleEndian();

            if (s > Q) {
                return false;
                }

            var h = HashModQ(Context, Rs, Public, Message);

            var sB = Base.Multiply(s);
            var hA = A.Multiply(h);

            return sB.Equal(hA);
            }


        }



    /// <summary>
    /// Manages the public key
    /// </summary>
    public class CurveEdwards448Public : IKeyAdvancedPublic {

        /// <summary>The public key, i.e. a point on the curve</summary>
        public CurveEdwards448 Public { get; }

        /// <summary>Encoded form of the public key.</summary>
        public byte[] Encoding { get; }

        /// <summary>
        /// Construct from public key parameters.
        /// </summary>
        /// <param name="Public">The public key.</param>
        public CurveEdwards448Public(CurveEdwards448 Public) {
            this.Public = Public;
            this.Encoding = Public.Encode();
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
        /// Create a new ephemeral private key and use it to perform a key
        /// agreement.
        /// </summary>
        /// <returns>The key agreement parameters, the public key value and the
        /// key agreement.</returns>
        public CurveEdwards448Result Agreement() {
            var Private = new CurveEdwards448Private();

            return new CurveEdwards448Result() {
                EphemeralPublicValue = Private.Public,
                Agreement = Private.Agreement(this)
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
        public IKeyAdvancedPublic Combine(IKeyAdvancedPublic Contribution) =>
            Combine(Contribution as CurveEdwards448Public);
        }


    /// <summary>
    /// Manages the private key.
    /// </summary>
    public class CurveEdwards448Private : IKeyAdvancedPrivate {

        /// <summary>The random secret used to generate the private key</summary>
        byte[] Secret { get; }

        /// <summary>The private key, i.e. a scalar</summary>
        public BigInteger Private { get; }

        /// <summary>Hash of the secret value bytes [0:31]</summary>
        byte[] PreSecret { get; }

        /// <summary>Hash of the secret value bytes [31:63]</summary>
        byte[] HashPrefix { get; }

        /// <summary>The corresponding public key</summary>
        public CurveEdwards448Public Public { get; }

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
        /// <param name="Secret">The byte array used to generate the secret key</param>
        /// <param name="Exportable">If true, the private key is exportable</param>
        public CurveEdwards448Private(byte[] Secret, bool Exportable = false) {
            this.Secret = Secret;

            var Buffer = SHAKE256.Process(Secret, 114 * 8);
            PreSecret = Buffer.Duplicate(0, 57);
            HashPrefix = Buffer.Duplicate(57, 57);
            Private = ExtractPrivate(PreSecret);

            var PublicPoint = CurveEdwards448.GetPublic(Private);
            Public = new CurveEdwards448Public(PublicPoint);
            if (Exportable) {
                Encoding = this.Secret;
                }
            }


        /// <summary>
        /// Construct a private key from the specified input buffer.
        /// </summary>
        /// <param name="Private">The private key</param>
        /// <param name="Exportable">If true, the private key is exportable</param>
        public CurveEdwards448Private(BigInteger Private, bool Exportable = false) {
            this.Private = Private;
            this.Secret = Private.ToByteArray();

            //var Buffer = Platform.SHA2_512.Process(Secret);
            //PreSecret = Secret;
            //HashPrefix = Buffer.Duplicate(32, 32);



            var PublicPoint = CurveEdwards448.GetPublic(Private);
            Public = new CurveEdwards448Public(PublicPoint);

            if (Exportable) {
                Encoding = this.Secret;
                }
            }



        /// <summary>
        /// Generate a new private key using the specified Nonce value to generate
        /// a Witness value for the private key.
        /// </summary>
        /// <param name="Blind">The blinding value n.</param>
        /// <param name="Witness">The point [s-SHA512(n)]B where s is the secret key.</param>
        /// <param name="Exportable">If true, the private key is exportable</param>
        public CurveEdwards448Private(
                    byte[] Blind, out CurveEdwards448 Witness,
                    bool Exportable = false) {

            var SecretLocal = ExtractPrivate(Platform.GetRandomBytes(32));
            var SecretBlind = ExtractPrivate(Blind);

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
            Witness = CurveEdwards448.GetPublic(SecretLocal);

            if (Exportable) {
                Encoding = this.Secret;
                }
            }

        /// <summary>
        /// Verify that a witness value was used to construct a public key.
        /// </summary>
        /// <param name="Blind">The blinding value.</param>
        /// <param name="Witness">The witness value.</param>
        /// <param name="Public">The resulting private key.</param>
        /// <returns>True if the value was correctly constructed using the specified witness, otherwise false.</returns>
        public bool VerifyWitness(byte[] Blind, CurveEdwards448 Witness, CurveEdwards448 Public) {
            var SecretBlind = ExtractPrivate(Blind);
            var PublicBlind = CurveEdwards448.GetPublic(SecretBlind);

            var TestPublic = Witness.Add(PublicBlind);
            return TestPublic.Equal(Public);
            }


        /// <summary>
        /// Create the extended private key. The Private key is extended using the
        /// hash value.
        /// </summary>
        /// <param name="Hash">The hash value</param>
        /// <returns>The private key.</returns>
        public BigInteger ExtractPrivate(byte[] Hash) => ValidatePrivateBytes(Hash).BigIntegerLittleEndian();


        /// <summary>
        /// Create the extended private key. The Private key is extended using the
        /// hash value.
        /// </summary>
        /// <param name="Hash">The hash value</param>
        /// <returns>True if the private key is valid, otherwise false.</returns>
        public byte[] ValidatePrivateBytes(byte[] Hash) {
            var Copy = new byte[57];
            Array.Copy(Hash, Copy, 57); // bytes 0-31

            Copy[0] = (byte)(Copy[0] & 0xfC);
            Copy[56] = (byte)(Copy[56] | 0x80);
            Copy[56] = 0;
            return Copy;
            }


        /// <summary>
        /// Sign a message using the public key according to RFC8032
        /// </summary>
        /// <remarks>This method does not prehash the message data since if
        /// prehashing is desired, it is because the data needs to be hashed
        /// before being presented.</remarks>
        /// <param name="Message">The message</param>
        /// <param name="Context">Context value, if used.</param>
        /// <returns>The encoded signature data</returns>
        public byte[] Sign(byte[] Message, byte[] Context = null) {

            var r = CurveEdwards448.HashModQ(Context, HashPrefix, Message);
            var R = CurveEdwards448.Base.Multiply(r);
            var Rs = R.Encode();

            var h = CurveEdwards448.HashModQ(Context, Rs, Public.Encoding, Message);
            var s = (r + h * Private) % CurveEdwards448.Q;

            var Bs = s.ToByteArray();

            var Result = new byte[114];
            Array.Copy(Rs, Result, 57);
            Array.Copy(Bs, 0, Result, 57, 57);

            return Result;
            }




        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to a public key
        /// </summary>
        /// <param name="Public">Public key parameters</param>
        /// <returns>The key agreement value ZZ</returns>
        public CurveEdwards448 Agreement(CurveEdwards448Public Public) => (CurveEdwards448)Public.Public.Multiply(Private);


        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to a private key
        /// </summary>
        /// <param name="Public">Public key parameters</param>
        /// <param name="Carry">Recryption carry over value, to be combined with the
        /// result of this key agreement.</param>
        /// <returns>The key agreement value ZZ</returns>
        public CurveEdwards448 Agreement(CurveEdwards448Public Public, CurveEdwards448 Carry) {
            var Result = (CurveEdwards448)Public.Public.Multiply(Private);
            Result.Accumulate(Carry);

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
        /// <param name="Shares">The number of keys to create.</param>
        /// <returns>The created keys</returns>
        public IKeyAdvancedPrivate[] MakeRecryptionKeySet(int Shares) {
            BigInteger Accumulator = 0;
            var Result = new IKeyAdvancedPrivate[Shares];

            for (var i = 1; i < Shares; i++) {
                //var Range = 2 * Accumulator / (1+ Shares - i);
                //var NewPrivate = Platform.GetRandomBigInteger(Range);

                //Assert.True(NewPrivate > 0 & NewPrivate < Private, CryptographicException.Throw);

                //Result[i] = new CurveEdwards448Private(NewPrivate) { IsRecryption = true };
                //Accumulator -= NewPrivate;


                var NewPrivate = Platform.GetRandomBigInteger(CurveEdwards448.Q);
                Result[i] = new CurveEdwards448Private(NewPrivate) { IsRecryption = true };
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
        /// Combine the two public keys to create a composite public key.
        /// </summary>
        /// <param name="Contribution">The key contribution.</param>
        /// <returns>The composite key</returns>
        public CurveEdwards448Private Combine(CurveEdwards448Private Contribution) {
            var NewPrivate = (Private + Contribution.Private).Mod(CurveEdwards448.Q);
            return new CurveEdwards448Private(NewPrivate);
            }


        /// <summary>
        /// Combine the two public keys to create a composite public key.
        /// </summary>
        /// <param name="Contribution">The key contribution.</param>
        /// <returns>The composite key</returns>
        public IKeyAdvancedPrivate Combine(IKeyAdvancedPrivate Contribution) =>
            Combine(Contribution as DiffeHellmanPrivate);
        #endregion

        }


    /// <summary>
    /// Represent the result of a Diffie Hellman Key exchange.
    /// </summary>
    public class CurveEdwards448Result : ResultECDH {

        /// <summary>The key agreement result</summary>
        public CurveEdwards448 Agreement;

        /// <summary>
        /// The DER encoding of the data. This is the IKM octet sequence.
        /// </summary>
        /// <returns></returns>
        public override byte[] DER() => Agreement.Encode();


        /// <summary>The key agreement result as a byte array</summary>
        public override byte[] IKM  => Agreement.Encode();

        /// <summary>
        /// The Ephemeral public key
        /// </summary>
        public override KeyPair EphemeralKeyPair => new KeyPairEd448(EphemeralKeyValue448);


        /// <summary>Public key generated by ephemeral key generation.</summary>
        CurveEdwards448Public EphemeralKeyValue448 => EphemeralPublicValue as CurveEdwards448Public;

        }


    }
