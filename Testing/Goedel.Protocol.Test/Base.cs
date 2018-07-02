using System;
using System.Collections.Generic;
using MT=Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Cryptography;
using Goedel.Utilities;
using System.IO;
using Goedel.Protocol;
using Goedel.Test;


namespace Goedel.Protocol.Test {
    [MT.TestClass]
    public partial class GoedelProtocol {

        /// <summary>
        /// 
        /// </summary>
        public static void TestDirect() {
            InitializeClass();

            var Instance = new GoedelProtocol();
            Instance.TestArrayB();
            //Instance.TestInstanceB();
            }



        [MT.AssemblyInitialize]
        public static void InitializeClass(MT.TestContext Context) => InitializeClass();
        public static void InitializeClass() {
            
            }



        [MT.TestMethod]
        public void TestInstance() => TestEncodeDecode(TestDataBasic,
                        DataEncoding.JSON, JSONReader.JSONReaderFactory);

        [MT.TestMethod]
        public void TestArray() => TestEncodeDecode(TestDataArray,
                        DataEncoding.JSON, JSONReader.JSONReaderFactory);

        [MT.TestMethod]
        public void TestStruct() => TestEncodeDecode(TestDataStruct,
                        DataEncoding.JSON, JSONReader.JSONReaderFactory);



        [MT.TestMethod]
        public void TestInstanceB() => TestEncodeDecode(TestDataBasic,
                        DataEncoding.JSON_B, JSONBCDReader.JSONReaderFactory);

        [MT.TestMethod]
        public void TestArrayB() => TestEncodeDecode(TestDataArray,
                        DataEncoding.JSON_B, JSONBCDReader.JSONReaderFactory);

        [MT.TestMethod]
        public void TestStructB() => TestEncodeDecode(TestDataStruct,
                        DataEncoding.JSON_B, JSONBCDReader.JSONReaderFactory);


        [MT.TestMethod]
        public void TestInstanceB2() => TestEncodeDecode(TestDataBasic,
                        DataEncoding.JSON, JSONBCDReader.JSONReaderFactory);

        [MT.TestMethod]
        public void TestArrayB2() => TestEncodeDecode(TestDataArray,
                        DataEncoding.JSON, JSONBCDReader.JSONReaderFactory);

        [MT.TestMethod]
        public void TestStructB2() => TestEncodeDecode(TestDataStruct,
                        DataEncoding.JSON, JSONBCDReader.JSONReaderFactory);


        [MT.TestMethod]
        public void TestJSON() {
            TestInstance();
            TestArray();
            TestStruct();
            }

        [MT.TestMethod]
        public void TestJSONB() {
            TestInstanceB();
            TestArrayB();
            TestStructB();
            }

        [MT.TestMethod]
        public void TestJSONB2() {
            TestInstanceB2();
            TestArrayB2();
            TestStructB2();
            }

        public void TestEncodeDecode(
                    MultiInstance First, 
                    DataEncoding DataEncoding,
                    JSONReaderFactoryDelegate ReaderFactory) {
            var FirstJSON = First.GetBytes(DataEncoding, true);
            var Second = MultiInstance.FromJSON(ReaderFactory(FirstJSON));
            CheckEqual(First, Second);
            }

        #region // Test Data
        MultiInstance TestDataBasic = new MultiInstance() {
            FieldBoolean = true,
            FieldInteger = 1,
            FieldDateTime = DateTime.Now,
            FieldString = "This is a test",
            FieldBinary = new byte[] { 0, 1, 2, 3, 4 }
            };



        MultiArray TestDataArray = new MultiArray() {
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

        public void CheckEqual(MultiInstance First, MultiInstance Second) {
            Assert.True(First.FieldBoolean == Second.FieldBoolean, Goedel.Test.Compare.Throw, "Boolean failed");
            Assert.True(First.FieldInteger == Second.FieldInteger, Compare.Throw, "Integer failed");
            Assert.True(First.FieldDateTime.IsEqualTo(Second.FieldDateTime), Compare.Throw, "DateTime failed");
            Assert.True(First.FieldString == Second.FieldString, Compare.Throw, "String failed");
            Assert.True(First.FieldBinary.IsEqualTo(Second.FieldBinary), Compare.Throw, "Binary failed");
            }

        public void CheckEqual(MultiArray First, MultiArray Second) {
            CheckEqual(First as MultiInstance, Second);

            Assert.True(First.ArrayBoolean.Count == Second.ArrayBoolean.Count,
                         Goedel.Test.Compare.Throw, "Boolean Array Length");
            for (var i = 0; i < First.ArrayBoolean.Count; i++) {
                Assert.True(First.ArrayBoolean[i] == Second.ArrayBoolean[i],
                         Goedel.Test.Compare.Throw, "Boolean Array");
                }

            Assert.True(First.ArrayInteger.Count == Second.ArrayInteger.Count,
             Goedel.Test.Compare.Throw, "Boolean Array Length");
            for (var i = 0; i < First.ArrayInteger.Count; i++) {
                Assert.True(First.ArrayInteger[i] == Second.ArrayInteger[i],
                         Goedel.Test.Compare.Throw, "Boolean Array");
                }

            Assert.True(First.ArrayDateTime.Count == Second.ArrayDateTime.Count,
             Goedel.Test.Compare.Throw, "Boolean Array Length");
            for (var i = 0; i < First.ArrayDateTime.Count; i++) {
                Assert.True(First.ArrayDateTime[i].IsEqualTo(Second.ArrayDateTime[i]),
                         Goedel.Test.Compare.Throw, "Boolean Array");
                }

            Assert.True(First.ArrayString.Count == Second.ArrayString.Count,
             Goedel.Test.Compare.Throw, "Boolean Array Length");
            for (var i = 0; i < First.ArrayString.Count; i++) {
                Assert.True(First.ArrayString[i] == Second.ArrayString[i],
                         Goedel.Test.Compare.Throw, "Boolean Array");
                }

            Assert.True(First.ArrayBinary.Count == Second.ArrayBinary.Count,
             Goedel.Test.Compare.Throw, "Boolean Array Length");
            for (var i = 0; i < First.ArrayBinary.Count; i++) {
                Assert.True(First.ArrayBinary[i].IsEqualTo(Second.ArrayBinary[i]),
                         Goedel.Test.Compare.Throw, "Boolean Array");
                }
            }
        #endregion
        }
    }
