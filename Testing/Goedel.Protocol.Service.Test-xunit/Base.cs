using Goedel.Protocol;
using Goedel.Test.Core;
using Goedel.Test;
using Goedel.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using Goedel.Protocol.Service;

using Xunit;

#pragma warning disable IDE0051

namespace Goedel.XUnit {

    public partial class GoedelProtocolService {

        public static GoedelProtocolService Test() => new GoedelProtocolService();


        [Fact]
        public void TestService() {
            var testService = new TestService();

            }
        }
    }
