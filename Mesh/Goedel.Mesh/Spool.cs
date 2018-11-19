using System;
using System.Collections.Generic;
using System.Text;
using Goedel.IO;
using System.IO;
using Goedel.Utilities;
using Goedel.Cryptography.Dare;

namespace Goedel.Mesh {
    public class Spool : Store {





        protected override void Disposing() => Container?.Dispose();

        protected Spool(string directory, string containerName) {

            containerName = containerName ?? ContainerDefault;

            var fileName = Path.Combine(directory, Path.ChangeExtension(containerName, ".spl"));
            Container = new ContainerPersistenceStore(fileName, "application/mmm-spool",
                fileStatus: FileStatus.OpenOrCreate,
                containerType: ContainerType.MerkleTree
                );
            }

        public static ContainerStatus Status(string directory, string containerName) {
            using (var container = new Spool(directory, containerName)) {

                return new ContainerStatus() {
                    Index = (int)container.Container.FrameCount,
                    Container = containerName
                    };
                }
            }
        }

    /// <summary>
    /// The outbound spool contains messages that are queued to be sent to other parties.
    /// </summary>
    public class SpoolOutbound : Spool {
        public static string Label = "SpoolOutbound";

        public override string ContainerDefault => Label;
        public SpoolOutbound(string directory, string containerName = null) : base(directory, containerName) {
            }
        }

    public class SpoolInbound : Spool {
        public static string Label = "SpoolInbound";

        public override string ContainerDefault => Label;

        public SpoolInbound(string directory, string containerName = null) : base (directory, containerName) {
            }
        }




    public class SpoolArchive : Spool {
        public static string Label = "SpoolArchive";

        public override string ContainerDefault => Label;

        public SpoolArchive(string directory, string containerName = null) : base(directory, containerName) {
            }
        }

    public class SpoolAccount : Spool {
        public static string Label = "SpoolAccount";

        public override string ContainerDefault => Label;

        public SpoolAccount(string directory, string containerName=null) : base(directory, containerName) {
            }
        }



    }
