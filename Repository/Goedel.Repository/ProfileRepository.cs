//  Copyright © 2021 by Threshold Secrets Llc.
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

namespace Goedel.Repository;

public partial class ProfileRepository {


    /// <summary>
    /// Create and return an empty instance.
    /// </summary>
    public ProfileRepository() {
        }

    /// <summary>
    /// Construct a Profile Account instance  from <paramref name="accountAddress"/>.
    /// </summary>
    /// <param name="accountAddress">The account address</param>
    /// <param name="activationAccount">The activation used to create the account data.</param>
    ProfileRepository(
                string accountAddress,
                ActivationCommon activationAccount) : base(accountAddress, activationAccount) { 
        }


    /// <summary>
    /// Construct a Profile Account instance  from <paramref name="accountAddress"/>.
    /// </summary>
    /// <param name="accountAddress">The account address</param>
    /// <param name="activationAccount">The activation used to create the account data.</param>
    public static ProfileRepository Generate(
                string accountAddress,
                ActivationCommon activationAccount) {

        var profile = new ProfileRepository(accountAddress, activationAccount);

        profile.SignProfile();
        return profile;
        }


    /// <summary>
    /// Verify the profile to check that it is correctly signed and consistent.
    /// </summary>
    /// <returns></returns>
    public override void Validate() {
        base.Validate();

        AccountEncryptionKey.PublicOnly.AssertTrue(InvalidProfile.Throw);
        AdministratorSignatureKey.PublicOnly.AssertTrue(InvalidProfile.Throw);

        }


    }



