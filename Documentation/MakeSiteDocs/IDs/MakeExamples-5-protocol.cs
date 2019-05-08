using  System.Text;
using  Goedel.Mesh;
using  Goedel.Protocol;
using  Goedel.Utilities;
using  Goedel.Cryptography;
using  Goedel.Cryptography.Dare;
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
			 ProtocolHelloDevice(Example);
			 ProtocolHelloProfile(Example);
			 ProtocolHelloTicket(Example);
			 ProtocolAccountCreate(Example);
			 ProtocolAccountDelete(Example);
			 ProtocolStatus(Example);
			 ProtocolDownload(Example);
			 ProtocolUpload(Example);
			 ProtocolConnect(Example);
			 ProtocolConnectPIN(Example);
			 ProtocolConnectEARL(Example);
			 ProtocolContact(Example);
			 ProtocolConfirm(Example);
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

				  DescribeRequestBinding (Example.ProfileHello);
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

				  DescribeResponseBinding (Example.ProfileHello);
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

				  DescribeRequest (Example.ProfileHello);
				  DescribeResponse (Example.ProfileHello);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ProtocolHelloDevice
		//
		public static void ProtocolHelloDevice(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\ProtocolHelloDevice.md")) {
				Example._ProtocolHelloDevice(Example);
				}
			}
		public void _ProtocolHelloDevice(CreateExamples Example) {

				  DescribeRequestBinding (Example.ProfileHelloDevice);
				  DescribeResponseBinding (Example.ProfileHelloDevice);
					}
		

		//
		// ProtocolHelloProfile
		//
		public static void ProtocolHelloProfile(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\ProtocolHelloProfile.md")) {
				Example._ProtocolHelloProfile(Example);
				}
			}
		public void _ProtocolHelloProfile(CreateExamples Example) {

				  DescribeRequestBinding (Example.ProfileHelloProfile);
				  DescribeResponseBinding (Example.ProfileHelloProfile);
					}
		

		//
		// ProtocolHelloTicket
		//
		public static void ProtocolHelloTicket(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\ProtocolHelloTicket.md")) {
				Example._ProtocolHelloTicket(Example);
				}
			}
		public void _ProtocolHelloTicket(CreateExamples Example) {

				  DescribeRequestBinding (Example.ProfileHelloTicket);
				  DescribeResponseBinding (Example.ProfileHelloTicket);
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

				  DescribeRequest (Example.ProfileAliceCreate);
				  DescribeResponse (Example.ProfileAliceCreate);
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

				  DescribeRequest (Example.ProfileAliceDelete);
				  DescribeResponse (Example.ProfileAliceDelete);
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

				  DescribeRequest (Example.ProfileSync);// Message 0,0
				  DescribeResponse (Example.ProfileSync);
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

				  DescribeRequest (Example.ProfileSync);// Message 0,1
				  DescribeResponse (Example.ProfileSync);
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

				  DescribeRequest (Example.ProfileSync);  // Message 0,2
				  DescribeResponse (Example.ProfileSync);
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

				  DescribeRequest (Example.ConnectRequest);
				  DescribeResponse (Example.ConnectRequest);
				  DescribeRequest (Example.ConnectPending);
				  DescribeResponse (Example.ConnectPending);
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

				  DescribeRequest (Example.ConnectGetPin);
				  DescribeResponse (Example.ConnectGetPin);
				  DescribeRequest (Example.ConnectPin);
				  DescribeResponse (Example.ConnectPin);
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

				  DescribeRequest (Example.DeviceEarl1);
				  DescribeRequest (Example.DeviceEarl3);
					}
		

		//
		// ProtocolContact
		//
		public static void ProtocolContact(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\ProtocolContact.md")) {
				Example._ProtocolContact(Example);
				}
			}
		public void _ProtocolContact(CreateExamples Example) {

				  DescribeRequest (Example.ContactRequest);
				  DescribeResponse (Example.ContactRequest);
				  DescribeRequest (Example.ContactAccept);
				  DescribeResponse (Example.ContactAccept);
					}
		

		//
		// ProtocolConfirm
		//
		public static void ProtocolConfirm(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\ProtocolConfirm.md")) {
				Example._ProtocolConfirm(Example);
				}
			}
		public void _ProtocolConfirm(CreateExamples Example) {

				  DescribeRequest (Example.ConfirmRequest);
				  DescribeResponse (Example.ConfirmRequest);
				  DescribeRequest (Example.ConfirmAccept);
				  DescribeResponse (Example.ConfirmAccept);
					}
		}
	}
