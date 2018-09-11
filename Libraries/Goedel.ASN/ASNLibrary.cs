using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Goedel.ASN {

    /// <summary>
    /// Constants used for encoding and decoding ASN.1 data
    /// </summary>
    public class Constants {

        /// <summary>Boolean</summary>
        public const byte Boolean           =  1;
        /// <summary>Integer</summary>
        public const byte Integer           =  2;
        /// <summary>Bit string</summary>
        public const byte BitString         =  3;
        /// <summary>Array of bytes</summary>
        public const byte OctetString       =  4;
        /// <summary>Null object</summary>
        public const byte Null              =  5;
        /// <summary>Object Identifier OID</summary>
        public const byte ObjectIdentifier  =  6;
        /// <summary>Object descriptor</summary>
        public const byte ObjectDescriptor  =  7;
        /// <summary>External type</summary>
        public const byte External          =  8;
        /// <summary>Floating point value</summary>
        public const byte Real              =  9;
        /// <summary>Numerated value</summary>
        public const byte Numerated         = 10;
        /// <summary>Embedded value</summary>
        public const byte Embedded          = 11;
        /// <summary>UTF8 string</summary>
        public const byte UTF8String        = 12;
        /// <summary>Part of OID</summary>
        public const byte RelativeOid       = 13;
        /// <summary>List of items</summary>
        public const byte Sequence          = 16;
        /// <summary>List of items occurring only once.</summary>
        public const byte Set               = 17;
        /// <summary>Numeric string</summary>
        public const byte NumericString     = 18;
        /// <summary>Printable string</summary>
        public const byte PrintableString   = 19;
        /// <summary>Teletext string</summary>
        public const byte TeletexString     = 20;
        /// <summary>Videotext string</summary>
        public const byte VideotexString    = 21;
        /// <summary>IA5String</summary>
        public const byte IA5String         = 22;
        /// <summary>UTC time</summary>
        public const byte UTCTime           = 23;
        /// <summary>General time.</summary>
        public const byte GeneralizedTime   = 24;
        /// <summary>Graphic string</summary>
        public const byte GraphicString     = 25;
        /// <summary>Visible string</summary>
        public const byte VisibleString     = 26;
        /// <summary>Generci string</summary>
        public const byte GeneralString     = 27;
        /// <summary>Universal string</summary>
        public const byte UniversalString   = 28;
        /// <summary>Charactr string</summary>
        public const byte CharacterString   = 29;
        /// <summary>Bitmapped string</summary>
        public const byte BMPString         = 30;


        }



    /// <summary>
    /// Root class for all ASN.1 backing structures
    /// </summary>
    public abstract class Root {
        /// <summary>
        /// Object identifier of this structure.
        /// </summary>
        public virtual int [] OID  => null;  

        /// <summary>
        /// Return the DER encoding of this structure
        /// </summary>
        /// <returns>The DER encoded value.</returns>
        public virtual byte [] DER () {
            Goedel.ASN.Buffer Buffer = new Buffer ();
            this.Encode (Buffer);

            return Buffer.Data;
            }

        /// <summary>
        /// Write this structure to a buffer.
        /// </summary>
        /// <param name="Buffer">Buffer to write to.</param>
        public abstract void Encode (Goedel.ASN.Buffer Buffer) ;

        }

    /// <summary>
    /// ANS.1 presentation class consisting of a single byte array with no
    /// sequence boundaries.
    /// </summary>
    public class ByteArrayVerbatim : Root {

        /// <summary>
        /// ASN.1 member Data 
        /// </summary>
        public byte[] Data;


        /// <summary>
        /// Write this structure to a buffer.
        /// </summary>
        /// <param name="Buffer">Buffer to write to.</param>
        public override void Encode(Goedel.ASN.Buffer Buffer) => Buffer.Encode__Octets(Data, 0, -1);


        /// <summary>
        /// Decode buffer to populate class members
        ///
        /// This is done in the forward direction
        /// </summary>
        /// <param name="Buffer">The source buffer</param>
        public void Decode(global::Goedel.ASN.DecodeBuffer Buffer) =>
            Data = Buffer.Decode__Octets(0, -1);
        }


    /// <summary>
    /// Utility class containing static methods.
    /// </summary>
    public static class ASN {
        static char[] Dot = new char[] { '.' };

        /// <summary>Convert an OID value to an array of integers</summary>
        /// <param name="OID">The string value of the OID.</param>
        /// <returns>The integer values of the OID segments.</returns>
        public static int[] OIDToArray(this string OID) {
            var Split = OID.Split(Dot);
            var Result = new int [Split.Length];
            for (var i = 0; i < Split.Length; i++) {
                Result [i] = Convert.ToInt32 (Split[i]);
                }
            return Result;
            }

        /// <summary>
        /// Convert byte array to big integer
        /// </summary>
        /// <param name="Array">Array to convert</param>
        /// <returns>Result of conversion</returns>
        public static BigInteger ToBigInteger(this byte[] Array) => new BigInteger(Array);

        }

    }
