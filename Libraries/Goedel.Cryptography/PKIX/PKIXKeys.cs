﻿#region // Copyright - MIT License
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
using System.Security.Cryptography;

namespace Goedel.Cryptography.PKIX;

/// <summary>
/// Interface permitting Key classes to be managed as if they inherited from
/// a common base class.
/// </summary>
public interface IPKIXData {

    /// <summary>
    /// Return the DER encoding of this structure
    /// </summary>
    /// <returns>The DER encoded value.</returns>
    byte[] DER();


    /// <summary>
    /// Return the algorithm identifier that represents this key
    /// </summary>
    int[] OID { get; }

    ///// <summary>
    ///// Return an ASN.1 object
    ///// </summary>
    //ASN.Root GetASN { get; }

    }


/// <summary>
/// Interface permitting Key classes to be managed as if they inherited from
/// a common base class.
/// </summary>
public interface IPKIXPublicKey : IPKIXData {

    /// <summary>
    /// Construct a PKIX SubjectPublicKeyInfo block
    /// </summary>
    /// <param name="OID">The OID value</param>
    /// <returns>The PKIX structure</returns>
    SubjectPublicKeyInfo SubjectPublicKeyInfo(int[] OID = null);

    /// <summary>
    /// Return the corresponding public parameters
    /// </summary>
    IPKIXPublicKey PublicParameters { get; }

    }


/// <summary>
/// Interface permitting Key classes to be managed as if they inherited from
/// a common base class.
/// </summary>
public interface IPKIXPrivateKey : IPKIXPublicKey {

    }

/// <summary>
/// Interface permitting Key classes to be managed as if they inherited from
/// a common base class.
/// </summary>
public interface IPKIXAgreement : IPKIXData {
    }


public partial class PKIXPublicKeyDH : IPKIXPublicKey, IKeyPublicDH {

    /// <summary>
    /// Construct a PKIX SubjectPublicKeyInfo block
    /// </summary>
    /// <param name="OIDValue">The OID value</param>
    /// <returns>The PKIX structure</returns>
    public SubjectPublicKeyInfo SubjectPublicKeyInfo(int[] OIDValue = null) {
        OIDValue ??= OID;
        return new SubjectPublicKeyInfo(OIDValue, DER());
        }

    /// <summary>
    /// Return the algorithm identifier that represents this key
    /// </summary>
    public override int[] OID => Constants.OID__id_dh_public;


    /// <summary>
    /// Return the corresponding public parameters
    /// </summary>
    public IPKIXPublicKey PublicParameters => this;

