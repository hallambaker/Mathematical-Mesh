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

using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;

namespace ExampleGenerator;

public class ShellHash : ExampleSet {
    public List<ExampleResult> HashUDF2;
    public List<ExampleResult> HashUDF3;
    public List<ExampleResult> HashUDF200; // Wrong precision, implement /bits
    public List<ExampleResult> HashUDFExpect; // implement /expect
    public List<ExampleResult> HashDigest;
    public List<ExampleResult> HashDigests;
    public List<ExampleResult> MAC1;  // return the key
    public List<ExampleResult> MAC2;  // implement key option
    public List<ExampleResult> MAC3;  // implement expect option



    public ShellHash(CreateExamples createExamples) :
            base(createExamples) {
        HashUDF2 = Alice1.Example($"hash udf {TestFile1}");
        var expect2 = (HashUDF2[0].Result as ResultDigest).Digest;
        HashUDF3 = Alice1.Example($"hash udf {TestFile1} /cty=application/binary",
                                          $"hash udf {TestFile1} /alg=sha3");
        var expect3 = (HashUDF3[0].Result as ResultDigest).Digest;
        HashUDF200 = Alice1.Example($"hash udf {TestFile1} /bits=200");
        HashUDFExpect = Alice1.Example($"hash udf {TestFile1} /expect={expect2}",
                                          $"~hash udf {TestFile1} /expect={expect3}");
        HashDigest = Alice1.Example($"hash digest {TestFile1}");
        HashDigests = Alice1.Example($"hash digest {TestFile1} /alg=sha256",
                                          // $"hash digest {TestFile1} /alg=sha128",
                                          $"hash digest {TestFile1} /alg=sha3256",
                                          $"hash digest {TestFile1} /alg=sha3");
        MAC1 = Alice1.Example($"hash mac {TestFile1}");
        var key = (MAC1[0].Result as ResultDigest).Key;
        var digest = (MAC1[0].Result as ResultDigest).Digest;

        MAC2 = Alice1.Example($"hash mac {TestFile1} /key={key}");
        MAC3 = Alice1.Example($"hash mac {TestFile1} /key={key} /expect={digest}",
            $"~hash mac {TestFile1} /key={key} /expect={expect2}");
        }
    }
