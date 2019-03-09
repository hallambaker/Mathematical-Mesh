using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goedel.Registry {

    /// <summary>
    /// Extension methods to create labels, escaped strings, etc. in a specified
    /// target language.
    /// </summary>
    public static partial class ExtensionMethods {

        private static string _Target = "CS" ;

        /// <summary>
        /// Sets the code generation target type. This ensures that labels,
        /// etc have the correct prefixes and formatting style for the target
        /// language. The default is 'CS' to generate for C#.
        /// </summary>
        public static string Target {
            get => _Target.ToUpper();
            set => _Target = value;
            }

        /// <summary>
        /// Generate a label for the currently specified code generation target.
        /// The default is to generate for C#.
        /// </summary>
        /// <param name="Base">Base string</param>
        /// <returns>Appropriately escaped label for current target language.</returns>
        public static string Label(this object Base) {
            switch (Target) {
                case "CS": {
                    return Base.CS();
                    }
                }
            return Base.CS();
            }


        /// <summary>
        /// Convert an arbitrary string to a label suitable for use in C# code
        /// avoiding collisions with reserved words and labels reserved to 
        /// implementation code.
        /// 
        /// All spaces are converted to underscores. Labels that begin with a 
        /// number or a leading underscore or are a reserved word are prefixed
        /// by an underscore.
        /// </summary>
        /// <param name="Base">Input string</param>
        /// <returns>Character safe label.</returns>
        public static string CS(this object Base) => Base.ToString();

        /// <summary>
        /// Create a quoted, escaped string in the current language
        /// </summary>
        /// <param name="Base">Unescaped string</param>
        /// <returns>Quoted escaped string.</returns>
        public static string QuotedNull(this string Base) => Base == null ? "null" : Quoted(Base);


        /// <summary>
        /// Create a quoted, escaped string in the current language
        /// </summary>
        /// <param name="Base">Unescaped string</param>
        /// <returns>Quoted escaped string.</returns>
        public static string Quoted (this string Base) {
            var StringBuilder = new StringBuilder();
            StringBuilder.Append("\"");
            Escape(StringBuilder, Base);
            StringBuilder.Append("\"");

            return StringBuilder.ToString();
            }

        /// <summary>
        /// Create an escaped string in the current language
        /// </summary>
        /// <param name="Base">Unescaped string</param>
        /// <returns>Escaped string.</returns>
        public static string Quoted(this List<string> Base) {
            if (Base == null) {
                return "\"\"";
                }

            var StringBuilder = new StringBuilder();
            StringBuilder.Append("\"");
            bool Space = false;
            foreach (var Text in Base) {
                if (Space) {
                    StringBuilder.Append(" ");
                    }
                Space = true;
                Escape(StringBuilder, Text);
                }
            StringBuilder.Append("\"");

            return StringBuilder.ToString();
            }

        private static void Escape(StringBuilder Builder, string Text) {
            foreach (var c in Text) {
                if (c == '\"') {
                    Builder.Append("\\\"");
                    }
                else if (c == '\'') {
                    Builder.Append("\\\'");
                    }
                else {
                    Builder.Append(c);
                    }
                }
            }

        /// <summary>
        /// Return the string value if a condition is met, otherwise return an
        /// empty string.
        /// </summary>
        /// <param name="Value">The condition value.</param>
        /// <param name="Text">The string to return if Value is true.</param>
        /// <returns>The string Text if Value is true, otherwise a null string.</returns>
        public static string If(this string Text) => If(Text!=null, Text, "");

        /// <summary>
        /// Return the string value if a condition is met, otherwise return an
        /// empty string.
        /// </summary>
        /// <param name="Value">The condition value.</param>
        /// <param name="Text">The string to return if Value is true.</param>
        /// <returns>The string Text if Value is true, otherwise a null string.</returns>
        public static string If(this bool Value, string Text) => If(Value, Text, "");

        /// <summary>
        /// Return the first string value if a condition is met, otherwise return the second
        /// </summary>
        /// <param name="Value">The condition value.</param>
        /// <param name="TrueText">The string to return if Value is true.</param>
        /// <param name="FalseText">The string to return if Value is false.</param>
        /// <returns>The string Text if Value is true, otherwise a null string.</returns>
        public static string If(this bool Value, string TrueText, string FalseText) => Value ? TrueText : FalseText;

        /// <summary>
        /// To Be Specified stub. Writes out the value to the console an returns the string.
        /// </summary>
        /// <param name="Value">Value to write</param>
        /// <param name="Bold">If true, wrap value in bold style tags</param>
        /// <returns>The resulting formatted string.</returns>
        public static string TBS (this string Value, bool Bold=true) {
            var Message = String.Format("TBS: {0}", Value);
            //Console.WriteLine(Message);
            return Bold ? "<b>" + Message + "</b>" : Message;
            }

        }


    /// <summary>
    /// The separator class prints as one value the first time ToString() is called
    /// and a different value thereafter.
    /// </summary>
    public class Separator {

        /// <summary>
        /// Value to return the first time ToString() is called
        /// </summary>
        public string First;

        /// <summary>
        /// Value to return after the first time ToString() is called
        /// </summary>
        public string Next;

        /// <summary>
        /// Is this the first time ToString was called?
        /// </summary>
        public bool IsFirst = true;

        /// <summary>
        /// Create a separator class.
        /// </summary>
        /// <param name="First">String to return on the first call to ToString()</param>
        /// <param name="Next">String to return after the first call to ToString()</param>
        public Separator(string First, string Next) {
            this.First = First;
            this.Next = Next;
            }

        /// <summary>
        /// Create a separactor class that returns an empty string the first
        /// time ToString is called.
        /// </summary>
        /// <param name="Next">String to return after the first call to ToString()</param>

        public Separator(string Next) : this ("", Next){
            }

        /// <summary>
        /// Return the value First if this is the first time the
        /// method is called or Next otherwise.
        /// </summary>
        /// <returns>The string value</returns>
        public override string ToString() {
            if (IsFirst) {
                IsFirst = false;
                return First;
                }
            return Next;
            }

        }
    }
