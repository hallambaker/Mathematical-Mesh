using System;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Cryptography {

    /// <summary>SHA3 Implementation</summary>
    public class SHA3 {
        readonly static int[] Rotations = new int[] {
            0, 1, 62, 28, 27, 36, 44, 6, 55, 20, 3, 10, 43, 25, 39, 41,
            45, 15, 21, 8, 18, 2, 61, 56, 14 };

        readonly static int[] Permutations = new int[] {
            1,6,9,22,14, 20,2,12,13,19, 23,15,4,24,21, 8,16,5,3,
            18,17,11,7,10 };

        readonly static ulong[] RoundConstant = new ulong[] {0x0000000000000001,0x0000000000008082,0x800000000000808a,
          0x8000000080008000,0x000000000000808b,0x0000000080000001,
          0x8000000080008081,0x8000000000008009,0x000000000000008a,
          0x0000000000000088,0x0000000080008009,0x000000008000000a,
          0x000000008000808b,0x800000000000008b,0x8000000000008089,
          0x8000000000008003,0x8000000000008002,0x8000000000000080,
          0x000000000000800a,0x800000008000000a,0x8000000080008081,
          0x8000000000008080,0x0000000080000001,0x8000000080008008 };

        ulong[] s = new ulong[25];

        /// <summary>Default constructor</summary>
        public SHA3 () {
            }

        /// <summary>The SHAKE256 function.</summary>
        /// <param name="Message">Message to digest.</param>
        /// <param name="OutLength">Output length.</param>
        /// <returns>The digest value.</returns>
        public byte[] Shake256(byte[] Message, int OutLength ) {
            return ShaCore(Message, 17, 31, OutLength);
            }

        byte[] ShaCore(byte[] Message, int ReadWords, int PadValue, int OutLength) {
            int Byte;
            var ReadBytes = 8 * ReadWords;

            // Process blocks
            int Block;
            //var FullBlocks = ReadBytes * (Message.Length / ReadBytes);
            for (Block = 0; Block < (Message.Length - ReadBytes - 1); Block += ReadBytes) {
                Process(Message, Block, ReadWords);
                Transform();
                }

            //Handle whole blocks.
            var Final = new byte[ReadBytes];
            Array.Copy(Message, Block, Final, 0, Message.Length - Block);
            Final[Message.Length - Block] = (byte)PadValue;
            Final[ReadBytes - 1] = 128;
            Process(Final, 0, ReadWords);

            //Output.
            var Result = new byte[OutLength];
            int Index = 0;
            while (Index < OutLength) {
                Transform();
                for (var Word = 0; (Word < ReadWords) & (Index < OutLength); Word++) {
                    var OutWord = s[Word];
                    for (Byte = 0; (Byte < 8) & (Index < OutLength); Byte++) {
                        Result[Index] = (byte)(OutWord & 0xff);
                        OutWord >>= 8;
                        Index++;
                        }
                    }

                }

            return Result;
            }

        // Rotate a word x by b places to the left.
        private static ulong RotateLeft(ulong x, int b) {
            return ((x << b) | (x >> (64 - b)));
            }
        
        // XOR the input stream into the leading edge of S
        private void Process(byte[] Message, int Start, int ReadWords) { 
            for (var Word = 0; Word < ReadWords; Word++) {
                ulong XOR = 0;
                for (var Byte = 7; Byte >= 0; Byte--) {
                    XOR = (XOR << 8) | Message[Start + (Word * 8) + Byte];
                    }
                s[Word] ^= XOR;
                }

            }

        private  void Transform() {

            int i, j;
            for (var Round = 0; Round < 24; Round++) {
                // AddColumnParity (Theta)
                var C = new ulong[5];
                var D = new ulong[5];
                for (i =0; i<25; i++) {
                    C[i % 5] ^= s[i];
                    }
                for (i = 0; i < 5; i++) {
                    D[i] = C[(i + 4) % 5] ^ RotateLeft(C[(i + 1) % 5], 1);
                    }
                for (i = 0; i < 25; i++) {
                    s[i] ^= D[i % 5];
                    }
                // RotateWords (Rho)

                for (i = 0; i < 25; i++) {
                    s[i] = RotateLeft(s[i], Rotations[i]);
                    }
                // PermuteWords (Pi)
                var t = s[Permutations[0]];
                for (i = 0; i < Permutations.Length-1; i++) {
                    s[Permutations[i]] = s[Permutations[i + 1]];
                    }
                s[Permutations[Permutations.Length - 1]] = t;
                // NonlinearMixRows (Chi)
                for (i = 0; i < 25; i+=5) {
                    var Temp = new ulong[] { s[i], s[i + 1], s[i + 2], s[i + 3], s[i + 4], s[i], s[i + 1] };
                    for (j = 0; j < 5; j ++) {
                        s[i + j] = Temp[j] ^ ((~Temp[j + 1]) & (Temp[j + 2]));
                        }
                    }
                // AddRoundConstant (Iota)
                s[0] ^= RoundConstant[Round];
                }

            }

        }
    }
