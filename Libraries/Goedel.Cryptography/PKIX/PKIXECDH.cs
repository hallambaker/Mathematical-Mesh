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
        /// Empty constructor for deserialization operations.
        /// </summary>
        public PKIXPrivateKeyECDH() {
            }

        /// <summary>
        /// Create PKIX representation from the encoded values.
        /// </summary>
        /// <param name="Data"></param>
        public PKIXPrivateKeyECDH(byte[] Data) => this.Data = Data.Duplicate();



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
        public PKIXPublicKeyECDH PKIXPublicKeyECDH => throw new NYI();



        }



    /// <summary>
	/// PKIXPrivateKeyECDH 
    /// </summary>
	public partial class PKIXPublicKeyEd25519 : PKIXPublicKeyECDH {



        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPublicKeyEd25519() {
            }


        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPublicKeyEd25519(byte[] Data) => PublicKeyData = Data;


        /// <summary>
        /// Return the algorithm identifier that represents this key
        /// </summary>
        public override int[] OID => Constants.OID__id_Ed25519;

        }



    /// <summary>
	/// PKIXPrivateKeyECDH 
    /// </summary>
	public partial class PKIXPrivateKey25519 : PKIXPrivateKeyECDH {

        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPrivateKey25519() : base(){
            }


        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPrivateKey25519(byte[] Data) : base(Data) {
            }


        /// <summary>
        /// Return the algorithm identifier that represents this key
        /// </summary>
        public override int[] OID => Constants.OID__id_Ed25519;

        }



    /// <summary>
	/// PKIXPrivateKeyECDH 
    /// </summary>
	public partial class PKIXPublicKeyEd448 : PKIXPublicKeyECDH {



        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPublicKeyEd448() {
            }


        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPublicKeyEd448(byte[] Data) => PublicKeyData = Data;


        /// <summary>
        /// Return the algorithm identifier that represents this key
        /// </summary>
        public override int[] OID => Constants.OID__id_Ed448;

        }



    /// <summary>
	/// PKIXPrivateKeyECDH 
    /// </summary>
	public partial class PKIXPrivateKeyEd448 : PKIXPrivateKeyECDH {

        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPrivateKeyEd448() {
            }


        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPrivateKeyEd448(byte[] Data) {
            }


        /// <summary>
        /// Return the algorithm identifier that represents this key
        /// </summary>
        public override int[] OID => Constants.OID__id_Ed448;

        }





    }
