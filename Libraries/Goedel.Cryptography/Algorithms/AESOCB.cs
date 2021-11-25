#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
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
#endregion
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
//using Org.BouncyCastle.Crypto;
//using Org.BouncyCastle.Crypto.Engines;
//using Org.BouncyCastle.Crypto.Modes;
//using Org.BouncyCastle.Crypto.Parameters;
//using Org.BouncyCastle.Security;
//using Org.BouncyCastle.Utilities;
//using Org.BouncyCastle.Utilities.Date;
//using Org.BouncyCastle.Utilities.Encoders;
//using Org.BouncyCastle.Utilities.Test;

//using Org.BouncyCastle.Crypto.Tests;

using Goedel.Utilities;
//using Goedel.Test;

namespace TestConsole;

//class Program {
//    static void Main(string[] args) {
//        Console.WriteLine("Hello World!");

//        //var test = new OcbTest();
//        //test.Perform();
//        Test();
//        Test2();
//        }

//    static void Test() {




//        //Test(OcbTest.TEST_VECTORS_128[0]);
//        Test(OcbTest.TEST_VECTORS_128[7]);

//        //foreach (var testVector1 in OcbTest.TEST_VECTORS_128) {
//        //    Test(testVector);
//        //    }

//        }


//    static void Test2() {


//        foreach (var testVector in OcbTest.TEST_VECTORS_128) {
//            Test(testVector);
//            }

//        }

//    static void Test(string [] testVector) {
//        var testNonce = Hex.Decode(testVector[0]);
//        var testAuthData = Hex.Decode(testVector[1]);
//        var testPlaintext = Hex.Decode(testVector[2]);
//        var testCipherText = Hex.Decode(testVector[3]);
//        var testKey = Hex.Decode(OcbTest.KEY_128);

//        var macLengthBits = 128;
//        int macLengthBytes = macLengthBits / 8;


//        //var aesEngine = Aes.Create();

//        //////var aesEngine = new AesManaged();
//        //aesEngine.Mode = CipherMode.ECB;
//        //aesEngine.Padding = PaddingMode.None;
//        //var aesenc = aesEngine.CreateEncryptor(testKey, null);
//        //var aesdec = aesEngine.CreateDecryptor(testKey, null);

//        //var encData = new byte[16];
//        //var decData = new byte[16];
//        //aesenc.TransformBlock(testKey, 0, AesOCB.AesBlock, encData, 0);
//        //var b = aesdec.TransformBlock(encData, 0, AesOCB.AesBlock, decData, 0);




//        KeyParameter keyParameter = new KeyParameter(testKey);
//        AeadParameters parameters = new AeadParameters(keyParameter, macLengthBits, testNonce, testAuthData);
//        byte[] tag = Arrays.CopyOfRange(testCipherText, testCipherText.Length - macLengthBytes, testCipherText.Length);

//        // The Bouncy castle version
//        var encCipher = new OcbBlockCipher(new AesEngine(), new AesEngine());
//        encCipher.Init(true, parameters);
//        byte[] enc = new byte[encCipher.GetOutputSize(testPlaintext.Length)];
//        int len = encCipher.ProcessBytes(testPlaintext, 0, testPlaintext.Length, enc, 0);
//        len += encCipher.DoFinal(enc, len);

//        // My version
//        var aesOCB = new AesOCB(testKey, testNonce);
//        var enc2 = aesOCB.Process(testPlaintext, testAuthData);


//        enc.TestEqual(enc2);
//        enc2.TestEqual(testCipherText);


//        // **** Decipher

//        var deCipher = new OcbBlockCipher(new AesEngine(), new AesEngine());
//        deCipher.Init(false, parameters);
//        byte[] dec = new byte[deCipher.GetOutputSize(enc.Length)];
//        int len2 = deCipher.ProcessBytes(enc, 0, enc.Length, dec, 0);
//        len2 += deCipher.DoFinal(dec, len2);


//        var aesOCB2 = new AesOCB(testKey, testNonce, encrypt: false);
//        var dec2 = aesOCB2.Process(enc2, testAuthData);

//        testPlaintext.TestEqual(dec2);


//        (enc.Length == len).TestTrue();
//        testCipherText.TestEqual(enc);
//        tag.TestEqual(encCipher.GetMac());
//        }

//    public static void Check(IList l1, List<byte[]> l2) {

//        l1.Count.TestEqual(l2.Count);
//        for (var i = 0; i < l1.Count; i++) {
//            var le1 = l1[i] as byte[];
//            le1.TestEqual(l2[i]);
//            }
//        }

//    }

/// <summary>
/// Implementation of OCB mode for AES. This does not currently expose the full capabilities 
/// of the .NET cryptographic processing classes.
/// </summary>
public class AesOCB {

