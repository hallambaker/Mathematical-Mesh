
using Goedel.Cryptography;
using Goedel.Test.Core;
using Goedel.Utilities;
using Goedel.Test;
using System.IO;

using Xunit;

namespace Goedel.XUnit {

    public class Utilities {
        public static Utilities Test() => new Utilities();
        public Utilities() => TestEnvironmentCommon.Initialize(true);



        class TestVectorBaseConvert {
            public byte[] Data;
            public string Base16;
            public string Base32;
            public string Base32Hex;
            public string Base64;
            public string Base64Url;


            public TestVectorBaseConvert(
                    string Data,
                    string Base16,
                    string Base32,
                    string Base32Hex,
                    string Base64,
                    string Base64Url) : this(
                        Data.ToBytes(), Base16, Base32, Base32Hex, Base64, Base64Url) {
                }
            public TestVectorBaseConvert(
                    byte[] Data,
                    string Base16,
                    string Base32,
                    string Base32Hex,
                    string Base64,
                    string Base64Url) {
                this.Data = Data;
                this.Base16 = Base16;
                this.Base32 = Base32;
                this.Base32Hex = Base32Hex;
                this.Base64 = Base64;
                this.Base64Url = Base64Url;
                }

            }

        readonly TestVectorBaseConvert[] TestVector = new TestVectorBaseConvert[] {
            new TestVectorBaseConvert (new byte[] { },
                    "", "", "", "", ""),

            new TestVectorBaseConvert ("This is a test",
                    "5468697320697320612074657374",
                    "KRUGS4ZANFZSAYJAORSXG5A",
                    "AHK6ISP0D5PI0O90EHIN6T0",
                    "VGhpcyBpcyBhIHRlc3Q=",
                    "VGhpcyBpcyBhIHRlc3Q"),

            new TestVectorBaseConvert ("ABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890",
                    "4142434445464748494A4B4C4D4E4F505152535455565758595A3031323334353637383930",
                    "IFBEGRCFIZDUQSKKJNGE2TSPKBIVEU2UKVLFOWCZLIYDCMRTGQ2TMNZYHEYA",
                    "85146H258P3KGIAA9D64QJIFA18L4KQKALB5EM2PB8O32CHJ6GQJCDPO74O0",
                    "QUJDREVGR0hJSktMTU5PUFFSU1RVVldYWVowMTIzNDU2Nzg5MA==",
                    "QUJDREVGR0hJSktMTU5PUFFSU1RVVldYWVowMTIzNDU2Nzg5MA"),

            new TestVectorBaseConvert ("<Test>No?",
                    "3C546573743E4E6F3F",
                    "HRKGK43UHZHG6PY",
                    "7HA6ASRK7P76UFO",
                    "PFRlc3Q+Tm8/",
                    "PFRlc3Q-Tm8_")

            };

        string TestFormat1 = "4C07219E8B5CBC9FD99C8A0CB1CEC050B1BB91796F136FEEFFBE1A2C869E643875407E72237CEC46E2A615DD361B88A1C6F264AD651DEE7F63CF1361918AB010AF";
        string TestFormat1Draft = "TAchnotcvJ/ZnIoMsc7AULG7kXlvE2/u/74aLIaeZDh1QH5yI3zsRuKmFd02G4ihxvJkrWUd\n  7n9jzxNhkYqwEK8";
        string TestFormat1Hex =
                "\n  4C 07 21 9E  8B 5C BC 9F  D9 9C 8A 0C  B1 CE C0 50\n" +
                "  B1 BB 91 79  6F 13 6F EE  FF BE 1A 2C  86 9E 64 38\n" +
                "  75 40 7E 72  23 7C EC 46  E2 A6 15 DD  36 1B 88 A1\n" +
                "  C6 F2 64 AD  65 1D EE 7F  63 CF 13 61  91 8A B0 10\n" +
                "  AF";
        string TestFormat1Dash6 = "JQDS-DHUL-LS6J-7WM4-RIGL-DTWA-KCY3-XELZ";
        string TestFormat1Dash5 = "JQDSD-HULLS-6J7WM-4RIGL-DTWAK";

