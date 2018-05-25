using System;

using System.Collections.Generic;
using System.IO;
using System.Numerics;
using Goedel.Mesh;
using Goedel.Utilities;
using Goedel.Protocol.Debug;
using Goedel.Mesh.MeshMan;
using Goedel.Mesh.Portal;
using Goedel.Mesh.Portal.Server;
using Goedel.Mesh.Portal.Client;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;
using Goedel.Protocol.Exchange;
using Goedel.Protocol.Exchange.Server;
using Goedel.IO;
using Goedel.Command;
using Goedel.Cryptography.Algorithms;

namespace ExampleGenerator {

    public partial class DAREHeaderDebug : DAREHeader {

        byte[] MasterSecret;
        ///// <summary>
        ///// The authentication algorithm
        ///// </summary>
        //public CryptoAlgorithmID AuthenticateID;

        public DAREHeaderDebug (byte[] MasterSecret,
                    CryptoAlgorithmID EncryptID = CryptoAlgorithmID.Default,
                    CryptoAlgorithmID AuthenticateID = CryptoAlgorithmID.Default) {
            this.MasterSecret = MasterSecret;
            ProviderEncryption = CryptoCatalog.Default.GetEncryption(EncryptID);

            }
        }

    public partial class EnhancedDataSequenceWriterDebug : EnhancedDataSequenceWriter {

        /// <summary>
        /// Create a buffered writer for an Enhanced Data Sequence
        /// </summary>
        /// <param name="MasterSecret"></param>
        /// <param name="ProviderEncrypt">Crypto algorithm provider</param>
        /// <param name="Salt"></param>
        /// <param name="Plaintext"></param>
        /// <param name="OutputStream">The output stream</param>
        /// <param name="ContentLength">The content length. If this value is 0 or greater, the 
        /// PayloadLength property will be set to the value of the payload data length field. </param>
        public EnhancedDataSequenceWriterDebug (
                    JSONWriter OutputStream,
                    byte[] MasterSecret,
                    CryptoProviderEncryption ProviderEncrypt = null,
                    byte[] Salt = null,
                    byte[] Plaintext = null,
                    long ContentLength = -1
                    ) : base(OutputStream, MasterSecret, ProviderEncrypt, Salt, Plaintext, ContentLength) {
            }

        public byte[] RevealKeyEncrypt => KeyEncrypt;
        public byte[] RevealKeyKeyMac => KeyMac;
        public byte[] RevealKeyIV => IV;


        /// <summary>
        /// Enhance the specified plaintext data under the specified Master Secret and Sale (if specified).
        /// </summary>
        /// <param name="MasterSecret">The Master Secret from which the necessary cryptographic parameters 
        /// are generated.</param>
        /// <param name="ProviderEncrypt">Crypto algorithm provider</param>
        /// <param name="Plaintext">The input</param>
        /// <param name="Salt"></param>
        /// <returns>The result of applying the enhancement.</returns>
        public static byte[] Enhance (
                    byte[] MasterSecret,
                    byte[] Plaintext,
                    out byte[] KeyEncrypt,
                    out byte[] KeyMac,
                    out byte[] IV,
                    byte[] Salt = null,
                    CryptoProviderEncryption ProviderEncrypt = null
                    ) {
            var Output = new MemoryStream();
            var JSONBWriter = new JSONBWriter(Output);
            var EDS = new EnhancedDataSequenceWriterDebug(
                        JSONBWriter, MasterSecret, ProviderEncrypt, Salt, Plaintext);
            KeyEncrypt = EDS.RevealKeyEncrypt;
            KeyMac = EDS.KeyMac;
            IV = EDS.RevealKeyIV;

            return Output.ToArray();
            }

        }

    public partial class CreateExamples {

        public byte[] MessagePlaintext = "This is a sample Plaintext".ToBytes();

        public string MessageTestPlaintext              = "TBS";
        public string MessageTestRSAMAC                 = "TBS";
        public string MessageTestRSAEncrypted           = "TBS";
        public string MessageTestRSAEncryptedMAC        = "TBS";
        public string MessageTestRSASigned              = "TBS";
        public string MessageTestRSAEncryptedSigned     = "TBS";

