using System;
using System.Collections.Generic;

using System.Text;

namespace Goedel.Discovery {

    /// <summary>
    /// Base class for DNS Records
    /// </summary>
    public abstract partial class DNSRecord {

        /// <summary>
        /// Return data value in default unknown encoding.
        /// </summary>
        /// <returns>Encoding of record in unknown text encoding.</returns>
        public string Unknown() {
            string result = Unknown(out var encoding);

            for (int i = 0; i < encoding.Length; i++) {
                result += Canonicalize.Hex(encoding[i]);
                }

            return result;
            }

        /// <summary>
        /// Return data value in default unknown encoding.
        /// </summary>
        /// <param name="encoding">Encoded parameters in byte form</param>
        /// <returns>Encoding of record in unknown text encoding.</returns>
        public string Unknown(out byte[] encoding) {
            DNSBufferIndex DNSBufferIndex = new DNSBufferIndex();
            this.Encode(DNSBufferIndex);
            encoding = DNSBufferIndex.Bytes;

            string result = "TYPE" + (int)Code + " \\# " + encoding.Length + " ";


            return result;
            }


        }


    /// <summary>Unknown DNS record</summary>
    public partial class DNSRecord_Unknown : DNSRecord {

        /// <summary>Decode record or query from buffer</summary>	
        /// <param name="Index">Input data</param>
        /// <param name="Length">Maximum amount of data to read</param>
        /// <returns>Parsed record.</returns>
        public static DNSRecord_Unknown Decode(DNSBufferIndex Index, int Length) {
            DNSRecord_Unknown NewRecord = new DNSRecord_Unknown();

            Index.ReadL16Data(out NewRecord.RData);

            return NewRecord;
            }

        /// <summary>Convert to canonical form</summary>
        /// <returns>Canonical form of record data contents</returns>
        public override string Canonical() => Unknown();
        }
    }
