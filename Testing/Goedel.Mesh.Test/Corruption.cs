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

using System.IO;

using Goedel.Cryptography.Dare;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Test;
using Goedel.Utilities;

namespace Goedel.Mesh.Test;

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
