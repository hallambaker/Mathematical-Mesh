using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Goedel.ASN {

    /// <summary>
    /// A stack entry framing a data region.
    /// </summary>
    class StackEntry {
        /// <summary>
        /// The start position.
        /// </summary>
        public int StartPosition;

        /// <summary>
        /// The end position.
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
        /// <param name="Text">Text to write</param>
        public virtual void Debug(string Text) {
            }

        /// <summary>
        /// Read a byte from the input stream
        /// </summary>
        /// <returns></returns>
        byte Read() => Input[ReadPointer++];

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

                Assert.AssertFalse(Byte4 >= 0x80, InvalidLength.ThrowNew);
                return (Byte1 << 24) | (Byte2 << 16) | (Byte3 << 8) | Byte4;
                }

            throw new InvalidLength();
            }

        int ReadCheckedLength(bool Indefinite) {
            var Length = ReadLength();

            Assert.AssertFalse(!Indefinite & Length < 0, IndefiniteLengthInvalid.ThrowNew);
            Assert.AssertFalse(ReadPointer + Length > Input.Length, LengthExceedsInput.ThrowNew);
            Assert.AssertFalse(ReadPointer + Length > ReadLimit, LengthExceedsStructure.ThrowNew);

            return Length;
            }

        /// <summary>
        /// Decode the start of a sequence
        /// </summary>
        public virtual void Decode__Sequence_Start() {
            var Identifier = Read();
            Assert.AssertFalse(Identifier != Constants.Sequence + (int)TagMode.Constructed,
                        ExpectedSequence.ThrowNew);

            var Length = ReadCheckedLength(false);


            ReadLimit = ReadPointer + Length;
            var StackEntry = new StackEntry {
                StartPosition = ReadPointer,
                EndPosition = ReadLimit
                };
            Stack.Add(StackEntry);


            }

        /// <summary>
        /// Decode the end of a sequence
        /// </summary>
        public virtual void Decode__Sequence_End() {
            Assert.AssertFalse(ReadPointer != ReadLimit, UnExpectedData.ThrowNew);
            Stack.RemoveAt(Stack.Count - 1);

            if (Stack.Count > 0) {
                ReadLimit = Stack.Last().EndPosition;
                }
            else {
                ReadLimit = Input.Length;
                }
            }

        /// <summary>
        /// Decode an integer
        /// </summary>
        /// <param name="Flags">ASN.1 flags</param>
        /// <param name="Code">ASN.1 code</param>
        /// <returns>The value read</returns>
        public virtual int Decode__Integer(int Flags, int Code) {
            var Identifier = Read();
            Assert.AssertFalse(Identifier != Constants.Integer, ExpectedInteger.ThrowNew);

            var Length = ReadCheckedLength(false);
            Assert.AssertFalse(Length < 1, InvalidLength.ThrowNew);
            Assert.AssertFalse(Length > 4, IntegerOverflow.ThrowNew);

            var Byte0 = Read();
            Assert.AssertFalse(Byte0 >= 0x80, Implementation.ThrowNew);
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
        /// Decode a big integer.
        /// </summary>
        /// <param name="Flags">ASN.1 Flags</param>
        /// <param name="Code">ASN.1 Code</param>
        /// <returns>Big integer decoded to buffer with MSB in index 0 </returns>
        public virtual byte[] Decode__BigInteger(int Flags, int Code) {
            var Identifier = Read();
            Assert.AssertFalse(Identifier != Constants.Integer, ExpectedInteger.ThrowNew);

            var Length = ReadCheckedLength(false);
            Assert.AssertFalse(Length < 1, InvalidLength.ThrowNew);

            var Byte0 = Read();
            Assert.AssertFalse(Byte0 >= 0x80, Implementation.ThrowNew);

            byte[] Result;

            if (Byte0 == 0) {
                Result = new byte[Length - 1];
                for (var i = 1; i < Length; i++) {
                    Result[i - 1] = Read();
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



        /// <summary>
        /// Decode a sequence of octets.
        /// </summary>
        /// <param name="Flags">ASN.1 Flags</param>
        /// <param name="Code">ASN.1 Code</param>
        /// <returns>Big integer decoded to buffer with MSB in index 0 </returns>
        public virtual byte[] Decode__Octets(int Flags, int Code) => throw new NotImplementedException();


        /// <summary>
        /// Decode a sequence of octets.
        /// </summary>
        /// <param name="Flags">ASN.1 Flags</param>
        /// <param name="Code">ASN.1 Code</param>
        /// <returns>Big integer decoded to buffer with MSB in index 0 </returns>
        public virtual Goedel.ASN.Root Decode__Object(int Flags, int Code) => throw new NotImplementedException();


        /// <summary>
        /// Decode a sequence of octets.
        /// </summary>
        /// <param name="Flags">ASN.1 Flags</param>
        /// <param name="Code">ASN.1 Code</param>
        /// <returns>Big integer decoded to buffer with MSB in index 0 </returns>
        public virtual Goedel.ASN.Root Decode__OIDRef(int Flags, int Code) => throw new NotImplementedException();


        /// <summary>
        /// Decode a sequence of octets.
        /// </summary>
        /// <param name="Flags">ASN.1 Flags</param>
        /// <param name="Code">ASN.1 Code</param>
        /// <returns>Big integer decoded to buffer with MSB in index 0 </returns>
        public virtual byte[] Decode__Bits(int Flags, int Code) => throw new NotImplementedException();

        /// <summary>
        /// Decode a sequence of octets.
        /// </summary>
        /// <param name="Flags">ASN.1 Flags</param>
        /// <param name="Code">ASN.1 Code</param>
        /// <returns>Big integer decoded to buffer with MSB in index 0 </returns>
        public virtual DateTime Decode__Time(int Flags, int Code) => throw new NotImplementedException();


        }
    }
