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

using System;
using System.Collections.Generic;

using Goedel.Cryptography.Dare;
using Goedel.IO;
using Goedel.Utilities;

namespace Goedel.XUnit;

/// <summary>
/// 
/// </summary>
public partial class TestItem {

    ///////<summary>Initialization property. Access this property to force initialization 
    ///////of the static method.</summary>
    ////public static object Initialize => null;

    //static TestItem() => AddDictionary(ref _TagDictionary);




    /// <summary>
    /// Primary key to use for the object. Note that a primary key MUST be unique. 
    /// </summary>
    public override string _PrimaryKey => AccountID;


    public const string KeyUserProfileUDF = "UserProfileUDF";
    readonly static List<string> Keys = new() { KeyUserProfileUDF };

    /// <summary>
    /// Secondary keys describing the object
    /// </summary>
    public override List<string> _Keys => Keys;

    /// <summary>
    /// Secondary key/values pairs describing the object
    /// </summary>
    public override List<KeyValuePair<string, string>> _KeyValues =>
        new() {
            new KeyValuePair<string, string>(KeyUserProfileUDF, UserProfileUDF)
            };


    /// <summary>
    /// Container header corresponding to persistence store entry
    /// </summary>
    public DareHeader ContainerHeader {
        get => _Metadata as DareHeader; set => _Metadata = value;
        }
    }


public class TestItemContainerPersistenceStore : PersistenceStore {

    IPersistenceIndex indexKeyUserProfileUDF;


    /// <summary>
    /// Open or create a persistence store in specified mode with 
    /// the specified file name, content type and optional comment.
    /// </summary>
    /// <param name="FileName">Log file.</param>
    /// <param name="ReadOnly">If true, persistence store must exist
    /// and will be opened in read-only mode. If false, persistence store
    /// is opened in read/write mode and a new store will be created
    /// if none exists.</param>
    /// <param name="Type">Type of data to store (the schema name).</param>
    /// <param name="Comment">Comment to be written to the log.</param>
    /// <param name="ContainerType">The Container type.</param>
    /// <param name="FileStatus">The file status in which to open the container.</param>
    public TestItemContainerPersistenceStore(string FileName, string Type = null,
                FileStatus FileStatus = FileStatus.OpenOrCreate,
                SequenceType ContainerType = SequenceType.Chain) : base(
                    FileName, Type, FileStatus, ContainerType) =>
                    indexKeyUserProfileUDF = GetIndex(TestItem.KeyUserProfileUDF);

    static TestItem Get(IPersistenceEntry DataItem) => DataItem.JsonObject as TestItem;


    /// <summary>
    /// Get the latest value of the TestItem object with the specified unique ID
    /// </summary>
    /// <param name="AccountID">The account identifier</param>
    /// <returns>The test item if found, otherwise null.</returns>
    public TestItem GetAccountID(string AccountID) {
        var Entry = Get(AccountID);
        return Entry != null ? Get(Entry) : null;
        }

    /// <summary>
    /// Get the latest value of the last TestItem object with the specified unique ID that was created.
    /// </summary>
    /// <param name="UserProfileUDF">The user profile UDF</param>
    /// <returns>The test item</returns>
    public TestItem GetUserProfileUDF(string UserProfileUDF) {
        var IndexEntry = indexKeyUserProfileUDF.Last(UserProfileUDF);
        var DataItem = IndexEntry.Data;
        return Get(DataItem);
        }

    ///// <summary>
    ///// Get the previous value(s) of a test item version.
    ///// </summary>
    ///// <param name="TestItem">The base version</param>
    ///// <param name="MaxResult">Maximum number of results to return.</param>
    ///// <param name="OnOrAfter">Only return versions that are on or after the specified value.</param>
    ///// <returns>The list of previous versions.</returns>
    //public static List<TestItem> GetPrevious(TestItem TestItem, int MaxResult, DateTime OnOrAfter) => throw new NYI();


    //public static TestItem GetRecord(int Record) =>
    //    // read the header and data from container

    //    //


    //    throw new NYI();



    }
