﻿
//  This file was automatically generated at 6/10/2021 3:16:03 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  commandparse version 3.0.0.659
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

				DefaultCommand = _HostStart._DescribeCommand;
				Description = "Mathematical Mesh command tool";

			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"start", _HostStart._DescribeCommand },
				{"pause", _HostPause._DescribeCommand },
				{"stop", _HostStop._DescribeCommand },
				{"verify", _HostVerify._DescribeCommand },
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




		public static void Handle_HostStart (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			HostStart		Options = new HostStart ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.HostStart (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_HostPause (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			HostPause		Options = new HostPause ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.HostPause (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_HostStop (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			HostStop		Options = new HostStop ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.HostStop (Options);
			Dispatch._PostProcess (result);
			}

		public static void Handle_HostVerify (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			HostVerify		Options = new HostVerify ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			var result = Dispatch.HostVerify (Options);
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


    public class _HostStart : Goedel.Command.Dispatch ,
							IReporting {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new ExistingFile (),
			new Enumeration<EnumReporting> (CommandLineInterpreter.DescribeEnumReporting),
			new Flag (),
			new Flag (),
			new Flag ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile HostConfig {
			get => _Data[0] as ExistingFile;
			set => _Data[0]  = value;
			}

		public virtual string _HostConfig {
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
			Identifier = "start",
			Brief =  "Start the host service",
			HandleDelegate =  CommandLineInterpreter.Handle_HostStart,
			Lazy =  false,
            IsDefault = true,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "HostConfig", 
					Default = null, // null if null
					Brief = "The host configuration file",
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

    public partial class HostStart : _HostStart {
        } // class HostStart

    public class _HostPause : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new ExistingFile ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile HostConfig {
			get => _Data[0] as ExistingFile;
			set => _Data[0]  = value;
			}

		public virtual string _HostConfig {
			set => _Data[0].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "pause",
			Brief =  "Start the host service in paused mode or pause the service if already started.",
			HandleDelegate =  CommandLineInterpreter.Handle_HostPause,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "HostConfig", 
					Default = null, // null if null
					Brief = "The host configuration file",
					Index = 0,
					Key = ""
					}
				}
			};

		}

    public partial class HostPause : _HostPause {
        } // class HostPause

    public class _HostStop : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new ExistingFile ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile HostConfig {
			get => _Data[0] as ExistingFile;
			set => _Data[0]  = value;
			}

		public virtual string _HostConfig {
			set => _Data[0].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "stop",
			Brief =  "Stop the host service.",
			HandleDelegate =  CommandLineInterpreter.Handle_HostStop,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "HostConfig", 
					Default = null, // null if null
					Brief = "The host configuration file",
					Index = 0,
					Key = ""
					}
				}
			};

		}

    public partial class HostStop : _HostStop {
        } // class HostStop

    public class _HostVerify : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new ExistingFile ()			} ;





		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile HostConfig {
			get => _Data[0] as ExistingFile;
			set => _Data[0]  = value;
			}

		public virtual string _HostConfig {
			set => _Data[0].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "verify",
			Brief =  "Verify that the host configuration file is correct.",
			HandleDelegate =  CommandLineInterpreter.Handle_HostVerify,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "HostConfig", 
					Default = null, // null if null
					Brief = "The host configuration file",
					Index = 0,
					Key = ""
					}
				}
			};

		}

    public partial class HostVerify : _HostVerify {
        } // class HostVerify


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

		public virtual ShellResult HostStart ( HostStart Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult HostPause ( HostPause Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult HostStop ( HostStop Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}

		public virtual ShellResult HostVerify ( HostVerify Options) {
			CommandLineInterpreter.DescribeValues (Options);
			return null;
			}


        } // class _Shell

    public partial class Shell : _Shell {
        } // class Shell

    } // namespace Shell

