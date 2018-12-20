using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;

using Goedel.Cryptography.Dare;

namespace Goedel.Mesh.Shell {
    public partial class DareShell : _DareShell {


        static void Main(string[] Args) {
            var CLI = new CommandLineInterpreter();
            var Dispatch = new DareShell();
            CLI.MainMethod(Dispatch, Args);
            }

        public DareShell() {
            //MeshAsync.Initialize();                 // To parse async messaging
            //MeshCatalog.Initialize();                 // To parse async messaging
            //MeshRecrypt.Initialize();               // To parse recryption profiles
            //Goedel.Mesh.Mesh.Initialize(true);
            }

        ShellDispatch SetShell(Goedel.Command.Dispatch Options) {
            var Result = new ShellDispatch();

            if (Options is IReporting Reporting) {
                Result.Verbose = Reporting.Verbose.Value;
                Result.Report = Reporting.Report.Value;
                Result.Json = Reporting.Json.Value;
                }

            if (Options is IAccountOptions AccountOptions) {
                Result.AccountID = AccountOptions.AccountID.Value;
                Result.UDF = AccountOptions.UDF.Value;
                // Set the account here using MeshMachine
                }

            if (Options is IDeviceProfileInfo DeviceProfileInfo) {
                Result.DeviceNew = DeviceProfileInfo.DeviceNew.Value;
                Result.DeviceUDF = DeviceProfileInfo.DeviceUDF.Value;
                Result.DeviceID = DeviceProfileInfo.DeviceID.Value;
                Result.DeviceDescription = DeviceProfileInfo.DeviceDescription.Value;
                // Set the Device profile here
                }

            if (Options is IMailOptions MailOptions) {
                }

            if (Options is IPublicKeyOptions PublicKeyOptions) {
                }

            if (Options is IPrivateKeyOptions PrivateKeyOptions) {
                }

            return Result;
            }

        public List<string> Signers(IEncryptOptions Options) =>
            (Options.Signer.Value == null) ? null : new List<string> { Options.Signer.Value };
        public List<string> Recipients(IEncryptOptions Options) =>
            (Options.Recipient.Value == null) ? null : new List<string> { Options.Recipient.Value };


        public KeyCollection KeyCollection(IAccountOptions Options) => 
                    Cryptography.Jose.KeyCollection.Default;

        public CryptoParameters CryptoParameters(IEncryptOptions Options) =>
            throw new NYI();

        #region // Profile
        public override void ProfileReset(ProfileReset Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.ProfileReset(
                );
            }

        public override void DeviceCreate(DeviceCreate Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.DeviceCreate(
                    Options.DeviceID.Value, 
                    Options.DeviceDescription.Value, 
                    Options.Default.Value);
            }

        public override void PersonalCreate(PersonalCreate Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.PersonalCreate(
                Options.NewAccountID.Value
                );
            }

        public override void ProfileRegister(ProfileRegister Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.ProfileRegister(
                Options.NewAccountID.Value
                );
            }

        public override void ProfileSync(ProfileSync Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.ProfileSync(
                );
            }

        public override void ProfileEscrow(ProfileEscrow Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.ProfileEscrow(
                Options.Quorum.Value,
                Options.Shares.Value
                );
            }

        void AddIfPresent(String Share, List<string> Shares) {
            if (Share.Text != null) {
                Shares.Add(Share.Text);
                }
            }

        public override void ProfileRecover(ProfileRecover Options) {
            var ShellDispatch = SetShell(Options);
            var Shares = new List<string>();
            AddIfPresent(Options.Share1, Shares);
            AddIfPresent(Options.Share2, Shares);
            AddIfPresent(Options.Share3, Shares);
            AddIfPresent(Options.Share4, Shares);
            AddIfPresent(Options.Share5, Shares);
            AddIfPresent(Options.Share6, Shares);
            AddIfPresent(Options.Share7, Shares);
            AddIfPresent(Options.Share8, Shares);

            ShellDispatch.ProfileRecover(
                    Options.File.Value,
                    Shares
                    );
            }

        public override void ProfileExport(ProfileExport Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.ProfileExport(
                Options.File.Value
                );
            }

        public override void ProfileImport(ProfileImport Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.ProfileImport(
                Options.File.Value
                );
            }

        public override void ProfileList(ProfileList Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.ProfileList(
                );
            }

