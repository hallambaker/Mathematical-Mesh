using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Registry;

namespace Goedel.Mesh.MeshMan {
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


        public void MainMethod(string[] args) {

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
						case "verify" : {
							Handle_Verify (Dispatch, args, 1);
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
						case "deregister" : {
							Handle_Deregister (Dispatch, args, 1);
							break;
							}
						case "fingerprint" : {
							Handle_Fingerprint (Dispatch, args, 1);
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
						case "pwadd" : {
							Handle_AddPassword (Dispatch, args, 1);
							break;
							}
						case "pwget" : {
							Handle_GetPassword (Dispatch, args, 1);
							break;
							}
						case "pwdelete" : {
							Handle_DeletePassword (Dispatch, args, 1);
							break;
							}
						case "pwdump" : {
							Handle_DumpPassword (Dispatch, args, 1);
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
						case "sshauth" : {
							Handle_SSHAuth (Dispatch, args, 1);
							break;
							}
						case "sshknown" : {
							Handle_SSHKnown (Dispatch, args, 1);
							break;
							}
						case "sshpub" : {
							Handle_SSHPublic (Dispatch, args, 1);
							break;
							}
						case "sshpriv" : {
							Handle_SSHPrivate (Dispatch, args, 1);
							break;
							}
						case "confirm" : {
							Handle_Confirm (Dispatch, args, 1);
							break;
							}
						case "confimpost" : {
							Handle_ConfirmPost (Dispatch, args, 1);
							break;
							}
						case "confimget" : {
							Handle_ConfirmGet (Dispatch, args, 1);
							break;
							}
						case "confimaccept" : {
							Handle_ConfirmAccept (Dispatch, args, 1);
							break;
							}
						case "confimreject" : {
							Handle_ConfirmReject (Dispatch, args, 1);
							break;
							}
						case "recrypt" : {
							Handle_Recrypt (Dispatch, args, 1);
							break;
							}
						case "recryptgroup" : {
							Handle_RecryptGroup (Dispatch, args, 1);
							break;
							}
						case "recryptadd" : {
							Handle_RecryptAdd (Dispatch, args, 1);
							break;
							}
						case "recryptdel" : {
							Handle_RecryptDelete (Dispatch, args, 1);
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
		private enum TagType_Verify {
			Portal,
			Verbose,
			Report,
			}

		private static void Handle_Verify (
					Shell Dispatch, string[] args, int index) {
			Verify		Options = new Verify ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_Verify.Portal);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_Verify.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_Verify.Report);

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

				TagType_Verify TagType = (TagType_Verify) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Verify.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Verify.Report : {
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
			Dispatch.Verify (Options);

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
		private enum TagType_Register {
			Portal,
			UDF,
			Verbose,
			Report,
			}

		private static void Handle_Register (
					Shell Dispatch, string[] args, int index) {
			Register		Options = new Register ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_Register.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Register.UDF);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_Register.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_Register.Report);

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
		private enum TagType_Deregister {
			Portal,
			Verbose,
			Report,
			}

		private static void Handle_Deregister (
					Shell Dispatch, string[] args, int index) {
			Deregister		Options = new Deregister ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_Deregister.Portal);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_Deregister.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_Deregister.Report);

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

				TagType_Deregister TagType = (TagType_Deregister) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Deregister.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Deregister.Report : {
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
			Dispatch.Deregister (Options);

			}
		private enum TagType_Fingerprint {
			DeviceID,
			Portal,
			UDF,
			Verbose,
			Report,
			}

		private static void Handle_Fingerprint (
					Shell Dispatch, string[] args, int index) {
			Fingerprint		Options = new Fingerprint ();

			var Registry = new Goedel.Registry.Registry ();

			Options.DeviceID.Register ("did", Registry, (int) TagType_Fingerprint.DeviceID);
			Options.Portal.Register ("portal", Registry, (int) TagType_Fingerprint.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Fingerprint.UDF);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_Fingerprint.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_Fingerprint.Report);


#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Fingerprint TagType = (TagType_Fingerprint) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Fingerprint.DeviceID : {
						int OptionParams = Options.DeviceID.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.DeviceID.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Fingerprint.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Fingerprint.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Fingerprint.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Fingerprint.Report : {
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
			Dispatch.Fingerprint (Options);

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
			File,
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
			Options.File.Register ("file", Registry, (int) TagType_Escrow.File);
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
					case TagType_Escrow.File : {
						int OptionParams = Options.File.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.File.Parameter (args[i]);
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
			ID,
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
			Options.ID.Register ("id", Registry, (int) TagType_AddPassword.ID);
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
					case TagType_AddPassword.ID : {
						int OptionParams = Options.ID.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.ID.Parameter (args[i]);
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
			ID,
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
			Options.ID.Register ("id", Registry, (int) TagType_GetPassword.ID);
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
					case TagType_GetPassword.ID : {
						int OptionParams = Options.ID.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.ID.Parameter (args[i]);
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
			ID,
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
			Options.ID.Register ("id", Registry, (int) TagType_DeletePassword.ID);
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
					case TagType_DeletePassword.ID : {
						int OptionParams = Options.ID.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.ID.Parameter (args[i]);
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
		private enum TagType_DumpPassword {
			JSON,
			Portal,
			UDF,
			ID,
			Verbose,
			Report,
			}

		private static void Handle_DumpPassword (
					Shell Dispatch, string[] args, int index) {
			DumpPassword		Options = new DumpPassword ();

			var Registry = new Goedel.Registry.Registry ();

			Options.JSON.Register ("json", Registry, (int) TagType_DumpPassword.JSON);
			Options.Portal.Register ("portal", Registry, (int) TagType_DumpPassword.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_DumpPassword.UDF);
			Options.ID.Register ("id", Registry, (int) TagType_DumpPassword.ID);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_DumpPassword.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_DumpPassword.Report);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.JSON.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_DumpPassword TagType = (TagType_DumpPassword) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_DumpPassword.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_DumpPassword.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_DumpPassword.ID : {
						int OptionParams = Options.ID.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.ID.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_DumpPassword.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_DumpPassword.Report : {
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
			Dispatch.DumpPassword (Options);

			}
		private enum TagType_Mail {
			Address,
			CA,
			Portal,
			UDF,
			Verbose,
			Report,
			}

		private static void Handle_Mail (
					Shell Dispatch, string[] args, int index) {
			Mail		Options = new Mail ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Address.Register ("address", Registry, (int) TagType_Mail.Address);
			Options.CA.Register ("ca", Registry, (int) TagType_Mail.CA);
			Options.Portal.Register ("portal", Registry, (int) TagType_Mail.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Mail.UDF);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_Mail.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_Mail.Report);

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

				TagType_Mail TagType = (TagType_Mail) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Mail.CA : {
						int OptionParams = Options.CA.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.CA.Parameter (args[i]);
								}
							}
						break;
						}
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
			Host,
			Client,
			Portal,
			UDF,
			Verbose,
			Report,
			}

		private static void Handle_SSH (
					Shell Dispatch, string[] args, int index) {
			SSH		Options = new SSH ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Host.Register ("host", Registry, (int) TagType_SSH.Host);
			Options.Client.Register ("client", Registry, (int) TagType_SSH.Client);
			Options.Portal.Register ("portal", Registry, (int) TagType_SSH.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_SSH.UDF);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_SSH.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_SSH.Report);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Host.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Client.Parameter (args [index]);
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
		private enum TagType_SSHAuth {
			Host,
			Client,
			Portal,
			UDF,
			ID,
			Verbose,
			Report,
			}

		private static void Handle_SSHAuth (
					Shell Dispatch, string[] args, int index) {
			SSHAuth		Options = new SSHAuth ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Host.Register ("host", Registry, (int) TagType_SSHAuth.Host);
			Options.Client.Register ("client", Registry, (int) TagType_SSHAuth.Client);
			Options.Portal.Register ("portal", Registry, (int) TagType_SSHAuth.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_SSHAuth.UDF);
			Options.ID.Register ("id", Registry, (int) TagType_SSHAuth.ID);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_SSHAuth.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_SSHAuth.Report);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Host.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Client.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_SSHAuth TagType = (TagType_SSHAuth) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_SSHAuth.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_SSHAuth.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_SSHAuth.ID : {
						int OptionParams = Options.ID.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.ID.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_SSHAuth.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_SSHAuth.Report : {
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
			Dispatch.SSHAuth (Options);

			}
		private enum TagType_SSHKnown {
			Host,
			Client,
			Portal,
			UDF,
			ID,
			Verbose,
			Report,
			}

		private static void Handle_SSHKnown (
					Shell Dispatch, string[] args, int index) {
			SSHKnown		Options = new SSHKnown ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Host.Register ("host", Registry, (int) TagType_SSHKnown.Host);
			Options.Client.Register ("client", Registry, (int) TagType_SSHKnown.Client);
			Options.Portal.Register ("portal", Registry, (int) TagType_SSHKnown.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_SSHKnown.UDF);
			Options.ID.Register ("id", Registry, (int) TagType_SSHKnown.ID);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_SSHKnown.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_SSHKnown.Report);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Host.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Client.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_SSHKnown TagType = (TagType_SSHKnown) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_SSHKnown.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_SSHKnown.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_SSHKnown.ID : {
						int OptionParams = Options.ID.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.ID.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_SSHKnown.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_SSHKnown.Report : {
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
			Dispatch.SSHKnown (Options);

			}
		private enum TagType_SSHPublic {
			Host,
			Client,
			Portal,
			UDF,
			ID,
			Verbose,
			Report,
			}

		private static void Handle_SSHPublic (
					Shell Dispatch, string[] args, int index) {
			SSHPublic		Options = new SSHPublic ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Host.Register ("host", Registry, (int) TagType_SSHPublic.Host);
			Options.Client.Register ("client", Registry, (int) TagType_SSHPublic.Client);
			Options.Portal.Register ("portal", Registry, (int) TagType_SSHPublic.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_SSHPublic.UDF);
			Options.ID.Register ("id", Registry, (int) TagType_SSHPublic.ID);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_SSHPublic.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_SSHPublic.Report);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Host.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Client.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_SSHPublic TagType = (TagType_SSHPublic) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_SSHPublic.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_SSHPublic.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_SSHPublic.ID : {
						int OptionParams = Options.ID.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.ID.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_SSHPublic.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_SSHPublic.Report : {
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
			Dispatch.SSHPublic (Options);

			}
		private enum TagType_SSHPrivate {
			Host,
			Client,
			Portal,
			UDF,
			ID,
			Verbose,
			Report,
			}

		private static void Handle_SSHPrivate (
					Shell Dispatch, string[] args, int index) {
			SSHPrivate		Options = new SSHPrivate ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Host.Register ("host", Registry, (int) TagType_SSHPrivate.Host);
			Options.Client.Register ("client", Registry, (int) TagType_SSHPrivate.Client);
			Options.Portal.Register ("portal", Registry, (int) TagType_SSHPrivate.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_SSHPrivate.UDF);
			Options.ID.Register ("id", Registry, (int) TagType_SSHPrivate.ID);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_SSHPrivate.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_SSHPrivate.Report);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Host.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Client.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_SSHPrivate TagType = (TagType_SSHPrivate) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_SSHPrivate.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_SSHPrivate.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_SSHPrivate.ID : {
						int OptionParams = Options.ID.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.ID.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_SSHPrivate.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_SSHPrivate.Report : {
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
			Dispatch.SSHPrivate (Options);

			}
		private enum TagType_Confirm {
			Address,
			PIN,
			Portal,
			UDF,
			Verbose,
			Report,
			}

		private static void Handle_Confirm (
					Shell Dispatch, string[] args, int index) {
			Confirm		Options = new Confirm ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Address.Register ("address", Registry, (int) TagType_Confirm.Address);
			Options.PIN.Register ("pin", Registry, (int) TagType_Confirm.PIN);
			Options.Portal.Register ("portal", Registry, (int) TagType_Confirm.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Confirm.UDF);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_Confirm.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_Confirm.Report);

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

				TagType_Confirm TagType = (TagType_Confirm) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Confirm.PIN : {
						int OptionParams = Options.PIN.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.PIN.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Confirm.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Confirm.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Confirm.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Confirm.Report : {
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
			Dispatch.Confirm (Options);

			}
		private enum TagType_ConfirmPost {
			Portal,
			UDF,
			ID,
			Verbose,
			Report,
			}

		private static void Handle_ConfirmPost (
					Shell Dispatch, string[] args, int index) {
			ConfirmPost		Options = new ConfirmPost ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_ConfirmPost.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_ConfirmPost.UDF);
			Options.ID.Register ("id", Registry, (int) TagType_ConfirmPost.ID);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_ConfirmPost.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_ConfirmPost.Report);


#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_ConfirmPost TagType = (TagType_ConfirmPost) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_ConfirmPost.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_ConfirmPost.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_ConfirmPost.ID : {
						int OptionParams = Options.ID.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.ID.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_ConfirmPost.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_ConfirmPost.Report : {
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
			Dispatch.ConfirmPost (Options);

			}
		private enum TagType_ConfirmGet {
			Portal,
			UDF,
			ID,
			Verbose,
			Report,
			}

		private static void Handle_ConfirmGet (
					Shell Dispatch, string[] args, int index) {
			ConfirmGet		Options = new ConfirmGet ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_ConfirmGet.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_ConfirmGet.UDF);
			Options.ID.Register ("id", Registry, (int) TagType_ConfirmGet.ID);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_ConfirmGet.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_ConfirmGet.Report);


#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_ConfirmGet TagType = (TagType_ConfirmGet) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_ConfirmGet.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_ConfirmGet.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_ConfirmGet.ID : {
						int OptionParams = Options.ID.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.ID.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_ConfirmGet.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_ConfirmGet.Report : {
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
			Dispatch.ConfirmGet (Options);

			}
		private enum TagType_ConfirmAccept {
			Portal,
			UDF,
			ID,
			Verbose,
			Report,
			}

		private static void Handle_ConfirmAccept (
					Shell Dispatch, string[] args, int index) {
			ConfirmAccept		Options = new ConfirmAccept ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_ConfirmAccept.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_ConfirmAccept.UDF);
			Options.ID.Register ("id", Registry, (int) TagType_ConfirmAccept.ID);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_ConfirmAccept.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_ConfirmAccept.Report);


#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_ConfirmAccept TagType = (TagType_ConfirmAccept) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_ConfirmAccept.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_ConfirmAccept.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_ConfirmAccept.ID : {
						int OptionParams = Options.ID.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.ID.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_ConfirmAccept.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_ConfirmAccept.Report : {
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
			Dispatch.ConfirmAccept (Options);

			}
		private enum TagType_ConfirmReject {
			Portal,
			UDF,
			ID,
			Verbose,
			Report,
			}

		private static void Handle_ConfirmReject (
					Shell Dispatch, string[] args, int index) {
			ConfirmReject		Options = new ConfirmReject ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_ConfirmReject.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_ConfirmReject.UDF);
			Options.ID.Register ("id", Registry, (int) TagType_ConfirmReject.ID);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_ConfirmReject.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_ConfirmReject.Report);


#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_ConfirmReject TagType = (TagType_ConfirmReject) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_ConfirmReject.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_ConfirmReject.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_ConfirmReject.ID : {
						int OptionParams = Options.ID.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.ID.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_ConfirmReject.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_ConfirmReject.Report : {
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
			Dispatch.ConfirmReject (Options);

			}
		private enum TagType_Recrypt {
			Address,
			PIN,
			Portal,
			UDF,
			Verbose,
			Report,
			}

		private static void Handle_Recrypt (
					Shell Dispatch, string[] args, int index) {
			Recrypt		Options = new Recrypt ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Address.Register ("address", Registry, (int) TagType_Recrypt.Address);
			Options.PIN.Register ("pin", Registry, (int) TagType_Recrypt.PIN);
			Options.Portal.Register ("portal", Registry, (int) TagType_Recrypt.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Recrypt.UDF);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_Recrypt.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_Recrypt.Report);

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

				TagType_Recrypt TagType = (TagType_Recrypt) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Recrypt.PIN : {
						int OptionParams = Options.PIN.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.PIN.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Recrypt.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Recrypt.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Recrypt.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Recrypt.Report : {
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
			Dispatch.Recrypt (Options);

			}
		private enum TagType_RecryptGroup {
			Portal,
			UDF,
			ID,
			Verbose,
			Report,
			}

		private static void Handle_RecryptGroup (
					Shell Dispatch, string[] args, int index) {
			RecryptGroup		Options = new RecryptGroup ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_RecryptGroup.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_RecryptGroup.UDF);
			Options.ID.Register ("id", Registry, (int) TagType_RecryptGroup.ID);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_RecryptGroup.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_RecryptGroup.Report);


#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_RecryptGroup TagType = (TagType_RecryptGroup) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_RecryptGroup.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_RecryptGroup.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_RecryptGroup.ID : {
						int OptionParams = Options.ID.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.ID.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_RecryptGroup.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_RecryptGroup.Report : {
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
			Dispatch.RecryptGroup (Options);

			}
		private enum TagType_RecryptAdd {
			Portal,
			UDF,
			ID,
			Verbose,
			Report,
			}

		private static void Handle_RecryptAdd (
					Shell Dispatch, string[] args, int index) {
			RecryptAdd		Options = new RecryptAdd ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_RecryptAdd.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_RecryptAdd.UDF);
			Options.ID.Register ("id", Registry, (int) TagType_RecryptAdd.ID);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_RecryptAdd.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_RecryptAdd.Report);


#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_RecryptAdd TagType = (TagType_RecryptAdd) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_RecryptAdd.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_RecryptAdd.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_RecryptAdd.ID : {
						int OptionParams = Options.ID.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.ID.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_RecryptAdd.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_RecryptAdd.Report : {
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
			Dispatch.RecryptAdd (Options);

			}
		private enum TagType_RecryptDelete {
			Portal,
			UDF,
			ID,
			Verbose,
			Report,
			}

		private static void Handle_RecryptDelete (
					Shell Dispatch, string[] args, int index) {
			RecryptDelete		Options = new RecryptDelete ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_RecryptDelete.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_RecryptDelete.UDF);
			Options.ID.Register ("id", Registry, (int) TagType_RecryptDelete.ID);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_RecryptDelete.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_RecryptDelete.Report);


#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_RecryptDelete TagType = (TagType_RecryptDelete) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_RecryptDelete.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_RecryptDelete.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_RecryptDelete.ID : {
						int OptionParams = Options.ID.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.ID.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_RecryptDelete.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_RecryptDelete.Report : {
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
			Dispatch.RecryptDelete (Options);

			}
		private enum TagType_Encrypt {
			Portal,
			UDF,
			ID,
			Verbose,
			Report,
			}

		private static void Handle_Encrypt (
					Shell Dispatch, string[] args, int index) {
			Encrypt		Options = new Encrypt ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_Encrypt.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Encrypt.UDF);
			Options.ID.Register ("id", Registry, (int) TagType_Encrypt.ID);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_Encrypt.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_Encrypt.Report);


#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Encrypt TagType = (TagType_Encrypt) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Encrypt.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Encrypt.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Encrypt.ID : {
						int OptionParams = Options.ID.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.ID.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Encrypt.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Encrypt.Report : {
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
			Dispatch.Encrypt (Options);

			}
		private enum TagType_Decrypt {
			Portal,
			UDF,
			ID,
			Verbose,
			Report,
			}

		private static void Handle_Decrypt (
					Shell Dispatch, string[] args, int index) {
			Decrypt		Options = new Decrypt ();

			var Registry = new Goedel.Registry.Registry ();

			Options.Portal.Register ("portal", Registry, (int) TagType_Decrypt.Portal);
			Options.UDF.Register ("udf", Registry, (int) TagType_Decrypt.UDF);
			Options.ID.Register ("id", Registry, (int) TagType_Decrypt.ID);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_Decrypt.Verbose);
			Options.Report.Register ("report", Registry, (int) TagType_Decrypt.Report);


#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new System.Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Decrypt TagType = (TagType_Decrypt) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Decrypt.Portal : {
						int OptionParams = Options.Portal.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Portal.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Decrypt.UDF : {
						int OptionParams = Options.UDF.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.UDF.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Decrypt.ID : {
						int OptionParams = Options.ID.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.ID.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Decrypt.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Decrypt.Report : {
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
					Verify		Dummy = new Verify ();
#pragma warning restore 219

					Console.Write ("{0}verify ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage (null, "portal", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Verify requested portal address");

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
					Register		Dummy = new Register ();
#pragma warning restore 219

					Console.Write ("{0}register ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage (null, "portal", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Register the specified profile at a new portal");

				}

				{
#pragma warning disable 219
					Deregister		Dummy = new Deregister ();
#pragma warning restore 219

					Console.Write ("{0}deregister ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage (null, "portal", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Deregister the specified profile at a portal");

				}

				{
#pragma warning disable 219
					Fingerprint		Dummy = new Fingerprint ();
#pragma warning restore 219

					Console.Write ("{0}fingerprint ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.DeviceID.Usage ("did", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Return the fingerprint of a Mesh profile");

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
					Console.Write ("[{0}] ", Dummy.File.Usage ("file", "value", UsageFlag));
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

					Console.Write ("{0}pwadd ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Site.Usage (null, "site", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Username.Usage (null, "user", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Password.Usage (null, "password", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Add password entry");

				}

				{
#pragma warning disable 219
					GetPassword		Dummy = new GetPassword ();
#pragma warning restore 219

					Console.Write ("{0}pwget ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Site.Usage (null, "site", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Lookup password entry");

				}

				{
#pragma warning disable 219
					DeletePassword		Dummy = new DeletePassword ();
#pragma warning restore 219

					Console.Write ("{0}pwdelete ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Site.Usage (null, "site", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Delete password entry");

				}

				{
#pragma warning disable 219
					DumpPassword		Dummy = new DumpPassword ();
#pragma warning restore 219

					Console.Write ("{0}pwdump ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.JSON.Usage (null, "json", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Describe password entry");

				}

				{
#pragma warning disable 219
					Mail		Dummy = new Mail ();
#pragma warning restore 219

					Console.Write ("{0}mail ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Address.Usage (null, "address", UsageFlag));
					Console.Write ("[{0}] ", Dummy.CA.Usage ("ca", "value", UsageFlag));
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
					Console.Write ("[{0}] ", Dummy.Host.Usage (null, "host", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Client.Usage (null, "client", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Add a ssh application profile to a personal profile");

				}

				{
#pragma warning disable 219
					SSHAuth		Dummy = new SSHAuth ();
#pragma warning restore 219

					Console.Write ("{0}sshauth ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Host.Usage (null, "host", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Client.Usage (null, "client", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    List the SSH Authorized keys");

				}

				{
#pragma warning disable 219
					SSHKnown		Dummy = new SSHKnown ();
#pragma warning restore 219

					Console.Write ("{0}sshknown ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Host.Usage (null, "host", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Client.Usage (null, "client", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    List the SSH Known Hosts");

				}

				{
#pragma warning disable 219
					SSHPublic		Dummy = new SSHPublic ();
#pragma warning restore 219

					Console.Write ("{0}sshpub ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Host.Usage (null, "host", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Client.Usage (null, "client", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Return the ssh public key for this device");

				}

				{
#pragma warning disable 219
					SSHPrivate		Dummy = new SSHPrivate ();
#pragma warning restore 219

					Console.Write ("{0}sshpriv ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Host.Usage (null, "host", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Client.Usage (null, "client", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Return the ss private key for this device");

				}

				{
#pragma warning disable 219
					Confirm		Dummy = new Confirm ();
#pragma warning restore 219

					Console.Write ("{0}confirm ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Address.Usage (null, "address", UsageFlag));
					Console.Write ("[{0}] ", Dummy.PIN.Usage ("pin", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Add a confirmation profile account");

				}

				{
#pragma warning disable 219
					ConfirmPost		Dummy = new ConfirmPost ();
#pragma warning restore 219

					Console.Write ("{0}confimpost ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Post a confirmation request to an account");

				}

				{
#pragma warning disable 219
					ConfirmGet		Dummy = new ConfirmGet ();
#pragma warning restore 219

					Console.Write ("{0}confimget ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    List the pending confirmation requests for this account");

				}

				{
#pragma warning disable 219
					ConfirmAccept		Dummy = new ConfirmAccept ();
#pragma warning restore 219

					Console.Write ("{0}confimaccept ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Accept a confirmation request");

				}

				{
#pragma warning disable 219
					ConfirmReject		Dummy = new ConfirmReject ();
#pragma warning restore 219

					Console.Write ("{0}confimreject ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Reject a confirmation request");

				}

				{
#pragma warning disable 219
					Recrypt		Dummy = new Recrypt ();
#pragma warning restore 219

					Console.Write ("{0}recrypt ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Address.Usage (null, "address", UsageFlag));
					Console.Write ("[{0}] ", Dummy.PIN.Usage ("pin", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Add a confirmation profile account");

				}

				{
#pragma warning disable 219
					RecryptGroup		Dummy = new RecryptGroup ();
#pragma warning restore 219

					Console.Write ("{0}recryptgroup ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Create a new recryption group");

				}

				{
#pragma warning disable 219
					RecryptAdd		Dummy = new RecryptAdd ();
#pragma warning restore 219

					Console.Write ("{0}recryptadd ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Add a member to a recryption group");

				}

				{
#pragma warning disable 219
					RecryptDelete		Dummy = new RecryptDelete ();
#pragma warning restore 219

					Console.Write ("{0}recryptdel ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Remove a member from a recryption group");

				}

				{
#pragma warning disable 219
					Encrypt		Dummy = new Encrypt ();
#pragma warning restore 219

					Console.Write ("{0}encrypt ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Encrypt a file or directory");

				}

				{
#pragma warning disable 219
					Decrypt		Dummy = new Decrypt ();
#pragma warning restore 219

					Console.Write ("{0}decrypt ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Decrypt a file or directory");

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



	public interface IReporting {
		Flag			Verbose{get; set;}
		Flag			Report{get; set;}
		}


	public interface IPortalAccount {
		String			Portal{get; set;}
		String			UDF{get; set;}
		}


	public interface IApplicationProfile {
		String			Portal{get; set;}
		String			UDF{get; set;}
		String			ID{get; set;}
		}


	public interface IDeviceProfileInfo {
		Flag			DeviceNew{get; set;}
		String			DeviceUDF{get; set;}
		String			DeviceID{get; set;}
		String			DeviceDescription{get; set;}
		}



    public class _Reset : Goedel.Registry.Dispatch  {


		}

    public partial class Reset : _Reset {
        } // class Reset


    public class _Device : Goedel.Registry.Dispatch  {
		public String			DeviceID{get; set;}  = new String ();
		public String			DeviceDescription{get; set;}  = new String ();
		public Flag			Default{get; set;} = new  Flag ();


		}

    public partial class Device : _Device {
        } // class Device


    public class _Verify : Goedel.Registry.Dispatch ,
							IReporting {
		public String			Portal{get; set;}  = new String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class Verify : _Verify {
        } // class Verify


    public class _Personal : Goedel.Registry.Dispatch ,
							IReporting,
							IDeviceProfileInfo {
		public String			Portal{get; set;}  = new String ();
		public String			Description{get; set;}  = new String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");
		public Flag			DeviceNew{get; set;} = new  Flag ();
		public String			DeviceUDF{get; set;} = new  String ();
		public String			DeviceID{get; set;} = new  String ();
		public String			DeviceDescription{get; set;} = new  String ();


		}

    public partial class Personal : _Personal {
        } // class Personal


    public class _Register : Goedel.Registry.Dispatch ,
							IReporting {
		public String			Portal{get; set;}  = new String ();
		public String			UDF{get; set;}  = new String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class Register : _Register {
        } // class Register


    public class _Deregister : Goedel.Registry.Dispatch ,
							IReporting {
		public String			Portal{get; set;}  = new String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class Deregister : _Deregister {
        } // class Deregister


    public class _Fingerprint : Goedel.Registry.Dispatch ,
							IPortalAccount,
							IReporting {
		public String			DeviceID{get; set;} = new  String ();
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class Fingerprint : _Fingerprint {
        } // class Fingerprint


    public class _Sync : Goedel.Registry.Dispatch ,
							IPortalAccount,
							IReporting {
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class Sync : _Sync {
        } // class Sync


    public class _Escrow : Goedel.Registry.Dispatch ,
							IPortalAccount,
							IReporting {
		public Integer			Quorum{get; set;} = new  Integer ();
		public Integer			Shares{get; set;} = new  Integer ();
		public NewFile			File{get; set;} = new  NewFile ();
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class Escrow : _Escrow {
        } // class Escrow


    public class _Export : Goedel.Registry.Dispatch ,
							IPortalAccount,
							IReporting {
		public NewFile			File{get; set;}  = new NewFile ();
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class Export : _Export {
        } // class Export


    public class _Import : Goedel.Registry.Dispatch ,
							IPortalAccount,
							IReporting {
		public NewFile			File{get; set;}  = new NewFile ();
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class Import : _Import {
        } // class Import


    public class _List : Goedel.Registry.Dispatch ,
							IReporting {
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class List : _List {
        } // class List


    public class _Dump : Goedel.Registry.Dispatch ,
							IPortalAccount,
							IReporting {
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class Dump : _Dump {
        } // class Dump


    public class _Pending : Goedel.Registry.Dispatch ,
							IPortalAccount,
							IReporting {
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class Pending : _Pending {
        } // class Pending


    public class _Connect : Goedel.Registry.Dispatch ,
							IReporting,
							IDeviceProfileInfo {
		public String			Portal{get; set;}  = new String ();
		public String			PIN{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");
		public Flag			DeviceNew{get; set;} = new  Flag ();
		public String			DeviceUDF{get; set;} = new  String ();
		public String			DeviceID{get; set;} = new  String ();
		public String			DeviceDescription{get; set;} = new  String ();


		}

    public partial class Connect : _Connect {
        } // class Connect


    public class _Accept : Goedel.Registry.Dispatch ,
							IReporting,
							IPortalAccount {
		public String			DeviceUDF{get; set;}  = new String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();


		}

    public partial class Accept : _Accept {
        } // class Accept


    public class _Complete : Goedel.Registry.Dispatch ,
							IReporting,
							IPortalAccount {
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();


		}

    public partial class Complete : _Complete {
        } // class Complete


    public class _Password : Goedel.Registry.Dispatch ,
							IPortalAccount,
							IReporting {
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class Password : _Password {
        } // class Password


    public class _AddPassword : Goedel.Registry.Dispatch ,
							IApplicationProfile,
							IReporting {
		public String			Site{get; set;}  = new String ();
		public String			Username{get; set;}  = new String ();
		public String			Password{get; set;}  = new String ();
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public String			ID{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class AddPassword : _AddPassword {
        } // class AddPassword


    public class _GetPassword : Goedel.Registry.Dispatch ,
							IApplicationProfile,
							IReporting {
		public String			Site{get; set;}  = new String ();
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public String			ID{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class GetPassword : _GetPassword {
        } // class GetPassword


    public class _DeletePassword : Goedel.Registry.Dispatch ,
							IApplicationProfile,
							IReporting {
		public String			Site{get; set;}  = new String ();
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public String			ID{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class DeletePassword : _DeletePassword {
        } // class DeletePassword


    public class _DumpPassword : Goedel.Registry.Dispatch ,
							IApplicationProfile,
							IReporting {
		public Flag			JSON{get; set;}  = new Flag ();
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public String			ID{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class DumpPassword : _DumpPassword {
        } // class DumpPassword


    public class _Mail : Goedel.Registry.Dispatch ,
							IPortalAccount,
							IReporting {
		public String			Address{get; set;}  = new String ();
		public String			CA{get; set;} = new  String ();
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class Mail : _Mail {
        } // class Mail


    public class _SSH : Goedel.Registry.Dispatch ,
							IPortalAccount,
							IReporting {
		public Flag			Host{get; set;}  = new Flag ();
		public Flag			Client{get; set;}  = new Flag ();
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class SSH : _SSH {
        } // class SSH


    public class _SSHAuth : Goedel.Registry.Dispatch ,
							IApplicationProfile,
							IReporting {
		public Flag			Host{get; set;}  = new Flag ();
		public Flag			Client{get; set;}  = new Flag ();
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public String			ID{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class SSHAuth : _SSHAuth {
        } // class SSHAuth


    public class _SSHKnown : Goedel.Registry.Dispatch ,
							IApplicationProfile,
							IReporting {
		public Flag			Host{get; set;}  = new Flag ();
		public Flag			Client{get; set;}  = new Flag ();
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public String			ID{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class SSHKnown : _SSHKnown {
        } // class SSHKnown


    public class _SSHPublic : Goedel.Registry.Dispatch ,
							IApplicationProfile,
							IReporting {
		public Flag			Host{get; set;}  = new Flag ();
		public Flag			Client{get; set;}  = new Flag ();
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public String			ID{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class SSHPublic : _SSHPublic {
        } // class SSHPublic


    public class _SSHPrivate : Goedel.Registry.Dispatch ,
							IApplicationProfile,
							IReporting {
		public Flag			Host{get; set;}  = new Flag ();
		public Flag			Client{get; set;}  = new Flag ();
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public String			ID{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class SSHPrivate : _SSHPrivate {
        } // class SSHPrivate


    public class _Confirm : Goedel.Registry.Dispatch ,
							IPortalAccount,
							IReporting {
		public String			Address{get; set;}  = new String ();
		public String			PIN{get; set;} = new  String ();
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class Confirm : _Confirm {
        } // class Confirm


    public class _ConfirmPost : Goedel.Registry.Dispatch ,
							IApplicationProfile,
							IReporting {
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public String			ID{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class ConfirmPost : _ConfirmPost {
        } // class ConfirmPost


    public class _ConfirmGet : Goedel.Registry.Dispatch ,
							IApplicationProfile,
							IReporting {
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public String			ID{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class ConfirmGet : _ConfirmGet {
        } // class ConfirmGet


    public class _ConfirmAccept : Goedel.Registry.Dispatch ,
							IApplicationProfile,
							IReporting {
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public String			ID{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class ConfirmAccept : _ConfirmAccept {
        } // class ConfirmAccept


    public class _ConfirmReject : Goedel.Registry.Dispatch ,
							IApplicationProfile,
							IReporting {
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public String			ID{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class ConfirmReject : _ConfirmReject {
        } // class ConfirmReject


    public class _Recrypt : Goedel.Registry.Dispatch ,
							IPortalAccount,
							IReporting {
		public String			Address{get; set;}  = new String ();
		public String			PIN{get; set;} = new  String ();
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class Recrypt : _Recrypt {
        } // class Recrypt


    public class _RecryptGroup : Goedel.Registry.Dispatch ,
							IApplicationProfile,
							IReporting {
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public String			ID{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class RecryptGroup : _RecryptGroup {
        } // class RecryptGroup


    public class _RecryptAdd : Goedel.Registry.Dispatch ,
							IApplicationProfile,
							IReporting {
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public String			ID{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class RecryptAdd : _RecryptAdd {
        } // class RecryptAdd


    public class _RecryptDelete : Goedel.Registry.Dispatch ,
							IApplicationProfile,
							IReporting {
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public String			ID{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class RecryptDelete : _RecryptDelete {
        } // class RecryptDelete


    public class _Encrypt : Goedel.Registry.Dispatch ,
							IApplicationProfile,
							IReporting {
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public String			ID{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


		}

    public partial class Encrypt : _Encrypt {
        } // class Encrypt


    public class _Decrypt : Goedel.Registry.Dispatch ,
							IApplicationProfile,
							IReporting {
		public String			Portal{get; set;} = new  String ();
		public String			UDF{get; set;} = new  String ();
		public String			ID{get; set;} = new  String ();
		public Flag			Verbose{get; set;}  = new  Flag ("false");
		public Flag			Report{get; set;}  = new  Flag ("true");


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
			get => Text;
			}

        } // _String

    public partial class  String : _String {
        public String() {
            } 
        public String(string Value) {
			Default (Value);
            } 
        } // String


    // Parameter type Integer
    public abstract class _Integer : Goedel.Registry.Type {
        public _Integer() {
            }
        public _Integer(string Value) {
			Default (Value);
            } 

		public string			Value {
			get => Text;
			}

        } // _Integer

    public partial class  Integer : _Integer {
        public Integer() {
            } 
        public Integer(string Value) {
			Default (Value);
            } 
        } // Integer




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
		public virtual void Verify ( Verify Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Verify		Dummy = new Verify ();
#pragma warning restore 219

					Console.Write ("{0}verify ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage (null, "portal", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Verify requested portal address");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
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
		public virtual void Register ( Register Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Register		Dummy = new Register ();
#pragma warning restore 219

					Console.Write ("{0}register ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage (null, "portal", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage (null, "udf", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Register the specified profile at a new portal");

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
		public virtual void Deregister ( Deregister Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Deregister		Dummy = new Deregister ();
#pragma warning restore 219

					Console.Write ("{0}deregister ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage (null, "portal", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Deregister the specified profile at a portal");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Fingerprint ( Fingerprint Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Fingerprint		Dummy = new Fingerprint ();
#pragma warning restore 219

					Console.Write ("{0}fingerprint ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.DeviceID.Usage ("did", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Return the fingerprint of a Mesh profile");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"DeviceID", Options.DeviceID);
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
					Console.Write ("[{0}] ", Dummy.File.Usage ("file", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Create a set of key escrow shares");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "Integer", 
							"Quorum", Options.Quorum);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Integer", 
							"Shares", Options.Shares);
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

					Console.Write ("{0}pwadd ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Site.Usage (null, "site", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Username.Usage (null, "user", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Password.Usage (null, "password", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
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
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"ID", Options.ID);
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

					Console.Write ("{0}pwget ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Site.Usage (null, "site", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
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
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"ID", Options.ID);
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

					Console.Write ("{0}pwdelete ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Site.Usage (null, "site", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
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
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"ID", Options.ID);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void DumpPassword ( DumpPassword Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					DumpPassword		Dummy = new DumpPassword ();
#pragma warning restore 219

					Console.Write ("{0}pwdump ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.JSON.Usage (null, "json", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Describe password entry");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"JSON", Options.JSON);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"ID", Options.ID);
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
					Console.Write ("[{0}] ", Dummy.Address.Usage (null, "address", UsageFlag));
					Console.Write ("[{0}] ", Dummy.CA.Usage ("ca", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Add a mail application profile to a personal profile");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Address", Options.Address);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"CA", Options.CA);
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
					Console.Write ("[{0}] ", Dummy.Host.Usage (null, "host", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Client.Usage (null, "client", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Add a ssh application profile to a personal profile");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Host", Options.Host);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Client", Options.Client);
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
		public virtual void SSHAuth ( SSHAuth Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					SSHAuth		Dummy = new SSHAuth ();
#pragma warning restore 219

					Console.Write ("{0}sshauth ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Host.Usage (null, "host", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Client.Usage (null, "client", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    List the SSH Authorized keys");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Host", Options.Host);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Client", Options.Client);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"ID", Options.ID);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void SSHKnown ( SSHKnown Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					SSHKnown		Dummy = new SSHKnown ();
#pragma warning restore 219

					Console.Write ("{0}sshknown ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Host.Usage (null, "host", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Client.Usage (null, "client", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    List the SSH Known Hosts");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Host", Options.Host);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Client", Options.Client);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"ID", Options.ID);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void SSHPublic ( SSHPublic Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					SSHPublic		Dummy = new SSHPublic ();
#pragma warning restore 219

					Console.Write ("{0}sshpub ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Host.Usage (null, "host", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Client.Usage (null, "client", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Return the ssh public key for this device");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Host", Options.Host);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Client", Options.Client);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"ID", Options.ID);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void SSHPrivate ( SSHPrivate Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					SSHPrivate		Dummy = new SSHPrivate ();
#pragma warning restore 219

					Console.Write ("{0}sshpriv ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Host.Usage (null, "host", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Client.Usage (null, "client", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Return the ss private key for this device");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Host", Options.Host);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Client", Options.Client);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"ID", Options.ID);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Confirm ( Confirm Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Confirm		Dummy = new Confirm ();
#pragma warning restore 219

					Console.Write ("{0}confirm ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Address.Usage (null, "address", UsageFlag));
					Console.Write ("[{0}] ", Dummy.PIN.Usage ("pin", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Add a confirmation profile account");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Address", Options.Address);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"PIN", Options.PIN);
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
		public virtual void ConfirmPost ( ConfirmPost Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					ConfirmPost		Dummy = new ConfirmPost ();
#pragma warning restore 219

					Console.Write ("{0}confimpost ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Post a confirmation request to an account");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"ID", Options.ID);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void ConfirmGet ( ConfirmGet Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					ConfirmGet		Dummy = new ConfirmGet ();
#pragma warning restore 219

					Console.Write ("{0}confimget ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    List the pending confirmation requests for this account");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"ID", Options.ID);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void ConfirmAccept ( ConfirmAccept Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					ConfirmAccept		Dummy = new ConfirmAccept ();
#pragma warning restore 219

					Console.Write ("{0}confimaccept ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Accept a confirmation request");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"ID", Options.ID);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void ConfirmReject ( ConfirmReject Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					ConfirmReject		Dummy = new ConfirmReject ();
#pragma warning restore 219

					Console.Write ("{0}confimreject ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Reject a confirmation request");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"ID", Options.ID);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Recrypt ( Recrypt Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					Recrypt		Dummy = new Recrypt ();
#pragma warning restore 219

					Console.Write ("{0}recrypt ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Address.Usage (null, "address", UsageFlag));
					Console.Write ("[{0}] ", Dummy.PIN.Usage ("pin", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Add a confirmation profile account");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Address", Options.Address);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"PIN", Options.PIN);
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
		public virtual void RecryptGroup ( RecryptGroup Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					RecryptGroup		Dummy = new RecryptGroup ();
#pragma warning restore 219

					Console.Write ("{0}recryptgroup ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Create a new recryption group");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"ID", Options.ID);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void RecryptAdd ( RecryptAdd Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					RecryptAdd		Dummy = new RecryptAdd ();
#pragma warning restore 219

					Console.Write ("{0}recryptadd ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Add a member to a recryption group");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"ID", Options.ID);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void RecryptDelete ( RecryptDelete Options
				) {

			char UsageFlag = '-';
				{
#pragma warning disable 219
					RecryptDelete		Dummy = new RecryptDelete ();
#pragma warning restore 219

					Console.Write ("{0}recryptdel ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Remove a member from a recryption group");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"ID", Options.ID);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
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
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Encrypt a file or directory");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"ID", Options.ID);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Verbose", Options.Verbose);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Report", Options.Report);
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
					Console.Write ("[{0}] ", Dummy.Portal.Usage ("portal", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.UDF.Usage ("udf", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.ID.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Report.Usage ("report", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Decrypt a file or directory");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Portal", Options.Portal);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"UDF", Options.UDF);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"ID", Options.ID);
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


