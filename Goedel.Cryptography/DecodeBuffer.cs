using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.ASN1 {

    /// <summary>
    /// 
    /// </summary>
    class StackEntry {
        /// <summary>
        /// 
        /// </summary>
        public int StartPosition;

        /// <summary>
        /// 
        /// </summary>
        public int EndPosition;    // Set to -1 if indefinite construction
        }

    /// <summary>
    /// Buffer used to decode ASN1 data
    /// </summary>
    public class DecodeBuffer {
        byte[] Input;
        int ReadPointer = 0;
        int ReadLimit;
        List<StackEntry> Stack = new List<StackEntry>();

        /// <summary>
        /// Create a decode buffer from the specified byte array
        /// </summary>
        /// <param name="Input">Byte array containing encoded data</param>
        public DecodeBuffer(byte[] Input) {
            this.Input = Input;
            ReadLimit = Input.Length;
            }

        /// <summary>
        /// Write out debug message during processing
        /// </summary>
        /// <param name="Text"></param>
        public virtual void Debug(string Text) {
            }

        /// <summary>
        /// Read a byte from the input stream
        /// </summary>
        /// <returns></returns>
        byte Read () {
            return Input[ReadPointer++];
            }

        /// <summary>
        /// Read an ASN.1 Length value
        /// </summary>
        /// <returns>The length value read</returns>
        int ReadLength() {
            var Byte0 = Read();

            if (Byte0 < 0x80) {
                return Byte0;
                }
            if (Byte0 == 0x80) {
                return -1;          // indefinite length encoding
                }
            if (Byte0 == 0x81) {
                var Byte1 = Read();
                return Byte1;
                }
            if (Byte0 == 0x82) {
                var Byte1 = Read();
                var Byte2 = Read();
                return (Byte1 << 8) | Byte2;
                }
            if (Byte0 == 0x83) {
                var Byte1 = Read();
                var Byte2 = Read();
                var Byte3 = Read();
                return (Byte1 << 16) | (Byte2 << 8) | Byte3;
                }
            if (Byte0 == 0x84) {
                var Byte1 = Read();
                var Byte2 = Read();
                var Byte3 = Read();
                var Byte4 = Read();

                if (Byte4 >= 0x80) {
                    throw new Exception("Length too long");
                    }
                return (Byte1 <<24) | (Byte2 << 16) | (Byte3 <<8) | Byte4;
                }

            throw new Exception("Length too long");
            }

        int ReadCheckedLength (bool Indefinite) {
            var Length = ReadLength();

            if (!Indefinite & Length < 0) {
                throw new Exception("Indefinite length not valid");
                }

            if (ReadPointer + Length > Input.Length) {
                throw new Exception("Length exceeds data input");
                }
            if (ReadPointer + Length > ReadLimit) {
                throw new Exception("Length exceeds current structure");
                }

            return Length;
            }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Decode__Sequence_Start() {
            var Identifier = Read();
            if (Identifier != Constants.Sequence + (int)TagMode.Constructed) {
                throw new Exception("Expected Sequence");
                }

            var Length = ReadCheckedLength(false);


            ReadLimit = ReadPointer + Length;
            var StackEntry = new StackEntry {
                StartPosition = ReadPointer,
                EndPosition = ReadLimit
                };
            Stack.Add(StackEntry);


            }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Decode__Sequence_End() {
            if (ReadPointer != ReadLimit) {
                throw new Exception("Unexpected Data");
                }
            Stack.RemoveAt(Stack.Count - 1);

            if (Stack.Count > 0) {
                ReadLimit = Stack.Last().EndPosition;
                }
            else {
                ReadLimit = Input.Length;
                }
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Flags"></param>
        /// <param name="Code"></param>
        /// <returns></returns>
        public virtual int Decode__Integer(int Flags, int Code) {
            var Identifier = Read();
            if (Identifier != Constants.Integer) {
                throw new Exception("Expected Integer");
                }
            var Length = ReadCheckedLength(false);

            if (Length <1) {
                throw new Exception("Invalid length");
                }
            if (Length >4) {
                throw new Exception("Integer too large");
                }

            var Byte0 = Read();
            if (Byte0 >= 0x80) {
                throw new Exception("Negative integers not supported");
                }
            if (Length == 1) {
                return Byte0;
                }

            var Byte1 = Read();
            if (Length == 2) {
                return Byte0 << 8 | Byte1;
                }

            var Byte2 = Read();
            if (Length == 3) {
                return Byte0 << 16 | Byte1 << 8 + Byte2;
                }

            var Byte3 = Read();
            if (Length == 4) {
                return Byte0 << 24 | Byte1 << 16 + Byte2 << 8 + Byte3;
                }

            return 0;
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Flags"></param>
        /// <param name="Code"></param>
        /// <returns></returns>
        public virtual byte[] Decode__BigInteger(int Flags, int Code) {
            var Identifier = Read();
            if (Identifier != Constants.Integer) {
                throw new Exception("Expected Integer");
                }

            var Length = ReadCheckedLength(false);
            if (Length < 1) {
                throw new Exception("Invalid length");
                }

            var Byte0 = Read();
            if (Byte0 >= 0x80) {
                throw new Exception("Negative integers not supported");
                }


            byte[] Result;


            if (Byte0 == 0) {
                Result = new byte[Length-1];
                for (var i = 1; i < Length; i++) {
                    Result[i-1] = Read();
                    }
                }
            else {
                Result = new byte[Length];
                Result[0] = Byte0;
                for (var i = 1; i < Length; i++) {
                    Result[i] = Read();
                    }
                }



            return Result;
            }

        }
    }
