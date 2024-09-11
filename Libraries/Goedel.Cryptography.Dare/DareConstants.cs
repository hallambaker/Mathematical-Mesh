
//  This file was automatically generated at 9/11/2024 2:40:10 AM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  constant version 3.0.0.945
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.22631.0
//  
//  
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

using Goedel.Utilities;

namespace Goedel.Cryptography.Dare ;


///<summary>Sequence types</summary>
public enum SequenceType {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>List</summary>
    List,
    ///<summary>Digest</summary>
    Digest,
    ///<summary>Chain</summary>
    Chain,
    ///<summary>Tree</summary>
    Tree,
    ///<summary>Merkle</summary>
    Merkle    }

///<summary>Encryption policies</summary>
public enum PolicyEncryption {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>Once</summary>
    Once,
    ///<summary>Session</summary>
    Session,
    ///<summary>Isolated</summary>
    Isolated,
    ///<summary>None</summary>
    None    }

///<summary>Signature policies</summary>
public enum PolicySignature {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>None</summary>
    None,
    ///<summary>Isolated</summary>
    Isolated,
    ///<summary>Last</summary>
    Last,
    ///<summary>Any</summary>
    Any    }

///<summary>Sequence Events</summary>
public enum SequenceEvent {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>New</summary>
    New,
    ///<summary>Update</summary>
    Update,
    ///<summary>Delete</summary>
    Delete,
    ///<summary>Erase</summary>
    Erase    }


///<summary>
///Constants specified in hallambaker-mesh-udf
///</summary>
public static partial class DareConstants {

    // File: Misc

    ///<summary>
    ///</summary>
    public const string DareSignaturePrefix = "DARE Signature v. 3.0";

    // File: ContainerTypes


    ///<summary>Jose enumeration tag for SequenceType.List</summary>
    public const string  SequenceTypeListTag = "List";
    ///<summary>Jose enumeration tag for SequenceType.Digest</summary>
    public const string  SequenceTypeDigestTag = "Digest";
    ///<summary>Jose enumeration tag for SequenceType.Chain</summary>
    public const string  SequenceTypeChainTag = "Chain";
    ///<summary>Jose enumeration tag for SequenceType.Tree</summary>
    public const string  SequenceTypeTreeTag = "Tree";
    ///<summary>Jose enumeration tag for SequenceType.Merkle</summary>
    public const string  SequenceTypeMerkleTag = "Merkle";

    /// <summary>
    /// Convert the string <paramref name="text"/> to the corresponding enumeration
    /// value.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The enumeration value.</returns>
    public static SequenceType ToSequenceType (this string text) =>
        text switch {
            SequenceTypeListTag => SequenceType.List,
            SequenceTypeDigestTag => SequenceType.Digest,
            SequenceTypeChainTag => SequenceType.Chain,
            SequenceTypeTreeTag => SequenceType.Tree,
            SequenceTypeMerkleTag => SequenceType.Merkle,
            _ => SequenceType.Unknown
            };

    /// <summary>
    /// Convert the enumerated value <paramref name="data"/> to the corresponding string
    /// value.
    /// </summary>
    /// <param name="data">The enumerated value.</param>
    /// <returns>The text value.</returns>
    public static string ToLabel (this SequenceType data) =>
        data switch {
            SequenceType.List => SequenceTypeListTag,
            SequenceType.Digest => SequenceTypeDigestTag,
            SequenceType.Chain => SequenceTypeChainTag,
            SequenceType.Tree => SequenceTypeTreeTag,
            SequenceType.Merkle => SequenceTypeMerkleTag,
            _ => null
            };

    // File: EncryptionPolicies


    ///<summary>Jose enumeration tag for PolicyEncryption.Once</summary>
    public const string  PolicyEncryptionOnceTag = "Once";
    ///<summary>Jose enumeration tag for PolicyEncryption.Session</summary>
    public const string  PolicyEncryptionSessionTag = "Session";
    ///<summary>Jose enumeration tag for PolicyEncryption.Isolated</summary>
    public const string  PolicyEncryptionIsolatedTag = "Isolated";
    ///<summary>Jose enumeration tag for PolicyEncryption.None</summary>
    public const string  PolicyEncryptionNoneTag = "None";

