
//This file was automatically generated at 11/10/2015 5:04:43 PM
// 
//Changes to this file may be overwritten without warning
//
//Generator:  CommandParse version 1.0.5616.17996
//    Goedel Script Version : 0.1   Generated 
//    Goedel Schema Version : 0.1   Generated
//
//    Copyright : Copyright ©  2012
//
//Build Platform: Win32NT 6.2.9200.0
//
//
//Copyright ©  2012 by Default Deny Security Inc.
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in
//all copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//THE SOFTWARE.
//
//


using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Registry;

namespace MeshServerShell {
    class _Main {

		static char UsageFlag;
		static char UnixFlag = '-';
		static char WindowsFlag = '/';

		//static char Separator;
		//static char UnixSeparator = '=';
		//static char WindowsSeparator = ':';

        static bool IsFlag(char c) {
            return (c == UnixFlag) | (c == WindowsFlag) ;
            }

        static _Main () {
            System.OperatingSystem OperatingSystem = System.Environment.OSVersion;

            if (OperatingSystem.Platform == PlatformID.Unix |
                    OperatingSystem.Platform == PlatformID.MacOSX) {
                UsageFlag = UnixFlag;
				//Separator = UnixSeparator;
                }
            else {
                UsageFlag = WindowsFlag;
				//Separator = WindowsSeparator;
                }
            }

        static void Main(string[] args) {

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
			Address,
			MeshStore,
			PortalStore,
			Verify,
			}

		private static void Handle_Start (
					MeshServerShell Dispatch, string[] args, int index) {
			Start		Options = new Start ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Address.Register ("address", Registry, (int) TagType_Start.Address);
			Options.MeshStore.Register ("mesh", Registry, (int) TagType_Start.MeshStore);
			Options.PortalStore.Register ("mesh", Registry, (int) TagType_Start.PortalStore);
			Options.Verify.Register ("verify", Registry, (int) TagType_Start.Verify);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Address.Parameter (args [index]);
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
					Console.Write ("[{0}] ", Dummy.Address.Usage (null, "address", UsageFlag));
					Console.Write ("[{0}] ", Dummy.MeshStore.Usage ("mesh", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.PortalStore.Usage ("mesh", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verify.Usage ("verify", "value", UsageFlag));
					Console.WriteLine ();

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
		public String			Address = new String ();

		public String			MeshStore = new  String ("MeshPersistenceStore.jlog");

		public String			PortalStore = new  String ("PortalPersistenceStore.jlog");

		public Flag			Verify = new  Flag ();


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
					Console.Write ("[{0}] ", Dummy.Address.Usage (null, "address", UsageFlag));
					Console.Write ("[{0}] ", Dummy.MeshStore.Usage ("mesh", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.PortalStore.Usage ("mesh", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verify.Usage ("verify", "value", UsageFlag));
					Console.WriteLine ();

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Address", Options.Address);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"MeshStore", Options.MeshStore);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"PortalStore", Options.PortalStore);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verify", Options.Verify);
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


