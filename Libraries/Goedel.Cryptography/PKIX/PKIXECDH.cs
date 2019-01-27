using System;
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

        ///// <summary>
        ///// The RFC8032 Public Key byte data
        ///// </summary>
        ////public byte[] PublicKeyData;

        /// <summary>
        /// Construct a PKIX SubjectPublicKeyInfo block
        /// </summary>
        /// <param name="oidValue">The OID value</param>
        /// <returns>The PKIX structure</returns>
        public SubjectPublicKeyInfo SubjectPublicKeyInfo(int[] oidValue = null) {
            oidValue = oidValue ?? OID;
            return new SubjectPublicKeyInfo(oidValue, DER());
            }

        /// <summary>
        /// Empty constructor for deserialization operations.
        /// </summary>
        public PKIXPublicKeyECDH() {
            }

        /// <summary>
        /// Create PKIX representation from the encoded values.
        /// </summary>
        /// <param name="data"></param>
        public PKIXPublicKeyECDH(byte[] data) => Data = data.Duplicate();


        /// <summary>
        /// Encode ASN.1 class members to specified buffer. 
        ///
        /// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
        /// </summary>
        /// <param name="buffer">Output buffer</param>
        public override void Encode(Goedel.ASN.Buffer buffer) => buffer.Encode__Octets(Data, 0, -1);

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
        /// <param name="data">The private key data as an octet string</param>
        /// <param name="public">The public key representation.</param>
        public PKIXPrivateKeyECDH(byte[] data, PKIXPublicKeyECDH @public) {
            this.Data = data.Duplicate();
            PKIXPublicKeyECDH = @public;
            }


        /// <summary>
        /// Construct a PKIX SubjectPublicKeyInfo block
        /// </summary>
        /// <param name="oidValue">The OID value</param>
        /// <returns>The PKIX structure</returns>
        public SubjectPublicKeyInfo SubjectPublicKeyInfo(int[] oidValue = null) {
            oidValue = oidValue ?? OID;
            return new SubjectPublicKeyInfo(oidValue, DER());
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
        public PKIXPublicKeyEd25519(byte[] data) => Data = data;

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
        /// <param name="data">The private key data as an octet string</param>
        /// <param name="publicKey">The public key representation.</param>
        public PKIXPrivateKeyEd25519(byte[] data, PKIXPublicKeyECDH publicKey) : base(data, publicKey) {
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
        public PKIXPublicKeyEd448(byte[] data) => Data = data;

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
        public PKIXPrivateKeyEd448(byte[] data, PKIXPublicKeyECDH publicKey) : base(data, publicKey) {
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
        public PKIXPublicKeyX25519(byte[] data) => Data = data;

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
        public PKIXPrivateKeyX25519(byte[] data, PKIXPublicKeyECDH publicKey) : base(data, publicKey) {
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
        public PKIXPublicKeyX448(byte[] data) => Data = data;

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
        public PKIXPrivateKeyX448(byte[] data, PKIXPublicKeyECDH publicKey) : base(data, publicKey) {
            }

        }
    #endregion
    }
