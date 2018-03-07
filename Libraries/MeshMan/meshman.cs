using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Command;
using Goedel.Utilities;

namespace Goedel.Mesh.MeshMan {
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
        public static void Help (DispatchShell Dispatch, string[] args, int index) {
            Brief(Description, DefaultCommand, Entries);
            }

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
        public static void About (DispatchShell Dispatch, string[] args, int index) {
            FileTools.About();
            }

        public static DescribeCommandEntry DescribeAbout = new DescribeCommandEntry() {
            Identifier = "about",
            HandleDelegate = About,
            Entries = new List<DescribeEntry>() { }
            };

        static bool IsFlag(char c) {
            return (c == UnixFlag) | (c == WindowsFlag) ;
            }

		static DescribeCommandSet DescribeCommandSet_Mail = new DescribeCommandSet () {
            Identifier = "mail",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"add", _MailAdd._DescribeCommand }
				} // End Entries
			};

		static DescribeCommandSet DescribeCommandSet_SSH = new DescribeCommandSet () {
            Identifier = "ssh",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"add", _SSHAdd._DescribeCommand },
				{"known", _SSHKnown._DescribeCommand },
				{"auth", _SSHAuth._DescribeCommand },
				{"public", _SSHPublic._DescribeCommand },
				{"private", _SSHPrivate._DescribeCommand }
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
				{"reset", _Reset._DescribeCommand },
				{"device", _Device._DescribeCommand },
				{"personal", _PersonalCreate._DescribeCommand },
				{"register", _Register._DescribeCommand },
				{"fingerprint", _Fingerprint._DescribeCommand },
				{"sync", _Sync._DescribeCommand },
				{"escrow", _Escrow._DescribeCommand },
				{"recover", _Recover._DescribeCommand },
				{"export", _Export._DescribeCommand },
				{"import", _Import._DescribeCommand },
				{"list", _List._DescribeCommand },
				{"dump", _Dump._DescribeCommand },
				{"pending", _Pending._DescribeCommand },
				{"connect", _Connect._DescribeCommand },
				{"accept", _Accept._DescribeCommand },
				{"complete", _Complete._DescribeCommand },
				{"keygen", _KeyGen._DescribeCommand },
				{"password", _Password._DescribeCommand },
				{"pwadd", _AddPassword._DescribeCommand },
				{"pwget", _GetPassword._DescribeCommand },
				{"pwdelete", _DeletePassword._DescribeCommand },
				{"pwdump", _DumpPassword._DescribeCommand },
				{"mail", DescribeCommandSet_Mail},
				{"ssh", DescribeCommandSet_SSH},
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


        public void MainMethod(Shell Dispatch, string[] Args) {
			Dispatcher (Entries, DefaultCommand, Dispatch, Args, 0);
            } // Main



		public static void Handle_Reset (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Reset		Options = new Reset ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Reset (Options);
			}

		public static void Handle_Device (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Device		Options = new Device ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Device (Options);
			}

		public static void Handle_PersonalCreate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			PersonalCreate		Options = new PersonalCreate ();
			ProcessOptions (Args, Index, Options);
			Dispatch.PersonalCreate (Options);
			}

		public static void Handle_Register (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Register		Options = new Register ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Register (Options);
			}

		public static void Handle_Fingerprint (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Fingerprint		Options = new Fingerprint ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Fingerprint (Options);
			}

		public static void Handle_Sync (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Sync		Options = new Sync ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Sync (Options);
			}

		public static void Handle_Escrow (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Escrow		Options = new Escrow ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Escrow (Options);
			}

		public static void Handle_Recover (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Recover		Options = new Recover ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Recover (Options);
			}

		public static void Handle_Export (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Export		Options = new Export ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Export (Options);
			}

		public static void Handle_Import (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Import		Options = new Import ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Import (Options);
			}

		public static void Handle_List (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			List		Options = new List ();
			ProcessOptions (Args, Index, Options);
			Dispatch.List (Options);
			}

		public static void Handle_Dump (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Dump		Options = new Dump ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Dump (Options);
			}

		public static void Handle_Pending (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Pending		Options = new Pending ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Pending (Options);
			}

		public static void Handle_Connect (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Connect		Options = new Connect ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Connect (Options);
			}

		public static void Handle_Accept (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Accept		Options = new Accept ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Accept (Options);
			}

		public static void Handle_Complete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Complete		Options = new Complete ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Complete (Options);
			}

		public static void Handle_KeyGen (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			KeyGen		Options = new KeyGen ();
			ProcessOptions (Args, Index, Options);
			Dispatch.KeyGen (Options);
			}

		public static void Handle_Password (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Password		Options = new Password ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Password (Options);
			}

		public static void Handle_AddPassword (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			AddPassword		Options = new AddPassword ();
			ProcessOptions (Args, Index, Options);
			Dispatch.AddPassword (Options);
			}

		public static void Handle_GetPassword (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			GetPassword		Options = new GetPassword ();
			ProcessOptions (Args, Index, Options);
			Dispatch.GetPassword (Options);
			}

		public static void Handle_DeletePassword (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DeletePassword		Options = new DeletePassword ();
			ProcessOptions (Args, Index, Options);
			Dispatch.DeletePassword (Options);
			}

		public static void Handle_DumpPassword (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DumpPassword		Options = new DumpPassword ();
			ProcessOptions (Args, Index, Options);
			Dispatch.DumpPassword (Options);
			}

		public static void Handle_MailAdd (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			MailAdd		Options = new MailAdd ();
			ProcessOptions (Args, Index, Options);
			Dispatch.MailAdd (Options);
			}

		public static void Handle_SSHAdd (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			SSHAdd		Options = new SSHAdd ();
			ProcessOptions (Args, Index, Options);
			Dispatch.SSHAdd (Options);
			}

		public static void Handle_SSHKnown (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			SSHKnown		Options = new SSHKnown ();
			ProcessOptions (Args, Index, Options);
			Dispatch.SSHKnown (Options);
			}

		public static void Handle_SSHAuth (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			SSHAuth		Options = new SSHAuth ();
			ProcessOptions (Args, Index, Options);
			Dispatch.SSHAuth (Options);
			}

		public static void Handle_SSHPublic (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			SSHPublic		Options = new SSHPublic ();
			ProcessOptions (Args, Index, Options);
			Dispatch.SSHPublic (Options);
			}

		public static void Handle_SSHPrivate (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			SSHPrivate		Options = new SSHPrivate ();
			ProcessOptions (Args, Index, Options);
			Dispatch.SSHPrivate (Options);
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
		}

	public interface IPortalAccount {
		String			Portal{get; set;}
		String			UDF{get; set;}
		String			ID{get; set;}
		}

	public interface IDeviceProfileInfo {
		Flag			DeviceNew{get; set;}
		String			DeviceUDF{get; set;}
		String			DeviceID{get; set;}
		String			DeviceDescription{get; set;}
		}


    public class _Reset : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {			} ;

		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "reset",
			Brief =  "Delete all test profiles",
			HandleDelegate =  CommandLineInterpreter.Handle_Reset,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				}
			};

		}

    public partial class Reset : _Reset {
        } // class Reset

    public class _Device : Goedel.Command.Dispatch  {

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
			HandleDelegate =  CommandLineInterpreter.Handle_Device,
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

    public partial class Device : _Device {
        } // class Device

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
			new String (),
			new Flag ()			} ;

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
		/// <summary>Field accessor for option [next]</summary>
		public virtual Flag Next {
			get => _Data[8] as Flag;
			set => _Data[8]  = value;
			}

		public virtual string _Next {
			set => _Data[8].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "personal",
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
					Default = "true", // null if null
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
					},
				new DescribeEntryOption () {
					Identifier = "Next", 
					Default = null, // null if null
					Brief = "If set ask the ",
					Index = 8,
					Key = "next"
					}
				}
			};

		}

    public partial class PersonalCreate : _PersonalCreate {
        } // class PersonalCreate

    public class _Register : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String UDF {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _UDF {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Portal {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Portal {
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "register",
			Brief =  "Register the specified profile at a new portal",
			HandleDelegate =  CommandLineInterpreter.Handle_Register,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "UDF", 
					Default = null, // null if null
					Brief = "Profile fingerprint",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "New portal account",
					Index = 1,
					Key = ""
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
					Brief = "Report results (default)",
					Index = 3,
					Key = "report"
					}
				}
			};

		}

    public partial class Register : _Register {
        } // class Register

    public class _Fingerprint : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [did]</summary>
		public virtual String DeviceID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _DeviceID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String Portal {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Portal {
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
		/// <summary>Field accessor for option [ID]</summary>
		public virtual String ID {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _ID {
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "fingerprint",
			Brief =  "Return the fingerprint of a Mesh profile",
			HandleDelegate =  CommandLineInterpreter.Handle_Fingerprint,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "DeviceID", 
					Default = null, // null if null
					Brief = "Device identifier",
					Index = 0,
					Key = "did"
					},
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "Portal account",
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
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Profile identifier",
					Index = 3,
					Key = "id"
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
					Brief = "Report results (default)",
					Index = 5,
					Key = "report"
					}
				}
			};

		}

    public partial class Fingerprint : _Fingerprint {
        } // class Fingerprint

    public class _Sync : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String Portal {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Portal {
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
		/// <summary>Field accessor for option [ID]</summary>
		public virtual String ID {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _ID {
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "sync",
			Brief =  "Synchronize local copies of Mesh profiles with the server",
			HandleDelegate =  CommandLineInterpreter.Handle_Sync,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "Portal account",
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
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Profile identifier",
					Index = 2,
					Key = "id"
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
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					}
				}
			};

		}

    public partial class Sync : _Sync {
        } // class Sync

    public class _Escrow : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new ExistingFile (),
			new Integer (),
			new Integer ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String Portal {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Portal {
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
		/// <summary>Field accessor for option [ID]</summary>
		public virtual String ID {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _ID {
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
		/// <summary>Field accessor for option [file]</summary>
		public virtual ExistingFile File {
			get => _Data[5] as ExistingFile;
			set => _Data[5]  = value;
			}

		public virtual string _File {
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

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "escrow",
			Brief =  "Create a set of key escrow shares",
			HandleDelegate =  CommandLineInterpreter.Handle_Escrow,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "Portal account",
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
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Profile identifier",
					Index = 2,
					Key = "id"
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
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 5,
					Key = "file"
					},
				new DescribeEntryOption () {
					Identifier = "Quorum", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 6,
					Key = "quorum"
					},
				new DescribeEntryOption () {
					Identifier = "Shares", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 7,
					Key = "shares"
					}
				}
			};

		}

    public partial class Escrow : _Escrow {
        } // class Escrow

    public class _Recover : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
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

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String Portal {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Portal {
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
		/// <summary>Field accessor for option [ID]</summary>
		public virtual String ID {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _ID {
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
		/// <summary>Field accessor for option [s1]</summary>
		public virtual String Share1 {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Share1 {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [s2]</summary>
		public virtual String Share2 {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _Share2 {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [s3]</summary>
		public virtual String Share3 {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _Share3 {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [s4]</summary>
		public virtual String Share4 {
			get => _Data[8] as String;
			set => _Data[8]  = value;
			}

		public virtual string _Share4 {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for option [s5]</summary>
		public virtual String Share5 {
			get => _Data[9] as String;
			set => _Data[9]  = value;
			}

		public virtual string _Share5 {
			set => _Data[9].Parameter (value);
			}
		/// <summary>Field accessor for option [s6]</summary>
		public virtual String Share6 {
			get => _Data[10] as String;
			set => _Data[10]  = value;
			}

		public virtual string _Share6 {
			set => _Data[10].Parameter (value);
			}
		/// <summary>Field accessor for option [s7]</summary>
		public virtual String Share7 {
			get => _Data[11] as String;
			set => _Data[11]  = value;
			}

		public virtual string _Share7 {
			set => _Data[11].Parameter (value);
			}
		/// <summary>Field accessor for option [s8]</summary>
		public virtual String Share8 {
			get => _Data[12] as String;
			set => _Data[12]  = value;
			}

		public virtual string _Share8 {
			set => _Data[12].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "recover",
			Brief =  "Recover escrowed profile",
			HandleDelegate =  CommandLineInterpreter.Handle_Recover,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "Portal account",
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
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Profile identifier",
					Index = 2,
					Key = "id"
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
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Share1", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 5,
					Key = "s1"
					},
				new DescribeEntryOption () {
					Identifier = "Share2", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 6,
					Key = "s2"
					},
				new DescribeEntryOption () {
					Identifier = "Share3", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 7,
					Key = "s3"
					},
				new DescribeEntryOption () {
					Identifier = "Share4", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 8,
					Key = "s4"
					},
				new DescribeEntryOption () {
					Identifier = "Share5", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 9,
					Key = "s5"
					},
				new DescribeEntryOption () {
					Identifier = "Share6", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 10,
					Key = "s6"
					},
				new DescribeEntryOption () {
					Identifier = "Share7", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 11,
					Key = "s7"
					},
				new DescribeEntryOption () {
					Identifier = "Share8", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 12,
					Key = "s8"
					}
				}
			};

		}

    public partial class Recover : _Recover {
        } // class Recover

    public class _Export : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new NewFile (),
			new String (),
			new String (),
			new String (),
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
		public virtual String Portal {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Portal {
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
		/// <summary>Field accessor for option [ID]</summary>
		public virtual String ID {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _ID {
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "export",
			Brief =  "Export the specified profile data to the specified file",
			HandleDelegate =  CommandLineInterpreter.Handle_Export,
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
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "Portal account",
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
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Profile identifier",
					Index = 3,
					Key = "id"
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
					Brief = "Report results (default)",
					Index = 5,
					Key = "report"
					}
				}
			};

		}

    public partial class Export : _Export {
        } // class Export

    public class _Import : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new NewFile (),
			new String (),
			new String (),
			new String (),
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
		public virtual String Portal {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Portal {
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
		/// <summary>Field accessor for option [ID]</summary>
		public virtual String ID {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _ID {
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "import",
			Brief =  "Import the specified profile data to the specified file",
			HandleDelegate =  CommandLineInterpreter.Handle_Import,
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
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "Portal account",
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
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Profile identifier",
					Index = 3,
					Key = "id"
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
					Brief = "Report results (default)",
					Index = 5,
					Key = "report"
					}
				}
			};

		}

    public partial class Import : _Import {
        } // class Import

    public class _List : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "list",
			Brief =  "List all profiles on the local machine",
			HandleDelegate =  CommandLineInterpreter.Handle_List,
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
					Brief = "Report results (default)",
					Index = 1,
					Key = "report"
					}
				}
			};

		}

    public partial class List : _List {
        } // class List

    public class _Dump : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String Portal {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Portal {
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
		/// <summary>Field accessor for option [ID]</summary>
		public virtual String ID {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _ID {
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "dump",
			Brief =  "Describe the specified profile",
			HandleDelegate =  CommandLineInterpreter.Handle_Dump,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "Portal account",
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
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Profile identifier",
					Index = 2,
					Key = "id"
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
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					}
				}
			};

		}

    public partial class Dump : _Dump {
        } // class Dump

    public class _Pending : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String Portal {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Portal {
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
		/// <summary>Field accessor for option [ID]</summary>
		public virtual String ID {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _ID {
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "pending",
			Brief =  "Get list of pending connection requests",
			HandleDelegate =  CommandLineInterpreter.Handle_Pending,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "Portal account",
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
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Profile identifier",
					Index = 2,
					Key = "id"
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
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					}
				}
			};

		}

    public partial class Pending : _Pending {
        } // class Pending

    public class _Connect : Goedel.Command.Dispatch ,
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
			Identifier = "connect",
			Brief =  "Connect to an existing profile registered at a portal",
			HandleDelegate =  CommandLineInterpreter.Handle_Connect,
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

    public partial class Connect : _Connect {
        } // class Connect

    public class _Accept : Goedel.Command.Dispatch ,
							IReporting,
							IPortalAccount {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Flag (),
			new Flag (),
			new String (),
			new String (),
			new String ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String DeviceUDF {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _DeviceUDF {
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
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String Portal {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _Portal {
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
		/// <summary>Field accessor for option [ID]</summary>
		public virtual String ID {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _ID {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "accept",
			Brief =  "Accept a pending connection",
			HandleDelegate =  CommandLineInterpreter.Handle_Accept,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "DeviceUDF", 
					Default = null, // null if null
					Brief = "Fingerprint of connection to accept",
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
					Brief = "Report results (default)",
					Index = 2,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "Portal account",
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
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Profile identifier",
					Index = 5,
					Key = "id"
					}
				}
			};

		}

    public partial class Accept : _Accept {
        } // class Accept

    public class _Complete : Goedel.Command.Dispatch ,
							IReporting,
							IPortalAccount {

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
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String Portal {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _Portal {
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
		/// <summary>Field accessor for option [ID]</summary>
		public virtual String ID {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _ID {
			set => _Data[4].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "complete",
			Brief =  "Complete a pending connection request",
			HandleDelegate =  CommandLineInterpreter.Handle_Complete,
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
					Brief = "Report results (default)",
					Index = 1,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "Portal account",
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
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Profile identifier",
					Index = 4,
					Key = "id"
					}
				}
			};

		}

    public partial class Complete : _Complete {
        } // class Complete

    public class _KeyGen : Goedel.Command.Dispatch ,
							IReporting,
							IPortalAccount {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Flag (),
			new Flag (),
			new String (),
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
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String Portal {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _Portal {
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
		/// <summary>Field accessor for option [ID]</summary>
		public virtual String ID {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _ID {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [alg]</summary>
		public virtual String Algorithm {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _Algorithm {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "keygen",
			Brief =  "<Unspecified>",
			HandleDelegate =  CommandLineInterpreter.Handle_KeyGen,
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
					Brief = "Report results (default)",
					Index = 1,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "Portal account",
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
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Profile identifier",
					Index = 4,
					Key = "id"
					},
				new DescribeEntryOption () {
					Identifier = "Algorithm", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 5,
					Key = "alg"
					}
				}
			};

		}

    public partial class KeyGen : _KeyGen {
        } // class KeyGen

    public class _Password : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String Portal {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Portal {
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
		/// <summary>Field accessor for option [ID]</summary>
		public virtual String ID {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _ID {
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "password",
			Brief =  "Add a web application profile to a personal profile",
			HandleDelegate =  CommandLineInterpreter.Handle_Password,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "Portal account",
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
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Profile identifier",
					Index = 2,
					Key = "id"
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
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					}
				}
			};

		}

    public partial class Password : _Password {
        } // class Password

    public class _AddPassword : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
			new String (),
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
		public virtual String Portal {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _Portal {
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
		/// <summary>Field accessor for option [ID]</summary>
		public virtual String ID {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _ID {
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "pwadd",
			Brief =  "Add password entry",
			HandleDelegate =  CommandLineInterpreter.Handle_AddPassword,
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
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "Portal account",
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
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Profile identifier",
					Index = 5,
					Key = "id"
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
					Brief = "Report results (default)",
					Index = 7,
					Key = "report"
					}
				}
			};

		}

    public partial class AddPassword : _AddPassword {
        } // class AddPassword

    public class _GetPassword : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new String (),
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
		public virtual String Portal {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Portal {
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
		/// <summary>Field accessor for option [ID]</summary>
		public virtual String ID {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _ID {
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "pwget",
			Brief =  "Lookup password entry",
			HandleDelegate =  CommandLineInterpreter.Handle_GetPassword,
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
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "Portal account",
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
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Profile identifier",
					Index = 3,
					Key = "id"
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
					Brief = "Report results (default)",
					Index = 5,
					Key = "report"
					}
				}
			};

		}

    public partial class GetPassword : _GetPassword {
        } // class GetPassword

    public class _DeletePassword : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new String (),
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
		public virtual String Portal {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Portal {
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
		/// <summary>Field accessor for option [ID]</summary>
		public virtual String ID {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _ID {
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "pwdelete",
			Brief =  "Delete password entry",
			HandleDelegate =  CommandLineInterpreter.Handle_DeletePassword,
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
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "Portal account",
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
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Profile identifier",
					Index = 3,
					Key = "id"
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
					Brief = "Report results (default)",
					Index = 5,
					Key = "report"
					}
				}
			};

		}

    public partial class DeletePassword : _DeletePassword {
        } // class DeletePassword

    public class _DumpPassword : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Flag (),
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual Flag JSON {
			get => _Data[0] as Flag;
			set => _Data[0]  = value;
			}

		public virtual string _JSON {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [portal]</summary>
		public virtual String Portal {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Portal {
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
		/// <summary>Field accessor for option [ID]</summary>
		public virtual String ID {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _ID {
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "pwdump",
			Brief =  "Describe password entry",
			HandleDelegate =  CommandLineInterpreter.Handle_DumpPassword,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "JSON", 
					Default = null, // null if null
					Brief = "Report results as JSON structure.",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "Portal account",
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
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Profile identifier",
					Index = 3,
					Key = "id"
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
					Brief = "Report results (default)",
					Index = 5,
					Key = "report"
					}
				}
			};

		}

    public partial class DumpPassword : _DumpPassword {
        } // class DumpPassword

    public class _MailAdd : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new String (),
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
		public virtual String Portal {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Portal {
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
		/// <summary>Field accessor for option [ID]</summary>
		public virtual String ID {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _ID {
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
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "Portal account",
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
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Profile identifier",
					Index = 3,
					Key = "id"
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
					Brief = "Report results (default)",
					Index = 5,
					Key = "report"
					}
				}
			};

		}

    public partial class MailAdd : _MailAdd {
        } // class MailAdd

    public class _SSHAdd : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String Portal {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Portal {
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
		/// <summary>Field accessor for option [ID]</summary>
		public virtual String ID {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _ID {
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual Flag Host {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _Host {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual Flag Client {
			get => _Data[6] as Flag;
			set => _Data[6]  = value;
			}

		public virtual string _Client {
			set => _Data[6].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "add",
			Brief =  "Add a ssh application profile to a personal profile",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHAdd,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "Portal account",
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
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Profile identifier",
					Index = 2,
					Key = "id"
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
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryParameter () {
					Identifier = "Host", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 5,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Client", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 6,
					Key = ""
					}
				}
			};

		}

    public partial class SSHAdd : _SSHAdd {
        } // class SSHAdd

    public class _SSHKnown : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String Portal {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Portal {
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
		/// <summary>Field accessor for option [ID]</summary>
		public virtual String ID {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _ID {
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "known",
			Brief =  "List the known SSH sites",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHKnown,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "Portal account",
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
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Profile identifier",
					Index = 2,
					Key = "id"
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
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					}
				}
			};

		}

    public partial class SSHKnown : _SSHKnown {
        } // class SSHKnown

    public class _SSHAuth : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String Portal {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Portal {
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
		/// <summary>Field accessor for option [ID]</summary>
		public virtual String ID {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _ID {
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "auth",
			Brief =  "List the authorized device keys",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHAuth,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "Portal account",
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
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Profile identifier",
					Index = 2,
					Key = "id"
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
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					}
				}
			};

		}

    public partial class SSHAuth : _SSHAuth {
        } // class SSHAuth

    public class _SSHPublic : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new ExistingFile ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String Portal {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Portal {
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
		/// <summary>Field accessor for option [ID]</summary>
		public virtual String ID {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _ID {
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
		/// <summary>Field accessor for option [file]</summary>
		public virtual ExistingFile File {
			get => _Data[5] as ExistingFile;
			set => _Data[5]  = value;
			}

		public virtual string _File {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "public",
			Brief =  "List the public key",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHPublic,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "Portal account",
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
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Profile identifier",
					Index = 2,
					Key = "id"
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
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 5,
					Key = "file"
					}
				}
			};

		}

    public partial class SSHPublic : _SSHPublic {
        } // class SSHPublic

    public class _SSHPrivate : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new ExistingFile ()			} ;

		/// <summary>Field accessor for option [portal]</summary>
		public virtual String Portal {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Portal {
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
		/// <summary>Field accessor for option [ID]</summary>
		public virtual String ID {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _ID {
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
		/// <summary>Field accessor for option [file]</summary>
		public virtual ExistingFile File {
			get => _Data[5] as ExistingFile;
			set => _Data[5]  = value;
			}

		public virtual string _File {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "private",
			Brief =  "List the private key",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHPrivate,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = null, // null if null
					Brief = "Portal account",
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
					Identifier = "ID", 
					Default = null, // null if null
					Brief = "Profile identifier",
					Index = 2,
					Key = "id"
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
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 5,
					Key = "file"
					}
				}
			};

		}

    public partial class SSHPrivate : _SSHPrivate {
        } // class SSHPrivate


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
    public class _Shell : global::Goedel.Command.DispatchShell {

		public virtual void Reset ( Reset Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Device ( Device Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void PersonalCreate ( PersonalCreate Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Register ( Register Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Fingerprint ( Fingerprint Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Sync ( Sync Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Escrow ( Escrow Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Recover ( Recover Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Export ( Export Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Import ( Import Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void List ( List Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Dump ( Dump Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Pending ( Pending Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Connect ( Connect Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Accept ( Accept Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Complete ( Complete Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void KeyGen ( KeyGen Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Password ( Password Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void AddPassword ( AddPassword Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void GetPassword ( GetPassword Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void DeletePassword ( DeletePassword Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void DumpPassword ( DumpPassword Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void MailAdd ( MailAdd Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void SSHAdd ( SSHAdd Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void SSHKnown ( SSHKnown Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void SSHAuth ( SSHAuth Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void SSHPublic ( SSHPublic Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void SSHPrivate ( SSHPrivate Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}


        } // class _Shell

    public partial class Shell : _Shell {
        } // class Shell

    } // namespace Shell


