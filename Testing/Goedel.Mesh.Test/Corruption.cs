using Goedel.Cryptography.Dare;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Test;
using System.IO;

namespace Goedel.Mesh.Test {
    public static class Extension {


        public static void CorruptDareMessage(this string filename) {

            using var inputStream = filename.OpenFileReadWrite();
            var jsonReader = new JsonBcdReader(inputStream);

            (jsonReader.StartArray()).TestTrue();
            var Header = DareHeader.FromJson(jsonReader, false);
            Header.TestNotNull();
            (jsonReader.NextArray()).TestTrue();

            jsonReader.PeekToken();

            switch (jsonReader.TokenType) {
                case JsonReader.Token.Binary: {
                    CorruptBinaryJSON(inputStream);
                    return;
                    }

                case JsonReader.Token.String: {
                    CorruptStringJSON(inputStream);
                    return;
                    }
                }
            }

        static void CorruptStringJSON(FileStream input) => throw new NYI();
        static void CorruptBinaryJSON(FileStream input) => throw new NYI();
        }
    }
