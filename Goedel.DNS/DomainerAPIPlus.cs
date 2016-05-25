using System;
using System.Collections.Generic;

using System.Text;

namespace Goedel.DNS {
    public abstract partial class DNSRecord {
        public string Unknown() {
            byte [] encoding;
            string result = Unknown (out encoding);

            for (int i = 0; i < encoding.Length; i++) {
                result += Canonicalize.Hex (encoding[i]);
                }

            return result;
            }


        public string Unknown(out byte []encoding) {
            DNSBufferIndex DNSBufferIndex = new DNSBufferIndex ();
            this.Encode (DNSBufferIndex);
            encoding = DNSBufferIndex.Bytes;

            string result = "TYPE" + (int) Code + " \\# " + encoding.Length + " ";


            return result;
            }
        }
    }
