#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion
using System.Collections.Generic;

using Goedel.Utilities;

namespace Goedel.Test {
    /// <summary>
    /// Convenience routines to test various types of assertion and throw
    /// an exception using an exception factory method such as the ones
    /// created by Exceptional.
    /// </summary>
    public static class AssertTest {

        public static bool FlagFailure { get; set; } = true;
        public static int TestsFailed { get; set; } = 0;


        /// <summary>Throw an exception if the specified object is not null. 
        /// </summary>
        /// <param name="test">The condition</param>
        /// <param name="throwDelegate">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="Reason">Reason data for filling throw template</param>
        /// <param name="Int">Integer default parameter</param>
        /// <param name="String">String default parameter</param>
        public static void TestNotNull(this object test, ThrowDelegate throwDelegate = null,
                    params object[] args) {
            if (FlagFailure) {
                Assert.AssertNotNull(test, throwDelegate ?? TestExpectedNotNull.Throw, args);
                }
            else {
                TestsFailed++;
                }
            }
        /// <summary>Throw an exception if <paramref name="test"/> is not null. 
        /// </summary>
        /// <param name="test">The object to test to see if it is null</param>
        /// <param name="throwDelegate">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="args">Reason arguments to be passed to the throw delegate.</param>
        public static void TestNull(this object test, ThrowDelegate throwDelegate = null,
                    params object[] args) {
            if (FlagFailure) {
                Assert.AssertNull(test, throwDelegate ?? TestExpectedNull.Throw, args);
                }
            else {
                TestsFailed++;
                }
            }


        /// <summary>Throw an exception if <paramref name="condition"/> is true. 
        /// (test, NYIException.Throw, "test was false").AssertTrue();
        /// </summary>
        /// <param name="condition">The condition</param>
        /// <param name="throwDelegate">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="args">Reason arguments to be passed to the throw delegate.</param>
        public static void TestFalse(this bool condition, ThrowDelegate throwDelegate = null,
                    params object[] args) {
            if (FlagFailure) {
                Assert.AssertFalse(condition, throwDelegate ?? TestExpectedFalse.Throw, args);
                }
            else {
                TestsFailed++;
                }
            }


        /// <summary>Throw an exception if <paramref name="condition"/> is false. 
        /// (test, NYIException.Throw, "test was false").AssertTrue();
        /// </summary>
        /// <param name="condition">The condition</param>
        /// <param name="throwDelegate">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="args">Reason arguments to be passed to the throw delegate.</param>
        public static void TestTrue(this bool condition, ThrowDelegate throwDelegate = null,
                    params object[] args) {
            if (FlagFailure) {
                Assert.AssertTrue(condition, throwDelegate ?? TestExpectedTrue.Throw, args);
                }
            else {
                TestsFailed++;
                }
            }


        /// <summary>Test to see if two arrays are equal.
        /// </summary>
        /// <param name="test1">First test value</param>
        /// <param name="test2">Second test value</param>
        /// <param name="throwDelegate">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="args">Reason arguments to be passed to the throw delegate.</param>

        public static void TestEqual(this byte[] test1, byte[] test2, ThrowDelegate throwDelegate = null,
                    params object[] args) {
            if (FlagFailure) {
                Assert.AssertEqual(test1, test2, throwDelegate ?? TestExpectedArraysEqual.Throw, args);
                }
            else {
                TestsFailed++;
                }
            }


        /// <summary>Test to see if two values are equal.
        /// </summary>
        /// <param name="test1">First test value</param>
        /// <param name="test2">Second test value</param>
        /// <param name="throwDelegate">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="args">Reason arguments to be passed to the throw delegate.</param>

        public static void TestEqual<T>(this T test1, T test2, ThrowDelegate throwDelegate = null,
                    params object[] args) {
            if (FlagFailure) {
                Assert.AssertEqual(test1, test2, throwDelegate ?? TestExpectedEqual.Throw, args);
                }
            else {
                TestsFailed++;
                }
            }

        /// <summary>
        /// Test to see if the dictionaries <paramref name="first"/> and <paramref name="second"/>
        /// contain exactly the same set of keys.
        /// </summary>
        /// <typeparam name="T">The key type.</typeparam>
        /// <typeparam name="U">The value type of the first dictionary (ignored)</typeparam>
        /// <typeparam name="V">The value type of the second dictionary (ignored</typeparam>
        /// <param name="first">The first dictionary</param>
        /// <param name="second">The second dictionary</param>
        /// <param name="throwDelegate">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="args">Reason arguments to be passed to the throw delegate.</param>
        public static void TestEqualKeys<T, U, V>(
                    this Dictionary<T, U> first,
                    Dictionary<T, V> second,
                    ThrowDelegate throwDelegate = null,
                    params object[] args) {
            first.Count.TestEqual(second.Count, throwDelegate, args);
            foreach (var entry in first) {
                second.ContainsKey(entry.Key).TestTrue(throwDelegate, args);
                }
            }

        /// <summary>
        /// Test to see if the dictionaries <paramref name="first"/> and <paramref name="second"/>
        /// contain exactly the same set of keys.
        /// </summary>
        /// <typeparam name="T">The key type.</typeparam>
        /// <typeparam name="U">The value type of the first dictionary (ignored)</typeparam>
        /// <typeparam name="V">The value type of the second dictionary (ignored</typeparam>
        /// <param name="first">The first dictionary</param>
        /// <param name="second">The second dictionary</param>
        /// <param name="throwDelegate">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="args">Reason arguments to be passed to the throw delegate.</param>
        public static void TestEqualKeys<T, U, V>(
                    this Dictionary<T, U> first,
                    SortedDictionary<T, V> second,
                    ThrowDelegate throwDelegate = null,
                    params object[] args) {
            first.Count.TestEqual(second.Count, throwDelegate, args);
            foreach (var entry in first) {
                second.ContainsKey(entry.Key).TestTrue(throwDelegate, args);
                }
            }

        /// <summary>
        /// Test to see if the dictionaries <paramref name="first"/> and <paramref name="second"/>
        /// contain exactly the same set of keys.
        /// </summary>
        /// <typeparam name="T">The key type.</typeparam>
        /// <typeparam name="U">The value type of the first dictionary (ignored)</typeparam>
        /// <typeparam name="V">The value type of the second dictionary (ignored</typeparam>
        /// <param name="first">The first dictionary</param>
        /// <param name="second">The second dictionary</param>
        /// <param name="throwDelegate">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="args">Reason arguments to be passed to the throw delegate.</param>
        public static void TestEqualKeys<T, U, V>(
                    this SortedDictionary<T, U> first,
                    SortedDictionary<T, V> second,
                    ThrowDelegate throwDelegate = null,
                    params object[] args) {
            first.Count.TestEqual(second.Count, throwDelegate, args);
            foreach (var entry in first) {
                second.ContainsKey(entry.Key).TestTrue(throwDelegate, args);
                }
            }
        }
    }

