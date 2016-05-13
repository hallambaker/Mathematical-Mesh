
//This file was generated automatically.

using System;
using System.Collections.Generic;
using Goedel.Registry;
using Goedel.Trojan;


namespace PHB.Apps.Mesh.ProfileManager {

	// Make extensible partial classes for all the toplevel classes
	// This allows an implementation to decorate any class at will.
	public abstract partial class Object:  Goedel.Trojan.Object {
		}
	public abstract partial class Menu:  Goedel.Trojan.Menu {
		}
	public abstract partial class Window:  Goedel.Trojan.Window {
		}
	public abstract partial class Model:  Goedel.Trojan.Model {
		}

	//The main declarations
	public partial class ProfileManager : _ProfileManager {
		}


	public partial class _ProfileManager : Model {
		public virtual void Refresh () {
			}

		public virtual void Create () {
			}

		public virtual void AddApplication () {
			}

		public virtual void PendingRequest () {
			}

		public virtual void ScanQR () {
			}

		public virtual void GetOTC () {
			}

		public virtual void Administrator (Device Device) {
			}

		public virtual void Connect (Message Message) {
			}

		public virtual void Quit () {
			}

		public virtual void Accept (ConnectRequest ConnectRequest) {
			}

		public virtual void Reject (ConnectRequest ConnectRequest) {
			}

		public virtual void Revoke (KeysSMIME KeysSMIME) {
			}

		public virtual void Renew (KeysSMIME KeysSMIME) {
			}

		public virtual void Revoke (KeysPGP KeysPGP) {
			}

		public virtual void Renew (KeysPGP KeysPGP) {
			}


		Message Selected_Message = null ;
		ConnectRequest Selected_ConnectRequest = null ;
		Profile Selected_Profile = null ;
		Device Selected_Device = null ;
		Application Selected_Application = null ;
		Group Selected_Group = null ;
		ApplicationMail Selected_ApplicationMail = null ;
		ApplicationSSH Selected_ApplicationSSH = null ;
		ApplicationPassword Selected_ApplicationPassword = null ;
		ApplicationWiFi Selected_ApplicationWiFi = null ;
		Key Selected_Key = null ;
		KeysSMIME Selected_KeysSMIME = null ;
		KeysPGP Selected_KeysPGP = null ;
		SSHKey Selected_SSHKey = null ;
		SSHService Selected_SSHService = null ;
		WebPassword Selected_WebPassword = null ;
		WiFi Selected_WiFi = null ;
		Server Selected_Server = null ;
		ServerTLS Selected_ServerTLS = null ;
		ServerSASL Selected_ServerSASL = null ;

        public override void  Dispach(string Command) {
            switch (Command) {
                case "Refresh": {
                        Refresh();
                        return;
                        }
                case "Create": {
                        Create();
                        return;
                        }
                case "AddApplication": {
                        AddApplication();
                        return;
                        }
                case "PendingRequest": {
                        PendingRequest();
                        return;
                        }
                case "ScanQR": {
                        ScanQR();
                        return;
                        }
                case "GetOTC": {
                        GetOTC();
                        return;
                        }
                case "Administrator_Device": {
                        Administrator(Selected_Device);
                        return;
                        }
                case "Connect_Message": {
                        Connect(Selected_Message);
                        return;
                        }
                case "Quit": {
                        Quit();
                        return;
                        }
                case "Accept_ConnectRequest": {
                        Accept(Selected_ConnectRequest);
                        return;
                        }
                case "Reject_ConnectRequest": {
                        Reject(Selected_ConnectRequest);
                        return;
                        }
                case "Revoke_KeysSMIME": {
                        Revoke(Selected_KeysSMIME);
                        return;
                        }
                case "Renew_KeysSMIME": {
                        Renew(Selected_KeysSMIME);
                        return;
                        }
                case "Revoke_KeysPGP": {
                        Revoke(Selected_KeysPGP);
                        return;
                        }
                case "Renew_KeysPGP": {
                        Renew(Selected_KeysPGP);
                        return;
                        }
                }
            }

        public bool Active(String Command) {
            switch (Command) {
                case "Administrator_Device": {
                        return Selected_Device != null;
                        }
                case "Connect_Message": {
                        return Selected_Message != null;
                        }
                case "Accept_ConnectRequest": {
                        return Selected_ConnectRequest != null;
                        }
                case "Reject_ConnectRequest": {
                        return Selected_ConnectRequest != null;
                        }
                case "Revoke_KeysSMIME": {
                        return Selected_KeysSMIME != null;
                        }
                case "Renew_KeysSMIME": {
                        return Selected_KeysSMIME != null;
                        }
                case "Revoke_KeysPGP": {
                        return Selected_KeysPGP != null;
                        }
                case "Renew_KeysPGP": {
                        return Selected_KeysPGP != null;
                        }
                }
            return true;
            }
		}

