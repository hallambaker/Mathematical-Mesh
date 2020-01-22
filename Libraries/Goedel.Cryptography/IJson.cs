using System;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Cryptography {
    public interface IJson {

        /// <summary>
        /// Encode object as a JSON-B byte array
        /// </summary>
        /// <param name="tag">If true, serialization is tagged with 
        /// the object type.</param>
        /// <returns>The encoded data.</returns>
        byte[] ToJson(bool tag = false);

        /// <summary>
        ///If true, a stored key may be exported from the machine on 
        ///which it is stored.
        /// </summary>
        bool Exportable { get; set; }
        }

    }
