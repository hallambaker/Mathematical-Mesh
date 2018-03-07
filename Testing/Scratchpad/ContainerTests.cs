using System;
using System.Text;
using System.Collections.Generic;
using Goedel.Cryptography.Container;
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Cryptography.Framework;
using Goedel.Cryptography.KeyFile;
using Goedel.IO;
using Goedel.Utilities;
using Goedel.Test;

namespace Scratchpad.Old {



    class Program {



        byte[] Empty = new byte[0];

        // The tree methods do not currently work when re-opening an existing file
        // it is necessary to re-traverse the chain to build pointers to the previous powers of 2.


        public void Go1 () {
            TestContainer("ContainerX", ContainerType.MerkleTree, 500, ReOpen: 7, MoveStep: 23);
            //TestContainer("ContainerX", ContainerType.List, 500, ReOpen: 7, MoveStep: 23);
            //TestContainer("ContainerDigest1", ContainerType.Digest, 5, ReOpen: 3);
            //TestContainer("ContainerChain1", ContainerType.Chain, 1);
            //TestContainer("ContainerTree1", ContainerType.Tree, 30, ReOpen: 5);
            //TestContainer("ContainerMerkle1", ContainerType.MerkleTree, 20, ReOpen: 5);
            }

        public void TestJBCDStream (string FileName, int Records, int MaxSize = 0) {
            //ReOpen = ReOpen == 0 ? Records : ReOpen;
            MaxSize = MaxSize == 0 ? Records + 1 : MaxSize;


            using (var JBCDStream = new JBCDStream(FileName, FileStatus.Overwrite)) {
                for (int i = 0; i < Records; i++) {
                    var Test1 = MakeConstant("Header ", ((i + 1) % MaxSize));
                    var Test2 = MakeConstant("Data ", ((i + 1) % MaxSize));
                    JBCDStream.WriteWrappedFrame(Test1, Test2);
                    }
                }

            using (var JBCDStream = new JBCDStream(FileName, FileStatus.Read)) {
                for (int i = 0; i < Records; i++) {
                    var Test1 = MakeConstant("Header ", ((i + 1) % MaxSize));
                    var Test2 = MakeConstant("Data ", ((i + 1) % MaxSize));

                    JBCDStream.ReadFrame(out var Header, out var Data);

                    Assert.True(Header.IsEqualTo(Test1));
                    Assert.True(Data.IsEqualTo(Test2));
                    }

                }
            }

