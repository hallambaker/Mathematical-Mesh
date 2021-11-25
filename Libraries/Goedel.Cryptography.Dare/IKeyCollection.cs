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
using System;

using Goedel.Cryptography.PKIX;

namespace Goedel.Cryptography.Dare;

/// <summary>
/// Stub class describing the result of a signature path validation. 
/// </summary>
public class TrustResult {

    ///<summary>If true a valid trust path was found.</summary>
    public bool Trusted => Exception == null;

    ///<summary>The trust path anchor.</summary>
    public string Anchor;

    ///<summary>If <see cref="Trusted"/> is false, contains the exception raised
    ///describing the failure.</summary>
    public Exception Exception;

    }

/// <summary>
/// Key collection extending IKeyLocate to add signature key validation capability.
/// </summary>
public interface IKeyCollection : IKeyLocate {

    /// <summary>
    /// Attempt to form a trust path for the key used to sign <paramref name="dareSignature"/>.
    /// </summary>
    /// <param name="dareSignature">The signature to validate.</param>
    /// <param name="anchor">If present specifies the fingerprint of a key that MUST anchor
    /// the trust path.</param>
    /// <returns>The result of the trust path analysis.</returns>
    TrustResult ValidateTrustPath(DareSignature dareSignature, string anchor = null);


    /// <summary>
    /// Attempt to erase the private key with fingerprint <paramref name="udf"/> from the
    /// associated persistence store.
    /// </summary>
    /// <param name="udf"></param>
    /// <returns>True if the key was found, otherwise false.</returns>
    void ErasePrivateKey(string udf);


    /// <summary>
    /// Locate the private key with fingerprint <paramref name="udf"/> and return
    /// the corresponding JSON description.
    /// </summary>
    /// <param name="udf">Key to locate</param>
    /// <returns>The JSON description (if found).</returns>
    IJson LocatePrivateKey(string udf);


    /// <summary>
    /// Persist the key pair specified by <paramref name="privateKey"/> and mark as exportable
    /// or non-exportable according to the value of <paramref name="Exportable"/>.
    /// </summary>
    /// <param name="udf">The UDF of the key</param>
    /// <param name="privateKey">The private key parameters.</param>
    /// <param name="Exportable">If true, the key is exportable.</param>
    void Persist(string udf, IPKIXPrivateKey privateKey, bool Exportable);


    /// <summary>
    /// Persist the key pair specified by <paramref name="joseKey"/> and mark as exportable
    /// or non-exportable according to the value of <paramref name="exportable"/>.
    /// </summary>
    /// <param name="udf">The UDF of the key</param>
    /// <param name="joseKey">The private key parameters.</param>
    /// <param name="exportable">If true, the key is exportable.</param>
    void Persist(string udf, IJson joseKey, bool exportable);
    }
