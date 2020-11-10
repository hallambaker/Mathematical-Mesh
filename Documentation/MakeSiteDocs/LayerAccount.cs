using Goedel.Mesh;
using Goedel.Mesh.Test;
using Goedel.Utilities;
using Goedel.IO;
using System;
using System.Collections.Generic;

namespace ExampleGenerator {


    public partial class LayerAccount : ExampleSet {



        public string EncryptSourceFile = "plaintext.txt";
        public string EncryptTargetFile = "ciphertext.dare";
        public string EncryptResultFile = "plaintext1.txt";

        public List<ExampleResult> CreateAlice;
        public List<ExampleResult> CreateBob;
        public List<ExampleResult> CreateConsole;
        public List<ExampleResult> ConsoleEncryptFile;
        public List<ExampleResult> ConsoleDecryptFile;
        public List<ExampleResult> ProfileEscrow;
        public List<ExampleResult> ProfileRecover;
        public List<ExampleResult> PasswordAdd;
        public List<ExampleResult> PasswordGet;
        public List<ExampleResult> DeleteAlice;
        public List<ExampleResult> SyncAlice;


        public LayerAccount(CreateExamples createExamples) :
                base(createExamples) {
            }


        }

    public partial class LayerConnect : ExampleSet {
        public string EncryptResultFile = "plaintext2.txt";

        public List<ExampleResult> ConnectRequest;
        public List<ExampleResult> ConnectPending;
        public List<ExampleResult> ConnectAccept;
        public List<ExampleResult> ConnectComplete;
        public List<ExampleResult> PasswordList2;
        public List<ExampleResult> Disconnect;
        public List<ExampleResult> PasswordList2Disconnect;

        public ProfileDevice AliceProfileDeviceCoffee;
        public ActivationDevice AliceActivationDeviceCoffee;
        public ActivationAccount AliceActivationAccountCoffee;
        public ConnectionDevice AliceConnectionDeviceCoffee;
        public ActivationDevice AliceActivationDeviceWatch;
        public ProfileDevice AliceProfileDeviceWatch;

        public List<ExampleResult> ConnectMakerCreate;
        public List<ExampleResult> ConnectStaticPrepare;
        public List<ExampleResult> ConnectStaticInstall;
        public List<ExampleResult> ConnectStaticPollFail;
        public List<ExampleResult> ConnectStaticClaim;
        public List<ExampleResult> ConnectStaticPollSuccess;


        public List<ExampleResult> ConnectPINCreate;
        public List<ExampleResult> ConnectPINRequest;
        public List<ExampleResult> ConnectPINComplete;


        public DevicePreconfiguration ConnectStaticPreconfig;



        public MessagePin ConnectPINMessagePin;
        public AcknowledgeConnection ConnectPINAcknowledgeConnection;
        public RespondConnection ConnectPINConnectResponse;
        
        
        public MessageComplete ConnectPINCompleteMessage;
        public RequestConnection ConnectRequestPIN;
        public AcknowledgeConnection AcknowledgeConnectionPIN;
        public RespondConnection RespondConnectionPIN;

        public RequestConnection ConnectRequestWitness;
        public RespondConnection AcknowledgeConnectionWitness;
        public RespondConnection RespondConnectionWitness;

        public string ConnectEARL;




        public LayerConnect(CreateExamples createExamples) :
                base(createExamples) {
            }


        }


    public partial class LayerService : ExampleSet {

        public List<ExampleResult> Hello;
        public ProfileDevice ProfileService;
        public ProfileDevice ConnectionHost;


        public LayerService(CreateExamples createExamples) :
                base(createExamples) {
            }


        }

    public partial class LayerApps : ExampleSet {

        public List<ExampleResult> SSH;
        public List<ExampleResult> Mail;

        public CatalogedEntry BookmarkCatalogEntry;
        public CatalogedEntry ContactCatalogEntry;
        public CatalogedEntry CredentialCatalogEntry;
        public CatalogedEntry NetworkCatalogEntry;
        public CatalogedEntry TaskCatalogEntry;

        public CatalogedEntry MailCatalogEntry;
        public CatalogedEntry SSHCatalogEntry;

        public LayerApps(CreateExamples createExamples) :
                base(createExamples) {
            }


        }


    public partial class LayerContact : ExampleSet {

        public List<ExampleResult> ContactBobRequest;
        public List<ExampleResult> ContactAliceResponse;

        public MessagePin MessagePin;

        public MessageContact BobRequest;
        public MessageContact AliceResponse;


        public LayerContact(CreateExamples createExamples) :
                base(createExamples) {
            }


        public string AliceDynamicQRCode;
        public string AliceStaticQRCode;

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
        public string EncryptTargetFile = "groupsecret.dare";
        public string TestText = "The group secret handshake";


        public List<ExampleResult> GroupCreate;
        public List<ExampleResult> GroupEncrypt;
        public List<ExampleResult> GroupDecryptAlice;
        public List<ExampleResult> GroupDecryptBobFail;
        public List<ExampleResult> GroupAddBob;
        public List<ExampleResult> GroupDecryptBobSuccess;
        public List<ExampleResult> GroupDeleteBob;
        public List<ExampleResult> GroupDecryptBobRevoked;


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
    }
