﻿#region // Copyright - MIT License
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


namespace Goedel.Mesh.Shell;

/// <summary>
/// Convert between IANA content types and file extensions.
/// </summary>
public static class MimeMapping {

    ///<summary>Dictionary mapping file extension to IANA content type.</summary>
    public static Dictionary<string, string> MimeMap = new() {
            { ".saml", "application/samlassertion+xml" },
            { ".dns", "application/dns" },
            { ".json", "application/json" },
            { ".pdf", "application/pdf" },
            { ".pfx", "application/pkcs12" },
            { ".cer", "application/pkix-cert" },
            { ".crt", "application/pkix-cert" },
            { ".nb", "application/mathematica" },
            { ".ma", "application/mathematica" },
            { ".mb", "application/mathematica" },
            { ".doc", "application/msword" },
            { ".docx", "application/msword" },
            { ".csv", "	text/csv" },
            { ".csh", "application/x-csh" },
            { ".css", "	text/css" },
            { ".htm", "text/html" },
            { ".html", "text/html" },
            { ".txt", "text/plain" }
        };

    /// <summary>
    /// Returns the IANA content type for <paramref name="fileName"/>.
    /// </summary>
    /// <param name="fileName">The file to process.</param>
    /// <returns>The IANA content type if found.</returns>
    public static string GetMimeMapping(string fileName) {
        var extension = Path.GetExtension(fileName).ToLower();
        var found = MimeMap.TryGetValue(extension, out var value);
        return found ? value : null;
        }
    }
