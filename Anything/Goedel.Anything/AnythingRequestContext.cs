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

/// <summary>
/// Request context, saves state acropss multiple stage requests.
/// </summary>
public record AnythingRequestContext {

    ///<summary>Unique transaction identifier</summary> 
    public string Id { get; init; }

    ///<summary>The current request state.</summary> 
    public AnythingState State { get; set; }

    ///<summary>The thing being registered</summary> 
    public CatalogedThing Thing { get; init; }

    ///<summary>List of object prototypes to be signed by the device.</summary> 
    public List<SignedObject> ToBeSigned { get; set; }

    ///<summary>List of signed objects.</summary> 
    public List<SignedObject> Signed { get; set; }

    ///<summary>Hint telling device not to bother retry before this time.</summary> 
    public DateTime TryAfter { get; init; }

    ///<summary>List of ACME challenges to be provisioned.</summary> 
    public List<AcmeChallenge>? Challenges { get; set; }


    }


/// <summary>
/// The request states.
/// </summary>
public enum AnythingState {

    ///<summary>Start state</summary> 
    Initial = 1,

    ///<summary>Waiting on CA to perform validation of request</summary> 
    WaitValidate = 2,

    ///<summary>Waiting on device providing signed CSRs</summary> 
    WaitCsr = 3,

    ///<summary>CSRs are ready, device waiting for presentment.</summary> 
    CsrReady = 4,

    ///<summary>Certificates requested by service, waiting for delivery.</summary> 
    WaitCertificate = 5,

    ///<summary>Request completed.</summary> 
    Complete = 6,

    ///<summary>The request failed for some reason.</summary> 
    Fail = -1

    }

/// <summary>
/// Identifies objects that were signed or are to be signed.
/// </summary>
public enum SignedObjectType {

    ///<summary>Private CA certificate.</summary> 
    PrivateCA,

    ///<summary>End entity certificate chained to private CA.</summary> 
    EndEntityPrivate,

    ///<summary>End entity certificate chained to public CA.</summary> 
    EndEntityPublic

    }

/// <summary>
/// An object that is either signed or to be signed.
/// </summary>
public record SignedObject {

    ///<summary>The object type.</summary> 
    public SignedObjectType Type { get; init; }

    ///<summary>The binary data.</summary> 
    public byte[] Data { get; init; }


    }

/// <summary>
/// Acme challenge value.
/// </summary>
public record AcmeChallenge {

    ///<summary>The challenge value.</summary> 
    public string Value { get; init; }

    ///<summary>The (prefixed) label to which the challenge is to be published.</summary> 
    public string Label { get; init; }

    }