#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion

using System.Collections.Generic;



/// <summary>
/// 
/// </summary>
namespace Test.Common;

/// <summary>
/// Constants for use in testing.
/// </summary>
public class TestConstant {

    public static string Service => "example.com";
    public static string UserName => "Alice";
    //public readonly string AccountID = Account.ID(UserName, Service);


    public static string Device1 => "Voodoo";
    public static string Device1Description => "Windows Desktop";
    public static string Device1DescriptionBad => "Windows Desktap";

    public static string App1 => "Password";
    public static string App2 => "Mail";

    public static string MailAccount => "alice@example.com";

    public static List<string> STARTTLS => new() { "STARTTLS" };
    public static List<string> TLS => new() { "TLS" };
    //public static Connection ConnectionSubmit = new Connection(
    //    "smtp.example.com", 587, "_submission._tcp", STARTTLS);
    //public static Connection ConnectionIMAP = new Connection(
    //    "imap.example.com", 993, "_imap4._tcp", TLS);

    public static string Device2 => "Phone";
    public static string Device2Description => "Apple iPhone";

    public static string Device3 => "Watch";
    public static string Device3Description => "Android Watch";

    public static string PWDSite => "www.example.com";
    public static string PWDUser => "Alice";
    public static string PWDPassword => "Secret1";

    public static string PWDUserResult { get; set; }
    public static string PWDPasswordResult { get; set; }

    public static string NameService => "prismproof.org";
    public static string LogMesh => "Tmesh.jlog";
    public static string LogPortal => "Tportal.jlog";



    //public readonly MailAccountInfo MailAccountInfoAlice = new MailAccountInfo() {
    //    EmailAddress = "alice@example.com",
    //    DisplayName = "Alice Accountant",
    //    AccountName = "Work Account",
    //    Outbound = new List<Connection> { ConnectionSubmit },
    //    Inbound = new List<Connection> { ConnectionIMAP }
    //    };


    //public readonly MailAccountInfo MailAccountInfoBob = new MailAccountInfo() {
    //    EmailAddress = "bob@example.com",
    //    DisplayName = "Bob Baker",
    //    AccountName = "Home Account",
    //    Outbound = new List<Connection> { ConnectionSubmit },
    //    Inbound = new List<Connection> { ConnectionIMAP }
    //    };


    }
