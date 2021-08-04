﻿#region // Copyright
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
using System;
using System.Collections.Generic;
using System.Globalization;



namespace Goedel.Utilities {

    /// <summary>
    /// Base class for all exceptions generated by Exceptional
    /// </summary>
    public abstract class GoedelException : Exception {
        /// <summary>
        /// Construct instance for exception "An internal error occurred"
        /// </summary>		
        public GoedelException() : base("An unknown error occurred") {
            }

        /// <summary>
        /// Construct instance for exception "An internal error occurred"
        /// </summary>		
        /// <param name="description">Description of the error</param>	
        public GoedelException(string description) : base(description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="description">Description of the error</param>	
        /// <param name="inner">Inner Exception</param>	
        public GoedelException(string description = null, Exception inner = null) :
                base(description, inner) {
            }

        ///<summary>The message template in the current locale.</summary>
        public static string MessageTemplate { get; }

        /// <summary>
        /// User data associated with the exception.
        /// </summary>	
        public object UserData;

        /// <summary>
        /// User data associated with the exception.
        /// </summary>	
        public object[] UserDataNew;

        /// <summary>
        /// Formatted error return.
        /// </summary>
        /// <param name="reasons">Exception parameter data.</param>
        /// <returns>The formated exception description.</returns>
        public virtual string Format(params object[] reasons) => "Formatted reasons...";

        ///<summary>Templates used to format the exception message.</summary>
        public static System.Collections.Generic.List<string> Templates = null;

        ///<summary>The exception formatting delegate</summary>
        public static ExceptionFormatDelegate ExceptionFormatDelegate = FormatException;

        ///<summary>Default error message return</summary>
        public static string NoMessageSpecified { get; set; } = "Unspecified error";

        /// <summary>
        /// Default exception message format provider.
        /// </summary>
        /// <param name="description">Description of the exception (overrides templates and culture).</param>
        /// <param name="templates">Exception message templates.</param>
        /// <param name="culture">The culture in which the message is to be formatted.</param>
        /// <param name="args">Arguments to be used to construct the message.</param>
        /// <returns>The formatted message string</returns>
        public static string FormatException(
                string description,
                List<string> templates,
                CultureInfo culture,
                params object[] args) {

            culture.Future();


            if (description != null) {
                return description;
                }

            if (templates != null) {
                foreach (var template in templates) {
                    return string.Format(template, args);
                    }
                }

            return NoMessageSpecified;
            }
        }


    /// <summary>
    /// Delegate that will be thrown as an exception if a condition is met
    /// </summary>
    /// <param name="reasons">The reason for raising the exception.</param>
    /// <returns>The exception to throw</returns>
    public delegate System.Exception ThrowDelegate(object[] reasons = null);

    ///// <summary>
    ///// Delegate that will be thrown as an exception if a condition is met
    ///// </summary>
    ///// <param name="reasons">The reasons for raising the exception.</param>
    ///// <returns>The exception to throw</returns>
    //public delegate System.Exception ThrowNewDelegate(object[] reasons = null);


    /// <summary>
    /// Convenience class for constructing an object on the fly to report exception
    /// parameters of type integer or string.
    /// </summary>
    public class ExceptionData {
        /// <summary>An integer value;</summary>
        public int Int { get; set; }

        /// <summary>A string value</summary>
        public string String { get; set; }

        /// <summary>
        /// Factory method to create and return object with specified integer
        /// and/or string values.
        /// </summary>
        /// <param name="Int">The integer value</param>
        /// <param name="String">The string value</param>
        /// <returns>The boxed exception data.</returns>
        public static ExceptionData Box(int Int = 0, string String = "") => new ExceptionData() {
            Int = Int,
            String = String
            };
        }

    /// <summary>
    /// Delegate returning an exception message format provider.
    /// </summary>
    /// <param name="description">Description of the exception (overrides templates and culture).</param>
    /// <param name="templates">Exception message templates.</param>
    /// <param name="culture">The culture in which the message is to be formatted.</param>
    /// <param name="args">Arguments to be used to construct the message.</param>
    /// <returns>The formatted message string</returns>
    public delegate string ExceptionFormatDelegate(
                string description,
                List<string> templates,
                CultureInfo culture,
                params object[] args);


    /// <summary>
    /// Convenience routines to test various types of assertion and throw
    /// an exception using an exception factory method such as the ones
    /// created by Exceptional.
    /// </summary>
    public static class Assert {







        /// <summary>
        /// Syntactic sugar to allow compact tests on the return value of a function.
        /// Returns true is <paramref name="test"/> is not null, otherwise false.
        /// The value <paramref name="result"/> is set equal to the value of 
        /// <paramref name="test"/> in either case.
        /// </summary>
        /// <example>
        /// This sample shows how to call the <see cref="NotNull"/> method.
        /// <code>
        /// if (base.Get(key).NotNull (out var result)) {
        ///     return result;
        ///     }
        /// </code>
        /// </example>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="test">The test value.</param>
        /// <param name="result">Returns the value <paramref name="test"/>.</param>
        /// <returns>True if the value <paramref name="test"/> is not null,
        /// otherwise false.</returns>
        public static bool NotNull<T>(this T test, out T result) where T : class {
            result = test;
            return test != null;
            }

        /// <summary>
        /// Provides a means of optionally expiring a value specified by <paramref name="value"/>.
        /// If <paramref name="expiry"/> is not null and specifies a time value that is strictly 
        /// less than the value of <see cref="DateTime.Now"/>, the value null is returned. Otherwise
        /// the value <paramref name="value"/> is returned.
        /// </summary>
        /// <typeparam name="T">The type to return and of <paramref name="value"/>.</typeparam>
        /// <param name="expiry">The expiry time.</param>
        /// <param name="value">The value to return if not expired.</param>
        /// <returns>
        /// The value <paramref name="value"/> unless the parameter <paramref name="expiry"/>
        /// is not null and is strictly less than the current time in which case the value 
        /// <code>null</code> is returned. 
        ///</returns>
        public static T Expired<T>(this DateTime? expiry, T value) {
            if (expiry == null) {
                return value;
                }
            if (DateTime.Now < expiry) {
                return value;
                }
            return default;
            }


