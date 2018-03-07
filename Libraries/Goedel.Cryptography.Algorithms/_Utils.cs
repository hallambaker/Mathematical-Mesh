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


using System.Security.Cryptography;

namespace Goedel.Cryptography.Algorithms {
    internal static class _Utils {
		private static volatile RNGCryptoServiceProvider _rng = null;

		//[MethodImpl(MethodImplOptions.InternalCall)]
		//internal static extern bool _ProduceLegacyHmacValues();

		internal static RNGCryptoServiceProvider StaticRandomNumberGenerator {
			get {
				if (_rng == null) {
					_rng = new RNGCryptoServiceProvider();
				}
				return _rng;
			}
		}

		internal static byte[] GenerateRandom(int keySize) {
			byte[] data = new byte[keySize];
			StaticRandomNumberGenerator.GetBytes(data);
			return data;
		}


	}
}
