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

    public string DigestCiphertext => TestFile1 + ".dare";
    public string SignedCiphertext => TestFile1 + ".mesh.dare";

    public string SymmetricCiphertext => TestFile1 + ".symmetric.dare";

    public ShellDare(CreateExamples createExamples) :
            base(createExamples) {
        DarePlaintext = Alice1.Example($"dare encode {TestFile1} /out={DigestCiphertext}");
        DareSymmetric = Alice1.Example($"dare encode {TestFile1} /out={SymmetricCiphertext}" +
                    $"/key={Secret1}");
        DareSub = Alice1.Example($"dare encode {TestDir1} /encrypt={Secret1}");
        DareMesh = Alice1.Example($"dare encode {TestFile1} {SignedCiphertext} " +
                    $"/encrypt={BobAccount} /sign={AliceAccount}");

        DareVerifyDigest = Alice1.Example($"dare verify {DigestCiphertext}");
        DareVerifySigned = Alice1.Example($"dare verify {SignedCiphertext}");
        DareVerifySymmetricUnknown = Alice1.Example($"dare verify {SymmetricCiphertext}");


        DareVerifySymmetric = Alice1.Example($"dare verify {SymmetricCiphertext} /encrypt={Secret1}");

        DareDecodePlaintext = Alice1.Example($"dare decode {DigestCiphertext}");
        DareDecodeSymmetric = Alice1.Example($"dare decode {SymmetricCiphertext} /encrypt={Secret1}");
        DareDecodePrivate = Alice1.Example($"dare decode {SignedCiphertext}");

        DareEarl = Alice1.Example($"dare earl {TestFile1} {EARLService}");
        DareEARLLog = Alice1.Example($"dare log create {DareLogEarl} /encrypt={AliceAccount}",
                                                $"dare earl {TestFile1} /log={DareLogEarl}");
        DareEARLLogNew = Alice1.Example($"dare earl {TestFile1} /new={DareLogEarl}");

        }
    }
