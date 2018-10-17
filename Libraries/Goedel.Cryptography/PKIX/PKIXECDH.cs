﻿using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;

namespace Goedel.Cryptography.PKIX {


    /// <summary>
	/// PKIXPublicKeyECDH 
    /// </summary>
	public abstract partial class PKIXPublicKeyECDH : Goedel.ASN.ByteArrayVerbatim, IPKIXPublicKey {

        /// <summary>
        /// The Jose curve identifier.
        /// </summary>
        public abstract string CurveJose { get; }

        /// <summary>
        /// The RFC8032 Public Key byte data
        /// </summary>
        public byte[] PublicKeyData;

        /// <summary>
        /// Construct a PKIX SubjectPublicKeyInfo block
        /// </summary>
        /// <param name="OIDValue">The OID value</param>
        /// <returns>The PKIX structure</returns>
        public SubjectPublicKeyInfo SubjectPublicKeyInfo(int[] OIDValue = null) {
            OIDValue = OIDValue ?? OID;
            return new SubjectPublicKeyInfo(OIDValue, DER());
            }

        /// <summary>
        /// Empty constructor for deserialization operations.
        /// </summary>
        public PKIXPublicKeyECDH() {
            }

        /// <summary>
        /// Create PKIX representation from the encoded values.
        /// </summary>
        /// <param name="Data"></param>
        public PKIXPublicKeyECDH(byte[] Data) => this.Data = Data.Duplicate();


        /// <summary>
        /// Encode ASN.1 class members to specified buffer. 
        ///
        /// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
        /// </summary>
        /// <param name="Buffer">Output buffer</param>
        public override void Encode(Goedel.ASN.Buffer Buffer) => Buffer.Encode__Octets(PublicKeyData, 0, -1);

        /// <summary>
        /// Return the corresponding public parameters
        /// </summary>
        public IPKIXPublicKey PublicParameters => this;

        }

    /// <summary>
	/// PKIXPrivateKeyECDH 
    /// </summary>
	public abstract partial class PKIXPrivateKeyECDH : Goedel.ASN.ByteArrayVerbatim, IPKIXPrivateKey {

        /// <summary>
        /// The Jose curve identifier.
        /// </summary>
        public abstract string CurveJose { get; }

        /// <summary>
        /// Empty constructor for deserialization operations.
        /// </summary>
        public PKIXPrivateKeyECDH() {
            }

        /// <summary>
        /// Create PKIX representation from the encoded values.
        /// </summary>
        /// <param name="Data">The private key data as an octet string</param>
        /// <param name="Public">The public key representation.</param>
        public PKIXPrivateKeyECDH(byte[] Data, PKIXPublicKeyECDH Public) {
            this.Data = Data.Duplicate();
            PKIXPublicKeyECDH = Public;
            }


        /// <summary>
        /// Construct a PKIX SubjectPublicKeyInfo block
        /// </summary>
        /// <param name="OIDValue">The OID value</param>
        /// <returns>The PKIX structure</returns>
        public SubjectPublicKeyInfo SubjectPublicKeyInfo(int[] OIDValue = null) {
            OIDValue = OIDValue ?? OID;
            return new SubjectPublicKeyInfo(OIDValue, DER());
            }


        /// <summary>
        /// Return the corresponding public parameters
        /// </summary>
        public IPKIXPublicKey PublicParameters => PKIXPublicKeyECDH;


        /// <summary>
        /// Return the corresponding public parameters
        /// </summary>
        public PKIXPublicKeyECDH PKIXPublicKeyECDH { get; }

        }


    #region // Edwards Curves
    /// <summary>
    /// PKIXPrivateKeyECDH 
    /// </summary>
    public partial class PKIXPublicKeyEd25519 : PKIXPublicKeyECDH {

        /// <summary>
        /// The Jose curve identifier (Ed25519);
        /// </summary>
        public override string CurveJose => "Ed25519";

        /// <summary>
        /// Return the algorithm identifier that represents this key
        /// </summary>
        public override int[] OID => Constants.OID__id_Ed25519;

        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPublicKeyEd25519() {
            }

        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPublicKeyEd25519(byte[] Data) => PublicKeyData = Data;

        }

    /// <summary>
	/// PKIXPrivateKeyECDH 
    /// </summary>
	public partial class PKIXPrivateKeyEd25519 : PKIXPrivateKeyECDH {

