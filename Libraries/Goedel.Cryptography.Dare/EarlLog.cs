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
using Goedel.Protocol;

namespace Goedel.Cryptography.Dare;


public partial class EntryUpdate {

    public SequenceEvent SequenceEvent => Event.ToSequenceEvent();

    public EntryUpdate() {
        }


    public EntryUpdate(string id, string status) {
        Id = id;
        Event = status;
        }

    public EntryUpdate(string id, SequenceEvent status) {
        Id = id;
        Event = status.ToLabel();
        }


    }

public abstract class EarlLog : EarlSequence {
    protected EarlLog(
        EarlStream stream,
            DataEncoding dataEncoding) : base(stream, dataEncoding) {
        }
    public static EarlLog<T> Create<T> (
        string fileName) where T : JsonObject {
        var stream = EarlStream.Create(fileName, DareConstants.TypeIdentifierDareSequence);
        var result = new EarlLog<T>(stream);

        result.WriteInitial();

        return result;
        }


    public static EarlLog<T> Open<T>(
        string fileName) where T : JsonObject {

        var stream = EarlStream.OpenReadWrite(fileName);
        var sequence = new EarlLog<T>(stream);
        sequence.ReadInitial();

        return sequence;
        }



    }


/// <summary>Provides a view on a data log containing items of type T.</summary>
/// <typeparam name="T">The type of item logged.</typeparam>
public class EarlLog<T> : EarlLog where T : JsonObject {


    internal EarlLog(
                EarlStream stream,
            DataEncoding dataEncoding = DataEncoding.JSON) : base(stream, dataEncoding) {

        }

    /// <summary>Append an entry to the log constructing the appropriate
    /// unprotected and protected headers.</summary>
    /// <param name="item"></param>
    /// <returns>The entry index.</returns>
    public EarlEntryIndex Add(T item) {
        return Append(item);
        }





    public T ReadNextObject() {
        var envelope = ReadNext();

        var result = JsonObject.StreamParseTag<T>(envelope.Payload);
        return result;

        }



    }

