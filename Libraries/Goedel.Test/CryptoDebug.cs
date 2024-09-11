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
using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.PQC;
using Goedel.Protocol;

namespace Goedel.Test.Core;

public enum DataValidity {
    ///<summary>The data is valid.</summary>
    Valid = 0b_0000_0000,

    ///<summary>The public key is invalid.</summary>
    CorruptSigner = 0b_0000_0001,

    ///<summary>The signature data is modified.</summary>
    CorruptSignature = 0b_0000_0010,

    ///<summary>The digest data is modified.</summary>
    CorruptDigest = 0b_0000_0100,

    ///<summary>The body is modified.</summary>
    CorruptPayload = 0b_0000_1000,

    ///<summary>An Attribute is modified.</summary>
    CorruptAttributes = 0b_0001_0000,

    ///<summary>The body is modified.</summary>
    CorruptMissing = 0b_0010_0000,

    }

public static class Extension {


    static byte[] CorruptCharacter = new byte[256];

    static Extension() {
        for (var i = 0; i < 256; i++) {
            CorruptCharacter[i] = (byte)i;
            }
        CorruptCharacters('0', 10);
        CorruptCharacters('a', 26);
        CorruptCharacters('A', 26);
        CorruptCharacter['+'] = (byte)'/';
        CorruptCharacter['/'] = (byte)'+';
        CorruptCharacter['-'] = (byte)'_';
        CorruptCharacter['_'] = (byte)'-';
        }

    static void CorruptCharacters(char start, int count) {
        var count2 = count / 2;
        for (var i = 0; i < count; i++) {
            CorruptCharacter[start + i] = (byte)(start + ((i + count2) % count));
            }

        }




    public static string CorruptedPIN(this string data) =>
        $"{data[0]}{data[1]}{data[2].Corrupt()}" + data[3..];

    public static char Corrupt(this char data) {
        var c = ((int)data) ^ 0x01;
        return (char)c;

        }

    public static string Corrupted(this string data) => data switch {
        null => "A",
        "" => "A",
        _ => data[0].Corrupt() + data[1..]
        };


    public static void Corrupt(
            this DareEnvelope envelope,
            DataValidity dataValidity = DataValidity.CorruptPayload,
            DareEnvelope alternative = null) {

        switch (dataValidity) {
            case DataValidity.CorruptPayload: {
                envelope.Body = envelope.Body.Corrupt();
                return;
                }
            case DataValidity.CorruptMissing: {
                envelope.Trailer.Signatures = null;
                return;
                }
            case DataValidity.CorruptDigest: {
                envelope.Trailer.PayloadDigest = envelope.Trailer.PayloadDigest.Corrupt();
                return;
                }
            case DataValidity.CorruptSignature: {
                var signature = envelope.Trailer.Signatures[0];
                signature.SignatureValue = signature.SignatureValue.Corrupt();
                return;
                }
            case DataValidity.CorruptSigner: {
                envelope.Trailer.Signatures = alternative.Trailer.Signatures;
                return;
                }

            }
        }



    public static void Corrupt(
            ref byte[] data) => data = Corrupt(data);


    public static byte[] Corrupt(
            this byte[] data) {
        if ((data == null) || (data.Length == 0)) {
            return new byte[1];
            }
        else {
            data[0] ^= 1;
            return data;
            }
        }

    public static void CorruptSignatureField(this Stream file, JcbdEnvelope envelope, string item) {
        var signatures = envelope.Header.GetProperty("signatures") ??
            envelope.Trailer.GetProperty("signatures");

        var signaturesValue = signatures.Value as JbcdValueArray;

        foreach (var sig in signaturesValue.Values) {
            var sigObject = sig as JbcdValueObject;

            var kid = sigObject.GetProperty(item);
            CorruptBinary(kid.Value, file);
            }
        }

    public static void CorruptSignature(this Stream file, JcbdEnvelope envelope) =>
        CorruptSignatureField(file, envelope, "signature");

    public static void CorruptSigner(this Stream file, JcbdEnvelope envelope) =>
        CorruptSignatureField(file, envelope, "kid");

    public static void CorruptMissingSignature(this Stream file, JcbdEnvelope envelope) {
        var signatures = envelope.Header.GetProperty("signatures") ??
            envelope.Trailer.GetProperty("signatures");

        signatures.ClearValue(file);
        }

    public static void CorruptSalt(this Stream file, JcbdEnvelope envelope) {
        var salt = envelope.Header.GetProperty("Salt");
        CorruptBinary(salt.Value, file);
        }

    public static void EraseSalt(this Stream file, JcbdEnvelope envelope) {
        var salt = envelope.Header.GetProperty("Salt");
        salt.ClearValue(file);
        }





    public static void CorruptDigestAlg(this Stream file, JcbdEnvelope envelope) {

        var digest = envelope.Header.GetProperty("dig");
        digest.AssertNotNull(NYI.Throw);

        Corrupt(digest.Value as JbcdValueString, file);

        }


    public static void CorruptDigestValue(this Stream file, JcbdEnvelope envelope) {

        // Corrupt the header value first if present
        var digest = envelope.Header.GetProperty("PayloadDigest");
        if (digest != null) {
            CorruptBinary(digest.Value, file);

            // If there is a header payload value, the trailer value MUST be null
            digest = envelope.Trailer?.GetProperty("PayloadDigest");
            digest.AssertNull(NYI.Throw);
            return;
            }

        // Corrupt the trailer value
        digest = envelope.Trailer.GetProperty("PayloadDigest");
        digest.AssertNotNull(NYI.Throw);
        CorruptBinary(digest.Value, file);


        }

