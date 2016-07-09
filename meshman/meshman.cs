using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Registry;

namespace Goedel.Mesh.MeshMan {
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

			MeshManShell Dispatch = new MeshManShell ();


				if (args.Length == 0) {
					throw new ParserException ("No command specified");
					}

                if (IsFlag(args[0][0])) {


                    switch (args[0].Substring(1).ToLower()) {
						case "mathematical mesh key manager" : {
							Usage ();
							break;
							}
						case "about" : {
							Handle_About (Dispatch, args, 1);
							break;
							}
						case "reset" : {
							Handle_Reset (Dispatch, args, 1);
							break;
							}
						case "create" : {
							Handle_Create (Dispatch, args, 1);
							break;
							}
						case "register" : {
							Handle_Register (Dispatch, args, 1);
							break;
							}
						case "sync" : {
							Handle_Sync (Dispatch, args, 1);
							break;
							}
						case "escrow" : {
							Handle_Escrow (Dispatch, args, 1);
							break;
							}
						case "export" : {
							Handle_Export (Dispatch, args, 1);
							break;
							}
						case "import" : {
							Handle_Import (Dispatch, args, 1);
							break;
							}
						case "list" : {
							Handle_List (Dispatch, args, 1);
							break;
							}
						case "pending" : {
							Handle_Pending (Dispatch, args, 1);
							break;
							}
						case "connect" : {
							Handle_Connect (Dispatch, args, 1);
							break;
							}
						case "accept" : {
							Handle_Accept (Dispatch, args, 1);
							break;
							}
						case "complete" : {
							Handle_Complete (Dispatch, args, 1);
							break;
							}
						case "web" : {
							Handle_Web (Dispatch, args, 1);
							break;
							}
						case "pwa" : {
							Handle_AddPassword (Dispatch, args, 1);
							break;
							}
						case "pwg" : {
							Handle_GetPassword (Dispatch, args, 1);
							break;
							}
						case "pwd" : {
							Handle_DeletePassword (Dispatch, args, 1);
							break;
							}
						case "mail" : {
							Handle_Mail (Dispatch, args, 1);
							break;
							}
						case "ssh" : {
							Handle_SSH (Dispatch, args, 1);
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


		private enum TagType_About {
			}

		private static void Handle_About (
					MeshManShell Dispatch, string[] args, int index) {
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
		private enum TagType_Reset {
			}

		private static void Handle_Reset (
					MeshManShell Dispatch, string[] args, int index) {
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
		private enum TagType_Create {
			Profile,
			}

		private static void Handle_Create (
					MeshManShell Dispatch, string[] args, int index) {
			Create		Options = new Create ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Profile.Register ("profile", Registry, (int) TagType_Create.Profile);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Profile.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Create TagType = (TagType_Create) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Create (Options);

			}
		private enum TagType_Register {
			UDF,
			Portal,
			}

		private static void Handle_Register (
					MeshManShell Dispatch, string[] args, int index) {
			Register		Options = new Register ();

			var Registry = new Goedel.Registry.Registry ();

			Options.UDF.Register ("udf", Registry, (int) TagType_Register.UDF);
			Options.Portal.Register ("portal", Registry, (int) TagType_Register.Portal);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.UDF.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Portal.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Register TagType = (TagType_Register) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Register (Options);

			}
		private enum TagType_Sync {
			Portal,
			UDF,
			}

		private static void Handle_Sync (
					MeshManShell Dispatch, string[] args, int index) {
			Sync		Options = new Sync ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_Sync.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Sync.UDF);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Portal.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.UDF.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Sync TagType = (TagType_Sync) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Sync (Options);

			}
		private enum TagType_Escrow {
			Portal,
			UDF,
			Quorum,
			Shares,
			}

		private static void Handle_Escrow (
					MeshManShell Dispatch, string[] args, int index) {
			Escrow		Options = new Escrow ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_Escrow.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Escrow.UDF);
			Options.Quorum.Register ("quorum", Registry, (int) TagType_Escrow.Quorum);
			Options.Shares.Register ("shares", Registry, (int) TagType_Escrow.Shares);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Portal.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.UDF.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Escrow TagType = (TagType_Escrow) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Escrow.Quorum : {
						int OptionParams = Options.Quorum.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Quorum.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Escrow.Shares : {
						int OptionParams = Options.Shares.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Shares.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Escrow (Options);

			}
		private enum TagType_Export {
			File,
			Portal,
			UDF,
			}

		private static void Handle_Export (
					MeshManShell Dispatch, string[] args, int index) {
			Export		Options = new Export ();

			var Registry = new Goedel.Registry.Registry ();

			Options.File.Register ("file", Registry, (int) TagType_Export.File);
			Options.Portal.Register ("portal", Registry, (int) TagType_Export.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Export.UDF);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.File.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Portal.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.UDF.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Export TagType = (TagType_Export) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Export (Options);

			}
		private enum TagType_Import {
			File,
			Portal,
			UDF,
			}

		private static void Handle_Import (
					MeshManShell Dispatch, string[] args, int index) {
			Import		Options = new Import ();

			var Registry = new Goedel.Registry.Registry ();

			Options.File.Register ("file", Registry, (int) TagType_Import.File);
			Options.Portal.Register ("portal", Registry, (int) TagType_Import.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Import.UDF);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.File.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Portal.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.UDF.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Import TagType = (TagType_Import) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Import (Options);

			}
		private enum TagType_List {
			Portal,
			UDF,
			All,
			}

		private static void Handle_List (
					MeshManShell Dispatch, string[] args, int index) {
			List		Options = new List ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_List.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_List.UDF);
			Options.All.Register ("all", Registry, (int) TagType_List.All);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Portal.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.UDF.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.All.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_List TagType = (TagType_List) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.List (Options);

			}
		private enum TagType_Pending {
			Portal,
			}

		private static void Handle_Pending (
					MeshManShell Dispatch, string[] args, int index) {
			Pending		Options = new Pending ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_Pending.Portal);


#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Pending TagType = (TagType_Pending) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Pending.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Pending (Options);

			}
		private enum TagType_Connect {
			UDF,
			Portal,
			PIN,
			}

		private static void Handle_Connect (
					MeshManShell Dispatch, string[] args, int index) {
			Connect		Options = new Connect ();

			var Registry = new Goedel.Registry.Registry ();

			Options.UDF.Register ("udf", Registry, (int) TagType_Connect.UDF);
			Options.Portal.Register ("portal", Registry, (int) TagType_Connect.Portal);
			Options.PIN.Register ("pin", Registry, (int) TagType_Connect.PIN);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.UDF.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Connect TagType = (TagType_Connect) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Connect.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Connect.PIN : {
						int OptionParams = Options.PIN.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.PIN.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Connect (Options);

			}
		private enum TagType_Accept {
			UDF,
			}

		private static void Handle_Accept (
					MeshManShell Dispatch, string[] args, int index) {
			Accept		Options = new Accept ();

			var Registry = new Goedel.Registry.Registry ();

			Options.UDF.Register ("udf", Registry, (int) TagType_Accept.UDF);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.UDF.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Accept TagType = (TagType_Accept) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Accept (Options);

			}
		private enum TagType_Complete {
			Portal,
			UDF,
			}

		private static void Handle_Complete (
					MeshManShell Dispatch, string[] args, int index) {
			Complete		Options = new Complete ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_Complete.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Complete.UDF);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.UDF.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Complete TagType = (TagType_Complete) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Complete.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Complete (Options);

			}
		private enum TagType_Web {
			Portal,
			UDF,
			}

		private static void Handle_Web (
					MeshManShell Dispatch, string[] args, int index) {
			Web		Options = new Web ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_Web.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Web.UDF);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.UDF.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Web TagType = (TagType_Web) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Web.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Web (Options);

			}
		private enum TagType_AddPassword {
			Site,
			Username,
			Password,
			Portal,
			UDF,
			}

		private static void Handle_AddPassword (
					MeshManShell Dispatch, string[] args, int index) {
			AddPassword		Options = new AddPassword ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Site.Register ("site", Registry, (int) TagType_AddPassword.Site);
			Options.Username.Register ("user", Registry, (int) TagType_AddPassword.Username);
			Options.Password.Register ("password", Registry, (int) TagType_AddPassword.Password);
			Options.Portal.Register ("portal", Registry, (int) TagType_AddPassword.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_AddPassword.UDF);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Site.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Username.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Password.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.UDF.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_AddPassword TagType = (TagType_AddPassword) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_AddPassword.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.AddPassword (Options);

			}
		private enum TagType_GetPassword {
			Site,
			Portal,
			UDF,
			}

		private static void Handle_GetPassword (
					MeshManShell Dispatch, string[] args, int index) {
			GetPassword		Options = new GetPassword ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Site.Register ("site", Registry, (int) TagType_GetPassword.Site);
			Options.Portal.Register ("portal", Registry, (int) TagType_GetPassword.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_GetPassword.UDF);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Site.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.UDF.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_GetPassword TagType = (TagType_GetPassword) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_GetPassword.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.GetPassword (Options);

			}
		private enum TagType_DeletePassword {
			Site,
			Portal,
			UDF,
			}

		private static void Handle_DeletePassword (
					MeshManShell Dispatch, string[] args, int index) {
			DeletePassword		Options = new DeletePassword ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Site.Register ("site", Registry, (int) TagType_DeletePassword.Site);
			Options.Portal.Register ("portal", Registry, (int) TagType_DeletePassword.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_DeletePassword.UDF);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Site.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.UDF.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_DeletePassword TagType = (TagType_DeletePassword) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_DeletePassword.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.DeletePassword (Options);

			}
		private enum TagType_Mail {
			address,
			Portal,
			UDF,
			}

		private static void Handle_Mail (
					MeshManShell Dispatch, string[] args, int index) {
			Mail		Options = new Mail ();

			var Registry = new Goedel.Registry.Registry ();

			Options.address.Register ("address", Registry, (int) TagType_Mail.address);
			Options.Portal.Register ("portal", Registry, (int) TagType_Mail.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Mail.UDF);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.address.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.UDF.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Mail TagType = (TagType_Mail) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Mail.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Mail (Options);

			}
		private enum TagType_SSH {
			Portal,
			UDF,
			}

		private static void Handle_SSH (
					MeshManShell Dispatch, string[] args, int index) {
			SSH		Options = new SSH ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_SSH.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_SSH.UDF);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.UDF.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_SSH TagType = (TagType_SSH) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_SSH.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.SSH (Options);

			}

		private static void Usage () {

				Console.WriteLine ("MatheMatical Mesh Key Manager");
				Console.WriteLine ("");

				{
#pragma warning disable 219
					About		Dummy = new About ();
#pragma warning restore 219

					Console.Write ("{0}about ", UsageFlag);
					Console.WriteLine ();

					Console.WriteLine ("    Report version and build date");

				}

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
					Create		Dummy = new Create ();
#pragma warning restore 219

					Console.Write ("{0}create ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Profile.Usage (null, "profile", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Create new personal profile");

				}

				{
#pragma warning disable 219
					Register		Dummy = new Register ();
#pragma warning restore 219

					Console.Write ("{0}register ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage (null, "portal", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Register the specified profile at a new portal");

				}

				{
#pragma warning disable 219
					Sync		Dummy = new Sync ();
#pragma warning restore 219

					Console.Write ("{0}sync ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage (null, "portal", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Synchronize local copies of Mesh profiles with the server");

				}

				{
#pragma warning disable 219
					Escrow		Dummy = new Escrow ();
#pragma warning restore 219

					Console.Write ("{0}escrow ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage (null, "portal", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Quorum.Usage ("quorum", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Shares.Usage ("shares", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Create a set of key escrow shares");

				}

				{
#pragma warning disable 219
					Export		Dummy = new Export ();
#pragma warning restore 219

					Console.Write ("{0}export ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.File.Usage (null, "file", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage (null, "portal", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Export the specified profile data to the specified file");

				}

				{
#pragma warning disable 219
					Import		Dummy = new Import ();
#pragma warning restore 219

					Console.Write ("{0}import ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.File.Usage (null, "file", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage (null, "portal", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Import the specified profile data to the specified file");

				}

				{
#pragma warning disable 219
					List		Dummy = new List ();
#pragma warning restore 219

					Console.Write ("{0}list ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage (null, "portal", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.All.Usage (null, "all", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    List all profiles");

				}

				{
#pragma warning disable 219
					Pending		Dummy = new Pending ();
#pragma warning restore 219

					Console.Write ("{0}pending ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Get list of pending connection requests");

				}

				{
#pragma warning disable 219
					Connect		Dummy = new Connect ();
#pragma warning restore 219

					Console.Write ("{0}connect ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.PIN.Usage ("pin", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Connect to an existing profile registered at a portal");

				}

				{
#pragma warning disable 219
					Accept		Dummy = new Accept ();
#pragma warning restore 219

					Console.Write ("{0}accept ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Accept a pending connection");

				}

				{
#pragma warning disable 219
					Complete		Dummy = new Complete ();
#pragma warning restore 219

					Console.Write ("{0}complete ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Complete a pending connection request");

				}

				{
#pragma warning disable 219
					Web		Dummy = new Web ();
#pragma warning restore 219

					Console.Write ("{0}web ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Add a web application profile to a personal profile");

				}

				{
#pragma warning disable 219
					AddPassword		Dummy = new AddPassword ();
#pragma warning restore 219

					Console.Write ("{0}pwa ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Site.Usage (null, "site", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Username.Usage (null, "user", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Password.Usage (null, "password", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.WriteLine ();

				}

				{
#pragma warning disable 219
					GetPassword		Dummy = new GetPassword ();
#pragma warning restore 219

					Console.Write ("{0}pwg ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Site.Usage (null, "site", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.WriteLine ();

				}

				{
#pragma warning disable 219
					DeletePassword		Dummy = new DeletePassword ();
#pragma warning restore 219

					Console.Write ("{0}pwd ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Site.Usage (null, "site", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.WriteLine ();

				}

				{
#pragma warning disable 219
					Mail		Dummy = new Mail ();
#pragma warning restore 219

					Console.Write ("{0}mail ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.address.Usage (null, "address", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Add a mail application profile to a personal profile");

				}

				{
#pragma warning disable 219
					SSH		Dummy = new SSH ();
#pragma warning restore 219

					Console.Write ("{0}ssh ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Add a ssh application profile to a personal profile");

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




    public class _About : Goedel.Registry.Dispatch {


		}

    public partial class About : _About {
        } // class About


    public class _Reset : Goedel.Registry.Dispatch {


		}

    public partial class Reset : _Reset {
        } // class Reset


    public class _Create : Goedel.Registry.Dispatch {
		public String			Profile = new String ();


		}

    public partial class Create : _Create {
        } // class Create


    public class _Register : Goedel.Registry.Dispatch {
		public String			UDF = new String ();
		public String			Portal = new String ();


		}

    public partial class Register : _Register {
        } // class Register


    public class _Sync : Goedel.Registry.Dispatch {
		public String			Portal = new String ();
		public String			UDF = new String ();


		}

    public partial class Sync : _Sync {
        } // class Sync


    public class _Escrow : Goedel.Registry.Dispatch {
		public String			Portal = new String ();
		public String			UDF = new String ();

		public integer			Quorum = new  integer ();

		public integer			Shares = new  integer ();


		}

    public partial class Escrow : _Escrow {
        } // class Escrow


    public class _Export : Goedel.Registry.Dispatch {
		public NewFile			File = new NewFile ();
		public String			Portal = new String ();
		public String			UDF = new String ();


		}

    public partial class Export : _Export {
        } // class Export


    public class _Import : Goedel.Registry.Dispatch {
		public NewFile			File = new NewFile ();
		public String			Portal = new String ();
		public String			UDF = new String ();


		}

    public partial class Import : _Import {
        } // class Import


    public class _List : Goedel.Registry.Dispatch {
		public String			Portal = new String ();
		public String			UDF = new String ();
		public Flag			All = new Flag ();


		}

    public partial class List : _List {
        } // class List


    public class _Pending : Goedel.Registry.Dispatch {

		public String			Portal = new  String ();


		}

    public partial class Pending : _Pending {
        } // class Pending


    public class _Connect : Goedel.Registry.Dispatch {
		public String			UDF = new String ();

		public String			Portal = new  String ();

		public String			PIN = new  String ();


		}

    public partial class Connect : _Connect {
        } // class Connect


    public class _Accept : Goedel.Registry.Dispatch {
		public String			UDF = new String ();


		}

    public partial class Accept : _Accept {
        } // class Accept


    public class _Complete : Goedel.Registry.Dispatch {

		public String			Portal = new  String ();
		public String			UDF = new String ();


		}

    public partial class Complete : _Complete {
        } // class Complete


    public class _Web : Goedel.Registry.Dispatch {

		public String			Portal = new  String ();
		public string			UDF = new string ();


		}

    public partial class Web : _Web {
        } // class Web


    public class _AddPassword : Goedel.Registry.Dispatch {
		public String			Site = new String ();
		public String			Username = new String ();
		public String			Password = new String ();

		public String			Portal = new  String ();
		public String			UDF = new String ();


		}

    public partial class AddPassword : _AddPassword {
        } // class AddPassword


    public class _GetPassword : Goedel.Registry.Dispatch {
		public String			Site = new String ();

		public String			Portal = new  String ();
		public string			UDF = new string ();


		}

    public partial class GetPassword : _GetPassword {
        } // class GetPassword


    public class _DeletePassword : Goedel.Registry.Dispatch {
		public String			Site = new String ();

		public String			Portal = new  String ();
		public String			UDF = new String ();


		}

    public partial class DeletePassword : _DeletePassword {
        } // class DeletePassword


    public class _Mail : Goedel.Registry.Dispatch {
		public String			address = new String ();

		public String			Portal = new  String ();
		public String			UDF = new String ();


		}

    public partial class Mail : _Mail {
        } // class Mail


    public class _SSH : Goedel.Registry.Dispatch {

		public String			Portal = new  String ();
		public String			UDF = new String ();


		}

    public partial class SSH : _SSH {
        } // class SSH



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


    // Parameter type integer
    public abstract class _integer : Goedel.Registry.Type {
        public _integer() {
            }
        public _integer(string Value) {
			Default (Value);
            } 

		public string			Value {
			get {return Text;}
			}

        } // _integer

    public partial class  integer : _integer {
        public integer() {
            } 
        public integer(string Value) {
			Default (Value);
            } 
        } // integer


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


    // Parameter type string
    public abstract class _string : Goedel.Registry.Type {
        public _string() {
            }
        public _string(string Value) {
			Default (Value);
            } 

		public string			Value {
			get {return Text;}
			}

        } // _string

    public partial class  string : _string {
        public string() {
            } 
        public string(string Value) {
			Default (Value);
            } 
        } // string




	// The stub class just contains routines that echo their arguments and
	// write 'not yet implemented'

	// Eventually there will be a compiler option to suppress the debugging
	// to eliminate the redundant code
    public class _MeshManShell {


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
		public virtual void Create ( Create Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Create		Dummy = new Create ();
#pragma warning restore 219

					Console.Write ("{0}create ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Profile.Usage (null, "profile", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Create new personal profile");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Profile", Options.Profile);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Register ( Register Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Register		Dummy = new Register ();
#pragma warning restore 219

					Console.Write ("{0}register ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage (null, "portal", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Register the specified profile at a new portal");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Sync ( Sync Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Sync		Dummy = new Sync ();
#pragma warning restore 219

					Console.Write ("{0}sync ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage (null, "portal", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Synchronize local copies of Mesh profiles with the server");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Escrow ( Escrow Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Escrow		Dummy = new Escrow ();
#pragma warning restore 219

					Console.Write ("{0}escrow ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage (null, "portal", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Quorum.Usage ("quorum", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Shares.Usage ("shares", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Create a set of key escrow shares");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "integer", 
							"Quorum", Options.Quorum);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "integer", 
							"Shares", Options.Shares);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Export ( Export Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Export		Dummy = new Export ();
#pragma warning restore 219

					Console.Write ("{0}export ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.File.Usage (null, "file", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage (null, "portal", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Export the specified profile data to the specified file");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "NewFile", 
							"File", Options.File);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Import ( Import Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Import		Dummy = new Import ();
#pragma warning restore 219

					Console.Write ("{0}import ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.File.Usage (null, "file", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage (null, "portal", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Import the specified profile data to the specified file");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "NewFile", 
							"File", Options.File);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void List ( List Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					List		Dummy = new List ();
#pragma warning restore 219

					Console.Write ("{0}list ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage (null, "portal", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.All.Usage (null, "all", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    List all profiles");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"All", Options.All);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Pending ( Pending Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Pending		Dummy = new Pending ();
#pragma warning restore 219

					Console.Write ("{0}pending ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Get list of pending connection requests");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Connect ( Connect Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Connect		Dummy = new Connect ();
#pragma warning restore 219

					Console.Write ("{0}connect ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.PIN.Usage ("pin", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Connect to an existing profile registered at a portal");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"PIN", Options.PIN);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Accept ( Accept Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Accept		Dummy = new Accept ();
#pragma warning restore 219

					Console.Write ("{0}accept ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Accept a pending connection");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Complete ( Complete Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Complete		Dummy = new Complete ();
#pragma warning restore 219

					Console.Write ("{0}complete ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Complete a pending connection request");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Web ( Web Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Web		Dummy = new Web ();
#pragma warning restore 219

					Console.Write ("{0}web ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Add a web application profile to a personal profile");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "string", 
							"UDF", Options.UDF);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void AddPassword ( AddPassword Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					AddPassword		Dummy = new AddPassword ();
#pragma warning restore 219

					Console.Write ("{0}pwa ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Site.Usage (null, "site", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Username.Usage (null, "user", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Password.Usage (null, "password", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.WriteLine ();

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Site", Options.Site);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Username", Options.Username);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Password", Options.Password);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void GetPassword ( GetPassword Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					GetPassword		Dummy = new GetPassword ();
#pragma warning restore 219

					Console.Write ("{0}pwg ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Site.Usage (null, "site", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.WriteLine ();

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Site", Options.Site);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "string", 
							"UDF", Options.UDF);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void DeletePassword ( DeletePassword Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					DeletePassword		Dummy = new DeletePassword ();
#pragma warning restore 219

					Console.Write ("{0}pwd ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Site.Usage (null, "site", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.WriteLine ();

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Site", Options.Site);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Mail ( Mail Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Mail		Dummy = new Mail ();
#pragma warning restore 219

					Console.Write ("{0}mail ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.address.Usage (null, "address", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Add a mail application profile to a personal profile");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"address", Options.address);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void SSH ( SSH Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					SSH		Dummy = new SSH ();
#pragma warning restore 219

					Console.Write ("{0}ssh ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Add a ssh application profile to a personal profile");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
			Console.WriteLine ("Not Yet Implemented");
			}

        } // class _MeshManShell

    public partial class MeshManShell : _MeshManShell {
        } // class MeshManShell

    } // namespace MeshManShell


