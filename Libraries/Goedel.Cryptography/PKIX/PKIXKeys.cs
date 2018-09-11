using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Cryptography.PKIX {

    /// <summary>
    /// Interface permitting Key classes to be managed as if they inherited from
    /// a common base class.
    /// </summary>
    public interface IPKIXData {

        /// <summary>
        /// Return the DER encoding of this structure
        /// </summary>
        /// <returns>The DER encoded value.</returns>
        byte[] DER ();


        /// <summary>
        /// Return the algorithm identifier that represents this key
        /// </summary>
        int[] OID { get; }

        ///// <summary>
        ///// Return an ASN.1 object
        ///// </summary>
        //ASN.Root GetASN { get; }

        }


    /// <summary>
    /// Interface permitting Key classes to be managed as if they inherited from
    /// a common base class.
    /// </summary>
    public interface IPKIXPublicKey : IPKIXData {

        /// <summary>
        /// Construct a PKIX SubjectPublicKeyInfo block
        /// </summary>
        /// <param name="OID">The OID value</param>
        /// <returns>The PKIX structure</returns>
        SubjectPublicKeyInfo SubjectPublicKeyInfo(int[] OID = null);

        /// <summary>
        /// Return the corresponding public parameters
        /// </summary>
        IPKIXPublicKey PublicParameters { get; }

        }


    /// <summary>
    /// Interface permitting Key classes to be managed as if they inherited from
    /// a common base class.
    /// </summary>
    public interface IPKIXPrivateKey : IPKIXPublicKey {

        }

    /// <summary>
    /// Interface permitting Key classes to be managed as if they inherited from
    /// a common base class.
    /// </summary>
    public interface IPKIXAgreement : IPKIXData {
        }


    public partial class PKIXPublicKeyDH : IPKIXPublicKey {

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
        /// Return the algorithm identifier that represents this key
        /// </summary>
        public override int[] OID  => Constants.OID__id_dh_public;


        /// <summary>
        /// Return the corresponding public parameters
        /// </summary>
        public IPKIXPublicKey PublicParameters => this;

        }

    public partial class PKIXPrivateKeyDH : IPKIXPrivateKey {

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
        /// Return the algorithm identifier that represents this key
        /// </summary>
        public override int[] OID => Constants.OID__id_dh_private;


        /// <summary>
        /// Return the corresponding public parameters
        /// </summary>
        public IPKIXPublicKey PublicParameters => PKIXPublicKeyDH;


        /// <summary>
        /// Return the corresponding public parameters
        /// </summary>
        public PKIXPublicKeyDH PKIXPublicKeyDH {
            get {
                _PKIXPublicKeyDH = _PKIXPublicKeyDH ?? new PKIXPublicKeyDH() {
                    Shared = Shared,
                    Public = Public
                    };
                return _PKIXPublicKeyDH;
                }
            }

        PKIXPublicKeyDH _PKIXPublicKeyDH = null;

        }




    public partial class PKIXPublicKeyRSA : IPKIXPublicKey {

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
        /// Return the algorithm identifier that represents this key
        /// </summary>
        public override int[] OID => Constants.OID__rsaEncryption;


        /// <summary>
        /// Return the corresponding public parameters
        /// </summary>
        public IPKIXPublicKey PublicParameters => this; 

        }

    public partial class PKIXPrivateKeyRSA : IPKIXPrivateKey {

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
        /// Return the algorithm identifier that represents this key
        /// </summary>
        public override int[] OID => Constants.OID__rsaEncryption;


        /// <summary>
        /// Return the corresponding public parameters
        /// </summary>
        public IPKIXPublicKey PublicParameters => PKIXPublicKeyRSA;


        /// <summary>
        /// Return the corresponding public parameters
        /// </summary>
        public PKIXPublicKeyRSA PKIXPublicKeyRSA {
            get {
                _PKIXPublicKeyRSA = _PKIXPublicKeyRSA ?? new PKIXPublicKeyRSA() {
                    Modulus = Modulus,
                    PublicExponent = PublicExponent
                    };
                return _PKIXPublicKeyRSA;
                }
            }

        PKIXPublicKeyRSA _PKIXPublicKeyRSA = null;

        }


    }
