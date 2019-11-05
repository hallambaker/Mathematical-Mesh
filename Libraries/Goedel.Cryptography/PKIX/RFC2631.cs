using Goedel.Utilities;

using System;
using System.Numerics;

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
