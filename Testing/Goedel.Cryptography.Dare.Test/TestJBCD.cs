using System;
using System.Text;
using MT = Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.IO;

namespace Goedel.Cryptography.Dare.Test {
    [MT.TestClass]
    public class TestJBCD {

        [MT.TestMethod]
        public void Test0 () {
            TestJBCDStream("JBCD0.jbcd", 0);
            }

        [MT.TestMethod]
        public void Test1 () {
            TestJBCDStream("JBCD0.jbcd", 1);
            }

        [MT.TestMethod]
        public void Test10 () {
            TestJBCDStream("JBCD0.jbcd", 10);
            }


        byte[] MakeConstant (string Text, int Repeat) {

            var Builder = new StringBuilder();
            for (var i = 0; i < Repeat; i++) {
                Builder.Append(Text);
                }

            return Builder.ToString().ToBytes();

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


        }
    }
