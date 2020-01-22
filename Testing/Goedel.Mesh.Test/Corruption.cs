using Goedel.Cryptography.Dare;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Utilities;

using System.IO;

namespace Goedel.Mesh.Test {
    public static class Extension {


        public static void CorruptDareMessage(this string filename) {

            using var inputStream = filename.OpenFileReadWrite();
            var jsonReader = new JSONBCDReader(inputStream);

            Assert.True(jsonReader.StartArray());
            var Header = DareHeader.FromJSON(jsonReader, false);
            Assert.NotNull(Header);
            Assert.True(jsonReader.NextArray());

            jsonReader.PeekToken();

            switch (jsonReader.TokenType) {
                case JSONReader.Token.Binary: {
                    CorruptBinaryJSON(inputStream);
                    return;
                    }

                case JSONReader.Token.String: {
                    CorruptStringJSON(inputStream);
                    return;
                    }
                }
            }

        static void CorruptStringJSON(FileStream input) => throw new NYI();
        static void CorruptBinaryJSON(FileStream input) => throw new NYI();
        }
    }