    ///<summary>The block length in bytes.</summary> 
    public const int AesBlock = 16;

    ///<summary>Processing mode is encryption if true and decryption if false.</summary> 
    public bool Encrypt { get; }

    int TagLengthBytes { get; }

    byte[] stretch = new byte[24];
    byte[] offset = new byte[16];
    byte[] checksum = new byte[16];

    byte[] lAsterisk = new byte[AesBlock];
    byte[] lDollar = new byte[AesBlock];

    List<byte[]> l = new();

    Aes aesEngine;
    ICryptoTransform aesHash;
    ICryptoTransform aesMain;

    byte[] sum = new byte[16];


    /// <summary>
    /// Constructor for an OCB processor with key, nonce, tag length and processing mode
    /// specified by <paramref name="key"/>, <paramref name="n"/>, <paramref name="tagLengthBits"/>
    /// and <paramref name="encrypt"/> respectively.
    /// </summary>
    /// <param name="key">The key. This MUST be a valid AES key size (i.e. 128, 192 or 256).</param>
    /// <param name="n"></param>
    /// <param name="tagLengthBits">The tag length in bits. The value MUST be in the interval
    /// [64..128].</param>
    /// <param name="encrypt">Processing mode is encryption if true and decryption if false.</param>
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
        aesHash.TransformBlock(lAsterisk, 0, AesBlock, lAsterisk, 0);
        lDollar = Double(lAsterisk);
        l.Add(Double(lDollar));

        // Process the nonce to obtain the input to the cipher to create KTOP
        var nonce = ExpandNonce(n ?? Array.Empty<byte>());
        var bottom = nonce[15] & 0x3F;
        nonce[15] &= 0xC0;

        // Derrive kTop, this will be the first 16 bytes of Stretch
        aesHash.TransformBlock(nonce, 0, AesBlock, stretch, 0);
        // Next 8 bytes of Stretch are byte n ^ byte n+1
        for (int i = 0; i < 8; ++i) {
            stretch[16 + i] = (byte)(stretch[i] ^ stretch[i + 1]);
            }

