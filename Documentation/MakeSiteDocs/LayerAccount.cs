using Goedel.Mesh;
using Goedel.Mesh.Test;
using Goedel.Utilities;
using Goedel.IO;
using System;
using System.Collections.Generic;

namespace ExampleGenerator {


    public partial class LayerAccount {
        CreateExamples CreateExamples;


        public string EncryptSourceFile = "plaintext.txt";
        public string EncryptTargetFile = "ciphertext.dare";

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


        public LayerAccount(CreateExamples createExamples) {
            CreateExamples = createExamples;
            }


        }

    public partial class LayerConnect {


        public List<ExampleResult> ConnectRequest;
        public List<ExampleResult> ConnectPending;
        public List<ExampleResult> ConnectAccept;
        public List<ExampleResult> ConnectComplete;
        public List<ExampleResult> PasswordList2;
        public List<ExampleResult> Disconnect;
        public List<ExampleResult> PasswordList2Disconnect;

        public ProfileDevice AliceProfileDeviceCoffee;
        public ActivationDevice AliceActivationDeviceCoffee;
        public ConnectionDevice AliceConnectionDeviceCoffee;
        public ActivationDevice AliceActivationDeviceWatch;

        public List<ExampleResult> ConnectStaticPrepare;
        public List<ExampleResult> ConnectStaticPollFail;
        public List<ExampleResult> ConnectStaticClaim;
        public List<ExampleResult> ConnectStaticPollSuccess;


        public RequestConnection ConnectRequestWitness ;
        public AcknowledgeConnection AcknowledgeConnectionWitness;
        public RespondConnection ConnectResponseWitness;


        public MessagePin ConnectPINMessagePin;
        public AcknowledgeConnection ConnectPINAcknowledgeConnection;
        public RespondConnection ConnectPINConnectResponse;
        public MessageComplete ConnectPINCompleteWitness;

        public ConnectRequest ConnectRequestPIN;

        public string ConnectEARL;




        public LayerConnect(CreateExamples CreateExamples) {
            }


        }


    public partial class LayerService {

        public List<ExampleResult> Hello;
        public ProfileDevice ProfileService;
        public ProfileDevice ConnectionHost;


        public LayerService(CreateExamples CreateExamples) {
            }


        }

    public partial class LayerApps {

        public List<ExampleResult> SSH;
        public List<ExampleResult> Mail;


        public ProfileDevice MailCatalogEntry;
        public ProfileDevice BookmarkCatalogEntry;
        public ProfileDevice ContactCatalogEntry;
        public ProfileDevice CredentialCatalogEntry;
        public ProfileDevice CredentialNetworkEntry;
        public ProfileDevice TaskCatalogEntry;

        public ProfileDevice SSHCatalogEntry;

        public LayerApps(CreateExamples CreateExamples) {
            }


        }


    public partial class LayerContact {

        public List<ExampleResult> ContactBobRequest;
        public List<ExampleResult> ContactAliceResponse;
        public MessageContact BobRequest;
        public MessagePin MessagePin;
        public MessageContact AliceResponse;
        public LayerContact(CreateExamples CreateExamples) {
            }


        public string AliceDynamicQRCode;
        public string AliceStaticQRCode;

        }

    public partial class LayerConfirm {

        public List<ExampleResult> ConfirmRequest;
        public List<ExampleResult> ConfirmAliceResponse;
        public List<ExampleResult> ConfirmVerify;

        public RequestConfirmation RequestConfirmation;
        public ResponseConfirmation ResponseConfirmation;

        public LayerConfirm(CreateExamples CreateExamples) {
            }
        }

    public partial class LayerGroup {
        public string GroupAccount = "groupw@example.com";
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

        public LayerGroup(CreateExamples CreateExamples) {
            }
        }

    public partial class LayerNYI {


        public List<ExampleResult> GroupCreate;


        public LayerNYI(CreateExamples CreateExamples) {
            }

        }
    }
