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


namespace Goedel.Mesh;

public partial class ProfileAccount {

    ///<summary>The actor type</summary> 
    public override MeshActor MeshActor => MeshActor.Account;

    ///<summary>Typed enveloped data</summary> 
    public Enveloped<ProfileAccount> GetEnvelopedProfileAccount() => new(DareEnvelope);


    ///<summary>The account encryption key</summary> 
    public KeyPair AccountAuthenticationKey => accountAuthenticationKey ??
        CommonAuthentication.GetKeyPair().CacheValue(out accountAuthenticationKey);
    KeyPair accountAuthenticationKey;


    ///<summary>The account encryption key</summary> 
    public KeyPair AccountEncryptionKey => accountEncryptionKey ??
        CommonEncryption.GetKeyPair().CacheValue(out accountEncryptionKey);
    KeyPair accountEncryptionKey;

    ///<summary>The account administrator signature key</summary> 
    public KeyPair AdministratorSignatureKey => administratorSignatureKey ??
        AdministratorSignature.GetKeyPair().CacheValue(out administratorSignatureKey);
    KeyPair administratorSignatureKey;

    /// <summary>
    /// Blank constructor for use by deserializers.
    /// </summary>
    public ProfileAccount() {
        }

    /// <summary>
    /// Construct a Profile Host instance  from a <see cref="PrivateKeyUDF"/>
    /// </summary>
    /// <param name="secretSeed">The secret seed value.</param>
    public ProfileAccount(
                PrivateKeyUDF secretSeed,
                IEnumerable<CryptoAlgorithmId> algorithms = null) : base(secretSeed) {
        }

    /// <summary>
    /// Construct a Profile Account instance  from <paramref name="accountAddress"/>.
    /// </summary>
    /// <param name="accountAddress">The account address</param>
    /// <param name="activationAccount">The activation used to create the account data.</param>
    protected ProfileAccount(
                string accountAddress,
                ActivationCommon activationAccount) {
        AccountAddress = accountAddress;

        // Set the root UDFs
        KeyProfileSigners = activationAccount.KeyProfileSigners;
        SetRoots();

        //Set the public key parameters
        EscrowEncryption = new KeyData(activationAccount.EscrowEncryptionKey);
        //ProfileSignature = new KeyData(activationAccount.ProfileSignatureKey);
        AdministratorSignature = new KeyData(activationAccount.AdministratorSignatureKey);
        CommonEncryption = new KeyData(activationAccount.CommonEncryptionKey);
        CommonAuthentication = new KeyData(activationAccount.CommonAuthenticationKey);
        }



    ///<inheritdoc/>
    public override void Validate() {
        base.Validate();

        AccountEncryptionKey.PublicOnly.AssertTrue(InvalidProfile.Throw);
        AdministratorSignatureKey.PublicOnly.AssertTrue(InvalidProfile.Throw);

        }

    /////<inheritdoc/>
    //public override bool Verify(
    //        DareSignature signature,
    //        byte[] digest,
    //        string keyIdentifier) {
    //    if (!Udf.Matches(keyIdentifier)) {
    //        return false;
    //        }
    //    if (AdministratorSignatureKey.MatchKeyIdentifier(signature.KeyIdentifier)) {
    //        return AdministratorSignatureKey.VerifyManifest(digest, signature.SignatureValue);
    //        }
    //    if (ProfileSignatureKey.MatchKeyIdentifier(ProfileSignatureKey.KeyIdentifier)) {
    //        return ProfileSignatureKey.VerifyManifest(digest, signature.SignatureValue);
    //        }
    //    return false;
    //    }


    }