    byte[] IKeyPublicDH.Shared { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    byte[] IKeyPublicDH.Public { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }

public partial class PKIXPrivateKeyDH : IPKIXPrivateKey, IKeyPrivateDH {

    /// <summary>
    /// Construct a PKIX SubjectPublicKeyInfo block
    /// </summary>
    /// <param name="OIDValue">The OID value</param>
    /// <returns>The PKIX structure</returns>
    public SubjectPublicKeyInfo SubjectPublicKeyInfo(int[] OIDValue = null) {
        OIDValue ??= OID;
        return new SubjectPublicKeyInfo(OIDValue, DER());
        }

    ///<inheritdoc/>
    public override int[] OID => Constants.OID__id_dh_private;


    /// <summary>
    /// Return the corresponding public parameters
    /// </summary>
    public IPKIXPublicKey PublicParameters => PKIXPublicKeyDH;


    /// <summary>
    /// Return the corresponding public parameters
    /// </summary>
    public PKIXPublicKeyDH PKIXPublicKeyDH {
        get {
            _PKIXPublicKeyDH ??= new PKIXPublicKeyDH() {
                Shared = Shared,
                Public = Public
                };
            return _PKIXPublicKeyDH;
            }
        }

    byte[] IKeyPrivateDH.Shared { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    byte[] IKeyPrivateDH.Public { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    byte[] IKeyPrivateDH.Private { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    PKIXPublicKeyDH _PKIXPublicKeyDH = null;

    }




public partial class PkixPublicKeyRsa : IPKIXPublicKey {

    /// <summary>
    /// Construct a PKIX SubjectPublicKeyInfo block
    /// </summary>
    /// <param name="OIDValue">The OID value</param>
    /// <returns>The PKIX structure</returns>
    public SubjectPublicKeyInfo SubjectPublicKeyInfo(int[] OIDValue = null) {
        OIDValue ??= OID;
        return new SubjectPublicKeyInfo(OIDValue, DER());
        }

    /// <summary>
    /// Return the algorithm identifier that represents this key
    /// </summary>
    public override int[] OID => Constants.OID__rsaEncryption;


    /// <summary>
    /// Return the corresponding public parameters
    /// </summary>
    public IPKIXPublicKey PublicParameters => this;

    }

public partial class PkixPrivateKeyRsa : IPKIXPrivateKey {

    /// <summary>
    /// Construct a PKIX SubjectPublicKeyInfo block
    /// </summary>
    /// <param name="OIDValue">The OID value</param>
    /// <returns>The PKIX structure</returns>
    public SubjectPublicKeyInfo SubjectPublicKeyInfo(int[] OIDValue = null) {
        OIDValue ??= OID;
        return new SubjectPublicKeyInfo(OIDValue, DER());
        }

    /// <summary>
    /// Return the algorithm identifier that represents this key
    /// </summary>
    public override int[] OID => Constants.OID__rsaEncryption;


    /// <summary>
    /// Return the corresponding public parameters
    /// </summary>
    public IPKIXPublicKey PublicParameters => PKIXPublicKeyRSA;


    /// <summary>
    /// Return the corresponding public parameters
    /// </summary>
    public PkixPublicKeyRsa PKIXPublicKeyRSA {
        get {
            _PKIXPublicKeyRSA ??= new PkixPublicKeyRsa() {
                Modulus = Modulus,
                PublicExponent = PublicExponent
                };
            return _PKIXPublicKeyRSA;
            }
        }

    PkixPublicKeyRsa _PKIXPublicKeyRSA = null;

    }

/// <summary>
/// PKIX wrapper for opaque binary public key.
/// </summary>
public partial class PublicKeyInfo : IPKIXPublicKey {

    ///<inheritdoc/>
    public override int[] OID => Algorithm.Algorithm;

    ///<inheritdoc/>
    public IPKIXPublicKey PublicParameters => this;

    /// <summary>
    /// Default constructor for deserialization.
    /// </summary>
    public PublicKeyInfo() {
        }

    /// <summary>
    /// Construtor returning an instance for the public key <paramref name="key"/>.
    /// </summary>
    /// <param name="key">The public key</param>
    public PublicKeyInfo(IOpaqueBinaryKey key) {
        Algorithm = new AlgorithmIdentifier(key.OID);
        PublicKey = key.GetPublicBinary();
        }

    ///<inheritdoc/>
    public SubjectPublicKeyInfo SubjectPublicKeyInfo(int[] OIDValue = null) {
        OIDValue ??= OID;
        return new SubjectPublicKeyInfo(OIDValue, PublicKey);
        }
    }

/// <summary>
/// PKIX wrapper for opaque binary private key.
/// </summary>
public partial class PrivateKeyInfo : IPKIXPrivateKey {

    ///<inheritdoc/>
    public override int[] OID => PrivateKeyAlgorithm.Algorithm;

    ///<inheritdoc/>
    public IPKIXPublicKey PublicParameters => new PublicKeyInfo() {
        Algorithm = PrivateKeyAlgorithm,
        PublicKey = PublicKey,
        };

    /// <summary>
    /// Construtor returning an instance for the public key <paramref name="key"/>.
    /// </summary>
    /// <param name="key">The public key</param>
    public PrivateKeyInfo(IOpaqueBinaryKey key) {
        PrivateKeyAlgorithm = new AlgorithmIdentifier(key.OID);
        PublicKey = key.GetPublicBinary();
        PrivateKey = key.GetPrivateBinary();
        }

    ///<inheritdoc/>
    public SubjectPublicKeyInfo SubjectPublicKeyInfo(int[] OIDValue = null) {
        OIDValue ??= OID;
        return new SubjectPublicKeyInfo(OIDValue, DER());
        }
    }
