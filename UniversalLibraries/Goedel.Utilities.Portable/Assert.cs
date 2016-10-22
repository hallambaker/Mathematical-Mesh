using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Utilities {


    /// <summary>
    /// Delegate that will be thrown if a condition is met
    /// </summary>
    /// <param name="Reason"></param>
    /// <returns></returns>
    public delegate System.Exception ThrowDelegate(string Reason);

    /// <summary>
    /// Extension methods on 
    /// </summary>
    public static class Assert {


        /// <summary>
        ///Throw an exception if the specified condition is true. 
        ///Assert.False (test, NYIException.Throw, "test was true")
        /// </summary>
        /// <param name="Condition">The condition</param>
        /// <param name="Throw">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="Reason">Reason, for debugging</param>
        public static void False(bool Condition, ThrowDelegate Throw, object Reason) {
            if (Condition) {
                if (Reason as string != null) {
                    throw Throw(Reason as string);
                    }
                else {
                    throw Throw("");
                    }
                }
            }


        /// <summary>
        ///Throw an exception if the specified condition is true. 
        ///Assert.False (test, NYIException.Throw, "test was true")
        /// </summary>
        /// <param name="Condition">The condition</param>
        /// <param name="Throw">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        public static void False(bool Condition, ThrowDelegate Throw) {
            False(Condition, Throw, null);
            }

        /// <summary>
        ///Throw an exception if the specified condition is false. 
        ///Assert.True (test, NYIException.Throw, "test was false")
        /// </summary>
        /// <param name="Condition">The condition</param>
        /// <param name="Throw">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="Reason">Reason, for debugging</param>
        public static void True(bool Condition, ThrowDelegate Throw, string Reason) {
            False(!Condition, Throw, Reason);
            }

        /// <summary>
        ///Throw an exception if the specified condition is false. 
        ///Assert.True (test, NYIException.Throw, "test was false")
        /// </summary>
        /// <param name="Condition">The condition</param>
        /// <param name="Throw">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        public static void True(bool Condition, ThrowDelegate Throw) {
            True(Condition, Throw, null);
            }


        /// <summary>
        ///Throw an exception if the specified object is null. 
        ///Throw.False (Object, NYIException.Throw, "Object was null")
        /// </summary>
        /// <param name="Object">The condition</param>
        /// <param name="Throw">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="Reason">Reason, for debugging</param>
        public static void Null(object Object, ThrowDelegate Throw, string Reason) {
            True(Object == null, Throw, Reason);
            }

        /// <summary>
        ///Throw an exception if the specified object is null. 
        ///Throw.False (Object, NYIException.Throw)
        /// </summary>
        /// <param name="Object">The condition</param>
        /// <param name="Throw">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        public static void Null(object Object, ThrowDelegate Throw) {
            Null(Object, Throw, null);
            }


        /// <summary>
        ///Throw an exception if the specified object is not null. 
        ///Throw.False (Object, NYIException.Throw, "Object was not null")
        /// </summary>
        /// <param name="Object">The condition</param>
        /// <param name="Throw">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="Reason">Reason, for debugging</param>
        public static void NotNull(object Object, ThrowDelegate Throw, string Reason) {
            True(Object != null, Throw, Reason);
            }

        /// <summary>
        ///Throw an exception if the specified object is not null. 
        ///Throw.False (Object, NYIException.Throw)
        /// </summary>
        /// <param name="Object">The condition</param>
        /// <param name="Throw">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        public static void NotNull(object Object, ThrowDelegate Throw) {
            NotNull(Object, Throw, null);
            }


        }




    /// <summary>
    /// Exception for 'Not yet implemented' exception.
    /// </summary>
    public class NYI : System.Exception {
        /// <summary>
        /// The public fatory delegate
        /// </summary>
        public static ThrowDelegate Throw;

        static System.Exception _Throw(string Reason) {
            return new NYI();
            }
        }



    }

