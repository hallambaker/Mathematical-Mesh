using System;

using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Numerics;
using Goedel.Mesh;
using Goedel.Utilities;
using Goedel.Protocol.Debug;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;

using Goedel.IO;
using Goedel.Command;
using Goedel.Cryptography.Algorithms;
using Goedel.Test;
using Goedel.Cryptography.Core;
using Goedel.Test.Core;

namespace ExampleGenerator {

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

        public DareMessage GetDAREMessage(CryptoParameters CryptoParameters) {
            var Data = new List<byte[]>() {
                MakeData("From", From),MakeData("To", To),MakeData("Subject", Subject)
                };
            return new DareMessage(CryptoParameters, Body.ToUTF8(),
                contentType: "application/example-mail", dataSequences: Data);
            }


        byte[] MakeData(string Tag, string Data) => $"{Tag}: {Data}".ToUTF8();
           
        }




    public partial class CreateExamples {

        public bool GitHub = true;
        public string Preformat => GitHub ? "````" : "~~~~" ;


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



        public DareMessage DAREMessageAtomic;
        public DareMessage DAREMessageAtomicSign;
        public DareMessage DAREMessageAtomicSignEncrypt;
        public DareMessage MessageAtomicDS;
        public DareMessage MessageEnc;
        public DareMessage MessageAtomicDSEnc;


        public byte[] DareMessageBody;


        public string ContainerFramingEncrypted = "";
        public string ContainerFramingEncryptedIndependent;
        byte[] TestData300 = TestData(300);

        public string AccountAlice = "alice@example.com";


        public CryptoParameters CryptoParametersPlaintext;
        public CryptoParameters CryptoParametersEncrypt;
        public CryptoParameters CryptoParametersSign;
        public CryptoParameters CryptoParametersSignEncrypt;

        public CryptoStackDebug CryptoStackEncrypt;

        KeyCollection KeyCollection;

        List<byte[]> DataSequences;

        public MailMessage MailMessage;
        public string MailMessageAsRFC822;
        public DareMessage MailMessageAsDAREPlaintext;
        public DareMessage MailMessageAsDAREEncrypted;

        public string EDSText;


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


            KeyCollection = new KeyCollectionTest(Machine1);
            KeyCollection.Add(DareMessageAlicePrivateKeyPair);
            KeyCollection.Add(SignatureAliceKeyPair);

            // Initialize the crypto parameters.

            var Accounts = new List<string> { AccountAlice };
            CryptoParametersPlaintext = new CryptoParameters(
                        keyCollection: KeyCollection);

            CryptoParametersEncrypt = new CryptoParameters(
                        keyCollection: KeyCollection,
                        recipients: Accounts);

            CryptoParametersSign = new CryptoParameters(
                        keyCollection: KeyCollection,
                        signers: Accounts);

            CryptoParametersSignEncrypt = new CryptoParameters(
                        keyCollection: KeyCollection,
                        recipients: Accounts,
                        signers: Accounts);

            CryptoStackEncrypt = new CryptoStackDebug(CryptoParametersEncrypt);


            // Data Sequences
            DataSequences = new List<byte[]> { DareMessageTest2, DareMessageTest3 };

            // Dummy Mail Message
            MailMessage = new MailMessage();
            MailMessageAsRFC822 = MailMessage.GetRFC822();
            MailMessageAsDAREPlaintext = MailMessage.GetDAREMessage(CryptoParametersPlaintext);
            MailMessageAsDAREEncrypted = MailMessage.GetDAREMessage(CryptoParametersEncrypt);

            var EDS1 = MailMessageAsDAREPlaintext.Header.EDSS[0];
            EDSText = ReadEDS(EDS1);

            }


        byte[] ReadBinary(JBCDStream JBCDStream) {
            JBCDStream.ReadTag(out var Code, out var Length);
            var Result = new byte[Length];
            JBCDStream.Read(Result, 0, (int)Length);
            return Result;
            }

        string ReadEDS(byte[] Data) {
            var TextWriter = new StringWriter();

            using (var Input = new MemoryStream(Data)) {
                using (var JBCDStream = new JBCDStreamDebug(Input, TextWriter)) {

                    var Salt = ReadBinary(JBCDStream);
                    var Body = ReadBinary(JBCDStream);
                    var Tag = ReadBinary(JBCDStream);
                    }
                }


            return TextWriter.ToString();
            }


        void GoDareMessage() {

            // Plaintext atomic
            DAREMessageAtomic = new DareMessage(CryptoParametersPlaintext, DareMessageTest1);

            // Plaintext atomic EDS
            MessageAtomicDS = new DareMessage(CryptoParametersPlaintext, DareMessageTest1, dataSequences: DataSequences);

            DAREMessageAtomicSign = new DareMessage(CryptoParametersSign, DareMessageTest1);
            DAREMessageAtomicSignEncrypt = new DareMessage(CryptoParametersSignEncrypt, DareMessageTest1);


            CryptoStackEncrypt = new CryptoStackDebug(CryptoParametersEncrypt);
            MessageEnc = new DareMessage(CryptoStackEncrypt, DareMessageTest1);

            //CryptoStackEncrypt.Message(DareMessageTest1);

            //ExampleGenerator.MeshExamplesMessage(this);
            }

        void GoDareContainer() {
            // Encrypt a set of data under one key exchange.
            var EncryptingContainer = MakeContainer("Test1Enc", CryptoParametersEncrypt, ContainerType.List);
            EncryptingContainer.Append(TestData300);
            EncryptingContainer.Append(TestData300);
            ContainerHeadersEncryptSingleSession = ReadContainer(EncryptingContainer);
            ContainerFramingEncrypted = ConsoleWriter.ToString();


            // Encrypt a sequence of items with a key exchange per item.
            var EncryptedContainer = MakeContainer("Test1EncSep", CryptoParametersPlaintext, ContainerType.List);
            EncryptedContainer.Append(TestData300, cryptoParameters: CryptoParametersEncrypt);
            EncryptedContainer.Append(TestData300, cryptoParameters: CryptoParametersEncrypt);
            ContainerHeadersEncryptIndependentSession = ReadContainer(EncryptedContainer);
            ContainerFramingEncryptedIndependent = ConsoleWriter.ToString();
            }

        //public string ContainerFramingEncrypted;
        public List<ContainerFrame> ContainerHeadersEncryptSingleSession;
        public List<ContainerFrame> ContainerHeadersEncryptIndependentSession;

        public byte[] Enhance(
                    byte[] MasterSecret,
                    byte[] Plaintext,
                    byte[] Salt = null) {

            Salt = Salt ?? Goedel.Cryptography.Platform.GetRandomBits(128);
            var CryptoStack = new CryptoStack(EncryptID: CryptoAlgorithmID.AES256CBC) {
                Salt = Salt ?? Goedel.Cryptography.Platform.GetRandomBits(128),
                MasterSecret = MasterSecret
                };
            return CryptoStack.EncodeEDS(Plaintext, null);
            }


        public string ContainerFramingSimple = "";
        StringWriter ConsoleWriter;

        public List<ContainerFrame> ContainerHeadersSimple;
        public List<ContainerFrame> ContainerHeadersChain;
        public List<ContainerFrame> ContainerHeadersTree;
        public List<ContainerFrame> ContainerHeadersMerkleTree;
        public List<ContainerFrame> ContainerHeadersSigned;




        void GoContainer() {
            var CryptoParametersPlaintext = new Goedel.Test.CryptoParametersTest();

            // Simple
            var TContainer = MakeContainer("Test1List", CryptoParametersPlaintext, ContainerType.List);
            TContainer.Append(TestData300);
            ContainerHeadersSimple = ReadContainer(TContainer);
            ContainerFramingSimple = ConsoleWriter.ToString();


            // Digest
            TContainer = MakeContainer("Test1Chain", CryptoParametersPlaintext, ContainerType.Chain);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            ContainerHeadersChain = ReadContainer(TContainer);


            // Tree
            TContainer = MakeContainer("Test1Tree", CryptoParametersPlaintext, ContainerType.Tree);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            ContainerHeadersTree = ReadContainer(TContainer);


            // Merkle Tree
            TContainer = MakeContainer("Test1Merkle", CryptoParametersPlaintext, ContainerType.MerkleTree);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            ContainerHeadersMerkleTree = ReadContainer(TContainer);


            TContainer = MakeContainer("Test1Sign", CryptoParametersPlaintext, ContainerType.MerkleTree);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300, CryptoParametersSign);
            ContainerHeadersSigned = ReadContainer(TContainer);



            //ExampleGenerator.MeshExamplesContainer(this);
            //ExampleGenerator.MeshExamplesUDFCompressed(this);
            }

        //KeyExchangeClient KeyExchangeClient;
        //KeyExchangePortalTraced KeyExchangePortalTraced;

        public TraceDictionary KeyExchangeTraces;
        public Key ClientDHIdentity;
        public string TraceDH = "DiffieHellman";

        //AdvancedRecovery
        public byte[] AdvancedRecoveryMaster;
        public int AdvancedRecoveryThreshold = 3;
        public int AdvancedRecoveryCount = 5;
        public BigInteger[] AdvancedRecoveryPolynomial;
        public KeyShare[] AdvancedRecoveryShares;
        public BigInteger[] AdvancedRecoveryShareValues;
        public byte[][] AdvancedRecoverySharesHex;
        public string[] AdvancedRecoveryBase32;

        //AdvancedCogen
        public ProfileDevice AdvancedCogenDeviceProfile;
        public byte[] AdvancedCogenPrivateKeySeed;
        public PrivateKeyECDH AdvancedCogenPrivateKeyValue;
        public PublicKeyECDH AdvancedCogenCompositeKey;
        public DareMessage AdvancedCogenPrivateKeySeedEncrypted;


        //AdvancedRecryption
        public string AdvancedRecryptionGroupID = "recrypt@example.com";
        public ProfileMaster AdvancedRecryptionGroup;
        public string AdvancedRecryptionMessagePlaintext;
        public DareMessage AdvancedRecryptionMessageEncrypted;
        public Assertion AdvancedRecryptionBobProfile;
        public Key AdvancedRecryptionBobDecryptionKey;
        public Key AdvancedRecryptionBobRecryptionKey;
        public Key AdvancedRecryptionBobRecryptionEntry;
        public Object AdvancedRecryptionRecryptionAddMemberRequest;
        public Object AdvancedRecryptionRecryptionRecryptionRequest;
        public Object AdvancedRecryptionRecryptionRecryptionResponse;
        public Object AdvancedRecryptionDecryptionValue;
        public Object AdvancedRecryptionKeyAgreementValue;

        //AdvancedQuantum
        public byte[] AdvancedQuantumMasterSecret;
        public string[] AdvancedQuantumShares;
        public byte[][] AdvancedQuantumPrivate;
        public byte[] AdvancedQuantumPublic;
        public string AdvancedQuantumPublicUDF;

        void GoAdvanced() {

            //// AdvancedRecovery 
            //var AdvancedRecoveryMaster = CryptoCatalog.GetBits(128);
            var Secret = new Secret(AdvancedRecoveryMaster);
            //var AdvancedRecoveryShares = Secret.Split(AdvancedRecoveryThreshold,
            //        AdvancedRecoveryCount, out AdvancedRecoveryPolynomial);
            //AdvancedRecoveryShareValues = new BigInteger[AdvancedRecoveryCount];
            //AdvancedRecoverySharesHex = new byte[AdvancedRecoveryCount][];
            //AdvancedRecoveryBase32 = new string[AdvancedRecoveryCount];

            //for (var i = 0; i < AdvancedRecoveryCount; i++) {
            //    AdvancedRecoveryShareValues[i] = AdvancedRecoveryShares[i].Value;
            //    AdvancedRecoverySharesHex[i] = AdvancedRecoveryShares[i].Key;
            //    AdvancedRecoveryBase32[i] = AdvancedRecoveryShares[i].UDFKey;
            //    }

            // AdvancedCogen
            //AdvancedCogenDeviceProfile = new DeviceProfile(
            //            "AliceWatch", "A wearable watch computer",
            //            CryptoAlgorithmID.Ed25519,
            //            CryptoAlgorithmID.XEd25519);


            //var AdvancedCogenDeviceSignPublic =
            //    (PublicKeyECDH)null; //AdvancedCogenDeviceProfile.DeviceSignatureKey.PublicParameters;
            //var AdvancedCogenDeviceSignPrivate =
            //    (PrivateKeyECDH)null; //AdvancedCogenDeviceProfile.DeviceSignatureKey.PrivateParameters;

            //AdvancedCogenPrivateKeySeed = CryptoCatalog.GetBits(128);
            //var CogenPrivateKeyValue = new PrivateKeyECDH(AdvancedCogenPrivateKeySeed, true);

            //AdvancedCogenPrivateKeyValue = AdvancedCogenDeviceSignPrivate.CombinePrivate(CogenPrivateKeyValue);
            //AdvancedCogenCompositeKey = AdvancedCogenDeviceSignPublic.CombinePublic(CogenPrivateKeyValue);

            //AdvancedCogenPrivateKeySeedEncrypted = AdvancedCogenDeviceProfile.DareEncrypt(AdvancedCogenPrivateKeyValue);


            //AdvancedRecryption
            //var AliceProfile = MakeProfile("", out var AliceKeyCollection);
            //var BobProfile = MakeProfile("", out var BobKeyCollection);

            //AddMessage(AliceProfile);
            //AddMessage(BobProfile);

            //var RecryptionGroup = new RecryptionGroup ("recrypt@example.com");
            //RecryptionGroup.AddAdmin(AliceProfile);
            //RecryptionGroup.AddMember(BobProfile);

            //AdvancedRecryptionMessagePlaintext = $"Welcome to the group {AdvancedRecryptionGroupID}";
            //AdvancedRecryptionMessageEncrypted = RecryptionGroup.Encrypt(AdvancedRecryptionMessagePlaintext);

            //BobKeyCollection.Decrypt(AdvancedRecryptionMessageEncrypted);


            //public ApplicationProfile AdvancedRecryptionGroup;
            //public string AdvancedRecryptionMessagePlaintext;
            //public DAREMessage AdvancedRecryptionMessageEncrypted;
            //public ApplicationProfile AdvancedRecryptionBobProfile;
            //public Key AdvancedRecryptionBobDecryptionKey;
            //public Key AdvancedRecryptionBobRecryptionKey;
            //public Key AdvancedRecryptionBobRecryptionEntry;
            //public Object AdvancedRecryptionRecryptionAddMemberRequest;
            //public Object AdvancedRecryptionRecryptionRecryptionRequest;
            //public Object AdvancedRecryptionRecryptionRecryptionResponse;
            //public Object AdvancedRecryptionDecryptionValue;
            //public Object AdvancedRecryptionKeyAgreementValue;





            // AdvancedQuantum

            //var XMSS = new XMSS();
            //AdvancedQuantumMasterSecret = XMSS.MasterSecret;
            //var AdvancedQuantumKeyShares = Secret.Split(AdvancedRecoveryThreshold,
            //        AdvancedRecoveryCount, out AdvancedRecoveryPolynomial);
            //AdvancedQuantumShares = new string[AdvancedRecoveryCount];
            //for (var i = 0; i < AdvancedRecoveryCount; i++) {
            //    AdvancedQuantumShares[i] = AdvancedQuantumKeyShares[i].UDFKey;
            //    }


            //AdvancedQuantumPrivate = XMSS.Private;
            //AdvancedQuantumPublic = XMSS.Public;
            //AdvancedQuantumPublicUDF = XMSS.UDF;

            }








        public Container MakeContainer (
                    string FileName,
                    CryptoParameters CryptoParameters, 
                    ContainerType ContainerType = ContainerType.Chain) {
            ConsoleWriter = new StringWriter();

            //var FileStream = FileName.FileStream(FileStatus.Overwrite);
            var JBCDStream = new JBCDStreamDebug(FileName, FileStatus.Overwrite, Output:ConsoleWriter);
            return Container.NewContainer(JBCDStream, CryptoParameters, ContainerType);

            }



        public static byte[] TestData (int MaxSize) {
            var Data = new byte[MaxSize];
            for (var i = 0; i < MaxSize; i++) {
                Data[i] = (byte)(i & 0xff);
                }
            return Data;
            }


        public List<ContainerFrame>  ReadContainer (Container Container) {
            var ContainerHeaders = new List<ContainerFrame> {
                new ContainerFrame {
                    Header = Container.ContainerHeaderFirst
                    }
                };
            //Console.WriteLine($"First Frame {Container.ContainerHeader}");
            foreach (var ContainerDataReader in Container) {
                var Trailer = (ContainerDataReader as ContainerFrameReader).GetTrailer();

                ContainerHeaders.Add(new ContainerFrame {
                    Header = ContainerDataReader.Header,
                    Trailer = Trailer
                    });
                //Console.WriteLine($"Read Frame {ContainerDataReader.Header}");
                }
            return ContainerHeaders;
            }



        //public static string NameAccount = "alice";
        //public static string NameService = "example.com";


        //public static string Device1Name = "AliceDesktop";
        //public static string Device1Description = "A desktop computer built by Acme Computer Co.";

        //public static string Device2Name = "AliceRing";
        //public static string Device2Description = "A wearable ring computer";

        //public static string Device3Name = "AliceLaptop";
        //public static string Device3Description = "A laptop computer";



        //public string Device1(string Command) => Device1(Command, out var _);
        //public string Device1(string Command, out string Tag) {
        //    Tag = Label(Command);
        //    throw new NYI();

        //    }


        //public string Device2(string Command, out string Tag) {
        //    Tag = Label(Command);
        //    throw new NYI();
        //    //return Shell2.Dispatch(Command);
        //    }

        ////public Shell Shell3 = new Shell() {
        ////    MeshMachine = new MeshMachineCached(),
        ////    DefaultDescription = Device3Description
        ////    };
        //public string Device3(string Command, out string Tag) {
        //    Tag = Label(Command);
        //    throw new NYI();
        //    //return Shell3.Dispatch(Command);
        //    }

        ////static int Count = 0;
        //string Label(string Command) => throw new NYI();
        //    //var Tag = Count++.ToString();
        //    //Portal.Label(Tag);
        //    //Portal.Traces.Current.Command = Command;
        //    //return Tag;


        //public string LabelValidate;
        //public string LabelCreatePersonal;
        //public string CommandValidate;

        ///// <summary>
        ///// Create a new profile for alice@example.com
        ///// </summary>
        //void CreateProfile() {
        //    Device1("keygen");


        //    // check that the name is available
        //    Device1("verify test@prismproof.org", out LabelValidate);

        //    // create the profile
        //    Device1("personal create test@prismproof.org \\id=" + Device1Name, out LabelCreatePersonal);
        //    }


        //public string LabelConnectRequest;
        //public string LabelConnectPending;
        //public string LabelConnectAccept;
        //public string LabelConnectComplete;
        ///// <summary>
        ///// Add a second device
        ///// </summary>
        //void ConnectDevice() {

        //    // Connect the second device
        //    Device2("connect start test@prismproof.org", out LabelConnectRequest);
        //    //var Authenticator = (Shell2.LastResult as ResultConnectStart).Authenticator;

        //    Device1("connect pending", out LabelConnectPending);
        //    //Device1("connect accept " + Authenticator, out LabelConnectAccept);
        //    Device2("connect Complete", out LabelConnectComplete);
        //    }

        
        //public string LabelApplicationWeb1;
        //public string LabelApplicationWeb2;
        //public string LabelApplicationWeb3;
        //public string LabelApplicationWeb4;
        //public string LabelApplicationWeb5;


        //public string LabelApplicationProfile;


        ////SSHProfile SSHProfile;

        ///// <summary>
        ///// Create a SSH credential profile.
        ///// </summary>
        //void AddApplicationSSH() {
        //    Device1("keygen"); // Generate a password for the later pieces 

        //    Device1("ssh create");

        //    Device1("ssh public ");
        //    Device1("ssh private");

        //    Device1("ssh known");
        //    Device1("ssh add ssh1.example.com rsa AAAA1234");
        //    Device1("ssh known");

        //    }

        ///// <summary>
        ///// Create a SSH credential profile.
        ///// </summary>
        //void AddApplicationMail() => throw new NYI();



        //public string LabelEscrow = "Publish escrow";
        //public string LabelRecover = "Recover";



        }
    }
