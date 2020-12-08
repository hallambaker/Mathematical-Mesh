
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

using Goedel.Utilities;

namespace Goedel.Cryptography.Dare {


    ///<summary>Container types</summary>
    public enum ContainerType {
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
        Merkle        }

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
        None        }

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
        Any        }


    ///<summary>
    ///Constants specified in hallambaker-mesh-udf
    ///</summary>
    public static partial class DareConstants {

        // File: ContainerTypes


        ///<summary>Jose enumeration tag for ContainerType.List</summary>
        public const string  ContainerTypeListTag = "List";
        ///<summary>Jose enumeration tag for ContainerType.Digest</summary>
        public const string  ContainerTypeDigestTag = "Digest";
        ///<summary>Jose enumeration tag for ContainerType.Chain</summary>
        public const string  ContainerTypeChainTag = "Chain";
        ///<summary>Jose enumeration tag for ContainerType.Tree</summary>
        public const string  ContainerTypeTreeTag = "Tree";
        ///<summary>Jose enumeration tag for ContainerType.Merkle</summary>
        public const string  ContainerTypeMerkleTag = "Merkle";

        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static ContainerType ToContainerType (this string text) =>
            text switch {
                ContainerTypeListTag => ContainerType.List,
                ContainerTypeDigestTag => ContainerType.Digest,
                ContainerTypeChainTag => ContainerType.Chain,
                ContainerTypeTreeTag => ContainerType.Tree,
                ContainerTypeMerkleTag => ContainerType.Merkle,
                _ => ContainerType.Unknown
                };

        /// <summary>
        /// Convert the enumerated value <paramref name="data"/> to the corresponding string
        /// value.
        /// </summary>
        /// <param name="data">The enumerated value.</param>
        /// <returns>The text value.</returns>
        public static string ToLabel (this ContainerType data) =>
            data switch {
                ContainerType.List => ContainerTypeListTag,
                ContainerType.Digest => ContainerTypeDigestTag,
                ContainerType.Chain => ContainerTypeChainTag,
                ContainerType.Tree => ContainerTypeTreeTag,
                ContainerType.Merkle => ContainerTypeMerkleTag,
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
    }
