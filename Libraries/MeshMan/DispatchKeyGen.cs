using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Protocol;
using Goedel.Cryptography;
using Goedel.IO;
using Goedel.Mesh.Platform;

// This file is just a handy place to put my to do list of things
// that aren't yet implemented.
namespace Goedel.Mesh.MeshMan {



    public partial class Shell {

        /// <summary>
        /// Create an offline key escrow record and associated key shares.
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void KeyGen (KeyGen Options) {
            SetReporting(Options);


            var Algorithm = Options.Algorithm.Value;

            switch (Algorithm) {
                case null:
                case "":
                case "random": {
                    var Result = UDF.Random();
                    LastResult = new ResultKeyGenPassword() { UDF = Result };
                    ReportWrite(LastResult.ToString());
                    break;
                    }

                }

            }

        }
    }
