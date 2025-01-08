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


namespace Goedel.Anything;
public partial class Identity {

    ///<summary>Suffix appended to the name of the things deployed to the identity.</summary> 
    public abstract string DnsRoot { get; }

    /// <summary>
    /// Map the localname <paramref name="name"/> to the corresponding DNS name for this identity
    /// </summary>
    /// <param name="name">The local name to map</param>
    /// <returns>The DNS name</returns>
    public virtual string GetDnsName(string name) => $"{name}.{DnsRoot}";



    public virtual void CreateCertificate(
                CatalogedThing thing,
                CryptoAlgorithmId cryptoAlgorithm = CryptoAlgorithmId.P384) {


        }


    }

public partial class CatalogedIdentity {

    public string GetPrivateName() {
        foreach (var identity in Identities) {
            if (identity is CallsignIdentity) {
                return identity.Name;
                }
            }
        foreach (var identity in Identities) {
            if (identity is DnsIdentity) {
                return identity.Name;
                }
            }
        return Udf.Nonce(80);
        }



    public void CreateRoot(CryptoAlgorithmId algorithmId = CryptoAlgorithmId.P384) {


        //foreach (var identity in DnsIdenties) {
        //    identity.CreateRoot(algorithmId);
        //    }
        }


    public virtual void CreateCertificateSet (
                CatalogedThing thing,
                CryptoAlgorithmId cryptoAlgorithm = CryptoAlgorithmId.P384) {


        }


    }

public partial class LocalIdentity {

    ///<inheritdoc/>
    public override string DnsRoot => Name + ".";

    /////<inheritdoc/>
    //public override string GetDnsName(string name) => $"{name}.local.";


    public void CreateRoot(CryptoAlgorithmId cryptoAlgorithm = CryptoAlgorithmId.P384) {


        }


    }


public partial class DnsIdentity {
    ///<inheritdoc/>
    public override string DnsRoot => Name + ".";

    /////<inheritdoc/>
    //public override string GetDnsName(string name) => $"{name}.{Name}.";

    public void CreateRoot(CryptoAlgorithmId cryptoAlgorithm = CryptoAlgorithmId.P384) {


        }


    }

public partial class CallsignIdentity {
    ///<inheritdoc/>
    public override string DnsRoot => Name + ".mesh.";

    //public override string GetDnsName(string name) => $"{name}.{DnsRoot}";

    }