
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

using Goedel.Utilities;

namespace Goedel.Cryptography.Dare {


    ///<summary>Container types</summary>
    public enum ContainerType {
        ///<summary>Undefined type</summary>
        Unknown,
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
        Unknown,
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
        Unknown,
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


        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static  ContainerType ToContainerType (this string text) =>
            text switch {
                "List" => ContainerType.List,
                "Digest" => ContainerType.Digest,
                "Chain" => ContainerType.Chain,
                "Tree" => ContainerType.Tree,
                "Merkle" => ContainerType.Merkle,
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
                ContainerType.List => "List",
                ContainerType.Digest => "Digest",
                ContainerType.Chain => "Chain",
                ContainerType.Tree => "Tree",
                ContainerType.Merkle => "Merkle",
                _ => null
                };

        // File: EncryptionPolicies


        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static  PolicyEncryption ToPolicyEncryption (this string text) =>
            text switch {
                "Once" => PolicyEncryption.Once,
                "Session" => PolicyEncryption.Session,
                "Isolated" => PolicyEncryption.Isolated,
                "None" => PolicyEncryption.None,
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
                PolicyEncryption.Once => "Once",
                PolicyEncryption.Session => "Session",
                PolicyEncryption.Isolated => "Isolated",
                PolicyEncryption.None => "None",
                _ => null
                };

        // File: SignaturePolicies


        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static  PolicySignature ToPolicySignature (this string text) =>
            text switch {
                "None" => PolicySignature.None,
                "Isolated" => PolicySignature.Isolated,
                "Last" => PolicySignature.Last,
                "Any" => PolicySignature.Any,
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
                PolicySignature.None => "None",
                PolicySignature.Isolated => "Isolated",
                PolicySignature.Last => "Last",
                PolicySignature.Any => "Any",
                _ => null
                };

        }
    }
