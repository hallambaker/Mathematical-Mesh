﻿#region // Copyright - MIT License
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
        public ConnectionService AliceConnectionDeviceCoffee;
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


        public List<ExampleResult> ConnectPINCreate;
        public List<ExampleResult> ConnectPINRequest;
        public List<ExampleResult> ConnectPINComplete;
        public List<ExampleResult> ConnectPINPending;

        public DevicePreconfiguration ConnectStaticPreconfig;
        public string ConnectEARL;




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
        public List<ExampleResult> ContactBobFinal;

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

        public string GroupDecryptBobFile = "grouptext_bob.dare";
        public string GroupDecryptBobFile2 = "grouptext_bob2.dare";
        public string GroupDecryptAliceFile = "grouptext_alice.dare";

        public string EncryptTargetFile = "groupsecret.dare";
        public string TestText = "The group secret handshake";


        public List<ExampleResult> GroupCreate;
        public List<ExampleResult> GroupEncrypt;
        public List<ExampleResult> GroupDecryptAlice;
        public List<ExampleResult> GroupDecryptBobFail;
        public List<ExampleResult> GroupAddAlice;
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
