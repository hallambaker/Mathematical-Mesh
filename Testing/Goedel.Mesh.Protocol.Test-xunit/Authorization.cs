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
//  

using System;
using System.Collections.Generic;

using Goedel.Cryptography.KeyFile;
using Goedel.Mesh;
using Goedel.Mesh.Test;
using Goedel.Registry;
using Goedel.Test;
using Goedel.Utilities;

using Xunit;

namespace Goedel.XUnit {
    public partial class TestService {

        /// <summary>
        /// Connect a device by approving a request
        /// </summary>
        [Fact]
        public void MeshDeviceDirectKey() {
            var rights = new List<string> { Rights.IdRolesDirect };


            var testEnvironmentCommon = GetTestEnvironmentCommon();
            var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceAliceAdmin, AccountAlice, "main");

            // New Device
            var contextOnboardPending = MeshMachineTest.Connect(testEnvironmentCommon, DeviceAlice3,
                    AccountAlice);

            // Admin Device
            contextAccountAlice.Sync();
            var connectRequest = contextAccountAlice.GetPendingMessageConnectionRequest();
            contextAccountAlice.Process(connectRequest, roles: rights);

            // Check second device
            var contextOnboarded = TestCompletionSuccess(contextOnboardPending);
            ExerciseAccount(contextOnboarded);



            //Check the access catalog
            //   Should have no threshold entry
            //   Should have service auth entry

            }

        /// <summary>
        /// Connect a device by approving a request
        /// </summary>
        [Fact]
        public void MeshDeviceThresholdKey() {

            var roles = new List<string> { Rights.IdRolesUser };

            var testEnvironmentCommon = GetTestEnvironmentCommon();
            var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceAliceAdmin, AccountAlice, "main");

            // New Device
            var contextOnboardPending = MeshMachineTest.Connect(testEnvironmentCommon, DeviceAlice3,
                    AccountAlice);

            // Admin Device
            contextAccountAlice.Sync();
            var connectRequest = contextAccountAlice.GetPendingMessageConnectionRequest();
            contextAccountAlice.Process(connectRequest, roles:roles);

            // Check second device
            var contextOnboarded = TestCompletionSuccess(contextOnboardPending);
            ExerciseAccount(contextOnboarded);

            //Check the capability catalog
            //   Should have threshold entry
            //   Should have service auth entry

            }



        [Fact]
        public void MeshDeviceSsh() {
            var roles = new List<string> { Rights.IdRolesWeb };

            var testEnvironmentCommon = GetTestEnvironmentCommon();
            var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceAliceAdmin, AccountAlice, "main");

            // New Device
            var contextOnboardPending = MeshMachineTest.Connect(testEnvironmentCommon, DeviceAlice3,
                    AccountAlice);

            // Admin Device
            contextAccountAlice.Sync();
            var connectRequest = contextAccountAlice.GetPendingMessageConnectionRequest();
            contextAccountAlice.Process(connectRequest, roles: roles);

            // Check second device
            var contextOnboarded = TestCompletionSuccess(contextOnboardPending);
            ExerciseAccount(contextOnboarded);

            var id = "ssh";
            // Create an ssh application
            var applicationSSH = CatalogedApplicationSsh.Create(id, roles);

            var transaction1 = contextAccountAlice.TransactBegin();
            transaction1.ApplicationCreate(applicationSSH);
            var result1 = transaction1.Transact();

            contextOnboarded.Sync();

            var applicationSsh1 = contextAccountAlice.GetApplicationSsh(id);
            var applicationEntrySsh1 = contextAccountAlice.GetApplicationEntrySsh(id);
            var applicationSsh2 = contextOnboarded.GetApplicationSsh(id);
            var applicationEntrySsh2 = contextOnboarded.GetApplicationEntrySsh(id);

            // check applicationSsh1 == applicationSsh2
            // check we have a private key for each device.

            applicationSsh1.TestNotNull();
            applicationEntrySsh1.TestNotNull();
            applicationSsh2.TestNotNull();
            applicationEntrySsh2.TestNotNull();

            // now extract some files

            applicationSsh1.ClientKey.ToKeyFile("MeshDeviceSshPublic1", KeyFileFormat.OpenSSH);
            applicationSsh2.ClientKey.ToKeyFile("MeshDeviceSshPublic2", KeyFileFormat.OpenSSH);

            applicationEntrySsh1.Activation.ClientKey.ToKeyFile("MeshDeviceSshPrivate1", KeyFileFormat.PEMPrivate);
            applicationEntrySsh2.Activation.ClientKey.ToKeyFile("MeshDeviceSshPrivate2", KeyFileFormat.PEMPrivate);

            }



        /// <summary>
        /// Connect a device by approving a request
        /// </summary>
        [Fact]
        public void MeshDeviceDeveloper() {
            var rights = new List<string> { Rights.IdRolesDeveloper, Rights.IdRolesWeb};


            var testEnvironmentCommon = GetTestEnvironmentCommon();
            var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceAliceAdmin, AccountAlice, "main");

            // New Device
            var contextOnboardPending = MeshMachineTest.Connect(testEnvironmentCommon, DeviceAlice3,
                    AccountAlice);

            // Admin Device
            contextAccountAlice.Sync();
            var connectRequest = contextAccountAlice.GetPendingMessageConnectionRequest();
            contextAccountAlice.Process(connectRequest, roles: rights);

            // Check second device
            var contextOnboarded = TestCompletionSuccess(contextOnboardPending);
            ExerciseAccount(contextOnboarded);



            //Check the access catalog
            //   Should have no threshold entry
            //   Should have service auth entry

            }




        }

    }
