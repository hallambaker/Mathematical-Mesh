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


using Goedel.Protocol;

namespace Goedel.Mesh {




    /// <summary>
    /// A verified device credential.
    /// </summary>
    public class MeshVerifiedDevice  {

        ///<summary>The credential provider.</summary> 
        public string Provider => MeshCredential.Provider;

        ///<summary>The validation data??</summary> 
        public CredentialValidation CredentialValidation => MeshCredential.CredentialValidation;

        ///<summary>Return the underlying credential.</summary> 
        public MeshCredentialPublic MeshCredential { get; }

        /// <summary>
        /// Construct an instance from the credential <paramref name="meshCredential"/>
        /// </summary>
        /// <param name="meshCredential">The credential from which the instance is to be created.</param>
        public MeshVerifiedDevice(MeshCredentialPublic meshCredential) =>
            MeshCredential = meshCredential;

        }



    /// <summary>
    /// A verified account credential.
    /// </summary>
    public class MeshVerifiedAccount : MeshVerifiedDevice {

        ///<summary>The account address</summary> 
        public string AccountAddress => MeshCredential.Account;

        /// <summary>
        /// Construct an instance from the credential <paramref name="meshCredential"/>
        /// </summary>
        /// <param name="meshCredential">The credential from which the instance is to be created.</param>
        public MeshVerifiedAccount(MeshCredentialPublic meshCredential) : base(meshCredential) {
            }

        /// <summary>
        /// Validate the profile <paramref name="profile"/> under this credential
        /// </summary>
        /// <param name="profile">The profile to validate.</param>
        public virtual void Validate(ProfileUser profile) => MeshCredential.ConnectionDevice.Validate(profile);

        /// <summary>
        /// Validate the profile <paramref name="profile"/> under this credential
        /// </summary>
        /// <param name="profile">The profile to validate.</param>
        public virtual void Validate(ProfileGroup profile) {
            //MeshCredential.ConnectionDevice.Validate(profile);


            // stub this out for now.

            }


        }


    }
