using System.Collections.Generic;
using System.Text;
using System;

namespace Goedel.Utilities {

    /// <summary>
    /// 
    /// </summary>
    public static partial class Extension {

        /// <summary>
        /// Convert a list of strings to a comma separated string.
        /// </summary>
        /// <param name="texts">The input strings.</param>
        /// <returns>If Texts is not null, the string values separated by commas, otherwise null.</returns>
        public static string ToCommaSeparated(this List<string> texts) {
            if (texts == null) {
                return null;
                }
            return string.Join(", ", texts);


            }

        readonly static char[] Split = { ' ', ',' };

        /// <summary>
        /// Split a string into a series of substrings delimited by spaces and/or commas
        /// with null entries suppressed.
        /// </summary>
        /// <param name="text">The text to split</param>
        /// <returns>The split strings.</returns>
        public static string[] SplitByComma(this string text) =>
            text.Split(Split, StringSplitOptions.RemoveEmptyEntries);

        /// <summary>
        /// Convert UTF8 encoded bytes to string
        /// </summary>
        /// <param name="data">The encoded bytes to convert.</param>
        /// <returns>The resulting string.</returns>
        public static string ToUTF8(this byte[] data) => Encoding.UTF8.GetString(data, 0, data.Length);


        /// <summary>
        /// Convert UTF8 encoded bytes to string
        /// </summary>
        /// <param name="data">The encoded bytes to convert.</param>
        /// <returns>The resulting string.</returns>
        public static string ToUTF8(this Span<byte>data) => Encoding.UTF8.GetString(data);


        /// <summary>
        /// Convert Text to UTF8 encoded bytes
        /// </summary>
        /// <param name="text">Text to convert</param>
        /// <returns>The encoded bytes</returns>
        public static byte[] ToBytes(this string text) => Encoding.UTF8.GetBytes(text);

        /// <summary>
        /// Convert integer to ASCII character if in the range 1-127, otherwise
        /// return .
        /// </summary>
        /// <param name="c">The character to convert</param>
        /// <returns>ASCII character if 0 &lt; In &lt; 128, otherwise '.'</returns>
        public static char ToASCII(this int c) => (c > 0 & c < 128) ? (char)c : '.';

        /// <summary>Test to see if an input character is a Base64 character.
        /// </summary>
        /// <param name="c">The input character value</param>
        /// <returns>true if and only if the input corresponds to an ASCII 
        /// character used to encode Base64 in traditional or URL encoding
        /// format.</returns>
        public static bool IsBase64(this int c) =>
            ((c >= 'a' & c <= 'z') | (c >= 'A' & c <= 'Z') |
                (c >= '0' & c <= '9') | c == '+' | c == '/' | c == '_' | c == '-');


        /// <summary>
        /// Test to see whether the input string is blank. That is either a 
        /// null pointer or an empty string.
        /// </summary>
        /// <param name="c">The string to test.</param>
        /// <returns>True if either c is null or c is the empty string, otherwise false.</returns>
        public static bool IsBlank(this string c) =>
            c == null | c == "";

        /// <summary>Test to see if an input character is a Base64 character.
        /// </summary>
        /// <param name="c">The input character value</param>
        /// <returns>true if and only if the input corresponds to an ASCII 
        /// character used to encode Base64 in traditional or URL encoding
        /// format.</returns>
        public static bool IsWhite(this int c) => (c == ' ' | c == '\t' | c == '\n' | c == '\r');

        // Encoder, is just used to call static methods.
        static UTF8Encoding UTF8Encoding = new UTF8Encoding();

        /// <summary>
        /// Count the number of bytes that are required to encode
        /// a string in UTF8.
        /// </summary>
        /// <param name="text">Input string</param>
        /// <returns>Number of bytes required to encode the string.</returns>
        public static int CountUTF8(this string text) => UTF8Encoding.GetByteCount(text);

        /// <summary>
        /// Convert a string to a UTF byte array
        /// </summary>
        /// <param name="text">Text to convert</param>
        /// <returns>UTF8 character data as array</returns>
        public static byte[] ToUTF8(this string text) => UTF8Encoding.GetBytes(text);

        /// <summary>
        /// Convert a string to a UTF byte array
        /// </summary>
        /// <param name="text">Text to convert</param>
        /// <param name="buffer">Output buffer to write result to.</param>
        /// <param name="position">Starting position to write data to.</param>
        /// <returns>Number of characters converted</returns>
        public static int ToUTF8(this string text, byte[] buffer, int position) =>
            UTF8Encoding.GetBytes(text, 0, text.Length, buffer, position);


