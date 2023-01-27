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


/// <summary>
/// Conversion class to and from RFC3339 dateTime representation.
/// </summary>
public static class Utilities {

    /// <summary>
    /// Return the earliest time instant in the presented parameters.
    /// </summary>
    /// <param name="first">First parameter.</param>
    /// <param name="others">Remaining parameters.</param>
    /// <returns>The earliest occurring time instant.</returns>
    public static DateTime Earliest(this DateTime first,
            params DateTime[] others) {
        foreach (var other in others) {
            if (other < first) {
                first = other;
                }
            }
        return first;
        }

    /// <summary>
    /// Return the earliest time instant in the presented parameters.
    /// </summary>
    /// <param name="first">First parameter.</param>
    /// <param name="others">Remaining parameters.</param>
    /// <returns>The earliest occurring time instant.</returns>
    public static DateTime Latest(this DateTime first,
            params DateTime[] others) {
        foreach (var other in others) {
            if (other > first) {
                first = other;
                }
            }
        return first;
        }

    /// <summary>
    /// If C is a digit (0-9), return the numeric value. Otherwise return -1
    /// </summary>
    /// <param name="C">Character to convert</param>
    /// <returns>Integer value of character</returns>
    public static int Digit(char C) {
        var Result = C - '0';
        return (Result >= 0 & Result < 10) ? Result : -1;
        }


    // Hack: This should be rewritten so that it returns a boolean instead of
    // throwing an exception.
    static void Accumulate(ref int total, char C) {
        var Result = Digit(C);
        if (Result < 0) {
            throw new Exception();
            }
        total = total * 10 + Result;
        }


    static void Test(char v1, char v2) {
        if (v1 != v2) {
            throw new Exception();
            }
        }

    /// <summary>
    /// Format a dateTime value in RFC3339 format.
    /// </summary>
    /// <param name="dateTime">The time to convert.</param>
    /// <returns>The converted date time</returns>
    public static string ToRFC3339(this System.DateTime dateTime) => dateTime.ToString("yyyy-MM-dd'T'HH:mm:ssZ");

    /// <summary>
    /// Format a dateTime value in RFC3339 format.
    /// </summary>
    /// <param name="dateTime">The time to convert.</param>
    /// <returns>The converted date time</returns>
    public static string ToRFC3339(this System.DateTime? dateTime) => dateTime == null ? "null" :
        ((System.DateTime)dateTime).ToString("yyyy-MM-dd'T'HH:mm:ssZ");



    /// <summary>
    /// Parse an RFC3339 format date time value.
    /// </summary>
    /// <param name="text">The date to parse</param>
    /// <returns>The date value</returns>
    public static System.DateTime FromRFC3339(this string text) {
        int Index = 0;

        try {
            var Year = 0;
            Accumulate(ref Year, text[Index++]);
            Accumulate(ref Year, text[Index++]);
            Accumulate(ref Year, text[Index++]);
            Accumulate(ref Year, text[Index++]);
            Test('-', text[Index++]);
            var Month = 0;
            Accumulate(ref Month, text[Index++]);
            Accumulate(ref Month, text[Index++]);
            Test('-', text[Index++]);
            var Day = 0;
            Accumulate(ref Day, text[Index++]);
            Accumulate(ref Day, text[Index++]);
            Test('T', text[Index++]);
            var Hour = 0;
            Accumulate(ref Hour, text[Index++]);
            Accumulate(ref Hour, text[Index++]);
            Test(':', text[Index++]);
            var Minute = 0;
            Accumulate(ref Minute, text[Index++]);
            Accumulate(ref Minute, text[Index++]);
            Test(':', text[Index++]);
            var Seconds = 0;
            Accumulate(ref Seconds, text[Index++]);
            Accumulate(ref Seconds, text[Index++]);
            Test('Z', text[Index++]);

            return new System.DateTime(Year, Month, Day, Hour, Minute, Seconds, DateTimeKind.Utc);

            }
        catch {
            return System.DateTime.MinValue;
            }

        }


    /// <summary>
    /// Attempt to parse the value <paramref name="text"/> as an RFC3339 encoded 
    /// value and return <code>true</code> if successful, otherwise false.
    /// The parsed value is returned in in <paramref name="dateTime"/>.
    /// </summary>
    /// <param name="text">The text to parse</param>
    /// <param name="dateTime">The parsed value if successful, otherwise 
    /// the default value for the type.</param>
    /// <returns>True if the parse succeeded, otherwise false.</returns>
    public static bool TryParseRFC3339(this string text, out DateTime dateTime) {
        try {
            dateTime = FromRFC3339(text);
            return true;
            }
        catch {
            dateTime = default;
            return false;
            }
        }

    }
