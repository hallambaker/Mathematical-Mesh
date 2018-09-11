using System;
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


        ///// <summary>
        ///// Construct a key
        ///// </summary>
        ///// <param name="KeyPair"></param>
        //public PublicKeyECDH(KeyPairBaseECDH KeyPair) => throw new NYI();



        /// <summary>
        /// Construct from a PKIX RSAPublicKey structure.
        /// </summary>
        /// <param name="DHPublicKey">RSA Public Key.</param>
        public PublicKeyECDH(PKIXPublicKeyECDH DHPublicKey) => throw new NYI();


        /// <summary>
        /// Return the parameters as a PKIX RSAPublicKey structure;
        /// </summary>
        public virtual PKIXPublicKeyECDH PKIXParameters => throw new NYI();


        /// <summary>
        /// Extract a KeyPair object from the JOSE data structure.
        /// </summary>
        /// <param name="Exportable">If true, private key parameters may be exported</param>
        /// <returns>The extracted key pair</returns>
        public override KeyPair GetKeyPair(bool Exportable = false) => throw new NYI();


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
        /// <param name="PKIXKey">DH Public Key.</param>
        public PrivateKeyECDH(PKIXPrivateKeyECDH PKIXKey) => throw new NYI();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="PrivateKey"></param>
        /// <param name="Export"></param>
        public PrivateKeyECDH(byte[] PrivateKey, bool Export = false) => throw new NYI();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Private"></param>
        /// <returns></returns>
        public PrivateKeyECDH CombinePrivate (PrivateKeyECDH Private) => throw new NYI();


        /// <summary>
        /// Return the parameters as PKIX RSAPrivateKey structure;
        /// </summary>
        public virtual PKIXPrivateKeyECDH DHPrivateKey => throw new NYI();

        /// <summary>
        /// Extract a KeyPair object from the JOSE data structure.
        /// </summary>
        /// <param name="Exportable">If true, private key parameters may be exported</param>
        /// <returns>The extracted key pair</returns>
        public override KeyPair GetKeyPair(bool Exportable = false) => throw new NYI();


        }


    }