        // derive Offset0
        int bits = bottom % 8, bytes = bottom / 8;
        if (bits == 0) {
            Array.Copy(stretch, bytes, offset, 0, 16);
            }
        else {
            for (int i = 0; i < 16; ++i) {
                uint b1 = stretch[bytes++];
                uint b2 = stretch[bytes];
                offset[i] = (byte)((b1 << bits) | (b2 >> (8 - bits)));
                }
            }
        }

    /// <summary>
    /// Returns the output data length for an input of <paramref name="inputLength"/> bytes
    /// </summary>
    /// <param name="inputLength">The input length</param>
    /// <returns>The corresponding output length.</returns>
    public int GetOutputLength(int inputLength) => Encrypt ?
        inputLength + TagLengthBytes : inputLength - TagLengthBytes;

    /// <summary>
    /// Returns the length of the plaintext for the input length <paramref name="inputLength"/>
    /// </summary>
    /// <param name="inputLength">The input length</param>
    /// <returns>The corresponding plaintext length.</returns>
    public int GetDataLength(int inputLength) => Encrypt ?
        inputLength : inputLength - TagLengthBytes;


    /// <summary>
    /// Process the input data <paramref name="input"/> with associated data 
    /// <paramref name="authData"/> and return the result.
    /// </summary>
    /// <param name="input">The input data</param>
    /// <param name="authData">Additional authentication data (ignored if null)</param>
    /// <returns>The processed data.</returns>
    public byte[] Process(byte[] input, byte[] authData = null) {
        var output = new byte[GetOutputLength(input.Length)];
        Process(input, output, authData);
        return output;
        }


    /// <summary>
    /// Process the input data <paramref name="input"/> with associated data 
    /// <paramref name="authData"/> and return the result.
    /// </summary>
    /// <param name="input">The input data</param>
    /// <param name="output">Buffer in which the output data is to be stored.</param>
    /// <param name="authData">Additional authentication data (ignored if null)</param>
    /// <returns>The number of bytes written to <paramref name="output"/>.</returns>
    public int Process(byte[] input, byte[] output, byte[] authData = null) {
        var dataLength = GetDataLength(input.Length);

        var offset = Process(input, 0, dataLength, output, 0);

        Finalize(input, offset, output, offset, authData);

        return GetOutputLength(input.Length);
        }



    static bool IsFullBlock(int index, int length) => ((index + 1) * AesBlock) <= length;

    /// <summary>
    /// Get the OCB hash value on the associated data <paramref name="authData"/>.
    /// </summary>
    /// <param name="authData">The </param>
    public void GetHash(byte[] authData = null) {
        if (authData == null) {
            return;
            }

        var offset = new byte[16];
        var hashBlock = new byte[16];

        int block = 0;
        for (; IsFullBlock(block, authData.Length); block++) {

            // calculate the offset
            var trailingZeroes = CountTrailingZeros(block + 1);
            var L = GetLSub(trailingZeroes);
            Xor(offset, L);

            // Transformation
            Xor(authData, block * AesBlock, offset, hashBlock);
            aesHash.TransformBlock(hashBlock, 0, AesBlock, hashBlock, 0);
            Xor(sum, hashBlock);
            }

        // process an incomplete block here
        var remainder = authData.Length - block * AesBlock;
        if (remainder > 0) {

            // calculate the offset, we use the static value LAsterisk for this.
            // Apply to the block

            Xor(offset, lAsterisk);
            FillFinal(authData, AesBlock * block, offset, hashBlock, remainder);

            // Transformation
            aesHash.TransformBlock(hashBlock, 0, AesBlock, hashBlock, 0);
            Xor(sum, hashBlock);
            }

        Console.WriteLine($"My sum1 {sum.ToStringBase16()}");
        }

    /// <summary>
    /// Process the block <paramref name="input"/> starting at byte <paramref name="offsetIn"/> for 
    /// <paramref name="length"/> bytes and write the result to <paramref name="output"/> starting
    /// at <paramref name="offsetOut"/>.
    /// </summary>
    /// <param name="input">The input buffer.</param>
    /// <param name="offsetIn">Initial byte to process in the input buffer.</param>
    /// <param name="length">Number of bytes to process. MUST be a whole multiple
    /// of <see cref="AesBlock"/>.</param>
    /// <param name="output">The output buffer. This MUST be large enough to hold
    /// the output bytes.</param>
    /// <param name="offsetOut">Starting position within the output buffer.</param>
    /// <returns>The number of data bytes written to <paramref name="output"/>. This
    /// SHOULD be added to <paramref name="offsetOut"/> on the next call if
    /// performing sequential processing to a pre-allocated buffer.</returns>
    public int Process(byte[] input, int offsetIn, int length, byte[] output, int offsetOut) {
        var hashBlock = new byte[16];
        //var outBlock = new byte[16];
        int block;

        for (block = 0; IsFullBlock(block, length); block++) {
            var offsetBytes = offsetIn + block * AesBlock;

            if (Encrypt) {
                // add the data to the checksum on the input.
                Xor(checksum, input, offsetBytes);

                Console.WriteLine($"Enc  Checksum {checksum.ToStringBase16()}");
                }

            // Calculate L
            var trailingZeroes = CountTrailingZeros(block + 1);
            var L = GetLSub(trailingZeroes);

            //Console.WriteLine($"My L {L.ToStringBase16()}");

            // Apply L
            Xor(offset, L);
            Xor(input, offsetBytes, offset, hashBlock);

            //Console.WriteLine($"My Offset {Offset.ToStringBase16()}");
            //Console.WriteLine($"My hashBlock {hashBlock.ToStringBase16()}");

            aesMain.TransformBlock(hashBlock, 0, AesBlock, hashBlock, 0);


            //Console.WriteLine($"My Output {output.ToStringBase16()}");
            Xor(hashBlock, offset);

            // copy to output
            var posOut = offsetOut + block * AesBlock;
            Array.Copy(hashBlock, 0, output, posOut, AesBlock);
            //Console.WriteLine($"My Output {output.ToStringBase16()}");

            if (!Encrypt) {

                Console.WriteLine();
                //Console.WriteLine($"My Checksum {Checksum.ToStringBase16()}");

                Xor(checksum, output, posOut);

                Console.WriteLine($"Dec Checksum {checksum.ToStringBase16()}");
                }

            //offsetIn += 16;
            }
        //PositionAuthData = block * AesBlock;

        return offsetOut + block * AesBlock;


        }

    /// <summary>
    /// Complete processing of the data,
    /// </summary>
    /// <param name="input">The input buffer.</param>
    /// <param name="offsetIn">Initial byte to process in the input buffer.</param>
    /// <param name="output">The output buffer. This MUST be large enough to hold
    /// the output bytes.</param>
    /// <param name="offsetOut">Starting position within the output buffer.</param>
    /// <param name="authData">Optional authenticated plaintext data.</param>
    public void Finalize(byte[] input, int offsetIn, byte[] output, int offsetOut, byte[] authData) {

        GetHash(authData);

        var remainder = Encrypt ? input.Length - offsetIn : input.Length - offsetIn - TagLengthBytes;
        if (remainder > 0) {
            if (Encrypt) {
                FillFinal(input, offsetIn, checksum, checksum, remainder);
                }
            Xor(offset, lAsterisk);
            var pad = new byte[16];

            aesHash.TransformBlock(offset, 0, AesBlock, pad, 0);
            for (int i = 0; i < remainder; i++) {
                output[offsetOut + i] = (byte)(pad[i] ^ input[offsetIn + i]);
                }

            if (!Encrypt) {
                FillFinal(output, offsetOut, checksum, checksum, remainder);
                }
            offsetOut += remainder;
            }


        Xor(checksum, offset);
        Xor(checksum, lDollar);

        aesHash.TransformBlock(checksum, 0, AesBlock, checksum, 0);
        Xor(checksum, sum);

        if (Encrypt) {
            // Tweak: Could avoid this copy by combining with the preceding XOR.
            Array.Copy(checksum, 0, output, offsetOut, AesBlock);
            }
        else {
            // Tweak: Could combine with the preceding XOR.
            var tagStart = input.Length - TagLengthBytes;
            for (var i = 0; i < TagLengthBytes; i++) {
                if (input[tagStart + i] != checksum[i]) {
                    throw new NYI();
                    }
                }
            }
        }

    static void FillFinal(byte[] input, int start, byte[] offset, byte[] hashBlock, int remainder) {

        for (var i = 0; i < AesBlock; i++) {
            hashBlock[i] = i < remainder ? (byte)(input[start + i] ^ offset[i]) : offset[i];
            }
        hashBlock[remainder] ^= 0x80;
        }


    /// <summary>
    /// Expand the nonce <paramref name="n"/> to create the nonce block value.
    /// </summary>
    /// <param name="n">The supplied nonce.</param>
    /// <returns>The nonce block value.</returns>
    protected byte[] ExpandNonce(byte[] n) {
        byte[] nonce = new byte[16];

        nonce[0] = (byte)(TagLengthBytes << 4);
        Array.Copy(n, 0, nonce, nonce.Length - n.Length, n.Length);
        nonce[15 - n.Length] |= 1;

        return nonce;
        }


    /// <summary>
    /// Double the value of the block <paramref name="block"/>.
    /// </summary>
    /// <param name="block">The block to double.</param>
    /// <returns>The doubled block.</returns>
    protected static byte[] Double(byte[] block) {
        byte[] result = new byte[16];
        int carry = ShiftLeft(block, result);

        result[15] ^= (byte)(0x87 >> ((1 - carry) << 3));

        return result;
        }

    /// <summary>
    /// Shift the block <paramref name="block"/> left.
    /// </summary>
    /// <param name="block">The input block.</param>
    /// <param name="output">The left shifted block.</param>
    /// <returns>the leftmost bit of the input.</returns>
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

    /// <summary>
    /// XOR the block <paramref name="b1"/> with the block <paramref name="b2"/> 
    /// beginning at offset <paramref name="offsetb2"/>, writing the result to
    /// <paramref name="b1"/>.
    /// </summary>
    /// <param name="b1">First input and the output.</param>
    /// <param name="b2">Second input block.</param>
    /// <param name="offsetb2">Offset from the start of b2.</param>
    protected static void Xor(byte[] b1, byte[] b2, int offsetb2 = 0) {
        for (int i = 15; i >= 0; --i) {
            b1[i] ^= b2[i + offsetb2];
            }
        }

    /// <summary>
    /// XOR the block <paramref name="b1"/> 
    /// beginning at offset <paramref name="offsetb1"/>, 
    /// with the block <paramref name="b2"/> writing the result to
    /// <paramref name="result"/>.
    /// </summary>
    /// <param name="b1">First input.</param>
    /// <param name="b2">Second input block.</param>
    /// <param name="offsetb1">Offset from the start of b1.</param>
    /// <param name="result">The output.</param>
    protected static void Xor(byte[] b1, int offsetb1, byte[] b2, byte[] result) {
        for (int i = 15; i >= 0; --i) {
            result[i] = (byte)((b1[i + offsetb1]) ^ b2[i]);
            }
        }


    /// <summary>
    /// Count the trailing zeros of <paramref name="x"/>
    /// </summary>
    /// <param name="x">The input.</param>
    /// <returns>The number of trailing zeros.</returns>
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

    /// <summary>
    /// Return the L value L_<paramref name="n"/>
    /// </summary>
    /// <param name="n">The subscript.</param>
    /// <returns>The L value.</returns>
    protected virtual byte[] GetLSub(int n) {
        while (n >= l.Count) {
            l.Add(Double((byte[])l[^1]));
            }
        return (byte[])l[n];
        }

    }
