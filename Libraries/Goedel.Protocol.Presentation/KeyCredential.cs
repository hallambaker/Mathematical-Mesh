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
//  

using Goedel.Cryptography;
using Goedel.Cryptography.Jose;


namespace Goedel.Protocol.Presentation;

/// <summary>
/// Connection credentialed by means of raw key alone.
/// </summary>
public class KeyCredentialPublic : ICredentialPublic {
    #region // Properties

    ///<inheritdoc/>
    public KeyPairAdvanced AuthenticationPublic { get; init; }

    ///<summary>The account being claimed (unverified).</summary> 
    public string Account { get; init; }

    ///<summary>The credential provider (always null)</summary> 
    public string Provider => null;

    ///<summary>The authentication key identifier.</summary> 
    public string AuthenticationKeyId => AuthenticationPublic.KeyIdentifier;

    ///<summary>The credential validation report (always fails as no provider)</summary> 
    public CredentialValidation CredentialValidation { get; set; } = CredentialValidation.None;
    #endregion
    #region // Constructors

    /// <summary>
    /// Create a new instance with the public key <paramref name="authenticationPublic"/>
    /// </summary>
    /// <param name="authenticationPublic">The public key.</param>
    public KeyCredentialPublic(KeyPairAdvanced authenticationPublic) =>
        AuthenticationPublic = authenticationPublic;

    #endregion
    #region // Implement Interface: ICredentialPrivate

    ///<inheritdoc/>
    public virtual (KeyPairAdvanced, KeyPairAdvanced) SelectKey() =>
        (KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Ephemeral) as KeyPairAdvanced,
                    AuthenticationPublic);

    ///<inheritdoc/>
    public virtual (KeyPairAdvanced, KeyPairAdvanced) SelectKey(
            List<KeyPairAdvanced> ephemerals,
            string keyId) =>
        (ephemerals[0], AuthenticationPublic);
    #endregion
    }

/// <summary>
/// Private key credential specifying only a raw key.
/// </summary>
public class KeyCredentialPrivate : KeyCredentialPublic, ICredentialPrivate {
    #region // Properties

    string Tag { get; }

    ///<summary>The packet extensions describing the private key.</summary> 
    public List<PacketExtension> Extensions { get; } = new();

    ///<summary>The private key used to authenticate packets.</summary> 
    public KeyPairAdvanced AuthenticationPrivate { get; init; }
    #endregion

    #region // Destructor
    #endregion

    #region // Constructors

    /// <summary>
    /// Create a new instance with the private key <paramref name="authenticationPrivate"/>
    /// </summary>
    /// <param name="authenticationPrivate">The private key.</param>
    /// <param name="account">The account claimed.</param>
    public KeyCredentialPrivate(KeyPairAdvanced authenticationPrivate,
            string account) :
                base(authenticationPrivate) {
        AuthenticationPrivate = authenticationPrivate;
        Account = account;

        if (authenticationPrivate != null) {
            Tag = authenticationPrivate switch {

                KeyPairX448 => PresentationConstants.ExtensionTagsDirectX448Tag,
                //KeyPairX25519 => Constants.ExtensionTagsX25519Tag,
                _ => throw new NYI()
                };
            Extensions.Add(new PacketExtension() {
                Tag = Tag,
                Value = AuthenticationPrivate.IKeyAdvancedPublic.EncodingPublicKey
                });
            }

        if (account is not null) {
            Extensions.Add(new PacketExtension() {
                Tag = PresentationConstants.ExtensionTagsClaimIdTag,
                Value = account.ToUTF8()
                });
            }

        }

    #endregion
    #region // Implement Interface: ICredentialPrivate

    ///<inheritdoc/>
    public virtual ICredentialPublic GetICredentialPublic() => GetKeyCredentialPublic();

    ///<inheritdoc/>
    public KeyCredentialPublic GetKeyCredentialPublic() =>
                new(
                AuthenticationPrivate.KeyPairPublic() as KeyPairAdvanced);


    ///<inheritdoc/>
    public virtual void AddCredentials(
            List<PacketExtension> extensions
            ) {
        foreach (var extension in Extensions) {
            extensions.Add(extension);
            }
        }
    ///<inheritdoc/>
    public virtual void AddEphemerals(
            List<PacketExtension> extensions,
            ref List<KeyPairAdvanced> ephmeralsOffered) {
        KeyPairAdvanced ephemeral;

        if (ephmeralsOffered != null) {
            ephemeral = ephmeralsOffered[0];
            //Screen.WriteLine($"Re-Offer of = {ephemeral}");

            }
        else {
            ephemeral = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Ephemeral) as KeyPairAdvanced;
            ephmeralsOffered = new List<KeyPairAdvanced> { ephemeral };
            //Screen.WriteLine($"Make Offer of = {ephemeral}");
            }

        var extension = new PacketExtension() {
            Tag = ephemeral.CryptoAlgorithmId.ToJoseID(),
            Value = ephemeral.IKeyAdvancedPublic.EncodingPublicKey
            };


        extensions.Add(extension);

        }

    ///<inheritdoc/>
    public virtual ICredentialPublic GetCredentials(List<PacketExtension> extensions) =>
        throw new NotImplementedException();

    ///<inheritdoc/>
    public virtual (KeyPairAdvanced, KeyPairAdvanced) SelectKey(List<PacketExtension> extensions) {
        foreach (var extension in extensions) {
            if (extension.Tag == PresentationConstants.ExtensionTagsX448Tag) {
                var ephemeral = new KeyPairX448(extension.Value, KeySecurity.Public);
                //Screen.WriteLine($"SelectEnvelope = {ephemeral}");
                return (AuthenticationPrivate, ephemeral);
                }
            }
        throw new NYI();
        }

    ///<inheritdoc/>
    public virtual (KeyPairAdvanced, KeyPairAdvanced) SelectKey(string keyId, byte[] ephemeral) =>
        (AuthenticationPrivate, new KeyPairX448(ephemeral, KeySecurity.Public));

    #endregion
    }
