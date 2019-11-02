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
    /// Implement Diffie Hellman Key operations. Note that this is a standalone
    /// class and does not inherit from the KeyPair class to provide hooks for
    /// implementing a provider, etc. This is in DHKeyPair.
    /// </summary>
    public class DiffeHellmanPublic : IKeyAdvancedPublic {


        /// <summary>
        /// The shared domain parameters
        /// </summary>

        public DHDomain DHDomain { get; }
        
        /// <summary>Group modulus</summary>
        public BigInteger Modulus { get; }

        /// <summary>Generator</summary>
        public BigInteger Generator { get; }

        /// <summary>Public Key</summary>
        public BigInteger Public { get; protected set; }

        #region // Constructors

        /// <summary>
        /// Create a new set of Diffie Hellman group parameters.
        /// </summary>
        /// <param name="Bits">The number of bits, this identifies the group modulus </param>
        public DiffeHellmanPublic(int Bits=2048) {
            switch (Bits) {
                case 0:
                case 2048: {
                    DHDomain = DHDomain.DHDomain2048;
                    break;
                    }
                case 4096: {
                    DHDomain = DHDomain.DHDomain4096;
                    break;
                    }
                default:  {
                    throw new KeySizeNotSupported();
                    }
                }
            Modulus = DHDomain.BigIntegerP;
            Generator = DHDomain.BigIntegerG;
            }

        /// <summary>
        /// Create a new set of Diffie Hellman parameters using the shared modulus, 
        /// a newly constructed generator and public and private keys.
        /// </summary>
        /// <param name="DHDomain">The shared parameters</param>
        /// <param name="Public">Optional public value</param>
        public DiffeHellmanPublic(DHDomain DHDomain, BigInteger? Public=null)  {
            this.DHDomain = DHDomain;
            Modulus = DHDomain.BigIntegerP;
            Generator = DHDomain.BigIntegerG;
            if (Public != null) {
                this.Public = (BigInteger)Public;
                }
            }

        /// <summary>
        /// Clone the public components of the key pair <paramref name="Base"/>.
        /// </summary>
        /// <param name="Base">The key pair to copy.</param>
        public DiffeHellmanPublic(DiffeHellmanPublic Base) {
            DHDomain = Base.DHDomain;
            Modulus = Base.Modulus;
            Generator = Base.Generator;
            Public = Base.Public;
            }


        /// <summary>
        /// Construct from public key parameters
        /// </summary>
        /// <param name="PKIXParameters">The key parameters</param>
        public DiffeHellmanPublic (PKIXPublicKeyDH PKIXParameters) {
            DHDomain = PKIXParameters.Domain;
            Assert.NotNull(DHDomain, UnknownNamedParameters.Throw);

            Modulus = DHDomain.BigIntegerP;
            Generator = DHDomain.BigIntegerG;
            Public = PKIXParameters.Public.ToBigInteger();

            }

        #endregion


        /// <summary>
        /// Check that the Diffie Hellman parameters presented match those of this Key.
        /// </summary>
        /// <param name="Key">The key to verify</param>
        public void Verify(DiffeHellmanPublic Key) {
            Assert.True(Key.Modulus == Modulus, CryptographicException.Throw);
            Assert.True(Key.Generator == Generator, CryptographicException.Throw);
            }


        #region // Key Agreement methods

        /// <summary>
        /// Create a new ephemeral private key and use it to perform a key
        /// agreement.
        /// </summary>
        /// <returns>The key agreement parameters, the public key value and the
        /// key agreement.</returns>
        public ResultDiffieHellman Agreement() {
            var Private = new DiffeHellmanPrivate(this);
            var DiffeHellmanPublic = Private.DiffeHellmanPublic;

            var Result = new ResultDiffieHellman() {
                EphemeralPublicValue = Private.DiffeHellmanPublic,
                Agreement = Private.Agreement(this)
                };

            return Result;
            }




        /// <summary>
        /// Perform final stage in a Diffie Hellman Agreement to reduce an 
        /// array of carry returns to a single agreement result.
        /// </summary>
        /// <param name="Carry">The partial recryption results.</param>
        /// <returns>The key agreement value ZZ</returns>
        public BigInteger Agreement(BigInteger[] Carry) {

            Assert.True(Carry.Length >= 1, InsufficientResults.Throw);

            var Accumulator = Carry[0];
            for (var i = 1; i < Carry.Length; i++) {
                Accumulator *= Carry[i];
                }
            return Accumulator % Modulus;
            }

        #endregion

        #region // Advanced 

        /// <summary>
        /// Combine the two public keys to create a composite public key.
        /// </summary>
        /// <param name="Contribution">The key contribution.</param>
        /// <returns>The composite key</returns>
        public DiffeHellmanPublic Combine (DiffeHellmanPublic Contribution) {
            var NewPublic = (Public * Contribution.Public) % Modulus;
            return new DiffeHellmanPublic(DHDomain, NewPublic);
            }


        /// <summary>
        /// Combine the two public keys to create a composite public key.
        /// </summary>
        /// <param name="Contribution">The key contribution.</param>
        /// <returns>The composite key</returns>
        public IKeyAdvancedPublic Combine(IKeyAdvancedPublic Contribution) =>
            Combine(Contribution as DiffeHellmanPublic);

        #endregion
        }

    /// <summary>
    /// Represents a set of Diffie Hellman parameters.
    /// </summary>
    public class DiffeHellmanPrivate : DiffeHellmanPublic, IKeyAdvancedPrivate {

        /// <summary>Private Key</summary>
        public BigInteger Private { get; set; }

        /// <summary>If true, this key is part of a recryption set.</summary>
        public bool IsRecryption { get; set; }

        DiffeHellmanPublic _DiffeHellmanPublic = null;

        /// <summary>
        /// Return the public key.
        /// </summary>
        public DiffeHellmanPublic DiffeHellmanPublic {
            get {
                if (_DiffeHellmanPublic == null) {
                    _DiffeHellmanPublic = new DiffeHellmanPublic(DHDomain, Public);
                    }
                return _DiffeHellmanPublic;
                }
            }


        #region // Constructors

        /// <summary>
        /// Create a new set of Diffie Hellman parameters using the shared modulus, 
        /// a newly constructed generator and public and private keys.
        /// </summary>
        /// <param name="Bits">The number of bits in the modulus to be created. Valid values
        /// are 2048 and 4096</param>
        public DiffeHellmanPrivate(int Bits=2048) : base(Bits) {
            Private = Platform.GetRandomBigInteger(Modulus);
            Public = BigInteger.ModPow(Generator, Private, Modulus);
            IsRecryption = false;
            }

        /// <summary>
        /// Create a new set of Diffie Hellman parameters using the shared modulus, 
        /// a newly constructed generator and public and private keys.
        /// </summary>
        /// <param name="DiffeHellmanPublic">Public key to use to specify the
        /// modulus and generator</param>
        public DiffeHellmanPrivate(DiffeHellmanPublic DiffeHellmanPublic) : 
                     base(DiffeHellmanPublic.DHDomain) {

            Private = Platform.GetRandomBigInteger(Modulus);
            Public = BigInteger.ModPow(Generator, Private, Modulus);
            IsRecryption = false;
            }

        /// <summary>
        /// Create a new set of Diffie Hellman parameters using the shared modulus, 
        /// a newly constructed generator and public and private keys.
        /// </summary>
        /// <param name="PKIXPrivateKeyDH">Key parameters</param>
        public DiffeHellmanPrivate(PKIXPrivateKeyDH PKIXPrivateKeyDH) : base (PKIXPrivateKeyDH.Domain) {
            Private = PKIXPrivateKeyDH.Private.ToBigInteger();
            Public = PKIXPrivateKeyDH.Public.ToBigInteger();
            IsRecryption = false;
            }

        private DiffeHellmanPrivate (BigInteger Private) {
            this.Private = Private;
            Public = BigInteger.ModPow(Generator, Private, Modulus);
            }

        #endregion
        #region // Key Agreement methods

        /// <summary>
        /// Perform a partial key agreement.
        /// </summary>
        /// <param name="keyPair">The key pair to perform the agreement against.</param>
        /// <returns>The key agreement result.</returns>
        public KeyAgreementResult Agreement(KeyPair keyPair) {
            var agreement = Agreement((keyPair as KeyPairAdvanced).IKeyAdvancedPublic);
            return new ResultDiffieHellman() { Agreement = agreement };
            }


        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to this private key
        /// </summary>
        /// <param name="Public">Set of newly created DH parameters for Alice</param>
        /// <returns>The key agreement value ZZ</returns>
        public BigInteger Agreement(IKeyAdvancedPublic Public) {
            var PublicDH = Public as DiffeHellmanPublic;
            Verify(PublicDH);
            return BigInteger.ModPow(PublicDH.Public, Private, Modulus);
            }

        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to this private key
        /// </summary>
        /// <param name="Public">Set of newly created DH parameters for Alice</param>
        /// <param name="Carry">Recryption carry over value, to be combined with the
        /// result of this key agreement.</param>
        /// <returns>The key agreement value ZZ</returns>
        public BigInteger Agreement(IKeyAdvancedPublic Public, BigInteger Carry) {
            var PublicDH = Public as DiffeHellmanPublic;
            Verify(PublicDH);
            var Partial = Agreement(PublicDH);
            return (Partial * Carry) % Modulus;
            }
        #endregion
        #region // Advanced functions
        /// <summary>
        /// Make a recryption keyset by splitting the private key.
        /// </summary>
        /// <param name="Shares">Number of shares to create</param>
        /// <returns>Array shares.</returns>
        public IKeyAdvancedPrivate[] MakeRecryptionKeySet(int Shares) {
            BigInteger Accumulator = 0;
            var Result = new IKeyAdvancedPrivate[Shares];

            for (var i = 1; i < Shares; i++) {
                var NewPrivate = Platform.GetRandomBigInteger(Modulus - 1);
                Result[i] = new DiffeHellmanPrivate(NewPrivate) { IsRecryption = true };
                Accumulator = (Accumulator + NewPrivate) % (Modulus - 1);
                }

            Result[0] = new DiffeHellmanPrivate((Modulus + Private - Accumulator - 1) % (Modulus - 1)) {
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
                var key = share as KeyPairDH;
                var privateKey = (key.IKeyAdvancedPrivate as CurveEdwards448Private);

                Accumulator = (Accumulator + privateKey.Private).Mod(Modulus - 1);
                }

            return new DiffeHellmanPrivate(
                (Modulus - 1 + Private - Accumulator).Mod(Modulus - 1)) {
                IsRecryption = true
                };
            }



        /// <summary>
        /// Combine the two public keys to create a composite public key.
        /// </summary>
        /// <param name="Contribution">The key contribution.</param>
        /// <returns>The composite key</returns>
        public DiffeHellmanPrivate Combine(DiffeHellmanPrivate Contribution) {
            var NewPrivate = (Private + Contribution.Private) % Modulus;
            return new DiffeHellmanPrivate(NewPrivate);
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
    public class ResultDiffieHellman : KeyAgreementResult {

        /// <summary>The key agreement result</summary>
        public BigInteger Agreement;

        /// <summary>Wrap as an ASN.1 Structure</summary>
        public AgreementDH ASNAgreement  => new AgreementDH() {
                Result = Agreement.ToByteArray()
                };

        /// <summary>The agreement as ASN.1 DER encoding</summary>
        /// <returns>The DER encoded value.</returns>
        public override byte[] DER () => ASNAgreement.DER();

        /// <summary>The key agreement result as a byte array</summary>
        public override byte[] IKM => Agreement.ToByteArray();  

        /// <summary>
        /// The Ephemeral public key
        /// </summary>
        public override KeyPair EphemeralKeyPair => new KeyPairDH (EphemeralPublicValue as DiffeHellmanPublic);

        }

    }
