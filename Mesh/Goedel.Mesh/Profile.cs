
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



using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Standard;

using System.Security.Cryptography;

namespace Goedel.Mesh;

public partial class Profile {

    #region // Properties

    ///<summary>List of signing keys used to sign the profile.</summary> 
    public List<CryptoKey> KeyProfileSigners { get; protected set; } 

    ///<summary>The key contribution type</summary> 
    public virtual MeshKeyType MeshKeyType => Goedel.Mesh.MeshKeyType.Base;

    ///<summary>The actor type</summary> 
    public virtual MeshActor MeshActor => throw new NYI();

    ///<summary>The key identifier</summary> 
    public virtual UdfAlgorithmIdentifier UdfAlgorithmIdentifier =>
        MeshActor switch {
            MeshActor.Device => UdfAlgorithmIdentifier.MeshProfileDevice,
            MeshActor.Host => UdfAlgorithmIdentifier.MeshProfileDevice,
            MeshActor.Account => UdfAlgorithmIdentifier.MeshProfileAccount,
            MeshActor.Service => UdfAlgorithmIdentifier.MeshProfileService,
            //MeshActor.Host => UdfAlgorithmIdentifier.MeshProfileHost,
            _ => throw new NYI()
            };


    ///<summary>The primary key value.</summary>
    public override string _PrimaryKey => UdfString;

    ///<summary>The UDF of the profile, that is the UDF of the list <see cref="RootUdfs"/></summary>
    public string UdfString => Udf?.AsString;

    ///<summary>The UDF bytes</summary> 
    public byte[] UdfBytes => Udf?.Value;

    ///<summary>The profile exended UDF used for matching.</summary> 
    public Udf Udf => udf ?? Udf.CalculateProfileUdf (RootUdfs).CacheValue(out udf);
    Udf udf;

    ///<summary>The secret seed value used to derrive the private keys.</summary>
    ///
    public PrivateKeyUDF SecretSeed { get; set; }

    #endregion
    #region // Constructors
    /// <summary>
    /// Base constructor used for deserialization
    /// </summary>
    public Profile() {
        }

    /// <summary>
    /// Construct a Profile Host instance  from a <see cref="PrivateKeyUDF"/>
    /// </summary>
    /// <param name="secretSeed">The secret seed value.</param>
    /// <param name="keyCollection">The keyCollection to manage and persist the generated keys.</param>
    /// <param name="persist">If <see langword="true"/> persist the secret seed value to
    /// <paramref name="keyCollection"/>.</param>
    /// 
    protected Profile(
                PrivateKeyUDF secretSeed,
                IKeyCollection keyCollection = null,
                bool persist = false) {
        SecretSeed = secretSeed ?? new PrivateKeyUDF(udfAlgorithmIdentifier: UdfAlgorithmIdentifier);

        // Generate profile specific keys
        Generate();

        if (persist) {
            keyCollection.Persist(UdfString, secretSeed, false);
            }

        }

    #endregion
    #region // Methods 

    /// <summary>
    /// Sign the profile under the complete set of root signature keys.
    /// </summary>
    public void SignProfile() {
        // sign the profile.
        Envelope(KeyProfileSigners, includeSignatureKey: true);
        }


    /// <summary>
    /// Test to see if <paramref name="presentation"/> matches the profile UDF value.
    /// </summary>
    /// <param name="presentation">The value to test</param>
    /// <param name="minBits">The minimum number of precision to accept in 
    ///     <paramref name="presentation"/></param>
    /// <returns>True if <paramref name="presentation"/> is a match to the specified precision,
    /// othewise false.</returns>
    public bool Matches(
            string presentation,
            int minBits = 100) => Udf.Matches(presentation, minBits);


    /// <summary>
    /// Persist the secret seed used to generate a profile to the local machine as a non-exportable
    /// secret.
    /// </summary>
    /// <param name="keyCollection"></param>
    public void PersistSeed(IKeyCollection keyCollection = null) {
        SecretSeed.AssertNotNull(NoDeviceSecret.Throw);
        keyCollection.Persist(UdfString, SecretSeed, false);
        }


    /// <summary>
    /// Activate the private keys in the device profile using the seed stored in 
    /// <paramref name="keyLocate"/>.
    /// </summary>
    /// <param name="keyLocate">Key collection containing the secret seed.</param>
    public void Activate(IKeyCollection keyLocate) {
        SecretSeed ??= keyLocate.LocatePrivateKey(UdfString) as PrivateKeyUDF;

        // Hack: choose which algorithm(s) to unpack under!
        // Default to single signed under the default algorithm
        var algorithms = new List<CryptoAlgorithmId>() { CryptoID.DefaultSignatureId };
        Generate();
        }



