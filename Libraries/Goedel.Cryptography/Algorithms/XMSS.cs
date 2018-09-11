using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;

namespace Goedel.Cryptography.Algorithms {

    /// <summary>
    /// rfc8391
    /// </summary>
    public class XMSS {

        ///<summary>The master secret value</summary>
        public byte[] MasterSecret;

        ///<summary>The private key as a set of values</summary>
        public byte[][] Private;

        ///<summary>The public key in canonical form</summary>
        public byte[] Public;

        ///<summary>The public key fingerprint</summary>
        public string UDF;

        /// <summary>
        /// Default constructor, not yet implemented
        /// </summary>
        public XMSS() => throw new NYI();


        }
    }
