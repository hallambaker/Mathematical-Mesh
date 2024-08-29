#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion

namespace Goedel.XUnit;

public class TestJBCD : UnitTestSet {



    static byte[] MakeConstant(string Text, int Repeat) {

        var Builder = new StringBuilder();
        for (var i = 0; i < Repeat; i++) {
            Builder.Append(Text);
            }

        return Builder.ToString().ToBytes();

        }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    public void TestJBCDStream(int Records, int MaxSize = 0) {

        Seed = DeterministicSeed.Auto(Records, MaxSize);
        var filename = Seed.GetFilename("JBCD");

        //ReOpen = ReOpen == 0 ? Records : ReOpen;
        MaxSize = MaxSize == 0 ? Records + 1 : MaxSize;


        using (var JBCDStream = new JbcdStream(filename, FileStatus.Overwrite)) {
            for (int i = 0; i < Records; i++) {
                var Test1 = MakeConstant("Header ", ((i + 1) % MaxSize));
                var Test2 = MakeConstant("Data ", ((i + 1) % MaxSize));
                JBCDStream.WriteWrappedFrame(Test1, Test2);
                }
            }

        using (var JBCDStream = new JbcdStream(filename, FileStatus.Read)) {
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
