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

using Goedel.Cryptography.Dare;
using Goedel.Mesh;
using Goedel.Mesh.Test;
using Goedel.Test.Core;

namespace ExampleGenerator;


public partial class LayerAccount : ExampleSet {



    public string EncryptSourceFile = "plaintext.txt";
    public string EncryptTargetFile = "ciphertext.dare";
    public string EncryptResultFile = "plaintext1.txt";

    public List<ExampleResult> CreateAlice;
    public List<ExampleResult> CreateBob;
    public List<ExampleResult> CreateMallet;
    public List<ExampleResult> CreateCarol;
    public List<ExampleResult> CreateDoug;
    public List<ExampleResult> CreateEdward;

    public List<ExampleResult> CreateConsole;
    public List<ExampleResult> ConsoleEncryptFile;
    public List<ExampleResult> ConsoleDecryptFile;
    public List<ExampleResult> ProfileEscrow;
    public List<ExampleResult> ProfileRecover;
    public List<ExampleResult> PasswordAdd;
    public List<ExampleResult> PasswordGet;
    public List<ExampleResult> DeleteAlice;
    public List<ExampleResult> SyncAlice;
    public List<ExampleResult> StatusAlice;

    public List<ExampleResult> ListGetAccountAlice;
    public List<ExampleResult> ListAlice;
    public List<ExampleResult> GetAccountAlice;
    public List<ExampleResult> PublishAlice;
    public List<ExampleResult> PinAlice;
    public List<ExampleResult> ProfilePurge;
    public List<ExampleResult> ConnectUri;
    public List<ExampleResult> Export;
    public List<ExampleResult> Import;

    public LayerAccount(CreateExamples createExamples) :
            base(createExamples) {
        }


    }

public partial class LayerConnect : ExampleSet {
    public string EncryptResultFile = "plaintext2.txt";
    public string EncryptResultFile3 = "plaintext3.txt";

    public List<ExampleResult> ConnectRequest;
    public List<ExampleResult> ConnectRequestMallet;
    public List<ExampleResult> ConnectPending;
    public List<ExampleResult> ConnectAccept;
    public List<ExampleResult> ConnectReject;
    public List<ExampleResult> ConnectComplete;

    public List<ExampleResult> ConnectList;
    public List<ExampleResult> ConnectDelete;



    public List<ExampleResult> PasswordList2;
    public List<ExampleResult> Disconnect;
    public List<ExampleResult> PasswordList2Disconnect;

    public List<ExampleResult> DisconnectThresh;

    public List<ExampleResult> DisconnectThreshDecrypt;

    public ProfileDevice AliceProfileDevice2;
    public ActivationDevice AliceActivationDevice2;
    public ActivationAccount AliceActivationAccount2;
    public ConnectionService AliceConnectionDevice2;
    public ConnectionService AliceConnectionService2;

    public ProfileDevice AliceProfileDevice3;
    public ActivationDevice AliceActivationDevice3;
    public ActivationAccount AliceActivationAccount3;
    public ConnectionService AliceConnectionDevice3;
    public ConnectionService AliceConnectionService3;






    public ActivationDevice AliceActivationDeviceWatch;
    public ProfileDevice AliceProfileDeviceWatch;

    public List<ExampleResult> ConnectMakerCreate;
    public List<ExampleResult> ConnectStaticPrepare;
    public List<ExampleResult> ConnectStaticInstall;
    public List<ExampleResult> ConnectStaticPollFail;
    public List<ExampleResult> ConnectStaticClaim;
    public List<ExampleResult> ConnectStaticPollSuccess;



    public string ClaimUri;
    public MessageClaim MessageClaim;
    public Trace RequestClaim;
    public Trace ResponseClaim;
    public Trace RequestPollClaim;
    public Trace ResponsePollClaim;

    // The witness connection example.
    public Trace ConnectPINRequestConnection;
    //public AcknowledgeConnection WitnessAcknowledgeConnection;
    public Trace ConnectPINResponseConnection;
    public ActivationDevice ConnectPINActivationDevice;
    public CatalogedDevice ConnectPINCatalogedDevice;
    public Trace ConnectPINRequestComplete;
    public Trace ConnectPINRespondComplete;


    public string Device2Id;
    public string Device3Id;

    public List<ExampleResult> ConnectPINCreate;
    public List<ExampleResult> ConnectPINRequest;
    public List<ExampleResult> ConnectPINComplete;
    public List<ExampleResult> ConnectPINPending;

