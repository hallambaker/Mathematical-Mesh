﻿using Goedel.Mesh.Client;
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


    public partial class ResultConnect {

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString() {
            var Builder = new StringBuilder();


            switch (CatalogedMachine) {

                case CatalogedPending catalogedPending: {
                    var messageConnectionResponse = AcknowledgeConnection.Decode(
                                catalogedPending.EnvelopedMessageConnectionResponse);
                    Builder.AppendLine($"   Device UDF = {catalogedPending.DeviceUDF}");
                    Builder.AppendLine($"   Witness value = {messageConnectionResponse.Witness}");

                    break;
                    }
                case CatalogedStandard catalogedStandard: {
                    break;
                    }
                case CatalogedAdmin catalogedAdmin: {
                    break;
                    }

                default:
                    break;
                }



            if (CatalogedMachine.EnvelopedProfileMaster != null) {

                var profileMaster = ProfileMesh.Decode(CatalogedMachine.EnvelopedProfileMaster);
                Builder.AppendLine($"   Personal Mesh = {profileMaster.UDF}");
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
                    if (respondConnection.Result == Constants.TransactionResultAccept) {
                        Builder.AppendLine($"Added device: {respondConnection.CatalogedDevice.DeviceUDF}");
                        }
                    break;
                    }

                default:
                    break;
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

                if (StatusResponse.EnvelopedProfileMaster != null) {
                    }
                if (StatusResponse.EnvelopedCatalogEntryDevice != null) {
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

                builder.AppendLine($"MessageID: {message.MessageID}");

                switch (message) {
                    case AcknowledgeConnection acknowledgeConnection: {
                        ToBuilder(builder, message, $"    Connection Request:");
                        builder.AppendLine($"        Device:  {acknowledgeConnection.MessageConnectionRequest.ProfileDevice.UDF}");
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
                    case ReplyContact replyContact: {
                        ToBuilder(builder, message, $"    Contact Reply:");
                        builder.AppendLine($"        Witness: {replyContact.Witness}->{replyContact.PinUDF}");
                        builder.AppendLine($"        Nonce: {replyContact.Nonce}");
                        break;
                        }
                    case RequestContact requestContact: {
                        ToBuilder(builder, message, $"    Contact Request:");
                        builder.AppendLine($"        PIN: {requestContact.PIN}->{requestContact.PinUDF}");
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


        void ToBuilder(StringBuilder builder, Message message, string tag) {
            builder.AppendLine($"    {tag}:");
            builder.AppendLine($"        MessageID: {message.MessageID}");
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
                Builder.Append($"PIN={MessagePIN.SaltedPIN}");

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
        public string Account => ActivationAccount?.AccountUDF;

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString() {
            var Builder = StringBuilder();
            Builder.AppendNotNull(Account, $"Account={Account}");
            return Builder.ToString();
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

        ///<summary>The <see cref="ConnectionDevice"/> instance.</summary>
        public ConnectionDevice ConnectionDevice = null;

        ///<summary>The <see cref="ActivationDevice"/> instance.</summary>
        public ActivationDevice PrivateDevice = null;

        ///<summary>The <see cref="AssertionAccount"/> instance.</summary>
        public ProfileAccount AssertionAccount = null;

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
