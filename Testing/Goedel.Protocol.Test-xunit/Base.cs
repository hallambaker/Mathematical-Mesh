using Goedel.Protocol;
using Goedel.Test.Core;
using Goedel.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;

using Xunit;

namespace Goedel.XUnit {

    public partial class GoedelProtocol {

        public static GoedelProtocol Test => new GoedelProtocol();
        public GoedelProtocol() => TestEnvironmentCommon.Initialize(true);




        [Fact]
        public void TestInstance() => TestEncodeDecode(TestDataBasic,
                        DataEncoding.JSON, JSONReader.JSONReaderFactory);

        [Fact]
        public void TestArray() => TestEncodeDecode(TestDataArray,
                        DataEncoding.JSON, JSONReader.JSONReaderFactory);

        [Fact]
        public void TestStruct() => TestEncodeDecode(TestDataStruct,
                        DataEncoding.JSON, JSONReader.JSONReaderFactory);



        [Fact]
        public void TestInstanceB() => TestEncodeDecode(TestDataBasic,
                        DataEncoding.JSON_B, JSONBCDReader.JSONReaderFactory);

        [Fact]
        public void TestArrayB() => TestEncodeDecode(TestDataArray,
                        DataEncoding.JSON_B, JSONBCDReader.JSONReaderFactory);

        [Fact]
        public void TestStructB() => TestEncodeDecode(TestDataStruct,
                        DataEncoding.JSON_B, JSONBCDReader.JSONReaderFactory);


        [Fact]
        public void TestInstanceB2() => TestEncodeDecode(TestDataBasic,
                        DataEncoding.JSON, JSONBCDReader.JSONReaderFactory);

        [Fact]
        public void TestArrayB2() => TestEncodeDecode(TestDataArray,
                        DataEncoding.JSON, JSONBCDReader.JSONReaderFactory);
        [Fact]
        public void TestStructB2() => TestEncodeDecode(TestDataStruct,
                        DataEncoding.JSON, JSONBCDReader.JSONReaderFactory);


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

        [Theory]
        [ClassData(typeof(JSONReadersTestData))]
        public void TestEncodeDecode(
                    MultiInstance First,
                    DataEncoding DataEncoding,
                    JSONReaderFactoryDelegate ReaderFactory) {
            var FirstJSON = First.GetBytes(DataEncoding, true);
            var Second = MultiInstance.FromJSON(ReaderFactory(FirstJSON));
            CheckEqual(First, Second);
            }

        public class JSONReadersTestData : IEnumerable<object[]> {
            public IEnumerator<object[]> GetEnumerator() {
                yield return new object[] { TestDataBasic, DataEncoding.JSON, JSONReader.JSONReaderFactory };
                yield return new object[] { TestDataArray, DataEncoding.JSON, JSONReader.JSONReaderFactory };
                yield return new object[] { TestDataStruct, DataEncoding.JSON, JSONReader.JSONReaderFactory };

                yield return new object[] { TestDataBasic, DataEncoding.JSON_B, JSONBCDReader.JSONReaderFactory };
                yield return new object[] { TestDataArray, DataEncoding.JSON_B, JSONBCDReader.JSONReaderFactory };
                yield return new object[] { TestDataStruct, DataEncoding.JSON_B, JSONBCDReader.JSONReaderFactory };

                yield return new object[] { TestDataBasic, DataEncoding.JSON, JSONBCDReader.JSONReaderFactory };
                yield return new object[] { TestDataArray, DataEncoding.JSON, JSONBCDReader.JSONReaderFactory };
                yield return new object[] { TestDataStruct, DataEncoding.JSON, JSONBCDReader.JSONReaderFactory };
                }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            }



        #region // Test Data
        static MultiInstance TestDataBasic = new MultiInstance() {
            FieldBoolean = true,
            FieldInteger = 1,
            FieldDateTime = DateTime.Now,
            FieldString = "This is a test",
            FieldBinary = new byte[] { 0, 1, 2, 3, 4 }
            };

        static MultiArray TestDataArray = new MultiArray() {
            FieldBoolean = true,
            FieldInteger = 1,
            FieldDateTime = DateTime.Now,
            FieldString = "This is a test",
            FieldBinary = new byte[] { 0, 1, 2, 3, 4 },
            ArrayBoolean = new List<bool> { true, false, true, false },
            ArrayInteger = new List<int> { 0, 2, 4, 8 },
            ArrayDateTime = new List<DateTime?> { DateTime.Now },
            ArrayString = new List<string> { "Alice", "Bob", "Carol", },
            ArrayBinary = new List<byte[]> { "One".ToBytes(), "Two".ToBytes() }
            };

