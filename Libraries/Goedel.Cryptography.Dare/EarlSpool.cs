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
namespace Goedel.Cryptography.Dare;

public class EarlSpool : EarlSequence {

    protected EarlSpool(
        EarlStream stream) : base(stream) {
        }


    public static EarlSpool<T> Create<T>(
    string fileName) where T : JsonObject {
        var stream = EarlStreamDebug.Create(fileName, DareConstants.TypeIdentifierDareSequence);
        var result = new EarlSpool<T>(stream);

        result.WriteInitial();

        return result;
        }

    public static EarlSpool<T> Open<T>(
            string fileName) where T : JsonObject {

        var stream = EarlStreamDebug.OpenReadWrite(fileName);
        var spool = new EarlSpool<T>(stream);
        spool.ReadInitial();

        return spool;
        }

    }

/// <summary>Provides a view on a data spool containing a sequence items of 
/// type T, each oif which has a unique primary key. Each item has an associated 
/// state which MAY be modified by subsequent entries.</summary>
/// <typeparam name="T">The type of item stored.</typeparam>
public class EarlSpool<T> : EarlSpool where T : JsonObject {

    public Dictionary<string, T> StatusDictionary { get; } = [];

    internal EarlSpool(
                EarlStream stream) : base(stream) {
        }

    public EarlEntryIndex Add(T item, string state) {

        return Append(item);
        }

    public EarlEntryIndex Update(List<EntryUpdate> updates) {

        var updateSet = new EntryUpdateSet() {
            Entries = updates
            };

        throw new NotImplementedException();
        }

    }