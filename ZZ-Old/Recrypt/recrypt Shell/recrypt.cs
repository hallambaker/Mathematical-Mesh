using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Registry;

namespace Goedel.Recrypt.Shell {
    class _Main {

		static char UsageFlag;
		static char UnixFlag = '-';
		static char WindowsFlag = '/';

        static bool IsFlag(char c) {
            return (c == UnixFlag) | (c == WindowsFlag) ;
            }

        static _Main () {
			// For compatability with .NET Core, remove all references to operating
			// system version. Since this is only used for giving help, this does not
			// matter a great deal.

		    UsageFlag = WindowsFlag;

            //System.OperatingSystem OperatingSystem = System.Environment.OSVersion;

            //if (OperatingSystem.Platform == PlatformID.Unix |
            //        OperatingSystem.Platform == PlatformID.MacOSX) {
            //    UsageFlag = UnixFlag;
            //    }
            //else {
            //    UsageFlag = WindowsFlag;
            //    }
            }

        static void Main(string[] args) {

			Shell Dispatch = new Shell ();


				if (args.Length == 0) {
					throw new ParserException ("No command specified");
					}

                if (IsFlag(args[0][0])) {


                    switch (args[0].Substring(1).ToLower()) {
						case "about" : {
							FileTools.About ();
							break;
							}
						case "brief" : {
							Usage ();
							break;
							}
						case "reset" : {
							Handle_Reset (Dispatch, args, 1);
							break;
							}
						case "device" : {
							Handle_Device (Dispatch, args, 1);
							break;
							}
						case "personal" : {
							Handle_Personal (Dispatch, args, 1);
							break;
							}
						case "label" : {
							Handle_Label (Dispatch, args, 1);
							break;
							}
						case "add" : {
							Handle_Add (Dispatch, args, 1);
							break;
							}
						case "remove" : {
							Handle_Remove (Dispatch, args, 1);
							break;
							}
						case "rekey" : {
							Handle_Rekey (Dispatch, args, 1);
							break;
							}
						case "encrypt" : {
							Handle_Encrypt (Dispatch, args, 1);
							break;
							}
						case "decrypt" : {
							Handle_Decrypt (Dispatch, args, 1);
							break;
							}
						default: {
							throw new ParserException("Unknown Command: " + args[0]);
                            }
                        }
                    }
                else {
                    throw new ParserException ("No command specified");
                    }
            } // Main


		private enum TagType_Reset {
			}

		private static void Handle_Reset (
					Shell Dispatch, string[] args, int index) {
			Reset		Options = new Reset ();

			var Registry = new Goedel.Registry.Registry ();



#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Reset TagType = (TagType_Reset) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Reset (Options);

			}
		private enum TagType_Device {
			DeviceID,
			DeviceDescription,
			Default,
			}

