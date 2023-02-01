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

using System.Collections.Generic;
using System.IO;
using System.Text;

using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.IO;
using Goedel.Mesh.Test;
using Goedel.Test.Core;
using Goedel.Utilities;

namespace ExampleGenerator;


public class ExampleDare {
    // Sequence stuff
    public string ContainerFramingSimple = "";
    public string ContainerFramingEncrypted = "";
    public string ContainerFramingEncryptedIndependent;

    public string EDSText;

    public string MailMessageAsRFC822;
    public DareEnvelope MailMessageAsDAREPlaintext;
    public DareEnvelope MailMessageAsDAREEncrypted;

    public List<SequenceFrame> ContainerHeadersSimple;
    public List<SequenceFrame> ContainerHeadersChain;
    public List<SequenceFrame> ContainerHeadersTree;
    public List<SequenceFrame> ContainerHeadersMerkleTree;
    public List<SequenceFrame> ContainerHeadersSigned;

    public List<SequenceFrame> ContainerHeadersEncryptSingleSession;
    public List<SequenceFrame> ContainerHeadersEncryptIndependentSession;


    // envelope stuff
    public readonly byte[] DareMessageTest1 = "This is a test long enough to require multiple blocks".ToUTF8();
    public readonly byte[] DareMessageTest2 = "Subject: Message metadata should be encrypted".ToUTF8();
    public readonly byte[] DareMessageTest3 = "2018-02-01".ToUTF8();

    public KeyPairEd25519 DareMessageAliceKeypair;
    public Key DareMessageAliceKey;

    public CurveEdwards25519Public SignatureAlicePrivate;
    public CurveEdwards25519Private SignatureAlicePublic;
    public KeyPairEd25519 SignatureAliceKeyPair;
    public Key SignatureAliceKey;

    public DareEnvelope DAREMessageAtomic;
    public DareEnvelope DAREMessageAtomicSign;
    public DareEnvelope DAREMessageAtomicSignEncrypt;
    public DareEnvelope MessageAtomicDS;
    public DareEnvelope MessageEnc;
    public DareEnvelope MessageAtomicDSEnc;

    public DarePolicy DarePolicyPlaintext;
    public DarePolicy DarePolicyEncrypt;
    public DarePolicy DarePolicySign;
    public DarePolicy DarePolicySignEncrypt;

    public CryptoParameters CryptoParametersPlaintext;
    public CryptoParameters CryptoParametersEncrypt;
    public CryptoParameters CryptoParametersSign;
    public CryptoParameters CryptoParametersSignEncrypt;
    public CryptoStackDebug CryptoStackEncrypt;




    }

public partial class CreateExamples {


    public ExampleDare Dare = new();


    StringWriter consoleWriter;


    public void PlatformDare() {

        GoContainer();
        GenerateKeys();
        GoDareEnvelope();
        GoDareSequence();
        //GoAdvanced();

        ShellKey = new ShellKey(this);
        ShellHash = new ShellHash(this);
        ShellDare = new ShellDare(this);
        ShellSequence = new ShellSequence(this);

        }

    #region // utils

    public Sequence MakeContainer(
                string FileName,
                DarePolicy policy,
                SequenceType ContainerType = SequenceType.Chain) {
        consoleWriter = new StringWriter();

        //var FileStream = FileName.FileStream(FileStatus.Overwrite);
        var JBCDStream = new JBCDStreamDebug(FileName, FileStatus.Overwrite, Output: consoleWriter);
        return Goedel.Cryptography.Dare.Sequence.NewSequence(JBCDStream, sequenceType: ContainerType, policy: policy);

        }

    public static byte[] TestData(int maxSize) {
        var Data = new byte[maxSize];
        for (var i = 0; i < maxSize; i++) {
            Data[i] = (byte)(i & 0xff);
            }
        return Data;
        }

    public static List<SequenceFrame> ReadContainer(Sequence container) {
        var ContainerHeaders = new List<SequenceFrame> {
                new SequenceFrame {
                    Header = container.HeaderFirst
                    }
                };
        //Console.WriteLine($"First Frame {Sequence.ContainerHeader}");
        foreach (var ContainerDataReader in container) {
            ContainerHeaders.Add(new SequenceFrame {
                Header = ContainerDataReader.Header,
                Trailer = ContainerDataReader.Trailer
                });
            //Console.WriteLine($"Read Frame {ContainerDataReader.Header}");
            }
        return ContainerHeaders;
        }

    static byte[] ReadBinary(JbcdStream jBCDStream) {
        jBCDStream.ReadTag(out _, out var Length);
        var Result = new byte[Length];
        jBCDStream.Read(Result, 0, (int)Length);
        return Result;
        }

