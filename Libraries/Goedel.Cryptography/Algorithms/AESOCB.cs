using System;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Date;
using Org.BouncyCastle.Utilities.Encoders;
using Org.BouncyCastle.Utilities.Test;

using Org.BouncyCastle.Crypto.Tests;

using Goedel.Utilities;
using Goedel.Test;

namespace TestConsole {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            //var test = new OcbTest();
            //test.Perform();
            Test();
            Test2();
            }

        static void Test() {




            //Test(OcbTest.TEST_VECTORS_128[0]);
            Test(OcbTest.TEST_VECTORS_128[7]);

            //foreach (var testVector1 in OcbTest.TEST_VECTORS_128) {
            //    Test(testVector);
            //    }

            }


        static void Test2() {


            foreach (var testVector in OcbTest.TEST_VECTORS_128) {
                Test(testVector);
                }

            }

        static void Test(string [] testVector) {
            var testNonce = Hex.Decode(testVector[0]);
            var testAuthData = Hex.Decode(testVector[1]);
            var testPlaintext = Hex.Decode(testVector[2]);
            var testCipherText = Hex.Decode(testVector[3]);
            var testKey = Hex.Decode(OcbTest.KEY_128);
            
            var macLengthBits = 128;
            int macLengthBytes = macLengthBits / 8;


            //var aesEngine = Aes.Create();

            //////var aesEngine = new AesManaged();
            //aesEngine.Mode = CipherMode.ECB;
            //aesEngine.Padding = PaddingMode.None;
            //var aesenc = aesEngine.CreateEncryptor(testKey, null);
            //var aesdec = aesEngine.CreateDecryptor(testKey, null);

            //var encData = new byte[16];
            //var decData = new byte[16];
            //aesenc.TransformBlock(testKey, 0, AesOCB.AesBlock, encData, 0);
            //var b = aesdec.TransformBlock(encData, 0, AesOCB.AesBlock, decData, 0);




            KeyParameter keyParameter = new KeyParameter(testKey);
            AeadParameters parameters = new AeadParameters(keyParameter, macLengthBits, testNonce, testAuthData);
            byte[] tag = Arrays.CopyOfRange(testCipherText, testCipherText.Length - macLengthBytes, testCipherText.Length);

            // The Bouncy castle version
            var encCipher = new OcbBlockCipher(new AesEngine(), new AesEngine());
            encCipher.Init(true, parameters);
            byte[] enc = new byte[encCipher.GetOutputSize(testPlaintext.Length)];
            int len = encCipher.ProcessBytes(testPlaintext, 0, testPlaintext.Length, enc, 0);
            len += encCipher.DoFinal(enc, len);

            // My version
            var aesOCB = new AesOCB(testKey, testNonce);
            var enc2 = aesOCB.Process(testPlaintext, testAuthData);


            enc.TestEqual(enc2);
            enc2.TestEqual(testCipherText);


            // **** Decipher

            var deCipher = new OcbBlockCipher(new AesEngine(), new AesEngine());
            deCipher.Init(false, parameters);
            byte[] dec = new byte[deCipher.GetOutputSize(enc.Length)];
            int len2 = deCipher.ProcessBytes(enc, 0, enc.Length, dec, 0);
            len2 += deCipher.DoFinal(dec, len2);


            var aesOCB2 = new AesOCB(testKey, testNonce, encrypt: false);
            var dec2 = aesOCB2.Process(enc2, testAuthData);

            testPlaintext.TestEqual(dec2);


            (enc.Length == len).TestTrue();
            testCipherText.TestEqual(enc);
            tag.TestEqual(encCipher.GetMac());
            }

        public static void Check(IList l1, List<byte[]> l2) {

            l1.Count.TestEqual(l2.Count);
            for (var i = 0; i < l1.Count; i++) {
                var le1 = l1[i] as byte[];
                le1.TestEqual(l2[i]);
                }
            }

        }


    public class AesOCB {
        public const int AesBlock = 16;
        int TagLengthBytes { get; }

        public byte[] Stretch = new byte[24];
        public byte[] Offset = new byte[16];
        public byte[] Checksum = new byte[16];

        public bool Encrypt { get; }


        public byte[] LAsterisk = new byte[AesBlock];
        public byte[] LDollar = new byte[AesBlock];

        public List<byte[]> L = new();

        Aes aesEngine;

        ICryptoTransform aesHash;
        ICryptoTransform aesMain;



        public byte[] Sum = new byte[16];


        public byte[] Hash = new byte[16];

        public AesOCB(byte[] key, byte[] n = null, int tagLengthBits = 128, bool encrypt = true) {

            Encrypt = encrypt;

            // Validate the tag length parameter
            ((tagLengthBits >= 64) & (tagLengthBits <= 128)).AssertTrue(NYI.Throw);
            TagLengthBytes = tagLengthBits / 8;

            // Set up the AES encryptors and decryptors.
            aesEngine = Aes.Create();

            //aesEngine = new AesManaged();
            aesEngine.Mode = CipherMode.ECB;
            aesEngine.Padding = PaddingMode.None;
            aesHash = aesEngine.CreateEncryptor(key, null);
            aesMain = encrypt ? aesHash : aesEngine.CreateDecryptor(key, null);

            // Initialize the L array.
            aesHash.TransformBlock(LAsterisk, 0, AesBlock, LAsterisk, 0);
            LDollar = Double(LAsterisk);
            L.Add(Double(LDollar));

            // Process the nonce to obtain the input to the cipher to create KTOP
            var nonce = ExpandNonce(n ?? new byte[0]);
            var bottom = nonce[15] & 0x3F;
            nonce[15] &= 0xC0;

            // Derrive kTop, this will be the first 16 bytes of Stretch
            aesHash.TransformBlock(nonce, 0, AesBlock, Stretch, 0);
            // Next 8 bytes of Stretch are byte n ^ byte n+1
            for (int i = 0; i < 8; ++i) {
                Stretch[16 + i] = (byte)(Stretch[i] ^ Stretch[i + 1]);
                }

            // derive Offset0
            int bits = bottom % 8, bytes = bottom / 8;
            if (bits == 0) {
                Array.Copy(Stretch, bytes, Offset, 0, 16);
                }
            else {
                for (int i = 0; i < 16; ++i) {
                    uint b1 = Stretch[bytes++];
                    uint b2 = Stretch[bytes];
                    Offset[i] = (byte)((b1 << bits) | (b2 >> (8 - bits)));
                    }
                }
            }


        public int GetOutputLength(int inputLength) => Encrypt ?
            inputLength + TagLengthBytes : inputLength - TagLengthBytes;

        public int GetDataLength(int inputLength) => Encrypt ?
            inputLength : inputLength - TagLengthBytes;



        public byte[] Process(byte[] input, byte[] authData=null) {
            var output = new byte[GetOutputLength(input.Length)];
            var dataLength = GetDataLength(input.Length);

            var offset = Process(input, 0, dataLength, output, 0);

            Finalize(input, offset, output, offset, authData);

            return output;
            }


        static bool IsFullBlock(int index, int length) => ((index + 1) * AesBlock) <= length;


        public void GetHash(byte[] authData = null) {
            if (authData == null) {
                return;
                }

            var offset = new byte[16];
            var hashBlock = new byte[16];

            int block = 0;
            for (; IsFullBlock(block, authData.Length); block ++) {

                // calculate the offset
                var trailingZeroes = CountTrailingZeros(block+1);
                var L = GetLSub(trailingZeroes);
                Xor(offset, L);

                // Transformation
                Xor(authData, block * AesBlock, offset, hashBlock);
                aesHash.TransformBlock(hashBlock, 0, AesBlock, hashBlock, 0);
                Xor(Sum, hashBlock);
                }

            //Console.WriteLine($"My sum0 {Sum.ToStringBase16()}");

            // process an incomplete block here

            var remainder = authData.Length - block * AesBlock;
            if (remainder > 0 ) {

                // calculate the offset, we use the static value LAsterisk for this.

                //Console.WriteLine($"My offset {offset.ToStringBase16()}");

                // Apply to the block

                Xor(offset, LAsterisk);
                FillFinal(authData, AesBlock * block, offset, hashBlock, remainder);

                // Transformation
                aesHash.TransformBlock(hashBlock, 0, AesBlock, hashBlock, 0);

                //Console.WriteLine($"My hashblock {hashBlock.ToStringBase16()}");
                //Console.WriteLine();

                Xor(Sum, hashBlock);
                }

            Console.WriteLine($"My sum1 {Sum.ToStringBase16()}");
            }


        public int Process(byte[] input, int offsetIn, int length, byte[] output, int offsetOut) {
            var hashBlock = new byte[16];
            //var outBlock = new byte[16];
            int block;

            for (block = 0; IsFullBlock(block, length); block++) {
                var offsetBytes = offsetIn + block * AesBlock;

                if (Encrypt) {
                    // add the data to the checksum on the input.
                    Xor(Checksum, input, offsetBytes);

                    Console.WriteLine($"Enc  Checksum {Checksum.ToStringBase16()}");
                    }

                // Calculate L
                var trailingZeroes = CountTrailingZeros(block + 1);
                var L = GetLSub(trailingZeroes);

                //Console.WriteLine($"My L {L.ToStringBase16()}");

                // Apply L
                Xor(Offset, L);
                Xor(input, offsetBytes, Offset, hashBlock);

                //Console.WriteLine($"My Offset {Offset.ToStringBase16()}");
                //Console.WriteLine($"My hashBlock {hashBlock.ToStringBase16()}");

                aesMain.TransformBlock(hashBlock, 0, AesBlock, hashBlock, 0);


                //Console.WriteLine($"My Output {output.ToStringBase16()}");
                Xor(hashBlock, Offset);

                // copy to output
                var posOut = offsetOut + block * AesBlock;
                Array.Copy(hashBlock, 0, output, posOut, AesBlock);
                //Console.WriteLine($"My Output {output.ToStringBase16()}");

                if (!Encrypt) {

                    Console.WriteLine();
                    //Console.WriteLine($"My Checksum {Checksum.ToStringBase16()}");

                    Xor(Checksum, output, posOut);

                    Console.WriteLine($"Dec Checksum {Checksum.ToStringBase16()}");
                    }

                //offsetIn += 16;
                }
            //PositionAuthData = block * AesBlock;

            return offsetOut + block * AesBlock;


            }

        public void Finalize(byte[] input, int offsetIn, byte[] output, int offsetOut, byte[] authData) {

            GetHash(authData);



            //var hashBlock = new byte[16];


            // Process additional authenticated data.


            // Process any final partial block


            var remainder = Encrypt ? input.Length - offsetIn : input.Length - offsetIn - TagLengthBytes;
            if (remainder>0) {
                if (Encrypt) {
                    FillFinal(input, offsetIn, Checksum, Checksum, remainder);
                    }
                Xor(Offset, LAsterisk);

                //Console.WriteLine();
                //Console.WriteLine($"My OffsetMAIN {Offset.ToStringBase16()}");
                //Console.WriteLine($"My Checksum {Checksum.ToStringBase16()}");


                var pad = new byte[16];

                aesHash.TransformBlock(Offset, 0, AesBlock, pad, 0);
                //Console.WriteLine($"My pad {pad.ToStringBase16()}");





                //Console.Write("Block");
                for (int i = 0; i < remainder; i++) {
                    output[offsetOut + i] = (byte) (pad[i] ^ input[offsetIn+i]);

                    //Console.Write(" {0:x}",output[offsetOut + i]);
                    }





                //Console.WriteLine();

                //Xor(hashBlock, pad);
                //Console.WriteLine($"My mainblock {hashBlock.ToStringBase16()}");
                // copy to output here.
                //Array.Copy(hashBlock, 0, output, offsetOut, remainder);
                




                //Console.WriteLine("** Finalize Checksum");
                //Console.WriteLine($"My OffsetMAIN {Offset.ToStringBase16()}");




                if (!Encrypt) {
                    FillFinal(output, offsetOut, Checksum, Checksum, remainder);
                    }
                offsetOut += remainder;
                }

            Console.WriteLine($"**** My Penult Checksum {Checksum.ToStringBase16()}");

            Xor(Checksum, Offset);
            Xor(Checksum, LDollar);


            Console.WriteLine($"**** My Input Checksum {Checksum.ToStringBase16()}");
            aesHash.TransformBlock(Checksum, 0, AesBlock, Checksum, 0);

            Console.WriteLine($"**** My Sum {Sum.ToStringBase16()}");


            Xor(Checksum, Sum);






            Console.WriteLine($"FINAL Checksum {Checksum.ToStringBase16()}");

            if (Encrypt) {
                Array.Copy(Checksum, 0, output, offsetOut, AesBlock);
                }
            else {
                var tagStart = input.Length - TagLengthBytes;
                for (var i = 0; i < TagLengthBytes; i++) {
                    if (input[tagStart+i] != Checksum[i]) {
                        throw new NYI();
                        }
                    }
                }

            Console.WriteLine($"   output {output.ToStringBase16()}");
            Console.WriteLine("");
            }



        public void FillFinal(byte[] input, int start, byte[] offset, byte[] hashBlock, int remainder) {

            for (var i = 0; i < AesBlock; i++) {
                hashBlock[i] = i < remainder ? (byte)(input[start + i] ^ offset[i]) : offset[i];
                }
            hashBlock[remainder] ^= 0x80;
            }



        protected byte[] ExpandNonce(byte[] n) {
            byte[] nonce = new byte[16];

            nonce[0] = (byte)(TagLengthBytes << 4);
            Array.Copy(n, 0, nonce, nonce.Length - n.Length, n.Length);
            nonce[15 - n.Length] |= 1;

            return nonce;
            }



        protected static byte[] Double(byte[] block) {
            byte[] result = new byte[16];
            int carry = ShiftLeft(block, result);

            result[15] ^= (byte)(0x87 >> ((1 - carry) << 3));

            return result;
            }

        protected static int ShiftLeft(byte[] block, byte[] output) {
            int i = 16;
            uint bit = 0;
            while (--i >= 0) {
                uint b = block[i];
                output[i] = (byte)((b << 1) | bit);
                bit = (b >> 7) & 1;
                }
            return (int)bit;
            }

        protected static void Xor(byte[] block, byte[] val, int offset = 0) {
            for (int i = 15; i >= 0; --i) {
                block[i] ^= val[i+ offset];
                }
            }


        protected static void Xor(byte[] v1, int offset , byte[] v2, byte[] result) {
            for (int i = 15; i >= 0; --i) {
                result[i] = (byte) ((v1[i + offset]) ^ v2[i]);
                }
            }


        protected static int CountTrailingZeros(long x) {
            if (x == 0) {
                return 64;
                }

            int n = 0;
            ulong ux = (ulong)x;
            while ((ux & 1UL) == 0UL) {
                ++n;
                ux >>= 1;
                }
            return n;
            }

        protected virtual byte[] GetLSub(int n) {
            while (n >= L.Count) {
                L.Add(Double((byte[])L[L.Count - 1]));
                }
            return (byte[])L[n];
            }

        }


    }
