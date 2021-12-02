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
using System.Diagnostics.Contracts;

using Goedel.ASN;

namespace Goedel.Cryptography.Algorithms;


/// <summary>
/// Implement Diffie Hellman Key operations. Note that this is a standalone
/// class and does not inherit from the KeyPair class to provide hooks for
/// implementing a provider, etc. This is in DHKeyPair.
/// </summary>
public class DiffeHellmanPublic : IKeyAdvancedPublic {


    /// <summary>
    /// The shared domain parameters
    /// </summary>

    public DHDomain DHDomain { get; }

    /// <summary>Group modulus</summary>
    public BigInteger Modulus { get; }

    /// <summary>Generator</summary>
    public BigInteger Generator { get; }

    /// <summary>Public Key</summary>
    public BigInteger Public { get; protected set; }

    #region // Constructors

    /// <summary>
    /// Create a new set of Diffie Hellman group parameters.
    /// </summary>
    /// <param name="Bits">The number of bits, this identifies the group modulus </param>
    public DiffeHellmanPublic(int Bits = 2048) {
        switch (Bits) {
            case 0:
            case 2048: {
                    DHDomain = DHDomain.DHDomain2048;
                    break;
                    }
            case 4096: {
                    DHDomain = DHDomain.DHDomain4096;
                    break;
                    }
            default: {
                    throw new KeySizeNotSupported();
                    }
            }
        Modulus = DHDomain.BigIntegerP;
        Generator = DHDomain.BigIntegerG;
        }

    /// <summary>
    /// Create a new set of Diffie Hellman parameters using the shared modulus, 
    /// a newly constructed generator and public and private keys.
    /// </summary>
    /// <param name="dhDomain">The shared parameters</param>
    /// <param name="Public">Optional public value</param>
    public DiffeHellmanPublic(DHDomain dhDomain, BigInteger? Public = null) {
        Contract.Requires(dhDomain != null);
        dhDomain.AssertNotNull(NullParameter.Throw);

        this.DHDomain = dhDomain;
        Modulus = dhDomain.BigIntegerP;
        Generator = dhDomain.BigIntegerG;
        if (Public != null) {
            this.Public = (BigInteger)Public;
            }
        }

    /// <summary>
    /// Clone the public components of the key pair <paramref name="baseKey"/>.
    /// </summary>
    /// <param name="baseKey">The key pair to copy.</param>
    public DiffeHellmanPublic(DiffeHellmanPublic baseKey) {
        Contract.Requires(baseKey != null);
        baseKey.AssertNotNull(NullParameter.Throw);

        DHDomain = baseKey.DHDomain;
        Modulus = baseKey.Modulus;
        Generator = baseKey.Generator;
        Public = baseKey.Public;
        }


    /// <summary>
    /// Construct from public key parameters
    /// </summary>
    /// <param name="pkixParameters">The key parameters</param>
    public DiffeHellmanPublic(PKIXPublicKeyDH pkixParameters) {
        Contract.Requires(pkixParameters != null);
        pkixParameters.AssertNotNull(NullParameter.Throw);

        DHDomain = pkixParameters.Domain;
        Assert.AssertNotNull(DHDomain, UnknownNamedParameters.Throw);

        Modulus = DHDomain.BigIntegerP;
        Generator = DHDomain.BigIntegerG;
        Public = pkixParameters.Public.ToBigInteger();

        }

    #endregion


    /// <summary>
    /// Check that the Diffie Hellman parameters presented match those of this Key.
    /// </summary>
    /// <param name="key">The key to verify</param>
    public void Verify(DiffeHellmanPublic key) {
        Contract.Requires(key != null);
        key.AssertNotNull(NullParameter.Throw);


        Assert.AssertTrue(key.Modulus == Modulus, CryptographicException.Throw);
        Assert.AssertTrue(key.Generator == Generator, CryptographicException.Throw);
        }


    #region // Key Agreement methods

    /// <summary>
    /// Create a new ephemeral private key and use it to perform a key
    /// agreement.
    /// </summary>
    /// <returns>The key agreement parameters, the public key value and the
    /// key agreement.</returns>
    public ResultDiffieHellman Agreement() {
        var Private = new DiffeHellmanPrivate(this);

        var Result = new ResultDiffieHellman() {
            EphemeralPublicValue = Private.DiffeHellmanPublic,
            Agreement = Private.Agreement(this)
            };

        return Result;
        }




    /// <summary>
    /// Perform final stage in a Diffie Hellman Agreement to reduce an 
    /// array of carry returns to a single agreement result.
    /// </summary>
    /// <param name="carry">The partial recryption results.</param>
    /// <returns>The key agreement value ZZ</returns>
    public BigInteger Agreement(BigInteger[] carry) {
        Contract.Requires(carry != null);
        carry.AssertNotNull(NullParameter.Throw);

        Assert.AssertTrue(carry.Length >= 1, InsufficientResults.Throw);

        var Accumulator = carry[0];
        for (var i = 1; i < carry.Length; i++) {
            Accumulator *= carry[i];
            }
        return Accumulator % Modulus;
        }

    #endregion

    #region // Advanced 

