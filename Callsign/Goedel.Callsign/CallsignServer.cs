////  Copyright © 2021 by Threshold Secrets Llc.
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

//using Goedel.Utilities;

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;
//using Goedel.Mesh;
//using Goedel.Cryptography;
//using Goedel.Cryptography.Dare;
//using Goedel.IO;

//namespace Goedel.Callsign; 
//public class CallsignServer {
//    #region // Properties

//    public Callsign Callsign { get; }
//    public Registration Registration { get; }
//    public KeyPair KeySign { get; }


//    public string Filename { get; }

//    public Sequence Sequence;

//    #endregion
//    #region // Constructors

//    public CallsignServer(
//                Callsign callsign, 
//                Registration registration, 
//                KeyPair keyPair,
//                DarePolicy policy = null,
//                CryptoParameters cryptoParameters = null,
//                IKeyCollection keyCollection = null,
//                bool create = false) {
//        Callsign = callsign;
//        Registration = registration;
//        KeySign = keyPair;

//        Filename = callsign.Id + ".dares";

//        Sequence = Sequence.Open(
//            Filename,
//            FileStatus.ConcurrentLocked,
//            keyCollection ?? cryptoParameters?.KeyLocate,
//            SequenceType.Merkle,
//            policy,
//            "application/mmm-catalog",
//            create: create
//            );




//        }



//    #endregion
//    #region // Methods

//    public void Enter(CallsignEntry callsignEntry) {

//        var envelope = Enveloped<CallsignEntry>.Envelope(callsignEntry, KeySign);
//        Sequence.Append(envelope);
//        }


//    public Notarization CreateNotarization (
//                Notarization previous) {
//        // Write out the callsign registration to the first item in the sequence.


        
//        var witness = new Witness() {
//            Id = Callsign.Id,
//            Issuer = Callsign.Id,
//            Apex = Sequence.TrailerLast.PayloadDigest
//            };
//        var envelopedWitness = Enveloped<Witness>.Envelope(witness, KeySign);




//        var notarization = new Notarization() {
//            Entries = new List<Enveloped<Witness>> { envelopedWitness }
//            };

//        if (previous != null) {
//            notarization.Proof = new Proof();
//            }

//        return notarization;
//        }


//    public void EnterNotarization(
//                Notarization notarization) {

        
//        var envelopedNotarization = Enveloped<Notarization>.Envelope(notarization, KeySign);

//        Sequence.Append(envelopedNotarization);

//        //return CreateNotarization();
//        }


//    #endregion
//    }
