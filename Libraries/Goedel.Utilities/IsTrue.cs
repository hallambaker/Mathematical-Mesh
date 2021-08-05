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
namespace Goedel.Utilities {


    public static partial class Extension {

        /// <summary>
        /// Tell compiler that an object is reserved.
        /// </summary>
        /// <param name="o">Object to reserve.</param>
        /// <returns>true if the object is not null, false otherwise.</returns>
        public static bool Keep(this object o) => o != null;

        /// <summary>
        /// Tell compiler that an object is reserved for future use.
        /// </summary>
        /// <param name="o">Object to reserve.</param>
        /// <returns>true if the object is not null, false otherwise.</returns>
        public static bool Future(this object o) => o != null;


        /// <summary>
        /// You might think this code is unnecessary but it is actually very 
        /// important. Don't tamper with it unless you understand how the
        /// different storage classes affect the moves permitted by the optimizer.
        /// </summary>
        static bool AlwaysTrue = true; // DO NOT DELETE

        /// <summary>
        /// Convert constant truth value to static. This allows the programmer 
        /// to prevent unreachable code being removed.
        /// </summary>
        /// <param name="Value">The test value</param>
        /// <returns>True if the test value is true, false otherwise.</returns>
        public static bool True(this bool Value) => (Value & AlwaysTrue);

        /// <summary>
        /// Convert constant truth value to static. This allows the programmer 
        /// to prevent unreachable code being removed.
        /// </summary>
        /// <param name="Value">The test value</param>
        /// <returns>False if the test value is true, true otherwise.</returns>
        public static bool False(this bool Value) => (!Value & AlwaysTrue);
        }
    }
