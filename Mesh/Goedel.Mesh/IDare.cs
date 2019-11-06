using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.IO;

namespace Goedel.Mesh {
    interface IDare : IKeyLocate {


        public DareEnvelope DareEncode(
            byte[] plaintext,
            ContentMeta contentMeta = null,
            byte[] cloaked = null,
            List<byte[]> dataSequences = null,
            List<string> recipients = null,
            bool sign = false);

        /// <summary>
        /// Decode a DARE envelope
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <returns>The plaintext payload data.</returns>
        public byte[] DareDecode(
                    DareEnvelope envelope,
                    bool verify = false);




        }
    }
