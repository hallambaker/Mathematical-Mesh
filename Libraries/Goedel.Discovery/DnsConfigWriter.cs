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
using System.Net;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Discovery;

/// <summary>
/// DNS documentation class, outputs a config file entry corresponding to a record.
/// </summary>
public class DnsConfigWriter : DNSBufferIndex {


    ///<summary>The output, defaults to <see cref="Console.Out"/></summary> 
    public TextWriter Output { get; init; } = Console.Out;

    ///<summary>Spacer output between fields</summary> 
    public string Spacer { get; init; } = "    ";

    /// <summary>
    /// Constructor, the values <see cref="Output"/> and <see cref="Spacer"/> can be set
    /// as initalizations.
    /// </summary>
    public DnsConfigWriter() {
        }

    ///<inheritdoc/>
    public void Encode(DNSRecord record) {

        Output.Write($"{ record.Domain.Name}  {record.Code}");
        WriteInt16(record.RClass); // Will always be IN
        record.Encode(this);

        // Trailing semicolon
        Output.WriteLine(";");
        }

    ///<inheritdoc/>
    public override void WriteInt16(DNSFlags data) {
        }

    ///<inheritdoc/>
    public override void Write(ushort data) {
        Output.Write(Spacer);
        Output.Write(data.ToString());
        }

    ///<inheritdoc/>
    public override void WriteByte(byte data) {
        Output.Write(Spacer);
        Output.Write(data.ToString());
        }

    ///<inheritdoc/>
    public override void WriteData(byte[] data) {
        // TBS !!!
        }

    ///<inheritdoc/>
    public override void WriteDomain(Domain Domain) {
        Output.Write(Spacer);
        Output.Write(Domain.Name);
        }

    ///<inheritdoc/>
    public override void WriteInt16(DNSClass data) {
        Output.Write(Spacer);
        Output.Write(data.ToString());
        }

    ///<inheritdoc/>
    public override void WriteInt16(DNSTypeCode data) {
        Output.Write(Spacer);
        Output.Write(data.ToString());
        }

    ///<inheritdoc/>
    public override void WriteInt16(int data) {
        Output.Write(Spacer);
        Output.Write(data.ToString());
        }

    ///<inheritdoc/>
    public override void WriteInt16(ushort data) {
        Output.Write(Spacer);
        Output.Write(data.ToString());
        }

    ///<inheritdoc/>
    public override void WriteInt32(uint data) {
        Output.Write(Spacer);
        Output.Write(data.ToString());
        }

    ///<inheritdoc/>
    public override void WriteInt48(ulong data) {
        Output.Write(Spacer);
        Output.Write(data.ToString());
        }

    ///<inheritdoc/>
    public override void WriteInt64(ulong data) {
        Output.Write(Spacer);
        Output.Write(data.ToString());
        }

    ///<inheritdoc/>
    public override void WriteIPv4(IPAddress data) {
        Output.Write(Spacer);
        Output.Write(data.ToString());
        }

    ///<inheritdoc/>
    public override void WriteIPv6(IPAddress data) => WriteIPv4(data);

    ///<inheritdoc/>
    public override void WriteL16Data(byte[] data) => WriteData(data);

    ///<inheritdoc/>
    public override void WriteL8Data(byte[] data) => WriteData(data);

    ///<inheritdoc/>
    public override void WriteMail(string data) {
        Output.Write(Spacer);
        Output.Write(data.ToString());
        }

    ///<inheritdoc/>
    public override void WriteName(string data) {
        Output.Write(Spacer);
        Output.Write(data.ToString());
        }

    ///<inheritdoc/>
    public override void WriteString(string data) {
        Output.Write(Spacer);
        Output.Write('\"');
        Output.Write(data.ToString());
        Output.Write('\"');
        }

    ///<inheritdoc/>
    public override void WriteString8(string data) => WriteString(data);

    ///<inheritdoc/>
    public override void WriteTag(string tag) {
        Output.Write(Spacer);
        Output.Write(tag);
        }
    }