	// Windows


	public partial class MainWindow : _MainWindow {

		string _Title = "Mesh Profile Manager";
		public override string Title {
			get {return _Title;}
			set {_Title = value;}
			}

		public MainWindow  (Model Model, Binding Binding) {
			// Call backing code to populate the data model
			Populate ();

			// Initialize the view and controller
			Initialize (Model, Binding);
			}
		}

	public abstract class _MainWindow : Window {

		Menu _Menu = new MenuTop ();
        public override Goedel.Trojan.Menu Menu { get { return _Menu; } }
		}


	public partial class MenuTop : _MenuTop {
		}

	public partial class _MenuTop : Menu {
	
		public override List<MenuEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<MenuEntry> _Entries = new List<MenuEntry> {
			new MenuEntry ("Refresh",  "Refresh"),
			new MenuEntry ("Create",  "Create"),
			new MenuEntry ("AddApplication",  "Add"),
			new SubMenu ("Connect",  "Connect", new Connect()),
			new SubMenu ("Privilege",  "Privileges", new Privilege()),
			new MenuEntry ("Quit",  "Quit")};
		}



	public partial class Connect : _Connect {
		}

	public partial class _Connect : Menu {
	
		public override List<MenuEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<MenuEntry> _Entries = new List<MenuEntry> {
			new MenuEntry ("PendingRequest",  "Pending Request"),
			new MenuEntry ("ScanQR",  "Scan QR"),
			new MenuEntry ("GetOTC",  "Get One Time Code")};
		}



	public partial class Privilege : _Privilege {
		}

	public partial class _Privilege : Menu {
	
		public override List<MenuEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<MenuEntry> _Entries = new List<MenuEntry> {
			new MenuEntry ("Administrator",  "Administrative"),
			new MenuEntry ("Connect",  "Connect")};
		}



	// Objects

	public partial class Message : _Message{


	public class _Message : Object {

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		public DateTime Issued; // FieldNumber =  0
		public DateTime Expires; // FieldNumber =  1
		public string Status; // FieldNumber =  2


		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectField ("Issued", "Sent", WidgetType.DateTime ),
			new ObjectField ("Expires", "Expires", WidgetType.DateTime ),
			new ObjectField ("Status", "Status", WidgetType.String )			} ;
		}


	public partial class ConnectRequest : _ConnectRequest{


	public class _ConnectRequest : Message {

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		public string Description; // FieldNumber =  3
		public string Fingerprint; // FieldNumber =  4


		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectField ("Issued", "Sent", WidgetType.DateTime ),
			new ObjectField ("Expires", "Expires", WidgetType.DateTime ),
			new ObjectField ("Status", "Status", WidgetType.String ),
			new ObjectField ("Description", "Device description", WidgetType.String ),
			new ObjectField ("Fingerprint", "Fingerprint", WidgetType.String ),
			new ObjectCommand ("Accept",  "Accept"),
			new ObjectCommand ("Reject",  "Reject")			} ;
		}


	public partial class Profile : _Profile{


	public class _Profile : Object {

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		public string Fingerprint; // FieldNumber =  0
		public List<Group> Groups; // FieldNumber =  1
		public List<Device> Devices; // FieldNumber =  2
		public List<Application> Applications; // FieldNumber =  3


		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectField ("Fingerprint", "Fingerprint", WidgetType.String ),
			new ObjectField ("Groups", "Groups", WidgetType.Set ),
			new ObjectField ("Devices", "Connected devices", WidgetType.Set ),
			new ObjectField ("Applications", "Connected applications", WidgetType.Set )			} ;
		}


	public partial class Device : _Device{


	public class _Device : Object {

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		public List<Group> Groups; // FieldNumber =  0
		public List<Application> Applications; // FieldNumber =  1


		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectField ("Groups", "Member of groups", WidgetType.Set ),
			new ObjectField ("Applications", "Connected applications", WidgetType.Set )			} ;
		}


	public partial class Application : _Application{


