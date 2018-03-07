using System;
using System.Text;
using System.Collections.Generic;
using MT = Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Cryptography;
using Goedel.Cryptography.Container;
using Goedel.Utilities;
using Goedel.IO;

namespace Test.Goedel.Cryptography.Container {
    [MT.TestClass]
    public class TestContainers {
        [MT.ClassInitialize]
        public static void Initialize (MT.TestContext Context) {
            global::Goedel.IO.Debug.Initialize();
            global::Goedel.Cryptography.Cryptography.Initialize();
            }

        [MT.TestMethod]
        public void ContainerTestList () {
            var n = 0;
            TestContainer($"ContainerList-{n}", ContainerType.List, n);
            }

        [MT.TestMethod]
        public void ContainerTestDigest () {
            var n = 0;
            TestContainer($"ContainerDigest-{n}", ContainerType.Digest, n);
            }


        [MT.TestMethod]
        public void ContainerTestChain () {
            var n = 0;
            TestContainer($"ContainerChain-{n}", ContainerType.Chain, n);
            }

        [MT.TestMethod]
        public void ContainerTestTree () {
            var n = 0;
            TestContainer($"ContainerTree-{n}", ContainerType.Tree, n);
            }

        [MT.TestMethod]
        public void ContainerTestMerkleTree () {
            var n = 0;
            TestContainer($"ContainerMerkle-{n}", ContainerType.MerkleTree, n);
            }


        [MT.TestMethod]
        public void ContainerTest0 () {
            var n = 0;
            TestContainer($"ContainerList{n}", ContainerType.List, n);
            TestContainer($"ContainerDigest{n}", ContainerType.Digest, n);
            TestContainer($"ContainerChain{n}", ContainerType.Chain, n);
            TestContainer($"ContainerTree{n}", ContainerType.Tree, n);
            TestContainer($"ContainerMerkle{n}", ContainerType.MerkleTree, n);
            }

        [MT.TestMethod]
        public void ContainerTest1 () {
            var n = 1;
            TestContainer($"ContainerList{n}", ContainerType.List, n);
            TestContainer($"ContainerDigest{n}", ContainerType.Digest, n);
            TestContainer($"ContainerChain{n}", ContainerType.Chain, n);
            TestContainer($"ContainerTree{n}", ContainerType.Tree, n);
            TestContainer($"ContainerMerkle{n}", ContainerType.MerkleTree, n);
            }

        [MT.TestMethod]
        public void ContainerTest10 () {
            var n = 10;
            TestContainer($"ContainerList{n}", ContainerType.List, n);
            TestContainer($"ContainerDigest{n}", ContainerType.Digest, n);
            TestContainer($"ContainerChain{n}", ContainerType.Chain, n);
            TestContainer($"ContainerTree{n}", ContainerType.Tree, n);
            TestContainer($"ContainerMerkle{n}", ContainerType.MerkleTree, n);
            }


        [MT.TestMethod]
        public void ContainerTest500 () {
            var Records = 500;
            var ReOpen = 13;
            var MoveStep = 27;
            TestContainer($"ContainerList{Records}-{ReOpen}-{MoveStep}", ContainerType.List, 
                Records, ReOpen: ReOpen, MoveStep: MoveStep);
            TestContainer($"ContainerDigest{Records}-{ReOpen}-{MoveStep}", ContainerType.Digest,
                Records, ReOpen: ReOpen, MoveStep: MoveStep);
            TestContainer($"ContainerChain{Records}-{ReOpen}-{MoveStep}", ContainerType.Chain,
                Records, ReOpen: ReOpen, MoveStep: MoveStep);
            TestContainer($"ContainerTree{Records}-{ReOpen}-{MoveStep}", ContainerType.Tree,
                Records, ReOpen: ReOpen, MoveStep: MoveStep);
            TestContainer($"ContainerMerkle{Records}-{ReOpen}-{MoveStep}", ContainerType.MerkleTree,
                Records, ReOpen: ReOpen, MoveStep: MoveStep);
            }


        byte[] MakeConstant (string Text, int Repeat) {

            var Builder = new StringBuilder();
            for (var i = 0; i < Repeat; i++) {
                Builder.Append(Text);
                }

            return Builder.ToString().ToBytes();

            }

        public void TestContainer (string FileName, ContainerType ContainerType,
                    int Records = 1, int MaxSize = 0, int ReOpen = 0, int MoveStep = 0) {
            ReOpen = ReOpen == 0 ? Records : ReOpen;
            MaxSize = MaxSize == 0 ? Records + 1 : MaxSize;

            int Record;

            // Write initial set of records
            using (var XContainer = global::Goedel.Cryptography.Container.Container.NewContainer(FileName, FileStatus.Overwrite, ContainerType)) {
                for (Record = 0; Record < ReOpen; Record++) {
                    var Test = MakeConstant("Test ", ((Record + 1) % MaxSize));
                    XContainer.Append(Test);
                    }
                }

            // Write additional records
            while (Record < Records) {
                using (var XContainer = global::Goedel.Cryptography.Container.Container.Open(FileName, FileStatus.Append)) {
                    for (var i = 0; (Record < Records) & i < ReOpen; i++) {
                        var Test = MakeConstant("Test ", ((Record + 1) % MaxSize));
                        XContainer.Append(Test);
                        Record++;
                        }
                    }
                }

            //CheckContainer(FileName);

            var Headers = new List<ContainerHeader>();


            // Read records 
            using (var XContainer = global::Goedel.Cryptography.Container.Container.Open(FileName, FileStatus.Read)) {
                for (Record = 0; Record < Records; Record++) {
                    var Test = MakeConstant("Test ", ((Record + 1) % MaxSize));
                    var Result = XContainer.Next();

                    Console.WriteLine("====");
                    Console.WriteLine(XContainer.ContainerHeader.ToString());
                    Headers.Add(XContainer.ContainerHeader);

                    Assert.True(Result);
                    Assert.True(XContainer.FrameData.IsEqualTo(Test));
                    }

                var Last = XContainer.Next();
                Assert.False(Last);

                XContainer.CheckContainer(Headers);
                }

            if (MoveStep > 0) {
                using (var XContainer = global::Goedel.Cryptography.Container.Container.Open(FileName, FileStatus.Read)) {
                    for (Record = MoveStep; Record < Records; Record+= MoveStep) {

                        XContainer.Move(Record);
                        Assert.True(XContainer.ContainerHeader.Index == Record);

                        }

                    }
                }

            // check last record.
            using (var XContainer = global::Goedel.Cryptography.Container.Container.Open(FileName, FileStatus.Read)) {
                var Last = XContainer.Last();
                if (Records == 0) {
                    Assert.False(Last);
                    }
                else {
                    Assert.True(Last);
                    var Test = MakeConstant("Test ", (Records % MaxSize));
                    Assert.True(XContainer.FrameData.IsEqualTo(Test));
                    }

                
                
                }


            }
        

        }
    }