        public override void ProfileDump(ProfileDump Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.ProfileDump(
                );
            }

        public override void ProfilePending(ProfilePending Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.ProfilePending(
                );
            }

        public override void ProfileConnect(ProfileConnect Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.ProfileConnect(
                Options.Portal.Value,
                Options.PIN.Value
                );
            }

        public override void ProfileAccept(ProfileAccept Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.ProfileAccept(
                Options.CompletionCode.Value
                );
            }

        public override void ProfileReject(ProfileReject Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.ProfileReject(
                Options.CompletionCode.Value
                );
            }

        public override void ProfileGetPIN(ProfileGetPIN Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.ProfileGetPIN(
                Options.Length.Value
                );
            }

        public override void ProfileComplete(ProfileComplete Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.ProfileComplete(
                );
            }
        #endregion
        #region // Password
        public override void PasswordAdd(PasswordAdd Options) {
            var ShellDispatch = SetShell(Options);
            var Result = ShellDispatch.PasswordAdd(
                Options.Site.Value,
                Options.Username.Value,
                Options.Password.Value
                );
            ShellDispatch.ReportResult(Result);
            }

        public override void PasswordGet(PasswordGet Options) {
            var ShellDispatch = SetShell(Options);
            var Result = ShellDispatch.PasswordGet(
                Options.Site.Value
                );
            ShellDispatch.ReportResult(Result);
            }

        public override void PasswordDelete(PasswordDelete Options) {
            var ShellDispatch = SetShell(Options);
            var Result = ShellDispatch.PasswordDelete(
                Options.Site.Value
                );
            ShellDispatch.ReportResult(Result);
            }

        public override void PasswordDump(PasswordDump Options) {
            var ShellDispatch = SetShell(Options);
            var Result = ShellDispatch.PasswordDump(
                );
            ShellDispatch.ReportResult(Result);
            }
        #endregion
        #region // Contact
        public override void ContactAdd(ContactAdd Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.ContactAdd(
                Options.File.Value
                );
            }

        public override void ContactDelete(ContactDelete Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.ContactDelete(
                Options.Identifier.Value
                );
            }
        public override void ContactdGet(ContactdGet Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.ContactdGet(
                Options.Identifier.Value
                );
            }
        public override void ContactDump(ContactDump Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.ContactDump(
                );
            }
        #endregion
        #region // Bookmark
        public override void BookmarkAdd(BookmarkAdd Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.BookmarkAdd(
                Options.Uri.Value,
                Options.Title.Value,
                Options.Path.Value
                );
            }

        public override void BookmarkDelete(BookmarkDelete Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.BookmarkDelete(
                Options.Uri.Value,
                Options.Path.Value
                );
            }

        public override void BookmarkDump(BookmarkDump Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.BookmarkDump(
                );
            }
        #endregion
        #region // Calendar
        public override void CalendarAdd(CalendarAdd Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.CalendarAdd(
                Options.File.Value
                );
            }

        public override void CalendarDelete(CalendarDelete Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.CalendarDelete(
                Options.Identifier.Value
                );
            }

        public override void CalendarDump(CalendarDump Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.CalendarDump(
                );
            }
        #endregion
        #region // Network
        public override void NetworkAdd(NetworkAdd Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.NetworkAdd(
                Options.File.Value
                );
            }

        public override void NetworkDelete(NetworkDelete Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.NetworkDelete(
                Options.Identifier.Value
                );
            }

        public override void NetworkDump(NetworkDump Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.NetworkDump(
                );
            }
        #endregion
        #region // Group
        public override void GroupAdd(GroupAdd Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.GroupAdd(
                Options.GroupID.Value
                );
            }

        public override void GroupCreate(GroupCreate Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.GroupCreate(
                Options.GroupID.Value
                );
            }

        public override void GroupUser(GroupUser Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.GroupUser(
                Options.GroupID.Value,
                Options.MemberID.Value
                );
            }

        public override void GroupDelete(GroupDelete Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.GroupDelete(
                Options.GroupID.Value,
                Options.MemberID.Value
                );
            }
        #endregion
        #region // Mail
        public override void MailAdd(MailAdd Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.MailAdd(
                Options.Address.Value
                );
            }

        public override void MailUpdate(MailUpdate Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.MailUpdate(
                Options.Address.Value
                );
            }

        public override void SMIMEPrivate(SMIMEPrivate Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.SMIMEPrivate(
                Options.Address.Value
                );
            }

