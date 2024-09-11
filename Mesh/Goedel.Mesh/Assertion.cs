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

public partial class Assertion {
    /// <summary>
    /// Default Constructor
    /// </summary>
    public Assertion() {
        }


    /// <summary>
    /// Verify the profile to check that it is correctly signed and consistent.
    /// </summary>
    /// <returns></returns>
    public virtual void Validate(ProfileAccount profile) =>
        DareEnvelope.VerifySignature(profile.AdministratorSignatureKey).
                AssertTrue(InvalidAssertion.Throw);


    /// <summary>
    /// Validate the binding value against the specified root of trust.
    /// </summary>
    /// <returns>True if the binding is valid, otherwise false.</returns>
    public virtual bool ValidateAll(IEnumerable<Enveloped<Profile>> profiles, string profileUdf) {

        var signatures = DareEnvelope?.Header?.Signatures ??
            DareEnvelope?.Trailer?.Signatures;
        if (signatures == null) {
            return false;
            }

        // get the payload digest, check against Payload digest if specified.
        var digest = DareEnvelope.GetValidatedDigest();

        // Every signature specified MUST be valid and MUST be present in <profiles>
        foreach (var signature in signatures) {
            if (!Profile.Validate(profiles, signature, digest, profileUdf)) {
                return false;
                }
            }

        return true;
        }

    /// <summary>
    /// Validate the binding value against the specified root of trust.
    /// </summary>
    /// <returns>True if the binding is valid, otherwise false.</returns>
    public virtual bool ValidateAny(IEnumerable<Enveloped<Profile>> profiles, string profileUdf) {

        var signatures = DareEnvelope?.Header?.Signatures ??
            DareEnvelope?.Trailer?.Signatures;
        if (signatures == null) {
            return false;
            }

        // get the payload digest, check against Payload digest if specified.
        var digest = DareEnvelope.GetValidatedDigest();

        // Every signature specified MUST be valid and MUST be present in <profiles>
        foreach (var signature in signatures) {
            if (Profile.Validate(profiles, signature, digest, profileUdf)) {
                return true;
                }
            }

        return false;
        }

    }