    public DevicePreconfigurationPrivate ConnectStaticPreconfig;
    public string ConnectEARL;


    public Goedel.Mesh.Shell.ResultPublishDevice ConnectStaticResult;

    public MessagePin ConnectPINMessagePin;
    public AcknowledgeConnection ConnectPINAcknowledgeConnection;
    public RespondConnection ConnectPINConnectResponse;


    public MessageComplete ConnectPINCompleteMessage;
    public RequestConnection ConnectRequestPIN;

    //public AcknowledgeConnection AcknowledgeConnectionPIN;
    public RespondConnection RespondConnectionPIN;

    public RequestConnection ConnectRequestWitness;
    public RespondConnection AcknowledgeConnectionWitness;
    public RespondConnection RespondConnectionWitness;

    public string ConnectDynamicURI;

    public List<ExampleResult> ConnectJoin;

    public List<ExampleResult> ConnectJoinPinCreate;
    public List<ExampleResult> ConnectJoinPending;
    public List<ExampleResult> ConnectJoinComplete;
    public List<ExampleResult> ConnectJoinAuth;
    public List<ExampleResult> ConnectSSHAuth;
    public List<ExampleResult> ConnectMailAuth;



    public DareEnvelope ResponseIdentifierEnvelope;
    public RequestConnection ResponseIdentifierMessage;

    public string ResponseIdentifierMessageId;
    public string ResponseIdentifierResponseId;

    public string ProofOfKnowledgePin;
    public byte[] ProofOfKnowledgeAlg;
    public byte[] ProofOfKnowledgePinData;
    public string ProofOfKnowledgeActionString;
    public byte[] ProofOfKnowledgeActionBytes;
    public byte[] ProofOfKnowledgeSaltedPin;
    public string ProofOfKnowledgeSaltedPinId;

    public byte[] ProofOfKnowledgeWitnessData;
    public string ProofOfKnowledgeWitnessValue;

    public MessagePinValidated MessagePinValidated;


    public List<ExampleResult> AddPasswordToDevice1;
    public List<ExampleResult> AddPasswordToDevice2BySync;




    public LayerConnect(CreateExamples createExamples) :
            base(createExamples) {
        }


    }


public partial class LayerService : ExampleSet {

    public List<ExampleResult> Hello;
    public ProfileService ProfileService;
    public ProfileDevice ProfileHost;
    public ConnectionService ConnectionHost;

    public LayerService(CreateExamples createExamples) :
            base(createExamples) {
        }


    }

public partial class LayerApps : ExampleSet {

    public string SshPublicKey = "alice1_ssh_pub.pem";
    public string SshPrivateKey = "alice1_ssh_prv.pem";
    public string SshPrivateKey2 = "alice2_ssh_prv.pem";


    public string Mailaddress = "alice@example.net";
    public string Mailinbound1 = "pop://alice@pop3.example.net";
    public string Mailinbound2 = "imap://alice@imap.example.net";
    public string Mailoutbound = "submit://alice@submit.example.net";

    public string MailSmimeFile = "alice1_smime_sign.pem";
    public string MailOpenpgpFile = "alice1_opgp_sign.pem";
    public string MailSmimeFileEncrypt = "alice1_smime_encrypt.pem";
    public string MailOpenpgpFileEncrypt = "alice1_opgp_encrypt.pem";

    public List<ExampleResult> SSHCreate;

    public List<ExampleResult> SSHAddClient;
    public List<ExampleResult> SSHAddHost;

    public List<ExampleResult> SSHDelete;
    public List<ExampleResult> SSHImport;
    public List<ExampleResult> SSHGet;
    public List<ExampleResult> SSHMergeClients;
    public List<ExampleResult> SSHMergeHosts;
    public List<ExampleResult> SSHPublic;
    public List<ExampleResult> SSHPrivate;
    public List<ExampleResult> SSHConnect;
    public List<ExampleResult> SSHAuthProof;
    public List<ExampleResult> SSHList;
    public List<ExampleResult> SSHListHosts;

    public List<ExampleResult> Mail;
    public List<ExampleResult> MailGet;
    public List<ExampleResult> MailList;
    public List<ExampleResult> MailImport;
    public List<ExampleResult> MailUpdate;