        /// <summary>
        /// The Jose curve identifier (Ed25519);
        /// </summary>
        public override string CurveJose => "Ed25519";

        /// <summary>
        /// Return the algorithm identifier that represents this key
        /// </summary>
        public override int[] OID => Constants.OID__id_Ed25519;


        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPrivateKeyEd25519() : base(){
            }

        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        /// <param name="Data">The private key data as an octet string</param>
        /// <param name="Public">The public key representation.</param>
        public PKIXPrivateKeyEd25519(byte[] Data, PKIXPublicKeyECDH Public) : base(Data, Public) {
            }

        }

    /// <summary>
	/// PKIXPrivateKeyECDH 
    /// </summary>
	public partial class PKIXPublicKeyEd448 : PKIXPublicKeyECDH {

        /// <summary>
        /// The Jose curve identifier (Ed25519);
        /// </summary>
        public override string CurveJose => "Ed448";

        /// <summary>
        /// Return the algorithm identifier that represents this key
        /// </summary>
        public override int[] OID => Constants.OID__id_Ed448;

        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPublicKeyEd448() {
            }

        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPublicKeyEd448(byte[] Data) => PublicKeyData = Data;

        }

    /// <summary>
	/// PKIXPrivateKeyECDH 
    /// </summary>
	public partial class PKIXPrivateKeyEd448 : PKIXPrivateKeyECDH {

        /// <summary>
        /// The Jose curve identifier (Ed25519);
        /// </summary>
        public override string CurveJose => "Ed448";

        /// <summary>
        /// Return the algorithm identifier that represents this key
        /// </summary>
        public override int[] OID => Constants.OID__id_Ed448;

        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPrivateKeyEd448() {
            }

        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPrivateKeyEd448(byte[] Data, PKIXPublicKeyECDH Public) : base(Data, Public) {
            }

        }
    #endregion
    #region // Montgomery Curves
    /// <summary>
    /// PKIXPrivateKeyECDH 
    /// </summary>
    public partial class PKIXPublicKeyX25519 : PKIXPublicKeyECDH {

        /// <summary>
        /// The Jose curve identifier (Ed25519);
        /// </summary>
        public override string CurveJose => "X25519";

        /// <summary>
        /// Return the algorithm identifier that represents this key
        /// </summary>
        public override int[] OID => Constants.OID__id_X25519;

        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPublicKeyX25519() {
            }

        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPublicKeyX25519(byte[] Data) => PublicKeyData = Data;

        }



    /// <summary>
	/// PKIXPrivateKeyECDH 
    /// </summary>
	public partial class PKIXPrivateKeyX25519 : PKIXPrivateKeyECDH {

        /// <summary>
        /// The Jose curve identifier (Ed25519);
        /// </summary>
        public override string CurveJose => "X25519";

        /// <summary>
        /// Return the algorithm identifier that represents this key
        /// </summary>
        public override int[] OID => Constants.OID__id_X25519;


        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPrivateKeyX25519() : base() {
            }

        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPrivateKeyX25519(byte[] Data, PKIXPublicKeyECDH Public) : base(Data, Public) {
            }

        }



    /// <summary>
	/// PKIXPrivateKeyECDH 
    /// </summary>
	public partial class PKIXPublicKeyX448 : PKIXPublicKeyECDH {

        /// <summary>
        /// The Jose curve identifier (Ed25519);
        /// </summary>
        public override string CurveJose => "X448";

        /// <summary>
        /// Return the algorithm identifier that represents this key
        /// </summary>
        public override int[] OID => Constants.OID__id_X448;

        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPublicKeyX448() {
            }

        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPublicKeyX448(byte[] Data) => PublicKeyData = Data;

        }



    /// <summary>
	/// PKIXPrivateKeyECDH 
    /// </summary>
	public partial class PKIXPrivateKeyX448 : PKIXPrivateKeyECDH {

        /// <summary>
        /// The Jose curve identifier (Ed25519);
        /// </summary>
        public override string CurveJose => "X448";

        /// <summary>
        /// Return the algorithm identifier that represents this key
        /// </summary>
        public override int[] OID => Constants.OID__id_X448;

        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPrivateKeyX448() {
            }

        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPrivateKeyX448(byte[] Data, PKIXPublicKeyECDH Public) : base(Data, Public) {
            }

        }
    #endregion
    }