    string ReadEDS(byte[] data) {
        var TextWriter = new StringWriter();

        using (var Input = new MemoryStream(data)) {
            using var JBCDStream = new JBCDStreamDebug(Input, TextWriter);
            var Salt = ReadBinary(JBCDStream);
            var Body = ReadBinary(JBCDStream);
            var Tag = ReadBinary(JBCDStream);
            }


        return TextWriter.ToString();
        }

    public class MailMessage {
        public string From = "Alice@example.com";
        public string To = "bob@example.com";
        public string Subject = "TOP-SECRET Product Launch Today!";
        public string Body = "The CEO told me the product launch is today. Tell no-one!";

        public string GetRFC822() {
            var Builder = new StringBuilder();
            Builder.AppendLine($"From: {From}");
            Builder.AppendLine($"To: {To}");
            Builder.AppendLine($"Subject: {Subject}");
            Builder.AppendLine();
            Builder.AppendLine(Body);
            return Builder.ToString();
            }

        public DareEnvelope GetDAREMessage(CryptoParameters cryptoParameters) {
            var data = new List<byte[]>() {
                MakeData("From", From),MakeData("To", To),MakeData("Subject", Subject)
                };

            var contentInfo = new ContentMeta() { ContentType = "application/example-mail" };

            return new DareEnvelope(cryptoParameters, Body.ToUTF8(),
                contentMeta: contentInfo, dataSequences: data);
            }

        static byte[] MakeData(string Tag, string Data) => $"{Tag}: {Data}".ToUTF8();

        }

    #endregion


    #region // Result fields



    readonly byte[] testData300 = TestData(300);
    KeyCollection keyCollection;
    List<byte[]> dataSequences;

    #endregion


    #region // Tests -bare

    void GoContainer() {
        var policyPlaintext = new DarePolicy();

        // Simple
        var TContainer = MakeContainer("Test1List", policyPlaintext, SequenceType.List);
        TContainer.Append(testData300);
        Dare.ContainerHeadersSimple = ReadContainer(TContainer);
        Dare.ContainerFramingSimple = consoleWriter.ToString();


        // Bitmask
        TContainer = MakeContainer("Test1Chain", policyPlaintext, SequenceType.Chain);
        TContainer.Append(testData300);
        TContainer.Append(testData300);
        TContainer.Append(testData300);
        Dare.ContainerHeadersChain = ReadContainer(TContainer);


        // Tree
        TContainer = MakeContainer("Test1Tree", policyPlaintext, SequenceType.Tree);
        TContainer.Append(testData300);
        TContainer.Append(testData300);
        TContainer.Append(testData300);
        TContainer.Append(testData300);
        TContainer.Append(testData300);
        TContainer.Append(testData300);
        Dare.ContainerHeadersTree = ReadContainer(TContainer);


        // Merkle Tree
        TContainer = MakeContainer("Test1Merkle", policyPlaintext, SequenceType.Merkle);
        TContainer.Append(testData300);
        TContainer.Append(testData300);
        TContainer.Append(testData300);
        TContainer.Append(testData300);
        TContainer.Append(testData300);
        TContainer.Append(testData300);
        Dare.ContainerHeadersMerkleTree = ReadContainer(TContainer);


        TContainer = MakeContainer("Test1Sign", policyPlaintext, SequenceType.Merkle);
        TContainer.Append(testData300);
        TContainer.Append(testData300);
        Dare.ContainerHeadersSigned = ReadContainer(TContainer);

        }

