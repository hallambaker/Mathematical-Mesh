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

using System.Collections.Generic;

using Goedel.Mesh.Test;

namespace ExampleGenerator;

public class ShellDare : ExampleSet {
    public List<ExampleResult> DarePlaintext;
    public List<ExampleResult> DareSymmetric;
    public List<ExampleResult> DareSub;
    public List<ExampleResult> DareMesh;


    public List<ExampleResult> DareVerifyDigest;
    public List<ExampleResult> DareVerifySigned;
    public List<ExampleResult> DareVerifySymmetric;
    public List<ExampleResult> DareVerifySymmetricUnknown;

    public List<ExampleResult> DareDecodePlaintext;
    public List<ExampleResult> DareDecodeSymmetric;
    public List<ExampleResult> DareDecodePrivate;

    public List<ExampleResult> DareEarl;
    public List<ExampleResult> DareEARLLog;
    public List<ExampleResult> DareEARLLogNew;

    public ShellDare(CreateExamples createExamples) :
            base(createExamples) {
        DarePlaintext = Alice1.Example($"dare encode {TestFile1}");
        DareSymmetric = Alice1.Example($"dare encode {TestFile1} /out={TestFile1}.symmetric.dare " +
                    $"/key={Secret1}");
        DareSub = Alice1.Example($"dare encode {TestDir1} /encrypt={Secret1}");
        DareMesh = Alice1.Example($"dare encode {TestFile1} {TestFile1}.mesh.dare" +
                    $"/encrypt={BobAccount} /sign={AliceAccount}");

        DareVerifyDigest = Alice1.Example($"dare verify {TestFile1}.dare");
        DareVerifySigned = Alice1.Example($"dare verify {TestFile1}.mesh.dare");
        DareVerifySymmetricUnknown = Alice1.Example($"dare verify {TestFile1}.symmetric.dare");
        DareVerifySymmetric = Alice1.Example($"dare verify {TestFile1}.symmetric.dare /encrypt={Secret1}");

        DareDecodePlaintext = Alice1.Example($"dare decode {TestFile1}.dare");
        DareDecodeSymmetric = Alice1.Example($"dare decode {TestFile1}.symmetric.dare /encrypt={Secret1}");
        DareDecodePrivate = Alice1.Example($"dare decode {TestFile1}.mesh.dare");

        //            DareEarl = testCLIAlice1.Example($"dare earl {TestFile1} {EARLDomain}");
        //            DareEARLLog = testCLIAlice1.Example($"dare container create {DareLogEarl} /encrypt={AliceService1}",
        //                                                    $"dare earl {TestFile1} /log={DareLogEarl}");
        //            DareEARLLogNew = testCLIAlice1.Example($"dare earl {TestFile1} /new={DareLogEarl}");

        }
    }
