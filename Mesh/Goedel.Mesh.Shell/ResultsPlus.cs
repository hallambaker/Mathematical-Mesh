using Goedel.Mesh.Client;
using Goedel.Utilities;

using System.Text;

namespace Goedel.Mesh.Shell {

    public partial class ShellResult {

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/> with 
        /// additional details.
        /// </summary>
        /// <returns>The string value.</returns>
        public virtual string Verbose() => ToString();
        }

    public partial class Result {

        /// <summary>
        /// Default constructor, initialize the value <see cref="Success"/> to <see langword="true"/>.
        /// </summary>
        public Result() => Success = true;

        /// <summary>
        /// Returns a <see cref="StringBuilder"/> instance initialized with the success value and
        /// the expanded error message reason (if relevant).
        /// </summary>
        /// <returns>The <see cref="StringBuilder"/> instance.</returns>
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

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString() {
            var Builder = StringBuilder();

            return Builder.ToString();
            }



        }


    public partial class ResultKey {

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
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

    public partial class ResultReceived {

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString() {
            var Builder = new StringBuilder();


            switch (Message) {
                case null: {
                    Builder.AppendLine("Pending");
                    break;
                    }
                case ResponseConfirmation responseConfirmation: {
                    Builder.AppendLine(responseConfirmation.Accept ? "Accept" :  "Reject");
                    break;
                    }


                }





            return Builder.ToString();
            }
        }


    public partial class ResultDigest {

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
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

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString() {
            var Builder = new StringBuilder();

            if (Response != null) {


                if (Response.Version != null) {
                    Builder.AppendLine($"MeshService {Response.Version.Major}.{Response.Version.Minor}");
                    }
                if (Response.EnvelopedProfileService != null) {
                    var profileService = Response.EnvelopedProfileService.Decode();
                    Builder.AppendLine($"   Service UDF = {profileService.Udf}");
                    }
                if (Response.EnvelopedProfileHost != null) {
                    var profileHost = Response.EnvelopedProfileHost.Decode();
                    Builder.AppendLine($"   Host UDF = {profileHost.Udf}");
                    }
                }


            return Builder.ToString();
            }
        }


    public partial class ResultConnect {

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString() {
            var Builder = new StringBuilder();


            switch (CatalogedMachine) {

                case CatalogedPending catalogedPending: {
                    var acknowledgeConnection = 
                            catalogedPending.EnvelopedAcknowledgeConnection.Decode();
                    Builder.AppendLine($"   Device UDF = {catalogedPending.DeviceUDF}");
                    Builder.AppendLine($"   Witness value = {acknowledgeConnection.Witness}");

                    break;
                    }
                case CatalogedStandard catalogedStandard: {
                    Builder.AppendLine($"   Device UDF = {catalogedStandard.ProfileDevice.Udf}");

                    if (Profile is ProfileUser profileUser) {
                        Builder.AppendLine($"   Account = {profileUser.AccountAddress}");
                        }
                    Builder.AppendLine($"   Account UDF = {Profile.Udf}");

                    break;
                    }
                //case CatalogedAdmin catalogedAdmin: {
                //    break;
                //    }

                default:
                    break;
                }
            return Builder.ToString();
            }
        }


    public partial class ResultProcess {

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString() {
            var Builder = new StringBuilder();

            switch (ProcessResult) {
                case RespondConnection respondConnection: {
                    Builder.AppendLine($"Result: {respondConnection.Result}");
                    if (respondConnection.Result == MeshConstants.TransactionResultAccept) {
                        Builder.AppendLine($"Added device: {respondConnection.CatalogedDevice.DeviceUdf}");
                        }
                    break;
                    }

                default:
                    break;
                }
            return Builder.ToString();
            }
        }


    public partial class ResultSent {

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString() {
            var Builder = new StringBuilder();
            if (Message != null) {
                Builder.AppendLine($"Envelope ID: {Message.EnvelopeId}");
                Builder.AppendLine($"Message ID: {Message.MessageId}");
                Builder.AppendLine($"Response ID: {Message.GetResponseId()}");
                }
            return Builder.ToString();
            }
        }


    public partial class ResultStatus {

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString() {
            var Builder = new StringBuilder();

            if (StatusResponse != null) {

                if (StatusResponse.EnvelopedProfileAccount != null) {
                    }
                if (StatusResponse.EnvelopedCatalogedDevice != null) {
                    }
                if (StatusResponse.ContainerStatus != null) {
                    foreach (var containerStatus in StatusResponse.ContainerStatus) {
                        var digest = containerStatus.Digest == null ? "" :
                            containerStatus.Digest.ToStringBase32(format: ConversionFormat.Dash4, outputMax: 120);

                        Builder.Append($"   [{containerStatus.Container}] {containerStatus.Index}  {digest}");
                        Builder.AppendLine();
                        }
                    }
                }

            return Builder.ToString();
            }
        }