        [Fact]
        public void BaseConversionFormatting() {
            var Bytes = TestFormat1.FromBase16();

            var ResultDraft = Bytes.ToStringBase64(format: ConversionFormat.Draft);
            CheckExact(ResultDraft, TestFormat1Draft, "Draft formatting failed");

            var ResultHex = Bytes.ToStringBase16FormatHex();
            CheckExact(ResultHex, TestFormat1Hex, "Hex formatting failed");
            var ResultDash4 = Bytes.ToStringBase32hs(20);
            CheckExact(ResultDash4, TestFormat1Dash6, "Dash 4 formatting failed");
            var ResultDash5 = Bytes.ToStringBase32(format: ConversionFormat.Dash5, outputMax: 25);
            CheckExact(ResultDash5, TestFormat1Dash5, "Dash 5 formatting failed");

            }



        delegate IBytesToStream GetStreamConverterDelegate(Stream Output,
                ConversionFormat Format = ConversionFormat.None);


        delegate byte[] FromStringDelegate(string Data);


        [Fact]
        public void BaseConversionsToString() {
            foreach (var Vector in TestVector) {
                ToStringConvertTest(Vector);
                }

            }

        [Fact]
        public void BaseConversionsToStream() {
            foreach (var Vector in TestVector) {
                ToStreamConvertTest(Vector);
                }

            }

        [Fact]
        public void BaseConversionsFromString() {
            foreach (var Vector in TestVector) {
                FromStringConvertTest(Vector);
                }

            }

        [Fact]
        public void BaseConversionsRoundTripRandomized() {
            foreach (var Vector in TestVector) {
                for (int i = 0; i < 35; i++) {
                    TestRandomRoundTrip(Vector, i);
                    }
                TestRandomRoundTrip(Vector, 100);
                TestRandomRoundTrip(Vector, 1000);
                }

            }


        void TestRandomRoundTrip(TestVectorBaseConvert Vector, int Length) {
            var Bytes = Platform.GetRandomBytes(Length);
            TestRandomRoundTrip(BaseConvert.ToStreamBase16, BaseConvert.FromBase16, Bytes, ConversionFormat.None);
            TestRandomRoundTrip(BaseConvert.ToStreamBase16, BaseConvert.FromBase16, Bytes, ConversionFormat.Hex);
            TestRandomRoundTrip(BaseConvert.ToStreamBase32, BaseConvert.FromBase32, Bytes, ConversionFormat.None);
            TestRandomRoundTrip(BaseConvert.ToStreamBase32, BaseConvert.FromBase32, Bytes, ConversionFormat.Dash5);
            TestRandomRoundTrip(BaseConvert.ToStreamBase32, BaseConvert.FromBase32, Bytes, ConversionFormat.Dash4);
            TestRandomRoundTrip(BaseConvert.ToStreamBase64, BaseConvert.FromBase64, Bytes, ConversionFormat.None);
            TestRandomRoundTrip(BaseConvert.ToStreamBase64, BaseConvert.FromBase64, Bytes, ConversionFormat.Terminal);
            TestRandomRoundTrip(BaseConvert.ToStreamBase64, BaseConvert.FromBase64, Bytes, ConversionFormat.Draft);
            TestRandomRoundTrip(BaseConvert.ToStreamBase64, BaseConvert.FromBase64, Bytes,
                    ConversionFormat.Draft | ConversionFormat.Terminal);
            TestRandomRoundTrip(BaseConvert.ToStreamBase64Url, BaseConvert.FromBase64, Bytes, ConversionFormat.None);
            TestRandomRoundTrip(BaseConvert.ToStreamBase64Url, BaseConvert.FromBase64, Bytes, ConversionFormat.Draft);
            }

        void TestRandomRoundTrip(GetStreamConverterDelegate ByteToString,
                    FromStringDelegate StringToByte, byte[] Data, ConversionFormat ConversionFormat, int Chunk = -1) {
            var StringValue = StreamToString(ByteToString, Data, ConversionFormat, Chunk);
            var Result = StringToByte(StringValue);
            Result.TestEqual(Data);
            }

