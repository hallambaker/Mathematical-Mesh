using System.Text;
using Goedel.Utilities;
using Goedel.Mesh.Client;

namespace Goedel.Mesh.Shell {

    public partial class ShellResult {
        public virtual string Verbose() => ToString();
        }

    public partial class Result {

        public Result() => Success = true;

        public Result(string reason) {
            Success = true;
            Reason = reason;
            }


        public virtual StringBuilder StringBuilder() {
            var Builder = new StringBuilder();

            if (!Success) {
                Builder.Append("ERROR");
                if (Reason != null) {
                    Builder.Append(" - ");
                    Builder.Append(Reason);
                    }
                Builder.Append("\n");
                }
            return Builder;

            }

        public override string ToString() {
            var Builder = StringBuilder();

            return Builder.ToString();
            }

        

        }


    public partial class ResultKey {
        public override string ToString() {
            var Builder = new StringBuilder();

            if (Key != null) {
                Builder.AppendLine(Key);
                }
            if (Identifier != null) {
                Builder.AppendLine(Identifier);
                }
            if (Shares != null) {
                foreach (var share in Shares) {
                    Builder.AppendLine(share);
                    }
                }
            return Builder.ToString();
            }
        }

    public partial class ResultDigest {
        public override string ToString() {
            var Builder = new StringBuilder();

            if (Verified) {
                Builder.AppendLine($"{Success}");
                }
            else {
                if (Digest != null) {
                    Builder.AppendLine(Digest);
                    }
                if (Key != null) {
                    Builder.AppendLine(Key);
                    }
                }


            return Builder.ToString();
            }
        }

    public partial class ResultHello {
        public override string ToString() {
            var Builder = new StringBuilder();

            if (Response != null) {


                if (Response.Version != null) {
                    Builder.AppendLine($"MeshService {Response.Version.Major}.{Response.Version.Minor}");
                    }
                if (Response.EnvelopedProfileService != null) {
                    var profileService = ProfileService.Decode(Response.EnvelopedProfileService);
                    Builder.AppendLine($"   Service UDF = {profileService.UDF}");
                    }
                if (Response.EnvelopedProfileHost != null) {
                    var profileHost = ProfileHost.Decode(Response.EnvelopedProfileHost);
                    Builder.AppendLine($"   Host UDF = {profileHost.UDF}");
                    }
                }


            return Builder.ToString();
            }
        }


    public partial class ResultConnect{
        public override string ToString() {
            var Builder = new StringBuilder();


            switch (CatalogedMachine) {

                case CatalogedPending catalogedPending: {
                    var messageConnectionResponse = AcknowledgeConnection.Decode(
                                catalogedPending.EnvelopedMessageConnectionResponse);
                    Builder.AppendLine($"   Witness value = {messageConnectionResponse.Witness}");

                    break;
                    }
                case CatalogedStandard  catalogedStandard: {
                    break;
                    }
                case CatalogedAdmin catalogedAdmin: {
                    break;
                    }
                }



            if (CatalogedMachine.EnvelopedProfileMaster != null) {

                var profileMaster = ProfileMesh.Decode(CatalogedMachine.EnvelopedProfileMaster);
                Builder.AppendLine($"   Personal Mesh = {profileMaster.UDF}");
                }


            return Builder.ToString();
            }
        }


    public partial class ResultStatus {
        public override string ToString() {
            var Builder = new StringBuilder();

            if (StatusResponse != null) {

                if (StatusResponse.EnvelopedProfileMaster != null) {
                    }

                if (StatusResponse.EnvelopedAccountAssertion != null) {
                    }

                if (StatusResponse.EnvelopedCatalogEntryDevice != null) {
                    }
                if (StatusResponse.ContainerStatus != null) {
                    foreach (var containerStatus in StatusResponse.ContainerStatus) {

                        var digest = containerStatus.Digest == null ? "" :
                            containerStatus.Digest.ToStringBase32(Format: ConversionFormat.Dash4, OutputMax: 120);


                        Builder.Append($"   [{containerStatus.Container}] {containerStatus.Index}  {digest}");

                        

                        Builder.AppendLine();
                        }
                    }

                }



            return Builder.ToString();
            }
        }


    public partial class ResultPIN {
        public override string ToString() {
            var Builder = new StringBuilder();

            if (MessagePIN != null) {
                Builder.Append($"PIN={MessagePIN.PIN}");

                if (MessagePIN.Expires != null) {
                    Builder.Append($" (Expires={MessagePIN.Expires.ToRFC3339()})");

                    }
                Builder.AppendLine();

                }


            return Builder.ToString();
            }
        }


    public partial class ResultCreateDevice {

        public override string ToString() {
            var Builder = StringBuilder();
            Builder.Append($"Device Profile UDF={DeviceUDF}\n");
            return Builder.ToString();
            }
        }


    public partial class ResultCreateAccount {

        //public AssertionDeviceConnection ConnectionDevice = null;
        //public AssertionDevicePrivate PrivateDevice = null;
        //public AssertionAccount AssertionAccount = null;
        //CatalogEntryDevice.EnvelopedDevicePrivate.;

        public string Account => ActivationAccount?.AccountUDF;

        public override string ToString() {
            var Builder = StringBuilder();
            Builder.AppendNotNull(Account, $"Account={Account}");
            return Builder.ToString();
            }
        }

    public partial class ResultCreatePersonal {

        public ConnectionDevice ConnectionDevice = null;
        public ActivationDevice PrivateDevice = null;
        public ProfileAccount AssertionAccount = null;
        //CatalogEntryDevice.EnvelopedDevicePrivate.;



        public override string ToString() {
            var Builder = StringBuilder();
            Builder.Append($"Device Profile UDF={DeviceUDF}\n");
            Builder.Append($"Personal Profile UDF={MeshUDF}\n");
            Builder.AppendNotNull(Account, $"Account={Account}");
            return Builder.ToString();
            }
        }


    public partial class ResultEntry {
        public override string ToString() => CatalogEntry?.ToString() ?? "Empty\n";


        }

    public partial class ResultDump {
        public override string ToString() {
            var builder = StringBuilder();
            foreach (var entry in CatalogedEntries) {
                builder.Append(entry.ToString());
                //builder.AppendLine();
                }
            return builder.ToString();
            }
        //public override string ToString() => Data;
        }




    public partial class ResultEscrow {
        public override string ToString() {
            var Builder = new StringBuilder();

            foreach (var share in Shares) {
                Builder.AppendLine($"Share: {share}");
                }
            if (Filename != null) {
                Builder.AppendLine($"Written to {Filename}");
                }

            return Builder.ToString();
            }
        }




    public partial class ResultRecover {
        public override string ToString() {
            var Builder = new StringBuilder();

            //if (SignUDF != null) {
            //    Builder.AppendLine($"Signature Key: {SignUDF}");
            //    }
            //foreach (var key in EncryptUDF) {
            //    Builder.AppendLine($"Encryption Key: {key}");
            //    }


            return Builder.ToString();
            }
        }


    }
