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

    /// <summary>Returns an enumerator for <paramref name="item"/> if not null
    /// or a dummy enumerator that always returns a zero length list.</summary>
    /// <typeparam name="T">The enumerable type.</typeparam>
    /// <param name="item">An enumerable object.</param>
    /// <returns>The enumerator.</returns>
    public static IEnumerable<T> IfEnumerable<T>(this IEnumerable<T>? item) =>
        new SafeEnumerable<T>(item);

    /// <summary>Returns true if <paramref name="item"/> is null or empty.</summary>
    /// <typeparam name="T">The dictionary key type.</typeparam>
    /// <typeparam name="S">The dictionary value type.</typeparam>
    /// <param name="item"></param>
    /// <returns>true if <paramref name="item"/> is null or empty, otherwise false.</returns>
    public static bool IsEmpty<T,S>(this Dictionary<T,S>? item) =>
        (item == null) || (item.Count == 0);

    /// <summary>Returns true if <paramref name="item"/> is null or empty.</summary>
    /// <typeparam name="T">The list type.</typeparam>
    /// <param name="item"></param>
    /// <returns>true if <paramref name="item"/> is null or empty, otherwise false.</returns>
    public static bool IsEmpty<T>(this List<T>? item) =>
        (item == null) || (item.Count == 0);

    /// <summary>Returns true if <paramref name="item"/> is null or empty.</summary>
    /// <typeparam name="T">The array type.</typeparam>
    /// <param name="item"></param>
    /// <returns>true if <paramref name="item"/> is null or empty, otherwise false.</returns>
    public static bool IsEmpty<T>(this T[]? item) =>
            (item == null) || (item.Length == 0);
    }

/// <summary>Safe enumerator of type <typeparamref name="T"/>.</summary>
/// <typeparam name="T">The enumerable type.</typeparam>
public class SafeEnumerable<T> : IEnumerable<T> {

    IEnumerable<T>? enumerable;

    /// <summary>Constructor, returns a new instance for the enumerable <paramref name="item"/>.</summary>
    /// <param name="item">The object to enumerate.</param>
    public SafeEnumerable(IEnumerable<T>? item) {
        enumerable = item;
        }

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator() => enumerable is null ?
        new NullEnumerator<T>() : enumerable.GetEnumerator();

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
        }
    }




/// <summary>Null enumerator of type <typeparamref name="T"/>.</summary>
/// <typeparam name="T">The enumerable type.</typeparam>

public class NullEnumerator<T> : IEnumerator<T> {

    /// <summary>The current value, this is always the default value for 
    /// <typeparamref name="T"/>.</summary>
    public T Current => default;

    /// <inheritdoc/>
    object IEnumerator.Current => Current;

    /// <summary>Constructor, returns a new instance.</summary>
    public NullEnumerator() {
        }

    /// <inheritdoc/>
    public void Dispose() {
        }

    /// <inheritdoc/>
    public bool MoveNext() => false;

    /// <inheritdoc/>
    public void Reset() {
        }
    }

