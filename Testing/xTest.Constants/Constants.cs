using System;
using System.Collections.Generic;
using System.Diagnostics;
using Goedel.Utilities;
using Goedel.Mesh;


/// <summary>
/// 
/// </summary>
namespace Test.Common {

    /// <summary>
    /// Constants for use in testing.
    /// </summary>
    public class TestConstant {

        public static string Service = "example.com";
        public static string UserName = "Alice";
        public readonly string AccountID = Account.ID(UserName, Service);


        public static string Device1 = "Voodoo";
        public static string Device1Description = "Windows Desktop";
        public static string Device1DescriptionBad = "Windows Desktap";

        public static string App1 = "Password";
        public static string App2 = "Mail";

        public static string MailAccount = "alice@example.com";

        public static List<string> STARTTLS = new List<string> { "STARTTLS" };
        public static List<string> TLS = new List<string> { "TLS" };
        public static Connection ConnectionSubmit = new Connection(
            "smtp.example.com", 587, "_submission._tcp", STARTTLS);
        public static Connection ConnectionIMAP = new Connection(
            "imap.example.com", 993, "_imap4._tcp", TLS);

        public static string Device2 = "Phone";
        public static string Device2Description = "Apple iPhone";

        public static string Device3 = "Watch";
        public static string Device3Description = "Android Watch";

        public static string PWDSite = "www.example.com";
        public static string PWDUser = "Alice";
        public static string PWDPassword = "Secret1";

        public static string PWDUserResult, PWDPasswordResult;

        public string NameService = "prismproof.org";
        public string LogMesh = "Tmesh.jlog";
        public string LogPortal = "Tportal.jlog";



        public readonly MailAccountInfo MailAccountInfoAlice = new MailAccountInfo() {
            EmailAddress = "alice@example.com",
            DisplayName = "Alice Accountant",
            AccountName = "Work Account",
            Outbound = new List<Connection> { ConnectionSubmit },
            Inbound = new List<Connection> { ConnectionIMAP }
            };


        public readonly MailAccountInfo MailAccountInfoBob = new MailAccountInfo() {
            EmailAddress = "bob@example.com",
            DisplayName = "Bob Baker",
            AccountName = "Home Account",
            Outbound = new List<Connection> { ConnectionSubmit },
            Inbound = new List<Connection> { ConnectionIMAP }
            };


        }

    }