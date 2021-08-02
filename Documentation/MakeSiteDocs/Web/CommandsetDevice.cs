using  System.Text;
using  Goedel.Mesh;
using  Goedel.Mesh.Shell;
using  Goedel.Protocol;
 #pragma warning disable IDE0022
 #pragma warning disable IDE0060
 #pragma warning disable IDE1006
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator {
	public partial class CreateExamples : global::Goedel.Registry.Script {

		

		//
		// WebConnect
		//
		public static void WebConnect(CreateExamples Examples) { /* XFile  */
				using var _Output = new StreamWriter("Guide/device.md");
			Examples._Output = _Output;
			Examples._WebConnect(Examples);
			}
		public void _WebConnect(CreateExamples Examples) {

				 MakeTitle ("device");
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `device` command set contains commands used to connect devices to a \n{0}", _Indent);
				_Output.Write ("profile.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Requesting a connection\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used on the new device \n{0}", _Indent, ToCommand("device request"));
				_Output.Write ("to request connection to the user's profile. Alice need only specify \n{0}", _Indent);
				_Output.Write ("the mesh service account {1} to which connection is requested:\n{0}", _Indent, AliceAccount);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (ShellAccount.ConnectRequest);
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
				  ConsoleExample (ShellAccount.ConnectPending);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice sees the request that she posted and approves it with the connect\n{0}", _Indent);
				_Output.Write ("{1} command:\n{0}", _Indent, ToCommand("device accept"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (ShellAccount.ConnectAccept);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("There is a second request (from Mallet) that Alice doesn't recognize. Alice rejects this\n{0}", _Indent);
				_Output.Write ("request:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (ShellAccount.ConnectReject);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The connection process is completed by synchronizing the new device. At this point,\n{0}", _Indent);
				_Output.Write ("all the applications that were available to the first device are available to the\n{0}", _Indent);
				_Output.Write ("second:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (ShellAccount.ConnectSync);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Managing connected devices\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command gives a list of devices in the device \n{0}", _Indent, ToCommand("device list"));
				_Output.Write ("catalog:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (ShellAccount.ConnectList);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command removes a device from the catalog:\n{0}", _Indent, ToCommand("device delete"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (ShellAccount.ConnectDelete);
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
				  ConsoleExample (ShellAccount.ConnectGetPin);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The pin code can now be used to authenticate the connection request:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (ShellAccount.ConnectPin);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Since the PIN code that was issued was set to be self-authorizing, the device\n{0}", _Indent);
				_Output.Write ("is connected automatically when the user synchronizes their account from an \n{0}", _Indent);
				_Output.Write ("administrator device:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (ShellAccount.ConnectPending3);
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
				_Output.Write ("These steps may be performed on the device to be connected using the \n{0}", _Indent);
				_Output.Write ("{1} command with the `/earl` option. Instead of requesting\n{0}", _Indent, ToCommand("device request"));
				_Output.Write ("connection to a user account, the device requests connection to a special purpose\n{0}", _Indent);
				_Output.Write ("account established for the purpose of providing a hailing account for enabling\n{0}", _Indent);
				_Output.Write ("this type of device connection.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				// ConsoleExample (ShellAccount.DeviceEarl1);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The device can attempt to complete the connection whenever it is provided with power \n{0}", _Indent);
				_Output.Write ("and network connectivity using the {1} command.\n{0}", _Indent, ToCommand("profile sync"));
				_Output.Write ("\n{0}", _Indent);
				// ConsoleExample (ShellAccount.DeviceEarl2);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The key specified in the '/earl' option is used to create a UDF EARL specifying a \n{0}", _Indent);
				_Output.Write ("location from which a device description document may be obtained. Note that \n{0}", _Indent);
				_Output.Write ("it is not necessary for the device description document to be on the same service \n{0}", _Indent);
				_Output.Write ("or even in the same domain as the service used to resolve the UDF.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The UDF is typically presented to the user as a QR code either on the device itself \n{0}", _Indent);
				_Output.Write ("or its packaging. Alternatively, a device might transmit the UDF by blinking its \n{0}", _Indent);
				_Output.Write ("activity LED at a rate suitable to allow transmission of a short message to a \n{0}", _Indent);
				_Output.Write ("smart phone camera.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A QR code or other scanning application can use the meshman tool to resolve the EARL \n{0}", _Indent);
				_Output.Write ("and retrieve the data using the {1} command:\n{0}", _Indent, ToCommand("device earl"));
				_Output.Write ("\n{0}", _Indent);
				// ConsoleExample (ShellAccount.DeviceEarl3);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The tool performs the tasks of resolving the EARL, decrypting the discovery record\n{0}", _Indent);
				_Output.Write ("and posting a connection response to both the hailing account and the profile account.\n{0}", _Indent);
				_Output.Write ("The next time the device polls the hailing account, it retrieves the connection data:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				// ConsoleExample (ShellAccount.DeviceEarl4);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Once connected to an account, a device does not attempt to poll the hailing account. \n{0}", _Indent);
				_Output.Write ("Further attempts to make a connection are thus ignored unless the device is \n{0}", _Indent);
				_Output.Write ("reset.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ConnectReference
		//
		public static void ConnectReference(CreateExamples Examples) { /* XFile  */
				using var _Output = new StreamWriter("Reference/device.md");
			Examples._Output = _Output;
			Examples._ConnectReference(Examples);
			}
		public void _ConnectReference(CreateExamples Examples) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Connect;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _DeviceAccept._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Accept a pending connection request.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleReference (ShellAccount.ConnectAccept);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _DeviceAuthorize._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `device auth` command changes the set of authorizations given to the\n{0}", _Indent);
				_Output.Write ("specified device, adding or removing authorizations according to the \n{0}", _Indent);
				_Output.Write ("flags specified on the command line.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The parameter specifies the device being configured by means of either\n{0}", _Indent);
				_Output.Write ("the UDF of the device profile or the device identifier.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `/id` option may be used to specify a friendly name for the device.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Specifying the `/all` option causes the device to be granted all the \n{0}", _Indent);
				_Output.Write ("available device authorizations except for those explicitly denied \n{0}", _Indent);
				_Output.Write ("by means of a negative authorization grant (e.g. `/nobookmark`).\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Specifying the `/noall` option causes the device to be granted no \n{0}", _Indent);
				_Output.Write ("available device authorizations except for those explicitly granted \n{0}", _Indent);
				_Output.Write ("by means of a positive authorization grant (e.g. `/bookmark`).\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("If neither the `/all` option or the `/noall` option is specified, the \n{0}", _Indent);
				_Output.Write ("device authorizations remain unchanged except where explicitly \n{0}", _Indent);
				_Output.Write ("granted or denied.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The following authorizations may be granted or denied:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* `bookmark`: Authorize response to confirmation requests\n{0}", _Indent);
				_Output.Write ("* `calendar`: Authorize access to calendar catalog\n{0}", _Indent);
				_Output.Write ("* `contact`: Authorize access to contacts catalog\n{0}", _Indent);
				_Output.Write ("* `confirm`: Authorize response to confirmation requests\n{0}", _Indent);
				_Output.Write ("* `mail`: Authorize access to configure SMTP mail services.\n{0}", _Indent);
				_Output.Write ("* `network`: Authorize access to the network catalog\n{0}", _Indent);
				_Output.Write ("* `password`: Authorize access to password catalog\n{0}", _Indent);
				_Output.Write ("* `ssh`: Authorize use of SSH\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleReference (ShellContact.ContactAuth);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _DeviceAccept._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `device accept` command accepts the specified connection request.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The command must specify the connection identifier of the request \n{0}", _Indent);
				_Output.Write ("being accepted. The connection identifier may be abbreviated provided that\n{0}", _Indent);
				_Output.Write ("this uniquely identifies the connection being accepted and that at least \n{0}", _Indent);
				_Output.Write ("four characters are given.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `/id` option may be used to specify a friendly name for the device.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The authorizations to be granted to the device may be specified using\n{0}", _Indent);
				_Output.Write ("the same syntax as for the `device auth` command with the default authorization\n{0}", _Indent);
				_Output.Write ("being that all authorizations are denied.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleReference (ShellAccount.ConnectAccept);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _DeviceDelete._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `device delete` command removes the specified device from the catalog.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The parameter specifies the device being configured by means of either\n{0}", _Indent);
				_Output.Write ("the UDF of the device profile or the device identifier.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleReference (ShellAccount.ConnectDelete);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _DeviceJoin._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `device join` command attempts to connect a device to a personal profile\n{0}", _Indent);
				_Output.Write ("by means of a URI supplied by an administration device.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _DeviceList._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `device list` command lists the device profiles in the device catalog.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleReference (ShellAccount.ConnectList);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _DevicePending._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `device pending` command lists the pending device connection requests in\n{0}", _Indent);
				_Output.Write ("the inbound message spool.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleReference (ShellAccount.ConnectPending);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _DeviceReject._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `device reject` command rejects the specified connection request.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The command must specify the connection identifier of the request \n{0}", _Indent);
				_Output.Write ("being accepted. The connection identifier may be abbreviated provided that\n{0}", _Indent);
				_Output.Write ("this uniquely identifies the connection being accepted and that at least \n{0}", _Indent);
				_Output.Write ("four characters are given.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleReference (ShellAccount.ConnectReject);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _DeviceRequestConnect._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `device request \\<account\\>` command requests connection of a device to a mesh profile.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The \\<account\\> parameter specifies the account for which the connection request is\n{0}", _Indent);
				_Output.Write ("made.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("If the account holder has generated an authentication code, this is specified by means of \n{0}", _Indent);
				_Output.Write ("the `/pin` option.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleReference (ShellAccount.ConnectRequest);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
