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


namespace Goedel.Utilities;

/// <summary>Specify formatting options fdor conversion</summary>
public enum ConversionFormat {
    /// <summary>Apply no additional formatting</summary>
    None = 0,
    /// <summary>Add trailing base64 equals characters if required.</summary>
    Terminal = 1,
    /// <summary>Perform linewrapping at 72 charcters and insert 
    /// leading spaces as per an Internet Draft.</summary>
    Draft = 2,
    /// <summary>Perform hexadecimal spacing</summary>
    Hex = 4,
    /// <summary>Insert a dash every 4 output characters</summary>
    Dash4 = 6,
    /// <summary>Insert a dash every 5 output characters</summary>
    Dash5 = 8,
    /// <summary>Format according to PEM rules, i.e. wrap at exactly 64 chars.</summary>
    PEM64 = 16
    }


/// <summary>
/// Routines to convert binary data to various character representations.
/// Supported representations include Base16, Base32 and Base64 and common
/// variations thereof.
/// </summary>
public static partial class BaseConvert {



    #region // Conversion table constants

    /// <summary>Base16 conversion table</summary>
    public static readonly char[] BASE16 = new char[]{
                    '0', '1', '2', '3', '4', '5', '6', '7',
                    '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

    /// <summary>Base32 conversion table</summary>
    public static readonly char[] BASE32 = new char[]{
                    'A' , 'B', 'C', 'D', 'E', 'F', 'G', 'H',
                     'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
                     'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
                     'Y', 'Z', '2', '3', '4', '5', '6', '7'};

    /// <summary>Base32Hex conversion table</summary>
    public static readonly char[] BASE32HEX = new char[]{
                    '0' , '1', '2', '3', '4', '5', '6', '7',
                     '8', '9', 'A', 'B', 'C', 'D', 'E', 'F',
                     'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
                     'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V'};

    /// <summary>Base64URL conversion table</summary>
    public static readonly char[] BASE64URL = new char[]{
                    'A' , 'B', 'C', 'D', 'E', 'F', 'G', 'H',
                     'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
                     'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
                     'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f',
                     'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
                     'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
                     'w', 'x', 'y', 'z', '0', '1', '2', '3',
                     '4', '5', '6', '7', '8', '9', '-', '_'};

    /// <summary>Base64 conversion table</summary>
    public static readonly char[] BASE64 = new char[]{
                    'A' , 'B', 'C', 'D', 'E', 'F', 'G', 'H',
                     'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
                     'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
                     'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f',
                     'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
                     'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
                     'w', 'x', 'y', 'z', '0', '1', '2', '3',
                     '4', '5', '6', '7', '8', '9', '+', '/'};

    /// <summary>Base 16 conversion table</summary>
    public static readonly byte[] BASE16Value = new byte[] {
                    255, 255, 255, 255,  255, 255, 255, 255,   //  0-7
                    255, 255, 255, 255,  255, 255, 255, 255,   //  8-15
                    255, 255, 255, 255,  255, 255, 255, 255,   //  16-23
                    255, 255, 255, 255,  255, 255, 255, 255,   //  24-31
                    255, 255, 255, 255,  255, 255, 255, 255,   //  32-39
                    255, 255, 255, 255,  255, 255, 255, 255,   //  40
                      0,   1,   2,   3,    4,   5,   6,   7,   //  48
                      8,   9, 255, 255,  255, 255, 255, 255,   //  56
                    255,  10,  11,  12,   13,  14,  15, 255,   //  64
                    255, 255, 255, 255,  255, 255, 255, 255,   //  72
                    255, 255, 255, 255,  255, 255, 255, 255,   //  80-87
                    255, 255, 255, 255,  255, 255, 255, 255,   //  88
                    255,  10,  11,  12,   13,  14,  15, 255,   //  96
                    255, 255, 255, 255,  255, 255, 255, 255,   // 104
                    255, 255, 255, 255,  255, 255, 255, 255,   // 112
                    255, 255, 255, 255,  255, 255, 255, 255,   // 120-127
        };

    /// <summary>Base 32 conversion table</summary>
    public static readonly byte[] BASE32Value = new byte[] {
                    255, 255, 255, 255,  255, 255, 255, 255,   //  0-7
                    255, 255, 255, 255,  255, 255, 255, 255,   //  8-15
                    255, 255, 255, 255,  255, 255, 255, 255,   //  16-23
                    255, 255, 255, 255,  255, 255, 255, 255,   //  24-31
                    255, 255, 255, 255,  255, 255, 255, 255,   //  32-39
                    255, 255, 255, 255,  255, 255, 255, 255,   //  40
                    255, 255,  26,  27,   28,  29,  30,  31,   //  48
                    255, 255, 255, 255,  255, 255, 255, 255,   //  56
                    255,   0,   1,   2,   3,    4,   5,   6,   //  64
                      7,   8,   9,  10,  11,   12,  13,  14,   //  72
                     15,  16,  17,  18,  19,   20,  21,  22,   //  80
                     23,  24,  25, 255, 255,  255, 255, 255,   //  88
                    255,   0,   1,   2,   3,    4,   5,   6,   //  96
                      7,   8,   9,  10,  11,   12,  13,  14,   // 104
                     15,  16,  17,  18,  19,   20,  21,  22,   // 112
                     23,  24,  25, 255, 255,  255, 255, 255,    // 120-127
            };

    //
    // For reverse conversion permit either Base64 (+/) 
    // or Base64Url (-_) encodings of 62 and 63
    // 
    /// <summary>Base 64 conversion table</summary>
    public static readonly byte[] BASE64Value = new byte[] {
                    255, 255, 255, 255,  255, 255, 255, 255,   //  0-7
                    255, 255, 255, 255,  255, 255, 255, 255,   //  8-15
                    255, 255, 255, 255,  255, 255, 255, 255,   //  16-23
                    255, 255, 255, 255,  255, 255, 255, 255,   //  24-31
                    255, 255, 255, 255,  255, 255, 255, 255,   //  32-39
                    255, 255, 255,  62,  255,  62, 255,  63,   //  40
                     52,  53,  54,  55,   56,  57,  58,  59,   //  48
                     60,  61, 255, 255,  255, 255, 255, 255,   //  56
                    255,   0,   1,   2,    3,   4,   5,   6,   //  64
                      7,   8,   9,  10,   11,  12,  13,  14,   //  72
                     15,  16,  17,  18,   19,  20,  21,  22,   //  80-87
                     23,  24,  25, 255,  255, 255, 255,  63,   //  88
                    255,  26,  27,  28,   29,  30,  31,  32,   //  96
                     33,  34,  35,  36,   37,  38,  39,  40,   // 104
                     41,  42,  43,  44,   45,  46,  47,  48,   // 112
                     49,  50,  51, 255,  255, 255, 255, 255,   // 120-127
        };
    #endregion

    /// <summary>
    /// Convenience function returning the number of characters that will be returned by converting
    /// a string of <paramref name="precision"/> bits to Base32 encoding.
    /// </summary>
    /// <param name="precision">Output precision</param>
    /// <returns>The output length</returns>
    public static int OutputLength32(int precision) => (precision + 4) / 5;

    #region // Base16

    /// <summary>
    /// Return reusable stream converter to convert data input to 
    /// base 16 (hexadecimal) with uppercase characters 
    /// and write characters to specified stream in ASCII/UTF8.
    /// </summary>
    /// <param name="output">The stream to write the output to.</param>
    /// <param name="format">Specifies the output format</param>
    /// <returns>The stream converter</returns>
    public static IBytesToStream ToStreamBase16(
        this Stream output,
        ConversionFormat format = ConversionFormat.None) =>
            new StreamConvertBits(output, BASE16, 4, format);

    /// <summary>
    /// Return reusable stream converter to convert data input to 
    /// base 16 (hexadecimal) with uppercase characters 
    /// and write characters to specified stream in ASCII/UTF8.
    /// </summary>
    /// <param name="output">The stream to write the output to.</param>
    /// <param name="format">Specifies the output format</param>
    /// <returns>The stream converter</returns>
    public static IBytesToStream ToStreamBase16(
        this StringBuilder output,
        ConversionFormat format = ConversionFormat.None) =>
            new StringBuilderConvertBits(output, BASE16, 4, format);

    /// <summary>
    /// Convert data to base32 encoded string
    /// </summary>
    /// <param name="data">The data to convert</param>
    /// <param name="first">The index position of the first byte to convert.</param>
    /// <param name="length">The number of bytes to convert</param>
    /// <param name="Format">Specifies the output format</param>
    /// <returns>The encoded data</returns>
    public static string ToStringBase16(
            this byte[] data,
            int first = 0,
            int length = -1,
            ConversionFormat Format = ConversionFormat.None) => StringBuilderConvertBits.Convert(
                    data, BASE16, 4, Format, first, length);

    /// <summary>
    /// Convert data to base32 encoded string
    /// </summary>
    /// <param name="data">The data to convert</param>
    /// <param name="first">The index position of the first byte to convert.</param>
    /// <param name="length">The number of bytes to convert</param>
    /// <returns>The encoded data</returns>
    public static string ToStringBase16FormatHex(
            this byte[] data,
            int first = 0,
            int length = -1) => StringBuilderConvertBits.Convert(
                    data, BASE16, 4, ConversionFormat.Hex, first, length);


    /// <summary>
    /// Convert data to Base16 (hexadecimal) and append to the specified stringbuilder.
    /// </summary>
    /// <param name="stringBuilder">String builder to append data to</param>
    /// <param name="first">Position of first byte to send.</param>
    /// <param name="length">Position of last byte to send. If less than zero, read to end.</param>
    /// <param name="data">The data to be encoded.</param>
    /// <param name="Format">Specifies the output format</param>
    public static void ToStringBase16(
                this StringBuilder stringBuilder,
                byte[] data,
                int first = 0,
                int length = -1,
                ConversionFormat Format = ConversionFormat.None) => StringBuilderConvertBits.Append(data, BASE16, 4, Format, stringBuilder, first, length);

    #endregion
    #region // Base32

    /// <summary>
    /// Return reusable stream converter to convert data input to 
    /// base 32 with prefered (disambiguated) characters 
    /// and write characters to specified stream in ASCII/UTF8.
    /// </summary>
    /// <param name="output">The stream to write the output to.</param>
    /// <param name="format">Specifies the output format</param>
    /// <returns>The stream converter</returns>
    public static IBytesToStream ToStreamBase32(
        Stream output,
        ConversionFormat format = ConversionFormat.None) =>
            new StreamConvertBits(output, BASE32, 5, format);

    /// <summary>
    /// Return reusable stream converter to convert data input to 
    /// base 32 with prefered (disambiguated) characters 
    /// and write characters to specified stream in ASCII/UTF8.
    /// </summary>
    /// <param name="output">The stream to write the output to.</param>
    /// <param name="format">Specifies the output format</param>
    /// <param name="outputMax">The maximum number of significant bits in the output.</param>
    /// <returns>The stream converter</returns>
    public static IBytesToStream ToStreamBase32(
        StringBuilder output,
        ConversionFormat format = ConversionFormat.None,
        int outputMax = -1) =>
            new StringBuilderConvertBits(output, BASE32, 5, format, outputMax: outputMax);

    /// <summary>
    /// Convert data to base32 encoded string
    /// </summary>
    /// <param name="data">The data to convert</param>
    /// <param name="first">The index position of the first byte to convert.</param>
    /// <param name="length">The number of bytes to convert</param>
    /// <param name="format">Specifies the output format</param>
    /// <param name="outputMax">The maximum number of significant bits in the output.</param>
    /// <returns>The encoded data</returns>
    public static string ToStringBase32(
            this byte[] data,
            int first = 0,
            int length = -1,
            ConversionFormat format = ConversionFormat.None,
            int outputMax = -1) =>
                StringBuilderConvertBits.Convert(
                    data, BASE32, 5, format, first, length, outputMax: outputMax);

    /// <summary>
    /// Convert data to Base32 and append to the specified stringbuilder.
    /// </summary>
    /// <param name="stringBuilder">String builder to append data to</param>
    /// <param name="first">Position of first byte to send.</param>
    /// <param name="length">Position of last byte to send. If less than zero, read to end.</param>
    /// <param name="data">The data to be encoded.</param>
    /// <param name="format">Specifies the output format</param>
    /// <param name="outputMax">The maximum number of significant bits in the output.</param>
    public static void ToStringBase32(
                this StringBuilder stringBuilder,
                byte[] data,
                int first = 0,
                int length = -1,
                ConversionFormat format = ConversionFormat.None,
                int outputMax = -1) => StringBuilderConvertBits.Append(data, BASE32, 5, format, stringBuilder, first, length, outputMax: outputMax);

    #endregion
    #region // Base32Hex

    /// <summary>
    /// Return reusable stream converter to convert data input to 
    /// base 32 using the extended hexadecimal encoding
    /// and write characters to specified stream in ASCII/UTF8.
    /// </summary>
    /// <param name="output">The stream to write the output to.</param>
    /// <param name="format">Specifies the output format</param>
    /// <returns>The stream converter</returns>
    public static IBytesToStream ToStreamBase32Hex(
        Stream output,
        ConversionFormat format = ConversionFormat.None) =>
            new StreamConvertBits(output, BASE32HEX, 5, format);

    /// <summary>
    /// Return reusable stream converter to convert data input to 
    /// base 32 using the extended hexadecimal encoding
    /// and write characters to specified stream in ASCII/UTF8.
    /// </summary>
    /// <param name="output">The stream to write the output to.</param>
    /// <param name="format">Specifies the output format</param>
    /// <returns>The stream converter</returns>
    public static IBytesToStream ToStreamBase32Hex(
        StringBuilder output,
        ConversionFormat format = ConversionFormat.None) =>
            new StringBuilderConvertBits(output, BASE32HEX, 5, format);

    /// <summary>
    /// Convert data to base32Hex encoded string
    /// </summary>
    /// <param name="data">The data to convert</param>
    /// <param name="first">The index position of the first byte to convert.</param>
    /// <param name="length">The number of bytes to convert</param>
    /// <param name="Format">Specifies the output format</param>
    /// <returns>The encoded data</returns>
    public static string ToStringBase32Hex(
            this byte[] data,
            int first = 0,
            int length = -1,
            ConversionFormat Format = ConversionFormat.None) =>
                StringBuilderConvertBits.Convert(
                    data, BASE32HEX, 5, Format, first, length);

    /// <summary>
    /// Convert data to Base32 (with hexadecimal characters) and append to the specified stringbuilder.
    /// </summary>
    /// <param name="stringBuilder">String builder to append data to</param>
    /// <param name="first">Position of first byte to send.</param>
    /// <param name="length">Position of last byte to send. If less than zero, read to end.</param>
    /// <param name="data">The data to be encoded.</param>
    /// <param name="format">Specifies the output format</param>
    public static void ToStringBase32Hex(
                this StringBuilder stringBuilder,
                byte[] data,
                int first = 0,
                int length = -1,
                ConversionFormat format = ConversionFormat.None) => StringBuilderConvertBits.Append(data, BASE32HEX, 5, format, stringBuilder, first, length);

    #endregion
    #region // Base64

    /// <summary>
    /// Return reusable stream converter to convert data input to 
    /// base 64 (original) characters
    /// and write characters to specified stream in ASCII/UTF8.
    /// </summary>
    /// <param name="output">The stream to write the output to.</param>
    /// <param name="format">Specifies the output format</param>
    /// <returns>The stream converter</returns>
    public static IBytesToStream ToStreamBase64(
        Stream output,
        ConversionFormat format = ConversionFormat.None) =>
            new StreamConvertBits(output, BASE64, 6, format);

    /// <summary>
    /// Return reusable stream converter to convert data input to 
    /// base 64 (original) characters
    /// and write characters to specified stream in ASCII/UTF8.
    /// </summary>
    /// <param name="output">The stream to write the output to.</param>
    /// <param name="format">Specifies the output format</param>
    /// <returns>The stream converter</returns>
    public static IBytesToStream ToStreamBase64(
        StringBuilder output,
        ConversionFormat format = ConversionFormat.None) =>
            new StringBuilderConvertBits(output, BASE64, 6, format);

    /// <summary>
    /// Convert data to base64 encoded string
    /// </summary>
    /// <param name="data">The data to convert</param>
    /// <param name="first">The index position of the first byte to convert.</param>
    /// <param name="length">The number of bytes to convert</param>
    /// <param name="format">Specifies the output format</param>
    /// <returns>The encoded data</returns>
    public static string ToStringBase64(
            this byte[] data,
            int first = 0,
            int length = -1,
            ConversionFormat format = ConversionFormat.None) => StringBuilderConvertBits.Convert(
                    data, BASE64, 6, format, first, length);

    /// <summary>
    /// Convert data to Base64 and append to the specified stringbuilder.
    /// </summary>
    /// <param name="stringBuilder">String builder to append data to</param>
    /// <param name="first">Position of first byte to send.</param>
    /// <param name="length">Position of last byte to send. If less than zero, read to end.</param>
    /// <param name="data">The data to be encoded.</param>
    /// <param name="format">Specifies the output format</param>
    public static void ToStringBase64(
                this StringBuilder stringBuilder,
                byte[] data,
                int first = 0,
                int length = -1,
                ConversionFormat format = ConversionFormat.None) => 
        StringBuilderConvertBits.Append(data, BASE64, 6, format, stringBuilder, first, length);

    #endregion
    #region // Base64Url

    /// <summary>
    /// Return reusable stream converter to convert data input to 
    /// base 64 URL-safe characters 
    /// and write characters to specified stream in ASCII/UTF8.
    /// </summary>
    /// <param name="output">The stream to write the output to.</param>
    /// <param name="format">Specifies the output format</param>
    /// <returns>The stream converter</returns>
    public static IBytesToStream ToStreamBase64Url(
        Stream output,
        ConversionFormat format = ConversionFormat.None) =>
            new StreamConvertBits(output, BASE64URL, 6, format);

    /// <summary>
    /// Return reusable stream converter to convert data input to 
    /// base 64 URL-safe characters 
    /// and write characters to specified stream in ASCII/UTF8.
    /// </summary>
    /// <param name="output">The stream to write the output to.</param>
    /// <param name="format">Specifies the output format</param>
    /// <returns>The stream converter</returns>
    public static IBytesToStream ToStreamBase64Url(
        StringBuilder output,
        ConversionFormat format = ConversionFormat.None) =>
            new StringBuilderConvertBits(output, BASE64URL, 6, format);

    /// <summary>
    /// Convert data to base64URL encoded string
    /// </summary>
    /// <param name="data">The data to convert</param>
    /// <param name="first">The index position of the first byte to convert.</param>
    /// <param name="length">The number of bytes to convert</param>
    /// <param name="format">Specifies the output format</param>
    /// <param name="outputCol">The initial ouput column</param>
    /// <param name="outputMax">The maximum output width.</param>
    /// <returns>The encoded data</returns>
    public static string ToStringBase64url(
            this byte[] data,
            int first = 0,
            int length = -1,
            ConversionFormat format = ConversionFormat.None,
            int outputCol = 0,
            int outputMax = 70) =>
                StringBuilderConvertBits.Convert(data, BASE64URL, 6, format, first, length,
                    outputCol, outputMax);

    /// <summary>
    /// Convert data to Base64URL and append to the specified stringbuilder.
    /// </summary>
    /// <param name="stringBuilder">String builder to append data to</param>
    /// <param name="first">Position of first byte to send.</param>
    /// <param name="length">Position of last byte to send. If less than zero, read to end.</param>
    /// <param name="data">The data to be encoded.</param>
    /// <param name="Format">Specifies the output format</param>
    public static void ToStringBase64URL(
                this StringBuilder stringBuilder,
                byte[] data,
                int first = 0,
                int length = -1,
                ConversionFormat Format = ConversionFormat.None) => StringBuilderConvertBits.Append(data, BASE64URL, 6, Format, stringBuilder, first, length);

    #endregion




    /*
     * These routines still use the old mechanism
     */


    /// <summary>
    /// Convert data to Base32HS string. This is probably not necessary as 
    /// the ticket mechanism needs to be overhauled anyway.
    /// </summary>
    /// <param name="data">The data to convert</param>
    /// <param name="length">The maximum number of characters in the output string</param>
    /// <returns>The resulting string.</returns>
    public static string ToStringBase32hs(this byte[] data, int length) =>
        ToStringBase32(data, format: ConversionFormat.Dash4, length: length);


    /// <summary>
    /// Convert Base64/Base64URL character string data to binary data. Note
    /// that because the two character sets are unambiguous, a single conversion
    /// function converts both types of data.
    /// </summary>
    /// <param name="data">The string to convert</param>
    /// <returns>The resulting binary data.</returns>
    public static byte[] FromBase64(this string data) =>
        StreamConvertString.Convert(BASE64Value, 6, data);

    /// <summary>
    /// Return a streaming converter to 
    /// convert Base32 character string data to binary data.
    /// </summary>
    /// <returns>The resulting binary data.</returns>
    public static IStringToStream FromBase32() =>
        new StreamConvertString(BASE32Value, 6);

    /// <summary>
    /// Convert Base32 character string data to binary data.
    /// </summary>
    /// <param name="data">The string to convert</param>
    /// <returns>The resulting binary data.</returns>
    public static byte[] FromBase32(this string data) =>
        StreamConvertString.Convert(BASE32Value, 5, data);

    /// <summary>
    /// Return a streaming converter to 
    /// convert Base32 character string data to binary data.
    /// </summary>
    /// <returns>The resulting binary data.</returns>
    public static IStringToStream FromBase16() =>
        new StreamConvertString(BASE16Value, 6);

    /// <summary>
    /// Convert Base16 character string data to binary data.
    /// </summary>
    /// <param name="data">The string to convert</param>
    /// <returns>The resulting binary data.</returns>
    public static byte[] FromBase16(this string data) =>
        StreamConvertString.Convert(BASE16Value, 4, data);

    }