        public override void SMIMEPublic(SMIMEPublic Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.SMIMEPublic(
                Options.Address.Value
                );
            }

        public override void PGPPrivate(PGPPrivate Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.PGPPrivate(
                Options.Address.Value
                );
            }

        public override void PGPPublic(PGPPublic Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.PGPPublic(
                Options.Address.Value
                );
            }

        #endregion
        #region // SSH
        public override void SSHAddHost(SSHAddHost Options) {
            var ShellDispatch = SetShell(Options);
            //ShellDispatch.SSHAdd(
            //    Options.Host.Value,
            //    Options.Client.Value
            //    );
            }
        public override void SSHAddClient(SSHAddClient Options) {
            var ShellDispatch = SetShell(Options);
            //ShellDispatch.SSHAdd(
            //    Options.Host.Value,
            //    Options.Client.Value
            //    );
            }
        public override void SSHHost(SSHHost Options) {
            var ShellDispatch = SetShell(Options);
            //ShellDispatch.SSHAdd(
            //    Options.Host.Value,
            //    Options.Client.Value
            //    );
            }
        public override void SSHCreate(SSHCreate Options) {
            var ShellDispatch = SetShell(Options);
            //ShellDispatch.SSHAdd(
            //    Options.Host.Value,
            //    Options.Client.Value
            //    );
            }

        public override void SSHKnown(SSHKnown Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.SSHKnown(
                );
            }

        public override void SSHAuth(SSHAuth Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.SSHAuth(
                );
            }

        public override void SSHPublic(SSHPublic Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.SSHPublic(
                );
            }

        public override void SSHPrivate(SSHPrivate Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.SSHPrivate(
                );
            }
        #endregion
        #region // Message
        public override void MessageConnect(MessageConnect Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.MessageConnect(
                Options.Recipient.Value
                );
            }

        public override void MessageConfirm(MessageConfirm Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.MessageConfirm(
                Options.Recipient.Value
                );
            }

        public override void MessageStatus(MessageStatus Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.MessageStatus(
                Options.RequestID.Value
                );
            }

        public override void MessagePending(MessagePending Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.MessagePending(
                );
            }

        public override void MessageAccept(MessageAccept Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.MessageAccept(
                Options.RequestID.Value
                );
            }

        public override void MessageReject(MessageReject Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.MessageReject(
                Options.RequestID.Value
                );
            }

        public override void MessageBlock(MessageBlock Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.MessageBlock(
                Options.RequestID.Value
                );
            }
        #endregion      
        #region // File
        public override void FileEncrypt(FileEncrypt Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.FileEncrypt(
                CryptoParameters(Options),
                Options.Input.Value,
                Options.Output.Value,
                Options.Subdirectories.Value
                );
            }

        public override void FileDecrypt(FileDecrypt Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.FileDecrypt(
                KeyCollection(Options)
,
                Options.Input.Value,
                Options.Output.Value);
            }
        #endregion
        #region // Container
        public override void ContainerCreate(ContainerCreate Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.ContainerCreate(
                Options.Output.Value,
                CryptoParameters(Options)
                );
            }

        public override void ContainerArchive(ContainerArchive Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.ContainerArchive(
                CryptoParameters(Options),
                Options.Output.Value,
                Options.Input.Value);
            }

        public override void ContainerAppend(ContainerAppend Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.ContainerAppend(
                CryptoParameters(Options),
                Options.Input.Value,
                Options.Output.Value);
            }

        public override void ContainerExtract(ContainerExtract Options) {
            var ShellDispatch = SetShell(Options);

            var Record = Options.Record.Value;

            ShellDispatch.ContainerExtract(
                KeyCollection(Options),
                Options.Input.Value,
                Options.Output.Value,
                Record,
                Options.Filename.Value);
            }

        public override void ContainerCopy(ContainerCopy Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.ContainerCopy(
                CryptoParameters(Options),
                Options.Input.Value,
                Options.Output.Value,
                Options.Decrypt.Value,
                Options.Index.Value,
                Options.Purge.Value
                );
            }

        public override void ContainerVerify(ContainerVerify Options) {
            var ShellDispatch = SetShell(Options);
            ShellDispatch.ContainerVerify(
                KeyCollection(Options)
,
                Options.Input.Value);
            }
        #endregion

        }


    }
