

namespace Goedel.Utilities;
public static partial class Extension {

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

    }
