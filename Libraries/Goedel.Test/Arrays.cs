using System;
using System.Collections.Generic;
using System.Diagnostics;
using Goedel.Utilities;
using Goedel.Cryptography;

/// <summary>
/// 
/// </summary>
namespace Goedel.Test {


    public static class Extensions {

        public static long SecondsInCE (this DateTime time) => time.Ticks / 10_000_000;
        public static long SecondsInCE (this DateTime? time) => 
                    time == null ? -1 : SecondsInCE((DateTime)time);

        public static bool IsEqualTo (this DateTime first, DateTime second) =>
            first.SecondsInCE() == second.SecondsInCE();

        public static bool IsEqualTo (this DateTime? first, DateTime? second) =>
                    first.SecondsInCE() == second.SecondsInCE();

        public static int[] Shuffle(int length) {
            var result = new int[length];
            var random = new Random();

            for (var i = 0; i < length; i++) {
                result[i] = i;
                }

            for (var i = 0; i < length; i++) {
                var j = random.Next(length - i);
                var x = result[j];
                result[j] = result[i];
                result[i] = x;
                }

            return result;
            }

        public static KeyShare[] Shuffle(this KeyShare[] keyShares, int count) {
            var permutation = Shuffle(keyShares.Length);
            var result = new KeyShare[count];
            for (var i = 0; i < count; i++) {
                result[i] = keyShares[permutation[i]];
                }
            return result;
            }
        }

    /// <summary>
    /// 
    /// </summary>
    public static class TestVector {

        public static byte[] FillConstant (int length, int value) {
            var result = new byte[length];
            for (var i = 0; i < length; i++) {
                result[i] = (byte)value;
                }
            return result;


            }

        public static byte[] FillCount(int length, int offset = 0) {
            var result = new byte[length];
            for (var i = 0; i < length; i++) {
                result[i] = (byte) (offset+i);
                }
            return result;


            }


        }

    }