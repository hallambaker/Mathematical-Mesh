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
using System;
using System.Numerics;

using Goedel.Utilities;

namespace Goedel.Cryptography.PKIX {
    public partial class RFC2631OtherInfo {
        int Count;
        int AgreedBits;
        byte[] AgreementData;

        /// <summary>
        /// Principal constructor
        /// </summary>
        /// 
        /// <param name="AgreedBits">The number of bits agreed</param>
        /// <param name="Agrement">The agreement result.</param>
        /// <param name="OID">The digest OID to be used to create the key value</param>
        /// <param name="Nonce">Optional nonce. If present MUST be 512 bits</param>
        /// <param name="KeyBits">The number of bits in the generated key</param>
        /// <param name="Count">Counter, this is initially 1 and increases with
        /// each call.</param>
        public RFC2631OtherInfo(int AgreedBits, BigInteger Agrement,
                    int[] OID, int KeyBits, byte[] Nonce = null, int Count = 1) {
            this.Count = Count;
            AgreementData = Agrement.ToByteArray();
            this.AgreedBits = AgreedBits;

            KeyInfo = new KeySpecificInfo() {
                Algorithm = OID,
                Counter = Count.NetworkByte()
                };

            PartyAInfo = Nonce;
            SuppPubInfo = KeyBits.NetworkByte();

            }

        /// <summary>
        /// Increment the counter value to obtain the next agreement.
        /// </summary>
        public void Next() {
            Count++;
            KeyInfo.Counter.SetBigEndian(Count);
            }

        /// <summary>
        /// Convert Agreed value and support parameters to DER encoded array
        /// </summary>
        /// <remarks>The counter value is automatically incremented with each
        /// call. Thus the value will change slightly between calls.</remarks>
        /// <returns>The DER encoded value.</returns>
        public override byte[] DER() {
            var Buffer = new ASN.Buffer();

            Encode(Buffer);
            Next();

            // Finaly add the Big integer value.

            int i;
            var Bytes = AgreedBits / 8;

            // Write out buffer in big endian order 
            for (i = 0; i < AgreementData.Length; i++) {
                Buffer.Add(AgreementData[i]);
                }
            // Pad buffer with leading zeros if necessary.
            for (; i < Bytes; i++) {
                Buffer.Add(0);
                }

            return Buffer.Data;
            }



        }
    }
