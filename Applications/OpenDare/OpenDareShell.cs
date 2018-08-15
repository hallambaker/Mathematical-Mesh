using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Command;
using Goedel.Utilities;

namespace Goedel.Dare.Shell {
    public partial class CommandLineInterpreter : CommandLineInterpreterBase {
        
		/// <summary>The command entries</summary>
        public static SortedDictionary<string, DescribeCommand> Entries;
        /// <summary>The default command.</summary>
        public static DescribeCommandEntry DefaultCommand;
        /// <summary>Description of the comman</summary>
        public static string Description = "<Not specified>";

		static char UnixFlag = '-';
		static char WindowsFlag = '/';

		
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Dispatch"></param>
        /// <param name="args"></param>
        /// <param name="index"></param>
        public static void Help (DispatchShell Dispatch, string[] args, int index) =>
            Brief(Description, DefaultCommand, Entries);

        public static DescribeCommandEntry DescribeHelp = new DescribeCommandEntry() {
            Identifier = "help",
            HandleDelegate = Help,
            Entries = new List<DescribeEntry>() { }
            };

        /// <summary>
        /// Describe the application invoked by the command.
        /// </summary>
        /// <param name="Dispatch">The command description.</param>
        /// <param name="args">The set of arguments.</param>
        /// <param name="index">The first unparsed argument.</param>
        public static void About (DispatchShell Dispatch, string[] args, int index) =>
            FileTools.About();


        public static DescribeCommandEntry DescribeAbout = new DescribeCommandEntry() {
            Identifier = "about",
            HandleDelegate = About,
            Entries = new List<DescribeEntry>() { }
            };

        static bool IsFlag(char c) =>
            (c == UnixFlag) | (c == WindowsFlag) ;


