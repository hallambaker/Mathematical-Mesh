using Goedel.Protocol;
using Goedel.Test.Core;
using Goedel.Test;
using Goedel.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using Goedel.Mesh.Test;

using Xunit;

#pragma warning disable IDE0051

namespace Goedel.XUnit {




    public partial class GoedelProtocolService {

        public static GoedelProtocolService Test() => new GoedelProtocolService();

        static GoedelProtocolService() {
            _ = Goedel.Cryptography.Core.Initialization.Initialized;
            }



        [Fact]
        public void TestService() {
            var TestEnvironmentCommon = new TestEnvironmentCommon();


            var testService = new TestService(TestEnvironmentCommon);

            }


        byte[] MakePayload(int size = 100) => new byte[size];


        }
    }
