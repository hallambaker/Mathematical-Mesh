using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Registry;

namespace MeshServerShell {
    public partial class CommandLineInterpreter : CommandLineInterpreterBase {

		static char UsageFlag;
		static char UnixFlag = '-';
		static char WindowsFlag = '/';

        static bool IsFlag(char c) {
            return (c == UnixFlag) | (c == WindowsFlag) ;
            }

        static CommandLineInterpreter () {
            System.OperatingSystem OperatingSystem = System.Environment.OSVersion;

            if (OperatingSystem.Platform == PlatformID.Unix |
                    OperatingSystem.Platform == PlatformID.MacOSX) {
                UsageFlag = UnixFlag;
                }
            else {
                UsageFlag = WindowsFlag;
                }
            }

        static void Main(string[] args) {
			var CLI = new CommandLineInterpreter ();
			CLI.MainMethod (args);
			}
        public void MainMethod(string[] args) {

			MeshServerShell Dispatch = new MeshServerShell ();


				if (args.Length == 0) {
					throw new ParserException ("No command specified");
					}

                if (IsFlag(args[0][0])) {


                    switch (args[0].Substring(1).ToLower()) {
						case "mathematical mesh server" : {
							Usage ();
							break;
							}
						case "start" : {
							Handle_Start (Dispatch, args, 1);
							break;
							}
						case "about" : {
							Handle_About (Dispatch, args, 1);
							break;
							}
						default: {
							throw new ParserException("Unknown Command: " + args[0]);
                            }
                        }
                    }
                else {
					Handle_Start (Dispatch, args, 0);
                    }
            } // Main


		private enum TagType_Start {
			PortalAddress,
			HostAddress,
			MeshStore,
			PortalStore,
			Verify,
			Fallback,
			Multithread,
			}

