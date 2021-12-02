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

namespace Goedel.Cryptography.Jose;

/// <summary>
/// Represents an RSA Public Key.
/// </summary>
public partial class PublicKeyRSA : Key {
    /// <summary>
    /// Default Constructor
    /// </summary>
    public PublicKeyRSA() { }

    /// <summary>
    /// Construct from the specified RSA Key
    /// </summary>
    /// <param name="KeyPair">An RSA key Pair.</param>
    public PublicKeyRSA(KeyPairBaseRSA KeyPair) {
        Kid = KeyPair.KeyIdentifier;
        var RSAPublicKey = KeyPair.PkixPublicKeyRsa;

        N = RSAPublicKey.Modulus;
        E = RSAPublicKey.PublicExponent;
        }

    /// <summary>
    /// Construct from a PKIX RSAPublicKey structure.
    /// </summary>
    /// <param name="RSAPublicKey">RSA Public Key.</param>
    public PublicKeyRSA(PkixPublicKeyRsa RSAPublicKey) {
        this.N = RSAPublicKey.Modulus;
        this.E = RSAPublicKey.PublicExponent;
        }


    /// <summary>
    /// Return the parameters as a PKIX RSAPublicKey structure;
    /// </summary>
    public virtual PkixPublicKeyRsa PKIXPublicKeyRSA => new() {
        Modulus = N,
        PublicExponent = E
        };

    /// <summary>
    /// Extract a KeyPair object from the JOSE data structure.
    /// </summary>
    /// <param name="keySecurity">The key security model</param>
    /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
    /// the value of <paramref name="keySecurity"/></param>
    /// <returns>The extracted key pair</returns>
    public override KeyPair GetKeyPair(KeySecurity keySecurity, IKeyLocate keyCollection) {

        var PKIXParams = PKIXPublicKeyRSA;
        var KeyPair = KeyPairBaseRSA.KeyPairPublicFactory(PKIXParams);

        return KeyPair;
        }

    }

/// <summary>
/// Represents an RSA Private Key.
/// </summary>
public partial class PrivateKeyRSA {
    /// <summary>
    /// Default Constructor
    /// </summary>
    public PrivateKeyRSA() { }

    /// <summary>
    /// Construct from the specified RSA Key
    /// </summary>
    /// <param name="KeyPair">An RSA key Pair.</param>
    public PrivateKeyRSA(KeyPairBaseRSA KeyPair) {
        Kid = KeyPair.KeyIdentifier;
        var RSAPrivateKey = KeyPair.PkixPrivateKeyRSA;
        Assert.AssertNotNull(RSAPrivateKey, NotExportable.Throw);


        N = RSAPrivateKey.Modulus;
        E = RSAPrivateKey.PublicExponent;
        D = RSAPrivateKey.PrivateExponent;
        P = RSAPrivateKey.Prime1;
        Q = RSAPrivateKey.Prime2;
        DP = RSAPrivateKey.Exponent1;
        DQ = RSAPrivateKey.Exponent2;
        QI = RSAPrivateKey.Coefficient;
        }


    /// <summary>
    /// Construct from a PKIX RSAPublicKey structure.
    /// </summary>
    /// <param name="RSAPrivateKey">RSA Public Key.</param>
    public PrivateKeyRSA(PkixPrivateKeyRsa RSAPrivateKey) {
        N = RSAPrivateKey.Modulus;
        E = RSAPrivateKey.PublicExponent;
        D = RSAPrivateKey.PrivateExponent;
        P = RSAPrivateKey.Prime1;
        Q = RSAPrivateKey.Prime2;
        DP = RSAPrivateKey.Exponent1;
        DQ = RSAPrivateKey.Exponent2;
        QI = RSAPrivateKey.Coefficient;
        }

    /// <summary>
    /// Return the parameters as PKIX RSAPrivateKey structure;
    /// </summary>
    public virtual PkixPrivateKeyRsa PKIXPrivateKeyRSA => new() {
        Modulus = N,
        PublicExponent = E,
        PrivateExponent = D,
        Prime1 = P,
        Prime2 = Q,
        Exponent1 = DP,
        Exponent2 = DQ,
        Coefficient = QI
        };



    /// <summary>
    /// Extract a KeyPair object from the JOSE data structure.
    /// </summary>
    /// <param name="keySecurity">The key security model</param>
    /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
    /// the value of <paramref name="keySecurity"/></param>
    /// <returns>The extracted key pair</returns>
    public override KeyPair GetKeyPair(KeySecurity keySecurity, IKeyLocate keyCollection) {

        var PKIXParams = PKIXPublicKeyRSA;
        var KeyPair = KeyPairBaseRSA.KeyPairPrivateFactory(PKIXPrivateKeyRSA, keySecurity, keyCollection);

        return KeyPair;
        }

    }
