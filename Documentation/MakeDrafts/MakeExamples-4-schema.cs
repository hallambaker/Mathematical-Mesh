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
		// MakeSchemaExamples
		//
		public void MakeSchemaExamples (CreateExamples Example) {
			 SchemaMaster(Example);
			 SchemaDevice(Example);
			 SchemaMesh(Example);
			 SchemaEntryDevice(Example);
			 SchemaEntryContact(Example);
			 SchemaEntryCredential(Example);
			 SchemaEntryNetwork(Example);
			 SchemaEntryBookmark(Example);
			 SchemaEntryTask(Example);
			 SchemaEntrySSH(Example);
			 SchemaEntryMail(Example);
			 SchemaMessageConnection(Example);
			 SchemaMessageContact(Example);
			 SchemaMessageConfirmation(Example);
			}
		

		//
		// SchemaMaster
		//
		public static void SchemaMaster(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\SchemaMaster.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\SchemaMaster.md" };
				obj._SchemaMaster(Example);
				}
			}
		public void _SchemaMaster(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example SchemaMaster\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// SchemaDevice
		//
		public static void SchemaDevice(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\SchemaDevice.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\SchemaDevice.md" };
				obj._SchemaDevice(Example);
				}
			}
		public void _SchemaDevice(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example SchemaDevice\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// SchemaMesh
		//
		public static void SchemaMesh(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\SchemaMesh.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\SchemaMesh.md" };
				obj._SchemaMesh(Example);
				}
			}
		public void _SchemaMesh(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example SchemaMesh\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// SchemaEntryDevice
		//
		public static void SchemaEntryDevice(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\SchemaEntryDevice.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\SchemaEntryDevice.md" };
				obj._SchemaEntryDevice(Example);
				}
			}
		public void _SchemaEntryDevice(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example SchemaEntryDevice\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// SchemaEntryContact
		//
		public static void SchemaEntryContact(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\SchemaEntryContact.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\SchemaEntryContact.md" };
				obj._SchemaEntryContact(Example);
				}
			}
		public void _SchemaEntryContact(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example SchemaEntryContact\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// SchemaEntryCredential
		//
		public static void SchemaEntryCredential(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\SchemaEntryCredential.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\SchemaEntryCredential.md" };
				obj._SchemaEntryCredential(Example);
				}
			}
		public void _SchemaEntryCredential(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example SchemaEntryCredential\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// SchemaEntryNetwork
		//
		public static void SchemaEntryNetwork(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\SchemaEntryNetwork.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\SchemaEntryNetwork.md" };
				obj._SchemaEntryNetwork(Example);
				}
			}
		public void _SchemaEntryNetwork(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example SchemaEntryNetwork\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// SchemaEntryBookmark
		//
		public static void SchemaEntryBookmark(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\SchemaEntryBookmark.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\SchemaEntryBookmark.md" };
				obj._SchemaEntryBookmark(Example);
				}
			}
		public void _SchemaEntryBookmark(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example SchemaEntryBookmark\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// SchemaEntryTask
		//
		public static void SchemaEntryTask(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\SchemaEntryTask.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\SchemaEntryTask.md" };
				obj._SchemaEntryTask(Example);
				}
			}
		public void _SchemaEntryTask(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example SchemaEntryTask\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// SchemaEntrySSH
		//
		public static void SchemaEntrySSH(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\SchemaEntrySSH.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\SchemaEntrySSH.md" };
				obj._SchemaEntrySSH(Example);
				}
			}
		public void _SchemaEntrySSH(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example SchemaEntrySSH\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// SchemaEntryMail
		//
		public static void SchemaEntryMail(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\SchemaEntryMail.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\SchemaEntryMail.md" };
				obj._SchemaEntryMail(Example);
				}
			}
		public void _SchemaEntryMail(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example SchemaEntryMail\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// SchemaMessageConnection
		//
		public static void SchemaMessageConnection(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\SchemaMessageConnection.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\SchemaMessageConnection.md" };
				obj._SchemaMessageConnection(Example);
				}
			}
		public void _SchemaMessageConnection(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example SchemaMessageConnection\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// SchemaMessageContact
		//
		public static void SchemaMessageContact(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\SchemaMessageContact.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\SchemaMessageContact.md" };
				obj._SchemaMessageContact(Example);
				}
			}
		public void _SchemaMessageContact(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example SchemaMessageContact\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		

		//
		// SchemaMessageConfirmation
		//
		public static void SchemaMessageConfirmation(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\SchemaMessageConfirmation.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\SchemaMessageConfirmation.md" };
				obj._SchemaMessageConfirmation(Example);
				}
			}
		public void _SchemaMessageConfirmation(CreateExamples Example) {

				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("Example SchemaMessageConfirmation\n{0}", _Indent);
				_Output.Write ("````\n{0}", _Indent);
					}
		}
	}
