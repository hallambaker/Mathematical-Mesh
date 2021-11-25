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
//  

using System;
using System.Collections.Generic;

using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

namespace Goedel.Test.Core;

public class TestFile {

    string PlaintextFilename { get; }

    string EncryptedtFilename => PlaintextFilename + ".dare";

    int PlaintextLength { get; }

    int index = 0;

    public TestFile(string plaintext) {
        PlaintextFilename = plaintext.ToFileUnique();
        PlaintextLength = plaintext.Length;
        }


    public void Encrypt(IKeyLocate keyLocate,
        string recipient,
                string signer = null) {

        var cryptoParameters = new CryptoParameters(keyLocate,
            new List<string> { recipient },
            signer == null ? null : new List<string> { signer });
        DareEnvelope.Encode(cryptoParameters, PlaintextFilename, EncryptedtFilename);
        }


    public void Decrypt(IKeyLocate keyLocate) {
        var outputFile = $"{PlaintextFilename}_{index++}";
        var bytes_1 = DareEnvelope.Decode(EncryptedtFilename, outputFile,
            keyCollection: keyLocate);

        bytes_1.AssertEqual(PlaintextLength, NYI.Throw);
        }


    }
