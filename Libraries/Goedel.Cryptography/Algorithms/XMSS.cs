using Goedel.Utilities;

namespace Goedel.Cryptography.Algorithms {

    /// <summary>
    /// rfc8391
    /// </summary>
    public class XMSS {

        ///<summary>The master secret value</summary>
        public byte[] MasterSecret { get; set; }

        ///<summary>The private key as a set of values</summary>
        public byte[][] Private { get; set; }

        ///<summary>The public key in canonical form</summary>
        public byte[] Public { get; set; }

        ///<summary>The public key fingerprint</summary>
        public string UDF { get; set; }

        /// <summary>
        /// Default constructor, not yet implemented
        /// </summary>
        public XMSS() => throw new NYI();


        }
    }
