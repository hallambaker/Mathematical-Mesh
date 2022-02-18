﻿using System;
using System.Text;
using System.Collections.Generic;
using MT = Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.IO;

namespace Test.Goedel.Cryptography.Container {
    public partial class TestContainers {
        [MT.ClassInitialize]
        public static void Initialize(MT.TestContext Context) {
            global::Goedel.IO.Debug.Initialize();
            global::Goedel.Cryptography.Cryptography.Initialize();
            }

        [MT.TestMethod]
        public void ContainerTestList() {
            TestContainer($"ContainerList", ContainerType.List, 0);
            TestContainer($"ContainerList", ContainerType.List, 1);
            TestContainer($"ContainerList", ContainerType.List, 10);
            }

        [MT.TestMethod]
        public void ContainerTestDigest() {
            TestContainer($"ContainerDigest", ContainerType.Digest, 0);
            TestContainer($"ContainerDigest", ContainerType.Digest, 1);
            TestContainer($"ContainerDigest", ContainerType.Digest, 10);
            }


        [MT.TestMethod]
        public void ContainerTestChain() {
            TestContainer($"ContainerChain", ContainerType.Chain, 0);
            TestContainer($"ContainerChain", ContainerType.Chain, 1);
            TestContainer($"ContainerChain", ContainerType.Chain, 10);
            }

        [MT.TestMethod]
        public void ContainerTestTree() {
            TestContainer($"ContainerTree", ContainerType.Tree, 0);
            TestContainer($"ContainerTree", ContainerType.Tree, 1);
            TestContainer($"ContainerTree", ContainerType.Tree, 10);
            }

        [MT.TestMethod]
        public void ContainerTestMerkleTree() {
            TestContainer($"ContainerMerkle", ContainerType.MerkleTree, 0);
            TestContainer($"ContainerMerkle", ContainerType.MerkleTree, 1);
            TestContainer($"ContainerMerkle", ContainerType.MerkleTree, 10);
            }


        [MT.TestMethod]
        public void ContainerTest0() {
            var n = 0;
            TestContainer($"ContainerList-", ContainerType.List, n);
            TestContainer($"ContainerDigest-", ContainerType.Digest, n);
            TestContainer($"ContainerChain-", ContainerType.Chain, n);
            TestContainer($"ContainerTree-", ContainerType.Tree, n);
            TestContainer($"ContainerMerkle-", ContainerType.MerkleTree, n);
            }

        [MT.TestMethod]
        public void ContainerTest1() {
            var n = 1;
            TestContainer($"ContainerList-", ContainerType.List, n);
            TestContainer($"ContainerDigest-", ContainerType.Digest, n);
            TestContainer($"ContainerChain-", ContainerType.Chain, n);
            TestContainer($"ContainerTree-", ContainerType.Tree, n);
            TestContainer($"ContainerMerkle-", ContainerType.MerkleTree, n);
            }

        [MT.TestMethod]
        public void ContainerTest10() {
            var n = 10;
            TestContainer($"ContainerList-", ContainerType.List, n);
            TestContainer($"ContainerDigest-", ContainerType.Digest, n);
            TestContainer($"ContainerChain-", ContainerType.Chain, n);
            TestContainer($"ContainerTree-", ContainerType.Tree, n);
            TestContainer($"ContainerMerkle-", ContainerType.MerkleTree, n);
            }


        [MT.TestMethod]
        public void ContainerTest500() {
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


        byte[] MakeConstant(string Text, int Repeat) {

            var Builder = new StringBuilder();
            for (var i = 0; i < Repeat; i++) {
                Builder.Append(Text);
                }

            return Builder.ToString().ToBytes();

            }



        public void TestContainer(string FileName, ContainerType ContainerType,
                    int Records = 1, int MaxSize = 0, int ReOpen = 0, int MoveStep = 0) {
            ReOpen = ReOpen == 0 ? Records : ReOpen;
            MaxSize = MaxSize == 0 ? Records + 1 : MaxSize;

            FileName = FileName + $"-{Records}";

            int Record;

            // Write initial set of records
            using (var XContainer = global::Goedel.Cryptography.Dare.Container.NewContainer(FileName, FileStatus.Overwrite, ContainerType)) {
                for (Record = 0; Record < ReOpen; Record++) {
                    var Test = MakeConstant("Test ", ((Record + 1) % MaxSize));
                    XContainer.Append(Test);
                    }
                }

            // Write additional records
            while (Record < Records) {
                using (var XContainer = global::Goedel.Cryptography.Dare.Container.Open(FileName, FileStatus.Append)) {
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
            using (var XContainer = global::Goedel.Cryptography.Dare.Container.Open(FileName, FileStatus.Read)) {
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
                using (var XContainer = global::Goedel.Cryptography.Dare.Container.Open(FileName, FileStatus.Read)) {
                    for (Record = MoveStep; Record < Records; Record+= MoveStep) {

                        XContainer.Move(Record);
                        Assert.True(XContainer.ContainerHeader.Index == Record);

                        }

                    }
                }

            // check last record.
            using (var XContainer = global::Goedel.Cryptography.Dare.Container.Open(FileName, FileStatus.Read)) {
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
