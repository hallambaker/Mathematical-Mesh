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
using System.Linq;
using System.Text;

namespace Goedel.ASN {

    /// <summary>
    /// Constants for encoding ASN1 data
    /// </summary>
    public class Constants {
        /// <summary>
        /// 
        /// </summary>
        public const byte Boolean           =  1;
        /// <summary>
        /// 
        /// </summary>
        public const byte Integer           =  2;
        /// <summary>
        /// 
        /// </summary>
        public const byte BitString         =  3;
        /// <summary>
        /// 
        /// </summary>
        public const byte OctetString       =  4;
        /// <summary>
        /// 
        /// </summary>
        public const byte Null              =  5;
        /// <summary>
        /// 
        /// </summary>
        public const byte ObjectIdentifier  =  6;
        /// <summary>
        /// 
        /// </summary>
        public const byte ObjectDescriptor  =  7;
        /// <summary>
        /// 
        /// </summary>
        public const byte External          =  8;
        /// <summary>
        /// 
        /// </summary>
        public const byte Real              =  9;
        /// <summary>
        /// 
        /// </summary>
        public const byte Numerated         = 10;
        /// <summary>
        /// 
        /// </summary>
        public const byte Embedded          = 11;
        /// <summary>
        /// 
        /// </summary>
        public const byte UTF8String        = 12;
        /// <summary>
        /// 
        /// </summary>
        public const byte RelativeOid       = 13;
        /// <summary>
        /// 
        /// </summary>
        public const byte Sequence          = 16;
        /// <summary>
        /// 
        /// </summary>
        public const byte Set               = 17;
        /// <summary>
        /// 
        /// </summary>
        public const byte NumericString     = 18;
        /// <summary>
        /// 
        /// </summary>
        public const byte PrintableString   = 19;
        /// <summary>
        /// 
        /// </summary>
        public const byte TeletexString     = 20;
        /// <summary>
        /// 
        /// </summary>
        public const byte VideotexString    = 21;
        /// <summary>
        /// 
        /// </summary>
        public const byte IA5String         = 22;
        /// <summary>
        /// 
        /// </summary>
        public const byte UTCTime           = 23;
        /// <summary>
        /// 
        /// </summary>
        public const byte GeneralizedTime   = 24;
        /// <summary>
        /// 
        /// </summary>
        public const byte GraphicString     = 25;
        /// <summary>
        /// 
        /// </summary>
        public const byte VisibleString     = 26;
        /// <summary>
        /// 
        /// </summary>
        public const byte GeneralString     = 27;
        /// <summary>
        /// 
        /// </summary>
        public const byte UniversalString   = 28;
        /// <summary>
        /// 
        /// </summary>

        public const byte CharacterString   = 29;
        /// <summary>
        /// 
        /// </summary>
        public const byte BMPString         = 30;


        }



    /// <summary>
    /// 
    /// </summary>

    public abstract class Root {
        /// <summary>
        /// 
        /// </summary>
        public virtual int [] OID { get { return null; } }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual byte [] DER () {
            Goedel.ASN.Buffer Buffer = new Buffer ();
            this.Encode (Buffer);

            return Buffer.Data;
            }
        /// <summary>
        /// 
        /// </summary>

        public abstract void Encode (Goedel.ASN.Buffer Buffer) ;

        }

    /// <summary>
    /// Utility class containing static methods.
    /// </summary>
    public class ASN {
        /// <summary>
        /// 
        /// </summary>
        static char[] Dot = new char[] { '.' };

        /// <summary>
        ///
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static int[] OIDToArray(string OID) {
            var Split = OID.Split(Dot);
            var Result = new int [Split.Length];
            for (var i = 0; i < Split.Length; i++) {
                Result [i] = Convert.ToInt32 (Split[i]);
                }
            return Result;
            }
        }

    }