        public readonly byte[] DareMessageTest1 = "This is a test long enough to require multiple blocks".ToUTF8();
        public readonly byte[] DareMessageTest2 = "Subject: Message metadata should be encrypted".ToUTF8();
        public readonly byte[] DareMessageTest3 = "2018-02-01".ToUTF8();
        public DiffeHellmanPrivate DareMessageAlicePrivate;
        public DiffeHellmanPublic DareMessageAlicePublic;
        
        public KeyPairDH DareMessageAliceKeypair;
        public Key DareMessageAliceKey;

        public DAREMessage DAREMessageAtomic;
        public DAREMessage MessageAtomicDS;
        public DAREMessage MessageEnc;
        public DAREMessage MessageAtomicDSEnc;

        public byte[] MasterSecret;
        public byte[] DareMessageBody;
        public byte[] DareEDSSalt;

        public string ContainerFramingEncrypted = "";
        public string ContainerFramingEncryptedIndependent;
        byte[] TestData300 = TestData(300);

        void GoDareMessage () {
            DareMessageAlicePrivate = new DiffeHellmanPrivate();
            var DareMessageAlicePrivateKeyPair = new KeyPairDH(DareMessageAlicePrivate, KeySecurity: KeySecurity.Exportable);
            DareMessageAliceKey = Key.GetPrivate(DareMessageAlicePrivateKeyPair);

            DareMessageAlicePublic = DareMessageAlicePrivate.DiffeHellmanPublic;
            DareMessageAliceKeypair = new KeyPairDH(DareMessageAlicePublic);
            var EncryptionKeys = new List<KeyPair> { DareMessageAliceKeypair };

            var DataSequences = new List<byte[]> { DareMessageTest2, DareMessageTest3 };

            // Plaintext atomic
            DAREMessageAtomic = new DAREMessage(DareMessageTest1);

            // Plaintext atomic EDS
            MessageAtomicDS = new DAREMessage(DareMessageTest1, DataSequences: DataSequences);


            //var Header = new DAREHeader(EncryptionKeys, ContentLength: -1, DataSequences: DataSequences);

            MasterSecret = Platform.GetRandomBits(256);
            var Header = new DAREHeaderDebug(MasterSecret);
            var KeyBits = Header.EncryptionKeySize;

            var Recipients = new List<DARERecipient>() {
                    MakeRecipient(MasterSecret, DareMessageAliceKeypair)
                    };
            Header.Recipients = Recipients;


            DareEDSSalt = new byte[] { 1 };
            var ProviderEncryption = CryptoCatalog.Default.GetEncryption(CryptoAlgorithmID.AES256CBC);
            DareMessageBody = Enhance(MasterSecret, DareMessageTest1, DareEDSSalt, ProviderEncryption);

            MessageAtomicDSEnc = new DAREMessage() { Header = Header, Body = DareMessageBody };


            //// Plaintext atomic
            //MessageEnc = new DAREMessage(DareMessageTest1, EncryptionKeys: EncryptionKeys);

            //// Plaintext atomic EDS
            //MessageAtomicDSEnc = new DAREMessage(DareMessageTest1, EncryptionKeys: EncryptionKeys, DataSequences: DataSequences);

            ExampleGenerator.MeshExamplesMessage(this);


            var EncryptingContainer = MakeContainer("Test1Enc", ContainerType.List, EncryptionKeys);
            EncryptingContainer.Append(TestData300);
            EncryptingContainer.Append(TestData300);
            ReadContainer(EncryptingContainer, ContainerHeadersEncryptSingleSession);
            ContainerFramingEncrypted = ConsoleWriter.ToString();

            var EncryptedContainer = MakeContainer("Test1EncSep", ContainerType.List);
            EncryptedContainer.Append(TestData300, EncryptionKeys);
            EncryptedContainer.Append(TestData300, EncryptionKeys);
            ReadContainer(EncryptedContainer, ContainerHeadersEncryptIndependentSession);
            ContainerFramingEncryptedIndependent = ConsoleWriter.ToString();
            }

