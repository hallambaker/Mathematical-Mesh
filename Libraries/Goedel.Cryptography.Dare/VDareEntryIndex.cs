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

/// <summary>Index of entry in a DARE Sequence.</summary>
/// <param name="Frame">The frame number.</param>
/// <param name="Start">The first byte of the frame</param>
/// <param name="Length">The number of bytes in the frame.</param>
/// <param name="PayloadStart">The first byte of the payload.</param>
/// <param name="PayloadLength">The number of bytes in the payload</param>
public record VDareEntryIndex(
        long Frame,
        long Start,
        long Length,
        long PayloadStart,
        long PayloadLength) {

    /// <summary>Envelope constructed from the corresponding entry.</summary>
    public EarlEnvelope? EarlEnvelope { get; set; } = null;

    /// <summary>The primary key.</summary>
    public string Id { get; set; } = null;

    /// <summary>The payload as a JSonObject</summary>
    public JsonObject JsonObject { get; set; } = null;

    /// <summary>The index of the previous entry.</summary>
    public VDareEntryIndex? Previous { get; set; } = null;
    
    /// <summary>If true, the entry object has been deleted.</summary>
    public bool Deleted { get; set; } = false;
    }

/// <summary>Typed tndex of entry in a DARE Sequence.</summary>
/// <param name="Frame">The frame number.</param>
/// <param name="Start">The first byte of the frame</param>
/// <param name="Length">The number of bytes in the frame.</param>
/// <param name="PayloadStart">The first byte of the payload.</param>
/// <param name="PayloadLength">The number of bytes in the payload</param>
/// <typeparam name="T">The type of the corresponding entry payload.</typeparam>
public record VDareEntryIndex<T>(
        long Frame,
        long Start,
        long Length,
        long PayloadStart,
        long PayloadLength) : VDareEntryIndex (Frame, Start, Length, PayloadStart, PayloadLength) 
                where T : JsonObject {

    /// <summary>The payload as the underlying type.</summary>
    public T Object => JsonObject as T;

    /// <summary>If true, this is the default entry.</summary>
    public bool Default { get; set; }

    /// <summary>The primary key.</summary>
    public string PrimaryKey => Object?._PrimaryKey ?? EarlEnvelope?.SignedHeader?.UniqueId;

    /// <summary>The list of secondary keys.</summary>
    public List<string> SecondaryKeys => Object?._SecondaryKeys ?? EarlEnvelope?.SignedHeader?.Labels;

    }