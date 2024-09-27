using System;
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

using Goedel.Cryptography.Algorithms;

using System.Numerics;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Nist;

#pragma warning disable IDE0059

namespace Goedel.XUnit;

public partial class TestGoedelCryptography {

    [Fact]
    public void TestECDHP() {

        var Alice = KeyPairECDHNist.Generate(256, KeySecurity.Exportable);
        var key = Platform.GetRandomBytes(32);

        // encrypt the key value.
        Alice.Encrypt(key, out var exchange, out var ephemeral);

        // decrypt the key
        var key1 = Alice.Decrypt(exchange, ephemeral);

        // Check that the returned shared secret is the same as the original.
        key1.TestEqual(key);
        }

    [Fact]
    public void TestECDHPThreshold() {

        var KeyA = new CurveNistPrivate(EccCurveFactory.P256);
        var KeyAPublic = KeyA.PublicKey;

        var RecryptKeys = KeyA.MakeThresholdKeySet(2);

        var Result = KeyAPublic.Agreement();

        EccPoint[] Carry = new EccPoint[2];
        Carry[0] = (RecryptKeys[0] as CurveNistPrivate).Agreement(Result.EphemeralPoint);
        Carry[1] = (RecryptKeys[1] as CurveNistPrivate).Agreement(Result.EphemeralPoint);

        var AgreeAB = CurveNistPrivate.Agreement(Carry);

        AgreeAB.AgreementNist.Equals(Result.AgreementNist).TestTrue();
        }

    [Fact]
    public void TestECDSA() {

        var Alice = KeyPairECDHNist.Generate(256, KeySecurity.Exportable);
        var digest = Platform.GetRandomBytes(32);

        // encrypt the key value.
        var signature = Alice.SignDigest(digest, CryptoAlgorithmId.SHA_2_256);

        // decrypt the key
        var check = Alice.VerifyDigest(digest, signature);

        // Check that the returned shared secret is the same as the original.
        check.TestTrue();
        }

    /*
     * This example uses ECDH-ES Key Agreement and the Concat KDF to derive
   the CEK in the manner described in Section 4.6.  In this example, the
   ECDH-ES Direct Key Agreement mode ("alg" value "ECDH-ES") is used to
   produce an agreed-upon key for AES GCM with a 128-bit key ("enc"
   value "A128GCM").

   In this example, a producer Alice is encrypting content to a consumer
   Bob.  The producer (Alice) generates an ephemeral key for the key
   agreement computation.  Alice's ephemeral key (in JWK format) used
   for the key agreement computation in this example (including the
   private part) is:

     {"kty":"EC",
      "crv":"P-256",
      "x":"gI0GAILBdu7T53akrFmMyGcsF3n5dO7MmwNBHKW5SV0",
      "y":"SLW_xSffzlPWrHEVI30DHM_4egVwt3NQqeUD7nMFpps",
      "d":"0_NxaRPUMQoAJt50Gz8YiTr8gRTwyEaCumd-MToTmIo"
     }

   The consumer's (Bob's) key (in JWK format) used for the key agreement
   computation in this example (including the private part) is:

     {"kty":"EC",
      "crv":"P-256",
      "x":"weNJy2HscCSM6AEDTDg04biOvhFhyyWvOHQfeF_PxMQ",
      "y":"e8lnCO-AlStT-NJVX-crhB7QRYhiix03illJOVAOyck",
      "d":"VEmDZpDXXK8p8N0Cndsxs924q6nS1RXFASRl6BfUqdw"
     }

   Header Parameter values used in this example are as follows.  The
   "apu" (agreement PartyUInfo) Header Parameter value is the base64url
   encoding of the UTF-8 string "Alice" and the "apv" (agreement
   PartyVInfo) Header Parameter value is the base64url encoding of the
   UTF-8 string "Bob".  The "epk" (ephemeral public key) Header
   Parameter is used to communicate the producer's (Alice's) ephemeral
   public key value to the consumer (Bob).

    {"alg":"ECDH-ES",
      "enc":"A128GCM",
      "apu":"QWxpY2U",
      "apv":"Qm9i",
      "epk":
       {"kty":"EC",
        "crv":"P-256",
        "x":"gI0GAILBdu7T53akrFmMyGcsF3n5dO7MmwNBHKW5SV0",
        "y":"SLW_xSffzlPWrHEVI30DHM_4egVwt3NQqeUD7nMFpps"
       }
     }

   The resulting Concat KDF [NIST.800-56A] parameter values are:

   Z
      This is set to the ECDH-ES key agreement output.  (This value is
      often not directly exposed by libraries, due to NIST security
      requirements, and only serves as an input to a KDF.)  In this
      example, Z is following the octet sequence (using JSON array
      notation):
      [158, 86, 217, 29, 129, 113, 53, 211, 114, 131, 66, 131, 191, 132,
      38, 156, 251, 49, 110, 163, 218, 128, 106, 72, 246, 218, 167, 121,
      140, 254, 144, 196].



   AlgorithmID
      This is set to the octets representing the 32-bit big-endian value
      7 - [0, 0, 0, 7] - the number of octets in the AlgorithmID content
      "A128GCM", followed, by the octets representing the ASCII string
      "A128GCM" - [65, 49, 50, 56, 71, 67, 77].

   PartyUInfo
      This is set to the octets representing the 32-bit big-endian value
      5 - [0, 0, 0, 5] - the number of octets in the PartyUInfo content
      "Alice", followed, by the octets representing the UTF-8 string
      "Alice" - [65, 108, 105, 99, 101].

   PartyVInfo
      This is set to the octets representing the 32-bit big-endian value
      3 - [0, 0, 0, 3] - the number of octets in the PartyUInfo content
      "Bob", followed, by the octets representing the UTF-8 string "Bob"
      - [66, 111, 98].



   keydatalen
      This value is 128 - the number of bits in the desired output key
      (because "A128GCM" uses a 128-bit key).

   SuppPubInfo
      This is set to the octets representing the 32-bit big-endian value
      128 - [0, 0, 0, 128] - the keydatalen value.

   SuppPrivInfo
      This is set to the empty octet sequence.

   Concatenating the parameters AlgorithmID through SuppPubInfo results
   in an OtherInfo value of:
   [0, 0, 0, 7, 65, 49, 50, 56, 71, 67, 77, 0, 0, 0, 5, 65, 108, 105,
   99, 101, 0, 0, 0, 3, 66, 111, 98, 0, 0, 0, 128]

   Concatenating the round number 1 ([0, 0, 0, 1]), Z, and the OtherInfo
   value results in the Concat KDF round 1 hash input of:
   [0, 0, 0, 1,
   158, 86, 217, 29, 129, 113, 53, 211, 114, 131, 66, 131, 191, 132, 38,
   156, 251, 49, 110, 163, 218, 128, 106, 72, 246, 218, 167, 121, 140,
   254, 144, 196,
   0, 0, 0, 7, 65, 49, 50, 56, 71, 67, 77, 
   0, 0, 0, 5, 65, 108, 105, 99, 101, 
   0, 0, 0, 3, 66, 111, 98, 
   0, 0, 0, 128]

   The resulting derived key, which is the first 128 bits of the round 1
   hash output is:
   [86, 170, 141, 234, 248, 35, 109, 32, 92, 34, 40, 205, 113, 167, 16,
   26]

   The base64url-encoded representation of this derived key is:

     VqqN6vgjbSBcIijNcacQGg


     */




    }
