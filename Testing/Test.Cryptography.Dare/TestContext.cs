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

using Goedel.Debug;
namespace Goedel.XUnit;




public enum ModeEnhance {

    ///<summary>No signature/encryption</summary> 
    None,

    ///<summary>Signature/Key Agreement at the individual record level. Each record
    ///individually enhanced.</summary> 
    Record,

    ///<summary>Signature/Key Agreement at the sequence level, decrypting or verifying
    ///once authenticates, decrypts entire file.</summary> 
    Sequence,

    ///<summary>Signature/Key Agreement of multiple records but not the entire 
    ///sequence in one operation.</summary> 
    Sparse
    }


/// <summary>
/// Mode in which to modify data
/// </summary>
///  [Flags]
public enum ModeCorruption {
    ///<summary></summary> 
    None,

    ///<summary></summary> 
    Data = 1 << 0,

    ///<summary>Corrupt the decryption or verification key.</summary> 
    Key = 1 << 1,

    ///<summary>Corrupt the decryption or verification key.</summary> 
    SignKey = 1 << 2,

    ///<summary>Corrupt the salt value.</summary> 
    Salt = 1 << 3,

    ///<summary>Corrupt the signature value.</summary> 
    Value = 1 << 4,

    }
public record TestContext {

    public DeterministicSeed Seed { get; }


    public string Filename => Seed.Seed + ".dares";


    public KeyPair KeyEncrypt { get; }
    public KeyPair KeySign { get; }
    public List<string> Recipients { get; }
    public List<string> Signers { get; }
    public KeyCollection KeyCollection { get; }


    public KeyCollection BadKeyCollection { get; }


    public KeyPair BadKeyEncrypt { get; }
    public KeyPair BadKeySign { get; }

    public DarePolicy DarePolicy { get; }

    public ModeEnhance Encrypt { get; }
    public ModeEnhance Sign { get; }
    public ModeCorruption Corruption { get; }


    public TestContext(
                DeterministicSeed deterministicSeed,
                ModeEnhance encrypt = ModeEnhance.None,
                ModeEnhance sign = ModeEnhance.None,
                ModeCorruption corruption = ModeCorruption.None) {
        Seed = deterministicSeed;
        Encrypt = encrypt;
        Sign = sign;
        Corruption = corruption;

        // Return if we are not doing any cryptography
        if ((encrypt == ModeEnhance.None) && (sign == ModeEnhance.None)) {
            return;
            }

        KeyCollection = new KeyCollectionTest(deterministicSeed.GetDirectory("Keys"));
        BadKeyCollection = new KeyCollectionTest(deterministicSeed.GetDirectory("Bad"));

        // set up base keys
        if (encrypt != ModeEnhance.None) {
            KeyEncrypt = KeyPair.Factory(CryptoAlgorithmId.X448,
                KeySecurity.Session, KeyCollection, keyUses: KeyUses.Encrypt);
            BadKeyEncrypt = KeyEncrypt.InvalidateKey(BadKeyCollection);
            Recipients = new List<string>() { (KeyEncrypt.KeyIdentifier) };

            }
        if (sign != ModeEnhance.None) {
            KeySign = KeyPair.Factory(CryptoAlgorithmId.Ed448,
                KeySecurity.Session, KeyCollection, keyUses: KeyUses.Sign);
            BadKeySign = KeySign.InvalidateKey(BadKeyCollection);
            Signers = new List<string>() { (KeySign.KeyIdentifier) };
            }

        DarePolicy = new DarePolicy(KeyCollection, signers: Signers, recipients: Recipients);
        }





    }
