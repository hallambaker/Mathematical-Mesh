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

using Goedel.Protocol.Test;

using System.Collections;
using System.IO;
using System.Text.Json;

#pragma warning disable IDE0051

namespace Goedel.XUnit;

public partial class GoedelProtocol {

    public static GoedelProtocol Test() => new();




    [Fact]
    public void TestInstance() => TestEncodeDecode(TestDataBasic,
                    DataEncoding.JSON, JsonReader.JSONReaderFactory);

    [Fact]
    public void TestArray() => TestEncodeDecode(TestDataArray,
                    DataEncoding.JSON, JsonReader.JSONReaderFactory);

    [Fact]
    public void TestStruct() => TestEncodeDecode(TestDataStruct,
                    DataEncoding.JSON, JsonReader.JSONReaderFactory);



    [Fact]
    public void TestInstanceB() => TestEncodeDecode(TestDataBasic,
                    DataEncoding.JSON_B, JsonBcdReader.JSONReaderFactory);

    [Fact]
    public void TestArrayB() => TestEncodeDecode(TestDataArray,
                    DataEncoding.JSON_B, JsonBcdReader.JSONReaderFactory);

    [Fact]
    public void TestStructB() => TestEncodeDecode(TestDataStruct,
                    DataEncoding.JSON_B, JsonBcdReader.JSONReaderFactory);


    [Fact]
    public void TestInstanceB2() => TestEncodeDecode(TestDataBasic,
                    DataEncoding.JSON, JsonBcdReader.JSONReaderFactory);

    [Fact]
    public void TestArrayB2() => TestEncodeDecode(TestDataArray,
                    DataEncoding.JSON, JsonBcdReader.JSONReaderFactory);
    [Fact]
    public void TestStructB2() => TestEncodeDecode(TestDataStruct,
                    DataEncoding.JSON, JsonBcdReader.JSONReaderFactory);


    [Fact]
    public void TestJSON() {
        TestInstance();
        TestArray();
        TestStruct();
        }

    [Fact]
    public void TestJSONB() {
        TestInstanceB();
        TestArrayB();
        TestStructB();
        }

    [Fact]
    public void TestJSONB2() {
        TestInstanceB2();
        TestArrayB2();
        TestStructB2();
        }

    [Fact]

    public void TestEncodeDecode3() {
        var First = TestDataStruct;

        var FirstJSON = First.GetBytes(DataEncoding.JSON, true);
        Console.WriteLine($"Input: {FirstJSON.ToUTF8()}");

        var Second = JsonObject.ParseTagged(FirstJSON) as MultiStruct;
        CheckEqual(First, Second);
        }

    [Fact]

    public void TestEncodeDecode2() {



        var First = TestDataStruct;

        var FirstJSON = First.GetBytes(DataEncoding.JSON);
        Console.WriteLine($"Input: {FirstJSON.ToUTF8()}");

        //var stream = new MemoryStream(FirstJSON);

        //var dom = JsonDocument.Parse(FirstJSON);
        var Second = JsonObject.StreamParse<MultiStruct>(FirstJSON, false);

        var SecondJSON = Second.GetBytes(DataEncoding.JSON);
        Console.WriteLine($"Output: {SecondJSON.ToUTF8()}");


        CheckEqual(First, Second);





        //var x = JsonValueKind.False;
        //var asString = FirstJSON.ToUTF8();
        //Console.WriteLine(asString);

        //var Second = MultiInstance.FromJson(ReaderFactory(FirstJSON));
        //CheckEqual(First, Second);
        }



    [Theory]
    [ClassData(typeof(JSONReadersTestData))]
    public void TestEncodeDecode(
                MultiInstance First,
                DataEncoding DataEncoding,
                JSONReaderFactoryDelegate ReaderFactory) {
        var FirstJSON = First.GetBytes(DataEncoding, true);


        var asString = FirstJSON.ToUTF8();
        Console.WriteLine(asString);

        var Second = JsonObject.StreamParse < MultiInstance>(ReaderFactory(FirstJSON));
        CheckEqual(First, Second);
        }

