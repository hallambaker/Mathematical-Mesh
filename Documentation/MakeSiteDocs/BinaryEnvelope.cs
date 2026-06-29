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

using Goedel.Cryptography.Dare;
using Goedel.Protocol;
using Goedel.Utilities;

using Newtonsoft.Json.Linq;

using static System.Runtime.InteropServices.JavaScript.JSType;
namespace ExampleGenerator;


public partial class CreateExamples {


    void WriteTitle(string title, string type=null) {
        if (title == null) {
            return;
            }
        if (type != null) {
            _Output.Write(type);
            _Output.Write(": ");
            }
        _Output.WriteLine(title);


        }

    void FormatData(string title, byte[] data) {
        _Output.Write(title);
        if (data != null) {
            _Output.WriteLine(data.ToStringBase16FormatHex());
            }
        }

    void FormatData(string title, string data) {
        WriteTitle(title);
        if (data != null) {
            _Output.WriteLine(data);
            }
        }

    void FormatData(string title, JsonObject json) {
        WriteTitle("Envelope", title);
        if (json != null) {
            _Output.WriteLine(json.ToString());
            }
        }
    void FormatData(string title, DareEnvelope json, bool unpack=false, bool binary=false) {
        WriteTitle("Envelope", title);

        if (binary) {
            var data = json.ToArray();
            _Output.WriteLine(data.ToStringBase16FormatHex());
            }
        else {
            JSONDebugWriter.WriteLine(_Output, json);
            }
        if (unpack) {
            _Output.WriteLine("Signed Header:");
            JSONDebugWriter.WriteLine(_Output, json.GetSigned());
            _Output.WriteLine("Payload:");
            _Output.WriteLine(json.Payload.ToUTF8());
            }
        }

    void FormatData(string title, DareSequence json, bool binary = false) {
        WriteTitle("Sequence",title);

        if (binary) {
            var data = json.ToArray();
            _Output.WriteLine(data.ToStringBase16FormatHex());
            }
        else {
            JSONDebugWriter.WriteLine(_Output, json);
            }



        }

    }


public record LengthValue {
    public byte[] Length { get; set; }
    public byte[] Value { get; set; }

    public static LengthValue Dummy (string text) => new () {
            Length = [0xFF],
            Value = text.ToBytes()
            };
        
    }

public record BinaryEnvelopeEntry {

    public byte[] FrameStart { get; set; }
    public LengthValue UnsignedHeader;
    public LengthValue SignedHeader;
    public LengthValue Payload;

    public byte[] FrameEnd { get; set; }

    protected BinaryEnvelopeEntry() {
        }

    protected BinaryEnvelopeEntry(ParseDare parser) {
        FrameStart = parser.FrameStart();
        UnsignedHeader = parser.GetChunk();
        SignedHeader = parser.GetChunk();
        Payload = parser.GetChunk();
        FrameEnd = parser.FrameEnd(FrameStart);
        }

    public static BinaryEnvelopeEntry Dummy(string text) => new BinaryEnvelopeEntry() {
        FrameStart = [01, 02],
        FrameEnd = [02, 01],
        UnsignedHeader = LengthValue.Dummy("unsigned"),
        SignedHeader = LengthValue.Dummy("signed"),
        Payload = LengthValue.Dummy(text),
        };
    }

public record BinaryEnvelope : BinaryEnvelopeEntry {
    public byte[] TypeIndicator;

    public List<LengthValue> Payloads;

    public LengthValue Trailer;

    public byte[] Data;

    public BinaryEnvelope(byte[] data) : base() {
        Data = data;
        if (data == null) {
            TypeIndicator = [ 1, 0];
            UnsignedHeader = LengthValue.Dummy ("Header");
            SignedHeader = LengthValue.Dummy("Signed");
            Payloads = [
                LengthValue.Dummy("First"),
                LengthValue.Dummy("Second")];
            Trailer = LengthValue.Dummy("Trailer");
            return;
            }
        var parser = new ParseDare(data);

        TypeIndicator = parser.GetTypeIndicator();
        UnsignedHeader = parser.GetChunk();
        SignedHeader = parser.GetChunk();
        Payloads = parser.GetChunks();
        Trailer = parser.GetChunk();
        }

    }


public record BinarySequence {

    public byte[] TypeIndicator;

    public List<BinaryEnvelopeEntry> Envelopes;
    public byte[] Data;
    public BinarySequence(byte[] data) {
        Data = data;

        if (data == null) {
            TypeIndicator = [1, 0];
            Envelopes = [
                BinaryEnvelopeEntry.Dummy ("First"),
                BinaryEnvelopeEntry.Dummy ("Second")
                    ];
            return;
            }


        var parser = new ParseDare(data);
        TypeIndicator = parser.GetTypeIndicator();

        while (!parser.IsComplete) {
            }
        }

    }


public class ParseDare {

    byte[] Data;
    int Index = 0;

    public bool IsComplete => Index >= Data.Length;

    public ParseDare(byte[] data) {
        Data = data;
        }

    public byte[] GetTypeIndicator() {
        var buffer = new MemoryStream();

        bool going = true;
        while (going) {
            var next = Get();
            buffer.WriteByte(next);
            going = (next & 1) == 0;
            }

        return buffer.ToArray();
        }


    byte Get() => Data[Index++];

    (ulong, byte[]) GetVarint () {
        ulong result;

        var read = Get();
        var type = read & 0b1100_0000;
        result = (ulong)read & 0b0011_1111;

        var count = type switch {
            0 => 0,
            0b0100_0000 => 1,
            0b1000_0000 => 3,
            0b1100_0000 => 7,
            _ => throw new NYI()
            };


        var bytes = new byte[count+1];
        bytes[0] = read;

        for (var i = 0; i < count; i++) {
            read = Get();
            bytes[i+1] = read;

            result <<= 8;
            result |= read;
            }

        return (result, bytes);
        }



    byte[] GetRavint(byte[] start) => GetBytes((ulong) start.Length);


    byte[] GetBytes(ulong length) {
        var result = new byte[length];


        for (ulong i = 0; i < length; i++) {
            var next = Get();
            result [i] = next;
            }

        return result;

        }


    public LengthValue GetChunk() {
        var (length, bytes) = GetVarint();
        var data = GetBytes(length);
        return new LengthValue() {
            Length = bytes,
            Value = data
            };

        }

    public List<LengthValue> GetChunks() {
        var result = new List<LengthValue>();

        var (length, bytes) = GetVarint();
        while (length > 0) {
            var data = GetBytes(length);
            var chunk = new LengthValue() {
                Length = bytes,
                Value = data
                };
            result.Add(chunk);

            (length, bytes) = GetVarint();
            }

        return result;

        }

    public byte[] FrameStart() {
        var (length, bytes) = GetVarint();
        return bytes;
        }

    public byte[] FrameEnd(byte[] start) => GetRavint(start);

        


    }