    public partial class ResultPending {

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString() {
            var builder = new StringBuilder();

            foreach (var message in Messages) {

                builder.AppendLine($"MessageID: {message.MessageId}");

                switch (message) {
                    case AcknowledgeConnection acknowledgeConnection: {
                        ToBuilder(builder, message, $"    Connection Request:");
                        builder.AppendLine($"        Device:  {acknowledgeConnection.MessageConnectionRequest.ProfileDevice.Udf}");
                        builder.AppendLine($"        Witness: {acknowledgeConnection.Witness}");
                        break;
                        }
                    case RequestConfirmation requestConfirmation: {
                        ToBuilder(builder, message, $"    Confirmation Request:");
                        builder.AppendLine($"        Text: {requestConfirmation.Text}");
                        break;
                        }
                    case ResponseConfirmation responseConfirmation: {
                        ToBuilder(builder, message, $"    Confirmation Reply:");
                        builder.AppendLine($"        RequestID: {responseConfirmation.Request.Header.EnvelopeID}");
                        builder.AppendLine($"        Accept: {responseConfirmation.Accept}");
                        break;
                        }
                    case RequestTask requestTask: {
                        ToBuilder(builder, message, $"    Task Request:");
                        requestTask.Future();
                        break;
                        }
                    //case ReplyContact replyContact: {
                    //        ToBuilder(builder, message, $"    Contact Reply:");
                    //    builder.AppendLine($"        Witness: {replyContact.PinWitness}->{replyContact.PinId}");
                    //    builder.AppendLine($"        Nonce: {replyContact.ClientNonce}");
                    //    break;
                    //    }
                    case Mesh.MessageContact requestContact: {
                        ToBuilder(builder, message, $"    Contact Request:");
                        builder.AppendLine($"        PIN: {requestContact.PIN}");
                        break;
                        }
                    case GroupInvitation groupInvitation: {
                        ToBuilder(builder, message, $"    Group invitation:");
                        groupInvitation.Future();
                        break;
                        }

                    default:
                        break;
                    }
                }

            return builder.ToString();
            }

        static void ToBuilder(StringBuilder builder, Message message, string tag) {
            builder.AppendLine($"    {tag}:");
            builder.AppendLine($"        MessageID: {message.MessageId}");
            builder.AppendLine($"        To: {message.Recipient} From: {message.Sender}");
            }

        }


    public partial class ResultPIN {

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString() {
            var Builder = new StringBuilder();

            if (Uri != null) {
                Builder.Append($"URI={Uri}");
                }

            else if (MessagePIN != null) {
                Builder.Append($"PIN={MessagePIN.SaltedPin}");

                if (MessagePIN.Expires != null) {
                    Builder.Append($" (Expires={MessagePIN.Expires.ToRFC3339()})");
                    }
                Builder.AppendLine();
                }


            return Builder.ToString();
            }
        }


    public partial class ResultCreateDevice {

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
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

        ///<summary>The account UDF.</summary>
        public string Account => ActivationDevice?.AccountUdf;

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString() {
            var builder = StringBuilder();
            builder.AppendNotNull(ProfileAccount?.AccountAddress, $"Account={ProfileAccount?.AccountAddress}");
            builder.AppendNotNull(ProfileAccount?.ProfileSignature?.Udf, $"UDF={ProfileAccount?.ProfileSignature?.Udf}");
            return builder.ToString();
            }
        }

    public partial class ResultRegisterService {

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString() {
            var Builder = StringBuilder();
            Builder.AppendNotNull(Account, $"Account={Account}");
            Builder.AppendNotNull(AccountAddress, $"AccountAddress={AccountAddress}");
            return Builder.ToString();
            }
        }

    public partial class ResultCreatePersonal {

        ///<summary>The <see cref="Mesh.ConnectionDevice"/> instance.</summary>
        public ConnectionDevice ConnectionUser = null;


        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString() {
            var Builder = StringBuilder();
            Builder.Append($"Device Profile UDF={DeviceUDF}\n");
            Builder.Append($"Personal Profile UDF={MeshUDF}\n");
            Builder.AppendNotNull(Account, $"Account={Account}");
            return Builder.ToString();
            }
        }


    public partial class ResultEntry {

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString() => CatalogEntry?.ToString() ?? "Empty\n";


        }

    public partial class ResultDump {

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString() {
            var builder = StringBuilder();
            foreach (var entry in CatalogedEntries) {
                entry.Describe(builder);
                builder.AppendLine();
                }
            return builder.ToString();
            }
        }


    public partial class ResultFileDare {

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString() {
            var builder = StringBuilder();
            builder.Append($"File: {Filename}\n");
            builder.Append($"    Bytes: {TotalBytes}\n");
            if (Envelope == null) {
                builder.Append($"    Error: Not a DARE envelope\n");
                }
            else {
                ToString(builder);
                }
            return builder.ToString();
            }

        void ToString(StringBuilder builder) {
            var header = Envelope?.Header;
            var trailer = Envelope?.Trailer;
            if (header?.Encrypt != null) {
                builder.Append($"    Encryption Algorithm: {header.EncryptionAlgorithm}\n");
                if (header.Recipients != null) {
                    foreach (var recipient in header.Recipients) {
                        builder.Append($"        Recipient: {recipient.KeyIdentifier}\n");
                        }
                    }
                }
            if (header?.DigestAlgorithm != null) {
                builder.Append($"    Digest Algorithm: {header.DigestAlgorithm}\n");
                builder.Append($"    Payload Digest: {trailer?.PayloadDigest?.ToStringBase16()}\n");
                if (trailer?.Signatures != null) {
                    foreach (var signature in trailer?.Signatures) {
                        builder.Append($"        Signer: {signature.KeyIdentifier}\n");
                        }
                    }
                }
            }
        }

    public partial class ResultEscrow {

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString() {
            var Builder = new StringBuilder();

            foreach (var share in Shares) {
                Builder.AppendLine($"Share: {share}");
                }

            return Builder.ToString();
            }
        }


    }
