using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics;

namespace Goedel.Utilities {

    /// <summary>
    /// Utility functions using reflection to extract information from the stack.
    /// </summary>
    public static class AssemblyStack {

        /// <summary>
        /// Return the name of the calling method.
        /// </summary>
        /// <returns>The name of the calling method.</returns>
        public static string GetMethodName() {
            var stack = new StackTrace();
            var frame = stack.GetFrame(1);
            var method = frame.GetMethod();

            return method.Name;
            }

        /// <summary>
        /// Return the name of the caller of the calling method.
        /// </summary>
        /// <returns>The name of the caller of the calling method.</returns>
        public static string GetCallerMethodName() {
            var stack = new StackTrace();
            var frame = stack.GetFrame(2);
            var method = frame.GetMethod();

            return method.Name;
            }


        }
    }
