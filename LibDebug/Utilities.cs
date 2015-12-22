//Sample license text.
using System;
using System.Collections.Generic;
using System.Text;


namespace Goedel.Debug {
    public partial class Trace {

        /// <summary>
        /// Convert string of hex data to byte array. [why isn't this in 
        /// the conversions library?)
        /// </summary>
        /// <param name="input">String to convert.</param>
        /// <returns>Byte array constructed from the specified value.</returns>
        public static byte[] HexToByte(string input) {
            int Valid = 0;
            bool High = true;
            int Buffer = 0;
            int Index = 0;

            foreach (char c in input) {
                if (HexValue(c) >= 0) Valid++;
                }

            var Result = new byte[(Valid + 1) / 2];
            foreach (char c in input) {
                var h = HexValue(c);
                if (h >= 0) {
                    if (High) {
                        Buffer = h;
                        }
                    else {
                        Result[Index++] = (byte)(h + (Buffer * 16));
                        }

                    High = !High;
                    }
                }
            return Result;
            }


        static int HexValue(char c) {
            if (c >= '0' & c <= '9') {
                return c - '0';
                }
            if (c >= 'a' & c <= 'f') {
                return c + 10 - 'a';
                }
            if (c >= 'A' & c <= 'F') {
                return c + 10 - 'A';
                }
            return -1;
            }

        }
    }
