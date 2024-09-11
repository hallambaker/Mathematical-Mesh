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
using Goedel.Cryptography.Standard;
using Goedel.Protocol;
using Goedel.Utilities;

namespace Goedel.Cryptography.Test;




public class TestDare {

    long BodyStart { get; }
    long TrailerStart { get; }
    DareEnvelope Message { get; }


    public TestDare(byte[] envelope) : this (new MemoryStream(envelope)){ 
        }

    /// <summary>
    /// Read an envelope from <paramref name="inputStream"/> without decrypting the
    /// message body.
    /// </summary>
    /// <param name="inputStream"></param>
    public TestDare(
                Stream inputStream) {

        var jsonBcdReader = new JsonBcdReader(inputStream);
        Message = DareEnvelope.DecodeHeader(jsonBcdReader);

        BodyStart = inputStream.Position;

        // need to read in the value verbatim here...

        //var decoder = Message.Header.GetDecoder(
        //    jsonBcdReader, out var Reader,
        //    keyCollection: keyCollection,
        //    verify: true);


        //var outputStream = new MemoryStream();
        //Reader.CopyTo(outputStream);
        //outputStream.Flush();
        //decoder.Close();
        //Message.Body = outputStream.ToArray();

        Message.Body = jsonBcdReader.ReadBinary();


        // read in the trailer
        if (jsonBcdReader.NextArray()) {
            TrailerStart = inputStream.Position;

            Message.Trailer = DareTrailer.FromJson(jsonBcdReader, false);
            }

        //var payloadDigest = 
        //        Message.Trailer?.PayloadDigest ??
        //        Message.Header.PayloadDigest;

        //payloadDigest.AssertEqual(decoder.DigestValue, NYI.Throw);

        }


    public byte[] GetBytes() {
        using var stream = new MemoryStream();
        var writer = new JsonBWriter(stream);

        writer.WriteArrayStart();
        Message.Header.Serialize(writer);
        writer.WriteArraySeparator();
        writer.WriteBinary(Message.Body);

        if (Message.Trailer != null) {
            writer.WriteArraySeparator();
            Message.Trailer.Serialize(writer);
            }
        writer.WriteArrayEnd();
        writer.Flush();
        stream.Flush();

        return stream.ToArray();
        }

    /// <summary>
    /// Corrupt the envelope body and correct the payload digest.
    /// </summary>
    public void CorruptBody() {
        // flip the first bit
        Message.Body[0] ^= 0x01;

        var digestLocation = Message.Trailer ?? Message.Header;

        switch (Message.Header.DigestAlgorithm) {
            case JoseConstants.SHA2:
            case JoseConstants.SHA2_512: {
                var provider = new CryptoProviderSHA2_512();

                digestLocation.PayloadDigest = provider.ProcessData(Message.Body);
                break;
                }
            case JoseConstants.SHA3:
            case JoseConstants.SHA3_512: {
                var provider = new CryptoProviderSHA3_512();

                digestLocation.PayloadDigest = provider.ProcessData(Message.Body);
                break;
                }
            }

        }



    }
