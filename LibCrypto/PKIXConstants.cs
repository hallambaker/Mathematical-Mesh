using System;
using System.Collections.Generic;
using Goedel.CryptoLibNG;
using Goedel.CryptoLibNG.PKIX;

namespace Goedel.CryptoLibNG.PKIX {

    /// <summary>
    /// X.500 String types. Most should be avoided.
    /// </summary>
    public enum StringType {
        /// <summary>
        /// US variant of the ASCII encoding.
        /// </summary>
        IA5,

        /// <summary>
        /// Synonym for IA5.
        /// </summary>
        ASCII = IA5,

        /// <summary>
        /// Avoid
        /// </summary>
        BMP,
        /// <summary>
        /// UTF8 encoding
        /// </summary>
        UTF8,

        /// <summary>
        /// Avoid
        /// </summary>
        Printable,

        /// <summary>
        /// Avoid
        /// </summary>
        Teletex,

        /// <summary>
        /// No really, just avoid, avoid, avoid.
        /// </summary>
        Universal
        }


    /// <summary>
    /// High level Key Uses
    /// </summary>
    public enum Application {
        /// <summary>
        /// Server Authentication
        /// </summary>

        ServerAuth = 0x0001,

        /// <summary>
        /// Client Authentication
        /// </summary>
        ClientAuth = 0x0002,

        /// <summary>
        /// Code Signing
        /// </summary>
        CodeSigning = 0x0004,

        /// <summary>
        /// Email encryption
        /// </summary>
        EmailEncryption = 0x0008,

        /// <summary>
        /// Email Signature
        /// </summary>
        EmailSignature = 0x0010,

        /// <summary>
        /// Data Encryption
        /// </summary>
        DataEncryption = 0x0020,

        /// <summary>
        /// Data Signature
        /// </summary>
        DataSignature = 0x0040,

        /// <summary>
        /// Timestamp
        /// </summary>
        TimeStamping = 0x0080,

        /// <summary>
        /// Signing OCSP status responses
        /// </summary>
        OCSP = 0x0100,

        /// <summary>
        /// Signing CRLs
        /// </summary>
        CRL = 0x0200,

        /// <summary>
        /// Mesh personal master profile signature.
        /// </summary>
        PersonalMaster = 0x0400,

        /// <summary>
        /// Confirmation
        /// </summary>
        Confirmation = 0x0800,

        /// <summary>
        /// Certificate Authority intermediate signer
        /// </summary>
        CA = 0x1000,

        /// <summary>
        /// Root of trust.
        /// </summary>
        Root = 0x2000,

        /// <summary>
        /// Device root.
        /// </summary>
        DeviceMaster = 0x4000,
        }




    /// <summary>
    /// PKIX Key Uses
    /// </summary>
    public enum KeyUses {
        /// <summary>
        /// Sign
        /// </summary>
        DigitalSignature = 0x0001,       // EmailSignature | DataSignature | CodeSigning
        
        /// <summary>
        /// If clear, signatures may be repudiated
        /// </summary>
        NonRepudiation = 0x0002,       // Confirmation

        /// <summary>
        /// Encryption
        /// </summary>
        KeyEncipherment = 0x0004,       // EmailEncryption | DataEncryption

        /// <summary>
        /// Don't use.
        /// </summary>
        DataEncipherment = 0x0008,       // Don't Use

        /// <summary>
        /// Key agreement (used for client, server authentication).
        /// </summary>
        KeyAgreement = 0x0010,       // ServerAuth | ClientAuth

        /// <summary>
        /// Sign certificates
        /// </summary>
        KeyCertSign = 0x0020,       // CA | Root

        /// <summary>
        /// Sign CRLs
        /// </summary>
        CRLSign = 0x0040,       // CRL

        /// <summary>
        /// Don't use
        /// </summary>
        EncipherOnly = 0x0080,       // Don't use

        /// <summary>
        /// Don't Use.
        /// </summary>
        DecipherOnly = 0x0100        // Don't use
        }


    }
