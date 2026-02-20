
//  This file was automatically generated at 2/20/2026 3:32:46 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  constant version 3.0.0.1170
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.26200.0
//  
//  
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

using Goedel.Utilities;

namespace Goedel.Cryptography.Dare ;


///<summary>Sequence Index types</summary>
public enum EarlSequenceIndexType {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>Simple</summary>
    None,
    ///<summary>Terminal</summary>
    Terminal,
    ///<summary>Incremental</summary>
    Incremental,
    ///<summary>Separate</summary>
    Separate    }

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


///<summary>
///Constants specified in hallambaker-mesh-udf
///</summary>
public static partial class DareConstants {

    // File: Misc

    ///<summary>
    ///</summary>
    public const string DareSignaturePrefix = "DARE Signature v. 3.0";

    // File: ContainerTypes


    ///<summary>Jose enumeration tag for EarlSequenceIndexType.None</summary>
    public const string  EarlSequenceIndexTypeNoneTag = "None";
    ///<summary>Jose enumeration tag for EarlSequenceIndexType.Terminal</summary>
    public const string  EarlSequenceIndexTypeTerminalTag = "Terminal";
    ///<summary>Jose enumeration tag for EarlSequenceIndexType.Incremental</summary>
    public const string  EarlSequenceIndexTypeIncrementalTag = "Incremental";
    ///<summary>Jose enumeration tag for EarlSequenceIndexType.Separate</summary>
    public const string  EarlSequenceIndexTypeSeparateTag = "Separate";

    /// <summary>
    /// Convert the string <paramref name="text"/> to the corresponding enumeration
    /// value.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The enumeration value.</returns>
    public static EarlSequenceIndexType ToEarlSequenceIndexType (this string text) =>
        text switch {
            EarlSequenceIndexTypeNoneTag => EarlSequenceIndexType.None,
            EarlSequenceIndexTypeTerminalTag => EarlSequenceIndexType.Terminal,
            EarlSequenceIndexTypeIncrementalTag => EarlSequenceIndexType.Incremental,
            EarlSequenceIndexTypeSeparateTag => EarlSequenceIndexType.Separate,
            _ => EarlSequenceIndexType.Unknown
            };

    /// <summary>
    /// Convert the enumerated value <paramref name="data"/> to the corresponding string
    /// value.
    /// </summary>
    /// <param name="data">The enumerated value.</param>
    /// <returns>The text value.</returns>
    public static string ToLabel (this EarlSequenceIndexType data) =>
        data switch {
            EarlSequenceIndexType.None => EarlSequenceIndexTypeNoneTag,
            EarlSequenceIndexType.Terminal => EarlSequenceIndexTypeTerminalTag,
            EarlSequenceIndexType.Incremental => EarlSequenceIndexTypeIncrementalTag,
            EarlSequenceIndexType.Separate => EarlSequenceIndexTypeSeparateTag,
            _ => null
            };


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

    }

