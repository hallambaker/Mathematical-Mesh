using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Mesh;
using Goedel.Mesh.Platform;

// This file is just a handy place to put my to do list of things
// that aren't yet implemented.
namespace Goedel.Mesh.MeshMan {



    public partial class Shell {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Export(Export Options) {
            SetReporting(Options);
            var RegistrationPersonal = GetPersonal(Options);

            var Filename = Options.File.Value;
            Assert.NotNull(Filename != null);

            Filename.WriteFileNew(RegistrationPersonal.SignedPersonalProfile.GetBytes());

            var ResultObject = new ResultExport();
            LastResult = ResultObject;
            ReportWrite(LastResult.ToString());
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Import(Import Options) {
            SetReporting(Options.Report, Options.Verbose);

            var ResultObject = new ResultImport();
            LastResult = ResultObject;
            ReportWrite(LastResult.ToString());

            throw new NYI("");
            }

        }
    }
