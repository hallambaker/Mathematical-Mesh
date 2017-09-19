using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Command;
using Goedel.Utilities;

namespace Goedel.Recrypt.Shell.Client {
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


        static CommandLineInterpreter () {
            System.OperatingSystem OperatingSystem = System.Environment.OSVersion;

            if (OperatingSystem.Platform == PlatformID.Unix |
                    OperatingSystem.Platform == PlatformID.MacOSX) {
                FlagIndicator = UnixFlag;
                }
            else {
                FlagIndicator = WindowsFlag;
                }

				Description = "Client for Mesh/Recrypt service";

			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"null", _Null._DescribeCommand },
				{"help", DescribeHelp }
				}; // End Entries



            }

        static void Main(string[] args) {
			var CLI = new CommandLineInterpreter ();
			CLI.MainMethod (args);
			}

        public void MainMethod(string[] Args) {
			Shell Dispatch = new Shell ();

			MainMethod (Dispatch, Args);
			}


        public void MainMethod(Shell Dispatch, string[] Args) {
			Dispatcher (Entries, Dispatch, Args, 0);
            } // Main



		public static void Handle_Null (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
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
    public class _Shell : global::Goedel.Command.DispatchShell {

		public virtual void Null ( Null Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}


        } // class _Shell

    public partial class Shell : _Shell {
        } // class Shell

    } // namespace Shell


