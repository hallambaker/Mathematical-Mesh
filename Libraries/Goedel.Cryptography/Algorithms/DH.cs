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
    public class DiffeHellmanPublic  {


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

        /// <summary>
        /// Create a new set of Diffie Hellman group parameters.
        /// </summary>
        /// <param name="Bits">The number of bits, this identifies the group modulus </param>
        public DiffeHellmanPublic(int Bits=2048) {
            switch (Bits) {
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
        /// Create a new set of Diffie Hellman group parameters.
        /// </summary>
        /// <param name="Generator">The generator parameter, g.</param>
        /// <param name="Modulus">The modulus parameter, p.</param>
        /// <param name="Public">The public parameter, g^x mod p.</param>
        public DiffeHellmanPublic(BigInteger Modulus, BigInteger Generator,
                        BigInteger? Public) {
            this.Modulus = Modulus;
            this.Generator = Generator;
            if (Public != null) {
                this.Public = (BigInteger)Public;
                }
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

        /// <summary>
        /// Create a copy of a key that is guaranteed to only have the public parameters.
        /// </summary>
        /// <param name="Private"></param>
        public DiffeHellmanPublic(DiffeHellmanPublic Private) {
            DHDomain = Private.DHDomain;
            Modulus = Private.Modulus;
            Generator = Private.Generator;
            Public = Private.Public;
            }

        /// <summary>
        /// Create a new ephemeral private key and use it to perform a key
        /// agreement.
        /// </summary>
        /// <returns>The key agreement parameters, the public key value and the
        /// key agreement.</returns>
        public DiffieHellmanResult Agreement() {
            var Private = new DiffeHellmanPrivate(this);
            var DiffeHellmanPublic = Private.DiffeHellmanPublic;

            var Result = new DiffieHellmanResult() {
                DiffeHellmanPublic = DiffeHellmanPublic,
                Agreement = Private.Agreement(this)
                };

            return Result;
            }


        /// <summary>
        /// Check that the Diffie Hellman parameters presented match those of this Key.
        /// </summary>
        /// <param name="Key">The key to verify</param>
        public void Verify (DiffeHellmanPublic Key) {
            Assert.True(Key.Modulus == Modulus, CryptographicException.Throw);
            Assert.True(Key.Generator == Generator, CryptographicException.Throw);
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
                Accumulator = Accumulator * Carry[i];
                }
            return Accumulator % Modulus;
            }

        /// <summary>
        /// Combine the two public keys to create a composite public key.
        /// </summary>
        /// <param name="Contribution">The key contribution.</param>
        /// <returns>The composite key</returns>
        public DiffeHellmanPublic Combine (DiffeHellmanPublic Contribution) {
            var NewPublic = (Public * Contribution.Public) % Modulus;
            return new DiffeHellmanPublic(DHDomain, NewPublic);
            }

        }

    /// <summary>
    /// Represents a set of Diffie Hellman parameters.
    /// </summary>
    public class DiffeHellmanPrivate : DiffeHellmanPublic {

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


        /// <summary>
        /// Create a new set of Diffie Hellman parameters using the shared modulus, 
        /// a newly constructed generator and public and private keys.
        /// </summary>
        /// <param name="DHDomain">The shared parameters</param>
        public DiffeHellmanPrivate(DHDomain DHDomain) : base (DHDomain) {
            Private = Platform.GetRandomBigInteger(Modulus);
            Public = BigInteger.ModPow(Generator, Private, Modulus);
            IsRecryption = false;
            }


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
                    //base(Modulus:DiffeHellmanPublic.Modulus,
                    //    Generator:DiffeHellmanPublic.Generator,
                    //    Public: null) {
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

        /// <summary>
        /// Construct a new Diffie Hellman key using co-generation using the supplied private key as 
        /// the base.
        /// </summary>
        /// <param name="Base">The private key to use as the co-generation base</param>
        public DiffeHellmanPrivate (DiffeHellmanPrivate Base) : base (Base.DHDomain) {
            Private = Platform.GetRandomBigInteger(Modulus);
            Public = BigInteger.ModPow(Generator, Private, Modulus);

            Private = (Private + Base.Private) % Modulus-1;
            }


        private DiffeHellmanPrivate (BigInteger Private) {
            this.Private = Private;
            Public = BigInteger.ModPow(Generator, Private, Modulus);
            }


        /// <summary>
        /// Make a recryption keyset by splitting the private key.
        /// </summary>
        /// <param name="Shares">Number of shares to create</param>
        /// <returns>Array shares.</returns>
        public DiffeHellmanPrivate[] MakeRecryption (int Shares) {
            BigInteger Accumulator = 0;
            var Result = new DiffeHellmanPrivate[Shares];

            for (var i = 1; i < Shares; i++) {
                var NewPrivate = Platform.GetRandomBigInteger(Modulus-1);
                Result[i] = new DiffeHellmanPrivate(NewPrivate) { IsRecryption = true};
                Accumulator = (Accumulator + NewPrivate) % (Modulus-1);
                }

            Result[0] = new DiffeHellmanPrivate((Modulus + Private - Accumulator -1) % (Modulus-1)) {
                IsRecryption = true };
            return Result;
            }


        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to this private key
        /// </summary>
        /// <param name="Public">Set of newly created DH parameters for Alice</param>
        /// <returns>The key agreement value ZZ</returns>
        public BigInteger Agreement(DiffeHellmanPublic Public) {
            Verify(Public);
            return BigInteger.ModPow(Public.Public, Private, Modulus);
            }

        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to this private key
        /// </summary>
        /// <param name="Public">Set of newly created DH parameters for Alice</param>
        /// <param name="Carry">Recryption carry over value, to be combined with the
        /// result of this key agreement.</param>
        /// <returns>The key agreement value ZZ</returns>
        public BigInteger Agreement(DiffeHellmanPublic Public, BigInteger Carry) {
            Verify(Public);
            var Partial = Agreement(Public);
            return (Partial * Carry) % Modulus;
            }


        }


    /// <summary>
    /// Represent the result of a Diffie Hellman Key exchange.
    /// </summary>
    public class DiffieHellmanResult : KeyAgreementResult {

        /// <summary>Wrap as an ASN.1 Structure</summary>
        public AgreementDH ASNAgreement  => new AgreementDH() {
                Result = Agreement.ToByteArray()
                };


        /// <summary>The oid value describing the parameters.</summary>
        public override int[] OID => null;

        /// <summary>The agreement as ASN.1 DER encoding</summary>
        /// <returns>The DER encoded value.</returns>
        public override byte[] DER () => ASNAgreement.DER();

        ///// <summary>Convert to ASN.1 DER form </summary>
        //public abstract byte[] GetJson { get; }


        /// <summary>Default Constructor</summary>
        public DiffieHellmanResult () { }

        /// <summary>Constructor from ASN.1 parameters</summary>
        /// <param name="AgreementDH">The key agreement parameters.</param>
        public DiffieHellmanResult(AgreementDH AgreementDH) => Agreement = new BigInteger(AgreementDH.Result);

        /// <summary>The key agreement result</summary>
        public BigInteger Agreement;

        /// <summary>The key agreement result as a byte array</summary>
        public byte[] IKM => Agreement.ToByteArray();  

        /// <summary>Carry from proxy recryption efforts</summary>
        public BigInteger Carry;

        /// <summary>Public key generated by ephemeral key generation.</summary>
        public DiffeHellmanPublic DiffeHellmanPublic;

        byte[] _Salt;
        KeyDerive _KeyDerive = null;

        /// <summary>Salt to use in HKDF key derivation. If set will set the 
        /// Key derivation function to HKDF with the specified salt.</summary>
        public override byte[] Salt {
            get => _Salt;
            set {
                _Salt = value;
                _KeyDerive = new KeyDeriveHKDF(IKM, _Salt);
                }
            }

        /// <summary>Key derivation function. May be overridden, defaults to KDF.</summary>
        public override KeyDerive KeyDerive {
            get {
                _KeyDerive = _KeyDerive ?? new KeyDeriveHKDF(IKM, _Salt);
                return _KeyDerive;
                }
            set => _KeyDerive = value;
            }

        }

    }
