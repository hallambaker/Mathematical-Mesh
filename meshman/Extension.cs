using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Mesh.MeshMan {
    public static class Extensions {
        /// <summary>
        /// Extension method to report the success or failure of transaction.
        /// Success return codes are integers in the range 200..299
        /// </summary>
        /// <param name="Status">Status code returned by transaction.</param>
        /// <returns>true if and only iff the transaction succeeded.</returns>
        public static bool Success(this int Status) {
            return (Status >= 200) & (Status < 300);
            }

        }

    }
