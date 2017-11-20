using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Utilities;

namespace Goedel.Cryptography {

    /// <summary>Factory delegate for block processing provider.</summary>
    public delegate BlockProvider BlockProviderFactoryDelegate(byte[] Key, bool Encrypt);

    /// <summary>
    /// Base class for block providers
    /// </summary>
    public abstract class BlockProvider {

        /// <summary>The block size in bits</summary>
        public abstract int BlockSize { get; }

        /// <summary>
        /// Encrypt or decrypt a single block of data under the specified key
        /// </summary>
        /// <param name="Input">The input data block</param>
        /// <param name="InputOffset">The input offset</param>
        /// <param name="Output">The output data block</param>
        /// <param name="OutputOffset">The output offset</param>
        public abstract void Process(byte[] Input, int InputOffset, byte[] Output, int OutputOffset);

        }

    /// <summary>Base class for key wrapping operations</summary>
    public abstract class KeyWrap {

        /// <summary>Wrap a symmetric key</summary>
        /// <param name="Kek">The key encryption key</param>
        /// <param name="Plaintext">The Key to wrap</param>
        /// <returns>The wrapped key</returns>
        public abstract byte[] Wrap(byte[] Kek, byte[] Plaintext);

        /// <summary>Wrap a symmetric key</summary>
        /// <param name="Kek">The key encryption key</param>
        /// <param name="Ciphertext">The encrypted key to unwrap</param>
        /// <returns>The unwrapped key</returns>
        public abstract byte[] Unwrap(byte[] Kek, byte[] Ciphertext);

        }

    /// <summary>RFC3394 key wrap</summary>
    public class KeyWrapRFC3394 : KeyWrap {

        /// <summary>Wrap a symmetric key</summary>
        /// <param name="Kek">The key encryption key</param>
        /// <param name="Plaintext">The Key to wrap</param>
        /// <returns>The wrapped key</returns>
        public override byte[] Wrap(byte[] Kek, byte[] Plaintext) {
            return WrapKey(Kek, Plaintext);
            }


        /// <summary>Wrap a symmetric key</summary>
        /// <param name="Kek">The key encryption key</param>
        /// <param name="Plaintext">The Key to wrap</param>
        /// <returns>The wrapped key</returns>
        public static byte[] WrapKey(byte[] Kek, byte[] Plaintext) {

            var Encryptor = Platform.BlockProviderFactoryAes(Kek, true);

            int n = Plaintext.Length / 8; // The length in blocks
            var R = new Block[n + 1];

            //1) Initialize variables.
            //    Set A = IV, an initial value (see 2.2.3)
            //    For i = 1 to n
            //        R[i] = P[i]


            //TraceX.WriteLine("Kek {0}", BaseConvert.ToBase16String(Kek));
            //TraceX.WriteLine("Key {0}", BaseConvert.ToBase16String(Key));
            R[0] = new Block(0xA6);
            for (var i = 0; i < n; i++) {
                R[i + 1] = new Block(Plaintext, i);
                }

            //Trace(R);

            //2) Calculate intermediate values.
            //    For j = 0 to 5
            //        For i = 1 to n
            //            B = AES(K, A | R[i])
            //            A = MSB(64, B) ^ t where t = (n * j) + i
            //            R[i] = LSB(64, B)

            var In = new byte[16];
            var B = new byte[16];

            for (var j = 0; j <= 5; j++) {
                //TraceX.WriteLine("Round #{0}", j);
                for (var i = 1; i <= n; i++) {
                    long t = (n * j) + i;
                    Block.Concat(R[0], R[i], In);
                    Encryptor.Process(In, 0, B, 0);
                    R[0].MSB(B);
                    R[0].XOR(t);
                    R[i].LSB(B);

                    //Trace(R);
                    }
                }

            //3) Output the results.
            //    Set C[0] = A
            //    For i = 1 to n
            //        C[i] = R[i]
            var Result = Block.ToByte(R);
            //TraceX.WriteLine("Result {0}", BaseConvert.ToBase16String(Result));

            return Result;
            }
        /// <summary>Wrap a symmetric key</summary>
        /// <param name="Kek">The key encryption key</param>
        /// <param name="Ciphertext">The encrypted key to unwrap</param>
        /// <returns>The unwrapped key</returns>
        public override byte[] Unwrap(byte[] Kek, byte[] Ciphertext) {
            return UnwrapKey(Kek, Ciphertext);
            }

