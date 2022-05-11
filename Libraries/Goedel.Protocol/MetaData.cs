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


namespace Goedel.Protocol;


/// <summary>
/// Metadata record. While the same data is available using System.Reflection, we wish to 
/// make use of a highly restricted approach that only exposes the JSON data model.
/// </summary>
public abstract record MetaData {

    ///<summary>If true, the field is a list field.</summary> 
    public virtual bool Multiple => false;
    }

/// <summary>
/// Metadata class describing boolean field.
/// </summary>
/// <param name="Setter">Set accessor</param>
/// <param name="Getter">Get accessor</param>
public record MetaDataBoolean (
        Action<bool?> Setter, 
        Func<bool?> Getter) : MetaData {
    }


/// <summary>
/// Metadata class describing boolean field.
/// </summary>
/// <param name="Setter">Set accessor</param>
/// <param name="Getter">Get accessor</param>
public record MetaDataInteger32(
        Action<int?> Setter,
        Func<int?> Getter) : MetaData {
    }

/// <summary>
/// Metadata class describing boolean field.
/// </summary>
/// <param name="Setter">Set accessor</param>
/// <param name="Getter">Get accessor</param>
public record MetaDataInteger64(
        Action<long?> Setter,
        Func<long?> Getter) : MetaData {
    }

/// <summary>
/// Metadata class describing boolean field.
/// </summary>
/// <param name="Setter">Set accessor</param>
/// <param name="Getter">Get accessor</param>
public record MetaDataBinary(
        Action<byte[]> Setter,
        Func<byte[]> Getter) : MetaData {
    }

/// <summary>
/// Metadata class describing boolean field.
/// </summary>
/// <param name="Setter">Set accessor</param>
/// <param name="Getter">Get accessor</param>
public record MetaDataString(
        Action<string> Setter,
        Func<string> Getter) : MetaData {
    }

/// <summary>
/// Metadata class describing boolean field.
/// </summary>
/// <param name="Setter">Set accessor</param>
/// <param name="Getter">Get accessor</param>
public record MetaDataDateTime(
        Action<DateTime?> Setter,
        Func<DateTime?> Getter) : MetaData {
    }

/// <summary>
/// Metadata class describing object field.
/// </summary>
/// <param name="Setter">Set accessor</param>
/// <param name="Getter">Get accessor</param>
/// <param name="Type">The type name</param>
/// <param name="Tagged">If true, the structure is a tagged structure</param>
public record MetaDataStruct(
        Action<object> Setter, 
        Func<object> Getter,
        string Type,
        bool Tagged=false) : MetaData {
    }



/// <summary>
/// Metadata record 
/// </summary>
public abstract record MetaDataList : MetaData {
    public override bool Multiple => true;
    }

/// <summary>
/// Metadata class describing boolean field.
/// </summary>
/// <param name="Setter">Set accessor</param>
/// <param name="Getter">Get accessor</param>
public record MetaDataListBoolean(
        Action<List<bool?>> Setter,
        Func<List<bool?>> Getter) : MetaDataList {
    }


/// <summary>
/// Metadata class describing boolean field.
/// </summary>
/// <param name="Setter">Set accessor</param>
/// <param name="Getter">Get accessor</param>
public record MetaDataListInteger32(
        Action<List<int?>> Setter,
        Func<List<int?>> Getter) : MetaDataList {
    }

/// <summary>
/// Metadata class describing boolean field.
/// </summary>
/// <param name="Setter">Set accessor</param>
/// <param name="Getter">Get accessor</param>
public record MetaDataListInteger64(
        Action<List<long?>> Setter,
        Func<List<long?>> Getter) : MetaDataList {
    }

/// <summary>
/// Metadata class describing boolean field.
/// </summary>
/// <param name="Setter">Set accessor</param>
/// <param name="Getter">Get accessor</param>
public record MetaDataListBinary(
        Action<List<byte[]>> Setter,
        Func<List<byte[]>> Getter) : MetaDataList {
    }

/// <summary>
/// Metadata class describing boolean field.
/// </summary>
/// <param name="Setter">Set accessor</param>
/// <param name="Getter">Get accessor</param>
public record MetaDataListString(
        Action<List<string>> Setter,
        Func<List<string>> Getter) : MetaDataList {
    }

/// <summary>
/// Metadata class describing boolean field.
/// </summary>
/// <param name="Setter">Set accessor</param>
/// <param name="Getter">Get accessor</param>
public record MetaDataListDateTime(
        Action<List<DateTime?>> Setter,
        Func<List<DateTime?>> Getter) : MetaDataList {
    }

/// <summary>
/// Metadata class describing object field.
/// </summary>
/// <param name="Setter">Set accessor</param>
/// <param name="Getter">Get accessor</param>
/// <param name="Type">The type name</param>
/// <param name="Tagged">If true, the structure is a tagged structure</param>
public record MetaDataListStruct(
        Action<object> Setter,
        Func<object> Getter,
        string Type,
        bool Tagged = false) : MetaDataList {
    }
