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

using Goedel.Cryptography;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.XUnit;
using Goedel.Test;
using Goedel.Mesh.Test;
using Goedel.Cryptography.Algorithms;
using Goedel.Test.Core;

namespace Scratchpad {


    // ToDo: Server logging
    // ToDo: Server status info
    // ToDo: Test write validator, read in all catalogs and check encryption etc. status

    // ToDo: RUD Documentation - Grab examples from connection formation
    // ToDo: RUD Documentation - Describe stream lifecycle
    // ToDo: RUD Documentation - Describe account binding

    partial class Program {
        static void Main() {
            Screen.WriteInfo($"Start test  {DateTime.Now}");


            Goedel.XUnit.MakeSiteDocs.Test().FullTest();



            //ShellTestsAdmin.Test().TestProfileMail();

            //ShellTestsAdmin.Test().TestMessageContactRemote();
            //ShellTestsAdmin.Test().TestFilePlain();

            //ShellTestsAdmin.Test().TestHello();
            //ShellTestsAdmin.Test().TestAccountDelete();
            //ShellTestsAdmin.Test().TestProfileConnectPin();
            //ShellTestsAdmin.Test().TestProfileConnectPinExpired();
            //ShellTestsAdmin.Test().TestProfileConnectPinInvalid();






            //TestService.Test().MeshCatalogGroup();
            //TestService.Test().MeshDeviceThresholdKey();




            //ShellTestsAdmin.Test().TestProfileConnectStaticQR();



            //ShellTestsAdmin.Test().TestCreateSuper();


            //ShellTestsAdmin.Test().TestMessageConfirmationAccept();
            //ShellTestsAdmin.Test().TestProfileConnect();

            //ShellTestsAdmin.Test().TestProfileConnect();


            //ShellTestsAdmin.Test().TestCreateDevice();




            //ShellTestsAdmin.Test().TestHello();
            //ShellTestsRud.Test().TestHello();


            // Refactor to make KeyCredential Mesh a subclass and chain Mesh credential off that.
            //ShellTestsHTTP.Test().TestAccount();

            //Goedel.XUnit.MakeSiteDocs.Test().GroupTests();
            //ShellTests.Test().TestMessageGroup();



            //TestService.Test().MeshDeviceDirectKey();



            //Debug();


            //TestService.Test().MeshEscrowRecover();



            //TestService.Test().MeshDeviceConnectPIN();
            //TestService.Test().MeshDeviceConnectDynamicQR();
            //TestService.Test().MeshDeviceConnectStaticQR();

            //TestService.Test().MeshDeviceMail();


            //ShellTests.Test().TestProfileConnectPinReused();
            //ShellTests.Test().TestProfileMail();
            //ShellTests.Test().TestProfileSSHPrivate();
            //ShellTests.Test().TestProfileSSHPublic();

            //TestService.Test().MeshDeviceSsh();


            //TestService.Test().MeshDeviceDeveloper();



            //TestService.Test().MeshDeviceConnectPIN();
            //TestService.Test().MeshDeviceConnectDynamicQR();



            //ShellTests.Test().TestProfileConnectPin();


            //ShellTests.Test().TestProfileConnect();
            //ShellTests.Test().TestProfileConnectDynamicQR();


            //ShellTestsHTTP.Test().TestMessageGroup();
            //TestPresentationMesh.Test().TestMeshService();


            //// This is failing as a result of Operate having a lock that is acquired but not released.
            //ShellTestsAdmin.Test().TestAccount();


            //TestPresentationMesh.Test().TestAccountDeletion();
            //TestPresentationMesh.Test().TestDeviceDeletion();

            //TestPresentationMesh.Test().TestImpersonationConfirm();

            //TestPresentationMesh.Test().TestImpersonationGroup();


            }

        public static void Debug() {
            var testEnvironmentCommon = new TestEnvironmentCommon();
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
            for (var i = 0; true; i++) {
                if ((i % 1000) == 0) {
                    Console.WriteLine(i);
                    }

                var document = $"UDF Compressed Document {i}";
                var contentType = "text/plain";
                var utf8 = document.ToUTF8();
                var digest = Platform.SHA3_512.Process(utf8);

                var buffer = UDF.UDFBuffer(digest, contentType);
                var UDFData = buffer.GetDigest(cryptoAlgorithmID);

                if (UDF.GetCompression(UDFData) > 0) {
                    Console.WriteLine($"!!!!!!!!!!!!!!!!  {i}");
                    return;
                    }

                }
            }

        }
    }
