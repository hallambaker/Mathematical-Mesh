using System;
using System.Collections.Generic;
using System.Diagnostics;
using Goedel.Utilities;

/// <summary>
/// 
/// </summary>
namespace Goedel.Test {

    /// <summary>
    /// 
    /// </summary>
    public static class TestVector {

        public static byte[] FillConstant (int Length, int Value) {
            var Result = new byte[Length];
            for (var i = 0; i < Length; i++) {
                Result[i] = (byte)Value;
                }
            return Result;


            }

        public static byte[] FillCount(int Length, int Offset = 0) {
            var Result = new byte[Length];
            for (var i = 0; i < Length; i++) {
                Result[i] = (byte) (Offset+i);
                }
            return Result;


            }


        }

    }