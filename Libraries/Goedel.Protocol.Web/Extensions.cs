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

using System.Runtime.CompilerServices;

namespace Goedel.Protocol.Web;


/// <summary>
/// Extensions class
/// </summary>
public static partial class WebExtensions {

    /// <summary>
    /// Encode <paramref name="data"/> using the HTTP form encoding.
    /// </summary>
    /// <param name="data">The object to encode.</param>
    /// <returns>The encoded data.</returns>
    public static byte[] GetAsFormEncoding(this JsonObject data) {
        using var buffer = new MemoryStream();
        using var writer = new StreamWriter(buffer);

        foreach (var item in data._Binding.Properties) {
            switch (item.Value) {
                case PropertyString propertyString: {
                    var value = propertyString.Get(data);
                    writer.Write('&');
                    writer.Write(propertyString.Tag);
                    writer.Write('=');
                    writer.WriteLine(WebUtility.UrlEncode(value));
                    break;
                    }
                }
            }

        return buffer.ToArray();
        }

    /// <summary>
    /// Extract non-null fields from <paramref name="data"/> and return a set of 
    /// tag value pairs for encoding.
    /// </summary>
    /// <param name="data">The object to encode.</param>
    /// <returns>The encoded data.</returns>
    public static IEnumerable<KeyValuePair<String, String>> GetAsKeyValue(this JsonObject data) {
        using var buffer = new MemoryStream();
        using var writer = new StreamWriter(buffer);

        foreach (var item in data._Binding.Properties) {
            switch (item.Value) {
                case PropertyString propertyString: {
                    var value = propertyString.Get(data);
                    if (value != null) {
                        yield return new KeyValuePair<string, string>(propertyString.Tag, value);
                        }
                    break;
                    }
                }
            }
        }

    /// <summary>
    /// Extract non-null fields from <paramref name="data"/> and append the result
    /// to <paramref name="uri"/> as a URI query string.
    /// </summary>
    /// <param name="data">The object to encode.</param>
    /// <param name="uri">The base URI for the query.</param>
    /// <returns>The encoded data.</returns>
    public static string GetAsUrlQuery(this JsonObject data, string uri=null) {
        var builder = new StringBuilder();

        builder.Append(uri ?? "");
        bool first = true;
        foreach (var item in data._Binding.Properties) {
            switch (item.Value) {

                case PropertyString propertyString: {
                    var value = propertyString.Get(data);

                    builder.Append(first ? '?' : '&');
                    first = false;

                    builder.Append(propertyString.Tag);
                    builder.Append('=');
                    builder.Append(WebUtility.UrlEncode(value));
                    break;
                    }
                }
            }

        return builder.ToString();

        }


    }
