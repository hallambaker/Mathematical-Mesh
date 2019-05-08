using  System.Text;
using  Goedel.Mesh;
using  Goedel.Protocol;
using  Goedel.Utilities;
using  Goedel.Cryptography;
using  Goedel.Cryptography.Dare;
using  Goedel.Mesh.Shell;
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
			 SchemaCatalog(Example);
			 SchemaSpool(Example);
			 SchemaContact(Example);
			 SchemaAccount(Example);
			 SchemaDevicePrivate(Example);
			 SchemaDeviceConnection(Example);
			 SchemaService(Example);
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
			 SchemaMessageCompletion(Example);
			}
		

		//
		// SchemaMaster
		//
		public static void SchemaMaster(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\SchemaMaster.md")) {
				Example._SchemaMaster(Example);
				}
			}
		public void _SchemaMaster(CreateExamples Example) {

				 Format(AliceProfiles.ProfileMaster);
					}
		

		//
		// SchemaDevice
		//
		public static void SchemaDevice(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\SchemaDevice.md")) {
				Example._SchemaDevice(Example);
				}
			}
		public void _SchemaDevice(CreateExamples Example) {

				 Format(AliceProfiles.ProfileDevice);
					}
		

		//
		// SchemaService
		//
		public static void SchemaService(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\SchemaService.md")) {
				Example._SchemaService(Example);
				}
			}
		public void _SchemaService(CreateExamples Example) {

				 Format(ResultHello.ProfileService);
					}
		

		//
		// SchemaAccount
		//
		public static void SchemaAccount(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\SchemaAccount.md")) {
				Example._SchemaAccount(Example);
				}
			}
		public void _SchemaAccount(CreateExamples Example) {

				 Format(AliceProfiles.AssertionAccount);
					}
		

		//
		// SchemaDevicePrivate
		//
		public static void SchemaDevicePrivate(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\SchemaDevicePrivate.md")) {
				Example._SchemaDevicePrivate(Example);
				}
			}
		public void _SchemaDevicePrivate(CreateExamples Example) {

				 Format(AliceProfiles.AssertionAccount);
					}
		

		//
		// SchemaDeviceConnection
		//
		public static void SchemaDeviceConnection(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\SchemaDeviceConnection.md")) {
				Example._SchemaDeviceConnection(Example);
				}
			}
		public void _SchemaDeviceConnection(CreateExamples Example) {

				 Format(AliceProfiles.AssertionAccount);
					}
		

		//
		// SchemaCatalog
		//
		public static void SchemaCatalog(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\SchemaCatalog.md")) {
				Example._SchemaCatalog(Example);
				}
			}
		public void _SchemaCatalog(CreateExamples Example) {

				_Output.Write ("{1}\n{0}", _Indent, "SchemaCatalog".Task("SchemaCatalog"));
					}
		

		//
		// SchemaSpool
		//
		public static void SchemaSpool(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\SchemaSpool.md")) {
				Example._SchemaSpool(Example);
				}
			}
		public void _SchemaSpool(CreateExamples Example) {

				_Output.Write ("{1}\n{0}", _Indent, "SchemaCatalog".Task("SchemaCatalog"));
					}
		

		//
		// SchemaContact
		//
		public static void SchemaContact(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\SchemaContact.md")) {
				Example._SchemaContact(Example);
				}
			}
		public void _SchemaContact(CreateExamples Example) {

				_Output.Write ("{1}\n{0}", _Indent, "SchemaEntryMail".Task("SchemaEntryMail"));
					}
		

		//
		// SchemaEntryDevice
		//
		public static void SchemaEntryDevice(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\SchemaEntryDevice.md")) {
				Example._SchemaEntryDevice(Example);
				}
			}
		public void _SchemaEntryDevice(CreateExamples Example) {

				_Output.Write ("{1}\n{0}", _Indent, "SchemaEntryDevice".Task("SchemaEntryDevice"));
					}
		

		//
		// SchemaEntryContact
		//
		public static void SchemaEntryContact(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\SchemaEntryContact.md")) {
				Example._SchemaEntryContact(Example);
				}
			}
		public void _SchemaEntryContact(CreateExamples Example) {

				 Format(ContactGet[0].ResultEntry.CatalogEntry);
					}
		

		//
		// SchemaEntryCredential
		//
		public static void SchemaEntryCredential(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\SchemaEntryCredential.md")) {
				Example._SchemaEntryCredential(Example);
				}
			}
		public void _SchemaEntryCredential(CreateExamples Example) {

				 Format(PasswordGet[0].ResultEntry.CatalogEntry);
					}
		

		//
		// SchemaEntryNetwork
		//
		public static void SchemaEntryNetwork(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\SchemaEntryNetwork.md")) {
				Example._SchemaEntryNetwork(Example);
				}
			}
		public void _SchemaEntryNetwork(CreateExamples Example) {

				 Format(NetworkGet[0].ResultEntry.CatalogEntry);
					}
		

		//
		// SchemaEntryBookmark
		//
		public static void SchemaEntryBookmark(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\SchemaEntryBookmark.md")) {
				Example._SchemaEntryBookmark(Example);
				}
			}
		public void _SchemaEntryBookmark(CreateExamples Example) {

				 Format(BookmarkGet[0].ResultEntry.CatalogEntry);
					}
		

		//
		// SchemaEntryTask
		//
		public static void SchemaEntryTask(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\SchemaEntryTask.md")) {
				Example._SchemaEntryTask(Example);
				}
			}
		public void _SchemaEntryTask(CreateExamples Example) {

				 Format(CalendarGet[0].ResultEntry.CatalogEntry);
					}
		

		//
		// SchemaEntrySSH
		//
		public static void SchemaEntrySSH(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\SchemaEntrySSH.md")) {
				Example._SchemaEntrySSH(Example);
				}
			}
		public void _SchemaEntrySSH(CreateExamples Example) {

				 Format(SSHCreate[0].ResultSSH?.CatalogEntry);
					}
		

		//
		// SchemaEntryMail
		//
		public static void SchemaEntryMail(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\SchemaEntryMail.md")) {
				Example._SchemaEntryMail(Example);
				}
			}
		public void _SchemaEntryMail(CreateExamples Example) {

				 Format(MailAdd[0].ResultMail?.CatalogEntry);
					}
		

		//
		// SchemaMessageConnection
		//
		public static void SchemaMessageConnection(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\SchemaMessageConnection.md")) {
				Example._SchemaMessageConnection(Example);
				}
			}
		public void _SchemaMessageConnection(CreateExamples Example) {

				 DescribeMessage (ConnectPending[0]);
					}
		

		//
		// SchemaMessageContact
		//
		public static void SchemaMessageContact(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\SchemaMessageContact.md")) {
				Example._SchemaMessageContact(Example);
				}
			}
		public void _SchemaMessageContact(CreateExamples Example) {

				 DescribeMessage (ContactPending[0]);
					}
		

		//
		// SchemaMessageConfirmation
		//
		public static void SchemaMessageConfirmation(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\SchemaMessageConfirmation.md")) {
				Example._SchemaMessageConfirmation(Example);
				}
			}
		public void _SchemaMessageConfirmation(CreateExamples Example) {

				 DescribeMessage (ConfirmPending[0]);
					}
		

		//
		// SchemaMessageCompletion
		//
		public static void SchemaMessageCompletion(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\SchemaMessageCompletion.md")) {
				Example._SchemaMessageCompletion(Example);
				}
			}
		public void _SchemaMessageCompletion(CreateExamples Example) {

				 DescribeMessage (ConfirmGetReject[0]);
					}
		}
	}
