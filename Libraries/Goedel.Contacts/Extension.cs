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

using Goedel.Cryptography;
using Goedel.Discovery;

using System.Runtime.CompilerServices;

namespace Goedel.Contacts;

/// <summary>
/// Extension methods
/// </summary>
public static partial class Extension {


    /// <summary>Inverse dictionary lookup, return the first key <paramref name="key"/> that has the value 
    /// <paramref name="value"/> in the dictionary <paramref name="keyValuePairs"/>.</summary> 
    /// <param name="keyValuePairs">The key value pairs.</param>
    /// <param name="value">The value to find.</param>
    /// <param name="key">The returned key, null if not found.</param>
    /// <returns>True if the value was found, otherwise false.</returns>
    public static bool TryGetKey (
                this Dictionary<string, string> keyValuePairs, 
                string value, 
                out string? key) {
        foreach (var pair in keyValuePairs) {
            if (pair.Value == value) {
                key = pair.Key;
                return true;
                }
            }
        key = null;
        return false;

        }

    }