	public class _Application : Object {

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		public List<Group> Groups; // FieldNumber =  0
		public List<Device> Devices; // FieldNumber =  1


		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectField ("Groups", "Member of groups", WidgetType.Set ),
			new ObjectField ("Devices", "Connected devices", WidgetType.Set )			} ;
		}


	public partial class Group : _Group{


	public class _Group : Object {

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		public List<Device> Devices; // FieldNumber =  0
		public List<Application> Applications; // FieldNumber =  1


		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectField ("Devices", "Devices", WidgetType.Set ),
			new ObjectField ("Applications", "Applications", WidgetType.Set )			} ;
		}


	public partial class ApplicationMail : _ApplicationMail{


	public class _ApplicationMail : Application {

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		public string Account; // FieldNumber =  2
		public string Address; // FieldNumber =  3
		public ServerSASL Inbound; // FieldNumber =  4
		public ServerSASL Outbound; // FieldNumber =  5
		public bool EnablePGP; // FieldNumber =  6
		public bool PGPPerDeviceSign; // FieldNumber =  7
		public bool PGPPerDeviceDecrypt; // FieldNumber =  8
		public bool PGPSelectAlgorithms; // FieldNumber =  9
		public List<string> PGPAlgorithms; // FieldNumber =  10
		public List<KeysPGP> PGPKeys; // FieldNumber =  11
		public bool EnableSMIME; // FieldNumber =  12
		public bool SMIMEPerDeviceSign; // FieldNumber =  13
		public bool SMIMEPerDeviceDecrypt; // FieldNumber =  14
		public bool SMIMESelectAlgorithms; // FieldNumber =  15
		public List<string> SMIMEAlgorithms; // FieldNumber =  16
		public List<KeysSMIME> SMIMEKeys; // FieldNumber =  17


		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectField ("Groups", "Member of groups", WidgetType.Set ),
			new ObjectField ("Devices", "Connected devices", WidgetType.Set ),
			new ObjectField ("Account", "Account name", WidgetType.String ),
			new ObjectField ("Address", "Email address", WidgetType.String ),
			new ObjectField ("Inbound", "Inbound Server", WidgetType.Item ),
			new ObjectField ("Outbound", "Outbound Server", WidgetType.Item ),
			new ObjectField ("EnablePGP", "OpenPGP", WidgetType.Option ),
			new ObjectField ("EnableSMIME", "S/MIME", WidgetType.Option )			} ;
		}


	public partial class ApplicationSSH : _ApplicationSSH{


	public class _ApplicationSSH : Application {

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		public string Fingerprint; // FieldNumber =  2
		public string Algorithm; // FieldNumber =  3
		public string Key; // FieldNumber =  4


		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectField ("Groups", "Member of groups", WidgetType.Set ),
			new ObjectField ("Devices", "Connected devices", WidgetType.Set ),
			new ObjectField ("Fingerprint", "Fingerprint", WidgetType.String ),
			new ObjectField ("Algorithm", "Algorithm", WidgetType.String ),
			new ObjectField ("Key", "Key", WidgetType.String )			} ;
		}


	public partial class ApplicationPassword : _ApplicationPassword{


	public class _ApplicationPassword : Application {

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		public List<WebPassword> Sites; // FieldNumber =  2


		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectField ("Groups", "Member of groups", WidgetType.Set ),
			new ObjectField ("Devices", "Connected devices", WidgetType.Set ),
			new ObjectField ("Sites", "Sites", WidgetType.List )			} ;
		}


	public partial class ApplicationWiFi : _ApplicationWiFi{


	public class _ApplicationWiFi : Application {

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		public List<WiFi> WiFis; // FieldNumber =  2


		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectField ("Groups", "Member of groups", WidgetType.Set ),
			new ObjectField ("Devices", "Connected devices", WidgetType.Set ),
			new ObjectField ("WiFis", "Networks", WidgetType.List )			} ;
		}


	public partial class Key : _Key{


	public class _Key : Object {

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		public string Fingerprint; // FieldNumber =  0


		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectField ("Fingerprint", "Fingerprint", WidgetType.String )			} ;
		}


	public partial class KeysSMIME : _KeysSMIME{


	public class _KeysSMIME : Key {

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		public bool Valid; // FieldNumber =  1
		public string Created; // FieldNumber =  2
		public string Expires; // FieldNumber =  3


		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectField ("Fingerprint", "Fingerprint", WidgetType.String ),
			new ObjectField ("Valid", "Is valid", WidgetType.Boolean ),
			new ObjectField ("Created", "Created", WidgetType.String ),
			new ObjectField ("Expires", "Expires", WidgetType.String ),
			new ObjectCommand ("Revoke",  "Revoke"),
			new ObjectCommand ("Renew",  "Renew")			} ;
		}