    /// <summary>
    /// Combine the two public keys to create a composite public key.
    /// </summary>
    /// <param name="contribution">The key contribution.</param>
    /// <returns>The composite key</returns>
    public DiffeHellmanPublic Combine(DiffeHellmanPublic contribution) {
        Contract.Requires(contribution != null);
        contribution.AssertNotNull(NullParameter.Throw);

        var NewPublic = (Public * contribution.Public) % Modulus;
        return new DiffeHellmanPublic(DHDomain, NewPublic);
        }


    /// <summary>
    /// Combine the two public keys to create a composite public key.
    /// </summary>
    /// <param name="contribution">The key contribution.</param>
    /// <returns>The composite key</returns>
    public IKeyAdvancedPublic Combine(IKeyAdvancedPublic contribution) =>
        Combine(contribution as DiffeHellmanPublic);

    ///<summary>The encoding of the public value.</summary>
    public byte[] Encoding => Public.ToByteArray();

    #endregion
    }

/// <summary>
/// Represents a set of Diffie Hellman parameters.
/// </summary>
public class DiffeHellmanPrivate : DiffeHellmanPublic, IKeyAdvancedPrivate {

    /// <summary>Private Key</summary>
    public BigInteger Private { get; set; }

    /// <summary>If true, this key is part of a recryption set.</summary>
    public bool IsRecryption { get; set; }



    /// <summary>
    /// Return the public key.
    /// </summary>
    public DiffeHellmanPublic DiffeHellmanPublic {
        get {
            if (diffeHellmanPublic == null) {
                diffeHellmanPublic = new DiffeHellmanPublic(DHDomain, Public);
                }
            return diffeHellmanPublic;
            }
        }
    DiffeHellmanPublic diffeHellmanPublic = null;

    #region // Constructors

    /// <summary>
    /// Create a new set of Diffie Hellman parameters using the shared modulus, 
    /// a newly constructed generator and public and private keys.
    /// </summary>
    /// <param name="bits">The number of bits in the modulus to be created. Valid values
    /// are 2048 and 4096</param>
    public DiffeHellmanPrivate(int bits = 2048) : base(bits) {
        Private = Platform.GetRandomBigInteger(Modulus);
        Public = BigInteger.ModPow(Generator, Private, Modulus);
        IsRecryption = false;
        }

    /// <summary>
    /// Create a new set of Diffie Hellman parameters using the shared modulus, 
    /// a newly constructed generator and public and private keys.
    /// </summary>
    /// <param name="diffeHellmanPublic">Public key to use to specify the
    /// modulus and generator</param>
    public DiffeHellmanPrivate(DiffeHellmanPublic diffeHellmanPublic) :
                 base(diffeHellmanPublic?.DHDomain) {

        Private = Platform.GetRandomBigInteger(Modulus);
        Public = BigInteger.ModPow(Generator, Private, Modulus);
        IsRecryption = false;
        }

    /// <summary>
    /// Create a new set of Diffie Hellman parameters using the shared modulus, 
    /// a newly constructed generator and public and private keys.
    /// </summary>
    /// <param name="pkixPrivateKeyDH">Key parameters</param>
    public DiffeHellmanPrivate(PKIXPrivateKeyDH pkixPrivateKeyDH) : base(pkixPrivateKeyDH?.Domain) {
        Private = pkixPrivateKeyDH.Private.ToBigInteger();
        Public = pkixPrivateKeyDH.Public.ToBigInteger();
        IsRecryption = false;
        }

    private DiffeHellmanPrivate(BigInteger @private) {
        this.Private = @private;
        Public = BigInteger.ModPow(Generator, @private, Modulus);
        }

    #endregion

    /// <summary>
    /// Create a new key pair instance for this private key.
    /// </summary>
    /// <param name="keyType">The key type.</param>
    /// <param name="keyUses">The permitted key uses.</param>
    /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
    /// in signature operations.</param>
    /// <returns>The KeyPair instance.</returns>
    public KeyPairAdvanced GetKeyPair(
                KeySecurity keyType = KeySecurity.Public,
                KeyUses keyUses = KeyUses.Any,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default) => new
                    KeyPairDH(this, keyType);

    #region // Key Agreement methods

    /// <summary>
    /// Perform a partial key agreement.
    /// </summary>
    /// <param name="keyPair">The key pair to perform the agreement against.</param>
    /// <returns>The key agreement result.</returns>
    public KeyAgreementResult Agreement(KeyPair keyPair) {
        var agreement = Agreement((keyPair as KeyPairAdvanced)?.IKeyAdvancedPublic);
        return new ResultDiffieHellman() { Agreement = agreement };
        }


    /// <summary>
    /// Perform a Diffie Hellman Key Agreement to this private key
    /// </summary>
    /// <param name="publicKey">Set of newly created DH parameters for Alice</param>
    /// <returns>The key agreement value ZZ</returns>
    public BigInteger Agreement(IKeyAdvancedPublic publicKey) {
        var publicDH = publicKey as DiffeHellmanPublic;
        Contract.Requires(publicDH != null);
        Verify(publicDH);
        return BigInteger.ModPow(publicDH.Public, Private, Modulus);
        }

