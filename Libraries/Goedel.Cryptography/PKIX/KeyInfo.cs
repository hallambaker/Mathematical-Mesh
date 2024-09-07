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


namespace Goedel.Cryptography.PKIX;

public partial class SubjectPublicKeyInfo {


    /// <summary>
    /// Construct from algorithm identifier and key data.
    /// </summary>
    /// <param name="oid">Algorithm identifier.</param>
    /// <param name="keyData">Key Data.</param>
    public SubjectPublicKeyInfo(string oid, byte[] keyData) {
        Algorithm = new AlgorithmIdentifier(oid);
        SubjectPublicKey = keyData;

        }

    /// <summary>
    /// Construct from algorithm identifier and key data.
    /// </summary>
    /// <param name="oid">Algorithm identifier.</param>
    /// <param name="keyData">Key Data.</param>
    /// <param name="parameter">Optional algorithm parameter.</param>
    public SubjectPublicKeyInfo(int[] oid, byte[] keyData, int[] parameter = null) {
        Algorithm = new AlgorithmIdentifier(oid, parameter);
        SubjectPublicKey = keyData;
        }

    }


public partial class AlgorithmIdentifier {


    /// <summary>
    /// Construct from OID identifier string.
    /// </summary>
    /// <param name="id">The identifier as a string</param>
    public AlgorithmIdentifier(string id) => Algorithm = ASN.ASN.OIDToArray(id);

    /// <summary>
    /// Create an Algorithm Identifier from an integer array.
    /// </summary>
    /// <param name="numbers">OID as an integer sequence.</param>
    /// <param name="parameter">Optional algorithm parameter.</param>
    public AlgorithmIdentifier(int[] numbers, int[] parameter = null) {
        Algorithm = numbers;
        Parameters = parameter;
        }

    }