	public partial class KeysPGP : _KeysPGP{


	public class _KeysPGP : Key {

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		public bool Valid; // FieldNumber =  1
		public string Created; // FieldNumber =  2
		public string Expires; // FieldNumber =  3


		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectField ("Fingerprint", "Fingerprint", WidgetType.String ),
			new ObjectField ("Valid", "Is valid", WidgetType.Boolean ),
			new ObjectField ("Created", "Created", WidgetType.String ),
			new ObjectField ("Expires", "Expires", WidgetType.String ),
			new ObjectCommand ("Revoke",  "Revoke"),
			new ObjectCommand ("Renew",  "Renew")			} ;
		}


	public partial class SSHKey : _SSHKey{


	public class _SSHKey : Key {

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		public string Algorithm; // FieldNumber =  1
		public string Key; // FieldNumber =  2


		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectField ("Fingerprint", "Fingerprint", WidgetType.String ),
			new ObjectField ("Algorithm", "Algorithm", WidgetType.String ),
			new ObjectField ("Key", "Key", WidgetType.String )			} ;
		}


	public partial class SSHService : _SSHService{


	public class _SSHService : Object {

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		public Server Server; // FieldNumber =  0
		public string Fingerprint; // FieldNumber =  1


		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectField ("Server", "Server", WidgetType.Item ),
			new ObjectField ("Fingerprint", "Fingerprint", WidgetType.String )			} ;
		}


	public partial class WebPassword : _WebPassword{


	public class _WebPassword : Object {

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		public string Site; // FieldNumber =  0
		public string Account; // FieldNumber =  1
		public string Password; // FieldNumber =  2


		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectField ("Site", "Site", WidgetType.String ),
			new ObjectField ("Account", "Account", WidgetType.String ),
			new ObjectField ("Password", "Password", WidgetType.Secret )			} ;
		}


	public partial class WiFi : _WiFi{


	public class _WiFi : Object {

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		public string SSID; // FieldNumber =  0
		public string Password; // FieldNumber =  1
		public bool WEP; // FieldNumber =  2
		public bool WPA; // FieldNumber =  3
		public bool WPA2; // FieldNumber =  4
		public bool WPAEnterprise; // FieldNumber =  5
		public bool WPA2Enterprise; // FieldNumber =  6


		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectField ("SSID", "SSID", WidgetType.String ),
			new ObjectField ("Password", "Password", WidgetType.Secret ),
			new ObjectField ("WEP", "WEP", WidgetType.Boolean ),
			new ObjectField ("WPA", "WPA", WidgetType.Boolean ),
			new ObjectField ("WPA2", "WPA2", WidgetType.Boolean ),
			new ObjectField ("WPAEnterprise", "WPA Enterprise", WidgetType.Boolean ),
			new ObjectField ("WPA2Enterprise", "WPA2 Enterprise", WidgetType.Boolean )			} ;
		}


	public partial class Server : _Server{


	public class _Server : Object {

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		public string Address; // FieldNumber =  0
		public int Port; // FieldNumber =  1


		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectField ("Address", "DNS Address", WidgetType.String ),
			new ObjectField ("Port", "Port", WidgetType.Integer )			} ;
		}


	public partial class ServerTLS : _ServerTLS{


	public class _ServerTLS : Server {

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		public bool TLS; // FieldNumber =  2
		public string Root; // FieldNumber =  3


		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectField ("Address", "DNS Address", WidgetType.String ),
			new ObjectField ("Port", "Port", WidgetType.Integer ),
			new ObjectField ("TLS", "Require TLS", WidgetType.Boolean ),
			new ObjectField ("Root", "TLS Root", WidgetType.String )			} ;
		}


	public partial class ServerSASL : _ServerSASL{


	public class _ServerSASL : Server {

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		public string Password; // FieldNumber =  2
		public bool Auth; // FieldNumber =  3
		public string Schemes; // FieldNumber =  4


		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectField ("Address", "DNS Address", WidgetType.String ),
			new ObjectField ("Port", "Port", WidgetType.Integer ),
			new ObjectField ("Password", "Password", WidgetType.Secret ),
			new ObjectField ("Auth", "Require Secure Auth", WidgetType.Boolean ),
			new ObjectField ("Schemes", "Only accept", WidgetType.String )			} ;
		}





	}

