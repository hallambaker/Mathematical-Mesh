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


        public static IntPtr ToUnmanaged (this byte[] Input) {

            var OutputArray = Marshal.AllocHGlobal(Input.Length);
            Marshal.Copy(Input, 0, OutputArray, Input.Length);

            return OutputArray;
            }

        public static byte[] ToManagedByte (this IntPtr Input, int Length) {

            var Result = new byte[Length];
            Marshal.Copy(Input, Result, 0, Length);

            return Result;
            }

        }

    }
