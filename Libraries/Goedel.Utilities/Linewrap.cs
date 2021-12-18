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

namespace Goedel.Utilities;


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
    /// <param name="input">The input string.</param>
    /// <param name="input2">Additional input</param>
    /// <param name="length">Maximum line length</param>
    /// <param name="indent">Number of spaces to indent wrapped lines.</param>
    /// <returns>The wrapped string.</returns>
    public static string Wrap(this string input, string input2 = null,
            int length = 68, int indent = 0) {
        var buffer = new StringBuilder();
        var line = new StringBuilder();
        var space = new StringBuilder();
        var current = new StringBuilder();
        var first = true;
        int col() => line.Length + space.Length;
        var max = length - indent;

        if (input2 != null) {
            line.Append(input2);
            }

        foreach (char c in input) {
            // space - just keep it in case needed
            if (c == ' ') {
                if (current.Length > 0) {
                    addCurrent();
                    }

                // Check to see if we need to line wrap
                if (col() >= length) {
                    newline();
                    }

                // Suppress leading spaces at col 0
                if (!first) {
                    space.Append(c);
                    }

                }
            else {
                first = false;
                current.Append(c);
                }
            }

        addCurrent();

        line.Append(current);
        buffer.Append(line);
        line.Clear();
        buffer.Append('\n');



        return buffer.ToString();

        void addSpace() {
            line.Append(space);
            space.Clear();
            }

        void addCurrent() {
            if (current.Length > max) {
                var chunk = length - col();
                var left = current.ToString()[..chunk];
                var right = current.ToString()[chunk..];

                line.Append(left);
                newline();
                while (right.Length > max) {
                    left = right[..max];
                    line.Append(left);
                    newline();
                    right = right[max..];
                    }
                line.Append(right); // the remainder
                current.Clear();
                }
            if (col() + current.Length > length) {
                space.Clear();
                newline();
                }

            else {
                addSpace();
                line.Append(current);
                current.Clear();
                }
            }

        void newline() {
            buffer.Append(line);
            line.Clear();
            buffer.Append('\n');
            line.Append("".PadRight(indent));
            }
        }






    }
