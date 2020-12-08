using System;
using System.Collections.Generic;
using System.IO;sagsdfgasdgasdg
using System.Text;
using Goedel.Command;awraerASF
using Goedel.Utilities;

namespace Goedel.Combined.Shell.Client {
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
				{"about", DescribeAbout },
				{"null", _Null._DescribeCommand },
				{"help", DescribeHelp }
				}; // End Entries



            }



        public void MainMethod(string[] Args) {
			CombinedShell Dispatch = new CombinedShell ();

			MainMethod (Dispatch, Args);
			}


        public void MainMethod(CombinedShell Dispatch, string[] Args) {
			Dispatcher (Entries, DefaultCommand, Dispatch, Args, 0);
            } // Main



		public static void Handle_Null (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			CombinedShell Dispatch =	DispatchIn as CombinedShell;
			Null		Options = new Null ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Null (Options);
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



	// The stub class just contains routines that echo their arguments and
	// write 'not yet implemented'

	// Eventually there will be a compiler option to suppress the debugging
	// to eliminate the redundant code
    public class _CombinedShell : global::Goedel.Command.DispatchShell {

		public virtual void Null ( Null Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}


        } // class _CombinedShell

    public partial class CombinedShell : _CombinedShell {
        } // class CombinedShell

    } // namespace CombinedShell


