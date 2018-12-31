using System;
using System.Collections.Generic;
using Xunit;
using Goedel.Mesh.Shell;
using Goedel.Cryptography;
using Goedel.Mesh.Test;
using Goedel.Test.Core;
using Goedel.Test;
using Goedel.Utilities;


namespace Goedel.XUnit {
    public partial class ShellTests {


        public bool TestFile(string content, string contentType=null) {
            var testCLI = new TestCLI();
            var filename = content.ToFileUnique();
            var contentClause = contentType == null ? "" : $" /cty {contentType}";

            var result1 = testCLI.Dispatch($"dare encode {filename}{contentClause}") as ResultFile;
            var result2 = testCLI.Dispatch($"dare decode {result1.Filename}") as ResultFile;
            var result3 = testCLI.Dispatch($"dare verify {result1.Filename}") as ResultFile;


            return true;
            }




        }
    }
