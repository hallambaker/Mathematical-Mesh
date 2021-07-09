
//  This file was automatically generated at 7/9/2021 1:37:36 AM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  commandparse version 3.0.0.662
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2019
//  
//  Build Platform: Win32NT 10.0.18362.0
//  
//  
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Command;
using Goedel.Utilities;
#pragma warning disable IDE1006
#pragma warning disable CS1591

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




		public static DescribeCommandSet DescribeCommandSet_Account = new DescribeCommandSet () {
            Identifier = "account",
			Brief = "Account creation and management commands.",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"hello", _AccountHello._DescribeCommand },
				{"create", _AccountCreate._DescribeCommand },
				{"delete", _AccountDelete._DescribeCommand },
				{"status", _AccountStatus._DescribeCommand },
				{"sync", _AccountSync._DescribeCommand },
				{"pin", _AccountGetPIN._DescribeCommand },
				{"publish", _AccountPublish._DescribeCommand },
				{"connect", _AccountConnect._DescribeCommand },
				{"escrow", _AccountEscrow._DescribeCommand },
				{"purge", _AccountPurge._DescribeCommand },
				{"recover", _AccountRecover._DescribeCommand },
				{"list", _AccountList._DescribeCommand },
				{"get", _AccountGet._DescribeCommand },
				{"export", _AccountExport._DescribeCommand },
				{"import", _AccountImport._DescribeCommand }
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_Connect = new DescribeCommandSet () {
            Identifier = "device",
			Brief = "Device management commands.",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"request", _DeviceRequestConnect._DescribeCommand },
				{"pending", _DevicePending._DescribeCommand },
				{"complete", _DeviceComplete._DescribeCommand },
				{"accept", _DeviceAccept._DescribeCommand },
				{"reject", _DeviceReject._DescribeCommand },
				{"delete", _DeviceDelete._DescribeCommand },
				{"list", _DeviceList._DescribeCommand },
				{"auth", _DeviceAuthorize._DescribeCommand },
				{"join", _DeviceJoin._DescribeCommand },
				{"install", _DeviceInstall._DescribeCommand },
				{"preconfig", _DevicePreconfigure._DescribeCommand }
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
				{"get", _GroupGet._DescribeCommand },
				{"delete", _GroupDelete._DescribeCommand },
				{"list", _GroupList._DescribeCommand }
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
				{"self", _ContactSelf._DescribeCommand },
				{"static", _ContactStatic._DescribeCommand },
				{"dynamic", _ContactDynamic._DescribeCommand },
				{"fetch", _ContactFetch._DescribeCommand },
				{"exchange", _ContactExchange._DescribeCommand },
				{"export", _ContactExport._DescribeCommand },
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
				{"import", _CalendarImport._DescribeCommand },
				{"add", _CalendarAdd._DescribeCommand },
				{"get", _CalendarGet._DescribeCommand },
				{"delete", _CalendarDelete._DescribeCommand },
				{"list", _CalendarDump._DescribeCommand }
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_Network = new DescribeCommandSet () {
            Identifier = "network",
			Brief = "Manage network profile settings",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"import", _NetworkImport._DescribeCommand },
				{"add", _NetworkAdd._DescribeCommand },
				{"get", _NetworkGet._DescribeCommand },
				{"delete", _NetworkDelete._DescribeCommand },
				{"list", _NetworkDump._DescribeCommand }
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
				{"earl", _DareEARL._DescribeCommand },
				{"sequence", _DareSequence._DescribeCommand },
				{"archive", _DareArchive._DescribeCommand },
				{"log", _DareLog._DescribeCommand },
				{"append", _DareAppend._DescribeCommand },
				{"delete", _DareDelete._DescribeCommand },
				{"dir", _DareDir._DescribeCommand },
				{"list", _DareList._DescribeCommand },
				{"index", _DareIndex._DescribeCommand },
				{"extract", _DareExtract._DescribeCommand },
				{"purge", _DarePurge._DescribeCommand }
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_Mail = new DescribeCommandSet () {
            Identifier = "mail",
			Brief = "Manage mail profiles connected to a personal profile",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"add", _MailAdd._DescribeCommand },
				{"update", _MailUpdate._DescribeCommand },
				{"smime", DescribeCommandSet_SMIME},
				{"openpgp", DescribeCommandSet_PGP},
				{"list", _MailList._DescribeCommand }
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
				{"account", DescribeCommandSet_Account},
				{"device", DescribeCommandSet_Connect},
				{"message", DescribeCommandSet_Message},
				{"group", DescribeCommandSet_Group},
				{"password", DescribeCommandSet_Password},
				{"contact", DescribeCommandSet_Contact},
				{"bookmark", DescribeCommandSet_Bookmark},
				{"calendar", DescribeCommandSet_Calendar},
				{"network", DescribeCommandSet_Network},
				{"key", DescribeCommandSet_Key},
				{"hash", DescribeCommandSet_Hash},
				{"dare", DescribeCommandSet_Dare},
				{"mail", DescribeCommandSet_Mail},
				{"ssh", DescribeCommandSet_SSH},
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




		public static void Handle_AccountHello (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			AccountHello		Options = new AccountHello ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.AccountHello (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_AccountCreate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			AccountCreate		Options = new AccountCreate ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.AccountCreate (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_AccountDelete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			AccountDelete		Options = new AccountDelete ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.AccountDelete (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_AccountStatus (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			AccountStatus		Options = new AccountStatus ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.AccountStatus (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_AccountSync (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			AccountSync		Options = new AccountSync ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.AccountSync (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_AccountGetPIN (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			AccountGetPIN		Options = new AccountGetPIN ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.AccountGetPIN (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_AccountPublish (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			AccountPublish		Options = new AccountPublish ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.AccountPublish (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_AccountConnect (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			AccountConnect		Options = new AccountConnect ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.AccountConnect (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_AccountEscrow (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			AccountEscrow		Options = new AccountEscrow ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.AccountEscrow (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_AccountPurge (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			AccountPurge		Options = new AccountPurge ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.AccountPurge (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_AccountRecover (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			AccountRecover		Options = new AccountRecover ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.AccountRecover (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_AccountList (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			AccountList		Options = new AccountList ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.AccountList (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_AccountGet (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			AccountGet		Options = new AccountGet ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.AccountGet (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_AccountExport (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			AccountExport		Options = new AccountExport ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.AccountExport (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_AccountImport (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			AccountImport		Options = new AccountImport ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.AccountImport (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DeviceRequestConnect (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DeviceRequestConnect		Options = new DeviceRequestConnect ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DeviceRequestConnect (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DevicePending (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DevicePending		Options = new DevicePending ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DevicePending (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DeviceComplete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DeviceComplete		Options = new DeviceComplete ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DeviceComplete (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DeviceAccept (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DeviceAccept		Options = new DeviceAccept ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DeviceAccept (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DeviceReject (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DeviceReject		Options = new DeviceReject ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DeviceReject (Options);
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

		public static void Handle_DeviceAuthorize (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DeviceAuthorize		Options = new DeviceAuthorize ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DeviceAuthorize (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DeviceJoin (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DeviceJoin		Options = new DeviceJoin ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DeviceJoin (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DeviceInstall (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DeviceInstall		Options = new DeviceInstall ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DeviceInstall (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DevicePreconfigure (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DevicePreconfigure		Options = new DevicePreconfigure ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DevicePreconfigure (Options);
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

		public static void Handle_GroupGet (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			GroupGet		Options = new GroupGet ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.GroupGet (Options);
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

		public static void Handle_ContactSelf (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ContactSelf		Options = new ContactSelf ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ContactSelf (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ContactStatic (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ContactStatic		Options = new ContactStatic ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ContactStatic (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ContactDynamic (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ContactDynamic		Options = new ContactDynamic ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ContactDynamic (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ContactFetch (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ContactFetch		Options = new ContactFetch ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ContactFetch (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ContactExchange (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ContactExchange		Options = new ContactExchange ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ContactExchange (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_ContactExport (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ContactExport		Options = new ContactExport ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.ContactExport (Options);
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

		public static void Handle_CalendarImport (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			CalendarImport		Options = new CalendarImport ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.CalendarImport (Options);
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

		public static void Handle_NetworkImport (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			NetworkImport		Options = new NetworkImport ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.NetworkImport (Options);
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

		public static void Handle_DareSequence (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DareSequence		Options = new DareSequence ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DareSequence (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DareArchive (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DareArchive		Options = new DareArchive ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DareArchive (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DareLog (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DareLog		Options = new DareLog ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DareLog (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DareAppend (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DareAppend		Options = new DareAppend ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DareAppend (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DareDelete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DareDelete		Options = new DareDelete ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DareDelete (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DareDir (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DareDir		Options = new DareDir ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DareDir (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DareList (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DareList		Options = new DareList ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DareList (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DareIndex (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DareIndex		Options = new DareIndex ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DareIndex (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DareExtract (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DareExtract		Options = new DareExtract ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DareExtract (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DarePurge (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DarePurge		Options = new DarePurge ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DarePurge (Options);
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

		public static void Handle_MailList (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			MailList		Options = new MailList ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.MailList (Options);
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

	public interface ILogOptions {
		ExistingFile			Log{get; set;}
		String			Admin{get; set;}
		}

	public interface IAccountOptions {
		String			AccountAddress{get; set;}
		String			LocalName{get; set;}
		}

	public interface IDeviceProfileInfo {
		Flag			DeviceNew{get; set;}
		String			DeviceUDF{get; set;}
		String			DeviceID{get; set;}
		String			DeviceDescription{get; set;}
		}

	public interface IDeviceAuthOptions {
		String			Auth{get; set;}
		Flag			AuthSuper{get; set;}
		Flag			AuthAdmin{get; set;}
		Flag			AuthMessage{get; set;}
		Flag			AuthWeb{get; set;}
		Flag			AuthDevice{get; set;}
		String			AuthSSH{get; set;}
		String			AuthEmail{get; set;}
		String			AuthGroupMember{get; set;}
		String			AuthGroupAdmin{get; set;}
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

	public interface ISequenceOptions {
		String			Type{get; set;}
		}


    public class _AccountHello : Goedel.Command.Dispatch ,
							IAccountOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
			set => _Data[1].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "hello",
			Brief =  "Connect to the service(s) a profile is connected to and report status.",
			HandleDelegate =  CommandLineInterpreter.Handle_AccountHello,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
					}
				}
			};

		}

    public partial class AccountHello : _AccountHello {
        } // class AccountHello

    public class _AccountCreate : Goedel.Command.Dispatch ,
							IDeviceProfileInfo,
							IReporting,
							ICryptoOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new String (),
			new String (),
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
		/// <summary>Field accessor for option [localname]</summary>
		public virtual String Localname {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Localname {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [new]</summary>
		public virtual Flag DeviceNew {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _DeviceNew {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [dudf]</summary>
		public virtual String DeviceUDF {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _DeviceUDF {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [did]</summary>
		public virtual String DeviceID {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _DeviceID {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [dd]</summary>
		public virtual String DeviceDescription {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _DeviceDescription {
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
		/// <summary>Field accessor for option [alg]</summary>
		public virtual String Algorithms {
			get => _Data[10] as String;
			set => _Data[10]  = value;
			}

		public virtual string _Algorithms {
			set => _Data[10].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "create",
			Brief =  "Create new account profile",
			HandleDelegate =  CommandLineInterpreter.Handle_AccountCreate,
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
					Identifier = "Localname", 
					Default = null, // null if null
					Brief = "Account friendly name",
					Index = 1,
					Key = "localname"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceNew", 
					Default = "false", // null if null
					Brief = "Force creation of new device profile",
					Index = 2,
					Key = "new"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceUDF", 
					Default = null, // null if null
					Brief = "Device profile fingerprint",
					Index = 3,
					Key = "dudf"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceID", 
					Default = null, // null if null
					Brief = "Device identifier",
					Index = 4,
					Key = "did"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceDescription", 
					Default = null, // null if null
					Brief = "Device description",
					Index = 5,
					Key = "dd"
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
					Identifier = "Algorithms", 
					Default = null, // null if null
					Brief = "List of algorithm specifiers",
					Index = 10,
					Key = "alg"
					}
				}
			};

		}

    public partial class AccountCreate : _AccountCreate {
        } // class AccountCreate

    public class _AccountDelete : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual String ProfileUdf {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _ProfileUdf {
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
			Brief =  "Delete an account profile",
			HandleDelegate =  CommandLineInterpreter.Handle_AccountDelete,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "ProfileUdf", 
					Default = null, // null if null
					Brief = "Fingerprint of the account to be removed from this device",
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
					}
				}
			};

		}

    public partial class AccountDelete : _AccountDelete {
        } // class AccountDelete

    public class _AccountStatus : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
			Brief =  "Return the status of the account catalogs and spools",
			HandleDelegate =  CommandLineInterpreter.Handle_AccountStatus,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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

    public partial class AccountStatus : _AccountStatus {
        } // class AccountStatus

    public class _AccountSync : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for option [auto]</summary>
		public virtual Flag AutoApprove {
			get => _Data[6] as Flag;
			set => _Data[6]  = value;
			}

		public virtual string _AutoApprove {
			set => _Data[6].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "sync",
			Brief =  "Synchronize local copies of Mesh profiles with the server",
			HandleDelegate =  CommandLineInterpreter.Handle_AccountSync,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "AutoApprove", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 6,
					Key = "auto"
					}
				}
			};

		}

    public partial class AccountSync : _AccountSync {
        } // class AccountSync

    public class _AccountGetPIN : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Integer (),
			new String (),
			new String (),
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
		/// <summary>Field accessor for option [expire]</summary>
		public virtual String Expire {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Expire {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "pin",
			Brief =  "Get a pin value to pre-authorize a connection",
			HandleDelegate =  CommandLineInterpreter.Handle_AccountGetPIN,
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
					Identifier = "Expire", 
					Default = "1", // null if null
					Brief = "<Unspecified>",
					Index = 1,
					Key = "expire"
					},
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 2,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 3,
					Key = "local"
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

    public partial class AccountGetPIN : _AccountGetPIN {
        } // class AccountGetPIN

    public class _AccountPublish : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "publish",
			Brief =  "Create a new device profile and register the corresponding URI.",
			HandleDelegate =  CommandLineInterpreter.Handle_AccountPublish,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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

    public partial class AccountPublish : _AccountPublish {
        } // class AccountPublish

    public class _AccountConnect : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							IDeviceAuthOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String (),
			new String (),
			new String ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual String Uri {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Uri {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for option [auth]</summary>
		public virtual String Auth {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _Auth {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [root]</summary>
		public virtual Flag AuthSuper {
			get => _Data[8] as Flag;
			set => _Data[8]  = value;
			}

		public virtual string _AuthSuper {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for option [admin]</summary>
		public virtual Flag AuthAdmin {
			get => _Data[9] as Flag;
			set => _Data[9]  = value;
			}

		public virtual string _AuthAdmin {
			set => _Data[9].Parameter (value);
			}
		/// <summary>Field accessor for option [message]</summary>
		public virtual Flag AuthMessage {
			get => _Data[10] as Flag;
			set => _Data[10]  = value;
			}

		public virtual string _AuthMessage {
			set => _Data[10].Parameter (value);
			}
		/// <summary>Field accessor for option [web]</summary>
		public virtual Flag AuthWeb {
			get => _Data[11] as Flag;
			set => _Data[11]  = value;
			}

		public virtual string _AuthWeb {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for option [device]</summary>
		public virtual Flag AuthDevice {
			get => _Data[12] as Flag;
			set => _Data[12]  = value;
			}

		public virtual string _AuthDevice {
			set => _Data[12].Parameter (value);
			}
		/// <summary>Field accessor for option [ssh]</summary>
		public virtual String AuthSSH {
			get => _Data[13] as String;
			set => _Data[13]  = value;
			}

		public virtual string _AuthSSH {
			set => _Data[13].Parameter (value);
			}
		/// <summary>Field accessor for option [email]</summary>
		public virtual String AuthEmail {
			get => _Data[14] as String;
			set => _Data[14]  = value;
			}

		public virtual string _AuthEmail {
			set => _Data[14].Parameter (value);
			}
		/// <summary>Field accessor for option [member]</summary>
		public virtual String AuthGroupMember {
			get => _Data[15] as String;
			set => _Data[15]  = value;
			}

		public virtual string _AuthGroupMember {
			set => _Data[15].Parameter (value);
			}
		/// <summary>Field accessor for option [group]</summary>
		public virtual String AuthGroupAdmin {
			get => _Data[16] as String;
			set => _Data[16]  = value;
			}

		public virtual string _AuthGroupAdmin {
			set => _Data[16].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "connect",
			Brief =  "Connect by means of a connection uri",
			HandleDelegate =  CommandLineInterpreter.Handle_AccountConnect,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Uri", 
					Default = null, // null if null
					Brief = "The device location URI",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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
					},
				new DescribeEntryOption () {
					Identifier = "Auth", 
					Default = null, // null if null
					Brief = "(De)Authorize the specified function on the device",
					Index = 7,
					Key = "auth"
					},
				new DescribeEntryOption () {
					Identifier = "AuthSuper", 
					Default = "false", // null if null
					Brief = "Device as super administration device",
					Index = 8,
					Key = "root"
					},
				new DescribeEntryOption () {
					Identifier = "AuthAdmin", 
					Default = "false", // null if null
					Brief = "Device as administration device",
					Index = 9,
					Key = "admin"
					},
				new DescribeEntryOption () {
					Identifier = "AuthMessage", 
					Default = "false", // null if null
					Brief = "Authorize rights for Mesh messaging",
					Index = 10,
					Key = "message"
					},
				new DescribeEntryOption () {
					Identifier = "AuthWeb", 
					Default = "false", // null if null
					Brief = "Authorize rights for Mesh messaging and Web.",
					Index = 11,
					Key = "web"
					},
				new DescribeEntryOption () {
					Identifier = "AuthDevice", 
					Default = "false", // null if null
					Brief = "Device restrictive access",
					Index = 12,
					Key = "device"
					},
				new DescribeEntryOption () {
					Identifier = "AuthSSH", 
					Default = "false", // null if null
					Brief = "Authorize rights for specified SSH account",
					Index = 13,
					Key = "ssh"
					},
				new DescribeEntryOption () {
					Identifier = "AuthEmail", 
					Default = "false", // null if null
					Brief = "Authorize rights for specified smtp email account",
					Index = 14,
					Key = "email"
					},
				new DescribeEntryOption () {
					Identifier = "AuthGroupMember", 
					Default = "false", // null if null
					Brief = "Authorize member rights for specified Mesh group",
					Index = 15,
					Key = "member"
					},
				new DescribeEntryOption () {
					Identifier = "AuthGroupAdmin", 
					Default = "false", // null if null
					Brief = "Authorize group administrator rights for specified Mesh group",
					Index = 16,
					Key = "group"
					}
				}
			};

		}

    public partial class AccountConnect : _AccountConnect {
        } // class AccountConnect

    public class _AccountEscrow : Goedel.Command.Dispatch ,
							ICryptoOptions,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
			HandleDelegate =  CommandLineInterpreter.Handle_AccountEscrow,
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class AccountEscrow : _AccountEscrow {
        } // class AccountEscrow

    public class _AccountPurge : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "purge",
			Brief =  "Purge the Mesh recovery key from this device",
			HandleDelegate =  CommandLineInterpreter.Handle_AccountPurge,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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

    public partial class AccountPurge : _AccountPurge {
        } // class AccountPurge

    public class _AccountRecover : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
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





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		public virtual String Share1 {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Share1 {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Share2 {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _Share2 {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Share3 {
			get => _Data[8] as String;
			set => _Data[8]  = value;
			}

		public virtual string _Share3 {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Share4 {
			get => _Data[9] as String;
			set => _Data[9]  = value;
			}

		public virtual string _Share4 {
			set => _Data[9].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Share5 {
			get => _Data[10] as String;
			set => _Data[10]  = value;
			}

		public virtual string _Share5 {
			set => _Data[10].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Share6 {
			get => _Data[11] as String;
			set => _Data[11]  = value;
			}

		public virtual string _Share6 {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Share7 {
			get => _Data[12] as String;
			set => _Data[12]  = value;
			}

		public virtual string _Share7 {
			set => _Data[12].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Share8 {
			get => _Data[13] as String;
			set => _Data[13]  = value;
			}

		public virtual string _Share8 {
			set => _Data[13].Parameter (value);
			}
		/// <summary>Field accessor for option [file]</summary>
		public virtual ExistingFile File {
			get => _Data[14] as ExistingFile;
			set => _Data[14]  = value;
			}

		public virtual string _File {
			set => _Data[14].Parameter (value);
			}
		/// <summary>Field accessor for option [verify]</summary>
		public virtual Flag Verify {
			get => _Data[15] as Flag;
			set => _Data[15]  = value;
			}

		public virtual string _Verify {
			set => _Data[15].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "recover",
			Brief =  "Recover escrowed profile",
			HandleDelegate =  CommandLineInterpreter.Handle_AccountRecover,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "Share1", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 6,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Share2", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 7,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Share3", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 8,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Share4", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 9,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Share5", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 10,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Share6", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 11,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Share7", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 12,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Share8", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 13,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 14,
					Key = "file"
					},
				new DescribeEntryOption () {
					Identifier = "Verify", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 15,
					Key = "verify"
					}
				}
			};

		}

    public partial class AccountRecover : _AccountRecover {
        } // class AccountRecover

    public class _AccountList : Goedel.Command.Dispatch ,
							IReporting,
							IAccountOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _LocalName {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "list",
			Brief =  "List all profiles on the local machine",
			HandleDelegate =  CommandLineInterpreter.Handle_AccountList,
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 4,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 5,
					Key = "local"
					}
				}
			};

		}

    public partial class AccountList : _AccountList {
        } // class AccountList

    public class _AccountGet : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
			Brief =  "Describe the specified profile",
			HandleDelegate =  CommandLineInterpreter.Handle_AccountGet,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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

    public partial class AccountGet : _AccountGet {
        } // class AccountGet

    public class _AccountExport : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new NewFile (),
			new String (),
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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "export",
			Brief =  "Export the specified profile data to the specified file",
			HandleDelegate =  CommandLineInterpreter.Handle_AccountExport,
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class AccountExport : _AccountExport {
        } // class AccountExport

    public class _AccountImport : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new NewFile (),
			new String (),
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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "import",
			Brief =  "Import the specified profile data to the specified file",
			HandleDelegate =  CommandLineInterpreter.Handle_AccountImport,
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class AccountImport : _AccountImport {
        } // class AccountImport

    public class _DeviceRequestConnect : Goedel.Command.Dispatch ,
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
			new String (),
			new String (),
			new String (),
			new String ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
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
		/// <summary>Field accessor for option [root]</summary>
		public virtual Flag AuthSuper {
			get => _Data[11] as Flag;
			set => _Data[11]  = value;
			}

		public virtual string _AuthSuper {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for option [admin]</summary>
		public virtual Flag AuthAdmin {
			get => _Data[12] as Flag;
			set => _Data[12]  = value;
			}

		public virtual string _AuthAdmin {
			set => _Data[12].Parameter (value);
			}
		/// <summary>Field accessor for option [message]</summary>
		public virtual Flag AuthMessage {
			get => _Data[13] as Flag;
			set => _Data[13]  = value;
			}

		public virtual string _AuthMessage {
			set => _Data[13].Parameter (value);
			}
		/// <summary>Field accessor for option [web]</summary>
		public virtual Flag AuthWeb {
			get => _Data[14] as Flag;
			set => _Data[14]  = value;
			}

		public virtual string _AuthWeb {
			set => _Data[14].Parameter (value);
			}
		/// <summary>Field accessor for option [device]</summary>
		public virtual Flag AuthDevice {
			get => _Data[15] as Flag;
			set => _Data[15]  = value;
			}

		public virtual string _AuthDevice {
			set => _Data[15].Parameter (value);
			}
		/// <summary>Field accessor for option [ssh]</summary>
		public virtual String AuthSSH {
			get => _Data[16] as String;
			set => _Data[16]  = value;
			}

		public virtual string _AuthSSH {
			set => _Data[16].Parameter (value);
			}
		/// <summary>Field accessor for option [email]</summary>
		public virtual String AuthEmail {
			get => _Data[17] as String;
			set => _Data[17]  = value;
			}

		public virtual string _AuthEmail {
			set => _Data[17].Parameter (value);
			}
		/// <summary>Field accessor for option [member]</summary>
		public virtual String AuthGroupMember {
			get => _Data[18] as String;
			set => _Data[18]  = value;
			}

		public virtual string _AuthGroupMember {
			set => _Data[18].Parameter (value);
			}
		/// <summary>Field accessor for option [group]</summary>
		public virtual String AuthGroupAdmin {
			get => _Data[19] as String;
			set => _Data[19]  = value;
			}

		public virtual string _AuthGroupAdmin {
			set => _Data[19].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "request",
			Brief =  "Connect to an existing profile registered at a portal",
			HandleDelegate =  CommandLineInterpreter.Handle_DeviceRequestConnect,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "The Mesh Service Account",
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
					Brief = "(De)Authorize the specified function on the device",
					Index = 10,
					Key = "auth"
					},
				new DescribeEntryOption () {
					Identifier = "AuthSuper", 
					Default = "false", // null if null
					Brief = "Device as super administration device",
					Index = 11,
					Key = "root"
					},
				new DescribeEntryOption () {
					Identifier = "AuthAdmin", 
					Default = "false", // null if null
					Brief = "Device as administration device",
					Index = 12,
					Key = "admin"
					},
				new DescribeEntryOption () {
					Identifier = "AuthMessage", 
					Default = "false", // null if null
					Brief = "Authorize rights for Mesh messaging",
					Index = 13,
					Key = "message"
					},
				new DescribeEntryOption () {
					Identifier = "AuthWeb", 
					Default = "false", // null if null
					Brief = "Authorize rights for Mesh messaging and Web.",
					Index = 14,
					Key = "web"
					},
				new DescribeEntryOption () {
					Identifier = "AuthDevice", 
					Default = "false", // null if null
					Brief = "Device restrictive access",
					Index = 15,
					Key = "device"
					},
				new DescribeEntryOption () {
					Identifier = "AuthSSH", 
					Default = "false", // null if null
					Brief = "Authorize rights for specified SSH account",
					Index = 16,
					Key = "ssh"
					},
				new DescribeEntryOption () {
					Identifier = "AuthEmail", 
					Default = "false", // null if null
					Brief = "Authorize rights for specified smtp email account",
					Index = 17,
					Key = "email"
					},
				new DescribeEntryOption () {
					Identifier = "AuthGroupMember", 
					Default = "false", // null if null
					Brief = "Authorize member rights for specified Mesh group",
					Index = 18,
					Key = "member"
					},
				new DescribeEntryOption () {
					Identifier = "AuthGroupAdmin", 
					Default = "false", // null if null
					Brief = "Authorize group administrator rights for specified Mesh group",
					Index = 19,
					Key = "group"
					}
				}
			};

		}

    public partial class DeviceRequestConnect : _DeviceRequestConnect {
        } // class DeviceRequestConnect

    public class _DevicePending : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "pending",
			Brief =  "Get list of pending connection requests",
			HandleDelegate =  CommandLineInterpreter.Handle_DevicePending,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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

    public partial class DevicePending : _DevicePending {
        } // class DevicePending

    public class _DeviceComplete : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "complete",
			Brief =  "Complete a pending request",
			HandleDelegate =  CommandLineInterpreter.Handle_DeviceComplete,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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

    public partial class DeviceComplete : _DeviceComplete {
        } // class DeviceComplete

    public class _DeviceAccept : Goedel.Command.Dispatch ,
							IDeviceAuthOptions,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String (),
			new String (),
			new String (),
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual String DeviceID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _DeviceID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [auth]</summary>
		public virtual String Auth {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _Auth {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [root]</summary>
		public virtual Flag AuthSuper {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _AuthSuper {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [admin]</summary>
		public virtual Flag AuthAdmin {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _AuthAdmin {
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
		/// <summary>Field accessor for option [web]</summary>
		public virtual Flag AuthWeb {
			get => _Data[6] as Flag;
			set => _Data[6]  = value;
			}

		public virtual string _AuthWeb {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [device]</summary>
		public virtual Flag AuthDevice {
			get => _Data[7] as Flag;
			set => _Data[7]  = value;
			}

		public virtual string _AuthDevice {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [ssh]</summary>
		public virtual String AuthSSH {
			get => _Data[8] as String;
			set => _Data[8]  = value;
			}

		public virtual string _AuthSSH {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for option [email]</summary>
		public virtual String AuthEmail {
			get => _Data[9] as String;
			set => _Data[9]  = value;
			}

		public virtual string _AuthEmail {
			set => _Data[9].Parameter (value);
			}
		/// <summary>Field accessor for option [member]</summary>
		public virtual String AuthGroupMember {
			get => _Data[10] as String;
			set => _Data[10]  = value;
			}

		public virtual string _AuthGroupMember {
			set => _Data[10].Parameter (value);
			}
		/// <summary>Field accessor for option [group]</summary>
		public virtual String AuthGroupAdmin {
			get => _Data[11] as String;
			set => _Data[11]  = value;
			}

		public virtual string _AuthGroupAdmin {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[12] as String;
			set => _Data[12]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[12].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[13] as String;
			set => _Data[13]  = value;
			}

		public virtual string _LocalName {
			set => _Data[13].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[14] as Enumeration<EnumReporting>;
			set => _Data[14]  = value;
			}

		public virtual string _EnumReporting {
			set => _Data[14].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[15] as Flag;
			set => _Data[15]  = value;
			}

		public virtual string _Verbose {
			set => _Data[15].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[16] as Flag;
			set => _Data[16]  = value;
			}

		public virtual string _Report {
			set => _Data[16].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[17] as Flag;
			set => _Data[17]  = value;
			}

		public virtual string _Json {
			set => _Data[17].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "accept",
			Brief =  "Accept a pending connection",
			HandleDelegate =  CommandLineInterpreter.Handle_DeviceAccept,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "CompletionCode", 
					Default = null, // null if null
					Brief = "Fingerprint of connection to accept",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "DeviceID", 
					Default = null, // null if null
					Brief = "Device identifier",
					Index = 1,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Auth", 
					Default = null, // null if null
					Brief = "(De)Authorize the specified function on the device",
					Index = 2,
					Key = "auth"
					},
				new DescribeEntryOption () {
					Identifier = "AuthSuper", 
					Default = "false", // null if null
					Brief = "Device as super administration device",
					Index = 3,
					Key = "root"
					},
				new DescribeEntryOption () {
					Identifier = "AuthAdmin", 
					Default = "false", // null if null
					Brief = "Device as administration device",
					Index = 4,
					Key = "admin"
					},
				new DescribeEntryOption () {
					Identifier = "AuthMessage", 
					Default = "false", // null if null
					Brief = "Authorize rights for Mesh messaging",
					Index = 5,
					Key = "message"
					},
				new DescribeEntryOption () {
					Identifier = "AuthWeb", 
					Default = "false", // null if null
					Brief = "Authorize rights for Mesh messaging and Web.",
					Index = 6,
					Key = "web"
					},
				new DescribeEntryOption () {
					Identifier = "AuthDevice", 
					Default = "false", // null if null
					Brief = "Device restrictive access",
					Index = 7,
					Key = "device"
					},
				new DescribeEntryOption () {
					Identifier = "AuthSSH", 
					Default = "false", // null if null
					Brief = "Authorize rights for specified SSH account",
					Index = 8,
					Key = "ssh"
					},
				new DescribeEntryOption () {
					Identifier = "AuthEmail", 
					Default = "false", // null if null
					Brief = "Authorize rights for specified smtp email account",
					Index = 9,
					Key = "email"
					},
				new DescribeEntryOption () {
					Identifier = "AuthGroupMember", 
					Default = "false", // null if null
					Brief = "Authorize member rights for specified Mesh group",
					Index = 10,
					Key = "member"
					},
				new DescribeEntryOption () {
					Identifier = "AuthGroupAdmin", 
					Default = "false", // null if null
					Brief = "Authorize group administrator rights for specified Mesh group",
					Index = 11,
					Key = "group"
					},
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 12,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 13,
					Key = "local"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 14,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 15,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 16,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 17,
					Key = "json"
					}
				}
			};

		}

    public partial class DeviceAccept : _DeviceAccept {
        } // class DeviceAccept

    public class _DeviceReject : Goedel.Command.Dispatch ,
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
		public virtual String CompletionCode {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _CompletionCode {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "reject",
			Brief =  "Reject a pending connection",
			HandleDelegate =  CommandLineInterpreter.Handle_DeviceReject,
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class DeviceReject : _DeviceReject {
        } // class DeviceReject

    public class _DeviceDelete : Goedel.Command.Dispatch ,
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
		public virtual String DeviceID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _DeviceID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
			Brief =  "Remove device from device catalog",
			HandleDelegate =  CommandLineInterpreter.Handle_DeviceDelete,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "DeviceID", 
					Default = null, // null if null
					Brief = "Device identifier",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class DeviceDelete : _DeviceDelete {
        } // class DeviceDelete

    public class _DeviceList : Goedel.Command.Dispatch ,
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





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		public virtual String GroupID {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _GroupID {
			set => _Data[6].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "list",
			Brief =  "List devices in the device catalog",
			HandleDelegate =  CommandLineInterpreter.Handle_DeviceList,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "GroupID", 
					Default = null, // null if null
					Brief = "Recryption group name in user@example.com format",
					Index = 6,
					Key = ""
					}
				}
			};

		}

    public partial class DeviceList : _DeviceList {
        } // class DeviceList

    public class _DeviceAuthorize : Goedel.Command.Dispatch ,
							IDeviceAuthOptions,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual String DeviceID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _DeviceID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [auth]</summary>
		public virtual String Auth {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Auth {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [root]</summary>
		public virtual Flag AuthSuper {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _AuthSuper {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [admin]</summary>
		public virtual Flag AuthAdmin {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _AuthAdmin {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [message]</summary>
		public virtual Flag AuthMessage {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _AuthMessage {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [web]</summary>
		public virtual Flag AuthWeb {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _AuthWeb {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [device]</summary>
		public virtual Flag AuthDevice {
			get => _Data[6] as Flag;
			set => _Data[6]  = value;
			}

		public virtual string _AuthDevice {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [ssh]</summary>
		public virtual String AuthSSH {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _AuthSSH {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [email]</summary>
		public virtual String AuthEmail {
			get => _Data[8] as String;
			set => _Data[8]  = value;
			}

		public virtual string _AuthEmail {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for option [member]</summary>
		public virtual String AuthGroupMember {
			get => _Data[9] as String;
			set => _Data[9]  = value;
			}

		public virtual string _AuthGroupMember {
			set => _Data[9].Parameter (value);
			}
		/// <summary>Field accessor for option [group]</summary>
		public virtual String AuthGroupAdmin {
			get => _Data[10] as String;
			set => _Data[10]  = value;
			}

		public virtual string _AuthGroupAdmin {
			set => _Data[10].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[11] as String;
			set => _Data[11]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[12] as String;
			set => _Data[12]  = value;
			}

		public virtual string _LocalName {
			set => _Data[12].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[13] as Enumeration<EnumReporting>;
			set => _Data[13]  = value;
			}

		public virtual string _EnumReporting {
			set => _Data[13].Parameter (value);
			}
		/// <summary>Field accessor for option [verbose]</summary>
		public virtual Flag Verbose {
			get => _Data[14] as Flag;
			set => _Data[14]  = value;
			}

		public virtual string _Verbose {
			set => _Data[14].Parameter (value);
			}
		/// <summary>Field accessor for option [report]</summary>
		public virtual Flag Report {
			get => _Data[15] as Flag;
			set => _Data[15]  = value;
			}

		public virtual string _Report {
			set => _Data[15].Parameter (value);
			}
		/// <summary>Field accessor for option [json]</summary>
		public virtual Flag Json {
			get => _Data[16] as Flag;
			set => _Data[16]  = value;
			}

		public virtual string _Json {
			set => _Data[16].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "auth",
			Brief =  "Authorize device to use application",
			HandleDelegate =  CommandLineInterpreter.Handle_DeviceAuthorize,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "DeviceID", 
					Default = null, // null if null
					Brief = "Device identifier",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Auth", 
					Default = null, // null if null
					Brief = "(De)Authorize the specified function on the device",
					Index = 1,
					Key = "auth"
					},
				new DescribeEntryOption () {
					Identifier = "AuthSuper", 
					Default = "false", // null if null
					Brief = "Device as super administration device",
					Index = 2,
					Key = "root"
					},
				new DescribeEntryOption () {
					Identifier = "AuthAdmin", 
					Default = "false", // null if null
					Brief = "Device as administration device",
					Index = 3,
					Key = "admin"
					},
				new DescribeEntryOption () {
					Identifier = "AuthMessage", 
					Default = "false", // null if null
					Brief = "Authorize rights for Mesh messaging",
					Index = 4,
					Key = "message"
					},
				new DescribeEntryOption () {
					Identifier = "AuthWeb", 
					Default = "false", // null if null
					Brief = "Authorize rights for Mesh messaging and Web.",
					Index = 5,
					Key = "web"
					},
				new DescribeEntryOption () {
					Identifier = "AuthDevice", 
					Default = "false", // null if null
					Brief = "Device restrictive access",
					Index = 6,
					Key = "device"
					},
				new DescribeEntryOption () {
					Identifier = "AuthSSH", 
					Default = "false", // null if null
					Brief = "Authorize rights for specified SSH account",
					Index = 7,
					Key = "ssh"
					},
				new DescribeEntryOption () {
					Identifier = "AuthEmail", 
					Default = "false", // null if null
					Brief = "Authorize rights for specified smtp email account",
					Index = 8,
					Key = "email"
					},
				new DescribeEntryOption () {
					Identifier = "AuthGroupMember", 
					Default = "false", // null if null
					Brief = "Authorize member rights for specified Mesh group",
					Index = 9,
					Key = "member"
					},
				new DescribeEntryOption () {
					Identifier = "AuthGroupAdmin", 
					Default = "false", // null if null
					Brief = "Authorize group administrator rights for specified Mesh group",
					Index = 10,
					Key = "group"
					},
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 11,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 12,
					Key = "local"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 13,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "true", // null if null
					Brief = "Verbose reports (default)",
					Index = 14,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true", // null if null
					Brief = "Report output (default)",
					Index = 15,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Json", 
					Default = "false", // null if null
					Brief = "Report output in JSON format",
					Index = 16,
					Key = "json"
					}
				}
			};

		}

    public partial class DeviceAuthorize : _DeviceAuthorize {
        } // class DeviceAuthorize

    public class _DeviceJoin : Goedel.Command.Dispatch ,
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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "join",
			Brief =  "Connect by means of a connection URI from an administration device.",
			HandleDelegate =  CommandLineInterpreter.Handle_DeviceJoin,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Uri", 
					Default = null, // null if null
					Brief = "The device location URI",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class DeviceJoin : _DeviceJoin {
        } // class DeviceJoin

    public class _DeviceInstall : Goedel.Command.Dispatch ,
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
		public virtual String Profile {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Profile {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "install",
			Brief =  "Connect by means of a connection URI from an administration device.",
			HandleDelegate =  CommandLineInterpreter.Handle_DeviceInstall,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Profile", 
					Default = null, // null if null
					Brief = "The device profile",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class DeviceInstall : _DeviceInstall {
        } // class DeviceInstall

    public class _DevicePreconfigure : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "preconfig",
			Brief =  "Generate new device profile and publish as an EARL",
			HandleDelegate =  CommandLineInterpreter.Handle_DevicePreconfigure,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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

    public partial class DevicePreconfigure : _DevicePreconfigure {
        } // class DevicePreconfigure

    public class _MessageContact : Goedel.Command.Dispatch ,
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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class MessageContact : _MessageContact {
        } // class MessageContact

    public class _MessageConfirm : Goedel.Command.Dispatch ,
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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _LocalName {
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 2,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 3,
					Key = "local"
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

    public partial class MessageConfirm : _MessageConfirm {
        } // class MessageConfirm

    public class _MessagePending : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for option [unread]</summary>
		public virtual Flag Unread {
			get => _Data[6] as Flag;
			set => _Data[6]  = value;
			}

		public virtual string _Unread {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [read]</summary>
		public virtual Flag Read {
			get => _Data[7] as Flag;
			set => _Data[7]  = value;
			}

		public virtual string _Read {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [raw]</summary>
		public virtual Flag Raw {
			get => _Data[8] as Flag;
			set => _Data[8]  = value;
			}

		public virtual string _Raw {
			set => _Data[8].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "pending",
			Brief =  "List pending requests",
			HandleDelegate =  CommandLineInterpreter.Handle_MessagePending,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "Unread", 
					Default = "false", // null if null
					Brief = "<Unspecified>",
					Index = 6,
					Key = "unread"
					},
				new DescribeEntryOption () {
					Identifier = "Read", 
					Default = "true", // null if null
					Brief = "<Unspecified>",
					Index = 7,
					Key = "read"
					},
				new DescribeEntryOption () {
					Identifier = "Raw", 
					Default = "false", // null if null
					Brief = "<Unspecified>",
					Index = 8,
					Key = "raw"
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
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual String RequestID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _RequestID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "status",
			Brief =  "Request status of pending request",
			HandleDelegate =  CommandLineInterpreter.Handle_MessageStatus,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "RequestID", 
					Default = null, // null if null
					Brief = "Specifies the request to provide the status of",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class MessageStatus : _MessageStatus {
        } // class MessageStatus

    public class _MessageAccept : Goedel.Command.Dispatch ,
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
		public virtual String RequestID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _RequestID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "accept",
			Brief =  "Accept a pending request",
			HandleDelegate =  CommandLineInterpreter.Handle_MessageAccept,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "RequestID", 
					Default = null, // null if null
					Brief = "Specifies the request to accept",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class MessageAccept : _MessageAccept {
        } // class MessageAccept

    public class _MessageReject : Goedel.Command.Dispatch ,
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
		public virtual String RequestID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _RequestID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "reject",
			Brief =  "Reject a pending request",
			HandleDelegate =  CommandLineInterpreter.Handle_MessageReject,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "RequestID", 
					Default = null, // null if null
					Brief = "Specifies the request to reject",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class MessageReject : _MessageReject {
        } // class MessageReject

    public class _MessageBlock : Goedel.Command.Dispatch ,
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
		public virtual String RequestID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _RequestID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "block",
			Brief =  "Reject a pending request and block requests from that source",
			HandleDelegate =  CommandLineInterpreter.Handle_MessageBlock,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "RequestID", 
					Default = null, // null if null
					Brief = "Specifies the request to reject and block",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class MessageBlock : _MessageBlock {
        } // class MessageBlock

    public class _GroupCreate : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							ICryptoOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for option [alg]</summary>
		public virtual String Algorithms {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Algorithms {
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "Algorithms", 
					Default = null, // null if null
					Brief = "List of algorithm specifiers",
					Index = 6,
					Key = "alg"
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

    public class _GroupAdd : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		public virtual String GroupID {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _GroupID {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String MemberID {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _MemberID {
			set => _Data[7].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "add",
			Brief =  "Add user to recryption group",
			HandleDelegate =  CommandLineInterpreter.Handle_GroupAdd,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "GroupID", 
					Default = null, // null if null
					Brief = "Recryption group name in user@example.com format",
					Index = 6,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "MemberID", 
					Default = null, // null if null
					Brief = "User to add",
					Index = 7,
					Key = ""
					}
				}
			};

		}

    public partial class GroupAdd : _GroupAdd {
        } // class GroupAdd

    public class _GroupGet : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		public virtual String GroupID {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _GroupID {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String MemberID {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _MemberID {
			set => _Data[7].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "get",
			Brief =  "Find member in recryption group",
			HandleDelegate =  CommandLineInterpreter.Handle_GroupGet,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "GroupID", 
					Default = null, // null if null
					Brief = "Recryption group name in user@example.com format",
					Index = 6,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "MemberID", 
					Default = null, // null if null
					Brief = "User to find",
					Index = 7,
					Key = ""
					}
				}
			};

		}

    public partial class GroupGet : _GroupGet {
        } // class GroupGet

    public class _GroupDelete : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		public virtual String GroupID {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _GroupID {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String MemberID {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _MemberID {
			set => _Data[7].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "delete",
			Brief =  "Remove user from recryption group",
			HandleDelegate =  CommandLineInterpreter.Handle_GroupDelete,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "GroupID", 
					Default = null, // null if null
					Brief = "Recryption group name in user@example.com format",
					Index = 6,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "MemberID", 
					Default = null, // null if null
					Brief = "User to delete",
					Index = 7,
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
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		public virtual String GroupID {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _GroupID {
			set => _Data[6].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "list",
			Brief =  "List members of a recryption group",
			HandleDelegate =  CommandLineInterpreter.Handle_GroupList,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "GroupID", 
					Default = null, // null if null
					Brief = "Recryption group name in user@example.com format",
					Index = 6,
					Key = ""
					}
				}
			};

		}

    public partial class GroupList : _GroupList {
        } // class GroupList
	public interface ISSHOptions {
		String			Application{get; set;}
		}


    public class _PasswordAdd : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _LocalName {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[5] as Enumeration<EnumReporting>;
			set => _Data[5]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 3,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 4,
					Key = "local"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 5,
					Key = "report"
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

    public partial class PasswordAdd : _PasswordAdd {
        } // class PasswordAdd

    public class _PasswordGet : Goedel.Command.Dispatch ,
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
		public virtual String Site {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Site {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class PasswordGet : _PasswordGet {
        } // class PasswordGet

    public class _PasswordDelete : Goedel.Command.Dispatch ,
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
		public virtual String Site {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Site {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class PasswordDelete : _PasswordDelete {
        } // class PasswordDelete

    public class _PasswordDump : Goedel.Command.Dispatch ,
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
		public virtual String Site {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Site {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class PasswordDump : _PasswordDump {
        } // class PasswordDump

    public class _ContactSelf : Goedel.Command.Dispatch ,
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





		/// <summary>Field accessor for option [file]</summary>
		public virtual ExistingFile File {
			get => _Data[0] as ExistingFile;
			set => _Data[0]  = value;
			}

		public virtual string _File {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "self",
			Brief =  "Update contact entry for self",
			HandleDelegate =  CommandLineInterpreter.Handle_ContactSelf,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 0,
					Key = "file"
					},
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class ContactSelf : _ContactSelf {
        } // class ContactSelf

    public class _ContactStatic : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "static",
			Brief =  "Create static contact retrieval URI",
			HandleDelegate =  CommandLineInterpreter.Handle_ContactStatic,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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

    public partial class ContactStatic : _ContactStatic {
        } // class ContactStatic

    public class _ContactDynamic : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "dynamic",
			Brief =  "Create dynamic contact retrieval URI",
			HandleDelegate =  CommandLineInterpreter.Handle_ContactDynamic,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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

    public partial class ContactDynamic : _ContactDynamic {
        } // class ContactDynamic

    public class _ContactFetch : Goedel.Command.Dispatch ,
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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "fetch",
			Brief =  "Request contact from URI without presenting own contact",
			HandleDelegate =  CommandLineInterpreter.Handle_ContactFetch,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Uri", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class ContactFetch : _ContactFetch {
        } // class ContactFetch

    public class _ContactExchange : Goedel.Command.Dispatch ,
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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "exchange",
			Brief =  "Request contact from URI presenting own contact",
			HandleDelegate =  CommandLineInterpreter.Handle_ContactExchange,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Uri", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class ContactExchange : _ContactExchange {
        } // class ContactExchange

    public class _ContactExport : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new NewFile (),
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual NewFile File {
			get => _Data[1] as NewFile;
			set => _Data[1]  = value;
			}

		public virtual string _File {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "export",
			Brief =  "Export contact entry from catalog",
			HandleDelegate =  CommandLineInterpreter.Handle_ContactExport,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Identifier", 
					Default = null, // null if null
					Brief = "Contact entry identifier",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 1,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 2,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 3,
					Key = "local"
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

    public partial class ContactExport : _ContactExport {
        } // class ContactExport

    public class _ContactAdd : Goedel.Command.Dispatch ,
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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class ContactAdd : _ContactAdd {
        } // class ContactAdd

    public class _ContactDelete : Goedel.Command.Dispatch ,
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
		public virtual String Identifier {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Identifier {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class ContactDelete : _ContactDelete {
        } // class ContactDelete

    public class _ContactGet : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for option [encrypt]</summary>
		public virtual String Encrypt {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _Encrypt {
			set => _Data[7].Parameter (value);
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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
					},
				new DescribeEntryOption () {
					Identifier = "Encrypt", 
					Default = null, // null if null
					Brief = "Encrypt the contact under the specified key",
					Index = 7,
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
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
			Brief =  "List contact entries",
			HandleDelegate =  CommandLineInterpreter.Handle_ContactDump,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _LocalName {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[5] as Enumeration<EnumReporting>;
			set => _Data[5]  = value;
			}

		public virtual string _EnumReporting {
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 3,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 4,
					Key = "local"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 5,
					Key = "report"
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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _LocalName {
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 2,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 3,
					Key = "local"
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

    public partial class BookmarkDelete : _BookmarkDelete {
        } // class BookmarkDelete

    public class _BookmarkGet : Goedel.Command.Dispatch ,
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
		public virtual String Identifier {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Identifier {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class BookmarkGet : _BookmarkGet {
        } // class BookmarkGet

    public class _BookmarkDump : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
			Brief =  "List bookmark entries",
			HandleDelegate =  CommandLineInterpreter.Handle_BookmarkDump,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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

    public partial class BookmarkDump : _BookmarkDump {
        } // class BookmarkDump

    public class _CalendarImport : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new ExistingFile (),
			new String (),
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
		/// <summary>Field accessor for option [id]</summary>
		public virtual String Identifier {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Identifier {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "import",
			Brief =  "Add calendar entry from file",
			HandleDelegate =  CommandLineInterpreter.Handle_CalendarImport,
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
					Identifier = "Identifier", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 1,
					Key = "id"
					},
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 2,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 3,
					Key = "local"
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

    public partial class CalendarImport : _CalendarImport {
        } // class CalendarImport

    public class _CalendarAdd : Goedel.Command.Dispatch ,
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
		public virtual String Title {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Title {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [id]</summary>
		public virtual String Identifier {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Identifier {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _LocalName {
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
			Brief =  "Add calendar entry",
			HandleDelegate =  CommandLineInterpreter.Handle_CalendarAdd,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Title", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Identifier", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 1,
					Key = "id"
					},
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 2,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 3,
					Key = "local"
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

    public partial class CalendarAdd : _CalendarAdd {
        } // class CalendarAdd

    public class _CalendarGet : Goedel.Command.Dispatch ,
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
		public virtual String Identifier {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Identifier {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class CalendarGet : _CalendarGet {
        } // class CalendarGet

    public class _CalendarDelete : Goedel.Command.Dispatch ,
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
		public virtual String Identifier {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Identifier {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class CalendarDelete : _CalendarDelete {
        } // class CalendarDelete

    public class _CalendarDump : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
			Brief =  "List calendar entries",
			HandleDelegate =  CommandLineInterpreter.Handle_CalendarDump,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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

    public partial class CalendarDump : _CalendarDump {
        } // class CalendarDump

    public class _NetworkImport : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new ExistingFile (),
			new String (),
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
		/// <summary>Field accessor for option [id]</summary>
		public virtual String Identifier {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Identifier {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "import",
			Brief =  "Add calendar entry from file",
			HandleDelegate =  CommandLineInterpreter.Handle_NetworkImport,
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
					Identifier = "Identifier", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 1,
					Key = "id"
					},
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 2,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 3,
					Key = "local"
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

    public partial class NetworkImport : _NetworkImport {
        } // class NetworkImport

    public class _NetworkAdd : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new ExistingFile (),
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Password {
			get => _Data[1] as ExistingFile;
			set => _Data[1]  = value;
			}

		public virtual string _Password {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _LocalName {
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
			Brief =  "Add calendar entry from file",
			HandleDelegate =  CommandLineInterpreter.Handle_NetworkAdd,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Identifier", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Password", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 1,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 2,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 3,
					Key = "local"
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

    public partial class NetworkAdd : _NetworkAdd {
        } // class NetworkAdd

    public class _NetworkGet : Goedel.Command.Dispatch ,
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
		public virtual String Identifier {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Identifier {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class NetworkGet : _NetworkGet {
        } // class NetworkGet

    public class _NetworkDelete : Goedel.Command.Dispatch ,
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
		public virtual String Identifier {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Identifier {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class NetworkDelete : _NetworkDelete {
        } // class NetworkDelete

    public class _NetworkDump : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
			Brief =  "List network entries",
			HandleDelegate =  CommandLineInterpreter.Handle_NetworkDump,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
			new NewFile (),
			new String (),
			new String (),
			new String (),
			new Flag (),
			new String (),
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[8] as String;
			set => _Data[8]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for option [sub]</summary>
		public virtual Flag Subdirectories {
			get => _Data[13] as Flag;
			set => _Data[13]  = value;
			}

		public virtual string _Subdirectories {
			set => _Data[13].Parameter (value);
			}
		/// <summary>Field accessor for option [key]</summary>
		public virtual String SymmetrictKey {
			get => _Data[14] as String;
			set => _Data[14]  = value;
			}

		public virtual string _SymmetrictKey {
			set => _Data[14].Parameter (value);
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
				new DescribeEntryParameter () {
					Identifier = "Output", 
					Default = null, // null if null
					Brief = "Filename for encrypted output.",
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 7,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 8,
					Key = "local"
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
				new DescribeEntryOption () {
					Identifier = "Subdirectories", 
					Default = null, // null if null
					Brief = "Process subdirectories recursively.",
					Index = 13,
					Key = "sub"
					},
				new DescribeEntryOption () {
					Identifier = "SymmetrictKey", 
					Default = null, // null if null
					Brief = "Specifies the value of the master key",
					Index = 14,
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
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new ExistingFile (),
			new NewFile (),
			new String ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		public virtual ExistingFile Input {
			get => _Data[6] as ExistingFile;
			set => _Data[6]  = value;
			}

		public virtual string _Input {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual NewFile Output {
			get => _Data[7] as NewFile;
			set => _Data[7]  = value;
			}

		public virtual string _Output {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [key]</summary>
		public virtual String SymmetrictKey {
			get => _Data[8] as String;
			set => _Data[8]  = value;
			}

		public virtual string _SymmetrictKey {
			set => _Data[8].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "decode",
			Brief =  "Decode a DARE Message.",
			HandleDelegate =  CommandLineInterpreter.Handle_DareDecode,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "Input", 
					Default = null, // null if null
					Brief = "Encrypted File",
					Index = 6,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Output", 
					Default = null, // null if null
					Brief = "Decrypted File",
					Index = 7,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "SymmetrictKey", 
					Default = null, // null if null
					Brief = "Specifies the value of the master key",
					Index = 8,
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
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new ExistingFile (),
			new String ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		public virtual ExistingFile Input {
			get => _Data[6] as ExistingFile;
			set => _Data[6]  = value;
			}

		public virtual string _Input {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [key]</summary>
		public virtual String SymmetricKey {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _SymmetricKey {
			set => _Data[7].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "verify",
			Brief =  "Verify a DARE Message.",
			HandleDelegate =  CommandLineInterpreter.Handle_DareVerify,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "Input", 
					Default = null, // null if null
					Brief = "Encrypted File",
					Index = 6,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "SymmetricKey", 
					Default = null, // null if null
					Brief = "Specifies the value of the master key",
					Index = 7,
					Key = "key"
					}
				}
			};

		}

    public partial class DareVerify : _DareVerify {
        } // class DareVerify

    public class _DareEARL : Goedel.Command.Dispatch ,
							ICryptoOptions,
							ILogOptions,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new ExistingFile (),
			new String (),
			new ExistingFile (),
			new Flag (),
			new String (),
			new ExistingFile (),
			new String (),
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Domain {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Domain {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [dir]</summary>
		public virtual ExistingFile Directory {
			get => _Data[2] as ExistingFile;
			set => _Data[2]  = value;
			}

		public virtual string _Directory {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [new]</summary>
		public virtual Flag New {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _New {
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
		/// <summary>Field accessor for option [log]</summary>
		public virtual ExistingFile Log {
			get => _Data[5] as ExistingFile;
			set => _Data[5]  = value;
			}

		public virtual string _Log {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [admin]</summary>
		public virtual String Admin {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Admin {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[8] as String;
			set => _Data[8]  = value;
			}

		public virtual string _LocalName {
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
					Brief = "File to encode",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Domain", 
					Default = null, // null if null
					Brief = "Domain of the EARL service.",
					Index = 1,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Directory", 
					Default = ".earl", // null if null
					Brief = "Directory to write encrypted output.",
					Index = 2,
					Key = "dir"
					},
				new DescribeEntryOption () {
					Identifier = "New", 
					Default = null, // null if null
					Brief = "Only convert file if not listed in DARE Sequence Log.",
					Index = 3,
					Key = "new"
					},
				new DescribeEntryOption () {
					Identifier = "Algorithms", 
					Default = null, // null if null
					Brief = "List of algorithm specifiers",
					Index = 4,
					Key = "alg"
					},
				new DescribeEntryOption () {
					Identifier = "Log", 
					Default = null, // null if null
					Brief = "Write transaction report to DARE Sequence Log.",
					Index = 5,
					Key = "log"
					},
				new DescribeEntryOption () {
					Identifier = "Admin", 
					Default = null, // null if null
					Brief = "Identifier of administrator authorized to read the log.",
					Index = 6,
					Key = "admin"
					},
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 7,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 8,
					Key = "local"
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
					}
				}
			};

		}

    public partial class DareEARL : _DareEARL {
        } // class DareEARL

    public class _DareSequence : Goedel.Command.Dispatch ,
							IEncodeOptions,
							ICryptoOptions,
							ISequenceOptions,
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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[8] as String;
			set => _Data[8]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[9] as String;
			set => _Data[9]  = value;
			}

		public virtual string _LocalName {
			set => _Data[9].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[10] as Enumeration<EnumReporting>;
			set => _Data[10]  = value;
			}

		public virtual string _EnumReporting {
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual NewFile Sequence {
			get => _Data[14] as NewFile;
			set => _Data[14]  = value;
			}

		public virtual string _Sequence {
			set => _Data[14].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "sequence",
			Brief =  "Create a new DARE Sequence",
			HandleDelegate =  CommandLineInterpreter.Handle_DareSequence,
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
					Brief = "The sequence type, plain/tree/digest/chain/tree",
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 8,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 9,
					Key = "local"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 10,
					Key = "report"
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
				new DescribeEntryParameter () {
					Identifier = "Sequence", 
					Default = null, // null if null
					Brief = "New sequence",
					Index = 14,
					Key = ""
					}
				}
			};

		}

    public partial class DareSequence : _DareSequence {
        } // class DareSequence

    public class _DareArchive : Goedel.Command.Dispatch ,
							IEncodeOptions,
							ICryptoOptions,
							IAccountOptions,
							IReporting,
							ISequenceOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new String (),
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
			new NewFile (),
			new Flag ()			} ;





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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for option [type]</summary>
		public virtual String Type {
			get => _Data[11] as String;
			set => _Data[11]  = value;
			}

		public virtual string _Type {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for parameter [auth]</summary>
		public virtual Enumeration<EnumAuthentication> EnumAuthentication {
			get => _Data[12] as Enumeration<EnumAuthentication>;
			set => _Data[12]  = value;
			}

		public virtual string _EnumAuthentication {
			set => _Data[12].Parameter (value);
			}
		/// <summary>Field accessor for parameter [use]</summary>
		public virtual Enumeration<EnumUse> EnumUse {
			get => _Data[13] as Enumeration<EnumUse>;
			set => _Data[13]  = value;
			}

		public virtual string _EnumUse {
			set => _Data[13].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Input {
			get => _Data[14] as ExistingFile;
			set => _Data[14]  = value;
			}

		public virtual string _Input {
			set => _Data[14].Parameter (value);
			}
		/// <summary>Field accessor for option [out]</summary>
		public virtual NewFile Sequence {
			get => _Data[15] as NewFile;
			set => _Data[15]  = value;
			}

		public virtual string _Sequence {
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "archive",
			Brief =  "Create a new DARE archive and add the specified files",
			HandleDelegate =  CommandLineInterpreter.Handle_DareArchive,
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 5,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 6,
					Key = "local"
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
					Identifier = "Type", 
					Default = null, // null if null
					Brief = "The sequence type, plain/tree/digest/chain/tree",
					Index = 11,
					Key = "type"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumAuthentication", 
					Default = null, // null if null
					Brief = "Authentication and indexing",
					Index = 12,
					Key = "auth"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumUse", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 13,
					Key = "use"
					},
				new DescribeEntryParameter () {
					Identifier = "Input", 
					Default = null, // null if null
					Brief = "Directory containing files to create archive from",
					Index = 14,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Sequence", 
					Default = null, // null if null
					Brief = "New sequence",
					Index = 15,
					Key = "out"
					},
				new DescribeEntryOption () {
					Identifier = "Index", 
					Default = "true", // null if null
					Brief = "Append index to the archive",
					Index = 16,
					Key = "index"
					}
				}
			};

		}

    public partial class DareArchive : _DareArchive {
        } // class DareArchive

    public class _DareLog : Goedel.Command.Dispatch ,
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
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Sequence {
			get => _Data[11] as ExistingFile;
			set => _Data[11]  = value;
			}

		public virtual string _Sequence {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual NewFile Entry {
			get => _Data[12] as NewFile;
			set => _Data[12]  = value;
			}

		public virtual string _Entry {
			set => _Data[12].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "log",
			Brief =  "Append the specified string to the sequence.",
			HandleDelegate =  CommandLineInterpreter.Handle_DareLog,
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 5,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 6,
					Key = "local"
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
				new DescribeEntryParameter () {
					Identifier = "Sequence", 
					Default = null, // null if null
					Brief = "Sequence to append to",
					Index = 11,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Entry", 
					Default = null, // null if null
					Brief = "Text to append",
					Index = 12,
					Key = ""
					}
				}
			};

		}

    public partial class DareLog : _DareLog {
        } // class DareLog

    public class _DareAppend : Goedel.Command.Dispatch ,
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
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new ExistingFile (),
			new NewFile (),
			new String (),
			new Flag ()			} ;





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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Sequence {
			get => _Data[11] as ExistingFile;
			set => _Data[11]  = value;
			}

		public virtual string _Sequence {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual NewFile File {
			get => _Data[12] as NewFile;
			set => _Data[12]  = value;
			}

		public virtual string _File {
			set => _Data[12].Parameter (value);
			}
		/// <summary>Field accessor for option [key]</summary>
		public virtual String Key {
			get => _Data[13] as String;
			set => _Data[13]  = value;
			}

		public virtual string _Key {
			set => _Data[13].Parameter (value);
			}
		/// <summary>Field accessor for option [index]</summary>
		public virtual Flag Index {
			get => _Data[14] as Flag;
			set => _Data[14]  = value;
			}

		public virtual string _Index {
			set => _Data[14].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "append",
			Brief =  "Append the specified file as an entry to the specified sequence.",
			HandleDelegate =  CommandLineInterpreter.Handle_DareAppend,
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 5,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 6,
					Key = "local"
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
				new DescribeEntryParameter () {
					Identifier = "Sequence", 
					Default = null, // null if null
					Brief = "Sequence to append to",
					Index = 11,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "File to append",
					Index = 12,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Key", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 13,
					Key = "key"
					},
				new DescribeEntryOption () {
					Identifier = "Index", 
					Default = "false", // null if null
					Brief = "Append index to the archive",
					Index = 14,
					Key = "index"
					}
				}
			};

		}

    public partial class DareAppend : _DareAppend {
        } // class DareAppend

    public class _DareDelete : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new ExistingFile (),
			new String (),
			new String ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Sequence {
			get => _Data[0] as ExistingFile;
			set => _Data[0]  = value;
			}

		public virtual string _Sequence {
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
			HandleDelegate =  CommandLineInterpreter.Handle_DareDelete,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Sequence", 
					Default = null, // null if null
					Brief = "Sequence to append to",
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

    public partial class DareDelete : _DareDelete {
        } // class DareDelete

    public class _DareDir : Goedel.Command.Dispatch ,
							IReporting,
							IAccountOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _LocalName {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Sequence {
			get => _Data[6] as ExistingFile;
			set => _Data[6]  = value;
			}

		public virtual string _Sequence {
			set => _Data[6].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "dir",
			Brief =  "Compile a catalog for the specified sequence.",
			HandleDelegate =  CommandLineInterpreter.Handle_DareDir,
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 4,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 5,
					Key = "local"
					},
				new DescribeEntryParameter () {
					Identifier = "Sequence", 
					Default = null, // null if null
					Brief = "Sequence to be cataloged",
					Index = 6,
					Key = ""
					}
				}
			};

		}

    public partial class DareDir : _DareDir {
        } // class DareDir

    public class _DareList : Goedel.Command.Dispatch ,
							IReporting,
							IAccountOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String (),
			new ExistingFile (),
			new NewFile ()			} ;





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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _LocalName {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Sequence {
			get => _Data[6] as ExistingFile;
			set => _Data[6]  = value;
			}

		public virtual string _Sequence {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual NewFile Output {
			get => _Data[7] as NewFile;
			set => _Data[7]  = value;
			}

		public virtual string _Output {
			set => _Data[7].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "list",
			Brief =  "Compile a catalog for the specified sequence.",
			HandleDelegate =  CommandLineInterpreter.Handle_DareList,
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 4,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 5,
					Key = "local"
					},
				new DescribeEntryParameter () {
					Identifier = "Sequence", 
					Default = null, // null if null
					Brief = "Sequence to be cataloged",
					Index = 6,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Output", 
					Default = null, // null if null
					Brief = "List output",
					Index = 7,
					Key = ""
					}
				}
			};

		}

    public partial class DareList : _DareList {
        } // class DareList

    public class _DareIndex : Goedel.Command.Dispatch ,
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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Sequence {
			get => _Data[11] as ExistingFile;
			set => _Data[11]  = value;
			}

		public virtual string _Sequence {
			set => _Data[11].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "index",
			Brief =  "Compile an index for the specified sequence and append to the end.",
			HandleDelegate =  CommandLineInterpreter.Handle_DareIndex,
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 5,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 6,
					Key = "local"
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
				new DescribeEntryParameter () {
					Identifier = "Sequence", 
					Default = null, // null if null
					Brief = "Sequence to be indexed",
					Index = 11,
					Key = ""
					}
				}
			};

		}

    public partial class DareIndex : _DareIndex {
        } // class DareIndex

    public class _DareExtract : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new ExistingFile (),
			new NewFile (),
			new Integer (),
			new String (),
			new String (),
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Sequence {
			get => _Data[0] as ExistingFile;
			set => _Data[0]  = value;
			}

		public virtual string _Sequence {
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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _LocalName {
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
			Identifier = "extract",
			Brief =  "Extract the specified record from the sequence",
			HandleDelegate =  CommandLineInterpreter.Handle_DareExtract,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Sequence", 
					Default = null, // null if null
					Brief = "Sequence to read",
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 5,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 6,
					Key = "local"
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

    public partial class DareExtract : _DareExtract {
        } // class DareExtract

    public class _DarePurge : Goedel.Command.Dispatch ,
							IEncodeOptions,
							ICryptoOptions,
							ISequenceOptions,
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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[10] as String;
			set => _Data[10]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[10].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[11] as String;
			set => _Data[11]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for option [decrypt]</summary>
		public virtual Flag Decrypt {
			get => _Data[16] as Flag;
			set => _Data[16]  = value;
			}

		public virtual string _Decrypt {
			set => _Data[16].Parameter (value);
			}
		/// <summary>Field accessor for option [index]</summary>
		public virtual Flag Index {
			get => _Data[17] as Flag;
			set => _Data[17]  = value;
			}

		public virtual string _Index {
			set => _Data[17].Parameter (value);
			}
		/// <summary>Field accessor for option [purge]</summary>
		public virtual Flag Purge {
			get => _Data[18] as Flag;
			set => _Data[18]  = value;
			}

		public virtual string _Purge {
			set => _Data[18].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "purge",
			Brief =  "Copy sequence contents to create a new sequence removing deleted elements",
			HandleDelegate =  CommandLineInterpreter.Handle_DarePurge,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Input", 
					Default = null, // null if null
					Brief = "Sequence to read",
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
					Brief = "The sequence type, plain/tree/digest/chain/tree",
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 10,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 11,
					Key = "local"
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
					},
				new DescribeEntryOption () {
					Identifier = "Decrypt", 
					Default = "false", // null if null
					Brief = "Decrypt contents",
					Index = 16,
					Key = "decrypt"
					},
				new DescribeEntryOption () {
					Identifier = "Index", 
					Default = "true", // null if null
					Brief = "Append an index record to the end",
					Index = 17,
					Key = "index"
					},
				new DescribeEntryOption () {
					Identifier = "Purge", 
					Default = "true", // null if null
					Brief = "Purge unused data etc.",
					Index = 18,
					Key = "purge"
					}
				}
			};

		}

    public partial class DarePurge : _DarePurge {
        } // class DarePurge

    public class _MailAdd : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							IMailOptions,
							ICryptoOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for option [openpgp]</summary>
		public virtual Flag OpenPGP {
			get => _Data[7] as Flag;
			set => _Data[7]  = value;
			}

		public virtual string _OpenPGP {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [smime]</summary>
		public virtual Flag SMIME {
			get => _Data[8] as Flag;
			set => _Data[8]  = value;
			}

		public virtual string _SMIME {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for option [configuration]</summary>
		public virtual ExistingFile Configuration {
			get => _Data[9] as ExistingFile;
			set => _Data[9]  = value;
			}

		public virtual string _Configuration {
			set => _Data[9].Parameter (value);
			}
		/// <summary>Field accessor for option [ca]</summary>
		public virtual String CA {
			get => _Data[10] as String;
			set => _Data[10]  = value;
			}

		public virtual string _CA {
			set => _Data[10].Parameter (value);
			}
		/// <summary>Field accessor for option [inbound]</summary>
		public virtual String Inbound {
			get => _Data[11] as String;
			set => _Data[11]  = value;
			}

		public virtual string _Inbound {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for option [outbound]</summary>
		public virtual String Outbound {
			get => _Data[12] as String;
			set => _Data[12]  = value;
			}

		public virtual string _Outbound {
			set => _Data[12].Parameter (value);
			}
		/// <summary>Field accessor for option [alg]</summary>
		public virtual String Algorithms {
			get => _Data[13] as String;
			set => _Data[13]  = value;
			}

		public virtual string _Algorithms {
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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
					},
				new DescribeEntryOption () {
					Identifier = "OpenPGP", 
					Default = null, // null if null
					Brief = "Create encryption and signature keys for OpenPGP",
					Index = 7,
					Key = "openpgp"
					},
				new DescribeEntryOption () {
					Identifier = "SMIME", 
					Default = null, // null if null
					Brief = "Create encryption and signature keys for S/MIME",
					Index = 8,
					Key = "smime"
					},
				new DescribeEntryOption () {
					Identifier = "Configuration", 
					Default = null, // null if null
					Brief = "Configuration file describing network settings",
					Index = 9,
					Key = "configuration"
					},
				new DescribeEntryOption () {
					Identifier = "CA", 
					Default = null, // null if null
					Brief = "Certificate Authority to request certificate from",
					Index = 10,
					Key = "ca"
					},
				new DescribeEntryOption () {
					Identifier = "Inbound", 
					Default = null, // null if null
					Brief = "inbound service configuration",
					Index = 11,
					Key = "inbound"
					},
				new DescribeEntryOption () {
					Identifier = "Outbound", 
					Default = null, // null if null
					Brief = "outbound service configuration",
					Index = 12,
					Key = "outbound"
					},
				new DescribeEntryOption () {
					Identifier = "Algorithms", 
					Default = null, // null if null
					Brief = "List of algorithm specifiers",
					Index = 13,
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
		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _LocalName {
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 1,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 2,
					Key = "local"
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

    public partial class MailUpdate : _MailUpdate {
        } // class MailUpdate

    public class _SMIMEPrivate : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							IPrivateKeyOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String (),
			new NewFile (),
			new String ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for option [format]</summary>
		public virtual String Format {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Format {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [password]</summary>
		public virtual String Password {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _Password {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [file]</summary>
		public virtual NewFile File {
			get => _Data[8] as NewFile;
			set => _Data[8]  = value;
			}

		public virtual string _File {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Address {
			get => _Data[9] as String;
			set => _Data[9]  = value;
			}

		public virtual string _Address {
			set => _Data[9].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "private",
			Brief =  "Extract the private key for the specified account",
			HandleDelegate =  CommandLineInterpreter.Handle_SMIMEPrivate,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "Format", 
					Default = null, // null if null
					Brief = "File format",
					Index = 6,
					Key = "format"
					},
				new DescribeEntryOption () {
					Identifier = "Password", 
					Default = null, // null if null
					Brief = "Password to encrypt private key",
					Index = 7,
					Key = "password"
					},
				new DescribeEntryOption () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "Output file",
					Index = 8,
					Key = "file"
					},
				new DescribeEntryParameter () {
					Identifier = "Address", 
					Default = null, // null if null
					Brief = "Mail account to update",
					Index = 9,
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new NewFile (),
			new String ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for option [format]</summary>
		public virtual String Format {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Format {
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
			Identifier = "public",
			Brief =  "Extract the public key/certificate for the specified account",
			HandleDelegate =  CommandLineInterpreter.Handle_SMIMEPublic,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "Format", 
					Default = null, // null if null
					Brief = "File format",
					Index = 6,
					Key = "format"
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
					Brief = "Mail account identifier",
					Index = 8,
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String (),
			new NewFile (),
			new String ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for option [format]</summary>
		public virtual String Format {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Format {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [password]</summary>
		public virtual String Password {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _Password {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [file]</summary>
		public virtual NewFile File {
			get => _Data[8] as NewFile;
			set => _Data[8]  = value;
			}

		public virtual string _File {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Address {
			get => _Data[9] as String;
			set => _Data[9]  = value;
			}

		public virtual string _Address {
			set => _Data[9].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "private",
			Brief =  "Extract the private key for the specified account",
			HandleDelegate =  CommandLineInterpreter.Handle_PGPPrivate,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "Format", 
					Default = null, // null if null
					Brief = "File format",
					Index = 6,
					Key = "format"
					},
				new DescribeEntryOption () {
					Identifier = "Password", 
					Default = null, // null if null
					Brief = "Password to encrypt private key",
					Index = 7,
					Key = "password"
					},
				new DescribeEntryOption () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "Output file",
					Index = 8,
					Key = "file"
					},
				new DescribeEntryParameter () {
					Identifier = "Address", 
					Default = null, // null if null
					Brief = "Mail account to update",
					Index = 9,
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new NewFile (),
			new String ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for option [format]</summary>
		public virtual String Format {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Format {
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
			Identifier = "public",
			Brief =  "Extract the public key/certificate for the specified account",
			HandleDelegate =  CommandLineInterpreter.Handle_PGPPublic,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "Format", 
					Default = null, // null if null
					Brief = "File format",
					Index = 6,
					Key = "format"
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
					Brief = "Mail account identifier",
					Index = 8,
					Key = ""
					}
				}
			};

		}

    public partial class PGPPublic : _PGPPublic {
        } // class PGPPublic

    public class _MailList : Goedel.Command.Dispatch ,
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





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		public virtual String Address {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Address {
			set => _Data[6].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "list",
			Brief =  "List mail account information",
			HandleDelegate =  CommandLineInterpreter.Handle_MailList,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "Address", 
					Default = null, // null if null
					Brief = "Mail account identifier",
					Index = 6,
					Key = ""
					}
				}
			};

		}

    public partial class MailList : _MailList {
        } // class MailList

    public class _SSHCreate : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							ISSHOptions,
							ICryptoOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String (),
			new String ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for option [application]</summary>
		public virtual String Application {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Application {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [alg]</summary>
		public virtual String Algorithms {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _Algorithms {
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "Application", 
					Default = null, // null if null
					Brief = "The application format",
					Index = 6,
					Key = "application"
					},
				new DescribeEntryOption () {
					Identifier = "Algorithms", 
					Default = null, // null if null
					Brief = "List of algorithm specifiers",
					Index = 7,
					Key = "alg"
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

    public class _SSHPrivate : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							IPrivateKeyOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new String (),
			new NewFile ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for option [format]</summary>
		public virtual String Format {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Format {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [password]</summary>
		public virtual String Password {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _Password {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [file]</summary>
		public virtual NewFile File {
			get => _Data[8] as NewFile;
			set => _Data[8]  = value;
			}

		public virtual string _File {
			set => _Data[8].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "private",
			Brief =  "Extract the private key for this device",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHPrivate,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "Format", 
					Default = null, // null if null
					Brief = "File format",
					Index = 6,
					Key = "format"
					},
				new DescribeEntryOption () {
					Identifier = "Password", 
					Default = null, // null if null
					Brief = "Password to encrypt private key",
					Index = 7,
					Key = "password"
					},
				new DescribeEntryOption () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "Output file",
					Index = 8,
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new NewFile ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for option [format]</summary>
		public virtual String Format {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Format {
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
			Identifier = "public",
			Brief =  "Extract the public key for this device",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHPublic,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "Format", 
					Default = null, // null if null
					Brief = "File format",
					Index = 6,
					Key = "format"
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

    public partial class SSHPublic : _SSHPublic {
        } // class SSHPublic

    public class _SSHMergeKnown : Goedel.Command.Dispatch ,
							IAccountOptions,
							IReporting,
							ISSHOptions {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new ExistingFile ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for option [application]</summary>
		public virtual String Application {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Application {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile File {
			get => _Data[7] as ExistingFile;
			set => _Data[7]  = value;
			}

		public virtual string _File {
			set => _Data[7].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "host",
			Brief =  "Add one or more hosts to the known_hosts file",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHMergeKnown,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "Application", 
					Default = null, // null if null
					Brief = "The application format",
					Index = 6,
					Key = "application"
					},
				new DescribeEntryParameter () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 7,
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
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for option [application]</summary>
		public virtual String Application {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Application {
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
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "Application", 
					Default = null, // null if null
					Brief = "The application format",
					Index = 6,
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
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
			new ExistingFile ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for option [application]</summary>
		public virtual String Application {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Application {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile File {
			get => _Data[7] as ExistingFile;
			set => _Data[7]  = value;
			}

		public virtual string _File {
			set => _Data[7].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "client",
			Brief =  "Add one or more keys to the authorized_keys file",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHAddClient,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "Application", 
					Default = null, // null if null
					Brief = "The application format",
					Index = 6,
					Key = "application"
					},
				new DescribeEntryParameter () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 7,
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
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for option [application]</summary>
		public virtual String Application {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Application {
			set => _Data[6].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "host",
			Brief =  "List the known SSH sites (aka known hosts)",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHKnown,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "Application", 
					Default = null, // null if null
					Brief = "The application format",
					Index = 6,
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
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String ()			} ;





		/// <summary>Field accessor for option [account]</summary>
		public virtual String AccountAddress {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountAddress {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [local]</summary>
		public virtual String LocalName {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _LocalName {
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
		/// <summary>Field accessor for option [application]</summary>
		public virtual String Application {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Application {
			set => _Data[6].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "client",
			Brief =  "List the authorized device keys (aka authorized_keys)",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHAuth,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountAddress", 
					Default = null, // null if null
					Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
					Index = 0,
					Key = "account"
					},
				new DescribeEntryOption () {
					Identifier = "LocalName", 
					Default = null, // null if null
					Brief = "Local name for account (e.g. personal)",
					Index = 1,
					Key = "local"
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
					Identifier = "Application", 
					Default = null, // null if null
					Brief = "The application format",
					Index = 6,
					Key = "application"
					}
				}
			};

		}

    public partial class SSHAuth : _SSHAuth {
        } // class SSHAuth


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
        public Enumeration(DescribeEntryEnumerate description) : base(description){
            }
        } // _Enumeration<T>

	// The stub class just contains routines that echo their arguments and
	// write 'not yet implemented'

	// Eventually there will be a compiler option to suppress the debugging
	// to eliminate the redundant code
    public class _Shell : global::Goedel.Command.DispatchShell {

		public virtual ShellResult AccountHello ( AccountHello Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult AccountCreate ( AccountCreate Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult AccountDelete ( AccountDelete Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult AccountStatus ( AccountStatus Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult AccountSync ( AccountSync Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult AccountGetPIN ( AccountGetPIN Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult AccountPublish ( AccountPublish Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult AccountConnect ( AccountConnect Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult AccountEscrow ( AccountEscrow Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult AccountPurge ( AccountPurge Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult AccountRecover ( AccountRecover Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult AccountList ( AccountList Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult AccountGet ( AccountGet Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult AccountExport ( AccountExport Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult AccountImport ( AccountImport Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DeviceRequestConnect ( DeviceRequestConnect Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DevicePending ( DevicePending Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DeviceComplete ( DeviceComplete Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DeviceAccept ( DeviceAccept Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DeviceReject ( DeviceReject Options) {
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

		public virtual ShellResult DeviceAuthorize ( DeviceAuthorize Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DeviceJoin ( DeviceJoin Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DeviceInstall ( DeviceInstall Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DevicePreconfigure ( DevicePreconfigure Options) {
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

		public virtual ShellResult GroupGet ( GroupGet Options) {
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

		public virtual ShellResult ContactSelf ( ContactSelf Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ContactStatic ( ContactStatic Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ContactDynamic ( ContactDynamic Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ContactFetch ( ContactFetch Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ContactExchange ( ContactExchange Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult ContactExport ( ContactExport Options) {
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

		public virtual ShellResult CalendarImport ( CalendarImport Options) {
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

		public virtual ShellResult NetworkImport ( NetworkImport Options) {
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

		public virtual ShellResult DareSequence ( DareSequence Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DareArchive ( DareArchive Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DareLog ( DareLog Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DareAppend ( DareAppend Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DareDelete ( DareDelete Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DareDir ( DareDir Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DareList ( DareList Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DareIndex ( DareIndex Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DareExtract ( DareExtract Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DarePurge ( DarePurge Options) {
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

		public virtual ShellResult MailList ( MailList Options) {
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


        } // class _Shell

    public partial class Shell : _Shell {
        } // class Shell

    } // namespace Shell


