using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Utilities;
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
        public override void Register(Register Options) {
            SetReporting(Options.Report, Options.Verbose);
            throw new NYI("");
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Sync(Sync Options) {
            SetReporting(Options.Report, Options.Verbose);
            throw new NYI("");
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Escrow(Escrow Options) {
            SetReporting(Options.Report, Options.Verbose);
            throw new NYI("");
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Export(Export Options) {
            SetReporting(Options.Report, Options.Verbose);
            throw new NYI("");
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Import(Import Options) {
            SetReporting(Options.Report, Options.Verbose);
            throw new NYI("");
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Mail(Mail Options) {
            SetReporting(Options.Report, Options.Verbose);
            throw new NYI("");
            }

        }
    }