        //public string ContainerFramingEncrypted;
        public List<ContainerHeader> ContainerHeadersEncryptSingleSession = new List<ContainerHeader>();
        public List<ContainerHeader> ContainerHeadersEncryptIndependentSession = new List<ContainerHeader>();

        public byte[] DareMessageKeyEncrypt;
        byte[] DareMessageKeyMac;
        byte[] DareMessageKeyIV;

        /// <summary>
        /// Enhance the specified plaintext data under the specified Master Secret and Sale (if specified).
        /// </summary>
        /// <param name="MasterSecret">The Master Secret from which the necessary cryptographic parameters 
        /// are generated.</param>
        /// <param name="ProviderEncrypt">Crypto algorithm provider</param>
        /// <param name="Plaintext">The input</param>
        /// <param name="Salt"></param>
        /// <returns>The result of applying the enhancement.</returns>
        public byte[] Enhance (
                    byte[] MasterSecret,
                    byte[] Plaintext,
                    byte[] Salt = null,
                    CryptoProviderEncryption ProviderEncrypt = null
                    ) {
            var Output = new MemoryStream();
            var JSONBWriter = new JSONBWriter(Output);
            return EnhancedDataSequenceWriterDebug.Enhance(MasterSecret, Plaintext,
                out DareMessageKeyEncrypt, out DareMessageKeyMac, out DareMessageKeyIV, Salt, ProviderEncrypt);
            }


        static readonly byte[] MasterKeyInfo = "master".ToUTF8();

        public Key EphemeralPrivateKey;
        public BigInteger DareEncryptAgreement;
        public KeyDerive DareEncrypt;
        public byte[] DareEncrypEncryptionKey;

        DARERecipient MakeRecipient (byte[] MasterKey, KeyPairDH PublicKey) {

            //ExchangeProvider.Encrypt(MasterKey, out var Exchange, out var Ephemeral);

            //var ExchangeProvider = new CryptoProviderExchangeDH(PublicKey);

            var EphemeralPrivate = new DiffeHellmanPrivate(PublicKey.DHDomain);
            EphemeralPrivateKey = Key.GetPrivate(new KeyPairDH(EphemeralPrivate, KeySecurity: KeySecurity.Exportable));

            var EphemeralPublic = EphemeralPrivate.DiffeHellmanPublic;

            DareEncryptAgreement = EphemeralPrivate.Agreement(PublicKey.PublicKey);

            var Result = new DiffieHellmanResult() {
                DiffeHellmanPublic = EphemeralPublic,
                Agreement = DareEncryptAgreement
                };

            var DareEncryptKeyDerive = Result.KeyDerive;
            DareEncrypEncryptionKey = DareEncryptKeyDerive.Derive(MasterKeyInfo, Length: 256);
            var Exchange = Platform.KeyWrapRFC3394.Wrap(DareEncrypEncryptionKey, MasterKey);


            var JoseKey = Key.GetPublic(new KeyPairDH(EphemeralPublic));

            return new DARERecipient() {
                KeyIdentifier = PublicKey.UDF,
                Epk = JoseKey,
                WrappedMasterKey = Exchange
                };
            }

        ///// <summary>
        ///// Encrypt the bulk key.
        ///// </summary>
        ///// <returns>The encoder</returns>
        //public override void Encrypt (byte[] Key,
        //    out byte[] Exchange, out KeyPair Ephemeral) {

        //    var Agreement = DHKeyPair.Agreement();
        //    var KeyDerive = Agreement.KeyDerive;

        //    // Need to do some form of key derrivation here.

        //    var EncryptionKey = KeyDerive.Derive(MasterKeyInfo, Length: 256);

        //    Exchange = Platform.KeyWrapRFC3394.Wrap(EncryptionKey, Key);
        //    Ephemeral = new KeyPairDH(Agreement.DiffeHellmanPublic);
        //    }

