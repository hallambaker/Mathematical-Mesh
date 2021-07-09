
//  This file was automatically generated at 7/8/2021 11:37:34 PM
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

namespace Goedel.Mesh.Shell.ServiceAdmin {

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
				{"create", _Create._DescribeCommand },
				{"start", _Start._DescribeCommand },
				{"stop", _Stop._DescribeCommand },
				{"pause", _Pause._DescribeCommand },
				{"fetch", _Fetch._DescribeCommand },
				{"update", _Update._DescribeCommand },
				{"verify", _Verify._DescribeCommand },
				{"dns", _DNS._DescribeCommand },
				{"credential", _Credential._DescribeCommand },
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




		public static void Handle_Create (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Create		Options = new Create ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.Create (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_Start (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Start		Options = new Start ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.Start (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_Stop (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Stop		Options = new Stop ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.Stop (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_Pause (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Pause		Options = new Pause ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.Pause (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_Fetch (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Fetch		Options = new Fetch ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.Fetch (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_Update (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Update		Options = new Update ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.Update (Options);
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

		public static void Handle_DNS (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			DNS		Options = new DNS ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.DNS (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_Credential (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Credential		Options = new Credential ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.Credential (Options);
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


    public class _Create : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new ExistingFile (),
			new String (),
			new String (),
			new String (),
			new String (),
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile ServiceConfig {
			get => _Data[4] as ExistingFile;
			set => _Data[4]  = value;
			}

		public virtual string _ServiceConfig {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String ServiceDns {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _ServiceDns {
			set => _Data[5].Parameter (value);
			}
		/// <summary>Field accessor for option [ip]</summary>
		public virtual String HostIp {
			get => _Data[6] as String;
			set => _Data[6]  = value;
			}

		public virtual string _HostIp {
			set => _Data[6].Parameter (value);
			}
		/// <summary>Field accessor for option [host]</summary>
		public virtual String HostDns {
			get => _Data[7] as String;
			set => _Data[7]  = value;
			}

		public virtual string _HostDns {
			set => _Data[7].Parameter (value);
			}
		/// <summary>Field accessor for option [admin]</summary>
		public virtual String Admin {
			get => _Data[8] as String;
			set => _Data[8]  = value;
			}

		public virtual string _Admin {
			set => _Data[8].Parameter (value);
			}
		/// <summary>Field accessor for option [out]</summary>
		public virtual NewFile NewFile {
			get => _Data[9] as NewFile;
			set => _Data[9]  = value;
			}

		public virtual string _NewFile {
			set => _Data[9].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "create",
			Brief =  "Initialize a new Mesh service and administration account",
			HandleDelegate =  CommandLineInterpreter.Handle_Create,
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
					Identifier = "ServiceConfig", 
					Default = null, // null if null
					Brief = "The service configuration file, is created if necessary",
					Index = 4,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "ServiceDns", 
					Default = null, // null if null
					Brief = "The DNS address of the service",
					Index = 5,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "HostIp", 
					Default = null, // null if null
					Brief = "The external IP address of the host.",
					Index = 6,
					Key = "ip"
					},
				new DescribeEntryOption () {
					Identifier = "HostDns", 
					Default = null, // null if null
					Brief = "The DNS address of the host for service configuration",
					Index = 7,
					Key = "host"
					},
				new DescribeEntryOption () {
					Identifier = "Admin", 
					Default = null, // null if null
					Brief = "The administrator account address, also default for the host domain.",
					Index = 8,
					Key = "admin"
					},
				new DescribeEntryOption () {
					Identifier = "NewFile", 
					Default = null, // null if null
					Brief = "File to write the configuration to",
					Index = 9,
					Key = "out"
					}
				}
			};

		}

    public partial class Create : _Create {
        } // class Create

    public class _Start : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual String HostDns {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _HostDns {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [all]</summary>
		public virtual Flag All {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _All {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "start",
			Brief =  "Start the host service",
			HandleDelegate =  CommandLineInterpreter.Handle_Start,
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
					Identifier = "HostDns", 
					Default = null, // null if null
					Brief = "The DNS address of the service",
					Index = 4,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "All", 
					Default = null, // null if null
					Brief = "Start all hosts in the service",
					Index = 5,
					Key = "all"
					}
				}
			};

		}

    public partial class Start : _Start {
        } // class Start

    public class _Stop : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual String HostDns {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _HostDns {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [all]</summary>
		public virtual Flag All {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _All {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "stop",
			Brief =  "Stop the host service.",
			HandleDelegate =  CommandLineInterpreter.Handle_Stop,
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
					Identifier = "HostDns", 
					Default = null, // null if null
					Brief = "The DNS address of the service",
					Index = 4,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "All", 
					Default = null, // null if null
					Brief = "Stop all hosts in the service",
					Index = 5,
					Key = "all"
					}
				}
			};

		}

    public partial class Stop : _Stop {
        } // class Stop

    public class _Pause : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new String (),
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual String HostDns {
			get => _Data[4] as String;
			set => _Data[4]  = value;
			}

		public virtual string _HostDns {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for option [all]</summary>
		public virtual Flag All {
			get => _Data[5] as Flag;
			set => _Data[5]  = value;
			}

		public virtual string _All {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "pause",
			Brief =  "Start the host service in paused mode or pause the service if already started.",
			HandleDelegate =  CommandLineInterpreter.Handle_Pause,
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
					Identifier = "HostDns", 
					Default = null, // null if null
					Brief = "The DNS address of the service",
					Index = 4,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "All", 
					Default = null, // null if null
					Brief = "Pause all hosts in the service",
					Index = 5,
					Key = "all"
					}
				}
			};

		}

    public partial class Pause : _Pause {
        } // class Pause

    public class _Fetch : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new NewFile (),
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
		public virtual NewFile HostConfig {
			get => _Data[4] as NewFile;
			set => _Data[4]  = value;
			}

		public virtual string _HostConfig {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String HostDns {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _HostDns {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "fetch",
			Brief =  "Fetch the host configuration file from the specified service.",
			HandleDelegate =  CommandLineInterpreter.Handle_Fetch,
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
					Identifier = "HostConfig", 
					Default = null, // null if null
					Brief = "The host configuration file",
					Index = 4,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "HostDns", 
					Default = null, // null if null
					Brief = "The DNS address of the service",
					Index = 5,
					Key = ""
					}
				}
			};

		}

    public partial class Fetch : _Fetch {
        } // class Fetch

    public class _Update : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new ExistingFile (),
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
		public virtual ExistingFile HostConfig {
			get => _Data[4] as ExistingFile;
			set => _Data[4]  = value;
			}

		public virtual string _HostConfig {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String HostDns {
			get => _Data[5] as String;
			set => _Data[5]  = value;
			}

		public virtual string _HostDns {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "update",
			Brief =  "Initialize this machine as a host",
			HandleDelegate =  CommandLineInterpreter.Handle_Update,
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
					Identifier = "HostConfig", 
					Default = null, // null if null
					Brief = "The host configuration file",
					Index = 4,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "HostDns", 
					Default = null, // null if null
					Brief = "The DNS address of the service",
					Index = 5,
					Key = ""
					}
				}
			};

		}

    public partial class Update : _Update {
        } // class Update

    public class _Verify : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile HostConfig {
			get => _Data[4] as ExistingFile;
			set => _Data[4]  = value;
			}

		public virtual string _HostConfig {
			set => _Data[4].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "verify",
			Brief =  "Verify that the host configuration file is correct.",
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
					},
				new DescribeEntryParameter () {
					Identifier = "HostConfig", 
					Default = null, // null if null
					Brief = "The host configuration file",
					Index = 4,
					Key = ""
					}
				}
			};

		}

    public partial class Verify : _Verify {
        } // class Verify

    public class _DNS : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new ExistingFile (),
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile HostConfig {
			get => _Data[4] as ExistingFile;
			set => _Data[4]  = value;
			}

		public virtual string _HostConfig {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile DnsConfig {
			get => _Data[5] as ExistingFile;
			set => _Data[5]  = value;
			}

		public virtual string _DnsConfig {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "dns",
			Brief =  "Compute the DNS configuration from the service config.",
			HandleDelegate =  CommandLineInterpreter.Handle_DNS,
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
					Identifier = "HostConfig", 
					Default = null, // null if null
					Brief = "The host configuration file",
					Index = 4,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "DnsConfig", 
					Default = null, // null if null
					Brief = "The DNS configuration file",
					Index = 5,
					Key = ""
					}
				}
			};

		}

    public partial class DNS : _DNS {
        } // class DNS

    public class _Credential : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag (),
			new ExistingFile (),
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
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile HostConfig {
			get => _Data[4] as ExistingFile;
			set => _Data[4]  = value;
			}

		public virtual string _HostConfig {
			set => _Data[4].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile HostName {
			get => _Data[5] as ExistingFile;
			set => _Data[5]  = value;
			}

		public virtual string _HostName {
			set => _Data[5].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "credential",
			Brief =  "Issue a credential to the specified host",
			HandleDelegate =  CommandLineInterpreter.Handle_Credential,
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
					Identifier = "HostConfig", 
					Default = null, // null if null
					Brief = "The host configuration file, is created if necessary",
					Index = 4,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "HostName", 
					Default = null, // null if null
					Brief = "The host to add.",
					Index = 5,
					Key = ""
					}
				}
			};

		}

    public partial class Credential : _Credential {
        } // class Credential


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

		public virtual ShellResult Create ( Create Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult Start ( Start Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult Stop ( Stop Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult Pause ( Pause Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult Fetch ( Fetch Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult Update ( Update Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult Verify ( Verify Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult DNS ( DNS Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult Credential ( Credential Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}


        } // class _Shell

    public partial class Shell : _Shell {
        } // class Shell

    } // namespace Shell