    /// <summary>
    /// Perform a Diffie Hellman Key Agreement to this private key
    /// </summary>
    /// <param name="publicKey">Set of newly created DH parameters for Alice</param>
    /// <param name="carry">Recryption carry over value, to be combined with the
    /// result of this key agreement.</param>
    /// <returns>The key agreement value ZZ</returns>
    public BigInteger Agreement(IKeyAdvancedPublic publicKey, BigInteger carry) {
        var publicDH = publicKey as DiffeHellmanPublic;
        Verify(publicDH);
        var partial = Agreement(publicDH);
        return (partial * carry) % Modulus;
        }
    #endregion
    #region // Advanced functions


    /// <summary>
    /// Make a Shamir threshold keyset with <paramref name="shares"/> shares
    /// with a threshold of <paramref name="threshold"/>.
    /// </summary>
    /// <param name="shares">Number of shares to create</param>
    /// <param name="threshold">The number of shares required to recover the key.</param>
    /// <returns>The shares created.</returns>
    public ShamirSharePrivate[] MakeThresholdKeySet(int shares, int threshold) => throw new NYI();

    /// <summary>
    /// Make a recryption keyset by splitting the private key.
    /// </summary>
    /// <param name="shares">Number of shares to create</param>
    /// <returns>Array shares.</returns>
    public IKeyAdvancedPrivate[] MakeThresholdKeySet(int shares) {
        BigInteger accumulator = 0;
        var result = new IKeyAdvancedPrivate[shares];

        for (var i = 1; i < shares; i++) {
            var newPrivate = Platform.GetRandomBigInteger(Modulus - 1);
            result[i] = new DiffeHellmanPrivate(newPrivate) { IsRecryption = true };
            accumulator = (accumulator + newPrivate) % (Modulus - 1);
            }

        result[0] = new DiffeHellmanPrivate((Modulus + Private - accumulator - 1) % (Modulus - 1)) {
            IsRecryption = true
            };
        return result;
        }

    /// <summary>
    /// Make a recryption keyset by splitting the private key.
    /// </summary>
    /// <param name="shares">Number of shares to create</param>
    /// <returns>Array shares.</returns>
    public IKeyAdvancedPrivate CompleteRecryptionKeySet(IEnumerable<KeyPair> shares) {
        Contract.Requires(shares != null);
        shares.AssertNotNull(NullParameter.Throw);


        BigInteger accumulator = 0;

        foreach (var share in shares) {
            var key = share as KeyPairDH;
            var privateKey = (key.IKeyAdvancedPrivate as CurveEdwards448Private);

            accumulator = (accumulator + privateKey.Private).Mod(Modulus - 1);
            }

        return new DiffeHellmanPrivate(
            (Modulus - 1 + Private - accumulator).Mod(Modulus - 1)) {
            IsRecryption = true
            };
        }



    /// <summary>
    /// Combine the two public keys to create a composite public key.
    /// </summary>
    /// <param name="contribution">The key contribution.</param>
    /// <param name="keySecurity">The key security model.</param>
    /// <param name="keyUses">The allowed key uses.</param>
    /// <returns>The composite key</returns>
    public DiffeHellmanPrivate Combine(DiffeHellmanPrivate contribution,
                KeySecurity keySecurity = KeySecurity.Bound,
                KeyUses keyUses = KeyUses.Any) {
        Contract.Requires(contribution != null);
        contribution.AssertNotNull(NullParameter.Throw);


        var newPrivate = (Private + contribution.Private) % Modulus;
        return new DiffeHellmanPrivate(newPrivate);
        }


    /// <summary>
    /// Combine the two public keys to create a composite public key.
    /// </summary>
    /// <param name="contribution">The key contribution.</param>
    /// <param name="keySecurity">The key security model.</param>
    /// <param name="keyUses">The allowed key uses.</param>
    /// <returns>The composite key</returns>
    public IKeyAdvancedPrivate Combine(IKeyAdvancedPrivate contribution,
                KeySecurity keySecurity = KeySecurity.Bound,
                KeyUses keyUses = KeyUses.Any) =>
        Combine(contribution as CurveEdwards448Private, keySecurity, keyUses);
    #endregion


    }





/// <summary>
/// Represent the result of a Diffie Hellman Key exchange.
/// </summary>
public class ResultDiffieHellman : KeyAgreementResult {

    /// <summary>The key agreement result</summary>
    public BigInteger Agreement { get; set; }

    /// <summary>Wrap as an ASN.1 Structure</summary>
    public AgreementDH ASNAgreement => new() {
        Result = Agreement.ToByteArray()
        };

    /// <summary>The agreement as ASN.1 DER encoding</summary>
    /// <returns>The DER encoded value.</returns>
    public override byte[] DER() => ASNAgreement.DER();

    /// <summary>The key agreement result as a byte array</summary>
    public override byte[] IKM => Agreement.ToByteArray();

    /// <summary>
    /// The Ephemeral public key
    /// </summary>
    public override KeyPair EphemeralKeyPair => new KeyPairDH(EphemeralPublicValue as DiffeHellmanPublic);

    }
