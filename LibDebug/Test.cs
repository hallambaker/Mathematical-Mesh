using System;
using System.Collections.Generic;

namespace Goedel.Debug {
    public partial class Trace {

        public static bool AreEqual(byte[] X, byte[] Y) {
            if (X.Length != Y.Length) return false;
            for (var i = 0; i < X.Length; i++) {
                if (X[i] != Y[i]) return false;
                }
            return true;
            }

        public static bool AssertEqual(string Text, byte[] X, byte[] Y) {
            var Test = AreEqual(X, Y);
            return (Assert(Text, Test));
            }

        public static bool AssertNotEqual(string Text, byte[] X, byte[] Y) {
            var Test = !AreEqual(X, Y);
            return (Assert(Text, Test));
            }

        public static bool Assert(string Text, bool True) {
            if (!True) {
                throw new SystemException(Text);
                }
            return True;
            }

        /// <summary>
        /// Creates a clone of the input array with the first byte flipped.
        /// </summary>
        /// <param name="Array">input array</param>
        /// <param name="BadArray">bad array</param>

        public static void Spoil(byte[] Array, byte [] BadArray) {
            BadArray = new byte[Array.Length];
            Array.CopyTo(BadArray, 0);
            BadArray[0] = (byte)(Array[0] ^ 0xff);
            }

        public static void Spoil(ref byte[] Array) {
            Array[0] = (byte)(Array[0] ^ 0xff);
            }

        }
    }
