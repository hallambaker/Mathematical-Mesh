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
/// Record returning all the information relating to construction of an EARL.
/// </summary>
public record EarlSet {

    ///<summary>The earl key in Base32-dash form.</summary> 
    public string Earl { get; }

    ///<summary>The locator key.</summary> 
    public string Locator { get; }

    ///<summary>The EARL ciphertext.</summary> 
    public byte[] Ciphertext { get; }

    ///<summary>The EARL URI scheme.</summary> 
    public string Scheme { get; }

    ///<summary>The EARL URI.</summary> 
    public string Uri => Scheme + ":" + Authority + Earl;

    ///<summary>The HTTPS Well Known Service fo rretrieval of the EARL ciphertext.</summary> 
    public string WellKnown => GetWellKnown(Authority, Locator);

    ///<summary>The authority section of the EARL URI, a DNS name.</summary> 
    public string Authority { get; }

    ///<summary>Password value computed from the EARL key.</summary> 
    public string Password => Udf.EarlLocator1(Earl);

    ///<summary>Username value computed from the EARL key.</summary> 
    public string Username => Password;

    /// <summary>
    /// Constructor returning an instance with the specified parameters.
    /// </summary>
    /// <param name="envelope">The enveloped data bytes.</param>
    /// <param name="authority">The authority section of the EARL URI, a DNS name.</param>
    /// <param name="scheme">The EARL URI scheme.</param>
    /// <param name="precision">The desired work factor in bits.</param>
    public EarlSet(
                byte[] envelope,
                string? authority = null,
                string scheme = "earl",
                int precision = 140) {
        (Earl, Locator, Ciphertext) = Udf.Earl(envelope);
        Scheme = scheme;
        Authority = authority == null ? "" : $"//{authority}/";
        }

    /// <summary>
    /// Constructor returning an instance with the specified parameters.
    /// </summary>
    /// <param name="contentMeta">The content metadata.</param>
    /// <param name="payload">The payload bytes.</param>
    /// <param name="authority">The authority section of the EARL URI, a DNS name.</param>
    /// <param name="scheme">The EARL URI scheme.</param>
    /// <param name="precision">The desired work factor in bits.</param>
    public EarlSet(
            ContentMeta contentMeta,
            byte[] payload,
            string? authority = null,
            string scheme = "earl",
                int precision = 140) : this(
                 VDareEnvelopeWriter.GetBytes(payload, contentMeta), authority, scheme, precision) {
        }

    /// <summary>
    /// Constructor returning an instance with the specified parameters.
    /// </summary>
    /// <param name="contentMeta">The content metadata.</param>
    /// <param name="payload">The payload bytes.</param>
    /// <param name="signers">A list of signing keys.</param>
    /// <param name="authority">The authority section of the EARL URI, a DNS name.</param>
    /// <param name="scheme">The EARL URI scheme.</param>
    /// <param name="precision">The desired work factor in bits.</param>
    public EarlSet(
            ContentMeta contentMeta,
            byte[] payload,
            IEnumerable<KeyPair> signers,
            string? authority = null,
            string scheme = "earl",
                int precision = 140) {



        //var writer = new EarlEnvelopeWriter(signers, contentMeta);
        //writer.Write(payload);
        //var envelope = writer.End(signers);


        var envelope = VDareEnvelopeWriter.GetBytes(payload, contentMeta, signers);


        (Earl, Locator, Ciphertext) = Udf.Earl(envelope);
        Scheme = scheme;
        Authority = authority == null ? "" : $"//{authority}/";

        }

    /// <summary>
    /// Convenience routine computing the well-known service for locating the ciphertext
    /// package from authority <paramref name="authority"/> using locator <paramref name="locator"/>.
    /// </summary>
    /// <param name="authority">The authority section of the EARL URI, a DNS name.</param>
    /// <param name="locator">The locator key.</param>
    /// <returns></returns>
    public static string GetWellKnown(
                string authority,
                string locator) => $"https://{authority}/.well-known/earl/{locator}.earl";




    }


/// <summary>EARL Envelope context.</summary>
public record EarlEnvelopeContext {

    /// <summary>Epiry time.</summary>
    public DateTime? Expire { get; set; } = null;

    /// <summary>Optional associated PIN for authenticating a response.</summary>
    public string? Pin { get; set; } = null;

    /// <summary>The set of signature keys.</summary>
    public IEnumerable<string>? SigningKeys { get; set; } = null;



    }