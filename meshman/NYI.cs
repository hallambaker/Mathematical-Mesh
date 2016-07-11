using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Goedel.Mesh;
using Goedel.Mesh.Platform;

// This file is just a handy place to put my to do list of things
// that aren't yet implemented.
namespace Goedel.Mesh.MeshMan {



    public partial class Shell {

        public MeshClient GetMeshClient() {
            return GetMeshClient(PortalID);
            }


        /// <summary>
        /// Bind to the Mesh client for the specified portal account
        /// </summary>
        /// <param name="PortalID"></param>
        /// <returns></returns>
        public MeshClient GetMeshClient(string PortalID) {
            this.PortalID = PortalID;

            Utilities.Assert(PortalID != null, "No Portal account specified");
            Account.SplitAccountID(PortalID, out AccountID, out Portal);
            Utilities.Assert(AccountID != null | Portal != null, "[{0}] is not a valid portal address");

            MeshClient = new MeshClient(Portal);
            Utilities.Assert(MeshClient != null, "Could not connect to portal {0}", Portal);

            return MeshClient;
            }

        /// <summary>
        /// Rough draft, I think this is correct but can't check now 
        /// as the server is accepting everything.
        /// </summary>
        private void GetNextAccount() {

            int Base = 1;
            int Index = 1;

            bool Found = CheckAccount (Index);
            if (Found) {
                AccountID = MakeAccountID(Index);
                return;
                }

            while (!Found) {
                Base = Index;
                Index = Index * 2;
                Found = CheckAccount(Index);
                }
            while (Index > 2) {
                Index = Index / 2;
                Found = CheckAccount(Base + Index);
                if (!Found) {
                    Base = Base + Index;
                    }
                }
            AccountID = MakeAccountID(Base + Index);


            Utilities.NYI("Generate new identifer if original is taken");

            }

        private string MakeAccountID(int I) {
            return AccountID + "_" + I.ToString("x");
            }

        private bool CheckAccount(int I) {
            var TestID = MakeAccountID(I);
            var AccountAvailable = MeshClient.Validate(AccountID);
            return AccountAvailable.Valid;
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Register(Register Options) {
            SetReporting(Options.Report, Options.Verbose);
            Utilities.NYI();
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Sync(Sync Options) {
            SetReporting(Options.Report, Options.Verbose);
            Utilities.NYI();
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Escrow(Escrow Options) {
            SetReporting(Options.Report, Options.Verbose);
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Export(Export Options) {
            SetReporting(Options.Report, Options.Verbose);
            Utilities.NYI();
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Import(Import Options) {
            SetReporting(Options.Report, Options.Verbose);
            Utilities.NYI();
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Mail(Mail Options) {
            SetReporting(Options.Report, Options.Verbose);
            Utilities.NYI();
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void SSH(SSH Options) {
            SetReporting(Options.Report, Options.Verbose);
            Utilities.NYI();
            }

        }
    }
