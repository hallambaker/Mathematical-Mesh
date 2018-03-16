using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RGiesecke.DllExport;
using System.Runtime.InteropServices;
using Goedel.Utilities;

namespace MeshMananaged {
    public class Interface {

        static bool DecryptTurn = false;
        const string Refused = "<h1>Access Denied</h1>";

        /// <summary>
        /// Decrypt an encrypted container.
        /// </summary>
        /// <param name="InputArray">The container data.</param>
        /// <param name="InputLength">The container data length.</param>
        /// <param name="OutputArray">The decrypted content data. The caller must free this data using
        /// a call to the unmanaged free data routine.</param>
        /// <param name="OutputLength">The decrypted content length.</param>
        [DllExport(ExportName = "Decrypt", CallingConvention = CallingConvention.StdCall)]
        static void Decrypt (
                IntPtr InputArray,
                int InputLength,
                out IntPtr OutputArray,
                out int OutputLength) {

            byte[] Input;

            if (DecryptTurn) {
                Input = InputArray.ToManagedByte(InputLength);
                }
            else {
                Input = Refused.ToBytes();
                }

            OutputArray = Input.ToUnmanaged();
            OutputLength = Input.Length;

            DecryptTurn = !DecryptTurn;
            }



        }
    }
