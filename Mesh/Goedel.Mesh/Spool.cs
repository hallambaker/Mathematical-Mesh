using System;
using System.Collections.Generic;
using System.Text;
using Goedel.IO;
using System.IO;
using Goedel.Utilities;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography;

namespace Goedel.Mesh {
    public class Spool : Store {
        public const string SpoolOutbound = "mmm_Outbound";
        public const string SpoolInbound = "mmm_Inbound";
        public const string SpoolArchive = "mmm_Archive";

        public Spool(string directory, string containerName,
            CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null) :
                base(directory, containerName, cryptoParameters, keyCollection) {

            }

        public static ContainerStatus Status(string directory, string containerName) {
            using (var container = new Spool(directory, containerName)) {

                return new ContainerStatus() {
                    Index = (int)container.Container.FrameCount,
                    Container = containerName
                    };
                }
            }

        public void Add(DareEnvelope dareMessage) => Container.Append(dareMessage);


        }



    }
