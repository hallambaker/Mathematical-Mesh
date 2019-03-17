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
		// WebConnect
		//
		public static void WebConnect(Examples Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/connect.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Guide/connect.md" };
				obj._WebConnect(Examples);
				}
			}
		public void _WebConnect(Examples Examples) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the device Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `device` command set contains commands used to connect devices to a \n{0}", _Indent);
				_Output.Write ("profile.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Requesting a connection\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used on the new device \n{0}", _Indent, ToCommand("device request"));
				_Output.Write ("to request connection to the user's profile. Alice need only specify \n{0}", _Indent);
				_Output.Write ("the mesh service account {1} to which connection is requested:\n{0}", _Indent, Examples.AliceAccount);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.DeviceRequest);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("In this case there is no existing device profile and so a new profile is\n{0}", _Indent);
				_Output.Write ("created and used to create a registration request which is posted to the user's \n{0}", _Indent);
				_Output.Write ("account.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The tool reports the connection request authenticator, a UDF fingerprint which\n{0}", _Indent);
				_Output.Write ("authenticates this particular request.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice must use a device already connected to her account to\n{0}", _Indent);
				_Output.Write ("complete the connection process.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command gives a list of pending connection\n{0}", _Indent, ToCommand("device pending"));
				_Output.Write ("messages.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ConnectPending);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice sees the request that she posted and approves it with the connect\n{0}", _Indent);
				_Output.Write ("{1} command:\n{0}", _Indent, ToCommand("device accept"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ConnectAccept);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("There is a second request (from Mallet) that Alice doesn't recognize. Alice rejects this\n{0}", _Indent);
				_Output.Write ("request:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ConnectReject);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The connection process is completed by synchronizing the new device. At this point,\n{0}", _Indent);
				_Output.Write ("all the applications that were available to the first device are available to the\n{0}", _Indent);
				_Output.Write ("second:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ConnectSync);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Managing connected devices\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command gives a list of devices in the device \n{0}", _Indent, ToCommand("device list"));
				_Output.Write ("catalog:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ConnectList);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command removes a device from the catalog:\n{0}", _Indent, ToCommand("device delete"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ConnectDelete);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Requesting a connection using a PIN\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The simple connection mechanism is straightforward but relies on the user who is\n{0}", _Indent);
				_Output.Write ("processing the connection requests recognizing the correct fingerprint. While this\n{0}", _Indent);
				_Output.Write ("is approach has proved practical when it is the same user who is making and \n{0}", _Indent);
				_Output.Write ("approving the connection request, it is less satisfactory when this is done\n{0}", _Indent);
				_Output.Write ("by two different people or by the same person at different times.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Connection requests may be authenticated by means of a PIN created on an \n{0}", _Indent);
				_Output.Write ("administration device. The {1} command generates\n{0}", _Indent, ToCommand("device pin"));
				_Output.Write ("a new PIN code:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ConnectGetPin);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The pin code can now be used to authenticate the connection request:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ConnectPin);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Since the PIN code that was issued was set to be self-authorizing, the device\n{0}", _Indent);
				_Output.Write ("is connected automatically when the user synchronizes their account from an \n{0}", _Indent);
				_Output.Write ("administrator device:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ConnectPending3);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Pre Configuring Devices\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command creates a device profile without attempting\n{0}", _Indent, ToCommand("device delete"));
				_Output.Write ("to connect the device to a Mesh profile:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.DeviceCreate);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The most common reason for generating a device profile in this fashion is to allow\n{0}", _Indent);
				_Output.Write ("an embedded or 'IoT' device to be preconfigured for Mesh control during manufacture.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("### Requesting a connection using an EARL\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Encrypted Authenticated Resource Locators provide one means of preconfiguring\n{0}", _Indent);
				_Output.Write ("a device to enable simple and straightforward connection to a Mesh profile.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The EARL itself is typically presented by means of a barcode on the device\n{0}", _Indent);
				_Output.Write ("or its packaging. To connect the device, the user simply scans the QR code using\n{0}", _Indent);
				_Output.Write ("a Mesh enabled application on an administion device and applies power.\n{0}", _Indent);
				_Output.Write ("configuration then proceeds automatically.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alternatively, the EARL may be transfered wirelessly by a near field \n{0}", _Indent);
				_Output.Write ("communications link or by cycling an LED.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To enable this connection mode, the manufacturer performs the steps of\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Generating a device profile and open connection request\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Encrypting the open connection request under a randomly chosen key\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Provisioning the encrypted device profile to a Web site\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Creating UDF EARL of the key\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Converting the EARL to a QR code which is printed on the device or its packaging.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("These steps may be performed using the meshman tool and a QR code generation tool as follows:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.ConnectEarlPrep);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A QR code scanning application can use the meshman tool to resolve the EARL and retrieve\n{0}", _Indent);
				_Output.Write ("the data using the {1} command:\n{0}", _Indent, ToCommand("device earl"));
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.ConnectEarl);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The tool resolves the EARL to obtain the encrypted open connection request,\n{0}", _Indent);
				_Output.Write ("decrypts it and adds it to the user's device catalog. A connection request is\n{0}", _Indent);
				_Output.Write ("to the Mesh service specified in the open connection request to allow the \n{0}", _Indent);
				_Output.Write ("new device to be notified of the connection request and complete the connection.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("If the device is already connected to a Mesh profile, it will need to be reset \n{0}", _Indent);
				_Output.Write ("before it can be connected to another profile unless the device is designed\n{0}", _Indent);
				_Output.Write ("to allow connection to multiple devices simultaneously.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ConnectReference
		//
		public static void ConnectReference(Examples Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/connect.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Reference/connect.md" };
				obj._ConnectReference(Examples);
				}
			}
		public void _ConnectReference(Examples Examples) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Connect;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ProfileConnect._DescribeCommand);
				  ConsoleReference (Examples.DeviceRequest);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ProfilePending._DescribeCommand);
				  ConsoleReference (Examples.ConnectPending);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ProfileAccept._DescribeCommand);
				  ConsoleReference (Examples.ConnectAccept);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ProfileReject._DescribeCommand);
				  ConsoleReference (Examples.ConnectReject);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ProfileGetPIN._DescribeCommand);
				  ConsoleReference (Examples.ConnectGetPin);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ProfileGetPIN._DescribeCommand);
				  ConsoleReference (Examples.ConnectGetPin);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ConnectEarl._DescribeCommand);
				  ConsoleReference (Examples.ConnectEarl);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _DeviceList._DescribeCommand);
				  ConsoleReference (Examples.ConnectList);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _DeviceDelete._DescribeCommand);
				  ConsoleReference (Examples.ConnectDelete);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
