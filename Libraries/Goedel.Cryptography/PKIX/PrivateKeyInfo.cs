using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Goedel.Cryptography.PKIX {

    /// <summary>
    /// PrivateKeyInfo 
    /// </summary>
    public partial class PrivateKeyInfo {

        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PrivateKeyInfo () {
            }

        /// <summary>
        /// Create structure from ASN1 data
        /// </summary>
        /// <param name="Data">The encoded private key data</param>
        public PrivateKeyInfo (byte[] Data) {
            var Buffer = new global::Goedel.ASN.DecodeBuffer(Data);
            Decode(Buffer);
            }



        /// <summary>
        /// Decode buffer to populate class members
        ///
        /// This is done in the forward direction
        /// </summary>
        /// <param name="Buffer">The data to decode.</param>
        public void Decode (Goedel.ASN.DecodeBuffer Buffer) {
            Buffer.Decode__Sequence_Start();

            Version = Buffer.Decode__Integer(0, -1);
            //Buffer.Debug("Version");

            PrivateKeyAlgorithm = Buffer.Decode__Object(0, -1) as AlgorithmIdentifier;
            //Buffer.Debug("PrivateKeyAlgorithm");

            PrivateKey = Buffer.Decode__Octets(0, -1);
            //Buffer.Debug("PrivateKey");

            //if (Attributes == null || Attributes.Count == 0) {
            //    Buffer.Decode__Object(null, 1, 0);
            //    }
            //else {
            //    int XPosition = Decode.Encode__Set_Start();
            //    foreach (Goedel.Cryptography.PKIX.AttributeTypeValues _Index in Attributes) {

            //        Buffer.Encode__Object(_Index, 0, 0);
            //        }
            //    Buffer.Decode__Set_End(XPosition, 1, 0);
            //    }
            //Buffer.Debug("Attributes");
            Buffer.Decode__Sequence_End();
            }

        }




    public partial class PKIXPrivateKeyRSA {


        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPrivateKeyRSA () {
            }

        /// <summary>
        /// Create structure from ASN1 data
        /// </summary>
        /// <param name="Data">The encoded private key data</param>
        public PKIXPrivateKeyRSA (byte[] Data) {
            var Buffer = new global::Goedel.ASN.DecodeBuffer(Data);
            Decode(Buffer);
            }



        /// <summary>
        /// Decode buffer to populate class members
        ///
        /// This is done in the forward direction
        /// </summary>
        /// <param name="Buffer">The source buffer</param>
        public void Decode (global::Goedel.ASN.DecodeBuffer Buffer) {
            Buffer.Decode__Sequence_Start();

            Version = Buffer.Decode__Integer(0, -1);
            //Buffer.Debug("Version");

            Modulus = Buffer.Decode__BigInteger(0, -1);
            //Buffer.Debug("Modulus");

            PublicExponent = Buffer.Decode__BigInteger(0, -1);
            //Buffer.Debug("PublicExponent");

            PrivateExponent = Buffer.Decode__BigInteger(0, -1);
            //Buffer.Debug("PrivateExponent");

            Prime1 = Buffer.Decode__BigInteger(0, -1);
            //Buffer.Debug("Prime1");

            Prime2 = Buffer.Decode__BigInteger(0, -1);
            //Buffer.Debug("Prime2");

            Exponent1 = Buffer.Decode__BigInteger(0, -1);
            //Buffer.Debug("Exponent1");

            Exponent2 = Buffer.Decode__BigInteger(0, -1);
            //Buffer.Debug("Exponent2");

            Coefficient = Buffer.Decode__BigInteger(0, -1);
            //Buffer.Debug("Coefficient");

            Buffer.Decode__Sequence_End();
            }



        /// <summary>
        /// Debugging aid.
        /// </summary>
        public void Dump () {
            var BigModulus = new BigInteger(Modulus);
            Debug.WriteLine("Modulus\n {0}", BigModulus.ToString());

            var BigPrivateExponent = new BigInteger(PrivateExponent);
            Debug.WriteLine("BigPrivateExponent\n {0}", BigPrivateExponent.ToString());

            var BigP = new BigInteger(Prime1);
            Debug.WriteLine("P\n {0}", BigP.ToString());

            var BigQ = new BigInteger(Prime2);
            Debug.WriteLine("Q\n {0}", BigQ.ToString());

            var BigExponent1 = new BigInteger(Exponent1);
            Debug.WriteLine("Exponent1\n {0}", BigExponent1.ToString());

            var BigExponent2 = new BigInteger(Exponent2);
            Debug.WriteLine("Coefficient\n {0}", BigExponent2.ToString());

            var BigCoefficient = new BigInteger(Coefficient);
            Debug.WriteLine("Coefficient\n {0}", BigCoefficient.ToString());


            var TestModulus = BigP * BigQ;
            Debug.WriteLine("Test Modulus\n {0}", TestModulus.ToString());


            var Subtract = BigP + BigQ;

            Subtract -= new BigInteger(1);

            var TestCoefficient = TestModulus - Subtract;
            Debug.WriteLine("Test Coefficient\n {0}", TestCoefficient.ToString());

            }


        }

    /// <summary>
    /// PKIXPrivateKeyDH 
    /// </summary>
    public partial class PKIXPrivateKeyDH : Goedel.ASN.Root {

        /// <summary>
        /// Default constructor, create empty structure.
        /// </summary>
        public PKIXPrivateKeyDH () {
            }

        /// <summary>
        /// Create structure from ASN1 data
        /// </summary>
        /// <param name="Data">The encoded private key data</param>
        public PKIXPrivateKeyDH (byte[] Data) {
            var Buffer = new global::Goedel.ASN.DecodeBuffer(Data);
            Decode(Buffer);
            }


        /// <summary>
        /// Decode buffer to populate class members
        ///
        /// This is done in the forward direction
        /// </summary>
        /// <param name="Buffer">The data to decode.</param>
        public void Decode (Goedel.ASN.DecodeBuffer Buffer) {
            Buffer.Decode__Sequence_Start();

            Shared = Buffer.Decode__Octets(0, -1);
            //Buffer.Debug("Shared");

            Public = Buffer.Decode__BigInteger(0, -1);
            //Buffer.Debug("Public");

            Private = Buffer.Decode__BigInteger(0, -1);
            //Buffer.Debug("Private");
            Buffer.Decode__Sequence_End();
            }
        }

    public partial class AgreementDH : Goedel.ASN.Root {
        /// <summary>
        /// Decode buffer to populate class members
        ///
        /// This is done in the forward direction
        /// </summary>
        /// <param name="Buffer">Buffer to decode.</param>
        public  void Decode (Goedel.ASN.DecodeBuffer Buffer) {
            Buffer.Decode__Sequence_Start();

            Result = Buffer.Decode__BigInteger(0, -1);

            Buffer.Decode__Sequence_End();
            }
        }
    }