    public class JSONReadersTestData : IEnumerable<object[]> {
        public IEnumerator<object[]> GetEnumerator() {
            yield return new object[] { TestDataBasic, DataEncoding.JSON, JsonReader.JSONReaderFactory };
            yield return new object[] { TestDataArray, DataEncoding.JSON, JsonReader.JSONReaderFactory };
            yield return new object[] { TestDataStruct, DataEncoding.JSON, JsonReader.JSONReaderFactory };

            yield return new object[] { TestDataBasic, DataEncoding.JSON_B, JsonBcdReader.JSONReaderFactory };
            yield return new object[] { TestDataArray, DataEncoding.JSON_B, JsonBcdReader.JSONReaderFactory };
            yield return new object[] { TestDataStruct, DataEncoding.JSON_B, JsonBcdReader.JSONReaderFactory };

            yield return new object[] { TestDataBasic, DataEncoding.JSON, JsonBcdReader.JSONReaderFactory };
            yield return new object[] { TestDataArray, DataEncoding.JSON, JsonBcdReader.JSONReaderFactory };
            yield return new object[] { TestDataStruct, DataEncoding.JSON, JsonBcdReader.JSONReaderFactory };
            }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }



    #region // Test Data
    static readonly MultiInstance TestDataBasic = new() {
        FieldBoolean = true,
        FieldInteger = 1,
        FieldDateTime = System.DateTime.UtcNow,
        FieldString = "This is a test",
        FieldBinary = new byte[] { 0, 1, 2, 3, 4 }
        };

    static readonly MultiArray TestDataArray = new() {
        FieldBoolean = true,
        FieldInteger = 1,
        FieldDateTime = System.DateTime.UtcNow,
        FieldString = "This is a test",
        FieldBinary = new byte[] { 0, 1, 2, 3, 4 },
        ArrayBoolean = new List<bool> { true, false, true, false },
        ArrayInteger = new List<int> { 0, 2, 4, 8 },
        ArrayDateTime = new List<System.DateTime> { System.DateTime.UtcNow },
        ArrayString = new List<string> { "Alice", "Bob", "Carol", },
        ArrayBinary = new List<byte[]> { "One".ToBytes(), "Two".ToBytes() }
        };


    static readonly DictArray TestDataDict = new() {
        FieldBoolean = true,
        FieldInteger = 1,
        FieldDateTime = System.DateTime.UtcNow,
        FieldString = "This is a test",
        FieldBinary = [0, 1, 2, 3, 4],
        ArrayBoolean = [true, false, true, false],
        ArrayInteger = [0, 2, 4, 8],
        ArrayDateTime = [System.DateTime.UtcNow],
        ArrayString = ["Alice", "Bob", "Carol",],
        ArrayBinary = ["One".ToBytes(), "Two".ToBytes()],

        DictBoolean = new() {
               {"One", true},
               {"Two", false},
               {"Three", true},
               {"Four", true},
               {"Five", false}},
        DictString = new() {
               {"One", "hello"},
               {"Two", "there"},
               {"Three", "scotty"},
               {"Four", ""},
               {"Five", "Help"}},
        DictBinary = new() {
               {"One", "hello".ToBytes()},
               {"Two", "there".ToBytes()},
               {"Three", "scotty".ToBytes()},
               {"Four", "".ToBytes()},
               {"Five", "Help".ToBytes()}},
        DictInteger = new() {
               {"One", 1},
               {"Two", 2},
               {"Three", 3},
               {"Four", 4},
               {"Five", 5}}
        };



    static readonly MultiInstance Struct1 = new() {
        FieldBoolean = true,
        FieldInteger = 1,
        FieldDateTime = System.DateTime.UtcNow,
        FieldString = "This is a test",
        FieldBinary = new byte[] { 0, 1, 2, 3, 4 }
        };

    static readonly MultiInstance Struct2 = new() {
        FieldBoolean = true,
        FieldInteger = 1,
        FieldDateTime = System.DateTime.UtcNow,
        FieldString = "This is a test",
        FieldBinary = new byte[] { 0, 1, 2, 3, 4 }
        };