        /// <summary>Wrap a symmetric key</summary>
        /// <param name="Kek">The key encryption key</param>
        /// <param name="Ciphertext">The encrypted key to unwrap</param>
        /// <returns>The unwrapped key</returns>
        public static byte[] UnwrapKey (byte[] Kek, byte[] Ciphertext) {

            var Decryptor = Platform.BlockProviderFactoryAes(Kek, false);

            int n = (Ciphertext.Length / 8) -1;
            var R = new Block[n + 1];

            //TraceX.WriteLine("Kek {0}", BaseConvert.ToBase16String(Kek));
            //TraceX.WriteLine("Key {0}", BaseConvert.ToBase16String(Ciphertext));

            //1) Initialize variables.

            //    Set A = C[0]
            //    For i = 1 to n
            //        R[i] = C[i]

            for (var i = 0; i < n+1; i++) {
                R[i] = new Block(Ciphertext, i);
                }

            //2) Compute intermediate values.

            //    For j = 5 to 0
            //        For i = n to 1
            //            B = AES - 1(K, (A ^ t) | R[i]) where t = n * j + i
            //            A = MSB(64, B)
            //            R[i] = LSB(64, B)

            var In = new byte[16];
            var B = new byte[16];

            for (var j = 5; j >= 0; j--) {
                //TraceX.WriteLine("Round #{0}", j);
                for (var i = n; i >= 1; i--) {
                    long t = (n * j) + i;

                    R[0].XOR(t);
                    Block.Concat(R[0], R[i], In);
                    Decryptor.Process(In, 0, B, 0);
                    R[0].MSB(B);
                    R[i].LSB(B);

                    //Trace(R);
                    }
                }


            //3) Output results.

            //If A is an appropriate initial value(see 2.2.3),
            //Then
            //    For i = 1 to n
            //        P[i] = R[i]
            //Else
            //    Return an error
            Assert.True (R[0].Verify(0xA6), UnwrapFailed.Throw);
            //TraceX.WriteLine("Sentry {0}", R[0].ToString());

            var Result = Block.ToByte(R, 1);
            //TraceX.WriteLine("Result {0}", BaseConvert.ToBase16String(Result));

            return Result;
            }

        /// <summary>
        /// Debug aid
        /// </summary>
        /// <param name="R">Write out the register set</param>
        public void Trace (Block[] R) {
            var Builder = new StringBuilder();
            for (var i=0; i<R.Length; i++) {
                Builder.Append(R[i].ToString());
                Builder.Append("  ");
                }
            TraceX.WriteLine(Builder.ToString());
            }
        

        }

    /// <summary>Represents a block of data to be processed by cryptographic operations.
    /// This is used as a building block in key wrapping and derrivation functions.</summary>
    public struct Block {

        byte[] Data;

        /// <summary>
        /// Constructor from binary data.
        /// </summary>
        /// <param name="Data">The data to process</param>
        public Block(byte[] Data) {
            this.Data = Data;
            }

        /// <summary>
        /// Constructor from integer data.
        /// </summary>
        /// <param name="Value">Data value to initialize the value field.</param>
        public Block (int Value) {
            this.Data = new byte[8];
            for (var i=0; i<8; i++) {
                Data[i] = (byte)(Value & 0xff);
                }
            }

        /// <summary>
        /// Construct a data block from the specified source value
        /// </summary>
        /// <param name="Source">The source value.</param>
        /// <param name="Index">Offset within the block.</param>
        public Block(byte[] Source, int Index) {
            Data = new byte [8];
            Array.Copy(Source, Index * 8, Data, 0, 8);
            }

        /// <summary>
        /// Check that the sentry value is correct (bytes all the same value
        /// </summary>
        /// <param name="Value">The sentry value to check.</param>
        /// <returns>True if the sentry value is correct, false otherwise.</returns>
        public bool Verify (int Value) {
            foreach (var Byte in Data) {
                if (Byte != Value) {
                    return false;
                    }
                }

            return true;
            }

        /// <summary>
        /// Concatenate a left and right data value to form a cipher block.
        /// </summary>
        /// <param name="Left">The MSB</param>
        /// <param name="Right">The LSB</param>
        /// <param name="Result">The array to write the result to.</param>
        public static void Concat (Block Left, Block Right, byte[]Result) {
            Array.Copy(Left.Data, 0, Result, 0, 8);
            Array.Copy(Right.Data, 0, Result, 8, 8);
            return ;
            }

        /// <summary>
        /// Update the block value with the specified mask value.
        /// </summary>
        /// <param name="Mask">XOR mask value</param>
        public void XOR (long Mask) {

            //var Result = new byte[8];
            for (var i = 0; i < 8; i++) {
                Data[i] = (byte) (Data[i] ^ (Mask >> 56));
                Mask = Mask << 8;
                }
            }

        /// <summary>
        /// Extract the MSB from a cipher block.
        /// </summary>
        /// <param name="Source">The cipher block to extract from</param>
        /// <returns>The result</returns>
        public void MSB (byte[] Source) {
            Array.Copy(Source, 0, Data, 0, 8);
            }

        /// <summary>
        /// Extract the LSB from a cipher block.
        /// </summary>
        /// <param name="Source">The cipher block to extract from</param>
        /// <returns>The result</returns>
        public void LSB(byte[] Source) {
            Array.Copy(Source, 8, Data, 0, 8);
            }

        /// <summary>
        /// Convert the result to an array
        /// </summary>
        /// <param name="Blocks">The blocks to convert</param>
        /// <param name="Offset">Offset from start of array</param>
        /// <returns>The converted blocks.</returns>
        public static byte[] ToByte(Block[] Blocks, int Offset = 0) {
            var Result = new byte[(Blocks.Length- Offset) * 8];
            for (var i = Offset; i < Blocks.Length; i++) {
                Array.Copy(Blocks[i].Data, 0, Result, 8 * ( i- Offset), 8);
                }
            return Result;
            }


        /// <summary>
        /// Convert block value to hexadecimal string
        /// </summary>
        /// <returns>The text string representing the block value</returns>
        public override string ToString() {
            return BaseConvert.ToBase16String(Data);

            }
        }
    }
