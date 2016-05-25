//   Copyright © 2015 by Comodo Group Inc.
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
//  
//  

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