        ///// <summary>
        ///// Create a new ephemeral private key and use it to perform a key
        ///// agreement.
        ///// </summary>
        ///// <returns>The key agreement parameters, the public key value and the
        ///// key agreement.</returns>
        //public DiffieHellmanResult Agreement () {
        //    var Private = new DiffeHellmanPrivate(this);
        //    var DiffeHellmanPublic = Private.DiffeHellmanPublic;

        //    var Result = new DiffieHellmanResult() {
        //        DiffeHellmanPublic = DiffeHellmanPublic,
        //        Agreement = Private.Agreement(this)
        //        };

        //    return Result;
        //    }

        public string ContainerFramingSimple = "";
        StringWriter ConsoleWriter ;

        public List<ContainerHeader> ContainerHeadersSimple = new List<ContainerHeader>();
        public List<ContainerHeader> ContainerHeadersChain = new List<ContainerHeader>();
        public List<ContainerHeader> ContainerHeadersTree = new List<ContainerHeader>();
        public List<ContainerHeader> ContainerHeadersMerkleTree = new List<ContainerHeader>();


        


        void GoContainer () {
            // Simple
            var TContainer = MakeContainer("Test1List", ContainerType.List);
            TContainer.Append(TestData300);
            ReadContainer(TContainer, ContainerHeadersSimple);
            ContainerFramingSimple = ConsoleWriter.ToString();


            // Digest
            TContainer = MakeContainer("Test1Chain", ContainerType.Chain);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            ReadContainer(TContainer, ContainerHeadersChain);


            // Tree
            TContainer = MakeContainer("Test1Tree", ContainerType.Tree);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            ReadContainer(TContainer, ContainerHeadersTree);


            // Merkle Tree
            TContainer = MakeContainer("Test1Merkle", ContainerType.MerkleTree);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            TContainer.Append(TestData300);
            ReadContainer(TContainer, ContainerHeadersMerkleTree);


            ExampleGenerator.MeshExamplesContainer(this);

            ExampleGenerator.MeshExamplesUDF(this);
            ExampleGenerator.MeshExamplesUDFCompressed(this);
            //ExampleGenerator.MakeExamplesKeyExchange(this);
            }

        KeyExchangeClient KeyExchangeClient;
        KeyExchangePortalTraced KeyExchangePortalTraced;

        public TraceDictionary KeyExchangeTraces;
        public Key ClientDHIdentity;
        public string TraceDH = "DiffieHellman";

        void GoKeyExchange () {

            Message.Append(Message._TagDictionary, ExchangeMessage._TagDictionary);
            KeyExchangePortalTraced = new KeyExchangePortalTraced(NameService);
            KeyExchangePortal.Default = KeyExchangePortalTraced;

            KeyExchangeClient = new KeyExchangeClient(AccountID);

            KeyExchangeTraces = KeyExchangePortalTraced.Traces;
            KeyExchangeTraces.Label(TraceDH);

            var DHProvider = CryptoCatalog.Default.GetRecryption(CryptoAlgorithmID.DH);
            DHProvider.Generate(KeySecurity.Exportable, 2048);

            var ClientIdentity = DHProvider.KeyPair;


            var Ticket = KeyExchangeClient.GetTicket(DHProvider);
            }


        public Container MakeContainer (
                    string FileName, 
                    ContainerType ContainerType = ContainerType.Chain,
                    List<KeyPair> EncryptionKeys=null) {
            ConsoleWriter = new StringWriter();

            //var FileStream = FileName.FileStream(FileStatus.Overwrite);
            var JBCDStream = new JBCDStreamDebug(FileName, FileStatus.Overwrite, Output:ConsoleWriter);
            return Container.NewContainer(JBCDStream, ContainerType, EncryptionKeys:EncryptionKeys);

            }



        public static byte[] TestData (int MaxSize) {
            var Data = new byte[MaxSize];
            for (var i = 0; i < MaxSize; i++) {
                Data[i] = (byte)(i & 0xff);
                }
            return Data;
            }


