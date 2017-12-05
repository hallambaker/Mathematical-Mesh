using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Command;
using Goedel.Registry;
using Goedel.Utilities;

namespace Goedel.Command {
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

		static DescribeCommandSet DescribeCommandSet_Sub = new DescribeCommandSet () {
            Identifier = "sub",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"four", _Four._DescribeCommand },
				{"five", _Five._DescribeCommand },
				{"sub2", DescribeCommandSet_Sub2}
				} // End Entries
			};

		static DescribeCommandSet DescribeCommandSet_Sub2 = new DescribeCommandSet () {
            Identifier = "sub2",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"six", _Six._DescribeCommand },
				{"seven", _Seven._DescribeCommand }
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

				Description = "This is a test piece";

			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"about", DescribeAbout },
				{"one", _One._DescribeCommand },
				{"two", _Two._DescribeCommand },
				{"three", _Three._DescribeCommand },
				{"sub", DescribeCommandSet_Sub},
				{"help", DescribeHelp }
				}; // End Entries



            }



        public void MainMethod(string[] Args) {
			Shell Dispatch = new Shell ();

			MainMethod (Dispatch, Args);
			}


        public void MainMethod(Shell Dispatch, string[] Args) {
			Dispatcher (Entries, DefaultCommand, Dispatch, Args, 0);
            } // Main



		public static void Handle_One (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			One		Options = new One ();
			ProcessOptions (Args, Index, Options);
			Dispatch.One (Options);
			}

		public static void Handle_Two (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Two		Options = new Two ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Two (Options);
			}

		public static void Handle_Three (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Three		Options = new Three ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Three (Options);
			}

		public static void Handle_Four (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Four		Options = new Four ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Four (Options);
			}

		public static void Handle_Five (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Five		Options = new Five ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Five (Options);
			}

		public static void Handle_Six (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Six		Options = new Six ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Six (Options);
			}

		public static void Handle_Seven (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Seven		Options = new Seven ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Seven (Options);
			}


	} // class Main


	// The stub class for carrying optional parameters for each command type
	// As with the main class each consists of an abstract main class 
	// with partial virtual that can be extended as required.

	// All subclasses inherit from the abstract classes Goedel.Regisrty.Dispatch 
	// and Goedel.Command.Type


    public class _One : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Integer (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String P1 {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _P1 {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual Integer P2 {
			get => _Data[1] as Integer;
			set => _Data[1]  = value;
			}

		public virtual string _P2 {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [o1]</summary>
		public virtual Flag O1 {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _O1 {
			set => _Data[2].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "one",
			Brief =  "<Unspecified>",
			HandleDelegate =  CommandLineInterpreter.Handle_One,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "P1", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "P2", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 1,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "O1", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 2,
					Key = "o1"
					}
				}
			};

		}

    public partial class One : _One {
        } // class One

    public class _Two : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new Integer (),
			new Flag ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String P1 {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _P1 {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual Integer P2 {
			get => _Data[1] as Integer;
			set => _Data[1]  = value;
			}

		public virtual string _P2 {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for option [o1]</summary>
		public virtual Flag O1 {
			get => _Data[2] as Flag;
			set => _Data[2]  = value;
			}

		public virtual string _O1 {
			set => _Data[2].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "two",
			Brief =  "<Unspecified>",
			HandleDelegate =  CommandLineInterpreter.Handle_Two,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "P1", 
					Default = "DefaultValue", // null if null
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "P2", 
					Default = "42", // null if null
					Brief = "<Unspecified>",
					Index = 1,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "O1", 
					Default = "true", // null if null
					Brief = "<Unspecified>",
					Index = 2,
					Key = "o1"
					}
				}
			};

		}

    public partial class Two : _Two {
        } // class Two

    public class _Three : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {			} ;

		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "three",
			Brief =  "<Unspecified>",
			HandleDelegate =  CommandLineInterpreter.Handle_Three,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				}
			};

		}

    public partial class Three : _Three {
        } // class Three

    public class _Four : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new ExistingFile (),
			new NewFile ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile TestParser {
			get => _Data[0] as ExistingFile;
			set => _Data[0]  = value;
			}

		public virtual string _TestParser {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for option [.testout]</summary>
		public virtual NewFile Test {
			get => _Data[1] as NewFile;
			set => _Data[1]  = value;
			}

		public virtual string _Test {
			set => _Data[1].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "four",
			Brief =  "<Unspecified>",
			HandleDelegate =  CommandLineInterpreter.Handle_Four,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "TestParser", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 0,
					Key = ""
					},
				new DescribeEntryOption () {
					Identifier = "Test", 
					Default = null, // null if null
					Brief = "<Unspecified>",
					Index = 1,
					Key = ".testout"
					}
				}
			};

		}

    public partial class Four : _Four {
        } // class Four

    public class _Five : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {			} ;

		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "five",
			Brief =  "<Unspecified>",
			HandleDelegate =  CommandLineInterpreter.Handle_Five,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				}
			};

		}

    public partial class Five : _Five {
        } // class Five

    public class _Six : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {			} ;

		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "six",
			Brief =  "<Unspecified>",
			HandleDelegate =  CommandLineInterpreter.Handle_Six,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				}
			};

		}

    public partial class Six : _Six {
        } // class Six

    public class _Seven : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {			} ;

		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "seven",
			Brief =  "<Unspecified>",
			HandleDelegate =  CommandLineInterpreter.Handle_Seven,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				}
			};

		}

    public partial class Seven : _Seven {
        } // class Seven


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
    public class _Shell : global::Goedel.Command.DispatchShell {

		public virtual void One ( One Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Two ( Two Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Three ( Three Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Four ( Four Options) {
			string inputfile = null;

			inputfile = Options.TestParser.Text;

            Goedel.Command.TestParser Parse = new Goedel.Command.TestParser() {
				};
        
			
			using (Stream infile =
                        new FileStream(inputfile, FileMode.Open, FileAccess.Read)) {

                Lexer Schema = new Lexer(inputfile);

                Schema.Process(infile, Parse);
                }


			// Script output of type Test .testout
			if (Options.Test.Text != null) {
				string outputfile = Options.Test.Text; // Automatically defaults
				using (Stream outputStream =
							new FileStream(outputfile, FileMode.Create, FileAccess.Write)) {
					using (TextWriter OutputWriter = new StreamWriter(outputStream, Encoding.UTF8)) {

						Goedel.Command.TestScript Script = new Goedel.Command.TestScript (OutputWriter);

						Script.Test (Parse);
						}
					}
				}
			}

		public virtual void Five ( Five Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Six ( Six Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Seven ( Seven Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}


        } // class _Shell

    public partial class Shell : _Shell {
        } // class Shell

    } // namespace Shell


