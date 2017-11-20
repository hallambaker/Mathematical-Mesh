using System;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Utilities {
    /// <summary>
    /// Wrap xml output to fit within a line.
    /// </summary>
    public static class Linewrap {

        /// <summary>
        /// Wrap text to fit a line without breaking words.
        /// </summary>
        /// <param name="Input">The input string.</param>
        /// <param name="Length">Maximum line length</param>
        /// <returns>The wrapped string.</returns>
        public static string Wrap (this string Input, int Length=72) {
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
