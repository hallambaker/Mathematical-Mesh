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
		// UserGuideCredential
		//
		public static void UserGuideCredential (CreateExamples Examples) { /* File  */
			using (var _Output = new StreamWriter ("UserGuide/Apps/catalog.md")) {
				var _Indent = ""; 
				_Output.Write ("<title>Catalog\n{0}", _Indent);
				_Output.Write ("<titlebanner><h1>Mesh/Catalog\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h4>End-to-end encrypted password, bookmarks, contacts management and more.\n{0}", _Indent);
				_Output.Write ("</titlebanner>\n{0}", _Indent);
				_Output.Write ("<leftmain>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("This document provides an introduction to the Mesh/Confirm application. For a\n{0}", _Indent);
				_Output.Write ("more complete description and a detailed reference guide, consult the \n{0}", _Indent);
				_Output.Write ("<a=\"/Documents/draft-hallambaker-mesh-app.html\">Internet Draft</a>.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Mesh/Catalog application is used to maintain collections of passwords, bookmarks \n{0}", _Indent);
				_Output.Write ("and similar data and synchronize these across all the devices connected to a profile.\n{0}", _Indent);
				_Output.Write ("The types of data currently supported are:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<ul>\n{0}", _Indent);
				_Output.Write ("<li>Credentials\n{0}", _Indent);
				_Output.Write ("<li>Contacts\n{0}", _Indent);
				_Output.Write ("<li>Bookmarks\n{0}", _Indent);
				_Output.Write ("<li>Calendar\n{0}", _Indent);
				_Output.Write ("</ul>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("If an item is added to a profile on one device, it becomes available to every device \n{0}", _Indent);
				_Output.Write ("connected to the profile.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The protocol is designed to allow intelligent handling of cases in which multiple \n{0}", _Indent);
				_Output.Write ("devices attempt to make conflicting updates to the same data item at or close to\n{0}", _Indent);
				_Output.Write ("the same time. \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Mesh/Catalog applications are stored at a Mesh/Account service. While a Mesh/Account \n{0}", _Indent);
				_Output.Write ("service provider may also be a portal provider, this is not necessary. Nor is Mesh/Account\n{0}", _Indent);
				_Output.Write ("data synchronized between service providers through the CryptoMesh. The Mesh portal\n{0}", _Indent);
				_Output.Write ("service is intended to support very small quantities of data that are relatively \n{0}", _Indent);
				_Output.Write ("stable over long periods of time. A Mesh/Account service is designed to support larger\n{0}", _Indent);
				_Output.Write ("quantities of data with frequent incremental updates.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Creating a Mesh/Account.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("As with all the Mesh applications supported by a Mesh Service, each user must\n{0}", _Indent);
				_Output.Write ("have an account with the application service:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("AccountAlice"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Mesh/Catalog password and bookmarks manager were originally designed with the intention\n{0}", _Indent);
				_Output.Write ("that they would be integrated into another application such as a Web browser. They may\n{0}", _Indent);
				_Output.Write ("be accessed using the command line tool however and as this example shows, this can\n{0}", _Indent);
				_Output.Write ("be very useful.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Having created her application service account, Alice can add a credential. In this\n{0}", _Indent);
				_Output.Write ("case it is the username and password for an ftp service:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("PasswordAdd"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Having added the password to her profile, Alice can retrieve it when needed.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("PasswordGet"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Using the password catalog in this fashion provides a reminder. But what Alice really\n{0}", _Indent);
				_Output.Write ("wants to be able to do is to automate the process of using the ftp client to upload \n{0}", _Indent);
				_Output.Write ("files without having to enter her password each time or (worse) include the password\n{0}", _Indent);
				_Output.Write ("in the script:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, ToDo ("ConfirmScipt","Write the confirm script"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Having automated access to the ftp site, Alice doesn't need her password to be either\n{0}", _Indent);
				_Output.Write ("memorable or conveniently short. She decides to replace her bad password with a strong\n{0}", _Indent);
				_Output.Write ("password that is randomly generated:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("PasswordKeygen"));
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("PasswordUpdate"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