    public List<ExampleResult> MailSmimeSign;
    public List<ExampleResult> MailSmimeSignP12;
    public List<ExampleResult> MailSmimeEncrypt;
    public List<ExampleResult> MailOpenpgpSign;
    public List<ExampleResult> MailOpenpgpSignP12;
    public List<ExampleResult> MailOpenpgpEncrypt;

    public List<ExampleResult> MailConnect;


    public CatalogedEntry BookmarkCatalogEntry;
    public CatalogedEntry ContactCatalogEntry;
    public CatalogedEntry CredentialCatalogEntry;
    public CatalogedEntry NetworkCatalogEntry;
    public CatalogedEntry TaskCatalogEntry;

    public CatalogedEntry MailCatalogEntry;
    public CatalogedEntry SSHCatalogEntry;
    public CatalogedEntry PublicationEntry;

    public LayerApps(CreateExamples createExamples) :
            base(createExamples) {
        }


    }


public partial class LayerContact : ExampleSet {

    public List<ExampleResult> ContactBobRequest;
    public List<ExampleResult> ContactAliceResponse;
    public List<ExampleResult> ContactBobFinal;

    public MessagePin MessagePin;

    public MessageContact BobRequest;
    public MessageContact AliceResponse;


    public List<ExampleResult> ContactAdd;

    public List<ExampleResult> ContactGet;

    public List<ExampleResult> ContactList;
    public List<ExampleResult> ContactList1;
    public List<ExampleResult> ContactList2;

    public List<ExampleResult> ContactDelete;
    public List<ExampleResult> ContactAddSelf;
    public List<ExampleResult> ContactImport;


    public LayerContact(CreateExamples createExamples) :
            base(createExamples) {
        }


    public string AliceDynamicQRCode;
    public string AliceStaticQRCode;

    public List<ExampleResult> ContactCarolDynamicPin;
    public List<ExampleResult> ContactCarolDynamicFetch;
    public List<ExampleResult> ContactCarolDynamicAliceGet;

    public List<ExampleResult> ContactCarolListAlice;
    public List<ExampleResult> ContactCarolListCarol;



    public List<ExampleResult> ContactDougDynamicUri;
    public List<ExampleResult> ContactDougDynamicFetch;
    public List<ExampleResult> ContactDougDynamicDougGet;
    public List<ExampleResult> ContactDougListAlice;
    public List<ExampleResult> ContactDougListDoug;


    public List<ExampleResult> ContactDougStaticUri;
    public List<ExampleResult> ContactDougStaticFetch;

    public List<ExampleResult> ContactStaticListAlice;




    }

public partial class LayerConfirm : ExampleSet {

    public List<ExampleResult> ConfirmRequest;
    public List<ExampleResult> ConfirmAliceSync;
    public List<ExampleResult> ConfirmAliceResponse;
    public List<ExampleResult> ConfirmVerify;

    public RequestConfirmation RequestConfirmation;
    public ResponseConfirmation ResponseConfirmation;

    public LayerConfirm(CreateExamples createExamples) :
            base(createExamples) {
        }
    }

public partial class LayerGroup : ExampleSet {

    public string EncryptSourceFile = "grouptext.txt";

    public string GroupDecryptBobFile = "grouptext_bob.dare";
    public string GroupDecryptBobFile2 = "grouptext_bob2.dare";
    public string GroupDecryptAliceFile = "grouptext_alice.dare";

    public string EncryptTargetFile = "groupsecret.dare";
    public string TestText = "The group secret handshake";


    public List<ExampleResult> GroupCreate;
    public List<ExampleResult> GroupEncrypt;
    public List<ExampleResult> GroupDecryptAlice;
    //public List<ExampleResult> GroupDecryptAliceSuccess;

    public List<ExampleResult> GroupDecryptBobFail;
    public List<ExampleResult> GroupAddAlice;
    public List<ExampleResult> GroupAddBob;
    public List<ExampleResult> GroupDecryptBobSuccess;
    public List<ExampleResult> GroupDeleteBob;
    public List<ExampleResult> GroupDecryptBobRevoked;


    public List<ExampleResult> GroupList;
    public List<ExampleResult> GroupGet;


    public CatalogedAccess BobAccessEntry;

    public GroupInvitation GroupInvitation;

    public LayerGroup(CreateExamples createExamples) :
            base(createExamples) {
        }
    }

public partial class LayerNYI : ExampleSet {


    public List<ExampleResult> GroupCreate;


    public LayerNYI(CreateExamples createExamples) :
            base(createExamples) {
        }

    }
