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
namespace Goedel.Protocol;


/// <summary>Constants for tagging of JBCD encoded data</summary>
public partial class JSONBCD {


    /// <summary>8 bit length modifier</summary>
    public const byte Length8 = 0x00;
    /// <summary>16 bit length modifier</summary>
    public const byte Length16 = 0x01;
    /// <summary>32 bit length modifier</summary>
    public const byte Length32 = 0x02;
    /// <summary>64 bit length modifier</summary>
    public const byte Length64 = 0x03;
    /// <summary>64 bit length modifier</summary>
    public const byte Length128 = 0x05;
    /// <summary>Bignum length modifier. The following two bytes will give the length of the length,</summary>
    public const byte LengthBig = 0x05;

    /// <summary>Terminal UTF8 data string chunk</summary>
    public const byte StringTerm = 0x80;
    /// <summary>Non-terminal UTF8 data string chunk</summary>
    public const byte StringChunk = 0x84;
    /// <summary>Terminal binary data chunk</summary>
    public const byte DataTerm = 0x88;
    /// <summary>Non-terminal UTF8 data chunk</summary>
    public const byte DataChunk = 0x8C;

    /// <summary>Unidirectional frame record</summary>
    public const byte UFrame = 0xF0;
    /// <summary>Bidirectional frame record</summary>
    public const byte BFrame = 0xF4;

    /// <summary>Positive integer base</summary>
    public const byte PositiveInteger = 0xA0;
    /// <summary>Negative integer base</summary>
    public const byte NegativeInteger = 0xA8;

    /// <summary>Positive integer base</summary>
    public const byte PositiveBigInteger = PositiveInteger | LengthBig;
    /// <summary>Negative integer base</summary>
    public const byte NegativeBigInteger = NegativeInteger | LengthBig;


    /// <summary>True boolean values</summary>
    public const byte True = 0xB0;
    /// <summary>False boolean values</summary>
    public const byte False = 0xB1;
    /// <summary>Null object values</summary>
    public const byte Null = 0xB2;

    /// <summary>Terminal UTF8 data string chunk</summary>
    public const byte TagString = 0xB4;

    /// <summary>Insert data from tag with specified code.</summary>
    public const byte TagCode = 0xC0;
    /// <summary>Define a tag code</summary>
    public const byte TagDefinition = 0xC4;
    /// <summary>Define a tag code and insert corresponding data.</summary>
    public const byte TagCodeDefinition = 0xC8;
    /// <summary>Define a code dictionary</summary>
    public const byte TagDictionaryDefinition = 0xCC;

    /// <summary>Insert dictionary with specified hash.</summary>
    public const byte DictionaryHash = 0xD0;

    /// <summary>16 bit binary floating point values</summary>
    public const byte BinaryFloat16 = 0x90;
    /// <summary>32 bit binary floating point values</summary>
    public const byte BinaryFloat32 = 0x91;
    /// <summary>64 bit binary floating point values</summary>
    public const byte BinaryFloat64 = 0x92;
    /// <summary>128 bit binary floating point values</summary>
    public const byte BinaryFloat128 = 0x94;
    /// <summary>80 bit binary floating point values</summary>
    public const byte Intel80 = 0x95;
    /// <summary>32 bit decimal floating point values</summary>
    public const byte DecimalFloat32 = 0x96;
    /// <summary>64 bit decimal floating point values</summary>
    public const byte DecimalFloat64 = 0x97;
    /// <summary>128 bit decimal floating point values</summary>
    public const byte DecimalFloat128 = 0x98;
    }
