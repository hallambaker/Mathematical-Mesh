using System;


namespace Goedel.Debug {

    /// <summary>
    /// General utility routines to simplify checking of inputs, return values, etc.
    /// </summary>
    public partial class Utilities {


        // Convenience routines 

        /// <summary>
        /// Returns the override value if non-null and the default value otherwise.
        /// </summary>
        /// <param name="Override">The override value.</param>
        /// <param name="Default">The default value</param>
        /// <returns>The override value if non-null and the default value otherwise.</returns>
        public static string Default(string Override, string Default) {
            return Override == null ? Default : Override;
            }

        /// <summary>
        /// Write an error message to the console if the assertion test fails
        /// </summary>
        /// <param name="Value">Test value, error asserted if false</param>
        /// <param name="Reason">Text describing the reason the error was raised.</param>
        public static void Assert(bool Value, string Reason) {
            if (Value) return;
            Error(Reason);
            }
        /// <summary>
        /// Write an error message to the console if the assertion test fails
        /// </summary>
        /// <param name="Value">Test value, error asserted if null</param>
        /// <param name="Reason">Text describing the reason the error was raised.</param>
        public static void Assert(object Value, string Reason) {
            if (Value != null) return;
            Error(Reason);
            }

        /// <summary>
        /// Write an error message to the console if the assertion test fails
        /// </summary>
        /// <param name="Value">Test value, error asserted if false</param>
        /// <param name="Text">Format string describing the error.</param>
        /// <param name="Data">Data values to populate the format string.</param>
        public static void Assert(bool Value, string Text, params object[] Data) {
            if (Value) return;
            Error(Text, Data);
            }

        /// <summary>
        /// Write an error message to the console if the assertion test fails
        /// </summary>
        /// <param name="Value">Test value, error asserted if null</param>
        /// <param name="Text">Format string describing the error.</param>
        /// <param name="Data">Data values to populate the format string.</param>
        public static void Assert(object Value, string Text, params object[] Data) {
            if (Value != null) return;
            Error(Text, Data);
            }

        /// <summary>
        /// Report error text.
        /// </summary>
        /// <param name="Text">Format string describing the error.</param>
        /// <param name="Data">Data values to populate the format string.</param>
        public static void Error(string Text, params object[] Data) {
            var Reason = System.String.Format(Text, Data);
            Error(Reason);
            }

        /// <summary>
        /// Report error text. This can be overriden in calling code by assigning a 
        /// delegate error handler to OverrideError.
        /// </summary>
        /// <param name="Text">Text describing the error.</param>
        public static void Error(string Text) {
            OverrideError(Text);
            }

        /// <summary>
        /// Override the default error handler with a custom error handler.
        /// </summary>
        public static ErrorReport OverrideError = DefaultError;


        /// <summary>
        /// Report error text.
        /// </summary>
        /// <param name="Text">Text describing the error.</param>
        public static void DefaultError(string Text) {

            Console.WriteLine(Text);
            throw new Exception(Text);

            }

        /// <summary>
        /// Report error text.
        /// </summary>
        /// <param name="Text">Text describing the error.</param>
        public delegate void ErrorReport(string Text);


        /// <summary>
        /// Not Yet Implemented Error
        /// </summary>
        /// <param name="Item">Describe what is not yet implemented</param>
        public static void NYI(string Item) {
            Error("Not yet implemented: {0}", Item);
            }

        /// <summary>
        /// Not Yet Implemented Error
        /// </summary>
        public static void NYI() {
            Error("Not yet implemented");
            }
        }



    }
