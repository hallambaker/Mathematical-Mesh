using Goedel.Cryptography.Dare;
using Goedel.IO;
using Goedel.Test;
using Goedel.Test.Core;
using Goedel.Utilities;

using System.Text;

using Xunit;

namespace Goedel.XUnit {

    public class TestJBCD {



        static byte[] MakeConstant(string Text, int Repeat) {

            var Builder = new StringBuilder();
            for (var i = 0; i < Repeat; i++) {
                Builder.Append(Text);
                }

            return Builder.ToString().ToBytes();

            }

        [Theory]
        [InlineData("JBCD0.jbcd", 0)]
        [InlineData("JBCD1.jbcd", 1)]
        [InlineData("JBCD10.jbcd", 10)]
        public void TestJBCDStream(string FileName, int Records, int MaxSize = 0) {
            //ReOpen = ReOpen == 0 ? Records : ReOpen;
            MaxSize = MaxSize == 0 ? Records + 1 : MaxSize;


            using (var JBCDStream = new JbcdStream(FileName, FileStatus.Overwrite)) {
                for (int i = 0; i < Records; i++) {
                    var Test1 = MakeConstant("Header ", ((i + 1) % MaxSize));
                    var Test2 = MakeConstant("Data ", ((i + 1) % MaxSize));
                    JBCDStream.WriteWrappedFrame(Test1, Test2);
                    }
                }

            using (var JBCDStream = new JbcdStream(FileName, FileStatus.Read)) {
                for (int i = 0; i < Records; i++) {
                    var Test1 = MakeConstant("Header ", ((i + 1) % MaxSize));
                    var Test2 = MakeConstant("Data ", ((i + 1) % MaxSize));

                    JBCDStream.ReadFrame(out var Header, out var Data, out var FrameTrailer);

                    Header.IsEqualTo(Test1).TestTrue();
                    Data.IsEqualTo(Test2).TestTrue();
                    }

                }
            }


        }
    }
