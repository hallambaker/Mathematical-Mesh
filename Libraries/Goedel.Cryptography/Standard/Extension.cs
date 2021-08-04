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
namespace Goedel.Cryptography.Standard {

    /// <summary>
    /// Utility class for addressing containers.
    /// </summary>
    public static class ContainerFramework {

        /// <summary>
        /// Prefix for test containers
        /// </summary>
        public const string PrefixTest = "TEST:mmm:";

        /// <summary>
        /// Prefix for production containers.
        /// </summary>
        public const string PrefixProduction = "mmm:";


        /// <summary>
        /// Container prefix
        /// </summary>
        /// <returns>The container prefix</returns>
        public static string Prefix() => Goedel.Cryptography.KeyPair.TestMode ? PrefixTest : PrefixProduction;

        /// <summary>
        /// Generate a key container name from a UDF fingerprint.
        /// </summary>
        /// <param name="UDF">UDF fingerprint value.</param>
        /// <returns>The container name.</returns>
        public static string Name(string UDF) => (Prefix() + UDF);
        }
    }
