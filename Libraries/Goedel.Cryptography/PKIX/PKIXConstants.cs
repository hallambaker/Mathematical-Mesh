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


namespace Goedel.Cryptography.PKIX;

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