		private static void Handle_Device (
					Shell Dispatch, string[] args, int index) {
			Device		Options = new Device ();

			var Registry = new Goedel.Registry.Registry ();

			Options.DeviceID.Register ("id", Registry, (int) TagType_Device.DeviceID);
			Options.DeviceDescription.Register ("dd", Registry, (int) TagType_Device.DeviceDescription);
			Options.Default.Register ("default", Registry, (int) TagType_Device.Default);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.DeviceID.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.DeviceDescription.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Device TagType = (TagType_Device) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Device.Default : {
						int OptionParams = Options.Default.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Default.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Device (Options);

			}
		private enum TagType_Personal {
			Portal,
			Description,
			Verbose,
			Report,
			DeviceNew,
			DeviceUDF,
			DeviceID,
			DeviceDescription,
			}

		private static void Handle_Personal (
					Shell Dispatch, string[] args, int index) {
			Personal		Options = new Personal ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_Personal.Portal);
			Options.Description.Register ("pd", Registry, (int) TagType_Personal.Description);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_Personal.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_Personal.Report);
			Options.DeviceNew.Register ("new", Registry, (int) TagType_Personal.DeviceNew);
			Options.DeviceUDF.Register ("dudf", Registry, (int) TagType_Personal.DeviceUDF);
			Options.DeviceID.Register ("did", Registry, (int) TagType_Personal.DeviceID);
			Options.DeviceDescription.Register ("dd", Registry, (int) TagType_Personal.DeviceDescription);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Portal.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Description.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Personal TagType = (TagType_Personal) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Personal.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Personal.Report : {
						int OptionParams = Options.Report.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Report.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Personal.DeviceNew : {
						int OptionParams = Options.DeviceNew.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.DeviceNew.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Personal.DeviceUDF : {
						int OptionParams = Options.DeviceUDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.DeviceUDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Personal.DeviceID : {
						int OptionParams = Options.DeviceID.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.DeviceID.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Personal.DeviceDescription : {
						int OptionParams = Options.DeviceDescription.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.DeviceDescription.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Personal (Options);

			}
		private enum TagType_Label {
			Portal,
			UDF,
			}

		private static void Handle_Label (
					Shell Dispatch, string[] args, int index) {
			Label		Options = new Label ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_Label.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Label.UDF);


#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Label TagType = (TagType_Label) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Label.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Label.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Label (Options);

			}
		private enum TagType_Add {
			}

		private static void Handle_Add (
					Shell Dispatch, string[] args, int index) {
			Add		Options = new Add ();

			var Registry = new Goedel.Registry.Registry ();



#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Add TagType = (TagType_Add) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Add (Options);

			}
		private enum TagType_Remove {
			}

		private static void Handle_Remove (
					Shell Dispatch, string[] args, int index) {
			Remove		Options = new Remove ();

			var Registry = new Goedel.Registry.Registry ();



#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Remove TagType = (TagType_Remove) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Remove (Options);

			}
		private enum TagType_Rekey {
			}

		private static void Handle_Rekey (
					Shell Dispatch, string[] args, int index) {
			Rekey		Options = new Rekey ();

			var Registry = new Goedel.Registry.Registry ();



#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Rekey TagType = (TagType_Rekey) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Rekey (Options);

			}
		private enum TagType_Encrypt {
			}

		private static void Handle_Encrypt (
					Shell Dispatch, string[] args, int index) {
			Encrypt		Options = new Encrypt ();

			var Registry = new Goedel.Registry.Registry ();



#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Encrypt TagType = (TagType_Encrypt) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Encrypt (Options);

			}
		private enum TagType_Decrypt {
			}

		private static void Handle_Decrypt (
					Shell Dispatch, string[] args, int index) {
			Decrypt		Options = new Decrypt ();

			var Registry = new Goedel.Registry.Registry ();



#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Decrypt TagType = (TagType_Decrypt) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Decrypt (Options);

			}

		private static void Usage () {

				Console.WriteLine ("brief");
				Console.WriteLine ("");

				{
#pragma warning disable 219
					Reset		Dummy = new Reset ();
#pragma warning restore 219

					Console.Write ("{0}reset ", UsageFlag);
					Console.WriteLine ();

					Console.WriteLine ("    Delete all test profiles");

				}

				{
#pragma warning disable 219
					Device		Dummy = new Device ();
#pragma warning restore 219

					Console.Write ("{0}device ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.DeviceID.Usage (null, "id", UsageFlag));
					Console.Write ("[{0}] ", Dummy.DeviceDescription.Usage (null, "dd", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Default.Usage ("default", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Create new device profile");

				}

				{
#pragma warning disable 219
					Personal		Dummy = new Personal ();
#pragma warning restore 219

					Console.Write ("{0}personal ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage (null, "portal", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Description.Usage (null, "pd", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.DeviceNew.Usage ("new", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.DeviceUDF.Usage ("dudf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.DeviceID.Usage ("did", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.DeviceDescription.Usage ("dd", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Create new personal profile");

				}

				{
#pragma warning disable 219
					Label		Dummy = new Label ();
#pragma warning restore 219

					Console.Write ("{0}label ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Create new security label");

				}

				{
#pragma warning disable 219
					Add		Dummy = new Add ();
#pragma warning restore 219

					Console.Write ("{0}add ", UsageFlag);
					Console.WriteLine ();

					Console.WriteLine ("    Add user to a label");

				}

				{
#pragma warning disable 219
					Remove		Dummy = new Remove ();
#pragma warning restore 219

					Console.Write ("{0}remove ", UsageFlag);
					Console.WriteLine ();

					Console.WriteLine ("    Remove user from a label");

				}

				{
#pragma warning disable 219
					Rekey		Dummy = new Rekey ();
#pragma warning restore 219

					Console.Write ("{0}rekey ", UsageFlag);
					Console.WriteLine ();

					Console.WriteLine ("    Create a new label key and recryption keys");

				}

				{
#pragma warning disable 219
					Encrypt		Dummy = new Encrypt ();
#pragma warning restore 219

					Console.Write ("{0}encrypt ", UsageFlag);
					Console.WriteLine ();

					Console.WriteLine ("    Encrypt a data file to a label");

				}

				{
#pragma warning disable 219
					Decrypt		Dummy = new Decrypt ();
#pragma warning restore 219

					Console.Write ("{0}decrypt ", UsageFlag);
					Console.WriteLine ();

					Console.WriteLine ("    Decrypt a data file");

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




    public class _Reset : Goedel.Registry.Dispatch {


		}

    public partial class Reset : _Reset {
        } // class Reset


    public class _Device : Goedel.Registry.Dispatch {
		public String			DeviceID = new String ();
		public String			DeviceDescription = new String ();

		public Flag			Default = new  Flag ();


		}

    public partial class Device : _Device {
        } // class Device


    public class _Personal : Goedel.Registry.Dispatch {
		public String			Portal = new String ();
		public String			Description = new String ();

		public Flag			Verbose = new  Flag ("true");

		public Flag			Report = new  Flag ("true");

		public Flag			DeviceNew = new  Flag ();

		public String			DeviceUDF = new  String ();

		public String			DeviceID = new  String ();

		public String			DeviceDescription = new  String ();


		}

    public partial class Personal : _Personal {
        } // class Personal


    public class _Label : Goedel.Registry.Dispatch {

		public String			Portal = new  String ();

		public String			UDF = new  String ();


		}

    public partial class Label : _Label {
        } // class Label


    public class _Add : Goedel.Registry.Dispatch {


		}

    public partial class Add : _Add {
        } // class Add


    public class _Remove : Goedel.Registry.Dispatch {


		}

    public partial class Remove : _Remove {
        } // class Remove


    public class _Rekey : Goedel.Registry.Dispatch {


		}

    public partial class Rekey : _Rekey {
        } // class Rekey


    public class _Encrypt : Goedel.Registry.Dispatch {


		}

    public partial class Encrypt : _Encrypt {
        } // class Encrypt


    public class _Decrypt : Goedel.Registry.Dispatch {


		}

    public partial class Decrypt : _Decrypt {
        } // class Decrypt



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




	// The stub class just contains routines that echo their arguments and
	// write 'not yet implemented'

	// Eventually there will be a compiler option to suppress the debugging
	// to eliminate the redundant code
    public class _Shell {


		public virtual void Reset ( Reset Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Reset		Dummy = new Reset ();
#pragma warning restore 219

					Console.Write ("{0}reset ", UsageFlag);
					Console.WriteLine ();

					Console.WriteLine ("    Delete all test profiles");

				}

			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Device ( Device Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Device		Dummy = new Device ();
#pragma warning restore 219

					Console.Write ("{0}device ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.DeviceID.Usage (null, "id", UsageFlag));
					Console.Write ("[{0}] ", Dummy.DeviceDescription.Usage (null, "dd", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Default.Usage ("default", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Create new device profile");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"DeviceID", Options.DeviceID);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"DeviceDescription", Options.DeviceDescription);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Default", Options.Default);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Personal ( Personal Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Personal		Dummy = new Personal ();
#pragma warning restore 219

					Console.Write ("{0}personal ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage (null, "portal", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Description.Usage (null, "pd", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.DeviceNew.Usage ("new", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.DeviceUDF.Usage ("dudf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.DeviceID.Usage ("did", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.DeviceDescription.Usage ("dd", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Create new personal profile");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Description", Options.Description);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"DeviceNew", Options.DeviceNew);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"DeviceUDF", Options.DeviceUDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"DeviceID", Options.DeviceID);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"DeviceDescription", Options.DeviceDescription);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Label ( Label Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Label		Dummy = new Label ();
#pragma warning restore 219

					Console.Write ("{0}label ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Create new security label");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Add ( Add Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Add		Dummy = new Add ();
#pragma warning restore 219

					Console.Write ("{0}add ", UsageFlag);
					Console.WriteLine ();

					Console.WriteLine ("    Add user to a label");

				}

			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Remove ( Remove Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Remove		Dummy = new Remove ();
#pragma warning restore 219

					Console.Write ("{0}remove ", UsageFlag);
					Console.WriteLine ();

					Console.WriteLine ("    Remove user from a label");

				}

			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Rekey ( Rekey Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Rekey		Dummy = new Rekey ();
#pragma warning restore 219

					Console.Write ("{0}rekey ", UsageFlag);
					Console.WriteLine ();

					Console.WriteLine ("    Create a new label key and recryption keys");

				}

			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Encrypt ( Encrypt Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Encrypt		Dummy = new Encrypt ();
#pragma warning restore 219

					Console.Write ("{0}encrypt ", UsageFlag);
					Console.WriteLine ();

					Console.WriteLine ("    Encrypt a data file to a label");

				}

			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Decrypt ( Decrypt Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Decrypt		Dummy = new Decrypt ();
#pragma warning restore 219

					Console.Write ("{0}decrypt ", UsageFlag);
					Console.WriteLine ();

					Console.WriteLine ("    Decrypt a data file");

				}

			Console.WriteLine ("Not Yet Implemented");
			}

        } // class _Shell

    public partial class Shell : _Shell {
        } // class Shell

    } // namespace Shell


