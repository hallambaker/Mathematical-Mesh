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

using Goedel.Mesh;
using Goedel.Mesh.Test;
using Goedel.Registry;
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
            var applicationSSH = new CatalogedApplicationSsh() {
                Key = id,
                Grant = roles
                };


            "Move out to separate routine that reads the device catalog".TaskFunctionality();
            var transaction1 = contextAccountAlice.TransactBegin();
            transaction1.ApplicationCreate(applicationSSH);
            //transaction1.ApplicationDeviceAdd(applicationSSH);
            //transaction1.ApplicationDeviceAdd(applicationSSH, contextOnboarded.ConnectionDevice);
            var result1 = transaction1.Transact();


            var transaction2 = contextAccountAlice.TransactBegin();
            var applicationSsh1 = transaction2.ApplicationGetSsh(id);
            var result2 = transaction2.Transact();


            var transaction3 = contextOnboarded.TransactBegin();
            var applicationSsh2 = transaction3.ApplicationGetSsh(id);
            var result3 = transaction2.Transact();

            // check applicationSsh1 == applicationSsh2
            // check we have a private key for each device.
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
