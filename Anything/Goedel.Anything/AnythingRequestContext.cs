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

public record AnythingRequestContext {

    public string Id { get; init; }

    public AnythingState State { get; set; }

    public CatalogedThing Thing { get; init; }

    public List<SignedObject> ToBeSigned { get; set; }

    public List<SignedObject> Signed { get; set; }

    public DateTime TryAfter { get; init; }

    public List<AcmeChallenge>? Challenges { get; set; }


    }



public enum AnythingState {
    Initial = 1,
    WaitValidate = 2,
    WaitCsr = 3,
    CsrReady = 4,
    WaitCertificate = 5,
    Complete = 6

    }


public enum SignedObjectType {

    PrivateCA,
    EndEntityPrivate,
    EndEntityPublic

    }
public record SignedObject {

    public SignedObjectType Type { get; init; }

    public byte[] Data { get; init; }


    }

public record AcmeChallenge {
    public string Value { get; init; }
    public string Label { get; init; }

    }