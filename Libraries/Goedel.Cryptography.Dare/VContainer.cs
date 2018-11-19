//using System;
//using System.IO;
//using System.Collections.Generic;
//using Goedel.Utilities;
//using Goedel.Protocol;
//using Goedel.IO;
//using Goedel.Cryptography.Jose;
//using System.Collections;
//using Goedel.Cryptography.Dare;
//using Goedel.Cryptography;

//namespace Goedel.Cryptography.Dare {

//    public class MetaContainer : Container {

//        Container Container;
//        ContainerType ContainerType;
//        CryptoAlgorithmID DigestAlgorithm;
//        string FileName;

//        public MetaContainer(
//                    string fileName,
//                    KeyCollection KeyCollection = null,
//                    ContainerType containerType = ContainerType.Chain,
//                    CryptoAlgorithmID digestAlgorithm = CryptoAlgorithmID.Default) {
//            FileName = fileName;
//            try {
//                var streamRead = fileName.OpenFileRead();
//                var jbcdStream = new JBCDStream(streamRead, null);
//                var Container = Goedel.Cryptography.Dare.Container.Open(jbcdStream, KeyCollection);
//                }
//            catch (FileNotFoundException) {
//                Container = null;
//                ContainerType = containerType;
//                DigestAlgorithm = digestAlgorithm;

//                }


//            }


//        public override void CheckContainer(List<ContainerHeader> Headers) =>
//            Container.CheckContainer(Headers);

//        public override ContainerFramerReader GetFrameDataReader(long Index = -1, long Position = -1) =>
//            Container.GetFrameDataReader(Index, Position);

//        public override bool MoveToIndex(long FrameIndex) =>
//            Container.MoveToIndex(FrameIndex);
//        public override bool NextFrame() =>
//            Container.NextFrame();

//        public override bool Previous() =>
//            Container.Previous();
//        public override bool PreviousFrame() =>
//            Container.PreviousFrame();
//        public override long ReadDataBegin() =>
//            Container.ReadDataBegin();

//        protected override void FillDictionary(ContainerHeader Header, long FirstPosition, long PositionLast) =>
//            throw new NotImplementedException();

//        }
//    /// <summary>
//    /// Convenience class allowing a 
//    /// </summary>
//    public class ContainerHandle : Container {
//        MetaContainer ProtoContainer;
//        Container Container;

//        /// <summary>
//        /// The class specific disposal routine.
//        /// </summary>
//        protected override void Disposing() {
//            ProtoContainer.Detach();
//            }


//        public ContainerHandle(MetaContainer container, bool readOnly) {
//            ProtoContainer = container;

//            //DisposeJBCDStream = new JBCDStream();
//            if (readOnly) {
//                ProtoContainer.AttachRead();
//                }
//            else {
//                ProtoContainer.AttachWrite();
//                }
//            }





//        }
//    }
