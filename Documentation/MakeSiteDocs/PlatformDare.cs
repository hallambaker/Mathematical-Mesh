using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.IO;
using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Test.Core;
using Goedel.Utilities;

using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExampleGenerator {


    public partial class CreateExamples {
        public string ContainerFramingSimple = "";
        StringWriter ConsoleWriter;

        public List<ContainerFrame> ContainerHeadersSimple;
        public List<ContainerFrame> ContainerHeadersChain;
        public List<ContainerFrame> ContainerHeadersTree;
        public List<ContainerFrame> ContainerHeadersMerkleTree;
        public List<ContainerFrame> ContainerHeadersSigned;
        public void PlatformDare() {

            GoContainer();
            GenerateKeys();
            GoDareEnvelope();
            GoDareContainer();
            //GoAdvanced();

            DoCommandsKey();
            DoCommandsHash();
            DoCommandsDare();
            DoCommandsContainer();

            }

        #region // utils

        public Container MakeContainer(
                    string FileName,
                    CryptoParameters CryptoParameters,
                    ContainerType ContainerType = ContainerType.Chain) {
            ConsoleWriter = new StringWriter();

            //var FileStream = FileName.FileStream(FileStatus.Overwrite);
            var JBCDStream = new JBCDStreamDebug(FileName, FileStatus.Overwrite, Output: ConsoleWriter);
            return Container.NewContainer(JBCDStream, CryptoParameters, ContainerType);

            }

        public static byte[] TestData(int maxSize) {
            var Data = new byte[maxSize];
            for (var i = 0; i < maxSize; i++) {
                Data[i] = (byte)(i & 0xff);
                }
            return Data;
            }

        public List<ContainerFrame> ReadContainer(Container container) {
            var ContainerHeaders = new List<ContainerFrame> {
                new ContainerFrame {
                    Header = container.ContainerHeaderFirst
                    }
                };
            //Console.WriteLine($"First Frame {Container.ContainerHeader}");
            foreach (var ContainerDataReader in container) {
                ContainerHeaders.Add(new ContainerFrame {
                    Header = ContainerDataReader.Header,
                    Trailer = ContainerDataReader.Trailer
                    });
                //Console.WriteLine($"Read Frame {ContainerDataReader.Header}");
                }
            return ContainerHeaders;
            }


        byte[] ReadBinary(JbcdStream jBCDStream) {
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
                var Data = new List<byte[]>() {
                MakeData("From", From),MakeData("To", To),MakeData("Subject", Subject)
                };

                var contentInfo = new ContentMeta() { ContentType = "application/example-mail" };

                return new DareEnvelope(cryptoParameters, Body.ToUTF8(),
                    contentMeta: contentInfo, dataSequences: Data);
                }


            byte[] MakeData(string Tag, string Data) => $"{Tag}: {Data}".ToUTF8();

            }

        #endregion


        #region // Result fields

        public bool GitHub = true;
        public string Preformat => GitHub ? "````" : "~~~~";


        public byte[] MessagePlaintext = "This is a sample Plaintext".ToBytes();

        public string MessageTestPlaintext = "TBS";
        public string MessageTestRSAMAC = "TBS";
        public string MessageTestRSAEncrypted = "TBS";
        public string MessageTestRSAEncryptedMAC = "TBS";
        public string MessageTestRSASigned = "TBS";
        public string MessageTestRSAEncryptedSigned = "TBS";

        public readonly byte[] DareMessageTest1 = "This is a test long enough to require multiple blocks".ToUTF8();
        public readonly byte[] DareMessageTest2 = "Subject: Message metadata should be encrypted".ToUTF8();
        public readonly byte[] DareMessageTest3 = "2018-02-01".ToUTF8();

        //public CurveEdwards25519Private DareMessageAlicePrivate;
        //public CurveEdwards25519Public DareMessageAlicePublic;
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


        public byte[] DareMessageBody;


        public string ContainerFramingEncrypted = "";
        public string ContainerFramingEncryptedIndependent;
        byte[] testData300 = TestData(300);

        public string AccountAlice = "alice@example.com";


        public CryptoParameters CryptoParametersPlaintext;
        public CryptoParameters CryptoParametersEncrypt;
        public CryptoParameters CryptoParametersSign;
        public CryptoParameters CryptoParametersSignEncrypt;

        public CryptoStackDebug CryptoStackEncrypt;

        KeyCollection keyCollection;

        List<byte[]> dataSequences;


        public string MailMessageAsRFC822;
        public DareEnvelope MailMessageAsDAREPlaintext;
        public DareEnvelope MailMessageAsDAREEncrypted;

        public string EDSText;

        #endregion


        #region // Tests -bare

        void GoContainer() {
            var CryptoParametersPlaintext = new Goedel.Test.CryptoParametersTest();

            // Simple
            var TContainer = MakeContainer("Test1List", CryptoParametersPlaintext, ContainerType.List);
            TContainer.Append(testData300);
            ContainerHeadersSimple = ReadContainer(TContainer);
            ContainerFramingSimple = ConsoleWriter.ToString();


            // Digest
            TContainer = MakeContainer("Test1Chain", CryptoParametersPlaintext, ContainerType.Chain);
            TContainer.Append(testData300);
            TContainer.Append(testData300);
            TContainer.Append(testData300);
            ContainerHeadersChain = ReadContainer(TContainer);


            // Tree
            TContainer = MakeContainer("Test1Tree", CryptoParametersPlaintext, ContainerType.Tree);
            TContainer.Append(testData300);
            TContainer.Append(testData300);
            TContainer.Append(testData300);
            TContainer.Append(testData300);
            TContainer.Append(testData300);
            TContainer.Append(testData300);
            ContainerHeadersTree = ReadContainer(TContainer);


            // Merkle Tree
            TContainer = MakeContainer("Test1Merkle", CryptoParametersPlaintext, ContainerType.MerkleTree);
            TContainer.Append(testData300);
            TContainer.Append(testData300);
            TContainer.Append(testData300);
            TContainer.Append(testData300);
            TContainer.Append(testData300);
            TContainer.Append(testData300);
            ContainerHeadersMerkleTree = ReadContainer(TContainer);


            TContainer = MakeContainer("Test1Sign", CryptoParametersPlaintext, ContainerType.MerkleTree);
            TContainer.Append(testData300);
            TContainer.Append(testData300, CryptoParametersSign);
            ContainerHeadersSigned = ReadContainer(TContainer);



            //ExampleGenerator.MeshExamplesContainer(this);
            //ExampleGenerator.MeshExamplesUDFCompressed(this);
            }

        void GenerateKeys() {
            // Encryption Key Set.
            var testEnvironmentCommon = new TestEnvironmentCommon();
            var Machine1 = new MeshMachineTest(testEnvironmentCommon, name: "Machine1");


            var DareMessageAlicePrivateKeyPair = KeyPairEd25519.Generate(
                KeySecurity.Exportable, KeyUses.Encrypt);
            DareMessageAlicePrivateKeyPair.Locator = AccountAlice;

            DareMessageAliceKey = Key.GetPrivate(DareMessageAlicePrivateKeyPair);

            // Signature Key Set.
            SignatureAliceKeyPair = KeyPairEd25519.Generate(
                KeySecurity.Exportable, KeyUses.Sign);

            SignatureAliceKeyPair.Locator = AccountAlice;
            SignatureAliceKey = Key.GetPrivate(SignatureAliceKeyPair);


            keyCollection = new KeyCollectionTest(Machine1);
            keyCollection.Add(DareMessageAlicePrivateKeyPair);
            keyCollection.Add(SignatureAliceKeyPair);

            // Initialize the crypto parameters.

            var Accounts = new List<string> { AccountAlice };
            CryptoParametersPlaintext = new CryptoParameters(
                        keyCollection: keyCollection);

            CryptoParametersEncrypt = new CryptoParameters(
                        keyCollection: keyCollection,
                        recipients: Accounts);

            CryptoParametersSign = new CryptoParameters(
                        keyCollection: keyCollection,
                        signers: Accounts);

            CryptoParametersSignEncrypt = new CryptoParameters(
                        keyCollection: keyCollection,
                        recipients: Accounts,
                        signers: Accounts);

            CryptoStackEncrypt = new CryptoStackDebug(CryptoParametersEncrypt);


            // Data Sequences
            dataSequences = new List<byte[]> { DareMessageTest2, DareMessageTest3 };

            // Dummy Mail Message
            var MailMessage = new MailMessage();
            MailMessageAsRFC822 = MailMessage.GetRFC822();
            MailMessageAsDAREPlaintext = MailMessage.GetDAREMessage(CryptoParametersPlaintext);
            MailMessageAsDAREEncrypted = MailMessage.GetDAREMessage(CryptoParametersEncrypt);

            var EDS1 = MailMessageAsDAREPlaintext.Header.EDSS[0];
            EDSText = ReadEDS(EDS1);

            }


        void GoDareEnvelope() {

            // Plaintext atomic
            DAREMessageAtomic = new DareEnvelope(CryptoParametersPlaintext, DareMessageTest1);

            // Plaintext atomic EDS
            MessageAtomicDS = new DareEnvelope(CryptoParametersPlaintext, DareMessageTest1, dataSequences: dataSequences);

            DAREMessageAtomicSign = new DareEnvelope(CryptoParametersSign, DareMessageTest1);
            DAREMessageAtomicSignEncrypt = new DareEnvelope(CryptoParametersSignEncrypt, DareMessageTest1);


            CryptoStackEncrypt = new CryptoStackDebug(CryptoParametersEncrypt);
            MessageEnc = new DareEnvelope(CryptoStackEncrypt, DareMessageTest1);

            //CryptoStackEncrypt.Message(DareMessageTest1);

            //ExampleGenerator.MeshExamplesMessage(this);
            }

        //public string ContainerFramingEncrypted;
        public List<ContainerFrame> ContainerHeadersEncryptSingleSession;
        public List<ContainerFrame> ContainerHeadersEncryptIndependentSession;

        void GoDareContainer() {
            // Encrypt a set of data under one key exchange.
            var EncryptingContainer = MakeContainer("Test1Enc", CryptoParametersEncrypt, ContainerType.List);
            EncryptingContainer.Append(testData300);
            EncryptingContainer.Append(testData300);
            ContainerHeadersEncryptSingleSession = ReadContainer(EncryptingContainer);
            ContainerFramingEncrypted = ConsoleWriter.ToString();


            // Encrypt a sequence of items with a key exchange per item.
            var EncryptedContainer = MakeContainer("Test1EncSep", CryptoParametersPlaintext, ContainerType.List);
            EncryptedContainer.Append(testData300, cryptoParameters: CryptoParametersEncrypt);
            EncryptedContainer.Append(testData300, cryptoParameters: CryptoParametersEncrypt);
            ContainerHeadersEncryptIndependentSession = ReadContainer(EncryptedContainer);
            ContainerFramingEncryptedIndependent = ConsoleWriter.ToString();
            }

        #endregion




        #region // Tests - shell

        public List<ExampleResult> KeyNonce;
        public List<ExampleResult> KeyNonce256;
        public List<ExampleResult> KeySecret;
        public List<ExampleResult> KeySecret256;
        public List<ExampleResult> KeyEarl;

        public List<ExampleResult> KeyShare;
        public List<ExampleResult> KeyRecover;
        public List<ExampleResult> KeyShare2;
        public List<ExampleResult> KeyShare3;


        public string Secret1;


        public void DoCommandsKey() {
            KeyNonce = testCLIAlice1.Example("key nonce");
            KeyNonce256 = testCLIAlice1.Example("key nonce /bits=256");
            KeySecret = testCLIAlice1.Example("key secret");
            KeySecret256 = testCLIAlice1.Example("key secret /bits=256");
            KeyEarl = testCLIAlice1.Example("key earl");
            KeyShare = testCLIAlice1.Example("key share");
            Secret1 = (KeyShare[0].Result as ResultKey).Key;
            var share1 = (KeyShare[0].Result as ResultKey).Shares[0];
            var share2 = (KeyShare[0].Result as ResultKey).Shares[2];

            KeyRecover = testCLIAlice1.Example($"key recover {share1} {share2}");
            KeyShare2 = testCLIAlice1.Example($"key share /quorum=3 /shares=5");
            KeyShare3 = testCLIAlice1.Example($"key share {Secret1}");

            }

        public List<ExampleResult> HashUDF2;
        public List<ExampleResult> HashUDF3;
        public List<ExampleResult> HashUDF200; // Wrong precision, implement /bits
        public List<ExampleResult> HashUDFExpect; // implement /expect
        public List<ExampleResult> HashDigest;
        public List<ExampleResult> HashDigests;
        public List<ExampleResult> MAC1;  // return the key
        public List<ExampleResult> MAC2;  // implement key option
        public List<ExampleResult> MAC3;  // implement expect option

        public void DoCommandsHash() {
            HashUDF2 = testCLIAlice1.Example($"hash udf {TestFile1}");
            var expect2 = (HashUDF2[0].Result as ResultDigest).Digest;
            HashUDF3 = testCLIAlice1.Example($"hash udf {TestFile1} /cty=application/binary",
                                              $"hash udf {TestFile1} /alg=sha3");
            var expect3 = (HashUDF3[0].Result as ResultDigest).Digest;
            HashUDF200 = testCLIAlice1.Example($"hash udf {TestFile1} /bits=200");
            HashUDFExpect = testCLIAlice1.Example($"hash udf {TestFile1} /expect={expect2}",
                                              $"hash udf {TestFile1} /expect={expect3}");
            HashDigest = testCLIAlice1.Example($"hash digest {TestFile1}");
            HashDigests = testCLIAlice1.Example($"hash digest {TestFile1} /alg=sha256",
                                              // $"hash digest {TestFile1} /alg=sha128",
                                              $"hash digest {TestFile1} /alg=sha3256",
                                              $"hash digest {TestFile1} /alg=sha3");
            MAC1 = testCLIAlice1.Example($"hash mac {TestFile1}");
            var key = (MAC1[0].Result as ResultDigest).Key;
            var digest = (MAC1[0].Result as ResultDigest).Digest;

            MAC2 = testCLIAlice1.Example($"hash mac {TestFile1} /key={key}");
            MAC3 = testCLIAlice1.Example($"hash mac {TestFile1} /key={key} /expect={digest}",
                $"hash mac {TestFile1} /key={key} /expect={expect2}");
            }

        public List<ExampleResult> DarePlaintext;
        public List<ExampleResult> DareSymmetric;
        public List<ExampleResult> DareSub;
        public List<ExampleResult> DareMesh;
        public List<ExampleResult> GroupEncrypt;

        public List<ExampleResult> DareVerifyDigest;
        public List<ExampleResult> DareVerifySigned;
        public List<ExampleResult> DareVerifySymmetric;
        public List<ExampleResult> DareVerifySymmetricUnknown;

        public List<ExampleResult> DareDecodePlaintext;
        public List<ExampleResult> DareDecodeSymmetric;
        public List<ExampleResult> DareDecodePrivate;

        public List<ExampleResult> DareEarl;
        public List<ExampleResult> DareEARLLog;
        public List<ExampleResult> DareEARLLogNew;
        public void DoCommandsDare() {

            DarePlaintext = testCLIAlice1.Example($"dare encode {TestFile1}");
            DareSymmetric = testCLIAlice1.Example($"dare encode {TestFile1} /out={TestFile1}.symmetric.dare " +
                        $"/key={Secret1}");
            DareSub = testCLIAlice1.Example($"dare encode {TestDir1} /encrypt={Secret1}");
            DareMesh = testCLIAlice1.Example($"dare encode {TestFile1} /out={TestFile1}.mesh.dare" +
                        $"/encrypt={BobService} /sign={AliceService1}");

            DareVerifyDigest = testCLIAlice1.Example($"dare verify {TestFile1}.dare");
            DareVerifySigned = testCLIAlice1.Example($"dare verify {TestFile1}.mesh.dare");
            DareVerifySymmetricUnknown = testCLIAlice1.Example($"dare verify {TestFile1}.symmetric.dare");
            DareVerifySymmetric = testCLIAlice1.Example($"dare verify {TestFile1}.symmetric.dare /encrypt={Secret1}");

            DareDecodePlaintext = testCLIAlice1.Example($"dare decode {TestFile1}.dare");
            DareDecodeSymmetric = testCLIAlice1.Example($"dare decode {TestFile1}.symmetric.dare /encrypt={Secret1}");
            DareDecodePrivate = testCLIAlice1.Example($"dare decode {TestFile1}.mesh.dare");

            DareEarl = testCLIAlice1.Example($"dare earl {TestFile1}");
            DareEARLLog = testCLIAlice1.Example($"dare container create {DareLogEarl} /encrypt={AliceService1}",
                                                    $"dare earl {TestFile1} /log={DareLogEarl}");
            DareEARLLogNew = testCLIAlice1.Example($"dare earl {TestFile1} /new={DareLogEarl}");
            }

        public List<ExampleResult> ContainerCreate;
        public List<ExampleResult> ContainerCreateEncrypt;
        public List<ExampleResult> ContainerArchive;
        public List<ExampleResult> ContainerArchiveEnhance;
        public List<ExampleResult> ContainerArchiveVerify;
        public List<ExampleResult> ContainerArchiveExtractAll;
        public List<ExampleResult> ContainerArchiveExtractFile;

        public List<ExampleResult> ContainerAppend;
        public List<ExampleResult> ContainerDelete;
        public List<ExampleResult> ContainerIndex;
        public List<ExampleResult> ContainerArchiveCopy;
        public List<ExampleResult> ContainerArchiveCopyDecrypt;
        public List<ExampleResult> ContainerArchiveCopyPurge;

        public void DoCommandsContainer() {
            ContainerCreate = testCLIAlice1.Example($"container create {TestContainer}");
            ContainerCreateEncrypt = testCLIAlice1.Example($"container create {TestContainerEncrypt} /encrypt={GroupService}");
            ContainerArchive = testCLIAlice1.Example($"container archive {TestContainerArchive} {TestDir1}");
            ContainerArchiveEnhance = testCLIAlice1.Example($"container create {TestContainerArchiveEnhance} {TestDir1}",
                                                            $"/encrypt={GroupService} /sign={AliceService1}");
            ContainerArchiveVerify = testCLIAlice1.Example($"container verify {TestContainerArchiveEnhance}");
            ContainerArchiveExtractAll = testCLIAlice1.Example($"container extract {TestContainer} {TestDir2}");
            ContainerArchiveExtractFile = testCLIAlice1.Example($"container extract {TestContainer} /file={TestFile4}");
            ContainerAppend = testCLIAlice1.Example($"container append {TestContainer} {TestFile1}" +
                                                            $"container append {TestContainer} {TestFile2}" +
                                                            $"container append {TestContainer} {TestFile3}");
            ContainerDelete = testCLIAlice1.Example($"container delete {TestContainer}  {TestFile2}");
            ContainerIndex = testCLIAlice1.Example($"container index {TestContainer}");
            ContainerArchiveCopy = testCLIAlice1.Example($"container copy {TestContainer2}");
            ContainerArchiveCopyDecrypt = testCLIAlice1.Example($"container copy {TestContainerArchiveEnhance} /decrypt");
            ContainerArchiveCopyPurge = testCLIAlice1.Example($"container copy {TestContainer2} /purge");

            }

        #endregion
        }
    }
