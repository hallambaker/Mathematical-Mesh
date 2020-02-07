using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

namespace Goedel.Mesh {

    /// <summary>
    /// Base class for stores of type Spool.
    /// </summary>
    public class Spool : Store {

        ///<summary>Canonical name for outbound spool</summary>
        public const string SpoolOutbound = "mmm/Outbound";

        ///<summary>Canonical name for local spool</summary>
        public const string SpoolLocal = "mmm/Local";

        ///<summary>Canonical name for inbound spool</summary>
        public const string SpoolInbound = "mmm/Inbound";

        ///<summary>Canonical name for archive spool</summary>
        public const string SpoolArchive = "mmm/Archive";

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="directory">The directory in which the spool is stored.</param>
        /// <param name="storeName">The store name.</param>
        /// <param name="cryptoParameters">The cryptographic parameters.</param>
        /// <param name="keyCollection">The key collection to fetch keys from.</param>
        public Spool(string directory, string storeName,
            CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null) :
                base(directory, storeName, cryptoParameters, keyCollection) {

            }

        /// <summary>
        /// Return the status of the spool.
        /// </summary>
        /// <param name="directory">The directory in which the spool is stored.</param>
        /// <param name="storeName">The store name.</param>
        /// <returns></returns>
        public static ContainerStatus Status(string directory, string storeName) {
            using var store = new Spool(directory, storeName);
            return new ContainerStatus() {
                Index = (int)store.Container.FrameCount,
                Container = storeName
                };
            }

        /// <summary>
        /// Add an envelope to the spool. All information provided in the ContainerInfo
        /// field is discarded. The trailer, if present must be rewritten for the 
        /// purposes of the container.
        /// </summary>
        /// <param name="dareMessage"></param>
        public void Add(DareEnvelope dareMessage) =>
            // NYI: If the message is signed or encrypted, these enhancements should be carried over
            Container.Append(dareMessage.Body, null, dareMessage.Header.ContentMeta);



        }



    }
