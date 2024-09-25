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
/// PKIXPublicKeyECDH 
/// </summary>
public partial class PKIXEcdhKeyBase : Goedel.ASN.ByteArrayVerbatim  {

    /// <summary>The Jose curve identifier.</summary>
    public string CurveJose { get; }
    
    ///<summary>Optional additional oid specifying the curve.</summary> 
    public int[] Parameters { get; } = null;

    ///<inheritdoc/>
    public override int[] OID { get; }

    /// <summary>
    /// Construct a PKIX SubjectPublicKeyInfo block
    /// </summary>
    /// <param name="oidValue">The OID value</param>
    /// <returns>The PKIX structure</returns>
    public SubjectPublicKeyInfo SubjectPublicKeyInfo(int[] oidValue = null) {
        oidValue ??= OID;
        return new SubjectPublicKeyInfo(oidValue, DER(), Parameters);
        }

    /// <summary>
    /// Create PKIX representation from the encoded values.
    /// </summary>
    /// <param name="data">The encoded key.</param>
    /// <param name="cryptoAlgorithmID">The cryptographic algorithm.</param>
    public PKIXEcdhKeyBase(
                CryptoAlgorithmId cryptoAlgorithmID,
                byte[] data) {
        Data = data.Duplicate();
        (CurveJose, OID, Parameters) = GetParameters (cryptoAlgorithmID);
        }

    /// <summary>
    /// Encode ASN.1 class members to specified buffer. 
    ///
    /// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
    /// </summary>
    /// <param name="buffer">Output buffer</param>
    public override void Encode(Goedel.ASN.Buffer buffer) => buffer.Encode__Octets(Data, 0, -1);

    /// <summary>
    /// Return JOSE and ASN.1 identifiers describing an ECC algorithm <paramref name="cryptoAlgorithmID"/>.
    /// </summary>
    /// <param name="cryptoAlgorithmID">The ECC algorithm.</param>
    /// <returns>The Jose identifier string, Algorithm OID and Curve parameter.</returns>
    /// <exception cref="CryptographicException"></exception>
    public static (string, int[], int[]) GetParameters(CryptoAlgorithmId cryptoAlgorithmID) => cryptoAlgorithmID switch {
            CryptoAlgorithmId.P256 => 
                    (JoseConstants.P256, Constants.OID__id_ec_publicKey,Constants.OID__secp256r1),
            CryptoAlgorithmId.P384 => 
                    (JoseConstants.P384, Constants.OID__id_ec_publicKey,Constants.OID__secp384r1),
            CryptoAlgorithmId.P521 => 
                    (JoseConstants.P521, Constants.OID__id_ec_publicKey,Constants.OID__secp521r1),
            CryptoAlgorithmId.Ed25519 =>
                (JoseConstants.Ed25519, Constants.OID__id_Ed25519, null),
            CryptoAlgorithmId.Ed448 =>
                (JoseConstants.Ed448, Constants.OID__id_Ed25519, null),
            CryptoAlgorithmId.X25519 =>
                (JoseConstants.X25519, Constants.OID__id_Ed25519, null),
            CryptoAlgorithmId.X448 =>
                (JoseConstants.X448, Constants.OID__id_Ed25519, null),
            _ => throw new CryptographicException()
            };
    }


/// <summary>
/// PKIXPublicKeyECDH 
/// </summary>
public partial class PKIXPublicKeyECDH : PKIXEcdhKeyBase,
                IPKIXPublicKey, IKeyPublicECDH {
    /// <summary>
    /// Create PKIX representation from the encoded values.
    /// </summary>
    /// <param name="data">The encoded key.</param>
    /// <param name="cryptoAlgorithmID">The cryptographic algorithm.</param>
    public PKIXPublicKeyECDH(
                CryptoAlgorithmId cryptoAlgorithmID,
                byte[] data) : base (cryptoAlgorithmID, data) { }
    }

/// <summary>
/// PKIXPublicKeyECDH 
/// </summary>
public partial class PKIXPrivateKeyECDH : PKIXEcdhKeyBase,
                IPKIXPrivateKey, IKeyPrivateECDH {
    /// <summary>If true, this is a threshold key.</summary>
    public bool IsThreshold { get; set; } = false;

    /// <summary>
    /// Create PKIX representation from the encoded values.
    /// </summary>
    /// <param name="data">The encoded key.</param>
    /// <param name="cryptoAlgorithmID">The cryptographic algorithm.</param>
    public PKIXPrivateKeyECDH(
                CryptoAlgorithmId cryptoAlgorithmID,
                byte[] data) : base(cryptoAlgorithmID, data) { }

    }
