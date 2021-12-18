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

namespace Goedel.Registry;

/// <summary>
/// Extension methods to create labels, escaped strings, etc. in a specified
/// target language.
/// </summary>
public static partial class ExtensionMethods {

    private static string _Target = "CS";

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
    /// <param name="text">Base string</param>
    /// <returns>Appropriately escaped label for current target language.</returns>
    public static string Label(this object text) {
        switch (Target) {
            case "CS": {
                    return text.CS();
                    }

            default:
                break;
            }
        return text.CS();
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
    /// <param name="text">Input string</param>
    /// <returns>Character safe label.</returns>
    public static string CS(this object text) => text.ToString();

    /// <summary>
    /// Create a quoted, escaped string in the current language
    /// </summary>
    /// <param name="text">Unescaped string</param>
    /// <returns>Quoted escaped string.</returns>
    public static string QuotedNull(this string text) => text == null ? "null" : Quoted(text);


    /// <summary>
    /// Create a quoted, escaped string in the current language
    /// </summary>
    /// <param name="text">Unescaped string</param>
    /// <returns>Quoted escaped string.</returns>
    public static string Quoted(this string text) {
        var StringBuilder = new StringBuilder();
        StringBuilder.Append('\"');
        Escape(StringBuilder, text);
        StringBuilder.Append('\"');

        return StringBuilder.ToString();
        }

    /// <summary>
    /// Create an escaped string in the current language
    /// </summary>
    /// <param name="base">Unescaped string</param>
    /// <returns>Escaped string.</returns>
    public static string Quoted(this List<string> @base) {
        if (@base == null) {
            return "\"\"";
            }

        var StringBuilder = new StringBuilder();
        StringBuilder.Append('\"');
        bool Space = false;
        foreach (var Text in @base) {
            if (Space) {
                StringBuilder.Append(' ');
                }
            Space = true;
            Escape(StringBuilder, Text);
            }
        StringBuilder.Append('\"');

        return StringBuilder.ToString();
        }

    private static void Escape(StringBuilder builder, string text) {
        foreach (var c in text) {
            if (c == '\"') {
                builder.Append("\\\"");
                }
            else if (c == '\'') {
                builder.Append("\\\'");
                }
            else {
                builder.Append(c);
                }
            }
        }

    /// <summary>
    /// Return the string value if a condition is met, otherwise return an
    /// empty string.
    /// </summary>
    /// <param name="text">The string to return if Value is true.</param>
    /// <returns>The string Text if Value is true, otherwise a null string.</returns>
    public static string If(this string text) => If(text != null, text, "");

    /// <summary>
    /// Return the string value if a condition is met, otherwise return an
    /// empty string.
    /// </summary>
    /// <param name="value">The condition value.</param>
    /// <param name="text">The string to return if Value is true.</param>
    /// <returns>The string Text if Value is true, otherwise a null string.</returns>
    public static string If(this bool value, string text) => If(value, text, "");

    /// <summary>
    /// Return the first string value if a condition is met, otherwise return the second
    /// </summary>
    /// <param name="value">The condition value.</param>
    /// <param name="trueText">The string to return if Value is true.</param>
    /// <param name="falseText">The string to return if Value is false.</param>
    /// <returns>The string Text if Value is true, otherwise a null string.</returns>
    public static string If(this bool value, string trueText, string falseText) => value ? trueText : falseText;

    /// <summary>
    /// To Be Specified stub. Writes out the value to the console an returns the string.
    /// </summary>
    /// <param name="value">Value to write</param>
    /// <param name="bold">If true, wrap value in bold style tags</param>
    /// <returns>The resulting formatted string.</returns>
    public static string TBS(this string value, bool bold = true) {
        var Message = String.Format("TBS: {0}", value);
        //Console.WriteLine(Message);
        return bold ? "<b>" + Message + "</b>" : Message;
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
    /// <param name="first">String to return on the first call to ToString()</param>
    /// <param name="next">String to return after the first call to ToString()</param>
    public Separator(string first, string next) {
        this.First = first;
        this.Next = next;
        }

    /// <summary>
    /// Create a separactor class that returns an empty string the first
    /// time ToString is called.
    /// </summary>
    /// <param name="next">String to return after the first call to ToString()</param>

    public Separator(string next) : this("", next) {
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
