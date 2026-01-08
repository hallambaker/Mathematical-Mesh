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

public class EarlCatalog : EarlSequence {

    protected EarlCatalog(
        EarlStream stream) : base(stream) {
        }


    public static EarlCatalog<T> Create<T>(
    string fileName) where T : JsonObject {
        var stream = EarlStreamDebug.Create(fileName, DareConstants.TypeIdentifierDareSequence);
        var result = new EarlCatalog<T>(stream);

        result.WriteInitial();

        return result;
        }

    public static EarlCatalog<T> Open<T>(
            string fileName) where T : JsonObject {

        var stream = EarlStreamDebug.OpenReadWrite(fileName);
        var spool = new EarlCatalog<T>(stream);
        spool.ReadInitial();

        return spool;
        }
    }

public class EarlCatalog<T> : EarlCatalog where T : JsonObject {

    public Dictionary<string, T> EntriesById { get; } = [];

    internal EarlCatalog(
                EarlStream stream) : base(stream) {
        }

    public static EarlCatalog<T> Create(
        string fileName) {
        var stream = EarlStreamDebug.Create(fileName, DareConstants.TypeIdentifierDareSequence);
        var result = new EarlCatalog<T>(stream);

        result.WriteInitial();

        return result;
        }

    public EarlEntryIndex Add(T item) {
        var contentMeta = new ContentMeta() {
            UniqueId = item._PrimaryKey,
            Event = "Add"
            };
        EntriesById.Add(item._PrimaryKey, item);
        return Append(item, contentMeta);
        }

    public EarlEntryIndex Update(T item) {
        var contentMeta = new ContentMeta() {
            UniqueId = item._PrimaryKey,
            Event = "Add"
            };
        EntriesById.AddSafe(item._PrimaryKey, item);
        return Append(item, contentMeta);
        }

    public EarlEntryIndex Delete(string id) {
        var contentMeta = new ContentMeta() {
            UniqueId = id,
            Event = "Delete"
            };
        EntriesById.Remove(id);
        return Append([], contentMeta);
        }

    }