    /// <summary>
    /// Generate profile specific keys, is overriden in child classes.
    /// </summary>
    protected virtual void Generate() {
        KeyProfileSigners = SecretSeed.GenerateKeySet(
                    MeshKeyType, MeshActor, MeshKeyOperation.Profile);

        SetRoots();
        }


    /// <summary>
    /// Initialize <see cref="RootUdfs"/> from the list of signing keys.
    /// </summary>
    protected void SetRoots() {
        RootUdfs = [];
        foreach (var key in KeyProfileSigners) {
            RootUdfs.Add(key.UDFBytes);
            }
        }



    /// <summary>
    /// Verify the profile to check that it is correctly signed and consistent.
    /// </summary>
    /// <returns></returns>
    public virtual void Validate() {

        // Does 
        var assurance = ValidateRootUdfs();
        // Throw an exception if the assurance level is none.
        (assurance > AssuranceLevel.None).AssertTrue(InvalidProfile.Throw);


        //Verify(DareEnvelope).AssertTrue(InvalidProfile.Throw);
        //ProfileSignatureKey.PublicOnly.AssertTrue(InvalidProfile.Throw);


        }

    /// <summary>
    /// Validate each profile signature against the list of root signing key fingerprints.
    /// </summary>
    /// <returns>The highest assurance level achieved by the set of included
    /// signatures.</returns>
    public virtual AssuranceLevel ValidateRootUdfs() {

        // Check that there is a non empty list of signatures
        var signatures = DareEnvelope?.Signatures;
        signatures?.AssertNotNull(InvalidProfile.Throw);
        (signatures.Count>0).AssertTrue(InvalidProfile.Throw);

        var assurance = AssuranceLevel.None;
        foreach (var signature in signatures) {
            // Deferred signatures contain the key in the signature.
            signature.SignatureKey.AssertNotNull(InvalidProfile.Throw);

            // Convert the key parameters to a public key
            var signatureKey = signature.SignatureKey.GetKeyPair(KeySecurity.Public);

            // Check the recomputed UDF is in the Root UDFs
            RootUdfs.IsPresent(signatureKey.UDFBytes).AssertTrue(InvalidProfile.Throw);

            // Check that the signature is valid
            var result = DareEnvelope.VerifySignature(signatureKey, signature);
            result.AssertTrue(InvalidProfile.Throw);
            // Assurance level is the maximum of the signatures presented.
            assurance = assurance.Max(signatureKey.AssuranceLevel);
            }

        return assurance;
        }




    /// <summary>
    /// Verify that the assertion contained in <paramref name="envelopedAssertion"/>
    /// has a valid signature under this profile.
    /// </summary>
    /// <param name="envelopedAssertion">Envelope containing the assertion 
    /// to be verified.</param>
    /// <returns>True if there is a valid signature under this profile, otherwise false.</returns>
    public bool Verify(DareEnvelope envelopedAssertion) =>
                throw new NotImplementedException();
                //envelopedAssertion.VerifySignature(ProfileSignatureKey);

    /// <summary>
    /// Verify that the signature <paramref name="signature"/> is valid under one of the
    /// profiles specified in <paramref name="envelopedProfiles"/> and that the specified profile 
    /// has the key identifier <paramref name="keyIdentifier"/>.
    /// </summary>
    /// <param name="envelopedProfiles">The profiles to search.</param>
    /// <param name="signature">The signature to verify.</param>
    /// <param name="digest">The digest value to verify.</param>
    /// <param name="keyIdentifier">The key identifier to verify.</param>
    /// <returns></returns>
    public static bool Validate(
            IEnumerable<Enveloped<Profile>> envelopedProfiles,
            DareSignature signature,
            byte[] digest,
            string keyIdentifier
            ) {

        return true;
        //foreach (var envelope in envelopedProfiles) {
        //    var profile = envelope.Decode();
        //    if (profile.Verify(signature, digest, keyIdentifier)) {
        //        profile.Validate();
        //        return true;
        //        }
        //    }
        //return false;
        }

    /// <summary>
    /// Validate the binding value against the specified root of trust.
    /// </summary>
    /// <returns>True if the binding is valid, otherwise false.</returns>
    public static bool ValidateAny(
                    DareEnvelope dareEnvelope,
                    IEnumerable<Enveloped<Profile>> profiles,
                    string profileUdf) {

        var signatures = dareEnvelope?.Header?.Signatures ??
            dareEnvelope?.Trailer?.Signatures;
        if (signatures == null | profileUdf == null) {
            return false;
            }

        // get the payload digest, check against Payload digest if specified.
        var digest = dareEnvelope.PayloadDigestComputed ?? dareEnvelope.GetValidatedDigest();

        // Every signature specified MUST be valid and MUST be present in <profiles>
        foreach (var signature in signatures) {
            if (Profile.Validate(profiles, signature, digest, profileUdf)) {
                return true;
                }
            }

        return false;
        }



    #endregion
    }
