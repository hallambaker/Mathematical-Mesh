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
        public const string SpoolOutbound = "SpoolOutbound";
        public const string SpoolInbound = "SpoolInbound";
        public const string SpoolArchive = "SpoolArchive";

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

        public void Add(DareMessage dareMessage) => Container.AppendDirect(dareMessage);


        }

    ///// <summary>
    ///// The outbound spool contains messages that are queued to be sent to other parties.
    ///// </summary>
    //public class SpoolOutbound : Spool {
    //    public static string Label = "SpoolOutbound";

    //    public override string ContainerDefault => Label;
    //    public SpoolOutbound(string directory, string ContainerName = null,
    //        CryptoParameters cryptoParameters = null,
    //                KeyCollection keyCollection = null) :
    //        base(directory, ContainerName, cryptoParameters, keyCollection) {
    //        }

    //    public new static Spool Factory(
    //                string Directory,
    //                string name,
    //                CryptoParameters cryptoParameters,
    //                KeyCollection keyCollection) =>
    //        new SpoolOutbound(Directory, name??Label, cryptoParameters, keyCollection);

    //    }

    //public class SpoolInbound : Spool {
    //    public static string Label = "SpoolInbound";

    //    public override string ContainerDefault => Label;

    //    public SpoolInbound(string directory, string ContainerName = null,
    //        CryptoParameters cryptoParameters = null,
    //                KeyCollection keyCollection = null) :
    //        base(directory, ContainerName, cryptoParameters, keyCollection) {
    //        }

    //    public new static Spool Factory(
    //                string Directory,
    //                string name,
    //                CryptoParameters cryptoParameters,
    //                KeyCollection keyCollection) =>
    //        new SpoolInbound(Directory, name ?? Label, cryptoParameters, keyCollection);
    //    }




    //public class SpoolArchive : Spool {
    //    public static string Label = "SpoolArchive";

    //    public override string ContainerDefault => Label;

    //    public SpoolArchive(string directory, string ContainerName = null,
    //        CryptoParameters cryptoParameters = null,
    //                KeyCollection keyCollection = null) :
    //        base(directory, ContainerName, cryptoParameters, keyCollection) {
    //        }

    //    public new static Store Factory(
    //                string Directory,
    //                string name,
    //                CryptoParameters cryptoParameters,
    //                KeyCollection keyCollection) =>
    //        new SpoolArchive(Directory, name ?? Label, cryptoParameters, keyCollection);
    //    }

    //public class SpoolAccount : Spool {
    //    public static string Label = "SpoolAccount";

    //    public override string ContainerDefault => Label;

    //    public SpoolAccount(string directory, string ContainerName = null,
    //        CryptoParameters cryptoParameters = null,
    //                KeyCollection keyCollection = null) :
    //        base(directory, ContainerName, cryptoParameters, keyCollection) {
    //        }

    //    public new static Store Factory(
    //                string Directory,
    //                string name,
    //                CryptoParameters cryptoParameters,
    //                KeyCollection keyCollection) =>
    //        new SpoolAccount(Directory, name ?? Label, cryptoParameters, keyCollection);
    //    }



    }
