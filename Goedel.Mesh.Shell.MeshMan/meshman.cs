using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Command;
using Goedel.Utilities;

namespace Goedel.Mesh.MeshMan {
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Dispatch"></param>
        /// <param name="args"></param>
        /// <param name="index"></param>
        public static new void About (DispatchShell Dispatch, string[] args, int index) {
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
				{"verify", _Verify._DescribeCommand },
				{"personal", _Personal._DescribeCommand },
				{"register", _Register._DescribeCommand },
				{"deregister", _Deregister._DescribeCommand },
				{"fingerprint", _Fingerprint._DescribeCommand },
				{"sync", _Sync._DescribeCommand },
				{"escrow", _Escrow._DescribeCommand },
				{"export", _Export._DescribeCommand },
				{"import", _Import._DescribeCommand },
				{"list", _List._DescribeCommand },
				{"dump", _Dump._DescribeCommand },
				{"pending", _Pending._DescribeCommand },
				{"connect", _Connect._DescribeCommand },
				{"accept", _Accept._DescribeCommand },
				{"complete", _Complete._DescribeCommand },
				{"password", _Password._DescribeCommand },
				{"pwadd", _AddPassword._DescribeCommand },
				{"pwget", _GetPassword._DescribeCommand },
				{"pwdelete", _DeletePassword._DescribeCommand },
				{"pwdump", _DumpPassword._DescribeCommand },
				{"mail", _Mail._DescribeCommand },
				{"ssh", _SSH._DescribeCommand },
				{"sshauth", _SSHAuth._DescribeCommand },
				{"sshknown", _SSHKnown._DescribeCommand },
				{"sshpub", _SSHPublic._DescribeCommand },
				{"sshpriv", _SSHPrivate._DescribeCommand },
				{"confirm", _Confirm._DescribeCommand },
				{"confimpost", _ConfirmPost._DescribeCommand },
				{"confimget", _ConfirmGet._DescribeCommand },
				{"confimaccept", _ConfirmAccept._DescribeCommand },
				{"confimreject", _ConfirmReject._DescribeCommand },
				{"recrypt", _Recrypt._DescribeCommand },
				{"recryptgroup", _RecryptGroup._DescribeCommand },
				{"recryptadd", _RecryptAdd._DescribeCommand },
				{"recryptdel", _RecryptDelete._DescribeCommand },
				{"encrypt", _Encrypt._DescribeCommand },
				{"decrypt", _Decrypt._DescribeCommand },
				{"help", DescribeHelp }
				}; // End Entries



            }



        public void MainMethod(string[] Args) {
			Shell Dispatch = new Shell ();

			MainMethod (Dispatch, Args);
			}


        public void MainMethod(Shell Dispatch, string[] Args) {
			Dispatcher (Entries, Dispatch, Args, 0);
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

		public static void Handle_Verify (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Verify		Options = new Verify ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Verify (Options);
			}

		public static void Handle_Personal (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Personal		Options = new Personal ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Personal (Options);
			}

		public static void Handle_Register (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Register		Options = new Register ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Register (Options);
			}

		public static void Handle_Deregister (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Deregister		Options = new Deregister ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Deregister (Options);
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

		public static void Handle_Mail (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Mail		Options = new Mail ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Mail (Options);
			}

		public static void Handle_SSH (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			SSH		Options = new SSH ();
			ProcessOptions (Args, Index, Options);
			Dispatch.SSH (Options);
			}

		public static void Handle_SSHAuth (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			SSHAuth		Options = new SSHAuth ();
			ProcessOptions (Args, Index, Options);
			Dispatch.SSHAuth (Options);
			}

		public static void Handle_SSHKnown (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			SSHKnown		Options = new SSHKnown ();
			ProcessOptions (Args, Index, Options);
			Dispatch.SSHKnown (Options);
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

		public static void Handle_Confirm (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Confirm		Options = new Confirm ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Confirm (Options);
			}

		public static void Handle_ConfirmPost (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ConfirmPost		Options = new ConfirmPost ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ConfirmPost (Options);
			}

		public static void Handle_ConfirmGet (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ConfirmGet		Options = new ConfirmGet ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ConfirmGet (Options);
			}

		public static void Handle_ConfirmAccept (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ConfirmAccept		Options = new ConfirmAccept ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ConfirmAccept (Options);
			}

		public static void Handle_ConfirmReject (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			ConfirmReject		Options = new ConfirmReject ();
			ProcessOptions (Args, Index, Options);
			Dispatch.ConfirmReject (Options);
			}

		public static void Handle_Recrypt (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Recrypt		Options = new Recrypt ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Recrypt (Options);
			}

		public static void Handle_RecryptGroup (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			RecryptGroup		Options = new RecryptGroup ();
			ProcessOptions (Args, Index, Options);
			Dispatch.RecryptGroup (Options);
			}

		public static void Handle_RecryptAdd (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			RecryptAdd		Options = new RecryptAdd ();
			ProcessOptions (Args, Index, Options);
			Dispatch.RecryptAdd (Options);
			}

		public static void Handle_RecryptDelete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			RecryptDelete		Options = new RecryptDelete ();
			ProcessOptions (Args, Index, Options);
			Dispatch.RecryptDelete (Options);
			}

		public static void Handle_Encrypt (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Encrypt		Options = new Encrypt ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Encrypt (Options);
			}

		public static void Handle_Decrypt (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
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

	public interface IReporting {
		Flag			Verbose{get; set;}
		Flag			Report{get; set;}
		}

	public interface IPortalAccount {
		String			Portal{get; set;}
		String			UDF{get; set;}
		}

	public interface IApplicationProfile {
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
					Default = "",
					Brief = "Device identifier",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "DeviceDescription", 
					Default = "",
					Brief = "Device description",
					Index = 1,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Default", 
					Default = "",
					Brief = "Make the new device profile the default",
					Index = 2,
					Key = "default"
					}
				}
			};

		}

    public partial class Device : _Device {
        } // class Device

    public class _Verify : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "verify",
			Brief =  "Verify requested portal address",
			HandleDelegate =  CommandLineInterpreter.Handle_Verify,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Test portal account",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 1,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 2,
					Key = "report"
					}
				}
			};

		}

    public partial class Verify : _Verify {
        } // class Verify

    public class _Personal : Goedel.Command.Dispatch ,
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
			Identifier = "personal",
			Brief =  "Create new personal profile",
			HandleDelegate =  CommandLineInterpreter.Handle_Personal,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Portal", 
					Default = "",
					Brief = "New portal account",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Description", 
					Default = "",
					Brief = "Device description",
					Index = 1,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceNew", 
					Default = "",
					Brief = "Force creation of new profile",
					Index = 4,
					Key = "new"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceUDF", 
					Default = "",
					Brief = "Device profile fingerprint",
					Index = 5,
					Key = "dudf"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceID", 
					Default = "",
					Brief = "Device identifier",
					Index = 6,
					Key = "did"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceDescription", 
					Default = "",
					Brief = "Device description",
					Index = 7,
					Key = "dd"
					}
				}
			};

		}

    public partial class Personal : _Personal {
        } // class Personal

    public class _Register : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
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
		/// <summary>Field accessor for parameter []</summary>
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "register",
			Brief =  "Register the specified profile at a new portal",
			HandleDelegate =  CommandLineInterpreter.Handle_Register,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Portal", 
					Default = "",
					Brief = "New portal account",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 1,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 3,
					Key = "report"
					}
				}
			};

		}

    public partial class Register : _Register {
        } // class Register

    public class _Deregister : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "deregister",
			Brief =  "Deregister the specified profile at a portal",
			HandleDelegate =  CommandLineInterpreter.Handle_Deregister,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Portal", 
					Default = "",
					Brief = "New portal account",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 1,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 2,
					Key = "report"
					}
				}
			};

		}

    public partial class Deregister : _Deregister {
        } // class Deregister

    public class _Fingerprint : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
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
			Identifier = "fingerprint",
			Brief =  "Return the fingerprint of a Mesh profile",
			HandleDelegate =  CommandLineInterpreter.Handle_Fingerprint,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "DeviceID", 
					Default = "",
					Brief = "Device identifier",
					Index = 0,
					Key = "did"
					},
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 4,
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
			Identifier = "sync",
			Brief =  "Synchronize local copies of Mesh profiles with the server",
			HandleDelegate =  CommandLineInterpreter.Handle_Sync,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 3,
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
			new Flag (),
			new Flag (),
			new Integer (),
			new Integer (),
			new NewFile ()			} ;

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
		/// <summary>Field accessor for option [quorum]</summary>
		public virtual Integer Quorum {
			get => _Data[4] as Integer;
			set => _Data[4]  = value;
			}

		public virtual string _Quorum {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [shares]</summary>
		public virtual Integer Shares {
			get => _Data[5] as Integer;
			set => _Data[5]  = value;
			}

		public virtual string _Shares {
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
			Identifier = "escrow",
			Brief =  "Create a set of key escrow shares",
			HandleDelegate =  CommandLineInterpreter.Handle_Escrow,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Quorum", 
					Default = "",
					Brief = "<Unspecified>",
					Index = 4,
					Key = "quorum"
					},
				new DescribeEntryOption () {
					Identifier = "Shares", 
					Default = "",
					Brief = "<Unspecified>",
					Index = 5,
					Key = "shares"
					},
				new DescribeEntryOption () {
					Identifier = "File", 
					Default = "",
					Brief = "<Unspecified>",
					Index = 6,
					Key = "file"
					}
				}
			};

		}

    public partial class Escrow : _Escrow {
        } // class Escrow

    public class _Export : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new NewFile (),
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
			Identifier = "export",
			Brief =  "Export the specified profile data to the specified file",
			HandleDelegate =  CommandLineInterpreter.Handle_Export,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "File", 
					Default = "",
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 4,
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
			Identifier = "import",
			Brief =  "Import the specified profile data to the specified file",
			HandleDelegate =  CommandLineInterpreter.Handle_Import,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "File", 
					Default = "",
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 4,
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
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 0,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
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
			Identifier = "dump",
			Brief =  "Describe the specified profile",
			HandleDelegate =  CommandLineInterpreter.Handle_Dump,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 3,
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
			Identifier = "pending",
			Brief =  "Get list of pending connection requests",
			HandleDelegate =  CommandLineInterpreter.Handle_Pending,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 3,
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
					Default = "",
					Brief = "New portal account",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "PIN", 
					Default = "",
					Brief = "One time use authenticator",
					Index = 1,
					Key = "pin"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceNew", 
					Default = "",
					Brief = "Force creation of new profile",
					Index = 4,
					Key = "new"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceUDF", 
					Default = "",
					Brief = "Device profile fingerprint",
					Index = 5,
					Key = "dudf"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceID", 
					Default = "",
					Brief = "Device identifier",
					Index = 6,
					Key = "did"
					},
				new DescribeEntryOption () {
					Identifier = "DeviceDescription", 
					Default = "",
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "accept",
			Brief =  "Accept a pending connection",
			HandleDelegate =  CommandLineInterpreter.Handle_Accept,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "DeviceUDF", 
					Default = "",
					Brief = "Fingerprint of connection to accept",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 1,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 2,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 3,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 4,
					Key = "udf"
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
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "complete",
			Brief =  "Complete a pending connection request",
			HandleDelegate =  CommandLineInterpreter.Handle_Complete,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 0,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 1,
					Key = "report"
					},
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 2,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 3,
					Key = "udf"
					}
				}
			};

		}

    public partial class Complete : _Complete {
        } // class Complete

    public class _Password : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
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
			Identifier = "password",
			Brief =  "Add a web application profile to a personal profile",
			HandleDelegate =  CommandLineInterpreter.Handle_Password,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 3,
					Key = "report"
					}
				}
			};

		}

    public partial class Password : _Password {
        } // class Password

    public class _AddPassword : Goedel.Command.Dispatch ,
							IApplicationProfile,
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
		/// <summary>Field accessor for option [id]</summary>
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
					Default = "",
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Username", 
					Default = "",
					Brief = "<Unspecified>",
					Index = 1,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Password", 
					Default = "",
					Brief = "<Unspecified>",
					Index = 2,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 3,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 4,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "ID", 
					Default = "",
					Brief = "Application profile friendly name",
					Index = 5,
					Key = "id"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 6,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
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
							IApplicationProfile,
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
		/// <summary>Field accessor for option [id]</summary>
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
					Default = "",
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "ID", 
					Default = "",
					Brief = "Application profile friendly name",
					Index = 3,
					Key = "id"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 4,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
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
							IApplicationProfile,
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
		/// <summary>Field accessor for option [id]</summary>
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
					Default = "",
					Brief = "Domain name of Web site",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "ID", 
					Default = "",
					Brief = "Application profile friendly name",
					Index = 3,
					Key = "id"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 4,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
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
							IApplicationProfile,
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
		/// <summary>Field accessor for option [id]</summary>
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
					Default = "",
					Brief = "Report results as JSON structure.",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 1,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 2,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "ID", 
					Default = "",
					Brief = "Application profile friendly name",
					Index = 3,
					Key = "id"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 4,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 5,
					Key = "report"
					}
				}
			};

		}

    public partial class DumpPassword : _DumpPassword {
        } // class DumpPassword

    public class _Mail : Goedel.Command.Dispatch ,
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
		/// <summary>Field accessor for option [ca]</summary>
		public virtual String CA {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _CA {
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
			Identifier = "mail",
			Brief =  "Add a mail application profile to a personal profile",
			HandleDelegate =  CommandLineInterpreter.Handle_Mail,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Address", 
					Default = "",
					Brief = "Mail account to create profile from",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "CA", 
					Default = "",
					Brief = "Domain name of CA",
					Index = 1,
					Key = "ca"
					},
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 2,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 3,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 4,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 5,
					Key = "report"
					}
				}
			};

		}

    public partial class Mail : _Mail {
        } // class Mail

    public class _SSH : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual Flag Install {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Install {
			set => _Data[4].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "ssh",
			Brief =  "Add a ssh application profile to a personal profile",
			HandleDelegate =  CommandLineInterpreter.Handle_SSH,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryParameter () {
					Identifier = "Install", 
					Default = "",
					Brief = "<Unspecified>",
					Index = 4,
					Key = ""
					}
				}
			};

		}

    public partial class SSH : _SSH {
        } // class SSH

    public class _SSHAuth : Goedel.Command.Dispatch ,
							IApplicationProfile,
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
		/// <summary>Field accessor for option [id]</summary>
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
			Identifier = "sshauth",
			Brief =  "List the SSH Authorized keys",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHAuth,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "ID", 
					Default = "",
					Brief = "Application profile friendly name",
					Index = 2,
					Key = "id"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryParameter () {
					Identifier = "Host", 
					Default = "",
					Brief = "<Unspecified>",
					Index = 5,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Client", 
					Default = "",
					Brief = "<Unspecified>",
					Index = 6,
					Key = ""
					}
				}
			};

		}

    public partial class SSHAuth : _SSHAuth {
        } // class SSHAuth

    public class _SSHKnown : Goedel.Command.Dispatch ,
							IApplicationProfile,
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
		/// <summary>Field accessor for option [id]</summary>
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
			Identifier = "sshknown",
			Brief =  "List the SSH Known Hosts",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHKnown,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "ID", 
					Default = "",
					Brief = "Application profile friendly name",
					Index = 2,
					Key = "id"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryParameter () {
					Identifier = "Host", 
					Default = "",
					Brief = "<Unspecified>",
					Index = 5,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Client", 
					Default = "",
					Brief = "<Unspecified>",
					Index = 6,
					Key = ""
					}
				}
			};

		}

    public partial class SSHKnown : _SSHKnown {
        } // class SSHKnown

    public class _SSHPublic : Goedel.Command.Dispatch ,
							IApplicationProfile,
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
		/// <summary>Field accessor for option [id]</summary>
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
			Identifier = "sshpub",
			Brief =  "Return the ssh public key for this device",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHPublic,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "ID", 
					Default = "",
					Brief = "Application profile friendly name",
					Index = 2,
					Key = "id"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryParameter () {
					Identifier = "Host", 
					Default = "",
					Brief = "<Unspecified>",
					Index = 5,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Client", 
					Default = "",
					Brief = "<Unspecified>",
					Index = 6,
					Key = ""
					}
				}
			};

		}

    public partial class SSHPublic : _SSHPublic {
        } // class SSHPublic

    public class _SSHPrivate : Goedel.Command.Dispatch ,
							IApplicationProfile,
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
		/// <summary>Field accessor for option [id]</summary>
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
			Identifier = "sshpriv",
			Brief =  "Return the ss private key for this device",
			HandleDelegate =  CommandLineInterpreter.Handle_SSHPrivate,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "ID", 
					Default = "",
					Brief = "Application profile friendly name",
					Index = 2,
					Key = "id"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					},
				new DescribeEntryParameter () {
					Identifier = "Host", 
					Default = "",
					Brief = "<Unspecified>",
					Index = 5,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Client", 
					Default = "",
					Brief = "<Unspecified>",
					Index = 6,
					Key = ""
					}
				}
			};

		}

    public partial class SSHPrivate : _SSHPrivate {
        } // class SSHPrivate

    public class _Confirm : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Address {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _Address {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [pin]</summary>
		public virtual String PIN {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _PIN {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "confirm",
			Brief =  "Add a confirmation profile account",
			HandleDelegate =  CommandLineInterpreter.Handle_Confirm,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryParameter () {
					Identifier = "Address", 
					Default = "",
					Brief = "Confirmation account to create ",
					Index = 4,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "PIN", 
					Default = "",
					Brief = "One time use authenticator",
					Index = 5,
					Key = "pin"
					}
				}
			};

		}

    public partial class Confirm : _Confirm {
        } // class Confirm

    public class _ConfirmPost : Goedel.Command.Dispatch ,
							IApplicationProfile,
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
		/// <summary>Field accessor for option [id]</summary>
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
			Identifier = "confimpost",
			Brief =  "Post a confirmation request to an account",
			HandleDelegate =  CommandLineInterpreter.Handle_ConfirmPost,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "ID", 
					Default = "",
					Brief = "Application profile friendly name",
					Index = 2,
					Key = "id"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					}
				}
			};

		}

    public partial class ConfirmPost : _ConfirmPost {
        } // class ConfirmPost

    public class _ConfirmGet : Goedel.Command.Dispatch ,
							IApplicationProfile,
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
		/// <summary>Field accessor for option [id]</summary>
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
			Identifier = "confimget",
			Brief =  "List the pending confirmation requests for this account",
			HandleDelegate =  CommandLineInterpreter.Handle_ConfirmGet,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "ID", 
					Default = "",
					Brief = "Application profile friendly name",
					Index = 2,
					Key = "id"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					}
				}
			};

		}

    public partial class ConfirmGet : _ConfirmGet {
        } // class ConfirmGet

    public class _ConfirmAccept : Goedel.Command.Dispatch ,
							IApplicationProfile,
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
		/// <summary>Field accessor for option [id]</summary>
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
			Identifier = "confimaccept",
			Brief =  "Accept a confirmation request",
			HandleDelegate =  CommandLineInterpreter.Handle_ConfirmAccept,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "ID", 
					Default = "",
					Brief = "Application profile friendly name",
					Index = 2,
					Key = "id"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					}
				}
			};

		}

    public partial class ConfirmAccept : _ConfirmAccept {
        } // class ConfirmAccept

    public class _ConfirmReject : Goedel.Command.Dispatch ,
							IApplicationProfile,
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
		/// <summary>Field accessor for option [id]</summary>
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
			Identifier = "confimreject",
			Brief =  "Reject a confirmation request",
			HandleDelegate =  CommandLineInterpreter.Handle_ConfirmReject,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "ID", 
					Default = "",
					Brief = "Application profile friendly name",
					Index = 2,
					Key = "id"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					}
				}
			};

		}

    public partial class ConfirmReject : _ConfirmReject {
        } // class ConfirmReject

    public class _Recrypt : Goedel.Command.Dispatch ,
							IPortalAccount,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Flag (),
			new Flag (),
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Address {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _Address {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [pin]</summary>
		public virtual String PIN {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _PIN {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "recrypt",
			Brief =  "Add a confirmation profile account",
			HandleDelegate =  CommandLineInterpreter.Handle_Recrypt,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 2,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 3,
					Key = "report"
					},
				new DescribeEntryParameter () {
					Identifier = "Address", 
					Default = "",
					Brief = "Confirmation account to create ",
					Index = 4,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "PIN", 
					Default = "",
					Brief = "One time use authenticator",
					Index = 5,
					Key = "pin"
					}
				}
			};

		}

    public partial class Recrypt : _Recrypt {
        } // class Recrypt

    public class _RecryptGroup : Goedel.Command.Dispatch ,
							IApplicationProfile,
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
		/// <summary>Field accessor for option [id]</summary>
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
			Identifier = "recryptgroup",
			Brief =  "Create a new recryption group",
			HandleDelegate =  CommandLineInterpreter.Handle_RecryptGroup,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "ID", 
					Default = "",
					Brief = "Application profile friendly name",
					Index = 2,
					Key = "id"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					}
				}
			};

		}

    public partial class RecryptGroup : _RecryptGroup {
        } // class RecryptGroup

    public class _RecryptAdd : Goedel.Command.Dispatch ,
							IApplicationProfile,
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
		/// <summary>Field accessor for option [id]</summary>
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
			Identifier = "recryptadd",
			Brief =  "Add a member to a recryption group",
			HandleDelegate =  CommandLineInterpreter.Handle_RecryptAdd,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "ID", 
					Default = "",
					Brief = "Application profile friendly name",
					Index = 2,
					Key = "id"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					}
				}
			};

		}

    public partial class RecryptAdd : _RecryptAdd {
        } // class RecryptAdd

    public class _RecryptDelete : Goedel.Command.Dispatch ,
							IApplicationProfile,
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
		/// <summary>Field accessor for option [id]</summary>
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
			Identifier = "recryptdel",
			Brief =  "Remove a member from a recryption group",
			HandleDelegate =  CommandLineInterpreter.Handle_RecryptDelete,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "ID", 
					Default = "",
					Brief = "Application profile friendly name",
					Index = 2,
					Key = "id"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					}
				}
			};

		}

    public partial class RecryptDelete : _RecryptDelete {
        } // class RecryptDelete

    public class _Encrypt : Goedel.Command.Dispatch ,
							IApplicationProfile,
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
		/// <summary>Field accessor for option [id]</summary>
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
			Identifier = "encrypt",
			Brief =  "Encrypt a file or directory",
			HandleDelegate =  CommandLineInterpreter.Handle_Encrypt,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "ID", 
					Default = "",
					Brief = "Application profile friendly name",
					Index = 2,
					Key = "id"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					}
				}
			};

		}

    public partial class Encrypt : _Encrypt {
        } // class Encrypt

    public class _Decrypt : Goedel.Command.Dispatch ,
							IApplicationProfile,
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
		/// <summary>Field accessor for option [id]</summary>
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
			Identifier = "decrypt",
			Brief =  "Decrypt a file or directory",
			HandleDelegate =  CommandLineInterpreter.Handle_Decrypt,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryOption () {
					Identifier = "Portal", 
					Default = "",
					Brief = "Portal account",
					Index = 0,
					Key = "portal"
					},
				new DescribeEntryOption () {
					Identifier = "UDF", 
					Default = "",
					Brief = "Profile fingerprint",
					Index = 1,
					Key = "udf"
					},
				new DescribeEntryOption () {
					Identifier = "ID", 
					Default = "",
					Brief = "Application profile friendly name",
					Index = 2,
					Key = "id"
					},
				new DescribeEntryOption () {
					Identifier = "Verbose", 
					Default = "false",
					Brief = "Verbose reports (default)",
					Index = 3,
					Key = "verbose"
					},
				new DescribeEntryOption () {
					Identifier = "Report", 
					Default = "true",
					Brief = "Report results (default)",
					Index = 4,
					Key = "report"
					}
				}
			};

		}

    public partial class Decrypt : _Decrypt {
        } // class Decrypt


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

		public virtual void Verify ( Verify Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Personal ( Personal Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Register ( Register Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Deregister ( Deregister Options) {
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

		public virtual void Mail ( Mail Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void SSH ( SSH Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void SSHAuth ( SSHAuth Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void SSHKnown ( SSHKnown Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void SSHPublic ( SSHPublic Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void SSHPrivate ( SSHPrivate Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Confirm ( Confirm Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void ConfirmPost ( ConfirmPost Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void ConfirmGet ( ConfirmGet Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void ConfirmAccept ( ConfirmAccept Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void ConfirmReject ( ConfirmReject Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Recrypt ( Recrypt Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void RecryptGroup ( RecryptGroup Options) {
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


        } // class _Shell

    public partial class Shell : _Shell {
        } // class Shell

    } // namespace Shell


