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


/// <summary>
/// Index handle for data stored in a <see cref="StoreIndex"/> in-memory index.
/// </summary>
public class StoreEntry : IPersistenceEntry {


    #region // Propeties and fields

    ///<summary>The container the store entry belongs to</summary>
    Sequence Container { get; }

    /////<summary>The enveloped data</summary>
    //public DareEnvelope DareEnvelope;

    ///<summary>The envelope header</summary>
    public DareHeader ContainerHeader; //=> DareEnvelope.Header as ContainerHeader;

    ///<summary>The envelope metadata</summary>
    public ContentMeta ContentInfo => ContainerHeader.ContentMeta;

    ///<summary>Unique identifier of entry;</summary>
    public string UniqueID => ContentInfo?.UniqueId;

    ///<summary>The container frame</summary>
    public long FrameCount => ContainerHeader.SequenceInfo.LIndex;

    ///<summary>If true the object haws been deleted and cannot be further modified.</summary>

    public bool Deleted => ContentInfo?.Event == PersistenceStore.EventDelete;

    ///<summary>The JSONObject.</summary>
    public JsonObject JsonObject => jsonObject ?? FrameIndex.GetJSONObject(Container).CacheValue(out jsonObject);
    JsonObject jsonObject;

    ///<summary>The frame index within the container</summary>
    public SequenceFrameIndex FrameIndex;




    #endregion
    #region // Related records

    /// <summary>
    /// The previous object instance value for this object instance.
    /// </summary>
    public IPersistenceEntry Previous { get; }

    /// <summary>
    /// The first object instance value for this object instance.
    /// </summary>
    public IPersistenceEntry First { get; }




    #endregion

    /// <summary>
    /// Constructor, creates an entry for the specified container header, data and previous relationship.
    /// </summary>
    /// <param name="container">Container to create the entry in.</param>
    /// <param name="dareEnvelope">The envelope entry.</param>
    /// <param name="previous">Link to previous value of this object</param>
    /// <param name="item">The JSONObject representation.</param>
    public StoreEntry(Sequence container,
                DareEnvelope dareEnvelope,
                StoreEntry previous,
                JsonObject item = null) {
        Container = container;
        jsonObject = item;

        ContainerHeader = dareEnvelope.Header as DareHeader;
        Previous = previous;
        First = previous?.First ?? this;
        }

    /// <summary>
    /// Constructor, creates an entry for the specified container header, data and previous relationship.
    /// </summary>
    /// <param name="frameIndex">The position of the entry within the container frame.</param>
    /// <param name="previous">Link to previous value of this object</param>
    /// <param name="container"></param>
    /// <param name="item">The JSONObject representation.</param>
    public StoreEntry(
                SequenceFrameIndex frameIndex,
                StoreEntry previous,
                Sequence container,
                JsonObject item = null) {
        if ((frameIndex.DataPosition == 0) & (frameIndex.Header.Index > 0)) {

            }



        //((frameIndex.DataPosition == 0) & (FrameCount > 0)).AssertFalse(Internal.Throw);


        Container = container;
        ContainerHeader = frameIndex.Header;


        FrameIndex = frameIndex;
        jsonObject = item;

        Previous = previous;
        First = previous?.First ?? this;
        }


    //public JsonObject GetJsonObject(IKeyLocate keyCollection) => throw new System.NotImplementedException();
    //public byte[] GetPayload(IKeyLocate keyCollection) => throw new System.NotImplementedException();
    }