        public void TestContainer (string FileName, ContainerType ContainerType,
                    int Records = 1, int MaxSize = 0, int ReOpen = 0, int MoveStep = 0) {
            ReOpen = ReOpen == 0 ? Records : ReOpen;
            MaxSize = MaxSize == 0 ? Records + 1 : MaxSize;

            int Record;

            // Write initial set of records
            using (var XContainer = Container.NewContainer(FileName, FileStatus.Overwrite, ContainerType)) {
                for (Record = 0; (Record < Records) & Record < ReOpen; Record++) {
                    var Test = MakeConstant("Test ", ((Record + 1) % MaxSize));
                    XContainer.Append(Test);
                    }
                }

            // Write additional records
            while (Record < Records) {
                using (var XContainer = Container.Open(FileName, FileStatus.Append)) {
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
            using (var XContainer = Container.Open(FileName, FileStatus.Read)) {
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
                    for (Record = MoveStep; Record < Records; Record += MoveStep) {
                        XContainer.Move(Record);
                        Assert.True(XContainer.ContainerHeader.Index == Record);
                        }
                    }
                using (var XContainer = global::Goedel.Cryptography.Container.Container.Open(FileName, FileStatus.Read)) {
                    for (Record = Records; Record > 0; Record -= MoveStep) {
                        XContainer.Move(Record);
                        Assert.True(XContainer.ContainerHeader.Index == Record);
                        }
                    }
                }
            }


        byte[] MakeConstant (string Text, int Repeat) {

            var Builder = new StringBuilder();
            for (var i = 0; i < Repeat; i++) {
                Builder.Append(Text);
                }

            return Builder.ToString().ToBytes();

            }


        //public void TestFileContainer (string FileName, int Records = 1, int MaxSize = 0, int ReOpen = 0) {
        //    ReOpen = ReOpen == 0 ? Records : ReOpen;
        //    MaxSize = MaxSize == 0 ? Records + 1 : MaxSize;

        //    int Record;

        //    // Write initial set of records
        //    using (var Container = new FileContainer(FileName, FileStatus.Overwrite)) {
        //        for (Record = 0; Record < ReOpen; Record++) {
        //            var Test = MakeConstant("Test ", ((Record + 1) % MaxSize));
        //            Container.Add(Test);
        //            }
        //        }

        //    // Write additional records
        //    while (Record < Records) {
        //        using (var Container = new FileContainer(FileName, FileStatus.Append)) {
        //            for (var i = 0; (Record < Records) & i < ReOpen; i++) {
        //                var Test = MakeConstant("Test ", ((Record + 1) % MaxSize));
        //                Container.Add(Test);
        //                Record++;
        //                }
        //            }
        //        }

        //    CheckContainer(FileName);

        //    // Read records 
        //    using (var Container = new FileContainer(FileName, FileStatus.Read)) {
        //        for (Record = 0; Record < Records; Record++) {
        //            var Test = MakeConstant("Test ", ((Record + 1) % MaxSize));
        //            var Result = Container.Read();

        //            Assert.NotNull(Result);
        //            Assert.True(Result.IsEqualTo(Test));
        //            }

        //        var Last = Container.Read();
        //        Assert.Null(Last);
        //        }

        //    }



        public void Go () {

            //TestFileContainer("Singleton", 1);



            //var AliceKeyPair = new DHKeyPair();
            ////var MaxChunk = 200;
            //var Test1 = MakeConstant("Test1", 1) ;
            //var Test2 = MakeConstant("Test2", 100);
            //var Test3 = MakeConstant("Test3", 1000);

            //var Filename = "singleton_empty";
            ////// Create singleton containers
            ////using (var Container = new FileContainer(Filename)) {
            ////    Container.Add(Empty);
            ////    }
            ////CheckContainer(Filename, Empty);




            ////Filename = "singleton_text";
            ////using (var Container = new FileContainer(Filename)) {
            ////    Container.Add(Test1);
            ////    }
            ////CheckContainer(Filename, Test1);

            //Filename = "singleton_encrypted";
            //using (var Container = new FileContainer(Filename)) {
            //    Container.Add(Test1, Encrypt:AliceKeyPair);
            //    }
            //CheckContainer(Filename, Test1, AliceKeyPair);

            //// Create Multi-containers with different numbers of entries
            //Filename = "multi_empty";
            //using (var Container = new FileContainer(Filename)) {
            //    }

            //Filename = "multi_0";
            //using (var Container = new FileContainer(Filename)) {
            //    Container.Archive();
            //    }

            //Filename = "multi_1";
            //using (var Container = new FileContainer(Filename)) {
            //    Container.Add(Test1, Encrypt: AliceKeyPair);
            //    Container.Archive();
            //    }
            //CheckContainer(Filename, Test1, AliceKeyPair);


            //Filename = "multi_3";
            //using (var Container = new FileContainer(Filename)) {
            //    Container.Add(Test1, Encrypt: AliceKeyPair);
            //    Container.Add(Test2, Encrypt: AliceKeyPair);
            //    Container.Add(Test3, Encrypt: AliceKeyPair);
            //    Container.Archive();
            //    }
            //CheckContainer(Filename, Test3, AliceKeyPair);
            //CheckContainer(Filename, Test2, AliceKeyPair);
            //CheckContainer(Filename, Test1, AliceKeyPair);


            //// Create Serial container

            //Filename = "serial_1";
            //using (var Container = new FileContainer(Filename)) {
            //    Container.Add(Test1, Encrypt: AliceKeyPair, MaxChunk: MaxChunk);
            //    }
            //CheckContainer(Filename, Test1, AliceKeyPair);

            //Filename = "serial_2";
            //using (var Container = new FileContainer(Filename)) {
            //    Container.Add(Test2, Encrypt: AliceKeyPair, MaxChunk: MaxChunk);
            //    }
            //CheckContainer(Filename, Test2, AliceKeyPair);

            }

        public void CheckContainer (string FileName, byte[] Constant = null, KeyPair Encrypt = null) {

            using (var FileStream = FileName.FileStream(FileStatus.Read)) {

                var JBCDStream = new JBCDStreamDebug(FileStream) { Active = true };

                var Container = Goedel.Cryptography.Container.Container.OpenExisting(JBCDStream);

                Console.WriteLine("--Container Header--");
                Console.WriteLine(Container.ContainerHeaderFirst.ToString());

                JBCDStream.Active = true;
                Container.First();
                while (!Container.EOF) {

                    Console.WriteLine("--Header--");
                    Console.WriteLine(Container.ContainerHeader.ToString());

                    if (Container.FrameData != null) {
                        Console.WriteLine($"--Data-- [{Container.FrameData.Length} bytes]");
                        }

                    Console.WriteLine("---End Frame---");
                    Console.WriteLine("");
                    Container.Next();
                    }


                }
            }



        public void TestPersistence () {

            var Container = new ContainerPersistenceStore("test1", "application/mmm-portal", "Testy test container");

            var PortalEntry = new Account() {
                Created = DateTime.Now,
                AccountID = "Alice@example.com",
                Status = "Bogus"
                };


            Container.New(PortalEntry);
            }


        }
    }
