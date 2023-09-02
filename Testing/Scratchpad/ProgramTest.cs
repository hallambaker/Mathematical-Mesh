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


using System;
using System.Diagnostics;
using ExampleGenerator;
using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Dare;
using Goedel.Debug;
//using Goedel.Cryptography.PQC;
using Goedel.Mesh;
using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Test;
using Goedel.Test.Core;
using Goedel.Utilities;
using Goedel.XUnit;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace Scratchpad;


// ToDo: Server logging
// ToDo: Server status info
// ToDo: Test write validator, read in all catalogs and check encryption etc. status

// ToDo: RUD Documentation - Grab examples from connection formation
// ToDo: RUD Documentation - Describe stream lifecycle
// ToDo: RUD Documentation - Describe account binding

partial class Program {

    static public AssemblyLogger Logger { get; } = new AssemblyLogger();


    static void Main() {
        Trace.Listeners.Add(new GoedelTraceListener());



        Logger.LogInformation("Start test {time}", System.DateTime.Now);

        ServiceDiscovery.Test().TestServiceAddressParse();

        //TestService.Test().MeshCatalogGroup();
        //TestService.Test().MeshDeviceDirectKey();




        CallsignDirect.Test().RegisterAlice();

        RegistrationTests.Test().CallsignBind();






        Trace.WriteLine($"Trace enabled");
        GoedelProtocol.Test().TestStruct();






        TestService.Test().MeshDeviceDirectKey();
        TestService.Test().MeshDeviceThresholdKey();

        //TestService.Test().MeshDeviceSsh();

        //TestPresence.Test().PresenceSessionRequest();
        TestPresence.Test().PresenceHeartbeat();

        RegistrationTests.Test().CallsignPresencePresent();
        RegistrationTests.Test().CallsignPresenceAbsent();






        /* The presence stuff */

        TestService.Test().MeshPresence();



        /* Callsigns But likely redundant */
        TCallsign.Test().TestIssue();
        TCallsign.Test().TestResolve();
        TCallsign.Test().TestCallSignBadSignatureIssuer();
        TCallsign.Test().TestCallSignBadSignatureRegistration();
        TCallsign.Test().TestCallSignBadSignatureProfile();






        /* Save for later */


        ShellTests.Test().NewFileTestOnce();




        /* Skipped tests */

        /* Notary functionality */
        TestSequences.Test().TestProof();
        TClaimProof.Test().TestProof();
        TClaimProof.Test().TestNotaryToken();
        TClaimProof.Test().TestEnrolledNotaryToken();
        TClaimProof.Test().TestNotarizedSignature();
        TClaimProof.Test().TestServiceNotarizedSignature();
        TClaimProof.Test().TestMultiNotarizedSignature();
        TClaimProof.Test().TestWebNotarizedSignature();

        /* Catalog etc read permissions */
        TestService.Test().MalletCatalogReadFail();


        /* Carnet */
        TestService.Test().MeshCarnet(); 
        TestService.Test().MeshRepository();
        TCallsign.Test().TestPurchase();
        TCallsign.Test().TestPurchaseIndirect();
        RegistrationTests.Test().CallsignRegistrationPaid();
        RegistrationTests.Test().CallsignRegistrationInsufficient();

        /* Signatures */
        TSignatures.Test().TestSignatureProfile();

        /* Documentation */
        Goedel.XUnit.MakeSiteDocs.Test().FullTest();

        Logger.LogInformation("End test {time}, Fail={Softfail}", System.DateTime.Now, TestCLI.CountSoftFail);
        //Screen.WriteLine($"Total Soft fail {TestCLI.CountSoftFail}");
        }

    public static void Debug() {
        var testEnvironmentCommon = new TestEnvironmentCommon(DeterministicSeed.Create());
        var meshMachine = new MeshMachineTest(testEnvironmentCommon);
        var keyCollection = new KeyCollectionTest(meshMachine);

        var keyEncrypt = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Exportable, keyCollection) as KeyPairX448;
        var keyService = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device);
        keyCollection.Add(keyService);


        var (keyData, capability) = CatalogAccess.MakeShare(keyEncrypt, "example", keyService, null, null);


        var deviceShare = keyData.GetKeyPair() as KeyPairServiced;

        var ephemeral = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Ephemeral) as KeyPairX448;

        var agreement1 = ephemeral.Agreement(keyEncrypt);
        var agreement2 = keyEncrypt.Agreement(ephemeral);


        var remoteShare = capability.DecryptShare(keyCollection) as KeyPairServiced;
        var partial1 = remoteShare.Agreement(ephemeral) as CurveX448Result;
        var partial2 = deviceShare.Agreement(ephemeral) as CurveX448Result;


        //Screen.WriteLine($"Remote {remoteShare.Share.KeyIdentifier} Device {deviceShare.Share.KeyIdentifier}");


        partial2.AgreementX448.Accumulate(partial1.AgreementX448);
        var aggre3 = new CurveX448Result() { AgreementX448 = partial2.AgreementX448 };

        agreement1.IKM.TestEqual(agreement2.IKM);
        agreement1.IKM.TestEqual(aggre3.IKM);


        var agreement3 = (deviceShare.Share as KeyPairX448).Agreement(ephemeral, partial1 as CurveX448Result);

        agreement1.IKM.TestEqual(agreement3.IKM);
        }



    public static void Find(
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.SHA_3_512) {
        //  Magic number for SHA2 is 4187123
        //  Magic number for SHA3 is  774665
        var output = Console.Out;

        for (var i = 0; true; i++) {
            if ((i % 1000) == 0) {
                output.WriteLine(i);
                }

            var document = $"UDF Compressed Document {i}";
            var contentType = "text/plain";
            var utf8 = document.ToUTF8();
            var digest = Platform.SHA3_512.Process(utf8);

            var buffer = Udf.UDFBuffer(digest, contentType);
            var UDFData = buffer.GetDigest(cryptoAlgorithmID);

            if (Udf.GetCompression(UDFData) > 0) {
                output.WriteLine($"!!!!!!!!!!!!!!!!  {i}");
                return;
                }

            }
        }

    }
