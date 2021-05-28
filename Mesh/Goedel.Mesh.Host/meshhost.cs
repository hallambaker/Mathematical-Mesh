
//  This file was automatically generated at 5/28/2021 6:17:11 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  commandparse version 3.0.0.655
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

namespace Goedel.Mesh.Host {

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

        static bool IsFlag(char c) =>
            (c == UnixFlag) | (c == WindowsFlag) ;




		public static DescribeCommandSet DescribeCommandSet_Host = new DescribeCommandSet () {
            Identifier = "host",
			Brief = "<Unspecified>",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_Log = new DescribeCommandSet () {
            Identifier = "log",
			Brief = "<Unspecified>",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"local", _LogLocal._DescribeCommand },
				{"add", _LogAdd._DescribeCommand },
				{"set", _LogSet._DescribeCommand },
				{"delete", _LogDelete._DescribeCommand },
				{"get", _LogGet._DescribeCommand },
				{"list", _LogDump._DescribeCommand }
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_DNS = new DescribeCommandSet () {
            Identifier = "dns",
			Brief = "<Unspecified>",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"add", _DnsAdd._DescribeCommand },
				{"delete", _DnsDelete._DescribeCommand },
				{"get", _DnsGet._DescribeCommand },
				{"list", _DnsDump._DescribeCommand }
				} // End Entries
			};

		public static DescribeCommandSet DescribeCommandSet_Account = new DescribeCommandSet () {
            Identifier = "account",
			Brief = "<Unspecified>",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"pin", _AccountPin._DescribeCommand },
				{"delete", _AccountDelete._DescribeCommand },
				{"get", _AccountGet._DescribeCommand },
				{"quota", _AccountQuota._DescribeCommand },
				{"list", _AccountDump._DescribeCommand }
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

				DefaultCommand = _Start._DescribeCommand;
				Description = "Mathematical Mesh command tool";

			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"start", _Start._DescribeCommand },
				{"init", _Initialize._DescribeCommand },
				{"verify", _Verify._DescribeCommand },
				{"host", DescribeCommandSet_Host},
				{"log", DescribeCommandSet_Log},
				{"dns", DescribeCommandSet_DNS},
				{"account", DescribeCommandSet_Account},
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




		public static void Handle_Start (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Start		Options = new Start ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.Start (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_Initialize (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Initialize		Options = new Initialize ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.Initialize (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_Verify (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Verify		Options = new Verify ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.Verify (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_LogLocal (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			LogLocal		Options = new LogLocal ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.LogLocal (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_LogAdd (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			LogAdd		Options = new LogAdd ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.LogAdd (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_LogSet (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			LogSet		Options = new LogSet ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.LogSet (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_LogDelete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			LogDelete		Options = new LogDelete ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.LogDelete (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_LogGet (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			LogGet		Options = new LogGet ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.LogGet (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_LogDump (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			LogDump		Options = new LogDump ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.LogDump (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DnsAdd (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DnsAdd		Options = new DnsAdd ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DnsAdd (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DnsDelete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DnsDelete		Options = new DnsDelete ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DnsDelete (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DnsGet (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DnsGet		Options = new DnsGet ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DnsGet (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_DnsDump (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DnsDump		Options = new DnsDump ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DnsDump (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_AccountPin (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			AccountPin		Options = new AccountPin ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.AccountPin (Options);
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

		public static void Handle_AccountGet (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			AccountGet		Options = new AccountGet ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.AccountGet (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_AccountQuota (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			AccountQuota		Options = new AccountQuota ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.AccountQuota (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_AccountDump (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			AccountDump		Options = new AccountDump ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.AccountDump (Options);
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


    public class _Start : Goedel.Command.Dispatch ,
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
			Identifier = "start",
			Brief =  "Start the host service",
			HandleDelegate =  CommandLineInterpreter.Handle_Start,
			Lazy =  false,
            IsDefault = true,
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

    public partial class Start : _Start {
        } // class Start

    public class _Initialize : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual String ServiceDomain {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _ServiceDomain {
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
			Identifier = "init",
			Brief =  "Initialize the service configuration",
			HandleDelegate =  CommandLineInterpreter.Handle_Initialize,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "ServiceDomain", 
					Default = null, // null if null
					Brief = "The service DNS domain",
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

    public partial class Initialize : _Initialize {
        } // class Initialize

    public class _Verify : Goedel.Command.Dispatch ,
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
			Identifier = "verify",
			Brief =  "Verify the service configuration",
			HandleDelegate =  CommandLineInterpreter.Handle_Verify,
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

    public partial class Verify : _Verify {
        } // class Verify
	public interface ILogData {
		String			File{get; set;}
		String			Remote{get; set;}
		Flag			Error{get; set;}
		Flag			Event{get; set;}
		Flag			EventData{get; set;}
		Flag			Status{get; set;}
		}


    public class _LogLocal : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new String ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual String File {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _File {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [ops]</summary>
		public virtual String Operations {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Operations {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [config]</summary>
		public virtual String Config {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _Config {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [error]</summary>
		public virtual String Error {
			get => _Data[3] as String;
			set => _Data[3]  = value;
			}

		public virtual string _Error {
			set => _Data[3].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "local",
			Brief =  "Set the path on which to store logs and the roll policies none/hour/day/week/month)",
			HandleDelegate =  CommandLineInterpreter.Handle_LogLocal,
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
					Identifier = "Operations", 
					Default = null, // null if null
					Brief = "Operations log roll period",
					Index = 1,
					Key = "ops"
					},
				new DescribeEntryOption () {
					Identifier = "Config", 
					Default = null, // null if null
					Brief = "Configuration log roll period",
					Index = 2,
					Key = "config"
					},
				new DescribeEntryOption () {
					Identifier = "Error", 
					Default = null, // null if null
					Brief = "Error log roll period",
					Index = 3,
					Key = "error"
					}
				}
			};

		}

    public partial class LogLocal : _LogLocal {
        } // class LogLocal

    public class _LogAdd : Goedel.Command.Dispatch ,
							ILogData,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual String Id {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Id {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [file]</summary>
		public virtual String File {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _File {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [remote]</summary>
		public virtual String Remote {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _Remote {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [error]</summary>
		public virtual Flag Error {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Error {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [event]</summary>
		public virtual Flag Event {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Event {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [data]</summary>
		public virtual Flag EventData {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _EventData {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [status]</summary>
		public virtual Flag Status {
			get => _Data[6] as Flag;
			set => _Data[6]  = value;
			}

		public virtual string _Status {
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
			Identifier = "add",
			Brief =  "Add log destination",
			HandleDelegate =  CommandLineInterpreter.Handle_LogAdd,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Id", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "Set file log destination",
					Index = 1,
					Key = "file"
					},
				new DescribeEntryOption () {
					Identifier = "Remote", 
					Default = null, // null if null
					Brief = "Set remote log destination",
					Index = 2,
					Key = "remote"
					},
				new DescribeEntryOption () {
					Identifier = "Error", 
					Default = "true", // null if null
					Brief = "Error reports",
					Index = 3,
					Key = "error"
					},
				new DescribeEntryOption () {
					Identifier = "Event", 
					Default = "true", // null if null
					Brief = "Transaction events",
					Index = 4,
					Key = "event"
					},
				new DescribeEntryOption () {
					Identifier = "EventData", 
					Default = "false", // null if null
					Brief = "Transaction data",
					Index = 5,
					Key = "data"
					},
				new DescribeEntryOption () {
					Identifier = "Status", 
					Default = "true", // null if null
					Brief = "Status events",
					Index = 6,
					Key = "status"
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

    public partial class LogAdd : _LogAdd {
        } // class LogAdd

    public class _LogSet : Goedel.Command.Dispatch ,
							ILogData,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new String (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Flag (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual String Id {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Id {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [file]</summary>
		public virtual String File {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _File {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [remote]</summary>
		public virtual String Remote {
			get => _Data[2] as String;
			set => _Data[2]  = value;
			}

		public virtual string _Remote {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [error]</summary>
		public virtual Flag Error {
			get => _Data[3] as Flag;
			set => _Data[3]  = value;
			}

		public virtual string _Error {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [event]</summary>
		public virtual Flag Event {
			get => _Data[4] as Flag;
			set => _Data[4]  = value;
			}

		public virtual string _Event {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [data]</summary>
		public virtual Flag EventData {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _EventData {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [status]</summary>
		public virtual Flag Status {
			get => _Data[6] as Flag;
			set => _Data[6]  = value;
			}

		public virtual string _Status {
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
			Identifier = "set",
			Brief =  "Configure log destination",
			HandleDelegate =  CommandLineInterpreter.Handle_LogSet,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Id", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "File", 
					Default = null, // null if null
					Brief = "Set file log destination",
					Index = 1,
					Key = "file"
					},
				new DescribeEntryOption () {
					Identifier = "Remote", 
					Default = null, // null if null
					Brief = "Set remote log destination",
					Index = 2,
					Key = "remote"
					},
				new DescribeEntryOption () {
					Identifier = "Error", 
					Default = "true", // null if null
					Brief = "Error reports",
					Index = 3,
					Key = "error"
					},
				new DescribeEntryOption () {
					Identifier = "Event", 
					Default = "true", // null if null
					Brief = "Transaction events",
					Index = 4,
					Key = "event"
					},
				new DescribeEntryOption () {
					Identifier = "EventData", 
					Default = "false", // null if null
					Brief = "Transaction data",
					Index = 5,
					Key = "data"
					},
				new DescribeEntryOption () {
					Identifier = "Status", 
					Default = "true", // null if null
					Brief = "Status events",
					Index = 6,
					Key = "status"
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

    public partial class LogSet : _LogSet {
        } // class LogSet

    public class _LogDelete : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual String Id {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Id {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Address {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Address {
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
			Brief =  "Delete  remote log destination",
			HandleDelegate =  CommandLineInterpreter.Handle_LogDelete,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Id", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Address", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 1,
					Key = ""
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

    public partial class LogDelete : _LogDelete {
        } // class LogDelete

    public class _LogGet : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual String Id {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Id {
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
			Brief =  "Lookup remote log destination",
			HandleDelegate =  CommandLineInterpreter.Handle_LogGet,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Id", 
					Default = null, // null if null
					Brief = "<Unspecified>",
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

    public partial class LogGet : _LogGet {
        } // class LogGet

    public class _LogDump : Goedel.Command.Dispatch ,
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
			Brief =  "List  remote log destination",
			HandleDelegate =  CommandLineInterpreter.Handle_LogDump,
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

    public partial class LogDump : _LogDump {
        } // class LogDump

    public class _DnsAdd : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual String Domain {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Domain {
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
			Identifier = "add",
			Brief =  "Add dns service address",
			HandleDelegate =  CommandLineInterpreter.Handle_DnsAdd,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Domain", 
					Default = null, // null if null
					Brief = "<Unspecified>",
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

    public partial class DnsAdd : _DnsAdd {
        } // class DnsAdd

    public class _DnsDelete : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual String Domain {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Domain {
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
			Brief =  "Delete dns service address",
			HandleDelegate =  CommandLineInterpreter.Handle_DnsDelete,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Domain", 
					Default = null, // null if null
					Brief = "<Unspecified>",
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

    public partial class DnsDelete : _DnsDelete {
        } // class DnsDelete

    public class _DnsGet : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual String Domain {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Domain {
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
			Brief =  "Lookup dns service address",
			HandleDelegate =  CommandLineInterpreter.Handle_DnsGet,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Domain", 
					Default = null, // null if null
					Brief = "<Unspecified>",
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

    public partial class DnsGet : _DnsGet {
        } // class DnsGet

    public class _DnsDump : Goedel.Command.Dispatch ,
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
			Brief =  "List dns service addresses",
			HandleDelegate =  CommandLineInterpreter.Handle_DnsDump,
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

    public partial class DnsDump : _DnsDump {
        } // class DnsDump

    public class _AccountPin : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual String Account {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Account {
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
			Identifier = "pin",
			Brief =  "Issue PIN to grant account issue",
			HandleDelegate =  CommandLineInterpreter.Handle_AccountPin,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Account", 
					Default = null, // null if null
					Brief = "<Unspecified>",
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

    public partial class AccountPin : _AccountPin {
        } // class AccountPin

    public class _AccountDelete : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual String Account {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Account {
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
			Brief =  "Delete account",
			HandleDelegate =  CommandLineInterpreter.Handle_AccountDelete,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Account", 
					Default = null, // null if null
					Brief = "<Unspecified>",
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

    public class _AccountGet : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual String Account {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Account {
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
			Brief =  "Lookup account info",
			HandleDelegate =  CommandLineInterpreter.Handle_AccountGet,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Account", 
					Default = null, // null if null
					Brief = "<Unspecified>",
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

    public partial class AccountGet : _AccountGet {
        } // class AccountGet

    public class _AccountQuota : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Integer (),
			new Integer (),
			new Integer (),
			new Integer (),
			new Integer (),
			new Integer (),
			new Flag (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual String Account {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Account {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [kb]</summary>
		public virtual Integer KiloBytes {
			get => _Data[1] as Integer;
			set => _Data[1]  = value;
			}

		public virtual string _KiloBytes {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [mb]</summary>
		public virtual Integer MegaBytes {
			get => _Data[2] as Integer;
			set => _Data[2]  = value;
			}

		public virtual string _MegaBytes {
			set => _Data[2].Parameter (value);
			}
		/// <summary>Field accessor for option [gb]</summary>
		public virtual Integer GigaBytes {
			get => _Data[3] as Integer;
			set => _Data[3]  = value;
			}

		public virtual string _GigaBytes {
			set => _Data[3].Parameter (value);
			}
		/// <summary>Field accessor for option [trans]</summary>
		public virtual Integer Transactions {
			get => _Data[4] as Integer;
			set => _Data[4]  = value;
			}

		public virtual string _Transactions {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [in]</summary>
		public virtual Integer Inbound {
			get => _Data[5] as Integer;
			set => _Data[5]  = value;
			}

		public virtual string _Inbound {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [out]</summary>
		public virtual Integer Outbound {
			get => _Data[6] as Integer;
			set => _Data[6]  = value;
			}

		public virtual string _Outbound {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [suspend]</summary>
		public virtual Flag Suspend {
			get => _Data[7] as Flag;
			set => _Data[7]  = value;
			}

		public virtual string _Suspend {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for parameter [report]</summary>
		public virtual Enumeration<EnumReporting> EnumReporting {
			get => _Data[8] as Enumeration<EnumReporting>;
			set => _Data[8]  = value;
			}

		public virtual string _EnumReporting {
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

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "quota",
			Brief =  "Set account quota",
			HandleDelegate =  CommandLineInterpreter.Handle_AccountQuota,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Account", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "KiloBytes", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 1,
					Key = "kb"
					},
				new DescribeEntryOption () {
					Identifier = "MegaBytes", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 2,
					Key = "mb"
					},
				new DescribeEntryOption () {
					Identifier = "GigaBytes", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 3,
					Key = "gb"
					},
				new DescribeEntryOption () {
					Identifier = "Transactions", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 4,
					Key = "trans"
					},
				new DescribeEntryOption () {
					Identifier = "Inbound", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 5,
					Key = "in"
					},
				new DescribeEntryOption () {
					Identifier = "Outbound", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 6,
					Key = "out"
					},
				new DescribeEntryOption () {
					Identifier = "Suspend", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 7,
					Key = "suspend"
					},
				new DescribeEntryEnumerate () {
					Identifier = "EnumReporting", 
					Default = null, // null if null
					Brief = "Reporting level",
					Index = 8,
					Key = "report"
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
					}
				}
			};

		}

    public partial class AccountQuota : _AccountQuota {
        } // class AccountQuota

    public class _AccountDump : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual String Account {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _Account {
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
			Brief =  "List accounts matching optional pattern",
			HandleDelegate =  CommandLineInterpreter.Handle_AccountDump,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Account", 
					Default = null, // null if null
					Brief = "<Unspecified>",
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

    public partial class AccountDump : _AccountDump {
        } // class AccountDump


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

		public virtual HostResult Start ( Start Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual HostResult Initialize ( Initialize Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual HostResult Verify ( Verify Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual HostResult LogLocal ( LogLocal Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual HostResult LogAdd ( LogAdd Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual HostResult LogSet ( LogSet Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual HostResult LogDelete ( LogDelete Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual HostResult LogGet ( LogGet Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual HostResult LogDump ( LogDump Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual HostResult DnsAdd ( DnsAdd Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual HostResult DnsDelete ( DnsDelete Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual HostResult DnsGet ( DnsGet Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual HostResult DnsDump ( DnsDump Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual HostResult AccountPin ( AccountPin Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual HostResult AccountDelete ( AccountDelete Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual HostResult AccountGet ( AccountGet Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual HostResult AccountQuota ( AccountQuota Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual HostResult AccountDump ( AccountDump Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}


        } // class _Shell

    public partial class Shell : _Shell {
        } // class Shell

    } // namespace Shell


