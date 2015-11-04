using System;
using System.Collections.Generic;

namespace Goedel.Debug {


    public partial class Trace {

        /// <summary>
        /// Perform pairwise test for equality on members of an array. Unlike the
        /// builtin functions, ensures debugger stops at useful position.
        /// </summary>
        /// <param name="X">First array to compare</param>
        /// <param name="Y">Second array to compare</param>
        /// <returns>True if arrays are equal, otherwise false.</returns>
        public static bool AreEqual(byte[] X, byte[] Y) {
            if (X.Length != Y.Length) return false;
            for (var i = 0; i < X.Length; i++) {
                if (X[i] != Y[i]) return false;
                }
            return true;
            }

        /// <summary>
        /// Perform pairwise test for equality on members of an array. Unlike the
        /// builtin functions, throws exception if fails.
        /// </summary>
        /// <param name="Text">Report for exception.</param>
        /// <param name="X">First array to compare</param>
        /// <param name="Y">Second array to compare</param>
        /// <returns>True if arrays are equal, otherwise throws exception.</returns>
        public static bool AssertEqual(string Text, byte[] X, byte[] Y) {
            var Test = AreEqual(X, Y);
            return (Assert(Text, Test));
            }

        /// <summary>
        /// Perform pairwise test for inequality on members of an array. Unlike the
        /// builtin functions, throws exception if fails.
        /// </summary>
        /// <param name="Text">Report for exception.</param>
        /// <param name="X">First array to compare</param>
        /// <param name="Y">Second array to compare</param>
        /// <returns>True if arrays are not equal, otherwise throws exception.</returns>
        public static bool AssertNotEqual(string Text, byte[] X, byte[] Y) {
            var Test = !AreEqual(X, Y);
            return (Assert(Text, Test));
            }

        /// <summary>
        /// Yet another assertion method.
        /// </summary>
        /// <param name="Text">Text to report.</param>
        /// <param name="Test">Test value.</param>
        /// <returns>True if test is true, otherwise throws exception.</returns>
        public static bool Assert(string Text, bool Test) {
            if (!Test) {
                throw new SystemException(Text);
                }
            return Test;
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

        /// <summary>
        /// Spoil an element in the specified array.
        /// </summary>
        /// <param name="Array">The array to spoil.</param>
        public static void Spoil(ref byte[] Array) {
            Array[0] = (byte)(Array[0] ^ 0xff);
            }

        }
    }
