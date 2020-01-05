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
        /// <param name="Texts">The input strings.</param>
        /// <returns>If Texts is not null, the string values separated by commas, otherwise null.</returns>
        public static string ToCommaSeparated(this List<string> Texts) {
            if (Texts == null) {
                return null;
                }
            return string.Join(", ", Texts);


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
        /// <param name="Data">The encoded bytes to convert.</param>
        /// <returns>The resulting string.</returns>
        public static string ToUTF8(this byte[] Data) => Encoding.UTF8.GetString(Data, 0, Data.Length);

        /// <summary>
        /// Convert Text to UTF8 encoded bytes
        /// </summary>
        /// <param name="Text">Text to convert</param>
        /// <returns>The encoded bytes</returns>
        public static byte[] ToBytes(this string Text) => Encoding.UTF8.GetBytes(Text);

        /// <summary>
        /// Convert integer to ASCII character if in the range 1-127, otherwise
        /// return .
        /// </summary>
        /// <param name="In">The character to convert</param>
        /// <returns>ASCII character if 0 &lt; In &lt; 128, otherwise '.'</returns>
        public static char ToASCII(this int In) => (In > 0 & In < 128) ? (char)In : '.';

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
        /// <param name="Text">Input string</param>
        /// <returns>Number of bytes required to encode the string.</returns>
        public static int CountUTF8(this string Text) => UTF8Encoding.GetByteCount(Text);

        /// <summary>
        /// Convert a string to a UTF byte array
        /// </summary>
        /// <param name="Text">Text to convert</param>
        /// <returns>UTF8 character data as array</returns>
        public static byte[] ToUTF8(this string Text) => UTF8Encoding.GetBytes(Text);

        /// <summary>
        /// Convert a string to a UTF byte array
        /// </summary>
        /// <param name="Text">Text to convert</param>
        /// <param name="Buffer">Output buffer to write result to.</param>
        /// <param name="Position">Starting position to write data to.</param>
        /// <returns>Number of characters converted</returns>
        public static int ToUTF8(this string Text, byte[] Buffer, int Position) =>
            UTF8Encoding.GetBytes(Text, 0, Text.Length, Buffer, Position);


        /// <summary>
        /// Escape text using XML character entity sequences &amp;lt;, &amp;gt; and &amp;amp;
        /// </summary>
        /// <param name="In">String to be escaped</param>
        /// <returns>The escaped string</returns>
        public static string XMLEscape(this string In) {
            var Result = new StringBuilder();

            foreach (char c in In) {
                switch (c) {
                    case '…': Result.Append("..."); break;
                    case '‘': Result.Append("'"); break;
                    case '’': Result.Append("'"); break;
                    case '“': Result.Append("\""); break;
                    case '”': Result.Append("\""); break;
                    case '®': Result.Append("(R)"); break;
                    case '©': Result.Append("(C)"); break;

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
        /// <param name="In">String to be escaped</param>
        /// <returns>The escaped string</returns>
        public static string XMLEscapeStrict(this string In) {
            var Result = new StringBuilder();

            foreach (char c in In) {
                switch (c) {
                    case '…': Result.Append("..."); break;
                    case '‘': Result.Append("'"); break;
                    case '’': Result.Append("'"); break;
                    case '“': Result.Append("\""); break;
                    case '”': Result.Append("\""); break;
                    case '®': Result.Append("(R)"); break;
                    case '©': Result.Append("(C)"); break;

                    case '<': Result.Append("&lt;"); break;
                    case '>': Result.Append("&gt;"); break;
                    case '&': Result.Append("&amp;"); break;
                    case (char)160: Result.Append(" "); break;
                    default: Result.Append(c); break;
                    }
                }

            return Result.ToString();
            }


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
        /// <param name="In">String to be escaped</param>
        /// <returns>The escaped string</returns>
        public static string XMLAttributeEscape(this string In) {
            var Result = new StringBuilder();

            foreach (char c in In) {
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
