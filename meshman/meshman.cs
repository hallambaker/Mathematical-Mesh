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

			Shell Dispatch = new Shell ();


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
						case "device" : {
							Handle_Device (Dispatch, args, 1);
							break;
							}
						case "personal" : {
							Handle_Personal (Dispatch, args, 1);
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
						case "dump" : {
							Handle_Dump (Dispatch, args, 1);
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
						case "password" : {
							Handle_Password (Dispatch, args, 1);
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
					Shell Dispatch, string[] args, int index) {
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
			Next,
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
			Options.Next.Register ("next", Registry, (int) TagType_Personal.Next);
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
					case TagType_Personal.Next : {
						int OptionParams = Options.Next.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Next.Parameter (args[i]);
								}
							}
						break;
						}
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
		private enum TagType_Register {
			UDF,
			Portal,
			Verbose,
			Report,
			}

		private static void Handle_Register (
					Shell Dispatch, string[] args, int index) {
			Register		Options = new Register ();

			var Registry = new Goedel.Registry.Registry ();

			Options.UDF.Register ("udf", Registry, (int) TagType_Register.UDF);
			Options.Portal.Register ("portal", Registry, (int) TagType_Register.Portal);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_Register.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_Register.Report);

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
					case TagType_Register.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Register.Report : {
						int OptionParams = Options.Report.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Report.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Register (Options);

			}
		private enum TagType_Sync {
			Portal,
			UDF,
			Verbose,
			Report,
			}

		private static void Handle_Sync (
					Shell Dispatch, string[] args, int index) {
			Sync		Options = new Sync ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_Sync.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Sync.UDF);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_Sync.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_Sync.Report);


#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Sync TagType = (TagType_Sync) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Sync.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Sync.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Sync.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Sync.Report : {
						int OptionParams = Options.Report.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Report.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Sync (Options);

			}
		private enum TagType_Escrow {
			Quorum,
			Shares,
			Portal,
			UDF,
			Verbose,
			Report,
			}

		private static void Handle_Escrow (
					Shell Dispatch, string[] args, int index) {
			Escrow		Options = new Escrow ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Quorum.Register ("quorum", Registry, (int) TagType_Escrow.Quorum);
			Options.Shares.Register ("shares", Registry, (int) TagType_Escrow.Shares);
			Options.Portal.Register ("portal", Registry, (int) TagType_Escrow.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Escrow.UDF);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_Escrow.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_Escrow.Report);


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
					case TagType_Escrow.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Escrow.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Escrow.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Escrow.Report : {
						int OptionParams = Options.Report.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Report.Parameter (args[i]);
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
			Verbose,
			Report,
			}

		private static void Handle_Export (
					Shell Dispatch, string[] args, int index) {
			Export		Options = new Export ();

			var Registry = new Goedel.Registry.Registry ();

			Options.File.Register ("file", Registry, (int) TagType_Export.File);
			Options.Portal.Register ("portal", Registry, (int) TagType_Export.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Export.UDF);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_Export.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_Export.Report);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.File.Parameter (args [index]);
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
					case TagType_Export.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Export.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Export.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Export.Report : {
						int OptionParams = Options.Report.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Report.Parameter (args[i]);
								}
							}
						break;
						}
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
			Verbose,
			Report,
			}

		private static void Handle_Import (
					Shell Dispatch, string[] args, int index) {
			Import		Options = new Import ();

			var Registry = new Goedel.Registry.Registry ();

			Options.File.Register ("file", Registry, (int) TagType_Import.File);
			Options.Portal.Register ("portal", Registry, (int) TagType_Import.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Import.UDF);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_Import.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_Import.Report);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.File.Parameter (args [index]);
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
					case TagType_Import.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Import.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Import.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Import.Report : {
						int OptionParams = Options.Report.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Report.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Import (Options);

			}
		private enum TagType_List {
			Verbose,
			Report,
			}

		private static void Handle_List (
					Shell Dispatch, string[] args, int index) {
			List		Options = new List ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Verbose.Register ("verbose", Registry, (int) TagType_List.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_List.Report);


#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_List TagType = (TagType_List) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_List.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_List.Report : {
						int OptionParams = Options.Report.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Report.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.List (Options);

			}
		private enum TagType_Dump {
			Portal,
			UDF,
			Verbose,
			Report,
			}

		private static void Handle_Dump (
					Shell Dispatch, string[] args, int index) {
			Dump		Options = new Dump ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_Dump.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Dump.UDF);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_Dump.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_Dump.Report);


