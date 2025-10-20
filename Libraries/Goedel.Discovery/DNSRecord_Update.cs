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
using Goedel.Discovery;

namespace Goedel.Discovery;


/// <summary>
/// DNS update records.
/// </summary>
public abstract class DNSRecord_Update : DNSItem {


    }


/// <summary>
/// Precondition, name is in use or not in use.
/// </summary>
public class DNSRecord_PreNameInUse : DNSRecord_Update {

    ///<summary>If true, condition is the name must NOT be in use.</summary>
    public bool Negate { get; set; }
    }


/// <summary>
/// Precondition, record set exists or does not exist..
/// </summary>
public class DNSRecord_PreRRSetExists : DNSRecord_Update {

    ///<summary>If true, condition is the record set must NOT exist.</summary>
    public bool Negate { get; set; }

    ///<summary>The record set to test.</summary>
    public DNSRecord Value { get; set; }
    }

/// <summary>
/// Add a record.
/// </summary>
public class DNSRecord_Add : DNSRecord_Update {

    ///<summary>The record to add.</summary>
    public DNSRecord Add { get; set; }


    /// <summary>
    /// Constructor, create an add update record for a record with label
    /// <paramref name="label"/>, type <paramref name="typeCode"/> and
    /// data <paramref name="data"/>.
    /// </summary>
    /// <param name="label">The record label.</param>
    /// <param name="typeCode">The record typecode</param>
    /// <param name="data">The record data.</param>
    public DNSRecord_Add(
                string label,
                DNSTypeCode typeCode,
                byte[] data) {
        
        Add = DNSRecord.DecodeRData(label, typeCode, data);
        Add.Domain = new Domain(label);
        }


    }

/// <summary>
/// DNS Update, delete all records.
/// </summary>
public class DNSRecord_DeleteAll : DNSRecord_Update {

    /// <summary>
    /// Constructor, delete all records.
    /// </summary>
    /// <param name="label">The record label to delete.</param>
    public DNSRecord_DeleteAll(
                string label) {
        }


    }




/// <summary>
/// DNS Update, delete all records of a specified type
/// </summary>
public class DNSRecord_DeleteRRset : DNSRecord_Update {

    /// <summary>
    /// Constructor, delete all records of type <paramref name="type"/>.
    /// </summary>
    /// <param name="label">The record label to delete.</param>
    /// <param name="type">The type of label to delete.</param>
    public DNSRecord_DeleteRRset(
                string label,
                DNSTypeCode type) {
        }



    }


/// <summary>
/// DNS Update, delete a specified resource record.
/// </summary>
public class DNSRecord_DeleteRR : DNSRecord_Update {

    /// <summary>
    /// The record to delete.
    /// </summary>
    public DNSRecord Delete { get; set; }

    /// <summary>
    /// Constructor, the record of with label <paramref name="label"/>,
    /// type <paramref name="type"/> and value <paramref name="data"/>.
    /// </summary>
    /// <param name="label">The record label to delete.</param>
    /// <param name="type">The type of label to delete.</param>
    /// <param name="data"></param>
    public DNSRecord_DeleteRR(
            string label,
                DNSTypeCode type,
                byte[] data) {
        //Delete = delete;
        }



    }
