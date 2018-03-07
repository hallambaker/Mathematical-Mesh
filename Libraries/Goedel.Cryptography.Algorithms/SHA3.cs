// The MIT License (MIT)
//
// Copyright (c) 2013 Mohammad Mahdi Saffari <blog.saffarionline.net>
//
// Permission is hereby granted, free of charge, to any person obtaining 
// a copy of this software and associated documentation files ("the Software"), 
// to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the 
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included 
// in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS 
// OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.

using System;
using System.Runtime;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace Goedel.Cryptography.Algorithms {
    /// <summary>
    /// Computes the <see cref="T:System.Security.Cryptography.SHA3" /> hash for the input data.
    /// </summary>
    [ComVisible(true)]
	public abstract class SHA3 : HashAlgorithm {

		static SHA3() {
			CryptoConfig.AddAlgorithm(typeof(SHA3Managed), "SHA3", "SHA3Managed", "SHA-3", "System.Security.Cryptography.SHA3");
			CryptoConfig.AddOID("0.9.2.0", "SHA3", "SHA3Managed", "SHA-3", "System.Security.Cryptography.SHA3");
		}

		/// <summary>
		/// Initializes a new instance of <see cref="T:System.Security.Cryptography.SHA3" />.
		/// </summary>
		protected SHA3() {
			base.HashSizeValue = 512;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="hashBitLength"></param>
		protected SHA3(int hashBitLength) {
			if (hashBitLength != 224 && hashBitLength != 256 && hashBitLength != 384 && hashBitLength != 512) {
                throw new ArgumentException("hashBitLength must be 224, 256, 384, or 512", "hashBitLength");
                }

            Initialize();
			HashSizeValue = hashBitLength;
			switch (hashBitLength) {
				case 224:
					KeccakR = 1152;
					break;
				case 256:
					KeccakR = 1088;
					break;
				case 384:
					KeccakR = 832;
					break;
				case 512:
					KeccakR = 576;
					break;
			}
			RoundConstants = new ulong[]
            {
                0x0000000000000001UL,
                0x0000000000008082UL,
                0x800000000000808aUL,
                0x8000000080008000UL,
                0x000000000000808bUL,
                0x0000000080000001UL,
                0x8000000080008081UL,
                0x8000000000008009UL,
                0x000000000000008aUL,
                0x0000000000000088UL,
                0x0000000080008009UL,
                0x000000008000000aUL,
                0x000000008000808bUL,
                0x800000000000008bUL,
                0x8000000000008089UL,
                0x8000000000008003UL,
                0x8000000000008002UL,
                0x8000000000000080UL,
                0x000000000000800aUL,
                0x800000008000000aUL,
                0x8000000080008081UL,
                0x8000000000008080UL,
                0x0000000080000001UL,
                0x8000000080008008UL
            };
		}

		/// <summary>Creates an instance of the default implementation of <see cref="T:System.Security.Cryptography.SHA3" />.</summary>
		/// <returns>A new instance of <see cref="T:System.Security.Cryptography.SHA3" />.</returns>
		/// <exception cref="T:System.Reflection.TargetInvocationException">The algorithm was used with Federal Information Processing Standards (FIPS) mode enabled, but is not FIPS compatible.</exception>
		/// <PermissionSet>
		/// <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" />
		/// </PermissionSet>
		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static new SHA3 Create() {
			return Create("System.Security.Cryptography.SHA3");
		}

		/// <summary>Creates an instance of a specified implementation of <see cref="T:System.Security.Cryptography.SHA3" />.</summary>
		/// <returns>A new instance of <see cref="T:System.Security.Cryptography.SHA3" /> using the specified implementation.</returns>
		/// <param name="hashName">The name of the specific implementation of <see cref="T:System.Security.Cryptography.SHA3" /> to be used. </param>
		/// <exception cref="T:System.Reflection.TargetInvocationException">The algorithm described by the <paramref name="hashName" /> parameter was used with Federal Information Processing Standards (FIPS) mode enabled, but is not FIPS compatible.</exception>
		public static new SHA3 Create(string hashName) {
			return (SHA3)CryptoConfig.CreateFromName(hashName);
		}

		#region " Hash Algorithm Members "
		/// <summary>
		/// 
		/// </summary>
		/// <param name="array"></param>
		/// <param name="ibStart"></param>
		/// <param name="cbSize"></param>
		protected override void HashCore(byte[] array, int ibStart, int cbSize) {
			if (array == null) {
                throw new ArgumentNullException("array");
                }
            if (ibStart < 0) {
                throw new ArgumentOutOfRangeException("ibStart");
                }
            if (cbSize > array.Length) {
                throw new ArgumentOutOfRangeException("cbSize");
                }
            if (ibStart + cbSize > array.Length) {
                throw new ArgumentOutOfRangeException("ibStart or cbSize");
                }
            }

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected override byte[] HashFinal() {
			return this.Hash;
		}

		/// <summary>
		/// 
		/// </summary>
		public override void Initialize() {
			buffLength = 0;
			state = new ulong[5 * 5];//1600 bits
			HashValue = null;
		}
		#endregion

		#region Implementation
		internal const int KeccakB = 1600;
		internal const int KeccakNumberOfRounds = 24;
		internal const int KeccakLaneSizeInBits = 8 * 8;
		internal readonly ulong[] RoundConstants;
		internal ulong[] state;
        internal byte[] buffer;
        internal int buffLength;
		//protected new byte[] HashValue;
		//protected new int HashSizeValue;
		internal int keccakR;

		internal int KeccakR {
			get {
				return keccakR;
			}
			set {
				keccakR = value;
			}
		}

        /// <summary>
        /// 
        /// </summary>
        public int SizeInBytes => KeccakR / 8;

        /// <summary>
        /// 
        /// </summary>
        public int HashByteLength => HashSizeValue / 8;

        /// <summary>
        /// 
        /// </summary>
        public override bool CanReuseTransform => true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        protected ulong ROL(ulong a, int offset) {
			return (((a) << ((offset) % KeccakLaneSizeInBits)) ^ ((a) >> (KeccakLaneSizeInBits - ((offset) % KeccakLaneSizeInBits))));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="array"></param>
		/// <param name="offset"></param>
		/// <param name="count"></param>
		protected void AddToBuffer(byte[] array, ref int offset, ref int count) {
			int amount = Math.Min(count, buffer.Length - buffLength);
			Buffer.BlockCopy(array, offset, buffer, buffLength, amount);
			offset += amount;
			buffLength += amount;
			count -= amount;
		}

        /// <summary>
        /// 
        /// </summary>
        public override byte[] Hash => HashValue;

        /// <summary>
        /// 
        /// </summary>
        public override int HashSize => HashSizeValue;
        #endregion

        }
}
