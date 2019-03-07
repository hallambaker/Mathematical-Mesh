using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Command;
using Goedel.Utilities;

namespace ExampleGenerator {
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



        static CommandLineInterpreter () {
            System.OperatingSystem OperatingSystem = System.Environment.OSVersion;

            if (OperatingSystem.Platform == PlatformID.Unix |
                    OperatingSystem.Platform == PlatformID.MacOSX) {
                FlagIndicator = UnixFlag;
                }
            else {
                FlagIndicator = WindowsFlag;
                }

				DefaultCommand = _DefaultCommand._DescribeCommand;
				Description = "<brief description here";

			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"about", DescribeAbout },
				{"in", _DefaultCommand._DescribeCommand },
				{"help", DescribeHelp }
				}; // End Entries



            }

        static void Main(string[] args) {
			var CLI = new CommandLineInterpreter ();
			CLI.MainMethod (args);
			}

        public void MainMethod(string[] Args) {
			MakeSiteDocs Dispatch = new MakeSiteDocs ();

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


        public void MainMethod(MakeSiteDocs Dispatch, string[] Args) =>
			Dispatcher (Entries, DefaultCommand, Dispatch, Args, 0);




		public static void Handle_DefaultCommand (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			MakeSiteDocs Dispatch =	DispatchIn as MakeSiteDocs;
			DefaultCommand		Options = new DefaultCommand ();
			ProcessOptions (Args, Index, Options);
			Dispatch._PreProcess (Options);
			Dispatch.DefaultCommand (Options);
			}


	} // class Main


	// The stub class for carrying optional parameters for each command type
	// As with the main class each consists of an abstract main class 
	// with partial virtual that can be extended as required.

	// All subclasses inherit from the abstract classes Goedel.Regisrty.Dispatch 
	// and Goedel.Command.Type


    public class _DefaultCommand : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new Flag ()			} ;

		/// <summary>Field accessor for parameter [lazy]</summary>
		public virtual Flag Lazy {
			get => _Data[0] as Flag;
			set => _Data[0]  = value;
			}

		public virtual string _Lazy {
			set => _Data[0].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "in",
			Brief =  "<Unspecified>",
			HandleDelegate =  CommandLineInterpreter.Handle_DefaultCommand,
			Lazy =  true,
			Entries = new List<DescribeEntry> () {
				}
			};

		}

    public partial class DefaultCommand : _DefaultCommand {
        } // class DefaultCommand


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



	// The stub class just contains routines that echo their arguments and
	// write 'not yet implemented'

	// Eventually there will be a compiler option to suppress the debugging
	// to eliminate the redundant code
    public class _MakeSiteDocs : global::Goedel.Command.DispatchShell {

		public virtual void DefaultCommand ( DefaultCommand Options) =>
			CommandLineInterpreter.DescribeValues (Options);


        } // class _MakeSiteDocs

    public partial class MakeSiteDocs : _MakeSiteDocs {
        } // class MakeSiteDocs

    } // namespace MakeSiteDocs