		static DescribeCommandSet DescribeCommandSet_Profile = new DescribeCommandSet () {
            Identifier = "profile",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"reset", _ProfileReset._DescribeCommand },
				{"device", _DeviceCreate._DescribeCommand },
				{"personal", _PersonalCreate._DescribeCommand },
				{"register", _ProfileRegister._DescribeCommand },
				{"sync", _ProfileSync._DescribeCommand },
				{"escrow", _ProfileEscrow._DescribeCommand },
				{"recover", _ProfileRecover._DescribeCommand },
				{"export", _ProfileExport._DescribeCommand },
				{"import", _ProfileImport._DescribeCommand },
				{"list", _ProfileList._DescribeCommand },
				{"dump", _ProfileDump._DescribeCommand },
				{"pending", _ProfilePending._DescribeCommand },
				{"connect", _ProfileConnect._DescribeCommand },
				{"accept", _ProfileAccept._DescribeCommand },
				{"reject", _ProfileReject._DescribeCommand },
				{"pin", _ProfileGetPIN._DescribeCommand },
				{"complete", _ProfileComplete._DescribeCommand }
				} // End Entries
			};

		static DescribeCommandSet DescribeCommandSet_Mail = new DescribeCommandSet () {
            Identifier = "mail",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"add", _MailAdd._DescribeCommand },
				{"update", _MailUpdate._DescribeCommand },
				{"smime", DescribeCommandSet_SMIME},
				{"openpgp", DescribeCommandSet_PGP}
				} // End Entries
			};

		static DescribeCommandSet DescribeCommandSet_SMIME = new DescribeCommandSet () {
            Identifier = "smime",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"private", _SMIMEPrivate._DescribeCommand },
				{"public", _SMIMEPublic._DescribeCommand }
				} // End Entries
			};

		static DescribeCommandSet DescribeCommandSet_PGP = new DescribeCommandSet () {
            Identifier = "openpgp",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"private", _PGPPrivate._DescribeCommand },
				{"public", _PGPPublic._DescribeCommand }
				} // End Entries
			};

		static DescribeCommandSet DescribeCommandSet_SSH = new DescribeCommandSet () {
            Identifier = "ssh",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"add", DescribeCommandSet_SSHAdd},
				{"host", _SSHHost._DescribeCommand },
				{"create", _SSHCreate._DescribeCommand },
				{"known", _SSHKnown._DescribeCommand },
				{"auth", _SSHAuth._DescribeCommand },
				{"private", _SSHPrivate._DescribeCommand },
				{"public", _SSHPublic._DescribeCommand }
				} // End Entries
			};

		static DescribeCommandSet DescribeCommandSet_SSHAdd = new DescribeCommandSet () {
            Identifier = "add",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"host", _SSHAddHost._DescribeCommand },
				{"client", _SSHAddClient._DescribeCommand }
				} // End Entries
			};

		static DescribeCommandSet DescribeCommandSet_Password = new DescribeCommandSet () {
            Identifier = "password",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"add", _PasswordAdd._DescribeCommand },
				{"user", _PasswordGet._DescribeCommand },
				{"delete", _PasswordDelete._DescribeCommand },
				{"dump", _PasswordDump._DescribeCommand }
				} // End Entries
			};

		static DescribeCommandSet DescribeCommandSet_Contact = new DescribeCommandSet () {
            Identifier = "contact",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"add", _ContactAdd._DescribeCommand },
				{"delete", _ContactDelete._DescribeCommand },
				{"get", _ContactdGet._DescribeCommand },
				{"dump", _ContactDump._DescribeCommand }
				} // End Entries
			};

		static DescribeCommandSet DescribeCommandSet_Bookmark = new DescribeCommandSet () {
            Identifier = "bookmark",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"add", _BookmarkAdd._DescribeCommand },
				{"delete", _BookmarkDelete._DescribeCommand },
				{"dump", _BookmarkDump._DescribeCommand }
				} // End Entries
			};

		static DescribeCommandSet DescribeCommandSet_Calendar = new DescribeCommandSet () {
            Identifier = "calendar",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"add", _CalendarAdd._DescribeCommand },
				{"delete", _CalendarDelete._DescribeCommand },
				{"dump", _CalendarDump._DescribeCommand }
				} // End Entries
			};

		static DescribeCommandSet DescribeCommandSet_Network = new DescribeCommandSet () {
            Identifier = "network",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"add", _NetworkAdd._DescribeCommand },
				{"delete", _NetworkDelete._DescribeCommand },
				{"dump", _NetworkDump._DescribeCommand }
				} // End Entries
			};

		static DescribeCommandSet DescribeCommandSet_Message = new DescribeCommandSet () {
            Identifier = "message",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"connect", _MessageConnect._DescribeCommand },
				{"confirm", _MessageConfirm._DescribeCommand },
				{"status", _MessageStatus._DescribeCommand },
				{"pending", _MessagePending._DescribeCommand },
				{"accept", _MessageAccept._DescribeCommand },
				{"reject", _MessageReject._DescribeCommand },
				{"block", _MessageBlock._DescribeCommand }
				} // End Entries
			};

		static DescribeCommandSet DescribeCommandSet_Group = new DescribeCommandSet () {
            Identifier = "group",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"add", _GroupAdd._DescribeCommand },
				{"create", _GroupCreate._DescribeCommand },
				{"user", _GroupUser._DescribeCommand },
				{"delete", _GroupDelete._DescribeCommand }
				} // End Entries
			};

		static DescribeCommandSet DescribeCommandSet_File = new DescribeCommandSet () {
            Identifier = "file",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"encrypt", _FileEncrypt._DescribeCommand },
				{"decrypt", _FileDecrypt._DescribeCommand }
				} // End Entries
			};

		static DescribeCommandSet DescribeCommandSet_Container = new DescribeCommandSet () {
            Identifier = "container",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"create", _ContainerCreate._DescribeCommand },
				{"archive", _ContainerArchive._DescribeCommand },
				{"append", _ContainerAppend._DescribeCommand },
				{"extract", _ContainerExtract._DescribeCommand },
				{"copy", _ContainerCopy._DescribeCommand },
				{"verify", _ContainerVerify._DescribeCommand }
				} // End Entries
			};


        static CommandLineInterpreter () {
            System.OperatingSystem OperatingSystem = System.Environment.OSVersion;

            if (OperatingSystem.Platform == PlatformID.Unix |
                    OperatingSystem.Platform == PlatformID.MacOSX) {
                FlagIndicator = UnixFlag;
                }
            else {
                FlagIndicator = WindowsFlag;
                }

				Description = "brief";

			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"about", DescribeAbout },
				{"about", DescribeAbout },
				{"profile", DescribeCommandSet_Profile},
				{"mail", DescribeCommandSet_Mail},
				{"ssh", DescribeCommandSet_SSH},
				{"password", DescribeCommandSet_Password},
				{"contact", DescribeCommandSet_Contact},
				{"bookmark", DescribeCommandSet_Bookmark},
				{"calendar", DescribeCommandSet_Calendar},
				{"network", DescribeCommandSet_Network},
				{"message", DescribeCommandSet_Message},
				{"group", DescribeCommandSet_Group},
				{"file", DescribeCommandSet_File},
				{"container", DescribeCommandSet_Container},
				{"help", DescribeHelp }
				}; // End Entries



            }



        public void MainMethod(string[] Args) {
			DareShell Dispatch = new DareShell ();

			try {
				MainMethod (Dispatch, Args);
				}
            catch (Goedel.Command.ParserException) {
			    Brief(Description, DefaultCommand, Entries);
				}
            catch (System.Exception Exception) {
                Console.WriteLine("Application: {0}", Exception.Message);
                }
			}


        public void MainMethod(DareShell Dispatch, string[] Args) =>
			Dispatcher (Entries, DefaultCommand, Dispatch, Args, 0);




		public static void Handle_ProfileReset (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ProfileReset		Options = new ProfileReset ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ProfileReset (Options);
			}

		public static void Handle_DeviceCreate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			DeviceCreate		Options = new DeviceCreate ();
			ProcessOptions (Args, Index, Options);
			Dispatch.DeviceCreate (Options);
			}

		public static void Handle_PersonalCreate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			PersonalCreate		Options = new PersonalCreate ();
			ProcessOptions (Args, Index, Options);
			Dispatch.PersonalCreate (Options);
			}

		public static void Handle_ProfileRegister (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ProfileRegister		Options = new ProfileRegister ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ProfileRegister (Options);
			}

		public static void Handle_ProfileSync (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ProfileSync		Options = new ProfileSync ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ProfileSync (Options);
			}

		public static void Handle_ProfileEscrow (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ProfileEscrow		Options = new ProfileEscrow ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ProfileEscrow (Options);
			}

		public static void Handle_ProfileRecover (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ProfileRecover		Options = new ProfileRecover ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ProfileRecover (Options);
			}

		public static void Handle_ProfileExport (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ProfileExport		Options = new ProfileExport ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ProfileExport (Options);
			}

		public static void Handle_ProfileImport (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ProfileImport		Options = new ProfileImport ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ProfileImport (Options);
			}

		public static void Handle_ProfileList (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ProfileList		Options = new ProfileList ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ProfileList (Options);
			}

		public static void Handle_ProfileDump (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ProfileDump		Options = new ProfileDump ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ProfileDump (Options);
			}

		public static void Handle_ProfilePending (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ProfilePending		Options = new ProfilePending ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ProfilePending (Options);
			}

		public static void Handle_ProfileConnect (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ProfileConnect		Options = new ProfileConnect ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ProfileConnect (Options);
			}

		public static void Handle_ProfileAccept (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ProfileAccept		Options = new ProfileAccept ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ProfileAccept (Options);
			}

		public static void Handle_ProfileReject (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ProfileReject		Options = new ProfileReject ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ProfileReject (Options);
			}

		public static void Handle_ProfileGetPIN (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ProfileGetPIN		Options = new ProfileGetPIN ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ProfileGetPIN (Options);
			}

		public static void Handle_ProfileComplete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ProfileComplete		Options = new ProfileComplete ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ProfileComplete (Options);
			}

		public static void Handle_MailAdd (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			MailAdd		Options = new MailAdd ();
			ProcessOptions (Args, Index, Options);
			Dispatch.MailAdd (Options);
			}

		public static void Handle_MailUpdate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			MailUpdate		Options = new MailUpdate ();
			ProcessOptions (Args, Index, Options);
			Dispatch.MailUpdate (Options);
			}

		public static void Handle_SMIMEPrivate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			SMIMEPrivate		Options = new SMIMEPrivate ();
			ProcessOptions (Args, Index, Options);
			Dispatch.SMIMEPrivate (Options);
			}

		public static void Handle_SMIMEPublic (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			SMIMEPublic		Options = new SMIMEPublic ();
			ProcessOptions (Args, Index, Options);
			Dispatch.SMIMEPublic (Options);
			}

		public static void Handle_PGPPrivate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			PGPPrivate		Options = new PGPPrivate ();
			ProcessOptions (Args, Index, Options);
			Dispatch.PGPPrivate (Options);
			}

		public static void Handle_PGPPublic (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			PGPPublic		Options = new PGPPublic ();
			ProcessOptions (Args, Index, Options);
			Dispatch.PGPPublic (Options);
			}

		public static void Handle_SSHAddHost (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			SSHAddHost		Options = new SSHAddHost ();
			ProcessOptions (Args, Index, Options);
			Dispatch.SSHAddHost (Options);
			}

		public static void Handle_SSHAddClient (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			SSHAddClient		Options = new SSHAddClient ();
			ProcessOptions (Args, Index, Options);
			Dispatch.SSHAddClient (Options);
			}

		public static void Handle_SSHHost (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			SSHHost		Options = new SSHHost ();
			ProcessOptions (Args, Index, Options);
			Dispatch.SSHHost (Options);
			}

		public static void Handle_SSHCreate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			SSHCreate		Options = new SSHCreate ();
			ProcessOptions (Args, Index, Options);
			Dispatch.SSHCreate (Options);
			}

		public static void Handle_SSHKnown (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			SSHKnown		Options = new SSHKnown ();
			ProcessOptions (Args, Index, Options);
			Dispatch.SSHKnown (Options);
			}

		public static void Handle_SSHAuth (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			SSHAuth		Options = new SSHAuth ();
			ProcessOptions (Args, Index, Options);
			Dispatch.SSHAuth (Options);
			}

		public static void Handle_SSHPrivate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			SSHPrivate		Options = new SSHPrivate ();
			ProcessOptions (Args, Index, Options);
			Dispatch.SSHPrivate (Options);
			}

		public static void Handle_SSHPublic (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			SSHPublic		Options = new SSHPublic ();
			ProcessOptions (Args, Index, Options);
			Dispatch.SSHPublic (Options);
			}

		public static void Handle_PasswordAdd (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			PasswordAdd		Options = new PasswordAdd ();
			ProcessOptions (Args, Index, Options);
			Dispatch.PasswordAdd (Options);
			}

		public static void Handle_PasswordGet (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			PasswordGet		Options = new PasswordGet ();
			ProcessOptions (Args, Index, Options);
			Dispatch.PasswordGet (Options);
			}

		public static void Handle_PasswordDelete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			PasswordDelete		Options = new PasswordDelete ();
			ProcessOptions (Args, Index, Options);
			Dispatch.PasswordDelete (Options);
			}

		public static void Handle_PasswordDump (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			PasswordDump		Options = new PasswordDump ();
			ProcessOptions (Args, Index, Options);
			Dispatch.PasswordDump (Options);
			}

		public static void Handle_ContactAdd (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ContactAdd		Options = new ContactAdd ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ContactAdd (Options);
			}

		public static void Handle_ContactDelete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ContactDelete		Options = new ContactDelete ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ContactDelete (Options);
			}

		public static void Handle_ContactdGet (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ContactdGet		Options = new ContactdGet ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ContactdGet (Options);
			}

		public static void Handle_ContactDump (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ContactDump		Options = new ContactDump ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ContactDump (Options);
			}

		public static void Handle_BookmarkAdd (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			BookmarkAdd		Options = new BookmarkAdd ();
			ProcessOptions (Args, Index, Options);
			Dispatch.BookmarkAdd (Options);
			}

		public static void Handle_BookmarkDelete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			BookmarkDelete		Options = new BookmarkDelete ();
			ProcessOptions (Args, Index, Options);
			Dispatch.BookmarkDelete (Options);
			}

		public static void Handle_BookmarkDump (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			BookmarkDump		Options = new BookmarkDump ();
			ProcessOptions (Args, Index, Options);
			Dispatch.BookmarkDump (Options);
			}

		public static void Handle_CalendarAdd (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			CalendarAdd		Options = new CalendarAdd ();
			ProcessOptions (Args, Index, Options);
			Dispatch.CalendarAdd (Options);
			}

		public static void Handle_CalendarDelete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			CalendarDelete		Options = new CalendarDelete ();
			ProcessOptions (Args, Index, Options);
			Dispatch.CalendarDelete (Options);
			}

		public static void Handle_CalendarDump (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			CalendarDump		Options = new CalendarDump ();
			ProcessOptions (Args, Index, Options);
			Dispatch.CalendarDump (Options);
			}

		public static void Handle_NetworkAdd (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			NetworkAdd		Options = new NetworkAdd ();
			ProcessOptions (Args, Index, Options);
			Dispatch.NetworkAdd (Options);
			}

		public static void Handle_NetworkDelete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			NetworkDelete		Options = new NetworkDelete ();
			ProcessOptions (Args, Index, Options);
			Dispatch.NetworkDelete (Options);
			}

		public static void Handle_NetworkDump (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			NetworkDump		Options = new NetworkDump ();
			ProcessOptions (Args, Index, Options);
			Dispatch.NetworkDump (Options);
			}

		public static void Handle_MessageConnect (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			MessageConnect		Options = new MessageConnect ();
			ProcessOptions (Args, Index, Options);
			Dispatch.MessageConnect (Options);
			}

		public static void Handle_MessageConfirm (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			MessageConfirm		Options = new MessageConfirm ();
			ProcessOptions (Args, Index, Options);
			Dispatch.MessageConfirm (Options);
			}

		public static void Handle_MessageStatus (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			MessageStatus		Options = new MessageStatus ();
			ProcessOptions (Args, Index, Options);
			Dispatch.MessageStatus (Options);
			}

		public static void Handle_MessagePending (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			MessagePending		Options = new MessagePending ();
			ProcessOptions (Args, Index, Options);
			Dispatch.MessagePending (Options);
			}

		public static void Handle_MessageAccept (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			MessageAccept		Options = new MessageAccept ();
			ProcessOptions (Args, Index, Options);
			Dispatch.MessageAccept (Options);
			}

		public static void Handle_MessageReject (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			MessageReject		Options = new MessageReject ();
			ProcessOptions (Args, Index, Options);
			Dispatch.MessageReject (Options);
			}

		public static void Handle_MessageBlock (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			MessageBlock		Options = new MessageBlock ();
			ProcessOptions (Args, Index, Options);
			Dispatch.MessageBlock (Options);
			}

		public static void Handle_GroupAdd (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			GroupAdd		Options = new GroupAdd ();
			ProcessOptions (Args, Index, Options);
			Dispatch.GroupAdd (Options);
			}

		public static void Handle_GroupCreate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			GroupCreate		Options = new GroupCreate ();
			ProcessOptions (Args, Index, Options);
			Dispatch.GroupCreate (Options);
			}

		public static void Handle_GroupUser (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			GroupUser		Options = new GroupUser ();
			ProcessOptions (Args, Index, Options);
			Dispatch.GroupUser (Options);
			}

		public static void Handle_GroupDelete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			GroupDelete		Options = new GroupDelete ();
			ProcessOptions (Args, Index, Options);
			Dispatch.GroupDelete (Options);
			}

		public static void Handle_FileEncrypt (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			FileEncrypt		Options = new FileEncrypt ();
			ProcessOptions (Args, Index, Options);
			Dispatch.FileEncrypt (Options);
			}

		public static void Handle_FileDecrypt (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			FileDecrypt		Options = new FileDecrypt ();
			ProcessOptions (Args, Index, Options);
			Dispatch.FileDecrypt (Options);
			}

		public static void Handle_ContainerCreate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ContainerCreate		Options = new ContainerCreate ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ContainerCreate (Options);
			}

		public static void Handle_ContainerArchive (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ContainerArchive		Options = new ContainerArchive ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ContainerArchive (Options);
			}

		public static void Handle_ContainerAppend (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ContainerAppend		Options = new ContainerAppend ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ContainerAppend (Options);
			}

		public static void Handle_ContainerExtract (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ContainerExtract		Options = new ContainerExtract ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ContainerExtract (Options);
			}

		public static void Handle_ContainerCopy (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ContainerCopy		Options = new ContainerCopy ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ContainerCopy (Options);
			}

		public static void Handle_ContainerVerify (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			DareShell Dispatch =	DispatchIn as DareShell;
			ContainerVerify		Options = new ContainerVerify ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ContainerVerify (Options);
			}


	} // class Main


	// The stub class for carrying optional parameters for each command type
	// As with the main class each consists of an abstract main class 
	// with partial virtual that can be extended as required.

	// All subclasses inherit from the abstract classes Goedel.Regisrty.Dispatch 
	// and Goedel.Command.Type

	public interface IReporting {
		Flag			Verbose{get; set;}
		Flag			Report{get; set;}
		Flag			Json{get; set;}
		}

	public interface IAccountOptions {
		String			AccountID{get; set;}
		String			UDF{get; set;}
		}

	public interface IDeviceProfileInfo {
		Flag			DeviceNew{get; set;}
		String			DeviceUDF{get; set;}
		String			DeviceID{get; set;}
		String			DeviceDescription{get; set;}
		}


    public class _ProfileReset : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[0] as Flag;
			set => _Data[0]  = value;
			}

		public virtual string _Verbose {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[1] as Flag;
			set => _Data[1]  = value;
			}

		public virtual string _Report {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Json {
			set => _Data[2].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "reset",
			Brief =  "Delete all test profiles",
			HandleDelegate =  CommandLineInterpreter.Handle_ProfileReset,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 0,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 1,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 2,
					Key = "json"
					}
				}
			};

		}

    public partial class ProfileReset : _ProfileReset {
        } // class ProfileReset

    public class _DeviceCreate : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String DeviceID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _DeviceID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String DeviceDescription {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _DeviceDescription {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [default]</summary>
		public virtual Flag Default {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Default {
			set => _Data[2].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "device",
			Brief =  "Create new device profile",
			HandleDelegate =  CommandLineInterpreter.Handle_DeviceCreate,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "DeviceID", 
					Default = null, // null if null
					Brief = "Device identifier",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "DeviceDescription", 
					Default = null, // null if null
					Brief = "Device description",
					Index = 1,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Default", 
					Default = null, // null if null
					Brief = "Make the new device profile the default",
					Index = 2,
					Key = "default"
					}
				}
			};

		}

    public partial class DeviceCreate : _DeviceCreate {
        } // class DeviceCreate

    public class _PersonalCreate : Goedel.Command.Dispatch ,
							IReporting,
							IDeviceProfileInfo {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String (),
			new String ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String NewAccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _NewAccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[1] as Flag;
			set => _Data[1]  = value;
			}

		public virtual string _Verbose {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Report {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Json {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [new]</summary>
		public virtual Flag DeviceNew {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _DeviceNew {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [dudf]</summary>
		public virtual String DeviceUDF {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _DeviceUDF {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [did]</summary>
		public virtual String DeviceID {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _DeviceID {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [dd]</summary>
		public virtual String DeviceDescription {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _DeviceDescription {
			set => _Data[7].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "personal",
			Brief =  "Create new personal profile",
			HandleDelegate =  CommandLineInterpreter.Handle_PersonalCreate,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "NewAccountID", 
					Default = null, // null if null
					Brief = "New account",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 1,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 2,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 3,
					Key = "json"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceNew", 
					Default = null, // null if null
					Brief = "Force creation of new device profile",
					Index = 4,
					Key = "new"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceUDF", 
					Default = null, // null if null
					Brief = "Device profile fingerprint",
					Index = 5,
					Key = "dudf"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceID", 
					Default = null, // null if null
					Brief = "Device identifier",
					Index = 6,
					Key = "did"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceDescription", 
					Default = null, // null if null
					Brief = "Device description",
					Index = 7,
					Key = "dd"
					}
				}
			};

		}

    public partial class PersonalCreate : _PersonalCreate {
        } // class PersonalCreate

    public class _ProfileRegister : Goedel.Command.Dispatch ,
							IReporting,
							IAccountOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String NewAccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _NewAccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[1] as Flag;
			set => _Data[1]  = value;
			}

		public virtual string _Verbose {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Report {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Json {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _AccountID {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _UDF {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "register",
			Brief =  "Register existing profile at a new portal",
			HandleDelegate =  CommandLineInterpreter.Handle_ProfileRegister,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "NewAccountID", 
					Default = null, // null if null
					Brief = "New account",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 1,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 2,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 3,
					Key = "json"
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 4,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 5,
					Key = "udf"
					}
				}
			};

		}

    public partial class ProfileRegister : _ProfileRegister {
        } // class ProfileRegister

    public class _ProfileSync : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "sync",
			Brief =  "Synchronize local copies of Mesh profiles with the server",
			HandleDelegate =  CommandLineInterpreter.Handle_ProfileSync,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					}
				}
			};

		}

    public partial class ProfileSync : _ProfileSync {
        } // class ProfileSync

    public class _ProfileEscrow : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Integer (),
			new Integer ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [quorum]</summary>
		public virtual Integer Quorum {
			get => _Data[5] as Integer;
			set => _Data[5]  = value;
			}

		public virtual string _Quorum {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [shares]</summary>
		public virtual Integer Shares {
			get => _Data[6] as Integer;
			set => _Data[6]  = value;
			}

		public virtual string _Shares {
			set => _Data[6].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "escrow",
			Brief =  "Create a set of key escrow shares",
			HandleDelegate =  CommandLineInterpreter.Handle_ProfileEscrow,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					},
				new DescribeEntryOption () {
					Identifier = "Quorum", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 5,
					Key = "quorum"
					},
				new DescribeEntryOption () {
					Identifier = "Shares", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 6,
					Key = "shares"
					}
				}
			};

		}

    public partial class ProfileEscrow : _ProfileEscrow {
        } // class ProfileEscrow

    public class _ProfileRecover : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new ExistingFile ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Share1 {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Share1 {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Share2 {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Share2 {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Share3 {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _Share3 {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Share4 {
			get => _Data[8] as String;
			set => _Data[8]  = value;
			}

		public virtual string _Share4 {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Share5 {
			get => _Data[9] as String;
			set => _Data[9]  = value;
			}

		public virtual string _Share5 {
			set => _Data[9].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Share6 {
			get => _Data[10] as String;
			set => _Data[10]  = value;
			}

		public virtual string _Share6 {
			set => _Data[10].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Share7 {
			get => _Data[11] as String;
			set => _Data[11]  = value;
			}

		public virtual string _Share7 {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Share8 {
			get => _Data[12] as String;
			set => _Data[12]  = value;
			}

		public virtual string _Share8 {
			set => _Data[12].Parameter (value);
			}
		/// <summary>Field accessor for option [file]</summary>
		public virtual ExistingFile File {
			get => _Data[13] as ExistingFile;
			set => _Data[13]  = value;
			}

		public virtual string _File {
			set => _Data[13].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "recover",
			Brief =  "Recover escrowed profile",
			HandleDelegate =  CommandLineInterpreter.Handle_ProfileRecover,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					},
				new DescribeEntryParameter () {
					Identifier = "Share1", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 5,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Share2", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 6,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Share3", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 7,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Share4", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 8,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Share5", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 9,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Share6", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 10,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Share7", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 11,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Share8", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 12,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 13,
					Key = "file"
					}
				}
			};

		}

    public partial class ProfileRecover : _ProfileRecover {
        } // class ProfileRecover

    public class _ProfileExport : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new NewFile (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual NewFile File {
			get => _Data[0] as NewFile;
			set => _Data[0]  = value;
			}

		public virtual string _File {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _UDF {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Verbose {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Report {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Json {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "export",
			Brief =  "Export the specified profile data to the specified file",
			HandleDelegate =  CommandLineInterpreter.Handle_ProfileExport,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 5,
					Key = "json"
					}
				}
			};

		}

    public partial class ProfileExport : _ProfileExport {
        } // class ProfileExport

    public class _ProfileImport : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new NewFile (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual NewFile File {
			get => _Data[0] as NewFile;
			set => _Data[0]  = value;
			}

		public virtual string _File {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _UDF {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Verbose {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Report {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Json {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "import",
			Brief =  "Import the specified profile data to the specified file",
			HandleDelegate =  CommandLineInterpreter.Handle_ProfileImport,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 5,
					Key = "json"
					}
				}
			};

		}

    public partial class ProfileImport : _ProfileImport {
        } // class ProfileImport

    public class _ProfileList : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[0] as Flag;
			set => _Data[0]  = value;
			}

		public virtual string _Verbose {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[1] as Flag;
			set => _Data[1]  = value;
			}

		public virtual string _Report {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Json {
			set => _Data[2].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "list",
			Brief =  "List all profiles on the local machine",
			HandleDelegate =  CommandLineInterpreter.Handle_ProfileList,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 0,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 1,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 2,
					Key = "json"
					}
				}
			};

		}

    public partial class ProfileList : _ProfileList {
        } // class ProfileList

    public class _ProfileDump : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "dump",
			Brief =  "Describe the specified profile",
			HandleDelegate =  CommandLineInterpreter.Handle_ProfileDump,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					}
				}
			};

		}

    public partial class ProfileDump : _ProfileDump {
        } // class ProfileDump

    public class _ProfilePending : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "pending",
			Brief =  "Get list of pending connection requests",
			HandleDelegate =  CommandLineInterpreter.Handle_ProfilePending,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					}
				}
			};

		}

    public partial class ProfilePending : _ProfilePending {
        } // class ProfilePending

    public class _ProfileConnect : Goedel.Command.Dispatch ,
							IReporting,
							IDeviceProfileInfo {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String (),
			new String ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String Portal {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Portal {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [pin]</summary>
		public virtual String PIN {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _PIN {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [new]</summary>
		public virtual Flag DeviceNew {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _DeviceNew {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [dudf]</summary>
		public virtual String DeviceUDF {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _DeviceUDF {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [did]</summary>
		public virtual String DeviceID {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _DeviceID {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [dd]</summary>
		public virtual String DeviceDescription {
			get => _Data[8] as String;
			set => _Data[8]  = value;
			}

		public virtual string _DeviceDescription {
			set => _Data[8].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "connect",
			Brief =  "Connect to an existing profile registered at a portal",
			HandleDelegate =  CommandLineInterpreter.Handle_ProfileConnect,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "New portal account",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "PIN", 
					Default = null, // null if null
					Brief = "One time use authenticator",
					Index = 1,
					Key = "pin"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceNew", 
					Default = null, // null if null
					Brief = "Force creation of new device profile",
					Index = 5,
					Key = "new"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceUDF", 
					Default = null, // null if null
					Brief = "Device profile fingerprint",
					Index = 6,
					Key = "dudf"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceID", 
					Default = null, // null if null
					Brief = "Device identifier",
					Index = 7,
					Key = "did"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceDescription", 
					Default = null, // null if null
					Brief = "Device description",
					Index = 8,
					Key = "dd"
					}
				}
			};

		}

    public partial class ProfileConnect : _ProfileConnect {
        } // class ProfileConnect

    public class _ProfileAccept : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String CompletionCode {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _CompletionCode {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _UDF {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Verbose {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Report {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Json {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "accept",
			Brief =  "Accept a pending connection",
			HandleDelegate =  CommandLineInterpreter.Handle_ProfileAccept,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "CompletionCode", 
					Default = null, // null if null
					Brief = "Fingerprint of connection to accept",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 5,
					Key = "json"
					}
				}
			};

		}

    public partial class ProfileAccept : _ProfileAccept {
        } // class ProfileAccept

    public class _ProfileReject : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String CompletionCode {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _CompletionCode {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _UDF {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Verbose {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Report {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Json {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "reject",
			Brief =  "Reject a pending connection",
			HandleDelegate =  CommandLineInterpreter.Handle_ProfileReject,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "CompletionCode", 
					Default = null, // null if null
					Brief = "Fingerprint of connection to reject",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 5,
					Key = "json"
					}
				}
			};

		}

    public partial class ProfileReject : _ProfileReject {
        } // class ProfileReject

    public class _ProfileGetPIN : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Integer (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [length]</summary>
		public virtual Integer Length {
			get => _Data[0] as Integer;
			set => _Data[0]  = value;
			}

		public virtual string _Length {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _UDF {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Verbose {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Report {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Json {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "pin",
			Brief =  "Accept a pending connection",
			HandleDelegate =  CommandLineInterpreter.Handle_ProfileGetPIN,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Length", 
					Default = "8", // null if null
					Brief = "Length of PIN to generate (default is 8 characters)",
					Index = 0,
					Key = "length"
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 5,
					Key = "json"
					}
				}
			};

		}

    public partial class ProfileGetPIN : _ProfileGetPIN {
        } // class ProfileGetPIN

    public class _ProfileComplete : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "complete",
			Brief =  "Complete a pending connection request",
			HandleDelegate =  CommandLineInterpreter.Handle_ProfileComplete,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					}
				}
			};

		}

    public partial class ProfileComplete : _ProfileComplete {
        } // class ProfileComplete
	public interface IMailOptions {
		Flag			OpenPGP{get; set;}
		Flag			SMIME{get; set;}
		ExistingFile			Configuration{get; set;}
		String			CA{get; set;}
		String			Inbound{get; set;}
		String			Outbound{get; set;}
		}

	public interface IPublicKeyOptions {
		String			Format{get; set;}
		NewFile			File{get; set;}
		}

	public interface IPrivateKeyOptions {
		String			Format{get; set;}
		String			Password{get; set;}
		NewFile			File{get; set;}
		}

	public interface IKeyCreateOptions {
		String			AlgKey{get; set;}
		String			LengthKey{get; set;}
		}

	public interface IEncryptOptions {
		String			Recipient{get; set;}
		String			Signer{get; set;}
		String			AlgDigest{get; set;}
		String			AlgEncrypt{get; set;}
		String			ModeEncrypt{get; set;}
		String			ModeSign{get; set;}
		}


    public class _MailAdd : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							IMailOptions,
							IKeyCreateOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new ExistingFile (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String Address {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Address {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _UDF {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Verbose {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Report {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Json {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [openpgp]</summary>
		public virtual Flag OpenPGP {
			get => _Data[6] as Flag;
			set => _Data[6]  = value;
			}

		public virtual string _OpenPGP {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [smime]</summary>
		public virtual Flag SMIME {
			get => _Data[7] as Flag;
			set => _Data[7]  = value;
			}

		public virtual string _SMIME {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [configuration]</summary>
		public virtual ExistingFile Configuration {
			get => _Data[8] as ExistingFile;
			set => _Data[8]  = value;
			}

		public virtual string _Configuration {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for option [ca]</summary>
		public virtual String CA {
			get => _Data[9] as String;
			set => _Data[9]  = value;
			}

		public virtual string _CA {
			set => _Data[9].Parameter (value);
			}
		/// <summary>Field accessor for option [inbound]</summary>
		public virtual String Inbound {
			get => _Data[10] as String;
			set => _Data[10]  = value;
			}

		public virtual string _Inbound {
			set => _Data[10].Parameter (value);
			}
		/// <summary>Field accessor for option [outbound]</summary>
		public virtual String Outbound {
			get => _Data[11] as String;
			set => _Data[11]  = value;
			}

		public virtual string _Outbound {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for option [alg]</summary>
		public virtual String AlgKey {
			get => _Data[12] as String;
			set => _Data[12]  = value;
			}

		public virtual string _AlgKey {
			set => _Data[12].Parameter (value);
			}
		/// <summary>Field accessor for option [size]</summary>
		public virtual String LengthKey {
			get => _Data[13] as String;
			set => _Data[13]  = value;
			}

		public virtual string _LengthKey {
			set => _Data[13].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "add",
			Brief =  "Add a mail application profile to a personal profile",
			HandleDelegate =  CommandLineInterpreter.Handle_MailAdd,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Address", 
					Default = null, // null if null
					Brief = "Mail account to create profile from",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 5,
					Key = "json"
					},
				new DescribeEntryOption () {
					Identifier = "OpenPGP", 
					Default = "true", // null if null
					Brief = "Create encryption and signature keys for OpenPGP",
					Index = 6,
					Key = "openpgp"
					},
				new DescribeEntryOption () {
					Identifier = "SMIME", 
					Default = "true", // null if null
					Brief = "Create encryption and signature keys for S/MIME",
					Index = 7,
					Key = "smime"
					},
				new DescribeEntryOption () {
					Identifier = "Configuration", 
					Default = null, // null if null
					Brief = "Configuration file describing network settings",
					Index = 8,
					Key = "configuration"
					},
				new DescribeEntryOption () {
					Identifier = "CA", 
					Default = null, // null if null
					Brief = "Certificate Authority to request certificate from",
					Index = 9,
					Key = "ca"
					},
				new DescribeEntryOption () {
					Identifier = "Inbound", 
					Default = null, // null if null
					Brief = "inbound service configuration",
					Index = 10,
					Key = "inbound"
					},
				new DescribeEntryOption () {
					Identifier = "Outbound", 
					Default = null, // null if null
					Brief = "outbound service configuration",
					Index = 11,
					Key = "outbound"
					},
				new DescribeEntryOption () {
					Identifier = "AlgKey", 
					Default = null, // null if null
					Brief = "The public key algorithm",
					Index = 12,
					Key = "alg"
					},
				new DescribeEntryOption () {
					Identifier = "LengthKey", 
					Default = null, // null if null
					Brief = "The public key size",
					Index = 13,
					Key = "size"
					}
				}
			};

		}

    public partial class MailAdd : _MailAdd {
        } // class MailAdd

    public class _MailUpdate : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String Address {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Address {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _UDF {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Verbose {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Report {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Json {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "update",
			Brief =  "Update an existing mail application profile",
			HandleDelegate =  CommandLineInterpreter.Handle_MailUpdate,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Address", 
					Default = null, // null if null
					Brief = "Mail account to update",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 5,
					Key = "json"
					}
				}
			};

		}

    public partial class MailUpdate : _MailUpdate {
        } // class MailUpdate

    public class _SMIMEPrivate : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							IPrivateKeyOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String (),
			new NewFile (),
			new String ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [format]</summary>
		public virtual String Format {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Format {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [password]</summary>
		public virtual String Password {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Password {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [file]</summary>
		public virtual NewFile File {
			get => _Data[7] as NewFile;
			set => _Data[7]  = value;
			}

		public virtual string _File {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Address {
			get => _Data[8] as String;
			set => _Data[8]  = value;
			}

		public virtual string _Address {
			set => _Data[8].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "private",
			Brief =  "Extract the private key for the specified account",
			HandleDelegate =  CommandLineInterpreter.Handle_SMIMEPrivate,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					},
				new DescribeEntryOption () {
					Identifier = "Format", 
					Default = null, // null if null
					Brief = "File format",
					Index = 5,
					Key = "format"
					},
				new DescribeEntryOption () {
					Identifier = "Password", 
					Default = null, // null if null
					Brief = "Password to encrypt private key",
					Index = 6,
					Key = "password"
					},
				new DescribeEntryOption () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "Output file",
					Index = 7,
					Key = "file"
					},
				new DescribeEntryParameter () {
					Identifier = "Address", 
					Default = null, // null if null
					Brief = "Mail account to update",
					Index = 8,
					Key = ""
					}
				}
			};

		}

    public partial class SMIMEPrivate : _SMIMEPrivate {
        } // class SMIMEPrivate

    public class _SMIMEPublic : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							IPublicKeyOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new NewFile (),
			new String ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [format]</summary>
		public virtual String Format {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Format {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [file]</summary>
		public virtual NewFile File {
			get => _Data[6] as NewFile;
			set => _Data[6]  = value;
			}

		public virtual string _File {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Address {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _Address {
			set => _Data[7].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "public",
			Brief =  "Extract the public key/certificate for the specified account",
			HandleDelegate =  CommandLineInterpreter.Handle_SMIMEPublic,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					},
				new DescribeEntryOption () {
					Identifier = "Format", 
					Default = null, // null if null
					Brief = "File format",
					Index = 5,
					Key = "format"
					},
				new DescribeEntryOption () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "Output file",
					Index = 6,
					Key = "file"
					},
				new DescribeEntryParameter () {
					Identifier = "Address", 
					Default = null, // null if null
					Brief = "Mail account identifier",
					Index = 7,
					Key = ""
					}
				}
			};

		}

    public partial class SMIMEPublic : _SMIMEPublic {
        } // class SMIMEPublic

    public class _PGPPrivate : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							IPrivateKeyOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String (),
			new NewFile (),
			new String ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [format]</summary>
		public virtual String Format {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Format {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [password]</summary>
		public virtual String Password {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Password {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [file]</summary>
		public virtual NewFile File {
			get => _Data[7] as NewFile;
			set => _Data[7]  = value;
			}

		public virtual string _File {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Address {
			get => _Data[8] as String;
			set => _Data[8]  = value;
			}

		public virtual string _Address {
			set => _Data[8].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "private",
			Brief =  "Extract the private key for the specified account",
			HandleDelegate =  CommandLineInterpreter.Handle_PGPPrivate,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					},
				new DescribeEntryOption () {
					Identifier = "Format", 
					Default = null, // null if null
					Brief = "File format",
					Index = 5,
					Key = "format"
					},
				new DescribeEntryOption () {
					Identifier = "Password", 
					Default = null, // null if null
					Brief = "Password to encrypt private key",
					Index = 6,
					Key = "password"
					},
				new DescribeEntryOption () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "Output file",
					Index = 7,
					Key = "file"
					},
				new DescribeEntryParameter () {
					Identifier = "Address", 
					Default = null, // null if null
					Brief = "Mail account to update",
					Index = 8,
					Key = ""
					}
				}
			};

		}

    public partial class PGPPrivate : _PGPPrivate {
        } // class PGPPrivate

    public class _PGPPublic : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							IPublicKeyOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new NewFile (),
			new String ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [format]</summary>
		public virtual String Format {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Format {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [file]</summary>
		public virtual NewFile File {
			get => _Data[6] as NewFile;
			set => _Data[6]  = value;
			}

		public virtual string _File {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Address {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _Address {
			set => _Data[7].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "public",
			Brief =  "Extract the public key/certificate for the specified account",
			HandleDelegate =  CommandLineInterpreter.Handle_PGPPublic,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					},
				new DescribeEntryOption () {
					Identifier = "Format", 
					Default = null, // null if null
					Brief = "File format",
					Index = 5,
					Key = "format"
					},
				new DescribeEntryOption () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "Output file",
					Index = 6,
					Key = "file"
					},
				new DescribeEntryParameter () {
					Identifier = "Address", 
					Default = null, // null if null
					Brief = "Mail account identifier",
					Index = 7,
					Key = ""
					}
				}
			};

		}

    public partial class PGPPublic : _PGPPublic {
        } // class PGPPublic
	public interface ISSHOptions {
		String			Application{get; set;}
		}


    public class _SSHAddHost : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							ISSHOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new ExistingFile ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [application]</summary>
		public virtual String Application {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Application {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile File {
			get => _Data[6] as ExistingFile;
			set => _Data[6]  = value;
			}

		public virtual string _File {
			set => _Data[6].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "host",
			Brief =  "Add one or more hosts to the known_hosts file",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHAddHost,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					},
				new DescribeEntryOption () {
					Identifier = "Application", 
					Default = null, // null if null
					Brief = "The application format",
					Index = 5,
					Key = "application"
					},
				new DescribeEntryParameter () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 6,
					Key = ""
					}
				}
			};

		}

    public partial class SSHAddHost : _SSHAddHost {
        } // class SSHAddHost

    public class _SSHAddClient : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							ISSHOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new ExistingFile ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [application]</summary>
		public virtual String Application {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Application {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile File {
			get => _Data[6] as ExistingFile;
			set => _Data[6]  = value;
			}

		public virtual string _File {
			set => _Data[6].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "client",
			Brief =  "Add one or more keys to the authorized_keys file",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHAddClient,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					},
				new DescribeEntryOption () {
					Identifier = "Application", 
					Default = null, // null if null
					Brief = "The application format",
					Index = 5,
					Key = "application"
					},
				new DescribeEntryParameter () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 6,
					Key = ""
					}
				}
			};

		}

    public partial class SSHAddClient : _SSHAddClient {
        } // class SSHAddClient

    public class _SSHHost : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							ISSHOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [application]</summary>
		public virtual String Application {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Application {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "host",
			Brief =  "Add the SSH server key(s) of the current machine to the personal profile",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHHost,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					},
				new DescribeEntryOption () {
					Identifier = "Application", 
					Default = null, // null if null
					Brief = "The application format",
					Index = 5,
					Key = "application"
					}
				}
			};

		}

    public partial class SSHHost : _SSHHost {
        } // class SSHHost

    public class _SSHCreate : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							ISSHOptions,
							IKeyCreateOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String (),
			new String (),
			new String ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [application]</summary>
		public virtual String Application {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Application {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [alg]</summary>
		public virtual String AlgKey {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _AlgKey {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [size]</summary>
		public virtual String LengthKey {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _LengthKey {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [id]</summary>
		public virtual String ID {
			get => _Data[8] as String;
			set => _Data[8]  = value;
			}

		public virtual string _ID {
			set => _Data[8].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "create",
			Brief =  "Generate a new SSH public keypair for the current machine and add to the personal profile",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHCreate,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					},
				new DescribeEntryOption () {
					Identifier = "Application", 
					Default = null, // null if null
					Brief = "The application format",
					Index = 5,
					Key = "application"
					},
				new DescribeEntryOption () {
					Identifier = "AlgKey", 
					Default = null, // null if null
					Brief = "The public key algorithm",
					Index = 6,
					Key = "alg"
					},
				new DescribeEntryOption () {
					Identifier = "LengthKey", 
					Default = null, // null if null
					Brief = "The public key size",
					Index = 7,
					Key = "size"
					},
				new DescribeEntryOption () {
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Key identifier",
					Index = 8,
					Key = "id"
					}
				}
			};

		}

    public partial class SSHCreate : _SSHCreate {
        } // class SSHCreate

    public class _SSHKnown : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							ISSHOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [application]</summary>
		public virtual String Application {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Application {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "known",
			Brief =  "List the known SSH sites (aka known hosts)",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHKnown,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					},
				new DescribeEntryOption () {
					Identifier = "Application", 
					Default = null, // null if null
					Brief = "The application format",
					Index = 5,
					Key = "application"
					}
				}
			};

		}

    public partial class SSHKnown : _SSHKnown {
        } // class SSHKnown

    public class _SSHAuth : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							ISSHOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [application]</summary>
		public virtual String Application {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Application {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "auth",
			Brief =  "List the authorized device keys (aka authorized_keys)",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHAuth,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					},
				new DescribeEntryOption () {
					Identifier = "Application", 
					Default = null, // null if null
					Brief = "The application format",
					Index = 5,
					Key = "application"
					}
				}
			};

		}

    public partial class SSHAuth : _SSHAuth {
        } // class SSHAuth

    public class _SSHPrivate : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							IPrivateKeyOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String (),
			new NewFile ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [format]</summary>
		public virtual String Format {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Format {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [password]</summary>
		public virtual String Password {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Password {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [file]</summary>
		public virtual NewFile File {
			get => _Data[7] as NewFile;
			set => _Data[7]  = value;
			}

		public virtual string _File {
			set => _Data[7].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "private",
			Brief =  "Extract the private key for this device",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHPrivate,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					},
				new DescribeEntryOption () {
					Identifier = "Format", 
					Default = null, // null if null
					Brief = "File format",
					Index = 5,
					Key = "format"
					},
				new DescribeEntryOption () {
					Identifier = "Password", 
					Default = null, // null if null
					Brief = "Password to encrypt private key",
					Index = 6,
					Key = "password"
					},
				new DescribeEntryOption () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "Output file",
					Index = 7,
					Key = "file"
					}
				}
			};

		}

    public partial class SSHPrivate : _SSHPrivate {
        } // class SSHPrivate

    public class _SSHPublic : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							IPublicKeyOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new NewFile ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [format]</summary>
		public virtual String Format {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Format {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [file]</summary>
		public virtual NewFile File {
			get => _Data[6] as NewFile;
			set => _Data[6]  = value;
			}

		public virtual string _File {
			set => _Data[6].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "public",
			Brief =  "Extract the public key for this device",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHPublic,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					},
				new DescribeEntryOption () {
					Identifier = "Format", 
					Default = null, // null if null
					Brief = "File format",
					Index = 5,
					Key = "format"
					},
				new DescribeEntryOption () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "Output file",
					Index = 6,
					Key = "file"
					}
				}
			};

		}

    public partial class SSHPublic : _SSHPublic {
        } // class SSHPublic

    public class _PasswordAdd : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String Site {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Site {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Username {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Username {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Password {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _Password {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _AccountID {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _UDF {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Verbose {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[6] as Flag;
			set => _Data[6]  = value;
			}

		public virtual string _Report {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[7] as Flag;
			set => _Data[7]  = value;
			}

		public virtual string _Json {
			set => _Data[7].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "add",
			Brief =  "Add password entry",
			HandleDelegate =  CommandLineInterpreter.Handle_PasswordAdd,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Site", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Username", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 1,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Password", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 2,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 3,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 4,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 5,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 6,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 7,
					Key = "json"
					}
				}
			};

		}

    public partial class PasswordAdd : _PasswordAdd {
        } // class PasswordAdd

    public class _PasswordGet : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String Site {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Site {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _UDF {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Verbose {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Report {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Json {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "user",
			Brief =  "Lookup password entry",
			HandleDelegate =  CommandLineInterpreter.Handle_PasswordGet,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Site", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 5,
					Key = "json"
					}
				}
			};

		}

    public partial class PasswordGet : _PasswordGet {
        } // class PasswordGet

    public class _PasswordDelete : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String Site {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Site {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _UDF {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Verbose {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Report {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Json {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "delete",
			Brief =  "Delete password entry",
			HandleDelegate =  CommandLineInterpreter.Handle_PasswordDelete,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Site", 
					Default = null, // null if null
					Brief = "Domain name of Web site",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 5,
					Key = "json"
					}
				}
			};

		}

    public partial class PasswordDelete : _PasswordDelete {
        } // class PasswordDelete

    public class _PasswordDump : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String Site {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Site {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _UDF {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Verbose {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Report {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Json {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "dump",
			Brief =  "List password entries",
			HandleDelegate =  CommandLineInterpreter.Handle_PasswordDump,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Site", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 5,
					Key = "json"
					}
				}
			};

		}

    public partial class PasswordDump : _PasswordDump {
        } // class PasswordDump

    public class _ContactAdd : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new ExistingFile (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile File {
			get => _Data[0] as ExistingFile;
			set => _Data[0]  = value;
			}

		public virtual string _File {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _UDF {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Verbose {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Report {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Json {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "add",
			Brief =  "Add contact entry from file",
			HandleDelegate =  CommandLineInterpreter.Handle_ContactAdd,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 5,
					Key = "json"
					}
				}
			};

		}

    public partial class ContactAdd : _ContactAdd {
        } // class ContactAdd

    public class _ContactDelete : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String Identifier {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Identifier {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _UDF {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Verbose {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Report {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Json {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "delete",
			Brief =  "Delete contact entry",
			HandleDelegate =  CommandLineInterpreter.Handle_ContactDelete,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Identifier", 
					Default = null, // null if null
					Brief = "Contact entry identifier",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 5,
					Key = "json"
					}
				}
			};

		}

    public partial class ContactDelete : _ContactDelete {
        } // class ContactDelete

    public class _ContactdGet : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String Identifier {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Identifier {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _UDF {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Verbose {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Report {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Json {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "get",
			Brief =  "Lookup contact entry",
			HandleDelegate =  CommandLineInterpreter.Handle_ContactdGet,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Identifier", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 5,
					Key = "json"
					}
				}
			};

		}

    public partial class ContactdGet : _ContactdGet {
        } // class ContactdGet

    public class _ContactDump : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "dump",
			Brief =  "List contact entries",
			HandleDelegate =  CommandLineInterpreter.Handle_ContactDump,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					}
				}
			};

		}

    public partial class ContactDump : _ContactDump {
        } // class ContactDump

    public class _BookmarkAdd : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String Uri {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Uri {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Title {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Title {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [path]</summary>
		public virtual String Path {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _Path {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _AccountID {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _UDF {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Verbose {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[6] as Flag;
			set => _Data[6]  = value;
			}

		public virtual string _Report {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[7] as Flag;
			set => _Data[7]  = value;
			}

		public virtual string _Json {
			set => _Data[7].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "add",
			Brief =  "Add bookmark",
			HandleDelegate =  CommandLineInterpreter.Handle_BookmarkAdd,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Uri", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Title", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 1,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Path", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 2,
					Key = "path"
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 3,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 4,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 5,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 6,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 7,
					Key = "json"
					}
				}
			};

		}

    public partial class BookmarkAdd : _BookmarkAdd {
        } // class BookmarkAdd

    public class _BookmarkDelete : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String Uri {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Uri {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [path]</summary>
		public virtual String Path {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Path {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _AccountID {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _UDF {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Verbose {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Report {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[6] as Flag;
			set => _Data[6]  = value;
			}

		public virtual string _Json {
			set => _Data[6].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "delete",
			Brief =  "Delete bookmark entry",
			HandleDelegate =  CommandLineInterpreter.Handle_BookmarkDelete,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Uri", 
					Default = null, // null if null
					Brief = "Contact entry identifier",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Path", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 1,
					Key = "path"
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 2,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 3,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 4,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 5,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 6,
					Key = "json"
					}
				}
			};

		}

    public partial class BookmarkDelete : _BookmarkDelete {
        } // class BookmarkDelete

    public class _BookmarkDump : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "dump",
			Brief =  "List bookmark entries",
			HandleDelegate =  CommandLineInterpreter.Handle_BookmarkDump,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					}
				}
			};

		}

    public partial class BookmarkDump : _BookmarkDump {
        } // class BookmarkDump

    public class _CalendarAdd : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new ExistingFile (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile File {
			get => _Data[0] as ExistingFile;
			set => _Data[0]  = value;
			}

		public virtual string _File {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _UDF {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Verbose {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Report {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Json {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "add",
			Brief =  "Add calendar entry from file",
			HandleDelegate =  CommandLineInterpreter.Handle_CalendarAdd,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 5,
					Key = "json"
					}
				}
			};

		}

    public partial class CalendarAdd : _CalendarAdd {
        } // class CalendarAdd

    public class _CalendarDelete : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String Identifier {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Identifier {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _UDF {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Verbose {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Report {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Json {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "delete",
			Brief =  "Delete calendar entry",
			HandleDelegate =  CommandLineInterpreter.Handle_CalendarDelete,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Identifier", 
					Default = null, // null if null
					Brief = "Contact entry identifier",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 5,
					Key = "json"
					}
				}
			};

		}

    public partial class CalendarDelete : _CalendarDelete {
        } // class CalendarDelete

    public class _CalendarDump : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "dump",
			Brief =  "List calendar entries",
			HandleDelegate =  CommandLineInterpreter.Handle_CalendarDump,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					}
				}
			};

		}

    public partial class CalendarDump : _CalendarDump {
        } // class CalendarDump

    public class _NetworkAdd : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new ExistingFile (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile File {
			get => _Data[0] as ExistingFile;
			set => _Data[0]  = value;
			}

		public virtual string _File {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _UDF {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Verbose {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Report {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Json {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "add",
			Brief =  "Add calendar entry from file",
			HandleDelegate =  CommandLineInterpreter.Handle_NetworkAdd,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 5,
					Key = "json"
					}
				}
			};

		}

    public partial class NetworkAdd : _NetworkAdd {
        } // class NetworkAdd

    public class _NetworkDelete : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String Identifier {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Identifier {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _UDF {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Verbose {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Report {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Json {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "delete",
			Brief =  "Delete calendar entry",
			HandleDelegate =  CommandLineInterpreter.Handle_NetworkDelete,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Identifier", 
					Default = null, // null if null
					Brief = "Network entry identifier",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 5,
					Key = "json"
					}
				}
			};

		}

    public partial class NetworkDelete : _NetworkDelete {
        } // class NetworkDelete

    public class _NetworkDump : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "dump",
			Brief =  "List network entries",
			HandleDelegate =  CommandLineInterpreter.Handle_NetworkDump,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					}
				}
			};

		}

    public partial class NetworkDump : _NetworkDump {
        } // class NetworkDump

    public class _MessageConnect : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String Recipient {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Recipient {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _UDF {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Verbose {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Report {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Json {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "connect",
			Brief =  "Post a conection request to a user",
			HandleDelegate =  CommandLineInterpreter.Handle_MessageConnect,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Recipient", 
					Default = null, // null if null
					Brief = "The recipient to send the conection request to",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 5,
					Key = "json"
					}
				}
			};

		}

    public partial class MessageConnect : _MessageConnect {
        } // class MessageConnect

    public class _MessageConfirm : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String Recipient {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Recipient {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _UDF {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Verbose {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Report {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Json {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "confirm",
			Brief =  "Post a confirmation request to a user",
			HandleDelegate =  CommandLineInterpreter.Handle_MessageConfirm,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Recipient", 
					Default = null, // null if null
					Brief = "The recipient to send the confirmation request to",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 5,
					Key = "json"
					}
				}
			};

		}

    public partial class MessageConfirm : _MessageConfirm {
        } // class MessageConfirm

    public class _MessageStatus : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [requestid]</summary>
		public virtual String RequestID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _RequestID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _UDF {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Verbose {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Report {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Json {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "status",
			Brief =  "Request status of pending requests",
			HandleDelegate =  CommandLineInterpreter.Handle_MessageStatus,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "RequestID", 
					Default = null, // null if null
					Brief = "Specifies the request to provide the status of",
					Index = 0,
					Key = "requestid"
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 5,
					Key = "json"
					}
				}
			};

		}

    public partial class MessageStatus : _MessageStatus {
        } // class MessageStatus

    public class _MessagePending : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "pending",
			Brief =  "List pending requests",
			HandleDelegate =  CommandLineInterpreter.Handle_MessagePending,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					}
				}
			};

		}

    public partial class MessagePending : _MessagePending {
        } // class MessagePending

    public class _MessageAccept : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [requestid]</summary>
		public virtual String RequestID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _RequestID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _UDF {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Verbose {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Report {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Json {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "accept",
			Brief =  "Accept a pending request",
			HandleDelegate =  CommandLineInterpreter.Handle_MessageAccept,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "RequestID", 
					Default = null, // null if null
					Brief = "Specifies the request to accept",
					Index = 0,
					Key = "requestid"
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 5,
					Key = "json"
					}
				}
			};

		}

    public partial class MessageAccept : _MessageAccept {
        } // class MessageAccept

    public class _MessageReject : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [requestid]</summary>
		public virtual String RequestID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _RequestID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _UDF {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Verbose {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Report {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Json {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "reject",
			Brief =  "Reject a pending request",
			HandleDelegate =  CommandLineInterpreter.Handle_MessageReject,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "RequestID", 
					Default = null, // null if null
					Brief = "Specifies the request to reject",
					Index = 0,
					Key = "requestid"
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 5,
					Key = "json"
					}
				}
			};

		}

    public partial class MessageReject : _MessageReject {
        } // class MessageReject

    public class _MessageBlock : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [requestid]</summary>
		public virtual String RequestID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _RequestID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _UDF {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Verbose {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Report {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Json {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "block",
			Brief =  "Reject a pending request and block requests from that source",
			HandleDelegate =  CommandLineInterpreter.Handle_MessageBlock,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "RequestID", 
					Default = null, // null if null
					Brief = "Specifies the request to reject and block",
					Index = 0,
					Key = "requestid"
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 5,
					Key = "json"
					}
				}
			};

		}

    public partial class MessageBlock : _MessageBlock {
        } // class MessageBlock

    public class _GroupAdd : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String GroupID {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _GroupID {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "add",
			Brief =  "Add recryption group to keyring",
			HandleDelegate =  CommandLineInterpreter.Handle_GroupAdd,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					},
				new DescribeEntryParameter () {
					Identifier = "GroupID", 
					Default = null, // null if null
					Brief = "Recryption group name in user@example.com format",
					Index = 5,
					Key = ""
					}
				}
			};

		}

    public partial class GroupAdd : _GroupAdd {
        } // class GroupAdd

    public class _GroupCreate : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							IKeyCreateOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String (),
			new String ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [alg]</summary>
		public virtual String AlgKey {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _AlgKey {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [size]</summary>
		public virtual String LengthKey {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _LengthKey {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String GroupID {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _GroupID {
			set => _Data[7].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "create",
			Brief =  "Create recryption group",
			HandleDelegate =  CommandLineInterpreter.Handle_GroupCreate,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					},
				new DescribeEntryOption () {
					Identifier = "AlgKey", 
					Default = null, // null if null
					Brief = "The public key algorithm",
					Index = 5,
					Key = "alg"
					},
				new DescribeEntryOption () {
					Identifier = "LengthKey", 
					Default = null, // null if null
					Brief = "The public key size",
					Index = 6,
					Key = "size"
					},
				new DescribeEntryParameter () {
					Identifier = "GroupID", 
					Default = null, // null if null
					Brief = "Recryption group name in user@example.com format",
					Index = 7,
					Key = ""
					}
				}
			};

		}

    public partial class GroupCreate : _GroupCreate {
        } // class GroupCreate

    public class _GroupUser : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String GroupID {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _GroupID {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String MemberID {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _MemberID {
			set => _Data[6].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "user",
			Brief =  "Add user to recryption group",
			HandleDelegate =  CommandLineInterpreter.Handle_GroupUser,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					},
				new DescribeEntryParameter () {
					Identifier = "GroupID", 
					Default = null, // null if null
					Brief = "Recryption group name in user@example.com format",
					Index = 5,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "MemberID", 
					Default = null, // null if null
					Brief = "User to add",
					Index = 6,
					Key = ""
					}
				}
			};

		}

    public partial class GroupUser : _GroupUser {
        } // class GroupUser

    public class _GroupDelete : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String GroupID {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _GroupID {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String MemberID {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _MemberID {
			set => _Data[6].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "delete",
			Brief =  "Remove user from recryption group",
			HandleDelegate =  CommandLineInterpreter.Handle_GroupDelete,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					},
				new DescribeEntryParameter () {
					Identifier = "GroupID", 
					Default = null, // null if null
					Brief = "Recryption group name in user@example.com format",
					Index = 5,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "MemberID", 
					Default = null, // null if null
					Brief = "User to delete",
					Index = 6,
					Key = ""
					}
				}
			};

		}

    public partial class GroupDelete : _GroupDelete {
        } // class GroupDelete

    public class _FileEncrypt : Goedel.Command.Dispatch ,
							IEncryptOptions,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new ExistingFile (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new NewFile (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Input {
			get => _Data[0] as ExistingFile;
			set => _Data[0]  = value;
			}

		public virtual string _Input {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [recipient]</summary>
		public virtual String Recipient {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Recipient {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [sign]</summary>
		public virtual String Signer {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _Signer {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [algdigest]</summary>
		public virtual String AlgDigest {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _AlgDigest {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [algencrypt]</summary>
		public virtual String AlgEncrypt {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _AlgEncrypt {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [mencrypt]</summary>
		public virtual String ModeEncrypt {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _ModeEncrypt {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [msign]</summary>
		public virtual String ModeSign {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _ModeSign {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _AccountID {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[8] as String;
			set => _Data[8]  = value;
			}

		public virtual string _UDF {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[9] as Flag;
			set => _Data[9]  = value;
			}

		public virtual string _Verbose {
			set => _Data[9].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[10] as Flag;
			set => _Data[10]  = value;
			}

		public virtual string _Report {
			set => _Data[10].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[11] as Flag;
			set => _Data[11]  = value;
			}

		public virtual string _Json {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for option [out]</summary>
		public virtual NewFile Output {
			get => _Data[12] as NewFile;
			set => _Data[12]  = value;
			}

		public virtual string _Output {
			set => _Data[12].Parameter (value);
			}
		/// <summary>Field accessor for option [sub]</summary>
		public virtual Flag Subdirectories {
			get => _Data[13] as Flag;
			set => _Data[13]  = value;
			}

		public virtual string _Subdirectories {
			set => _Data[13].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "encrypt",
			Brief =  "Encode file as DARE Message.",
			HandleDelegate =  CommandLineInterpreter.Handle_FileEncrypt,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Input", 
					Default = null, // null if null
					Brief = "File or directory to encrypt",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Recipient", 
					Default = null, // null if null
					Brief = "Encrypt data for specified recipient",
					Index = 1,
					Key = "recipient"
					},
				new DescribeEntryOption () {
					Identifier = "Signer", 
					Default = null, // null if null
					Brief = "Sign data with specified key",
					Index = 2,
					Key = "sign"
					},
				new DescribeEntryOption () {
					Identifier = "AlgDigest", 
					Default = null, // null if null
					Brief = "The digest algorithm",
					Index = 3,
					Key = "algdigest"
					},
				new DescribeEntryOption () {
					Identifier = "AlgEncrypt", 
					Default = null, // null if null
					Brief = "The symmetric encryption algorithm",
					Index = 4,
					Key = "algencrypt"
					},
				new DescribeEntryOption () {
					Identifier = "ModeEncrypt", 
					Default = null, // null if null
					Brief = "The public key encryption mode",
					Index = 5,
					Key = "mencrypt"
					},
				new DescribeEntryOption () {
					Identifier = "ModeSign", 
					Default = null, // null if null
					Brief = "The signature mode",
					Index = 6,
					Key = "msign"
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 7,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 8,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 9,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 10,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 11,
					Key = "json"
					},
				new DescribeEntryOption () {
					Identifier = "Output", 
					Default = null, // null if null
					Brief = "Filename for encrypted output.",
					Index = 12,
					Key = "out"
					},
				new DescribeEntryOption () {
					Identifier = "Subdirectories", 
					Default = null, // null if null
					Brief = "Process subdirectories recursively.",
					Index = 13,
					Key = "sub"
					}
				}
			};

		}

    public partial class FileEncrypt : _FileEncrypt {
        } // class FileEncrypt

    public class _FileDecrypt : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new ExistingFile (),
			new NewFile ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Input {
			get => _Data[5] as ExistingFile;
			set => _Data[5]  = value;
			}

		public virtual string _Input {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual NewFile Output {
			get => _Data[6] as NewFile;
			set => _Data[6]  = value;
			}

		public virtual string _Output {
			set => _Data[6].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "decrypt",
			Brief =  "Decrypt a DARE Message.",
			HandleDelegate =  CommandLineInterpreter.Handle_FileDecrypt,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					},
				new DescribeEntryParameter () {
					Identifier = "Input", 
					Default = null, // null if null
					Brief = "Encrypted File",
					Index = 5,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Output", 
					Default = null, // null if null
					Brief = "Decrypted File",
					Index = 6,
					Key = ""
					}
				}
			};

		}

    public partial class FileDecrypt : _FileDecrypt {
        } // class FileDecrypt
	public interface IContainerOptions {
		String			Type{get; set;}
		}


    public class _ContainerCreate : Goedel.Command.Dispatch ,
							IEncryptOptions,
							IContainerOptions,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new NewFile ()			} ;

		/// <summary>Field accessor for option [recipient]</summary>
		public virtual String Recipient {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Recipient {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [sign]</summary>
		public virtual String Signer {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Signer {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [algdigest]</summary>
		public virtual String AlgDigest {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _AlgDigest {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [algencrypt]</summary>
		public virtual String AlgEncrypt {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _AlgEncrypt {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [mencrypt]</summary>
		public virtual String ModeEncrypt {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _ModeEncrypt {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [msign]</summary>
		public virtual String ModeSign {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _ModeSign {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [type]</summary>
		public virtual String Type {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Type {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _AccountID {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[8] as String;
			set => _Data[8]  = value;
			}

		public virtual string _UDF {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[9] as Flag;
			set => _Data[9]  = value;
			}

		public virtual string _Verbose {
			set => _Data[9].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[10] as Flag;
			set => _Data[10]  = value;
			}

		public virtual string _Report {
			set => _Data[10].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[11] as Flag;
			set => _Data[11]  = value;
			}

		public virtual string _Json {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual NewFile Output {
			get => _Data[12] as NewFile;
			set => _Data[12]  = value;
			}

		public virtual string _Output {
			set => _Data[12].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "create",
			Brief =  "Create a new DARE Container",
			HandleDelegate =  CommandLineInterpreter.Handle_ContainerCreate,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Recipient", 
					Default = null, // null if null
					Brief = "Encrypt data for specified recipient",
					Index = 0,
					Key = "recipient"
					},
				new DescribeEntryOption () {
					Identifier = "Signer", 
					Default = null, // null if null
					Brief = "Sign data with specified key",
					Index = 1,
					Key = "sign"
					},
				new DescribeEntryOption () {
					Identifier = "AlgDigest", 
					Default = null, // null if null
					Brief = "The digest algorithm",
					Index = 2,
					Key = "algdigest"
					},
				new DescribeEntryOption () {
					Identifier = "AlgEncrypt", 
					Default = null, // null if null
					Brief = "The symmetric encryption algorithm",
					Index = 3,
					Key = "algencrypt"
					},
				new DescribeEntryOption () {
					Identifier = "ModeEncrypt", 
					Default = null, // null if null
					Brief = "The public key encryption mode",
					Index = 4,
					Key = "mencrypt"
					},
				new DescribeEntryOption () {
					Identifier = "ModeSign", 
					Default = null, // null if null
					Brief = "The signature mode",
					Index = 5,
					Key = "msign"
					},
				new DescribeEntryOption () {
					Identifier = "Type", 
					Default = null, // null if null
					Brief = "The container type, plain/tree/digest/chain/tree",
					Index = 6,
					Key = "type"
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 7,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 8,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 9,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 10,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 11,
					Key = "json"
					},
				new DescribeEntryParameter () {
					Identifier = "Output", 
					Default = null, // null if null
					Brief = "New container",
					Index = 12,
					Key = ""
					}
				}
			};

		}

    public partial class ContainerCreate : _ContainerCreate {
        } // class ContainerCreate

    public class _ContainerArchive : Goedel.Command.Dispatch ,
							IEncryptOptions,
							IAccountOptions,
							IReporting,
							IContainerOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new ExistingFile (),
			new NewFile ()			} ;

		/// <summary>Field accessor for option [recipient]</summary>
		public virtual String Recipient {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Recipient {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [sign]</summary>
		public virtual String Signer {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Signer {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [algdigest]</summary>
		public virtual String AlgDigest {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _AlgDigest {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [algencrypt]</summary>
		public virtual String AlgEncrypt {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _AlgEncrypt {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [mencrypt]</summary>
		public virtual String ModeEncrypt {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _ModeEncrypt {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [msign]</summary>
		public virtual String ModeSign {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _ModeSign {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _AccountID {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _UDF {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[8] as Flag;
			set => _Data[8]  = value;
			}

		public virtual string _Verbose {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[9] as Flag;
			set => _Data[9]  = value;
			}

		public virtual string _Report {
			set => _Data[9].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[10] as Flag;
			set => _Data[10]  = value;
			}

		public virtual string _Json {
			set => _Data[10].Parameter (value);
			}
		/// <summary>Field accessor for option [type]</summary>
		public virtual String Type {
			get => _Data[11] as String;
			set => _Data[11]  = value;
			}

		public virtual string _Type {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Input {
			get => _Data[12] as ExistingFile;
			set => _Data[12]  = value;
			}

		public virtual string _Input {
			set => _Data[12].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual NewFile Output {
			get => _Data[13] as NewFile;
			set => _Data[13]  = value;
			}

		public virtual string _Output {
			set => _Data[13].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "archive",
			Brief =  "Create a new DARE Container and archive the specified files",
			HandleDelegate =  CommandLineInterpreter.Handle_ContainerArchive,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Recipient", 
					Default = null, // null if null
					Brief = "Encrypt data for specified recipient",
					Index = 0,
					Key = "recipient"
					},
				new DescribeEntryOption () {
					Identifier = "Signer", 
					Default = null, // null if null
					Brief = "Sign data with specified key",
					Index = 1,
					Key = "sign"
					},
				new DescribeEntryOption () {
					Identifier = "AlgDigest", 
					Default = null, // null if null
					Brief = "The digest algorithm",
					Index = 2,
					Key = "algdigest"
					},
				new DescribeEntryOption () {
					Identifier = "AlgEncrypt", 
					Default = null, // null if null
					Brief = "The symmetric encryption algorithm",
					Index = 3,
					Key = "algencrypt"
					},
				new DescribeEntryOption () {
					Identifier = "ModeEncrypt", 
					Default = null, // null if null
					Brief = "The public key encryption mode",
					Index = 4,
					Key = "mencrypt"
					},
				new DescribeEntryOption () {
					Identifier = "ModeSign", 
					Default = null, // null if null
					Brief = "The signature mode",
					Index = 5,
					Key = "msign"
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 6,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 7,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 8,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 9,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 10,
					Key = "json"
					},
				new DescribeEntryOption () {
					Identifier = "Type", 
					Default = null, // null if null
					Brief = "The container type, plain/tree/digest/chain/tree",
					Index = 11,
					Key = "type"
					},
				new DescribeEntryParameter () {
					Identifier = "Input", 
					Default = null, // null if null
					Brief = "Directory containing files to create archive from",
					Index = 12,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Output", 
					Default = null, // null if null
					Brief = "New container",
					Index = 13,
					Key = ""
					}
				}
			};

		}

    public partial class ContainerArchive : _ContainerArchive {
        } // class ContainerArchive

    public class _ContainerAppend : Goedel.Command.Dispatch ,
							IEncryptOptions,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new ExistingFile (),
			new NewFile ()			} ;

		/// <summary>Field accessor for option [recipient]</summary>
		public virtual String Recipient {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Recipient {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [sign]</summary>
		public virtual String Signer {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Signer {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [algdigest]</summary>
		public virtual String AlgDigest {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _AlgDigest {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [algencrypt]</summary>
		public virtual String AlgEncrypt {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _AlgEncrypt {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [mencrypt]</summary>
		public virtual String ModeEncrypt {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _ModeEncrypt {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [msign]</summary>
		public virtual String ModeSign {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _ModeSign {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _AccountID {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _UDF {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[8] as Flag;
			set => _Data[8]  = value;
			}

		public virtual string _Verbose {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[9] as Flag;
			set => _Data[9]  = value;
			}

		public virtual string _Report {
			set => _Data[9].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[10] as Flag;
			set => _Data[10]  = value;
			}

		public virtual string _Json {
			set => _Data[10].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Input {
			get => _Data[11] as ExistingFile;
			set => _Data[11]  = value;
			}

		public virtual string _Input {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual NewFile Output {
			get => _Data[12] as NewFile;
			set => _Data[12]  = value;
			}

		public virtual string _Output {
			set => _Data[12].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "append",
			Brief =  "Append the specified file as an entry to the specified container",
			HandleDelegate =  CommandLineInterpreter.Handle_ContainerAppend,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Recipient", 
					Default = null, // null if null
					Brief = "Encrypt data for specified recipient",
					Index = 0,
					Key = "recipient"
					},
				new DescribeEntryOption () {
					Identifier = "Signer", 
					Default = null, // null if null
					Brief = "Sign data with specified key",
					Index = 1,
					Key = "sign"
					},
				new DescribeEntryOption () {
					Identifier = "AlgDigest", 
					Default = null, // null if null
					Brief = "The digest algorithm",
					Index = 2,
					Key = "algdigest"
					},
				new DescribeEntryOption () {
					Identifier = "AlgEncrypt", 
					Default = null, // null if null
					Brief = "The symmetric encryption algorithm",
					Index = 3,
					Key = "algencrypt"
					},
				new DescribeEntryOption () {
					Identifier = "ModeEncrypt", 
					Default = null, // null if null
					Brief = "The public key encryption mode",
					Index = 4,
					Key = "mencrypt"
					},
				new DescribeEntryOption () {
					Identifier = "ModeSign", 
					Default = null, // null if null
					Brief = "The signature mode",
					Index = 5,
					Key = "msign"
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 6,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 7,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 8,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 9,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 10,
					Key = "json"
					},
				new DescribeEntryParameter () {
					Identifier = "Input", 
					Default = null, // null if null
					Brief = "Container to append to",
					Index = 11,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Output", 
					Default = null, // null if null
					Brief = "File to append",
					Index = 12,
					Key = ""
					}
				}
			};

		}

    public partial class ContainerAppend : _ContainerAppend {
        } // class ContainerAppend

    public class _ContainerExtract : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new ExistingFile (),
			new NewFile (),
			new Integer (),
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Input {
			get => _Data[0] as ExistingFile;
			set => _Data[0]  = value;
			}

		public virtual string _Input {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual NewFile Output {
			get => _Data[1] as NewFile;
			set => _Data[1]  = value;
			}

		public virtual string _Output {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [record]</summary>
		public virtual Integer Record {
			get => _Data[2] as Integer;
			set => _Data[2]  = value;
			}

		public virtual string _Record {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [file]</summary>
		public virtual String Filename {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _Filename {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _AccountID {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _UDF {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[6] as Flag;
			set => _Data[6]  = value;
			}

		public virtual string _Verbose {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[7] as Flag;
			set => _Data[7]  = value;
			}

		public virtual string _Report {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[8] as Flag;
			set => _Data[8]  = value;
			}

		public virtual string _Json {
			set => _Data[8].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "extract",
			Brief =  "Extract the specified record from the container",
			HandleDelegate =  CommandLineInterpreter.Handle_ContainerExtract,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Input", 
					Default = null, // null if null
					Brief = "Container to read",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Output", 
					Default = null, // null if null
					Brief = "Extracted file",
					Index = 1,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Record", 
					Default = "-1", // null if null
					Brief = "Index number of file to extract",
					Index = 2,
					Key = "record"
					},
				new DescribeEntryOption () {
					Identifier = "Filename", 
					Default = null, // null if null
					Brief = "Name of file to extract",
					Index = 3,
					Key = "file"
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 4,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 5,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 6,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 7,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 8,
					Key = "json"
					}
				}
			};

		}

    public partial class ContainerExtract : _ContainerExtract {
        } // class ContainerExtract

    public class _ContainerCopy : Goedel.Command.Dispatch ,
							IEncryptOptions,
							IContainerOptions,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new ExistingFile (),
			new NewFile (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Input {
			get => _Data[0] as ExistingFile;
			set => _Data[0]  = value;
			}

		public virtual string _Input {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual NewFile Output {
			get => _Data[1] as NewFile;
			set => _Data[1]  = value;
			}

		public virtual string _Output {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [recipient]</summary>
		public virtual String Recipient {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _Recipient {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [sign]</summary>
		public virtual String Signer {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _Signer {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [algdigest]</summary>
		public virtual String AlgDigest {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _AlgDigest {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [algencrypt]</summary>
		public virtual String AlgEncrypt {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _AlgEncrypt {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [mencrypt]</summary>
		public virtual String ModeEncrypt {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _ModeEncrypt {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [msign]</summary>
		public virtual String ModeSign {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _ModeSign {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [type]</summary>
		public virtual String Type {
			get => _Data[8] as String;
			set => _Data[8]  = value;
			}

		public virtual string _Type {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[9] as String;
			set => _Data[9]  = value;
			}

		public virtual string _AccountID {
			set => _Data[9].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[10] as String;
			set => _Data[10]  = value;
			}

		public virtual string _UDF {
			set => _Data[10].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[11] as Flag;
			set => _Data[11]  = value;
			}

		public virtual string _Verbose {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[12] as Flag;
			set => _Data[12]  = value;
			}

		public virtual string _Report {
			set => _Data[12].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[13] as Flag;
			set => _Data[13]  = value;
			}

		public virtual string _Json {
			set => _Data[13].Parameter (value);
			}
		/// <summary>Field accessor for option [decrypt]</summary>
		public virtual Flag Decrypt {
			get => _Data[14] as Flag;
			set => _Data[14]  = value;
			}

		public virtual string _Decrypt {
			set => _Data[14].Parameter (value);
			}
		/// <summary>Field accessor for option [index]</summary>
		public virtual Flag Index {
			get => _Data[15] as Flag;
			set => _Data[15]  = value;
			}

		public virtual string _Index {
			set => _Data[15].Parameter (value);
			}
		/// <summary>Field accessor for option [purge]</summary>
		public virtual Flag Purge {
			get => _Data[16] as Flag;
			set => _Data[16]  = value;
			}

		public virtual string _Purge {
			set => _Data[16].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "copy",
			Brief =  "Copy container contents to create a new container",
			HandleDelegate =  CommandLineInterpreter.Handle_ContainerCopy,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Input", 
					Default = null, // null if null
					Brief = "Container to read",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Output", 
					Default = null, // null if null
					Brief = "Copy",
					Index = 1,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Recipient", 
					Default = null, // null if null
					Brief = "Encrypt data for specified recipient",
					Index = 2,
					Key = "recipient"
					},
				new DescribeEntryOption () {
					Identifier = "Signer", 
					Default = null, // null if null
					Brief = "Sign data with specified key",
					Index = 3,
					Key = "sign"
					},
				new DescribeEntryOption () {
					Identifier = "AlgDigest", 
					Default = null, // null if null
					Brief = "The digest algorithm",
					Index = 4,
					Key = "algdigest"
					},
				new DescribeEntryOption () {
					Identifier = "AlgEncrypt", 
					Default = null, // null if null
					Brief = "The symmetric encryption algorithm",
					Index = 5,
					Key = "algencrypt"
					},
				new DescribeEntryOption () {
					Identifier = "ModeEncrypt", 
					Default = null, // null if null
					Brief = "The public key encryption mode",
					Index = 6,
					Key = "mencrypt"
					},
				new DescribeEntryOption () {
					Identifier = "ModeSign", 
					Default = null, // null if null
					Brief = "The signature mode",
					Index = 7,
					Key = "msign"
					},
				new DescribeEntryOption () {
					Identifier = "Type", 
					Default = null, // null if null
					Brief = "The container type, plain/tree/digest/chain/tree",
					Index = 8,
					Key = "type"
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 9,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 10,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 11,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 12,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 13,
					Key = "json"
					},
				new DescribeEntryOption () {
					Identifier = "Decrypt", 
					Default = "false", // null if null
					Brief = "Decrypt contents",
					Index = 14,
					Key = "decrypt"
					},
				new DescribeEntryOption () {
					Identifier = "Index", 
					Default = "true", // null if null
					Brief = "Append an index record to the end",
					Index = 15,
					Key = "index"
					},
				new DescribeEntryOption () {
					Identifier = "Purge", 
					Default = "true", // null if null
					Brief = "Purge unused data etc.",
					Index = 16,
					Key = "purge"
					}
				}
			};

		}

    public partial class ContainerCopy : _ContainerCopy {
        } // class ContainerCopy

    public class _ContainerVerify : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new ExistingFile ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [udf]</summary>
		public virtual String UDF {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _UDF {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Verbose {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Report {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Json {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Input {
			get => _Data[5] as ExistingFile;
			set => _Data[5]  = value;
			}

		public virtual string _Input {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "verify",
			Brief =  "Verify signatures and digests on container.",
			HandleDelegate =  CommandLineInterpreter.Handle_ContainerVerify,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com)",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 4,
					Key = "json"
					},
				new DescribeEntryParameter () {
					Identifier = "Input", 
					Default = null, // null if null
					Brief = "Container to read",
					Index = 5,
					Key = ""
					}
				}
			};

		}

    public partial class ContainerVerify : _ContainerVerify {
        } // class ContainerVerify


    public partial class  NewFile : _NewFile {
        public static NewFile Factory (string Value) {
            var Result = new NewFile();
            Result.Default(Value);
            return Result;
            }
        } // NewFile


    public partial class  ExistingFile : _ExistingFile {
        public static ExistingFile Factory (string Value) {
            var Result = new ExistingFile();
            Result.Default(Value);
            return Result;
            }
        } // ExistingFile


    public partial class  Flag : _Flag {
        public static Flag Factory (string Value) {
            var Result = new Flag();
            Result.Default(Value);
            return Result;
            }
        } // Flag


    public partial class  String : _String {
        public static String Factory (string Value) {
            var Result = new String();
            Result.Default(Value);
            return Result;
            }
        } // String


    public partial class  Integer : _Integer {
        public static Integer Factory (string Value) {
            var Result = new Integer();
            Result.Default(Value);
            return Result;
            }
        } // Integer



	// The stub class just contains routines that echo their arguments and
	// write 'not yet implemented'

	// Eventually there will be a compiler option to suppress the debugging
	// to eliminate the redundant code
    public class _DareShell : global::Goedel.Command.DispatchShell {

		public virtual void ProfileReset ( ProfileReset Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void DeviceCreate ( DeviceCreate Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void PersonalCreate ( PersonalCreate Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ProfileRegister ( ProfileRegister Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ProfileSync ( ProfileSync Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ProfileEscrow ( ProfileEscrow Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ProfileRecover ( ProfileRecover Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ProfileExport ( ProfileExport Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ProfileImport ( ProfileImport Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ProfileList ( ProfileList Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ProfileDump ( ProfileDump Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ProfilePending ( ProfilePending Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ProfileConnect ( ProfileConnect Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ProfileAccept ( ProfileAccept Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ProfileReject ( ProfileReject Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ProfileGetPIN ( ProfileGetPIN Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ProfileComplete ( ProfileComplete Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void MailAdd ( MailAdd Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void MailUpdate ( MailUpdate Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void SMIMEPrivate ( SMIMEPrivate Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void SMIMEPublic ( SMIMEPublic Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void PGPPrivate ( PGPPrivate Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void PGPPublic ( PGPPublic Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void SSHAddHost ( SSHAddHost Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void SSHAddClient ( SSHAddClient Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void SSHHost ( SSHHost Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void SSHCreate ( SSHCreate Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void SSHKnown ( SSHKnown Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void SSHAuth ( SSHAuth Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void SSHPrivate ( SSHPrivate Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void SSHPublic ( SSHPublic Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void PasswordAdd ( PasswordAdd Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void PasswordGet ( PasswordGet Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void PasswordDelete ( PasswordDelete Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void PasswordDump ( PasswordDump Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ContactAdd ( ContactAdd Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ContactDelete ( ContactDelete Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ContactdGet ( ContactdGet Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ContactDump ( ContactDump Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void BookmarkAdd ( BookmarkAdd Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void BookmarkDelete ( BookmarkDelete Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void BookmarkDump ( BookmarkDump Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void CalendarAdd ( CalendarAdd Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void CalendarDelete ( CalendarDelete Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void CalendarDump ( CalendarDump Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void NetworkAdd ( NetworkAdd Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void NetworkDelete ( NetworkDelete Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void NetworkDump ( NetworkDump Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void MessageConnect ( MessageConnect Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void MessageConfirm ( MessageConfirm Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void MessageStatus ( MessageStatus Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void MessagePending ( MessagePending Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void MessageAccept ( MessageAccept Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void MessageReject ( MessageReject Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void MessageBlock ( MessageBlock Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void GroupAdd ( GroupAdd Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void GroupCreate ( GroupCreate Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void GroupUser ( GroupUser Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void GroupDelete ( GroupDelete Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void FileEncrypt ( FileEncrypt Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void FileDecrypt ( FileDecrypt Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ContainerCreate ( ContainerCreate Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ContainerArchive ( ContainerArchive Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ContainerAppend ( ContainerAppend Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ContainerExtract ( ContainerExtract Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ContainerCopy ( ContainerCopy Options) =>
			CommandLineInterpreter.DescribeValues (Options);

		public virtual void ContainerVerify ( ContainerVerify Options) =>
			CommandLineInterpreter.DescribeValues (Options);


        } // class _DareShell

    public partial class DareShell : _DareShell {
        } // class DareShell

    } // namespace DareShell


