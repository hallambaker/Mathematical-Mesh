using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Mesh.Platform;

// This file is just a handy place to put my to do list of things
// that aren't yet implemented.
namespace Goedel.Mesh.MeshMan {



    public partial class Shell {

        public OfflineEscrowEntry OfflineEscrowEntry;

        /// <summary>
        /// Create an offline key escrow record and associated key shares.
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Escrow (Escrow Options) {
            SetReporting(Options);

            var RegistrationPersonal = GetPersonal(Options);

            var Shares = Options.Shares.Value;
            var Quorum =Options.Quorum.Value;
            Assert.True(Shares>=2 & Shares < 16, InvalidShares.Throw, Int: Shares);
            Assert.True((Quorum >= 1) & (Quorum <= Shares), InvalidQuorum.Throw, Int: Quorum);

            OfflineEscrowEntry = new OfflineEscrowEntry(
                RegistrationPersonal.PersonalProfile, Shares, Quorum);
            // Push to the Portal

            var ResultEscrow = new ResultEscrow() {
                Shares = new List<string>(),
                Quorum = Quorum
                };
            LastResult = ResultEscrow;

            ReportWriteLine("Created offline escrow entry Shares={0}, quorum={1}", Shares, Quorum);

            var Filename = Options.File.Value;
            if (Filename != null) {
                ResultEscrow.Filename = Filename;
                Filename.WriteFileNew(OfflineEscrowEntry.GetJson());
                ReportWriteLine("Written to file {0}", Filename);
                }
            else {
                ResultEscrow.Portal = true;
                var Escrow = RegistrationPersonal.Escrow(OfflineEscrowEntry);
                ReportWriteLine("Written to portal");
                }


            foreach (var Share in OfflineEscrowEntry.KeyShares) {
                ResultEscrow.Shares.Add(Share.Text);
                }


            ReportWrite(LastResult.ToString());
            }

        public override void Recover (Recover Options) {
            var ResultRecover = new ResultRecover();
            LastResult = ResultRecover;
            ReportWrite(LastResult.ToString());

            //throw new NYI();
            }
        }
    }
