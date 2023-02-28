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

public partial class TestDareArchive {
    public static TestDareArchive Test() => new();

    [Fact]
    public void ArchiveTest() {
        var seed = DeterministicSeed.Auto();
        TestArchiveCore(false, false, false);

        }


    static void TestArchiveCore(
                    bool encrypt,
                    bool sign,
                    bool notarize,
                    int length = 1000) {
        var seed = DeterministicSeed.Auto(encrypt, sign, notarize, length);
        var archive = Path.Combine(TestEnvironmentCommon.CommonData, TestArchive.Archive1);


        var testArchive = new TestArchive() {
            Filename = archive,
            Encrypt = encrypt,
            Sign = sign,
            Notarize = notarize,
            };




    }



    }
