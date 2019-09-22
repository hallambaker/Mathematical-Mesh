using System;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Utilities {


    //public delegate void ToBuilderDelegate(StringBuilder builder, int indent = 0);


    /// <summary>
    /// Wrap xml output to fit within a line.
    /// </summary>
    public static class Linewrap {


        /// <summary>
        /// Append <paramref name="text"/> to the string builder <paramref name="builder"/> prefixed
        /// by <paramref name="indent"/> indents of two spaces each.
        /// </summary>
        /// <param name="builder">The string builder to append to.</param>
        /// <param name="text">The text to write.</param>
        /// <param name="indent">The number of two space indents to prepend.</param>
        public static void AppendIndent(this StringBuilder builder, int indent, string text) {
            for (var i = 0; i < indent; i++) {
                builder.Append("  ");
                }
            builder.AppendLine(text);

            }


        /// <summary>
        /// Wrap text to fit a line without breaking words.
        /// </summary>
        /// <param name="Input">The input string.</param>
        /// <param name="Length">Maximum line length</param>
        /// <returns>The wrapped string.</returns>
        public static string Wrap (this string Input, int Length=68) {
            var Buffer = new StringBuilder();
            var Line = new StringBuilder();
            var Space = new StringBuilder();
            var Current = new StringBuilder();

            foreach (char c in Input) {
                if (c == ' ') {
                    if (Line.Length + Current.Length < Length) {
                        Line.Append(Current);
                        Current.Clear();
                        Space.Append(c);
                        }
                    else {
                        Line.Append("\n");
                        Buffer.Append(Line);
                        Line.Clear();

                        Line.Append(Current);
                        Current.Clear();
                        Space.Append(c);
                        }
                    }
                else if (Current.Length > Length) {
                    Buffer.Append(Current);
                    Buffer.Append("\n");
                    Current.Clear();
                    }
                else {
                    Line.Append(Space);
                    Space.Clear();
                    Current.Append(c);
                    }

                }

            if (Line.Length + Current.Length >= Length) {
                Line.Append("\n");                
                }

            Line.Append(Current);
            Buffer.Append(Line);
            return Buffer.ToString();
            }

        }
    }
