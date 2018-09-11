using System;
using MT=Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Cryptography;
using GCC=Goedel.Cryptography.Container;
using Goedel.Utilities;
using Goedel.IO;

namespace Test.Goedel.Cryptography.Container {
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



        public void TestContainer (GCC.IContainer Container, int Count, int MaxSize) {
            var Start = (int)Container.FrameCount;
            MakeContainer(Container, Count, MaxSize);
            VerifyContainer(Container, Count+ Start, MaxSize);
            }




        public void MakeContainer (GCC.IContainer Container, int Count, int MaxSize) {
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


        public void VerifyContainer (GCC.IContainer Container, int Count, int MaxSize) {
            Container.First();
            for (int i = 0; i < Count; i++) {
                Assert.False(Container.EOF, Internal.Throw, "Expected EOF clear");
                Assert.True(Container.ContainerHeader.Index == i,  Internal.Throw, "Bad index value");
                Container.Next();
                }

            Assert.True(Container.EOF, Internal.Throw, "Expected EOF set");
            }

        public void VerifyContainerReverse (GCC.IContainer Container, int Count, int MaxSize) {
            Container.Last();

            Assert.True(Container.EOF, Internal.Throw, "Expected EOF set");
            for (int i = Count-1; i >= 0; i--) {
                Assert.False(Container.EOF, Internal.Throw, "Expected EOF clear");
                Assert.True(Container.ContainerHeader.Index == i, Internal.Throw, "Bad index value");
                Container.Previous();
                }

            }


        public void VerifyData (int Count, int MaxSize, byte[] Data) {
            for (var i = 0; i < MaxSize; i++) {
                Assert.True(Data[i] == (byte)(i & 0xff), Internal.Throw, "Bad data value");
                }

            }
        }
    }
