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

using System.Collections;

namespace Goedel.Utilities;


/// <summary>
/// Extensions class relating to enumerable items
/// </summary>
public static class Enumerable {


    public static IEnumerable<T> IfEnumerable<T>(this IEnumerable<T>? item) =>
        new SafeEnumerable<T>(item);


    }

public class SafeEnumerable<T> : IEnumerable<T> {

    IEnumerable<T>? enumerable;
    public SafeEnumerable(IEnumerable<T>? item) {
        enumerable = item;
        }

    public IEnumerator<T> GetEnumerator() => enumerable is null ?
        new NullEnumerator<T>() : enumerable.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
        }
    }






public class NullEnumerator<T> : IEnumerator<T> {

    public T Current => default;

    object IEnumerator.Current => Current;

    public NullEnumerator() {
        }

    public void Dispose() {
        }

    public bool MoveNext() => false;

    public void Reset() {
        }
    }

