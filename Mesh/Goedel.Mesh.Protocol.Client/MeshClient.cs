using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Mesh.Protocol;
using Goedel.Protocol;
using Goedel.Cryptography.Dare;

namespace Goedel.Mesh.Protocol.Client {



    public partial class MeshResult {



        public bool Success => MeshResponse.Success();
        public bool Error => MeshResponse.Error();

        public void AssertSuccess() => Success.AssertTrue(ExpectedSuccess.Throw);
        public void AssertError() => Error.AssertTrue(ExpectedError.Throw);

        public void CheckResponse() => throw new NYI();

        public Response MeshResponse;
        }
    public partial class MeshResultConnect : MeshResult {
        public string Witness;
        }
    }
