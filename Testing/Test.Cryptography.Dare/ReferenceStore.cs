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

using System.Collections.Generic;
using System.Drawing;
using Goedel.Cryptography.Dare;
using Goedel.Mesh;
using Goedel.Test;
using Microsoft.VisualBasic;

namespace Goedel.XUnit;

public record ReferenceStore {



    public TestBase TestBase { get; }

    public DeterministicSeed Seed => TestBase.Seed;


    public Dictionary<string, ReferenceEnvelope> DictionaryData { get; } = new();

    public List<ReferenceEnvelope> ListContents { get; }  = new();


    public int Serial => ListContents.Count;

    public int Count => DictionaryData.Count;

    public int Length { get; init; } = 100;

    public bool RandomSize { get; init; } = false ;


    public ReferenceStore(TestBase testBase) {
        TestBase = testBase;
        }



    public string GetUniqueId(int serial) =>
            Seed.GetNonce("ReferenceEnvelope", serial);

    public string GetVersionId(int serial, int version) =>
            Seed.GetNonce("ReferenceEnvelope", serial);

    public MessageTest GetMessageTest(int serial, int version, int length, bool randomSize) {
        var result = new MessageTest() {
            UniqueId = GetUniqueId(serial),
            VersionId = GetVersionId(serial, version),
            Serial = serial,
            Version = version,
            Seed = Seed.Seed,
            Length = randomSize ? length : null
            };

        var label = $"{serial}-{version}";
        var dataLength = randomSize ? Seed.GetRandomInt(length, serial, label) : 0;
        result.Data = Seed.GetTestBytes(dataLength, label);

        return result;
        }

    public CatalogEntryTest GetCatalogEntryTest(int serial, int version, int length, bool randomSize) {

        var result = new CatalogEntryTest() {
            UniqueId = GetUniqueId(serial),
            VersionId = GetVersionId(serial, version),
            Serial = serial,
            Version = version,
            Seed = Seed.Seed,
            Length = randomSize ? length : null
            };

        var label = $"{serial}-{version}";
        var dataLength = randomSize ? Seed.GetRandomInt(length, serial, label) : 0;
        result.Data = Seed.GetTestBytes(dataLength, label);

        return result;
        }


    public DareEnvelope AddMessage(int? length = null, bool? randomSize= null) {

        var envelope = new ReferenceEnvelope(this, Serial, length ?? Length, randomSize ?? RandomSize);

        var message = envelope.GetMessageTest();
        //var result = GetEnvelopedMessageTest();
        ListContents.Add(envelope);

        message.Envelope();

        return message.DareEnvelope;
        }


    public DareEnvelope AddItem(int? length = null, bool? randomSize = null) {

        var envelope = new ReferenceEnvelope(this, Serial, length ?? Length, randomSize ?? RandomSize);

        var message = envelope.GetCatalogEntryTest();
        //var result = GetEnvelopedMessageTest();
        ListContents.Add(envelope);

        message.Envelope();

        return message.DareEnvelope;
        }




    public void Verify(DareEnvelope envelope, int serial) {
        }


    public void SetStatus(int serial, string status) {
        
        
        }







    }


public record ReferenceEnvelope {

    ReferenceStore ReferenceStore { get; }

    public DeterministicSeed Seed => ReferenceStore.Seed;

    public int Serial { get; }

    public int Version { get; private set; } = 0;

    public string UniqueId { get; }

    public int Length { get; }

    public bool RandomSize { get; }


    public string Status { get; set; }

    public string DigestValue { get; set; }



    public ReferenceEnvelope(
                ReferenceStore referenceStore,
                int serial,
                int length, 
                bool randomSize
                ) {
        ReferenceStore = referenceStore;
        Serial = serial;
        Length = length;
        RandomSize = randomSize;

        UniqueId = Seed.GetNonce("Data", Serial);
        }

    public MessageTest GetMessageTest() => 
                    ReferenceStore.GetMessageTest(Serial, Version, Length, RandomSize);

    public CatalogEntryTest GetCatalogEntryTest() => 
                    ReferenceStore.GetCatalogEntryTest(Serial, Version, Length, RandomSize);


    public DareEnvelope GetEnvelopedMessageTest() {
        var message = GetMessageTest();
        message.Envelope();

        return message.DareEnvelope;
        }


    }

