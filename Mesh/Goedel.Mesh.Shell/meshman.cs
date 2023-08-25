
//  This file was automatically generated at 8/25/2023 4:11:44 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  commandparse version 3.0.0.879
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.22621.0
//  
//  
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Command;
using Goedel.Utilities;
#pragma warning disable IDE0079
#pragma warning disable IDE1006
#pragma warning disable CS1591

namespace Goedel.Mesh.Shell;

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
    public static SortedDictionary<string, DescribeCommand> Entries { get; set; }
	/// <summary>The default command.</summary>
	public static DescribeCommandEntry DefaultCommand { get; set; }
	/// <summary>Description of the comman</summary>
	public static string Description { get; set; } = "<Not specified>";

	static readonly char UnixFlag = '-';
	static readonly char WindowsFlag = '/';

    /// <summary>
    /// Default help dispatch
    /// </summary>
    /// <param name="Dispatch">The command description.</param>
    /// <param name="args">The set of arguments.</param>
    /// <param name="index">The first unparsed argument.</param>
    public static void Help (DispatchShell Dispatch, string[] args, int index) =>
        Brief(Description, DefaultCommand, Entries);

    public readonly static DescribeCommandEntry DescribeHelp = new () {
        Identifier = "help",
        HandleDelegate = Help,
        Entries = new () { }
        };

	public readonly static DescribeEntryEnumerate DescribeEnumAuthentication = new  () {
        Identifier = "auth",
        Brief = "Authentication and indexing",
        Entries = new () { 
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
	public readonly static DescribeEntryEnumerate DescribeEnumUse = new  () {
        Identifier = "use",
        Brief = "<Unspecified>",
        Entries = new () { 
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



	public static DescribeCommandSet DescribeCommandSet_Account => new  () {
        Identifier = "account",
		Brief = "Account creation and management commands.",
		Entries = new  () {
			{"hello", _AccountHello._DescribeCommand },
			{"create", _AccountCreate._DescribeCommand },
			{"delete", _AccountDelete._DescribeCommand },
			{"status", _AccountStatus._DescribeCommand },
			{"sync", _AccountSync._DescribeCommand },
			{"info", _AccountInfo._DescribeCommand },
			{"pin", _AccountGetPIN._DescribeCommand },
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

	public static DescribeCommandSet DescribeCommandSet_Connect => new  () {
        Identifier = "device",
		Brief = "Device management commands.",
		Entries = new  () {
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

	public static DescribeCommandSet DescribeCommandSet_Message => new  () {
        Identifier = "message",
		Brief = "Contact and confirmation message options",
		Entries = new  () {
			{"confirm", _MessageConfirm._DescribeCommand },
			{"pending", _MessagePending._DescribeCommand },
			{"status", _MessageStatus._DescribeCommand },
			{"accept", _MessageAccept._DescribeCommand },
			{"reject", _MessageReject._DescribeCommand },
			{"block", _MessageBlock._DescribeCommand }
			} // End Entries
		};

	public static DescribeCommandSet DescribeCommandSet_Group => new  () {
        Identifier = "group",
		Brief = "Group management commands",
		Entries = new  () {
			{"create", _GroupCreate._DescribeCommand },
			{"add", _GroupAdd._DescribeCommand },
			{"get", _GroupGet._DescribeCommand },
			{"delete", _GroupDelete._DescribeCommand },
			{"list", _GroupList._DescribeCommand }
			} // End Entries
		};

	public static DescribeCommandSet DescribeCommandSet_Password => new  () {
        Identifier = "password",
		Brief = "Manage password catalogs connected to an account",
		Entries = new  () {
			{"add", _PasswordAdd._DescribeCommand },
			{"get", _PasswordGet._DescribeCommand },
			{"delete", _PasswordDelete._DescribeCommand },
			{"list", _PasswordDump._DescribeCommand }
			} // End Entries
		};

	public static DescribeCommandSet DescribeCommandSet_Contact => new  () {
        Identifier = "contact",
		Brief = "Manage contact catalogs connected to an account",
		Entries = new  () {
			{"add", _ContactAdd._DescribeCommand },
			{"static", _ContactStatic._DescribeCommand },
			{"dynamic", _ContactDynamic._DescribeCommand },
			{"fetch", _ContactFetch._DescribeCommand },
			{"exchange", _ContactExchange._DescribeCommand },
			{"request", _MessageContact._DescribeCommand },
			{"import", _ContactImport._DescribeCommand },
			{"export", _ContactExport._DescribeCommand },
			{"delete", _ContactDelete._DescribeCommand },
			{"get", _ContactGet._DescribeCommand },
			{"list", _ContactDump._DescribeCommand }
			} // End Entries
		};

	public static DescribeCommandSet DescribeCommandSet_Bookmark => new  () {
        Identifier = "bookmark",
		Brief = "Manage bookmark catalogs connected to an account",
		Entries = new  () {
			{"import", _BookmarkImport._DescribeCommand },
			{"add", _BookmarkAdd._DescribeCommand },
			{"delete", _BookmarkDelete._DescribeCommand },
			{"get", _BookmarkGet._DescribeCommand },
			{"list", _BookmarkDump._DescribeCommand }
			} // End Entries
		};

	public static DescribeCommandSet DescribeCommandSet_Calendar => new  () {
        Identifier = "calendar",
		Brief = "Manage calendar catalogs connected to an account",
		Entries = new  () {
			{"import", _CalendarImport._DescribeCommand },
			{"add", _CalendarAdd._DescribeCommand },
			{"get", _CalendarGet._DescribeCommand },
			{"delete", _CalendarDelete._DescribeCommand },
			{"list", _CalendarDump._DescribeCommand }
			} // End Entries
		};

	public static DescribeCommandSet DescribeCommandSet_Network => new  () {
        Identifier = "network",
		Brief = "Manage network profile settings",
		Entries = new  () {
			{"import", _NetworkImport._DescribeCommand },
			{"add", _NetworkAdd._DescribeCommand },
			{"get", _NetworkGet._DescribeCommand },
			{"delete", _NetworkDelete._DescribeCommand },
			{"list", _NetworkList._DescribeCommand }
			} // End Entries
		};

	public static DescribeCommandSet DescribeCommandSet_Key => new  () {
        Identifier = "key",
		Brief = "Key operations.",
		Entries = new  () {
			{"nonce", _KeyNonce._DescribeCommand },
			{"secret", _KeySecret._DescribeCommand },
			{"earl", _KeyEarl._DescribeCommand },
			{"share", _KeyShare._DescribeCommand },
			{"recover", _KeyRecover._DescribeCommand }
			} // End Entries
		};

	public static DescribeCommandSet DescribeCommandSet_Hash => new  () {
        Identifier = "hash",
		Brief = "Content Digest and Message Authentication Code operations on files",
		Entries = new  () {
			{"udf", _HashUDF._DescribeCommand },
			{"digest", _HashDigest._DescribeCommand },
			{"mac", _HashMac._DescribeCommand }
			} // End Entries
		};

	public static DescribeCommandSet DescribeCommandSet_Dare => new  () {
        Identifier = "dare",
		Brief = "DARE Message encryption and decryption commands",
		Entries = new  () {
			{"encode", _DareEncode._DescribeCommand },
			{"decode", _DareDecode._DescribeCommand },
			{"verify", _DareVerify._DescribeCommand },
			{"earl", _DareEARL._DescribeCommand }
			} // End Entries
		};

	public static DescribeCommandSet DescribeCommandSet_Archive => new  () {
        Identifier = "archive",
		Brief = "DARE archive commands",
		Entries = new  () {
			{"create", _ArchiveCreate._DescribeCommand },
			{"append", _ArchiveAppend._DescribeCommand },
			{"delete", _ArchiveDelete._DescribeCommand },
			{"index", _ArchiveIndex._DescribeCommand },
			{"dir", _ArchiveDir._DescribeCommand },
			{"extract", _ArchiveExtract._DescribeCommand },
			{"copy", _ArchiveCopy._DescribeCommand }
			} // End Entries
		};

	public static DescribeCommandSet DescribeCommandSet_Log => new  () {
        Identifier = "log",
		Brief = "DARE log commands",
		Entries = new  () {
			{"create", _LogCreate._DescribeCommand },
			{"append", _LogAppend._DescribeCommand },
			{"list", _LogList._DescribeCommand }
			} // End Entries
		};

	public static DescribeCommandSet DescribeCommandSet_Mail => new  () {
        Identifier = "mail",
		Brief = "Manage mail profiles connected to a personal profile",
		Entries = new  () {
			{"add", _MailAdd._DescribeCommand },
			{"get", _MailGet._DescribeCommand },
			{"list", _MailList._DescribeCommand },
			{"import", _MailImport._DescribeCommand },
			{"delete", _MailDelete._DescribeCommand },
			{"smime", DescribeCommandSet_SMIME},
			{"openpgp", DescribeCommandSet_PGP}
			} // End Entries
		};

	public static DescribeCommandSet DescribeCommandSet_SMIME => new  () {
        Identifier = "smime",
		Brief = "Commands for managing S/MIME entries",
		Entries = new  () {
			{"sign", _SmimeSign._DescribeCommand },
			{"encrypt", _SmimeEncrypt._DescribeCommand }
			} // End Entries
		};

	public static DescribeCommandSet DescribeCommandSet_PGP => new  () {
        Identifier = "openpgp",
		Brief = "Commands for managing PGP entries",
		Entries = new  () {
			{"sign", _OpenpgpSign._DescribeCommand },
			{"encrypt", _OpenpgpEncrypt._DescribeCommand }
			} // End Entries
		};

	public static DescribeCommandSet DescribeCommandSet_SSH => new  () {
        Identifier = "ssh",
		Brief = "Manage SSH profiles connected to a personal profile",
		Entries = new  () {
			{"create", _SSHCreate._DescribeCommand },
			{"get", _SSHGet._DescribeCommand },
			{"list", _SSHList._DescribeCommand },
			{"client", _SSHClient._DescribeCommand },
			{"host", _SSHHost._DescribeCommand },
			{"known", _SSHKnown._DescribeCommand },
			{"delete", _SSHDelete._DescribeCommand }
			} // End Entries
		};

	public static DescribeCommandSet DescribeCommandSet_Callsign => new  () {
        Identifier = "callsign",
		Brief = "<Unspecified>",
		Entries = new  () {
			{"register", _CallsignRegister._DescribeCommand },
			{"bind", _CallsignBind._DescribeCommand },
			{"resolve", _CallsignResolve._DescribeCommand },
			{"transfer", _CallsignTransfer._DescribeCommand },
			{"status", _CallsignStatus._DescribeCommand },
			{"list", _CallsignList._DescribeCommand }
			} // End Entries
		};

	public static DescribeCommandSet DescribeCommandSet_Wallet => new  () {
        Identifier = "wallet",
		Brief = "<Unspecified>",
		Entries = new  () {
			{"invoice", _WalletInvoice._DescribeCommand },
			{"transfer", _WalletTransfer._DescribeCommand },
			{"accept", _WalletAccept._DescribeCommand },
			{"reject", _WalletReject._DescribeCommand },
			{"redeem", _WalletRedeem._DescribeCommand },
			{"list", _WalletList._DescribeCommand },
			{"delete", _WalletDelete._DescribeCommand },
			{"get", _WalletkGet._DescribeCommand }
			} // End Entries
		};

	public static DescribeCommandSet DescribeCommandSet_Carnet => new  () {
        Identifier = "carnet",
		Brief = "<Unspecified>",
		Entries = new  () {
			{"mint", _CarnetMint._DescribeCommand },
			{"status", _CarnetStatus._DescribeCommand }
			} // End Entries
		};

	public static DescribeCommandSet DescribeCommandSet_Chat => new  () {
        Identifier = "chat",
		Brief = "<Unspecified>",
		Entries = new  () {
			{"message", _ChatMessage._DescribeCommand },
			{"listen", _ChatListen._DescribeCommand },
			{"poll", _ChatPoll._DescribeCommand }
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

		Entries = new   () {
			{"about", _About._DescribeCommand },
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
			{"archive", DescribeCommandSet_Archive},
			{"log", DescribeCommandSet_Log},
			{"mail", DescribeCommandSet_Mail},
			{"ssh", DescribeCommandSet_SSH},
			{"callsign", DescribeCommandSet_Callsign},
			{"wallet", DescribeCommandSet_Wallet},
			{"carnet", DescribeCommandSet_Carnet},
			{"chat", DescribeCommandSet_Chat},
			{"help", DescribeHelp }
			}; // End Entries



        }



    public void MainMethod(string[] Args) {
		Shell Dispatch = new ();

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




	public static void Handle_About (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		About		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.About (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_AccountHello (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		AccountHello		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.AccountHello (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_AccountCreate (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		AccountCreate		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.AccountCreate (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_AccountDelete (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		AccountDelete		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.AccountDelete (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_AccountStatus (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		AccountStatus		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.AccountStatus (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_AccountSync (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		AccountSync		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.AccountSync (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_AccountInfo (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		AccountInfo		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.AccountInfo (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_AccountGetPIN (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		AccountGetPIN		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.AccountGetPIN (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_AccountConnect (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		AccountConnect		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.AccountConnect (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_AccountEscrow (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		AccountEscrow		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.AccountEscrow (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_AccountPurge (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		AccountPurge		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.AccountPurge (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_AccountRecover (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		AccountRecover		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.AccountRecover (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_AccountList (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		AccountList		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.AccountList (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_AccountGet (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		AccountGet		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.AccountGet (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_AccountExport (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		AccountExport		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.AccountExport (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_AccountImport (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		AccountImport		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.AccountImport (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_DeviceRequestConnect (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		DeviceRequestConnect		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.DeviceRequestConnect (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_DevicePending (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		DevicePending		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.DevicePending (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_DeviceComplete (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		DeviceComplete		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.DeviceComplete (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_DeviceAccept (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		DeviceAccept		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.DeviceAccept (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_DeviceReject (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		DeviceReject		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.DeviceReject (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_DeviceDelete (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		DeviceDelete		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.DeviceDelete (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_DeviceList (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		DeviceList		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.DeviceList (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_DeviceAuthorize (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		DeviceAuthorize		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.DeviceAuthorize (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_DeviceJoin (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		DeviceJoin		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.DeviceJoin (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_DeviceInstall (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		DeviceInstall		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.DeviceInstall (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_DevicePreconfigure (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		DevicePreconfigure		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.DevicePreconfigure (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_MessageConfirm (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		MessageConfirm		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.MessageConfirm (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_MessagePending (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		MessagePending		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.MessagePending (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_MessageStatus (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		MessageStatus		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.MessageStatus (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_MessageAccept (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		MessageAccept		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.MessageAccept (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_MessageReject (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		MessageReject		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.MessageReject (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_MessageBlock (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		MessageBlock		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.MessageBlock (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_GroupCreate (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		GroupCreate		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.GroupCreate (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_GroupAdd (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		GroupAdd		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.GroupAdd (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_GroupGet (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		GroupGet		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.GroupGet (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_GroupDelete (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		GroupDelete		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.GroupDelete (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_GroupList (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		GroupList		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.GroupList (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_PasswordAdd (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		PasswordAdd		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.PasswordAdd (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_PasswordGet (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		PasswordGet		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.PasswordGet (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_PasswordDelete (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		PasswordDelete		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.PasswordDelete (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_PasswordDump (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		PasswordDump		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.PasswordDump (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_ContactAdd (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		ContactAdd		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.ContactAdd (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_ContactStatic (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		ContactStatic		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.ContactStatic (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_ContactDynamic (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		ContactDynamic		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.ContactDynamic (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_ContactFetch (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		ContactFetch		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.ContactFetch (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_ContactExchange (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		ContactExchange		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.ContactExchange (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_MessageContact (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		MessageContact		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.MessageContact (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_ContactImport (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		ContactImport		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.ContactImport (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_ContactExport (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		ContactExport		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.ContactExport (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_ContactDelete (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		ContactDelete		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.ContactDelete (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_ContactGet (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		ContactGet		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.ContactGet (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_ContactDump (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		ContactDump		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.ContactDump (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_BookmarkImport (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		BookmarkImport		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.BookmarkImport (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_BookmarkAdd (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		BookmarkAdd		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.BookmarkAdd (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_BookmarkDelete (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		BookmarkDelete		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.BookmarkDelete (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_BookmarkGet (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		BookmarkGet		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.BookmarkGet (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_BookmarkDump (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		BookmarkDump		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.BookmarkDump (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_CalendarImport (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		CalendarImport		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.CalendarImport (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_CalendarAdd (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		CalendarAdd		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.CalendarAdd (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_CalendarGet (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		CalendarGet		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.CalendarGet (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_CalendarDelete (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		CalendarDelete		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.CalendarDelete (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_CalendarDump (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		CalendarDump		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.CalendarDump (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_NetworkImport (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		NetworkImport		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.NetworkImport (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_NetworkAdd (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		NetworkAdd		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.NetworkAdd (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_NetworkGet (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		NetworkGet		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.NetworkGet (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_NetworkDelete (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		NetworkDelete		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.NetworkDelete (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_NetworkList (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		NetworkList		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.NetworkList (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_KeyNonce (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		KeyNonce		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.KeyNonce (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_KeySecret (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		KeySecret		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.KeySecret (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_KeyEarl (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		KeyEarl		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.KeyEarl (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_KeyShare (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		KeyShare		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.KeyShare (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_KeyRecover (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		KeyRecover		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.KeyRecover (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_HashUDF (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		HashUDF		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.HashUDF (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_HashDigest (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		HashDigest		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.HashDigest (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_HashMac (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		HashMac		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.HashMac (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_DareEncode (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		DareEncode		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.DareEncode (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_DareDecode (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		DareDecode		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.DareDecode (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_DareVerify (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		DareVerify		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.DareVerify (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_DareEARL (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		DareEARL		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.DareEARL (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_ArchiveCreate (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		ArchiveCreate		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.ArchiveCreate (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_ArchiveAppend (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		ArchiveAppend		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.ArchiveAppend (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_ArchiveDelete (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		ArchiveDelete		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.ArchiveDelete (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_ArchiveIndex (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		ArchiveIndex		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.ArchiveIndex (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_ArchiveDir (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		ArchiveDir		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.ArchiveDir (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_ArchiveExtract (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		ArchiveExtract		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.ArchiveExtract (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_ArchiveCopy (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		ArchiveCopy		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.ArchiveCopy (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_LogCreate (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		LogCreate		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.LogCreate (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_LogAppend (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		LogAppend		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.LogAppend (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_LogList (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		LogList		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.LogList (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_MailAdd (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		MailAdd		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.MailAdd (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_MailGet (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		MailGet		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.MailGet (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_MailList (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		MailList		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.MailList (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_MailImport (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		MailImport		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.MailImport (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_MailDelete (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		MailDelete		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.MailDelete (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_SmimeSign (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		SmimeSign		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.SmimeSign (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_SmimeEncrypt (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		SmimeEncrypt		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.SmimeEncrypt (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_OpenpgpSign (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		OpenpgpSign		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.OpenpgpSign (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_OpenpgpEncrypt (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		OpenpgpEncrypt		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.OpenpgpEncrypt (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_SSHCreate (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		SSHCreate		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.SSHCreate (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_SSHGet (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		SSHGet		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.SSHGet (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_SSHList (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		SSHList		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.SSHList (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_SSHClient (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		SSHClient		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.SSHClient (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_SSHHost (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		SSHHost		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.SSHHost (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_SSHKnown (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		SSHKnown		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.SSHKnown (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_SSHDelete (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		SSHDelete		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.SSHDelete (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_CallsignRegister (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		CallsignRegister		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.CallsignRegister (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_CallsignBind (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		CallsignBind		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.CallsignBind (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_CallsignResolve (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		CallsignResolve		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.CallsignResolve (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_CallsignTransfer (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		CallsignTransfer		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.CallsignTransfer (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_CallsignStatus (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		CallsignStatus		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.CallsignStatus (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_CallsignList (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		CallsignList		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.CallsignList (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_WalletInvoice (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		WalletInvoice		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.WalletInvoice (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_WalletTransfer (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		WalletTransfer		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.WalletTransfer (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_WalletAccept (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		WalletAccept		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.WalletAccept (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_WalletReject (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		WalletReject		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.WalletReject (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_WalletRedeem (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		WalletRedeem		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.WalletRedeem (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_WalletList (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		WalletList		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.WalletList (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_WalletDelete (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		WalletDelete		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.WalletDelete (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_WalletkGet (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		WalletkGet		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.WalletkGet (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_CarnetMint (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		CarnetMint		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.CarnetMint (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_CarnetStatus (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		CarnetStatus		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.CarnetStatus (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_ChatMessage (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		ChatMessage		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.ChatMessage (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_ChatListen (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		ChatListen		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.ChatListen (Options);
		Dispatch._PostProcess (result);
		}

	public static void Handle_ChatPoll (
				DispatchShell  DispatchIn, string[] Args, int Index) {
		Shell Dispatch =	DispatchIn as Shell;
		ChatPoll		Options = new ();
		ProcessOptions (Args, Index, Options);
		Dispatch._PreProcess (Options);
		var result = Dispatch.ChatPoll (Options);
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
	Flag			AutoSync{get; set;}
	Flag			AutoApprove{get; set;}
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
	Flag			AuthThreshold{get; set;}
	String			AuthSSH{get; set;}
	String			AuthEmail{get; set;}
	String			AuthGroupMember{get; set;}
	String			AuthGroupAdmin{get; set;}
	Flag			AuthNone{get; set;}
	}

public interface IMailOptions {
	Flag			OpenPGP{get; set;}
	Flag			SMIME{get; set;}
	ExistingFile			Configuration{get; set;}
	String			CA{get; set;}
	String			Inbound{get; set;}
	String			Outbound{get; set;}
	}

public interface IKeyFileOptions {
	String			Format{get; set;}
	NewFile			File{get; set;}
	String			Password{get; set;}
	Flag			Private{get; set;}
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
	String			Self{get; set;}
	String			Sign{get; set;}
	Flag			Hash{get; set;}
	ExistingFile			Cover{get; set;}
	}

public interface IDigestOptions {
	String			DigestKey{get; set;}
	}

public interface ISequenceOptions {
	String			Type{get; set;}
	}


public class _About : Goedel.Command.Dispatch ,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [where]</summary>
	public virtual Flag Where {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _Where {
		set => _Data[3].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "about",
		Brief =  "Report version and compilation date.",
		HandleDelegate =  CommandLineInterpreter.Handle_About,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				},
			new DescribeEntryOption () {
				Identifier = "Where", 
				Default = "false", // null if null
				Brief = "Report location of configuration files.",
				Index = 3,
				Key = "where"
				}
			}
		};

	}

public partial class About : _About {
    } // class About

public class _AccountHello : Goedel.Command.Dispatch ,
						IAccountOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new String ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Account {
		get => _Data[4] as String;
		set => _Data[4]  = value;
		}

	public virtual string _Account {
		set => _Data[4].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
				},
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryParameter () {
				Identifier = "Account", 
				Default = null, // null if null
				Brief = "Account",
				Index = 4,
				Key = ""
				}
			}
		};

	}

public partial class AccountHello : _AccountHello {
    } // class AccountHello

public class _AccountCreate : Goedel.Command.Dispatch ,
						IDeviceProfileInfo,
						IReporting,
						ICryptoOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String ()		} ;





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
	/// <summary>Field accessor for option [payment]</summary>
	public virtual String Payment {
		get => _Data[2] as String;
		set => _Data[2]  = value;
		}

	public virtual string _Payment {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [new]</summary>
	public virtual Flag DeviceNew {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _DeviceNew {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [dudf]</summary>
	public virtual String DeviceUDF {
		get => _Data[4] as String;
		set => _Data[4]  = value;
		}

	public virtual string _DeviceUDF {
		set => _Data[4].Parameter (value);
		}
	/// <summary>Field accessor for option [did]</summary>
	public virtual String DeviceID {
		get => _Data[5] as String;
		set => _Data[5]  = value;
		}

	public virtual string _DeviceID {
		set => _Data[5].Parameter (value);
		}
	/// <summary>Field accessor for option [dd]</summary>
	public virtual String DeviceDescription {
		get => _Data[6] as String;
		set => _Data[6]  = value;
		}

	public virtual string _DeviceDescription {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
				Identifier = "Payment", 
				Default = null, // null if null
				Brief = "Optional payment token",
				Index = 2,
				Key = "payment"
				},
			new DescribeEntryOption () {
				Identifier = "DeviceNew", 
				Default = "false", // null if null
				Brief = "Force creation of new device profile",
				Index = 3,
				Key = "new"
				},
			new DescribeEntryOption () {
				Identifier = "DeviceUDF", 
				Default = null, // null if null
				Brief = "Device profile fingerprint",
				Index = 4,
				Key = "dudf"
				},
			new DescribeEntryOption () {
				Identifier = "DeviceID", 
				Default = null, // null if null
				Brief = "Device identifier",
				Index = 5,
				Key = "did"
				},
			new DescribeEntryOption () {
				Identifier = "DeviceDescription", 
				Default = null, // null if null
				Brief = "Device description",
				Index = 6,
				Key = "dd"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





	/// <summary>Field accessor for parameter []</summary>
	public virtual String ProfileUdf {
		get => _Data[0] as String;
		set => _Data[0]  = value;
		}

	public virtual string _ProfileUdf {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class AccountDelete : _AccountDelete {
    } // class AccountDelete

public class _AccountStatus : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class AccountStatus : _AccountStatus {
    } // class AccountStatus

public class _AccountSync : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class AccountSync : _AccountSync {
    } // class AccountSync

public class _AccountInfo : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "info",
		Brief =  "Report the public keys of the specified account",
		HandleDelegate =  CommandLineInterpreter.Handle_AccountInfo,
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class AccountInfo : _AccountInfo {
    } // class AccountInfo

public class _AccountGetPIN : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting,
						IDeviceAuthOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new Integer (),
		new String (),
		new Flag (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [uri]</summary>
	public virtual Flag URI {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _URI {
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[5] as Flag;
		set => _Data[5]  = value;
		}

	public virtual string _AutoSync {
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
	/// <summary>Field accessor for option [threshold]</summary>
	public virtual Flag AuthThreshold {
		get => _Data[16] as Flag;
		set => _Data[16]  = value;
		}

	public virtual string _AuthThreshold {
		set => _Data[16].Parameter (value);
		}
	/// <summary>Field accessor for option [ssh]</summary>
	public virtual String AuthSSH {
		get => _Data[17] as String;
		set => _Data[17]  = value;
		}

	public virtual string _AuthSSH {
		set => _Data[17].Parameter (value);
		}
	/// <summary>Field accessor for option [email]</summary>
	public virtual String AuthEmail {
		get => _Data[18] as String;
		set => _Data[18]  = value;
		}

	public virtual string _AuthEmail {
		set => _Data[18].Parameter (value);
		}
	/// <summary>Field accessor for option [member]</summary>
	public virtual String AuthGroupMember {
		get => _Data[19] as String;
		set => _Data[19]  = value;
		}

	public virtual string _AuthGroupMember {
		set => _Data[19].Parameter (value);
		}
	/// <summary>Field accessor for option [group]</summary>
	public virtual String AuthGroupAdmin {
		get => _Data[20] as String;
		set => _Data[20]  = value;
		}

	public virtual string _AuthGroupAdmin {
		set => _Data[20].Parameter (value);
		}
	/// <summary>Field accessor for option [null]</summary>
	public virtual Flag AuthNone {
		get => _Data[21] as Flag;
		set => _Data[21]  = value;
		}

	public virtual string _AuthNone {
		set => _Data[21].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "pin",
		Brief =  "Get a pin value to pre-authorize a connection",
		HandleDelegate =  CommandLineInterpreter.Handle_AccountGetPIN,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryOption () {
				Identifier = "Length", 
				Default = "24", // null if null
				Brief = "Length of PIN to generate in characters",
				Index = 0,
				Key = "length"
				},
			new DescribeEntryOption () {
				Identifier = "Expire", 
				Default = "1", // null if null
				Brief = "Expiry time in days (1d), hours (1, 1h) or minutes (10m).",
				Index = 1,
				Key = "expire"
				},
			new DescribeEntryOption () {
				Identifier = "URI", 
				Default = null, // null if null
				Brief = "Return a dynamic connection URI",
				Index = 2,
				Key = "uri"
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 5,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 6,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				Identifier = "AuthThreshold", 
				Default = "false", // null if null
				Brief = "Authorize threshold rights for Mesh messaging and Web.",
				Index = 16,
				Key = "threshold"
				},
			new DescribeEntryOption () {
				Identifier = "AuthSSH", 
				Default = "false", // null if null
				Brief = "Authorize rights for specified SSH account",
				Index = 17,
				Key = "ssh"
				},
			new DescribeEntryOption () {
				Identifier = "AuthEmail", 
				Default = "false", // null if null
				Brief = "Authorize rights for specified smtp email account",
				Index = 18,
				Key = "email"
				},
			new DescribeEntryOption () {
				Identifier = "AuthGroupMember", 
				Default = "false", // null if null
				Brief = "Authorize member rights for specified Mesh group",
				Index = 19,
				Key = "member"
				},
			new DescribeEntryOption () {
				Identifier = "AuthGroupAdmin", 
				Default = "false", // null if null
				Brief = "Authorize group administrator rights for specified Mesh group",
				Index = 20,
				Key = "group"
				},
			new DescribeEntryOption () {
				Identifier = "AuthNone", 
				Default = "false", // null if null
				Brief = "Do not authorize any device rights at all (cannot be used with any rights grant))",
				Index = 21,
				Key = "null"
				}
			}
		};

	}

public partial class AccountGetPIN : _AccountGetPIN {
    } // class AccountGetPIN

public class _AccountConnect : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting,
						IDeviceAuthOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for option [auth]</summary>
	public virtual String Auth {
		get => _Data[8] as String;
		set => _Data[8]  = value;
		}

	public virtual string _Auth {
		set => _Data[8].Parameter (value);
		}
	/// <summary>Field accessor for option [root]</summary>
	public virtual Flag AuthSuper {
		get => _Data[9] as Flag;
		set => _Data[9]  = value;
		}

	public virtual string _AuthSuper {
		set => _Data[9].Parameter (value);
		}
	/// <summary>Field accessor for option [admin]</summary>
	public virtual Flag AuthAdmin {
		get => _Data[10] as Flag;
		set => _Data[10]  = value;
		}

	public virtual string _AuthAdmin {
		set => _Data[10].Parameter (value);
		}
	/// <summary>Field accessor for option [message]</summary>
	public virtual Flag AuthMessage {
		get => _Data[11] as Flag;
		set => _Data[11]  = value;
		}

	public virtual string _AuthMessage {
		set => _Data[11].Parameter (value);
		}
	/// <summary>Field accessor for option [web]</summary>
	public virtual Flag AuthWeb {
		get => _Data[12] as Flag;
		set => _Data[12]  = value;
		}

	public virtual string _AuthWeb {
		set => _Data[12].Parameter (value);
		}
	/// <summary>Field accessor for option [device]</summary>
	public virtual Flag AuthDevice {
		get => _Data[13] as Flag;
		set => _Data[13]  = value;
		}

	public virtual string _AuthDevice {
		set => _Data[13].Parameter (value);
		}
	/// <summary>Field accessor for option [threshold]</summary>
	public virtual Flag AuthThreshold {
		get => _Data[14] as Flag;
		set => _Data[14]  = value;
		}

	public virtual string _AuthThreshold {
		set => _Data[14].Parameter (value);
		}
	/// <summary>Field accessor for option [ssh]</summary>
	public virtual String AuthSSH {
		get => _Data[15] as String;
		set => _Data[15]  = value;
		}

	public virtual string _AuthSSH {
		set => _Data[15].Parameter (value);
		}
	/// <summary>Field accessor for option [email]</summary>
	public virtual String AuthEmail {
		get => _Data[16] as String;
		set => _Data[16]  = value;
		}

	public virtual string _AuthEmail {
		set => _Data[16].Parameter (value);
		}
	/// <summary>Field accessor for option [member]</summary>
	public virtual String AuthGroupMember {
		get => _Data[17] as String;
		set => _Data[17]  = value;
		}

	public virtual string _AuthGroupMember {
		set => _Data[17].Parameter (value);
		}
	/// <summary>Field accessor for option [group]</summary>
	public virtual String AuthGroupAdmin {
		get => _Data[18] as String;
		set => _Data[18]  = value;
		}

	public virtual string _AuthGroupAdmin {
		set => _Data[18].Parameter (value);
		}
	/// <summary>Field accessor for option [null]</summary>
	public virtual Flag AuthNone {
		get => _Data[19] as Flag;
		set => _Data[19]  = value;
		}

	public virtual string _AuthNone {
		set => _Data[19].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				},
			new DescribeEntryOption () {
				Identifier = "Auth", 
				Default = null, // null if null
				Brief = "(De)Authorize the specified function on the device",
				Index = 8,
				Key = "auth"
				},
			new DescribeEntryOption () {
				Identifier = "AuthSuper", 
				Default = "false", // null if null
				Brief = "Device as super administration device",
				Index = 9,
				Key = "root"
				},
			new DescribeEntryOption () {
				Identifier = "AuthAdmin", 
				Default = "false", // null if null
				Brief = "Device as administration device",
				Index = 10,
				Key = "admin"
				},
			new DescribeEntryOption () {
				Identifier = "AuthMessage", 
				Default = "false", // null if null
				Brief = "Authorize rights for Mesh messaging",
				Index = 11,
				Key = "message"
				},
			new DescribeEntryOption () {
				Identifier = "AuthWeb", 
				Default = "false", // null if null
				Brief = "Authorize rights for Mesh messaging and Web.",
				Index = 12,
				Key = "web"
				},
			new DescribeEntryOption () {
				Identifier = "AuthDevice", 
				Default = "false", // null if null
				Brief = "Device restrictive access",
				Index = 13,
				Key = "device"
				},
			new DescribeEntryOption () {
				Identifier = "AuthThreshold", 
				Default = "false", // null if null
				Brief = "Authorize threshold rights for Mesh messaging and Web.",
				Index = 14,
				Key = "threshold"
				},
			new DescribeEntryOption () {
				Identifier = "AuthSSH", 
				Default = "false", // null if null
				Brief = "Authorize rights for specified SSH account",
				Index = 15,
				Key = "ssh"
				},
			new DescribeEntryOption () {
				Identifier = "AuthEmail", 
				Default = "false", // null if null
				Brief = "Authorize rights for specified smtp email account",
				Index = 16,
				Key = "email"
				},
			new DescribeEntryOption () {
				Identifier = "AuthGroupMember", 
				Default = "false", // null if null
				Brief = "Authorize member rights for specified Mesh group",
				Index = 17,
				Key = "member"
				},
			new DescribeEntryOption () {
				Identifier = "AuthGroupAdmin", 
				Default = "false", // null if null
				Brief = "Authorize group administrator rights for specified Mesh group",
				Index = 18,
				Key = "group"
				},
			new DescribeEntryOption () {
				Identifier = "AuthNone", 
				Default = "false", // null if null
				Brief = "Do not authorize any device rights at all (cannot be used with any rights grant))",
				Index = 19,
				Key = "null"
				}
			}
		};

	}

public partial class AccountConnect : _AccountConnect {
    } // class AccountConnect

public class _AccountEscrow : Goedel.Command.Dispatch ,
						ICryptoOptions,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Integer (),
		new Integer ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for option [quorum]</summary>
	public virtual Integer Quorum {
		get => _Data[8] as Integer;
		set => _Data[8]  = value;
		}

	public virtual string _Quorum {
		set => _Data[8].Parameter (value);
		}
	/// <summary>Field accessor for option [shares]</summary>
	public virtual Integer Shares {
		get => _Data[9] as Integer;
		set => _Data[9]  = value;
		}

	public virtual string _Shares {
		set => _Data[9].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				},
			new DescribeEntryOption () {
				Identifier = "Quorum", 
				Default = "2", // null if null
				Brief = "<Unspecified>",
				Index = 8,
				Key = "quorum"
				},
			new DescribeEntryOption () {
				Identifier = "Shares", 
				Default = "3", // null if null
				Brief = "<Unspecified>",
				Index = 9,
				Key = "shares"
				}
			}
		};

	}

public partial class AccountEscrow : _AccountEscrow {
    } // class AccountEscrow

public class _AccountPurge : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class AccountPurge : _AccountPurge {
    } // class AccountPurge

public class _AccountRecover : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
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
		new String (),
		new String (),
		new ExistingFile (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Share1 {
		get => _Data[7] as String;
		set => _Data[7]  = value;
		}

	public virtual string _Share1 {
		set => _Data[7].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Share2 {
		get => _Data[8] as String;
		set => _Data[8]  = value;
		}

	public virtual string _Share2 {
		set => _Data[8].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Share3 {
		get => _Data[9] as String;
		set => _Data[9]  = value;
		}

	public virtual string _Share3 {
		set => _Data[9].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Share4 {
		get => _Data[10] as String;
		set => _Data[10]  = value;
		}

	public virtual string _Share4 {
		set => _Data[10].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Share5 {
		get => _Data[11] as String;
		set => _Data[11]  = value;
		}

	public virtual string _Share5 {
		set => _Data[11].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Share6 {
		get => _Data[12] as String;
		set => _Data[12]  = value;
		}

	public virtual string _Share6 {
		set => _Data[12].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Share7 {
		get => _Data[13] as String;
		set => _Data[13]  = value;
		}

	public virtual string _Share7 {
		set => _Data[13].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Share8 {
		get => _Data[14] as String;
		set => _Data[14]  = value;
		}

	public virtual string _Share8 {
		set => _Data[14].Parameter (value);
		}
	/// <summary>Field accessor for option [file]</summary>
	public virtual ExistingFile File {
		get => _Data[15] as ExistingFile;
		set => _Data[15]  = value;
		}

	public virtual string _File {
		set => _Data[15].Parameter (value);
		}
	/// <summary>Field accessor for option [verify]</summary>
	public virtual Flag Verify {
		get => _Data[16] as Flag;
		set => _Data[16]  = value;
		}

	public virtual string _Verify {
		set => _Data[16].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
			new DescribeEntryParameter () {
				Identifier = "Share1", 
				Default = null, // null if null
				Brief = "Recovery share",
				Index = 7,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Share2", 
				Default = null, // null if null
				Brief = "Recovery share",
				Index = 8,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Share3", 
				Default = null, // null if null
				Brief = "Recovery share",
				Index = 9,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Share4", 
				Default = null, // null if null
				Brief = "Recovery share",
				Index = 10,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Share5", 
				Default = null, // null if null
				Brief = "Recovery share",
				Index = 11,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Share6", 
				Default = null, // null if null
				Brief = "Recovery share",
				Index = 12,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Share7", 
				Default = null, // null if null
				Brief = "Recovery share",
				Index = 13,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Share8", 
				Default = null, // null if null
				Brief = "Recovery share",
				Index = 14,
				Key = ""
				},
			new DescribeEntryOption () {
				Identifier = "File", 
				Default = null, // null if null
				Brief = "File containing the recovery key blob",
				Index = 15,
				Key = "file"
				},
			new DescribeEntryOption () {
				Identifier = "Verify", 
				Default = null, // null if null
				Brief = "Check that the shares are valid for recovery without performing recovery.",
				Index = 16,
				Key = "verify"
				}
			}
		};

	}

public partial class AccountRecover : _AccountRecover {
    } // class AccountRecover

public class _AccountList : Goedel.Command.Dispatch ,
						IReporting,
						IAccountOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new String (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[5] as Flag;
		set => _Data[5]  = value;
		}

	public virtual string _AutoSync {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "list",
		Brief =  "List all profiles on the local machine",
		HandleDelegate =  CommandLineInterpreter.Handle_AccountList,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 5,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 6,
				Key = "auto"
				}
			}
		};

	}

public partial class AccountList : _AccountList {
    } // class AccountList

public class _AccountGet : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class AccountGet : _AccountGet {
    } // class AccountGet

public class _AccountExport : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new NewFile (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "export",
		Brief =  "Export the specified profile data to the specified file",
		HandleDelegate =  CommandLineInterpreter.Handle_AccountExport,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "File", 
				Default = null, // null if null
				Brief = "Name of the file to which the archive is to be written.",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class AccountExport : _AccountExport {
    } // class AccountExport

public class _AccountImport : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new NewFile (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "import",
		Brief =  "Import the specified profile data to the specified file",
		HandleDelegate =  CommandLineInterpreter.Handle_AccountImport,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "File", 
				Default = null, // null if null
				Brief = "Name of the file file which the archive is to be read.",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class AccountImport : _AccountImport {
    } // class AccountImport

public class _DeviceRequestConnect : Goedel.Command.Dispatch ,
						IReporting,
						IDeviceProfileInfo,
						IDeviceAuthOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
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
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [auth]</summary>
	public virtual String Auth {
		get => _Data[9] as String;
		set => _Data[9]  = value;
		}

	public virtual string _Auth {
		set => _Data[9].Parameter (value);
		}
	/// <summary>Field accessor for option [root]</summary>
	public virtual Flag AuthSuper {
		get => _Data[10] as Flag;
		set => _Data[10]  = value;
		}

	public virtual string _AuthSuper {
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
	/// <summary>Field accessor for option [message]</summary>
	public virtual Flag AuthMessage {
		get => _Data[12] as Flag;
		set => _Data[12]  = value;
		}

	public virtual string _AuthMessage {
		set => _Data[12].Parameter (value);
		}
	/// <summary>Field accessor for option [web]</summary>
	public virtual Flag AuthWeb {
		get => _Data[13] as Flag;
		set => _Data[13]  = value;
		}

	public virtual string _AuthWeb {
		set => _Data[13].Parameter (value);
		}
	/// <summary>Field accessor for option [device]</summary>
	public virtual Flag AuthDevice {
		get => _Data[14] as Flag;
		set => _Data[14]  = value;
		}

	public virtual string _AuthDevice {
		set => _Data[14].Parameter (value);
		}
	/// <summary>Field accessor for option [threshold]</summary>
	public virtual Flag AuthThreshold {
		get => _Data[15] as Flag;
		set => _Data[15]  = value;
		}

	public virtual string _AuthThreshold {
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
	/// <summary>Field accessor for option [null]</summary>
	public virtual Flag AuthNone {
		get => _Data[20] as Flag;
		set => _Data[20]  = value;
		}

	public virtual string _AuthNone {
		set => _Data[20].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				Identifier = "Auth", 
				Default = null, // null if null
				Brief = "(De)Authorize the specified function on the device",
				Index = 9,
				Key = "auth"
				},
			new DescribeEntryOption () {
				Identifier = "AuthSuper", 
				Default = "false", // null if null
				Brief = "Device as super administration device",
				Index = 10,
				Key = "root"
				},
			new DescribeEntryOption () {
				Identifier = "AuthAdmin", 
				Default = "false", // null if null
				Brief = "Device as administration device",
				Index = 11,
				Key = "admin"
				},
			new DescribeEntryOption () {
				Identifier = "AuthMessage", 
				Default = "false", // null if null
				Brief = "Authorize rights for Mesh messaging",
				Index = 12,
				Key = "message"
				},
			new DescribeEntryOption () {
				Identifier = "AuthWeb", 
				Default = "false", // null if null
				Brief = "Authorize rights for Mesh messaging and Web.",
				Index = 13,
				Key = "web"
				},
			new DescribeEntryOption () {
				Identifier = "AuthDevice", 
				Default = "false", // null if null
				Brief = "Device restrictive access",
				Index = 14,
				Key = "device"
				},
			new DescribeEntryOption () {
				Identifier = "AuthThreshold", 
				Default = "false", // null if null
				Brief = "Authorize threshold rights for Mesh messaging and Web.",
				Index = 15,
				Key = "threshold"
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
				},
			new DescribeEntryOption () {
				Identifier = "AuthNone", 
				Default = "false", // null if null
				Brief = "Do not authorize any device rights at all (cannot be used with any rights grant))",
				Index = 20,
				Key = "null"
				}
			}
		};

	}

public partial class DeviceRequestConnect : _DeviceRequestConnect {
    } // class DeviceRequestConnect

public class _DevicePending : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class DevicePending : _DevicePending {
    } // class DevicePending

public class _DeviceComplete : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class DeviceComplete : _DeviceComplete {
    } // class DeviceComplete

public class _DeviceAccept : Goedel.Command.Dispatch ,
						IDeviceAuthOptions,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [threshold]</summary>
	public virtual Flag AuthThreshold {
		get => _Data[8] as Flag;
		set => _Data[8]  = value;
		}

	public virtual string _AuthThreshold {
		set => _Data[8].Parameter (value);
		}
	/// <summary>Field accessor for option [ssh]</summary>
	public virtual String AuthSSH {
		get => _Data[9] as String;
		set => _Data[9]  = value;
		}

	public virtual string _AuthSSH {
		set => _Data[9].Parameter (value);
		}
	/// <summary>Field accessor for option [email]</summary>
	public virtual String AuthEmail {
		get => _Data[10] as String;
		set => _Data[10]  = value;
		}

	public virtual string _AuthEmail {
		set => _Data[10].Parameter (value);
		}
	/// <summary>Field accessor for option [member]</summary>
	public virtual String AuthGroupMember {
		get => _Data[11] as String;
		set => _Data[11]  = value;
		}

	public virtual string _AuthGroupMember {
		set => _Data[11].Parameter (value);
		}
	/// <summary>Field accessor for option [group]</summary>
	public virtual String AuthGroupAdmin {
		get => _Data[12] as String;
		set => _Data[12]  = value;
		}

	public virtual string _AuthGroupAdmin {
		set => _Data[12].Parameter (value);
		}
	/// <summary>Field accessor for option [null]</summary>
	public virtual Flag AuthNone {
		get => _Data[13] as Flag;
		set => _Data[13]  = value;
		}

	public virtual string _AuthNone {
		set => _Data[13].Parameter (value);
		}
	/// <summary>Field accessor for option [account]</summary>
	public virtual String AccountAddress {
		get => _Data[14] as String;
		set => _Data[14]  = value;
		}

	public virtual string _AccountAddress {
		set => _Data[14].Parameter (value);
		}
	/// <summary>Field accessor for option [local]</summary>
	public virtual String LocalName {
		get => _Data[15] as String;
		set => _Data[15]  = value;
		}

	public virtual string _LocalName {
		set => _Data[15].Parameter (value);
		}
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[16] as Flag;
		set => _Data[16]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[16].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[17] as Flag;
		set => _Data[17]  = value;
		}

	public virtual string _AutoApprove {
		set => _Data[17].Parameter (value);
		}
	/// <summary>Field accessor for option [verbose]</summary>
	public virtual Flag Verbose {
		get => _Data[18] as Flag;
		set => _Data[18]  = value;
		}

	public virtual string _Verbose {
		set => _Data[18].Parameter (value);
		}
	/// <summary>Field accessor for option [report]</summary>
	public virtual Flag Report {
		get => _Data[19] as Flag;
		set => _Data[19]  = value;
		}

	public virtual string _Report {
		set => _Data[19].Parameter (value);
		}
	/// <summary>Field accessor for option [json]</summary>
	public virtual Flag Json {
		get => _Data[20] as Flag;
		set => _Data[20]  = value;
		}

	public virtual string _Json {
		set => _Data[20].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
				Identifier = "AuthThreshold", 
				Default = "false", // null if null
				Brief = "Authorize threshold rights for Mesh messaging and Web.",
				Index = 8,
				Key = "threshold"
				},
			new DescribeEntryOption () {
				Identifier = "AuthSSH", 
				Default = "false", // null if null
				Brief = "Authorize rights for specified SSH account",
				Index = 9,
				Key = "ssh"
				},
			new DescribeEntryOption () {
				Identifier = "AuthEmail", 
				Default = "false", // null if null
				Brief = "Authorize rights for specified smtp email account",
				Index = 10,
				Key = "email"
				},
			new DescribeEntryOption () {
				Identifier = "AuthGroupMember", 
				Default = "false", // null if null
				Brief = "Authorize member rights for specified Mesh group",
				Index = 11,
				Key = "member"
				},
			new DescribeEntryOption () {
				Identifier = "AuthGroupAdmin", 
				Default = "false", // null if null
				Brief = "Authorize group administrator rights for specified Mesh group",
				Index = 12,
				Key = "group"
				},
			new DescribeEntryOption () {
				Identifier = "AuthNone", 
				Default = "false", // null if null
				Brief = "Do not authorize any device rights at all (cannot be used with any rights grant))",
				Index = 13,
				Key = "null"
				},
			new DescribeEntryOption () {
				Identifier = "AccountAddress", 
				Default = null, // null if null
				Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
				Index = 14,
				Key = "account"
				},
			new DescribeEntryOption () {
				Identifier = "LocalName", 
				Default = null, // null if null
				Brief = "Local name for account (e.g. personal)",
				Index = 15,
				Key = "local"
				},
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 16,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 17,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
				Brief = "Verbose reports (default)",
				Index = 18,
				Key = "verbose"
				},
			new DescribeEntryOption () {
				Identifier = "Report", 
				Default = "true", // null if null
				Brief = "Report output (default)",
				Index = 19,
				Key = "report"
				},
			new DescribeEntryOption () {
				Identifier = "Json", 
				Default = "false", // null if null
				Brief = "Report output in JSON format",
				Index = 20,
				Key = "json"
				}
			}
		};

	}

public partial class DeviceAccept : _DeviceAccept {
    } // class DeviceAccept

public class _DeviceReject : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class DeviceReject : _DeviceReject {
    } // class DeviceReject

public class _DeviceDelete : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class DeviceDelete : _DeviceDelete {
    } // class DeviceDelete

public class _DeviceList : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for parameter []</summary>
	public virtual String GroupID {
		get => _Data[7] as String;
		set => _Data[7]  = value;
		}

	public virtual string _GroupID {
		set => _Data[7].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class DeviceList : _DeviceList {
    } // class DeviceList

public class _DeviceAuthorize : Goedel.Command.Dispatch ,
						IDeviceAuthOptions,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [threshold]</summary>
	public virtual Flag AuthThreshold {
		get => _Data[7] as Flag;
		set => _Data[7]  = value;
		}

	public virtual string _AuthThreshold {
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
	/// <summary>Field accessor for option [null]</summary>
	public virtual Flag AuthNone {
		get => _Data[12] as Flag;
		set => _Data[12]  = value;
		}

	public virtual string _AuthNone {
		set => _Data[12].Parameter (value);
		}
	/// <summary>Field accessor for option [account]</summary>
	public virtual String AccountAddress {
		get => _Data[13] as String;
		set => _Data[13]  = value;
		}

	public virtual string _AccountAddress {
		set => _Data[13].Parameter (value);
		}
	/// <summary>Field accessor for option [local]</summary>
	public virtual String LocalName {
		get => _Data[14] as String;
		set => _Data[14]  = value;
		}

	public virtual string _LocalName {
		set => _Data[14].Parameter (value);
		}
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[15] as Flag;
		set => _Data[15]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[15].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[16] as Flag;
		set => _Data[16]  = value;
		}

	public virtual string _AutoApprove {
		set => _Data[16].Parameter (value);
		}
	/// <summary>Field accessor for option [verbose]</summary>
	public virtual Flag Verbose {
		get => _Data[17] as Flag;
		set => _Data[17]  = value;
		}

	public virtual string _Verbose {
		set => _Data[17].Parameter (value);
		}
	/// <summary>Field accessor for option [report]</summary>
	public virtual Flag Report {
		get => _Data[18] as Flag;
		set => _Data[18]  = value;
		}

	public virtual string _Report {
		set => _Data[18].Parameter (value);
		}
	/// <summary>Field accessor for option [json]</summary>
	public virtual Flag Json {
		get => _Data[19] as Flag;
		set => _Data[19]  = value;
		}

	public virtual string _Json {
		set => _Data[19].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
				Identifier = "AuthThreshold", 
				Default = "false", // null if null
				Brief = "Authorize threshold rights for Mesh messaging and Web.",
				Index = 7,
				Key = "threshold"
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
				Identifier = "AuthNone", 
				Default = "false", // null if null
				Brief = "Do not authorize any device rights at all (cannot be used with any rights grant))",
				Index = 12,
				Key = "null"
				},
			new DescribeEntryOption () {
				Identifier = "AccountAddress", 
				Default = null, // null if null
				Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
				Index = 13,
				Key = "account"
				},
			new DescribeEntryOption () {
				Identifier = "LocalName", 
				Default = null, // null if null
				Brief = "Local name for account (e.g. personal)",
				Index = 14,
				Key = "local"
				},
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 15,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 16,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
				Brief = "Verbose reports (default)",
				Index = 17,
				Key = "verbose"
				},
			new DescribeEntryOption () {
				Identifier = "Report", 
				Default = "true", // null if null
				Brief = "Report output (default)",
				Index = 18,
				Key = "report"
				},
			new DescribeEntryOption () {
				Identifier = "Json", 
				Default = "false", // null if null
				Brief = "Report output in JSON format",
				Index = 19,
				Key = "json"
				}
			}
		};

	}

public partial class DeviceAuthorize : _DeviceAuthorize {
    } // class DeviceAuthorize

public class _DeviceJoin : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class DeviceJoin : _DeviceJoin {
    } // class DeviceJoin

public class _DeviceInstall : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class DeviceInstall : _DeviceInstall {
    } // class DeviceInstall

public class _DevicePreconfigure : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Integer ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for option [length]</summary>
	public virtual Integer Length {
		get => _Data[7] as Integer;
		set => _Data[7]  = value;
		}

	public virtual string _Length {
		set => _Data[7].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				Identifier = "Length", 
				Default = "24", // null if null
				Brief = "Length of PIN to generate in characters",
				Index = 7,
				Key = "length"
				}
			}
		};

	}

public partial class DevicePreconfigure : _DevicePreconfigure {
    } // class DevicePreconfigure

public class _MessageConfirm : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[4].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[5] as Flag;
		set => _Data[5]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
				Brief = "Text of the request message",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 4,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 5,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class MessageConfirm : _MessageConfirm {
    } // class MessageConfirm

public class _MessagePending : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for option [unread]</summary>
	public virtual Flag Unread {
		get => _Data[7] as Flag;
		set => _Data[7]  = value;
		}

	public virtual string _Unread {
		set => _Data[7].Parameter (value);
		}
	/// <summary>Field accessor for option [read]</summary>
	public virtual Flag Read {
		get => _Data[8] as Flag;
		set => _Data[8]  = value;
		}

	public virtual string _Read {
		set => _Data[8].Parameter (value);
		}
	/// <summary>Field accessor for option [raw]</summary>
	public virtual Flag Raw {
		get => _Data[9] as Flag;
		set => _Data[9]  = value;
		}

	public virtual string _Raw {
		set => _Data[9].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				Identifier = "Unread", 
				Default = "true", // null if null
				Brief = "Return unread messages",
				Index = 7,
				Key = "unread"
				},
			new DescribeEntryOption () {
				Identifier = "Read", 
				Default = "false", // null if null
				Brief = "Return read messages",
				Index = 8,
				Key = "read"
				},
			new DescribeEntryOption () {
				Identifier = "Raw", 
				Default = "false", // null if null
				Brief = "Return messages in raw form",
				Index = 9,
				Key = "raw"
				}
			}
		};

	}

public partial class MessagePending : _MessagePending {
    } // class MessagePending

public class _MessageStatus : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class MessageStatus : _MessageStatus {
    } // class MessageStatus

public class _MessageAccept : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class MessageAccept : _MessageAccept {
    } // class MessageAccept

public class _MessageReject : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class MessageReject : _MessageReject {
    } // class MessageReject

public class _MessageBlock : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class MessageBlock : _MessageBlock {
    } // class MessageBlock

public class _GroupCreate : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting,
						ICryptoOptions,
						IDeviceAuthOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new String (),
		new ExistingFile ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for option [alg]</summary>
	public virtual String Algorithms {
		get => _Data[7] as String;
		set => _Data[7]  = value;
		}

	public virtual string _Algorithms {
		set => _Data[7].Parameter (value);
		}
	/// <summary>Field accessor for option [auth]</summary>
	public virtual String Auth {
		get => _Data[8] as String;
		set => _Data[8]  = value;
		}

	public virtual string _Auth {
		set => _Data[8].Parameter (value);
		}
	/// <summary>Field accessor for option [root]</summary>
	public virtual Flag AuthSuper {
		get => _Data[9] as Flag;
		set => _Data[9]  = value;
		}

	public virtual string _AuthSuper {
		set => _Data[9].Parameter (value);
		}
	/// <summary>Field accessor for option [admin]</summary>
	public virtual Flag AuthAdmin {
		get => _Data[10] as Flag;
		set => _Data[10]  = value;
		}

	public virtual string _AuthAdmin {
		set => _Data[10].Parameter (value);
		}
	/// <summary>Field accessor for option [message]</summary>
	public virtual Flag AuthMessage {
		get => _Data[11] as Flag;
		set => _Data[11]  = value;
		}

	public virtual string _AuthMessage {
		set => _Data[11].Parameter (value);
		}
	/// <summary>Field accessor for option [web]</summary>
	public virtual Flag AuthWeb {
		get => _Data[12] as Flag;
		set => _Data[12]  = value;
		}

	public virtual string _AuthWeb {
		set => _Data[12].Parameter (value);
		}
	/// <summary>Field accessor for option [device]</summary>
	public virtual Flag AuthDevice {
		get => _Data[13] as Flag;
		set => _Data[13]  = value;
		}

	public virtual string _AuthDevice {
		set => _Data[13].Parameter (value);
		}
	/// <summary>Field accessor for option [threshold]</summary>
	public virtual Flag AuthThreshold {
		get => _Data[14] as Flag;
		set => _Data[14]  = value;
		}

	public virtual string _AuthThreshold {
		set => _Data[14].Parameter (value);
		}
	/// <summary>Field accessor for option [ssh]</summary>
	public virtual String AuthSSH {
		get => _Data[15] as String;
		set => _Data[15]  = value;
		}

	public virtual string _AuthSSH {
		set => _Data[15].Parameter (value);
		}
	/// <summary>Field accessor for option [email]</summary>
	public virtual String AuthEmail {
		get => _Data[16] as String;
		set => _Data[16]  = value;
		}

	public virtual string _AuthEmail {
		set => _Data[16].Parameter (value);
		}
	/// <summary>Field accessor for option [member]</summary>
	public virtual String AuthGroupMember {
		get => _Data[17] as String;
		set => _Data[17]  = value;
		}

	public virtual string _AuthGroupMember {
		set => _Data[17].Parameter (value);
		}
	/// <summary>Field accessor for option [group]</summary>
	public virtual String AuthGroupAdmin {
		get => _Data[18] as String;
		set => _Data[18]  = value;
		}

	public virtual string _AuthGroupAdmin {
		set => _Data[18].Parameter (value);
		}
	/// <summary>Field accessor for option [null]</summary>
	public virtual Flag AuthNone {
		get => _Data[19] as Flag;
		set => _Data[19]  = value;
		}

	public virtual string _AuthNone {
		set => _Data[19].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String GroupID {
		get => _Data[20] as String;
		set => _Data[20]  = value;
		}

	public virtual string _GroupID {
		set => _Data[20].Parameter (value);
		}
	/// <summary>Field accessor for option [cover]</summary>
	public virtual ExistingFile Cover {
		get => _Data[21] as ExistingFile;
		set => _Data[21]  = value;
		}

	public virtual string _Cover {
		set => _Data[21].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				Identifier = "Algorithms", 
				Default = null, // null if null
				Brief = "List of algorithm specifiers",
				Index = 7,
				Key = "alg"
				},
			new DescribeEntryOption () {
				Identifier = "Auth", 
				Default = null, // null if null
				Brief = "(De)Authorize the specified function on the device",
				Index = 8,
				Key = "auth"
				},
			new DescribeEntryOption () {
				Identifier = "AuthSuper", 
				Default = "false", // null if null
				Brief = "Device as super administration device",
				Index = 9,
				Key = "root"
				},
			new DescribeEntryOption () {
				Identifier = "AuthAdmin", 
				Default = "false", // null if null
				Brief = "Device as administration device",
				Index = 10,
				Key = "admin"
				},
			new DescribeEntryOption () {
				Identifier = "AuthMessage", 
				Default = "false", // null if null
				Brief = "Authorize rights for Mesh messaging",
				Index = 11,
				Key = "message"
				},
			new DescribeEntryOption () {
				Identifier = "AuthWeb", 
				Default = "false", // null if null
				Brief = "Authorize rights for Mesh messaging and Web.",
				Index = 12,
				Key = "web"
				},
			new DescribeEntryOption () {
				Identifier = "AuthDevice", 
				Default = "false", // null if null
				Brief = "Device restrictive access",
				Index = 13,
				Key = "device"
				},
			new DescribeEntryOption () {
				Identifier = "AuthThreshold", 
				Default = "false", // null if null
				Brief = "Authorize threshold rights for Mesh messaging and Web.",
				Index = 14,
				Key = "threshold"
				},
			new DescribeEntryOption () {
				Identifier = "AuthSSH", 
				Default = "false", // null if null
				Brief = "Authorize rights for specified SSH account",
				Index = 15,
				Key = "ssh"
				},
			new DescribeEntryOption () {
				Identifier = "AuthEmail", 
				Default = "false", // null if null
				Brief = "Authorize rights for specified smtp email account",
				Index = 16,
				Key = "email"
				},
			new DescribeEntryOption () {
				Identifier = "AuthGroupMember", 
				Default = "false", // null if null
				Brief = "Authorize member rights for specified Mesh group",
				Index = 17,
				Key = "member"
				},
			new DescribeEntryOption () {
				Identifier = "AuthGroupAdmin", 
				Default = "false", // null if null
				Brief = "Authorize group administrator rights for specified Mesh group",
				Index = 18,
				Key = "group"
				},
			new DescribeEntryOption () {
				Identifier = "AuthNone", 
				Default = "false", // null if null
				Brief = "Do not authorize any device rights at all (cannot be used with any rights grant))",
				Index = 19,
				Key = "null"
				},
			new DescribeEntryParameter () {
				Identifier = "GroupID", 
				Default = null, // null if null
				Brief = "Recryption group name in user@example.com format",
				Index = 20,
				Key = ""
				},
			new DescribeEntryOption () {
				Identifier = "Cover", 
				Default = null, // null if null
				Brief = "File containing a default cover to be added to encrypted files",
				Index = 21,
				Key = "cover"
				}
			}
		};

	}

public partial class GroupCreate : _GroupCreate {
    } // class GroupCreate

public class _GroupAdd : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new String ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for parameter []</summary>
	public virtual String GroupID {
		get => _Data[7] as String;
		set => _Data[7]  = value;
		}

	public virtual string _GroupID {
		set => _Data[7].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String MemberID {
		get => _Data[8] as String;
		set => _Data[8]  = value;
		}

	public virtual string _MemberID {
		set => _Data[8].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
			new DescribeEntryParameter () {
				Identifier = "GroupID", 
				Default = null, // null if null
				Brief = "Recryption group name in user@example.com format",
				Index = 7,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "MemberID", 
				Default = null, // null if null
				Brief = "User to add",
				Index = 8,
				Key = ""
				}
			}
		};

	}

public partial class GroupAdd : _GroupAdd {
    } // class GroupAdd

public class _GroupGet : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new String ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for parameter []</summary>
	public virtual String GroupID {
		get => _Data[7] as String;
		set => _Data[7]  = value;
		}

	public virtual string _GroupID {
		set => _Data[7].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String MemberID {
		get => _Data[8] as String;
		set => _Data[8]  = value;
		}

	public virtual string _MemberID {
		set => _Data[8].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
			new DescribeEntryParameter () {
				Identifier = "GroupID", 
				Default = null, // null if null
				Brief = "Recryption group name in user@example.com format",
				Index = 7,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "MemberID", 
				Default = null, // null if null
				Brief = "User to find",
				Index = 8,
				Key = ""
				}
			}
		};

	}

public partial class GroupGet : _GroupGet {
    } // class GroupGet

public class _GroupDelete : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new String ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for parameter []</summary>
	public virtual String GroupID {
		get => _Data[7] as String;
		set => _Data[7]  = value;
		}

	public virtual string _GroupID {
		set => _Data[7].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String MemberID {
		get => _Data[8] as String;
		set => _Data[8]  = value;
		}

	public virtual string _MemberID {
		set => _Data[8].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
			new DescribeEntryParameter () {
				Identifier = "GroupID", 
				Default = null, // null if null
				Brief = "Recryption group name in user@example.com format",
				Index = 7,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "MemberID", 
				Default = null, // null if null
				Brief = "User to delete",
				Index = 8,
				Key = ""
				}
			}
		};

	}

public partial class GroupDelete : _GroupDelete {
    } // class GroupDelete

public class _GroupList : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for parameter []</summary>
	public virtual String GroupID {
		get => _Data[7] as String;
		set => _Data[7]  = value;
		}

	public virtual string _GroupID {
		set => _Data[7].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class GroupList : _GroupList {
    } // class GroupList

public class _PasswordAdd : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[5] as Flag;
		set => _Data[5]  = value;
		}

	public virtual string _AutoSync {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "add",
		Brief =  "Add password entry",
		HandleDelegate =  CommandLineInterpreter.Handle_PasswordAdd,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Site", 
				Default = null, // null if null
				Brief = "The site(s) at which the password is to be used.",
				Index = 0,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Username", 
				Default = null, // null if null
				Brief = "The username",
				Index = 1,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Password", 
				Default = null, // null if null
				Brief = "The password",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 5,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 6,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class PasswordAdd : _PasswordAdd {
    } // class PasswordAdd

public class _PasswordGet : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "get",
		Brief =  "Lookup password entry",
		HandleDelegate =  CommandLineInterpreter.Handle_PasswordGet,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Site", 
				Default = null, // null if null
				Brief = "The site name",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class PasswordGet : _PasswordGet {
    } // class PasswordGet

public class _PasswordDelete : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class PasswordDelete : _PasswordDelete {
    } // class PasswordDelete

public class _PasswordDump : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "list",
		Brief =  "List password entries",
		HandleDelegate =  CommandLineInterpreter.Handle_PasswordDump,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Site", 
				Default = null, // null if null
				Brief = "The site or sites to return.",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class PasswordDump : _PasswordDump {
    } // class PasswordDump

public class _ContactAdd : Goedel.Command.Dispatch {

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag ()		} ;





	/// <summary>Field accessor for parameter []</summary>
	public virtual String Address {
		get => _Data[0] as String;
		set => _Data[0]  = value;
		}

	public virtual string _Address {
		set => _Data[0].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Name {
		get => _Data[1] as String;
		set => _Data[1]  = value;
		}

	public virtual string _Name {
		set => _Data[1].Parameter (value);
		}
	/// <summary>Field accessor for option [uid]</summary>
	public virtual String Unique {
		get => _Data[2] as String;
		set => _Data[2]  = value;
		}

	public virtual string _Unique {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [id]</summary>
	public virtual String Identifier {
		get => _Data[3] as String;
		set => _Data[3]  = value;
		}

	public virtual string _Identifier {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [self]</summary>
	public virtual Flag Self {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _Self {
		set => _Data[4].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "add",
		Brief =  "Add contact entry from specified parameters",
		HandleDelegate =  CommandLineInterpreter.Handle_ContactAdd,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Address", 
				Default = null, // null if null
				Brief = "The user address",
				Index = 0,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Name", 
				Default = null, // null if null
				Brief = "The user name",
				Index = 1,
				Key = ""
				},
			new DescribeEntryOption () {
				Identifier = "Unique", 
				Default = null, // null if null
				Brief = "Unique identifier",
				Index = 2,
				Key = "uid"
				},
			new DescribeEntryOption () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "Local identifier",
				Index = 3,
				Key = "id"
				},
			new DescribeEntryOption () {
				Identifier = "Self", 
				Default = null, // null if null
				Brief = "Contact is for self",
				Index = 4,
				Key = "self"
				}
			}
		};

	}

public partial class ContactAdd : _ContactAdd {
    } // class ContactAdd

public class _ContactStatic : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class ContactStatic : _ContactStatic {
    } // class ContactStatic

public class _ContactDynamic : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class ContactDynamic : _ContactDynamic {
    } // class ContactDynamic

public class _ContactFetch : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class ContactFetch : _ContactFetch {
    } // class ContactFetch

public class _ContactExchange : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "exchange",
		Brief =  "Request contact from URI presenting own contact",
		HandleDelegate =  CommandLineInterpreter.Handle_ContactExchange,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Uri", 
				Default = null, // null if null
				Brief = "Contact exchange URI",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class ContactExchange : _ContactExchange {
    } // class ContactExchange

public class _MessageContact : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "request",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class MessageContact : _MessageContact {
    } // class MessageContact

public class _ContactImport : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new ExistingFile (),
		new Flag (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





	/// <summary>Field accessor for parameter []</summary>
	public virtual ExistingFile File {
		get => _Data[0] as ExistingFile;
		set => _Data[0]  = value;
		}

	public virtual string _File {
		set => _Data[0].Parameter (value);
		}
	/// <summary>Field accessor for option [self]</summary>
	public virtual Flag Self {
		get => _Data[1] as Flag;
		set => _Data[1]  = value;
		}

	public virtual string _Self {
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[4].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[5] as Flag;
		set => _Data[5]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "import",
		Brief =  "Import contact entry from file",
		HandleDelegate =  CommandLineInterpreter.Handle_ContactImport,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "File", 
				Default = null, // null if null
				Brief = "File containing the contact entry to add",
				Index = 0,
				Key = ""
				},
			new DescribeEntryOption () {
				Identifier = "Self", 
				Default = null, // null if null
				Brief = "Contact is for self",
				Index = 1,
				Key = "self"
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 4,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 5,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class ContactImport : _ContactImport {
    } // class ContactImport

public class _ContactExport : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new ExistingFile (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





	/// <summary>Field accessor for parameter []</summary>
	public virtual String Identifier {
		get => _Data[0] as String;
		set => _Data[0]  = value;
		}

	public virtual string _Identifier {
		set => _Data[0].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual ExistingFile File {
		get => _Data[1] as ExistingFile;
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[4].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[5] as Flag;
		set => _Data[5]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "export",
		Brief =  "Export contact entry from file",
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
				Brief = "File containing the contact entry to add",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 4,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 5,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class ContactExport : _ContactExport {
    } // class ContactExport

public class _ContactDelete : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class ContactDelete : _ContactDelete {
    } // class ContactDelete

public class _ContactGet : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for option [encrypt]</summary>
	public virtual String Encrypt {
		get => _Data[8] as String;
		set => _Data[8]  = value;
		}

	public virtual string _Encrypt {
		set => _Data[8].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				},
			new DescribeEntryOption () {
				Identifier = "Encrypt", 
				Default = null, // null if null
				Brief = "Encrypt the contact under the specified key",
				Index = 8,
				Key = "encrypt"
				}
			}
		};

	}

public partial class ContactGet : _ContactGet {
    } // class ContactGet

public class _ContactDump : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class ContactDump : _ContactDump {
    } // class ContactDump

public class _BookmarkImport : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new ExistingFile (),
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [format]</summary>
	public virtual String Format {
		get => _Data[2] as String;
		set => _Data[2]  = value;
		}

	public virtual string _Format {
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[5] as Flag;
		set => _Data[5]  = value;
		}

	public virtual string _AutoSync {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "import",
		Brief =  "Add bookmark entry from file",
		HandleDelegate =  CommandLineInterpreter.Handle_BookmarkImport,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "File", 
				Default = null, // null if null
				Brief = "File containing the bookmark entry to add",
				Index = 0,
				Key = ""
				},
			new DescribeEntryOption () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "Unique entry identifier",
				Index = 1,
				Key = "id"
				},
			new DescribeEntryOption () {
				Identifier = "Format", 
				Default = null, // null if null
				Brief = "Specifies the file format.",
				Index = 2,
				Key = "format"
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 5,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 6,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class BookmarkImport : _BookmarkImport {
    } // class BookmarkImport

public class _BookmarkAdd : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
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
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [uid]</summary>
	public virtual String Unique {
		get => _Data[2] as String;
		set => _Data[2]  = value;
		}

	public virtual string _Unique {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [id]</summary>
	public virtual String Identifier {
		get => _Data[3] as String;
		set => _Data[3]  = value;
		}

	public virtual string _Identifier {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [abstract]</summary>
	public virtual String Abstract {
		get => _Data[4] as String;
		set => _Data[4]  = value;
		}

	public virtual string _Abstract {
		set => _Data[4].Parameter (value);
		}
	/// <summary>Field accessor for option [comment]</summary>
	public virtual String Comment {
		get => _Data[5] as String;
		set => _Data[5]  = value;
		}

	public virtual string _Comment {
		set => _Data[5].Parameter (value);
		}
	/// <summary>Field accessor for option [react]</summary>
	public virtual String React {
		get => _Data[6] as String;
		set => _Data[6]  = value;
		}

	public virtual string _React {
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[9] as Flag;
		set => _Data[9]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[9].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[10] as Flag;
		set => _Data[10]  = value;
		}

	public virtual string _AutoApprove {
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
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "add",
		Brief =  "Add bookmark entry from specified parameters",
		HandleDelegate =  CommandLineInterpreter.Handle_BookmarkAdd,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Uri", 
				Default = null, // null if null
				Brief = "The recorded link",
				Index = 0,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Title", 
				Default = null, // null if null
				Brief = "Title of the recorded item",
				Index = 1,
				Key = ""
				},
			new DescribeEntryOption () {
				Identifier = "Unique", 
				Default = null, // null if null
				Brief = "Unique identifier",
				Index = 2,
				Key = "uid"
				},
			new DescribeEntryOption () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "Local identifier",
				Index = 3,
				Key = "id"
				},
			new DescribeEntryOption () {
				Identifier = "Abstract", 
				Default = null, // null if null
				Brief = "Abstract of the recorded item",
				Index = 4,
				Key = "abstract"
				},
			new DescribeEntryOption () {
				Identifier = "Comment", 
				Default = null, // null if null
				Brief = "Comment on reason for adding",
				Index = 5,
				Key = "comment"
				},
			new DescribeEntryOption () {
				Identifier = "React", 
				Default = null, // null if null
				Brief = "Reactions to the recorded item",
				Index = 6,
				Key = "react"
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 9,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 10,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				}
			}
		};

	}

public partial class BookmarkAdd : _BookmarkAdd {
    } // class BookmarkAdd

public class _BookmarkDelete : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[4].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[5] as Flag;
		set => _Data[5]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 4,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 5,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class BookmarkDelete : _BookmarkDelete {
    } // class BookmarkDelete

public class _BookmarkGet : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "get",
		Brief =  "Lookup bookmark entry",
		HandleDelegate =  CommandLineInterpreter.Handle_BookmarkGet,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "The unique entry identifier",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class BookmarkGet : _BookmarkGet {
    } // class BookmarkGet

public class _BookmarkDump : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class BookmarkDump : _BookmarkDump {
    } // class BookmarkDump

public class _CalendarImport : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new ExistingFile (),
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [format]</summary>
	public virtual String Format {
		get => _Data[2] as String;
		set => _Data[2]  = value;
		}

	public virtual string _Format {
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[5] as Flag;
		set => _Data[5]  = value;
		}

	public virtual string _AutoSync {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "import",
		Brief =  "Add calendar entry from file",
		HandleDelegate =  CommandLineInterpreter.Handle_CalendarImport,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "File", 
				Default = null, // null if null
				Brief = "File containing the calendar entry to add",
				Index = 0,
				Key = ""
				},
			new DescribeEntryOption () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "Unique entry identifier",
				Index = 1,
				Key = "id"
				},
			new DescribeEntryOption () {
				Identifier = "Format", 
				Default = null, // null if null
				Brief = "Specifies the file format.",
				Index = 2,
				Key = "format"
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 5,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 6,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class CalendarImport : _CalendarImport {
    } // class CalendarImport

public class _CalendarAdd : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[4].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[5] as Flag;
		set => _Data[5]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "add",
		Brief =  "Add calendar entry",
		HandleDelegate =  CommandLineInterpreter.Handle_CalendarAdd,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Title", 
				Default = null, // null if null
				Brief = "The entry title.",
				Index = 0,
				Key = ""
				},
			new DescribeEntryOption () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "Local identifier",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 4,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 5,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class CalendarAdd : _CalendarAdd {
    } // class CalendarAdd

public class _CalendarGet : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "get",
		Brief =  "Lookup calendar entry",
		HandleDelegate =  CommandLineInterpreter.Handle_CalendarGet,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "Unique entry identifier",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class CalendarGet : _CalendarGet {
    } // class CalendarGet

public class _CalendarDelete : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "delete",
		Brief =  "Delete calendar entry",
		HandleDelegate =  CommandLineInterpreter.Handle_CalendarDelete,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "Unique entry identifier",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class CalendarDelete : _CalendarDelete {
    } // class CalendarDelete

public class _CalendarDump : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class CalendarDump : _CalendarDump {
    } // class CalendarDump

public class _NetworkImport : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new ExistingFile (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[4].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[5] as Flag;
		set => _Data[5]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "import",
		Brief =  "Add network entry from file",
		HandleDelegate =  CommandLineInterpreter.Handle_NetworkImport,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "File", 
				Default = null, // null if null
				Brief = "File containing the network entry to add",
				Index = 0,
				Key = ""
				},
			new DescribeEntryOption () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "Unique entry identifier",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 4,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 5,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class NetworkImport : _NetworkImport {
    } // class NetworkImport

public class _NetworkAdd : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new ExistingFile (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





	/// <summary>Field accessor for parameter []</summary>
	public virtual String SSID {
		get => _Data[0] as String;
		set => _Data[0]  = value;
		}

	public virtual string _SSID {
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
	/// <summary>Field accessor for option [id]</summary>
	public virtual String Identifier {
		get => _Data[2] as String;
		set => _Data[2]  = value;
		}

	public virtual string _Identifier {
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[5] as Flag;
		set => _Data[5]  = value;
		}

	public virtual string _AutoSync {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "add",
		Brief =  "Add network entry ",
		HandleDelegate =  CommandLineInterpreter.Handle_NetworkAdd,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "SSID", 
				Default = null, // null if null
				Brief = "WiFi SSID parameter",
				Index = 0,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Password", 
				Default = null, // null if null
				Brief = "Password value",
				Index = 1,
				Key = ""
				},
			new DescribeEntryOption () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "Local identifier",
				Index = 2,
				Key = "id"
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 5,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 6,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class NetworkAdd : _NetworkAdd {
    } // class NetworkAdd

public class _NetworkGet : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "get",
		Brief =  "Lookup calendar entry",
		HandleDelegate =  CommandLineInterpreter.Handle_NetworkGet,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "Local identifier",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class NetworkGet : _NetworkGet {
    } // class NetworkGet

public class _NetworkDelete : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class NetworkDelete : _NetworkDelete {
    } // class NetworkDelete

public class _NetworkList : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "list",
		Brief =  "List network entries",
		HandleDelegate =  CommandLineInterpreter.Handle_NetworkList,
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class NetworkList : _NetworkList {
    } // class NetworkList

public class _KeyNonce : Goedel.Command.Dispatch ,
						IReporting,
						ILengthOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new Flag (),
		new Flag (),
		new Flag (),
		new Integer ()		} ;





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
	/// <summary>Field accessor for option [bits]</summary>
	public virtual Integer Bits {
		get => _Data[3] as Integer;
		set => _Data[3]  = value;
		}

	public virtual string _Bits {
		set => _Data[3].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "nonce",
		Brief =  "Return a randomized nonce value formatted as a UDF Nonce Type",
		HandleDelegate =  CommandLineInterpreter.Handle_KeyNonce,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				},
			new DescribeEntryOption () {
				Identifier = "Bits", 
				Default = null, // null if null
				Brief = "Secret size in bits",
				Index = 3,
				Key = "bits"
				}
			}
		};

	}

public partial class KeyNonce : _KeyNonce {
    } // class KeyNonce

public class _KeySecret : Goedel.Command.Dispatch ,
						IReporting,
						ILengthOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new Flag (),
		new Flag (),
		new Flag (),
		new Integer ()		} ;





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
	/// <summary>Field accessor for option [bits]</summary>
	public virtual Integer Bits {
		get => _Data[3] as Integer;
		set => _Data[3]  = value;
		}

	public virtual string _Bits {
		set => _Data[3].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "secret",
		Brief =  "Return a randomized secret value formatted as a UDF Encryption Key Type.",
		HandleDelegate =  CommandLineInterpreter.Handle_KeySecret,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				},
			new DescribeEntryOption () {
				Identifier = "Bits", 
				Default = null, // null if null
				Brief = "Secret size in bits",
				Index = 3,
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
						ILengthOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new Integer ()		} ;





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
	/// <summary>Field accessor for option [key]</summary>
	public virtual String DigestKey {
		get => _Data[3] as String;
		set => _Data[3]  = value;
		}

	public virtual string _DigestKey {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "earl",
		Brief =  "Return a randomized secret value and locator as UDFs",
		HandleDelegate =  CommandLineInterpreter.Handle_KeyEarl,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				},
			new DescribeEntryOption () {
				Identifier = "DigestKey", 
				Default = null, // null if null
				Brief = "Encrypt data for specified recipient",
				Index = 3,
				Key = "key"
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

public partial class KeyEarl : _KeyEarl {
    } // class KeyEarl

public class _KeyShare : Goedel.Command.Dispatch ,
						IReporting,
						IDigestOptions,
						ILengthOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new Integer (),
		new String (),
		new Integer (),
		new Integer ()		} ;





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
	/// <summary>Field accessor for option [key]</summary>
	public virtual String DigestKey {
		get => _Data[3] as String;
		set => _Data[3]  = value;
		}

	public virtual string _DigestKey {
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
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Secret {
		get => _Data[5] as String;
		set => _Data[5]  = value;
		}

	public virtual string _Secret {
		set => _Data[5].Parameter (value);
		}
	/// <summary>Field accessor for option [quorum]</summary>
	public virtual Integer Quorum {
		get => _Data[6] as Integer;
		set => _Data[6]  = value;
		}

	public virtual string _Quorum {
		set => _Data[6].Parameter (value);
		}
	/// <summary>Field accessor for option [shares]</summary>
	public virtual Integer Shares {
		get => _Data[7] as Integer;
		set => _Data[7]  = value;
		}

	public virtual string _Shares {
		set => _Data[7].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "share",
		Brief =  "Split a secret value according to the specified shares and quorum",
		HandleDelegate =  CommandLineInterpreter.Handle_KeyShare,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				},
			new DescribeEntryOption () {
				Identifier = "DigestKey", 
				Default = null, // null if null
				Brief = "Encrypt data for specified recipient",
				Index = 3,
				Key = "key"
				},
			new DescribeEntryOption () {
				Identifier = "Bits", 
				Default = null, // null if null
				Brief = "Secret size in bits",
				Index = 4,
				Key = "bits"
				},
			new DescribeEntryParameter () {
				Identifier = "Secret", 
				Default = null, // null if null
				Brief = "The parameter to share",
				Index = 5,
				Key = ""
				},
			new DescribeEntryOption () {
				Identifier = "Quorum", 
				Default = "2", // null if null
				Brief = "The number of shares required to recover the secret",
				Index = 6,
				Key = "quorum"
				},
			new DescribeEntryOption () {
				Identifier = "Shares", 
				Default = "3", // null if null
				Brief = "The number of shares to create",
				Index = 7,
				Key = "shares"
				}
			}
		};

	}

public partial class KeyShare : _KeyShare {
    } // class KeyShare

public class _KeyRecover : Goedel.Command.Dispatch ,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
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
		new String ()		} ;





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
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Share1 {
		get => _Data[3] as String;
		set => _Data[3]  = value;
		}

	public virtual string _Share1 {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Share2 {
		get => _Data[4] as String;
		set => _Data[4]  = value;
		}

	public virtual string _Share2 {
		set => _Data[4].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Share3 {
		get => _Data[5] as String;
		set => _Data[5]  = value;
		}

	public virtual string _Share3 {
		set => _Data[5].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Share4 {
		get => _Data[6] as String;
		set => _Data[6]  = value;
		}

	public virtual string _Share4 {
		set => _Data[6].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Share5 {
		get => _Data[7] as String;
		set => _Data[7]  = value;
		}

	public virtual string _Share5 {
		set => _Data[7].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Share6 {
		get => _Data[8] as String;
		set => _Data[8]  = value;
		}

	public virtual string _Share6 {
		set => _Data[8].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Share7 {
		get => _Data[9] as String;
		set => _Data[9]  = value;
		}

	public virtual string _Share7 {
		set => _Data[9].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Share8 {
		get => _Data[10] as String;
		set => _Data[10]  = value;
		}

	public virtual string _Share8 {
		set => _Data[10].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "recover",
		Brief =  "Recover a secret value from the shares provided",
		HandleDelegate =  CommandLineInterpreter.Handle_KeyRecover,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				},
			new DescribeEntryParameter () {
				Identifier = "Share1", 
				Default = null, // null if null
				Brief = "Share value #1",
				Index = 3,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Share2", 
				Default = null, // null if null
				Brief = "Share value #2",
				Index = 4,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Share3", 
				Default = null, // null if null
				Brief = "Share value #3",
				Index = 5,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Share4", 
				Default = null, // null if null
				Brief = "Share value #4",
				Index = 6,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Share5", 
				Default = null, // null if null
				Brief = "Share value #5",
				Index = 7,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Share6", 
				Default = null, // null if null
				Brief = "Share value #6",
				Index = 8,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Share7", 
				Default = null, // null if null
				Brief = "Share value #7",
				Index = 9,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Share8", 
				Default = null, // null if null
				Brief = "Share value #8",
				Index = 10,
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
						ILengthOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new Integer (),
		new String (),
		new String (),
		new ExistingFile ()		} ;





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
	/// <summary>Field accessor for option [alg]</summary>
	public virtual String Algorithms {
		get => _Data[3] as String;
		set => _Data[3]  = value;
		}

	public virtual string _Algorithms {
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
	/// <summary>Field accessor for option [cty]</summary>
	public virtual String ContentType {
		get => _Data[5] as String;
		set => _Data[5]  = value;
		}

	public virtual string _ContentType {
		set => _Data[5].Parameter (value);
		}
	/// <summary>Field accessor for option [expect]</summary>
	public virtual String Expect {
		get => _Data[6] as String;
		set => _Data[6]  = value;
		}

	public virtual string _Expect {
		set => _Data[6].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual ExistingFile Input {
		get => _Data[7] as ExistingFile;
		set => _Data[7]  = value;
		}

	public virtual string _Input {
		set => _Data[7].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "udf",
		Brief =  "Calculate the Uniform Data Fingerprint of the input data",
		HandleDelegate =  CommandLineInterpreter.Handle_HashUDF,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				},
			new DescribeEntryOption () {
				Identifier = "Algorithms", 
				Default = null, // null if null
				Brief = "List of algorithm specifiers",
				Index = 3,
				Key = "alg"
				},
			new DescribeEntryOption () {
				Identifier = "Bits", 
				Default = null, // null if null
				Brief = "Secret size in bits",
				Index = 4,
				Key = "bits"
				},
			new DescribeEntryOption () {
				Identifier = "ContentType", 
				Default = null, // null if null
				Brief = "Content Type",
				Index = 5,
				Key = "cty"
				},
			new DescribeEntryOption () {
				Identifier = "Expect", 
				Default = null, // null if null
				Brief = "Expected value",
				Index = 6,
				Key = "expect"
				},
			new DescribeEntryParameter () {
				Identifier = "Input", 
				Default = null, // null if null
				Brief = "File to take digest of",
				Index = 7,
				Key = ""
				}
			}
		};

	}

public partial class HashUDF : _HashUDF {
    } // class HashUDF

public class _HashDigest : Goedel.Command.Dispatch ,
						IReporting,
						ICryptoOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new ExistingFile ()		} ;





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
	/// <summary>Field accessor for option [alg]</summary>
	public virtual String Algorithms {
		get => _Data[3] as String;
		set => _Data[3]  = value;
		}

	public virtual string _Algorithms {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual ExistingFile Input {
		get => _Data[4] as ExistingFile;
		set => _Data[4]  = value;
		}

	public virtual string _Input {
		set => _Data[4].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "digest",
		Brief =  "Calculate the digest value of the input data",
		HandleDelegate =  CommandLineInterpreter.Handle_HashDigest,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				},
			new DescribeEntryOption () {
				Identifier = "Algorithms", 
				Default = null, // null if null
				Brief = "List of algorithm specifiers",
				Index = 3,
				Key = "alg"
				},
			new DescribeEntryParameter () {
				Identifier = "Input", 
				Default = null, // null if null
				Brief = "File to take digest of",
				Index = 4,
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
						ILengthOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new Integer (),
		new String (),
		new String (),
		new String (),
		new ExistingFile ()		} ;





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
	/// <summary>Field accessor for option [alg]</summary>
	public virtual String Algorithms {
		get => _Data[3] as String;
		set => _Data[3]  = value;
		}

	public virtual string _Algorithms {
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
	/// <summary>Field accessor for option [cty]</summary>
	public virtual String ContentType {
		get => _Data[5] as String;
		set => _Data[5]  = value;
		}

	public virtual string _ContentType {
		set => _Data[5].Parameter (value);
		}
	/// <summary>Field accessor for option [key]</summary>
	public virtual String DigestKey {
		get => _Data[6] as String;
		set => _Data[6]  = value;
		}

	public virtual string _DigestKey {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "mac",
		Brief =  "Calculate a commitment value for the input data",
		HandleDelegate =  CommandLineInterpreter.Handle_HashMac,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				},
			new DescribeEntryOption () {
				Identifier = "Algorithms", 
				Default = null, // null if null
				Brief = "List of algorithm specifiers",
				Index = 3,
				Key = "alg"
				},
			new DescribeEntryOption () {
				Identifier = "Bits", 
				Default = null, // null if null
				Brief = "Secret size in bits",
				Index = 4,
				Key = "bits"
				},
			new DescribeEntryOption () {
				Identifier = "ContentType", 
				Default = null, // null if null
				Brief = "Content Type",
				Index = 5,
				Key = "cty"
				},
			new DescribeEntryOption () {
				Identifier = "DigestKey", 
				Default = null, // null if null
				Brief = "Specifies the value of the key",
				Index = 6,
				Key = "key"
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
				Brief = "File to create commitment of",
				Index = 8,
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
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new ExistingFile (),
		new NewFile (),
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new ExistingFile (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String ()		} ;





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
	/// <summary>Field accessor for option [self]</summary>
	public virtual String Self {
		get => _Data[4] as String;
		set => _Data[4]  = value;
		}

	public virtual string _Self {
		set => _Data[4].Parameter (value);
		}
	/// <summary>Field accessor for option [sign]</summary>
	public virtual String Sign {
		get => _Data[5] as String;
		set => _Data[5]  = value;
		}

	public virtual string _Sign {
		set => _Data[5].Parameter (value);
		}
	/// <summary>Field accessor for option [hash]</summary>
	public virtual Flag Hash {
		get => _Data[6] as Flag;
		set => _Data[6]  = value;
		}

	public virtual string _Hash {
		set => _Data[6].Parameter (value);
		}
	/// <summary>Field accessor for option [cover]</summary>
	public virtual ExistingFile Cover {
		get => _Data[7] as ExistingFile;
		set => _Data[7]  = value;
		}

	public virtual string _Cover {
		set => _Data[7].Parameter (value);
		}
	/// <summary>Field accessor for option [alg]</summary>
	public virtual String Algorithms {
		get => _Data[8] as String;
		set => _Data[8]  = value;
		}

	public virtual string _Algorithms {
		set => _Data[8].Parameter (value);
		}
	/// <summary>Field accessor for option [account]</summary>
	public virtual String AccountAddress {
		get => _Data[9] as String;
		set => _Data[9]  = value;
		}

	public virtual string _AccountAddress {
		set => _Data[9].Parameter (value);
		}
	/// <summary>Field accessor for option [local]</summary>
	public virtual String LocalName {
		get => _Data[10] as String;
		set => _Data[10]  = value;
		}

	public virtual string _LocalName {
		set => _Data[10].Parameter (value);
		}
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[11] as Flag;
		set => _Data[11]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[11].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[12] as Flag;
		set => _Data[12]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for option [sub]</summary>
	public virtual Flag Subdirectories {
		get => _Data[16] as Flag;
		set => _Data[16]  = value;
		}

	public virtual string _Subdirectories {
		set => _Data[16].Parameter (value);
		}
	/// <summary>Field accessor for option [key]</summary>
	public virtual String SymmetrictKey {
		get => _Data[17] as String;
		set => _Data[17]  = value;
		}

	public virtual string _SymmetrictKey {
		set => _Data[17].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
				Identifier = "Self", 
				Default = null, // null if null
				Brief = "Encrypt a copy of the data for self",
				Index = 4,
				Key = "self"
				},
			new DescribeEntryOption () {
				Identifier = "Sign", 
				Default = null, // null if null
				Brief = "Sign data with specified key",
				Index = 5,
				Key = "sign"
				},
			new DescribeEntryOption () {
				Identifier = "Hash", 
				Default = "true", // null if null
				Brief = "Compute hash of content",
				Index = 6,
				Key = "hash"
				},
			new DescribeEntryOption () {
				Identifier = "Cover", 
				Default = null, // null if null
				Brief = "File containing a cover to be added to encrypted files",
				Index = 7,
				Key = "cover"
				},
			new DescribeEntryOption () {
				Identifier = "Algorithms", 
				Default = null, // null if null
				Brief = "List of algorithm specifiers",
				Index = 8,
				Key = "alg"
				},
			new DescribeEntryOption () {
				Identifier = "AccountAddress", 
				Default = null, // null if null
				Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
				Index = 9,
				Key = "account"
				},
			new DescribeEntryOption () {
				Identifier = "LocalName", 
				Default = null, // null if null
				Brief = "Local name for account (e.g. personal)",
				Index = 10,
				Key = "local"
				},
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 11,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 12,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				Identifier = "Subdirectories", 
				Default = null, // null if null
				Brief = "Process subdirectories recursively.",
				Index = 16,
				Key = "sub"
				},
			new DescribeEntryOption () {
				Identifier = "SymmetrictKey", 
				Default = null, // null if null
				Brief = "Specifies the value of the master key",
				Index = 17,
				Key = "key"
				}
			}
		};

	}

public partial class DareEncode : _DareEncode {
    } // class DareEncode

public class _DareDecode : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new ExistingFile (),
		new NewFile (),
		new String (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for parameter []</summary>
	public virtual ExistingFile Input {
		get => _Data[7] as ExistingFile;
		set => _Data[7]  = value;
		}

	public virtual string _Input {
		set => _Data[7].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual NewFile Output {
		get => _Data[8] as NewFile;
		set => _Data[8]  = value;
		}

	public virtual string _Output {
		set => _Data[8].Parameter (value);
		}
	/// <summary>Field accessor for option [key]</summary>
	public virtual String SymmetrictKey {
		get => _Data[9] as String;
		set => _Data[9]  = value;
		}

	public virtual string _SymmetrictKey {
		set => _Data[9].Parameter (value);
		}
	/// <summary>Field accessor for option [verify]</summary>
	public virtual Flag Verify {
		get => _Data[10] as Flag;
		set => _Data[10]  = value;
		}

	public virtual string _Verify {
		set => _Data[10].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
			new DescribeEntryParameter () {
				Identifier = "Input", 
				Default = null, // null if null
				Brief = "Encrypted File",
				Index = 7,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Output", 
				Default = null, // null if null
				Brief = "Decrypted File",
				Index = 8,
				Key = ""
				},
			new DescribeEntryOption () {
				Identifier = "SymmetrictKey", 
				Default = null, // null if null
				Brief = "Specifies the value of the master key",
				Index = 9,
				Key = "key"
				},
			new DescribeEntryOption () {
				Identifier = "Verify", 
				Default = "false", // null if null
				Brief = "Verify the message digest and signature if present.",
				Index = 10,
				Key = "verify"
				}
			}
		};

	}

public partial class DareDecode : _DareDecode {
    } // class DareDecode

public class _DareVerify : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new ExistingFile (),
		new String ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for parameter []</summary>
	public virtual ExistingFile Input {
		get => _Data[7] as ExistingFile;
		set => _Data[7]  = value;
		}

	public virtual string _Input {
		set => _Data[7].Parameter (value);
		}
	/// <summary>Field accessor for option [key]</summary>
	public virtual String SymmetricKey {
		get => _Data[8] as String;
		set => _Data[8]  = value;
		}

	public virtual string _SymmetricKey {
		set => _Data[8].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
			new DescribeEntryParameter () {
				Identifier = "Input", 
				Default = null, // null if null
				Brief = "Encrypted File",
				Index = 7,
				Key = ""
				},
			new DescribeEntryOption () {
				Identifier = "SymmetricKey", 
				Default = null, // null if null
				Brief = "Specifies the value of the master key",
				Index = 8,
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
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new ExistingFile (),
		new String (),
		new ExistingFile (),
		new Flag (),
		new String (),
		new ExistingFile (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[9] as Flag;
		set => _Data[9]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[9].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[10] as Flag;
		set => _Data[10]  = value;
		}

	public virtual string _AutoApprove {
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
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 9,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 10,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				}
			}
		};

	}

public partial class DareEARL : _DareEARL {
    } // class DareEARL

public class _ArchiveCreate : Goedel.Command.Dispatch ,
						IEncodeOptions,
						ICryptoOptions,
						IAccountOptions,
						IReporting,
						ISequenceOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new ExistingFile (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new Enumeration<EnumAuthentication> (CommandLineInterpreter.DescribeEnumAuthentication),
		new Enumeration<EnumUse> (CommandLineInterpreter.DescribeEnumUse),
		new NewFile (),
		new ExistingFile (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [self]</summary>
	public virtual String Self {
		get => _Data[2] as String;
		set => _Data[2]  = value;
		}

	public virtual string _Self {
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
	/// <summary>Field accessor for option [cover]</summary>
	public virtual ExistingFile Cover {
		get => _Data[5] as ExistingFile;
		set => _Data[5]  = value;
		}

	public virtual string _Cover {
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[9] as Flag;
		set => _Data[9]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[9].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[10] as Flag;
		set => _Data[10]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for option [type]</summary>
	public virtual String Type {
		get => _Data[14] as String;
		set => _Data[14]  = value;
		}

	public virtual string _Type {
		set => _Data[14].Parameter (value);
		}
	/// <summary>Field accessor for parameter [auth]</summary>
	public virtual Enumeration<EnumAuthentication> EnumAuthentication {
		get => _Data[15] as Enumeration<EnumAuthentication>;
		set => _Data[15]  = value;
		}

	public virtual string _EnumAuthentication {
		set => _Data[15].Parameter (value);
		}
	/// <summary>Field accessor for parameter [use]</summary>
	public virtual Enumeration<EnumUse> EnumUse {
		get => _Data[16] as Enumeration<EnumUse>;
		set => _Data[16]  = value;
		}

	public virtual string _EnumUse {
		set => _Data[16].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual NewFile Archive {
		get => _Data[17] as NewFile;
		set => _Data[17]  = value;
		}

	public virtual string _Archive {
		set => _Data[17].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual ExistingFile Input {
		get => _Data[18] as ExistingFile;
		set => _Data[18]  = value;
		}

	public virtual string _Input {
		set => _Data[18].Parameter (value);
		}
	/// <summary>Field accessor for option [index]</summary>
	public virtual Flag Index {
		get => _Data[19] as Flag;
		set => _Data[19]  = value;
		}

	public virtual string _Index {
		set => _Data[19].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "create",
		Brief =  "Create a new DARE archive and add the specified files",
		HandleDelegate =  CommandLineInterpreter.Handle_ArchiveCreate,
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
				Identifier = "Self", 
				Default = null, // null if null
				Brief = "Encrypt a copy of the data for self",
				Index = 2,
				Key = "self"
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
				Identifier = "Cover", 
				Default = null, // null if null
				Brief = "File containing a cover to be added to encrypted files",
				Index = 5,
				Key = "cover"
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 9,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 10,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				Identifier = "Type", 
				Default = null, // null if null
				Brief = "The sequence type, plain/tree/digest/chain/tree",
				Index = 14,
				Key = "type"
				},
			new DescribeEntryEnumerate () {
				Identifier = "EnumAuthentication", 
				Default = null, // null if null
				Brief = "Authentication and indexing",
				Index = 15,
				Key = "auth"
				},
			new DescribeEntryEnumerate () {
				Identifier = "EnumUse", 
				Default = null, // null if null
				Brief = "<Unspecified>",
				Index = 16,
				Key = "use"
				},
			new DescribeEntryParameter () {
				Identifier = "Archive", 
				Default = null, // null if null
				Brief = "Filename for encrypted output.",
				Index = 17,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Input", 
				Default = null, // null if null
				Brief = "Directory containing files to create archive from",
				Index = 18,
				Key = ""
				},
			new DescribeEntryOption () {
				Identifier = "Index", 
				Default = "true", // null if null
				Brief = "Append index to the archive",
				Index = 19,
				Key = "index"
				}
			}
		};

	}

public partial class ArchiveCreate : _ArchiveCreate {
    } // class ArchiveCreate

public class _ArchiveAppend : Goedel.Command.Dispatch ,
						IEncodeOptions,
						ICryptoOptions,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new ExistingFile (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new ExistingFile (),
		new NewFile (),
		new String (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [self]</summary>
	public virtual String Self {
		get => _Data[2] as String;
		set => _Data[2]  = value;
		}

	public virtual string _Self {
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
	/// <summary>Field accessor for option [cover]</summary>
	public virtual ExistingFile Cover {
		get => _Data[5] as ExistingFile;
		set => _Data[5]  = value;
		}

	public virtual string _Cover {
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[9] as Flag;
		set => _Data[9]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[9].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[10] as Flag;
		set => _Data[10]  = value;
		}

	public virtual string _AutoApprove {
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
	public virtual ExistingFile Archive {
		get => _Data[14] as ExistingFile;
		set => _Data[14]  = value;
		}

	public virtual string _Archive {
		set => _Data[14].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual NewFile File {
		get => _Data[15] as NewFile;
		set => _Data[15]  = value;
		}

	public virtual string _File {
		set => _Data[15].Parameter (value);
		}
	/// <summary>Field accessor for option [id]</summary>
	public virtual String Id {
		get => _Data[16] as String;
		set => _Data[16]  = value;
		}

	public virtual string _Id {
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
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "append",
		Brief =  "Append the specified file as an entry to the specified sequence.",
		HandleDelegate =  CommandLineInterpreter.Handle_ArchiveAppend,
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
				Identifier = "Self", 
				Default = null, // null if null
				Brief = "Encrypt a copy of the data for self",
				Index = 2,
				Key = "self"
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
				Identifier = "Cover", 
				Default = null, // null if null
				Brief = "File containing a cover to be added to encrypted files",
				Index = 5,
				Key = "cover"
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 9,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 10,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				Identifier = "Archive", 
				Default = null, // null if null
				Brief = "Sequence to append to",
				Index = 14,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "File", 
				Default = null, // null if null
				Brief = "File to append",
				Index = 15,
				Key = ""
				},
			new DescribeEntryOption () {
				Identifier = "Id", 
				Default = null, // null if null
				Brief = "Identifier of the file in the sequence",
				Index = 16,
				Key = "id"
				},
			new DescribeEntryOption () {
				Identifier = "Index", 
				Default = "false", // null if null
				Brief = "Append index to the archive",
				Index = 17,
				Key = "index"
				}
			}
		};

	}

public partial class ArchiveAppend : _ArchiveAppend {
    } // class ArchiveAppend

public class _ArchiveDelete : Goedel.Command.Dispatch ,
						IAccountOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new ExistingFile (),
		new String (),
		new String (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual ExistingFile Archive {
		get => _Data[4] as ExistingFile;
		set => _Data[4]  = value;
		}

	public virtual string _Archive {
		set => _Data[4].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Filename {
		get => _Data[5] as String;
		set => _Data[5]  = value;
		}

	public virtual string _Filename {
		set => _Data[5].Parameter (value);
		}
	/// <summary>Field accessor for option [key]</summary>
	public virtual String Key {
		get => _Data[6] as String;
		set => _Data[6]  = value;
		}

	public virtual string _Key {
		set => _Data[6].Parameter (value);
		}
	/// <summary>Field accessor for option [erase]</summary>
	public virtual Flag Erase {
		get => _Data[7] as Flag;
		set => _Data[7]  = value;
		}

	public virtual string _Erase {
		set => _Data[7].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "delete",
		Brief =  "Delete file from archive index.",
		HandleDelegate =  CommandLineInterpreter.Handle_ArchiveDelete,
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryParameter () {
				Identifier = "Archive", 
				Default = null, // null if null
				Brief = "Sequence to append to",
				Index = 4,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Filename", 
				Default = null, // null if null
				Brief = "Name of file to delete",
				Index = 5,
				Key = ""
				},
			new DescribeEntryOption () {
				Identifier = "Key", 
				Default = null, // null if null
				Brief = "<Unspecified>",
				Index = 6,
				Key = "key"
				},
			new DescribeEntryOption () {
				Identifier = "Erase", 
				Default = "false", // null if null
				Brief = "If true, erase file from container preventing recovery.",
				Index = 7,
				Key = "erase"
				}
			}
		};

	}

public partial class ArchiveDelete : _ArchiveDelete {
    } // class ArchiveDelete

public class _ArchiveIndex : Goedel.Command.Dispatch ,
						IEncodeOptions,
						ICryptoOptions,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new ExistingFile (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new ExistingFile ()		} ;





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
	/// <summary>Field accessor for option [self]</summary>
	public virtual String Self {
		get => _Data[2] as String;
		set => _Data[2]  = value;
		}

	public virtual string _Self {
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
	/// <summary>Field accessor for option [cover]</summary>
	public virtual ExistingFile Cover {
		get => _Data[5] as ExistingFile;
		set => _Data[5]  = value;
		}

	public virtual string _Cover {
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[9] as Flag;
		set => _Data[9]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[9].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[10] as Flag;
		set => _Data[10]  = value;
		}

	public virtual string _AutoApprove {
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
	public virtual ExistingFile Archive {
		get => _Data[14] as ExistingFile;
		set => _Data[14]  = value;
		}

	public virtual string _Archive {
		set => _Data[14].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "index",
		Brief =  "Compile an index for the specified sequence and append to the end.",
		HandleDelegate =  CommandLineInterpreter.Handle_ArchiveIndex,
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
				Identifier = "Self", 
				Default = null, // null if null
				Brief = "Encrypt a copy of the data for self",
				Index = 2,
				Key = "self"
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
				Identifier = "Cover", 
				Default = null, // null if null
				Brief = "File containing a cover to be added to encrypted files",
				Index = 5,
				Key = "cover"
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 9,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 10,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				Identifier = "Archive", 
				Default = null, // null if null
				Brief = "Sequence to be indexed",
				Index = 14,
				Key = ""
				}
			}
		};

	}

public partial class ArchiveIndex : _ArchiveIndex {
    } // class ArchiveIndex

public class _ArchiveDir : Goedel.Command.Dispatch ,
						IReporting,
						IAccountOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new ExistingFile ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[5] as Flag;
		set => _Data[5]  = value;
		}

	public virtual string _AutoSync {
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
	/// <summary>Field accessor for parameter []</summary>
	public virtual ExistingFile Archive {
		get => _Data[7] as ExistingFile;
		set => _Data[7]  = value;
		}

	public virtual string _Archive {
		set => _Data[7].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "dir",
		Brief =  "Compile a catalog for the specified sequence.",
		HandleDelegate =  CommandLineInterpreter.Handle_ArchiveDir,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 5,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 6,
				Key = "auto"
				},
			new DescribeEntryParameter () {
				Identifier = "Archive", 
				Default = null, // null if null
				Brief = "Sequence to be cataloged",
				Index = 7,
				Key = ""
				}
			}
		};

	}

public partial class ArchiveDir : _ArchiveDir {
    } // class ArchiveDir

public class _ArchiveExtract : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new ExistingFile (),
		new NewFile (),
		new Integer (),
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





	/// <summary>Field accessor for parameter []</summary>
	public virtual ExistingFile Archive {
		get => _Data[0] as ExistingFile;
		set => _Data[0]  = value;
		}

	public virtual string _Archive {
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
	/// <summary>Field accessor for option [record]</summary>
	public virtual Integer Record {
		get => _Data[2] as Integer;
		set => _Data[2]  = value;
		}

	public virtual string _Record {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [out]</summary>
	public virtual String Out {
		get => _Data[3] as String;
		set => _Data[3]  = value;
		}

	public virtual string _Out {
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[7] as Flag;
		set => _Data[7]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[7].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[8] as Flag;
		set => _Data[8]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for option [recover]</summary>
	public virtual Flag Recover {
		get => _Data[12] as Flag;
		set => _Data[12]  = value;
		}

	public virtual string _Recover {
		set => _Data[12].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "extract",
		Brief =  "Extract the specified record from the sequence",
		HandleDelegate =  CommandLineInterpreter.Handle_ArchiveExtract,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Archive", 
				Default = null, // null if null
				Brief = "Sequence to read",
				Index = 0,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "File", 
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
				Identifier = "Out", 
				Default = null, // null if null
				Brief = "Name of file to extract",
				Index = 3,
				Key = "out"
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 7,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 8,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				Identifier = "Recover", 
				Default = "false", // null if null
				Brief = "If true, return deleted files.",
				Index = 12,
				Key = "recover"
				}
			}
		};

	}

public partial class ArchiveExtract : _ArchiveExtract {
    } // class ArchiveExtract

public class _ArchiveCopy : Goedel.Command.Dispatch ,
						IEncodeOptions,
						ICryptoOptions,
						ISequenceOptions,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new ExistingFile (),
		new NewFile (),
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new ExistingFile (),
		new String (),
		new String (),
		new Enumeration<EnumAuthentication> (CommandLineInterpreter.DescribeEnumAuthentication),
		new Enumeration<EnumUse> (CommandLineInterpreter.DescribeEnumUse),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





	/// <summary>Field accessor for parameter []</summary>
	public virtual ExistingFile Archive {
		get => _Data[0] as ExistingFile;
		set => _Data[0]  = value;
		}

	public virtual string _Archive {
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
	/// <summary>Field accessor for option [self]</summary>
	public virtual String Self {
		get => _Data[4] as String;
		set => _Data[4]  = value;
		}

	public virtual string _Self {
		set => _Data[4].Parameter (value);
		}
	/// <summary>Field accessor for option [sign]</summary>
	public virtual String Sign {
		get => _Data[5] as String;
		set => _Data[5]  = value;
		}

	public virtual string _Sign {
		set => _Data[5].Parameter (value);
		}
	/// <summary>Field accessor for option [hash]</summary>
	public virtual Flag Hash {
		get => _Data[6] as Flag;
		set => _Data[6]  = value;
		}

	public virtual string _Hash {
		set => _Data[6].Parameter (value);
		}
	/// <summary>Field accessor for option [cover]</summary>
	public virtual ExistingFile Cover {
		get => _Data[7] as ExistingFile;
		set => _Data[7]  = value;
		}

	public virtual string _Cover {
		set => _Data[7].Parameter (value);
		}
	/// <summary>Field accessor for option [alg]</summary>
	public virtual String Algorithms {
		get => _Data[8] as String;
		set => _Data[8]  = value;
		}

	public virtual string _Algorithms {
		set => _Data[8].Parameter (value);
		}
	/// <summary>Field accessor for option [type]</summary>
	public virtual String Type {
		get => _Data[9] as String;
		set => _Data[9]  = value;
		}

	public virtual string _Type {
		set => _Data[9].Parameter (value);
		}
	/// <summary>Field accessor for parameter [auth]</summary>
	public virtual Enumeration<EnumAuthentication> EnumAuthentication {
		get => _Data[10] as Enumeration<EnumAuthentication>;
		set => _Data[10]  = value;
		}

	public virtual string _EnumAuthentication {
		set => _Data[10].Parameter (value);
		}
	/// <summary>Field accessor for parameter [use]</summary>
	public virtual Enumeration<EnumUse> EnumUse {
		get => _Data[11] as Enumeration<EnumUse>;
		set => _Data[11]  = value;
		}

	public virtual string _EnumUse {
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[14] as Flag;
		set => _Data[14]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[14].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[15] as Flag;
		set => _Data[15]  = value;
		}

	public virtual string _AutoApprove {
		set => _Data[15].Parameter (value);
		}
	/// <summary>Field accessor for option [verbose]</summary>
	public virtual Flag Verbose {
		get => _Data[16] as Flag;
		set => _Data[16]  = value;
		}

	public virtual string _Verbose {
		set => _Data[16].Parameter (value);
		}
	/// <summary>Field accessor for option [report]</summary>
	public virtual Flag Report {
		get => _Data[17] as Flag;
		set => _Data[17]  = value;
		}

	public virtual string _Report {
		set => _Data[17].Parameter (value);
		}
	/// <summary>Field accessor for option [json]</summary>
	public virtual Flag Json {
		get => _Data[18] as Flag;
		set => _Data[18]  = value;
		}

	public virtual string _Json {
		set => _Data[18].Parameter (value);
		}
	/// <summary>Field accessor for option [decrypt]</summary>
	public virtual Flag Decrypt {
		get => _Data[19] as Flag;
		set => _Data[19]  = value;
		}

	public virtual string _Decrypt {
		set => _Data[19].Parameter (value);
		}
	/// <summary>Field accessor for option [index]</summary>
	public virtual Flag Index {
		get => _Data[20] as Flag;
		set => _Data[20]  = value;
		}

	public virtual string _Index {
		set => _Data[20].Parameter (value);
		}
	/// <summary>Field accessor for option [purge]</summary>
	public virtual Flag Purge {
		get => _Data[21] as Flag;
		set => _Data[21]  = value;
		}

	public virtual string _Purge {
		set => _Data[21].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "copy",
		Brief =  "Copy sequence contents to create a new sequence removing deleted elements",
		HandleDelegate =  CommandLineInterpreter.Handle_ArchiveCopy,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Archive", 
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
				Identifier = "Self", 
				Default = null, // null if null
				Brief = "Encrypt a copy of the data for self",
				Index = 4,
				Key = "self"
				},
			new DescribeEntryOption () {
				Identifier = "Sign", 
				Default = null, // null if null
				Brief = "Sign data with specified key",
				Index = 5,
				Key = "sign"
				},
			new DescribeEntryOption () {
				Identifier = "Hash", 
				Default = "true", // null if null
				Brief = "Compute hash of content",
				Index = 6,
				Key = "hash"
				},
			new DescribeEntryOption () {
				Identifier = "Cover", 
				Default = null, // null if null
				Brief = "File containing a cover to be added to encrypted files",
				Index = 7,
				Key = "cover"
				},
			new DescribeEntryOption () {
				Identifier = "Algorithms", 
				Default = null, // null if null
				Brief = "List of algorithm specifiers",
				Index = 8,
				Key = "alg"
				},
			new DescribeEntryOption () {
				Identifier = "Type", 
				Default = null, // null if null
				Brief = "The sequence type, plain/tree/digest/chain/tree",
				Index = 9,
				Key = "type"
				},
			new DescribeEntryEnumerate () {
				Identifier = "EnumAuthentication", 
				Default = null, // null if null
				Brief = "Authentication and indexing",
				Index = 10,
				Key = "auth"
				},
			new DescribeEntryEnumerate () {
				Identifier = "EnumUse", 
				Default = null, // null if null
				Brief = "<Unspecified>",
				Index = 11,
				Key = "use"
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 14,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 15,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
				Brief = "Verbose reports (default)",
				Index = 16,
				Key = "verbose"
				},
			new DescribeEntryOption () {
				Identifier = "Report", 
				Default = "true", // null if null
				Brief = "Report output (default)",
				Index = 17,
				Key = "report"
				},
			new DescribeEntryOption () {
				Identifier = "Json", 
				Default = "false", // null if null
				Brief = "Report output in JSON format",
				Index = 18,
				Key = "json"
				},
			new DescribeEntryOption () {
				Identifier = "Decrypt", 
				Default = "false", // null if null
				Brief = "Decrypt contents",
				Index = 19,
				Key = "decrypt"
				},
			new DescribeEntryOption () {
				Identifier = "Index", 
				Default = "true", // null if null
				Brief = "Append an index record to the end",
				Index = 20,
				Key = "index"
				},
			new DescribeEntryOption () {
				Identifier = "Purge", 
				Default = "true", // null if null
				Brief = "Purge unused data etc.",
				Index = 21,
				Key = "purge"
				}
			}
		};

	}

public partial class ArchiveCopy : _ArchiveCopy {
    } // class ArchiveCopy

public class _LogCreate : Goedel.Command.Dispatch ,
						IEncodeOptions,
						ICryptoOptions,
						ISequenceOptions,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new ExistingFile (),
		new String (),
		new String (),
		new Enumeration<EnumAuthentication> (CommandLineInterpreter.DescribeEnumAuthentication),
		new Enumeration<EnumUse> (CommandLineInterpreter.DescribeEnumUse),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new NewFile ()		} ;





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
	/// <summary>Field accessor for option [self]</summary>
	public virtual String Self {
		get => _Data[2] as String;
		set => _Data[2]  = value;
		}

	public virtual string _Self {
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
	/// <summary>Field accessor for option [cover]</summary>
	public virtual ExistingFile Cover {
		get => _Data[5] as ExistingFile;
		set => _Data[5]  = value;
		}

	public virtual string _Cover {
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[12] as Flag;
		set => _Data[12]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[12].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[13] as Flag;
		set => _Data[13]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for parameter []</summary>
	public virtual NewFile Sequence {
		get => _Data[17] as NewFile;
		set => _Data[17]  = value;
		}

	public virtual string _Sequence {
		set => _Data[17].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "create",
		Brief =  "Create a new DARE Sequence",
		HandleDelegate =  CommandLineInterpreter.Handle_LogCreate,
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
				Identifier = "Self", 
				Default = null, // null if null
				Brief = "Encrypt a copy of the data for self",
				Index = 2,
				Key = "self"
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
				Identifier = "Cover", 
				Default = null, // null if null
				Brief = "File containing a cover to be added to encrypted files",
				Index = 5,
				Key = "cover"
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 12,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 13,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				},
			new DescribeEntryParameter () {
				Identifier = "Sequence", 
				Default = null, // null if null
				Brief = "New sequence",
				Index = 17,
				Key = ""
				}
			}
		};

	}

public partial class LogCreate : _LogCreate {
    } // class LogCreate

public class _LogAppend : Goedel.Command.Dispatch ,
						IEncodeOptions,
						ICryptoOptions,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new ExistingFile (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new ExistingFile (),
		new NewFile ()		} ;





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
	/// <summary>Field accessor for option [self]</summary>
	public virtual String Self {
		get => _Data[2] as String;
		set => _Data[2]  = value;
		}

	public virtual string _Self {
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
	/// <summary>Field accessor for option [cover]</summary>
	public virtual ExistingFile Cover {
		get => _Data[5] as ExistingFile;
		set => _Data[5]  = value;
		}

	public virtual string _Cover {
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[9] as Flag;
		set => _Data[9]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[9].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[10] as Flag;
		set => _Data[10]  = value;
		}

	public virtual string _AutoApprove {
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
	public virtual ExistingFile Sequence {
		get => _Data[14] as ExistingFile;
		set => _Data[14]  = value;
		}

	public virtual string _Sequence {
		set => _Data[14].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual NewFile Entry {
		get => _Data[15] as NewFile;
		set => _Data[15]  = value;
		}

	public virtual string _Entry {
		set => _Data[15].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "append",
		Brief =  "Append the specified string to the sequence.",
		HandleDelegate =  CommandLineInterpreter.Handle_LogAppend,
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
				Identifier = "Self", 
				Default = null, // null if null
				Brief = "Encrypt a copy of the data for self",
				Index = 2,
				Key = "self"
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
				Identifier = "Cover", 
				Default = null, // null if null
				Brief = "File containing a cover to be added to encrypted files",
				Index = 5,
				Key = "cover"
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 9,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 10,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				Brief = "Sequence to append to",
				Index = 14,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Entry", 
				Default = null, // null if null
				Brief = "Text to append",
				Index = 15,
				Key = ""
				}
			}
		};

	}

public partial class LogAppend : _LogAppend {
    } // class LogAppend

public class _LogList : Goedel.Command.Dispatch ,
						IReporting,
						IAccountOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new ExistingFile (),
		new NewFile ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[5] as Flag;
		set => _Data[5]  = value;
		}

	public virtual string _AutoSync {
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
	/// <summary>Field accessor for parameter []</summary>
	public virtual ExistingFile Sequence {
		get => _Data[7] as ExistingFile;
		set => _Data[7]  = value;
		}

	public virtual string _Sequence {
		set => _Data[7].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual NewFile Output {
		get => _Data[8] as NewFile;
		set => _Data[8]  = value;
		}

	public virtual string _Output {
		set => _Data[8].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "list",
		Brief =  "Compile a catalog for the specified sequence.",
		HandleDelegate =  CommandLineInterpreter.Handle_LogList,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 5,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 6,
				Key = "auto"
				},
			new DescribeEntryParameter () {
				Identifier = "Sequence", 
				Default = null, // null if null
				Brief = "Sequence to be cataloged",
				Index = 7,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Output", 
				Default = null, // null if null
				Brief = "List output",
				Index = 8,
				Key = ""
				}
			}
		};

	}

public partial class LogList : _LogList {
    } // class LogList

public class _MailAdd : Goedel.Command.Dispatch ,
						IDeviceAuthOptions,
						IAccountOptions,
						IReporting,
						IMailOptions,
						ICryptoOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new ExistingFile (),
		new String (),
		new String (),
		new String (),
		new String ()		} ;





	/// <summary>Field accessor for parameter []</summary>
	public virtual String Address {
		get => _Data[0] as String;
		set => _Data[0]  = value;
		}

	public virtual string _Address {
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
	/// <summary>Field accessor for option [threshold]</summary>
	public virtual Flag AuthThreshold {
		get => _Data[7] as Flag;
		set => _Data[7]  = value;
		}

	public virtual string _AuthThreshold {
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
	/// <summary>Field accessor for option [null]</summary>
	public virtual Flag AuthNone {
		get => _Data[12] as Flag;
		set => _Data[12]  = value;
		}

	public virtual string _AuthNone {
		set => _Data[12].Parameter (value);
		}
	/// <summary>Field accessor for option [account]</summary>
	public virtual String AccountAddress {
		get => _Data[13] as String;
		set => _Data[13]  = value;
		}

	public virtual string _AccountAddress {
		set => _Data[13].Parameter (value);
		}
	/// <summary>Field accessor for option [local]</summary>
	public virtual String LocalName {
		get => _Data[14] as String;
		set => _Data[14]  = value;
		}

	public virtual string _LocalName {
		set => _Data[14].Parameter (value);
		}
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[15] as Flag;
		set => _Data[15]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[15].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[16] as Flag;
		set => _Data[16]  = value;
		}

	public virtual string _AutoApprove {
		set => _Data[16].Parameter (value);
		}
	/// <summary>Field accessor for option [verbose]</summary>
	public virtual Flag Verbose {
		get => _Data[17] as Flag;
		set => _Data[17]  = value;
		}

	public virtual string _Verbose {
		set => _Data[17].Parameter (value);
		}
	/// <summary>Field accessor for option [report]</summary>
	public virtual Flag Report {
		get => _Data[18] as Flag;
		set => _Data[18]  = value;
		}

	public virtual string _Report {
		set => _Data[18].Parameter (value);
		}
	/// <summary>Field accessor for option [json]</summary>
	public virtual Flag Json {
		get => _Data[19] as Flag;
		set => _Data[19]  = value;
		}

	public virtual string _Json {
		set => _Data[19].Parameter (value);
		}
	/// <summary>Field accessor for option [openpgp]</summary>
	public virtual Flag OpenPGP {
		get => _Data[20] as Flag;
		set => _Data[20]  = value;
		}

	public virtual string _OpenPGP {
		set => _Data[20].Parameter (value);
		}
	/// <summary>Field accessor for option [smime]</summary>
	public virtual Flag SMIME {
		get => _Data[21] as Flag;
		set => _Data[21]  = value;
		}

	public virtual string _SMIME {
		set => _Data[21].Parameter (value);
		}
	/// <summary>Field accessor for option [configuration]</summary>
	public virtual ExistingFile Configuration {
		get => _Data[22] as ExistingFile;
		set => _Data[22]  = value;
		}

	public virtual string _Configuration {
		set => _Data[22].Parameter (value);
		}
	/// <summary>Field accessor for option [ca]</summary>
	public virtual String CA {
		get => _Data[23] as String;
		set => _Data[23]  = value;
		}

	public virtual string _CA {
		set => _Data[23].Parameter (value);
		}
	/// <summary>Field accessor for option [inbound]</summary>
	public virtual String Inbound {
		get => _Data[24] as String;
		set => _Data[24]  = value;
		}

	public virtual string _Inbound {
		set => _Data[24].Parameter (value);
		}
	/// <summary>Field accessor for option [outbound]</summary>
	public virtual String Outbound {
		get => _Data[25] as String;
		set => _Data[25]  = value;
		}

	public virtual string _Outbound {
		set => _Data[25].Parameter (value);
		}
	/// <summary>Field accessor for option [alg]</summary>
	public virtual String Algorithms {
		get => _Data[26] as String;
		set => _Data[26]  = value;
		}

	public virtual string _Algorithms {
		set => _Data[26].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
				Identifier = "AuthThreshold", 
				Default = "false", // null if null
				Brief = "Authorize threshold rights for Mesh messaging and Web.",
				Index = 7,
				Key = "threshold"
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
				Identifier = "AuthNone", 
				Default = "false", // null if null
				Brief = "Do not authorize any device rights at all (cannot be used with any rights grant))",
				Index = 12,
				Key = "null"
				},
			new DescribeEntryOption () {
				Identifier = "AccountAddress", 
				Default = null, // null if null
				Brief = "Account identifier (e.g. alice@example.com) or profile fingerprint",
				Index = 13,
				Key = "account"
				},
			new DescribeEntryOption () {
				Identifier = "LocalName", 
				Default = null, // null if null
				Brief = "Local name for account (e.g. personal)",
				Index = 14,
				Key = "local"
				},
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 15,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 16,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
				Brief = "Verbose reports (default)",
				Index = 17,
				Key = "verbose"
				},
			new DescribeEntryOption () {
				Identifier = "Report", 
				Default = "true", // null if null
				Brief = "Report output (default)",
				Index = 18,
				Key = "report"
				},
			new DescribeEntryOption () {
				Identifier = "Json", 
				Default = "false", // null if null
				Brief = "Report output in JSON format",
				Index = 19,
				Key = "json"
				},
			new DescribeEntryOption () {
				Identifier = "OpenPGP", 
				Default = null, // null if null
				Brief = "Create encryption and signature keys for OpenPGP",
				Index = 20,
				Key = "openpgp"
				},
			new DescribeEntryOption () {
				Identifier = "SMIME", 
				Default = null, // null if null
				Brief = "Create encryption and signature keys for S/MIME",
				Index = 21,
				Key = "smime"
				},
			new DescribeEntryOption () {
				Identifier = "Configuration", 
				Default = null, // null if null
				Brief = "Configuration file describing network settings",
				Index = 22,
				Key = "configuration"
				},
			new DescribeEntryOption () {
				Identifier = "CA", 
				Default = null, // null if null
				Brief = "Certificate Authority to request certificate from",
				Index = 23,
				Key = "ca"
				},
			new DescribeEntryOption () {
				Identifier = "Inbound", 
				Default = null, // null if null
				Brief = "inbound service configuration",
				Index = 24,
				Key = "inbound"
				},
			new DescribeEntryOption () {
				Identifier = "Outbound", 
				Default = null, // null if null
				Brief = "outbound service configuration",
				Index = 25,
				Key = "outbound"
				},
			new DescribeEntryOption () {
				Identifier = "Algorithms", 
				Default = null, // null if null
				Brief = "List of algorithm specifiers",
				Index = 26,
				Key = "alg"
				}
			}
		};

	}

public partial class MailAdd : _MailAdd {
    } // class MailAdd

public class _MailGet : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "get",
		Brief =  "Lookup mail entry",
		HandleDelegate =  CommandLineInterpreter.Handle_MailGet,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Address", 
				Default = null, // null if null
				Brief = "The mail account address",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class MailGet : _MailGet {
    } // class MailGet

public class _MailList : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class MailList : _MailList {
    } // class MailList

public class _MailImport : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new ExistingFile (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[4].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[5] as Flag;
		set => _Data[5]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "import",
		Brief =  "Import account information",
		HandleDelegate =  CommandLineInterpreter.Handle_MailImport,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "File", 
				Default = null, // null if null
				Brief = "File containing the contact entry to add",
				Index = 0,
				Key = ""
				},
			new DescribeEntryOption () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "Unique entry identifier",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 4,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 5,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class MailImport : _MailImport {
    } // class MailImport

public class _MailDelete : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Address {
		get => _Data[7] as String;
		set => _Data[7]  = value;
		}

	public virtual string _Address {
		set => _Data[7].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "delete",
		Brief =  "Delete mail account information",
		HandleDelegate =  CommandLineInterpreter.Handle_MailDelete,
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class MailDelete : _MailDelete {
    } // class MailDelete

public class _SmimeSign : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting,
						IKeyFileOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new NewFile (),
		new String (),
		new Flag (),
		new String ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for option [format]</summary>
	public virtual String Format {
		get => _Data[7] as String;
		set => _Data[7]  = value;
		}

	public virtual string _Format {
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
	/// <summary>Field accessor for option [password]</summary>
	public virtual String Password {
		get => _Data[9] as String;
		set => _Data[9]  = value;
		}

	public virtual string _Password {
		set => _Data[9].Parameter (value);
		}
	/// <summary>Field accessor for option [private]</summary>
	public virtual Flag Private {
		get => _Data[10] as Flag;
		set => _Data[10]  = value;
		}

	public virtual string _Private {
		set => _Data[10].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Address {
		get => _Data[11] as String;
		set => _Data[11]  = value;
		}

	public virtual string _Address {
		set => _Data[11].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "sign",
		Brief =  "Extract the signature key for the specified account",
		HandleDelegate =  CommandLineInterpreter.Handle_SmimeSign,
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				Identifier = "Format", 
				Default = null, // null if null
				Brief = "File format",
				Index = 7,
				Key = "format"
				},
			new DescribeEntryOption () {
				Identifier = "File", 
				Default = null, // null if null
				Brief = "Output file",
				Index = 8,
				Key = "file"
				},
			new DescribeEntryOption () {
				Identifier = "Password", 
				Default = null, // null if null
				Brief = "Password to encrypt private key",
				Index = 9,
				Key = "password"
				},
			new DescribeEntryOption () {
				Identifier = "Private", 
				Default = "false", // null if null
				Brief = "<Unspecified>",
				Index = 10,
				Key = "private"
				},
			new DescribeEntryParameter () {
				Identifier = "Address", 
				Default = null, // null if null
				Brief = "Mail account to update",
				Index = 11,
				Key = ""
				}
			}
		};

	}

public partial class SmimeSign : _SmimeSign {
    } // class SmimeSign

public class _SmimeEncrypt : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting,
						IKeyFileOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new NewFile (),
		new String (),
		new Flag (),
		new String ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for option [format]</summary>
	public virtual String Format {
		get => _Data[7] as String;
		set => _Data[7]  = value;
		}

	public virtual string _Format {
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
	/// <summary>Field accessor for option [password]</summary>
	public virtual String Password {
		get => _Data[9] as String;
		set => _Data[9]  = value;
		}

	public virtual string _Password {
		set => _Data[9].Parameter (value);
		}
	/// <summary>Field accessor for option [private]</summary>
	public virtual Flag Private {
		get => _Data[10] as Flag;
		set => _Data[10]  = value;
		}

	public virtual string _Private {
		set => _Data[10].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Address {
		get => _Data[11] as String;
		set => _Data[11]  = value;
		}

	public virtual string _Address {
		set => _Data[11].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "encrypt",
		Brief =  "Extract the public key/certificate for the specified account",
		HandleDelegate =  CommandLineInterpreter.Handle_SmimeEncrypt,
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				Identifier = "Format", 
				Default = null, // null if null
				Brief = "File format",
				Index = 7,
				Key = "format"
				},
			new DescribeEntryOption () {
				Identifier = "File", 
				Default = null, // null if null
				Brief = "Output file",
				Index = 8,
				Key = "file"
				},
			new DescribeEntryOption () {
				Identifier = "Password", 
				Default = null, // null if null
				Brief = "Password to encrypt private key",
				Index = 9,
				Key = "password"
				},
			new DescribeEntryOption () {
				Identifier = "Private", 
				Default = "false", // null if null
				Brief = "<Unspecified>",
				Index = 10,
				Key = "private"
				},
			new DescribeEntryParameter () {
				Identifier = "Address", 
				Default = null, // null if null
				Brief = "Mail account identifier",
				Index = 11,
				Key = ""
				}
			}
		};

	}

public partial class SmimeEncrypt : _SmimeEncrypt {
    } // class SmimeEncrypt

public class _OpenpgpSign : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting,
						IKeyFileOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new NewFile (),
		new String (),
		new Flag (),
		new String ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for option [format]</summary>
	public virtual String Format {
		get => _Data[7] as String;
		set => _Data[7]  = value;
		}

	public virtual string _Format {
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
	/// <summary>Field accessor for option [password]</summary>
	public virtual String Password {
		get => _Data[9] as String;
		set => _Data[9]  = value;
		}

	public virtual string _Password {
		set => _Data[9].Parameter (value);
		}
	/// <summary>Field accessor for option [private]</summary>
	public virtual Flag Private {
		get => _Data[10] as Flag;
		set => _Data[10]  = value;
		}

	public virtual string _Private {
		set => _Data[10].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Address {
		get => _Data[11] as String;
		set => _Data[11]  = value;
		}

	public virtual string _Address {
		set => _Data[11].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "sign",
		Brief =  "Extract the signature key for the specified account",
		HandleDelegate =  CommandLineInterpreter.Handle_OpenpgpSign,
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				Identifier = "Format", 
				Default = null, // null if null
				Brief = "File format",
				Index = 7,
				Key = "format"
				},
			new DescribeEntryOption () {
				Identifier = "File", 
				Default = null, // null if null
				Brief = "Output file",
				Index = 8,
				Key = "file"
				},
			new DescribeEntryOption () {
				Identifier = "Password", 
				Default = null, // null if null
				Brief = "Password to encrypt private key",
				Index = 9,
				Key = "password"
				},
			new DescribeEntryOption () {
				Identifier = "Private", 
				Default = "false", // null if null
				Brief = "<Unspecified>",
				Index = 10,
				Key = "private"
				},
			new DescribeEntryParameter () {
				Identifier = "Address", 
				Default = null, // null if null
				Brief = "Mail account to update",
				Index = 11,
				Key = ""
				}
			}
		};

	}

public partial class OpenpgpSign : _OpenpgpSign {
    } // class OpenpgpSign

public class _OpenpgpEncrypt : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting,
						IKeyFileOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new NewFile (),
		new String (),
		new Flag (),
		new String ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for option [format]</summary>
	public virtual String Format {
		get => _Data[7] as String;
		set => _Data[7]  = value;
		}

	public virtual string _Format {
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
	/// <summary>Field accessor for option [password]</summary>
	public virtual String Password {
		get => _Data[9] as String;
		set => _Data[9]  = value;
		}

	public virtual string _Password {
		set => _Data[9].Parameter (value);
		}
	/// <summary>Field accessor for option [private]</summary>
	public virtual Flag Private {
		get => _Data[10] as Flag;
		set => _Data[10]  = value;
		}

	public virtual string _Private {
		set => _Data[10].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Address {
		get => _Data[11] as String;
		set => _Data[11]  = value;
		}

	public virtual string _Address {
		set => _Data[11].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "encrypt",
		Brief =  "Extract the public key/certificate for the specified account",
		HandleDelegate =  CommandLineInterpreter.Handle_OpenpgpEncrypt,
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				Identifier = "Format", 
				Default = null, // null if null
				Brief = "File format",
				Index = 7,
				Key = "format"
				},
			new DescribeEntryOption () {
				Identifier = "File", 
				Default = null, // null if null
				Brief = "Output file",
				Index = 8,
				Key = "file"
				},
			new DescribeEntryOption () {
				Identifier = "Password", 
				Default = null, // null if null
				Brief = "Password to encrypt private key",
				Index = 9,
				Key = "password"
				},
			new DescribeEntryOption () {
				Identifier = "Private", 
				Default = "false", // null if null
				Brief = "<Unspecified>",
				Index = 10,
				Key = "private"
				},
			new DescribeEntryParameter () {
				Identifier = "Address", 
				Default = null, // null if null
				Brief = "Mail account identifier",
				Index = 11,
				Key = ""
				}
			}
		};

	}

public partial class OpenpgpEncrypt : _OpenpgpEncrypt {
    } // class OpenpgpEncrypt

public class _SSHCreate : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting,
						ICryptoOptions,
						IDeviceAuthOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new String ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for option [alg]</summary>
	public virtual String Algorithms {
		get => _Data[7] as String;
		set => _Data[7]  = value;
		}

	public virtual string _Algorithms {
		set => _Data[7].Parameter (value);
		}
	/// <summary>Field accessor for option [auth]</summary>
	public virtual String Auth {
		get => _Data[8] as String;
		set => _Data[8]  = value;
		}

	public virtual string _Auth {
		set => _Data[8].Parameter (value);
		}
	/// <summary>Field accessor for option [root]</summary>
	public virtual Flag AuthSuper {
		get => _Data[9] as Flag;
		set => _Data[9]  = value;
		}

	public virtual string _AuthSuper {
		set => _Data[9].Parameter (value);
		}
	/// <summary>Field accessor for option [admin]</summary>
	public virtual Flag AuthAdmin {
		get => _Data[10] as Flag;
		set => _Data[10]  = value;
		}

	public virtual string _AuthAdmin {
		set => _Data[10].Parameter (value);
		}
	/// <summary>Field accessor for option [message]</summary>
	public virtual Flag AuthMessage {
		get => _Data[11] as Flag;
		set => _Data[11]  = value;
		}

	public virtual string _AuthMessage {
		set => _Data[11].Parameter (value);
		}
	/// <summary>Field accessor for option [web]</summary>
	public virtual Flag AuthWeb {
		get => _Data[12] as Flag;
		set => _Data[12]  = value;
		}

	public virtual string _AuthWeb {
		set => _Data[12].Parameter (value);
		}
	/// <summary>Field accessor for option [device]</summary>
	public virtual Flag AuthDevice {
		get => _Data[13] as Flag;
		set => _Data[13]  = value;
		}

	public virtual string _AuthDevice {
		set => _Data[13].Parameter (value);
		}
	/// <summary>Field accessor for option [threshold]</summary>
	public virtual Flag AuthThreshold {
		get => _Data[14] as Flag;
		set => _Data[14]  = value;
		}

	public virtual string _AuthThreshold {
		set => _Data[14].Parameter (value);
		}
	/// <summary>Field accessor for option [ssh]</summary>
	public virtual String AuthSSH {
		get => _Data[15] as String;
		set => _Data[15]  = value;
		}

	public virtual string _AuthSSH {
		set => _Data[15].Parameter (value);
		}
	/// <summary>Field accessor for option [email]</summary>
	public virtual String AuthEmail {
		get => _Data[16] as String;
		set => _Data[16]  = value;
		}

	public virtual string _AuthEmail {
		set => _Data[16].Parameter (value);
		}
	/// <summary>Field accessor for option [member]</summary>
	public virtual String AuthGroupMember {
		get => _Data[17] as String;
		set => _Data[17]  = value;
		}

	public virtual string _AuthGroupMember {
		set => _Data[17].Parameter (value);
		}
	/// <summary>Field accessor for option [group]</summary>
	public virtual String AuthGroupAdmin {
		get => _Data[18] as String;
		set => _Data[18]  = value;
		}

	public virtual string _AuthGroupAdmin {
		set => _Data[18].Parameter (value);
		}
	/// <summary>Field accessor for option [null]</summary>
	public virtual Flag AuthNone {
		get => _Data[19] as Flag;
		set => _Data[19]  = value;
		}

	public virtual string _AuthNone {
		set => _Data[19].Parameter (value);
		}
	/// <summary>Field accessor for option [id]</summary>
	public virtual String ID {
		get => _Data[20] as String;
		set => _Data[20]  = value;
		}

	public virtual string _ID {
		set => _Data[20].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				Identifier = "Algorithms", 
				Default = null, // null if null
				Brief = "List of algorithm specifiers",
				Index = 7,
				Key = "alg"
				},
			new DescribeEntryOption () {
				Identifier = "Auth", 
				Default = null, // null if null
				Brief = "(De)Authorize the specified function on the device",
				Index = 8,
				Key = "auth"
				},
			new DescribeEntryOption () {
				Identifier = "AuthSuper", 
				Default = "false", // null if null
				Brief = "Device as super administration device",
				Index = 9,
				Key = "root"
				},
			new DescribeEntryOption () {
				Identifier = "AuthAdmin", 
				Default = "false", // null if null
				Brief = "Device as administration device",
				Index = 10,
				Key = "admin"
				},
			new DescribeEntryOption () {
				Identifier = "AuthMessage", 
				Default = "false", // null if null
				Brief = "Authorize rights for Mesh messaging",
				Index = 11,
				Key = "message"
				},
			new DescribeEntryOption () {
				Identifier = "AuthWeb", 
				Default = "false", // null if null
				Brief = "Authorize rights for Mesh messaging and Web.",
				Index = 12,
				Key = "web"
				},
			new DescribeEntryOption () {
				Identifier = "AuthDevice", 
				Default = "false", // null if null
				Brief = "Device restrictive access",
				Index = 13,
				Key = "device"
				},
			new DescribeEntryOption () {
				Identifier = "AuthThreshold", 
				Default = "false", // null if null
				Brief = "Authorize threshold rights for Mesh messaging and Web.",
				Index = 14,
				Key = "threshold"
				},
			new DescribeEntryOption () {
				Identifier = "AuthSSH", 
				Default = "false", // null if null
				Brief = "Authorize rights for specified SSH account",
				Index = 15,
				Key = "ssh"
				},
			new DescribeEntryOption () {
				Identifier = "AuthEmail", 
				Default = "false", // null if null
				Brief = "Authorize rights for specified smtp email account",
				Index = 16,
				Key = "email"
				},
			new DescribeEntryOption () {
				Identifier = "AuthGroupMember", 
				Default = "false", // null if null
				Brief = "Authorize member rights for specified Mesh group",
				Index = 17,
				Key = "member"
				},
			new DescribeEntryOption () {
				Identifier = "AuthGroupAdmin", 
				Default = "false", // null if null
				Brief = "Authorize group administrator rights for specified Mesh group",
				Index = 18,
				Key = "group"
				},
			new DescribeEntryOption () {
				Identifier = "AuthNone", 
				Default = "false", // null if null
				Brief = "Do not authorize any device rights at all (cannot be used with any rights grant))",
				Index = 19,
				Key = "null"
				},
			new DescribeEntryOption () {
				Identifier = "ID", 
				Default = null, // null if null
				Brief = "Key identifier",
				Index = 20,
				Key = "id"
				}
			}
		};

	}

public partial class SSHCreate : _SSHCreate {
    } // class SSHCreate

public class _SSHGet : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting,
						IKeyFileOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new NewFile (),
		new String (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for option [format]</summary>
	public virtual String Format {
		get => _Data[8] as String;
		set => _Data[8]  = value;
		}

	public virtual string _Format {
		set => _Data[8].Parameter (value);
		}
	/// <summary>Field accessor for option [file]</summary>
	public virtual NewFile File {
		get => _Data[9] as NewFile;
		set => _Data[9]  = value;
		}

	public virtual string _File {
		set => _Data[9].Parameter (value);
		}
	/// <summary>Field accessor for option [password]</summary>
	public virtual String Password {
		get => _Data[10] as String;
		set => _Data[10]  = value;
		}

	public virtual string _Password {
		set => _Data[10].Parameter (value);
		}
	/// <summary>Field accessor for option [private]</summary>
	public virtual Flag Private {
		get => _Data[11] as Flag;
		set => _Data[11]  = value;
		}

	public virtual string _Private {
		set => _Data[11].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "get",
		Brief =  "Get SSH account data",
		HandleDelegate =  CommandLineInterpreter.Handle_SSHGet,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "The mail account address",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				},
			new DescribeEntryOption () {
				Identifier = "Format", 
				Default = null, // null if null
				Brief = "File format",
				Index = 8,
				Key = "format"
				},
			new DescribeEntryOption () {
				Identifier = "File", 
				Default = null, // null if null
				Brief = "Output file",
				Index = 9,
				Key = "file"
				},
			new DescribeEntryOption () {
				Identifier = "Password", 
				Default = null, // null if null
				Brief = "Password to encrypt private key",
				Index = 10,
				Key = "password"
				},
			new DescribeEntryOption () {
				Identifier = "Private", 
				Default = "false", // null if null
				Brief = "<Unspecified>",
				Index = 11,
				Key = "private"
				}
			}
		};

	}

public partial class SSHGet : _SSHGet {
    } // class SSHGet

public class _SSHList : Goedel.Command.Dispatch ,
						IKeyFileOptions,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new NewFile (),
		new String (),
		new Flag (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





	/// <summary>Field accessor for option [format]</summary>
	public virtual String Format {
		get => _Data[0] as String;
		set => _Data[0]  = value;
		}

	public virtual string _Format {
		set => _Data[0].Parameter (value);
		}
	/// <summary>Field accessor for option [file]</summary>
	public virtual NewFile File {
		get => _Data[1] as NewFile;
		set => _Data[1]  = value;
		}

	public virtual string _File {
		set => _Data[1].Parameter (value);
		}
	/// <summary>Field accessor for option [password]</summary>
	public virtual String Password {
		get => _Data[2] as String;
		set => _Data[2]  = value;
		}

	public virtual string _Password {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [private]</summary>
	public virtual Flag Private {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _Private {
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[6] as Flag;
		set => _Data[6]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[6].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[7] as Flag;
		set => _Data[7]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "list",
		Brief =  "List SSH account information",
		HandleDelegate =  CommandLineInterpreter.Handle_SSHList,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryOption () {
				Identifier = "Format", 
				Default = null, // null if null
				Brief = "File format",
				Index = 0,
				Key = "format"
				},
			new DescribeEntryOption () {
				Identifier = "File", 
				Default = null, // null if null
				Brief = "Output file",
				Index = 1,
				Key = "file"
				},
			new DescribeEntryOption () {
				Identifier = "Password", 
				Default = null, // null if null
				Brief = "Password to encrypt private key",
				Index = 2,
				Key = "password"
				},
			new DescribeEntryOption () {
				Identifier = "Private", 
				Default = "false", // null if null
				Brief = "<Unspecified>",
				Index = 3,
				Key = "private"
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 6,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 7,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class SSHList : _SSHList {
    } // class SSHList

public class _SSHClient : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting,
						IKeyFileOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new ExistingFile (),
		new String (),
		new Flag (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new NewFile (),
		new String (),
		new Flag ()		} ;





	/// <summary>Field accessor for parameter []</summary>
	public virtual ExistingFile FileIn {
		get => _Data[0] as ExistingFile;
		set => _Data[0]  = value;
		}

	public virtual string _FileIn {
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
	/// <summary>Field accessor for option [merge]</summary>
	public virtual Flag Merge {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _Merge {
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[5] as Flag;
		set => _Data[5]  = value;
		}

	public virtual string _AutoSync {
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
	/// <summary>Field accessor for option [format]</summary>
	public virtual String Format {
		get => _Data[10] as String;
		set => _Data[10]  = value;
		}

	public virtual string _Format {
		set => _Data[10].Parameter (value);
		}
	/// <summary>Field accessor for option [file]</summary>
	public virtual NewFile File {
		get => _Data[11] as NewFile;
		set => _Data[11]  = value;
		}

	public virtual string _File {
		set => _Data[11].Parameter (value);
		}
	/// <summary>Field accessor for option [password]</summary>
	public virtual String Password {
		get => _Data[12] as String;
		set => _Data[12]  = value;
		}

	public virtual string _Password {
		set => _Data[12].Parameter (value);
		}
	/// <summary>Field accessor for option [private]</summary>
	public virtual Flag Private {
		get => _Data[13] as Flag;
		set => _Data[13]  = value;
		}

	public virtual string _Private {
		set => _Data[13].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "client",
		Brief =  "Import SSH client information",
		HandleDelegate =  CommandLineInterpreter.Handle_SSHClient,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "FileIn", 
				Default = null, // null if null
				Brief = "File containing the contact entry to add",
				Index = 0,
				Key = ""
				},
			new DescribeEntryOption () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "Unique entry identifier",
				Index = 1,
				Key = "id"
				},
			new DescribeEntryOption () {
				Identifier = "Merge", 
				Default = null, // null if null
				Brief = "Merge input file with Mesh profile",
				Index = 2,
				Key = "merge"
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 5,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 6,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				Identifier = "Format", 
				Default = null, // null if null
				Brief = "File format",
				Index = 10,
				Key = "format"
				},
			new DescribeEntryOption () {
				Identifier = "File", 
				Default = null, // null if null
				Brief = "Output file",
				Index = 11,
				Key = "file"
				},
			new DescribeEntryOption () {
				Identifier = "Password", 
				Default = null, // null if null
				Brief = "Password to encrypt private key",
				Index = 12,
				Key = "password"
				},
			new DescribeEntryOption () {
				Identifier = "Private", 
				Default = "false", // null if null
				Brief = "<Unspecified>",
				Index = 13,
				Key = "private"
				}
			}
		};

	}

public partial class SSHClient : _SSHClient {
    } // class SSHClient

public class _SSHHost : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting,
						IKeyFileOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new ExistingFile (),
		new String (),
		new Flag (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new NewFile (),
		new String (),
		new Flag ()		} ;





	/// <summary>Field accessor for parameter []</summary>
	public virtual ExistingFile FileIn {
		get => _Data[0] as ExistingFile;
		set => _Data[0]  = value;
		}

	public virtual string _FileIn {
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
	/// <summary>Field accessor for option [merge]</summary>
	public virtual Flag Merge {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _Merge {
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[5] as Flag;
		set => _Data[5]  = value;
		}

	public virtual string _AutoSync {
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
	/// <summary>Field accessor for option [format]</summary>
	public virtual String Format {
		get => _Data[10] as String;
		set => _Data[10]  = value;
		}

	public virtual string _Format {
		set => _Data[10].Parameter (value);
		}
	/// <summary>Field accessor for option [file]</summary>
	public virtual NewFile File {
		get => _Data[11] as NewFile;
		set => _Data[11]  = value;
		}

	public virtual string _File {
		set => _Data[11].Parameter (value);
		}
	/// <summary>Field accessor for option [password]</summary>
	public virtual String Password {
		get => _Data[12] as String;
		set => _Data[12]  = value;
		}

	public virtual string _Password {
		set => _Data[12].Parameter (value);
		}
	/// <summary>Field accessor for option [private]</summary>
	public virtual Flag Private {
		get => _Data[13] as Flag;
		set => _Data[13]  = value;
		}

	public virtual string _Private {
		set => _Data[13].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "host",
		Brief =  "Import account information",
		HandleDelegate =  CommandLineInterpreter.Handle_SSHHost,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "FileIn", 
				Default = null, // null if null
				Brief = "File containing the contact entry to add",
				Index = 0,
				Key = ""
				},
			new DescribeEntryOption () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "Unique entry identifier",
				Index = 1,
				Key = "id"
				},
			new DescribeEntryOption () {
				Identifier = "Merge", 
				Default = null, // null if null
				Brief = "Merge input file with Mesh profile",
				Index = 2,
				Key = "merge"
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 5,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 6,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				Identifier = "Format", 
				Default = null, // null if null
				Brief = "File format",
				Index = 10,
				Key = "format"
				},
			new DescribeEntryOption () {
				Identifier = "File", 
				Default = null, // null if null
				Brief = "Output file",
				Index = 11,
				Key = "file"
				},
			new DescribeEntryOption () {
				Identifier = "Password", 
				Default = null, // null if null
				Brief = "Password to encrypt private key",
				Index = 12,
				Key = "password"
				},
			new DescribeEntryOption () {
				Identifier = "Private", 
				Default = "false", // null if null
				Brief = "<Unspecified>",
				Index = 13,
				Key = "private"
				}
			}
		};

	}

public partial class SSHHost : _SSHHost {
    } // class SSHHost

public class _SSHKnown : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting,
						IKeyFileOptions{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new String (),
		new NewFile (),
		new String (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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
	/// <summary>Field accessor for option [format]</summary>
	public virtual String Format {
		get => _Data[8] as String;
		set => _Data[8]  = value;
		}

	public virtual string _Format {
		set => _Data[8].Parameter (value);
		}
	/// <summary>Field accessor for option [file]</summary>
	public virtual NewFile File {
		get => _Data[9] as NewFile;
		set => _Data[9]  = value;
		}

	public virtual string _File {
		set => _Data[9].Parameter (value);
		}
	/// <summary>Field accessor for option [password]</summary>
	public virtual String Password {
		get => _Data[10] as String;
		set => _Data[10]  = value;
		}

	public virtual string _Password {
		set => _Data[10].Parameter (value);
		}
	/// <summary>Field accessor for option [private]</summary>
	public virtual Flag Private {
		get => _Data[11] as Flag;
		set => _Data[11]  = value;
		}

	public virtual string _Private {
		set => _Data[11].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "known",
		Brief =  "Get SSH data for known host",
		HandleDelegate =  CommandLineInterpreter.Handle_SSHKnown,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "The mail account address",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				},
			new DescribeEntryOption () {
				Identifier = "Format", 
				Default = null, // null if null
				Brief = "File format",
				Index = 8,
				Key = "format"
				},
			new DescribeEntryOption () {
				Identifier = "File", 
				Default = null, // null if null
				Brief = "Output file",
				Index = 9,
				Key = "file"
				},
			new DescribeEntryOption () {
				Identifier = "Password", 
				Default = null, // null if null
				Brief = "Password to encrypt private key",
				Index = 10,
				Key = "password"
				},
			new DescribeEntryOption () {
				Identifier = "Private", 
				Default = "false", // null if null
				Brief = "<Unspecified>",
				Index = 11,
				Key = "private"
				}
			}
		};

	}

public partial class SSHKnown : _SSHKnown {
    } // class SSHKnown

public class _SSHDelete : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "delete",
		Brief =  "Delete SSH profile information",
		HandleDelegate =  CommandLineInterpreter.Handle_SSHDelete,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "Unique entry identifier",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class SSHDelete : _SSHDelete {
    } // class SSHDelete

public class _CallsignRegister : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "register",
		Brief =  "Register a callsign",
		HandleDelegate =  CommandLineInterpreter.Handle_CallsignRegister,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "The callsign to register in requested presentation form",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class CallsignRegister : _CallsignRegister {
    } // class CallsignRegister

public class _CallsignBind : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "bind",
		Brief =  "Bind a registered callsign to an account",
		HandleDelegate =  CommandLineInterpreter.Handle_CallsignBind,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "The callsign to bind",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class CallsignBind : _CallsignBind {
    } // class CallsignBind

public class _CallsignResolve : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "resolve",
		Brief =  "Request callsign resolution.",
		HandleDelegate =  CommandLineInterpreter.Handle_CallsignResolve,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "The callsign to resolve",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class CallsignResolve : _CallsignResolve {
    } // class CallsignResolve

public class _CallsignTransfer : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





	/// <summary>Field accessor for parameter []</summary>
	public virtual String Identifier {
		get => _Data[0] as String;
		set => _Data[0]  = value;
		}

	public virtual string _Identifier {
		set => _Data[0].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Recipient {
		get => _Data[1] as String;
		set => _Data[1]  = value;
		}

	public virtual string _Recipient {
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[4].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[5] as Flag;
		set => _Data[5]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "transfer",
		Brief =  "Transfer a callsign to another user.",
		HandleDelegate =  CommandLineInterpreter.Handle_CallsignTransfer,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "The callsign to bind",
				Index = 0,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Recipient", 
				Default = null, // null if null
				Brief = "The recipient to send the callsign to",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 4,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 5,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class CallsignTransfer : _CallsignTransfer {
    } // class CallsignTransfer

public class _CallsignStatus : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "status",
		Brief =  "Report callsign registration status.",
		HandleDelegate =  CommandLineInterpreter.Handle_CallsignStatus,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "The callsign to resolve",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class CallsignStatus : _CallsignStatus {
    } // class CallsignStatus

public class _CallsignList : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "list",
		Brief =  "List callsign registrations.",
		HandleDelegate =  CommandLineInterpreter.Handle_CallsignList,
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class CallsignList : _CallsignList {
    } // class CallsignList

public class _WalletInvoice : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new ExistingFile (),
		new String (),
		new String (),
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





	/// <summary>Field accessor for parameter []</summary>
	public virtual String Recipient {
		get => _Data[0] as String;
		set => _Data[0]  = value;
		}

	public virtual string _Recipient {
		set => _Data[0].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual ExistingFile Invoice {
		get => _Data[1] as ExistingFile;
		set => _Data[1]  = value;
		}

	public virtual string _Invoice {
		set => _Data[1].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Currency {
		get => _Data[2] as String;
		set => _Data[2]  = value;
		}

	public virtual string _Currency {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Amount {
		get => _Data[3] as String;
		set => _Data[3]  = value;
		}

	public virtual string _Amount {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Reason {
		get => _Data[4] as String;
		set => _Data[4]  = value;
		}

	public virtual string _Reason {
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[7] as Flag;
		set => _Data[7]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[7].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[8] as Flag;
		set => _Data[8]  = value;
		}

	public virtual string _AutoApprove {
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
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "invoice",
		Brief =  "Send a request for payment.",
		HandleDelegate =  CommandLineInterpreter.Handle_WalletInvoice,
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
				Identifier = "Invoice", 
				Default = null, // null if null
				Brief = "The invoice text",
				Index = 1,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Currency", 
				Default = null, // null if null
				Brief = "The payment currency",
				Index = 2,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Amount", 
				Default = null, // null if null
				Brief = "The payment amount",
				Index = 3,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Reason", 
				Default = null, // null if null
				Brief = "The reason for the payment request",
				Index = 4,
				Key = ""
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 7,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 8,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				}
			}
		};

	}

public partial class WalletInvoice : _WalletInvoice {
    } // class WalletInvoice

public class _WalletTransfer : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
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
		new Flag ()		} ;





	/// <summary>Field accessor for parameter []</summary>
	public virtual String Recipient {
		get => _Data[0] as String;
		set => _Data[0]  = value;
		}

	public virtual string _Recipient {
		set => _Data[0].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Currency {
		get => _Data[1] as String;
		set => _Data[1]  = value;
		}

	public virtual string _Currency {
		set => _Data[1].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Amount {
		get => _Data[2] as String;
		set => _Data[2]  = value;
		}

	public virtual string _Amount {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for parameter []</summary>
	public virtual String Reason {
		get => _Data[3] as String;
		set => _Data[3]  = value;
		}

	public virtual string _Reason {
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[6] as Flag;
		set => _Data[6]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[6].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[7] as Flag;
		set => _Data[7]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "transfer",
		Brief =  "Transfer a token to another user.",
		HandleDelegate =  CommandLineInterpreter.Handle_WalletTransfer,
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
				Identifier = "Currency", 
				Default = null, // null if null
				Brief = "The payment currency",
				Index = 1,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Amount", 
				Default = null, // null if null
				Brief = "The payment amount",
				Index = 2,
				Key = ""
				},
			new DescribeEntryParameter () {
				Identifier = "Reason", 
				Default = null, // null if null
				Brief = "The reason for the transfer",
				Index = 3,
				Key = ""
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 6,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 7,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class WalletTransfer : _WalletTransfer {
    } // class WalletTransfer

public class _WalletAccept : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





	/// <summary>Field accessor for parameter []</summary>
	public virtual String MessageId {
		get => _Data[0] as String;
		set => _Data[0]  = value;
		}

	public virtual string _MessageId {
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "accept",
		Brief =  "Accept an invoice and make payment",
		HandleDelegate =  CommandLineInterpreter.Handle_WalletAccept,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "MessageId", 
				Default = null, // null if null
				Brief = "The invoice message id",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class WalletAccept : _WalletAccept {
    } // class WalletAccept

public class _WalletReject : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





	/// <summary>Field accessor for parameter []</summary>
	public virtual String MessageId {
		get => _Data[0] as String;
		set => _Data[0]  = value;
		}

	public virtual string _MessageId {
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "reject",
		Brief =  "Accept an invoice and make payment",
		HandleDelegate =  CommandLineInterpreter.Handle_WalletReject,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "MessageId", 
				Default = null, // null if null
				Brief = "The invoice message id",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class WalletReject : _WalletReject {
    } // class WalletReject

public class _WalletRedeem : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





	/// <summary>Field accessor for parameter []</summary>
	public virtual String MessageId {
		get => _Data[0] as String;
		set => _Data[0]  = value;
		}

	public virtual string _MessageId {
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "redeem",
		Brief =  "Redeem an invoice payment",
		HandleDelegate =  CommandLineInterpreter.Handle_WalletRedeem,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "MessageId", 
				Default = null, // null if null
				Brief = "The payment message id to redeem",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class WalletRedeem : _WalletRedeem {
    } // class WalletRedeem

public class _WalletList : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[2] as Flag;
		set => _Data[2]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "list",
		Brief =  "List wallet entries",
		HandleDelegate =  CommandLineInterpreter.Handle_WalletList,
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 2,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 3,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class WalletList : _WalletList {
    } // class WalletList

public class _WalletDelete : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "delete",
		Brief =  "Delete wallet entry",
		HandleDelegate =  CommandLineInterpreter.Handle_WalletDelete,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "Wallet entry identifier",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class WalletDelete : _WalletDelete {
    } // class WalletDelete

public class _WalletkGet : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "get",
		Brief =  "Lookup wallet entry",
		HandleDelegate =  CommandLineInterpreter.Handle_WalletkGet,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "Local identifier",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class WalletkGet : _WalletkGet {
    } // class WalletkGet

public class _CarnetMint : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Integer (),
		new Integer (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





	/// <summary>Field accessor for parameter []</summary>
	public virtual String Amount {
		get => _Data[0] as String;
		set => _Data[0]  = value;
		}

	public virtual string _Amount {
		set => _Data[0].Parameter (value);
		}
	/// <summary>Field accessor for option [to]</summary>
	public virtual String Recipient {
		get => _Data[1] as String;
		set => _Data[1]  = value;
		}

	public virtual string _Recipient {
		set => _Data[1].Parameter (value);
		}
	/// <summary>Field accessor for option [currency]</summary>
	public virtual String Currency {
		get => _Data[2] as String;
		set => _Data[2]  = value;
		}

	public virtual string _Currency {
		set => _Data[2].Parameter (value);
		}
	/// <summary>Field accessor for option [tickets]</summary>
	public virtual Integer Tickets {
		get => _Data[3] as Integer;
		set => _Data[3]  = value;
		}

	public virtual string _Tickets {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [quantum]</summary>
	public virtual Integer Quantum {
		get => _Data[4] as Integer;
		set => _Data[4]  = value;
		}

	public virtual string _Quantum {
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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[7] as Flag;
		set => _Data[7]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[7].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[8] as Flag;
		set => _Data[8]  = value;
		}

	public virtual string _AutoApprove {
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
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "mint",
		Brief =  "Mint a carnet and send it to a user",
		HandleDelegate =  CommandLineInterpreter.Handle_CarnetMint,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Amount", 
				Default = null, // null if null
				Brief = "The payment amount",
				Index = 0,
				Key = ""
				},
			new DescribeEntryOption () {
				Identifier = "Recipient", 
				Default = null, // null if null
				Brief = "The recipient to send the confirmation request to",
				Index = 1,
				Key = "to"
				},
			new DescribeEntryOption () {
				Identifier = "Currency", 
				Default = null, // null if null
				Brief = "The payment currency",
				Index = 2,
				Key = "currency"
				},
			new DescribeEntryOption () {
				Identifier = "Tickets", 
				Default = null, // null if null
				Brief = "The number of tickets to issue",
				Index = 3,
				Key = "tickets"
				},
			new DescribeEntryOption () {
				Identifier = "Quantum", 
				Default = null, // null if null
				Brief = "The value of each ticket",
				Index = 4,
				Key = "quantum"
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 7,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 8,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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
				}
			}
		};

	}

public partial class CarnetMint : _CarnetMint {
    } // class CarnetMint

public class _CarnetStatus : Goedel.Command.Dispatch ,
						IAccountOptions,
						IReporting{

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new String (),
		new String (),
		new String (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag (),
		new Flag ()		} ;





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
	/// <summary>Field accessor for option [sync]</summary>
	public virtual Flag AutoSync {
		get => _Data[3] as Flag;
		set => _Data[3]  = value;
		}

	public virtual string _AutoSync {
		set => _Data[3].Parameter (value);
		}
	/// <summary>Field accessor for option [auto]</summary>
	public virtual Flag AutoApprove {
		get => _Data[4] as Flag;
		set => _Data[4]  = value;
		}

	public virtual string _AutoApprove {
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

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "status",
		Brief =  "Return status of a carnet entry",
		HandleDelegate =  CommandLineInterpreter.Handle_CarnetStatus,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryParameter () {
				Identifier = "Identifier", 
				Default = null, // null if null
				Brief = "The carnet identifier",
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
			new DescribeEntryOption () {
				Identifier = "AutoSync", 
				Default = "true", // null if null
				Brief = "If true, attempt to synchronize the account to the service before operation",
				Index = 3,
				Key = "sync"
				},
			new DescribeEntryOption () {
				Identifier = "AutoApprove", 
				Default = "true", // null if null
				Brief = "If true, automatically approve pending requests with prior authorization.",
				Index = 4,
				Key = "auto"
				},
			new DescribeEntryOption () {
				Identifier = "Verbose", 
				Default = "false", // null if null
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

public partial class CarnetStatus : _CarnetStatus {
    } // class CarnetStatus

public class _ChatMessage : Goedel.Command.Dispatch {

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {		} ;





	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "message",
		Brief =  "<Unspecified>",
		HandleDelegate =  CommandLineInterpreter.Handle_ChatMessage,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			}
		};

	}

public partial class ChatMessage : _ChatMessage {
    } // class ChatMessage

public class _ChatListen : Goedel.Command.Dispatch {

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {
		new Integer ()		} ;





	/// <summary>Field accessor for option [quantum]</summary>
	public virtual Integer Quantum {
		get => _Data[0] as Integer;
		set => _Data[0]  = value;
		}

	public virtual string _Quantum {
		set => _Data[0].Parameter (value);
		}
	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "listen",
		Brief =  "<Unspecified>",
		HandleDelegate =  CommandLineInterpreter.Handle_ChatListen,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			new DescribeEntryOption () {
				Identifier = "Quantum", 
				Default = null, // null if null
				Brief = "The value of each ticket",
				Index = 0,
				Key = "quantum"
				}
			}
		};

	}

public partial class ChatListen : _ChatListen {
    } // class ChatListen

public class _ChatPoll : Goedel.Command.Dispatch {

	public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type[] {		} ;





	public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

	public readonly static DescribeCommandEntry _DescribeCommand = new   () {
		Identifier = "poll",
		Brief =  "<Unspecified>",
		HandleDelegate =  CommandLineInterpreter.Handle_ChatPoll,
		Lazy =  false,
		Entries = new List<DescribeEntry> () {
			}
		};

	}

public partial class ChatPoll : _ChatPoll {
    } // class ChatPoll


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

	public virtual ShellResult About ( About Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

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

	public virtual ShellResult AccountInfo ( AccountInfo Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult AccountGetPIN ( AccountGetPIN Options) {
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

	public virtual ShellResult ContactAdd ( ContactAdd Options) {
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

	public virtual ShellResult MessageContact ( MessageContact Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult ContactImport ( ContactImport Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult ContactExport ( ContactExport Options) {
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

	public virtual ShellResult BookmarkImport ( BookmarkImport Options) {
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

	public virtual ShellResult NetworkList ( NetworkList Options) {
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

	public virtual ShellResult ArchiveCreate ( ArchiveCreate Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult ArchiveAppend ( ArchiveAppend Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult ArchiveDelete ( ArchiveDelete Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult ArchiveIndex ( ArchiveIndex Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult ArchiveDir ( ArchiveDir Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult ArchiveExtract ( ArchiveExtract Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult ArchiveCopy ( ArchiveCopy Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult LogCreate ( LogCreate Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult LogAppend ( LogAppend Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult LogList ( LogList Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult MailAdd ( MailAdd Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult MailGet ( MailGet Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult MailList ( MailList Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult MailImport ( MailImport Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult MailDelete ( MailDelete Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult SmimeSign ( SmimeSign Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult SmimeEncrypt ( SmimeEncrypt Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult OpenpgpSign ( OpenpgpSign Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult OpenpgpEncrypt ( OpenpgpEncrypt Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult SSHCreate ( SSHCreate Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult SSHGet ( SSHGet Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult SSHList ( SSHList Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult SSHClient ( SSHClient Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult SSHHost ( SSHHost Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult SSHKnown ( SSHKnown Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult SSHDelete ( SSHDelete Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult CallsignRegister ( CallsignRegister Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult CallsignBind ( CallsignBind Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult CallsignResolve ( CallsignResolve Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult CallsignTransfer ( CallsignTransfer Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult CallsignStatus ( CallsignStatus Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult CallsignList ( CallsignList Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult WalletInvoice ( WalletInvoice Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult WalletTransfer ( WalletTransfer Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult WalletAccept ( WalletAccept Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult WalletReject ( WalletReject Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult WalletRedeem ( WalletRedeem Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult WalletList ( WalletList Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult WalletDelete ( WalletDelete Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult WalletkGet ( WalletkGet Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult CarnetMint ( CarnetMint Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult CarnetStatus ( CarnetStatus Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult ChatMessage ( ChatMessage Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult ChatListen ( ChatListen Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}

	public virtual ShellResult ChatPoll ( ChatPoll Options) {
		CommandLineInterpreter.DescribeValues (Options);
		return null;
		}


    } // class _Shell

public partial class Shell : _Shell {
    } // class Shell



