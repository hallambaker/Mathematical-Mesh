#region // Copyright
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
using System.Text;

using Goedel.Cryptography.PKIX;
using Goedel.Utilities;

namespace Goedel.Cryptography.KeyFile {

    /// <summary>
    /// Implement a tokenized buffer for the data encoding used in SSH.
    /// </summary>
    public class DataBuffer {
        uint Length = 0;
        uint Pointer = 0;

        uint Remain => (uint)(Data.Length - Pointer);

        /// <summary>The collected data</summary>
        public byte[] Data;

        /// <summary>Default constructor</summary>
        public DataBuffer() {
            }

        /// <summary>
        /// Constructor for use decoding the specified input buffer
        /// </summary>
        /// <param name="Data">Data input</param>
        public DataBuffer(byte[] Data) => this.Data = Data;

        /// <summary>
        /// Reserve space for a data item
        /// </summary>
        /// <param name="Data">Byte array.</param>
        public void Size(byte[] Data) => Length += (uint)(4 + Data.Length);

        /// <summary>
        /// Reserve space for a data item
        /// </summary>
        /// <param name="Data">UTF8 string data</param>
        public void Size(string Data) => Length += (uint)(4 + Data.CountUTF8());

        /// <summary>
        /// Allocate a new data buffer for encoding with enough space for the 
        /// data items whose space has been reserved using the Size() method.
        /// </summary>
        public void Allocate() => Data = new byte[Length];

        /// <summary>
        /// Encode a 32 bit length
        /// </summary>
        /// <param name="Length">The length value to encode.</param>
        public void EncodeLength(uint Length) {
            Data[Pointer++] = (byte)((Length >> 24) & 0xff);
            Data[Pointer++] = (byte)((Length >> 16) & 0xff);
            Data[Pointer++] = (byte)((Length >> 8) & 0xff);
            Data[Pointer++] = (byte)(Length & 0xff);
            }

        /// <summary>
        /// Encode byte array.
        /// </summary>
        /// <param name="Input">Data to encode.</param>
        public void Encode(byte[] Input) {
            EncodeLength((uint)Input.Length);
            Array.Copy(Input, 0, Data, (int)Pointer, Input.Length);
            Pointer += (uint)(Input.Length);
            }

        /// <summary>
        /// Encode text
        /// </summary>
        /// <param name="Text">Data to encode.</param>
        public void Encode(string Text) {
            var Size = (uint)Text.CountUTF8();
            EncodeLength(Size);
            Text.ToUTF8(Data, (int)Pointer);
            Pointer += Size;
            }

        /// <summary>
        /// Decode a length value.
        /// </summary>
        /// <returns>The decoded length.</returns>
        public uint DecodeLength() {
            Assert.AssertFalse(Remain < 4, UnexpectedEnd.Throw);

            var Byte0 = Data[Pointer++];
            var Byte1 = Data[Pointer++];
            var Byte2 = Data[Pointer++];
            var Byte3 = Data[Pointer++];

            // Length encoding is bigendian
            uint Result = (uint)((Byte0 << 24) | Byte1 << 16 | Byte2 << 8 | Byte3);

            return Result;
            }

        /// <summary>
        /// Decode byte array item.
        /// </summary>
        /// <param name="Result">Decoded data</param>
        public void Decode(out byte[] Result) {
            var Bytes = DecodeLength();
            Result = new byte[Bytes];

            Array.Copy(Data, Pointer, Result, 0, Bytes);
            Pointer += Bytes;
            }

        /// <summary>
        /// Decode string data.
        /// </summary>
        /// <param name="Result">Decoded data.</param>
        public void Decode(out string Result) {
            var StringBuilder = new StringBuilder();
            var Bytes = DecodeLength();

            for (var i = 0; i < Bytes; i++) {
                var Byte = Data[Pointer++];
                StringBuilder.Append((char)Byte);
                }

            Result = StringBuilder.ToString();
            }
        }

    /// <summary>
    /// Base class for SSH data encoding.
    /// </summary>
    public abstract class SSHData {

        /// <summary>
        /// The tag for the data for use in files.
        /// </summary>
        public abstract string Tag { get; }

        /// <summary>
        /// Decode file containing a tagged data item.
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Parsed data.</returns>
        public static SSHData Decode(byte[] Data) {


            var DataBuffer = new DataBuffer(Data);
            DataBuffer.Decode(out string Tag2);

            if (Tag2 == SSH_RSA.TagID) {
                return new SSH_RSA(DataBuffer);
                }

            if (Tag2 == SSH_DSS.TagID) {
                return new SSH_RSA(DataBuffer);
                }

            return null;
            }

