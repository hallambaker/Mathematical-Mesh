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
namespace Goedel.Discovery;



public abstract partial class DNSItem {

    /// <summary>The domain name</summary>
    public Domain Domain;
    /// <summary>Record type code</summary>
    public DNSClass RClass;
    /// <summary>Time to live</summary>
    public uint TTL;
    /// <summary>Record data</summary>
    public DNSBufferIndex RData;
    /// <summary>Start index</summary>
    public int Start;

    /// <summary>Convert to wire form</summary>
    /// <param name="Index">Output buffer</param>
    public virtual void Encode(DNSBufferIndex Index) {
        }

    public byte[] GetBytes() {
        var buffer = new DNSBufferIndex();
        Encode(buffer);
        return buffer.Bytes;
        }

    }


public record DnsRecordDefinition(
            DNSTypeCode code,
            string Tag,
            Func<DNSBufferIndex, int, DNSRecord> Decode,
            Func<Parse, DNSRecord> Parse
            ) {
    }


/// <summary>
/// Base class for DNS Records
/// </summary>
public abstract partial class DNSRecord : DNSItem {


    /// <summary>The type code</summary>
    public virtual DNSTypeCode Code => (0);

    /// <summary>The type text</summary>		
    public virtual string Label => ("Unknown");

    /// <summary>Description</summary>
    public virtual string Description => ("Record is not defined");

    /// <summary>Default constructor</summary>
    public DNSRecord() {
        }


    /// <summary>Decode record or query from buffer</summary>	
    /// <param name="Index">Input data</param>
    /// <returns>Parsed record.</returns>
    public static DNSRecord Decode(DNSBufferIndex Index) {
        DNSRecord record;

        Domain domain;
        DNSTypeCode typeCode;
        DNSClass rClass;
        uint ttl;
        int rdLength;

        domain = Index.ReadDomain();
        typeCode = (DNSTypeCode)Index.ReadInt16();
        rClass = (DNSClass)Index.ReadInt16();
        ttl = Index.ReadInt32();
        rdLength = Index.ReadInt16();
        int NextRecord = Index.Pointer + rdLength;

        if (DNS.DictionaryTypeCode.TryGetValue(typeCode, out var description)){
            record = description.Decode(Index, rdLength);
            }
        else {
            throw new NYI();
            }

        record.Domain = domain;
        record.RClass = rClass;
        record.TTL = ttl;
        Index.Pointer = NextRecord;

        return record;
        }

    public static DNSRecord DecodeRData(
                        string name,
                        DNSTypeCode typeCode,
                        byte[] data) {
        var buffer = new DNSBufferIndex(data);

        if (!DNS.DictionaryTypeCode.TryGetValue(typeCode, out var description)) {
            throw new NYI();
            }
        var record = description.Decode(buffer, data.Length);
        record.Domain = new Domain(name);

        return record;
        }



    /// <summary>Convert to canonical form</summary>
    /// <returns>Canonical form of record data contents</returns>
    public abstract string Canonical();


    /// <summary>
    /// Return data value in default unknown encoding.
    /// </summary>
    /// <returns>Encoding of record in unknown text encoding.</returns>
    public string Unknown() {
        string result = Unknown(out var encoding);

        for (int i = 0; i < encoding.Length; i++) {
            result += Canonicalize.Hex(encoding[i]);
            }

        return result;
        }

    /// <summary>
    /// Return data value in default unknown encoding.
    /// </summary>
    /// <param name="encoding">Encoded parameters in byte form</param>
    /// <returns>Encoding of record in unknown text encoding.</returns>
    public string Unknown(out byte[] encoding) {
        DNSBufferIndex DNSBufferIndex = new();
        this.Encode(DNSBufferIndex);
        encoding = DNSBufferIndex.Bytes;

        string result = "TYPE" + (int)Code + " \\# " + encoding.Length + " ";

        return result;
        }


    }


/// <summary>Unknown DNS record</summary>
public partial class DNSRecord_Unknown : DNSRecord {

    /// <summary>Decode record or query from buffer</summary>	
    /// <param name="Index">Input data</param>
    /// <param name="Length">Maximum amount of data to read</param>
    /// <returns>Parsed record.</returns>
    public static DNSRecord_Unknown Decode(DNSBufferIndex Index, int Length) {
        DNSRecord_Unknown NewRecord = new();

        Index.ReadL16Data(out NewRecord.RData);

        return NewRecord;
        }

    /// <summary>Convert to canonical form</summary>
    /// <returns>Canonical form of record data contents</returns>
    public override string Canonical() => Unknown();
    }



