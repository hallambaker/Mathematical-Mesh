using Goedel.Protocol;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace TestReader
{
    
    
    /// <summary>
    ///This is a test class for JSONReaderTest and is intended
    ///to contain all JSONReaderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class JSONReaderTest {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
                }
            set {
                testContextInstance = value;
                }
            }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for JSONReader Constructor
        ///</summary>
        [TestMethod()]
        public void JSONReaderConstructorTest() {
            JSONReader target = new JSONReader();
            //Assert.Inconclusive("TODO: Implement code to verify target");
            }

        struct CharTest {
            public char Test;
            public JSONReader_Accessor.CharType Expected;
            }

        static CharTest[] CharTests = {
            new CharTest { Test = '\"', Expected = JSONReader_Accessor.CharType.Quote},
            new CharTest { Test = '{', Expected = JSONReader_Accessor.CharType.LeftBrace},
            new CharTest { Test = '}', Expected = JSONReader_Accessor.CharType.RightBrace},
            new CharTest { Test = '[', Expected = JSONReader_Accessor.CharType.LeftSquare},
            new CharTest { Test = ']', Expected = JSONReader_Accessor.CharType.RightSquare},

            new CharTest { Test = '0', Expected = JSONReader_Accessor.CharType.Zero},
            new CharTest { Test = '1', Expected = JSONReader_Accessor.CharType.Digit},
            new CharTest { Test = '9', Expected = JSONReader_Accessor.CharType.Digit},

            new CharTest { Test = '.', Expected = JSONReader_Accessor.CharType.Period},
            new CharTest { Test = ':', Expected = JSONReader_Accessor.CharType.Colon},
            new CharTest { Test = ',', Expected = JSONReader_Accessor.CharType.Comma},
            new CharTest { Test = '-', Expected = JSONReader_Accessor.CharType.Minus},
            new CharTest { Test = '+', Expected = JSONReader_Accessor.CharType.Plus},

            new CharTest { Test = 'e', Expected = JSONReader_Accessor.CharType.Ee},
            new CharTest { Test = 'u', Expected = JSONReader_Accessor.CharType.u},
            new CharTest { Test = '/', Expected = JSONReader_Accessor.CharType.Escaped},
            new CharTest { Test = 'a', Expected = JSONReader_Accessor.CharType.Hex},
            new CharTest { Test = 'z', Expected = JSONReader_Accessor.CharType.Lower},
            new CharTest { Test = ' ', Expected = JSONReader_Accessor.CharType.WS},
            new CharTest { Test = '\t', Expected = JSONReader_Accessor.CharType.WS},
            new CharTest { Test = '\f', Expected = JSONReader_Accessor.CharType.WS},
            new CharTest { Test = '*', Expected = JSONReader_Accessor.CharType.Other}
                               };

        /// <summary>
        ///A test for GetCharType
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Goedel.Protocol.dll")]
        public void GetCharTypeTest() {
            JSONReader_Accessor target = new JSONReader_Accessor();
            foreach (CharTest CharTest in CharTests) {
                JSONReader_Accessor.CharType actual = target.GetCharType(CharTest.Test);
                Assert.AreEqual(CharTest.Expected, actual);
                }
            }


        struct StringTest {
            public string Test;
            public string Return;
            public JSONReader.Token Token;
            public string Name;
            }


        static StringTest[] StringTests = {
            new StringTest { Test = "11.11E1", Return="11.11E1", Token = JSONReader.Token.Number},
            // Blocks
            new StringTest { Test = "{", Token = JSONReader.Token.StartObject},
            new StringTest { Test = "  {", Token = JSONReader.Token.StartObject},
            new StringTest { Test = "[", Token = JSONReader.Token.StartArray},
            new StringTest { Test = "  [", Token = JSONReader.Token.StartArray},
            new StringTest { Test = "}", Token = JSONReader.Token.EndObject},
            new StringTest { Test = " }", Token = JSONReader.Token.EndObject},
            new StringTest { Test = "]", Token = JSONReader.Token.EndArray},

            // Chars
            new StringTest { Test = ":", Token = JSONReader.Token.Colon},
            new StringTest { Test = ",", Token = JSONReader.Token.Comma},
            new StringTest { Test = "true", Token = JSONReader.Token.True},
            new StringTest { Test = "false", Token = JSONReader.Token.False},
            new StringTest { Test = "null", Token = JSONReader.Token.Null},

            // Close but wrong
            new StringTest { Test = "NULL", Token = JSONReader.Token.Invalid},


            //// strings
            new StringTest { Test = "\"hello\"", Return="hello", Token = JSONReader.Token.String},
            new StringTest { Test = "\"\"", Return="", Token = JSONReader.Token.String},
            new StringTest { Test = "\"\\\"\"", Return="\"", Token = JSONReader.Token.String},
            new StringTest { Test = "\"hello\\\"\"", Return="hello\"", Token = JSONReader.Token.String},
            new StringTest { Test = "\" \"", Return=" ", Token = JSONReader.Token.String},
            new StringTest { Test = " \" \"", Return=" ", Token = JSONReader.Token.String},
            new StringTest { Test = "\n\r\t \"hello\"", Return="hello", Token = JSONReader.Token.String},
            
            //// String escaping
            new StringTest { Name="Escape1", Test = "\"\\\"\"", Return="\"", Token = JSONReader.Token.String},
            new StringTest { Name="Escape2",Test = "\" \\\"\"", Return=" \"", Token = JSONReader.Token.String},
            new StringTest { Name="Escape3",Test = "\"\\\\\"", Return="\\", Token = JSONReader.Token.String},
            new StringTest { Name="Escape4",Test = "\" \\\\\"", Return=" \\", Token = JSONReader.Token.String},
            new StringTest { Test = "\"\\b\"", Return="\b", Token = JSONReader.Token.String},
            new StringTest { Test = "\" \\b\"", Return=" \b", Token = JSONReader.Token.String},
            new StringTest { Test = "\"\\f\"", Return="\f", Token = JSONReader.Token.String},
            new StringTest { Test = "\" \\f\"", Return=" \f", Token = JSONReader.Token.String},
            new StringTest { Test = "\"\\n\"", Return="\n", Token = JSONReader.Token.String},
            new StringTest { Test = "\" \\n\"", Return=" \n", Token = JSONReader.Token.String},           
            new StringTest { Test = "\"\\r\"", Return="\r", Token = JSONReader.Token.String},
            new StringTest { Test = "\" \\r\"", Return=" \r", Token = JSONReader.Token.String},             
            new StringTest { Test = "\"\\t\"", Return="\t", Token = JSONReader.Token.String},
            new StringTest { Test = "\" \\t\"", Return=" \t", Token = JSONReader.Token.String}, 
 
            new StringTest { Test = "\"\\u0123\"", Return="\u0123", Token = JSONReader.Token.String},
            new StringTest { Test = "\" \\u0123\"", Return=" \u0123", Token = JSONReader.Token.String},            
            
            //// numbers
            new StringTest { Test = "0", Return="0", Token = JSONReader.Token.Number},
            new StringTest { Test = "-0", Return="-0", Token = JSONReader.Token.Number},

            new StringTest { Test = "1", Return="1", Token = JSONReader.Token.Number},
            new StringTest { Test = "9", Return="9", Token = JSONReader.Token.Number},
            new StringTest { Test = "10", Return="10", Token = JSONReader.Token.Number},
            new StringTest { Test = "10", Return="10", Token = JSONReader.Token.Number},
            new StringTest { Test = "123456789", Return="123456789", Token = JSONReader.Token.Number},
            new StringTest { Test = "1.0", Return="1.0", Token = JSONReader.Token.Number},
            new StringTest { Test = "1.1", Return="1.1", Token = JSONReader.Token.Number},
            new StringTest { Test = "1.11", Return="1.11", Token = JSONReader.Token.Number},
            new StringTest { Test = "1.01", Return="1.01", Token = JSONReader.Token.Number},
            new StringTest { Test = "111.111", Return="111.111", Token = JSONReader.Token.Number},
            new StringTest { Test = "11.11E1", Return="11.11E1", Token = JSONReader.Token.Number},
            new StringTest { Test = "11.11E11", Return="11.11E11", Token = JSONReader.Token.Number},
            new StringTest { Test = "11.11E+1", Return="11.11E+1", Token = JSONReader.Token.Number},
            new StringTest { Test = "11.11E-1", Return="11.11E-1", Token = JSONReader.Token.Number},
            new StringTest { Test = "11.11E+10", Return="11.11E+10", Token = JSONReader.Token.Number},
            new StringTest { Test = "11.11E-19", Return="11.11E-19", Token = JSONReader.Token.Number},
            new StringTest { Test = "11.11e11", Return="11.11e11", Token = JSONReader.Token.Number},
            new StringTest { Test = "11e11", Return="11e11", Token = JSONReader.Token.Number},
            new StringTest { Test = "11e+11", Return="11e+11", Token = JSONReader.Token.Number},
           
            // Bad Numbers (for JSON at least)
            new StringTest { Test = "", Token = JSONReader.Token.Empty},
            new StringTest { Test = "+", Token = JSONReader.Token.Invalid},
            new StringTest { Test = "0.", Token = JSONReader.Token.Invalid},
            new StringTest { Test = "01", Token = JSONReader.Token.Invalid},
            new StringTest { Test = "0.", Token = JSONReader.Token.Invalid},
            new StringTest { Test = "1.", Token = JSONReader.Token.Invalid},
            new StringTest { Test = "-", Token = JSONReader.Token.Invalid},
            new StringTest { Test = ".", Token = JSONReader.Token.Invalid},
            new StringTest { Test = ".1", Token = JSONReader.Token.Invalid},

            // errors
            new StringTest { Test = "/n", Token = JSONReader.Token.Invalid}
            };



        /// <summary>
        ///A test for Lexer
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Goedel.Protocol.dll")]
        public void LexerTest() {
            foreach (StringTest StringTest in StringTests) {
                JSONReader_Accessor target = new JSONReader_Accessor(StringTest.Test); 
                JSONReader.Token Token;
                string Return = target.Lexer(out Token);
                Assert.AreEqual(StringTest.Token, Token);
                if (StringTest.Return != null) { 
                    Assert.AreEqual(StringTest.Return, Return);
                    }
                }
            }

        /// <summary>
        ///A test for JSONReader Constructor
        ///</summary>
        [TestMethod()]
        public void JSONReaderConstructorTest1() {
            TextReader InputIn = null; // TODO: Initialize to an appropriate value
            JSONReader target = new JSONReader(InputIn);
            //Assert.Inconclusive("TODO: Implement code to verify target");
            }
        }
}
