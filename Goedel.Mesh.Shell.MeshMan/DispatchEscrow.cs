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

        /// <summary>
        /// Create an offline key escrow record and associated key shares.
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Escrow (Escrow Options) {
            SetReporting(Options);

            var RegistrationPersonal = GetPersonal(Options);

            var GotShares= int.TryParse(Options.Shares.Value, out var Shares);
            var GotQuorum = int.TryParse(Options.Quorum.Value, out var Quorum);
            Assert.True(GotShares & GotQuorum, InvalidEscrowParameters.Throw);
            Assert.True(Shares>=2 & Shares < 16, InvalidShares.Throw, Int: Shares);
            Assert.True((Quorum >= 1) & (Quorum <= Shares), InvalidQuorum.Throw, Int: Quorum);

            var OfflineEscrowEntry = new OfflineEscrowEntry(
                RegistrationPersonal.PersonalProfile, Shares, Quorum);
            // Push to the Portal

            Report("Created offline escrow entry Shares={0}, quorum={1}", Shares, Quorum);

            var Filename = Options.File.Value;
            if (Filename != null) {
                Filename.WriteFileNew(OfflineEscrowEntry.GetJson());
                Report("Written to file {0}", Filename);
                }
            else {
                var Escrow = RegistrationPersonal.Escrow(OfflineEscrowEntry);
                Report("Written to portal");
                }


            foreach (var Share in OfflineEscrowEntry.KeyShares) {
                Report("Share {0}", Share.Text);
                }
            }


        }
    }
