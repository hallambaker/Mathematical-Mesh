//Sample license text.
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Goedel.LibCrypto;
using Goedel.ASN;

namespace Goedel.LibCrypto.PKIX {


    public partial class SubjectPublicKeyInfo : Goedel.ASN.Root {


        /// <summary>
        /// Construct from algorithm identifier and key data.
        /// </summary>
        /// <param name="OID">Algorithm identifier.</param>
        /// <param name="KeyData">Key Data.</param>

        public SubjectPublicKeyInfo(string OID, byte[] KeyData) {
            this.Algorithm = new AlgorithmIdentifier(OID);
            this.SubjectPublicKey = KeyData;

            }
        }


    public partial class AlgorithmIdentifier : Goedel.ASN.Root {
        string OIDString;

        /// <summary>
        /// Construct from OID identifier string.
        /// </summary>
        /// <param name="ID"></param>
        public AlgorithmIdentifier(string ID) {
            OIDString = ID;
            this.Algorithm = Goedel.ASN.ASN.OIDToArray(ID);
            }

        /// <summary>
        /// Create an Algorithm Identifier from an integer array.
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Numbers"></param>
        public AlgorithmIdentifier (string Text, int [] Numbers) {
            OIDString = Text;
            Algorithm = Numbers;
            }

        }
    }
