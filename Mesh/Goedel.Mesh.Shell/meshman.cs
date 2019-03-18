﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Command;
using Goedel.Utilities;

namespace Goedel.Mesh.Shell {

	// Enumeration type
	public enum EnumReporting {
        /// <summary>Case "json": Report output in JSON format</summary>
        eJson,
        /// <summary>Case "verbose": Verbose reports</summary>
        eVerbose,
        /// <summary>Case "report": Report output (default)</summary>
        eReport,
        /// <summary>Case "silent": Suppress output</summary>
        eSilent
		}

	// Enumeration type
	public enum EnumAuthentication {
        /// <summary>Case "plain": No authentication</summary>
        ePlain,
        /// <summary>Case "digest": Digest authentication</summary>
        eDigest,
        /// <summary>Case "chain": Chained digest authentication</summary>
        eChain,
        /// <summary>Case "tree": Tree without authentication</summary>
        eTree,
        /// <summary>Case "merkel": Merkel tree authentication</summary>
        eMerkel
		}

	// Enumeration type
	public enum EnumUse {
        /// <summary>Case "log": Log</summary>
        eLog,
        /// <summary>Case "archive": Archive</summary>
        eArchive,
        /// <summary>Case "spool": Message spool</summary>
        eSpool,
        /// <summary>Case "catalog": Object catalog</summary>
        eCatalog
		}



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
        /// Default help dispatch
        /// </summary>
        /// <param name="Dispatch">The command description.</param>
        /// <param name="args">The set of arguments.</param>
        /// <param name="index">The first unparsed argument.</param>
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

		public static DescribeEntryEnumerate DescribeEnumReporting = new DescribeEntryEnumerate () {
            Identifier = "report",
            Brief = "Reporting level",
            Entries = new List<DescribeCase>() { 
				new DescribeCase () {
					Identifier = "json",
					Brief = "Report output in JSON format",
					Value = (int) EnumReporting.eJson
					},
				new DescribeCase () {
					Identifier = "verbose",
					Brief = "Verbose reports",
					Value = (int) EnumReporting.eVerbose
					},
				new DescribeCase () {
					Identifier = "report",
					Brief = "Report output (default)",
					Value = (int) EnumReporting.eReport
					},
				new DescribeCase () {
					Identifier = "silent",
					Brief = "Suppress output",
					Value = (int) EnumReporting.eSilent
					}
				}
			};
		public static DescribeEntryEnumerate DescribeEnumAuthentication = new DescribeEntryEnumerate () {
            Identifier = "auth",
            Brief = "Authentication and indexing",
            Entries = new List<DescribeCase>() { 
				new DescribeCase () {
					Identifier = "plain",
					Brief = "No authentication",
					Value = (int) EnumAuthentication.ePlain
					},
				new DescribeCase () {
					Identifier = "digest",
					Brief = "Digest authentication",
					Value = (int) EnumAuthentication.eDigest
					},
				new DescribeCase () {
					Identifier = "chain",
					Brief = "Chained digest authentication",
					Value = (int) EnumAuthentication.eChain
					},
				new DescribeCase () {
					Identifier = "tree",
					Brief = "Tree without authentication",
					Value = (int) EnumAuthentication.eTree
					},
				new DescribeCase () {
					Identifier = "merkel",
					Brief = "Merkel tree authentication",
					Value = (int) EnumAuthentication.eMerkel
					}
				}
			};
		public static DescribeEntryEnumerate DescribeEnumUse = new DescribeEntryEnumerate () {
            Identifier = "use",
            Brief = "<Unspecified>",
            Entries = new List<DescribeCase>() { 
				new DescribeCase () {
					Identifier = "log",
					Brief = "Log",
					Value = (int) EnumUse.eLog
					},
				new DescribeCase () {
					Identifier = "archive",
					Brief = "Archive",
					Value = (int) EnumUse.eArchive
					},
				new DescribeCase () {
					Identifier = "spool",
					Brief = "Message spool",
					Value = (int) EnumUse.eSpool
					},
				new DescribeCase () {
					Identifier = "catalog",
					Brief = "Object catalog",
					Value = (int) EnumUse.eCatalog
					}
				}
			};

        static bool IsFlag(char c) =>
            (c == UnixFlag) | (c == WindowsFlag) ;




		public static DescribeCommandSet DescribeCommandSet_Profile = new DescribeCommandSet () {
            Identifier = "profile",
			Brief = "Manage personal and device profiles and accounts.",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"hello", _ProfileHello._DescribeCommand },
				{"create", _MasterCreate._DescribeCommand },
				{"register", _ProfileRegister._DescribeCommand },
				{"sync", _ProfileSync._DescribeCommand },
				{"escrow", _ProfileEscrow._DescribeCommand },
				{"recover", _ProfileRecover._DescribeCommand },
				{"export", _ProfileExport._DescribeCommand },
				{"import", _ProfileImport._DescribeCommand },
				{"list", _ProfileList._DescribeCommand },
				{"get", _ProfileDump._DescribeCommand }
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_Connect = new DescribeCommandSet () {
            Identifier = "device",
			Brief = "Device management commands.",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"create", _DeviceCreate._DescribeCommand },
				{"auth", _DeviceAuthorize._DescribeCommand },
				{"request", _ProfileConnect._DescribeCommand },
				{"pending", _ProfilePending._DescribeCommand },
				{"accept", _ProfileAccept._DescribeCommand },
				{"reject", _ProfileReject._DescribeCommand },
				{"pin", _ProfileGetPIN._DescribeCommand },
				{"earl", _ConnectEarl._DescribeCommand },
				{"delete", _DeviceDelete._DescribeCommand },
				{"list", _DeviceList._DescribeCommand }
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_Message = new DescribeCommandSet () {
            Identifier = "message",
			Brief = "Contact and confirmation message options",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"contact", _MessageContact._DescribeCommand },
				{"confirm", _MessageConfirm._DescribeCommand },
				{"pending", _MessagePending._DescribeCommand },
				{"status", _MessageStatus._DescribeCommand },
				{"accept", _MessageAccept._DescribeCommand },
				{"reject", _MessageReject._DescribeCommand },
				{"block", _MessageBlock._DescribeCommand }
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_Group = new DescribeCommandSet () {
            Identifier = "group",
			Brief = "Group management commands",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"create", _GroupCreate._DescribeCommand },
				{"add", _GroupAdd._DescribeCommand },
				{"delete", _GroupDelete._DescribeCommand },
				{"list", _GroupList._DescribeCommand }
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_Mail = new DescribeCommandSet () {
            Identifier = "mail",
			Brief = "Manage mail profiles connected to a personal profile",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"add", _MailAdd._DescribeCommand },
				{"update", _MailUpdate._DescribeCommand },
				{"smime", DescribeCommandSet_SMIME},
				{"openpgp", DescribeCommandSet_PGP}
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_SMIME = new DescribeCommandSet () {
            Identifier = "smime",
			Brief = "<Unspecified>",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"private", _SMIMEPrivate._DescribeCommand },
				{"public", _SMIMEPublic._DescribeCommand }
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_PGP = new DescribeCommandSet () {
            Identifier = "openpgp",
			Brief = "<Unspecified>",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"private", _PGPPrivate._DescribeCommand },
				{"public", _PGPPublic._DescribeCommand }
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_SSH = new DescribeCommandSet () {
            Identifier = "ssh",
			Brief = "Manage SSH profiles connected to a personal profile",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"create", _SSHCreate._DescribeCommand },
				{"private", _SSHPrivate._DescribeCommand },
				{"public", _SSHPublic._DescribeCommand },
				{"merge", DescribeCommandSet_SSHMerge},
				{"add", DescribeCommandSet_SSHAdd},
				{"show", DescribeCommandSet_SSHShow}
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_SSHMerge = new DescribeCommandSet () {
            Identifier = "merge",
			Brief = "<Unspecified>",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"host", _SSHMergeKnown._DescribeCommand },
				{"client", _SSHMergeClient._DescribeCommand }
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_SSHAdd = new DescribeCommandSet () {
            Identifier = "add",
			Brief = "<Unspecified>",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"host", _SSHAddHost._DescribeCommand },
				{"client", _SSHAddClient._DescribeCommand }
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_SSHShow = new DescribeCommandSet () {
            Identifier = "show",
			Brief = "<Unspecified>",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"host", _SSHKnown._DescribeCommand },
				{"client", _SSHAuth._DescribeCommand }
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_Password = new DescribeCommandSet () {
            Identifier = "password",
			Brief = "Manage password catalogs connected to an account",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"add", _PasswordAdd._DescribeCommand },
				{"get", _PasswordGet._DescribeCommand },
				{"delete", _PasswordDelete._DescribeCommand },
				{"list", _PasswordDump._DescribeCommand }
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_Contact = new DescribeCommandSet () {
            Identifier = "contact",
			Brief = "Manage contact catalogs connected to an account",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"add", _ContactAdd._DescribeCommand },
				{"delete", _ContactDelete._DescribeCommand },
				{"get", _ContactGet._DescribeCommand },
				{"list", _ContactDump._DescribeCommand }
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_Bookmark = new DescribeCommandSet () {
            Identifier = "bookmark",
			Brief = "Manage bookmark catalogs connected to an account",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"add", _BookmarkAdd._DescribeCommand },
				{"delete", _BookmarkDelete._DescribeCommand },
				{"get", _BookmarkGet._DescribeCommand },
				{"list", _BookmarkDump._DescribeCommand }
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_Calendar = new DescribeCommandSet () {
            Identifier = "calendar",
			Brief = "Manage calendar catalogs connected to an account",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"add", _CalendarAdd._DescribeCommand },
				{"get", _CalendarGet._DescribeCommand },
				{"delete", _CalendarDelete._DescribeCommand },
				{"dump", _CalendarDump._DescribeCommand }
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_Network = new DescribeCommandSet () {
            Identifier = "network",
			Brief = "Manage network profile settings",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"add", _NetworkAdd._DescribeCommand },
				{"get", _NetworkGet._DescribeCommand },
				{"delete", _NetworkDelete._DescribeCommand },
				{"dump", _NetworkDump._DescribeCommand }
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_Key = new DescribeCommandSet () {
            Identifier = "key",
			Brief = "Key operations.",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"nonce", _KeyNonce._DescribeCommand },
				{"secret", _KeySecret._DescribeCommand },
				{"earl", _KeyEarl._DescribeCommand },
				{"share", _KeyShare._DescribeCommand },
				{"recover", _KeyRecover._DescribeCommand }
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_Hash = new DescribeCommandSet () {
            Identifier = "hash",
			Brief = "Content Digest and Message Authentication Code operations on files",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"udf", _HashUDF._DescribeCommand },
				{"digest", _HashDigest._DescribeCommand },
				{"mac", _HashMac._DescribeCommand }
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_Dare = new DescribeCommandSet () {
            Identifier = "dare",
			Brief = "DARE Message encryption and decryption commands",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"encode", _DareEncode._DescribeCommand },
				{"decode", _DareDecode._DescribeCommand },
				{"verify", _DareVerify._DescribeCommand },
				{"earl", _DareEARL._DescribeCommand }
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_Container = new DescribeCommandSet () {
            Identifier = "container",
			Brief = "DARE container commands",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"create", _ContainerCreate._DescribeCommand },
				{"archive", _ContainerArchive._DescribeCommand },
				{"append", _ContainerAppend._DescribeCommand },
				{"delete", _ContainerDelete._DescribeCommand },
				{"index", _ContainerIndex._DescribeCommand },
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

