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

namespace Goedel.Cryptography.Dare;

/// <summary>
/// Stub key collection used to prevent keys being written to persistent storage.
/// </summary>
public class KeyCollectionEphemeral : KeyCollection, IKeyCollection {

    ///<inheritdoc/>
    public void ErasePrivateKey(string udf) => throw new NotImplementedException();

    ///<inheritdoc/>
    public override IJson LocatePrivateKey(string udf) => throw new PrivateKeyNotFound();

    ///<inheritdoc/>
    public override void Persist(string udf, IPKIXPrivateKey privateKey, bool Exportable) =>
            throw new NotImplementedException();

    ///<inheritdoc/>
    public override void Persist(string udf, IJson joseKey, bool exportable) =>
        throw new NotImplementedException();

    ///<inheritdoc/>
    public override KeyAgreementResult RemoteAgreement(string serviceAddress, KeyPairAdvanced ephemeral, string shareId) => throw new NotImplementedException();

    ///<inheritdoc/>
    public TrustResult ValidateTrustPath(DareSignature dareSignature, string anchor = null) =>
            throw new NotImplementedException();
    }
