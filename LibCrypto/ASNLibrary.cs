//Sample license text.
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
