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
/// Conversion class to and from RFC3339 DateTime representation.
/// </summary>
public static class RFC3339 {

    /// <summary>
    /// If C is a digit (0-9), return the numeric value. Otherwise return -1
    /// </summary>
    /// <param name="C">Character to convert</param>
    /// <returns>Integer value of character</returns>
    public static int Digit(char C) {
        var Result = C - '0';
        return (Result >= 0 & Result < 10) ? Result : -1;
        }

    static void Accumulate(ref int Total, char C) {
        var Result = Digit(C);
        if (Result < 0) {
            throw new Exception();
            }
        Total = Total * 10 + Result;
        }


    static void Test(char v1, char v2) {
        if (v1 != v2) {
            throw new Exception();
            }
        }

    /// <summary>
    /// Format a DateTime value in RFC3339 format.
    /// </summary>
    /// <param name="DateTime">The time to convert.</param>
    /// <returns>The converted date time</returns>
    public static string ToRFC3339(this DateTime DateTime) => DateTime.ToString("yyyy-MM-dd'T'HH:mm:ssZ");

    /// <summary>
    /// Format a DateTime value in RFC3339 format.
    /// </summary>
    /// <param name="DateTime">The time to convert.</param>
    /// <returns>The converted date time</returns>
    public static string ToRFC3339(this DateTime? DateTime) => DateTime == null ? "null" :
        ((DateTime)DateTime).ToString("yyyy-MM-dd'T'HH:mm:ssZ");



    /// <summary>
    /// Parse an RFC3339 format date time value.
    /// </summary>
    /// <param name="Text">The date to parse</param>
    /// <returns>The date value</returns>
    public static DateTime FromRFC3339(this string Text) {
        int Index = 0;

        try {
            var Year = 0;
            Accumulate(ref Year, Text[Index++]);
            Accumulate(ref Year, Text[Index++]);
            Accumulate(ref Year, Text[Index++]);
            Accumulate(ref Year, Text[Index++]);
            Test('-', Text[Index++]);
            var Month = 0;
            Accumulate(ref Month, Text[Index++]);
            Accumulate(ref Month, Text[Index++]);
            Test('-', Text[Index++]);
            var Day = 0;
            Accumulate(ref Day, Text[Index++]);
            Accumulate(ref Day, Text[Index++]);
            Test('T', Text[Index++]);
            var Hour = 0;
            Accumulate(ref Hour, Text[Index++]);
            Accumulate(ref Hour, Text[Index++]);
            Test(':', Text[Index++]);
            var Minute = 0;
            Accumulate(ref Minute, Text[Index++]);
            Accumulate(ref Minute, Text[Index++]);
            Test(':', Text[Index++]);
            var Seconds = 0;
            Accumulate(ref Seconds, Text[Index++]);
            Accumulate(ref Seconds, Text[Index++]);
            Test('Z', Text[Index++]);

            return new DateTime(Year, Month, Day, Hour, Minute, Seconds, DateTimeKind.Utc);

            }
        catch {
            return DateTime.MinValue;
            }

        }


    }
