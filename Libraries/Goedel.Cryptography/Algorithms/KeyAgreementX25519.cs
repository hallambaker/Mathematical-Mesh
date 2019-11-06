using System;
using System.Collections.Generic;
#pragma warning disable IDE0060  // NYI: Pretty much the whole of this scheme

namespace Goedel.Cryptography.Algorithms {
    /// <summary>
    /// Manages the public key
    /// </summary>
    public class CurveX25519Public : IKeyAdvancedPublic {

        /// <summary>Encoded form of the public key.</summary>
        public byte[] Encoding => throw new NotImplementedException();

        /// <summary>
        /// Combine the two public keys to create a composite public key.
        /// </summary>
        /// <param name="contribution">The key contribution.</param>
        /// <returns>The composite key</returns>
        public IKeyAdvancedPublic Combine(IKeyAdvancedPublic contribution) => throw new NotImplementedException();

        /// <summary>
        /// Construct provider from public key data.
        /// </summary>
        /// <param name="encoding">The encoded public key value.</param>
        public CurveX25519Public(byte[] encoding) => throw new NotImplementedException();

        /// <summary>
        /// Create a new ephemeral private key and use it to perform a key
        /// agreement.
        /// </summary>
        /// <returns>The key agreement parameters, the public key value and the
        /// key agreement.</returns>
        public CurveX25519Result Agreement() {
            var Private = new CurveX25519Private();

            return new CurveX25519Result() {
                EphemeralPublicValue = Private.PublicKey,
                Agreement = Private.Agreement(this)
                };
            }
        }

    /// <summary>
    /// Manages the public key
    /// </summary>
    public class CurveX25519Private : IKeyAdvancedPrivate {

        /// <summary>The public key, i.e. a point on the curve</summary>
        public CurveX25519Public PublicKey { get; set; }

        /// <summary>Encoded form of the public key.</summary>
        public byte[] Encoding => throw new NotImplementedException();

        /// <summary>
        /// Combine the two private keys to create a composite public key.
        /// </summary>
        /// <param name="contribution">The key contribution.</param>
        /// <returns>The composite key</returns>
        public IKeyAdvancedPrivate Combine(IKeyAdvancedPrivate contribution) => throw new NotImplementedException();

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
        public IKeyAdvancedPrivate[] MakeRecryptionKeySet(int shares) => throw new NotImplementedException();

        /// <summary>
        /// Make a recryption keyset by splitting the private key.
        /// </summary>
        /// <param name="Shares">Number of shares to create</param>
        /// <returns>Array shares.</returns>
        public IKeyAdvancedPrivate CompleteRecryptionKeySet(IEnumerable<KeyPair> Shares) => throw new NotImplementedException();


        /// <summary>
        /// Construct provider from private key data.
        /// </summary>
        /// <param name="encoding">The encoded private key value.</param>
        /// <param name="Exportable">If true, the private key is exportable</param>
        public CurveX25519Private(byte[] encoding, bool Exportable = false) => throw new NotImplementedException();

        /// <summary>
        /// Generate a new private key
        /// </summary>
        /// <param name="exportable">If true, the private key is exportable</param>
        public CurveX25519Private(bool exportable = false) => throw new NotImplementedException();


        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to a public key
        /// </summary>
        /// <param name="Public">Public key parameters</param>
        /// <returns>The key agreement value ZZ</returns>
        public CurveMontgomery25519 Agreement(CurveX25519Public Public) =>
            throw new NotImplementedException();


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
        /// Perform a Diffie Hellman Key Agreement to a private key
        /// </summary>
        /// <param name="Public">Public key parameters</param>
        /// <param name="Carry">Recryption carry over value, to be combined with the
        /// result of this key agreement.</param>
        /// <returns>The key agreement value ZZ</returns>
        public CurveMontgomery25519 Agreement(CurveX25519Public Public, CurveMontgomery25519 Carry) =>
            throw new NotImplementedException();



        }

    /// <summary>
    /// Represent the result of a Diffie Hellman Key exchange.
    /// </summary>
    public class CurveX25519Result : ResultECDH {

        /// <summary>The key agreement result</summary>
        public CurveMontgomery25519 Agreement { get; set; }

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
        public CurveMontgomery25519 Carry { get; set; }

        /// <summary>Public key generated by ephemeral key generation.</summary>
        public CurveX25519Public Public => EphemeralPublicValue as CurveX25519Public;
        }

    }