    public static void CorruptPayloadValue(this Stream file, JcbdEnvelope envelope) {
        CorruptBinary(envelope.Body, file);
        }

    public static void Corrupt(this JbcdValueString jbcdValue, Stream file) {
        file.Position = jbcdValue.DataStartPosition;

        var b = file.ReadByte();


        if (b == '\"') {
            var position = file.Position;
            b = file.ReadByte();

            file.Position = position;
            file.WriteByte(CorruptCharacter[b]);
            }

        }

    public static void Corrupt(this JbcdValueBinary jbcdValue, Stream file) {
        file.Position = jbcdValue.DataStartPosition;

        var b = file.ReadByte();
        while (b.IsWhite()) {
            b = file.ReadByte();
            }


        var length = ModifierToLength(b);
        var position = file.Position + length;
        file.Position = position;
        b = file.ReadByte();
        b ^= 0x1;

        file.Position = position;
        file.WriteByte((byte)b);
        }

    static int ModifierToLength(int c) {
        var code = c & 0x03;
        return code switch {
            0 => 1,
            1 => 2,
            2 => 4,
            3 => 8,
            _ => throw new NYI(),
            };
        }


    public static void CorruptBinary(this JbcdValue jbcdValue, Stream file) {
        switch (jbcdValue) {
            case JbcdValueBinary jbcdValueBinary: {
                Corrupt(jbcdValueBinary, file);
                break;
                }
            case JbcdValueString jbcdValueString: {
                Corrupt(jbcdValueString, file);
                break;
                }
            }
        }



    }
public class CryptoStackDebug : CryptoStackEncode {
    public byte[] KeyEncrypt;
    public byte[] KeyMac;
    public byte[] IV;

    /// <summary>
    /// Create a CryptoStack instance to encode data with the specified cryptographic
    /// parameters.
    /// </summary>
    public CryptoStackDebug(
                    CryptoParameters cryptoParameters,
                    DareHeader dareHeader
                    ) : base(cryptoParameters, dareHeader) => CalculateParameters(Salt, out KeyEncrypt, out KeyMac, out IV);

    }


public class CryptoParametersDebug : CryptoParameters {

    public CryptoParametersDebug(IKeyLocate keyCollection = null,
                    List<string> recipients = null,
                    List<string> signers = null,
                    CryptoKey recipient = null,
                    CryptoKey signer = null,
                    CryptoAlgorithmId encryptID = CryptoAlgorithmId.NULL,
                    CryptoAlgorithmId digestID = CryptoAlgorithmId.NULL) :
                base(keyCollection, recipients, signers, recipient, signer, encryptID, digestID) {
        }

    /// <summary>
    /// Perform a new key exchange and 
    /// </summary>
    /// <returns></returns>
    protected override List<DareRecipient> KeyExchange() {
        // create the new base seed.
        BaseSeed = Platform.GetRandomBits(KeySize);

        // perform a key exchange for each recipient.
        var result = new List<DareRecipient>();
        foreach (var encryptionKey in EncryptionKeys) {
            result.Add(new DareRecipientDebug(BaseSeed, encryptionKey));
            }

        return result;
        }


    }


public class DareRecipientDebug : DareRecipient {

    public Key EphemeralPrivate;

    public byte[] KeyAgreement;

    public byte[] EncryptionKey;

    /// <summary>
    /// Create a DARERecipient using the specified cryptographic parameters.
    /// </summary>
    /// <param name="MasterKey">The master key</param>
    /// <param name="PublicKey">The recipient public key.</param>
    /// <returns>The recipient informatin object.</returns>
    public DareRecipientDebug(byte[] MasterKey, CryptoKey PublicKey) {

        var secret = Platform.GetRandomBytes(32);
        var privateKey = new CurveEdwards25519Private();
        var ephemeralpublic = privateKey.Public;
        var pkixPublicKeyECDH = new PKIXPublicKeyECDH(CryptoAlgorithmId.Ed25519,ephemeralpublic.Encoding);
        var pkixPrivateKeyECDH = new PKIXPrivateKeyECDH(CryptoAlgorithmId.Ed25519, secret);
        EphemeralPrivate = new PrivateKeyECDH(pkixPrivateKeyECDH);

        var PublicKeyEd = PublicKey as KeyPairEd25519;

        var result = new CurveEdwards25519Result() {
            EphemeralPublicValue = privateKey.Public,
            AgreementEd25519 = privateKey.Agreement(PublicKeyEd.IKeyAdvancedPublic as CurveEdwards25519Public)
            };

        EncryptionKey = result.KeyDerive.Derive(KDFInfo, 256);
        KeyAgreement = result.IKM;

        var exchange = Platform.KeyWrapRFC3394.Wrap(EncryptionKey, MasterKey);

        if (result.EphemeralKeyPair is KeyPair keyPairEpk) {
            Epk = Key.GetPublic(keyPairEpk);
            }
        else if (result.EphemeralKeyPair is AgreementDataBinary kemCiphertext) {
            Ek = kemCiphertext.Value;
            }


        KeyIdentifier = PublicKey.KeyIdentifier;

        WrappedBaseSeed = exchange;
        }
    }
