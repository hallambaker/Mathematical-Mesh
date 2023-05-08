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


//#pragma warning disable IDE0059
//#pragma warning disable CA1822

namespace Goedel.XUnit;

public partial class TSignatures {

    [Fact(Skip = "PQC not yet implemented")]
    public void NYI_PQCProfile() {

        "Verify valid PQC profile".TaskTest();
        "Fail PQC profile with invalid ECC".TaskTest();
        "Fail PQC profile with invalid PQC".TaskTest();


        }






    [Fact(Skip = "Signature testing skiped pending invalidation library")]
    public void TestAuthorizationGood() => throw new NYI();

    [Fact(Skip = "Signature testing skiped pending invalidation library")]
    public void TestAuthorizationInsufficientTransact() => throw new NYI();

    [Fact(Skip = "Signature testing skiped pending invalidation library")]
    public void TestAuthorizationInsufficientDownload() => throw new NYI();

    [Fact(Skip = "Signature testing skiped pending invalidation library")]
    public void TestAuthorizationInsufficientPost() => throw new NYI();

    [Fact(Skip = "Signature testing skiped pending invalidation library")]
    public void TestAuthorizationInsufficientPublicRead() => throw new NYI();

    [Fact(Skip = "Signature testing skiped pending invalidation library")]
    public void TestAuthorizationInsufficientComplete() => throw new NYI();

    [Fact(Skip = "Signature testing skiped pending invalidation library")]
    public void TestAuthorizationInsufficientStatus() => throw new NYI();

    public static TSignatures Test() => new();

    [Fact(Skip = "Signature testing skiped pending invalidation library")]
    public void TestSignatureProfile() => throw new NYI();


    [Fact(Skip = "Signature testing skiped pending invalidation library")]
    public void TestProfileDevice() => throw new NYI();

    [Fact(Skip = "Signature testing skiped pending invalidation library")]
    public void TestSignatureProfileAccount() => throw new NYI();

    [Fact(Skip = "Signature testing skiped pending invalidation library")]
    public void TestSignatureProfileService() => throw new NYI();

    [Fact(Skip = "Signature testing skiped pending invalidation library")]
    public void TestSignatureProfileHost() => throw new NYI();

    [Fact(Skip = "Signature testing skiped pending invalidation library")]
    public void TestSignatureConnection() => throw new NYI();

    [Fact(Skip = "Signature testing skiped pending invalidation library")]
    public void TestSignatureConnectionStripped() => throw new NYI();

    [Fact(Skip = "Signature testing skiped pending invalidation library")]
    public void TestSignatureConnectionDevice() => throw new NYI();

    [Fact(Skip = "Signature testing skiped pending invalidation library")]
    public void TestSignatureConnectionHost() => throw new NYI();

    [Fact(Skip = "Signature testing skiped pending invalidation library")]
    public void TestConnectBadDevice() => throw new NYI();

    [Fact(Skip = "Signature testing skiped pending invalidation library")]
    public void TestConnectBadService() => throw new NYI();


    [Fact(Skip = "Signature testing skiped pending invalidation library")]
    public void TestContactBad() => throw new NYI();

    [Fact(Skip = "Signature testing skiped pending invalidation library")]
    public void TestConfirmBad() => throw new NYI();



    }
