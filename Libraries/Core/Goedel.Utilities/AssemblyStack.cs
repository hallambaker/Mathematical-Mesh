using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics;

namespace Goedel.Utilities {
    public static class AssemblyStack {

        public static string GetMethodName() {
            var stack = new StackTrace();
            var frame = stack.GetFrame(1);
            var method = frame.GetMethod();

            return method.Name;
            }

        public static string GetCallerMethodName() {
            var stack = new StackTrace();
            var frame = stack.GetFrame(2);
            var method = frame.GetMethod();

            return method.Name;
            }


        }
    }
