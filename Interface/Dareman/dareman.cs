using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Command;
using Goedel.Utilities;

namespace Goedel.Mesh.DareMan {
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

		static DescribeCommandSet DescribeCommandSet_Group = new DescribeCommandSet () {
            Identifier = "group",
			Entries = new  SortedDictionary<string, DescribeCommand> () {
				{"create", _Create._DescribeCommand },
				{"add", _Add._DescribeCommand },
				{"delete", _Delete._DescribeCommand }
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
				{"register", _Register._DescribeCommand },
				{"group", DescribeCommandSet_Group},
				{"encrypt", _Encrypt._DescribeCommand },
				{"decrypt", _Decrypt._DescribeCommand },
				{"help", DescribeHelp }
				}; // End Entries



            }

        static void Main(string[] args) {
			var CLI = new CommandLineInterpreter ();
			CLI.MainMethod (args);
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



		public static void Handle_Register (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Register		Options = new Register ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Register (Options);
			}

		public static void Handle_Create (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Create		Options = new Create ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Create (Options);
			}

		public static void Handle_Add (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Add		Options = new Add ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Add (Options);
			}

		public static void Handle_Delete (
					DispatchShell  DispatchIn, string[] Args, int Index) {
			Shell Dispatch =	DispatchIn as Shell;
			Delete		Options = new Delete ();
			ProcessOptions (Args, Index, Options);
			Dispatch.Delete (Options);
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


    public class _Register : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String AccountID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _AccountID {
			set => _Data[0].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "register",
			Brief =  "Register new mesh/recryption account data",
			HandleDelegate =  CommandLineInterpreter.Handle_Register,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "Mesh portal and account id",
					Index = 0,
					Key = ""
					}
				}
			};

		}

    public partial class Register : _Register {
        } // class Register

    public class _Create : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String GroupID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _GroupID {
			set => _Data[0].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "create",
			Brief =  "Create recryption group",
			HandleDelegate =  CommandLineInterpreter.Handle_Create,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "GroupID", 
					Default = null, // null if null
					Brief = "Recryption group name in user@example.com format",
					Index = 0,
					Key = ""
					}
				}
			};

		}

    public partial class Create : _Create {
        } // class Create

    public class _Add : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String GroupID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _GroupID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "add",
			Brief =  "Add user to recryption group",
			HandleDelegate =  CommandLineInterpreter.Handle_Add,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "GroupID", 
					Default = null, // null if null
					Brief = "Recryption group name in user@example.com format",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "User to add",
					Index = 1,
					Key = ""
					}
				}
			};

		}

    public partial class Add : _Add {
        } // class Add

    public class _Delete : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new String (),
			new String ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual String GroupID {
			get => _Data[0] as String;
			set => _Data[0]  = value;
			}

		public virtual string _GroupID {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String AccountID {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _AccountID {
			set => _Data[1].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "delete",
			Brief =  "Remove user from recryption group",
			HandleDelegate =  CommandLineInterpreter.Handle_Delete,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "GroupID", 
					Default = null, // null if null
					Brief = "Recryption group name in user@example.com format",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "AccountID", 
					Default = null, // null if null
					Brief = "User to delete",
					Index = 1,
					Key = ""
					}
				}
			};

		}

    public partial class Delete : _Delete {
        } // class Delete

    public class _Encrypt : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new ExistingFile (),
			new String (),
			new NewFile ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Input {
			get => _Data[0] as ExistingFile;
			set => _Data[0]  = value;
			}

		public virtual string _Input {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual String Group {
			get => _Data[1] as String;
			set => _Data[1]  = value;
			}

		public virtual string _Group {
			set => _Data[1].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual NewFile Output {
			get => _Data[2] as NewFile;
			set => _Data[2]  = value;
			}

		public virtual string _Output {
			set => _Data[2].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "encrypt",
			Brief =  "Encrypt file to recryption group.",
			HandleDelegate =  CommandLineInterpreter.Handle_Encrypt,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Input", 
					Default = null, // null if null
					Brief = "File to encrypt",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Group", 
					Default = null, // null if null
					Brief = "Recryption Group identifier",
					Index = 1,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Output", 
					Default = null, // null if null
					Brief = "Encrypted File",
					Index = 2,
					Key = ""
					}
				}
			};

		}

    public partial class Encrypt : _Encrypt {
        } // class Encrypt

    public class _Decrypt : Goedel.Command.Dispatch  {

		public override Goedel.Command.Type[] _Data {get; set;} = new Goedel.Command.Type [] {
			new ExistingFile (),
			new NewFile ()			} ;

		/// <summary>Field accessor for parameter []</summary>
		public virtual ExistingFile Input {
			get => _Data[0] as ExistingFile;
			set => _Data[0]  = value;
			}

		public virtual string _Input {
			set => _Data[0].Parameter (value);
			}
		/// <summary>Field accessor for parameter []</summary>
		public virtual NewFile Output {
			get => _Data[1] as NewFile;
			set => _Data[1]  = value;
			}

		public virtual string _Output {
			set => _Data[1].Parameter (value);
			}
		public override DescribeCommandEntry DescribeCommand {get; set;} = _DescribeCommand;

		public static DescribeCommandEntry _DescribeCommand = new  DescribeCommandEntry () {
			Identifier = "decrypt",
			Brief =  "Decrypt a DARE package.",
			HandleDelegate =  CommandLineInterpreter.Handle_Decrypt,
			Lazy =  false,
			Entries = new List<DescribeEntry> () {
				new DescribeEntryParameter () {
					Identifier = "Input", 
					Default = null, // null if null
					Brief = "Encrypted File",
					Index = 0,
					Key = ""
					},
				new DescribeEntryParameter () {
					Identifier = "Output", 
					Default = null, // null if null
					Brief = "Decrypted File",
					Index = 1,
					Key = ""
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


    public partial class  String : _String {
        public static String Factory (string Value) {
            var Result = new String();
            Result.Default(Value);
            return Result;
            }
        } // String



	// The stub class just contains routines that echo their arguments and
	// write 'not yet implemented'

	// Eventually there will be a compiler option to suppress the debugging
	// to eliminate the redundant code
    public class _Shell : global::Goedel.Command.DispatchShell {

		public virtual void Register ( Register Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Create ( Create Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Add ( Add Options) {
			CommandLineInterpreter.DescribeValues (Options);
			}

		public virtual void Delete ( Delete Options) {
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


