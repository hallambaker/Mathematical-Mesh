﻿using System;
using System.Collections.Generic;
using Goedel.Cryptography;
using Goedel.Cryptography.PKIX;
using Goedel.Utilities;

namespace Goedel.Cryptography.Jose {

    /// <summary>
    /// Represents a Diffie Hellman Public Key.
    /// </summary>
    public partial class PublicKeyDH {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public PublicKeyDH () { }

        /// <summary>
        /// Construct from the specified DH Key
        /// </summary>
        /// <param name="KeyPair">An RSA key Pair.</param>
        public PublicKeyDH(KeyPairBaseDH KeyPair) : this (KeyPair.PKIXPublicKeyDH) {
            }

        /// <summary>
        /// Construct from a PKIX RSAPublicKey structure.
        /// </summary>
        /// <param name="DHPublicKey">RSA Public Key.</param>
        public PublicKeyDH(PKIXPublicKeyDH DHPublicKey) {
            Kid = DHPublicKey.UDF();
            Domain = DHPublicKey.Domain.UDFData;
            Public = DHPublicKey.Public;

            }


        /// <summary>
        /// Return the parameters as a PKIX RSAPublicKey structure;
        /// </summary>
        public virtual PKIXPublicKeyDH PKIXParameters  => new PKIXPublicKeyDH() {
                Public = Public,
                Domain = DHDomain.GetByUDF(Domain)
                };

        /// <summary>
        /// Extract a KeyPair object from the JOSE data structure.
        /// </summary>
        /// <param name="keySecurity">The key security model</param>
        /// <param name="keyCollection">The key collection to add the key to.</param>
        /// <returns>The extracted key pair</returns>
        public override KeyPair GetKeyPair(KeySecurity keySecurity, keyCollection keyCollection) {

            var KeyPair = KeyPairBaseDH.KeyPairPublicFactory(PKIXParameters);

            return KeyPair;
            }

        }

    /// <summary>
    /// Represents a DHG Private Key.
    /// </summary>
    public partial class PrivateKeyDH {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public PrivateKeyDH () { }

        /// <summary>
        /// Construct from the specified RSA Key
        /// </summary>
        /// <param name="KeyPair">An RSA key Pair.</param>
        public PrivateKeyDH (KeyPairBaseDH KeyPair) : this(KeyPair.PKIXPrivateKeyDH) {
            }

        /// <summary>
        /// Construct from a PKIX PKIXPrivateKeyDH structure.
        /// </summary>
        /// <param name="pkixKey">DH Public Key.</param>
        public PrivateKeyDH(PKIXPrivateKeyDH pkixKey) {
            Assert.AssertNotNull(pkixKey, NotExportable.Throw);

            Kid = pkixKey.UDF();
            Domain = pkixKey.Domain.UDFData;
            Public = pkixKey.Public;
            Private = pkixKey.Private;
            }

        /// <summary>
        /// Return the parameters as PKIX RSAPrivateKey structure;
        /// </summary>
        public virtual PKIXPrivateKeyDH DHPrivateKey => new PKIXPrivateKeyDH() {
                Public = Public,
                Private = Private,
                Domain = DHDomain.GetByUDF(Domain)
                };


        /// <summary>
        /// Extract a KeyPair object from the JOSE data structure.
        /// </summary>
        /// <param name="keySecurity">The key security rextrictions.</param>
        /// <param name="keyCollection">The key collection to add the key to.</param>
        /// <returns>The extracted key pair</returns>
        public override KeyPair GetKeyPair(KeySecurity keySecurity, keyCollection keyCollection) {
            var KeyPair = KeyPairBaseDH.KeyPairPrivateFactory(DHPrivateKey, keySecurity);
            return KeyPair;
            }


        }

    }