    /// <summary>
    /// Convert the string <paramref name="text"/> to the corresponding enumeration
    /// value.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The enumeration value.</returns>
    public static PolicyEncryption ToPolicyEncryption (this string text) =>
        text switch {
            PolicyEncryptionOnceTag => PolicyEncryption.Once,
            PolicyEncryptionSessionTag => PolicyEncryption.Session,
            PolicyEncryptionIsolatedTag => PolicyEncryption.Isolated,
            PolicyEncryptionNoneTag => PolicyEncryption.None,
            _ => PolicyEncryption.Unknown
            };

    /// <summary>
    /// Convert the enumerated value <paramref name="data"/> to the corresponding string
    /// value.
    /// </summary>
    /// <param name="data">The enumerated value.</param>
    /// <returns>The text value.</returns>
    public static string ToLabel (this PolicyEncryption data) =>
        data switch {
            PolicyEncryption.Once => PolicyEncryptionOnceTag,
            PolicyEncryption.Session => PolicyEncryptionSessionTag,
            PolicyEncryption.Isolated => PolicyEncryptionIsolatedTag,
            PolicyEncryption.None => PolicyEncryptionNoneTag,
            _ => null
            };

    // File: SignaturePolicies


    ///<summary>Jose enumeration tag for PolicySignature.None</summary>
    public const string  PolicySignatureNoneTag = "None";
    ///<summary>Jose enumeration tag for PolicySignature.Isolated</summary>
    public const string  PolicySignatureIsolatedTag = "Isolated";
    ///<summary>Jose enumeration tag for PolicySignature.Last</summary>
    public const string  PolicySignatureLastTag = "Last";
    ///<summary>Jose enumeration tag for PolicySignature.Any</summary>
    public const string  PolicySignatureAnyTag = "Any";

    /// <summary>
    /// Convert the string <paramref name="text"/> to the corresponding enumeration
    /// value.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The enumeration value.</returns>
    public static PolicySignature ToPolicySignature (this string text) =>
        text switch {
            PolicySignatureNoneTag => PolicySignature.None,
            PolicySignatureIsolatedTag => PolicySignature.Isolated,
            PolicySignatureLastTag => PolicySignature.Last,
            PolicySignatureAnyTag => PolicySignature.Any,
            _ => PolicySignature.Unknown
            };

    /// <summary>
    /// Convert the enumerated value <paramref name="data"/> to the corresponding string
    /// value.
    /// </summary>
    /// <param name="data">The enumerated value.</param>
    /// <returns>The text value.</returns>
    public static string ToLabel (this PolicySignature data) =>
        data switch {
            PolicySignature.None => PolicySignatureNoneTag,
            PolicySignature.Isolated => PolicySignatureIsolatedTag,
            PolicySignature.Last => PolicySignatureLastTag,
            PolicySignature.Any => PolicySignatureAnyTag,
            _ => null
            };

    // File: SequenceEvents


    ///<summary>Jose enumeration tag for SequenceEvent.New</summary>
    public const string  SequenceEventNewTag = "New";
    ///<summary>Jose enumeration tag for SequenceEvent.Update</summary>
    public const string  SequenceEventUpdateTag = "Update";
    ///<summary>Jose enumeration tag for SequenceEvent.Delete</summary>
    public const string  SequenceEventDeleteTag = "Delete";
    ///<summary>Jose enumeration tag for SequenceEvent.Erase</summary>
    public const string  SequenceEventEraseTag = "Erase";

    /// <summary>
    /// Convert the string <paramref name="text"/> to the corresponding enumeration
    /// value.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The enumeration value.</returns>
    public static SequenceEvent ToSequenceEvent (this string text) =>
        text switch {
            SequenceEventNewTag => SequenceEvent.New,
            SequenceEventUpdateTag => SequenceEvent.Update,
            SequenceEventDeleteTag => SequenceEvent.Delete,
            SequenceEventEraseTag => SequenceEvent.Erase,
            _ => SequenceEvent.Unknown
            };

    /// <summary>
    /// Convert the enumerated value <paramref name="data"/> to the corresponding string
    /// value.
    /// </summary>
    /// <param name="data">The enumerated value.</param>
    /// <returns>The text value.</returns>
    public static string ToLabel (this SequenceEvent data) =>
        data switch {
            SequenceEvent.New => SequenceEventNewTag,
            SequenceEvent.Update => SequenceEventUpdateTag,
            SequenceEvent.Delete => SequenceEventDeleteTag,
            SequenceEvent.Erase => SequenceEventEraseTag,
            _ => null
            };

    }