    void GenerateKeys() {
        // Encryption Key Set.
        var testEnvironmentCommon = new TestEnvironmentCommon();
        var machine1 = new MeshMachineTest(testEnvironmentCommon, name: "Machine1");


        var dareMessageAlicePrivateKeyPair = KeyPairEd25519.Generate(
            KeySecurity.Exportable, KeyUses.Encrypt);
        dareMessageAlicePrivateKeyPair.Locator = AliceAccount;

        Dare.DareMessageAliceKey = Key.GetPrivate(dareMessageAlicePrivateKeyPair);

        // Signature Key Set.
        Dare.SignatureAliceKeyPair = KeyPairEd25519.Generate(
            KeySecurity.Exportable, KeyUses.Sign);

        Dare.SignatureAliceKeyPair.Locator = AliceAccount;
        Dare.SignatureAliceKey = Key.GetPrivate(Dare.SignatureAliceKeyPair);


        keyCollection = new KeyCollectionTest(machine1);
        keyCollection.Add(dareMessageAlicePrivateKeyPair);
        keyCollection.Add(Dare.SignatureAliceKeyPair);

        // Initialize the crypto parameters.
        var accounts = new List<string> { AliceAccount };


        Dare.DarePolicyPlaintext = new DarePolicy(
                    keyLocate: keyCollection,
                    signers: null);
        Dare.DarePolicyEncrypt = new DarePolicy(
                    keyLocate: keyCollection,
                    recipients: accounts);
        Dare.DarePolicySign = new DarePolicy(
                    keyLocate: keyCollection,
                    signers: accounts);
        Dare.DarePolicySignEncrypt = new DarePolicy(
                    keyLocate: keyCollection,
                    recipients: accounts,
                    signers: accounts);


        Dare.CryptoParametersPlaintext = new CryptoParameters() {
            KeyLocate = keyCollection
            };
        Dare.CryptoParametersEncrypt = new CryptoParametersDebug(
                    keyCollection: keyCollection,
                    recipients: accounts);
        Dare.CryptoParametersSign = new CryptoParameters(
                    keyCollection: keyCollection,
                    signers: accounts);
        Dare.CryptoParametersSignEncrypt = new CryptoParameters(
                    keyCollection: keyCollection,
                    recipients: accounts,
                    signers: accounts);





        // Data Sequences
        dataSequences = new List<byte[]> { Dare.DareMessageTest2, Dare.DareMessageTest3 };

        // Dummy Mail Message
        var MailMessage = new MailMessage();
        Dare.MailMessageAsRFC822 = MailMessage.GetRFC822();
        Dare.MailMessageAsDAREPlaintext = MailMessage.GetDAREMessage(Dare.CryptoParametersPlaintext);
        Dare.MailMessageAsDAREEncrypted = MailMessage.GetDAREMessage(Dare.CryptoParametersEncrypt);

        // Recalculate the encryption parameters
        Dare.CryptoStackEncrypt = new CryptoStackDebug(Dare.CryptoParametersEncrypt,
                     Dare.MailMessageAsDAREEncrypted.Header);


        var EDS1 = Dare.MailMessageAsDAREPlaintext.Header.EDSS[0];
        Dare.EDSText = ReadEDS(EDS1);

        }


    void GoDareEnvelope() {

        // Plaintext atomic
        Dare.DAREMessageAtomic = new DareEnvelope(Dare.CryptoParametersPlaintext, Dare.DareMessageTest1);

        // Plaintext atomic EDS
        Dare.MessageAtomicDS = new DareEnvelope(Dare.CryptoParametersPlaintext, Dare.DareMessageTest1, dataSequences: dataSequences);

        Dare.DAREMessageAtomicSign = new DareEnvelope(Dare.CryptoParametersSign, Dare.DareMessageTest1);
        Dare.DAREMessageAtomicSignEncrypt = new DareEnvelope(Dare.CryptoParametersSignEncrypt, Dare.DareMessageTest1);


        var encEnvelope = new DareEnvelope {
            Header = new DareHeader() {
                }
            };

        Dare.CryptoStackEncrypt = new CryptoStackDebug(Dare.CryptoParametersEncrypt, encEnvelope.Header);
        encEnvelope.Body = encEnvelope.Header.EnhanceBody(Dare.DareMessageTest1, out var trailer);
        encEnvelope.Trailer = trailer;

        Dare.MessageEnc = encEnvelope;

        //CryptoStackEncrypt.Message(DareMessageTest1);
        //ExampleGenerator.MeshExamplesMessage(this);
        }

    //public string ContainerFramingEncrypted;


    void GoDareSequence() {
        // Encrypt a set of data under one key exchange.
        var EncryptingContainer = MakeContainer("Test1Enc", Dare.DarePolicyEncrypt, SequenceType.List);
        EncryptingContainer.Append(testData300);
        EncryptingContainer.Append(testData300);
        Dare.ContainerHeadersEncryptSingleSession = ReadContainer(EncryptingContainer);
        Dare.ContainerFramingEncrypted = consoleWriter.ToString();


        // Encrypt a sequence of items with a key exchange per item.
        var EncryptedContainer = MakeContainer("Test1EncSep", Dare.DarePolicyPlaintext, SequenceType.List);
        EncryptedContainer.Append(testData300);
        EncryptedContainer.Append(testData300);
        Dare.ContainerHeadersEncryptIndependentSession = ReadContainer(EncryptedContainer);
        Dare.ContainerFramingEncryptedIndependent = consoleWriter.ToString();
        }

    #endregion


    }
