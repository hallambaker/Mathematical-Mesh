using  System.Text;
using  Goedel.Mesh;
using  Goedel.Mesh.Shell;
using  Goedel.Protocol;
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator;
public partial class CreateExamples : global::Goedel.Registry.Script {

	

	//
	// WebAccount
	//
	public static void WebAccount(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Guide/account.md");
		Examples._Output = _Output;
		Examples._WebAccount(Examples);
		}
	public void _WebAccount(CreateExamples Examples) {

			 MakeTitle ("account");
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'account' command set groups commands relating to account creation, maintenance and \n{0}", _Indent);
			_Output.Write ("connection to the service.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Contacting a Mesh Service.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'hello' command is used to test connection to a Mesh service. This allows connectivity\n{0}", _Indent);
			_Output.Write ("to the service to be tested before attempting other operations.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Connectivity may be tested by specifying an account or just a DNS service name:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Service.Hello);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Creating a Mesh Account\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("A Mesh account is created using the 'create' command. \n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The user specifies the initial account address to be used ({1}). Use of this address\n{0}", _Indent, AliceAccount);
			_Output.Write ("is of course dependent on authorization by the Mesh Service Provider ({1})\n{0}", _Indent, MeshServiceProvider);
			_Output.Write ("and is likely to require authentication and possibly payment. \n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("", _Indent);
			_Output.Write ("The account create command should support the presentation\n{0}", _Indent);
			_Output.Write ("of some form of one time use token to allow binding of a Web interaction providing payment\n{0}", _Indent);
			_Output.Write ("details to the request to bind the account to a service.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Account.CreateAlice);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The command returns the value of Alice's Mesh Account fingerprint {1}. \n{0}", _Indent, AliceFingerprint);
			_Output.Write ("This value is used as a unique identifier that is cryptographically bound to the signature key used\n{0}", _Indent);
			_Output.Write ("to authenticate the account profile.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("When creating an account, creation of an escrow recovery keyset as described later, is highly recommended.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Account description \n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("A device may be connected to multiple accounts at the same time. The 'list' command\n{0}", _Indent);
			_Output.Write ("returns a list of the accounts to which the device is connected and the 'get'\n{0}", _Indent);
			_Output.Write ("command returns information about a particular account.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1} \n{0}", _Indent, FutureFeature("ListGet", "List/get not currently implemented."));
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Account.ListGetAccountAlice);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Synchronizing an account with a service\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'account status' command returns the status of the account on the device without attempting\n{0}", _Indent);
			_Output.Write ("synchronization. \n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Account.StatusAlice);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The sync command is used to synchronize the account to the service. \n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1} Currently, the tool requires\n{0}", _Indent, FutureFeature("AutoSync", "The tool should sync before each operation requiring it."));
			_Output.Write ("synchronization to be requested manually before each command. This should be performed \n{0}", _Indent);
			_Output.Write ("automatically with an option to suppress.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Account.SyncAlice);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Synchronization will fail if a device has been removed from the account or not yet connected.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Escrow and Recovery\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The Mesh uses strong cryptography to protect the confidentiality and integrity of data. If\n{0}", _Indent);
			_Output.Write ("the private keys used to secure a Mesh account are lost, all data stored under the account \n{0}", _Indent);
			_Output.Write ("is lost and cannot be recovered.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Creation of at least one key escrow set is highly recommended.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("To create a set of recovery shares, the escrow command is used specifying the number of \n{0}", _Indent);
			_Output.Write ("shares to create and the number of shares required for recovery:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Account.ProfileEscrow);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The recovery command is used to recover access to the account from another device if the\n{0}", _Indent);
			_Output.Write ("original administration device is lost or compromized.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Account.ProfileRecover);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("After verifying that the account can be recovered on another device, the primary secret \n{0}", _Indent);
			_Output.Write ("may be purged from the administration device using the 'purge' command. This command is\n{0}", _Indent);
			_Output.Write ("of course irrevocable.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Account.ProfilePurge);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Account import/export\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1} These features are not currently implemented.\n{0}", _Indent, FutureFeature("Import/Export"));
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The export command causes the entire account profile to be written to an archive.\n{0}", _Indent);
			_Output.Write ("This may be used to create a backup copy of the account for archiving purposes\n{0}", _Indent);
			_Output.Write ("or to facilitate provisioning the account to a new machine.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Account.Export);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The import command causes the account profile to be read back from the archive.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Account.Import);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Device connection commands\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'pin' command is used to create a PIN code to provide an out-of-band pre-authentication \n{0}", _Indent);
			_Output.Write ("code for use in device connection. This command is only available to an administration device.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The authorizations to be granted to the device may be specified during PIN creation. This\n{0}", _Indent);
			_Output.Write ("allows the device connection process to be completed without additional user interaction. But\n{0}", _Indent);
			_Output.Write ("the connection can still only complete when an administration device creates the necessary \n{0}", _Indent);
			_Output.Write ("credentials.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Connect.ConnectPINCreate);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'connect' command is used to connect a device to the account by means of a \n{0}", _Indent);
			_Output.Write ("connection URI. This is usually used to connect devices by means of a QR code \n{0}", _Indent);
			_Output.Write ("printed on the device itself.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Connect.ConnectStaticClaim);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The connecting device will only receive notice of the connection request if it\n{0}", _Indent);
			_Output.Write ("has some form of network connectivity allowing it to discover that the connection\n{0}", _Indent);
			_Output.Write ("request is pending.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// AccountReference
	//
	public static void AccountReference(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Reference/profile.md");
		Examples._Output = _Output;
		Examples._AccountReference(Examples);
		}
	public void _AccountReference(CreateExamples Examples) {

			 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Account;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'account' command set groups commands relating to account creation, maintenance and \n{0}", _Indent);
			_Output.Write ("connection to the service.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The '/local', '/verbose', '/report' and '/json' options are supported by every command\n{0}", _Indent);
			_Output.Write ("in the set.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The '/account' option may be used to specify the Mesh account on which the device is \n{0}", _Indent);
			_Output.Write ("to be performed. If unspecified, the default account is used.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ account connect
			 Describe(CommandSet, _AccountConnect._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `account connect` command is used to initiate the process of device connection by means\n{0}", _Indent);
			_Output.Write ("of an account connection URI such as a URI encoded in a QR code on the device housing.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The request must specify the connection URI as the first (and only) parameter.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The '/account' option may be used to specify the Mesh account to which the device is \n{0}", _Indent);
			_Output.Write ("connected. If unspecified, the default account is used.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The '/local' option may be used to specify a local name for the device.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The '/auth' option may be used to specify authorizations to be granted to the device by\n{0}", _Indent);
			_Output.Write ("name. Alternatively the flags '/admin', '/root', '/message', '/web', '/threshold', etc. \n{0}", _Indent);
			_Output.Write ("may be used to specify the most commonly used authorizations.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Connect.ConnectStaticClaim);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ account create
			 Describe(CommandSet, _AccountCreate._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `account create` command is used to create accounts.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The command takes a single parameter, the make of the account to be created. This is always\n{0}", _Indent);
			_Output.Write ("specified in RFC822 style even if it is intended to bind the account to a callsign.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The '/localname' parameter may be used to specify a local (friendly) name for the account.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("If the device has an existing device profile provisioned, this will be reused unless\n{0}", _Indent);
			_Output.Write ("the '/new' option is used to force creation of a new profile. The '/did' and 'dd'\n{0}", _Indent);
			_Output.Write ("options may be used to specify a name and description for the device. If not specified,\n{0}", _Indent);
			_Output.Write ("a default name will be used.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Account.CreateAlice);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ account delete
			 Describe(CommandSet, _AccountDelete._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `account delete` command is used to delete an account from the service and local machine\n{0}", _Indent);
			_Output.Write ("once completed, the command cannot be undone unless the service provides a recovery capability.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The principle use for the current implementation is to test use of the escrow and recovery\n{0}", _Indent);
			_Output.Write ("functions and it is not particularly recommended for any other purpose. To avoid accidental\n{0}", _Indent);
			_Output.Write ("use, the UDF of the device profile must be specified.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Account.DeleteAlice);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ account escrow
			 Describe(CommandSet, _AccountEscrow._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `account escrow` command is used to create a set of key recovery shares for the account\n{0}", _Indent);
			_Output.Write ("primary secret from which the escrow and signature keys are derrived.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The options 'shares' and 'quorum' are used to specify the number of shares to be created\n{0}", _Indent);
			_Output.Write ("(e.g. 5) and the threshold number of shares required to perform recovery (e.g. 3).\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Account.ProfileEscrow);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ account export
			 Describe(CommandSet, _AccountExport._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `account export` command is used to export all data except for private keys associated with \n{0}", _Indent);
			_Output.Write ("the account to a DARE archive.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Account.Import);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ account get
			 Describe(CommandSet, _AccountGet._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `account get` command returns a description of the account. This includes the \n{0}", _Indent);
			_Output.Write ("account UDF fingerprint, the current service binding and the date of the most recent \n{0}", _Indent);
			_Output.Write ("synchronization operation.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Account.GetAccountAlice);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ account hello
			 Describe(CommandSet, _AccountHello._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `account hello` command attempts to contact a Mesh service and reports the\n{0}", _Indent);
			_Output.Write ("service configuration if successful.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Service.Hello);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ account import
			 Describe(CommandSet, _AccountImport._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `account import` command imports Mesh account data from a DARE archive such as \n{0}", _Indent);
			_Output.Write ("an archive created by the 'account export' command.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Account.Import);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ account list
			 Describe(CommandSet, _AccountList._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `account list` command lists all the Mesh accounts the current device is connected \n{0}", _Indent);
			_Output.Write ("to.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Account.ListAlice);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ account pin
			 Describe(CommandSet, _AccountGetPIN._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `account pin` command generates and registers a new PIN code that may be used\n{0}", _Indent);
			_Output.Write ("to authenticate a device connection request.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `/length` option specifies the length of the generated PIN in (significant)\n{0}", _Indent);
			_Output.Write ("characters.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The '/expire' option specifies an expiry time for the request as an integer \n{0}", _Indent);
			_Output.Write ("followed by the letter m, h or d for minutes, hours and days respectively.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The remaining options allow the authorization(s) of the device to be specified so\n{0}", _Indent);
			_Output.Write ("that the connection can be completed without additional user interaction.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Connect.ConnectPINCreate);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ account purge
			 Describe(CommandSet, _AccountPurge._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `account purge` command eliminates deleted objects and messages from the catalogs\n{0}", _Indent);
			_Output.Write ("and spools stored on the current device. The Purge command does not cause data to be\n{0}", _Indent);
			_Output.Write ("deleted from the service.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Account.ProfilePurge);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ account recover
			 Describe(CommandSet, _AccountRecover._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `account recover` command reassembles the account primary secret from a set of\n{0}", _Indent);
			_Output.Write ("recovery shares.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Account.ProfileRecover);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ account status
			 Describe(CommandSet, _AccountStatus._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `account status` command returns the current status of the account catalogs and spools \n{0}", _Indent);
			_Output.Write ("without attempting to synchronize with the service.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Account.StatusAlice);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ account sync
			 Describe(CommandSet, _AccountSync._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `account sync` command attempts to synchronize the account catalogs and spools with\n{0}", _Indent);
			_Output.Write ("the service and reports on the status of each.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("If the '/auto' flag is set, pre-authorized device connection and contact exchange requests\n{0}", _Indent);
			_Output.Write ("in inbound messages will be performed automatically without further user interaction.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Account.SyncAlice);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
		}
