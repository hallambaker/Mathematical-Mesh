using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

namespace Goedel.Mesh {
    public class Spool : Store {
        public const string SpoolOutbound = "mmm_Outbound";
        public const string SpoolLocal = "mmm_Local";
        public const string SpoolInbound = "mmm_Inbound";
        public const string SpoolArchive = "mmm_Archive";

        public Spool(string directory, string containerName,
            CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null) :
                base(directory, containerName, cryptoParameters, keyCollection) {

            }

        public static ContainerStatus Status(string directory, string containerName) {
            using var container = new Spool(directory, containerName);
            return new ContainerStatus() {
                Index = (int)container.Container.FrameCount,
                Container = containerName
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
