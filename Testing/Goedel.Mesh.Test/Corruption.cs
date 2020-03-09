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

                case JSONReader.Token.Invalid:
                    break;
                case JSONReader.Token.StartObject:
                    break;
                case JSONReader.Token.EndObject:
                    break;
                case JSONReader.Token.StartArray:
                    break;
                case JSONReader.Token.EndArray:
                    break;
                case JSONReader.Token.Colon:
                    break;
                case JSONReader.Token.Comma:
                    break;
                case JSONReader.Token.Tag:
                    break;
                case JSONReader.Token.Number:
                    break;
                case JSONReader.Token.Integer:
                    break;
                case JSONReader.Token.Real32:
                    break;
                case JSONReader.Token.Real64:
                    break;
                case JSONReader.Token.Litteral:
                    break;
                case JSONReader.Token.True:
                    break;
                case JSONReader.Token.False:
                    break;
                case JSONReader.Token.Null:
                    break;
                case JSONReader.Token.EndRecord:
                    break;
                case JSONReader.Token.JSONBCD:
                    break;
                case JSONReader.Token.Empty:
                    break;
                default:
                    break;
                }
            }

        static void CorruptStringJSON(FileStream input) => throw new NYI();
        static void CorruptBinaryJSON(FileStream input) => throw new NYI();
        }
    }
