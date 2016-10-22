using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Utilities {
    public static partial class Extension {

        public static char ToASCII(this int c) {
            if (c > 0 & c < 128) return (char)c;
            return '.';
            }

        public static bool IsBase64(this int c) {
            return ((c >= 'a' & c <= 'z') | (c >= 'A' & c <= 'Z') |
                (c >= '0' & c <= '9') | c == '+' | c == '/' | c == '_' | c == '-');

            }


        /// <summary>
        /// Count the number of bytes that are required to encode
        /// a string in UTF8.
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static int CountUTF8(this string Text) {
            var Encoding = new UTF8Encoding();
            return Encoding.GetByteCount(Text);
            }

        /// <summary>
        /// Convert a string to a UTF byte array
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static byte [] ToUTF8 (this string Text) {
            var Encoding = new UTF8Encoding();
            return Encoding.GetBytes(Text);
            }

        /// <summary>
        /// Convert a string to a UTF byte array
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static int ToUTF8(this string Text, byte[] Buffer, int Position) {
            var Encoding = new UTF8Encoding();
            return Encoding.GetBytes(Text, 0, Text.Length, Buffer, Position);
            }

        }
    }
