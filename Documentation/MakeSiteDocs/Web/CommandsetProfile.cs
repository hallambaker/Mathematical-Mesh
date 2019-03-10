using  System.Text;
using  Goedel.Mesh;
using  Goedel.Mesh.Shell;
using  Goedel.Protocol;
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace MakeSiteDocs {
	public partial class MakeSiteDocs : global::Goedel.Registry.Script {

		

		//
		// WebProfile
		//
		public static void WebProfile (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Guide/profile.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// ProfileReference
		//
		public static void ProfileReference (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Reference/profile.md")) {
				var _Indent = ""; 
				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Profile;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, ProfileHello._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _DeviceCreate._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _MasterCreate._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _ProfileRegister._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _ProfileSync._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _ProfileEscrow._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _ProfileRecover._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _ProfileExport._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _ProfileImport._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _ProfileList._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _ProfileDump._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _ProfilePending._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _ProfileConnect._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _ProfileAccept._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _ProfileReject._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _ProfileGetPIN._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