    static readonly MultiArray Struct3 = new() {
        FieldBoolean = true,
        FieldInteger = 1,
        FieldDateTime = System.DateTime.UtcNow,
        FieldString = "This is a test",
        FieldBinary = new byte[] { 0, 1, 2, 3, 4 },
        ArrayBoolean = new List<bool> { true, false, true, false }
        };


    public static readonly MultiStruct TestDataStruct = new() {
        FieldBoolean = true,
        FieldInteger = 1,
        FieldFloat = 3.14,
        FieldDateTime = System.DateTime.UtcNow,
        FieldString = "This is a test",
        FieldBinary = [0, 1, 2, 3, 4 ],
        ArrayBoolean = [true, false, true, false],
        ArrayInteger = [0, 2, 4, 8],
        ArrayFloat = [3.14],
        ArrayDateTime = [System.DateTime.UtcNow],
        ArrayString = ["Alice", "Bob", "Carol",],
        ArrayBinary = ["One".ToBytes(), "Two".ToBytes()],
        FieldMultiInstance = Struct1,
        ArrayMultiInstance = [Struct1, Struct2],
        TFieldMultiInstance = Struct3,
        TArrayMultiInstance = [Struct1, Struct2, Struct3]
        };
    #endregion

    #region // Equality tests

    static void CheckEqual(MultiInstance First, MultiInstance Second) {
        Utilities.Assert.AssertTrue(First.FieldBoolean == Second.FieldBoolean, Compare.Throw, "Boolean failed");
        Utilities.Assert.AssertTrue(First.FieldInteger == Second.FieldInteger, Compare.Throw, "Integer failed");

        Utilities.Assert.AssertTrue(First.FieldDateTime.IsEqualTo(Second.FieldDateTime), Compare.Throw);

        Utilities.Assert.AssertTrue(First.FieldString == Second.FieldString, Compare.Throw, "String failed");
        Utilities.Assert.AssertTrue(First.FieldBinary.IsEqualTo(Second.FieldBinary), Compare.Throw, "Binary failed");
        }

    void CheckEqual(MultiArray First, MultiArray Second) {
        CheckEqual(First as MultiInstance, Second);

        Utilities.Assert.AssertTrue(First.ArrayBoolean.Count == Second.ArrayBoolean.Count,
                     Compare.Throw, "Boolean Array Length");
        for (var i = 0; i < First.ArrayBoolean.Count; i++) {
            Utilities.Assert.AssertTrue(First.ArrayBoolean[i] == Second.ArrayBoolean[i],
                     Compare.Throw, "Boolean Array");
            }

        Utilities.Assert.AssertTrue(First.ArrayInteger.Count == Second.ArrayInteger.Count,
         Compare.Throw, "Boolean Array Length");
        for (var i = 0; i < First.ArrayInteger.Count; i++) {
            Utilities.Assert.AssertTrue(First.ArrayInteger[i] == Second.ArrayInteger[i],
                     Compare.Throw, "Boolean Array");
            }

        Utilities.Assert.AssertTrue(First.ArrayDateTime.Count == Second.ArrayDateTime.Count,
         Compare.Throw, "Boolean Array Length");
        for (var i = 0; i < First.ArrayDateTime.Count; i++) {
            First.ArrayDateTime[i].AssertEqualSeconds(Second.ArrayDateTime[i],
                     Compare.Throw);
            }

        Utilities.Assert.AssertTrue(First.ArrayString.Count == Second.ArrayString.Count,
         Compare.Throw, "Boolean Array Length");
        for (var i = 0; i < First.ArrayString.Count; i++) {
            Utilities.Assert.AssertTrue(First.ArrayString[i] == Second.ArrayString[i],
                     Compare.Throw, "Boolean Array");
            }

        Utilities.Assert.AssertTrue(First.ArrayBinary.Count == Second.ArrayBinary.Count,
         Compare.Throw, "Boolean Array Length");
        for (var i = 0; i < First.ArrayBinary.Count; i++) {
            Utilities.Assert.AssertTrue(First.ArrayBinary[i].IsEqualTo(Second.ArrayBinary[i]),
                     Compare.Throw, "Boolean Array");
            }
        }





    #endregion
    }
