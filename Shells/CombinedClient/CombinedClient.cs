using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Command;
using Goedel.Utilities;

namespace Goedel.Combined.Shell.Client {
    public partial class CommandLineInterpreter : CommandLineInterpreterBase {


		static char UnixFlag = '-';
		static char WindowsFlag = '/';

		
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Dispatch"></param>
        /// <param name="args"></param>
        /// <param name="index"></param>
        public static void Help (DispatchShell Dispatch, string[] args, int index) {
            Brief();
            }

        public static DescribeCommandEntry DescribeHelp = new DescribeCommandEntry() {
            Identifier = "help",
            HandleDelegate = Brief,
            Entries = new List<DescribeEntry>() { }
            };


        static bool IsFlag(char c) {
            return (c == UnixFlag) | (c == WindowsFlag) ;
            }

		static DescribeCommandSet DescribeCommandSet_Mesh = new DescribeCommandSet () {
            Identifier = "mesh",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"create", _PersonalCreate._DescribeCommand }
				} // End Entries
			};

		static DescribeCommandSet DescribeCommandSet_Account = new DescribeCommandSet () {
            Identifier = "account",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"create", _AccountCreate._DescribeCommand },
				{"delete", _AccountDelete._DescribeCommand },
				{"update", _AccountUpdate._DescribeCommand },
				{"get", _AccountGet._DescribeCommand }
				} // End Entries
			};

		static DescribeCommandSet DescribeCommandSet_Confirm = new DescribeCommandSet () {
            Identifier = "confirm",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"post", _ConfirmPost._DescribeCommand },
				{"status", _ConfirmStatus._DescribeCommand },
				{"pending", _ConfirmPending._DescribeCommand },
				{"accept", _ConfirmAccept._DescribeCommand },
				{"reject", _ConfirmReject._DescribeCommand }
				} // End Entries
			};

		static DescribeCommandSet DescribeCommandSet_Recrypt = new DescribeCommandSet () {
            Identifier = "recrypt",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"create", _CreateGroup._DescribeCommand },
				{"add", _RecryptAdd._DescribeCommand },
				{"delete", _RecryptDelete._DescribeCommand },
				{"encrypt", _Encrypt._DescribeCommand },
				{"decrypt", _Decrypt._DescribeCommand }
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

				Description = "Client for Mesh/Confirm service";

			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"null", _Null._DescribeCommand },
				{"mesh", DescribeCommandSet_Mesh},
				{"account", DescribeCommandSet_Account},
				{"confirm", DescribeCommandSet_Confirm},
				{"recrypt", DescribeCommandSet_Recrypt},
				{"help", DescribeHelp }
				}; // End Entries



            }



        public void MainMethod(string[] Args) {
			CombinedShell Dispatch = new CombinedShell ();

			MainMethod (Dispatch, Args);
			}


        public void MainMethod(CombinedShell Dispatch, string[] Args) {
			Dispatcher (Entries, Dispatch, Args, 0);
            } // Main



		public static void Handle_Null (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			CombinedShell Dispatch =	DispatchIn as CombinedShell;
			Null		Options = new Null ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Null (Options);
			}

		public static void Handle_PersonalCreate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			CombinedShell Dispatch =	DispatchIn as CombinedShell;
			PersonalCreate		Options = new PersonalCreate ();
			ProcessOptions (Args, Index, Options);
			Dispatch.PersonalCreate (Options);
			}

		public static void Handle_AccountCreate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			CombinedShell Dispatch =	DispatchIn as CombinedShell;
			AccountCreate		Options = new AccountCreate ();
			ProcessOptions (Args, Index, Options);
			Dispatch.AccountCreate (Options);
			}

		public static void Handle_AccountDelete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			CombinedShell Dispatch =	DispatchIn as CombinedShell;
			AccountDelete		Options = new AccountDelete ();
			ProcessOptions (Args, Index, Options);
			Dispatch.AccountDelete (Options);
			}

		public static void Handle_AccountUpdate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			CombinedShell Dispatch =	DispatchIn as CombinedShell;
			AccountUpdate		Options = new AccountUpdate ();
			ProcessOptions (Args, Index, Options);
			Dispatch.AccountUpdate (Options);
			}

		public static void Handle_AccountGet (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			CombinedShell Dispatch =	DispatchIn as CombinedShell;
			AccountGet		Options = new AccountGet ();
			ProcessOptions (Args, Index, Options);
			Dispatch.AccountGet (Options);
			}

		public static void Handle_ConfirmPost (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			CombinedShell Dispatch =	DispatchIn as CombinedShell;
			ConfirmPost		Options = new ConfirmPost ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ConfirmPost (Options);
			}

		public static void Handle_ConfirmStatus (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			CombinedShell Dispatch =	DispatchIn as CombinedShell;
			ConfirmStatus		Options = new ConfirmStatus ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ConfirmStatus (Options);
			}

		public static void Handle_ConfirmPending (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			CombinedShell Dispatch =	DispatchIn as CombinedShell;
			ConfirmPending		Options = new ConfirmPending ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ConfirmPending (Options);
			}

		public static void Handle_ConfirmAccept (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			CombinedShell Dispatch =	DispatchIn as CombinedShell;
			ConfirmAccept		Options = new ConfirmAccept ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ConfirmAccept (Options);
			}

		public static void Handle_ConfirmReject (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			CombinedShell Dispatch =	DispatchIn as CombinedShell;
			ConfirmReject		Options = new ConfirmReject ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ConfirmReject (Options);
			}

		public static void Handle_CreateGroup (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			CombinedShell Dispatch =	DispatchIn as CombinedShell;
			CreateGroup		Options = new CreateGroup ();
			ProcessOptions (Args, Index, Options);
			Dispatch.CreateGroup (Options);
			}

		public static void Handle_RecryptAdd (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			CombinedShell Dispatch =	DispatchIn as CombinedShell;
			RecryptAdd		Options = new RecryptAdd ();
			ProcessOptions (Args, Index, Options);
			Dispatch.RecryptAdd (Options);
			}

		public static void Handle_RecryptDelete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			CombinedShell Dispatch =	DispatchIn as CombinedShell;
			RecryptDelete		Options = new RecryptDelete ();
			ProcessOptions (Args, Index, Options);
			Dispatch.RecryptDelete (Options);
			}

		public static void Handle_Encrypt (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			CombinedShell Dispatch =	DispatchIn as CombinedShell;
			Encrypt		Options = new Encrypt ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Encrypt (Options);
			}

		public static void Handle_Decrypt (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			CombinedShell Dispatch =	DispatchIn as CombinedShell;
			Decrypt		Options = new Decrypt ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Decrypt (Options);
			}


	} // class Main


	// The stub class for carrying optional parameters for each command type
	// As with the main class each consists of an abstract main class 
	// with partial virtual that can be extended as required.

	// All subclasses inherit from the abstract classes Goedel.Regisrty.Dispatch 
	// and Goedel.Command.Type


    public class _Null : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {			} ;

		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "null",
			Brief =  "Do nothing yet",
			HandleDelegate =  CommandLineInterpreter.Handle_Null,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				}
			};

		}

    public partial class Null : _Null {
        } // class Null
	public interface IReporting {
		Flag			Verbose{get; set;}
		Flag			Report{get; set;}
		}

	public interface IDeviceProfileInfo {
		Flag			DeviceNew{get; set;}
		String			DeviceUDF{get; set;}
		String			DeviceID{get; set;}
		String			DeviceDescription{get; set;}
		}

	public interface IMeshProfile {
		String			MeshID{get; set;}
		}

	public interface IInputSpecifier {
		ExistingFile			In{get; set;}
		NewFile			Out{get; set;}
		Flag			Recurse{get; set;}
		}


    public class _PersonalCreate : Goedel.Command.Dispatch ,
							IReporting,
							IDeviceProfileInfo {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Description {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Description {
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
			Identifier = "create",
			Brief =  "Create new personal profile",
			HandleDelegate =  CommandLineInterpreter.Handle_PersonalCreate,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "New portal account",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Description", 
					Default = null, // null if null
					Brief = "Device description",
					Index = 1,
					Key = ""
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
					Brief = "Report results (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceNew", 
					Default = null, // null if null
					Brief = "Force creation of new profile",
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

    public class _AccountCreate : Goedel.Command.Dispatch ,
							IReporting,
							IMeshProfile {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Flag (),
			new Flag (),
			new String (),
			new String (),
			new String ()			} ;

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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String MeshID {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _MeshID {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String AccountID {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _AccountID {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [pin]</summary>
		public virtual String PIN {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _PIN {
			set => _Data[4].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "create",
			Brief =  "Create a new messaging account",
			HandleDelegate =  CommandLineInterpreter.Handle_AccountCreate,
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
					Brief = "Report results (default)",
					Index = 1,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "MeshID", 
					Default = null, // null if null
					Brief = "Mesh account identified by fingerprint or portal ID",
					Index = 2,
					Key = "mesh"
					},
				new DescribeEntryParameter () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "The account identifier in name@example.com format",
					Index = 3,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "PIN", 
					Default = null, // null if null
					Brief = "One time use authenticator",
					Index = 4,
					Key = "pin"
					}
				}
			};

		}

    public partial class AccountCreate : _AccountCreate {
        } // class AccountCreate

    public class _AccountDelete : Goedel.Command.Dispatch ,
							IReporting,
							IMeshProfile {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Flag (),
			new Flag (),
			new String (),
			new String ()			} ;

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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String MeshID {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _MeshID {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String AccountID {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _AccountID {
			set => _Data[3].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "delete",
			Brief =  "Delete a messaging account",
			HandleDelegate =  CommandLineInterpreter.Handle_AccountDelete,
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
					Brief = "Report results (default)",
					Index = 1,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "MeshID", 
					Default = null, // null if null
					Brief = "Mesh account identified by fingerprint or portal ID",
					Index = 2,
					Key = "mesh"
					},
				new DescribeEntryParameter () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "The account identifier in name@example.com format",
					Index = 3,
					Key = ""
					}
				}
			};

		}

    public partial class AccountDelete : _AccountDelete {
        } // class AccountDelete

    public class _AccountUpdate : Goedel.Command.Dispatch ,
							IReporting,
							IMeshProfile {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Flag (),
			new Flag (),
			new String (),
			new String ()			} ;

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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String MeshID {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _MeshID {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String AccountID {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _AccountID {
			set => _Data[3].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "update",
			Brief =  "Update a messaging account to add or remove features",
			HandleDelegate =  CommandLineInterpreter.Handle_AccountUpdate,
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
					Brief = "Report results (default)",
					Index = 1,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "MeshID", 
					Default = null, // null if null
					Brief = "Mesh account identified by fingerprint or portal ID",
					Index = 2,
					Key = "mesh"
					},
				new DescribeEntryParameter () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "The account identifier in name@example.com format",
					Index = 3,
					Key = ""
					}
				}
			};

		}

    public partial class AccountUpdate : _AccountUpdate {
        } // class AccountUpdate

    public class _AccountGet : Goedel.Command.Dispatch ,
							IReporting,
							IMeshProfile {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Flag (),
			new Flag (),
			new String (),
			new String ()			} ;

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
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String MeshID {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _MeshID {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String AccountID {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _AccountID {
			set => _Data[3].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "get",
			Brief =  "Get account status",
			HandleDelegate =  CommandLineInterpreter.Handle_AccountGet,
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
					Brief = "Report results (default)",
					Index = 1,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "MeshID", 
					Default = null, // null if null
					Brief = "Mesh account identified by fingerprint or portal ID",
					Index = 2,
					Key = "mesh"
					},
				new DescribeEntryParameter () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "The account identifier in name@example.com format",
					Index = 3,
					Key = ""
					}
				}
			};

		}

    public partial class AccountGet : _AccountGet {
        } // class AccountGet

    public class _ConfirmPost : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "post",
			Brief =  "Post a confirmation request",
			HandleDelegate =  CommandLineInterpreter.Handle_ConfirmPost,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "The responder account identifier in name@example.com format",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Text", 
					Default = null, // null if null
					Brief = "The text of the confirmation request",
					Index = 1,
					Key = ""
					}
				}
			};

		}

    public partial class ConfirmPost : _ConfirmPost {
        } // class ConfirmPost

    public class _ConfirmStatus : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String ID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _ID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [cancel]</summary>
		public virtual Flag Cancel {
			get => _Data[1] as Flag;
			set => _Data[1]  = value;
			}

		public virtual string _Cancel {
			set => _Data[1].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "status",
			Brief =  "Obtain the satus of a previously posted request.",
			HandleDelegate =  CommandLineInterpreter.Handle_ConfirmStatus,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "The broker ID of the confirmation request",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Cancel", 
					Default = null, // null if null
					Brief = "Cancel the request if no response has been received.",
					Index = 1,
					Key = "cancel"
					}
				}
			};

		}

    public partial class ConfirmStatus : _ConfirmStatus {
        } // class ConfirmStatus

    public class _ConfirmPending : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String ()			} ;

		/// <summary>Field accessor for option [id]</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "pending",
			Brief =  "Get pending confirmation requests",
			HandleDelegate =  CommandLineInterpreter.Handle_ConfirmPending,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "The responder account identifier in name@example.com format",
					Index = 0,
					Key = "id"
					}
				}
			};

		}

    public partial class ConfirmPending : _ConfirmPending {
        } // class ConfirmPending

    public class _ConfirmAccept : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String ID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _ID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [id]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "accept",
			Brief =  "Accept a pending confirmation request",
			HandleDelegate =  CommandLineInterpreter.Handle_ConfirmAccept,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "The broker ID of the confirmation request",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "The responder account identifier in name@example.com format",
					Index = 1,
					Key = "id"
					}
				}
			};

		}

    public partial class ConfirmAccept : _ConfirmAccept {
        } // class ConfirmAccept

    public class _ConfirmReject : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String ID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _ID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [id]</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "reject",
			Brief =  "Reject a pending confirmation request",
			HandleDelegate =  CommandLineInterpreter.Handle_ConfirmReject,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "The broker ID of the confirmation request",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "The responder account identifier in name@example.com format",
					Index = 1,
					Key = "id"
					}
				}
			};

		}

    public partial class ConfirmReject : _ConfirmReject {
        } // class ConfirmReject

    public class _CreateGroup : Goedel.Command.Dispatch ,
							IMeshProfile {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String ()			} ;

		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String MeshID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _MeshID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String GroupID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _GroupID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String AccountID {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _AccountID {
			set => _Data[2].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "create",
			Brief =  "Create a recryption group",
			HandleDelegate =  CommandLineInterpreter.Handle_CreateGroup,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "MeshID", 
					Default = null, // null if null
					Brief = "Mesh account identified by fingerprint or portal ID",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryParameter () {
					Identifier = "GroupID", 
					Default = null, // null if null
					Brief = "The group identifier in name@example.com format",
					Index = 1,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "The initial account administrator",
					Index = 2,
					Key = ""
					}
				}
			};

		}

    public partial class CreateGroup : _CreateGroup {
        } // class CreateGroup

    public class _RecryptAdd : Goedel.Command.Dispatch ,
							IMeshProfile {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String ()			} ;

		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String MeshID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _MeshID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String GroupID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _GroupID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String AccountID {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _AccountID {
			set => _Data[2].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "add",
			Brief =  "Add a member to a recryption group.",
			HandleDelegate =  CommandLineInterpreter.Handle_RecryptAdd,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "MeshID", 
					Default = null, // null if null
					Brief = "Mesh account identified by fingerprint or portal ID",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryParameter () {
					Identifier = "GroupID", 
					Default = null, // null if null
					Brief = "The recryption group identifier in name@example.com format",
					Index = 1,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "The user account identifier in name@example.com format",
					Index = 2,
					Key = ""
					}
				}
			};

		}

    public partial class RecryptAdd : _RecryptAdd {
        } // class RecryptAdd

    public class _RecryptDelete : Goedel.Command.Dispatch ,
							IMeshProfile {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String ()			} ;

		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String MeshID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _MeshID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String GroupID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _GroupID {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String AccountID {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _AccountID {
			set => _Data[2].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "delete",
			Brief =  "Delete a member from a recryption group.",
			HandleDelegate =  CommandLineInterpreter.Handle_RecryptDelete,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "MeshID", 
					Default = null, // null if null
					Brief = "Mesh account identified by fingerprint or portal ID",
					Index = 0,
					Key = "mesh"
					},
				new DescribeEntryParameter () {
					Identifier = "GroupID", 
					Default = null, // null if null
					Brief = "The recryption group identifier in name@example.com format",
					Index = 1,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "The user account identifier in name@example.com format",
					Index = 2,
					Key = ""
					}
				}
			};

		}

    public partial class RecryptDelete : _RecryptDelete {
        } // class RecryptDelete

    public class _Encrypt : Goedel.Command.Dispatch ,
							IInputSpecifier {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new ExistingFile (),
			new NewFile (),
			new Flag (),
			new Flag (),
			new String ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String GroupID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _GroupID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [in]</summary>
		public virtual ExistingFile In {
			get => _Data[1] as ExistingFile;
			set => _Data[1]  = value;
			}

		public virtual string _In {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [out]</summary>
		public virtual NewFile Out {
			get => _Data[2] as NewFile;
			set => _Data[2]  = value;
			}

		public virtual string _Out {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [Recurse]</summary>
		public virtual Flag Recurse {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Recurse {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [Upload]</summary>
		public virtual Flag Upload {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Upload {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [path]</summary>
		public virtual String Path {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Path {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "encrypt",
			Brief =  "Encrypt a file or files",
			HandleDelegate =  CommandLineInterpreter.Handle_Encrypt,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "GroupID", 
					Default = null, // null if null
					Brief = "The recryption group identifier in name@example.com format",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "In", 
					Default = null, // null if null
					Brief = "The input file",
					Index = 1,
					Key = "in"
					},
				new DescribeEntryOption () {
					Identifier = "Out", 
					Default = null, // null if null
					Brief = "The output file",
					Index = 2,
					Key = "out"
					},
				new DescribeEntryOption () {
					Identifier = "Recurse", 
					Default = null, // null if null
					Brief = "Perform operation recursively on subdirectories",
					Index = 3,
					Key = "recurse"
					},
				new DescribeEntryOption () {
					Identifier = "Upload", 
					Default = null, // null if null
					Brief = "Upload the encrypted file to the service",
					Index = 4,
					Key = "upload"
					},
				new DescribeEntryOption () {
					Identifier = "Path", 
					Default = null, // null if null
					Brief = "Path to store the encrypted file to",
					Index = 5,
					Key = "path"
					}
				}
			};

		}

    public partial class Encrypt : _Encrypt {
        } // class Encrypt

    public class _Decrypt : Goedel.Command.Dispatch ,
							IInputSpecifier,
							IMeshProfile {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new ExistingFile (),
			new NewFile (),
			new Flag (),
			new String (),
			new String ()			} ;

		/// <summary>Field accessor for option [in]</summary>
		public virtual ExistingFile In {
			get => _Data[0] as ExistingFile;
			set => _Data[0]  = value;
			}

		public virtual string _In {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [out]</summary>
		public virtual NewFile Out {
			get => _Data[1] as NewFile;
			set => _Data[1]  = value;
			}

		public virtual string _Out {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [Recurse]</summary>
		public virtual Flag Recurse {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _Recurse {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [mesh]</summary>
		public virtual String MeshID {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _MeshID {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [path]</summary>
		public virtual String Path {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _Path {
			set => _Data[4].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "decrypt",
			Brief =  "Decrypt a file or files",
			HandleDelegate =  CommandLineInterpreter.Handle_Decrypt,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "In", 
					Default = null, // null if null
					Brief = "The input file",
					Index = 0,
					Key = "in"
					},
				new DescribeEntryOption () {
					Identifier = "Out", 
					Default = null, // null if null
					Brief = "The output file",
					Index = 1,
					Key = "out"
					},
				new DescribeEntryOption () {
					Identifier = "Recurse", 
					Default = null, // null if null
					Brief = "Perform operation recursively on subdirectories",
					Index = 2,
					Key = "recurse"
					},
				new DescribeEntryOption () {
					Identifier = "MeshID", 
					Default = null, // null if null
					Brief = "Mesh account identified by fingerprint or portal ID",
					Index = 3,
					Key = "mesh"
					},
				new DescribeEntryOption () {
					Identifier = "Path", 
					Default = null, // null if null
					Brief = "Path to store the decrypted file to",
					Index = 4,
					Key = "path"
					}
				}
			};

		}

    public partial class Decrypt : _Decrypt {
        } // class Decrypt


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


    public partial class  ExistingFile : _ExistingFile {
        public static ExistingFile Factory (string Value) {
            var Result = new ExistingFile();
            Result.Default(Value);
            return Result;
            }
        } // ExistingFile


    public partial class  NewFile : _NewFile {
        public static NewFile Factory (string Value) {
            var Result = new NewFile();
            Result.Default(Value);
            return Result;
            }
        } // NewFile



	// The stub class just contains routines that echo their arguments and
	// write 'not yet implemented'

	// Eventually there will be a compiler option to suppress the debugging
	// to eliminate the redundant code
    public class _CombinedShell : global::Goedel.Command.DispatchShell {

		public virtual void Null ( Null Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void PersonalCreate ( PersonalCreate Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void AccountCreate ( AccountCreate Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void AccountDelete ( AccountDelete Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void AccountUpdate ( AccountUpdate Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void AccountGet ( AccountGet Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void ConfirmPost ( ConfirmPost Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void ConfirmStatus ( ConfirmStatus Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void ConfirmPending ( ConfirmPending Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void ConfirmAccept ( ConfirmAccept Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void ConfirmReject ( ConfirmReject Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void CreateGroup ( CreateGroup Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void RecryptAdd ( RecryptAdd Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void RecryptDelete ( RecryptDelete Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Encrypt ( Encrypt Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Decrypt ( Decrypt Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}


        } // class _CombinedShell

    public partial class CombinedShell : _CombinedShell {
        } // class CombinedShell

    } // namespace CombinedShell


