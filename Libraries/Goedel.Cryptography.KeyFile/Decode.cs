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

namespace Goedel.Cryptography.KeyFile;

// Feature: Read Bitvise private key
// Feature: Read PuTTY format private keys.

/// <summary>
/// Encoders and decoders for various key file formats
/// </summary>
public static class KeyFileDecode {

    /// <summary>
    /// Decode SSH Authorized Key file format
    /// </summary>
    /// <param name="fileName">File to decode.</param>
    /// <returns>List of authorized keys</returns>
    public static List<AuthorizedKey> DecodeAuthHost(string fileName) {
        using var TextReader = fileName.OpenFileReadShared();
        using LexReader LexReader = new(TextReader);
        return DecodeAuthHost(LexReader);
        }

    /// <summary>
    /// Decode an authorized hosts format file.
    /// </summary>
    /// <param name="lexReader">Input</param>
    /// <returns>List of authorized keys</returns>
    public static List<AuthorizedKey> DecodeAuthHost(LexReader lexReader) {
        List<AuthorizedKey> Result = new();

        try {
            using var Lexer = new AuthKeysFileLex(lexReader);
            var Token = Lexer.GetToken();
            while (Token == AuthKeysFileLex.Token.Data) {
                var TaggedData = Lexer.GetTaggedData();
                Result.Add(TaggedData);
                Token = Lexer.GetToken();
                }
            }
        catch (System.Exception inner) {
            throw new ParseError(inner: inner, args: lexReader.FilePath);
            }

        return Result;
        }



    /// <summary>
    /// Decode PEM format key file.
    /// </summary>
    /// <param name="fileName">Name of the file</param>
    /// <returns>Public key information</returns>
    /// <param name="keySecurity">The key security model</param>
    /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
    /// the value of <paramref name="keySecurity"/></param>
    public static KeyPair DecodePEM(string fileName,
        KeySecurity keySecurity, KeyCollection keyCollection) {
        using var TextReader = fileName.OpenFileReadShared();
        LexReader LexReader = new(TextReader);
        return DecodePEM(LexReader, keySecurity, keyCollection);
        }

    /// <summary>
    /// Decode PEM format key file.
    /// </summary>
    /// <param name="text">Text input.</param>
    /// <returns>Public key information</returns>
    /// <param name="keySecurity">The key security model</param>
    /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
    /// the value of <paramref name="keySecurity"/></param>
    public static KeyPair DecodePEMText(string text,
        KeySecurity keySecurity, KeyCollection keyCollection) {
        var Reader = new System.IO.StringReader(text);
        LexReader LexReader = new(Reader);
        return DecodePEM(LexReader, keySecurity, keyCollection);
        }


    /// <summary>
    /// Decode PEM format key file.
    /// </summary>
    /// <param name="lexReader">Input file.</param>
    /// <returns>Public key information</returns>
    /// <param name="keySecurity">The key security model</param>
    /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
    /// the value of <paramref name="keySecurity"/></param>
    public static KeyPair DecodePEM(LexReader lexReader,
                KeySecurity keySecurity, KeyCollection keyCollection) {
        using var Lexer = new KeyFileLex(lexReader);
        var Token = Lexer.GetToken();

        if (Token == KeyFileLex.Token.Data) {
            var TaggedData = Lexer.GetTaggedData();
            if (!TaggedData.Strict) {
                //Console.WriteLine("Some yukky data here");
                }

            if (TaggedData.Tag == "RSAPRIVATEKEY") {
                // is ASN.1 format DER modulus/exponent etc.

                var RSAPrivate = new PkixPrivateKeyRsa(TaggedData.Data);
                return KeyPairBaseRSA.KeyPairPrivateFactory(RSAPrivate, keySecurity, keyCollection);
                }
            else if (TaggedData.Tag == "RSAPUBLICKEY") {
                // is ASN.1 format DER modulus/exponent
                var RSAPrivate = new PkixPrivateKeyRsa(TaggedData.Data);
                return KeyPairBaseRSA.KeyPairPrivateFactory(RSAPrivate, keySecurity, keyCollection);
                }
            else if (TaggedData.Tag == "SSH2PUBLICKEY") {
                var SSH_Public_Key = SSHData.Decode(TaggedData.Data);
                return SSH_Public_Key.KeyPair;
                }
            }

        return null;
        }

    }