        /// <summary>
        /// Encode data item.
        /// </summary>
        /// <returns>The encoded data</returns>
        public abstract byte[] Encode();

        /// <summary>The key pair</summary>
        public virtual KeyPair KeyPair => null;    // Feature convert DSS keypair

        }

    /// <summary>
    /// RSA data in SSH format.
    /// </summary>
    public class SSH_RSA : SSHData {
        /// <summary>The SSH tag</summary>
        public override string Tag => "ssh-rsa";
        /// <summary>The SSH tag</summary>
        public static string TagID => "ssh-rsa";

        /// <summary>RSA public key exponent.</summary>
        public byte[] Exponent;
        /// <summary>RSA public key modulus.</summary>
        public byte[] Modulus;

        /// <summary>The RSA Key Pair</summary>
        public PkixPublicKeyRsa RSAPublicKey => new() {
            Modulus = Modulus,
            PublicExponent = Exponent
            };

        /// <summary>The key pair</summary>
        public override KeyPair KeyPair => KeyPairBaseRSA.Create(RSAPublicKey);   // NYI convert DSS keypair


        /// <summary>
        /// Construct an SSH_RSA object from an RSAKeyPair
        /// </summary>
        /// <param name="RSAKeyPair">Keypair to construct from</param>
        public SSH_RSA(KeyPairBaseRSA RSAKeyPair) {
            var PKIXPublicKeyRSA = RSAKeyPair.PkixPublicKeyRsa;
            Exponent = PKIXPublicKeyRSA.PublicExponent;
            Modulus = PKIXPublicKeyRSA.Modulus;
            }

        /// <summary>Encode structure</summary>
        /// <returns>Byte array representing structure.</returns>
        public override byte[] Encode() {
            var DataBuffer = new DataBuffer();

            DataBuffer.Size(Tag);
            DataBuffer.Size(Exponent);
            DataBuffer.Size(Modulus);

            DataBuffer.Allocate();

            DataBuffer.Encode(Tag);
            DataBuffer.Encode(Exponent);
            DataBuffer.Encode(Modulus);

            return DataBuffer.Data;
            }

        /// <summary>
        /// Constructor, decode the data item from the specified buffer.
        /// </summary>
        /// <param name="DataBuffer">Data input.</param>
        public SSH_RSA(DataBuffer DataBuffer) {
            DataBuffer.Decode(out Exponent);
            DataBuffer.Decode(out Modulus);
            }

        /// <summary>
        /// Constructor, decode the data item from the specified buffer.
        /// </summary>
        /// <param name="Data">Data input.</param>
        public SSH_RSA(byte[] Data) : this(new DataBuffer(Data)) {

            }
        }
    /// <summary>
    /// DSS private key in SSH format.
    /// </summary>
    public class SSH_DSS : SSHData {

        /// <summary>The SSH tag</summary>
        public override string Tag => "ssh-dss";

        /// <summary>The SSH tag</summary>
        public static string TagID => "ssh-dss";

        /// <summary>The parameter P</summary>
        public byte[] P;
        /// <summary>The parameter Q</summary>
        public byte[] Q;
        /// <summary>The parameter G</summary>
        public byte[] G;
        /// <summary>The parameter Y</summary>
        public byte[] Y;

        /// <summary>Encode structure</summary>
        /// <returns>Byte array representing structure.</returns>
        public override byte[] Encode() {
            var DataBuffer = new DataBuffer();

            DataBuffer.Size(Tag);
            DataBuffer.Size(P);
            DataBuffer.Size(Q);
            DataBuffer.Size(G);
            DataBuffer.Size(Y);

            DataBuffer.Allocate();

            DataBuffer.Encode(Tag);
            DataBuffer.Encode(P);
            DataBuffer.Encode(Q);
            DataBuffer.Encode(G);
            DataBuffer.Encode(Y);

            return DataBuffer.Data;
            }

        /// <summary>
        /// Constructor, decode the data item from the specified buffer.
        /// </summary>
        /// <param name="DataBuffer">Data input.</param>
        public SSH_DSS(DataBuffer DataBuffer) {
            DataBuffer.Decode(out P);
            DataBuffer.Decode(out Q);
            DataBuffer.Decode(out G);
            DataBuffer.Decode(out Y);
            }

        }
    }
