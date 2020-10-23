using  System.Text;
using  Goedel.Mesh;
using  Goedel.Protocol;
using  Goedel.Utilities;
using  Goedel.Cryptography;
using  Goedel.Cryptography.Dare;
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
		// MakeProtocolExamples
		//
		public void MakeProtocolExamples (CreateExamples Example) {
			 ProtocolHelloRequest(Example);
			 ProtocolHelloResponse(Example);
			 ProtocolHello(Example);
			 ProtocolAccountCreate(Example);
			 ProtocolCreateGroup(Example);
			 ProtocolAccountDelete(Example);
			 ProtocolStatus(Example);
			 ProtocolDownload(Example);
			 ProtocolUpload(Example);
			 ProtocolPostClientService(Example);
			 ProtocolPostServiceService(Example);
			 ProtocolClaim(Example);
			 ProtocolPollClaim(Example);
			 ProtocolCryptoKeyShare(Example);
			 ProtocolCryptoKeyAgree(Example);
			 ProtocolMessagePIN(Example);
			 ProtocolContactRemote(Example);
			 ProtocolContactQR(Example);
			 ProtocolContactStatic(Example);
			 ProtocolGroupInvite(Example);
			 ProtocolConfirmation(Example);
			 ProtocolConnect(Example);
			 ProtocolConnectPIN(Example);
			 ProtocolConnectEARL(Example);
			}
		

		//
		// ProtocolCreateGroup
		//
		public static void ProtocolCreateGroup(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolCreateGroup.md");
			Example._Output = _Output;
			Example._ProtocolCreateGroup(Example);
			}
		public void _ProtocolCreateGroup(CreateExamples Example) {

				_Output.Write ("[Example to be provided]\n{0}", _Indent);
					}
		

		//
		// ProtocolClaim
		//
		public static void ProtocolClaim(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolClaim.md");
			Example._Output = _Output;
			Example._ProtocolClaim(Example);
			}
		public void _ProtocolClaim(CreateExamples Example) {

				_Output.Write ("[Example to be provided]\n{0}", _Indent);
					}
		

		//
		// ProtocolPollClaim
		//
		public static void ProtocolPollClaim(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolPollClaim.md");
			Example._Output = _Output;
			Example._ProtocolPollClaim(Example);
			}
		public void _ProtocolPollClaim(CreateExamples Example) {

				_Output.Write ("[Example to be provided]\n{0}", _Indent);
					}
		

		//
		// ProtocolCryptoKeyShare
		//
		public static void ProtocolCryptoKeyShare(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolCryptoKeyShare.md");
			Example._Output = _Output;
			Example._ProtocolCryptoKeyShare(Example);
			}
		public void _ProtocolCryptoKeyShare(CreateExamples Example) {

				_Output.Write ("[Example to be provided]\n{0}", _Indent);
					}
		

		//
		// ProtocolCryptoKeyAgree
		//
		public static void ProtocolCryptoKeyAgree(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolCryptoKeyAgree.md");
			Example._Output = _Output;
			Example._ProtocolCryptoKeyAgree(Example);
			}
		public void _ProtocolCryptoKeyAgree(CreateExamples Example) {

				_Output.Write ("[Example to be provided]\n{0}", _Indent);
					}
		

		//
		// ProtocolMessagePIN
		//
		public static void ProtocolMessagePIN(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolMessagePIN.md");
			Example._Output = _Output;
			Example._ProtocolMessagePIN(Example);
			}
		public void _ProtocolMessagePIN(CreateExamples Example) {

				_Output.Write ("[Example to be provided]\n{0}", _Indent);
					}
		

		//
		// ProtocolContactRemote
		//
		public static void ProtocolContactRemote(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolContactRemote.md");
			Example._Output = _Output;
			Example._ProtocolContactRemote(Example);
			}
		public void _ProtocolContactRemote(CreateExamples Example) {

				_Output.Write ("[Example to be provided]\n{0}", _Indent);
					}
		

		//
		// ProtocolContactQR
		//
		public static void ProtocolContactQR(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolContactQR.md");
			Example._Output = _Output;
			Example._ProtocolContactQR(Example);
			}
		public void _ProtocolContactQR(CreateExamples Example) {

				_Output.Write ("[Example to be provided]\n{0}", _Indent);
					}
		

		//
		// ProtocolContactStatic
		//
		public static void ProtocolContactStatic(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolContactStatic.md");
			Example._Output = _Output;
			Example._ProtocolContactStatic(Example);
			}
		public void _ProtocolContactStatic(CreateExamples Example) {

				_Output.Write ("[Example to be provided]\n{0}", _Indent);
					}
		

		//
		// ProtocolGroupInvite
		//
		public static void ProtocolGroupInvite(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolGroupInvite.md");
			Example._Output = _Output;
			Example._ProtocolGroupInvite(Example);
			}
		public void _ProtocolGroupInvite(CreateExamples Example) {

				_Output.Write ("[Example to be provided]\n{0}", _Indent);
					}
		

		//
		// ProtocolConfirmation
		//
		public static void ProtocolConfirmation(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolConfirmation.md");
			Example._Output = _Output;
			Example._ProtocolConfirmation(Example);
			}
		public void _ProtocolConfirmation(CreateExamples Example) {

				_Output.Write ("[Example to be provided]\n{0}", _Indent);
					}
		

		//
		// ProtocolHelloRequest
		//
		public static void ProtocolHelloRequest(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolHelloRequest.md");
			Example._Output = _Output;
			Example._ProtocolHelloRequest(Example);
			}
		public void _ProtocolHelloRequest(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("[Note, this is showing the payload, not the binding as is intended because the current code \n{0}", _Indent);
				_Output.Write ("doesn't implement it as intended yet]\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequestBinding (Example.ProfileHello[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ProtocolHelloResponse
		//
		public static void ProtocolHelloResponse(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolHelloResponse.md");
			Example._Output = _Output;
			Example._ProtocolHelloResponse(Example);
			}
		public void _ProtocolHelloResponse(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("[Note, this is showing the payload, not the binding as is intended because the current code \n{0}", _Indent);
				_Output.Write ("doesn't implement it as intended yet]\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponseBinding (Example.ProfileHello[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ProtocolHello
		//
		public static void ProtocolHello(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolHello.md");
			Example._Output = _Output;
			Example._ProtocolHello(Example);
			}
		public void _ProtocolHello(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The request payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequestBinding (Example.ProfileHello[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponseBinding (Example.ProfileHello[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ProtocolAccountCreate
		//
		public static void ProtocolAccountCreate(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolAccountCreate.md");
			Example._Output = _Output;
			Example._ProtocolAccountCreate(Example);
			}
		public void _ProtocolAccountCreate(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The request payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequestBinding (Example.ProfileCreateAlice[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponseBinding (Example.ProfileCreateAlice[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ProtocolAccountDelete
		//
		public static void ProtocolAccountDelete(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolAccountDelete.md");
			Example._Output = _Output;
			Example._ProtocolAccountDelete(Example);
			}
		public void _ProtocolAccountDelete(CreateExamples Example) {

				 if (ExampleInvalid (Example.ProfileAliceDelete, 0)) {return;}
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The request payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequestBinding (Example.ProfileAliceDelete[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponseBinding (Example.ProfileAliceDelete[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ProtocolStatus
		//
		public static void ProtocolStatus(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolStatus.md");
			Example._Output = _Output;
			Example._ProtocolStatus(Example);
			}
		public void _ProtocolStatus(CreateExamples Example) {

				 if (ExampleInvalid (Example.ProfileSync)) {return;}
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The request payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequestBinding (Example.ProfileSync[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponseBinding (Example.ProfileSync[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ProtocolDownload
		//
		public static void ProtocolDownload(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolDownload.md");
			Example._Output = _Output;
			Example._ProtocolDownload(Example);
			}
		public void _ProtocolDownload(CreateExamples Example) {

				 if (ExampleInvalid (Example.ProfileSync, 0, 1)) {return;}
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The request payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequestBinding (Example.ProfileSync[0].Traces[1]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponseBinding (Example.ProfileSync[0].Traces[1]);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ProtocolUpload
		//
		public static void ProtocolUpload(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolUpload.md");
			Example._Output = _Output;
			Example._ProtocolUpload(Example);
			}
		public void _ProtocolUpload(CreateExamples Example) {

				 if (ExampleInvalid (Example.ProfileSync, 0, 2)) {return;}
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The request payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequestBinding (Example.ProfileSync[0].Traces[2]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponseBinding (Example.ProfileSync[0].Traces[2]);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ProtocolConnect
		//
		public static void ProtocolConnect(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolConnect.md");
			Example._Output = _Output;
			Example._ProtocolConnect(Example);
			}
		public void _ProtocolConnect(CreateExamples Example) {

				 if (ExampleInvalid (Example.ConnectRequest, 0)) {return;}
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The request payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequestBinding (Example.ConnectRequest[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponseBinding (Example.ConnectRequest[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ProtocolConnectPIN
		//
		public static void ProtocolConnectPIN(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolConnectPIN.md");
			Example._Output = _Output;
			Example._ProtocolConnectPIN(Example);
			}
		public void _ProtocolConnectPIN(CreateExamples Example) {

				 if (ExampleInvalid (Example.ConnectPin, 0)) {return;}
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The request payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequestBinding (Example.ConnectPin[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponseBinding (Example.ConnectPin[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ProtocolConnectEARL
		//
		public static void ProtocolConnectEARL(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolConnectEARL.md");
			Example._Output = _Output;
			Example._ProtocolConnectEARL(Example);
			}
		public void _ProtocolConnectEARL(CreateExamples Example) {

				 if (ExampleInvalid (Example.DeviceEarl1, 0)) {return;}
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The request payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequestBinding (Example.DeviceEarl1[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponseBinding (Example.DeviceEarl1[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ProtocolPostClientService
		//
		public static void ProtocolPostClientService(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolPostClientService.md");
			Example._Output = _Output;
			Example._ProtocolPostClientService(Example);
			}
		public void _ProtocolPostClientService(CreateExamples Example) {

				 if (ExampleInvalid (Example.ConnectRequest, 0)) {return;}
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The request payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequestBinding (Example.ConnectRequest[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponseBinding (Example.ConnectRequest[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ProtocolPostServiceService
		//
		public static void ProtocolPostServiceService(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolPostServiceService.md");
			Example._Output = _Output;
			Example._ProtocolPostServiceService(Example);
			}
		public void _ProtocolPostServiceService(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("[Not Yet Implemented]\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