        void ToStringConvertTest(TestVectorBaseConvert Vector) {
            CheckTrim(Vector.Base16, Vector.Data.ToStringBase16(Format: ConversionFormat.None));
            CheckTrim(Vector.Base32, Vector.Data.ToStringBase32());
            CheckTrim(Vector.Base32Hex, Vector.Data.ToStringBase32Hex());
            CheckTrim(Vector.Base64, Vector.Data.ToStringBase64(format: ConversionFormat.Terminal));
            CheckTrim(Vector.Base64Url, Vector.Data.ToStringBase64url());
            }

        void ToStreamConvertTest(TestVectorBaseConvert Vector) {
            ToStreamConvertTestMultiple(BaseConvert.ToStreamBase16, Vector.Data, Vector.Base16);
            ToStreamConvertTestMultiple(BaseConvert.ToStreamBase32, Vector.Data, Vector.Base32);
            ToStreamConvertTestMultiple(BaseConvert.ToStreamBase32Hex, Vector.Data, Vector.Base32Hex);
            ToStreamConvertTestMultiple(BaseConvert.ToStreamBase64, Vector.Data, Vector.Base64, ConversionFormat.Terminal);
            ToStreamConvertTestMultiple(BaseConvert.ToStreamBase64Url, Vector.Data, Vector.Base64Url);
            }


        void FromStringConvertTest(TestVectorBaseConvert Vector) {
            FromStringConvertTest(BaseConvert.FromBase16, Vector.Data, Vector.Base16);
            FromStringConvertTest(BaseConvert.FromBase32, Vector.Data, Vector.Base32);
            //FromStringConvertTest(BaseConvert.FromBase32HexString, Vector.Data, Vector.Base32Hex);
            FromStringConvertTest(BaseConvert.FromBase64, Vector.Data, Vector.Base64);
            FromStringConvertTest(BaseConvert.FromBase64, Vector.Data, Vector.Base64Url);
            }

        static void FromStringConvertTest(FromStringDelegate ConverterDelegate, byte[] Data, string Test) {
            var Result = ConverterDelegate(Test);
            Result.TestEqual(Data);
            }


        void ToStreamConvertTestMultiple(GetStreamConverterDelegate ConverterDelegate,
                    byte[] Data, string Test, ConversionFormat Format = ConversionFormat.None) {

            CheckStreamed(ConverterDelegate, Data, Test, Format);
            CheckStreamed(ConverterDelegate, Data, Test, Format, 7);
            CheckStreamed(ConverterDelegate, Data, Test, Format, 13);
            }




        void CheckStreamed(GetStreamConverterDelegate ConverterDelegate,
                    byte[] Data, string Test, ConversionFormat Format = ConversionFormat.None, int Chunk = -1) {
            var Result = StreamToString(ConverterDelegate, Data, Format, Chunk);
            CheckTrim(Result, Test);
            }

        static string StreamToString(GetStreamConverterDelegate ConverterDelegate,
            byte[] Data, ConversionFormat Format = ConversionFormat.None, int Chunk = -1) {

            var Stream = new MemoryStream();
            var Converter = ConverterDelegate(Stream, Format: Format);

            Chunk = Chunk < 0 ? Data.Length : Chunk;

            for (var i = 0; i < Data.Length; i += Chunk) {
                var Remainder = Data.Length - i;
                var Length = Remainder > Chunk ? Chunk : Remainder;
                Converter.Write(Data, i, Length);
                }
            Converter.Final();

            return Stream.ToArray().ToUTF8();
            }

        static void CheckTrim(string Value, string Result, string Reason = null) =>
            Value.AssertEqual(Result.Trim(), Compare.Throw,  Reason);



        static void CheckExact(string Value, string Result, string Reason = null) =>
            Value.AssertEqual(Result, Compare.Throw, Reason);

        }
    }
