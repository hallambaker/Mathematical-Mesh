using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;

namespace Goedel.Test {
    /// <summary>
    /// Convenience routines to test various types of assertion and throw
    /// an exception using an exception factory method such as the ones
    /// created by Exceptional.
    /// </summary>
    public static class AssertTest {

        /// <summary>Throw an exception if the specified object is not null. 
        /// </summary>
        /// <param name="test">The condition</param>
        /// <param name="throwDelegate">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="Reason">Reason data for filling throw template</param>
        /// <param name="Int">Integer default parameter</param>
        /// <param name="String">String default parameter</param>
        public static void TestNotNull(this object test, ThrowNewDelegate throwDelegate = null,
                    params object[] args) =>
            Assert.AssertNotNull(test, throwDelegate ?? TestExpectedNotNull.ThrowNew, args);

        /// <summary>Throw an exception if <paramref name="test"/> is not null. 
        /// </summary>
        /// <param name="test">The object to test to see if it is null</param>
        /// <param name="throwDelegate">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="args">Reason arguments to be passed to the throw delegate.</param>
        public static void TestNull(this object test, ThrowNewDelegate throwDelegate = null,
                    params object[] args) =>
            Assert.AssertNull(test, throwDelegate ?? TestExpectedNull.ThrowNew, args);

        /// <summary>Throw an exception if <paramref name="condition"/> is true. 
        /// (test, NYIException.Throw, "test was false").AssertTrue();
        /// </summary>
        /// <param name="condition">The condition</param>
        /// <param name="throwDelegate">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="args">Reason arguments to be passed to the throw delegate.</param>
        public static void TestFalse(this bool condition, ThrowNewDelegate throwDelegate = null,
                    params object[] args) =>
            Assert.AssertFalse(condition, throwDelegate ?? TestExpectedFalse.ThrowNew, args);

        /// <summary>Throw an exception if <paramref name="condition"/> is false. 
        /// (test, NYIException.Throw, "test was false").AssertTrue();
        /// </summary>
        /// <param name="condition">The condition</param>
        /// <param name="throwDelegate">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="args">Reason arguments to be passed to the throw delegate.</param>
        public static void TestTrue(this bool condition, ThrowNewDelegate throwDelegate = null,
                    params object[] args) =>
            Assert.AssertTrue(condition, throwDelegate ?? TestExpectedTrue.ThrowNew, args);

        /// <summary>Test to see if two arrays are equal.
        /// </summary>
        /// <param name="test1">First test value</param>
        /// <param name="test2">Second test value</param>
        /// <param name="throwDelegate">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="args">Reason arguments to be passed to the throw delegate.</param>

        public static void TestEqual(this byte[] test1, byte[] test2, ThrowNewDelegate throwDelegate = null,
                    params object[] args) =>
            Assert.AssertEqual(test1, test2, throwDelegate ?? TestExpectedArraysEqual.ThrowNew, args);

        /// <summary>Test to see if two values are equal.
        /// </summary>
        /// <param name="test1">First test value</param>
        /// <param name="test2">Second test value</param>
        /// <param name="throwDelegate">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="args">Reason arguments to be passed to the throw delegate.</param>

        public static void TestEqual<T>(this T test1, T test2, ThrowNewDelegate throwDelegate = null,
                    params object[] args) =>
            Assert.AssertEqual(test1, test2, throwDelegate ?? TestExpectedEqual.ThrowNew, args);

        }
    }