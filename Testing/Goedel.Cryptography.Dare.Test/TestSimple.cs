using System;
using MT=Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Cryptography;
using GCC=Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.IO;

namespace Goedel.Cryptography.Dare.Test {
    [MT.TestClass]
    public class TestSimple {
        //[MT.TestMethod]
        //public void TestSimpleContainer () {

        //    var NewContainer = GCC.Container.NewContainerFactory("Simple1", FileStatus.Overwrite);
        //    TestContainer(NewContainer, 100, 300);
        //    }

        //[MT.TestMethod]
        //public void TestSimpleContainerNavigate () {

        //    var NewContainer = GCC.Container.NewContainerFactory("Simple1", FileStatus.Overwrite);
        //    TestContainer(NewContainer, 10, 300);
        //    }



        public void TestContainer (Container Container, int Count, int MaxSize) {
            var Start = (int)Container.FrameCount;
            MakeContainer(Container, Count, MaxSize);
            VerifyContainer(Container, Count+ Start, MaxSize);
            }




        public void MakeContainer (Container Container, int Count, int MaxSize) {
            for (int i = 0; i < Count; i++) {
                var Data = TestData(Count, MaxSize);
                Container.Append(Data);
                }

            }


        public byte[] TestData (int Count, int MaxSize) {
            var Data = new byte[MaxSize];
            for (var i = 0; i < MaxSize; i++) {
                Data[i] = (byte)(i & 0xff);
                }
            return Data;
            }


        public void VerifyContainer (Container Container, int Count, int MaxSize) {
            var Index = -1;

            foreach (var ContainerDataReader in Container) {
                Assert.True(ContainerDataReader.Header.Index > Index, Internal.Throw, "Bad index value");
                Index = ContainerDataReader.Header.Index;
                }
            }

        public void VerifyData (int Count, int MaxSize, byte[] Data) {
            for (var i = 0; i < MaxSize; i++) {
                Assert.True(Data[i] == (byte)(i & 0xff), Internal.Throw, "Bad data value");
                }

            }
        }
    }
