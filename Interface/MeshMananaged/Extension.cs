using System;
using System.Collections.Generic;
using Goedel.Utilities;
using RGiesecke.DllExport;
using System.Runtime.InteropServices;

namespace MeshMananaged {

    /// <summary>
    /// 
    /// </summary>
    public static class Extension {

        /// <summary>
        /// Create unmanaged copy of managed byte array.
        /// </summary>
        /// <param name="Input">The input array.</param>
        /// <returns>Pointer to the unmanaged copy.</returns>
        public static IntPtr ToUnmanaged (this byte[] Input) {
            if (Input == null) {
                return IntPtr.Zero;
                }

            var OutputArray = Marshal.AllocHGlobal(Input.Length);
            Marshal.Copy(Input, 0, OutputArray, Input.Length);

            return OutputArray;
            }


        static readonly byte[] Zero = new byte[] { 0 };

        /// <summary>
        /// Create unmanaged copy of managed string as null terminated string
        /// </summary>
        /// <param name="Input">The input array.</param>
        /// <returns>Pointer to the unmanaged copy.</returns>
        public static IntPtr ToUnmanaged (this string Input) {
            if (Input == null) {
                return IntPtr.Zero;
                }

            var InputBytes = Input.ToBytes();
            var OutputArray = Marshal.AllocHGlobal(InputBytes.Length+1);

            Marshal.Copy(InputBytes, 0, OutputArray, Input.Length);
            Marshal.Copy(Zero, 0, IntPtr.Add(OutputArray, InputBytes.Length), 1);

            return OutputArray;
            }

        /// <summary>
        /// Create managed copy of unmanaged byte array.
        /// </summary>
        /// <param name="Input">The input data.</param>
        /// <param name="Length">The number of bytes to copy.</param>
        /// <returns>The managed byte array.</returns>
        public static byte[] ToManagedByte (this IntPtr Input, int Length) {

            var Result = new byte[Length];
            Marshal.Copy(Input, Result, 0, Length);

            return Result;
            }


        }

    }
