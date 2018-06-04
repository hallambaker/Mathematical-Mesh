using  System.Text;
using  Goedel.Mesh;
using  Goedel.Protocol;
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator {
	public partial class ExampleGenerator : global::Goedel.Registry.Script {

		

		//
		// MakeExamplesCatalog
		//
		public static void MakeExamplesCatalog (CreateExamples Examples) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\examples_catalog.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h2>Catalog Example\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice creates a new bookmarks profile which is shared between her laptop and\n{0}", _Indent);
				_Output.Write ("her phone. The initial profile is empty:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("#% var Bookmarks1 = new BookmarkProfilePrivate () {{Entries = new List <BookmarkEntry>()}};\n{0}", _Indent);
				_Output.Write ("#{{Bookmarks1.ToString()}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice adds a bookmark entry to her profile on the browser on her laptop:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("#% var Added = DateTime.Now;\n{0}", _Indent);
				_Output.Write ("#% var BookmarkEntry1 = new BookmarkEntry () {{ Added=Added, Title=\"First Site\", \n{0}", _Indent);
				_Output.Write ("#%  Uri = \"http://example.com/\" }};\n{0}", _Indent);
				_Output.Write ("#% Bookmarks1.Entries.Add (BookmarkEntry1);\n{0}", _Indent);
				_Output.Write ("#{{Bookmarks1.ToString()}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Later, Alice is attempting to connect to a site on her phone but has no network \n{0}", _Indent);
				_Output.Write ("connection. She decides to bookmark the site instead. \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("#% Added = Added.AddSeconds (5678);\n{0}", _Indent);
				_Output.Write ("#% var Bookmarks2 = new BookmarkProfilePrivate () {{Entries = new List <BookmarkEntry>()}};\n{0}", _Indent);
				_Output.Write ("#% var BookmarkEntry2 = new BookmarkEntry () {{Added=Added,  Title=\"Second Site\", \n{0}", _Indent);
				_Output.Write ("#%   Uri = \"https://example.com/\" }};\n{0}", _Indent);
				_Output.Write ("#% Bookmarks1.Entries.Add (BookmarkEntry2);\n{0}", _Indent);
				_Output.Write ("#% Bookmarks2.Entries.Add (BookmarkEntry2);\n{0}", _Indent);
				_Output.Write ("#{{Bookmarks2.ToString()}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("At this point, the profiles on Alice's two devices are out of sync. When the phone is\n{0}", _Indent);
				_Output.Write ("finally able to connect to the network, the profiles are merged:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("#{{Bookmarks1.ToString()}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// MakeExamplesBookmark
		//
		public static void MakeExamplesBookmark (CreateExamples Examples) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\examples_bookmarks.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<b>tbs</b>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// MakeExamplesCredential
		//
		public static void MakeExamplesCredential (CreateExamples Examples) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\examples_credentials.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h3>Credentials Example\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("#% var CredentialProfilePrivate = new CredentialProfilePrivate () {{\n{0}", _Indent);
				_Output.Write ("#%   NeverAsk = new List<String> {{ \"secure.example.com\", \"bank.example.com\" }},\n{0}", _Indent);
				_Output.Write ("#%   AutoGenerate = true,\n{0}", _Indent);
				_Output.Write ("#%   Entries = new List<CredentialEntry>() {{\n{0}", _Indent);
				_Output.Write ("#%       new CredentialEntry () {{Username =\"Alice\", Password=\"12345\",\n{0}", _Indent);
				_Output.Write ("#%           Sites = new List<String> {{\"luggage.example.net\"}}}},\n{0}", _Indent);
				_Output.Write ("#%       new CredentialEntry () {{Username =\"BitAlice\", Password=\"password\",\n{0}", _Indent);
				_Output.Write ("#%           Sites = new List<String> {{\"host.example.net\"}}, Protocol=\"ssh\",\n{0}", _Indent);
				_Output.Write ("#%           Label = new List<String> {{\"Linux\"}}}}\n{0}", _Indent);
				_Output.Write ("#%       }}}};\n{0}", _Indent);
				_Output.Write ("#{{CredentialProfilePrivate.ToString()}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// MakeExamplesContact
		//
		public static void MakeExamplesContact (CreateExamples Examples) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\examples_contacts.md")) {
				var _Indent = ""; 
				_Output.Write ("#% var AliceName = new PersonalName (){{First=\"Alice\"}};\n{0}", _Indent);
				_Output.Write ("#% var BobName = new PersonalName (){{First=\"Bob\"}};\n{0}", _Indent);
				_Output.Write ("#% var Contact1 = new ContactEntry (){{ Personals =  new List<PersonalName >{{AliceName}},\n{0}", _Indent);
				_Output.Write ("#%    Internets = new List<Internet> () {{new Internet() {{ Uri=\"mailto:alice@example.com\"}}}}}};\n{0}", _Indent);
				_Output.Write ("#% var Contact2 = new ContactEntry (){{ Personals =  new List<PersonalName >{{BobName}},\n{0}", _Indent);
				_Output.Write ("#%    Internets = new List<Internet> () {{new Internet() {{ Uri=\"mailto:bob@example.com\"}}}}}};\n{0}", _Indent);
				_Output.Write ("#% var ContactProfilePrivate = new ContactProfilePrivate () {{\n{0}", _Indent);
				_Output.Write ("#%  Entries = new List<ContactEntry> {{Contact1, Contact2}}}};\n{0}", _Indent);
				_Output.Write ("<h3>Contacts Example\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("#{{ContactProfilePrivate.ToString()}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				}
			}
		

		//
		// MakeExamplesCalendar
		//
		public static void MakeExamplesCalendar (CreateExamples Examples) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\examples_calendar.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h3>Calendar Example\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// MakeExamplesMail
		//
		public static void MakeExamplesMail (CreateExamples Examples) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\examples_mail.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h2>Mail Example\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// MakeExamplesSSH
		//
		public static void MakeExamplesSSH (CreateExamples Examples) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\examples_ssh.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h2>SSH Example\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
