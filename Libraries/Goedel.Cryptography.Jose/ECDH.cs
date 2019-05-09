﻿using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography.PKIX;

namespace Goedel.Cryptography.Jose {
    public partial class PublicKeyECDH {

        /// <summary>
        /// Default constructor
        /// </summary>
        public PublicKeyECDH() { }


        /// <summary>
        /// Construct a key
        /// </summary>
        /// <param name="KeyPair"></param>
        public PublicKeyECDH(KeyPairBaseECDH KeyPair) : this(KeyPair.PKIXPublicKeyECDH) {
            }



        /// <summary>
        /// Construct from a PKIX RSAPublicKey structure.
        /// </summary>
        /// <param name="pkixKey">RSA Public Key.</param>
        public PublicKeyECDH(PKIXPublicKeyECDH pkixKey) {
            PKIXParametersPublic = pkixKey;
            Public = pkixKey.Data;
            Curve = pkixKey.CurveJose;
            }


        /// <summary>
        /// Return the parameters as a PKIX RSAPublicKey structure;
        /// </summary>
        public virtual PKIXPublicKeyECDH PKIXParametersPublic { get; }


        /// <summary>
        /// Extract a KeyPair object from the JOSE data structure.
        /// </summary>
        /// <param name="keySecurity">The key security requirements. If KeySecurity.NULL is specified,
        /// the key security setting is ignored.</param>
        /// <param name="keyCollection">The key collection to add the key to.</param>
        /// <returns>The extracted key pair</returns>
        public override KeyPair GetKeyPair(
                KeySecurity keySecurity, 
                KeyCollection keyCollection = null) {

            var keyUses = Use.GetUses();


            switch (Curve) {
                case "Ed25519":
                    return new KeyPairEd25519(Public, KeySecurity.Public, keyUses, CryptoAlgorithmID.Ed448);
                case "Ed448":
                    return new KeyPairEd448(Public, KeySecurity.Public, keyUses, CryptoAlgorithmID.Ed448);
                case "X25519":
                    return new KeyPairX25519(Public, KeySecurity.Public, keyUses, CryptoAlgorithmID.Ed448);
                case "X448":
                    return new KeyPairX448(Public, KeySecurity.Public, keyUses, CryptoAlgorithmID.Ed448);
                }

            throw new NotSupportedException();
            }


        /// <summary>
        /// Combine the public key parameters of this key with another key to
        /// produce public key values for the combined key.
        /// </summary>
        /// <param name="Public">The public key value to combine</param>
        /// <returns>The composite public key.</returns>
        public virtual PublicKeyECDH CombinePublic (PublicKeyECDH Public) => throw new NYI();

        }


    public partial class PrivateKeyECDH {

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PrivateKeyECDH() { }

        /// <summary>
        /// Construct from the specified RSA Key
        /// </summary>
        /// <param name="KeyPair">An RSA key Pair.</param>
        public PrivateKeyECDH(KeyPairBaseECDH KeyPair) : this(KeyPair.PKIXPrivateKeyECDH) {
            }

        /// <summary>
        /// Construct from a PKIX PKIXPrivateKeyDH structure.
        /// </summary>
        /// <param name="pkixKey">DH Public Key.</param>
        public PrivateKeyECDH(PKIXPrivateKeyECDH pkixKey) {
            Assert.AssertNotNull(pkixKey, NotExportable.Throw);

            Private = pkixKey.Data;
            PKIXParametersPrivate = pkixKey;
            Curve = pkixKey.CurveJose;
            }


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="PrivateKey"></param>
        ///// <param name="Export"></param>
        //public PrivateKeyECDH(byte[] PrivateKey, bool Export = false) => throw new NYI();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Private"></param>
        /// <returns></returns>
        public PrivateKeyECDH CombinePrivate (PrivateKeyECDH Private) => throw new NYI();


        /// <summary>
        /// Return the parameters as PKIX RSAPrivateKey structure;
        /// </summary>
        public virtual PKIXPrivateKeyECDH PKIXParametersPrivate { get; }

        /// <summary>
        /// Extract a KeyPair object from the JOSE data structure.
        /// </summary>
        /// <param name="keySecurity">The key security rextrictions.</param>
        /// <param name="keyCollection">The key collection to add the key to.</param>
        /// <returns>The extracted key pair</returns>
        public override KeyPair GetKeyPair(KeySecurity keySecurity, KeyCollection keyCollection) {
            var keyUses = Use.GetUses();
            switch (Curve) {
                case "Ed25519":
                    return new KeyPairEd25519(Private, keySecurity, keyUses, CryptoAlgorithmID.Ed448);
                case "Ed448":
                    return new KeyPairEd448(Private, keySecurity, keyUses, CryptoAlgorithmID.Ed448);
                case "X25519":
                    return new KeyPairX25519(Private, keySecurity, keyUses, CryptoAlgorithmID.Ed448);
                case "X448":
                    return new KeyPairX448(Private, keySecurity, keyUses, CryptoAlgorithmID.Ed448);

                }
            throw new NotSupportedException();
            }


        }


    }