        public void ReadContainer (Container Container, List<ContainerHeader> ContainerHeaders) {

            //Goedel.Protocol.JSONReader.Trace = true; // HACK: 

            Container.First();
            ContainerHeaders.Add(Container.ContainerHeader);
            while (!Container.EOF) {
                Container.Next();
                ContainerHeaders.Add(Container.ContainerHeader);
                }
            }

        void GoMesh () {
            ExampleGenerator.MakeExamplesCatalog(this);
            ExampleGenerator.MakeExamplesBookmark(this);
            ExampleGenerator.MakeExamplesCredential(this);
            ExampleGenerator.MakeExamplesContact(this);
            ExampleGenerator.MakeExamplesCalendar(this);
            ExampleGenerator.MakeExamplesMail(this);
            ExampleGenerator.MakeExamplesSSH(this);

            //StartService();

            //CreateProfile();
            //ConnectDevice();
            ////AddApplicationWeb();  
            //AddApplicationSSH();  // Todo: check, implement
            ////AddApplicationMail(); // Todo: implement
            //KeyRecovery(); // Todo: implement

            //Traces = Portal.Traces;

            //ExampleGenerator.MeshExamples(this);
            //ExampleGenerator.MeshExamplesWeb(this);
            }

        public static string NameAccount = "alice";
        public static string NameService = "example.com";
        public readonly string AccountID = Account.ID(NameAccount, NameService);

        MeshClient MeshClient;
        MeshPortalTraced Portal;
        /// <summary>
        /// Start the Mesh as a direct service
        /// </summary>
        void StartService() {
            // Create test Mesh
            File.Delete(LogMesh);
            File.Delete(LogPortal);

            Portal = new MeshPortalTraced(NameService, LogMesh, LogPortal);
            MeshPortal.Default = Portal;

            MeshClient = new MeshClient(PortalAccount: AccountID);
            }

        public static string Device1Name = "AliceDesktop";
        public static string Device1Description = "A desktop computer built by Acme Computer Co.";

        public static string Device2Name = "AliceRing";
        public static string Device2Description = "A wearable ring computer";

        public static string Device3Name = "AliceLaptop";
        public static string Device3Description = "A laptop computer";


        //public SignedDeviceProfile SignedDeviceProfile1
        //public SignedDeviceProfile2;
        //public PersonalProfile PersonalProfile;
        //public SignedPersonalProfile SignedPersonalProfile;

        CommandLineInterpreter CommandLineInterpreter = new CommandLineInterpreter();

        public Shell Shell1 = new Shell() {
            MeshMachine = new MeshMachineCached(),
            DefaultDescription = Device1Description
            };
        public string Device1 (string Command) {
            return Device1(Command, out var Forget);
            }
        public string Device1 (string Command, out string Tag) {
            Tag = Label(Command);
            return Shell1.Dispatch(Command);
            }

        public Shell Shell2 = new Shell() {
            MeshMachine = new MeshMachineCached(),
            DefaultDescription = Device2Description
            };
        public string Device2 (string Command, out string Tag) {
            Tag = Label(Command);
            return Shell2.Dispatch(Command);
            }

        public Shell Shell3 = new Shell() {
            MeshMachine = new MeshMachineCached(),
            DefaultDescription = Device3Description
            };
        public string Device3 (string Command, out string Tag) {
            Tag = Label(Command);
            return Shell3.Dispatch(Command);
            }

        static int Count = 0;
        string Label (string Command) {
            var Tag = Count++.ToString();
            Portal.Label(Tag);
            Portal.Traces.Current.Command = Command;
            return Tag;
            }

        public string LabelValidate;
        public string LabelCreatePersonal;
        public string CommandValidate;

        /// <summary>
        /// Create a new profile for alice@example.com
        /// </summary>
        void CreateProfile() {
            Device1("keygen");


            // check that the name is available
            Device1("verify test@prismproof.org", out LabelValidate);

            // create the profile
            Device1("personal create test@prismproof.org \\id=" + Device1Name, out LabelCreatePersonal);
            }