        /// <summary>
        /// Escape text using XML character entity sequences &amp;lt;, &amp;gt; and &amp;amp;
        /// </summary>
        /// <param name="c">String to be escaped</param>
        /// <returns>The escaped string</returns>
        public static string CEscape(this string text) {
            var Result = new StringBuilder();
            foreach (char c in text) {
                switch (c) {
                    case '\n': Result.Append("\n"); break;
                    case '\r': Result.Append("\r"); break;
                    case '\t': Result.Append("\t"); break;
                    case '\\': Result.Append("\\"); break;
                    case '\'': Result.Append("\'"); break;
                    case '\"': Result.Append("\""); break;
                    default: Result.Append(c); break;
                    }
                }
            return Result.ToString();
            }
        /// <summary>
        /// Escape text using XML character entity sequences &amp;lt;, &amp;gt; and &amp;amp;
        /// </summary>
        /// <param name="c">String to be escaped</param>
        /// <returns>The escaped string</returns>
        public static string XMLEscape(this string text) {
            var Result = new StringBuilder();

            foreach (char c in text) {
                switch (c) {
                    case '…': Result.Append("..."); break;
                    case '‘': Result.Append("'"); break;
                    case '’': Result.Append("'"); break;
                    case '“': Result.Append("\""); break;
                    case '”': Result.Append("\""); break;
                    case '®': Result.Append("(R)"); break;
                    case '©': Result.Append("(C)"); break;
                    case '\u2011':
                        Result.Append("-"); break;
                    case '<': Result.Append("&lt;"); break;
                    case '>': Result.Append("&gt;"); break;
                    case '&': Result.Append("&amp;"); break;
                    case (char)160: Result.Append("&nbsp;"); break;
                    default: Result.Append(c); break;
                    }
                }

            return Result.ToString();
            }

        /// <summary>
        /// Escape text using XML character entity sequences &amp;lt;, &amp;gt; and &amp;amp;
        /// </summary>
        /// <param name="c">String to be escaped</param>
        /// <returns>The escaped string</returns>
        public static string XMLEscapeStrict(this string text) {
            var Result = new StringBuilder();

            foreach (char c in text) {
                switch (c) {
                    case '…': Result.Append("..."); break;
                    case '‘': Result.Append("'"); break;
                    case '’': Result.Append("'"); break;
                    case '“': Result.Append("\""); break;
                    case '”': Result.Append("\""); break;
                    case '®': Result.Append("(R)"); break;
                    case '©': Result.Append("(C)"); break;
                    case '\u2011':
                        Result.Append("-"); break;
                    case '<': Result.Append("&lt;"); break;
                    case '>': Result.Append("&gt;"); break;
                    case '&': Result.Append("&amp;"); break;
                    case (char)160: Result.Append(" "); break;
                    default: Result.Append(c); break;
                    }
                }

            return Result.ToString();
            }

        /// <summary>
        /// Escape text using XML character entity sequences &amp;lt;, &amp;gt; and &amp;amp;
        /// </summary>
        /// <param name="c">String to be escaped</param>
        /// <returns>The escaped string</returns>
        public static string XMLEscapeRFCBullies(this string text) {
            var Result = new StringBuilder();

            foreach (char c in text) {
                switch (c) {
                    case '…': Result.Append("..."); break;
                    case '‘': Result.Append("'"); break;
                    case '’': Result.Append("'"); break;
                    case '“': Result.Append("\""); break;
                    case '”': Result.Append("\""); break;
                    case '®': Result.Append("(R)"); break;
                    case '©': Result.Append("(C)"); break;
                    case '\u2011': 
                        Result.Append("-"); break;

                    //case '<': Result.Append("&lt;"); break;
                    //case '>': Result.Append("&gt;"); break;
                    //case '&': Result.Append("&amp;"); break;
                    case (char)160: Result.Append(" "); break;
                    default: Result.Append(c); break;
                    }
                }

            return Result.ToString();
            }

        /// <summary>
        /// Perform strict character constraints according to the undocumented requirements
        /// or the HTML RFC spec.
        /// </summary>
        /// <param name="c">The character to constrain.</param>
        /// <returns>The constrained character.</returns>
        public static char RFCBullies(char c) {
            var cint = (int)c;

            if (cint < 256) {
                return c;
                }

            return '?';
            }

        /// <summary>
        /// Convert the character <paramref name="c"/> to the choresponding escaped
        /// HTML character or entity binding.
        /// </summary>
        /// <param name="c">Character to escape.</param>
        /// <returns>The escaped character.</returns>
        public static string ToHTMLEntity(this char c) {
            switch (c) {
                case '&': {
                    return "&amp;";
                    }
                case '<': {
                    return "&lt;";
                    }
                case '>': {
                    return "&gt;";
                    }
                default: {
                    return c.ToString();
                    }
                }
            }

        /// <summary>
        /// Escape text using XML acharacter entity sequences &amp;lt;, &amp;gt;, &amp;amp;
        /// &amp;quot; and &amp;nbsp;.
        /// </summary>
        /// <param name="c">String to be escaped</param>
        /// <returns>The escaped string</returns>
        public static string XMLAttributeEscape(this string text) {
            var Result = new StringBuilder();

            foreach (char c in text) {
                switch (c) {
                    case '<': Result.Append("&lt;"); break;
                    case '>': Result.Append("&gt;"); break;
                    case '&': Result.Append("&amp;"); break;
                    case '\"': Result.Append("&quot;"); break;
                    case (char)160: Result.Append("&nbsp;"); break;
                    default: Result.Append(c); break;
                    }
                }

            return Result.ToString();
            }

        /// <summary>
        /// Append the string <paramref name="text"/> to the StringBuilder <paramref name="builder"/> 
        /// if and only if <paramref name="value"/> is not null.
        /// </summary>
        /// <param name="builder">The builder to append to.</param>
        /// <param name="value">The text value to append to <paramref name="builder"/>.</param>
        /// <param name="text">The test to be added iff <paramref name="value"/> is not null.</param>
        public static void AppendNotNull(this StringBuilder builder, string value, string text) {
            if (value != null) {
                builder.AppendLine(text);
                }
            }
        }
    }
