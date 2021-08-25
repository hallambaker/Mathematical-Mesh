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

using Goedel.Cryptography.Dare;
using Goedel.Utilities;

namespace Goedel.Mesh {
    // Todo: Mail Store account access details, passwords, etc.

    // Todo: Mail PGP Passprase for PEM keys
    // Todo: Mail PGP Support for PGP ECC algorithms
    // Todo: Mail PGP Create PGP subkey / fingerprint / etc.
    // Todo: Mail PGP Push key to MIT key server

    // Todo: Mail SMIME Create CSR
    // Todo: Mail SMIME Request CA issued cert via ACME
    // Todo: Mail SMIME Save private key as P12
    // Todo: Mail SMIME Self signed root o'trust


    public partial class ActivationApplicationMail {

        ///<summary>The enveloped object</summary> 
        public Enveloped<ActivationApplicationMail> EnvelopedActivationApplicationMail =>
            envelopedActivationApplicationMail ?? new Enveloped<ActivationApplicationMail>(DareEnvelope).
                    CacheValue(out envelopedActivationApplicationMail);
        Enveloped<ActivationApplicationMail> envelopedActivationApplicationMail;



        }

    public partial class ApplicationEntryMail {


        ///<summary>The decrypted activation.</summary> 
        public ActivationApplicationMail Activation { get; set; }

        ///<inheritdoc/>

        public override void Decode(IKeyCollection keyCollection) {

            Activation = EnvelopedActivation.Decode(keyCollection);

            }
        }

    }

