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

public record EarlSet {

    public string Earl { get; }
    public string Locator { get; }
    public byte[] Ciphertext { get; }

    public string Scheme { get; }

    public string Uri => Scheme + ":" + Authority + Earl;

    public string WellKnown => GetWellKnown(Authority, Locator);

    public string Authority { get; }

    public string Password => Udf.EarlLocator1(Earl);

    public string Username => Password;

    public EarlSet(
                byte[] envelope,
                string? service = null,
                string scheme = "earl",
                int precision = 140) {
        (Earl, Locator, Ciphertext) = Udf.Earl(envelope);
        Scheme = scheme;
        Authority = service == null ? "" : $"//{service}/";
        }

    public EarlSet(
            ContentMeta contentMeta,
            byte[] payload,
            string? service = null,
            string scheme = "earl",
                int precision = 140) : this(
                 EarlEnvelopeWriter.GetBytes(contentMeta, payload), service, scheme, precision) {
        }

    public static string GetWellKnown(
                string authority,
                string locator) => $"https://{authority}/.well-known/earl/{locator}";




    }