
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
	public abstract partial class Wizard:  Goedel.Trojan.Wizard {
		}
	public abstract partial class Model:  Goedel.Trojan.Model {
		}

	//The main declarations
	public partial class ProfileManager : _ProfileManager {
		}


	public partial class _ProfileManager : Model {

        public _ProfileManager() {
            _About = new About(this) {
				Name = "Mesh Profile Manager"
				};
            }




		public virtual void CreateProfile () {
			}

		public virtual void CreateApplication () {
			}

		public virtual void CreateEscrow () {
			}

		public virtual void About () {
			}

		public virtual void Quit () {
			}

		public virtual void ViewPendingRequests () {
			}

		public virtual void ViewPendingApplications () {
			}

		public virtual void ViewPendingDevices () {
			}

		public virtual void AcceptConnect (ConnectRequest ConnectRequest) {
			}

		public virtual void RejectConnect (ConnectRequest ConnectRequest) {
			}

		public virtual void Refresh () {
			}

		public virtual void GetOTC () {
			}

		public virtual void Delete (Device Device) {
			}

		public virtual void AdministratorGrant (Device Device) {
			}

		public virtual void AdministratorRemove (Device Device) {
			}

		public virtual void Rollover (Application Application) {
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

		public virtual void SecureEmail (SelectApplications SelectApplications) {
			}

		public virtual void SecureSSH (SelectApplications SelectApplications) {
			}

		public virtual void SecureWeb (SelectApplications SelectApplications) {
			}

		public virtual void SecureNetwork (SelectApplications SelectApplications) {
			}


		protected Message Selected_Message = null ;
		protected ConnectRequest Selected_ConnectRequest = null ;
		protected Profile Selected_Profile = null ;
		protected Device Selected_Device = null ;
		protected Application Selected_Application = null ;
		protected Group Selected_Group = null ;
		protected ApplicationMail Selected_ApplicationMail = null ;
		protected ApplicationSSH Selected_ApplicationSSH = null ;
		protected ApplicationPassword Selected_ApplicationPassword = null ;
		protected ApplicationWiFi Selected_ApplicationWiFi = null ;
		protected Key Selected_Key = null ;
		protected KeysSMIME Selected_KeysSMIME = null ;
		protected KeysPGP Selected_KeysPGP = null ;
		protected SSHKey Selected_SSHKey = null ;
		protected SSHService Selected_SSHService = null ;
		protected WebPassword Selected_WebPassword = null ;
		protected WiFi Selected_WiFi = null ;
		protected Server Selected_Server = null ;
		protected ServerTLS Selected_ServerTLS = null ;
		protected ServerSASL Selected_ServerSASL = null ;
		protected CreateProfile Selected_CreateProfile = null ;
		protected SelectApplications Selected_SelectApplications = null ;
		protected SelectAccountsEmail Selected_SelectAccountsEmail = null ;
		protected EmailAccounts Selected_EmailAccounts = null ;
		protected EmailOptions Selected_EmailOptions = null ;
		protected WebOptions Selected_WebOptions = null ;
		protected NetworkOptions Selected_NetworkOptions = null ;
		protected Review Selected_Review = null ;
		protected Share Selected_Share = null ;
		protected Finish Selected_Finish = null ;

        public override void  Dispach(string Command) {
            switch (Command) {
                case "CreateProfile": {
                        CreateProfile();
                        return;
                        }
                case "CreateApplication": {
                        CreateApplication();
                        return;
                        }
                case "CreateEscrow": {
                        CreateEscrow();
                        return;
                        }
                case "About": {
                        About();
                        return;
                        }
                case "Quit": {
                        Quit();
                        return;
                        }
                case "ViewPendingRequests": {
                        ViewPendingRequests();
                        return;
                        }
                case "ViewPendingApplications": {
                        ViewPendingApplications();
                        return;
                        }
                case "ViewPendingDevices": {
                        ViewPendingDevices();
                        return;
                        }
                case "AcceptConnect_ConnectRequest": {
                        AcceptConnect(Selected_ConnectRequest);
                        return;
                        }
                case "RejectConnect_ConnectRequest": {
                        RejectConnect(Selected_ConnectRequest);
                        return;
                        }
                case "Refresh": {
                        Refresh();
                        return;
                        }
                case "GetOTC": {
                        GetOTC();
                        return;
                        }
                case "Delete_Device": {
                        Delete(Selected_Device);
                        return;
                        }
                case "AdministratorGrant_Device": {
                        AdministratorGrant(Selected_Device);
                        return;
                        }
                case "AdministratorRemove_Device": {
                        AdministratorRemove(Selected_Device);
                        return;
                        }
                case "Rollover_Application": {
                        Rollover(Selected_Application);
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
                case "SecureEmail_SelectApplications": {
                        SecureEmail(Selected_SelectApplications);
                        return;
                        }
                case "SecureSSH_SelectApplications": {
                        SecureSSH(Selected_SelectApplications);
                        return;
                        }
                case "SecureWeb_SelectApplications": {
                        SecureWeb(Selected_SelectApplications);
                        return;
                        }
                case "SecureNetwork_SelectApplications": {
                        SecureNetwork(Selected_SelectApplications);
                        return;
                        }
                }
            }

        public bool Active(String Command) {
            switch (Command) {
                case "AcceptConnect_ConnectRequest": {
                        return Selected_ConnectRequest != null;
                        }
                case "RejectConnect_ConnectRequest": {
                        return Selected_ConnectRequest != null;
                        }
                case "Delete_Device": {
                        return Selected_Device != null;
                        }
                case "AdministratorGrant_Device": {
                        return Selected_Device != null;
                        }
                case "AdministratorRemove_Device": {
                        return Selected_Device != null;
                        }
                case "Rollover_Application": {
                        return Selected_Application != null;
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
                case "SecureEmail_SelectApplications": {
                        return Selected_SelectApplications != null;
                        }
                case "SecureSSH_SelectApplications": {
                        return Selected_SelectApplications != null;
                        }
                case "SecureWeb_SelectApplications": {
                        return Selected_SelectApplications != null;
                        }
                case "SecureNetwork_SelectApplications": {
                        return Selected_SelectApplications != null;
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
			new SubMenu ("Profiles",  "Profile", new Profiles()),
			new SubMenu ("View",  "View", new View()),
			new SubMenu ("Connect",  "Connections", new Connect()),
			new SubMenu ("Manage",  "Manage", new Manage())};
		}



	public partial class Profiles : _Profiles {
		}

	public partial class _Profiles : Menu {
	
		public override List<MenuEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<MenuEntry> _Entries = new List<MenuEntry> {
			new SubMenu ("Create",  "Create", new Create()),
			new MenuEntry ("About",  "About"),
			new MenuEntry ("Quit",  "Quit")};
		}



	public partial class Create : _Create {
		}

	public partial class _Create : Menu {
	
		public override List<MenuEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<MenuEntry> _Entries = new List<MenuEntry> {
			new MenuEntry ("CreateProfile",  "Create New Personal Profile"),
			new MenuEntry ("CreateApplication",  "Create New Application Profile"),
			new MenuEntry ("CreateEscrow",  "Create escrow key set")};
		}



	public partial class View : _View {
		}

	public partial class _View : Menu {
	
		public override List<MenuEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<MenuEntry> _Entries = new List<MenuEntry> {
			new MenuEntry ("ViewPendingRequests",  "View Pending Requests"),
			new MenuEntry ("ViewPendingApplications",  "View Applications"),
			new MenuEntry ("ViewPendingDevices",  "View Devices")};
		}



	public partial class Connect : _Connect {
		}

	public partial class _Connect : Menu {
	
		public override List<MenuEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<MenuEntry> _Entries = new List<MenuEntry> {
			new MenuEntry ("AcceptConnect",  "Accept"),
			new MenuEntry ("RejectConnect",  "Reject"),
			new MenuEntry ("Refresh",  "Get Pending Requests"),
			new MenuEntry ("GetOTC",  "Issue One Time Code"),
			new MenuEntry ("Delete",  "Delete")};
		}



	public partial class Manage : _Manage {
		}

	public partial class _Manage : Menu {
	
		public override List<MenuEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<MenuEntry> _Entries = new List<MenuEntry> {
			new SubMenu ("Privilege",  "Privileges", new Privilege()),
			new MenuEntry ("Rollover",  "Refresh Keys")};
		}



	public partial class Privilege : _Privilege {
		}

	public partial class _Privilege : Menu {
	
		public override List<MenuEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<MenuEntry> _Entries = new List<MenuEntry> {
			new MenuEntry ("AdministratorGrant",  "Grant Administrator"),
			new MenuEntry ("AdministratorRemove",  "Remove Administrator")};
		}



	// Wizards



	public partial class WizardCreateProfile : _WizardCreateProfile {
		}

	public partial class _WizardCreateProfile : Wizard {

        public override string Title => "Create a New Mesh Profile";
        public override List<string> Texts => _Texts;
        public override List<Step> Steps => _Steps;


	// WizardCreateProfile
		List<string> _Texts = 		new List<string> {
			"This wizard will guide you through the process of setting up a new mesh profile and configuring it for use with your applications." ,
			"To create a Mesh profile you will need to know the address of the portal where the profile is to be registered and provide a name for the profile at that portal." ,
			"Unlike an email account, a Mesh profile belongs to you and only you. You can always change the portal registration  for your profile at a later date." 
			};
		List<Step> _Steps = new List<Step> {
			new Step () {Object = new CreateProfile (), 
				Title = "Create Profile", Description =
				new List<string> {
					}},
			new Step () {Object = new SelectApplications (), 
				Title = "Select Applications", Description =
				new List<string> {
					}},
			new Step () {Object = new Review (), 
				Title = "Review", Description =
				new List<string> {
					}},
			new Step () {Object = new Finish (), 
				Title = "Finish", Description =
				new List<string> {
					}}};


		}



	// Objects

	public partial class Message : _Message{
		}


	public class _Message : Object {

		/// <summary>
        /// Issued
        /// </summary>
		public DateTime Issued {
			get {
				return ((ObjectFieldDateTime)Entries[0]).Value;
				}
			set {
				((ObjectFieldDateTime)Entries[0]).Value = value;
				}
			}
			
		/// <summary>
        /// Expires
        /// </summary>
		public DateTime Expires {
			get {
				return ((ObjectFieldDateTime)Entries[1]).Value;
				}
			set {
				((ObjectFieldDateTime)Entries[1]).Value = value;
				}
			}
			
		/// <summary>
        /// Status
        /// </summary>
		public string Status {
			get {
				return ((ObjectFieldString)Entries[2]).Value;
				}
			set {
				((ObjectFieldString)Entries[2]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldDateTime {Id = "Issued", 
						Label = "Sent" // ((ObjectFieldDateTime)Entries[0]).Value
					    },
			new ObjectFieldDateTime {Id = "Expires", 
						Label = "Expires" // ((ObjectFieldDateTime)Entries[1]).Value
					    },
			new ObjectFieldString {Id = "Status", 
						Label = "Status" // ((ObjectFieldString)Entries[2]).Value
					    }			} ;
		}


	public partial class ConnectRequest : _ConnectRequest{
		}


	public class _ConnectRequest : Message {

		/// <summary>
        /// Description
        /// </summary>
		public string Description {
			get {
				return ((ObjectFieldString)Entries[3]).Value;
				}
			set {
				((ObjectFieldString)Entries[3]).Value = value;
				}
			}
			
		/// <summary>
        /// Fingerprint
        /// </summary>
		public string Fingerprint {
			get {
				return ((ObjectFieldString)Entries[4]).Value;
				}
			set {
				((ObjectFieldString)Entries[4]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldDateTime {Id = "Issued", 
						Label = "Sent" // ((ObjectFieldDateTime)Entries[0]).Value
					    },
			new ObjectFieldDateTime {Id = "Expires", 
						Label = "Expires" // ((ObjectFieldDateTime)Entries[1]).Value
					    },
			new ObjectFieldString {Id = "Status", 
						Label = "Status" // ((ObjectFieldString)Entries[2]).Value
					    },
			new ObjectFieldString {Id = "Description", 
						Label = "Device description" // ((ObjectFieldString)Entries[3]).Value
					    },
			new ObjectFieldString {Id = "Fingerprint", 
						Label = "Fingerprint" // ((ObjectFieldString)Entries[4]).Value
					    },
			new ObjectCommand {
						Id = "Accept",  
						Label = "Accept"},
			new ObjectCommand {
						Id = "Reject",  
						Label = "Reject"}			} ;
		}


	public partial class Profile : _Profile{
		}


	public class _Profile : Object {

		/// <summary>
        /// Fingerprint
        /// </summary>
		public string Fingerprint {
			get {
				return ((ObjectFieldString)Entries[0]).Value;
				}
			set {
				((ObjectFieldString)Entries[0]).Value = value;
				}
			}
			
		/// <summary>
        /// Groups
        /// </summary>
		public List<Goedel.Trojan.Object> Groups {
			get {
				return ((ObjectFieldSet)Entries[1]).Value;
				}
			set {
				((ObjectFieldSet)Entries[1]).Value = value;
				}
			}
			
		/// <summary>
        /// Devices
        /// </summary>
		public List<Goedel.Trojan.Object> Devices {
			get {
				return ((ObjectFieldSet)Entries[2]).Value;
				}
			set {
				((ObjectFieldSet)Entries[2]).Value = value;
				}
			}
			
		/// <summary>
        /// Applications
        /// </summary>
		public List<Goedel.Trojan.Object> Applications {
			get {
				return ((ObjectFieldSet)Entries[3]).Value;
				}
			set {
				((ObjectFieldSet)Entries[3]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldString {Id = "Fingerprint", 
						Label = "Fingerprint" // ((ObjectFieldString)Entries[0]).Value
					    },
			new ObjectFieldSet {Id = "Groups", 
						Label = "Groups" // ((ObjectFieldSet)Entries[1]).Value
					    },
			new ObjectFieldSet {Id = "Devices", 
						Label = "Connected devices" // ((ObjectFieldSet)Entries[2]).Value
					    },
			new ObjectFieldSet {Id = "Applications", 
						Label = "Connected applications" // ((ObjectFieldSet)Entries[3]).Value
					    }			} ;
		}


	public partial class Device : _Device{
		}


	public class _Device : Object {

		/// <summary>
        /// Groups
        /// </summary>
		public List<Goedel.Trojan.Object> Groups {
			get {
				return ((ObjectFieldSet)Entries[0]).Value;
				}
			set {
				((ObjectFieldSet)Entries[0]).Value = value;
				}
			}
			
		/// <summary>
        /// Applications
        /// </summary>
		public List<Goedel.Trojan.Object> Applications {
			get {
				return ((ObjectFieldSet)Entries[1]).Value;
				}
			set {
				((ObjectFieldSet)Entries[1]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldSet {Id = "Groups", 
						Label = "Member of groups" // ((ObjectFieldSet)Entries[0]).Value
					    },
			new ObjectFieldSet {Id = "Applications", 
						Label = "Connected applications" // ((ObjectFieldSet)Entries[1]).Value
					    }			} ;
		}


	public partial class Application : _Application{
		}


	public class _Application : Object {

		/// <summary>
        /// Groups
        /// </summary>
		public List<Goedel.Trojan.Object> Groups {
			get {
				return ((ObjectFieldSet)Entries[0]).Value;
				}
			set {
				((ObjectFieldSet)Entries[0]).Value = value;
				}
			}
			
		/// <summary>
        /// Devices
        /// </summary>
		public List<Goedel.Trojan.Object> Devices {
			get {
				return ((ObjectFieldSet)Entries[1]).Value;
				}
			set {
				((ObjectFieldSet)Entries[1]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldSet {Id = "Groups", 
						Label = "Member of groups" // ((ObjectFieldSet)Entries[0]).Value
					    },
			new ObjectFieldSet {Id = "Devices", 
						Label = "Connected devices" // ((ObjectFieldSet)Entries[1]).Value
					    }			} ;
		}


	public partial class Group : _Group{
		}


	public class _Group : Object {

		/// <summary>
        /// Devices
        /// </summary>
		public List<Goedel.Trojan.Object> Devices {
			get {
				return ((ObjectFieldSet)Entries[0]).Value;
				}
			set {
				((ObjectFieldSet)Entries[0]).Value = value;
				}
			}
			
		/// <summary>
        /// Applications
        /// </summary>
		public List<Goedel.Trojan.Object> Applications {
			get {
				return ((ObjectFieldSet)Entries[1]).Value;
				}
			set {
				((ObjectFieldSet)Entries[1]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldSet {Id = "Devices", 
						Label = "Devices" // ((ObjectFieldSet)Entries[0]).Value
					    },
			new ObjectFieldSet {Id = "Applications", 
						Label = "Applications" // ((ObjectFieldSet)Entries[1]).Value
					    }			} ;
		}


	public partial class ApplicationMail : _ApplicationMail{
		}


	public class _ApplicationMail : Application {

		/// <summary>
        /// Account
        /// </summary>
		public string Account {
			get {
				return ((ObjectFieldString)Entries[2]).Value;
				}
			set {
				((ObjectFieldString)Entries[2]).Value = value;
				}
			}
			
		/// <summary>
        /// Address
        /// </summary>
		public string Address {
			get {
				return ((ObjectFieldString)Entries[3]).Value;
				}
			set {
				((ObjectFieldString)Entries[3]).Value = value;
				}
			}
			
		/// <summary>
        /// Inbound
        /// </summary>
		public ServerSASL Inbound {
			get {
				return (ServerSASL) ((ObjectFieldItem)Entries[4]).Value;
				}
			set {
				((ObjectFieldItem)Entries[4]).Value = value;
				}
			}
			
		/// <summary>
        /// Outbound
        /// </summary>
		public ServerSASL Outbound {
			get {
				return (ServerSASL) ((ObjectFieldItem)Entries[5]).Value;
				}
			set {
				((ObjectFieldItem)Entries[5]).Value = value;
				}
			}
			
		/// <summary>
        /// EnablePGP
        /// </summary>
		public bool EnablePGP {
			get {
				return ((ObjectFieldOption)Entries[6]).Value;
				}
			set {
				((ObjectFieldOption)Entries[6]).Value = value;
				}
			}
			
		/// <summary>
        /// PGPPerDeviceSign
        /// </summary>
		public bool PGPPerDeviceSign {
			get {
				return ((ObjectFieldBoolean)((ObjectFieldOption)Entries[6]).Entries[0]).Value;
				}
			set {
				((ObjectFieldBoolean)((ObjectFieldOption)Entries[6]).Entries[0]).Value = value;
				}
			}
			
		/// <summary>
        /// PGPPerDeviceDecrypt
        /// </summary>
		public bool PGPPerDeviceDecrypt {
			get {
				return ((ObjectFieldBoolean)((ObjectFieldOption)Entries[6]).Entries[1]).Value;
				}
			set {
				((ObjectFieldBoolean)((ObjectFieldOption)Entries[6]).Entries[1]).Value = value;
				}
			}
			
		/// <summary>
        /// PGPSelectAlgorithms
        /// </summary>
		public bool PGPSelectAlgorithms {
			get {
				return ((ObjectFieldOption)((ObjectFieldOption)Entries[6]).Entries[2]).Value;
				}
			set {
				((ObjectFieldOption)((ObjectFieldOption)Entries[6]).Entries[2]).Value = value;
				}
			}
			
		/// <summary>
        /// PGPAlgorithms
        /// </summary>
		public List<string> PGPAlgorithms {
			get {
				return ((ObjectFieldChooser)((ObjectFieldOption)((ObjectFieldOption)Entries[6]).Entries[2]).Entries[3]).Value;
				}
			set {
				((ObjectFieldChooser)((ObjectFieldOption)((ObjectFieldOption)Entries[6]).Entries[2]).Entries[3]).Value = value;
				}
			}
			
		/// <summary>
        /// PGPKeys
        /// </summary>
		public List<Goedel.Trojan.Object> PGPKeys {
			get {
				return ((ObjectFieldList)((ObjectFieldOption)Entries[6]).Entries[4]).Value;
				}
			set {
				((ObjectFieldList)((ObjectFieldOption)Entries[6]).Entries[4]).Value = value;
				}
			}
			
		/// <summary>
        /// EnableSMIME
        /// </summary>
		public bool EnableSMIME {
			get {
				return ((ObjectFieldOption)Entries[7]).Value;
				}
			set {
				((ObjectFieldOption)Entries[7]).Value = value;
				}
			}
			
		/// <summary>
        /// SMIMEPerDeviceSign
        /// </summary>
		public bool SMIMEPerDeviceSign {
			get {
				return ((ObjectFieldBoolean)((ObjectFieldOption)Entries[7]).Entries[5]).Value;
				}
			set {
				((ObjectFieldBoolean)((ObjectFieldOption)Entries[7]).Entries[5]).Value = value;
				}
			}
			
		/// <summary>
        /// SMIMEPerDeviceDecrypt
        /// </summary>
		public bool SMIMEPerDeviceDecrypt {
			get {
				return ((ObjectFieldBoolean)((ObjectFieldOption)Entries[7]).Entries[6]).Value;
				}
			set {
				((ObjectFieldBoolean)((ObjectFieldOption)Entries[7]).Entries[6]).Value = value;
				}
			}
			
		/// <summary>
        /// SMIMESelectAlgorithms
        /// </summary>
		public bool SMIMESelectAlgorithms {
			get {
				return ((ObjectFieldOption)((ObjectFieldOption)Entries[7]).Entries[7]).Value;
				}
			set {
				((ObjectFieldOption)((ObjectFieldOption)Entries[7]).Entries[7]).Value = value;
				}
			}
			
		/// <summary>
        /// SMIMEAlgorithms
        /// </summary>
		public List<string> SMIMEAlgorithms {
			get {
				return ((ObjectFieldChooser)((ObjectFieldOption)((ObjectFieldOption)Entries[7]).Entries[7]).Entries[8]).Value;
				}
			set {
				((ObjectFieldChooser)((ObjectFieldOption)((ObjectFieldOption)Entries[7]).Entries[7]).Entries[8]).Value = value;
				}
			}
			
		/// <summary>
        /// SMIMEKeys
        /// </summary>
		public List<Goedel.Trojan.Object> SMIMEKeys {
			get {
				return ((ObjectFieldList)((ObjectFieldOption)Entries[7]).Entries[9]).Value;
				}
			set {
				((ObjectFieldList)((ObjectFieldOption)Entries[7]).Entries[9]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldSet {Id = "Groups", 
						Label = "Member of groups" // ((ObjectFieldSet)Entries[0]).Value
					    },
			new ObjectFieldSet {Id = "Devices", 
						Label = "Connected devices" // ((ObjectFieldSet)Entries[1]).Value
					    },
			new ObjectFieldString {Id = "Account", 
						Label = "Account name" // ((ObjectFieldString)Entries[2]).Value
					    },
			new ObjectFieldString {Id = "Address", 
						Label = "Email address" // ((ObjectFieldString)Entries[3]).Value
					    },
			new ObjectFieldItem {Id = "Inbound", 
						Label = "Inbound Server" // ((ObjectFieldItem)Entries[4]).Value
					    },
			new ObjectFieldItem {Id = "Outbound", 
						Label = "Outbound Server" // ((ObjectFieldItem)Entries[5]).Value
					    },	
			new ObjectFieldOption {
						Id = "EnablePGP",  
						Label = "OpenPGP",
						Entries = new List<ObjectEntry> {
				new ObjectFieldBoolean {Id = "PGPPerDeviceSign", 
							Label = "Separate signing keys per device" // ((ObjectFieldBoolean)((ObjectFieldOption)Entries[6]).Entries[0]).Value
						    },
				new ObjectFieldBoolean {Id = "PGPPerDeviceDecrypt", 
							Label = "Separate decryption keys per device" // ((ObjectFieldBoolean)((ObjectFieldOption)Entries[6]).Entries[1]).Value
						    },	
				new ObjectFieldOption {
							Id = "PGPSelectAlgorithms",  
							Label = "Specifiy permitted algorithms",
							Entries = new List<ObjectEntry> {
					new ObjectFieldChooser {Id = "PGPAlgorithms", 
								Label = "Algorithms" // ((ObjectFieldChooser)((ObjectFieldOption)((ObjectFieldOption)Entries[6]).Entries[2]).Entries[3]).Value
							    }
								}
							},
				new ObjectFieldList {Id = "PGPKeys", 
							Label = "Keys" // ((ObjectFieldList)((ObjectFieldOption)Entries[6]).Entries[4]).Value
						    }
							}
						},	
			new ObjectFieldOption {
						Id = "EnableSMIME",  
						Label = "S/MIME",
						Entries = new List<ObjectEntry> {
				new ObjectFieldBoolean {Id = "SMIMEPerDeviceSign", 
							Label = "Separate signing keys per device" // ((ObjectFieldBoolean)((ObjectFieldOption)Entries[7]).Entries[5]).Value
						    },
				new ObjectFieldBoolean {Id = "SMIMEPerDeviceDecrypt", 
							Label = "Separate decryption keys per device" // ((ObjectFieldBoolean)((ObjectFieldOption)Entries[7]).Entries[6]).Value
						    },	
				new ObjectFieldOption {
							Id = "SMIMESelectAlgorithms",  
							Label = "Specifiy permitted algorithms",
							Entries = new List<ObjectEntry> {
					new ObjectFieldChooser {Id = "SMIMEAlgorithms", 
								Label = "Algorithms" // ((ObjectFieldChooser)((ObjectFieldOption)((ObjectFieldOption)Entries[7]).Entries[7]).Entries[8]).Value
							    }
								}
							},
				new ObjectFieldList {Id = "SMIMEKeys", 
							Label = "Keys" // ((ObjectFieldList)((ObjectFieldOption)Entries[7]).Entries[9]).Value
						    }
							}
						}			} ;
		}


	public partial class ApplicationSSH : _ApplicationSSH{
		}


	public class _ApplicationSSH : Application {

		/// <summary>
        /// Fingerprint
        /// </summary>
		public string Fingerprint {
			get {
				return ((ObjectFieldString)Entries[2]).Value;
				}
			set {
				((ObjectFieldString)Entries[2]).Value = value;
				}
			}
			
		/// <summary>
        /// Algorithm
        /// </summary>
		public string Algorithm {
			get {
				return ((ObjectFieldString)Entries[3]).Value;
				}
			set {
				((ObjectFieldString)Entries[3]).Value = value;
				}
			}
			
		/// <summary>
        /// Key
        /// </summary>
		public string Key {
			get {
				return ((ObjectFieldString)Entries[4]).Value;
				}
			set {
				((ObjectFieldString)Entries[4]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldSet {Id = "Groups", 
						Label = "Member of groups" // ((ObjectFieldSet)Entries[0]).Value
					    },
			new ObjectFieldSet {Id = "Devices", 
						Label = "Connected devices" // ((ObjectFieldSet)Entries[1]).Value
					    },
			new ObjectFieldString {Id = "Fingerprint", 
						Label = "Fingerprint" // ((ObjectFieldString)Entries[2]).Value
					    },
			new ObjectFieldString {Id = "Algorithm", 
						Label = "Algorithm" // ((ObjectFieldString)Entries[3]).Value
					    },
			new ObjectFieldString {Id = "Key", 
						Label = "Key" // ((ObjectFieldString)Entries[4]).Value
					    }			} ;
		}


	public partial class ApplicationPassword : _ApplicationPassword{
		}


	public class _ApplicationPassword : Application {

		/// <summary>
        /// Sites
        /// </summary>
		public List<Goedel.Trojan.Object> Sites {
			get {
				return ((ObjectFieldList)Entries[2]).Value;
				}
			set {
				((ObjectFieldList)Entries[2]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldSet {Id = "Groups", 
						Label = "Member of groups" // ((ObjectFieldSet)Entries[0]).Value
					    },
			new ObjectFieldSet {Id = "Devices", 
						Label = "Connected devices" // ((ObjectFieldSet)Entries[1]).Value
					    },
			new ObjectFieldList {Id = "Sites", 
						Label = "Sites" // ((ObjectFieldList)Entries[2]).Value
					    }			} ;
		}


	public partial class ApplicationWiFi : _ApplicationWiFi{
		}


	public class _ApplicationWiFi : Application {

		/// <summary>
        /// WiFis
        /// </summary>
		public List<Goedel.Trojan.Object> WiFis {
			get {
				return ((ObjectFieldList)Entries[2]).Value;
				}
			set {
				((ObjectFieldList)Entries[2]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldSet {Id = "Groups", 
						Label = "Member of groups" // ((ObjectFieldSet)Entries[0]).Value
					    },
			new ObjectFieldSet {Id = "Devices", 
						Label = "Connected devices" // ((ObjectFieldSet)Entries[1]).Value
					    },
			new ObjectFieldList {Id = "WiFis", 
						Label = "Networks" // ((ObjectFieldList)Entries[2]).Value
					    }			} ;
		}


	public partial class Key : _Key{
		}


	public class _Key : Object {

		/// <summary>
        /// Fingerprint
        /// </summary>
		public string Fingerprint {
			get {
				return ((ObjectFieldString)Entries[0]).Value;
				}
			set {
				((ObjectFieldString)Entries[0]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldString {Id = "Fingerprint", 
						Label = "Fingerprint" // ((ObjectFieldString)Entries[0]).Value
					    }			} ;
		}


	public partial class KeysSMIME : _KeysSMIME{
		}


	public class _KeysSMIME : Key {

		/// <summary>
        /// Valid
        /// </summary>
		public bool Valid {
			get {
				return ((ObjectFieldBoolean)Entries[1]).Value;
				}
			set {
				((ObjectFieldBoolean)Entries[1]).Value = value;
				}
			}
			
		/// <summary>
        /// Created
        /// </summary>
		public string Created {
			get {
				return ((ObjectFieldString)Entries[2]).Value;
				}
			set {
				((ObjectFieldString)Entries[2]).Value = value;
				}
			}
			
		/// <summary>
        /// Expires
        /// </summary>
		public string Expires {
			get {
				return ((ObjectFieldString)Entries[3]).Value;
				}
			set {
				((ObjectFieldString)Entries[3]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldString {Id = "Fingerprint", 
						Label = "Fingerprint" // ((ObjectFieldString)Entries[0]).Value
					    },
			new ObjectFieldBoolean {Id = "Valid", 
						Label = "Is valid" // ((ObjectFieldBoolean)Entries[1]).Value
					    },
			new ObjectFieldString {Id = "Created", 
						Label = "Created" // ((ObjectFieldString)Entries[2]).Value
					    },
			new ObjectFieldString {Id = "Expires", 
						Label = "Expires" // ((ObjectFieldString)Entries[3]).Value
					    },
			new ObjectCommand {
						Id = "Revoke",  
						Label = "Revoke"},
			new ObjectCommand {
						Id = "Renew",  
						Label = "Renew"}			} ;
		}


	public partial class KeysPGP : _KeysPGP{
		}


	public class _KeysPGP : Key {

		/// <summary>
        /// Valid
        /// </summary>
		public bool Valid {
			get {
				return ((ObjectFieldBoolean)Entries[1]).Value;
				}
			set {
				((ObjectFieldBoolean)Entries[1]).Value = value;
				}
			}
			
		/// <summary>
        /// Created
        /// </summary>
		public string Created {
			get {
				return ((ObjectFieldString)Entries[2]).Value;
				}
			set {
				((ObjectFieldString)Entries[2]).Value = value;
				}
			}
			
		/// <summary>
        /// Expires
        /// </summary>
		public string Expires {
			get {
				return ((ObjectFieldString)Entries[3]).Value;
				}
			set {
				((ObjectFieldString)Entries[3]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldString {Id = "Fingerprint", 
						Label = "Fingerprint" // ((ObjectFieldString)Entries[0]).Value
					    },
			new ObjectFieldBoolean {Id = "Valid", 
						Label = "Is valid" // ((ObjectFieldBoolean)Entries[1]).Value
					    },
			new ObjectFieldString {Id = "Created", 
						Label = "Created" // ((ObjectFieldString)Entries[2]).Value
					    },
			new ObjectFieldString {Id = "Expires", 
						Label = "Expires" // ((ObjectFieldString)Entries[3]).Value
					    },
			new ObjectCommand {
						Id = "Revoke",  
						Label = "Revoke"},
			new ObjectCommand {
						Id = "Renew",  
						Label = "Renew"}			} ;
		}


	public partial class SSHKey : _SSHKey{
		}


	public class _SSHKey : Key {

		/// <summary>
        /// Algorithm
        /// </summary>
		public string Algorithm {
			get {
				return ((ObjectFieldString)Entries[1]).Value;
				}
			set {
				((ObjectFieldString)Entries[1]).Value = value;
				}
			}
			
		/// <summary>
        /// Key
        /// </summary>
		public string Key {
			get {
				return ((ObjectFieldString)Entries[2]).Value;
				}
			set {
				((ObjectFieldString)Entries[2]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldString {Id = "Fingerprint", 
						Label = "Fingerprint" // ((ObjectFieldString)Entries[0]).Value
					    },
			new ObjectFieldString {Id = "Algorithm", 
						Label = "Algorithm" // ((ObjectFieldString)Entries[1]).Value
					    },
			new ObjectFieldString {Id = "Key", 
						Label = "Key" // ((ObjectFieldString)Entries[2]).Value
					    }			} ;
		}


	public partial class SSHService : _SSHService{
		}


	public class _SSHService : Object {

		/// <summary>
        /// Server
        /// </summary>
		public Server Server {
			get {
				return (Server) ((ObjectFieldItem)Entries[0]).Value;
				}
			set {
				((ObjectFieldItem)Entries[0]).Value = value;
				}
			}
			
		/// <summary>
        /// Fingerprint
        /// </summary>
		public string Fingerprint {
			get {
				return ((ObjectFieldString)Entries[1]).Value;
				}
			set {
				((ObjectFieldString)Entries[1]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldItem {Id = "Server", 
						Label = "Server" // ((ObjectFieldItem)Entries[0]).Value
					    },
			new ObjectFieldString {Id = "Fingerprint", 
						Label = "Fingerprint" // ((ObjectFieldString)Entries[1]).Value
					    }			} ;
		}


	public partial class WebPassword : _WebPassword{
		}


	public class _WebPassword : Object {

		/// <summary>
        /// Site
        /// </summary>
		public string Site {
			get {
				return ((ObjectFieldString)Entries[0]).Value;
				}
			set {
				((ObjectFieldString)Entries[0]).Value = value;
				}
			}
			
		/// <summary>
        /// Account
        /// </summary>
		public string Account {
			get {
				return ((ObjectFieldString)Entries[1]).Value;
				}
			set {
				((ObjectFieldString)Entries[1]).Value = value;
				}
			}
			
		/// <summary>
        /// Password
        /// </summary>
		public string Password {
			get {
				return ((ObjectFieldSecret)Entries[2]).Value;
				}
			set {
				((ObjectFieldSecret)Entries[2]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldString {Id = "Site", 
						Label = "Site" // ((ObjectFieldString)Entries[0]).Value
					    },
			new ObjectFieldString {Id = "Account", 
						Label = "Account" // ((ObjectFieldString)Entries[1]).Value
					    },
			new ObjectFieldSecret {Id = "Password", 
						Label = "Password" // ((ObjectFieldSecret)Entries[2]).Value
					    }			} ;
		}


	public partial class WiFi : _WiFi{
		}


	public class _WiFi : Object {

		/// <summary>
        /// SSID
        /// </summary>
		public string SSID {
			get {
				return ((ObjectFieldString)Entries[0]).Value;
				}
			set {
				((ObjectFieldString)Entries[0]).Value = value;
				}
			}
			
		/// <summary>
        /// Password
        /// </summary>
		public string Password {
			get {
				return ((ObjectFieldSecret)Entries[1]).Value;
				}
			set {
				((ObjectFieldSecret)Entries[1]).Value = value;
				}
			}
			
		/// <summary>
        /// WEP
        /// </summary>
		public bool WEP {
			get {
				return ((ObjectFieldBoolean)Entries[2]).Value;
				}
			set {
				((ObjectFieldBoolean)Entries[2]).Value = value;
				}
			}
			
		/// <summary>
        /// WPA
        /// </summary>
		public bool WPA {
			get {
				return ((ObjectFieldBoolean)Entries[3]).Value;
				}
			set {
				((ObjectFieldBoolean)Entries[3]).Value = value;
				}
			}
			
		/// <summary>
        /// WPA2
        /// </summary>
		public bool WPA2 {
			get {
				return ((ObjectFieldBoolean)Entries[4]).Value;
				}
			set {
				((ObjectFieldBoolean)Entries[4]).Value = value;
				}
			}
			
		/// <summary>
        /// WPAEnterprise
        /// </summary>
		public bool WPAEnterprise {
			get {
				return ((ObjectFieldBoolean)Entries[5]).Value;
				}
			set {
				((ObjectFieldBoolean)Entries[5]).Value = value;
				}
			}
			
		/// <summary>
        /// WPA2Enterprise
        /// </summary>
		public bool WPA2Enterprise {
			get {
				return ((ObjectFieldBoolean)Entries[6]).Value;
				}
			set {
				((ObjectFieldBoolean)Entries[6]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldString {Id = "SSID", 
						Label = "SSID" // ((ObjectFieldString)Entries[0]).Value
					    },
			new ObjectFieldSecret {Id = "Password", 
						Label = "Password" // ((ObjectFieldSecret)Entries[1]).Value
					    },
			new ObjectFieldBoolean {Id = "WEP", 
						Label = "WEP" // ((ObjectFieldBoolean)Entries[2]).Value
					    },
			new ObjectFieldBoolean {Id = "WPA", 
						Label = "WPA" // ((ObjectFieldBoolean)Entries[3]).Value
					    },
			new ObjectFieldBoolean {Id = "WPA2", 
						Label = "WPA2" // ((ObjectFieldBoolean)Entries[4]).Value
					    },
			new ObjectFieldBoolean {Id = "WPAEnterprise", 
						Label = "WPA Enterprise" // ((ObjectFieldBoolean)Entries[5]).Value
					    },
			new ObjectFieldBoolean {Id = "WPA2Enterprise", 
						Label = "WPA2 Enterprise" // ((ObjectFieldBoolean)Entries[6]).Value
					    }			} ;
		}


	public partial class Server : _Server{
		}


	public class _Server : Object {

		/// <summary>
        /// Address
        /// </summary>
		public string Address {
			get {
				return ((ObjectFieldString)Entries[0]).Value;
				}
			set {
				((ObjectFieldString)Entries[0]).Value = value;
				}
			}
			
		/// <summary>
        /// Port
        /// </summary>
		public int Port {
			get {
				return ((ObjectFieldInteger)Entries[1]).Value;
				}
			set {
				((ObjectFieldInteger)Entries[1]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldString {Id = "Address", 
						Label = "DNS Address" // ((ObjectFieldString)Entries[0]).Value
					    },
			new ObjectFieldInteger {Id = "Port", 
						Label = "Port" // ((ObjectFieldInteger)Entries[1]).Value
					    }			} ;
		}


	public partial class ServerTLS : _ServerTLS{
		}


	public class _ServerTLS : Server {

		/// <summary>
        /// TLS
        /// </summary>
		public bool TLS {
			get {
				return ((ObjectFieldBoolean)Entries[2]).Value;
				}
			set {
				((ObjectFieldBoolean)Entries[2]).Value = value;
				}
			}
			
		/// <summary>
        /// Root
        /// </summary>
		public string Root {
			get {
				return ((ObjectFieldString)Entries[3]).Value;
				}
			set {
				((ObjectFieldString)Entries[3]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldString {Id = "Address", 
						Label = "DNS Address" // ((ObjectFieldString)Entries[0]).Value
					    },
			new ObjectFieldInteger {Id = "Port", 
						Label = "Port" // ((ObjectFieldInteger)Entries[1]).Value
					    },
			new ObjectFieldBoolean {Id = "TLS", 
						Label = "Require TLS" // ((ObjectFieldBoolean)Entries[2]).Value
					    },
			new ObjectFieldString {Id = "Root", 
						Label = "TLS Root" // ((ObjectFieldString)Entries[3]).Value
					    }			} ;
		}


	public partial class ServerSASL : _ServerSASL{
		}


	public class _ServerSASL : Server {

		/// <summary>
        /// Password
        /// </summary>
		public string Password {
			get {
				return ((ObjectFieldSecret)Entries[2]).Value;
				}
			set {
				((ObjectFieldSecret)Entries[2]).Value = value;
				}
			}
			
		/// <summary>
        /// Auth
        /// </summary>
		public bool Auth {
			get {
				return ((ObjectFieldBoolean)Entries[3]).Value;
				}
			set {
				((ObjectFieldBoolean)Entries[3]).Value = value;
				}
			}
			
		/// <summary>
        /// Schemes
        /// </summary>
		public string Schemes {
			get {
				return ((ObjectFieldString)Entries[4]).Value;
				}
			set {
				((ObjectFieldString)Entries[4]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldString {Id = "Address", 
						Label = "DNS Address" // ((ObjectFieldString)Entries[0]).Value
					    },
			new ObjectFieldInteger {Id = "Port", 
						Label = "Port" // ((ObjectFieldInteger)Entries[1]).Value
					    },
			new ObjectFieldSecret {Id = "Password", 
						Label = "Password" // ((ObjectFieldSecret)Entries[2]).Value
					    },
			new ObjectFieldBoolean {Id = "Auth", 
						Label = "Require Secure Auth" // ((ObjectFieldBoolean)Entries[3]).Value
					    },
			new ObjectFieldString {Id = "Schemes", 
						Label = "Only accept" // ((ObjectFieldString)Entries[4]).Value
					    }			} ;
		}


	public partial class CreateProfile : _CreateProfile{
		}


	public class _CreateProfile : Object {

		/// <summary>
        /// FriendlyName
        /// </summary>
		public string FriendlyName {
			get {
				return ((ObjectFieldString)Entries[0]).Value;
				}
			set {
				((ObjectFieldString)Entries[0]).Value = value;
				}
			}
			
		/// <summary>
        /// PortalAccount
        /// </summary>
		public string PortalAccount {
			get {
				return ((ObjectFieldString)Entries[1]).Value;
				}
			set {
				((ObjectFieldString)Entries[1]).Value = value;
				}
			}
			
		/// <summary>
        /// PortalAddress
        /// </summary>
		public string PortalAddress {
			get {
				return ((ObjectFieldString)Entries[2]).Value;
				}
			set {
				((ObjectFieldString)Entries[2]).Value = value;
				}
			}
			
		/// <summary>
        /// Advanced
        /// </summary>
		public bool Advanced {
			get {
				return ((ObjectFieldOption)Entries[3]).Value;
				}
			set {
				((ObjectFieldOption)Entries[3]).Value = value;
				}
			}
			
		/// <summary>
        /// Harden
        /// </summary>
		public bool Harden {
			get {
				return ((ObjectFieldOption)((ObjectFieldOption)Entries[3]).Entries[0]).Value;
				}
			set {
				((ObjectFieldOption)((ObjectFieldOption)Entries[3]).Entries[0]).Value = value;
				}
			}
			
		/// <summary>
        /// Bits
        /// </summary>
		public int Bits {
			get {
				return ((ObjectFieldInteger)((ObjectFieldOption)((ObjectFieldOption)Entries[3]).Entries[0]).Entries[1]).Value;
				}
			set {
				((ObjectFieldInteger)((ObjectFieldOption)((ObjectFieldOption)Entries[3]).Entries[0]).Entries[1]).Value = value;
				}
			}
			
		/// <summary>
        /// Escrow
        /// </summary>
		public bool Escrow {
			get {
				return ((ObjectFieldOption)((ObjectFieldOption)Entries[3]).Entries[2]).Value;
				}
			set {
				((ObjectFieldOption)((ObjectFieldOption)Entries[3]).Entries[2]).Value = value;
				}
			}
			
		/// <summary>
        /// Shares
        /// </summary>
		public int Shares {
			get {
				return ((ObjectFieldInteger)((ObjectFieldOption)((ObjectFieldOption)Entries[3]).Entries[2]).Entries[3]).Value;
				}
			set {
				((ObjectFieldInteger)((ObjectFieldOption)((ObjectFieldOption)Entries[3]).Entries[2]).Entries[3]).Value = value;
				}
			}
			
		/// <summary>
        /// Quorum
        /// </summary>
		public int Quorum {
			get {
				return ((ObjectFieldInteger)((ObjectFieldOption)((ObjectFieldOption)Entries[3]).Entries[2]).Entries[4]).Value;
				}
			set {
				((ObjectFieldInteger)((ObjectFieldOption)((ObjectFieldOption)Entries[3]).Entries[2]).Entries[4]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldString {Id = "FriendlyName", 
						Label = "Identifier" // ((ObjectFieldString)Entries[0]).Value
					    },
			new ObjectFieldString {Id = "PortalAccount", 
						Label = "Account Name" // ((ObjectFieldString)Entries[1]).Value
					    },
			new ObjectFieldString {Id = "PortalAddress", 
						Label = "Portal Address" // ((ObjectFieldString)Entries[2]).Value
					    },	
			new ObjectFieldOption {
						Id = "Advanced",  
						Label = "Advanced Options",
						Entries = new List<ObjectEntry> {	
				new ObjectFieldOption {
							Id = "Harden",  
							Label = "Strong Fingerprint",
							Entries = new List<ObjectEntry> {
					new ObjectFieldInteger {Id = "Bits", 
								Label = "Number of Bits" // ((ObjectFieldInteger)((ObjectFieldOption)((ObjectFieldOption)Entries[3]).Entries[0]).Entries[1]).Value
							    },
					new ObjectText {
								Text = "A strong fingerprint is generated by generating master keys until  a master key matching a certain pattern is found. This increases the  difficulty of breaking the fingerprint by 'brute force' but only by the same amount of effort that was put into generating it."
								}
								}
							},	
				new ObjectFieldOption {
							Id = "Escrow",  
							Label = "Escrow Keys",
							Entries = new List<ObjectEntry> {
					new ObjectFieldInteger {Id = "Shares", 
								Label = "Number of Key Shares" // ((ObjectFieldInteger)((ObjectFieldOption)((ObjectFieldOption)Entries[3]).Entries[2]).Entries[3]).Value
							    },
					new ObjectFieldInteger {Id = "Quorum", 
								Label = "Number of shares required for recovery" // ((ObjectFieldInteger)((ObjectFieldOption)((ObjectFieldOption)Entries[3]).Entries[2]).Entries[4]).Value
							    },
					new ObjectText {
								Text = "Creating an escrow record for the Master Key allows it to be  recovered should the need arise."
								}
								}
							}
							}
						}			} ;
		}


	public partial class SelectApplications : _SelectApplications{
		}


	public class _SelectApplications : Object {


		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectText {
						Text = "Which applications do you want to use the Mesh to secure?"
						},
			new ObjectText {
						Text = "(You can always add or remove applications later on.)"
						},
			new ObjectCommand {
						Id = "SecureEmail",  
						Label = "Configure"},
			new ObjectCommand {
						Id = "SecureSSH",  
						Label = "Configure"},
			new ObjectCommand {
						Id = "SecureWeb",  
						Label = "Configure"},
			new ObjectCommand {
						Id = "SecureNetwork",  
						Label = "Configure"}			} ;
		}


	public partial class SelectAccountsEmail : _SelectAccountsEmail{
		}


	public class _SelectAccountsEmail : Object {

		public enum EnumSelection {
			All  /* Use same security settings for all accounts */
,
			Choose  /* Let me choose options for each account */
			};
		public EnumSelection Selection;
		/// <summary>
        /// Accounts
        /// </summary>
		public List<Goedel.Trojan.Object> Accounts {
			get {
				return ((ObjectFieldList)Entries[1]).Value;
				}
			set {
				((ObjectFieldList)Entries[1]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectText {
						Text = "The following accounts were discovered on your computer."
						},
			new ObjectFieldEnumerate {
						Id = "Selection",  
						Label = "Security settings",
						Entries = new List<ObjectEntry> {
				new ObjectFieldRadio {Id = "All", 
							Label = "Use same security settings for all accounts" // ((ObjectFieldRadio)((ObjectFieldEnumerate)Entries[0]).Entries[0]).Value
						    },
				new ObjectFieldRadio {Id = "Choose", 
							Label = "Let me choose options for each account" // ((ObjectFieldRadio)((ObjectFieldEnumerate)Entries[0]).Entries[1]).Value
						    }
							}
						},
			new ObjectFieldList {Id = "Accounts", 
						Label = "Email Accounts" // ((ObjectFieldList)Entries[1]).Value
					    }			} ;
		}


	public partial class EmailAccounts : _EmailAccounts{
		}


	public class _EmailAccounts : Object {

		/// <summary>
        /// Address
        /// </summary>
		public string Address {
			get {
				return ((ObjectFieldString)Entries[0]).Value;
				}
			set {
				((ObjectFieldString)Entries[0]).Value = value;
				}
			}
			
		/// <summary>
        /// Application
        /// </summary>
		public string Application {
			get {
				return ((ObjectFieldString)Entries[1]).Value;
				}
			set {
				((ObjectFieldString)Entries[1]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldString {Id = "Address", 
						Label = "Address" // ((ObjectFieldString)Entries[0]).Value
					    },
			new ObjectFieldString {Id = "Application", 
						Label = "Application" // ((ObjectFieldString)Entries[1]).Value
					    }			} ;
		}


	public partial class EmailOptions : _EmailOptions{
		}


	public class _EmailOptions : Object {

		/// <summary>
        /// Account
        /// </summary>
		public string Account {
			get {
				return ((ObjectFieldString)Entries[0]).Value;
				}
			set {
				((ObjectFieldString)Entries[0]).Value = value;
				}
			}
			
		/// <summary>
        /// Application
        /// </summary>
		public string Application {
			get {
				return ((ObjectFieldString)Entries[1]).Value;
				}
			set {
				((ObjectFieldString)Entries[1]).Value = value;
				}
			}
			
		/// <summary>
        /// UseOpenPGP
        /// </summary>
		public bool UseOpenPGP {
			get {
				return ((ObjectFieldOption)Entries[2]).Value;
				}
			set {
				((ObjectFieldOption)Entries[2]).Value = value;
				}
			}
			
		/// <summary>
        /// PublishPGPMesh
        /// </summary>
		public bool PublishPGPMesh {
			get {
				return ((ObjectFieldBoolean)((ObjectFieldOption)Entries[2]).Entries[0]).Value;
				}
			set {
				((ObjectFieldBoolean)((ObjectFieldOption)Entries[2]).Entries[0]).Value = value;
				}
			}
			
		/// <summary>
        /// PublishPGPKeyRing
        /// </summary>
		public bool PublishPGPKeyRing {
			get {
				return ((ObjectFieldBoolean)((ObjectFieldOption)Entries[2]).Entries[1]).Value;
				}
			set {
				((ObjectFieldBoolean)((ObjectFieldOption)Entries[2]).Entries[1]).Value = value;
				}
			}
			
		/// <summary>
        /// EscrowPGP
        /// </summary>
		public bool EscrowPGP {
			get {
				return ((ObjectFieldBoolean)((ObjectFieldOption)Entries[2]).Entries[2]).Value;
				}
			set {
				((ObjectFieldBoolean)((ObjectFieldOption)Entries[2]).Entries[2]).Value = value;
				}
			}
			
		/// <summary>
        /// UseSMIME
        /// </summary>
		public bool UseSMIME {
			get {
				return ((ObjectFieldOption)Entries[3]).Value;
				}
			set {
				((ObjectFieldOption)Entries[3]).Value = value;
				}
			}
			
		/// <summary>
        /// SMIMECA
        /// </summary>
		public string SMIMECA {
			get {
				return ((ObjectFieldString)((ObjectFieldOption)Entries[3]).Entries[3]).Value;
				}
			set {
				((ObjectFieldString)((ObjectFieldOption)Entries[3]).Entries[3]).Value = value;
				}
			}
			
		/// <summary>
        /// EscrowSMIME
        /// </summary>
		public bool EscrowSMIME {
			get {
				return ((ObjectFieldBoolean)((ObjectFieldOption)Entries[3]).Entries[4]).Value;
				}
			set {
				((ObjectFieldBoolean)((ObjectFieldOption)Entries[3]).Entries[4]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldString {Id = "Account", 
						Label = "Account" // ((ObjectFieldString)Entries[0]).Value
					    },
			new ObjectFieldString {Id = "Application", 
						Label = "Application" // ((ObjectFieldString)Entries[1]).Value
					    },	
			new ObjectFieldOption {
						Id = "UseOpenPGP",  
						Label = "Create keys for OpenPGP",
						Entries = new List<ObjectEntry> {
				new ObjectFieldBoolean {Id = "PublishPGPMesh", 
							Label = "Publish public key to the Mesh" // ((ObjectFieldBoolean)((ObjectFieldOption)Entries[2]).Entries[0]).Value
						    },
				new ObjectFieldBoolean {Id = "PublishPGPKeyRing", 
							Label = "Publish public key to OpenPGP key servers" // ((ObjectFieldBoolean)((ObjectFieldOption)Entries[2]).Entries[1]).Value
						    },
				new ObjectFieldBoolean {Id = "EscrowPGP", 
							Label = "Use personal escrow key to safeguard key" // ((ObjectFieldBoolean)((ObjectFieldOption)Entries[2]).Entries[2]).Value
						    }
							}
						},	
			new ObjectFieldOption {
						Id = "UseSMIME",  
						Label = "Create keys for S/MIME",
						Entries = new List<ObjectEntry> {
				new ObjectFieldString {Id = "SMIMECA", 
							Label = "DNS address of CA" // ((ObjectFieldString)((ObjectFieldOption)Entries[3]).Entries[3]).Value
						    },
				new ObjectFieldBoolean {Id = "EscrowSMIME", 
							Label = "Use personal escrow key to safeguard key" // ((ObjectFieldBoolean)((ObjectFieldOption)Entries[3]).Entries[4]).Value
						    }
							}
						}			} ;
		}


	public partial class WebOptions : _WebOptions{
		}


	public class _WebOptions : Object {

		public enum EnumSelection {
			Both  /* Use the Mesh to store Web passwords and bookmarks */
,
			Password  /* Use the Mesh to store Web passwords */
,
			Bookmark  /* Use the Mesh to store Web bookmarks */
,
			Neither  /* Don't use the Mesh to store Web data */
			};
		public EnumSelection Selection;

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldEnumerate {
						Id = "Selection",  
						Label = "",
						Entries = new List<ObjectEntry> {
				new ObjectFieldRadio {Id = "Both", 
							Label = "Use the Mesh to store Web passwords and bookmarks" // ((ObjectFieldRadio)((ObjectFieldEnumerate)Entries[0]).Entries[0]).Value
						    },
				new ObjectFieldRadio {Id = "Password", 
							Label = "Use the Mesh to store Web passwords" // ((ObjectFieldRadio)((ObjectFieldEnumerate)Entries[0]).Entries[1]).Value
						    },
				new ObjectFieldRadio {Id = "Bookmark", 
							Label = "Use the Mesh to store Web bookmarks" // ((ObjectFieldRadio)((ObjectFieldEnumerate)Entries[0]).Entries[2]).Value
						    },
				new ObjectFieldRadio {Id = "Neither", 
							Label = "Don't use the Mesh to store Web data" // ((ObjectFieldRadio)((ObjectFieldEnumerate)Entries[0]).Entries[3]).Value
						    }
							}
						}			} ;
		}


	public partial class NetworkOptions : _NetworkOptions{
		}


	public class _NetworkOptions : Object {

		/// <summary>
        /// DNS1
        /// </summary>
		public string DNS1 {
			get {
				return ((ObjectFieldString)Entries[0]).Value;
				}
			set {
				((ObjectFieldString)Entries[0]).Value = value;
				}
			}
			
		/// <summary>
        /// DNS2
        /// </summary>
		public string DNS2 {
			get {
				return ((ObjectFieldString)Entries[1]).Value;
				}
			set {
				((ObjectFieldString)Entries[1]).Value = value;
				}
			}
			
		/// <summary>
        /// Scope
        /// </summary>
		public string Scope {
			get {
				return ((ObjectFieldString)Entries[2]).Value;
				}
			set {
				((ObjectFieldString)Entries[2]).Value = value;
				}
			}
			
		/// <summary>
        /// RequireSecurity
        /// </summary>
		public bool RequireSecurity {
			get {
				return ((ObjectFieldOption)Entries[3]).Value;
				}
			set {
				((ObjectFieldOption)Entries[3]).Value = value;
				}
			}
			
		/// <summary>
        /// SecurityConfig
        /// </summary>
		public string SecurityConfig {
			get {
				return ((ObjectFieldString)((ObjectFieldOption)Entries[3]).Entries[0]).Value;
				}
			set {
				((ObjectFieldString)((ObjectFieldOption)Entries[3]).Entries[0]).Value = value;
				}
			}
			
		/// <summary>
        /// DNSTLS
        /// </summary>
		public bool DNSTLS {
			get {
				return ((ObjectFieldBoolean)((ObjectFieldOption)Entries[3]).Entries[1]).Value;
				}
			set {
				((ObjectFieldBoolean)((ObjectFieldOption)Entries[3]).Entries[1]).Value = value;
				}
			}
			
		/// <summary>
        /// DNSPrivate
        /// </summary>
		public bool DNSPrivate {
			get {
				return ((ObjectFieldBoolean)((ObjectFieldOption)Entries[3]).Entries[2]).Value;
				}
			set {
				((ObjectFieldBoolean)((ObjectFieldOption)Entries[3]).Entries[2]).Value = value;
				}
			}
			
		/// <summary>
        /// TrustRoot
        /// </summary>
		public string TrustRoot {
			get {
				return ((ObjectFieldString)((ObjectFieldOption)Entries[3]).Entries[3]).Value;
				}
			set {
				((ObjectFieldString)((ObjectFieldOption)Entries[3]).Entries[3]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldString {Id = "DNS1", 
						Label = "DNS server 1" // ((ObjectFieldString)Entries[0]).Value
					    },
			new ObjectFieldString {Id = "DNS2", 
						Label = "DNS server 2" // ((ObjectFieldString)Entries[1]).Value
					    },
			new ObjectFieldString {Id = "Scope", 
						Label = "Restrict scope to domains" // ((ObjectFieldString)Entries[2]).Value
					    },	
			new ObjectFieldOption {
						Id = "RequireSecurity",  
						Label = "Require Security",
						Entries = new List<ObjectEntry> {
				new ObjectFieldString {Id = "SecurityConfig", 
							Label = "Security policy" // ((ObjectFieldString)((ObjectFieldOption)Entries[3]).Entries[0]).Value
						    },
				new ObjectFieldBoolean {Id = "DNSTLS", 
							Label = "Allow DNS over TLS" // ((ObjectFieldBoolean)((ObjectFieldOption)Entries[3]).Entries[1]).Value
						    },
				new ObjectFieldBoolean {Id = "DNSPrivate", 
							Label = "Allow Private DNS" // ((ObjectFieldBoolean)((ObjectFieldOption)Entries[3]).Entries[2]).Value
						    },
				new ObjectFieldString {Id = "TrustRoot", 
							Label = "DNS Root of Trust" // ((ObjectFieldString)((ObjectFieldOption)Entries[3]).Entries[3]).Value
						    }
							}
						}			} ;
		}


	public partial class Review : _Review{
		}


	public class _Review : Object {

		/// <summary>
        /// Fingerprint
        /// </summary>
		public string Fingerprint {
			get {
				return ((ObjectFieldString)Entries[0]).Value;
				}
			set {
				((ObjectFieldString)Entries[0]).Value = value;
				}
			}
			
		/// <summary>
        /// MeshPortal
        /// </summary>
		public string MeshPortal {
			get {
				return ((ObjectFieldString)Entries[1]).Value;
				}
			set {
				((ObjectFieldString)Entries[1]).Value = value;
				}
			}
			
		/// <summary>
        /// Escrow
        /// </summary>
		public bool Escrow {
			get {
				return ((ObjectFieldOption)Entries[2]).Value;
				}
			set {
				((ObjectFieldOption)Entries[2]).Value = value;
				}
			}
			
		/// <summary>
        /// Quorum
        /// </summary>
		public string Quorum {
			get {
				return ((ObjectFieldString)((ObjectFieldOption)Entries[2]).Entries[0]).Value;
				}
			set {
				((ObjectFieldString)((ObjectFieldOption)Entries[2]).Entries[0]).Value = value;
				}
			}
			
		/// <summary>
        /// Shares
        /// </summary>
		public List<Goedel.Trojan.Object> Shares {
			get {
				return ((ObjectFieldList)((ObjectFieldOption)Entries[2]).Entries[1]).Value;
				}
			set {
				((ObjectFieldList)((ObjectFieldOption)Entries[2]).Entries[1]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldString {Id = "Fingerprint", 
						Label = "Master Fingerprint" // ((ObjectFieldString)Entries[0]).Value
					    },
			new ObjectFieldString {Id = "MeshPortal", 
						Label = "Mesh Portal" // ((ObjectFieldString)Entries[1]).Value
					    },	
			new ObjectFieldOption {
						Id = "Escrow",  
						Label = "Escrow encryption keys",
						Entries = new List<ObjectEntry> {
				new ObjectFieldString {Id = "Quorum", 
							Label = "Quorum" // ((ObjectFieldString)((ObjectFieldOption)Entries[2]).Entries[0]).Value
						    },
				new ObjectFieldList {Id = "Shares", 
							Label = "Shares" // ((ObjectFieldList)((ObjectFieldOption)Entries[2]).Entries[1]).Value
						    }
							}
						}			} ;
		}


	public partial class Share : _Share{
		}


	public class _Share : Object {

		/// <summary>
        /// Number
        /// </summary>
		public int Number {
			get {
				return ((ObjectFieldInteger)Entries[0]).Value;
				}
			set {
				((ObjectFieldInteger)Entries[0]).Value = value;
				}
			}
			
		/// <summary>
        /// Share
        /// </summary>
		public string Share {
			get {
				return ((ObjectFieldString)Entries[1]).Value;
				}
			set {
				((ObjectFieldString)Entries[1]).Value = value;
				}
			}
			

		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectFieldInteger {Id = "Number", 
						Label = "Number" // ((ObjectFieldInteger)Entries[0]).Value
					    },
			new ObjectFieldString {Id = "Share", 
						Label = "Share" // ((ObjectFieldString)Entries[1]).Value
					    }			} ;
		}


	public partial class Finish : _Finish{
		}


	public class _Finish : Object {


		public override List<ObjectEntry> Entries {
            get { return _Entries; }
            set { _Entries = value; }
            }

		List<ObjectEntry> _Entries = new List<ObjectEntry> {

			new ObjectText {
						Text = "Success! The profile was accepted by the mesh portal."
						}			} ;
		}





	}

