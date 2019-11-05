using System.Collections.Generic;
using System.IO;

namespace Goedel.Mesh.Shell {
    public static class MimeMapping {

        public static Dictionary<string, string> MimeMap = new Dictionary<string, string> {
                { ".saml", "application/samlassertion+xml"},
                { ".dns", "application/dns"},
                { ".json", "application/json"},
                { ".pdf", "application/pdf"},
                { ".pfx", "application/pkcs12"},
                { ".cer", "application/pkix-cert"},
                { ".crt", "application/pkix-cert"},
                { ".nb", "application/mathematica"},
                { ".ma", "application/mathematica"},
                { ".mb", "application/mathematica"},
                { ".doc", "application/msword"},
                { ".docx", "application/msword"},
                { ".csv", "	text/csv"},
                { ".csh", "application/x-csh"},
                { ".css", "	text/css"},
                { ".htm", "text/html"},
                { ".html", "text/html"},
                { ".txt", "text/plain"}
            };


        public static string GetMimeMapping(string fileName) {
            var extension = Path.GetExtension(fileName).ToLower();
            var found = MimeMap.TryGetValue(extension, out var value);
            return found ? value : null;
            }
        }
    }