        public string LabelConnectRequest;
        public string LabelConnectPending;
        public string LabelConnectAccept;
        public string LabelConnectComplete;
        /// <summary>
        /// Add a second device
        /// </summary>
        void ConnectDevice() {

            // Connect the second device
            Device2("connect start test@prismproof.org", out LabelConnectRequest);
            var Authenticator = (Shell2.LastResult as ResultConnectStart).Authenticator;

            Device1("connect pending", out LabelConnectPending);
            Device1("connect accept " + Authenticator, out LabelConnectAccept);
            Device2("connect Complete", out LabelConnectComplete);
            }

        
        public string LabelApplicationWeb1;
        public string LabelApplicationWeb2;
        public string LabelApplicationWeb3;
        public string LabelApplicationWeb4;
        public string LabelApplicationWeb5;


        public string LabelApplicationProfile;


        //public PasswordProfile PasswordProfile1 ;
        //public PasswordProfile PasswordProfile2 ;
        //public PasswordProfile PasswordProfile3 ;

        ///// <summary>
        ///// Create a Web credential profile.
        ///// </summary>
        //void AddApplicationWeb() {

        //    Device1("password create", out LabelApplicationWeb1);
        //    Device1("password add example.com alice password1", out LabelApplicationWeb1);
        //    PasswordProfile1 = Shell1.PasswordProfile;
        //    Device1("password add example.com alice password2", out LabelApplicationWeb2);
        //    Device1("password add example.net alice password3", out LabelApplicationWeb3);
        //    PasswordProfile2 = Shell1.PasswordProfile;
        //    Device1("password add example.com alice password2", out LabelApplicationWeb4);
        //    Device1("password delete example.net", out LabelApplicationWeb5);
        //    PasswordProfile3 = Shell1.PasswordProfile;
        //    }

        //SSHProfile SSHProfile;

        /// <summary>
        /// Create a SSH credential profile.
        /// </summary>
        void AddApplicationSSH() {
            Device1("keygen"); // Generate a password for the later pieces 

            Device1("ssh create");

            Device1("ssh public ");
            Device1("ssh private");

            Device1("ssh known");
            Device1("ssh add ssh1.example.com rsa AAAA1234");
            Device1("ssh known");

            }

        /// <summary>
        /// Create a SSH credential profile.
        /// </summary>
        void AddApplicationMail () {
            throw new NYI();
            }


        /// <summary>
        /// The offline escrow entry data.
        /// </summary>
        public OfflineEscrowEntry OfflineEscrowEntry => Shell1.OfflineEscrowEntry;  


        public string LabelEscrow = "Publish escrow";
        public string LabelRecover = "Recover";

        /// <summary>
        /// Create and recover profile.
        /// </summary>
        void KeyRecovery() {

            Device1("personal escrow /quorum 2 /shares 3 /file=escrow.json", out LabelEscrow);

            var Params = OfflineEscrowEntry.KeyShares[0].Text + " " +
                OfflineEscrowEntry.KeyShares[1].Text;
            Device1("personal recover " + Params, out LabelRecover);

            //throw new NYI();



            //// Create escrow keyshares for 2 our of 3
            //OfflineEscrowEntry = new OfflineEscrowEntry(PersonalProfile, 3, 2);

            //Portal.Label(LabelEscrow);
            //// Publish key escrow to the Mesh
            //MeshClient.Publish(OfflineEscrowEntry);

            //// Recover encryption key from two shares
            //var share1 = OfflineEscrowEntry.KeyShares[0].Text;
            //var share2 = OfflineEscrowEntry.KeyShares[1].Text;

            //// Get recovery data
            //string[] TestShares = { share1, share2 };
            //var RecoveryKey = new Secret (TestShares);

            //// Determine identifier
            //var Identifier = UDF.ToString(UDF.FromEscrowed(
            //    RecoveryKey.Key, 150));

            //// Here need a call to pull the data
            //Portal.Label(LabelRecover);

            //MeshClient.Recover(Identifier);
            }

        }
    }
