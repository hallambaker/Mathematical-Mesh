////  © 2021 by Phill Hallam-Baker
////  
////  Permission is hereby granted, free of charge, to any person obtaining a copy
////  of this software and associated documentation files (the "Software"), to deal
////  in the Software without restriction, including without limitation the rights
////  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
////  copies of the Software, and to permit persons to whom the Software is
////  furnished to do so, subject to the following conditions:
////  
////  The above copyright notice and this permission notice shall be included in
////  all copies or substantial portions of the Software.
////  
////  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
////  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
////  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
////  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
////  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
////  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
////  THE SOFTWARE.
////  

//using Goedel.Utilities;
//using Goedel.Cryptography;
//using Goedel.Cryptography.Dare;
//using System;
//using System.Collections.Generic;


//namespace Goedel.Test.Core {

//    public enum TestSignatureError {
//        None,
//        Data,
//        Digest,
//        Value,
//        KeyIdentifier,
//        Signer
//        }



//    public static partial class Extension {

//        #region // Methods 

//        public static void BreakSignature(this DareEnvelope dareEnvelope,
//                TestSignatureError testSignatureError = TestSignatureError.Data,
//                DareEnvelope alternative = null) {
//            switch (testSignatureError) {
//                case TestSignatureError.None: {
//                    BreakSignatureNone(dareEnvelope);
//                    break;
//                    }
//                case TestSignatureError.Data: {
//                    BreakSignatureData(dareEnvelope);
//                    break;
//                    }
//                case TestSignatureError.Digest: {
//                    BreakSignatureDigest(dareEnvelope);
//                    break;
//                    }
//                case TestSignatureError.Value: {
//                    BreakSignatureValue(dareEnvelope);
//                    break;
//                    }
//                case TestSignatureError.KeyIdentifier: {
//                    BreakSignatureKeyIdentifier(dareEnvelope);
//                    break;
//                    }
//                case TestSignatureError.Signer: {
//                    BreakSignatureSigner(dareEnvelope, alternative);
//                    break;
//                    }
//                }
//            }
//        public static void BreakSignatureNone(
//                this DareEnvelope dareEnvelope) => dareEnvelope.Trailer.Signatures = null;
//        public static void BreakSignatureData(
//                this DareEnvelope dareEnvelope) =>
//            dareEnvelope.Body.Corrupt();


//        public static void BreakSignatureDigest(
//                this DareEnvelope dareEnvelope) {
//            if (dareEnvelope.Trailer.PayloadDigest == null) {
//                dareEnvelope.Trailer.PayloadDigest = Platform.GetRandomBytes(512);
//                }
//            else {
//                dareEnvelope.Trailer.PayloadDigest.Corrupt();
//                }
//            }
//        public static void BreakSignatureValue(
//                this DareEnvelope dareEnvelope) => dareEnvelope.Trailer.Signatures[0].SignatureValue.Corrupt();

//        public static void BreakSignatureKeyIdentifier(
//                this DareEnvelope dareEnvelope) =>
//            dareEnvelope.Trailer.Signatures[0].KeyIdentifier = 
//                dareEnvelope.Trailer.Signatures[0].KeyIdentifier.Corrupted();
//        public static void BreakSignatureSigner(
//                this DareEnvelope dareEnvelope,
//                DareEnvelope alternative) => dareEnvelope.Trailer.Signatures[0] =
//                        alternative.Trailer.Signatures[0];


//        #endregion 
//        }

//    }
