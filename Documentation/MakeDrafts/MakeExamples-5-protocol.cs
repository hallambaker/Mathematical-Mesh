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
		// ProtocolHello
		//
		public static void ProtocolHello(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ProtocolHello.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ProtocolHello.md" };
				obj._ProtocolHello(Example);
				}
			}
		public void _ProtocolHello(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ProtocolHello\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ProtocolHelloDevice
		//
		public static void ProtocolHelloDevice(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ProtocolHelloDevice.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ProtocolHelloDevice.md" };
				obj._ProtocolHelloDevice(Example);
				}
			}
		public void _ProtocolHelloDevice(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ProtocolHelloDevice\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ProtocolHelloProfile
		//
		public static void ProtocolHelloProfile(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ProtocolHelloProfile.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ProtocolHelloProfile.md" };
				obj._ProtocolHelloProfile(Example);
				}
			}
		public void _ProtocolHelloProfile(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ProtocolHelloProfile\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ProtocolHelloTicket
		//
		public static void ProtocolHelloTicket(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ProtocolHelloTicket.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ProtocolHelloTicket.md" };
				obj._ProtocolHelloTicket(Example);
				}
			}
		public void _ProtocolHelloTicket(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ProtocolHelloTicket\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ProtocolAccountCreate
		//
		public static void ProtocolAccountCreate(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ProtocolAccountCreate.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ProtocolAccountCreate.md" };
				obj._ProtocolAccountCreate(Example);
				}
			}
		public void _ProtocolAccountCreate(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ProtocolAccountCreate\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ProtocolAccountDelete
		//
		public static void ProtocolAccountDelete(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ProtocolAccountDelete.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ProtocolAccountDelete.md" };
				obj._ProtocolAccountDelete(Example);
				}
			}
		public void _ProtocolAccountDelete(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ProtocolAccountDelete\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ProtocolStatus
		//
		public static void ProtocolStatus(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ProtocolStatus.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ProtocolStatus.md" };
				obj._ProtocolStatus(Example);
				}
			}
		public void _ProtocolStatus(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ProtocolStatus\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ProtocolDownload
		//
		public static void ProtocolDownload(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ProtocolDownload.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ProtocolDownload.md" };
				obj._ProtocolDownload(Example);
				}
			}
		public void _ProtocolDownload(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ProtocolDownload\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ProtocolUpload
		//
		public static void ProtocolUpload(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ProtocolUpload.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ProtocolUpload.md" };
				obj._ProtocolUpload(Example);
				}
			}
		public void _ProtocolUpload(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ProtocolProtocolUploadHello\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ProtocolConnect
		//
		public static void ProtocolConnect(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ProtocolConnect.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ProtocolConnect.md" };
				obj._ProtocolConnect(Example);
				}
			}
		public void _ProtocolConnect(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ProtocolConnect\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ProtocolConnectPIN
		//
		public static void ProtocolConnectPIN(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ProtocolConnectPIN.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ProtocolConnectPIN.md" };
				obj._ProtocolConnectPIN(Example);
				}
			}
		public void _ProtocolConnectPIN(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ProtocolConnectPIN\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ProtocolConnectEARL
		//
		public static void ProtocolConnectEARL(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ProtocolConnectEARL.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ProtocolConnectEARL.md" };
				obj._ProtocolConnectEARL(Example);
				}
			}
		public void _ProtocolConnectEARL(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ProtocolConnectEARL\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ProtocolContact
		//
		public static void ProtocolContact(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ProtocolContact.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ProtocolContact.md" };
				obj._ProtocolContact(Example);
				}
			}
		public void _ProtocolContact(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ProtocolContact\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ProtocolConfirm
		//
		public static void ProtocolConfirm(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ProtocolConfirm.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ProtocolConfirm.md" };
				obj._ProtocolConfirm(Example);
				}
			}
		public void _ProtocolConfirm(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ProtocolConfirm\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		}
	}
