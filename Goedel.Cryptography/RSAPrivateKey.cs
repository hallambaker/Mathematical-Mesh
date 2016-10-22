using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Goedel.Cryptography.PKIX {
    public partial class RSAPrivateKey  {

        /// <summary>
        /// Create structure from ASN1 data
        /// </summary>
        /// <param name="Data"></param>
        public RSAPrivateKey (byte[] Data) {
            var Buffer = new global::Goedel.ASN1.DecodeBuffer(Data);
            Decode(Buffer);


            var XModulus = new BigInteger(Modulus);
            Console.WriteLine("Modulus is {0}", XModulus);

            }


        /// <summary>
        /// Create structure from RSAParameters structure.
        /// </summary>
        /// <param name="RSAParameters">The RSA Parameters in .NET format.</param>
        public RSAPrivateKey (RSAParameters RSAParameters) {
            this.RSAParameters = RSAParameters;
            }

        /// <summary>
        /// Decode buffer to populate class members
        ///
        /// This is done in the forward direction
        /// </summary>
        public void Decode(global::Goedel.ASN1.DecodeBuffer Buffer) {
            Buffer.Decode__Sequence_Start();

            Version = Buffer.Decode__Integer(0, -1);
            Buffer.Debug("Version");

            Modulus = Buffer.Decode__BigInteger(0, -1);
            Buffer.Debug("Modulus");

            PublicExponent =Buffer.Decode__BigInteger(0, -1);
            Buffer.Debug("PublicExponent");

            PrivateExponent =Buffer.Decode__BigInteger(0, -1);
            Buffer.Debug("PrivateExponent");

            Prime1 = Buffer.Decode__BigInteger(0, -1);
            Buffer.Debug("Prime1");

            Prime2 = Buffer.Decode__BigInteger(0, -1);
            Buffer.Debug("Prime2");

            Exponent1 = Buffer.Decode__BigInteger(0, -1);
            Buffer.Debug("Exponent1");

            Exponent2 = Buffer.Decode__BigInteger(0, -1);
            Buffer.Debug("Exponent2");

            Coefficient = Buffer.Decode__BigInteger(0, -1);
            Buffer.Debug("Coefficient");

            Buffer.Decode__Sequence_End();
            }




        /// <summary>
        /// Gat/Set the private key parameters as .NET RSAParameters structure.
        /// </summary>
        public RSAParameters RSAParameters {
            get {

                return new RSAParameters {
                    Modulus = Modulus,
                    Exponent = PublicExponent,
                    D = PrivateExponent,
                    P = Prime1,
                    Q = Prime2,
                    DP = Exponent1,
                    DQ = Exponent2,
                    InverseQ = Coefficient,
                    };
                }
            set {
                Modulus = value.Modulus;
                PublicExponent = value.Exponent;
                PrivateExponent = value.D;
                Prime1 = value.P;
                Prime2 = value.Q;
                Exponent1 = value.DP;
                Exponent2 = value.DQ;
                Coefficient = value.InverseQ;
                }
            }

        /// <summary>
        /// 
        /// </summary>
        public void Dump() {
            var BigModulus = new BigInteger(Modulus);
            Console.WriteLine("Modulus\n {0}", BigModulus.ToString());

            var BigPrivateExponent = new BigInteger(PrivateExponent);
            Console.WriteLine("BigPrivateExponent\n {0}", BigPrivateExponent.ToString());

            var BigP = new BigInteger(Prime1);
            Console.WriteLine("P\n {0}", BigP.ToString());

            var BigQ = new BigInteger(Prime2);
            Console.WriteLine("Q\n {0}", BigQ.ToString());

            var BigExponent1 = new BigInteger(Exponent1);
            Console.WriteLine("Exponent1\n {0}", BigExponent1.ToString());

            var BigExponent2 = new BigInteger(Exponent2);
            Console.WriteLine("Coefficient\n {0}", BigExponent2.ToString());

            var BigCoefficient = new BigInteger(Coefficient);
            Console.WriteLine("Coefficient\n {0}", BigCoefficient.ToString());


            var TestModulus = BigP * BigQ;
            Console.WriteLine("Test Modulus\n {0}", TestModulus.ToString());


            var Subtract = BigP + BigQ;

            Subtract = Subtract - new BigInteger(1);

            var TestCoefficient = TestModulus - Subtract;
            Console.WriteLine("Test Coefficient\n {0}", TestCoefficient.ToString());

            }


        }
    }