        static MultiInstance Struct1 = new MultiInstance() {
            FieldBoolean = true,
            FieldInteger = 1,
            FieldDateTime = DateTime.Now,
            FieldString = "This is a test",
            FieldBinary = new byte[] { 0, 1, 2, 3, 4 }
            };

        static MultiInstance Struct2 = new MultiInstance() {
            FieldBoolean = true,
            FieldInteger = 1,
            FieldDateTime = DateTime.Now,
            FieldString = "This is a test",
            FieldBinary = new byte[] { 0, 1, 2, 3, 4 }
            };

        static MultiArray Struct3 = new MultiArray() {
            FieldBoolean = true,
            FieldInteger = 1,
            FieldDateTime = DateTime.Now,
            FieldString = "This is a test",
            FieldBinary = new byte[] { 0, 1, 2, 3, 4 },
            ArrayBoolean = new List<bool> { true, false, true, false }
            };


        static MultiStruct TestDataStruct = new MultiStruct() {
            FieldBoolean = true,
            FieldInteger = 1,
            FieldDateTime = DateTime.Now,
            FieldString = "This is a test",
            FieldBinary = new byte[] { 0, 1, 2, 3, 4 },
            ArrayBoolean = new List<bool> { true, false, true, false },
            ArrayInteger = new List<int> { 0, 2, 4, 8 },
            ArrayDateTime = new List<DateTime?> { DateTime.Now },
            ArrayString = new List<string> { "Alice", "Bob", "Carol", },
            ArrayBinary = new List<byte[]> { "One".ToBytes(), "Two".ToBytes() },
            FieldMultiInstance = Struct1,
            ArrayMultiInstance = new List<MultiInstance> { Struct1, Struct2 },
            TFieldMultiInstance = Struct3,
            TArrayMultiInstance = new List<MultiInstance> { Struct1, Struct2, Struct3 }
            };
        #endregion

        #region // Equality tests

        void CheckEqual(MultiInstance First, MultiInstance Second) {
            Utilities.Assert.True(First.FieldBoolean == Second.FieldBoolean, Goedel.Test.Core.Compare.Throw, "Boolean failed");
            Utilities.Assert.True(First.FieldInteger == Second.FieldInteger, Compare.Throw, "Integer failed");
            Utilities.Assert.True(First.FieldDateTime.IsEqualTo(Second.FieldDateTime), Compare.Throw, "DateTime failed");
            Utilities.Assert.True(First.FieldString == Second.FieldString, Compare.Throw, "String failed");
            Utilities.Assert.True(First.FieldBinary.IsEqualTo(Second.FieldBinary), Compare.Throw, "Binary failed");
            }

        void CheckEqual(MultiArray First, MultiArray Second) {
            CheckEqual(First as MultiInstance, Second);

            Utilities.Assert.True(First.ArrayBoolean.Count == Second.ArrayBoolean.Count,
                         Compare.Throw, "Boolean Array Length");
            for (var i = 0; i < First.ArrayBoolean.Count; i++) {
                Utilities.Assert.True(First.ArrayBoolean[i] == Second.ArrayBoolean[i],
                         Compare.Throw, "Boolean Array");
                }

            Utilities.Assert.True(First.ArrayInteger.Count == Second.ArrayInteger.Count,
             Compare.Throw, "Boolean Array Length");
            for (var i = 0; i < First.ArrayInteger.Count; i++) {
                Utilities.Assert.True(First.ArrayInteger[i] == Second.ArrayInteger[i],
                         Compare.Throw, "Boolean Array");
                }

            Utilities.Assert.True(First.ArrayDateTime.Count == Second.ArrayDateTime.Count,
             Compare.Throw, "Boolean Array Length");
            for (var i = 0; i < First.ArrayDateTime.Count; i++) {
                Utilities.Assert.True(First.ArrayDateTime[i].IsEqualTo(Second.ArrayDateTime[i]),
                         Compare.Throw, "Boolean Array");
                }

            Utilities.Assert.True(First.ArrayString.Count == Second.ArrayString.Count,
             Compare.Throw, "Boolean Array Length");
            for (var i = 0; i < First.ArrayString.Count; i++) {
                Utilities.Assert.True(First.ArrayString[i] == Second.ArrayString[i],
                         Compare.Throw, "Boolean Array");
                }

            Utilities.Assert.True(First.ArrayBinary.Count == Second.ArrayBinary.Count,
             Compare.Throw, "Boolean Array Length");
            for (var i = 0; i < First.ArrayBinary.Count; i++) {
                Utilities.Assert.True(First.ArrayBinary[i].IsEqualTo(Second.ArrayBinary[i]),
                         Compare.Throw, "Boolean Array");
                }
            }
        #endregion
        }
    }
