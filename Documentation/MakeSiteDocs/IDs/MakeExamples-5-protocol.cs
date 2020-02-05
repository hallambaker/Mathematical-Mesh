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
			 ProtocolAccountDelete(Example);
			 ProtocolStatus(Example);
			 ProtocolDownload(Example);
			 ProtocolUpload(Example);
			 ProtocolConnect(Example);
			 ProtocolConnectPIN(Example);
			 ProtocolConnectEARL(Example);
			 ProtocolPostClientService(Example);
			 ProtocolPostServiceService(Example);
			}
		

		//
		// ProtocolHelloRequest
		//
		public static void ProtocolHelloRequest(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\ProtocolHelloRequest.md")) {
				Example._ProtocolHelloRequest(Example);
				}
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
				using (Example._Output = new StreamWriter("Examples\\ProtocolHelloResponse.md")) {
				Example._ProtocolHelloResponse(Example);
				}
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
				using (Example._Output = new StreamWriter("Examples\\ProtocolHello.md")) {
				Example._ProtocolHello(Example);
				}
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
				using (Example._Output = new StreamWriter("Examples\\ProtocolAccountCreate.md")) {
				Example._ProtocolAccountCreate(Example);
				}
			}
		public void _ProtocolAccountCreate(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The request payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequestBinding (Example.CommandsAddServiceAlice[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponseBinding (Example.CommandsAddServiceAlice[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ProtocolAccountDelete
		//
		public static void ProtocolAccountDelete(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\ProtocolAccountDelete.md")) {
				Example._ProtocolAccountDelete(Example);
				}
			}
		public void _ProtocolAccountDelete(CreateExamples Example) {

				 if (ExampleInvalid (Example.CommandsDeleteServiceAlice, 0)) {return;}
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The request payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequestBinding (Example.CommandsDeleteServiceAlice[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponseBinding (Example.CommandsDeleteServiceAlice[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ProtocolStatus
		//
		public static void ProtocolStatus(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\ProtocolStatus.md")) {
				Example._ProtocolStatus(Example);
				}
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
				using (Example._Output = new StreamWriter("Examples\\ProtocolDownload.md")) {
				Example._ProtocolDownload(Example);
				}
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
				using (Example._Output = new StreamWriter("Examples\\ProtocolUpload.md")) {
				Example._ProtocolUpload(Example);
				}
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
				using (Example._Output = new StreamWriter("Examples\\ProtocolConnect.md")) {
				Example._ProtocolConnect(Example);
				}
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
				using (Example._Output = new StreamWriter("Examples\\ProtocolConnectPIN.md")) {
				Example._ProtocolConnectPIN(Example);
				}
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
				using (Example._Output = new StreamWriter("Examples\\ProtocolConnectEARL.md")) {
				Example._ProtocolConnectEARL(Example);
				}
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
				using (Example._Output = new StreamWriter("Examples\\ProtocolPostClientService.md")) {
				Example._ProtocolPostClientService(Example);
				}
			}
		public void _ProtocolPostClientService(CreateExamples Example) {

				 if (ExampleInvalid (Example.CommandsDeleteServiceAlice, 0)) {return;}
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
				using (Example._Output = new StreamWriter("Examples\\ProtocolPostServiceService.md")) {
				Example._ProtocolPostServiceService(Example);
				}
			}
		public void _ProtocolPostServiceService(CreateExamples Example) {

				 if (ExampleInvalid (Example.CommandsDeleteServiceAlice, 0)) {return;}
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("[Not Yet Implemented]\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
