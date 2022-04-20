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

public class ShellKey : ExampleSet {
    public List<ExampleResult> KeyNonce;
    public List<ExampleResult> KeyNonce256;
    public List<ExampleResult> KeySecret;
    public List<ExampleResult> KeySecret256;
    public List<ExampleResult> KeyEarl;

    public List<ExampleResult> KeyShare;
    public List<ExampleResult> KeyRecover;
    public List<ExampleResult> KeyShare2;
    public List<ExampleResult> KeyShare3;


    ////AdvancedQuantum
    public byte[] AdvancedQuantumMasterSecret;
    public string[] AdvancedQuantumShares;
    public byte[][] AdvancedQuantumPrivate;
    public byte[] AdvancedQuantumPublic;
    public string AdvancedQuantumPublicUDF;


    public ShellKey(CreateExamples createExamples) :
            base(createExamples) {
        KeyNonce = Alice1.Example("key nonce");
        KeyNonce256 = Alice1.Example("key nonce /bits=256");
        KeySecret = Alice1.Example("key secret");
        KeySecret256 = Alice1.Example("key secret /bits=256");
        KeyEarl = Alice1.Example("key earl");
        KeyShare = Alice1.Example("key share");
        Secret1 = (KeyShare[0].Result as ResultKey).Key;
        var share1 = (KeyShare[0].Result as ResultKey).Shares[0];
        var share2 = (KeyShare[0].Result as ResultKey).Shares[2];

        KeyRecover = Alice1.Example($"key recover {share1} {share2}");
        KeyShare2 = Alice1.Example($"key share /quorum=3 /shares=5");
        KeyShare3 = Alice1.Example($"~key share {Secret1}");

        }
    }
