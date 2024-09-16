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


namespace Goedel.Cryptography;

/// <summary>
/// Combined Key Uses. This is a conjunction of the JOSE and PKIX key uses.
/// </summary>
[Flags]
public enum KeyUses {
    ///<summary>PKIX Sign</summary>
    DigitalSignature = 0x0001,       // EmailSignature | DataSignature | CodeSigning

    ///<summary>Jose Sign (alias for the PKIX bitmask)</summary>
    Sign = DigitalSignature,

    ///<summary>If clear, signatures may be repudiated</summary>
    NonRepudiation = 0x0002,       // Confirmation

    ///<summary>PKIX Encryption</summary>
    KeyEncipherment = 0x0004,       // EmailEncryption | DataEncryption

    ///<summary>Jose Encryption (alias for the PKIX bitmask)</summary>
    Encrypt = KeyAgreement,

    ///<summary>PKIX Flag, should not be used.</summary>
    DataEncipherment = 0x0008,       // Don't Use

    ///<summary>PKIX Key agreement (used for client, server authentication).</summary>
    KeyAgreement = 0x0010,       // ServerAuth | ClientAuth

    ///<summary>PKIX Sign certificates</summary>
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
    DecipherOnly = 0x0100,        // Don't use

    ///<summary>Jose Sign or Encryption (alias for the PKIX bitmask)</summary>
    Any = Sign | Encrypt
    }