        /// <summary>
        /// Cache and return a value. This is used to produce compact expression
        /// body methods for properties that are only evaluated the first time
        /// they are called.
        /// </summary>
        /// <typeparam name="T">The type of data to be cached.</typeparam>
        /// <param name="Value">The value to be stored.</param>
        /// <param name="Store">The store that the value is to be written to.</param>
        /// <returns>The stored value.</returns>
        public static T CacheValue<T>(this T Value, out T Store) where T : class {
            Store = Value;
            return Value;
            }


        /// <summary>Throw an exception if <paramref name="condition"/> is true. 
        /// (test, NYIException.Throw, "test was false").AssertTrue();
        /// </summary>
        /// <param name="condition">The condition</param>
        /// <param name="throwDelegate">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="args">Reason arguments to be passed to the throw delegate.</param>
        public static void AssertFalse(this bool condition, ThrowDelegate throwDelegate,
                    params object[] args) {
            if (condition) {
                throw throwDelegate(args);
                }
            }

        /// <summary>Throw an exception if <paramref name="condition"/> is false. 
        /// (test, NYIException.Throw, "test was false").AssertTrue();
        /// </summary>
        /// <param name="condition">The condition</param>
        /// <param name="throwDelegate">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="args">Reason arguments to be passed to the throw delegate.</param>
        public static void AssertTrue(this bool condition, ThrowDelegate throwDelegate,
                    params object[] args) {
            if (!condition) {
                throw throwDelegate(args);
                }
            }

        /// <summary>Throw an exception if <paramref name="test"/> is not null. 
        /// </summary>
        /// <param name="test">The object to test to see if it is null</param>
        /// <param name="throwDelegate">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="args">Reason arguments to be passed to the throw delegate.</param>
        public static void AssertNull(this object test, ThrowDelegate throwDelegate,
                    params object[] args) {
            if (test != null) {
                throw throwDelegate(args);
                }
            }

        /// <summary>Throw an exception if <paramref name="test"/> is null. 
        /// </summary>
        /// <param name="test">The object to test to see if it is null</param>
        /// <param name="throwDelegate">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="args">Reason arguments to be passed to the throw delegate.</param>
        public static void AssertNotNull(this object test, ThrowDelegate throwDelegate,
                    params object[] args) {
            if (test == null) {
                throw throwDelegate(args);
                }
            }

        /// <summary>Test to see if two arrays are equal.
        /// </summary>
        /// <param name="test1">First test value</param>
        /// <param name="test2">Second test value</param>
        /// <param name="throwDelegate">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="args">Reason arguments to be passed to the throw delegate.</param>

        public static void AssertEqual(this byte[] test1, byte[] test2, ThrowDelegate throwDelegate,
                    params object[] args) {
            if (!ArrayUtilities.IsEqualTo(test1, test2)) {
                throw throwDelegate(args);
                }
            }


        /// <summary>Test to see if two values are equal.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="test1">First test value</param>
        /// <param name="test2">Second test value</param>
        /// <param name="throwDelegate">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="args">Reason arguments to be passed to the throw delegate.</param>

        public static void AssertEqual<T>(this T test1, T test2, ThrowDelegate throwDelegate,
                    params object[] args) {
            if (!test1.Equals(test2)) {
                throw throwDelegate(args);
                }
            }



        /// <summary>If debugging Throw an exception if <paramref name="condition"/> is false. 
        /// (test, NYIException.Throw, "test was false").AssertTrue();
        /// </summary>
        /// <param name="condition">The condition</param>
        /// <param name="throwDelegate">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="args">Reason arguments to be passed to the throw delegate.</param>
        public static void VerifyTrue(this bool condition, ThrowDelegate throwDelegate,
                    params object[] args) {
            if (!condition) {
                throw throwDelegate(args);
                }
            }




        /// <summary>
        /// Utility routine used to flag missing code to implement missing
        /// cryptographic authentication check
        /// </summary>
        /// <param name="description">Task description</param>
        public static void TaskValidate(this string description) => description.Keep();


        /// <summary>
        /// Utility routine used to flag possibly redundant code.
        /// </summary>
        /// <param name="description">Task description</param>
        public static void TaskRedundant(this string description) => description.Keep();


        /// <summary>
        /// Utility routine used to flag missing code to implement missing test for
        /// functionality not yet implemented.
        /// </summary>
        /// <param name="description">Task description</param>
        public static void TaskTest(this string description) => description.Keep();

        /// <summary>
        /// Utility routine used to flag missing code to implement missing test for
        /// functionality not yet implemented.
        /// </summary>
        /// <param name="description">Description of the missing functionality.</param>
        /// <param name="exception">If true, throw an exception.</param>
        public static void TaskFunctionality(this string description, bool exception = false) {
            Screen.WriteLine($"***Functionality missing***{description}");
            if (exception) {
                throw new NYI();
                }
            }

        /// <summary>
        /// Utility routine used to flag missing code to implement missing test for
        /// functionality not yet implemented.
        /// </summary>
        /// <param name="description">Description of the missing test.</param>
        /// <param name="result">The result value to be returned.</param>
        /// <returns>The value <paramref name="result"/>.</returns>
        public static string Task(this string result, string description) {
            Screen.WriteLine($"***Task***{description}");
            return result;
            }

        }

    }

