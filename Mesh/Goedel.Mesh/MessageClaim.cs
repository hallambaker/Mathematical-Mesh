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

public partial class MessageClaim {

    ///<summary>Typed enveloped data</summary> 
    public Enveloped<MessageClaim> GetEnvelopedMessageClaim() => new(DareEnvelope);


    ///<summary>Base constructor used for deserialization.</summary>
    public MessageClaim() { }


    /// <summary>
    /// Construct a MessageClaim instance making a claim by <paramref name="claimaintAccount"/>
    /// for <paramref name="targetAccount"/> using the value <paramref name="pin"/> for
    /// authentication.
    /// </summary>
    /// <param name="targetAccount">The account to which the claim is directed.</param>
    /// <param name="claimaintAccount">The account making the claim.</param>
    /// <param name="pin">Authentication code.</param>
    public MessageClaim(
            string targetAccount,
            string claimaintAccount,
            string pin) {
        Recipient = targetAccount;
        Sender = claimaintAccount;
        PublicationId = Udf.SymetricKeyId(pin);

        ServiceAuthenticate = CatalogedPublication.AuthenticateService(claimaintAccount, pin);
        DeviceAuthenticate = CatalogedPublication.AuthenticateDevice(claimaintAccount, pin);
        }

    /// <summary>
    /// Verify the claim against a service and device authenticator.
    /// </summary>
    /// <param name="serviceAuthenticator">The service authentication key.</param>
    /// <param name="deviceAuthenticator">The device authentication key.</param>
    /// <param name="length">minimum match length.</param>
    /// <returns>True if the match succeeded, otherwise false.</returns>
    public bool Verify(
            string serviceAuthenticator,
            string deviceAuthenticator,
            int length = 100) => CatalogedPublication.Verify(Sender, deviceAuthenticator, DeviceAuthenticate, length) &&
            CatalogedPublication.Verify(Sender, serviceAuthenticator, ServiceAuthenticate, length);// Hack: should this raise an exception?


    }
