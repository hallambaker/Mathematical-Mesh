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

		 public static CreateExamples Instance (StreamWriter output) => new CreateExamples () {_Output = output};
		

		//
		// MakeArchitectureExamples
		//
		public void MakeArchitectureExamples (CreateExamples Example) {
			 ArchitectureCreate(Example);
			 ArchitectureCredential(Example);
			 ArchitectureConnectDirect(Example);
			 ArchitectureConnectPIN(Example);
			 ArchitectureConnectQR(Example);
			 ArchitectureContactRequest(Example);
			 ArchitectureContactQR(Example);
			 ArchitectureConnectEARL(Example);
			 ArchitectureRecrypt(Example);
			 ArchitectureEscrow(Example);
			 ArchitectureRecovery(Example);
			 ArchitectureUDFTypes(Example);
			 ArchitectureSHA23(Example);
			 ArchitectureEARL(Example);
			}
		

		//
		// ArchitectureCreate
		//
		public static void ArchitectureCreate(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ArchitectureCreate.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ArchitectureCreate.md" };
				obj._ArchitectureCreate(Example);
				}
			}
		public void _ArchitectureCreate(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ArchitectureCreate\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ArchitectureCredential
		//
		public static void ArchitectureCredential(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ArchitectureCredential.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ArchitectureCredential.md" };
				obj._ArchitectureCredential(Example);
				}
			}
		public void _ArchitectureCredential(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ArchitectureCredential\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ArchitectureConnectDirect
		//
		public static void ArchitectureConnectDirect(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ArchitectureConnectDirect.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ArchitectureConnectDirect.md" };
				obj._ArchitectureConnectDirect(Example);
				}
			}
		public void _ArchitectureConnectDirect(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ArchitectureConnectDirect\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ArchitectureConnectPIN
		//
		public static void ArchitectureConnectPIN(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ArchitectureConnectPIN.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ArchitectureConnectPIN.md" };
				obj._ArchitectureConnectPIN(Example);
				}
			}
		public void _ArchitectureConnectPIN(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ArchitectureConnectPIN\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ArchitectureConnectQR
		//
		public static void ArchitectureConnectQR(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ArchitectureConnectQR.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ArchitectureConnectQR.md" };
				obj._ArchitectureConnectQR(Example);
				}
			}
		public void _ArchitectureConnectQR(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ArchitectureConnectQR\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ArchitectureContactRequest
		//
		public static void ArchitectureContactRequest(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ArchitectureContactRequest.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ArchitectureContactRequest.md" };
				obj._ArchitectureContactRequest(Example);
				}
			}
		public void _ArchitectureContactRequest(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ArchitectureContactRequest\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ArchitectureContactQR
		//
		public static void ArchitectureContactQR(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ArchitectureContactQR.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ArchitectureContactQR.md" };
				obj._ArchitectureContactQR(Example);
				}
			}
		public void _ArchitectureContactQR(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ArchitectureContactQR\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ArchitectureConnectEARL
		//
		public static void ArchitectureConnectEARL(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ArchitectureConnectEARL.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ArchitectureConnectEARL.md" };
				obj._ArchitectureConnectEARL(Example);
				}
			}
		public void _ArchitectureConnectEARL(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ArchitectureConnectEARL\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ArchitectureRecrypt
		//
		public static void ArchitectureRecrypt(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ArchitectureRecrypt.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ArchitectureRecrypt.md" };
				obj._ArchitectureRecrypt(Example);
				}
			}
		public void _ArchitectureRecrypt(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ArchitectureRecrypt\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ArchitectureEscrow
		//
		public static void ArchitectureEscrow(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ArchitectureEscrow.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ArchitectureEscrow.md" };
				obj._ArchitectureEscrow(Example);
				}
			}
		public void _ArchitectureEscrow(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ArchitectureEscrow\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ArchitectureRecovery
		//
		public static void ArchitectureRecovery(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ArchitectureRecovery.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ArchitectureRecovery.md" };
				obj._ArchitectureRecovery(Example);
				}
			}
		public void _ArchitectureRecovery(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ArchitectureRecovery\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ArchitectureUDFTypes
		//
		public static void ArchitectureUDFTypes(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ArchitectureUDFTypes.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ArchitectureUDFTypes.md" };
				obj._ArchitectureUDFTypes(Example);
				}
			}
		public void _ArchitectureUDFTypes(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ArchitectureUDFTypes\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ArchitectureSHA23
		//
		public static void ArchitectureSHA23(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ArchitectureSHA23.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ArchitectureSHA23.md" };
				obj._ArchitectureSHA23(Example);
				}
			}
		public void _ArchitectureSHA23(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ArchitectureSHA23\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// ArchitectureEARL
		//
		public static void ArchitectureEARL(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\ArchitectureEARL.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ArchitectureEARL.md" };
				obj._ArchitectureEARL(Example);
				}
			}
		public void _ArchitectureEARL(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example ArchitectureEARL\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		}
	}
