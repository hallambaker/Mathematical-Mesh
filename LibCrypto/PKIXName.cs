//Sample license text.
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Goedel.LibCrypto;

namespace Goedel.LibCrypto.PKIX {
    public partial class Name {

        /// <summary>
        /// Create a name with an empty segment list.
        /// </summary>
        public Name() {
            Member = new List<AttributeTypeValue>();
            }


        /// <summary>
        /// Create a name with a single segment.
        /// </summary>
        /// <param name="OID">Object identifier</param>
        /// <param name="Value">Text value.</param>
        /// <param name="Type">Text encoding.</param>
        public Name(int[] OID, string Value, StringType Type)
            : this() {
            Add(OID, Value, Type);
            }


        /// <summary>
        /// Create name from a text string.
        /// </summary>
        /// <param name="CommonName">Text</param>
        public Name(string CommonName)
            : this(Constants.OID__id_at_commonName, CommonName, StringType.IA5) {
            }


        /// <summary>
        /// Create name from the UDF fingerprint of a key.
        /// </summary>
        /// <param name="CryptoProvider"></param>
        public Name(CryptoProvider CryptoProvider) :
                this (CryptoProvider.UDF) {
            }


        /// <summary>
        /// Create name from the UDF fingerprint of a key.
        /// </summary>
        /// <param name="KeyPair">Key from which to create the fingerprint.</param>
        public Name(KeyPair KeyPair) :
            this(KeyPair.UDF) {
            }

        /// <summary>
        /// Add a name segment.
        /// </summary>
        /// <param name="OID">Object identifier</param>
        /// <param name="Value">Text value.</param>
        /// <param name="Type">Text encoding.</param>
        public void Add(int[] OID, string Value, StringType Type) {
            AttributeTypeValue AttributeTypeValue = new AttributeTypeValue(OID, Value, Type);
            Member.Add(AttributeTypeValue);
            }

        /// <summary>
        /// Convert to a singleton list.
        /// </summary>
        /// <returns>Singleton list with this as the only member.</returns>
        public List<Name> ToList() {
            List<Name> Result = new List<Name>();
            Result.Add(this);
            return Result;
            }
        }


    /// <summary>
    /// Attribute = type = value tripple
    /// </summary>
    public partial class AttributeTypeValue : Goedel.ASN.Root {

        /// <summary>
        /// Construct from components.
        /// </summary>
        /// <param name="OID">Object Identifier</param>
        /// <param name="Value">Value</param>
        /// <param name="StringType">Encoding.</param>
        public AttributeTypeValue(int[] OID, string Value, StringType StringType) {
            this.Type = OID;
            this.Value = new AnyString(Value, StringType);
            }

        }

    /// <summary>
    /// Encoding of X.500 text string.
    /// </summary>
    public partial class AnyString : Goedel.ASN.Root {
        /// <summary>
        /// Construct from StringType enumeration.
        /// </summary>
        /// <param name="Value">Text value.</param>
        /// <param name="StringType">Text Encoding.</param>
        public AnyString(string Value, StringType StringType) {
            switch (StringType) {
                case StringType.IA5: {
                    IA5String = Value;
                    break;
                    }
                case StringType.BMP: {
                    BMPString = Value;
                    break;
                    }
                case StringType.UTF8: {
                    UTF8String = Value;
                    break;
                    }
                case StringType.Printable: {
                    PrintableString = Value;
                    break;
                    }
                }
            }
        }    
    
    
    }