#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Dump TagType = (TagType_Dump) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Dump.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Dump.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Dump.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Dump.Report : {
						int OptionParams = Options.Report.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Report.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Dump (Options);

			}
		private enum TagType_Pending {
			Portal,
			UDF,
			Verbose,
			Report,
			}

		private static void Handle_Pending (
					Shell Dispatch, string[] args, int index) {
			Pending		Options = new Pending ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_Pending.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Pending.UDF);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_Pending.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_Pending.Report);


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
					case TagType_Pending.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Pending.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Pending.Report : {
						int OptionParams = Options.Report.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Report.Parameter (args[i]);
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
			Portal,
			PIN,
			Verbose,
			Report,
			DeviceNew,
			DeviceUDF,
			DeviceID,
			DeviceDescription,
			}

		private static void Handle_Connect (
					Shell Dispatch, string[] args, int index) {
			Connect		Options = new Connect ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_Connect.Portal);
			Options.PIN.Register ("pin", Registry, (int) TagType_Connect.PIN);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_Connect.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_Connect.Report);
			Options.DeviceNew.Register ("new", Registry, (int) TagType_Connect.DeviceNew);
			Options.DeviceUDF.Register ("dudf", Registry, (int) TagType_Connect.DeviceUDF);
			Options.DeviceID.Register ("did", Registry, (int) TagType_Connect.DeviceID);
			Options.DeviceDescription.Register ("dd", Registry, (int) TagType_Connect.DeviceDescription);

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

				TagType_Connect TagType = (TagType_Connect) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
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
					case TagType_Connect.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Connect.Report : {
						int OptionParams = Options.Report.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Report.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Connect.DeviceNew : {
						int OptionParams = Options.DeviceNew.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.DeviceNew.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Connect.DeviceUDF : {
						int OptionParams = Options.DeviceUDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.DeviceUDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Connect.DeviceID : {
						int OptionParams = Options.DeviceID.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.DeviceID.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Connect.DeviceDescription : {
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
			Dispatch.Connect (Options);

			}
		private enum TagType_Accept {
			DeviceUDF,
			Verbose,
			Report,
			Portal,
			UDF,
			}

		private static void Handle_Accept (
					Shell Dispatch, string[] args, int index) {
			Accept		Options = new Accept ();

			var Registry = new Goedel.Registry.Registry ();

			Options.DeviceUDF.Register ("udf", Registry, (int) TagType_Accept.DeviceUDF);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_Accept.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_Accept.Report);
			Options.Portal.Register ("portal", Registry, (int) TagType_Accept.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Accept.UDF);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.DeviceUDF.Parameter (args [index]);
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
					case TagType_Accept.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Accept.Report : {
						int OptionParams = Options.Report.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Report.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Accept.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Accept.UDF : {
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
			Dispatch.Accept (Options);

			}
		private enum TagType_Complete {
			Verbose,
			Report,
			Portal,
			UDF,
			}

		private static void Handle_Complete (
					Shell Dispatch, string[] args, int index) {
			Complete		Options = new Complete ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Verbose.Register ("verbose", Registry, (int) TagType_Complete.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_Complete.Report);
			Options.Portal.Register ("portal", Registry, (int) TagType_Complete.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Complete.UDF);


#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Complete TagType = (TagType_Complete) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Complete.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Complete.Report : {
						int OptionParams = Options.Report.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Report.Parameter (args[i]);
								}
							}
						break;
						}
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
					case TagType_Complete.UDF : {
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
			Dispatch.Complete (Options);

			}
		private enum TagType_Password {
			Portal,
			UDF,
			Verbose,
			Report,
			}

		private static void Handle_Password (
					Shell Dispatch, string[] args, int index) {
			Password		Options = new Password ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_Password.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Password.UDF);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_Password.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_Password.Report);


#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Password TagType = (TagType_Password) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Password.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Password.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Password.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Password.Report : {
						int OptionParams = Options.Report.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Report.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new System.Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Password (Options);

			}
		private enum TagType_AddPassword {
			Site,
			Username,
			Password,
			Portal,
			UDF,
			Verbose,
			Report,
			}

		private static void Handle_AddPassword (
					Shell Dispatch, string[] args, int index) {
			AddPassword		Options = new AddPassword ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Site.Register ("site", Registry, (int) TagType_AddPassword.Site);
			Options.Username.Register ("user", Registry, (int) TagType_AddPassword.Username);
			Options.Password.Register ("password", Registry, (int) TagType_AddPassword.Password);
			Options.Portal.Register ("portal", Registry, (int) TagType_AddPassword.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_AddPassword.UDF);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_AddPassword.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_AddPassword.Report);

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
					case TagType_AddPassword.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_AddPassword.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_AddPassword.Report : {
						int OptionParams = Options.Report.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Report.Parameter (args[i]);
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
			Verbose,
			Report,
			}

		private static void Handle_GetPassword (
					Shell Dispatch, string[] args, int index) {
			GetPassword		Options = new GetPassword ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Site.Register ("site", Registry, (int) TagType_GetPassword.Site);
			Options.Portal.Register ("portal", Registry, (int) TagType_GetPassword.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_GetPassword.UDF);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_GetPassword.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_GetPassword.Report);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Site.Parameter (args [index]);
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
					case TagType_GetPassword.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_GetPassword.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_GetPassword.Report : {
						int OptionParams = Options.Report.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Report.Parameter (args[i]);
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
			Verbose,
			Report,
			}

		private static void Handle_DeletePassword (
					Shell Dispatch, string[] args, int index) {
			DeletePassword		Options = new DeletePassword ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Site.Register ("site", Registry, (int) TagType_DeletePassword.Site);
			Options.Portal.Register ("portal", Registry, (int) TagType_DeletePassword.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_DeletePassword.UDF);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_DeletePassword.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_DeletePassword.Report);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Site.Parameter (args [index]);
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
					case TagType_DeletePassword.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_DeletePassword.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_DeletePassword.Report : {
						int OptionParams = Options.Report.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Report.Parameter (args[i]);
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
			Verbose,
			Report,
			}

		private static void Handle_Mail (
					Shell Dispatch, string[] args, int index) {
			Mail		Options = new Mail ();

			var Registry = new Goedel.Registry.Registry ();

			Options.address.Register ("address", Registry, (int) TagType_Mail.address);
			Options.Portal.Register ("portal", Registry, (int) TagType_Mail.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Mail.UDF);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_Mail.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_Mail.Report);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.address.Parameter (args [index]);
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
					case TagType_Mail.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Mail.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Mail.Report : {
						int OptionParams = Options.Report.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Report.Parameter (args[i]);
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
			Verbose,
			Report,
			}

		private static void Handle_SSH (
					Shell Dispatch, string[] args, int index) {
			SSH		Options = new SSH ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_SSH.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_SSH.UDF);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_SSH.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_SSH.Report);


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
					case TagType_SSH.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_SSH.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_SSH.Report : {
						int OptionParams = Options.Report.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Report.Parameter (args[i]);
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
					Console.Write ("[{0}] ", Dummy.Next.Usage ("next", "value", UsageFlag));
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
					Register		Dummy = new Register ();
#pragma warning restore 219

					Console.Write ("{0}register ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage (null, "portal", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Register the specified profile at a new portal");

				}

				{
#pragma warning disable 219
					Sync		Dummy = new Sync ();
#pragma warning restore 219

					Console.Write ("{0}sync ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Synchronize local copies of Mesh profiles with the server");

				}

				{
#pragma warning disable 219
					Escrow		Dummy = new Escrow ();
#pragma warning restore 219

					Console.Write ("{0}escrow ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Quorum.Usage ("quorum", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Shares.Usage ("shares", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Create a set of key escrow shares");

				}

				{
#pragma warning disable 219
					Export		Dummy = new Export ();
#pragma warning restore 219

					Console.Write ("{0}export ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.File.Usage (null, "file", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Export the specified profile data to the specified file");

				}

				{
#pragma warning disable 219
					Import		Dummy = new Import ();
#pragma warning restore 219

					Console.Write ("{0}import ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.File.Usage (null, "file", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Import the specified profile data to the specified file");

				}

				{
#pragma warning disable 219
					List		Dummy = new List ();
#pragma warning restore 219

					Console.Write ("{0}list ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    List all profiles on the local machine");

				}

				{
#pragma warning disable 219
					Dump		Dummy = new Dump ();
#pragma warning restore 219

					Console.Write ("{0}dump ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Describe the specified profile");

				}

				{
#pragma warning disable 219
					Pending		Dummy = new Pending ();
#pragma warning restore 219

					Console.Write ("{0}pending ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Get list of pending connection requests");

				}

				{
#pragma warning disable 219
					Connect		Dummy = new Connect ();
#pragma warning restore 219

					Console.Write ("{0}connect ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage (null, "portal", UsageFlag));
					Console.Write ("[{0}] ", Dummy.PIN.Usage ("pin", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.DeviceNew.Usage ("new", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.DeviceUDF.Usage ("dudf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.DeviceID.Usage ("did", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.DeviceDescription.Usage ("dd", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Connect to an existing profile registered at a portal");

				}

				{
#pragma warning disable 219
					Accept		Dummy = new Accept ();
#pragma warning restore 219

					Console.Write ("{0}accept ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.DeviceUDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Accept a pending connection");

				}

				{
#pragma warning disable 219
					Complete		Dummy = new Complete ();
#pragma warning restore 219

					Console.Write ("{0}complete ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Complete a pending connection request");

				}

				{
#pragma warning disable 219
					Password		Dummy = new Password ();
#pragma warning restore 219

					Console.Write ("{0}password ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
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
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Add password entry");

				}

				{
#pragma warning disable 219
					GetPassword		Dummy = new GetPassword ();
#pragma warning restore 219

					Console.Write ("{0}pwg ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Site.Usage (null, "site", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Lookup password entry");

				}

				{
#pragma warning disable 219
					DeletePassword		Dummy = new DeletePassword ();
#pragma warning restore 219

					Console.Write ("{0}pwd ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Site.Usage (null, "site", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Delete password entry");

				}

				{
#pragma warning disable 219
					Mail		Dummy = new Mail ();
#pragma warning restore 219

					Console.Write ("{0}mail ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.address.Usage (null, "address", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Add a mail application profile to a personal profile");

				}

				{
#pragma warning disable 219
					SSH		Dummy = new SSH ();
#pragma warning restore 219

					Console.Write ("{0}ssh ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
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

		public Flag			Next = new  Flag ();

		public Flag			Verbose = new  Flag ("true");

		public Flag			Report = new  Flag ("true");

		public Flag			DeviceNew = new  Flag ();

		public String			DeviceUDF = new  String ();

		public String			DeviceID = new  String ();

		public String			DeviceDescription = new  String ();


		}

    public partial class Personal : _Personal {
        } // class Personal


    public class _Register : Goedel.Registry.Dispatch {
		public String			UDF = new String ();
		public String			Portal = new String ();

		public Flag			Verbose = new  Flag ("true");

		public Flag			Report = new  Flag ("true");


		}

    public partial class Register : _Register {
        } // class Register


    public class _Sync : Goedel.Registry.Dispatch {

		public String			Portal = new  String ();

		public String			UDF = new  String ();

		public Flag			Verbose = new  Flag ("true");

		public Flag			Report = new  Flag ("true");


		}

    public partial class Sync : _Sync {
        } // class Sync


    public class _Escrow : Goedel.Registry.Dispatch {

		public integer			Quorum = new  integer ();

		public integer			Shares = new  integer ();

		public String			Portal = new  String ();

		public String			UDF = new  String ();

		public Flag			Verbose = new  Flag ("true");

		public Flag			Report = new  Flag ("true");


		}

    public partial class Escrow : _Escrow {
        } // class Escrow


    public class _Export : Goedel.Registry.Dispatch {
		public NewFile			File = new NewFile ();

		public String			Portal = new  String ();

		public String			UDF = new  String ();

		public Flag			Verbose = new  Flag ("true");

		public Flag			Report = new  Flag ("true");


		}

    public partial class Export : _Export {
        } // class Export


    public class _Import : Goedel.Registry.Dispatch {
		public NewFile			File = new NewFile ();

		public String			Portal = new  String ();

		public String			UDF = new  String ();

		public Flag			Verbose = new  Flag ("true");

		public Flag			Report = new  Flag ("true");


		}

    public partial class Import : _Import {
        } // class Import


    public class _List : Goedel.Registry.Dispatch {

		public Flag			Verbose = new  Flag ("true");

		public Flag			Report = new  Flag ("true");


		}

    public partial class List : _List {
        } // class List


    public class _Dump : Goedel.Registry.Dispatch {

		public String			Portal = new  String ();

		public String			UDF = new  String ();

		public Flag			Verbose = new  Flag ("true");

		public Flag			Report = new  Flag ("true");


		}

    public partial class Dump : _Dump {
        } // class Dump


    public class _Pending : Goedel.Registry.Dispatch {

		public String			Portal = new  String ();

		public String			UDF = new  String ();

		public Flag			Verbose = new  Flag ("true");

		public Flag			Report = new  Flag ("true");


		}

    public partial class Pending : _Pending {
        } // class Pending


    public class _Connect : Goedel.Registry.Dispatch {
		public String			Portal = new String ();

		public String			PIN = new  String ();

		public Flag			Verbose = new  Flag ("true");

		public Flag			Report = new  Flag ("true");

		public Flag			DeviceNew = new  Flag ();

		public String			DeviceUDF = new  String ();

		public String			DeviceID = new  String ();

		public String			DeviceDescription = new  String ();


		}

    public partial class Connect : _Connect {
        } // class Connect


    public class _Accept : Goedel.Registry.Dispatch {
		public String			DeviceUDF = new String ();

		public Flag			Verbose = new  Flag ("true");

		public Flag			Report = new  Flag ("true");

		public String			Portal = new  String ();

		public String			UDF = new  String ();


		}

    public partial class Accept : _Accept {
        } // class Accept


    public class _Complete : Goedel.Registry.Dispatch {

		public Flag			Verbose = new  Flag ("true");

		public Flag			Report = new  Flag ("true");

		public String			Portal = new  String ();

		public String			UDF = new  String ();


		}

    public partial class Complete : _Complete {
        } // class Complete


    public class _Password : Goedel.Registry.Dispatch {

		public String			Portal = new  String ();

		public String			UDF = new  String ();

		public Flag			Verbose = new  Flag ("true");

		public Flag			Report = new  Flag ("true");


		}

    public partial class Password : _Password {
        } // class Password


    public class _AddPassword : Goedel.Registry.Dispatch {
		public String			Site = new String ();
		public String			Username = new String ();
		public String			Password = new String ();

		public String			Portal = new  String ();

		public String			UDF = new  String ();

		public Flag			Verbose = new  Flag ("true");

		public Flag			Report = new  Flag ("true");


		}

    public partial class AddPassword : _AddPassword {
        } // class AddPassword


    public class _GetPassword : Goedel.Registry.Dispatch {
		public String			Site = new String ();

		public String			Portal = new  String ();

		public String			UDF = new  String ();

		public Flag			Verbose = new  Flag ("true");

		public Flag			Report = new  Flag ("true");


		}

    public partial class GetPassword : _GetPassword {
        } // class GetPassword


    public class _DeletePassword : Goedel.Registry.Dispatch {
		public String			Site = new String ();

		public String			Portal = new  String ();

		public String			UDF = new  String ();

		public Flag			Verbose = new  Flag ("true");

		public Flag			Report = new  Flag ("true");


		}

    public partial class DeletePassword : _DeletePassword {
        } // class DeletePassword


    public class _Mail : Goedel.Registry.Dispatch {
		public String			address = new String ();

		public String			Portal = new  String ();

		public String			UDF = new  String ();

		public Flag			Verbose = new  Flag ("true");

		public Flag			Report = new  Flag ("true");


		}

    public partial class Mail : _Mail {
        } // class Mail


    public class _SSH : Goedel.Registry.Dispatch {

		public String			Portal = new  String ();

		public String			UDF = new  String ();

		public Flag			Verbose = new  Flag ("true");

		public Flag			Report = new  Flag ("true");


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




	// The stub class just contains routines that echo their arguments and
	// write 'not yet implemented'

	// Eventually there will be a compiler option to suppress the debugging
	// to eliminate the redundant code
    public class _Shell {


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
					Console.Write ("[{0}] ", Dummy.Next.Usage ("next", "value", UsageFlag));
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
							"Next", Options.Next);
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
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Register the specified profile at a new portal");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
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
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Synchronize local copies of Mesh profiles with the server");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
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
					Console.Write ("[{0}] ", Dummy.Quorum.Usage ("quorum", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Shares.Usage ("shares", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Create a set of key escrow shares");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "integer", 
							"Quorum", Options.Quorum);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "integer", 
							"Shares", Options.Shares);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
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
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Export the specified profile data to the specified file");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "NewFile", 
							"File", Options.File);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
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
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Import the specified profile data to the specified file");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "NewFile", 
							"File", Options.File);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
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
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    List all profiles on the local machine");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Dump ( Dump Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Dump		Dummy = new Dump ();
#pragma warning restore 219

					Console.Write ("{0}dump ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Describe the specified profile");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
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
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Get list of pending connection requests");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
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
					Console.Write ("[{0}] ", Dummy.Portal.Usage (null, "portal", UsageFlag));
					Console.Write ("[{0}] ", Dummy.PIN.Usage ("pin", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.DeviceNew.Usage ("new", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.DeviceUDF.Usage ("dudf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.DeviceID.Usage ("did", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.DeviceDescription.Usage ("dd", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Connect to an existing profile registered at a portal");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"PIN", Options.PIN);
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
		public virtual void Accept ( Accept Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Accept		Dummy = new Accept ();
#pragma warning restore 219

					Console.Write ("{0}accept ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.DeviceUDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Accept a pending connection");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"DeviceUDF", Options.DeviceUDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
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
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Complete a pending connection request");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Password ( Password Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Password		Dummy = new Password ();
#pragma warning restore 219

					Console.Write ("{0}password ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Add a web application profile to a personal profile");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
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
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Add password entry");

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
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
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
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Lookup password entry");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Site", Options.Site);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
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
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Delete password entry");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Site", Options.Site);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
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
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Add a mail application profile to a personal profile");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"address", Options.address);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
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
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Add a ssh application profile to a personal profile");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
			Console.WriteLine ("Not Yet Implemented");
			}

        } // class _Shell

    public partial class Shell : _Shell {
        } // class Shell

    } // namespace Shell


