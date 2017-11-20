using System.Text;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Mesh;

namespace Goedel.Mesh.MeshMan {

    public partial class ResultBase {

        protected void Append (StringBuilder Builder,
                        string ProfileUDF,
                        SignedConnectionRequest Request) {
            var Device = Request.Data.Device;
            var Authenticator = UDF.FromUDFPair(
                    Device.UDF,
                    ProfileUDF
                    );
            Builder.Append("Connect Request  ");
            Builder.Append(Authenticator);
            Builder.Append("\n    Device       ");
            Builder.Append(Device.UDF);
            Builder.Append("\n    Profile  ");
            Builder.Append(ProfileUDF);
            Builder.Append("\n");
            }

        }

    public partial class ResultKeyGenPassword {

        public override string ToString () {
            var Builder = new StringBuilder();

            Builder.Append(UDF);
            Builder.Append("\n");

            return Builder.ToString();
            }

        }

    
    public partial class ResultConnectStart {
        public string Authenticator => UDF.FromUDFPair(
            Request?.Data?.Device?.UDF,
            ProfileUDF
            );

        public override string ToString () {
            var Builder = new StringBuilder();
            Append(Builder, ProfileUDF, Request);

            return Builder.ToString();
            }

        }


    public partial class ResultConnectPending {

        public override string ToString () {
            var Builder = new StringBuilder();
            Builder.Append("\n");

            if (Response.Pending == null | Response?.Pending.Count == 0) {
                Builder.Append("No connection requests pending\n");
                }
            else {
                foreach (var Request in Response.Pending) {
                    Append(Builder, ProfileUDF, Request);
                    }
                }
            return Builder.ToString();
            }

        }
    public partial class ResultConnectAccept {

        public string Authenticator => UDF.FromUDFPair(
                    Request?.Data?.Device?.UDF,
                    ProfileUDF
                    );

        public override string ToString () {
            var Builder = new StringBuilder();
            Append(Builder, ProfileUDF, Request);

            return Builder.ToString();
            }

        }
    public partial class ResultConnectComplete {

        public override string ToString () {
            var Builder = new StringBuilder();

            if (Response.Result == null) {
                Builder.Append("Still pending\n");
                }
            else {
                Builder.Append("Accepted\n");
                }

            

            return Builder.ToString();
            }

        }
    public partial class ResultEscrow {

        public override string ToString () {
            var Builder = new StringBuilder();

            Builder.Append($"Created offline escrow entry Shares={Shares.Count}, quorum={Quorum}\n");

            if (Filename != null) {
                Builder.Append("Written to file ");
                Builder.Append(Filename);
                Builder.Append("\n");
                }
            if (Portal) {
                Builder.Append("Written to portal\n");
                }

            foreach (var Share in Shares) {
                Builder.Append(Share);
                Builder.Append("\n");
                }


            return Builder.ToString();
            }

        }

    public partial class ResultRecover {

        public override string ToString () {
            var Builder = new StringBuilder();
            Builder.Append("\n");

            return Builder.ToString();
            }

        }

    // SSH 
    public partial class ResultApplicationCreate {

        public override string ToString () {
            var Builder = new StringBuilder();
            Builder.Append($"Created new profile {ApplicationProfile.UDF}\n");

            return Builder.ToString();
            }

        }
    public partial class ResultSSHKnown {

        public override string ToString () {
            
            if (SSHProfile == null) {
                return ("No SSH Profile found.\n");
                }
            else if (SSHProfile.Private == null) {
                return ("The specified SSH profile does not have an entry for this device.\n");
                }

            var Builder = new StringBuilder();
            var Private = SSHProfile.Private;
            Builder.Append($"{Private.HostEntries.Count} Entries found\n");
            foreach (var Host in Private.HostEntries) {
                Builder.Append($"Host {Host.Identifier}\n");
                }


            return Builder.ToString();
            }

        }
    public partial class ResultSSHAuth {

        public override string ToString () {

            if (SSHProfile == null) {
                return ("No SSH Profile found.\n");
                }
            else if (SSHProfile.Private == null) {
                return ("The specified SSH profile does not have an entry for this device.\n");
                }

            var Builder = new StringBuilder();
            Builder.Append("\n");

            return Builder.ToString();
            }

        }
    public partial class ResultSSHPublic {

        public override string ToString () {

            if (SSHProfile == null) {
                return ("No SSH Profile found.\n");
                }
            else if (SSHProfile.Private == null) {
                return ("The specified SSH profile does not have an entry for this device.\n");
                }


            var Builder = new StringBuilder();
            Builder.Append($"Public key of {SSHProfile.UDF} written to {Filename}\n");

            return Builder.ToString();
            }

        }
    public partial class ResultSSHPrivate {


        public override string ToString () {
            if (SSHProfile == null) {
                return ("No SSH Profile found.\n");
                }
            else if (SSHProfile.Private == null) {
                return ("The specified SSH profile does not have an entry for this device.\n");
                }

            var Builder = new StringBuilder();
            Builder.Append($"Private key of {SSHProfile.UDF} written to {Filename}\n");


            return Builder.ToString();
            }

        }
    public partial class ResultMailCreate {

        public override string ToString () {
            var Builder = new StringBuilder();
            Builder.Append("\n");

            return Builder.ToString();
            }

        }

    public partial class ResultExport {

        public override string ToString () {
            var Builder = new StringBuilder();
            Builder.Append("\n");

            return Builder.ToString();
            }

        }
    public partial class ResultImport {

        public override string ToString () {
            var Builder = new StringBuilder();
            Builder.Append("\n");

            return Builder.ToString();
            }

        }

    }
