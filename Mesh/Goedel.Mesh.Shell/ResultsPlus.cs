#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion

using System.Text;

using Goedel.Cryptography;
using Goedel.Mesh.Client;
using Goedel.Utilities;

namespace Goedel.Mesh.Shell {

    /// <summary>
    /// Information level to be returned in a result.
    /// </summary>
    public enum Verbosity {
        ///<summary>Minimal information, no additional text.</summary> 
        Terse,
        ///<summary>Standard descriptive result.</summary> 
        Standard,
        ///<summary>Verbose report with maximum information.</summary> 
        Full
        }

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
            var builder = new StringBuilder();

            if (!Success) {
                builder.Append("ERROR");
                if (Reason != null) {
                    builder.Append(" - ");
                    builder.Append(Reason);
                    }
                builder.Append("\n");
                }
            return builder;

            }

        ///<inheritdoc/>
        public override string ToString() {
            var builder = StringBuilder();
            ToBuilder(builder);
            return builder.ToString();
            }

        /// <summary>
        /// Append the description of the report to <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The builder to return the report to.</param>
        /// <param name="verbosity">The level of detail to return.</param>
        public virtual void ToBuilder(StringBuilder builder, Verbosity verbosity= Verbosity.Standard) {
            }
        }


    public partial class ResultKey {

        ///<inheritdoc/>
        public override void ToBuilder(StringBuilder builder, Verbosity verbosity = Verbosity.Standard) {

            if (Key != null) {
                builder.AppendLine(Key);
                }
            if (Identifier != null) {
                builder.AppendLine(Identifier);
                }
            if (Shares != null) {
                foreach (var share in Shares) {
                    builder.AppendLine(share);
                    }
                }
            }
        }

    public partial class ResultReceived {

        ///<inheritdoc/>
        public override void ToBuilder(StringBuilder builder, Verbosity verbosity = Verbosity.Standard) {



            switch (Message) {
                case null: {
                    builder.AppendLine("Pending");
                    break;
                    }
                case ResponseConfirmation responseConfirmation: {
                    builder.AppendLine(responseConfirmation.Accept ? "Accept" : "Reject");
                    break;
                    }


                }

            }
        }


    public partial class ResultDigest {

        ///<inheritdoc/>
        public override void ToBuilder(StringBuilder builder, Verbosity verbosity = Verbosity.Standard) {


            if (Verified) {
                builder.AppendLine($"{Success}");
                }
            else {
                if (Digest != null) {
                    builder.AppendLine(Digest);
                    }
                if (Key != null) {
                    builder.AppendLine(Key);
                    }
                }

            }
        }

    public partial class ResultHello {

        ///<inheritdoc/>
        public override void ToBuilder(StringBuilder builder, Verbosity verbosity = Verbosity.Standard) {


            if (Response != null) {


                if (Response.Version != null) {
                    builder.AppendLine($"MeshService {Response.Version.Major}.{Response.Version.Minor}");
                    }
                if (Response.EnvelopedProfileService != null) {
                    var profileService = Response.EnvelopedProfileService.Decode();
                    builder.AppendLine($"   Service UDF = {profileService.Udf}");
                    }
                if (Response.EnvelopedProfileHost != null) {
                    var profileHost = Response.EnvelopedProfileHost.Decode();
                    builder.AppendLine($"   Host UDF = {profileHost.Udf}");
                    }
                }


            }
        }


    public partial class ResultConnect {

        ///<inheritdoc/>
        public override void ToBuilder(StringBuilder builder, Verbosity verbosity = Verbosity.Standard) {



            switch (CatalogedMachine) {

                case CatalogedPending catalogedPending: {
                    var acknowledgeConnection =
                            catalogedPending.EnvelopedAcknowledgeConnection.Decode();
                    builder.AppendLine($"   Device UDF = {catalogedPending.DeviceUDF}");
                    builder.AppendLine($"   Witness value = {acknowledgeConnection.Witness}");

                    break;
                    }
                case CatalogedStandard catalogedStandard: {
                    builder.AppendLine($"   Device UDF = {catalogedStandard.ProfileDevice.Udf}");

                    if (Profile is ProfileUser profileUser) {
                        builder.AppendLine($"   Account = {profileUser.AccountAddress}");
                        }
                    builder.AppendLine($"   Account UDF = {Profile.Udf}");

                    break;
                    }
                //case CatalogedAdmin catalogedAdmin: {
                //    break;
                //    }

                default:
                break;
                }

            }
        }


    public partial class ResultProcess {

        ///<inheritdoc/>
        public override void ToBuilder(StringBuilder builder, Verbosity verbosity = Verbosity.Standard) {


            switch (ProcessResult) {
                case RespondConnection respondConnection: {
                    builder.AppendLine($"Result: {respondConnection.Result}");
                    if (respondConnection.Result == MeshConstants.TransactionResultAccept) {
                        builder.AppendLine($"Added device: {respondConnection.CatalogedDevice.DeviceUdf}");
                        }
                    break;
                    }

                default:
                break;
                }

            }
        }


    public partial class ResultSent {

        ///<inheritdoc/>
        public override void ToBuilder(StringBuilder builder, Verbosity verbosity = Verbosity.Standard) {

            if (Message != null) {
                builder.AppendLine($"Envelope ID: {Message.EnvelopeId}");
                builder.AppendLine($"Message ID: {Message.MessageId}");
                builder.AppendLine($"Response ID: {Message.GetResponseId()}");
                }

            }
        }


    public partial class ResultStatus {

        ///<inheritdoc/>
        public override void ToBuilder(StringBuilder builder, Verbosity verbosity = Verbosity.Standard) {


            if (StatusResponse != null) {

                if (StatusResponse.EnvelopedProfileAccount != null) {
                    }
                if (StatusResponse.EnvelopedCatalogedDevice != null) {
                    }
                if (StatusResponse.ContainerStatus != null) {
                    foreach (var containerStatus in StatusResponse.ContainerStatus) {
                        var digest = containerStatus.Digest == null ? "" :
                            containerStatus.Digest.ToStringBase32(format: ConversionFormat.Dash4, outputMax: 120);

                        builder.Append($"   [{containerStatus.Container}] {containerStatus.Index}  {digest}");
                        builder.AppendLine();
                        }
                    }
                }

            }
        }


    public partial class ResultPending {

        ///<inheritdoc/>
        public override void ToBuilder(StringBuilder builder, Verbosity verbosity = Verbosity.Standard) {


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
                        builder.AppendLine($"        RequestID: {responseConfirmation.Request.Header.EnvelopeId}");
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

            }

        static void ToBuilder(StringBuilder builder, Message message, string tag) {
            builder.AppendLine($"    {tag}:");
            builder.AppendLine($"        MessageID: {message.MessageId}");
            builder.AppendLine($"        To: {message.Recipient} From: {message.Sender}");
            }

        }


    public partial class ResultPIN {

        ///<inheritdoc/>
        public override void ToBuilder(StringBuilder builder, Verbosity verbosity = Verbosity.Standard) {


            if (Uri != null) {
                builder.Append($"URI={Uri}");
                }

            else if (MessagePIN != null) {
                builder.Append($"PIN={MessagePIN.Pin}");

                if (MessagePIN.Expires != null) {
                    builder.Append($"\n (Expires={MessagePIN.Expires.ToRFC3339()})");
                    }
                builder.AppendLine();
                }

            }
        }


    public partial class ResultCreateDevice {

        ///<inheritdoc/>
        public override void ToBuilder(StringBuilder builder, Verbosity verbosity = Verbosity.Standard) {

            builder.Append($"Device Profile UDF={DeviceUDF}\n");

            }
        }


    public partial class ResultCreateAccount {

        ///<summary>The account UDF.</summary>
        public string Account => ActivationDevice?.AccountUdf;

        ///<inheritdoc/>
        public override void ToBuilder(StringBuilder builder, Verbosity verbosity = Verbosity.Standard) {

            builder.AppendNotNull(ProfileAccount?.AccountAddress, $"Account={ProfileAccount?.AccountAddress}");
            builder.AppendNotNull(ProfileAccount?.ProfileSignature?.Udf, $"UDF={ProfileAccount?.ProfileSignature?.Udf}");

            }
        }

    public partial class ResultRegisterService {

        ///<inheritdoc/>
        public override void ToBuilder(StringBuilder builder, Verbosity verbosity = Verbosity.Standard) {
            builder.AppendNotNull(Account, $"Account={Account}");
            builder.AppendNotNull(AccountAddress, $"AccountAddress={AccountAddress}");

            }
        }

    public partial class ResultCreatePersonal {

        ///<summary>The <see cref="Mesh.ConnectionService"/> instance.</summary>
        public ConnectionService ConnectionUser = null;


        ///<inheritdoc/>
        public override void ToBuilder(StringBuilder builder, Verbosity verbosity = Verbosity.Standard) {

            builder.Append($"Device Profile UDF={DeviceUDF}\n");
            builder.Append($"Personal Profile UDF={MeshUDF}\n");
            builder.AppendNotNull(Account, $"Account={Account}\n");

            }
        }


    public partial class ResultEntry {

        ///<inheritdoc/>
        public override string ToString() => CatalogEntry?.ToString() + "\n" ?? "Empty\n";


        }

    public partial class ResultDump {
        ///<inheritdoc/>
        public override void ToBuilder(StringBuilder builder, Verbosity verbosity = Verbosity.Standard) {

            foreach (var entry in CatalogedEntries) {
                entry.Describe(builder);
                builder.AppendLine();
                }

            }
        }


    public partial class ResultFileDare {

        ///<inheritdoc/>
        public override void ToBuilder(StringBuilder builder, Verbosity verbosity = Verbosity.Standard) {

            builder.Append($"File: {Filename}\n");
            builder.Append($"    Bytes: {TotalBytes}\n");
            if (Envelope == null) {
                builder.Append($"    Error: Not a DARE envelope\n");
                }
            else {
                ToString(builder);
                }

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

        ///<inheritdoc/>
        public override void ToBuilder(StringBuilder builder, Verbosity verbosity = Verbosity.Standard) {


            foreach (var share in Shares) {
                builder.AppendLine($"Share: {share}");
                }


            }
        }

    public partial class ResultApplication {

        ///<inheritdoc/>
        public override void ToBuilder(StringBuilder builder, Verbosity verbosity = Verbosity.Standard) {


            Application.ToBuilder(builder);

            }

        }


    public partial class ResultApplicationList {

        ///<inheritdoc/>
        public override void ToBuilder(StringBuilder builder, Verbosity verbosity = Verbosity.Standard) {

            foreach (var application in Applications) {
                application.ToBuilder(builder);
                }
            }

        }
    }