				Description = "Mathematical Mesh command tool";

			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"profile", DescribeCommandSet_Profile},
				{"device", DescribeCommandSet_Connect},
				{"message", DescribeCommandSet_Message},
				{"group", DescribeCommandSet_Group},
				{"mail", DescribeCommandSet_Mail},
				{"ssh", DescribeCommandSet_SSH},
				{"password", DescribeCommandSet_Password},
				{"contact", DescribeCommandSet_Contact},
				{"bookmark", DescribeCommandSet_Bookmark},
				{"calendar", DescribeCommandSet_Calendar},
				{"network", DescribeCommandSet_Network},
				{"key", DescribeCommandSet_Key},
				{"hash", DescribeCommandSet_Hash},
				{"dare", DescribeCommandSet_Dare},
				{"container", DescribeCommandSet_Container},
				{"about", DescribeAbout },
				{"help", DescribeHelp }
				}; // End Entries



            }



        public void MainMethod(string[] Args) {
			Shell Dispatch = new Shell ();

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


        public void MainMethod(Shell Dispatch, string[] Args) =>
			Dispatcher (Entries, DefaultCommand, Dispatch, Args, 0);




		public static void Handle_ProfileHello (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ProfileHello		Options = new ProfileHello ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ProfileHello (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_MasterCreate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			MasterCreate		Options = new MasterCreate ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.MasterCreate (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ProfileRegister (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ProfileRegister		Options = new ProfileRegister ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ProfileRegister (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ProfileSync (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ProfileSync		Options = new ProfileSync ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ProfileSync (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ProfileEscrow (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ProfileEscrow		Options = new ProfileEscrow ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ProfileEscrow (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ProfileRecover (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ProfileRecover		Options = new ProfileRecover ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ProfileRecover (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ProfileExport (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ProfileExport		Options = new ProfileExport ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ProfileExport (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ProfileImport (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ProfileImport		Options = new ProfileImport ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ProfileImport (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ProfileList (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ProfileList		Options = new ProfileList ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ProfileList (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ProfileDump (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ProfileDump		Options = new ProfileDump ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ProfileDump (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DeviceCreate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DeviceCreate		Options = new DeviceCreate ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DeviceCreate (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DeviceAuthorize (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DeviceAuthorize		Options = new DeviceAuthorize ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DeviceAuthorize (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ProfileConnect (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ProfileConnect		Options = new ProfileConnect ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ProfileConnect (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ProfilePending (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ProfilePending		Options = new ProfilePending ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ProfilePending (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ProfileAccept (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ProfileAccept		Options = new ProfileAccept ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ProfileAccept (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ProfileReject (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ProfileReject		Options = new ProfileReject ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ProfileReject (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ProfileGetPIN (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ProfileGetPIN		Options = new ProfileGetPIN ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ProfileGetPIN (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ConnectEarl (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ConnectEarl		Options = new ConnectEarl ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ConnectEarl (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DeviceDelete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DeviceDelete		Options = new DeviceDelete ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DeviceDelete (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DeviceList (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DeviceList		Options = new DeviceList ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DeviceList (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_MessageContact (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			MessageContact		Options = new MessageContact ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.MessageContact (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_MessageConfirm (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			MessageConfirm		Options = new MessageConfirm ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.MessageConfirm (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_MessagePending (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			MessagePending		Options = new MessagePending ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.MessagePending (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_MessageStatus (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			MessageStatus		Options = new MessageStatus ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.MessageStatus (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_MessageAccept (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			MessageAccept		Options = new MessageAccept ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.MessageAccept (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_MessageReject (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			MessageReject		Options = new MessageReject ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.MessageReject (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_MessageBlock (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			MessageBlock		Options = new MessageBlock ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.MessageBlock (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_GroupCreate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			GroupCreate		Options = new GroupCreate ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.GroupCreate (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_GroupAdd (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			GroupAdd		Options = new GroupAdd ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.GroupAdd (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_GroupDelete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			GroupDelete		Options = new GroupDelete ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.GroupDelete (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_GroupList (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			GroupList		Options = new GroupList ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.GroupList (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_MailAdd (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			MailAdd		Options = new MailAdd ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.MailAdd (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_MailUpdate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			MailUpdate		Options = new MailUpdate ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.MailUpdate (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_SMIMEPrivate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			SMIMEPrivate		Options = new SMIMEPrivate ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.SMIMEPrivate (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_SMIMEPublic (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			SMIMEPublic		Options = new SMIMEPublic ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.SMIMEPublic (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_PGPPrivate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			PGPPrivate		Options = new PGPPrivate ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.PGPPrivate (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_PGPPublic (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			PGPPublic		Options = new PGPPublic ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.PGPPublic (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_SSHCreate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			SSHCreate		Options = new SSHCreate ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.SSHCreate (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_SSHPrivate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			SSHPrivate		Options = new SSHPrivate ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.SSHPrivate (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_SSHPublic (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			SSHPublic		Options = new SSHPublic ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.SSHPublic (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_SSHMergeKnown (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			SSHMergeKnown		Options = new SSHMergeKnown ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.SSHMergeKnown (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_SSHMergeClient (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			SSHMergeClient		Options = new SSHMergeClient ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.SSHMergeClient (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_SSHAddHost (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			SSHAddHost		Options = new SSHAddHost ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.SSHAddHost (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_SSHAddClient (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			SSHAddClient		Options = new SSHAddClient ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.SSHAddClient (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_SSHKnown (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			SSHKnown		Options = new SSHKnown ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.SSHKnown (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_SSHAuth (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			SSHAuth		Options = new SSHAuth ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.SSHAuth (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_PasswordAdd (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			PasswordAdd		Options = new PasswordAdd ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.PasswordAdd (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_PasswordGet (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			PasswordGet		Options = new PasswordGet ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.PasswordGet (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_PasswordDelete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			PasswordDelete		Options = new PasswordDelete ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.PasswordDelete (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_PasswordDump (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			PasswordDump		Options = new PasswordDump ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.PasswordDump (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ContactAdd (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ContactAdd		Options = new ContactAdd ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ContactAdd (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ContactDelete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ContactDelete		Options = new ContactDelete ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ContactDelete (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ContactGet (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ContactGet		Options = new ContactGet ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ContactGet (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ContactDump (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ContactDump		Options = new ContactDump ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ContactDump (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_BookmarkAdd (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			BookmarkAdd		Options = new BookmarkAdd ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.BookmarkAdd (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_BookmarkDelete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			BookmarkDelete		Options = new BookmarkDelete ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.BookmarkDelete (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_BookmarkGet (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			BookmarkGet		Options = new BookmarkGet ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.BookmarkGet (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_BookmarkDump (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			BookmarkDump		Options = new BookmarkDump ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.BookmarkDump (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_CalendarAdd (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			CalendarAdd		Options = new CalendarAdd ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.CalendarAdd (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_CalendarGet (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			CalendarGet		Options = new CalendarGet ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.CalendarGet (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_CalendarDelete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			CalendarDelete		Options = new CalendarDelete ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.CalendarDelete (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_CalendarDump (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			CalendarDump		Options = new CalendarDump ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.CalendarDump (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_NetworkAdd (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			NetworkAdd		Options = new NetworkAdd ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.NetworkAdd (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_NetworkGet (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			NetworkGet		Options = new NetworkGet ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.NetworkGet (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_NetworkDelete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			NetworkDelete		Options = new NetworkDelete ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.NetworkDelete (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_NetworkDump (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			NetworkDump		Options = new NetworkDump ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.NetworkDump (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_KeyNonce (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			KeyNonce		Options = new KeyNonce ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.KeyNonce (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_KeySecret (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			KeySecret		Options = new KeySecret ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.KeySecret (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_KeyEarl (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			KeyEarl		Options = new KeyEarl ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.KeyEarl (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_KeyShare (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			KeyShare		Options = new KeyShare ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.KeyShare (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_KeyRecover (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			KeyRecover		Options = new KeyRecover ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.KeyRecover (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_HashUDF (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			HashUDF		Options = new HashUDF ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.HashUDF (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_HashDigest (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			HashDigest		Options = new HashDigest ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.HashDigest (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_HashMac (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			HashMac		Options = new HashMac ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.HashMac (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DareEncode (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DareEncode		Options = new DareEncode ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DareEncode (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DareDecode (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DareDecode		Options = new DareDecode ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DareDecode (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DareVerify (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DareVerify		Options = new DareVerify ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DareVerify (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DareEARL (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DareEARL		Options = new DareEARL ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DareEARL (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ContainerCreate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ContainerCreate		Options = new ContainerCreate ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ContainerCreate (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ContainerArchive (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ContainerArchive		Options = new ContainerArchive ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ContainerArchive (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ContainerAppend (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ContainerAppend		Options = new ContainerAppend ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ContainerAppend (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ContainerDelete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ContainerDelete		Options = new ContainerDelete ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ContainerDelete (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ContainerIndex (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ContainerIndex		Options = new ContainerIndex ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ContainerIndex (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ContainerExtract (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ContainerExtract		Options = new ContainerExtract ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ContainerExtract (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ContainerCopy (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ContainerCopy		Options = new ContainerCopy ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ContainerCopy (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ContainerVerify (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ContainerVerify		Options = new ContainerVerify ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ContainerVerify (Options);
			Dispatch._PostProcess (result);
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
		String			Mesh{get; set;}
		}

	public interface IDeviceProfileInfo {
		Flag			DeviceNew{get; set;}
		String			DeviceUDF{get; set;}
		String			DeviceID{get; set;}
		String			DeviceDescription{get; set;}
		}

	public interface IDeviceAuthOptions {
		String			Auth{get; set;}
		Flag			AuthAdmin{get; set;}
		Flag			AuthAll{get; set;}
		Flag			AuthSSH{get; set;}
		Flag			AuthPassword{get; set;}
		Flag			AuthMessage{get; set;}
		Flag			AuthContacts{get; set;}
		Flag			AuthCalendar{get; set;}
		Flag			AuthNetwork{get; set;}
		Flag			AuthConfirm{get; set;}
		Flag			AuthBookmark{get; set;}
		}

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

	public interface ILengthOptions {
		Integer			Bits{get; set;}
		}

	public interface ICryptoOptions {
		String			Algorithms{get; set;}
		}

	public interface IEncodeOptions {
		String			ContentType{get; set;}
		String			Encrypt{get; set;}
		String			Sign{get; set;}
		Flag			Hash{get; set;}
		}

	public interface IDigestOptions {
		String			DigestKey{get; set;}
		}

	public interface IContainerOptions {
		String			Type{get; set;}
		}


    public class _ProfileHello : Goedel.Command.Dispatch ,
							IAccountOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "hello",
			Brief =  "Connect to the service(s) a profile is connected to and report status.",
			HandleDelegate =  CommandLineInterpreter.Handle_ProfileHello,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					}
				}
			};

		}

    public partial class ProfileHello : _ProfileHello {
        } // class ProfileHello

    public class _MasterCreate : Goedel.Command.Dispatch ,
							IReporting,
							IDeviceProfileInfo,
							ICryptoOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
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
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
		/// <summary>Field accessor for option [alg]</summary>
		public virtual String Algorithms {
			get => _Data[9] as String;
			set => _Data[9]  = value;
			}

		public virtual string _Algorithms {
			set => _Data[9].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "create",
			Brief =  "Create new personal profile",
			HandleDelegate =  CommandLineInterpreter.Handle_MasterCreate,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "NewAccountID", 
					Default = null, // null if null
					Brief = "New account",
					Index = 0,
					Key = ""
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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
					Default = "false", // null if null
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
					},
				new DescribeEntryOption () {
					Identifier = "Algorithms", 
					Default = null, // null if null
					Brief = "List of algorithm specifiers",
					Index = 9,
					Key = "alg"
					}
				}
			};

		}

    public partial class MasterCreate : _MasterCreate {
        } // class MasterCreate

    public class _ProfileRegister : Goedel.Command.Dispatch ,
							IReporting,
							IAccountOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual String NewAccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _NewAccountID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Mesh {
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
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 5,
					Key = "mesh"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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
							ICryptoOptions,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new NewFile (),
			new Integer (),
			new Integer ()			} ;





		/// <summary>Field accessor for option [alg]</summary>
		public virtual String Algorithms {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Algorithms {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual NewFile File {
			get => _Data[6] as NewFile;
			set => _Data[6]  = value;
			}

		public virtual string _File {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [quorum]</summary>
		public virtual Integer Quorum {
			get => _Data[7] as Integer;
			set => _Data[7]  = value;
			}

		public virtual string _Quorum {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [shares]</summary>
		public virtual Integer Shares {
			get => _Data[8] as Integer;
			set => _Data[8]  = value;
			}

		public virtual string _Shares {
			set => _Data[8].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "escrow",
			Brief =  "Create a set of key escrow shares",
			HandleDelegate =  CommandLineInterpreter.Handle_ProfileEscrow,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Algorithms", 
					Default = null, // null if null
					Brief = "List of algorithm specifiers",
					Index = 0,
					Key = "alg"
					},
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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
				new DescribeEntryParameter () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 6,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Quorum", 
					Default = "2", // null if null
					Brief = "<Unspecified>",
					Index = 7,
					Key = "quorum"
					},
				new DescribeEntryOption () {
					Identifier = "Shares", 
					Default = "3", // null if null
					Brief = "<Unspecified>",
					Index = 8,
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
			new ExistingFile (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
		/// <summary>Field accessor for option [verify]</summary>
		public virtual Flag Verify {
			get => _Data[14] as Flag;
			set => _Data[14]  = value;
			}

		public virtual string _Verify {
			set => _Data[14].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "recover",
			Brief =  "Recover escrowed profile",
			HandleDelegate =  CommandLineInterpreter.Handle_ProfileRecover,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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
					},
				new DescribeEntryOption () {
					Identifier = "Verify", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 14,
					Key = "verify"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[0] as Enumeration<EnumReporting>;
			set => _Data[0]  = value;
			}

		public virtual string _EnumReporting {
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "list",
			Brief =  "List all profiles on the local machine",
			HandleDelegate =  CommandLineInterpreter.Handle_ProfileList,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 0,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
			Identifier = "get",
			Brief =  "Describe the specified profile",
			HandleDelegate =  CommandLineInterpreter.Handle_ProfileDump,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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

    public class _DeviceCreate : Goedel.Command.Dispatch ,
							ICryptoOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new String ()			} ;





		/// <summary>Field accessor for option [alg]</summary>
		public virtual String Algorithms {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Algorithms {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String DeviceID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _DeviceID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String DeviceDescription {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _DeviceDescription {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [default]</summary>
		public virtual Flag Default {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Default {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [ocr]</summary>
		public virtual String OCR {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _OCR {
			set => _Data[4].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "create",
			Brief =  "Create new device profile",
			HandleDelegate =  CommandLineInterpreter.Handle_DeviceCreate,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Algorithms", 
					Default = null, // null if null
					Brief = "List of algorithm specifiers",
					Index = 0,
					Key = "alg"
					},
				new DescribeEntryParameter () {
					Identifier = "DeviceID", 
					Default = null, // null if null
					Brief = "Device identifier",
					Index = 1,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "DeviceDescription", 
					Default = null, // null if null
					Brief = "Device description",
					Index = 2,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Default", 
					Default = null, // null if null
					Brief = "Make the new device profile the default",
					Index = 3,
					Key = "default"
					},
				new DescribeEntryOption () {
					Identifier = "OCR", 
					Default = null, // null if null
					Brief = "Make the new device profile the default",
					Index = 4,
					Key = "ocr"
					}
				}
			};

		}

    public partial class DeviceCreate : _DeviceCreate {
        } // class DeviceCreate

    public class _DeviceAuthorize : Goedel.Command.Dispatch ,
							IDeviceAuthOptions,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [auth]</summary>
		public virtual String Auth {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Auth {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [admin]</summary>
		public virtual Flag AuthAdmin {
			get => _Data[1] as Flag;
			set => _Data[1]  = value;
			}

		public virtual string _AuthAdmin {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [all]</summary>
		public virtual Flag AuthAll {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _AuthAll {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [ssh]</summary>
		public virtual Flag AuthSSH {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _AuthSSH {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [password]</summary>
		public virtual Flag AuthPassword {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _AuthPassword {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [message]</summary>
		public virtual Flag AuthMessage {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _AuthMessage {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [contacts]</summary>
		public virtual Flag AuthContacts {
			get => _Data[6] as Flag;
			set => _Data[6]  = value;
			}

		public virtual string _AuthContacts {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [calendar]</summary>
		public virtual Flag AuthCalendar {
			get => _Data[7] as Flag;
			set => _Data[7]  = value;
			}

		public virtual string _AuthCalendar {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [network]</summary>
		public virtual Flag AuthNetwork {
			get => _Data[8] as Flag;
			set => _Data[8]  = value;
			}

		public virtual string _AuthNetwork {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for option [confirm]</summary>
		public virtual Flag AuthConfirm {
			get => _Data[9] as Flag;
			set => _Data[9]  = value;
			}

		public virtual string _AuthConfirm {
			set => _Data[9].Parameter (value);
			}
		/// <summary>Field accessor for option [bookmark]</summary>
		public virtual Flag AuthBookmark {
			get => _Data[10] as Flag;
			set => _Data[10]  = value;
			}

		public virtual string _AuthBookmark {
			set => _Data[10].Parameter (value);
			}
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[11] as String;
			set => _Data[11]  = value;
			}

		public virtual string _Mesh {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[12] as Enumeration<EnumReporting>;
			set => _Data[12]  = value;
			}

		public virtual string _EnumReporting {
			set => _Data[12].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[13] as Flag;
			set => _Data[13]  = value;
			}

		public virtual string _Verbose {
			set => _Data[13].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[14] as Flag;
			set => _Data[14]  = value;
			}

		public virtual string _Report {
			set => _Data[14].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[15] as Flag;
			set => _Data[15]  = value;
			}

		public virtual string _Json {
			set => _Data[15].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "auth",
			Brief =  "Authorize device to use application",
			HandleDelegate =  CommandLineInterpreter.Handle_DeviceAuthorize,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Auth", 
					Default = null, // null if null
					Brief = "Authorize the specified function",
					Index = 0,
					Key = "auth"
					},
				new DescribeEntryOption () {
					Identifier = "AuthAdmin", 
					Default = "false", // null if null
					Brief = "Authorize device as administration device",
					Index = 1,
					Key = "admin"
					},
				new DescribeEntryOption () {
					Identifier = "AuthAll", 
					Default = "false", // null if null
					Brief = "Authorize device for all application catalogs",
					Index = 2,
					Key = "all"
					},
				new DescribeEntryOption () {
					Identifier = "AuthSSH", 
					Default = "false", // null if null
					Brief = "Authorize use of SSH",
					Index = 3,
					Key = "ssh"
					},
				new DescribeEntryOption () {
					Identifier = "AuthPassword", 
					Default = "false", // null if null
					Brief = "Authorize access to password catalog",
					Index = 4,
					Key = "password"
					},
				new DescribeEntryOption () {
					Identifier = "AuthMessage", 
					Default = "false", // null if null
					Brief = "Authorize access to send and receive messages.",
					Index = 5,
					Key = "message"
					},
				new DescribeEntryOption () {
					Identifier = "AuthContacts", 
					Default = "false", // null if null
					Brief = "Authorize access to contacts catalog",
					Index = 6,
					Key = "contacts"
					},
				new DescribeEntryOption () {
					Identifier = "AuthCalendar", 
					Default = "false", // null if null
					Brief = "Authorize access to calendar catalog",
					Index = 7,
					Key = "calendar"
					},
				new DescribeEntryOption () {
					Identifier = "AuthNetwork", 
					Default = "false", // null if null
					Brief = "Authorize access to network catalog",
					Index = 8,
					Key = "network"
					},
				new DescribeEntryOption () {
					Identifier = "AuthConfirm", 
					Default = "false", // null if null
					Brief = "Authorize response to confirmation requests",
					Index = 9,
					Key = "confirm"
					},
				new DescribeEntryOption () {
					Identifier = "AuthBookmark", 
					Default = "false", // null if null
					Brief = "Authorize response to confirmation requests",
					Index = 10,
					Key = "bookmark"
					},
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 11,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 12,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 13,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 14,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 15,
					Key = "json"
					}
				}
			};

		}

    public partial class DeviceAuthorize : _DeviceAuthorize {
        } // class DeviceAuthorize

    public class _ProfileConnect : Goedel.Command.Dispatch ,
							IReporting,
							IDeviceProfileInfo,
							IDeviceAuthOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





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
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
		/// <summary>Field accessor for option [new]</summary>
		public virtual Flag DeviceNew {
			get => _Data[6] as Flag;
			set => _Data[6]  = value;
			}

		public virtual string _DeviceNew {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [dudf]</summary>
		public virtual String DeviceUDF {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _DeviceUDF {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [did]</summary>
		public virtual String DeviceID {
			get => _Data[8] as String;
			set => _Data[8]  = value;
			}

		public virtual string _DeviceID {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for option [dd]</summary>
		public virtual String DeviceDescription {
			get => _Data[9] as String;
			set => _Data[9]  = value;
			}

		public virtual string _DeviceDescription {
			set => _Data[9].Parameter (value);
			}
		/// <summary>Field accessor for option [auth]</summary>
		public virtual String Auth {
			get => _Data[10] as String;
			set => _Data[10]  = value;
			}

		public virtual string _Auth {
			set => _Data[10].Parameter (value);
			}
		/// <summary>Field accessor for option [admin]</summary>
		public virtual Flag AuthAdmin {
			get => _Data[11] as Flag;
			set => _Data[11]  = value;
			}

		public virtual string _AuthAdmin {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for option [all]</summary>
		public virtual Flag AuthAll {
			get => _Data[12] as Flag;
			set => _Data[12]  = value;
			}

		public virtual string _AuthAll {
			set => _Data[12].Parameter (value);
			}
		/// <summary>Field accessor for option [ssh]</summary>
		public virtual Flag AuthSSH {
			get => _Data[13] as Flag;
			set => _Data[13]  = value;
			}

		public virtual string _AuthSSH {
			set => _Data[13].Parameter (value);
			}
		/// <summary>Field accessor for option [password]</summary>
		public virtual Flag AuthPassword {
			get => _Data[14] as Flag;
			set => _Data[14]  = value;
			}

		public virtual string _AuthPassword {
			set => _Data[14].Parameter (value);
			}
		/// <summary>Field accessor for option [message]</summary>
		public virtual Flag AuthMessage {
			get => _Data[15] as Flag;
			set => _Data[15]  = value;
			}

		public virtual string _AuthMessage {
			set => _Data[15].Parameter (value);
			}
		/// <summary>Field accessor for option [contacts]</summary>
		public virtual Flag AuthContacts {
			get => _Data[16] as Flag;
			set => _Data[16]  = value;
			}

		public virtual string _AuthContacts {
			set => _Data[16].Parameter (value);
			}
		/// <summary>Field accessor for option [calendar]</summary>
		public virtual Flag AuthCalendar {
			get => _Data[17] as Flag;
			set => _Data[17]  = value;
			}

		public virtual string _AuthCalendar {
			set => _Data[17].Parameter (value);
			}
		/// <summary>Field accessor for option [network]</summary>
		public virtual Flag AuthNetwork {
			get => _Data[18] as Flag;
			set => _Data[18]  = value;
			}

		public virtual string _AuthNetwork {
			set => _Data[18].Parameter (value);
			}
		/// <summary>Field accessor for option [confirm]</summary>
		public virtual Flag AuthConfirm {
			get => _Data[19] as Flag;
			set => _Data[19]  = value;
			}

		public virtual string _AuthConfirm {
			set => _Data[19].Parameter (value);
			}
		/// <summary>Field accessor for option [bookmark]</summary>
		public virtual Flag AuthBookmark {
			get => _Data[20] as Flag;
			set => _Data[20]  = value;
			}

		public virtual string _AuthBookmark {
			set => _Data[20].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "request",
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
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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
					Identifier = "DeviceNew", 
					Default = "false", // null if null
					Brief = "Force creation of new device profile",
					Index = 6,
					Key = "new"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceUDF", 
					Default = null, // null if null
					Brief = "Device profile fingerprint",
					Index = 7,
					Key = "dudf"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceID", 
					Default = null, // null if null
					Brief = "Device identifier",
					Index = 8,
					Key = "did"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceDescription", 
					Default = null, // null if null
					Brief = "Device description",
					Index = 9,
					Key = "dd"
					},
				new DescribeEntryOption () {
					Identifier = "Auth", 
					Default = null, // null if null
					Brief = "Authorize the specified function",
					Index = 10,
					Key = "auth"
					},
				new DescribeEntryOption () {
					Identifier = "AuthAdmin", 
					Default = "false", // null if null
					Brief = "Authorize device as administration device",
					Index = 11,
					Key = "admin"
					},
				new DescribeEntryOption () {
					Identifier = "AuthAll", 
					Default = "false", // null if null
					Brief = "Authorize device for all application catalogs",
					Index = 12,
					Key = "all"
					},
				new DescribeEntryOption () {
					Identifier = "AuthSSH", 
					Default = "false", // null if null
					Brief = "Authorize use of SSH",
					Index = 13,
					Key = "ssh"
					},
				new DescribeEntryOption () {
					Identifier = "AuthPassword", 
					Default = "false", // null if null
					Brief = "Authorize access to password catalog",
					Index = 14,
					Key = "password"
					},
				new DescribeEntryOption () {
					Identifier = "AuthMessage", 
					Default = "false", // null if null
					Brief = "Authorize access to send and receive messages.",
					Index = 15,
					Key = "message"
					},
				new DescribeEntryOption () {
					Identifier = "AuthContacts", 
					Default = "false", // null if null
					Brief = "Authorize access to contacts catalog",
					Index = 16,
					Key = "contacts"
					},
				new DescribeEntryOption () {
					Identifier = "AuthCalendar", 
					Default = "false", // null if null
					Brief = "Authorize access to calendar catalog",
					Index = 17,
					Key = "calendar"
					},
				new DescribeEntryOption () {
					Identifier = "AuthNetwork", 
					Default = "false", // null if null
					Brief = "Authorize access to network catalog",
					Index = 18,
					Key = "network"
					},
				new DescribeEntryOption () {
					Identifier = "AuthConfirm", 
					Default = "false", // null if null
					Brief = "Authorize response to confirmation requests",
					Index = 19,
					Key = "confirm"
					},
				new DescribeEntryOption () {
					Identifier = "AuthBookmark", 
					Default = "false", // null if null
					Brief = "Authorize response to confirmation requests",
					Index = 20,
					Key = "bookmark"
					}
				}
			};

		}

    public partial class ProfileConnect : _ProfileConnect {
        } // class ProfileConnect

    public class _ProfilePending : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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

    public class _ProfileAccept : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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

    public class _ConnectEarl : Goedel.Command.Dispatch ,
							IAccountOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual String Earl {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Earl {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "earl",
			Brief =  "Connect a new device by means of an EARL",
			HandleDelegate =  CommandLineInterpreter.Handle_ConnectEarl,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Earl", 
					Default = null, // null if null
					Brief = "The EARL locator",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					}
				}
			};

		}

    public partial class ConnectEarl : _ConnectEarl {
        } // class ConnectEarl

    public class _DeviceDelete : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
			Identifier = "delete",
			Brief =  "Remove device from device catalog",
			HandleDelegate =  CommandLineInterpreter.Handle_DeviceDelete,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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

    public partial class DeviceDelete : _DeviceDelete {
        } // class DeviceDelete

    public class _DeviceList : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
			Identifier = "list",
			Brief =  "List devices in the device catalog",
			HandleDelegate =  CommandLineInterpreter.Handle_DeviceList,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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

    public partial class DeviceList : _DeviceList {
        } // class DeviceList

    public class _MessageContact : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
			Identifier = "contact",
			Brief =  "Post a conection request to a user",
			HandleDelegate =  CommandLineInterpreter.Handle_MessageContact,
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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

    public partial class MessageContact : _MessageContact {
        } // class MessageContact

    public class _MessageConfirm : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Text {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Text {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _Mesh {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[3] as Enumeration<EnumReporting>;
			set => _Data[3]  = value;
			}

		public virtual string _EnumReporting {
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
				new DescribeEntryParameter () {
					Identifier = "Text", 
					Default = null, // null if null
					Brief = "The recipient to send the confirmation request to",
					Index = 1,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 2,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 3,
					Key = "report"
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

    public partial class MessageConfirm : _MessageConfirm {
        } // class MessageConfirm

    public class _MessagePending : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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

    public class _MessageStatus : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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

    public class _MessageAccept : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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

    public class _GroupCreate : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							ICryptoOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
		public virtual String Algorithms {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Algorithms {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String GroupID {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _GroupID {
			set => _Data[6].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "create",
			Brief =  "Create recryption group",
			HandleDelegate =  CommandLineInterpreter.Handle_GroupCreate,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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
					Identifier = "Algorithms", 
					Default = null, // null if null
					Brief = "List of algorithm specifiers",
					Index = 5,
					Key = "alg"
					},
				new DescribeEntryParameter () {
					Identifier = "GroupID", 
					Default = null, // null if null
					Brief = "Recryption group name in user@example.com format",
					Index = 6,
					Key = ""
					}
				}
			};

		}

    public partial class GroupCreate : _GroupCreate {
        } // class GroupCreate

    public class _GroupAdd : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
			Identifier = "add",
			Brief =  "Add user to recryption group",
			HandleDelegate =  CommandLineInterpreter.Handle_GroupAdd,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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

    public partial class GroupAdd : _GroupAdd {
        } // class GroupAdd

    public class _GroupDelete : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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

    public class _GroupList : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
			Identifier = "list",
			Brief =  "List members of a recryption group",
			HandleDelegate =  CommandLineInterpreter.Handle_GroupList,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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

    public partial class GroupList : _GroupList {
        } // class GroupList

    public class _MailAdd : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							IMailOptions,
							ICryptoOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new ExistingFile (),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
		public virtual String Algorithms {
			get => _Data[12] as String;
			set => _Data[12]  = value;
			}

		public virtual string _Algorithms {
			set => _Data[12].Parameter (value);
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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
					Default = null, // null if null
					Brief = "Create encryption and signature keys for OpenPGP",
					Index = 6,
					Key = "openpgp"
					},
				new DescribeEntryOption () {
					Identifier = "SMIME", 
					Default = null, // null if null
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
					Identifier = "Algorithms", 
					Default = null, // null if null
					Brief = "List of algorithm specifiers",
					Index = 12,
					Key = "alg"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String (),
			new NewFile (),
			new String ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new NewFile (),
			new String ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String (),
			new NewFile (),
			new String ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new NewFile (),
			new String ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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


    public class _SSHCreate : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							ISSHOptions,
							ICryptoOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String (),
			new String ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
		public virtual String Algorithms {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Algorithms {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [id]</summary>
		public virtual String ID {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _ID {
			set => _Data[7].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "create",
			Brief =  "Generate a new SSH public keypair for the current machine and add to the personal profile",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHCreate,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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
					Identifier = "Algorithms", 
					Default = null, // null if null
					Brief = "List of algorithm specifiers",
					Index = 6,
					Key = "alg"
					},
				new DescribeEntryOption () {
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Key identifier",
					Index = 7,
					Key = "id"
					}
				}
			};

		}

    public partial class SSHCreate : _SSHCreate {
        } // class SSHCreate

    public class _SSHPrivate : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							IPrivateKeyOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String (),
			new NewFile ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new NewFile ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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

    public class _SSHMergeKnown : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							ISSHOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new ExistingFile ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
			HandleDelegate =  CommandLineInterpreter.Handle_SSHMergeKnown,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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

    public partial class SSHMergeKnown : _SSHMergeKnown {
        } // class SSHMergeKnown

    public class _SSHMergeClient : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {			} ;





		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "client",
			Brief =  "Add one or more hosts to the known_hosts file",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHMergeClient,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				}
			};

		}

    public partial class SSHMergeClient : _SSHMergeClient {
        } // class SSHMergeClient

    public class _SSHAddHost : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							ISSHOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
			Brief =  "Add one or more hosts to the known_hosts file",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHAddHost,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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

    public partial class SSHAddHost : _SSHAddHost {
        } // class SSHAddHost

    public class _SSHAddClient : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							ISSHOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new ExistingFile ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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

    public class _SSHKnown : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							ISSHOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
			Brief =  "List the known SSH sites (aka known hosts)",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHKnown,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
			Identifier = "client",
			Brief =  "List the authorized device keys (aka authorized_keys)",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHAuth,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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

    public class _PasswordAdd : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _Mesh {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[4] as Enumeration<EnumReporting>;
			set => _Data[4]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 3,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 4,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
			Identifier = "list",
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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

    public class _ContactGet : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual String Identifier {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Identifier {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
		/// <summary>Field accessor for option [encrypt]</summary>
		public virtual String Encrypt {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Encrypt {
			set => _Data[6].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "get",
			Brief =  "Lookup contact entry",
			HandleDelegate =  CommandLineInterpreter.Handle_ContactGet,
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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
					Identifier = "Encrypt", 
					Default = null, // null if null
					Brief = "Encrypt the contact under the specified key",
					Index = 6,
					Key = "encrypt"
					}
				}
			};

		}

    public partial class ContactGet : _ContactGet {
        } // class ContactGet

    public class _ContactDump : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
			Identifier = "list",
			Brief =  "List contact entries",
			HandleDelegate =  CommandLineInterpreter.Handle_ContactDump,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual String Path {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Path {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Uri {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Uri {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Title {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _Title {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _Mesh {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[4] as Enumeration<EnumReporting>;
			set => _Data[4]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Path", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Uri", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 1,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Title", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 2,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 3,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 4,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _Mesh {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[3] as Enumeration<EnumReporting>;
			set => _Data[3]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 2,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 3,
					Key = "report"
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

    public class _BookmarkGet : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
			Brief =  "Lookup bookmark entry",
			HandleDelegate =  CommandLineInterpreter.Handle_BookmarkGet,
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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

    public partial class BookmarkGet : _BookmarkGet {
        } // class BookmarkGet

    public class _BookmarkDump : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
			Identifier = "list",
			Brief =  "List bookmark entries",
			HandleDelegate =  CommandLineInterpreter.Handle_BookmarkDump,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Identifier {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Identifier {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _Mesh {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[3] as Enumeration<EnumReporting>;
			set => _Data[3]  = value;
			}

		public virtual string _EnumReporting {
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
				new DescribeEntryParameter () {
					Identifier = "Identifier", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 1,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 2,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 3,
					Key = "report"
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

    public partial class CalendarAdd : _CalendarAdd {
        } // class CalendarAdd

    public class _CalendarGet : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
			Brief =  "Lookup calendar entry",
			HandleDelegate =  CommandLineInterpreter.Handle_CalendarGet,
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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

    public partial class CalendarGet : _CalendarGet {
        } // class CalendarGet

    public class _CalendarDelete : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Identifier {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Identifier {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _Mesh {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[3] as Enumeration<EnumReporting>;
			set => _Data[3]  = value;
			}

		public virtual string _EnumReporting {
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
				new DescribeEntryParameter () {
					Identifier = "Identifier", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 1,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 2,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 3,
					Key = "report"
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

    public partial class NetworkAdd : _NetworkAdd {
        } // class NetworkAdd

    public class _NetworkGet : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
			Brief =  "Lookup calendar entry",
			HandleDelegate =  CommandLineInterpreter.Handle_NetworkGet,
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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

    public partial class NetworkGet : _NetworkGet {
        } // class NetworkGet

    public class _NetworkDelete : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Mesh {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[2] as Enumeration<EnumReporting>;
			set => _Data[2]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 2,
					Key = "report"
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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

    public class _KeyNonce : Goedel.Command.Dispatch ,
							IReporting,
							ILengthOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new Integer ()			} ;





		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[0] as Enumeration<EnumReporting>;
			set => _Data[0]  = value;
			}

		public virtual string _EnumReporting {
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
		/// <summary>Field accessor for option [bits]</summary>
		public virtual Integer Bits {
			get => _Data[4] as Integer;
			set => _Data[4]  = value;
			}

		public virtual string _Bits {
			set => _Data[4].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "nonce",
			Brief =  "Return a randomized nonce value formatted as a UDF Nonce Type",
			HandleDelegate =  CommandLineInterpreter.Handle_KeyNonce,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 0,
					Key = "report"
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
					Identifier = "Bits", 
					Default = null, // null if null
					Brief = "Secret size in bits",
					Index = 4,
					Key = "bits"
					}
				}
			};

		}

    public partial class KeyNonce : _KeyNonce {
        } // class KeyNonce

    public class _KeySecret : Goedel.Command.Dispatch ,
							IReporting,
							ILengthOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new Integer ()			} ;





		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[0] as Enumeration<EnumReporting>;
			set => _Data[0]  = value;
			}

		public virtual string _EnumReporting {
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
		/// <summary>Field accessor for option [bits]</summary>
		public virtual Integer Bits {
			get => _Data[4] as Integer;
			set => _Data[4]  = value;
			}

		public virtual string _Bits {
			set => _Data[4].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "secret",
			Brief =  "Return a randomized secret value formatted as a UDF Encryption Key Type.",
			HandleDelegate =  CommandLineInterpreter.Handle_KeySecret,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 0,
					Key = "report"
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
					Identifier = "Bits", 
					Default = null, // null if null
					Brief = "Secret size in bits",
					Index = 4,
					Key = "bits"
					}
				}
			};

		}

    public partial class KeySecret : _KeySecret {
        } // class KeySecret

    public class _KeyEarl : Goedel.Command.Dispatch ,
							IReporting,
							IDigestOptions,
							ILengthOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new Integer ()			} ;





		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[0] as Enumeration<EnumReporting>;
			set => _Data[0]  = value;
			}

		public virtual string _EnumReporting {
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
		/// <summary>Field accessor for option [key]</summary>
		public virtual String DigestKey {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _DigestKey {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [bits]</summary>
		public virtual Integer Bits {
			get => _Data[5] as Integer;
			set => _Data[5]  = value;
			}

		public virtual string _Bits {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "earl",
			Brief =  "Return a randomized secret value and locator as UDFs",
			HandleDelegate =  CommandLineInterpreter.Handle_KeyEarl,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 0,
					Key = "report"
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
					Identifier = "DigestKey", 
					Default = null, // null if null
					Brief = "Encrypt data for specified recipient",
					Index = 4,
					Key = "key"
					},
				new DescribeEntryOption () {
					Identifier = "Bits", 
					Default = null, // null if null
					Brief = "Secret size in bits",
					Index = 5,
					Key = "bits"
					}
				}
			};

		}

    public partial class KeyEarl : _KeyEarl {
        } // class KeyEarl

    public class _KeyShare : Goedel.Command.Dispatch ,
							IReporting,
							IDigestOptions,
							ILengthOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new Integer (),
			new String (),
			new Integer (),
			new Integer ()			} ;





		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[0] as Enumeration<EnumReporting>;
			set => _Data[0]  = value;
			}

		public virtual string _EnumReporting {
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
		/// <summary>Field accessor for option [key]</summary>
		public virtual String DigestKey {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _DigestKey {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [bits]</summary>
		public virtual Integer Bits {
			get => _Data[5] as Integer;
			set => _Data[5]  = value;
			}

		public virtual string _Bits {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Secret {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Secret {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [quorum]</summary>
		public virtual Integer Quorum {
			get => _Data[7] as Integer;
			set => _Data[7]  = value;
			}

		public virtual string _Quorum {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [shares]</summary>
		public virtual Integer Shares {
			get => _Data[8] as Integer;
			set => _Data[8]  = value;
			}

		public virtual string _Shares {
			set => _Data[8].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "share",
			Brief =  "Split a secret value according to the specified shares and quorum",
			HandleDelegate =  CommandLineInterpreter.Handle_KeyShare,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 0,
					Key = "report"
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
					Identifier = "DigestKey", 
					Default = null, // null if null
					Brief = "Encrypt data for specified recipient",
					Index = 4,
					Key = "key"
					},
				new DescribeEntryOption () {
					Identifier = "Bits", 
					Default = null, // null if null
					Brief = "Secret size in bits",
					Index = 5,
					Key = "bits"
					},
				new DescribeEntryParameter () {
					Identifier = "Secret", 
					Default = null, // null if null
					Brief = "The parameter to share",
					Index = 6,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Quorum", 
					Default = "2", // null if null
					Brief = "The number of shares required to recover the secret",
					Index = 7,
					Key = "quorum"
					},
				new DescribeEntryOption () {
					Identifier = "Shares", 
					Default = "3", // null if null
					Brief = "The number of shares to create",
					Index = 8,
					Key = "shares"
					}
				}
			};

		}

    public partial class KeyShare : _KeyShare {
        } // class KeyShare

    public class _KeyRecover : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
			new String ()			} ;





		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[0] as Enumeration<EnumReporting>;
			set => _Data[0]  = value;
			}

		public virtual string _EnumReporting {
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Share1 {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _Share1 {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Share2 {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Share2 {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Share3 {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Share3 {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Share4 {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _Share4 {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Share5 {
			get => _Data[8] as String;
			set => _Data[8]  = value;
			}

		public virtual string _Share5 {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Share6 {
			get => _Data[9] as String;
			set => _Data[9]  = value;
			}

		public virtual string _Share6 {
			set => _Data[9].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Share7 {
			get => _Data[10] as String;
			set => _Data[10]  = value;
			}

		public virtual string _Share7 {
			set => _Data[10].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Share8 {
			get => _Data[11] as String;
			set => _Data[11]  = value;
			}

		public virtual string _Share8 {
			set => _Data[11].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "recover",
			Brief =  "Recover a secret value from the shares provided",
			HandleDelegate =  CommandLineInterpreter.Handle_KeyRecover,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 0,
					Key = "report"
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
				new DescribeEntryParameter () {
					Identifier = "Share1", 
					Default = null, // null if null
					Brief = "Share value #1",
					Index = 4,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Share2", 
					Default = null, // null if null
					Brief = "Share value #2",
					Index = 5,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Share3", 
					Default = null, // null if null
					Brief = "Share value #3",
					Index = 6,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Share4", 
					Default = null, // null if null
					Brief = "Share value #4",
					Index = 7,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Share5", 
					Default = null, // null if null
					Brief = "Share value #5",
					Index = 8,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Share6", 
					Default = null, // null if null
					Brief = "Share value #6",
					Index = 9,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Share7", 
					Default = null, // null if null
					Brief = "Share value #7",
					Index = 10,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Share8", 
					Default = null, // null if null
					Brief = "Share value #8",
					Index = 11,
					Key = ""
					}
				}
			};

		}

    public partial class KeyRecover : _KeyRecover {
        } // class KeyRecover

    public class _HashUDF : Goedel.Command.Dispatch ,
							IReporting,
							ICryptoOptions,
							ILengthOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new Integer (),
			new String (),
			new String (),
			new ExistingFile ()			} ;





		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[0] as Enumeration<EnumReporting>;
			set => _Data[0]  = value;
			}

		public virtual string _EnumReporting {
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
		/// <summary>Field accessor for option [alg]</summary>
		public virtual String Algorithms {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _Algorithms {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [bits]</summary>
		public virtual Integer Bits {
			get => _Data[5] as Integer;
			set => _Data[5]  = value;
			}

		public virtual string _Bits {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [cty]</summary>
		public virtual String ContentType {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _ContentType {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [expect]</summary>
		public virtual String Expect {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _Expect {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Input {
			get => _Data[8] as ExistingFile;
			set => _Data[8]  = value;
			}

		public virtual string _Input {
			set => _Data[8].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "udf",
			Brief =  "Calculate the Uniform Data Fingerprint of the input data",
			HandleDelegate =  CommandLineInterpreter.Handle_HashUDF,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 0,
					Key = "report"
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
					Identifier = "Algorithms", 
					Default = null, // null if null
					Brief = "List of algorithm specifiers",
					Index = 4,
					Key = "alg"
					},
				new DescribeEntryOption () {
					Identifier = "Bits", 
					Default = null, // null if null
					Brief = "Secret size in bits",
					Index = 5,
					Key = "bits"
					},
				new DescribeEntryOption () {
					Identifier = "ContentType", 
					Default = null, // null if null
					Brief = "Content Type",
					Index = 6,
					Key = "cty"
					},
				new DescribeEntryOption () {
					Identifier = "Expect", 
					Default = null, // null if null
					Brief = "Expected value",
					Index = 7,
					Key = "expect"
					},
				new DescribeEntryParameter () {
					Identifier = "Input", 
					Default = null, // null if null
					Brief = "File to take digest of",
					Index = 8,
					Key = ""
					}
				}
			};

		}

    public partial class HashUDF : _HashUDF {
        } // class HashUDF

    public class _HashDigest : Goedel.Command.Dispatch ,
							IReporting,
							ICryptoOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new ExistingFile ()			} ;





		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[0] as Enumeration<EnumReporting>;
			set => _Data[0]  = value;
			}

		public virtual string _EnumReporting {
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
		/// <summary>Field accessor for option [alg]</summary>
		public virtual String Algorithms {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _Algorithms {
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
			Identifier = "digest",
			Brief =  "Calculate the digest value of the input data",
			HandleDelegate =  CommandLineInterpreter.Handle_HashDigest,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 0,
					Key = "report"
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
					Identifier = "Algorithms", 
					Default = null, // null if null
					Brief = "List of algorithm specifiers",
					Index = 4,
					Key = "alg"
					},
				new DescribeEntryParameter () {
					Identifier = "Input", 
					Default = null, // null if null
					Brief = "File to take digest of",
					Index = 5,
					Key = ""
					}
				}
			};

		}

    public partial class HashDigest : _HashDigest {
        } // class HashDigest

    public class _HashMac : Goedel.Command.Dispatch ,
							IReporting,
							ICryptoOptions,
							ILengthOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new Integer (),
			new String (),
			new String (),
			new String (),
			new ExistingFile ()			} ;





		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[0] as Enumeration<EnumReporting>;
			set => _Data[0]  = value;
			}

		public virtual string _EnumReporting {
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
		/// <summary>Field accessor for option [alg]</summary>
		public virtual String Algorithms {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _Algorithms {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [bits]</summary>
		public virtual Integer Bits {
			get => _Data[5] as Integer;
			set => _Data[5]  = value;
			}

		public virtual string _Bits {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [cty]</summary>
		public virtual String ContentType {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _ContentType {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [key]</summary>
		public virtual String DigestKey {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _DigestKey {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [expect]</summary>
		public virtual String Expect {
			get => _Data[8] as String;
			set => _Data[8]  = value;
			}

		public virtual string _Expect {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Input {
			get => _Data[9] as ExistingFile;
			set => _Data[9]  = value;
			}

		public virtual string _Input {
			set => _Data[9].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "mac",
			Brief =  "Calculate a commitment value for the input data",
			HandleDelegate =  CommandLineInterpreter.Handle_HashMac,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 0,
					Key = "report"
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
					Identifier = "Algorithms", 
					Default = null, // null if null
					Brief = "List of algorithm specifiers",
					Index = 4,
					Key = "alg"
					},
				new DescribeEntryOption () {
					Identifier = "Bits", 
					Default = null, // null if null
					Brief = "Secret size in bits",
					Index = 5,
					Key = "bits"
					},
				new DescribeEntryOption () {
					Identifier = "ContentType", 
					Default = null, // null if null
					Brief = "Content Type",
					Index = 6,
					Key = "cty"
					},
				new DescribeEntryOption () {
					Identifier = "DigestKey", 
					Default = null, // null if null
					Brief = "Specifies the value of the key",
					Index = 7,
					Key = "key"
					},
				new DescribeEntryOption () {
					Identifier = "Expect", 
					Default = null, // null if null
					Brief = "Expected value",
					Index = 8,
					Key = "expect"
					},
				new DescribeEntryParameter () {
					Identifier = "Input", 
					Default = null, // null if null
					Brief = "File to create commitment of",
					Index = 9,
					Key = ""
					}
				}
			};

		}

    public partial class HashMac : _HashMac {
        } // class HashMac

    public class _DareEncode : Goedel.Command.Dispatch ,
							IEncodeOptions,
							ICryptoOptions,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new ExistingFile (),
			new String (),
			new String (),
			new String (),
			new Flag (),
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new NewFile (),
			new Flag (),
			new String ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Input {
			get => _Data[0] as ExistingFile;
			set => _Data[0]  = value;
			}

		public virtual string _Input {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [cty]</summary>
		public virtual String ContentType {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _ContentType {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [encrypt]</summary>
		public virtual String Encrypt {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _Encrypt {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [sign]</summary>
		public virtual String Sign {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _Sign {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [hash]</summary>
		public virtual Flag Hash {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Hash {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [alg]</summary>
		public virtual String Algorithms {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Algorithms {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Mesh {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[7] as Enumeration<EnumReporting>;
			set => _Data[7]  = value;
			}

		public virtual string _EnumReporting {
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
		/// <summary>Field accessor for option [out]</summary>
		public virtual NewFile Output {
			get => _Data[11] as NewFile;
			set => _Data[11]  = value;
			}

		public virtual string _Output {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for option [sub]</summary>
		public virtual Flag Subdirectories {
			get => _Data[12] as Flag;
			set => _Data[12]  = value;
			}

		public virtual string _Subdirectories {
			set => _Data[12].Parameter (value);
			}
		/// <summary>Field accessor for option [key]</summary>
		public virtual String SymmetrictKey {
			get => _Data[13] as String;
			set => _Data[13]  = value;
			}

		public virtual string _SymmetrictKey {
			set => _Data[13].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "encode",
			Brief =  "Encode data as DARE Message.",
			HandleDelegate =  CommandLineInterpreter.Handle_DareEncode,
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
					Identifier = "ContentType", 
					Default = null, // null if null
					Brief = "Content Type",
					Index = 1,
					Key = "cty"
					},
				new DescribeEntryOption () {
					Identifier = "Encrypt", 
					Default = null, // null if null
					Brief = "Encrypt data for specified recipient",
					Index = 2,
					Key = "encrypt"
					},
				new DescribeEntryOption () {
					Identifier = "Sign", 
					Default = null, // null if null
					Brief = "Sign data with specified key",
					Index = 3,
					Key = "sign"
					},
				new DescribeEntryOption () {
					Identifier = "Hash", 
					Default = "true", // null if null
					Brief = "Compute hash of content",
					Index = 4,
					Key = "hash"
					},
				new DescribeEntryOption () {
					Identifier = "Algorithms", 
					Default = null, // null if null
					Brief = "List of algorithm specifiers",
					Index = 5,
					Key = "alg"
					},
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 6,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 7,
					Key = "report"
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
					Identifier = "Output", 
					Default = null, // null if null
					Brief = "Filename for encrypted output.",
					Index = 11,
					Key = "out"
					},
				new DescribeEntryOption () {
					Identifier = "Subdirectories", 
					Default = null, // null if null
					Brief = "Process subdirectories recursively.",
					Index = 12,
					Key = "sub"
					},
				new DescribeEntryOption () {
					Identifier = "SymmetrictKey", 
					Default = null, // null if null
					Brief = "Specifies the value of the master key",
					Index = 13,
					Key = "key"
					}
				}
			};

		}

    public partial class DareEncode : _DareEncode {
        } // class DareEncode

    public class _DareDecode : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new ExistingFile (),
			new NewFile (),
			new String ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
		/// <summary>Field accessor for option [key]</summary>
		public virtual String SymmetrictKey {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _SymmetrictKey {
			set => _Data[7].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "decode",
			Brief =  "Decode a DARE Message.",
			HandleDelegate =  CommandLineInterpreter.Handle_DareDecode,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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
					},
				new DescribeEntryOption () {
					Identifier = "SymmetrictKey", 
					Default = null, // null if null
					Brief = "Specifies the value of the master key",
					Index = 7,
					Key = "key"
					}
				}
			};

		}

    public partial class DareDecode : _DareDecode {
        } // class DareDecode

    public class _DareVerify : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new ExistingFile (),
			new String ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
		/// <summary>Field accessor for option [key]</summary>
		public virtual String SymmetrictKey {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _SymmetrictKey {
			set => _Data[6].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "verify",
			Brief =  "Verify a DARE Message.",
			HandleDelegate =  CommandLineInterpreter.Handle_DareVerify,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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
				new DescribeEntryOption () {
					Identifier = "SymmetrictKey", 
					Default = null, // null if null
					Brief = "Specifies the value of the master key",
					Index = 6,
					Key = "key"
					}
				}
			};

		}

    public partial class DareVerify : _DareVerify {
        } // class DareVerify

    public class _DareEARL : Goedel.Command.Dispatch ,
							ICryptoOptions,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new ExistingFile (),
			new ExistingFile (),
			new ExistingFile (),
			new ExistingFile (),
			new Flag (),
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [out]</summary>
		public virtual ExistingFile Output {
			get => _Data[1] as ExistingFile;
			set => _Data[1]  = value;
			}

		public virtual string _Output {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [log]</summary>
		public virtual ExistingFile Log {
			get => _Data[2] as ExistingFile;
			set => _Data[2]  = value;
			}

		public virtual string _Log {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [new]</summary>
		public virtual ExistingFile New {
			get => _Data[3] as ExistingFile;
			set => _Data[3]  = value;
			}

		public virtual string _New {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [sub]</summary>
		public virtual Flag Subdirectories {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Subdirectories {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [alg]</summary>
		public virtual String Algorithms {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Algorithms {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Mesh {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[7] as Enumeration<EnumReporting>;
			set => _Data[7]  = value;
			}

		public virtual string _EnumReporting {
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "earl",
			Brief =  "Create an Encrypted Authenticated Resource Locator (EARL)",
			HandleDelegate =  CommandLineInterpreter.Handle_DareEARL,
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
					Identifier = "Output", 
					Default = null, // null if null
					Brief = "Directory to write encrypted output.",
					Index = 1,
					Key = "out"
					},
				new DescribeEntryOption () {
					Identifier = "Log", 
					Default = null, // null if null
					Brief = "Write transaction report to DARE Container Log.",
					Index = 2,
					Key = "log"
					},
				new DescribeEntryOption () {
					Identifier = "New", 
					Default = null, // null if null
					Brief = "Only convert file if not listed in DARE Container Log.",
					Index = 3,
					Key = "new"
					},
				new DescribeEntryOption () {
					Identifier = "Subdirectories", 
					Default = null, // null if null
					Brief = "Process subdirectories recursively.",
					Index = 4,
					Key = "sub"
					},
				new DescribeEntryOption () {
					Identifier = "Algorithms", 
					Default = null, // null if null
					Brief = "List of algorithm specifiers",
					Index = 5,
					Key = "alg"
					},
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 6,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 7,
					Key = "report"
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
					}
				}
			};

		}

    public partial class DareEARL : _DareEARL {
        } // class DareEARL

    public class _ContainerCreate : Goedel.Command.Dispatch ,
							IEncodeOptions,
							ICryptoOptions,
							IContainerOptions,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new String (),
			new String (),
			new Enumeration<EnumAuthentication> (CommandLineInterpreter.DescribeEnumAuthentication),
			new Enumeration<EnumUse> (CommandLineInterpreter.DescribeEnumUse),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new NewFile ()			} ;





		/// <summary>Field accessor for option [cty]</summary>
		public virtual String ContentType {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _ContentType {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [encrypt]</summary>
		public virtual String Encrypt {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Encrypt {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [sign]</summary>
		public virtual String Sign {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _Sign {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [hash]</summary>
		public virtual Flag Hash {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Hash {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [alg]</summary>
		public virtual String Algorithms {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _Algorithms {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [type]</summary>
		public virtual String Type {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Type {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for parameter [auth]</summary>
		public virtual Enumeration<EnumAuthentication> EnumAuthentication {
			get => _Data[6] as Enumeration<EnumAuthentication>;
			set => _Data[6]  = value;
			}

		public virtual string _EnumAuthentication {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for parameter [use]</summary>
		public virtual Enumeration<EnumUse> EnumUse {
			get => _Data[7] as Enumeration<EnumUse>;
			set => _Data[7]  = value;
			}

		public virtual string _EnumUse {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[8] as String;
			set => _Data[8]  = value;
			}

		public virtual string _Mesh {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[9] as Enumeration<EnumReporting>;
			set => _Data[9]  = value;
			}

		public virtual string _EnumReporting {
			set => _Data[9].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[10] as Flag;
			set => _Data[10]  = value;
			}

		public virtual string _Verbose {
			set => _Data[10].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[11] as Flag;
			set => _Data[11]  = value;
			}

		public virtual string _Report {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[12] as Flag;
			set => _Data[12]  = value;
			}

		public virtual string _Json {
			set => _Data[12].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual NewFile Container {
			get => _Data[13] as NewFile;
			set => _Data[13]  = value;
			}

		public virtual string _Container {
			set => _Data[13].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "create",
			Brief =  "Create a new DARE Container",
			HandleDelegate =  CommandLineInterpreter.Handle_ContainerCreate,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "ContentType", 
					Default = null, // null if null
					Brief = "Content Type",
					Index = 0,
					Key = "cty"
					},
				new DescribeEntryOption () {
					Identifier = "Encrypt", 
					Default = null, // null if null
					Brief = "Encrypt data for specified recipient",
					Index = 1,
					Key = "encrypt"
					},
				new DescribeEntryOption () {
					Identifier = "Sign", 
					Default = null, // null if null
					Brief = "Sign data with specified key",
					Index = 2,
					Key = "sign"
					},
				new DescribeEntryOption () {
					Identifier = "Hash", 
					Default = "true", // null if null
					Brief = "Compute hash of content",
					Index = 3,
					Key = "hash"
					},
				new DescribeEntryOption () {
					Identifier = "Algorithms", 
					Default = null, // null if null
					Brief = "List of algorithm specifiers",
					Index = 4,
					Key = "alg"
					},
				new DescribeEntryOption () {
					Identifier = "Type", 
					Default = null, // null if null
					Brief = "The container type, plain/tree/digest/chain/tree",
					Index = 5,
					Key = "type"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumAuthentication", 
					Default = null, // null if null
					Brief = "Authentication and indexing",
					Index = 6,
					Key = "auth"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumUse", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 7,
					Key = "use"
					},
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 8,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 9,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 10,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 11,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 12,
					Key = "json"
					},
				new DescribeEntryParameter () {
					Identifier = "Container", 
					Default = null, // null if null
					Brief = "New container",
					Index = 13,
					Key = ""
					}
				}
			};

		}

    public partial class ContainerCreate : _ContainerCreate {
        } // class ContainerCreate

    public class _ContainerArchive : Goedel.Command.Dispatch ,
							IEncodeOptions,
							ICryptoOptions,
							IAccountOptions,
							IReporting,
							IContainerOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new Enumeration<EnumAuthentication> (CommandLineInterpreter.DescribeEnumAuthentication),
			new Enumeration<EnumUse> (CommandLineInterpreter.DescribeEnumUse),
			new ExistingFile (),
			new NewFile ()			} ;





		/// <summary>Field accessor for option [cty]</summary>
		public virtual String ContentType {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _ContentType {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [encrypt]</summary>
		public virtual String Encrypt {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Encrypt {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [sign]</summary>
		public virtual String Sign {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _Sign {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [hash]</summary>
		public virtual Flag Hash {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Hash {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [alg]</summary>
		public virtual String Algorithms {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _Algorithms {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Mesh {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[6] as Enumeration<EnumReporting>;
			set => _Data[6]  = value;
			}

		public virtual string _EnumReporting {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[7] as Flag;
			set => _Data[7]  = value;
			}

		public virtual string _Verbose {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[8] as Flag;
			set => _Data[8]  = value;
			}

		public virtual string _Report {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[9] as Flag;
			set => _Data[9]  = value;
			}

		public virtual string _Json {
			set => _Data[9].Parameter (value);
			}
		/// <summary>Field accessor for option [type]</summary>
		public virtual String Type {
			get => _Data[10] as String;
			set => _Data[10]  = value;
			}

		public virtual string _Type {
			set => _Data[10].Parameter (value);
			}
		/// <summary>Field accessor for parameter [auth]</summary>
		public virtual Enumeration<EnumAuthentication> EnumAuthentication {
			get => _Data[11] as Enumeration<EnumAuthentication>;
			set => _Data[11]  = value;
			}

		public virtual string _EnumAuthentication {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for parameter [use]</summary>
		public virtual Enumeration<EnumUse> EnumUse {
			get => _Data[12] as Enumeration<EnumUse>;
			set => _Data[12]  = value;
			}

		public virtual string _EnumUse {
			set => _Data[12].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Input {
			get => _Data[13] as ExistingFile;
			set => _Data[13]  = value;
			}

		public virtual string _Input {
			set => _Data[13].Parameter (value);
			}
		/// <summary>Field accessor for option [out]</summary>
		public virtual NewFile Container {
			get => _Data[14] as NewFile;
			set => _Data[14]  = value;
			}

		public virtual string _Container {
			set => _Data[14].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "archive",
			Brief =  "Create a new DARE Container and archive the specified files",
			HandleDelegate =  CommandLineInterpreter.Handle_ContainerArchive,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "ContentType", 
					Default = null, // null if null
					Brief = "Content Type",
					Index = 0,
					Key = "cty"
					},
				new DescribeEntryOption () {
					Identifier = "Encrypt", 
					Default = null, // null if null
					Brief = "Encrypt data for specified recipient",
					Index = 1,
					Key = "encrypt"
					},
				new DescribeEntryOption () {
					Identifier = "Sign", 
					Default = null, // null if null
					Brief = "Sign data with specified key",
					Index = 2,
					Key = "sign"
					},
				new DescribeEntryOption () {
					Identifier = "Hash", 
					Default = "true", // null if null
					Brief = "Compute hash of content",
					Index = 3,
					Key = "hash"
					},
				new DescribeEntryOption () {
					Identifier = "Algorithms", 
					Default = null, // null if null
					Brief = "List of algorithm specifiers",
					Index = 4,
					Key = "alg"
					},
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 5,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 6,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 7,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 8,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 9,
					Key = "json"
					},
				new DescribeEntryOption () {
					Identifier = "Type", 
					Default = null, // null if null
					Brief = "The container type, plain/tree/digest/chain/tree",
					Index = 10,
					Key = "type"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumAuthentication", 
					Default = null, // null if null
					Brief = "Authentication and indexing",
					Index = 11,
					Key = "auth"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumUse", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 12,
					Key = "use"
					},
				new DescribeEntryParameter () {
					Identifier = "Input", 
					Default = null, // null if null
					Brief = "Directory containing files to create archive from",
					Index = 13,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Container", 
					Default = null, // null if null
					Brief = "New container",
					Index = 14,
					Key = "out"
					}
				}
			};

		}

    public partial class ContainerArchive : _ContainerArchive {
        } // class ContainerArchive

    public class _ContainerAppend : Goedel.Command.Dispatch ,
							IEncodeOptions,
							ICryptoOptions,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new ExistingFile (),
			new NewFile (),
			new String ()			} ;





		/// <summary>Field accessor for option [cty]</summary>
		public virtual String ContentType {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _ContentType {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [encrypt]</summary>
		public virtual String Encrypt {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Encrypt {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [sign]</summary>
		public virtual String Sign {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _Sign {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [hash]</summary>
		public virtual Flag Hash {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Hash {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [alg]</summary>
		public virtual String Algorithms {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _Algorithms {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Mesh {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[6] as Enumeration<EnumReporting>;
			set => _Data[6]  = value;
			}

		public virtual string _EnumReporting {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[7] as Flag;
			set => _Data[7]  = value;
			}

		public virtual string _Verbose {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[8] as Flag;
			set => _Data[8]  = value;
			}

		public virtual string _Report {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[9] as Flag;
			set => _Data[9]  = value;
			}

		public virtual string _Json {
			set => _Data[9].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Container {
			get => _Data[10] as ExistingFile;
			set => _Data[10]  = value;
			}

		public virtual string _Container {
			set => _Data[10].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual NewFile File {
			get => _Data[11] as NewFile;
			set => _Data[11]  = value;
			}

		public virtual string _File {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for option [key]</summary>
		public virtual String Key {
			get => _Data[12] as String;
			set => _Data[12]  = value;
			}

		public virtual string _Key {
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
					Identifier = "ContentType", 
					Default = null, // null if null
					Brief = "Content Type",
					Index = 0,
					Key = "cty"
					},
				new DescribeEntryOption () {
					Identifier = "Encrypt", 
					Default = null, // null if null
					Brief = "Encrypt data for specified recipient",
					Index = 1,
					Key = "encrypt"
					},
				new DescribeEntryOption () {
					Identifier = "Sign", 
					Default = null, // null if null
					Brief = "Sign data with specified key",
					Index = 2,
					Key = "sign"
					},
				new DescribeEntryOption () {
					Identifier = "Hash", 
					Default = "true", // null if null
					Brief = "Compute hash of content",
					Index = 3,
					Key = "hash"
					},
				new DescribeEntryOption () {
					Identifier = "Algorithms", 
					Default = null, // null if null
					Brief = "List of algorithm specifiers",
					Index = 4,
					Key = "alg"
					},
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 5,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 6,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 7,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 8,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 9,
					Key = "json"
					},
				new DescribeEntryParameter () {
					Identifier = "Container", 
					Default = null, // null if null
					Brief = "Container to append to",
					Index = 10,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "File to append",
					Index = 11,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Key", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 12,
					Key = "key"
					}
				}
			};

		}

    public partial class ContainerAppend : _ContainerAppend {
        } // class ContainerAppend

    public class _ContainerDelete : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new ExistingFile (),
			new String (),
			new String ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Container {
			get => _Data[0] as ExistingFile;
			set => _Data[0]  = value;
			}

		public virtual string _Container {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [file]</summary>
		public virtual String Filename {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Filename {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [key]</summary>
		public virtual String Key {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _Key {
			set => _Data[2].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "delete",
			Brief =  "<Unspecified>",
			HandleDelegate =  CommandLineInterpreter.Handle_ContainerDelete,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Container", 
					Default = null, // null if null
					Brief = "Container to append to",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Filename", 
					Default = null, // null if null
					Brief = "Name of file to delete",
					Index = 1,
					Key = "file"
					},
				new DescribeEntryOption () {
					Identifier = "Key", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 2,
					Key = "key"
					}
				}
			};

		}

    public partial class ContainerDelete : _ContainerDelete {
        } // class ContainerDelete

    public class _ContainerIndex : Goedel.Command.Dispatch ,
							IEncodeOptions,
							ICryptoOptions,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new ExistingFile ()			} ;





		/// <summary>Field accessor for option [cty]</summary>
		public virtual String ContentType {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _ContentType {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [encrypt]</summary>
		public virtual String Encrypt {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Encrypt {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [sign]</summary>
		public virtual String Sign {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _Sign {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [hash]</summary>
		public virtual Flag Hash {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Hash {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [alg]</summary>
		public virtual String Algorithms {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _Algorithms {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Mesh {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[6] as Enumeration<EnumReporting>;
			set => _Data[6]  = value;
			}

		public virtual string _EnumReporting {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[7] as Flag;
			set => _Data[7]  = value;
			}

		public virtual string _Verbose {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[8] as Flag;
			set => _Data[8]  = value;
			}

		public virtual string _Report {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[9] as Flag;
			set => _Data[9]  = value;
			}

		public virtual string _Json {
			set => _Data[9].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Container {
			get => _Data[10] as ExistingFile;
			set => _Data[10]  = value;
			}

		public virtual string _Container {
			set => _Data[10].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "index",
			Brief =  "Compile an index for the specified container and append to the end.",
			HandleDelegate =  CommandLineInterpreter.Handle_ContainerIndex,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "ContentType", 
					Default = null, // null if null
					Brief = "Content Type",
					Index = 0,
					Key = "cty"
					},
				new DescribeEntryOption () {
					Identifier = "Encrypt", 
					Default = null, // null if null
					Brief = "Encrypt data for specified recipient",
					Index = 1,
					Key = "encrypt"
					},
				new DescribeEntryOption () {
					Identifier = "Sign", 
					Default = null, // null if null
					Brief = "Sign data with specified key",
					Index = 2,
					Key = "sign"
					},
				new DescribeEntryOption () {
					Identifier = "Hash", 
					Default = "true", // null if null
					Brief = "Compute hash of content",
					Index = 3,
					Key = "hash"
					},
				new DescribeEntryOption () {
					Identifier = "Algorithms", 
					Default = null, // null if null
					Brief = "List of algorithm specifiers",
					Index = 4,
					Key = "alg"
					},
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 5,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 6,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 7,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 8,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 9,
					Key = "json"
					},
				new DescribeEntryParameter () {
					Identifier = "Container", 
					Default = null, // null if null
					Brief = "Container to append to",
					Index = 10,
					Key = ""
					}
				}
			};

		}

    public partial class ContainerIndex : _ContainerIndex {
        } // class ContainerIndex

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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Container {
			get => _Data[0] as ExistingFile;
			set => _Data[0]  = value;
			}

		public virtual string _Container {
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
		/// <summary>Field accessor for option [key]</summary>
		public virtual String Key {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _Key {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Mesh {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[6] as Enumeration<EnumReporting>;
			set => _Data[6]  = value;
			}

		public virtual string _EnumReporting {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[7] as Flag;
			set => _Data[7]  = value;
			}

		public virtual string _Verbose {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[8] as Flag;
			set => _Data[8]  = value;
			}

		public virtual string _Report {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[9] as Flag;
			set => _Data[9]  = value;
			}

		public virtual string _Json {
			set => _Data[9].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "extract",
			Brief =  "Extract the specified record from the container",
			HandleDelegate =  CommandLineInterpreter.Handle_ContainerExtract,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Container", 
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
					Identifier = "Key", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 4,
					Key = "key"
					},
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 5,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 6,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 7,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 8,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 9,
					Key = "json"
					}
				}
			};

		}

    public partial class ContainerExtract : _ContainerExtract {
        } // class ContainerExtract

    public class _ContainerCopy : Goedel.Command.Dispatch ,
							IEncodeOptions,
							ICryptoOptions,
							IContainerOptions,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new ExistingFile (),
			new NewFile (),
			new String (),
			new String (),
			new String (),
			new Flag (),
			new String (),
			new String (),
			new Enumeration<EnumAuthentication> (CommandLineInterpreter.DescribeEnumAuthentication),
			new Enumeration<EnumUse> (CommandLineInterpreter.DescribeEnumUse),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
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
		/// <summary>Field accessor for option [cty]</summary>
		public virtual String ContentType {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _ContentType {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [encrypt]</summary>
		public virtual String Encrypt {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _Encrypt {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [sign]</summary>
		public virtual String Sign {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _Sign {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [hash]</summary>
		public virtual Flag Hash {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Hash {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [alg]</summary>
		public virtual String Algorithms {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Algorithms {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [type]</summary>
		public virtual String Type {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _Type {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for parameter [auth]</summary>
		public virtual Enumeration<EnumAuthentication> EnumAuthentication {
			get => _Data[8] as Enumeration<EnumAuthentication>;
			set => _Data[8]  = value;
			}

		public virtual string _EnumAuthentication {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for parameter [use]</summary>
		public virtual Enumeration<EnumUse> EnumUse {
			get => _Data[9] as Enumeration<EnumUse>;
			set => _Data[9]  = value;
			}

		public virtual string _EnumUse {
			set => _Data[9].Parameter (value);
			}
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[10] as String;
			set => _Data[10]  = value;
			}

		public virtual string _Mesh {
			set => _Data[10].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[11] as Enumeration<EnumReporting>;
			set => _Data[11]  = value;
			}

		public virtual string _EnumReporting {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[12] as Flag;
			set => _Data[12]  = value;
			}

		public virtual string _Verbose {
			set => _Data[12].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[13] as Flag;
			set => _Data[13]  = value;
			}

		public virtual string _Report {
			set => _Data[13].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[14] as Flag;
			set => _Data[14]  = value;
			}

		public virtual string _Json {
			set => _Data[14].Parameter (value);
			}
		/// <summary>Field accessor for option [decrypt]</summary>
		public virtual Flag Decrypt {
			get => _Data[15] as Flag;
			set => _Data[15]  = value;
			}

		public virtual string _Decrypt {
			set => _Data[15].Parameter (value);
			}
		/// <summary>Field accessor for option [index]</summary>
		public virtual Flag Index {
			get => _Data[16] as Flag;
			set => _Data[16]  = value;
			}

		public virtual string _Index {
			set => _Data[16].Parameter (value);
			}
		/// <summary>Field accessor for option [purge]</summary>
		public virtual Flag Purge {
			get => _Data[17] as Flag;
			set => _Data[17]  = value;
			}

		public virtual string _Purge {
			set => _Data[17].Parameter (value);
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
					Identifier = "ContentType", 
					Default = null, // null if null
					Brief = "Content Type",
					Index = 2,
					Key = "cty"
					},
				new DescribeEntryOption () {
					Identifier = "Encrypt", 
					Default = null, // null if null
					Brief = "Encrypt data for specified recipient",
					Index = 3,
					Key = "encrypt"
					},
				new DescribeEntryOption () {
					Identifier = "Sign", 
					Default = null, // null if null
					Brief = "Sign data with specified key",
					Index = 4,
					Key = "sign"
					},
				new DescribeEntryOption () {
					Identifier = "Hash", 
					Default = "true", // null if null
					Brief = "Compute hash of content",
					Index = 5,
					Key = "hash"
					},
				new DescribeEntryOption () {
					Identifier = "Algorithms", 
					Default = null, // null if null
					Brief = "List of algorithm specifiers",
					Index = 6,
					Key = "alg"
					},
				new DescribeEntryOption () {
					Identifier = "Type", 
					Default = null, // null if null
					Brief = "The container type, plain/tree/digest/chain/tree",
					Index = 7,
					Key = "type"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumAuthentication", 
					Default = null, // null if null
					Brief = "Authentication and indexing",
					Index = 8,
					Key = "auth"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumUse", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 9,
					Key = "use"
					},
				new DescribeEntryOption () {
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 10,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 11,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 12,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 13,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 14,
					Key = "json"
					},
				new DescribeEntryOption () {
					Identifier = "Decrypt", 
					Default = "false", // null if null
					Brief = "Decrypt contents",
					Index = 15,
					Key = "decrypt"
					},
				new DescribeEntryOption () {
					Identifier = "Index", 
					Default = "true", // null if null
					Brief = "Append an index record to the end",
					Index = 16,
					Key = "index"
					},
				new DescribeEntryOption () {
					Identifier = "Purge", 
					Default = "true", // null if null
					Brief = "Purge unused data etc.",
					Index = 17,
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new ExistingFile ()			} ;





		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String Mesh {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Mesh {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[1] as Enumeration<EnumReporting>;
			set => _Data[1]  = value;
			}

		public virtual string _EnumReporting {
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
		public virtual ExistingFile Container {
			get => _Data[5] as ExistingFile;
			set => _Data[5]  = value;
			}

		public virtual string _Container {
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
					Identifier = "Mesh", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 1,
					Key = "report"
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
					Identifier = "Container", 
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


    public partial class  Flag : Goedel.Command._Flag {
        public Flag(string value=null) : base (value) {}
        } // Flag

    public partial class  File : Goedel.Command._File {
	    public File(string value=null) : base (value) {}
        } // File

    public partial class  NewFile : Goedel.Command._NewFile {
		public NewFile(string value=null) : base (value) {}
        } // NewFile

    public partial class  ExistingFile : Goedel.Command._ExistingFile {
		public ExistingFile(string value=null) : base (value) {}
        } // ExistingFile

    public partial class  Integer : Goedel.Command._Integer {
		public Integer(string value=null) : base (value) {}
        } // Integer

    public partial class  String : Goedel.Command._String {
		public String(string value=null) : base (value) {}
        } // String



    public partial class  Enumeration<T> : _Enumeration<T> {
        public Enumeration(DescribeEntryEnumerate description, string value=null) : base(description, value){
            }
        } // _Enumeration<T>

	// The stub class just contains routines that echo their arguments and
	// write 'not yet implemented'

	// Eventually there will be a compiler option to suppress the debugging
	// to eliminate the redundant code
    public class _Shell : global::Goedel.Command.DispatchShell {

		public virtual ShellResult ProfileHello ( ProfileHello Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult MasterCreate ( MasterCreate Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ProfileRegister ( ProfileRegister Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ProfileSync ( ProfileSync Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ProfileEscrow ( ProfileEscrow Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ProfileRecover ( ProfileRecover Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ProfileExport ( ProfileExport Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ProfileImport ( ProfileImport Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ProfileList ( ProfileList Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ProfileDump ( ProfileDump Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DeviceCreate ( DeviceCreate Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DeviceAuthorize ( DeviceAuthorize Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ProfileConnect ( ProfileConnect Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ProfilePending ( ProfilePending Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ProfileAccept ( ProfileAccept Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ProfileReject ( ProfileReject Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ProfileGetPIN ( ProfileGetPIN Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ConnectEarl ( ConnectEarl Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DeviceDelete ( DeviceDelete Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DeviceList ( DeviceList Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult MessageContact ( MessageContact Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult MessageConfirm ( MessageConfirm Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult MessagePending ( MessagePending Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult MessageStatus ( MessageStatus Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult MessageAccept ( MessageAccept Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult MessageReject ( MessageReject Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult MessageBlock ( MessageBlock Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult GroupCreate ( GroupCreate Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult GroupAdd ( GroupAdd Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult GroupDelete ( GroupDelete Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult GroupList ( GroupList Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult MailAdd ( MailAdd Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult MailUpdate ( MailUpdate Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult SMIMEPrivate ( SMIMEPrivate Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult SMIMEPublic ( SMIMEPublic Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult PGPPrivate ( PGPPrivate Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult PGPPublic ( PGPPublic Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult SSHCreate ( SSHCreate Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult SSHPrivate ( SSHPrivate Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult SSHPublic ( SSHPublic Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult SSHMergeKnown ( SSHMergeKnown Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult SSHMergeClient ( SSHMergeClient Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult SSHAddHost ( SSHAddHost Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult SSHAddClient ( SSHAddClient Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult SSHKnown ( SSHKnown Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult SSHAuth ( SSHAuth Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult PasswordAdd ( PasswordAdd Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult PasswordGet ( PasswordGet Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult PasswordDelete ( PasswordDelete Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult PasswordDump ( PasswordDump Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ContactAdd ( ContactAdd Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ContactDelete ( ContactDelete Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ContactGet ( ContactGet Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ContactDump ( ContactDump Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult BookmarkAdd ( BookmarkAdd Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult BookmarkDelete ( BookmarkDelete Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult BookmarkGet ( BookmarkGet Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult BookmarkDump ( BookmarkDump Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult CalendarAdd ( CalendarAdd Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult CalendarGet ( CalendarGet Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult CalendarDelete ( CalendarDelete Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult CalendarDump ( CalendarDump Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult NetworkAdd ( NetworkAdd Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult NetworkGet ( NetworkGet Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult NetworkDelete ( NetworkDelete Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult NetworkDump ( NetworkDump Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult KeyNonce ( KeyNonce Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult KeySecret ( KeySecret Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult KeyEarl ( KeyEarl Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult KeyShare ( KeyShare Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult KeyRecover ( KeyRecover Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult HashUDF ( HashUDF Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult HashDigest ( HashDigest Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult HashMac ( HashMac Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DareEncode ( DareEncode Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DareDecode ( DareDecode Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DareVerify ( DareVerify Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DareEARL ( DareEARL Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ContainerCreate ( ContainerCreate Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ContainerArchive ( ContainerArchive Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ContainerAppend ( ContainerAppend Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ContainerDelete ( ContainerDelete Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ContainerIndex ( ContainerIndex Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ContainerExtract ( ContainerExtract Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ContainerCopy ( ContainerCopy Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ContainerVerify ( ContainerVerify Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}


        } // class _Shell

    public partial class Shell : _Shell {
        } // class Shell

    } // namespace Shell