		private static void Handle_Start (
					MeshServerShell Dispatch, string[] args, int index) {
			Start		Options = new Start ();

			var Registry = new Goedel.Registry.Registry ();

			Options.PortalAddress.Register ("portal", Registry, (int) TagType_Start.PortalAddress);
			Options.HostAddress.Register ("host", Registry, (int) TagType_Start.HostAddress);
			Options.MeshStore.Register ("mlog", Registry, (int) TagType_Start.MeshStore);
			Options.PortalStore.Register ("plog", Registry, (int) TagType_Start.PortalStore);
			Options.Verify.Register ("verify", Registry, (int) TagType_Start.Verify);
			Options.Fallback.Register ("fallback", Registry, (int) TagType_Start.Fallback);
			Options.Multithread.Register ("multi", Registry, (int) TagType_Start.Multithread);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.PortalAddress.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.HostAddress.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Start TagType = (TagType_Start) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Start.MeshStore : {
						int OptionParams = Options.MeshStore.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.MeshStore.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Start.PortalStore : {
						int OptionParams = Options.PortalStore.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.PortalStore.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Start.Verify : {
						int OptionParams = Options.Verify.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verify.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Start.Fallback : {
						int OptionParams = Options.Fallback.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Fallback.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Start.Multithread : {
						int OptionParams = Options.Multithread.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Multithread.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Start (Options);

			}
		private enum TagType_About {
			}

		private static void Handle_About (
					MeshServerShell Dispatch, string[] args, int index) {
			About		Options = new About ();

			var Registry = new Goedel.Registry.Registry ();



#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_About TagType = (TagType_About) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.About (Options);

			}

		private static void Usage () {

				Console.WriteLine ("MatheMatical Mesh Server");
				Console.WriteLine ("");

				{
#pragma warning disable 219
					Start		Dummy = new Start ();
#pragma warning restore 219

					Console.Write ("{0}start ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.PortalAddress.Usage (null, "portal", UsageFlag));
					Console.Write ("[{0}] ", Dummy.HostAddress.Usage (null, "host", UsageFlag));
					Console.Write ("[{0}] ", Dummy.MeshStore.Usage ("mlog", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.PortalStore.Usage ("plog", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verify.Usage ("verify", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Fallback.Usage ("fallback", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Multithread.Usage ("multi", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Start Mesh server");

				}

				{
#pragma warning disable 219
					About		Dummy = new About ();
#pragma warning restore 219

					Console.Write ("{0}about ", UsageFlag);
					Console.WriteLine ();

					Console.WriteLine ("    Report version and build date");

				}

			} // Usage 

		public class ParserException : System.Exception {

			public ParserException(string message)
				: base(message) {

				Console.WriteLine (message);
				}
			}


	} // class Main


	// The stub class for carrying optional parameters for each command type
	// As with the main class each consists of an abstract main class 
	// with partial virtual that can be extended as required.

	// All subclasses inherit from the abstract classes Goedel.Regisrty.Dispatch 
	// and Goedel.Registry.Type




    public class _Start : Goedel.Registry.Dispatch {
		public String			PortalAddress = new String ();
		public String			HostAddress = new String ();

		public String			MeshStore = new  String ("MeshPersistenceStore.jlog");

		public String			PortalStore = new  String ("PortalPersistenceStore.jlog");

		public Flag			Verify = new  Flag ();

		public Flag			Fallback = new  Flag ("true");

		public Flag			Multithread = new  Flag ("true");


		}

    public partial class Start : _Start {
        } // class Start


    public class _About : Goedel.Registry.Dispatch {


		}

    public partial class About : _About {
        } // class About



    // Parameter type NewFile
    public abstract class _NewFile : Goedel.Registry._File {
        public _NewFile() {
            }
        public _NewFile(string Value) {
			Default (Value);
            } 



        } // _NewFile

    public partial class  NewFile : _NewFile {
        public NewFile() {
            } 
        public NewFile(string Value) {
			Default (Value);
            } 
        } // NewFile


    // Parameter type ExistingFile
    public abstract class _ExistingFile : Goedel.Registry._File {
        public _ExistingFile() {
            }
        public _ExistingFile(string Value) {
			Default (Value);
            } 



        } // _ExistingFile

    public partial class  ExistingFile : _ExistingFile {
        public ExistingFile() {
            } 
        public ExistingFile(string Value) {
			Default (Value);
            } 
        } // ExistingFile


    // Parameter type String
    public abstract class _String : Goedel.Registry.Type {
        public _String() {
            }
        public _String(string Value) {
			Default (Value);
            } 

		public string			Value {
			get {return Text;}
			}

        } // _String

    public partial class  String : _String {
        public String() {
            } 
        public String(string Value) {
			Default (Value);
            } 
        } // String


    // Parameter type Flag
    public abstract class _Flag : Goedel.Registry._Flag {
        public _Flag() {
            }
        public _Flag(string Value) {
			Default (Value);
            } 




        } // _Flag

    public partial class  Flag : _Flag {
        public Flag() {
            } 
        public Flag(string Value) {
			Default (Value);
            } 
        } // Flag




	// The stub class just contains routines that echo their arguments and
	// write 'not yet implemented'

	// Eventually there will be a compiler option to suppress the debugging
	// to eliminate the redundant code
    public class _MeshServerShell {


		public virtual void Start ( Start Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Start		Dummy = new Start ();
#pragma warning restore 219

					Console.Write ("{0}start ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.PortalAddress.Usage (null, "portal", UsageFlag));
					Console.Write ("[{0}] ", Dummy.HostAddress.Usage (null, "host", UsageFlag));
					Console.Write ("[{0}] ", Dummy.MeshStore.Usage ("mlog", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.PortalStore.Usage ("plog", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verify.Usage ("verify", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Fallback.Usage ("fallback", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Multithread.Usage ("multi", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Start Mesh server");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"PortalAddress", Options.PortalAddress);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"HostAddress", Options.HostAddress);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"MeshStore", Options.MeshStore);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"PortalStore", Options.PortalStore);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verify", Options.Verify);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Fallback", Options.Fallback);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Multithread", Options.Multithread);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void About ( About Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					About		Dummy = new About ();
#pragma warning restore 219

					Console.Write ("{0}about ", UsageFlag);
					Console.WriteLine ();

					Console.WriteLine ("    Report version and build date");

				}

			Console.WriteLine ("Not Yet Implemented");
			}

        } // class _MeshServerShell

    public partial class MeshServerShell : _MeshServerShell {
        } // class MeshServerShell

    } // namespace MeshServerShell


