using System.Collections.Generic;
using System.IO;

namespace Goedel.Mesh.Shell {

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
    }
