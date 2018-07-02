using System;
using System.Collections.Generic;
using System.Diagnostics;
using Goedel.Utilities;

/// <summary>
/// 
/// </summary>
namespace Goedel.Test {


    public static class Extensions {

        public static long SecondsInCE (this DateTime Time) => Time.Ticks / 10_000_000;
        public static long SecondsInCE (this DateTime? Time) => 
                    Time == null ? -1 : SecondsInCE((DateTime)Time);

        public static bool IsEqualTo (this DateTime First, DateTime Second) =>
            First.SecondsInCE() == Second.SecondsInCE();

        public static bool IsEqualTo (this DateTime? First, DateTime? Second) =>
                    First.SecondsInCE() == Second.SecondsInCE();

        //public static bool IsEqualTo(byte[] Data1, byte[] Data2) {



        //    }


        }

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